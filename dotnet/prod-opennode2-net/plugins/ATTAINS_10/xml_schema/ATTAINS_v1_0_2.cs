using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm2;
using Windsor.Commons.Core;
using System.Collections.Generic;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.ATTAINS_10
{
    [DefaultTableNamePrefixAttribute("ATT")]
    [RemovePostfixNamesFromTableAndColumnNamesAttribute("DataType", "Details", "Code", "Data")]
    [NameReplacementsAttribute(
          "TRANSACTION_HEADER", ""
        , "VIOLATION_KEY_ELEMENTS", "VIOLATION_ELEMENTS"
        , "STORM_WATER", "SW"
        , "BIOSOLIDS", "BS"
        , "BIOSOLID", "BS"
        , "TRACKING", "TRACK"
        , "TRACK", "TRACK"
        , "NON", "NON"
        , "DATE", "DATE"
        , "CODE", "CODE"
        , "TEXT", "TXT"
        , "TYPE", "TYPE"
        , "USER", "USR"
        , "NUMBER", "NUM"
        , "STATE", "ST"
        , "WATER", "WTR"
        , "ASSOCIATED", "ASSC"
            //, "ASSESSMENT", "ASMNT" //Added 8/30 BR
        , "IDENTIFICATION", "IDENT"
        , "IDENTIFIER", "IDENT"
        , "FEDERAL", "FEDR"
        , "RESPONSE", "RSPN"
        , "COMMENTS", "CMNTS"
        , "COMMENT", "CMNT"
        , "FIELD", "FLD"
        , "ORGANIZATION", "ORG"
        , "ASSOCIATION", "ASSC"
        , "HORIZONTAL", "HORZ"
        , "VERTICAL", "VERT"
        , "PRODUCT", "PROD"
        , "GALLONS", "GAL"
        , "RECEIVED", "RCVD"
        , "RECEIVING", "RCVG"
        , "RECEIVE", "RECV"
            //, "REDUCTION", "RDCTN" //Added 8/30 BR
        , "PLANNER", "PLNR"
        , "NUMBERS", "NUM"
        , "TOTAL", "TTL"
        , "AVAILABLE", "AVAIL"
        , "DESCRIPTION", "DESC"
        , "AMOUNT", "AMT"
        , "GENERATED", "GNRTD"
        , "CATEGORY", "CATG"
        , "ALTERNATIVES", "ALTS"
        , "ALTERNATIVE", "ALT"
        , "ADDRESS", "ADDR"
        , "CONDITION", "COND"
        , "NUMERIC", "NUM"
        , "EVALUATION", "EVAL"
        , "AUTHORIZATION", "AUTH"
        , "PROJECTED", "PROJ"
        , "PROJECTS", "PROJ"
        , "PROJECT", "PROJ"
        , "DESIGN", "DSGN"
        , "AVERAGE", "AVER"
        , "PERMITTING", "PRMT"
        , "PERMITS", "PRMTS"
        , "PERMIT", "PRMT"
        , "PERMITTED", "PRMT"
        , "UNPERMITTED", "UNPRMT"
        , "EVENTS", "EVTS"
        , "EVENT", "EVT"
        , "REPORTS", "REP"
        , "REPORT", "REP"
        , "REPORTING", "REP"
        , "REPORTABLE", "REP"
        , "REPORTED", "REP"
        , "APPLICATION", "APPL"
        , "APPLICABLE", "APPL"
        , "COGNIZANT", "COGNZNT"
        , "CONTEXT", "CNTXT"
        , "ANIMAL", "ANML"
        , "SIGNIFICANT", "SIG"
        , "CONGRESSIONAL", "CONGR"
        , "CONSTRUCTION", "CNST"
        , "LATITUDE", "LAT"
        , "LONGITUDE", "LONG"
        , "CLASSIFICATION", "CLASS"
        , "PROGRAMS", "PROGS"
        , "PROGRAM", "PROG"
        , "AFFILIATION", "AFFIL"
        , "INDIVIDUAL", "INDVL"
        , "ELECTRONIC", "ELEC"
        , "TELEPHONE", "TELEPH"
        , "EXTENSION", "EXT"
        , "REFERENCE", "REF"
        , "COLLECTION", "COLL"
        , "DISTRIBUTION", "DIST"
        , "DISTRIBUTED", "DIST"
        , "PRODUCTION", "PROD"
        , "DISPOSAL", "DSPL"
        , "BENEFICIALLY", "BENEF"
        , "BENEFICIAL", "BENEF"
        , "PARAMETER", "PARAM"
        , "MANAGEMENT", "MGMT"
        , "VIOLATIONS", "VIOL"
        , "VIOLATION", "VIOL"
        , "VIOLATED", "VIOL"
        , "SURFACE", "SURF"
        , "AUTHORITY", "AUTH"
        , "AUTHORIZED", "AUTH"
        , "TRANSFER", "TRANS"
        , "APPROVE", "APRV"
        , "APPROVED", "APRVD"
        , "APPROVAL", "APRVL"
        , "DESIGNATION", "DESGN"
        , "CONTRIBUTING", "CONTRB"
        , "CONTRIBUTE", "CONTRB"
            //, "CONTROL", "CTRL" //Added 8/30 BR
        , "DRAINAGE", "DRAIN"
        , "INDICATOR", "IND"
        , "DEVELOPED", "DVLPD"
        , "CERTIFIED", "CERT"
        , "CERTIFY", "CERT"
        , "CERTIFIER", "CERT"
        , "CERTIFICATION", "CERT"
        , "ENVIRONMENTAL", "ENVR"
        , "ENVIRONMENT", "ENVR"
        , "SYSTEM", "SYSTM"
        , "COUNT", "CNT"
        , "PROCESSED", "PRCSS"
        , "PROCESS", "PRCSS"
        , "FEATURE", "FEATR"
        , "VOLUME", "VOL"
        , "DISCHARGES", "DSCH"
        , "DISCHARGE", "DSCH"
        , "PRECIPITATION", "PRECIP"
        , "SATELLITE", "SATL"
        , "COMPLIANCE", "CMPL"
        , "MONITORING", "MON"
        , "MONITOR", "MON"
        , "ACTIVITY", "ACTY"
        , "ASSISTANCE", "ASSIST"
        , "INSPECTIONS", "INSP"
        , "INSPECTION", "INSP"
        , "PHYSICALLY", "PHYS"
        , "PHYSICAL", "PHYS"
        , "DETERMINE", "DTRMN"
        , "DETERMINATION", "DTRMN"
        , "HAZARDOUS", "HAZ"
        , "MECHANISM", "MECH"
        , "FREQUENT", "FREQ"
        , "FREQUENCY", "FREQ"
        , "REQUIREMENT", "REQ"
        , "REQUIREMENTS", "REQS"
        , "ADMINISTRATIVE", "ADMIN"
        , "TECHNICAL", "TECH"
        , "REMOVAL", "RMVL"
        , "OVERFLOW", "OVRFLW"
        , "OTHER", "OTHR"
        , "ESTIMATED", "EST"
        , "ESTIMATE", "EST"
        , "PERFORMANCE", "PERF"
        , "DESCRIPTOR", "DESC"
        , "SCHEDULED", "SCHD"
        , "SCHEDULE", "SCHD"
        , "DETECTION", "DETECT"
        , "RESOLUTION", "RESL"
        , "EXECUTIVE", "EXEC"
        , "PRINCIPAL", "PRNCPL"
        , "OFFICER", "OFFCR"
        , "SIGNATORY", "SIGN"
        , "CONCENTRATION", "CONCEN"
        , "QUANTITY", "QTY"
        , "MODIFICATION", "MOD"
        , "SUPPLEMENTAL", "SUPPL"
        , "COMPLETION", "CMPL"
        , "SUBMISSION", "SUBM"
        , "STATISTICAL", "STAT"
        , "OPTIONAL", "OPT"
        , "EXPIRATION", "EXPR"
        , "REQUIRED", "REQD"
        , "SAMPLING", "SMPL"
        , "SAMPLED", "SMPL"
        , "SAMPLE", "SMPL"
        , "SAMPLES", "SMPL"
        , "PUBLISHED", "PUBL"
        , "ADMINISTRTIVE", "ADMIN"
        , "PENALTIES", "PNLTY"
        , "PENALTY", "PNLTY"
        , "REGIONAL", "RGNL"
        , "REGION", "RGN"
        , "TERMINATION", "TERM"
        , "NOTIFICATION", "NOTIF"
        , "ESSENTIAL", "ESSEN"
        , "ESSENTIALLY", "ESSEN"
        , "HISTORICAL", "HIST"
        , "HISTORIC", "HIST"
        , "INCORPORATED", "INCRP"
        , "EXPENDITURE", "EXPEN"
        , "MEASURE", "MEAS"
            //, "MEASURES", "MEAS" //Added 8/30 BR
        , "MEASUREMENT", "MEAS"
        , "RESPONSIBILITIES", "RESP"
        , "RESPONSIBILITY", "RESP"
        , "STORM", "STRM"
        , "ELEMENTS", "ELEM"
        , "GEOGRAPHIC", "GEO"
        , "ORIGINATING", "ORIG"
        , "COORDINATES", "COORD"
        , "COORDINATE", "COORD"
        , "OFFICIAL", "OFCL"
        , "FACILITY", "FAC"
        , "RANGE", "RNG"
        , "NUTRIENT", "NUTR"
        , "PHOSPHOROUS", "PHOSPH"
        , "LOCATION", "LOC"
        , "CORRECTIVE", "CORR"
        , "BIOMONITORING", "BIOMON"
        , "ACTION", "ACTN"
        , "MAXIMUM", "MAX"
        , "MINIMUM", "MIN"
        , "COLLECTED", "COLL"
        , "ENFORCEMENT", "ENFRC"
        , "CONDUCTING", "COND"
        , "GENERAL", "GNRL"
        , "FORMAL", "FRML"
        , "INFORMAL", "INFRML"
        , "CRITERION", "CRIT"
        , "CRITICAL", "CRIT"
        , "SIGNATURE", "SIGN"
        , "PROPERTY", "PROP"
        , "POPULATION", "POPL"
        , "QUALIFYING", "QUAL"
        , "SINGLE", "SNGL"
        , "EFFLUENT", "EFFLU"
        , "GUIDELINE", "GUIDE"
        , "WASTEWATER", "WW"
        , "STORAGE", "STOR"
        , "NATIONAL", "NAT"
        , "PRIORITIES", "PRIO"
        , "PRIORITY", "PRIO"
        , "PRETREATMENT", "PRETR"
        , "POLLUTANT", "POLUT"
            //, "POLLUTANTS", "POLUTS" //Addded 8/30 BR
        , "COMPONENT", "COMP"
        , "INDUSTRIAL", "INDST"
        , "LINKAGE", "LNK"
        , "GOVERNMENT", "GOV"
        , "NARRATIVE", "NARR"
        , "CHARACTERISTICS", "CHAR"
        , "SUMMARY", "SUMM"
        , "REISSUANCE", "REISSU"
        , "STATUS", "STAT"
        , "LIMIT", "LMT"
        , "LIMITS", "LMTS"
        , "INCINERATOR", "INCIN"
        , "POLICY", "PLCY"
        , "TREATMENT", "TRTMNT"
        , "AGENCY", "AGNCY"
        , "SOURCES", "SRCS"
        , "SOURCE", "SRC"
        , "FUNDING", "FUND"
        , "CREDIT", "CRDT"
        , "CREDITS", "CRDTS"
        , "LOCAL", "LOC"
        , "MANURE", "MNUR"
        , "ANNUAL", "ANNUL"
    )]

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
    [UseNewSameTableMapping]

    public partial class MappingAttributes
    {
    }


    public partial class Organization : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(this.Actions, delegate(Action action)
            {
                if (!CollectionUtils.IsNullOrEmpty(action.TMDLHistory))
                {
                    if (action.TMDLReportDetails == null)
                    {
                        action.TMDLReportDetails = new TMDLReportDetails();
                    }
                    action.TMDLReportDetails.TMDLHistory = action.TMDLHistory;
                    action.TMDLHistory = null;
                }
                if (!CollectionUtils.IsNullOrEmpty(action.StateWideActions) || !CollectionUtils.IsNullOrEmpty(action.SpecificWaters))
                {
                    if (action.AssociatedWaters == null)
                    {
                        action.AssociatedWaters = new AssociatedWaters();
                    }
                    action.AssociatedWaters.StateWideActions = action.StateWideActions;
                    action.StateWideActions = null;
                    action.AssociatedWaters.SpecificWaters = action.SpecificWaters;
                    action.SpecificWaters = null;
                }
            });
            CollectionUtils.ForEach(this.ReportingCycle, delegate(ReportingCycle reportingCycle)
            {
                CollectionUtils.ForEach(reportingCycle.Assessments, delegate(Assessment assessment)
                {
                    CollectionUtils.ForEach(assessment.UseAttainments, delegate(UseAttainment useAttainment)
                    {
                        if (!CollectionUtils.IsNullOrEmpty(useAttainment.AssessmentTypes) || !CollectionUtils.IsNullOrEmpty(useAttainment.AssessmentMethodTypes))
                        {
                            if (useAttainment.AssessmentMetadata == null)
                            {
                                useAttainment.AssessmentMetadata = new AssessmentMetadata();
                            }
                            useAttainment.AssessmentMetadata.AssessmentTypes = useAttainment.AssessmentTypes;
                            useAttainment.AssessmentTypes = null;
                            useAttainment.AssessmentMetadata.AssessmentMethodTypes = useAttainment.AssessmentMethodTypes;
                            useAttainment.AssessmentMethodTypes = null;
                        }
                    });
                    CollectionUtils.ForEach(assessment.Parameters, delegate(Parameter parameter)
                    {
                        if (!CollectionUtils.IsNullOrEmpty(parameter.PriorCauses))
                        {
                            if (parameter.ImpairedWatersInformation == null)
                            {
                                parameter.ImpairedWatersInformation = new ImpairedWatersInformation();
                            }
                            parameter.ImpairedWatersInformation.PriorCauses = parameter.PriorCauses;
                            parameter.PriorCauses = null;
                        }
                    });
                });
            });
        }
        public virtual void BeforeSaveToDatabase()
        {
            // TODO: Need to implement all the logic from AfterLoadFromDatabase() in this method to implement import of xml to db
        }
    }
}
