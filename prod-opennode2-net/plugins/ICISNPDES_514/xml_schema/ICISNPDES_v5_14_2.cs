using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm2;
using Windsor.Commons.Core;
using System.Collections.Generic;
using Windsor.Commons.Spring;
using System.Linq;

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_514
{
    [DefaultTableNamePrefixAttribute("ICS")]
    [RemovePostfixNamesFromTableAndColumnNamesAttribute("Data", "Details", "Code")]
    [AllowNestedSameTablesAttribute]
    [NameReplacementsAttribute(128, 128, new string[]
    {
        "TRANSACTION_HEADER", "",
        "VIOLATION_KEY_ELEMENTS", "VIOLATION_ELEMENTS",
        "MINIMUM_BOUNDARY_DISTANCE_TYPE_CODE", "MIN_BNDRY_DIST_TYPE_CODE",
        "MINIMUM_BOUNDARY_DISTANCE_INDICATOR", "MIN_BNDRY_DIST_IND",
        "SUPPLEMENTAL_ENVIRONMENTAL_PROJECT", "SEP",
        "STORM_WATER", "SW",
        "BIOSOLIDS", "BS",
        "BIOSOLID", "BS",
        "TRACKING", "TRACK",
        "TRACK", "TRACK",
        "NON", "NON",
        "DATE", "DATE",
        "CODE", "CODE",
        "TEXT", "TXT",
        "STAY", "STAY",
        "TYPE", "TYPE",
        "USER", "USR",
        "NUMBER", "NUM",
        "STATE", "ST",
        "WATER", "WTR",
        "REASON", "REASON",
        "DEFICIENCY", "DEFCY",
        "ASSOCIATED", "ASSC",
        "CONVERSION", "CONV",
        "CROSS", "CRSS",
        "EXCEEDENCE", "EXCEED",
        "MODULE", "MOD",
        "ABSTRACT", "ABST",
        "ACCEPTABLE", "ACCPT",
        "NUMEROUS", "NUMR",
        "IDENTIFICATION", "IDENT",
        "IDENTIFIER", "IDENT",
        "FEDERAL", "FEDR",
        "RESPONSE", "RSPN",
        "COMMENTS", "CMNTS",
        "COMMENT", "CMNT",
        "FIELD", "FLD",
        "ORGANIZATION", "ORG",
        "ASSOCIATION", "ASSC",
        "HORIZONTAL", "HORZ",
        "VERTICAL", "VERT",
        "PRODUCT", "PROD",
        "GALLONS", "GAL",
        "RECEIVED", "RCVD",
        "RECEIVING", "RCVG",
        "RECEIVE", "RECV",
        "PLANNER", "PLNR",
        "NUMBERS", "NUM",
        "TOTAL", "TTL",
        "AVAILABLE", "AVAIL",
        "DESCRIPTION", "DESC",
        "AMOUNT", "AMT",
        "GENERATED", "GNRTD",
        "CATEGORY", "CATG",
        "ALTERNATIVES", "ALTS",
        "ALTERNATIVE", "ALT",
        "ADDRESS", "ADDR",
        "ADDITIONAL", "ADDL",
        "INFORMATION", "INFO",
        "LOADING", "LOADING",
        "CONDITION", "COND",
        "ANALYTICAL", "ANLYTCL",
        "HANDLER", "HNDLR",
        "PREPARER", "PREPR",
        "BOUNDARY", "BOUNDARY",
        "SPECIFIC", "SPEC",
        "DISTANCE", "DISTANCE",
        "EXCEDENCE", "EXCD",
        "CONTAINER", "CNTNR",
        "NUMERIC", "NUM",
        "EVALUATION", "EVAL",
        "AUTHORIZATION", "AUTH",
        "PROJECTED", "PROJ",
        "PROJECTS", "PROJ",
        "PROJECT", "PROJ",
        "DESIGN", "DSGN",
        "AVERAGE", "AVER",
        "PERMITTING", "PRMT",
        "PERMITS", "PRMTS",
        "PERMIT", "PRMT",
        "PERMITTED", "PRMT",
        "UNPERMITTED", "UNPRMT",
        "EVENTS", "EVTS",
        "EVENT", "EVT",
        "REPORTS", "REP",
        "REPORT", "REP",
        "REPORTING", "REP",
        "REPORTABLE", "REP",
        "REPORTED", "REP",
        "APPLICATION", "APPL",
        "APPLICABLE", "APPL",
        "COGNIZANT", "COGNZNT",
        "CONTEXT", "CNTXT",
        "ANIMAL", "ANML",
        "SIGNIFICANT", "SIG",
        "CONGRESSIONAL", "CONGR",
        "CONSTRUCTION", "CNST",
        "LATITUDE", "LAT",
        "LONGITUDE", "LONG",
        "CLASSIFICATION", "CLASS",
        "PROGRAMS", "PROGS",
        "PROGRAM", "PROG",
        "AFFILIATION", "AFFIL",
        "INDIVIDUAL", "INDVL",
        "ELECTRONIC", "ELEC",
        "TELEPHONE", "TELEPH",
        "EXTENSION", "EXT",
        "REFERENCE", "REF",
        "COLLECTION", "COLL",
        "DISTRIBUTION", "DIST",
        "DISTRIBUTED", "DIST",
        "DISTURBING", "DISTRB",
        "DEMOLISHED", "DEMOED",
        "PRODUCTION", "PROD",
        "DISPOSAL", "DSPL",
        "BENEFICIALLY", "BENEF",
        "BENEFICIAL", "BENEF",
        "PARAMETER", "PARAM",
        "MANAGEMENT", "MGMT",
        "VIOLATIONS", "VIOL",
        "VIOLATION", "VIOL",
        "VIOLATED", "VIOL",
        "SURFACE", "SURF",
        "AUTHORITY", "AUTH",
        "AUTHORIZED", "AUTH",
        "TRANSFER", "TRANS",
        "APPROVE", "APRV",
        "APPROVED", "APRVD",
        "APPROVAL", "APRVL",
        "DESIGNATION", "DESGN",
        "CONTRIBUTING", "CONTRB",
        "CONTRIBUTE", "CONTRB",
        "CONTROL", "CONTROL",
        "DRAINAGE", "DRAIN",
        "INDICATOR", "IND",
        "DEVELOPED", "DVLPD",
        "CERTIFIED", "CERT",
        "CERTIFY", "CERT",
        "CERTIFIER", "CERT",
        "CERTIFICATION", "CERT",
        "ENVIRONMENTAL", "ENVR",
        "ENVIRONMENT", "ENVR",
        "SYSTEM", "SYSTM",
        "COUNT", "CNT",
        "PROCESSED", "PRCSS",
        "PROCESS", "PRCSS",
        "FEATURE", "FEATR",
        "VOLUME", "VOL",
        "DISCHARGES", "DSCH",
        "DISCHARGE", "DSCH",
        "PRECIPITATION", "PRECIP",
        "SATELLITE", "SATL",
        "COMPLIANCE", "CMPL",
        "MONITORING", "MON",
        "MONITOR", "MON",
        "ACTIVITY", "ACTY",
        "ACTIVITIES", "ACTIVITIES",
        "ASSISTANCE", "ASSIST",
        "EMERGENCY", "EMRGCY",
        "INSPECTIONS", "INSP",
        "INSPECTION", "INSP",
        "PHYSICALLY", "PHYS",
        "PHYSICAL", "PHYS",
        "DETERMINE", "DTRMN",
        "DETERMINATION", "DTRMN",
        "HAZARDOUS", "HAZ",
        "MECHANISM", "MECH",
        "FREQUENT", "FREQ",
        "FREQUENCY", "FREQ",
        "REQUIREMENT", "REQ",
        "REQUIREMENTS", "REQS",
        "ADMINISTRATIVE", "ADMIN",
        "TECHNICAL", "TECH",
        "REMOVAL", "RMVL",
        "OVERFLOW", "OVRFLW",
        "OTHER", "OTHR",
        "ESTIMATED", "EST",
        "ESTIMATE", "EST",
        "PERFORMANCE", "PERF",
        "DESCRIPTOR", "DESC",
        //"PRACTICES", "PRACTICES",
        "PATHOGEN", "PATHOGEN",
        "VECTOR", "VECTOR",
        "REDUCTION", "REDUCTION",
        "AGRONOMIC", "AGRONOMIC",
        "SCHEDULED", "SCHD",
        "SCHEDULE", "SCHD",
        "EXCEEDANCE", "EXCEEDANCE",
        "DETECTION", "DETECT",
        "RESOLUTION", "RESL",
        "EXECUTIVE", "EXEC",
        "PRINCIPAL", "PRNCPL",
        "OFFICER", "OFFCR",
        "SIGNATORY", "SIGN",
        "CONCENTRATION", "CONCEN",
        "QUANTITY", "QTY",
        "MODIFICATION", "MOD",
        "SUPPLEMENTAL", "SUPPL",
        "COMPLETION", "CMPL",
        "SUBMISSION", "SUBM",
        "STATISTICAL", "STAT",
        "OPTIONAL", "OPT",
        "EXPIRATION", "EXPR",
        "REQUIRED", "REQD",
        "SAMPLING", "SMPL",
        "SAMPLED", "SMPL",
        "SAMPLE", "SMPL",
        "SAMPLES", "SMPL",
        "PUBLISHED", "PUBL",
        "ADMINISTRTIVE", "ADMIN",
        "PENALTIES", "PNLTY",
        "PENALTY", "PNLTY",
        "REGIONAL", "RGNL",
        "REGION", "RGN",
        "TERMINATION", "TERM",
        "NOTIFICATION", "NOTIF",
        "ESSENTIAL", "ESSEN",
        "ESSENTIALLY", "ESSEN",
        "HISTORICAL", "HIST",
        "HISTORIC", "HIST",
        "INCORPORATED", "INCRP",
        "EXPENDITURE", "EXPEN",
        "MEASURE", "MEAS",
        "MEASUREMENT", "MEAS",
        "RESPONSIBILITIES", "RESP",
        "RESPONSIBILITY", "RESP",
        "STORM", "STRM",
        "STORMWATER", "SW",
        "STRUCTURE", "STRCT",
        "CHEMICAL", "CHEM",
        "CHEMICALS", "CHEMS",
        "EVALUATIONS", "EVALS",
        "PREPARED", "PREP",
        "ANTIDEGRADATION", "ANTIDEG",
        "ELEMENTS", "ELEM",
        "GEOGRAPHIC", "GEO",
        "ORIGINATING", "ORIG",
        "COORDINATES", "COORD",
        "COORDINATE", "COORD",
        "OFFICIAL", "OFCL",
        "FACILITY", "FAC",
        "RANGE", "RNG",
        "NUTRIENT", "NUTR",
        "PHOSPHOROUS", "PHOSPH",
        "LOCATION", "LOC",
        "CORRECTIVE", "CORR",
        "BIOMONITORING", "BIOMON",
        "ACTION", "ACTN",
        "MAXIMUM", "MAX",
        "MINIMUM", "MIN",
        "COLLECTED", "COLL",
        "ENFORCEMENT", "ENFRC",
        "CONDUCTING", "COND",
        "GENERAL", "GNRL",
        "FORMAL", "FRML",
        "INFORMAL", "INFRML",
        "CRITERION", "CRIT",
        "CRITICAL", "CRIT",
        "SIGNATURE", "SIGN",
        "OBLIGATION", "OBLGTN",
        "PROPERTY", "PROP",
        "POPULATION", "POPL",
        "QUALIFYING", "QUAL",
        "SINGLE", "SNGL",
        "EFFLUENT", "EFFLU",
        "GUIDELINE", "GUIDE",
        "WASTEWATER", "WW",
        "STORAGE", "STOR",
        "NATIONAL", "NAT",
        "PRIORITIES", "PRIO",
        "PRIORITY", "PRIO",
        "PRETREATMENT", "PRETR",
        "PREDEVELOPMENT", "PREDEV",
        "PROXIMITY", "PROX",
        "GROUP", "GRP",
        "POLLUTANT", "POLUT",
        "POLLUTANTS", "POLLUTANTS",
        "COMPONENT", "COMP",
        "INDUSTRIAL", "INDST",
        "LINKAGE", "LNK",
        "GOVERNMENT", "GOV",
        "NARRATIVE", "NARR",
        "CHARACTERISTICS", "CHAR",
        "SUMMARY", "SUMM",
        "REISSUANCE", "REISSU",
        "STATUS", "STAT",
        "LIMIT", "LMT",
        "LIMITS", "LMTS",
        "INCINERATOR", "INCIN",
        "POLICY", "PLCY",
        "TREATMENT", "TRTMNT",
        "AGENCY", "AGNCY",
        "SOURCES", "SRCS",
        "SOURCE", "SRC",
        "FUNDING", "FUND",
        "CREDIT", "CRDT",
        "CREDITS", "CRDTS",
        "LOCAL", "LOC",
        "MANURE", "MNUR",
        "ANNUAL", "ANNUL",
        "RECEIPT", "RCPT",
        "TARGET", "TRGT",

        "DEFINED", "DFND",
        "DURING", "DRNG",
        "LITTER", "LTTR",
        "LIVESTOCK", "LVSTCK",
        "CAPACITY", "CPCTY",
        "DATA", "DAT",
        "PARTNER", "PRTNER",
        "ENTERED", "ENTERD",
        "ACTUAL", "ACTUL",
        "DEFICIENCIES", "DFCNC",
        "INTERPRETATION", "INTRPRT",
        "TOXICANT", "TOXCNT",
        "SLUDGE", "SLDG",
        "STANDARDS", "STNDR",
        "FILED", "FILD",
        "SUITS", "SUTS",
        "AGAINST", "AGINST",
        "HAVE", "HAV",
        "EARTH", "ERTH",
        "ATTRACTION", "A",
        "CONFINEMENT", "CONFINEMNT",
        "HOUSED", "HOUSD",
        "ELEMENT", "ELM",
        "BASED", "BS",
        "MEASURES", "MSR",
        "PRACTICES", "PRACTICE",
        "UNDER", "UNDR",
        "HAULED", "HULED",
        "IDENTIFIED", "IDNTFD",
        "REVIEW", "RVIW",
        "DOMESTIC", "DOMSTIC",
        "WASTES", "WSTES",
        "CRIMINAL", "CRIMINL",
        "BEEN", "BEE",
        "STEPS", "STPS",
        "MONTH", "MN",


        "PARTICIPATION", "PRTICIPTON",
        "PUBLIC", "PBLC",
        "REMEDIAL", "RMD",
        "INFLUENT", "INFLUNT",
        "WHICH", "WHC",
        "PREVENT", "PREVNT",
        "MITIGATE", "MITIGTE",
        "REDUCE", "RDUCE",
    })]

    [DefaultElementNamePostfixLengthsAttribute(
                    "Text", "255",
                    "Name", "128",
                    "Code", "50",
                    "Value", "50",
                    "CodeContext", "50",
                    "Identifier", "50",
                    "UnitName", "50",
                    "PrecisionText", "50",
                    "Number", "20",
                    "Version", "20",
                    "NumberText", "20",
                    "Indicator", "50",
                    "IndividualFullName", "255",
                    "srsDimension", "10",
                    "srsName", "255"
    )]

    [AppliedAttribute(typeof(DischargeMonitoringReport), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "ItemsElementName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(BasicPermit), "ElectronicReportingWaiverData", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(BasicPermit), "MajorMinorStatus", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(BasicPermit), "DMRNonReceiptStatus", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(Facility), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(Facility), "ItemsElementName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeneralPermit), "ElectronicReportingWaiverData", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(GeneralPermit), "DMRNonReceiptStatus", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(GeneralPermit), "MajorMinorStatus", typeof(SameTableAttribute))]


    [AppliedAttribute(typeof(UnpermittedFacility), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(UnpermittedFacility), "ItemsElementName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(SewerOverflowLocationDetail), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(SewerOverflowLocationDetail), "ItemsElementName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(SewerOverflowBypassReportEvent), "SewerOverflowLocationDetail", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(WastewaterFlowTreatmentTechnology), "Items", typeof(DbIgnoreAttribute))]



    [AppliedAttribute(typeof(TransactionHeader), "TransactionType", typeof(DbNullAttribute))]

    [AppliedAttribute(typeof(BasicPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(BiosolidsAnnualProgramReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(BiosolidsPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CAFOAnnualProgramReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CAFOPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CSOLongTermControlPlanData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CWA316bProgramReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CaseFileLinkageData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CollectionSystemPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ComplianceMonitoringData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ComplianceMonitoringLinkageData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ComplianceScheduleData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CopyMGPLimitSetData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CopyMGPMS4RequirementData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(DMRViolationData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(DischargeMonitoringReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(EffluentTradePartnerData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(EnforcementActionMilestoneData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(EnforcementActionViolationLinkageData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(FinalOrderViolationLinkageData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(FormalEnforcementActionData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(GeneralPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(HistoricalPermitScheduleEventsData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(InformalEnforcementActionData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LimitSetData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LimitsData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MasterGeneralPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(NPDESVariancePermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(NarrativeConditionScheduleData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(POTWPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(POTWTreatmentTechnologyPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ParameterLimitsData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermitReissuanceData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermitTerminationData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermitTrackingEventData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermittedFeatureData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PretreatmentPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PretreatmentProgramReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWConstructionPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWIndustrialAnnualReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWIndustrialPermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWMS4AnnualProgramReportData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWMS4PermitData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ScheduleEventViolationData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SingleEventViolationData), "TransactionHeader", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(UnpermittedFacilityData), "TransactionHeader", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(BasicPermitData), "BasicPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(BiosolidsAnnualProgramReportData), "BiosolidsAnnualProgramReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(BiosolidsPermitData), "BiosolidsPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CAFOAnnualProgramReportData), "CAFOAnnualProgramReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CAFOPermitData), "CAFOPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CSOLongTermControlPlanData), "LTCPPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CWA316bProgramReportData), "CWA316bProgramReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CaseFileLinkageData), "CaseFileLinkage", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CollectionSystemPermitData), "CollectionSystemPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ComplianceMonitoringData), "ComplianceMonitoring", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ComplianceMonitoringLinkageData), "ComplianceMonitoringLinkage", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ComplianceScheduleData), "ComplianceSchedule", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CopyMGPLimitSetData), "CopyMGPLimitSet", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CopyMGPMS4RequirementData), "CopyMGPMS4Requirement", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(DMRViolationData), "DMRViolation", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(DischargeMonitoringReportData), "DischargeMonitoringReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(EffluentTradePartnerData), "EffluentTradePartner", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(EnforcementActionMilestoneData), "Milestone", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(EnforcementActionViolationLinkageData), "EnforcementActionViolationLinkage", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(FinalOrderViolationLinkageData), "FinalOrderViolationLinkage", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(FormalEnforcementActionData), "FormalEnforcementAction", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(GeneralPermitData), "GeneralPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(HistoricalPermitScheduleEventsData), "HistoricalPermitScheduleEvents", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(InformalEnforcementActionData), "InformalEnforcementAction", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LimitSetData), "LimitSet", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LimitsData), "Limits", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MasterGeneralPermitData), "MasterGeneralPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(NPDESVariancePermitData), "NPDESVariancePermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(NarrativeConditionScheduleData), "NarrativeCondition", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(POTWPermitData), "POTWPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(POTWTreatmentTechnologyPermitData), "POTWTreatmentTechnologyPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ParameterLimitsData), "ParameterLimits", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermitReissuanceData), "PermitReissuance", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermitTerminationData), "PermitTermination", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermitTrackingEventData), "PermitTrackingEvent", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PermittedFeatureData), "PermittedFeature", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PretreatmentPermitData), "PretreatmentPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(PretreatmentProgramReportData), "PretreatmentProgramReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWConstructionPermitData), "SWConstructionPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWIndustrialAnnualReportData), "SWIndustrialAnnualReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWIndustrialPermitData), "SWIndustrialPermit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWMS4AnnualProgramReportData), "SWMS4AnnualProgramReport", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWMS4PermitData), "SWMS4Permit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ScheduleEventViolationData), "ScheduleEventViolation", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SingleEventViolationData), "SingleEventViolation", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(UnpermittedFacilityData), "UnpermittedFacility", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(CopyMGPLimitSet), "TargetGeneralPermitLimitSetKeyElements", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CopyMGPLimitSet), "TargetPermittedFeatureGroup", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CopyMGPLimitSet), "TargetLimitSetGroup", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(CoolingWaterIntakeStructureInformation), "CoolingWaterIntakeStructureLocation", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CoolingWaterIntakeStructureInformation), "CoolingWaterIntakeStructureSourceWater", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(MS4RegulatedEntity), "MS4RegulatedEntityCategory", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MS4RegulatedEntity), "MS4RegulatedEntityOwnershipLevel", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(MS4PublicEducationRequirements), "MS4PublicEducationDelivery", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MS4PublicEducationRequirements), "MS4PublicEducationSubject", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MS4PublicEducationRequirements), "MS4PublicEducationAudience", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(MS4PublicInvolvementRequirements), "MS4PublicInvolvementDelivery", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MS4PublicInvolvementRequirements), "MS4PublicInvolvementSubject", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MS4PublicInvolvementRequirements), "MS4PublicInvolvementParticipant", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(ControlAuthorityProgramInformation), "POTWDischargeContamination", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ControlAuthorityProgramInformation), "POTWBiosolidsContamination", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(IndustrialUserInformation), "IUComplianceMonitoring", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(SewerOverflowBypassDurationDetail), "SewerOverflowBypassDurationDateTime", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SewerOverflowBypassReportEvent), "SewerOverflowBypassDurationDetail", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SewerOverflowBypassReportEvent), "SewerOverflowBypassVolumeDetail", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(POTWTreatmentTechnologyPermit), "WastewaterFlowTreatmentTechnology", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(CAFOLandApplicationFieldInformation), "CAFOLandApplicationFieldCropInformation", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CAFOLandApplicationFieldInformation), "CAFONarrativeRateApproachSoilMonitoring", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(CAFOLandApplicationFieldInformation), "CAFONarrativeRateApproachSupplementalFertilizer", typeof(SameTableAttribute))]

    // NO: [AppliedAttribute(typeof(PretreatmentProgramReport), "ControlAuthorityProgramInformation", typeof(SameTableAttribute))]
    // NO: [AppliedAttribute(typeof(PretreatmentProgramReport), "IndustrialUserInventory", typeof(SameTableAttribute))]
    // NO: [AppliedAttribute(typeof(CopyMGPMS4Requirement), "MasterGeneralPermitMS4Requirement", typeof(SameTableAttribute))]
    // NO: [AppliedAttribute(typeof(SWConstructionPermit), "GPCFNoticeOfIntent", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(SWConstructionPermit), "GPCFLowErosivityWaiver", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWConstructionPermit), "HistoricPreservationData", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(SWConstructionPermit), "GPCFNoticeOfTermination", typeof(SameTableAttribute))]

    public partial class MappingAttributes
    {
    }

    // Removed for 5.14
    ////[AdditionalCreateIndexAttribute("ICS_BASIC_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_BS_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CAFO_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CSO_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_GNRL_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_POTW_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PRETR_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SW_CNST_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SW_INDST_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SWMS_4_LARGE_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SWMS_4_SMALL_PRMT", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_UNPRMT_FAC", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CMPL_MON", "CMPL_MON_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CMPL_MON_LNK", "CMPL_MON_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PRMT_TRACK_EVT", "PRMT_IDENT, PRMT_TRACK_EVT_CODE, PRMT_TRACK_EVT_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CSO_EVT_REP", "PRMT_IDENT, CSO_EVT_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SW_EVT_REP", "PRMT_IDENT, DATE_STRM_EVT_SMPL", true)]
    ////[AdditionalCreateIndexAttribute("ICS_HIST_PRMT_SCHD_EVTS", "PRMT_IDENT, PRMT_EFFECTIVE_DATE, NARR_COND_NUM, SCHD_EVT_CODE, SCHD_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PRMT_FEATR", "PRMT_IDENT, PRMT_FEATR_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_LMT_SET", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR", true)]
    ////[AdditionalCreateIndexAttribute("ICS_DSCH_MON_REP", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR, MON_PERIOD_END_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_DMR_PROG_REP_LNK", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR, MON_PERIOD_END_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_DMR_VIOL", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR, MON_PERIOD_END_DATE, PARAM_CODE, MON_SITE_DESC_CODE, LMT_SEASON_NUM, NUM_REP_CODE, NUM_REP_VIOL_CODE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PARAM_LMTS", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR, PARAM_CODE, MON_SITE_DESC_CODE, LMT_SEASON_NUM", true)]
    ////[AdditionalCreateIndexAttribute("ICS_LMTS", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR, PARAM_CODE, MON_SITE_DESC_CODE, LMT_SEASON_NUM, LMT_START_DATE, LMT_END_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_EFFLU_TRADE_PRTNER", "PRMT_IDENT, PRMT_FEATR_IDENT, LMT_SET_DESIGNATOR, PARAM_CODE, MON_SITE_DESC_CODE, LMT_SEASON_NUM, LMT_START_DATE, LMT_END_DATE, LMT_MOD_EFFECTIVE_DATE, TRADE_ID", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CAFO_ANNUL_REP", "PRMT_IDENT, PRMT_AUTH_REP_RCVD_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_LOC_LMTS_PROG_REP", "PRMT_IDENT, PRMT_AUTH_REP_RCVD_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PRETR_PERF_SUMM", "PRMT_IDENT, PRETR_PERF_SUMM_END_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_BS_PROG_REP", "PRMT_IDENT, REP_COVERAGE_END_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SNGL_EVT_VIOL", "PRMT_IDENT, SNGL_EVT_VIOL_CODE, SNGL_EVT_VIOL_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SSO_ANNUL_REP", "PRMT_IDENT, SSO_ANNUL_REP_RCVD_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SSO_EVT_REP", "PRMT_IDENT, SSO_EVT_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SSO_MONTHLY_EVT_REP", "PRMT_IDENT, SSO_MONTHLY_REP_RCVD_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SWMS_4_PROG_REP", "PRMT_IDENT, SW_MS_4_REP_RCVD_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PRMT_REISSU", "PRMT_IDENT, PRMT_ISSUE_DATE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_PRMT_TERM", "PRMT_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_FRML_ENFRC_ACTN", "ENFRC_ACTN_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_INFRML_ENFRC_ACTN", "ENFRC_ACTN_IDENT", true)]
    ////[AdditionalCreateIndexAttribute("ICS_CMPL_SCHD", "ENFRC_ACTN_IDENT, FINAL_ORDER_IDENT, PRMT_IDENT, CMPL_SCHD_NUM", true)]
    ////[AdditionalCreateIndexAttribute("ICS_ENFRC_ACTN_MILESTONE", "ENFRC_ACTN_IDENT,MILESTONE_TYPE_CODE", true)]
    ////[AdditionalCreateIndexAttribute("ICS_NARR_COND_SCHD", "PRMT_IDENT, NARR_COND_NUM", true)]
    ////[AdditionalCreateIndexAttribute("ICS_SW_INDST_ANNUL_REP", "PRMT_IDENT, INDST_SW_ANNUL_REP_RCVD_DATE", true)]

    public partial class PayloadData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(Items, delegate(object item)
            {
                IAfterLoadFromDatabase afterLoadFromDatabase = item as IAfterLoadFromDatabase;
                if (afterLoadFromDatabase != null)
                {
                    afterLoadFromDatabase.AfterLoadFromDatabase();
                }
            });
        }
        public virtual void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(Items, delegate(object item)
            {
                IBeforeSaveToDatabase beforeSaveToDatabase = item as IBeforeSaveToDatabase;
                if (beforeSaveToDatabase != null)
                {
                    beforeSaveToDatabase.BeforeSaveToDatabase();
                }
            });
        }
        public static IDictionary<string, DbAppendSelectWhereClause> GetDefaultSelectClauses(SpringBaseDao dao)
        {
            string[] transactionTypeTableNames = new string[]
            {
                "ICS_BASIC_PRMT",
                "ICS_BS_ANNUL_PROG_REP",
                "ICS_BS_PRMT",
                "ICS_CAFO_ANNUL_PROG_REP",
                "ICS_CAFO_PRMT",
                "ICS_CMPL_MON",
                "ICS_CMPL_MON_LNK",
                "ICS_CMPL_SCHD",
                "ICS_COLL_SYSTM_PRMT",
                "ICS_COPY_MGP_LMT_SET",
                "ICS_COPY_MGPMS_4_REQ",
                "ICS_CSO_LONG_TERM_CONTROL_PLAN",
                "ICS_CWA_316B_PROG_REP",
                "ICS_DMR_VIOL",
                "ICS_DSCH_MON_REP",
                "ICS_EFFLU_TRADE_PRTNER",
                "ICS_ENFRC_ACTN_MILESTONE",
                "ICS_ENFRC_ACTN_VIOL_LNK",
                "ICS_FINAL_ORDER_VIOL_LNK",
                "ICS_FRML_ENFRC_ACTN",
                "ICS_GNRL_PRMT",
                "ICS_HIST_PRMT_SCHD_EVTS",
                "ICS_INFRML_ENFRC_ACTN",
                "ICS_LMT_SET",
                "ICS_LMTS",
                "ICS_MASTER_GNRL_PRMT",
                "ICS_NARR_COND_SCHD",
                "ICS_NPDES_VARIANCE_PRMT",
                "ICS_PARAM_LMTS",
                "ICS_POTW_PRMT",
                "ICS_POTW_TRTMNT_TECHNOLOGY_PRMT",
                "ICS_PRETR_PRMT",
                "ICS_PRETR_PROG_REP",
                "ICS_PRMT_FEATR",
                "ICS_PRMT_REISSU",
                "ICS_PRMT_TERM",
                "ICS_PRMT_TRACK_EVT",
                "ICS_SCHD_EVT_VIOL",
                "ICS_SEWER_OVRFLW_BYPASS_EVT_REP",
                "ICS_SNGL_EVT_VIOL",
                "ICS_SW_CNST_PRMT",
                "ICS_SW_INDST_ANNUL_REP",
                "ICS_SW_INDST_PRMT",
                "ICS_SWMS_4_ANNUL_PROG_REP",
                "ICS_SWMS_4_PRMT",
                "ICS_UNPRMT_FAC",


                // Removed:
                //"ICS_BS_PROG_REP",
                //"ICS_CAFO_ANNUL_REP",
                //"ICS_CSO_EVT_REP",
                //"ICS_CSO_PRMT",
                //"ICS_DMR_PROG_REP_LNK",
                //"ICS_LOC_LMTS_PROG_REP",
                //"ICS_PRETR_PERF_SUMM",
                //"ICS_SSO_ANNUL_REP",
                //"ICS_SSO_EVT_REP",
                //"ICS_SSO_MONTHLY_EVT_REP",
                //"ICS_SW_EVT_REP",
                //"ICS_SWMS_4_LARGE_PRMT",
                //"ICS_SWMS_4_PROG_REP",
                //"ICS_SWMS_4_SMALL_PRMT",
                //"ICS_COPY_MGP_LIMIT_SET",
            };

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>(60);
            foreach (string tableName in transactionTypeTableNames)
            {
                selectClauses.Add(tableName, new DbAppendSelectWhereClause("TRANSACTION_TYPE IS NOT NULL", null));
            }
            return selectClauses;
        }
    }
    public partial class SewerOverflowBypassReportEvent : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            List<string> items = null;
            List<ItemsChoiceType3> itemsElementName = null;
            if (LatitudeMeasure != null)
            {
                CollectionUtils.Add(LatitudeMeasure.ToString(), ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType3.LatitudeMeasure, ref itemsElementName);
            }
            if (LongitudeMeasure != null)
            {
                CollectionUtils.Add(LongitudeMeasure.ToString(), ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType3.LongitudeMeasure, ref itemsElementName);
            }
            if (PermittedFeatureIdentifier != null)
            {
                CollectionUtils.Add(PermittedFeatureIdentifier, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType3.PermittedFeatureIdentifier, ref itemsElementName);
            }
            if (items != null)
            {
                SewerOverflowLocationDetail = new SewerOverflowLocationDetail()
                {
                    Items = items.ToArray(),
                    ItemsElementName = itemsElementName.ToArray(),
                };
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (SewerOverflowLocationDetail != null)
            {
                int index = 0;
                CollectionUtils.ForEach(SewerOverflowLocationDetail.ItemsElementName, delegate (ICISNPDES_514.ItemsChoiceType3 itemsElementName)
                {
                    if ((SewerOverflowLocationDetail.Items == null) || (index >= SewerOverflowLocationDetail.Items.Length))
                    {
                        throw new ArgException("The SewerOverflowLocationDetail.Items array does not contain the required number of elements: {0}",
                                               SewerOverflowLocationDetail.ItemsElementName.Length.ToString());
                    }
                    var item = SewerOverflowLocationDetail.Items[index++];
                    switch (itemsElementName)
                    {
                        case ICISNPDES_514.ItemsChoiceType3.LatitudeMeasure:
                            LatitudeMeasure = new Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal();
                            LatitudeMeasure.SetValue(item);
                            break;
                        case ICISNPDES_514.ItemsChoiceType3.LongitudeMeasure:
                            LongitudeMeasure = new Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal();
                            LatitudeMeasure.SetValue(item);
                            break;
                        case ICISNPDES_514.ItemsChoiceType3.PermittedFeatureIdentifier:
                            PermittedFeatureIdentifier = item;
                            break;
                        default:
                            throw new ArgException("Unrecognized ItemsElementName was specified for the SewerOverflowBypassReportEvent: {0}", itemsElementName.ToString());
                    }
                });
            }
        }

        // SewerOverflowLocationDetail:
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("9", "7")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal LatitudeMeasure;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Decimal")]
        [Windsor.Commons.XsdOrm2.DbColumnScaleAttribute("10", "6")]
        public Windsor.Node2008.WNOSPlugin.ICISNPDES_514.RemoveTrailingZerosDecimal LongitudeMeasure;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;
    }
    public partial class Facility : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            List<string> items = null;
            List<ItemsChoiceType> itemsElementName = null;
            if (LocalityName != null)
            {
                CollectionUtils.Add(LocalityName, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType.LocalityName, ref itemsElementName);
            }
            if (LocationAddressCityCode != null)
            {
                CollectionUtils.Add(LocationAddressCityCode, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType.LocationAddressCityCode, ref itemsElementName);
            }
            if (LocationAddressCountyCode != null)
            {
                CollectionUtils.Add(LocationAddressCountyCode, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType.LocationAddressCountyCode, ref itemsElementName);
            }
            if (items != null)
            {
                Items = items.ToArray();
                ItemsElementName = itemsElementName.ToArray();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            int index = 0;
            CollectionUtils.ForEach(ItemsElementName, delegate (ICISNPDES_514.ItemsChoiceType itemsElementName)
            {
                if ((Items == null) || (index >= Items.Length))
                {
                    throw new ArgException("The Facility.Items array does not contain the required number of elements: {0}",
                                           ItemsElementName.Length.ToString());
                }
                var item = Items[index++];
                switch (itemsElementName)
                {
                    case ICISNPDES_514.ItemsChoiceType.LocalityName:
                        LocalityName = item;
                        break;
                    case ICISNPDES_514.ItemsChoiceType.LocationAddressCityCode:
                        LocationAddressCityCode = item;
                        break;
                    case ICISNPDES_514.ItemsChoiceType.LocationAddressCountyCode:
                        LocationAddressCountyCode = item;
                        break;
                    default:
                        throw new ArgException("Unrecognized ItemsElementName was specified for the Facility: {0}", itemsElementName.ToString());
                }
            });
        }

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string LocalityName;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string LocationAddressCityCode;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(5)]
        public string LocationAddressCountyCode;
    }
    public partial class PermittedFeatureData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (PermittedFeature != null)
            {
                PermittedFeature.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (PermittedFeature != null)
            {
                PermittedFeature.BeforeSaveToDatabase();
            }
        }
    }
    public partial class PermittedFeature : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (!CollectionUtils.IsNullOrEmpty(ImpairedWaterPollutants))
            ////{
            ////    if (PollutantList == null)
            ////    {
            ////        PollutantList = new PollutantList();
            ////    }
            ////    PollutantList.ImpairedWaterPollutants = ImpairedWaterPollutants.Select(e => e.GetXmlString()).ToArray();
            ////}
            ////if (!CollectionUtils.IsNullOrEmpty(TMDLPollutants))
            ////{
            ////    if (PollutantList == null)
            ////    {
            ////        PollutantList = new PollutantList();
            ////    }
            ////    PollutantList.TMDLPollutants = TMDLPollutants;
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (PollutantList != null)
            ////{
            ////    ImpairedWaterPollutants = PollutantList.ImpairedWaterPollutants.Select(e => new CustomXmlStringFormatInt32(int.Parse(e))).ToArray();
            ////    TMDLPollutants = PollutantList.TMDLPollutants;
            ////}
        }
    }
    public partial class BiosolidsAnnualProgramReportData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (BiosolidsAnnualProgramReport != null)
            {
                BiosolidsAnnualProgramReport.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (BiosolidsAnnualProgramReport != null)
            {
                BiosolidsAnnualProgramReport.BeforeSaveToDatabase();
            }
        }
    }
    public partial class BiosolidsAnnualProgramReport : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (!CollectionUtils.IsNullOrEmpty(AnalyticalMethodData))
            ////{
            ////    AnalyticalMethods = new ICISNPDES_514.AnalyticalMethods();
            ////    AnalyticalMethods.AnalyticalMethodData = AnalyticalMethodData;
            ////}
            ////if (!CollectionUtils.IsNullOrEmpty(ManagementPracticeData))
            ////{
            ////    BiosolidsManagementPractices = new ICISNPDES_514.BiosolidsManagementPractices();
            ////    BiosolidsManagementPractices.ManagementPracticeData = ManagementPracticeData;
            ////    foreach (var managementPracticeData in BiosolidsManagementPractices.ManagementPracticeData)
            ////    {
            ////        managementPracticeData.AfterLoadFromDatabase();
            ////    }
            ////}
            ////if (Contact != null)
            ////{
            ////    CertifierProgramReportContact = new CertifierProgramReportContact();
            ////    CertifierProgramReportContact.Contact = Contact;
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (AnalyticalMethods != null)
            ////{
            ////    AnalyticalMethodData = AnalyticalMethods.AnalyticalMethodData;
            ////}
            ////if ((BiosolidsManagementPractices != null) && (BiosolidsManagementPractices.ManagementPracticeData != null))
            ////{
            ////    ManagementPracticeData = BiosolidsManagementPractices.ManagementPracticeData;
            ////    foreach (var biosolidsManagementPractice in ManagementPracticeData)
            ////    {
            ////        biosolidsManagementPractice.BeforeSaveToDatabase();
            ////    }
            ////}
            ////if (CertifierProgramReportContact != null)
            ////{
            ////    Contact = CertifierProgramReportContact.Contact;
            ////}
        }
    }
    // Removed for 5.14
    ////public partial class BiosolidsManagementPracticesData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    ////{
    ////    public virtual void AfterLoadFromDatabase()
    ////    {
    ////        // Removed for 5.14
    ////        ////if ((LandApplicationSubCategoryCode != null) && (OtherSubCategoryCode != null))
    ////        ////{
    ////        ////    throw new ArgException("Both LandApplicationSubCategoryCode and OtherSubCategoryCode cannot be set for the element BiosolidsManagementPracticesData");
    ////        ////}
    ////        ////if (LandApplicationSubCategoryCode != null)
    ////        ////{
    ////        ////    Item = LandApplicationSubCategoryCode;
    ////        ////    ItemElementName = ICISNPDES_514.ItemElementName.LandApplicationSubCategoryCode;
    ////        ////}
    ////        ////if (OtherSubCategoryCode != null)
    ////        ////{
    ////        ////    Item = OtherSubCategoryCode;
    ////        ////    ItemElementName = ICISNPDES_514.ItemElementName.OtherSubCategoryCode;
    ////        ////}
    ////        ////if (Contact != null)
    ////        ////{
    ////        ////    ThirdPartyProgramReportContact = new ThirdPartyProgramReportContact();
    ////        ////    ThirdPartyProgramReportContact.Contact = Contact;
    ////        ////}
    ////        ////if (!CollectionUtils.IsNullOrEmpty(FacilityAddress))
    ////        ////{
    ////        ////    ThirdPartyProgramReportAddress = new ThirdPartyProgramReportAddress();
    ////        ////    ThirdPartyProgramReportAddress.Address = FacilityAddress;
    ////        ////}
    ////    }
    ////    public virtual void BeforeSaveToDatabase()
    ////    {
    ////        // Removed for 5.14
    ////        ////if (Item != null)
    ////        ////{
    ////        ////    switch (ItemElementName)
    ////        ////    {
    ////        ////        case ICISNPDES_514.ItemElementName.LandApplicationSubCategoryCode:
    ////        ////            LandApplicationSubCategoryCode = Item;
    ////        ////            break;
    ////        ////        case ICISNPDES_514.ItemElementName.OtherSubCategoryCode:
    ////        ////            OtherSubCategoryCode = Item;
    ////        ////            break;
    ////        ////        default:
    ////        ////            throw new ArgException("Unrecognized ItemElementName was specified for the BiosolidsManagementPracticesData: {0}", ItemElementName.ToString());
    ////        ////    }
    ////        ////}
    ////        ////if (ThirdPartyProgramReportContact != null)
    ////        ////{
    ////        ////    Contact = ThirdPartyProgramReportContact.Contact;
    ////        ////}
    ////        ////if ((ThirdPartyProgramReportAddress != null) && !CollectionUtils.IsNullOrEmpty(ThirdPartyProgramReportAddress.Address))
    ////        ////{
    ////        ////    FacilityAddress = ThirdPartyProgramReportAddress.Address;
    ////        ////}
    ////    }
    ////}
    public partial class SWConstructionPermitData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (SWConstructionPermit != null)
            {
                SWConstructionPermit.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (SWConstructionPermit != null)
            {
                SWConstructionPermit.BeforeSaveToDatabase();
            }
        }
    }
    public partial class SWConstructionPermit : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (!CollectionUtils.IsNullOrEmpty(ConstructionSiteCode))
            ////{
            ////    if (ConstructionSiteList == null)
            ////    {
            ////        ConstructionSiteList = new ConstructionSiteList();
            ////    }
            ////    ConstructionSiteList.ConstructionSiteCode = ConstructionSiteCode;
            ////}
            ////if (ConstructionSiteOtherText != null)
            ////{
            ////    if (ConstructionSiteList == null)
            ////    {
            ////        ConstructionSiteList = new ConstructionSiteList();
            ////    }
            ////    ConstructionSiteList.ConstructionSiteOtherText = ConstructionSiteOtherText;
            ////}
            ////if (SubsurfaceEarthDisturbanceIndicator != null)
            ////{
            ////    if (HistoricPreservationData == null)
            ////    {
            ////        HistoricPreservationData = new HistoricPreservationData();
            ////    }
            ////    HistoricPreservationData.SubsurfaceEarthDisturbanceIndicator = SubsurfaceEarthDisturbanceIndicator;
            ////}
            ////if (PriorSurveysEvaluationsIndicator != null)
            ////{
            ////    if (HistoricPreservationData == null)
            ////    {
            ////        HistoricPreservationData = new HistoricPreservationData();
            ////    }
            ////    HistoricPreservationData.PriorSurveysEvaluationsIndicator = PriorSurveysEvaluationsIndicator;
            ////}
            ////if (SubsurfaceEarthDisturbanceControlIndicator != null)
            ////{
            ////    if (HistoricPreservationData == null)
            ////    {
            ////        HistoricPreservationData = new HistoricPreservationData();
            ////    }
            ////    HistoricPreservationData.SubsurfaceEarthDisturbanceControlIndicator = SubsurfaceEarthDisturbanceControlIndicator;
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (ConstructionSiteList != null)
            ////{
            ////    ConstructionSiteCode = ConstructionSiteList.ConstructionSiteCode;
            ////    ConstructionSiteOtherText = ConstructionSiteList.ConstructionSiteOtherText;
            ////}
            ////if (HistoricPreservationData != null)
            ////{
            ////    SubsurfaceEarthDisturbanceIndicator = HistoricPreservationData.SubsurfaceEarthDisturbanceIndicator;
            ////    PriorSurveysEvaluationsIndicator = HistoricPreservationData.PriorSurveysEvaluationsIndicator;
            ////    SubsurfaceEarthDisturbanceControlIndicator = HistoricPreservationData.SubsurfaceEarthDisturbanceControlIndicator;
            ////}
        }
    }
    public partial class UnpermittedFacilityData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (UnpermittedFacility != null)
            {
                UnpermittedFacility.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (UnpermittedFacility != null)
            {
                UnpermittedFacility.BeforeSaveToDatabase();
            }
        }
    }
    public partial class UnpermittedFacility : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            List<string> items = null;
            List<ItemsChoiceType1> itemsElementName = null;
            if (LocalityName != null)
            {
                CollectionUtils.Add(LocalityName, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType1.LocalityName, ref itemsElementName);
            }
            if (LocationAddressCityCode != null)
            {
                CollectionUtils.Add(LocationAddressCityCode, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType1.LocationAddressCityCode, ref itemsElementName);
            }
            if (LocationAddressCountyCode != null)
            {
                CollectionUtils.Add(LocationAddressCountyCode, ref items);
                CollectionUtils.Add(ICISNPDES_514.ItemsChoiceType1.LocationAddressCountyCode, ref itemsElementName);
            }
            if (items != null)
            {
                Items = items.ToArray();
                ItemsElementName = itemsElementName.ToArray();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            int index = 0;
            CollectionUtils.ForEach(ItemsElementName, delegate (ICISNPDES_514.ItemsChoiceType1 itemsElementName)
            {
                if ((Items == null) || (index >= Items.Length))
                {
                    throw new ArgException("The UnpermittedFacility.Items array does not contain the required number of elements: {0}",
                                           ItemsElementName.Length.ToString());
                }
                var item = Items[index++];
                switch (itemsElementName)
                {
                    case ICISNPDES_514.ItemsChoiceType1.LocalityName:
                        LocalityName = item;
                        break;
                    case ICISNPDES_514.ItemsChoiceType1.LocationAddressCityCode:
                        LocationAddressCityCode = item;
                        break;
                    case ICISNPDES_514.ItemsChoiceType1.LocationAddressCountyCode:
                        LocationAddressCountyCode = item;
                        break;
                    default:
                        throw new ArgException("Unrecognized ItemsChoiceType1 was specified for the UnpermittedFacility: {0}", itemsElementName.ToString());
                }
            });
        }

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string LocalityName;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(12)]
        public string LocationAddressCityCode;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(5)]
        public string LocationAddressCountyCode;
    }
    public partial class BasicPermitData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (BasicPermit != null)
            {
                BasicPermit.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (BasicPermit != null)
            {
                BasicPermit.BeforeSaveToDatabase();
            }
        }
    }
    public partial class BasicPermit : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (MajorMinorStatusIndicatorSpecified || MajorMinorStatusStartDateSpecified)
            ////{
            ////    MajorMinorStatus = new MajorMinorStatus()
            ////    {
            ////        MajorMinorStatusIndicator = MajorMinorStatusIndicator,
            ////        MajorMinorStatusIndicatorSpecified = MajorMinorStatusIndicatorSpecified,
            ////        MajorMinorStatusStartDate = MajorMinorStatusStartDate,
            ////        MajorMinorStatusStartDateSpecified = MajorMinorStatusStartDateSpecified,
            ////    };
            ////}
            ////if (DMRNonReceiptStatusIndicatorSpecified || DMRNonReceiptStatusStartDateSpecified)
            ////{
            ////    DMRNonReceiptStatus = new DMRNonReceiptStatus()
            ////    {
            ////        DMRNonReceiptStatusIndicator = DMRNonReceiptStatusIndicator,
            ////        DMRNonReceiptStatusIndicatorSpecified = DMRNonReceiptStatusIndicatorSpecified,
            ////        DMRNonReceiptStatusStartDate = DMRNonReceiptStatusStartDate,
            ////        DMRNonReceiptStatusStartDateSpecified = DMRNonReceiptStatusStartDateSpecified,
            ////    };
            ////}
            ////if (ElectronicReportingWaiverTypeCode != null)
            ////{
            ////    if (ElectronicReportingWaiverData == null)
            ////    {
            ////        ElectronicReportingWaiverData = new ElectronicReportingWaiverData();
            ////    }
            ////    ElectronicReportingWaiverData.ElectronicReportingWaiverTypeCode = ElectronicReportingWaiverTypeCode;
            ////}
            ////if (ElectronicReportingWaiverEffectiveDate != null)
            ////{
            ////    if (ElectronicReportingWaiverData == null)
            ////    {
            ////        ElectronicReportingWaiverData = new ElectronicReportingWaiverData();
            ////    }
            ////    ElectronicReportingWaiverData.ElectronicReportingWaiverEffectiveDate = ElectronicReportingWaiverEffectiveDate;
            ////}
            ////if (ElectronicReportingWaiverExpirationDate != null)
            ////{
            ////    if (ElectronicReportingWaiverData == null)
            ////    {
            ////        ElectronicReportingWaiverData = new ElectronicReportingWaiverData();
            ////    }
            ////    ElectronicReportingWaiverData.ElectronicReportingWaiverExpirationDate = ElectronicReportingWaiverExpirationDate;
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (MajorMinorStatus != null)
            ////{
            ////    MajorMinorStatusIndicator = MajorMinorStatus.MajorMinorStatusIndicator;
            ////    MajorMinorStatusIndicatorSpecified = MajorMinorStatus.MajorMinorStatusIndicatorSpecified;
            ////    MajorMinorStatusStartDate = MajorMinorStatus.MajorMinorStatusStartDate;
            ////    MajorMinorStatusStartDateSpecified = MajorMinorStatus.MajorMinorStatusStartDateSpecified;
            ////}
            ////if (DMRNonReceiptStatus != null)
            ////{
            ////    DMRNonReceiptStatusIndicator = DMRNonReceiptStatus.DMRNonReceiptStatusIndicator;
            ////    DMRNonReceiptStatusIndicatorSpecified = DMRNonReceiptStatus.DMRNonReceiptStatusIndicatorSpecified;
            ////    DMRNonReceiptStatusStartDate = DMRNonReceiptStatus.DMRNonReceiptStatusStartDate;
            ////    DMRNonReceiptStatusStartDateSpecified = DMRNonReceiptStatus.DMRNonReceiptStatusStartDateSpecified;
            ////}
            ////if (ElectronicReportingWaiverData != null)
            ////{
            ////    ElectronicReportingWaiverTypeCode = ElectronicReportingWaiverData.ElectronicReportingWaiverTypeCode;
            ////    ElectronicReportingWaiverEffectiveDate = ElectronicReportingWaiverData.ElectronicReportingWaiverEffectiveDate;
            ////    ElectronicReportingWaiverEffectiveDateSpecified = true;
            ////    ElectronicReportingWaiverExpirationDate = ElectronicReportingWaiverData.ElectronicReportingWaiverExpirationDate;
            ////    ElectronicReportingWaiverExpirationDateSpecified = true;
            ////}
        }
    }
    public partial class GeneralPermitData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (GeneralPermit != null)
            {
                GeneralPermit.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (GeneralPermit != null)
            {
                GeneralPermit.BeforeSaveToDatabase();
            }
        }
    }
    public partial class GeneralPermit : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (MajorMinorStatusIndicatorSpecified || MajorMinorStatusStartDateSpecified)
            ////{
            ////    MajorMinorStatus = new MajorMinorStatus()
            ////    {
            ////        MajorMinorStatusIndicator = MajorMinorStatusIndicator,
            ////        MajorMinorStatusIndicatorSpecified = MajorMinorStatusIndicatorSpecified,
            ////        MajorMinorStatusStartDate = MajorMinorStatusStartDate,
            ////        MajorMinorStatusStartDateSpecified = MajorMinorStatusStartDateSpecified,
            ////    };
            ////}
            ////if (DMRNonReceiptStatusIndicatorSpecified || DMRNonReceiptStatusStartDateSpecified)
            ////{
            ////    DMRNonReceiptStatus = new DMRNonReceiptStatus()
            ////    {
            ////        DMRNonReceiptStatusIndicator = DMRNonReceiptStatusIndicator,
            ////        DMRNonReceiptStatusIndicatorSpecified = DMRNonReceiptStatusIndicatorSpecified,
            ////        DMRNonReceiptStatusStartDate = DMRNonReceiptStatusStartDate,
            ////        DMRNonReceiptStatusStartDateSpecified = DMRNonReceiptStatusStartDateSpecified,
            ////    };
            ////}
            ////if (ElectronicReportingWaiverTypeCode != null)
            ////{
            ////    if (ElectronicReportingWaiverData == null)
            ////    {
            ////        ElectronicReportingWaiverData = new ElectronicReportingWaiverData();
            ////    }
            ////    ElectronicReportingWaiverData.ElectronicReportingWaiverTypeCode = ElectronicReportingWaiverTypeCode;
            ////}
            ////if (ElectronicReportingWaiverEffectiveDate != null)
            ////{
            ////    if (ElectronicReportingWaiverData == null)
            ////    {
            ////        ElectronicReportingWaiverData = new ElectronicReportingWaiverData();
            ////    }
            ////    ElectronicReportingWaiverData.ElectronicReportingWaiverEffectiveDate = ElectronicReportingWaiverEffectiveDate;
            ////}
            ////if (ElectronicReportingWaiverExpirationDate != null)
            ////{
            ////    if (ElectronicReportingWaiverData == null)
            ////    {
            ////        ElectronicReportingWaiverData = new ElectronicReportingWaiverData();
            ////    }
            ////    ElectronicReportingWaiverData.ElectronicReportingWaiverExpirationDate = ElectronicReportingWaiverExpirationDate;
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (MajorMinorStatus != null)
            ////{
            ////    MajorMinorStatusIndicator = MajorMinorStatus.MajorMinorStatusIndicator;
            ////    MajorMinorStatusIndicatorSpecified = MajorMinorStatus.MajorMinorStatusIndicatorSpecified;
            ////    MajorMinorStatusStartDate = MajorMinorStatus.MajorMinorStatusStartDate;
            ////    MajorMinorStatusStartDateSpecified = MajorMinorStatus.MajorMinorStatusStartDateSpecified;
            ////}
            ////if (DMRNonReceiptStatus != null)
            ////{
            ////    DMRNonReceiptStatusIndicator = DMRNonReceiptStatus.DMRNonReceiptStatusIndicator;
            ////    DMRNonReceiptStatusIndicatorSpecified = DMRNonReceiptStatus.DMRNonReceiptStatusIndicatorSpecified;
            ////    DMRNonReceiptStatusStartDate = DMRNonReceiptStatus.DMRNonReceiptStatusStartDate;
            ////    DMRNonReceiptStatusStartDateSpecified = DMRNonReceiptStatus.DMRNonReceiptStatusStartDateSpecified;
            ////}
            ////if (ElectronicReportingWaiverData != null)
            ////{
            ////    ElectronicReportingWaiverTypeCode = ElectronicReportingWaiverData.ElectronicReportingWaiverTypeCode;
            ////    ElectronicReportingWaiverEffectiveDate = ElectronicReportingWaiverData.ElectronicReportingWaiverEffectiveDate;
            ////    ElectronicReportingWaiverEffectiveDateSpecified = true;
            ////    ElectronicReportingWaiverExpirationDate = ElectronicReportingWaiverData.ElectronicReportingWaiverExpirationDate;
            ////    ElectronicReportingWaiverExpirationDateSpecified = true;
            ////}
        }
    }
    public partial class DischargeMonitoringReportData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (DischargeMonitoringReport != null)
            {
                DischargeMonitoringReport.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (DischargeMonitoringReport != null)
            {
                DischargeMonitoringReport.BeforeSaveToDatabase();
            }
        }
    }
    public partial class DischargeMonitoringReport : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string DMRNoDischargeIndicator;

        [System.Xml.Serialization.XmlIgnore]
        public Windsor.Commons.XsdOrm2.CustomXmlStringFormatDate DMRNoDischargeReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DMRNoDischargeReceivedDateSpecified;

        [System.Xml.Serialization.XmlIgnore]
        public ReportParameter[] ReportParameter;

        public virtual void AfterLoadFromDatabase()
        {
            List<object> items = null;
            List<ItemsChoiceType2> itemsElementName = null;
            if (DMRNoDischargeIndicator != null)
            {
                CollectionUtils.Add(DMRNoDischargeIndicator, ref items);
                CollectionUtils.Add(ItemsChoiceType2.DMRNoDischargeIndicator, ref itemsElementName);
            }
            if (DMRNoDischargeReceivedDateSpecified)
            {
                CollectionUtils.Add(DMRNoDischargeReceivedDate, ref items);
                CollectionUtils.Add(ItemsChoiceType2.DMRNoDischargeReceivedDate, ref itemsElementName);
            }
            CollectionUtils.ForEach(ReportParameter, delegate (ReportParameter reportParameter)
            {
                CollectionUtils.Add(reportParameter, ref items);
                CollectionUtils.Add(ItemsChoiceType2.ReportParameter, ref itemsElementName);
            });
            if (items != null)
            {
                Items = items.ToArray();
                ItemsElementName = itemsElementName.ToArray();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            int index = 0;
            List<ReportParameter> reportParameters = null;
            CollectionUtils.ForEach(ItemsElementName, delegate (ItemsChoiceType2 itemsChoiceType)
            {
                if ((Items == null) || (index >= Items.Length))
                {
                    throw new ArgException("The DischargeMonitoringReport.Items array does not contain the required number of elements: {0}",
                                           ItemsElementName.Length.ToString());
                }
                object item = Items[index++];
                switch (itemsChoiceType)
                {
                    case ItemsChoiceType2.DMRNoDischargeIndicator:
                        if (DMRNoDischargeIndicator != null)
                        {
                            throw new ArgException("More than one DischargeMonitoringReport.DMRNoDischargeIndicator was specified");
                        }
                        DMRNoDischargeIndicator = (string)item;
                        break;
                    case ItemsChoiceType2.DMRNoDischargeReceivedDate:
                        if (DMRNoDischargeReceivedDateSpecified)
                        {
                            throw new ArgException("More than one DischargeMonitoringReport.DMRNoDischargeReceivedDate was specified");
                        }
                        DMRNoDischargeReceivedDate = new CustomXmlStringFormatDate((DateTime)item);
                        DMRNoDischargeReceivedDateSpecified = true;
                        break;
                    case ItemsChoiceType2.ReportParameter:
                        CollectionUtils.Add((ReportParameter)item, ref reportParameters);
                        break;
                    default:
                        throw new ArgException("Unrecognized ItemsChoiceType2 was specified: {0}", itemsChoiceType.ToString());
                }
            });
            if (reportParameters != null)
            {
                ReportParameter = reportParameters.ToArray();
            }
        }
    }

    public partial class POTWTreatmentTechnologyPermitData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (POTWTreatmentTechnologyPermit != null)
            {
                POTWTreatmentTechnologyPermit.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (POTWTreatmentTechnologyPermit != null)
            {
                POTWTreatmentTechnologyPermit.BeforeSaveToDatabase();
            }
        }
    }
    public partial class POTWTreatmentTechnologyPermit : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            if (WastewaterFlowTreatmentTechnology != null)
            {
                WastewaterFlowTreatmentTechnology.AfterLoadFromDatabase();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            if (WastewaterFlowTreatmentTechnology != null)
            {
                WastewaterFlowTreatmentTechnology.BeforeSaveToDatabase();
            }
        }
    }

    public partial class WastewaterFlowTreatmentTechnology : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            List<object> items = null;
            if (POTWTreatmentLevel != null)
            {
                CollectionUtils.Add(POTWTreatmentLevel, ref items);
            }
            if (POTWWastewaterDisinfectionTechnology != null)
            {
                CollectionUtils.Add(POTWWastewaterDisinfectionTechnology, ref items);
            }
            if (POTWWastewaterTreatmentTechnologyUnitOperations != null)
            {
                CollectionUtils.Add(POTWWastewaterTreatmentTechnologyUnitOperations, ref items);
            }
            if (items != null)
            {
                Items = items.ToArray();
            }
        }
        public virtual void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(Items, delegate (object item)
            {
                if (item is POTWTreatmentLevel)
                {
                    POTWTreatmentLevel = (POTWTreatmentLevel)item;
                }
                else if (item is POTWWastewaterDisinfectionTechnology)
                {
                    POTWWastewaterDisinfectionTechnology = (POTWWastewaterDisinfectionTechnology)item;
                }
                else if (item is POTWWastewaterTreatmentTechnologyUnitOperations)
                {
                    POTWWastewaterTreatmentTechnologyUnitOperations = (POTWWastewaterTreatmentTechnologyUnitOperations)item;
                }
            });
        }

        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.SameTable]
        public POTWTreatmentLevel POTWTreatmentLevel { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.SameTable]
        public POTWWastewaterDisinfectionTechnology POTWWastewaterDisinfectionTechnology { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.SameTable]
        public POTWWastewaterTreatmentTechnologyUnitOperations POTWWastewaterTreatmentTechnologyUnitOperations { get; set; }
    }

    [Serializable]
    public partial class MainElementBase
    {
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SourceSystemIdentifier;
    }

    [Serializable]
    public partial class SubmissionResultsDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SubmissionTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public SubmissionTransactionTypeCodeDataType TransactionType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string PermitIdentifier2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string LimitSetDesignator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime MonitoringPeriodEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MonitoringPeriodEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ParameterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string MonitoringSiteDescriptionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 9)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string LimitSeasonNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        public System.DateTime LimitStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LimitStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        public System.DateTime LimitEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LimitEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
        public string LimitModificationEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string TradeID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string ComplianceMonitoringIdentifier;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        //[Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        //public string ComplianceMonitoringCategoryCode;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        //[Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        //public string ComplianceMonitoringCategoryCode2;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 16)]
        //public System.DateTime ComplianceMonitoringDate;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ComplianceMonitoringDateSpecified;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 17)]
        //public System.DateTime ComplianceMonitoringDate2;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ComplianceMonitoringDate2Specified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 15)]
        public System.DateTime CSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CSOEventDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 16)]
        public System.DateTime DateStormEventSampled;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DateStormEventSampledSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 17)]
        public System.DateTime PermitIssueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitIssueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 18)]
        public System.DateTime PermitEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitEffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermitTrackingEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 20)]
        public System.DateTime PermitTrackingEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermitTrackingEventDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 21)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string NarrativeConditionNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string ScheduleEventCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 23)]
        public System.DateTime ScheduleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScheduleDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
        public NumericReportTextType NumericReportCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumericReportCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public NumericReportViolationCodeType NumericReportViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NumericReportViolationCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 26)]
        public System.DateTime PermittingAuthorityReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermittingAuthorityReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 27)]
        public System.DateTime PretreatmentPerformanceSummaryEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PretreatmentPerformanceSummaryEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 28)]
        public System.DateTime ReportCoverageEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportCoverageEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 29)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string SingleEventViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 30)]
        public System.DateTime SingleEventViolationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SingleEventViolationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 31)]
        public System.DateTime SSOAnnualReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SSOAnnualReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 32)]
        public System.DateTime SSOEventDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SSOEventDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 33)]
        public System.DateTime SSOMonthlyReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SSOMonthlyReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 34)]
        public System.DateTime StormWaterMS4ReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StormWaterMS4ReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string EnforcementActionIdentifier2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string FinalOrderIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string FinalOrderIdentifier2;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 39)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string ComplianceScheduleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string MilestoneTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string ScheduleViolationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
        public string EventId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 43)]
        public System.DateTime IndustrialStormWaterAnnualReportReceivedDate;

        /// <summary>
        /// Added to support ICIS schema v5.8
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndustrialStormWaterAnnualReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 44)]
        public System.DateTime BiosolidsAnnualReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BiosolidsAnnualReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
        [System.ComponentModel.DescriptionAttribute("An Service Provider (e.g., ICIS-NPDES) specific error code that uniquely identifi" +
            "es a type of error, information or warning.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string ResultCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
        [System.ComponentModel.DescriptionAttribute("The type of error, information or warning that is being returned.")]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(11)]
        public ResultTypeCodeDataType ResultTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
        [System.ComponentModel.DescriptionAttribute("A human readable description on an error, information or warning.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ResultDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 48)]
        [System.ComponentModel.DescriptionAttribute("The transaction id of the submission.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SubmissionTransactionId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 49)]
        [System.ComponentModel.DescriptionAttribute("The date and time when this row was created.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime CreatedDateTime;
    }

    [Serializable]
    public class SubmissionResultList
    {
        [System.Xml.Serialization.XmlElementAttribute("SubmissionResult", Order = 8)]
        public SubmissionResultsDataType[] SubmissionResult;
    }

    [Serializable]
    public enum ResultTypeCodeDataType
    {
        Error,
        Information,
        Warning,
        Accepted,
    }

    [Serializable]
    public enum TransactionStatusCode
    {
        Unknown,
        Received,
        Processing,
        Pending,
        Failed,
        Cancelled,
        Approved,
        Processed,
        Completed,
    }

    [Serializable]
    public partial class SubmissionTrackingDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 0)]
        public System.DateTime ETLCompletionDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ETLCompletionDateTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 1)]
        public System.DateTime DETChangeCompletionDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DETChangeCompletionDateTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 2)]
        public System.DateTime SubmissionDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionDateTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string SubmissionTransactionId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public TransactionStatusCode SubmissionTransactionStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionTransactionStatusSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 5)]
        public System.DateTime SubmissionStatusDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionStatusDateTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 6)]
        public System.DateTime ResponseParseDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResponseParseDateTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public TransactionStatusCode WorkflowStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string WorkflowStatusMessage;
    }
    [Serializable]
    public class RemoveTrailingZerosDecimal : CustomXmlStringFormatType<decimal>
    {
        public RemoveTrailingZerosDecimal()
        {
        }
        public RemoveTrailingZerosDecimal(decimal value)
            : base(value)
        {
        }
        public override string GetXmlString()
        {
            return Value.ToString("0.#############################");
        }
    }
    public partial class CopyMGPLimitSetData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (TargetGeneralPermitLimitSetKeyElements != null)
            ////{
            ////    if (CopyMGPLimitSet == null)
            ////    {
            ////        CopyMGPLimitSet = new CopyMGPLimitSet();
            ////    }
            ////    CopyMGPLimitSet.TargetGeneralPermitLimitSetKeyElements = TargetGeneralPermitLimitSetKeyElements;
            ////}
            ////if (TargetPermittedFeatureGroup != null)
            ////{
            ////    if (CopyMGPLimitSet == null)
            ////    {
            ////        CopyMGPLimitSet = new CopyMGPLimitSet();
            ////    }
            ////    CopyMGPLimitSet.TargetPermittedFeatureGroup = TargetPermittedFeatureGroup;
            ////}
            ////if (TargetLimitSetGroup != null)
            ////{
            ////    if (CopyMGPLimitSet == null)
            ////    {
            ////        CopyMGPLimitSet = new CopyMGPLimitSet();
            ////    }
            ////    CopyMGPLimitSet.TargetLimitSetGroup = TargetLimitSetGroup;
            ////}
            ////if (CopyMGPLimitSet != null)
            ////{
            ////    CopyMGPLimitSet.AfterLoadFromDatabase();
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (CopyMGPLimitSet != null)
            ////{
            ////    TargetGeneralPermitLimitSetKeyElements = CopyMGPLimitSet.TargetGeneralPermitLimitSetKeyElements;
            ////    TargetPermittedFeatureGroup = CopyMGPLimitSet.TargetPermittedFeatureGroup;
            ////    TargetLimitSetGroup = CopyMGPLimitSet.TargetLimitSetGroup;
            ////    CopyMGPLimitSet.BeforeSaveToDatabase();
            ////}
        }
    }
    public partial class CopyMGPLimitSet : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            // Removed for 5.14
            ////if (GeographicCoordinates != null)
            ////{
            ////    if (TargetPermittedFeatureGroup == null)
            ////    {
            ////        TargetPermittedFeatureGroup = new TargetPermittedFeatureGroup();
            ////    }
            ////    TargetPermittedFeatureGroup.GeographicCoordinates = GeographicCoordinates;
            ////}
            ////if (LimitSetStatus != null)
            ////{
            ////    if (TargetLimitSetGroup == null)
            ////    {
            ////        TargetLimitSetGroup = new TargetLimitSetGroup();
            ////    }
            ////    TargetLimitSetGroup.LimitSetStatus = LimitSetStatus;
            ////}
            ////if (LimitSetSchedule != null)
            ////{
            ////    if (TargetLimitSetGroup == null)
            ////    {
            ////        TargetLimitSetGroup = new TargetLimitSetGroup();
            ////    }
            ////    TargetLimitSetGroup.LimitSetSchedule = LimitSetSchedule;
            ////}
        }
        public virtual void BeforeSaveToDatabase()
        {
            // Removed for 5.14
            ////if (TargetPermittedFeatureGroup != null)
            ////{
            ////    if (TargetPermittedFeatureGroup.GeographicCoordinates != null)
            ////    {
            ////        GeographicCoordinates = TargetPermittedFeatureGroup.GeographicCoordinates;
            ////    }
            ////}
            ////if (TargetLimitSetGroup != null)
            ////{
            ////    if (TargetLimitSetGroup.LimitSetStatus != null)
            ////    {
            ////        LimitSetStatus = TargetLimitSetGroup.LimitSetStatus;
            ////    }
            ////    if (TargetLimitSetGroup.LimitSetSchedule != null)
            ////    {
            ////        LimitSetSchedule = TargetLimitSetGroup.LimitSetSchedule;
            ////    }
            ////}
        }

        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
        public string TargetGeneralPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string TargetGeneralPermittedFeatureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string TargetGeneralLimitSetDesignator;





        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
        public string PermittedFeatureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string PermittedFeatureDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PermittedFeatureStateWaterBodyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string ImpairedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
        public string TMDLCompletedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement1;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string PermittedFeatureUserDefinedDataElement2;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public GeographicCoordinates GeographicCoordinates;





        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string LimitSetNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(315)]
        public string DMRPrePrintCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public LimitSetStatus LimitSetStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public LimitSetSchedule[] LimitSetSchedule;

    }
}
