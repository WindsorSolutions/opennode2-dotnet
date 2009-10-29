namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_15
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("name", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class Property
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public nameType name;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class TransactionHeader
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class Contact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string MiddleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class Telephone
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ContactAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class EffluentTradePartnerAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LocationProvince;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LocationAddress))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class FacilityLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationZipCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LocationAddress : FacilityLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OrganizationDUNSNumber;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UnpermittedFacility))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4SmallPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4ProgramReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWIndustrialPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWConstructionPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWMS4LargePermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(POTWPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOMonthlyEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPerformanceSummary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MasterGeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LocalLimitsProgramReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GeneralPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOEventReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOAnnualReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BiosolidsProgramReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BasicPermit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Facility))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProgramInspectionKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEventKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEvent))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermittedFeatureKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermittedFeature))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleEventViolationKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitScheduleKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NarrativeConditionKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NarrativeCondition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSetKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSet))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimitKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimits))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Limits))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitDates))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartnerKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartner))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolationKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReportKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRProgramReportLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleEventViolationKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageToOtherInspection))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class UnpermittedFacility : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public FacilityLocation FacilityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermitCommentsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWMS4SmallPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWaterBodyName", Order = 0)]
        public string[] StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReceivingMS4Name", Order = 1)]
        public string[] ReceivingMS4Name;

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
        public string LegalEntityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string MS4PermitClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MS4TypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string MS4AcreageCoveredNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string MS4PopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string UrbanizedAreaIncorporatedPlaceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string ProjectSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string QualifyingLocalProgramIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string QualifyingLocalProgramDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string SharedResponsibilitiesIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string SharedResponsibilitiesDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public GPCFConstructionWaiver GPCFConstructionWaiver;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 27)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("MajorOutfallEstimatedMeasureIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class StormWaterContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWMS4ProgramReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime StormWaterMS4ReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectedSourcesOfFundingCode", Order = 5)]
        public string[] ProjectedSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 10)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWIndustrialPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWaterBodyName", Order = 0)]
        public string[] StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReceivingMS4Name", Order = 1)]
        public string[] ReceivingMS4Name;

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
        public GPCFNoticeOfIntent GPCFNoticeOfIntent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public GPCFNoticeOfTermination GPCFNoticeOfTermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public GPCFNoExposure GPCFNoExposure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 10)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string IndustrialActivitySize;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWEventReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime DateStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string RainfallStormEventSampledNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string DurationStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string VolumeDischargeSample;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string DurationSinceLastStormEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public SamplingBasisType SamplingBasisIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SamplingBasisIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public PrecipitationFormType PrecipitationForm;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrecipitationFormSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string SampleTakenWithinTimeframeIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string TimeExceedanceRationaleCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string EssentiallyIdenticalOutfallNotification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string MonitoringExemptionRationaleIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string PollutantMonitoringBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 13)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("SamplingBasisIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("PrecipitationForm", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWConstructionPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWaterBodyName", Order = 0)]
        public string[] StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReceivingMS4Name", Order = 1)]
        public string[] ReceivingMS4Name;

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
        public GPCFNoticeOfIntent GPCFNoticeOfIntent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public GPCFNoticeOfTermination GPCFNoticeOfTermination;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string ProjectTypeCodeOtherDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string ProjectPlanSizeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 15)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWMS4LargePermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWaterBodyName", Order = 0)]
        public string[] StateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReceivingMS4Name", Order = 1)]
        public string[] ReceivingMS4Name;

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
        public string LegalEntityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string MS4PermitClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string MS4TypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string MS4AcreageCoveredNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string MS4PopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string UrbanizedAreaIncorporatedPlaceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string MS4AnnualExpenditureDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string MS4AnnualExpenditureYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string MS4BudgetDollars;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string MS4BudgetYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string ProjectSourcesOfFundingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public EstimatedMeasuredType MajorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MajorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string MajorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public EstimatedMeasuredType MinorOutfallEstimatedMeasureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinorOutfallEstimatedMeasureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string MinorOutfallNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 22)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class POTWPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SSCSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CombinedSSCSSystemLength;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SatelliteCollectionSystem", Order = 2)]
        public SatelliteCollectionSystem[] SatelliteCollectionSystem;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SatelliteCollectionSystem
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SatelliteCollectionSystemIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SatelliteCollectionSystemName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SSOMonthlyEventReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime SSOMonthlyReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SSOMonthlyEventMonth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SSOMonthlyEventYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NumberSSOEventsReachUSWatersPerMonth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string VolumeSSOEventsReachUSWatersPerMonth;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SSOEventReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CauseOfSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LatitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("LongitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("SSOOverflowLocationStreet", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 3)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType4[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DurationOfSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SSOVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string NameOfReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpactOfSSOEvent", Order = 7)]
        public string[] ImpactOfSSOEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSystemComponent", Order = 8)]
        public SSOSystemComponent[] SSOSystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSteps", Order = 9)]
        public SSOSteps[] SSOSteps;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DescriptionOfStepsTaken;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {

        /// <remarks/>
        LatitudeMeasure,

        /// <remarks/>
        LongitudeMeasure,

        /// <remarks/>
        SSOOverflowLocationStreet,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SSOSystemComponent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherSystemComponent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SSOSteps
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StepsToReducePreventMitigate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string OtherStepsToReducePreventMitigate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SSOAnnualReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime SSOAnnualReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SSOAnnualReportYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NumberSSOEventsPerYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string VolumeSSOEventsPerYear;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PretreatmentPerformanceSummary : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PretreatmentPerformanceSummaryStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string SUOReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string SUODate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string AcceptanceOfHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string AcceptanceOfNonhazardousIndustrialWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string AcceptanceOfHauledDomesticWastes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string AnnualPretreatmentBudget;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string InadequacyOfSamplingInspectionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string AdequacyOfPretreatmentResources;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DeficienciesIdentifiedDuringIUFileReview;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string ControlMechanismDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string LegalAuthorityDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string DeficienciesInInterpretationApplicationPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string DeficienciesDataManagementPublicParticipation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string ViolationIUScheduleForRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string FormalResponseViolationIUScheduleForRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string AnnualFrequencyInfluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string AnnualFrequencyEffluentToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string AnnualFrequencySludgeToxicantSampling;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string NumberOfSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string SIUsWithoutControlMechanism;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string SIUsNotInspected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string SIUsNotSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string SIUsOnSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string SIUsSNCWithPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string SIUsSNCWithReportingRequirements;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string SIUsSNCWithPretreatmentSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string SIUsSNCPublishedInNewspaper;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string ViolationNoticesIssuedToSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string AdministrativeOrdersIssuedToSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string CivilSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public string CriminalSuitsFiledAgainstSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public string DollarAmountPenaltiesCollected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string IUsWhichPenaltiesHaveBeenCollected;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string NumberOfCIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string CIUsInSNC;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public string PassThroughInterferenceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public LocalLimits LocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        public RemovalCredits RemovalCredits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LocalLimits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string MostRecentDateTechnicalEvalForLocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MostRecentDateAdoptionTechnicallyBasedLocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocalLimitsPollutantCode", Order = 2)]
        public string[] LocalLimitsPollutantCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PretreatmentPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PretreatmentProgramRequiredIndicatorCode;

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
        [System.Xml.Serialization.XmlElementAttribute("PretreatmentContact", Order = 5)]
        public PretreatmentContact[] PretreatmentContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PretreatmentContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class MasterGeneralPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public BatchApplyFlagType BatchApplyFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchApplyFlagSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 10)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 11)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 13)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 14)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MasterGeneralPermitContact", Order = 21)]
        public MasterGeneralPermitContact[] MasterGeneralPermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string GeneralPermitIndustrialCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string PermitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitComponentTypeCode", Order = 24)]
        public string[] PermitComponentTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("BatchApplyFlag", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public enum BatchApplyFlagType
    {

        /// <remarks/>
        R,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class OtherPermits
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class AssociatedPermit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AssociatedPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AssociatedPermitReasonCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SICCodeDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SICPrimaryIndicatorCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class NAICSCodeDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NAICSPrimaryIndicatorCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class MasterGeneralPermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public Contact Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LocalLimitsProgramReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime PermittingAuthorityReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public LocalLimits LocalLimits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public RemovalCredits RemovalCredits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class GeneralPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string AssociatedMasterGeneralPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public BatchApplyFlagType BatchApplyFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchApplyFlagSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string PermitExpirationDate;

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
        public string TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public Permittee Permittee;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public FacilityLocation FacilityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RNCStatus", Order = 29)]
        public RNCStatus[] RNCStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 32)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitContact", Order = 38)]
        public PermitContact[] PermitContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class Permittee
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class RNCStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string RNCStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string RNCStatusCodeQuarter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string RNCManualStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CorrectedRNCManualStatusCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("LimitSetStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CSOPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CSSPopulationServedNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CombinedSewerSystemLength;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string CollectionSystemCombinedPercent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SatelliteCollectionSystem", Order = 3)]
        public SatelliteCollectionSystem[] SatelliteCollectionSystem;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CSOEventReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime CSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public WetDryType DryOrWetWeatherIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DryOrWetWeatherIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CSOOverflowLocationStreet", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("LatitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("LongitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureIdentifier", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 3)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DurationOfCSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string DischargeVolumeTreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string DischargeVolumeUntreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string CorrectiveActionTakenDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string InchesOfPrecipitation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("DryOrWetWeatherIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {

        /// <remarks/>
        CSOOverflowLocationStreet,

        /// <remarks/>
        LatitudeMeasure,

        /// <remarks/>
        LongitudeMeasure,

        /// <remarks/>
        PermittedFeatureIdentifier,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CAFOPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CAFOClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOContact", Order = 1)]
        public CAFOContact[] CAFOContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string IsAnimalFacilityTypeCAFOIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CAFODesignationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string CAFODesignationReasonText;

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
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string LegalDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CAFOContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ReportedAnimalType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ManureLitterProcessedWastewaterStorage
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class Containment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CAFOAnnualReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime PermittingAuthorityReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public DischargesFromProductionAreaType DischargesDuringYearFromProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DischargesDuringYearFromProductionAreaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportedAnimalType", Order = 2)]
        public ReportedAnimalType[] ReportedAnimalType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string SolidManureLitterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LiquidManureWastewaterGeneratedAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SolidManureLitterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string LiquidManureWastewaterTransferAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string NMPDevelopedCertifiedPlannerApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string TotalNumberAcresNMPIdentified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string TotalNumberAcresUsedLandApplication;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("DischargesDuringYearFromProductionAreaIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
        [System.Xml.Serialization.XmlElementAttribute("BiosolidsPermitContact", Order = 15)]
        public BiosolidsPermitContact[] BiosolidsPermitContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class BiosolidsPermitContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class BiosolidsProgramReport : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime ReportCoverageEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumberOfReportUnits;

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
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string AnnualLoadingParameterDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string AnnualLoadingOfBiosolidGallons;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string AnnualLoadingOfBiosolidDMT;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string AnnualLoadingOfNutrientNitrogen;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string AnnualLoadingOfNutrientPhosphorus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string TotalNumberLandApplicationViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string TotalNumberIncineratorViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string TotalNumberDistributionMarketingViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string TotalNumberSludgeRelatedManagementPracticeViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string TotalNumberSurfaceDisposalViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string TotalNumberOtherSludgeViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string TotalNumberCodisposalViolations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string BiosolidsReportComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class BasicPermit : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public BatchApplyFlagType BatchApplyFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchApplyFlagSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PermitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string PermitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string PermitExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string ReissuancePriorityPermitIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string BacklogReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string PermitIssuingOrganizationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OtherPermits", Order = 10)]
        public OtherPermits[] OtherPermits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPermit", Order = 11)]
        public AssociatedPermit[] AssociatedPermit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string PermitAppealedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 13)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 14)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string PermitUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string PermitUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public string PermitUserDefinedDataElement3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string PermitUserDefinedDataElement4Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string PermitUserDefinedDataElement5Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string PermitCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string MajorMinorRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string TotalApplicationDesignFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string TotalApplicationAverageFlowNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public Permittee Permittee;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public FacilityLocation FacilityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string ApplicationReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string PermitApplicationCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RNCStatus", Order = 28)]
        public RNCStatus[] RNCStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string NewSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public ComplianceTrackingStatus ComplianceTrackingStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EffluentGuidelineCode", Order = 31)]
        public string[] EffluentGuidelineCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
        public string PermitStateWaterBodyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public string PermitStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 34)]
        public string FederalGrantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        public string DMRCognizantOfficial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        public string DMRCognizantOfficialTelephoneNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitContact", Order = 37)]
        public PermitContact[] PermitContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        public string SignificantIUIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        public string ReceivingPermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class Facility : BasicPermitKeyElements
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LocationStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string LocationZipCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string LocationCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string OrganizationDUNSNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string StateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string StateRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string FacilityCongressionalDistrictNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityClassification", Order = 11)]
        public string[] FacilityClassification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string FacilitySmallBusinessIndicator;

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
        public string FacilityEnvironmentalJusticeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string TribalLandCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string ConstructionProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string ConstructionProjectLatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string ConstructionProjectLongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SICCodeDetails", Order = 23)]
        public SICCodeDetails[] SICCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NAICSCodeDetails", Order = 24)]
        public NAICSCodeDetails[] NAICSCodeDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public string SectionTownshipRange;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        public string FacilityComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string FacilityUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string FacilityUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        public string FacilityUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        public string FacilityUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        public string FacilityUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityContact", Order = 32)]
        public FacilityContact[] FacilityContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 33)]
        public GeographicCoordinates GeographicCoordinates;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class FacilityContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SingleEventViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SingleEventKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SingleEventViolation : SingleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SingleEventViolationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SingleEventViolationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string RNCDetectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string RNCDetectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string RNCResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string RNCResolutionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SingleEventUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SingleEventUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string SingleEventUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string SingleEventUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string SingleEventUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string SingleEventCommentText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SWInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SSOInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PretreatmentInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CSOInspection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoringLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CAFOInspection))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ProgramInspectionKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 0)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringDate", typeof(System.DateTime), DataType = "date", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringPlannedEndDate", typeof(System.DateTime), DataType = "date", Order = 1)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public System.DateTime Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        ComplianceMonitoringDate,

        /// <remarks/>
        ComplianceMonitoringPlannedEndDate,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWInspection : ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public StormWaterUnpermittedConstructionInspection StormWaterUnpermittedConstructionInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public StormWaterConstructionIndustrialInspection StormWaterConstructionIndustrialInspection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public StormWaterMS4Inspection StormWaterMS4Inspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class StormWaterUnpermittedConstructionInspection
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ProjectTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ProjectTypeCodeOtherDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EstimatedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string EstimatedCompleteDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string EstimatedAreaDisturbedAcresNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ProjectPlanSizeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
        [System.Xml.Serialization.XmlElementAttribute("ProjectedSourcesOfFundingCode", Order = 4)]
        public string[] ProjectedSourcesOfFundingCode;

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
        [System.Xml.Serialization.XmlElementAttribute("StormWaterContact", Order = 9)]
        public StormWaterContact[] StormWaterContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SSOInspection : ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SSOEventDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string CauseOfSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LatitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("LongitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("SSOOverflowLocationStreet", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 3)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DurationOfSSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SSOVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string NameOfReceivingWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImpactOfSSOEvent", Order = 7)]
        public string[] ImpactOfSSOEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSystemComponent", Order = 8)]
        public SSOSystemComponent[] SSOSystemComponent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SSOSteps", Order = 9)]
        public SSOSteps[] SSOSteps;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DescriptionOfStepsTaken;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        LatitudeMeasure,

        /// <remarks/>
        LongitudeMeasure,

        /// <remarks/>
        SSOOverflowLocationStreet,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PretreatmentInspection : ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SUOReference;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string SUODate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AcceptanceOfHazardousWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string AcceptanceOfNonhazardousIndustrialWaste;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string AcceptanceOfHauledDomesticWastes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string AnnualPretreatmentBudget;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string InadequacyOfSamplingInspectionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string AdequacyOfPretreatmentResources;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string DeficienciesIdentifiedDuringIUFileReview;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string ControlMechanismDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string LegalAuthorityDeficiencies;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string DeficienciesInInterpretationApplicationPretreatmentStandards;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string DeficienciesDataManagementPublicParticipation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string ViolationIUScheduleForRemedialMeasures;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string FormalResponseViolationIUScheduleForRemedialMeasures;

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
        public string NumberOfSIUs;

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
        public string SIUsSNCPublishedInNewspaper;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        public string ViolationNoticesIssuedToSIUs;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        public string AdministrativeOrdersIssuedToSIUs;

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
        public string NumberOfCIUs;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CSOInspection : ProgramInspectionKeyElements
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
        [System.Xml.Serialization.XmlElementAttribute("CSOOverflowLocationStreet", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("LatitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("LongitudeMeasure", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("PermittedFeatureIdentifier", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 3)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string DurationOfCSOOverflowEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string DischargeVolumeTreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string DischargeVolumeUntreated;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string CorrectiveActionTakenDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string InchesOfPrecipitation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        CSOOverflowLocationStreet,

        /// <remarks/>
        LatitudeMeasure,

        /// <remarks/>
        LongitudeMeasure,

        /// <remarks/>
        PermittedFeatureIdentifier,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ComplianceMonitoringLinkage : ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToSingleEvent", Order = 0)]
        public LinkageToSingleEvent[] LinkageToSingleEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToEnforcementAction", Order = 1)]
        public LinkageToEnforcementAction[] LinkageToEnforcementAction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToBiosolidsReport", Order = 2)]
        public LinkageToBiosolidsReport[] LinkageToBiosolidsReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToCAFOAnnualReport", Order = 3)]
        public LinkageToCAFOAnnualReport[] LinkageToCAFOAnnualReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToCSOEventReport", Order = 4)]
        public LinkageToCSOEventReport[] LinkageToCSOEventReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToLocalLimitsReport", Order = 5)]
        public LinkageToLocalLimitsReport[] LinkageToLocalLimitsReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToPretreatmentPerformanceReport", Order = 6)]
        public LinkageToPretreatmentPerformanceReport[] LinkageToPretreatmentPerformanceReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToSSOEventReport", Order = 7)]
        public LinkageToSSOEventReport[] LinkageToSSOEventReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToSSOMonthlyEventReport", Order = 8)]
        public LinkageToSSOMonthlyEventReport[] LinkageToSSOMonthlyEventReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToSSOAnnualReport", Order = 9)]
        public LinkageToSSOAnnualReport[] LinkageToSSOAnnualReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToSWEventReport", Order = 10)]
        public LinkageToSWEventReport[] LinkageToSWEventReport;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToSWMS4Report", Order = 11)]
        public LinkageToSWMS4Report[] LinkageToSWMS4Report;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinkageToOtherInspection", Order = 12)]
        public LinkageToOtherInspection[] LinkageToOtherInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToSingleEvent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToEnforcementAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToBiosolidsReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ReportCoverageEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToCAFOAnnualReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToCSOEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime CSOEventDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToLocalLimitsReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime PermittingAuthorityReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToPretreatmentPerformanceReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToSSOEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SSOEventDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToSSOMonthlyEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SSOMonthlyReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToSSOAnnualReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SSOAnnualReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToSWEventReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime DateStormEventSampled;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToSWMS4Report
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime StormWaterMS4ReportReceivedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LinkageToOtherInspection : ComplianceMonitoringKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceMonitoring))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkageToOtherInspection))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ComplianceMonitoringKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceInspectionTypeCode", Order = 0)]
        public string[] ComplianceInspectionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ComplianceMonitoringPlannedEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringPlannedEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ComplianceMonitoringDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceMonitoringDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ComplianceMonitoring : ComplianceMonitoringKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ComplianceMonitoringPlannedStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ComplianceMonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ComplianceMonitoringActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string BiomonitoringInspectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringActionReasonCode", Order = 4)]
        public string[] ComplianceMonitoringActionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringAgencyTypeCode", Order = 5)]
        public string[] ComplianceMonitoringAgencyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string ComplianceMonitoringAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string StateStatuteViolatedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string EPAAssistanceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public StateFederalJointType StateFederalJointIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StateFederalJointIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string JointInspectionReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public LeadPartyType LeadParty;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadPartySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string NumberDaysPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string NumberHoursPhysicallyConductingActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string ComplianceMonitoringActionOutcomeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string InspectionRatingCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string NationalPrioritiesCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public YesNoIndicatorTypeBase MultimediaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MultimediaIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public YesNoIndicatorTypeBase InspectionUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InspectionUserDefinedField1Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        public string InspectionUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        public string InspectionUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public string InspectionUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public string InspectionUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        public string InspectionUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        public string InspectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InspectionContact", Order = 25)]
        public InspectionContact[] InspectionContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("StateFederalJointIndicator", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public enum StateFederalJointType
    {

        /// <remarks/>
        S,

        /// <remarks/>
        F,

        /// <remarks/>
        J,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("*")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("LeadParty", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("InspectionUserDefinedField1", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public enum YesNoIndicatorTypeBase
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class InspectionContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class CAFOInspection : ProgramInspectionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string CAFOClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CAFOContact", Order = 1)]
        public CAFOContact[] CAFOContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string IsAnimalFacilityTypeCAFOIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CAFODesignationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string CAFODesignationReasonText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public DischargesFromProductionAreaType DischargesDuringYearFromProductionAreaIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DischargesDuringYearFromProductionAreaIndicatorSpecified;

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
        [System.Xml.Serialization.XmlElementAttribute("CAFOInspectionViolationTypeCode", Order = 25)]
        public string[] CAFOInspectionViolationTypeCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitTrackingEvent))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitTrackingEventKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitTrackingEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime PermitTrackingEventDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitTrackingEvent : PermitTrackingEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermitTrackingCommentsText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermittedFeature))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermittedFeatureKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string PermittedFeatureUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string FieldSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string IsSiteOwnByFacility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string IsSystemLinedWithLeachate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string DoesUnitHaveDailyCover;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string PropertyBoundaryDistance;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string IsRequiredNitrateGroundWater;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string WellNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public GeographicCoordinates GeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        public string SourcePermittedFeatureDetailText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SiteOwnerContact", Order = 19)]
        public SiteOwnerContact[] SiteOwnerContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SiteOwnerContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public Contact Contact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ContactAddress ContactAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitScheduleEventViolationKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        public string NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ScheduleViolationCode;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PermitSchedule))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitScheduleKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        public string NarrativeConditionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitScheduleEventKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NarrativeCondition))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class NarrativeConditionKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        public string NarrativeConditionNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class NarrativeCondition : NarrativeConditionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NarrativeConditionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NarrativeConditionComments;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitSet))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimitKeyElements))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimits))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LimitSetKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetDesignator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LimitSet : LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScheduledLimitSet", typeof(ScheduledLimitSet), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("UnscheduledLimitSet", typeof(UnscheduledLimitSet), Order = 0)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitSetMonthsApplicable", Order = 1)]
        public MonthTextType[] LimitSetMonthsApplicable;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ScheduledLimitSet
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AgencyReviewer;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LimitSetUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LimitSetUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public LimitSetSchedule LimitSetSchedule;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LimitSetStatus
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActiveInactiveType LimitSetStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LimitSetStatusStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string LimitSetStatusReasonText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class UnscheduledLimitSet
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string AgencyReviewer;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string LimitSetUserDefinedDataElement1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string LimitSetUserDefinedDataElement2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string NumberUnitsReportPeriodInteger;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string LimitSetModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string LimitSetModificationEffectiveDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("LimitSetMonthsApplicable", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ParameterLimits))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ParameterLimitKeyElements : LimitSetKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        public string LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ParameterLimits : ParameterLimitKeyElements
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Limits))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LimitDates))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LimitKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 4)]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime LimitEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
        public string EligibleForBurdenReduction;

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
        public string BasisOfLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string LimitModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public string LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public string LimitsUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public string LimitsUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public string LimitsUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NumericCondition", Order = 17)]
        public NumericCondition[] NumericCondition;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class NumericCondition
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public NumericReportTextType NumericConditionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NumericConditionQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string NumericConditionUnitMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NumericConditionStatisticalBaseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NumericConditionQualifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string NumericConditionOptionalMonitoringIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string NumericConditionStayValue;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("NumericReportCode", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class LimitDates : LimitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        public System.DateTime ChangedLimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChangedLimitStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ChangedLimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChangedLimitEndDateSpecified;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EffluentTradePartner))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class EffluentTradePartnerKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 4)]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string TradeID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class EffluentTradePartner : EffluentTradePartnerKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TradePartnerNPDESID", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("TradePartnerOtherID", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string TradePartnerType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public EffluentTradePartnerAddress EffluentTradePartnerAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string TradePartnerStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string TradePartnerEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        TradePartnerNPDESID,

        /// <remarks/>
        TradePartnerOtherID,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class DMRViolationKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime MonitoringPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 5)]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string NumericReportViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class DMRViolation : DMRViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string RNCDetectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string RNCDetectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string RNCResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string RNCResolutionDate;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMRProgramReportLinkage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DischargeMonitoringReport))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class DischargeMonitoringReportKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime MonitoringPeriodEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class DMRProgramReportLinkage : DischargeMonitoringReportKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public BiosolidsReportLink BiosolidsReportLink;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SWEventReportLink", Order = 1)]
        public SWEventReportLink[] SWEventReportLink;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class BiosolidsReportLink
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ReportCoverageEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SWEventReportLink
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime DateStormEventSampled;
    }

    //TSM:
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    //public partial class DischargeMonitoringReport : DischargeMonitoringReportKeyElements
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    public string SignatureDate;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    public string PrincipalExecutiveOfficerFirstName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    public string PrincipalExecutiveOfficerLastName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    public string PrincipalExecutiveOfficerTitle;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    public string PrincipalExecutiveOfficerTelephone;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    //    public string SignatoryFirstName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    public string SignatoryLastName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    //    public string SignatoryTelephone;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
    //    public string ReportCommentText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("DMRNoDischargeIndicator", typeof(string), Order = 9)]
    //    [System.Xml.Serialization.XmlElementAttribute("DMRNoDischargeReceivedDate", typeof(string), Order = 9)]
    //    [System.Xml.Serialization.XmlElementAttribute("ReportParameter", typeof(ReportParameter), Order = 9)]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public object[] Items;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 10)]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType[] ItemsElementName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
    //    public LandApplicationSite LandApplicationSite;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
    //    public SurfaceDisposalSite SurfaceDisposalSite;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
    //    public Incinerator Incinerator;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
    //    public CoDisposalSite CoDisposalSite;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class NumericReport
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ParameterKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LimitSeasonNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("PaintFilterTestResult", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceSchedule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ComplianceScheduleEventViolationKeyElements))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ComplianceScheduleKeyElements : BasicPermitKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        public string ComplianceScheduleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ComplianceScheduleEventViolationKeyElements : ComplianceScheduleKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ScheduleViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleType", Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public enum ComplianceScheduleFlagType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        J,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InformalEnforcementAction))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FormalEnforcementAction))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class InformalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionTypeCode", Order = 1)]
        public string[] EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EnforcementActionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ReturnComplianceActualDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 4)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string ReasonForDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string InformalEACommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string InformalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string InformalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string InformalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string InformalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public string InformalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public string InformalEAUserDefinedField6;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class FormalEnforcementAction : EnforcementActionKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentifier", Order = 0)]
        public string[] PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementActionTypeCode", Order = 1)]
        public string[] EnforcementActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProgramsViolatedCode", Order = 2)]
        public string[] ProgramsViolatedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string CombinedOrSupercededByEAID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string ReasonForDeletingRecord;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string FormalEAUserDefinedField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string FormalEAUserDefinedField2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string FormalEAUserDefinedField3;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string FormalEAUserDefinedField4;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string FormalEAUserDefinedField5;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string FormalEAUserDefinedField6;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public FinalOrder FinalOrder;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class FinalOrder
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FinalOrderTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderEnteredDate", typeof(string), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("FinalOrderIssuedDate", typeof(string), Order = 1)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType2 ItemElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string NPDESClosedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string FinalOrderQNCRComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string CashCivilPenaltyRequiredAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string OtherComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {

        /// <remarks/>
        FinalOrderEnteredDate,

        /// <remarks/>
        FinalOrderIssuedDate,
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ScheduleEventViolation))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleEventViolationKeyElements", typeof(ComplianceScheduleEventViolationKeyElements), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleEventViolationKeyElements", typeof(PermitScheduleEventViolationKeyElements), Order = 0)]
        public BasicPermitKeyElements Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ScheduleEventViolation : ScheduleEventViolationKeyElements
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string RNCResolutionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string RNCResolutionDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class FacilityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public Facility Facility;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class ComplianceScheduleViolation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ComplianceScheduleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ScheduleViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class DischargeMonitoringReportViolation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime MonitoringPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 5)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NumericReportViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class EnforcementActionViolationKey
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public EnforcementActionViolation EnforcementActionViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public FinalOrderViolation FinalOrderViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class EnforcementActionViolation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleViolation", Order = 0)]
        public PermitScheduleViolation[] PermitScheduleViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleViolation", Order = 1)]
        public ComplianceScheduleViolation[] ComplianceScheduleViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportViolation", Order = 2)]
        public DischargeMonitoringReportViolation[] DischargeMonitoringReportViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SingleEventsViolation", Order = 3)]
        public SingleEventsViolation[] SingleEventsViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class PermitScheduleViolation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ScheduleViolationCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SingleEventsViolation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SingleEventViolationDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class FinalOrderViolation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitScheduleViolation", Order = 0)]
        public PermitScheduleViolation[] PermitScheduleViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleViolation", Order = 1)]
        public ComplianceScheduleViolation[] ComplianceScheduleViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportViolation", Order = 2)]
        public DischargeMonitoringReportViolation[] DischargeMonitoringReportViolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SingleEventsViolation", Order = 3)]
        public SingleEventsViolation[] SingleEventsViolation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class SubActivity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SubActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string EnforcementActionPlannedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string EnforcementActionDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class PayloadData
    {
        // TSM:
        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("BasicPermitData", typeof(BasicPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("BiosolidsPermitData", typeof(BiosolidsPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("BiosolidsProgramReportData", typeof(BiosolidsProgramReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("CAFOAnnualReportData", typeof(CAFOAnnualReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("CAFOInspectionData", typeof(CAFOInspectionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("CAFOPermitData", typeof(CAFOPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("CSOEventReportData", typeof(CSOEventReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("CSOInspectionData", typeof(CSOInspectionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("CSOPermitData", typeof(CSOPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringData", typeof(ComplianceMonitoringData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("ComplianceMonitoringLinkageData", typeof(ComplianceMonitoringLinkageData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("ComplianceScheduleData", typeof(ComplianceScheduleData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("DMRProgramReportLinkageData", typeof(DMRProgramReportLinkageData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("DMRViolationData", typeof(DMRViolationData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportData", typeof(DischargeMonitoringReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("EffluentTradePartnerData", typeof(EffluentTradePartnerData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("EnforcementActionViolationKeyData", typeof(EnforcementActionViolationKeyData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("FacilityData", typeof(FacilityData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("FormalEnforcementActionData", typeof(FormalEnforcementActionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("GeneralPermitData", typeof(GeneralPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("InformalEnforcementActionData", typeof(InformalEnforcementActionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("LimitSetData", typeof(LimitSetData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("LimitsData", typeof(LimitsData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("LocalLimitsProgramReportData", typeof(LocalLimitsProgramReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("MasterGeneralPermitData", typeof(MasterGeneralPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("NarrativeConditionData", typeof(NarrativeConditionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("POTWPermitData", typeof(POTWPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PermitScheduleData", typeof(PermitScheduleData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PermitTrackingEventData", typeof(PermitTrackingEventData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PermittedFeatureData", typeof(PermittedFeatureData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PretreatmentInspectionData", typeof(PretreatmentInspectionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PretreatmentPerformanceSummaryData", typeof(PretreatmentPerformanceSummaryData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PretreatmentPermitData", typeof(PretreatmentPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SSOAnnualReportData", typeof(SSOAnnualReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SSOEventReportData", typeof(SSOEventReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SSOInspectionData", typeof(SSOInspectionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SSOMonthlyEventReportData", typeof(SSOMonthlyEventReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWConstructionPermitData", typeof(SWConstructionPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWEventReportData", typeof(SWEventReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWIndustrialPermitData", typeof(SWIndustrialPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWInspectionData", typeof(SWInspectionData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWMS4LargePermitData", typeof(SWMS4LargePermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWMS4ProgramReportData", typeof(SWMS4ProgramReportData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SWMS4SmallPermitData", typeof(SWMS4SmallPermitData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("ScheduleEventViolationData", typeof(ScheduleEventViolationData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SingleEventViolationData", typeof(SingleEventViolationData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("SubActivityData", typeof(SubActivityData), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("UnpermittedFacilityData", typeof(UnpermittedFacilityData), Order = 0)]
        //public object[] Items;
        [System.Xml.Serialization.XmlElementAttribute("DischargeMonitoringReportData", typeof(DischargeMonitoringReportData), Order = 0)]
        public DischargeMonitoringReportData[] DischargeMonitoringReportData;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public OperationType Operation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class CAFOInspectionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CAFOInspection CAFOInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class CSOInspectionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public CSOInspection CSOInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class EnforcementActionViolationKeyData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public EnforcementActionViolationKey EnforcementActionViolationKey;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class LimitsData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LimitDates", typeof(LimitDates), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("Limits", typeof(Limits), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("ParameterLimits", typeof(ParameterLimits), Order = 1)]
        public BasicPermitKeyElements[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class NarrativeConditionData
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class PermitScheduleData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PermitSchedule PermitSchedule;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class PretreatmentInspectionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public PretreatmentInspection PretreatmentInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class SSOInspectionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SSOInspection SSOInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class SWInspectionData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SWInspection SWInspection;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    public partial class SubActivityData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public TransactionHeader TransactionHeader;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public SubActivity SubActivity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
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
        CAFOInspectionSubmission,

        /// <remarks/>
        CAFOPermitSubmission,

        /// <remarks/>
        ComplianceMonitoringLinkageSubmission,

        /// <remarks/>
        ComplianceMonitoringSubmission,

        /// <remarks/>
        ComplianceScheduleSubmission,

        /// <remarks/>
        CSOEventReportSubmission,

        /// <remarks/>
        CSOInspectionSubmission,

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
        EnforcementActionViolationKeySubmission,

        /// <remarks/>
        FacilitySubmission,

        /// <remarks/>
        FormalEnforcementActionSubmission,

        /// <remarks/>
        GeneralPermitSubmission,

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
        NarrativeConditionSubmission,

        /// <remarks/>
        PermitScheduleSubmission,

        /// <remarks/>
        PermittedFeatureSubmission,

        /// <remarks/>
        PermitTrackingEventSubmission,

        /// <remarks/>
        PretreatmentInspectionSubmission,

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
        SSOInspectionSubmission,

        /// <remarks/>
        SSOMonthlyEventReportSubmission,

        /// <remarks/>
        POTWPermitSubmission,

        /// <remarks/>
        SubActivitySubmission,

        /// <remarks/>
        SWConstructionPermitSubmission,

        /// <remarks/>
        SWEventReportSubmission,

        /// <remarks/>
        SWIndustrialPermitSubmission,

        /// <remarks/>
        SWInspectionSubmission,

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
