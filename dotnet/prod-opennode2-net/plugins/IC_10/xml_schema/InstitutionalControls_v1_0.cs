namespace Windsor.Node2008.WNOSPlugin.InstitutionalControls_10
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InstrumentCategoryCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum InstrumentCategoryCode
    {

        /// <remarks/>
        Proprietary,

        /// <remarks/>
        Government,

        /// <remarks/>
        Informational,

        /// <remarks/>
        Enforcement,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Engineering Control")]
        [System.ComponentModel.DescriptionAttribute("A physical technology implemented to minimize the potential for human exposure to" +
            " contamination by means of control or remediation.")]
        EngineeringControl,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InstrumentTypeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum InstrumentTypeCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrictive Covenant")]
        RestrictiveCovenant,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Deed Restriction of Unspecified Type")]
        DeedRestrictionofUnspecifiedType,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Local Ordinance")]
        LocalOrdinance,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Subdivision Regulation")]
        SubdivisionRegulation,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Agricultural")]
        AdvisoryAgricultural,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Drinking Water")]
        AdvisoryDrinkingWater,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Fishing")]
        AdvisoryFishing,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Food")]
        AdvisoryFood,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Health")]
        AdvisoryHealth,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Swimming")]
        AdvisorySwimming,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Advisory - Unspecified Type")]
        AdvisoryUnspecifiedType,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("MediaTypeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum MediaTypeCode
    {

        /// <remarks/>
        Air,

        /// <remarks/>
        Debris,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Ground Water")]
        GroundWater,

        /// <remarks/>
        Leachate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Liquid Waste")]
        LiquidWaste,

        /// <remarks/>
        Residuals,

        /// <remarks/>
        Sediment,

        /// <remarks/>
        Sludge,

        /// <remarks/>
        Soil,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Solid Waste")]
        SolidWaste,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Subsurface Soil")]
        SubsurfaceSoil,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Surface Soil")]
        SurfaceSoil,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Surface Water")]
        SurfaceWater,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EngineeringControlTypeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum EngineeringControlTypeCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Vapor Mitigation System")]
        VaporMitigationSystem,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Treatment System")]
        TreatmentSystem,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Soil or Vegetative Cap")]
        SoilorVegetativeCap,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Sheet Piling or Slurry Wall")]
        SheetPilingorSlurryWall,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Paved or Concrete Cap")]
        PavedorConcreteCap,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Liner System")]
        LinerSystem,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Leachate Collection System")]
        LeachateCollectionSystem,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Landfill Gas System")]
        LandfillGasSystem,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Interceptor Wells or Trench")]
        InterceptorWellsorTrench,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Ground Water Recovery")]
        GroundWaterRecovery,

        /// <remarks/>
        Building,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EngineeringControlModeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum EngineeringControlModeCode
    {

        /// <remarks/>
        Active,

        /// <remarks/>
        Passive,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationTypeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum AffiliationTypeCode
    {

        /// <remarks/>
        Obligee,

        /// <remarks/>
        Owner,

        /// <remarks/>
        Occupant,

        /// <remarks/>
        Agency,

        /// <remarks/>
        Compliance,

        /// <remarks/>
        Other,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventTypeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum EventTypeCode
    {

        /// <remarks/>
        Assessment,

        /// <remarks/>
        Implementation,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Land Activity or Use Monitoring")]
        LandActivityorUseMonitoring,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Remote Monitoring")]
        RemoteMonitoring,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Field Inspection")]
        FieldInspection,

        /// <remarks/>
        Notice,

        /// <remarks/>
        Enforcement,

        /// <remarks/>
        Maintenance,

        /// <remarks/>
        Termination,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Property Transfer")]
        PropertyTransfer,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Operational Status Change")]
        OperationalStatusChange,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventFrequencyUnitCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum EventFrequencyUnitCode
    {

        /// <remarks/>
        Hours,

        /// <remarks/>
        Days,

        /// <remarks/>
        Weeks,

        /// <remarks/>
        Months,

        /// <remarks/>
        Years,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventDateQualifierCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum EventDateQualifierCode
    {

        /// <remarks/>
        Planned,

        /// <remarks/>
        Actual,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("UseRestrictionTypeCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum UseRestrictionTypeCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Excavation")]
        RestrictExcavation,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Residential Use")]
        RestrictResidentialUse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Building Construction or Use")]
        RestrictBuildingConstructionorUse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Sensitive Land Use")]
        RestrictSensitiveLandUse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Groundwater Use")]
        RestrictGroundwaterUse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Surface Water Use")]
        RestrictSurfaceWaterUse,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Food Production")]
        RestrictFoodProduction,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Restrict Other")]
        RestrictOther,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalCategoryCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum ChemicalCategoryCode
    {

        /// <remarks/>
        Asbestos,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Inorganic Non-Metallic")]
        InorganicNonMetallic,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Inorganic Metals")]
        InorganicMetals,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("PAH - Polynuclear Aromatic Hydrocarbons")]
        PAHPolynuclearAromaticHydrocarbons,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("PCB - Polychlorinated Byphenols")]
        PCBPolychlorinatedByphenols,

        /// <remarks/>
        Pesticides,

        /// <remarks/>
        Petroleum,

        /// <remarks/>
        Phenols,

        /// <remarks/>
        Radioactive,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SVOCs - Semi Volatile Organic Compounds")]
        SVOCsSemiVolatileOrganicCompounds,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TPH - Total Petroleum Hydrocarbons")]
        TPHTotalPetroleumHydrocarbons,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("VOCs - Volatile Organic Compounds")]
        VOCsVolatileOrganicCompounds,

        /// <remarks/>
        Unknown,

        /// <remarks/>
        Other,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AccreditationAuthorityIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class AccreditationAuthorityIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AccreditationAuthorityIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class AddressPostalCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AddressPostalCodeContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationStatusText", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum AffiliationStatusTextDataType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        I,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class AgencyCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class AgencyTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalGroupName", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class BiologicalGroupNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalGroupNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSynonymName", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class BiologicalSynonymNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalSynonymNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSystematicName", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class BiologicalSystematicNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalSystematicNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalVernacularName", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class BiologicalVernacularNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalVernacularNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ComplianceMilestoneIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComplianceMilestoneIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneStatusText", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum ComplianceMilestoneStatusTextDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Implemented by Due Date(s)")]
        ImplementedbyDueDates,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Implemented by Determination Date, but Later than Due Date(s)")]
        ImplementedbyDeterminationDatebutLaterthanDueDates,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not Implemented by Due Date(s) or Determination Date")]
        NotImplementedbyDueDatesorDeterminationDate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ComplianceMilestoneTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneViolationResponseIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum ComplianceMilestoneViolationResponseIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ComplianceScheduleIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComplianceScheduleIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum ComplianceScheduleIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ConditionIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ConditionIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ConditionIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSourceCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class CoordinateDataSourceCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("CountryCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class CountryCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("CountyCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class CountyCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddressTypeName", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum ElectronicAddressTypeName
    {

        /// <remarks/>
        Email,

        /// <remarks/>
        Internet,

        /// <remarks/>
        Intranet,

        /// <remarks/>
        HTTP,

        /// <remarks/>
        FTP,

        /// <remarks/>
        Telnet,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementActionIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class EnforcementActionIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EnforcementActionIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityManagementTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FacilityManagementTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FacilitySiteIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FacilitySiteIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FacilitySiteTypeCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FederalFacilityIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum FederalFacilityIndicator
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FormIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FormIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatumCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class GeographicReferenceDatumCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class GeometricTypeCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class IndividualIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IndividualIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InjunctiveReliefIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class InjunctiveReliefIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InjunctiveReliefIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("LaboratoryIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class LaboratoryIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LaboratoryIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnitCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class MeasureUnitCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("MethodIdentifierCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class MethodIdentifierCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class MonitoringLocationIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MonitoringLocationIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSPrimaryIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum NAICSPrimaryIndicatorDataType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class OrganizationIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OrganizationIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("OtherPermitIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class OtherPermitIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OtherPermitIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("PenaltyIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class PenaltyIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PenaltyIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("PermitIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class PermitIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PermitIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("PermittedFeatureIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class PermittedFeatureIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PermittedFeatureIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("PermitTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class PermitTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReferencePointCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ReferencePointCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReportIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ReportIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ReportIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReportTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ReportTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifierCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ResultQualifierCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("RevisionIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum RevisionIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("SICPrimaryIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum SICPrimaryIndicatorDataType
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class StateCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class SubstanceIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubstanceIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceName", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class SubstanceNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubstanceNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("TribalCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class TribalCodeListIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("TribalLandIndicator", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public enum TribalLandIndicator
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationIdentifer", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ViolationIdentiferDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ViolationIdentiferContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ViolationTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Contaminant", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class Contaminant
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A category that characterizes the type of chemical substance.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(39)]
        public ChemicalCategoryCode ChemicalCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A text description of the chemical category when \"Other\" is selected for the Chem" +
            "ical Category Code.")]
        public string OtherChemicalCategoryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique number assigned by Chemical Abstracts Service (CAS) to a chemical subs" +
            "tance.")]
        public string CASRegistryNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The text that provides clarification to the identity of a chemical substance.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string ChemicalSubstanceDefinitionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("DataSource", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class DataSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the partner that provided the data.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string OriginatingPartnerName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The abbreviated name that represents the name of an information management system" +
            " for an environmental program.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string InformationSystemAcronymName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A value corresponding to the date the data was added to the source system or the " +
            "date the partner last recorded a change to the data.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime LastUpdatedDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EngineeringControl", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class EngineeringControl
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name assigned to a physical technology implemented to minimize the potential " +
            "for human exposure to contamination by means of control or remediation.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string EngineeringControlName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A description of the engineering control.")]
        public string EngineeringControlDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of engineering control.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(27)]
        public EngineeringControlTypeCode EngineeringControlTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EngineeringControlTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A text description of the engineering control type when \"Other\" is selected for t" +
            "he Engineering Control Type Code.")]
        public string OtherEngineeringControlTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether an engineering control is an active or passive system.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public EngineeringControlModeCode EngineeringControlModeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EngineeringControlModeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EngineeringControlLocation", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A location where an Engineering Control applies.")]
        public EngineeringControlLocation[] EngineeringControlLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EngineeringControlLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class EngineeringControlLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddress", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ElectronicAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A resource address, usually consisting of the access protocol, the domain name, a" +
            "nd optionally, the path to a file or location.")]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the electronic address type.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(8)]
        public ElectronicAddressTypeName ElectronicAddressTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElectronicAddressTypeNameSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Resource", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class Resource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A name given to the resource.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string ResourceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An account of the content of the resource.")]
        public string ResourceDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The nature or genre of the content of the resource.")]
        public string ResourceTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A location within a system of worldwide electronic communication where a computer" +
            " user can access information or receive electronic mail.")]
        public ElectronicAddress ElectronicAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResourceLocation", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A location where a Resource applies.")]
        public ResourceLocation[] ResourceLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResourceLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ResourceLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Event", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class Event
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name given to an occurrence or action taking place on a specific date or over" +
            " a period of time.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string EventName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of occurrence or action taking place on a specific date or overa period " +
            "of time.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(31)]
        public EventTypeCode EventTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A text description of the event type when \"Other\" is selected for the Event Type " +
            "Code.")]
        public string OtherEventTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A text description of the event.")]
        public string EventDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date an event started or is planned to start.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime EventStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The time of day an event started or is planned to start.")]
        public System.DateTime EventStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventStartTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The date an event ended or is planned to end.")]
        public System.DateTime EventEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The time of day an event ended or is planned to end.")]
        public System.DateTime EventEndTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventEndTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The qualifier that specifies the meaning of the date that the event has taken or " +
            "will take place.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(7)]
        public EventDateQualifierCode EventDateQualifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventDateQualifierCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("An attribute for describing the status of the event.")]
        public string EventStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to a recurring event.")]
        public string RecurringEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Resource", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Describes any document or source of information either directly or indirectly ass" +
            "ociated with an IC.")]
        public Resource[] Resource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventLocation", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("A location where an event takes place.")]
        public EventLocation[] EventLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventAffiliate", Order = 13)]
        [System.ComponentModel.DescriptionAttribute("A person or organization related to an event.")]
        public EventAffiliate[] EventAffiliate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class EventLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventAffiliate", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class EventAffiliate
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier prescribed to a person or organization.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string AffiliateIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AffiliationTypeCode", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of affiliation between a person or organization and an IC Instrument or " +
            "Event.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public AffiliationTypeCode[] AffiliationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A text description of the affiliation type when \"Other\" is selected for the Affil" +
            "iation Type Code.")]
        public string OtherAffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action began.")]
        public System.DateTime AffiliationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action ended.")]
        public System.DateTime AffiliationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationEndDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("RecurringEvent", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class RecurringEvent
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to a recurring event.")]
        public string RecurringEventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name given to an occurrence or action taking place on a specific date or over" +
            " a period of time.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string EventName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of occurrence or action taking place on a specific date or overa period " +
            "of time.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(31)]
        public EventTypeCode EventTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A text description of the event type when \"Other\" is selected for the Event Type " +
            "Code.")]
        public string OtherEventTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A text description of the event.")]
        public string EventDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The number denoting the time interval between a series of recurring events.")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string EventFrequencyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure associated with a time interval between a series of events al" +
            "lotted to take place.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public EventFrequencyUnitCode EventFrequencyUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventFrequencyUnitCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The date a recurring event started or is scheduled to start.")]
        public System.DateTime EventFrequencyStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventFrequencyStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The date a recurring event ended or is scheduled to end.")]
        public System.DateTime EventFrequencyEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EventFrequencyEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Describes the condition that would cause the event to occur.")]
        public string EventTriggerText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RecurringEventLocation", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A location where a recurring event takes place.")]
        public RecurringEventLocation[] RecurringEventLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("RecurringEventLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class RecurringEventLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("UseRestriction", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class UseRestriction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of land or resource use specifically prohibited or restricted by the lan" +
            "guage of the IC instrument.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(37)]
        public UseRestrictionTypeCode UseRestrictionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UseRestrictionTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Describes a land or resource use specifically prohibited or restricted by the lan" +
            "guage of the IC instrument.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string UseRestrictionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date when a use restriction takes effect.")]
        public System.DateTime UseRestrictionStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UseRestrictionStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date when a use restriction is lifted.")]
        public System.DateTime UseRestrictionEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UseRestrictionEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UseRestrictionLocation", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A location where a Use Restriction applies.")]
        public UseRestrictionLocation[] UseRestrictionLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("UseRestrictionLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class UseRestrictionLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Instrument", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class Instrument
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A description of the partner who originally provided the information, the acronym" +
            " representing the source system and the date the information was last updated in" +
            " the source system.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public DataSource DataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to an administrative measure and/or legal mechanism " +
            "that establishes a specific set of land or resource use restrictions.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string InstrumentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name assigned to an administrative measure and/or legal mechanism that establ" +
            "ishes a specific set of land or resource use restrictions.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string InstrumentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The major IC classification to which an administrative measure and/or legal mecha" +
            "nism that establishes aspecific set of land or resource use restrictions belongs" +
            ".")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(19)]
        public InstrumentCategoryCode InstrumentCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstrumentCategoryCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A text description of the instrument category when \"Other\" is selected for the In" +
            "strument Category Code.")]
        public string OtherInstrumentCategoryText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The type of administrative measure and/or legal mechanism that establishes a spec" +
            "ific set of land or resource use restrictions.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(36)]
        public InstrumentTypeCode InstrumentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InstrumentTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A text description of the instrument type when \"Other\" is selected for the Instru" +
            "ment Type Code.")]
        public string OtherInstrumentTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The legal description of an IC.")]
        public string InstrumentLegalDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InstrumentLocation", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A location where an IC Instrument applies.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public InstrumentLocation[] InstrumentLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ObjectiveText", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The text describing the intended goal of an IC in minimizing the potential for hu" +
            "man exposure to remaining contamination and/or protecting the integrity of an en" +
            "gineering control by limiting land or resource use in a particular media.")]
        public string[] ObjectiveText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MediaTypeCode", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The name of the major environmental component contaminated and addressed by the l" +
            "anguage of the IC instrument.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public MediaTypeCode[] MediaTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("A text description of the media type when \"Other\" is selected for the Media Type " +
            "Code.")]
        public string OtherMediaTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UseRestriction", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("A land or resource use specifically prohibited or restricted by the language of t" +
            "he IC instrument.")]
        public UseRestriction[] UseRestriction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contaminant", Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Describes a hazardous substance remaining in a particular media of concern at a s" +
            "pecific location.")]
        public Contaminant[] Contaminant;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EngineeringControl", Order = 14)]
        [System.ComponentModel.DescriptionAttribute("A physical technology implemented to minimize the potential for human exposure to" +
            " contamination by means of control or remediation.")]
        public EngineeringControl[] EngineeringControl;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InstrumentAffiliate", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A person or organization that relates to an IC Instrument.")]
        public InstrumentAffiliate[] InstrumentAffiliate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Resource", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Describes any document or source of information either directly or indirectly ass" +
            "ociated with an IC.")]
        public Resource[] Resource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RecurringEvent", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Any any scheduled recurring action taking place on a specific date or over a peri" +
            "od of time, for which data may be collected, processed, distributed, or used for" +
            " purposes related to ICs.")]
        public RecurringEvent[] RecurringEvent;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event", Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Any occurrence or action taking place on a specific date or over a period of time" +
            ", for which data may be collected, processed, distributed, or used for purposes " +
            "related to ICs.")]
        public Event[] Event;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InstrumentLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class InstrumentLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InstrumentAffiliate", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class InstrumentAffiliate
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier prescribed to a person or organization.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string AffiliateIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AffiliationTypeCode", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of affiliation between a person or organization and an IC Instrument or " +
            "Event.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public AffiliationTypeCode[] AffiliationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A text description of the affiliation type when \"Other\" is selected for the Affil" +
            "iation Type Code.")]
        public string OtherAffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action began.")]
        public System.DateTime AffiliationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action ended.")]
        public System.DateTime AffiliationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationEndDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InstrumentList", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class InstrumentListDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Instrument", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Describes an instututional control or non-engineered instrument.")]
        public Instrument[] Instrument;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnit", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class MeasureUnit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        public string MeasureUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a measurement unit code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public MeasureUnitCodeListIdentifier MeasureUnitCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the unit of measure code.")]
        public string MeasureUnitName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifier", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ResultQualifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the results.")]
        public string ResultQualifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a result qualifier code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public ResultQualifierCodeListIdentifier ResultQualifierCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the result code of any qualifying issues that affect the results" +
            ".")]
        public string ResultQualifierName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Measure", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class HorizontalAccuracyMeasure
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The recorded dimension, capacity, quality, or amount of something ascertained by " +
            "measuring or observing.")]
        public string MeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a unit of measurement.")]
        public MeasureUnit MeasureUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The precision of the recorded value.")]
        public string MeasurePrecisionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify any qualifying issues that " +
            "affect results.")]
        public ResultQualifier ResultQualifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReferenceMethod", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class HorizontalCollectionMethod
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        public string MethodIdentifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a reference method code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public MethodIdentifierCodeListIdentifier MethodIdentifierCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The title of the method that appears on the method from the organization that pub" +
            "lished it.")]
        public string MethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A brief summary that provides general information about the method.")]
        public string MethodDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Text that identifies any deviations from the published method reference.")]
        public string MethodDeviationsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferencePoint", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class GeographicReferencePoint
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geographic reference point" +
            " code. Can be used to identify the URL of a source that defines the set of curre" +
            "ntly approved permitted values.")]
        public ReferencePointCodeListIdentifier ReferencePointCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text that identifies the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatum", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class HorizontalReferenceDatum
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the reference datum used in determining latitude and lon" +
            "gitude coordinates or vertical measure.")]
        public string GeographicReferenceDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geographic reference datum" +
            " code.Can be used to identify the URL of a source that defines the set of curren" +
            "tly approved permitted values.")]
        public GeographicReferenceDatumCodeListIdentifier GeographicReferenceDatumCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the reference datum used in determining latitude and long" +
            "itude coordinates or vertical measure.")]
        public string GeographicReferenceDatumName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSource", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class CoordinateDataSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the party responsible for providing the latitude and lon" +
            "gitude coordinates.")]
        public string CoordinateDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a coordinate data source typ" +
            "e code. Can be used to identify the URL of a source that defines the set of curr" +
            "ently approved permitted values.")]
        public CoordinateDataSourceCodeListIdentifier CoordinateDataSourceCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the party responsible for providing the latitude and longitude coordi" +
            "nates.")]
        public string CoordinateDataSourceName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricType", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class GeometricType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the geometric entity represented by one point or a seque" +
            "nce of latitude and longitude points.")]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geometric type code. Can b" +
            "e used to identify the URL of a source that defines the set of currently approve" +
            "d permitted values.")]
        public GeometricTypeCodeListIdentifier GeometricTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the geometric entity represented by one point or a seque" +
            "nce of latitude and longitude points.")]
        public string GeometricTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class GeographicLocationDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string SourceMapScaleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The measure of the accuracy of the latitude and longitude coordinates.")]
        public HorizontalAccuracyMeasure HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to determine the latitude and longitud" +
            "e coordinates for a point on the earth.")]
        public HorizontalCollectionMethod HorizontalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geographic reference poin" +
            "t.")]
        public GeographicReferencePoint GeographicReferencePoint;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the reference datum used in determining latitude and l" +
            "ongitude coordinates.")]
        public HorizontalReferenceDatum HorizontalReferenceDatum;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when data were collected.")]
        public System.DateTime DataCollectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about the geographic coordinates.")]
        public string LocationCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The measure of elevation (i.e. the altitude) above or below are reference datum.")]
        public HorizontalAccuracyMeasure VerticalMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to collect the vertical measure(i.e., " +
            "the altitude) of a reference point.")]
        public HorizontalCollectionMethod VerticalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the reference datum used to determine the vertical mea" +
            "sure (i.e., the altitude).")]
        public HorizontalReferenceDatum VerticalReferenceDatum;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method or process used to verify the latitude and " +
            "longitude coordinates.")]
        public HorizontalCollectionMethod VerificationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a data source of coordinate" +
            " data.")]
        public CoordinateDataSource CoordinateDataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geometric entity represen" +
            "ted by one point or a sequence of points.")]
        public GeometricType GeometricType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ICGeographicLocationDescription", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ICGeographicLocationDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Envelope", typeof(EnvelopeType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LineString", typeof(LineStringType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("Point", typeof(PointType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("Polygon", typeof(PolygonType), Namespace = "http://www.opengis.net/gml", Order = 0)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string SourceMapScaleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The measure of the accuracy of the latitude and longitude coordinates.")]
        public HorizontalAccuracyMeasure HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to determine the latitude and longitud" +
            "e coordinates for a point on the earth.")]
        public HorizontalCollectionMethod HorizontalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geographic reference poin" +
            "t.")]
        public GeographicReferencePoint GeographicReferencePoint;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when data were collected.")]
        public System.DateTime DataCollectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about the geographic coordinates.")]
        public string LocationCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to collect the vertical measure(i.e., " +
            "the altitude) of a reference point.")]
        public HorizontalCollectionMethod VerticalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method or process used to verify the latitude and " +
            "longitude coordinates.")]
        public HorizontalCollectionMethod VerificationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a data source of coordinate" +
            " data.")]
        public CoordinateDataSource CoordinateDataSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class EnvelopeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lowerCorner", typeof(pos), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("upperCorner", typeof(pos), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public pos[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        //TSM:
        //public ItemsElementName[] ItemsElementName;
        public CornerType[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public int srsDimension;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("pos", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class pos
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public int srsDimension;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string doubleList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml", IncludeInSchema = false)]
    //TSM:
    //public enum ItemsElementName {
    public enum CornerType
    {

        /// <remarks/>
        lowerCorner,

        /// <remarks/>
        upperCorner,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("LineString", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class LineStringType : AbstractCurveType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("posList", Order = 0)]
        //TSM:
        //public Item Item;
        public posList posList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("posList", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    //TSM:
    //public partial class Item {
    public partial class posList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public int srsDimension;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public int count;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string doubleList;
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_GeometricPrimitive", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGeometricPrimitiveType : AbstractGeometryType
    {
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_Geometry", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGeometryType : AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string srsName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        public int srsDimension;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureCollectionType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FeatureCollectionType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometryType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSurfaceType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("_GML", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public abstract partial class AbstractGMLType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "ID")]
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
        public boundedBy boundedBy;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("boundedBy", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class boundedBy
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Envelope", Order = 0)]
        public EnvelopeType Envelope;
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
        public featureMember[] featureMember;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("featureMember", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class featureMember
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FeatureCollection", Order = 0)]
        public FeatureCollectionType FeatureCollection;
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
        //TSM:
        //public Item Item;
        public posList posList;
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
        public exterior exterior;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("exterior", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class exterior
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LinearRing", Order = 0)]
        public LinearRingType Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    [System.Xml.Serialization.XmlRootAttribute("Point", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
    public partial class PointType : AbstractGeometricPrimitiveType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("pos", Order = 0)]
        public pos Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteType", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FacilitySiteType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the type of site a facility occupies.")]
        public string FacilitySiteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a facility site type code. C" +
            "an be used to identify the URL of a source that defines the set of currently app" +
            "roved permitted values.")]
        public FacilitySiteTypeCodeListIdentifier FacilitySiteTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The descriptive name for the type of site the facility occupies.")]
        public string FacilitySiteTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FacilitySiteIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a governmental entity to identify a faci" +
            "lity site.")]
        public FacilitySiteIdentifier FacilitySiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to represents the type of site a facili" +
            "ty occupies.")]
        public FacilitySiteType FacilitySiteType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An indicator identifying facilities owned or operated by a federal government uni" +
            "t.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public FederalFacilityIndicator FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FederalFacilityIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("StateIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class StateIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a principal administrative subdivision of the " +
            "United States, Canada, or Mexico.")]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a state code. Can be used to" +
            " identify the URL of a source that defines the set of currently approved permitt" +
            "ed values.")]
        public StateCodeListIdentifier StateCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a principal administrative subdivision of the United Stat" +
            "es, Canada, or Mexico.")]
        public string StateName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("CountryIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class CountryIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string CountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a country code. Can be used " +
            "to identify the URL of a source that defines the set of currently approved permi" +
            "tted values.")]
        public CountryCodeListIdentifier CountryCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a primary geopolitical unit of the world.")]
        public string CountryName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("CountyIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class CountyIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the county.")]
        public string CountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a county code. Can be used t" +
            "o identify the URL of a source that defines the set of currently approved permit" +
            "ted values.")]
        public CountyCodeListIdentifier CountyCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the county code.")]
        public string CountyName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("TribalIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class TribalIdentityCodeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian tribe or Alaskan Native entity.")]
        public string TribalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a tribal code. Can be used t" +
            "o identify the URL of a source that defines the set of currently approved permit" +
            "ted values.")]
        public TribalCodeListIdentifier TribalCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the American Indian tribe or Alaskan Native entity.")]
        public string TribalName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class LocationAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic) location of the front door o" +
            "r main entrance of a facility site, including urban-style street address or rura" +
            "l address.")]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about a place, including a building" +
            " name with its secondary unit and number, an industrial park name, an installati" +
            "on name or descriptive text where no formal address is available.")]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of a city, town, village or other locality.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentity StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCode AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentity CountryIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a U.S. county or county equ" +
            "ivalent.")]
        public CountyIdentity CountyIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name of an American Indian or Alaskan native area where the location address " +
            "exists.")]
        public string TribalLandName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("An indicator denoting the location address is a tribal land")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public TribalLandIndicator TribalLandIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TribalLandIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A brief explanation of a location, including navigational directions and/or more " +
            "descriptive information.")]
        public string LocationDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Facility", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class FacilityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Basic information used by an organization to identify a facility or site.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public FacilitySiteIdentity FacilitySiteIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The physical location of an individual or organization.")]
        public LocationAddress LocationAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("LandParcel", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class LandParcelDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies the parcel schema.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LandParcelNamingSchema;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the jurisitiction that generated the parcel value, typically a county " +
            "tax assessor office.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LandParcelSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Parcel value compliant with parcel schema typically referred to as a Parcel Ident" +
            "ification Number (PIN) or Assessors Parcel Number (APN)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LandParcelIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ICLocation", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ICLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier used to uniquely identify a location.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string LocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Facility", typeof(FacilityDataType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("ICGeographicLocationDescription", typeof(ICGeographicLocationDescriptionDataType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("LandParcel", typeof(LandParcelDataType), Order = 1)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ICLocationList", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ICLocationListDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ICLocation", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A physical location or area defined by a geographic area description, tax parcel," +
            " or facility address.")]
        public ICLocation[] ICLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class IndividualIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify an individual within a context.")]
        public IndividualIdentifier IndividualIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text that describes the title that precedes an individual\'s name.")]
        public string NamePrefixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("IndividualFullName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("MiddleName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsElementName[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Additional title that indicates lineage or professional title.")]
        public string NameSuffixText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1", IncludeInSchema = false)]
    public enum ItemsElementName
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
        FirstName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The complete name of a person, potentially including first name, middle name or i" +
            "nitial, and or surname.")]
        IndividualFullName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
        LastName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
        MiddleName,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentity", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class OrganizationIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a unique business establishment within a c" +
            "ontext.")]
        public OrganizationIdentifier OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The legal designator (i.e. formal name) of an organization.")]
        public string OrganizationFormalName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class MailingAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The exact address where a mail piece is intended to be delivered, including urban" +
            "-style street address, rural route, and PO Box.")]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information to facilitate the delivery of a mai" +
            "l piece, including building name, secondary units, and mail stop or local box nu" +
            "mbers not serviced by the U.S. Postal Service.")]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the city, town, or village where the mail is delivered.")]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentity StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCode AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentity CountryIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Telephonic", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class Telephonic
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that identifies a particular telephone connection.")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes a telephone number type.")]
        public string TelephoneNumberTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number assigned within an organization to an individual telephone that extend" +
            "s the external telephone number.")]
        public string TelephoneExtensionNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("TelephonicList", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class TelephonicListDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephonic", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identification of a telephone connection.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Telephonic[] Telephonic;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddressList", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class ElectronicAddressListDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ElectronicAddress", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A location within a system of worldwide electronic communication where a computer" +
            " user can access information or receive electronic mail.")]
        public ElectronicAddress[] ElectronicAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("Affiliate", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class Affiliate
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier prescribed to a person or organization.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public string AffiliateIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Telephonic", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more telephone numbers.")]
        public Telephonic[] TelephonicList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ElectronicAddress", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more electronic addresses.")]
        public ElectronicAddress[] ElectronicAddressList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualIdentity", typeof(IndividualIdentityDataType), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("OrganizationIdentity", typeof(OrganizationIdentityDataType), Order = 3)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The standard address used to send mail to an individual or organization.")]
        public MailingAddress MailingAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliateList", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class AffiliateListDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Affiliate", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Describes an individual or organization.")]
        public Affiliate[] Affiliate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IC/1")]
    [System.Xml.Serialization.XmlRootAttribute("InstitutionalControlsDocument", Namespace = "http://www.exchangenetwork.net/schema/IC/1", IsNullable = false)]
    public partial class InstitutionalControlsDocumentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Instrument", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more institutional control instruments.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Instrument[] InstrumentList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ICLocation", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more locations.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ICLocation[] ICLocationList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Affiliate", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more individuals or organizations.")]
        public Affiliate[] AffiliateList;
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
        public pos Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public radius radius;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public interpolation interpolation;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool interpolationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string numArc;

        public ArcByCenterPointType()
        {
            this.interpolation = interpolation.circularArcCenterPointWithRadius;
            this.numArc = "1";
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    public partial class radius : MeasureType
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    public partial class MeasureType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
        public string uom;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public double Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.opengis.net/gml")]
    public enum interpolation
    {

        /// <remarks/>
        linear,

        /// <remarks/>
        geodesic,

        /// <remarks/>
        circularArc3Points,

        /// <remarks/>
        circularArc2PointWithBulge,

        /// <remarks/>
        circularArcCenterPointWithRadius,

        /// <remarks/>
        elliptical,

        /// <remarks/>
        clothoid,

        /// <remarks/>
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
