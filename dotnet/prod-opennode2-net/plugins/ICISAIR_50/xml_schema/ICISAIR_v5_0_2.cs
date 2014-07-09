using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm2;
using Windsor.Commons.Core;
using System.Collections.Generic;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.ICISAIR_50
{
    [DefaultTableNamePrefixAttribute("ICA")]
    [RemovePostfixNamesFromTableAndColumnNamesAttribute("Data", "Details", "Code")]
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
    , "STRATEGY", "STRGY"
    , "CONTACT", "CNTCT"
    , "RESULTS", "RSLTS"
    , "RESOLVED", "RSLVD"
    , "RESOLVED", "RSLVD"
    , "POLLUTANTS", "POLUTS"
    , "SENSITIVE", "SENS"
    , "REASON", "RSN"
    , "REMOVED", "RMVD"
    , "CONDITIONS", "CONDS"
    , "CONDUCTOR", "CNDCTR"
    , "OTHER", "OTHR"
    , "STACK", "STCK"
    , "TEST", "TST"
    , "AIR", ""
    , "EXCEEDANCE", "EXCEED"
    , "EXCURSION", "EXCURS"
    , "OPERATING", "OPER"
    , "PORTABLE", "PORT"
    , "PRIMARY", "PRI"
    , "GEOMETRIC", "GEOM"
    , "UNIFORM", "UNIFM"
    , "RESOURCE", "RSRC"
    , "REGISTRATION", "REG"
    , "BUSINESS", "BUSNSS"
    , "OWNERSHIP", "OWNER"
    , "DEFINED", "DEF"
    , "RECORD", "REC"
    , "DELETING" , "DEL"
    , "SECTIONS", "SECTS"
    , "SECTION", "SECT"
    , "COMBINED", "COMB"
    , "MILESTONE", "MILSTN"
    , "ADVISEMENT", "ADVISE"
    , "CHANGE", "CHNG"
    , "SUPERSEDED", "SPRSED"
    , "CHANGING", "CHNG"
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

    public partial class MappingAttributes
    {
    }

    [AdditionalCreateIndexAttribute("ICA_CMPL_MON_STRGY", "FAC_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_DA_CMPL_MON", "CMPL_MON_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_DA_ENFRC_ACTN_MILSTN", "DA_ENFRC_ACTN_IDENT, MILSTN_TYPE_CODE", true)]
    [AdditionalCreateIndexAttribute("ICA_DA_FRML_ENFRC_ACTN", "DA_ENFRC_ACTN_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_DA_INFRML_ENFRC_ACTN", "DA_ENFRC_ACTN_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_FAC", "FAC_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_POLUTS", "FAC_IDENT, POLUTS_CODE", true)]
    [AdditionalCreateIndexAttribute("ICA_PROGS", "FAC_IDENT, PROG_CODE", true)]
    [AdditionalCreateIndexAttribute("ICA_TVACC", "CMPL_MON_IDENT", true)]

    [AdditionalCreateIndexAttribute("ICA_DA_CASE_FILE", "CASE_FILE_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_DA_ENFRC_ACTN_LNK", "DA_ENFRC_ACTN_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_CASE_FILE_LNK", "CASE_FILE_IDENT", true)]
    [AdditionalCreateIndexAttribute("ICA_CMPL_MON_LNK", "CMPL_MON_IDENT", true)]

    public partial class Payload : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    {
        public virtual void AfterLoadFromDatabase()
        {
            //CollectionUtils.ForEach(Items, delegate(object item)
            //{
            //    IAfterLoadFromDatabase afterLoadFromDatabase = item as IAfterLoadFromDatabase;
            //    if (afterLoadFromDatabase != null)
            //    {
            //        afterLoadFromDatabase.AfterLoadFromDatabase();
            //    }
            //});
        }
        public virtual void BeforeSaveToDatabase()
        {
            //CollectionUtils.ForEach(Items, delegate(object item)
            //{
            //    IBeforeSaveToDatabase beforeSaveToDatabase = item as IBeforeSaveToDatabase;
            //    if (beforeSaveToDatabase != null)
            //    {
            //        beforeSaveToDatabase.BeforeSaveToDatabase();
            //    }
            //});
        }
        ////    public static IDictionary<string, DbAppendSelectWhereClause> GetDefaultSelectClauses(SpringBaseDao dao)
        ////    {
        ////        string[] transactionTypeTableNames = new string[]
        ////        {
        ////            "ICS_BASIC_PRMT", "ICS_BS_PRMT", "ICS_BS_PROG_REP", "ICS_CAFO_ANNUL_REP", "ICS_CAFO_PRMT", "ICS_CMPL_MON", "ICS_CMPL_MON_LNK",
        ////            "ICS_CMPL_SCHD", "ICS_CSO_EVT_REP", "ICS_CSO_PRMT", "ICS_DMR_PROG_REP_LNK", "ICS_DMR_VIOL", "ICS_DSCH_MON_REP",
        ////            "ICS_EFFLU_TRADE_PRTNER", "ICS_ENFRC_ACTN_MILESTONE", "ICS_ENFRC_ACTN_VIOL_LNK", "ICS_FINAL_ORDER_VIOL_LNK",
        ////            "ICS_FRML_ENFRC_ACTN", "ICS_GNRL_PRMT", "ICS_HIST_PRMT_SCHD_EVTS", "ICS_INFRML_ENFRC_ACTN", "ICS_LMT_SET", "ICS_LMTS",
        ////            "ICS_LOC_LMTS_PROG_REP", "ICS_MASTER_GNRL_PRMT", "ICS_NARR_COND_SCHD", "ICS_PARAM_LMTS", "ICS_POTW_PRMT", "ICS_PRETR_PERF_SUMM",
        ////            "ICS_PRETR_PRMT", "ICS_PRMT_FEATR", "ICS_PRMT_REISSU", "ICS_PRMT_TERM", "ICS_PRMT_TRACK_EVT", "ICS_SCHD_EVT_VIOL",
        ////            "ICS_SNGL_EVT_VIOL", "ICS_SSO_ANNUL_REP", "ICS_SSO_EVT_REP", "ICS_SSO_MONTHLY_EVT_REP", "ICS_SW_CNST_PRMT", "ICS_SW_EVT_REP",
        ////            "ICS_SW_INDST_PRMT", "ICS_SWMS_4_LARGE_PRMT", "ICS_SWMS_4_PROG_REP", "ICS_SWMS_4_SMALL_PRMT", "ICS_UNPRMT_FAC", 
        ////        };

        ////        Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>(60);
        ////        foreach (string tableName in transactionTypeTableNames)
        ////        {
        ////            selectClauses.Add(tableName, new DbAppendSelectWhereClause("TRANSACTION_TYPE IS NOT NULL", null));
        ////        }
        ////        return selectClauses;
        ////    }
    }
    ////public partial class DischargeMonitoringReportData : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    ////{
    ////    public virtual void AfterLoadFromDatabase()
    ////    {
    ////        if (DischargeMonitoringReport != null)
    ////        {
    ////            DischargeMonitoringReport.AfterLoadFromDatabase();
    ////        }
    ////    }
    ////    public virtual void BeforeSaveToDatabase()
    ////    {
    ////        if (DischargeMonitoringReport != null)
    ////        {
    ////            DischargeMonitoringReport.BeforeSaveToDatabase();
    ////        }
    ////    }
    ////}
    ////public partial class DischargeMonitoringReport : IAfterLoadFromDatabase, IBeforeSaveToDatabase
    ////{
    ////    [System.Xml.Serialization.XmlIgnore]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
    ////    public string DMRNoDischargeIndicator;

    ////    [System.Xml.Serialization.XmlIgnore]
    ////    public DateTime DMRNoDischargeReceivedDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool DMRNoDischargeReceivedDateSpecified;

    ////    [System.Xml.Serialization.XmlIgnore]
    ////    public ReportParameter[] ReportParameter;

    ////    public virtual void AfterLoadFromDatabase()
    ////    {
    ////        List<object> items = null;
    ////        List<ItemsChoiceType> itemsElementName = null;
    ////        if (DMRNoDischargeIndicator != null)
    ////        {
    ////            CollectionUtils.Add(DMRNoDischargeIndicator, ref items);
    ////            CollectionUtils.Add(ItemsChoiceType.DMRNoDischargeIndicator, ref itemsElementName);
    ////        }
    ////        if (DMRNoDischargeReceivedDateSpecified)
    ////        {
    ////            CollectionUtils.Add(DMRNoDischargeReceivedDate, ref items);
    ////            CollectionUtils.Add(ItemsChoiceType.DMRNoDischargeReceivedDate, ref itemsElementName);
    ////        }
    ////        CollectionUtils.ForEach(ReportParameter, delegate(ReportParameter reportParameter)
    ////        {
    ////            CollectionUtils.Add(reportParameter, ref items);
    ////            CollectionUtils.Add(ItemsChoiceType.ReportParameter, ref itemsElementName);
    ////        });
    ////        if (items != null)
    ////        {
    ////            Items = items.ToArray();
    ////            ItemsElementName = itemsElementName.ToArray();
    ////        }
    ////    }
    ////    public virtual void BeforeSaveToDatabase()
    ////    {
    ////        int index = 0;
    ////        List<ReportParameter> reportParameters = null;
    ////        CollectionUtils.ForEach(ItemsElementName, delegate(ItemsChoiceType itemsChoiceType)
    ////        {
    ////            if ((Items == null) || (index >= Items.Length))
    ////            {
    ////                throw new ArgException("The DischargeMonitoringReport.Items array does not contain the required number of elements: {0}",
    ////                                       ItemsElementName.Length.ToString());
    ////            }
    ////            object item = Items[index++];
    ////            switch (itemsChoiceType)
    ////            {
    ////                case ItemsChoiceType.DMRNoDischargeIndicator:
    ////                    if (DMRNoDischargeIndicator != null)
    ////                    {
    ////                        throw new ArgException("More than one DischargeMonitoringReport.DMRNoDischargeIndicator was specified");
    ////                    }
    ////                    DMRNoDischargeIndicator = (string)item;
    ////                    break;
    ////                case ItemsChoiceType.DMRNoDischargeReceivedDate:
    ////                    if (DMRNoDischargeReceivedDateSpecified)
    ////                    {
    ////                        throw new ArgException("More than one DischargeMonitoringReport.DMRNoDischargeReceivedDate was specified");
    ////                    }
    ////                    DMRNoDischargeReceivedDate = (DateTime)item;
    ////                    DMRNoDischargeReceivedDateSpecified = true;
    ////                    break;
    ////                case ItemsChoiceType.ReportParameter:
    ////                    CollectionUtils.Add((ReportParameter)item, ref reportParameters);
    ////                    break;
    ////                default:
    ////                    throw new ArgException("Unrecognized ItemsChoiceType was specified: {0}", itemsChoiceType.ToString());
    ////            }
    ////        });
    ////        if (reportParameters != null)
    ////        {
    ////            ReportParameter = reportParameters.ToArray();
    ////        }
    ////    }
    ////}

    ////[Serializable]
    ////public partial class MainElementBase
    ////{
    ////    [System.Xml.Serialization.XmlIgnore]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
    ////    public string SourceSystemIdentifier;
    ////}

    ////[Serializable]
    ////public partial class SubmissionResultsDataType
    ////{
    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    ////    [System.ComponentModel.DescriptionAttribute("The type of the submission.")]
    ////    [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
    ////    public string SubmissionTypeName;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    ////    [System.ComponentModel.DescriptionAttribute("The type of transaction that was sent in the submission.")]
    ////    [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
    ////    [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
    ////    public SubmissionTransactionTypeCodeDataType TransactionType;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    ////    [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
    ////    public string PermitIdentifier;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    ////    [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(9)]
    ////    public string PermitIdentifier2;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
    ////    public string PermittedFeatureIdentifier;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
    ////    public string LimitSetDesignator;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
    ////    public System.DateTime MonitoringPeriodEndDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool MonitoringPeriodEndDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
    ////    public string ParameterCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
    ////    public string MonitoringSiteDescriptionCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 9)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
    ////    public string LimitSeasonNumber;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
    ////    public System.DateTime LimitStartDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool LimitStartDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
    ////    public System.DateTime LimitEndDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool LimitEndDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Date")]
    ////    public string LimitModificationEffectiveDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
    ////    public string TradeID;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
    ////    public string ComplianceMonitoringCategoryCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
    ////    public string ComplianceMonitoringCategoryCode2;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 16)]
    ////    public System.DateTime ComplianceMonitoringDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ComplianceMonitoringDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 17)]
    ////    public System.DateTime ComplianceMonitoringDate2;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ComplianceMonitoringDate2Specified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 18)]
    ////    public System.DateTime CSOEventDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool CSOEventDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 19)]
    ////    public System.DateTime DateStormEventSampled;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool DateStormEventSampledSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 20)]
    ////    public System.DateTime PermitIssueDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool PermitIssueDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 21)]
    ////    public System.DateTime PermitEffectiveDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool PermitEffectiveDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
    ////    public string PermitTrackingEventCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 23)]
    ////    public System.DateTime PermitTrackingEventDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool PermitTrackingEventDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 24)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
    ////    public string NarrativeConditionNumber;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
    ////    public string ScheduleEventCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 26)]
    ////    public System.DateTime ScheduleDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ScheduleDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
    ////    [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(2)]
    ////    public NumericReportTextType NumericReportCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool NumericReportCodeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
    ////    [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(1)]
    ////    public NumericReportViolationCodeType NumericReportViolationCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool NumericReportViolationCodeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 29)]
    ////    public System.DateTime PermittingAuthorityReportReceivedDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool PermittingAuthorityReportReceivedDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 30)]
    ////    public System.DateTime PretreatmentPerformanceSummaryEndDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool PretreatmentPerformanceSummaryEndDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 31)]
    ////    public System.DateTime ReportCoverageEndDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ReportCoverageEndDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 32)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
    ////    public string SingleEventViolationCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 33)]
    ////    public System.DateTime SingleEventViolationDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SingleEventViolationDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 34)]
    ////    public System.DateTime SSOAnnualReportReceivedDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SSOAnnualReportReceivedDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 35)]
    ////    public System.DateTime SSOEventDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SSOEventDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 36)]
    ////    public System.DateTime SSOMonthlyReportReceivedDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SSOMonthlyReportReceivedDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 37)]
    ////    public System.DateTime StormWaterMS4ReportReceivedDate;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool StormWaterMS4ReportReceivedDateSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 38)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
    ////    public string EnforcementActionIdentifier;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
    ////    public string EnforcementActionIdentifier2;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
    ////    public string FinalOrderIdentifier;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
    ////    public string FinalOrderIdentifier2;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 42)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
    ////    public string ComplianceScheduleNumber;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
    ////    public string MilestoneTypeCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 44)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(3)]
    ////    public string ScheduleViolationCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 45)]
    ////    [Windsor.Commons.XsdOrm2.DbColumnTypeAttribute("Int32")]
    ////    public string EventId;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 46)]
    ////    [System.ComponentModel.DescriptionAttribute("An Service Provider (e.g., ICIS-NPDES) specific error code that uniquely identifi" +
    ////        "es a type of error, information or warning.")]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
    ////    public string ResultCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 47)]
    ////    [System.ComponentModel.DescriptionAttribute("The type of error, information or warning that is being returned.")]
    ////    [Windsor.Commons.XsdOrm2.DbFixedColumnSizeAttribute(11)]
    ////    public ResultTypeCodeDataType ResultTypeCode;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ResultTypeCodeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 48)]
    ////    [System.ComponentModel.DescriptionAttribute("A human readable description on an error, information or warning.")]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
    ////    public string ResultDescription;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 49)]
    ////    [System.ComponentModel.DescriptionAttribute("The transaction id of the submission.")]
    ////    [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
    ////    public string SubmissionTransactionId;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 50)]
    ////    [System.ComponentModel.DescriptionAttribute("The date and time when this row was created.")]
    ////    [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
    ////    public System.DateTime CreatedDateTime;
    ////}

    ////[Serializable]
    ////public class SubmissionResultList
    ////{
    ////    [System.Xml.Serialization.XmlElementAttribute("SubmissionResult", Order = 8)]
    ////    public SubmissionResultsDataType[] SubmissionResult;
    ////}

    ////[Serializable]
    ////public enum ResultTypeCodeDataType
    ////{
    ////    Error,
    ////    Information,
    ////    Warning,
    ////    Accepted,
    ////}

    ////[Serializable]
    ////public enum TransactionStatusCode
    ////{
    ////    Unknown,
    ////    Received,
    ////    Processing,
    ////    Pending,
    ////    Failed,
    ////    Cancelled,
    ////    Approved,
    ////    Processed,
    ////    Completed,
    ////}

    ////[Serializable]
    ////public partial class SubmissionTrackingDataType
    ////{
    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 0)]
    ////    public System.DateTime ETLCompletionDateTime;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ETLCompletionDateTimeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 1)]
    ////    public System.DateTime DETChangeCompletionDateTime;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool DETChangeCompletionDateTimeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 2)]
    ////    public System.DateTime SubmissionDateTime;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SubmissionDateTimeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
    ////    public string SubmissionTransactionId;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
    ////    public TransactionStatusCode SubmissionTransactionStatus;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SubmissionTransactionStatusSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 5)]
    ////    public System.DateTime SubmissionStatusDateTime;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool SubmissionStatusDateTimeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(DataType = "dateTime", Order = 6)]
    ////    public System.DateTime ResponseParseDateTime;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlIgnoreAttribute()]
    ////    public bool ResponseParseDateTimeSpecified;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
    ////    [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
    ////    public TransactionStatusCode WorkflowStatus;

    ////    /// <remarks/>
    ////    [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
    ////    [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
    ////    public string WorkflowStatusMessage;
    ////}
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
            return Value.ToString("G29");
        }
    }
}
