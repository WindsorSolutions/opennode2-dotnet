using System.Xml.Serialization;
using System.Data;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.UIC_20
{
    [DefaultTableNamePrefixAttribute("UIC")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [UseTableNameForDefaultPrimaryKeysAttribute]

    [AbbreviationsAttribute("LOCATION", "LOC",
                            "ICISCOMPLIANCE", "ICIS_COMPL",
                            "ICISMOA", "ICIS_MOA",
                            "REGIONAL", "RGN",
                            "USDWDEPTH", "USDW_DEPTH",
                            "POSITION", "POS",
                            "ACTIVITY", "ACT",
                            "IDENTIFIER", "IDENT",
                            "EXEMPTION", "EXEMPT",
                            "INJECTION", "INJECT",
                            "AQUIFER", "AQUIF",
                            "HIGH", "HI",
                            "LOW", "LO",
                            "PRIORITY", "PRI",
                            "SOURCE", "SRC",
                            "TEXT", "TXT",
                            "OPERATING", "OPER",
                            "GEOGRAPHIC", "GEO",
                            "REFERENCE", "REF",
                            "POINT", "PT",
                            "HORIZONTAL", "HORZ",
                            "COORDINATE", "COORD",
                            "SYSTEM", "SYS",
                            "RETURN", "RTN",
                            "COMPLIANCE", "COMPL",
                            "INSPECTION", "INSP",
                            "MONITORING", "MONTR",
                            "MECHANICAL", "MECH",
                            "INTEGRITY", "INTEG",
                            "REASON", "RSN",
                            "CODE", "CD",
                            "ACTION", "ACT",
                            "REMEDIAL", "REM",
                            "ENGINEERING", "ENGR",
                            "MAXIMUM", "MAX",
                            "MINIMUM", "MIN",
                            "NUMERIC", "NUM",
                            "PERMITTED", "PERM",
                            "VOLUME", "VOL",
                            "INJECT", "INJ",
                            "GEOLOGY", "GEO",
                            "BOTTOM", "BOT",
                            "ZONE", "ZN",
                            "TEST", "TST",
                            "LITHOLOGIC", "LITH",
                            "INJECTIONE", "INJ",
                            "PERMEABILITY", "PERM",
                            "CONFINING", "CONF",
                            "POROSITY", "POR",
                            "PERCENT", "PCNT"
                         )]

    [AppliedAttribute(typeof(FacilityDetailType), "FacilityIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(FacilityDetailType), "LocalityName", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityDetailType), "FacilitySiteName", typeof(ColumnAttribute), 80, false)]
    [AppliedAttribute(typeof(FacilityDetailType), "FacilityPetitionStatusCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityDetailType), "LocationAddressStateCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityDetailType), "FacilityStateIdentifier", typeof(ColumnAttribute), 50, false)]
    [AppliedAttribute(typeof(FacilityDetailType), "LocationAddressText", typeof(ColumnAttribute), 150, false)]
    [AppliedAttribute(typeof(FacilityDetailType), "FacilitySiteTypeCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityDetailType), "NAICSCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityDetailType), "SICCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityDetailType), "LocationAddressPostalCode", typeof(ColumnAttribute), 14, false)]

    [AppliedAttribute(typeof(FacilityInspectionDetailType), "InspectionIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(FacilityInspectionDetailType), "InspectionActionDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(FacilityInspectionDetailType), "InspectionFacilityIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationContaminationCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationEndangeringCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationReturnComplianceDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8)]
    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationSignificantCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationDeterminedDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(FacilityViolationDetailType), "ViolationFacilityIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(ResponseDetailDataType), "ResponseEnforcementIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(ResponseDetailDataType), "ResponseViolationIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(WellDetailType), "WellIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellDetailType), "WellAquiferExemptionInjectionCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellDetailType), "WellTotalDepthNumeric", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellDetailType), "WellHighPriorityDesignationCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellDetailType), "WellContactIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellDetailType), "WellFacilityIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellDetailType), "WellGeologyIdentifier", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(WellDetailType), "WellSiteAreaNameText", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellDetailType), "WellPermitIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellDetailType), "WellStateIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellDetailType), "WellStateTribalCode", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellDetailType), "WellInSourceWaterAreaLocationText", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellDetailType), "WellName", typeof(ColumnAttribute), 128)]

    [AppliedAttribute(typeof(WellStatusDetailType), "WellStatusIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellStatusDetailType), "WellStatusDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(WellStatusDetailType), "WellStatusWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(WellTypeDetailDataType), "WellTypeIdentifier", typeof(ColumnAttribute), 20, false)]
    
    [AppliedAttribute(typeof(WellTypeDetailDataType), "WellTypeCode", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellTypeDetailDataType), "WellTypeDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(WellTypeDetailDataType), "WellTypeWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(LocationDetailType), "LocationIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(LocationDetailType), "LocationAddressCounty", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(LocationDetailType), "LocationAccuracyValueMeasure", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(LocationDetailType), "GeographicReferencePointCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(LocationDetailType), "HorizontalCoordinateReferenceSystemDatumCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(LocationDetailType), "HorizontalCollectionMethodCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(LocationDetailType), "LocationPointLineAreaCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(LocationDetailType), "SourceMapScaleNumeric", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(LocationDetailType), "LocationWellIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(LocationDetailType), "LatitudeMeasure", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(LocationDetailType), "LongitudeMeasure", typeof(ColumnAttribute), 20)]

    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationContaminationCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationEndangeringCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationReturnComplianceDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8)]
    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationSignificantCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationDeterminedDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(WellViolationDetailType), "ViolationWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionAssistanceCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionDeficiencyCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionActionDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionICISComplianceMonitoringReasonCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionICISComplianceMonitoringTypeCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionICISComplianceActivityTypeCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionICISMOAName", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionICISRegionalPriorityName", typeof(ColumnAttribute), 128)]
    [AppliedAttribute(typeof(WellInspectionDetailType), "InspectionWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(CorrectionDetailType), "CorrectionIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(CorrectionDetailType), "CorrectionActionTypeCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(CorrectionDetailType), "CorrectionCommentText", typeof(ColumnAttribute), 255)]
    [AppliedAttribute(typeof(CorrectionDetailType), "CorrectionInspectionIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(MITestDetailType), "MechanicalIntegrityTestIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(MITestDetailType), "MechanicalIntegrityTestCompletedDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(MITestDetailType), "MechanicalIntegrityTestRemedialActionDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8)]
    [AppliedAttribute(typeof(MITestDetailType), "MechanicalIntegrityTestRemedialActionTypeCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(MITestDetailType), "MechanicalIntegrityTestWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(EngineeringDetailType), "EngineeringIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(EngineeringDetailType), "EngineeringMaximumFlowRateNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(EngineeringDetailType), "EngineeringPermittedOnsiteInjectionVolumeNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(EngineeringDetailType), "EngineeringPermittedOffsiteInjectionVolumeNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(EngineeringDetailType), "EngineeringWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(WasteDetailType), "WasteIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(WasteDetailType), "WasteCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WasteDetailType), "WasteStreamClassificationCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(WasteDetailType), "WasteWellIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(ConstituentDetailType), "ConstituentIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(ConstituentDetailType), "MeasureValue", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(ConstituentDetailType), "MeasureUnitCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(ConstituentDetailType), "ConstituentNameText", typeof(ColumnAttribute), 255)]
    [AppliedAttribute(typeof(ConstituentDetailType), "ConstituentWasteIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(ContactDetailType), "ContactIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(ContactDetailType), "TelephoneNumberText", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(ContactDetailType), "IndividualFullName", typeof(ColumnAttribute), 70, false)]
    [AppliedAttribute(typeof(ContactDetailType), "ContactCityName", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(ContactDetailType), "ContactAddressStateCode", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(ContactDetailType), "ContactAddressText", typeof(ColumnAttribute), 150, false)]
    [AppliedAttribute(typeof(ContactDetailType), "ContactAddressPostalCode", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(PermitDetailType), "PermitIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(PermitDetailType), "PermitAORWellNumberNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(PermitDetailType), "PermitOwnershipTypeCode", typeof(ColumnAttribute), 50)]
    [AppliedAttribute(typeof(PermitDetailType), "PermitAuthorizedIdentifier", typeof(ColumnAttribute), 50, false)]

    [AppliedAttribute(typeof(PermitActivityDetailType), "PermitActivityIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(PermitActivityDetailType), "PermitActivityDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]
    [AppliedAttribute(typeof(PermitActivityDetailType), "PermitActivityPermitIdentifier", typeof(ColumnAttribute), 20, false)]

    [AppliedAttribute(typeof(GeologyDetailType), "GeologyIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyConfiningZoneName", typeof(ColumnAttribute), 255)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyConfiningZoneTopNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyConfiningZoneBottomNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyLithologicConfiningZoneText", typeof(ColumnAttribute), 255)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyInjectionZoneFormationName", typeof(ColumnAttribute), 255)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyBottomInjectionZoneNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyLithologicInjectionZoneText", typeof(ColumnAttribute), 255)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyTopInjectionIntervalNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyBottomInjectionIntervalNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyInjectioneZonePermeabilityRateNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyInjectionZonePorosityPercentNumeric", typeof(ColumnAttribute), 20)]
    [AppliedAttribute(typeof(GeologyDetailType), "GeologyUSDWDepthNumeric", typeof(ColumnAttribute), 20)]

    [AppliedAttribute(typeof(EnforcementDetailType), "EnforcementIdentifier", typeof(ColumnAttribute), 20, false)]
    [AppliedAttribute(typeof(EnforcementDetailType), "EnforcementActionDate", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, 8, false)]

    [Table("UIC_ORG")]
    public partial class UICDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [UserPrimaryKey(DbType.AnsiString, 4)]
        public string OrgId;

        [System.Xml.Serialization.XmlIgnore]
        [Column(DbType.AnsiString, 255)]
        public string OrgName;
    }
    [Table("UIC_FACILITY_RESPONSE")]
    public partial class FacilityResponseDetailDataType : ResponseDetailDataType
    {
    }
    [Table("UIC_WELL_RESPONSE")]
    public partial class WellResponseDetailDataType : ResponseDetailDataType
    {
    }
    [Table("UIC_FACILITY")]
    public partial class FacilityListType
    {
    }
    [Table("UIC_CONTACT")]
    public partial class ContactDetailType
    {
    }
    [Table("UIC_PERMIT")]
    public partial class PermitDetailType
    {
    }
    [Table("UIC_PERMIT_ACTIVITY")]
    public partial class PermitActivityDetailType
    {
    }
    [Table("UIC_WELL")]
    public partial class WellDetailType
    {
    }
    [Table("UIC_WELL_STATUS")]
    public partial class WellStatusDetailType
    {
    }
    [Table("UIC_WELL_TYPE")]
    public partial class WellTypeDetailDataType
    {
    }
    [Table("UIC_FACILITY_INSPECTION")]
    public partial class FacilityInspectionDetailType
    {
    }
    [Table("UIC_WELL_INSPECTION")]
    public partial class WellInspectionDetailType
    {
    }
    [Table("UIC_FACILITY_VIOLATION")]
    public partial class FacilityViolationDetailType
    {
    }
    [Table("UIC_WELL_VIOLATION")]
    public partial class WellViolationDetailType
    {
    }
    [Table("UIC_ENFORCEMENT")]
    public partial class EnforcementDetailType
    {
    }
    [Table("UIC_CORRECTION")]
    public partial class CorrectionDetailType
    {
    }
    [Table("UIC_MI_TEST")]
    public partial class MITestDetailType
    {
    }
    [Table("UIC_ENGINEERING")]
    public partial class EngineeringDetailType
    {
    }
    [Table("UIC_GEOLOGY")]
    public partial class GeologyDetailType
    {
    }
    [Table("UIC_WASTE")]
    public partial class WasteDetailType
    {
    }
    [Table("UIC_CONSTITUENT")]
    public partial class ConstituentDetailType
    {
    }
}
