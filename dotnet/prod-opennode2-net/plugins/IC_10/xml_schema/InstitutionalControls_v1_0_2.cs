using System.Xml.Serialization;
using Windsor.Commons.XsdOrm2;
namespace Windsor.Node2008.WNOSPlugin.InstitutionalControls_10
{
    [DefaultTableNamePrefixAttribute("IC")]
    [DefaultDecimalPrecision(19, 14)]
    [RemovePostfixNamesFromTableAndColumnNamesAttribute("Data", "Details", "Code")]
    [NameReplacementsAttribute(
        "TRANSACTION_HEADER", ""
        , "TYPE_CODE", "CODE"
        , "TYPE_CODE_LIST", "LST"
        , "CODE_LIST", "LST"
        , "COORD_DATA", "COORD"
        , "INSTITUTIONAL", "INSTL"
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
        , "IDENTIFICATION", "IDFN"
        , "IDENTIFIER", "IDEN"
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
        , "LONGITUDE", "LON"
        , "CLASSIFICATION", "CLASS"
        , "PROGRAMS", "PROGS"
        , "PROGRAM", "PROG"
        , "AFFILIATION", "AFFIL"
        , "AFFILIATE", "AFFIL"
        , "INDIVIDUAL", "INDVL"
        , "ELECTRONIC", "ELEC"
        , "TELEPHONE", "TELE"
        , "TELEPHONIC", "TELE"
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
        , "ELEMENT", "ELEM"
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
        , "AGENCY", "AGCY"
        , "SOURCES", "SRCS"
        , "SOURCE", "SRC"
        , "FUNDING", "FUND"
        , "CREDIT", "CRDT"
        , "CREDITS", "CRDTS"
        , "LOCAL", "LOC"
        , "MANURE", "MNUR"
        , "ANNUAL", "ANNUL"
        , "DOCUMENT", "DOC"
        , "CONTROLS", "CTRLS"
        , "CONTROL", "CTRL"
        , "OBJECTIVE", "OBJTV"
        , "RESOURCE", "RSRC"
        , "INSTRUMENT", "INSTR"
        , "RECURRING", "RECR"
        , "ENGINEERING", "ENGR"
        , "CONTAMINANT", "CNTMT"
        , "REGISTRY", "REG"
        , "DEFINITION", "DEF"
        , "SUBSTANCE", "SUBST"
        , "CHEMICAL", "CHEM"
        , "INFORMATION", "INFO"
        , "SYSTEM", "INFO"
        , "QUALIFIER", "QUAL"
        , "VERSION", "VERS"
        , "IDENTITY", "IDTY"
        , "ACRONYM", "ACNYM"
        , "COUNTRY", "CNTRY"
        , "LIST", "LST"
        , "SITE", "SITE"
        , "RESTRICTION", "RSTCT"
        , "RESTRICTIVE", "RSTCT"
        , "RESTRICT", "RSTCT"
        , "RESULT", "RSLT"
        , "COUNTY", "CNTY"
        , "ACCURACY", "ACCY"
        , "VERIFICATION", "VERIF"
        , "POINT", "PT"
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
                    "srsName", "255",
                    "doubleList", "4000"
    )]

    [AppliedAttribute(typeof(Affiliate), "Item", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(IndividualIdentityDataType), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(IndividualIdentityDataType), "ItemsElementName", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(ICLocation), "Item", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "Item", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(EnvelopeType), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(EnvelopeType), "ItemsElementName", typeof(DbIgnoreAttribute))]

    [AppliedAttribute(typeof(LocationAddress), "StateIdentity", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LocationAddress), "AddressPostalCode", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LocationAddress), "CountryIdentity", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(LocationAddress), "CountyIdentity", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(MailingAddress), "StateIdentity", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MailingAddress), "AddressPostalCode", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(MailingAddress), "CountryIdentity", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(Instrument), "DataSource", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(Resource), "ElectronicAddress", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(StateIdentity), "StateCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(CountryIdentity), "CountryCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(CountyIdentity), "CountyCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(FacilitySiteIdentity), "FacilitySiteIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(FacilitySiteIdentity), "FacilitySiteType", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(FacilitySiteType), "FacilitySiteTypeCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(FacilityDataType), "FacilitySiteIdentity", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(FacilityDataType), "LocationAddress", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "HorizontalAccuracyMeasure", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "HorizontalCollectionMethod", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "GeographicReferencePoint", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "VerticalCollectionMethod", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "VerificationMethod", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(ICGeographicLocationDescriptionDataType), "CoordinateDataSource", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(HorizontalAccuracyMeasure), "MeasureUnit", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(HorizontalAccuracyMeasure), "ResultQualifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(HorizontalAccuracyMeasureUnit), "MeasureUnitCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(HorizontalAccuracyResultQualifier), "ResultQualifierCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(HorizontalCollectionMethod), "MethodIdentifierCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(GeographicReferencePoint), "ReferencePointCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(CoordinateDataSource), "CoordinateDataSourceCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(VerticalCollectionMethod), "MethodIdentifierCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(VerificationMethod), "MethodIdentifierCodeListIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(Affiliate), "MailingAddress", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(Affiliate), "IndividualIdentity", typeof(SameTableAttribute))]
    [AppliedAttribute(typeof(Affiliate), "OrganizationIdentity", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(IndividualIdentityDataType), "IndividualIdentifier", typeof(SameTableAttribute))]

    [AppliedAttribute(typeof(OrganizationIdentityDataType), "OrganizationIdentifier", typeof(SameTableAttribute))]

    public partial class MappingAttributes
    {
    }

    public partial class InstitutionalControlsDocumentDataType
    {
    }

    public partial class Affiliate
    {
        [XmlIgnore] // Before/AfterSaveToDatabase
        public IndividualIdentityDataType IndividualIdentity;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public OrganizationIdentityDataType OrganizationIdentity;
    }

    public partial class IndividualIdentityDataType
    {
        [XmlIgnore] // Before/AfterSaveToDatabase
        [Windsor.Commons.XsdOrm2.DbMaxColumnSize(50)]
        public string FirstName;

        [XmlIgnore] // Before/AfterSaveToDatabase
        [Windsor.Commons.XsdOrm2.DbMaxColumnSize(100)]
        public string IndividualFullName;

        [XmlIgnore] // Before/AfterSaveToDatabase
        [Windsor.Commons.XsdOrm2.DbMaxColumnSize(50)]
        public string LastName;

        [XmlIgnore] // Before/AfterSaveToDatabase
        [Windsor.Commons.XsdOrm2.DbMaxColumnSize(50)]
        public string MiddleName;
    }

    public partial class ICLocation
    {
        [XmlIgnore] // Before/AfterSaveToDatabase
        public FacilityDataType Facility;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public ICGeographicLocationDescriptionDataType ICGeographicLocationDescription;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public LandParcelDataType LandParcel;
    }

    public partial class ICGeographicLocationDescriptionDataType
    {
        [XmlIgnore] // Before/AfterSaveToDatabase
        public string srsName;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public int srsDimension;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool srsDimensionSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal PointLatitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool PointLatitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal PointLongitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool PointLongitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal EnvelopeUpperLatitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool EnvelopeUpperLatitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal EnvelopeUpperLongitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool EnvelopeUpperLongitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal EnvelopeLowerLatitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool EnvelopeLowerLatitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal EnvelopeLowerLongitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool EnvelopeLowerLongitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal LineStartLatitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool LineStartLatitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal LineStartLongitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool LineStartLongitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal LineEndLatitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool LineEndLatitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public decimal LineEndLongitude;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public bool LineEndLongitudeSpecified;

        [XmlIgnore] // Before/AfterSaveToDatabase
        public LatitudeLongitudePolygon[] Polygon;
    }

    public partial class LatitudeLongitudePolygon
    {
        [DbNotNull()]
        public decimal Latitude;

        [DbNotNull()]
        public decimal Longitude;
    }
}
