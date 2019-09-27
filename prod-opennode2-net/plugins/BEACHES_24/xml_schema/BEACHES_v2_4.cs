namespace Windsor.Node2008.WNOSPlugin.BEACHES_24
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachCoordinateStartPointDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachCoordinatePointDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public decimal LatitudeMeasure;
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public decimal LongitudeMeasure;
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the method used to determine the latitude and longitude " +
            "coordinates for a point on the earth.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the reference datum used in determining latitude and long" +
            "itude coordinates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCoordinateReferenceSystemDatumName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachAccessibilityType", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum BeachAccessibilityDataType
    {

        /// <remarks/>
        PUB_PUB_ACC,

        /// <remarks/>
        PRV_PRV_ACC,

        /// <remarks/>
        PUB_PRV_ACC,

        /// <remarks/>
        PRV_PUB_ACC,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachAccessibilityDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachAccessibilityDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The accessibility of the beach (ex: PUB_PUB_ACC, PRV_PUB_ACC)")]
        public BeachAccessibilityDataType BeachAccessibilityType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A short comment about the accessibility of the beach")]
        public string BeachAccessibilityComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("WaterBodyNameCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum WaterBodyNameCodeDataType
    {

        /// <remarks/>
        ATLANTIC,

        /// <remarks/>
        PACIFIC,

        /// <remarks/>
        GULF_MEXICO,

        /// <remarks/>
        LAKE_SUPR,

        /// <remarks/>
        LAKE_MCHGN,

        /// <remarks/>
        LAKE_HURON,

        /// <remarks/>
        LAKE_ERIE,

        /// <remarks/>
        LAKE_ONTR,

        /// <remarks/>
        INLAND,

        /// <remarks/>
        LNG_ISL_SND,

        /// <remarks/>
        CHSPK_BAY,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item1,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("WaterBodyTypeCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum WaterBodyTypeCodeDataType
    {

        /// <remarks/>
        OPEN_COAST,

        /// <remarks/>
        SND_BY_INLT,

        /// <remarks/>
        STILL_WATER,

        /// <remarks/>
        FLOW_WATER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("PersonStatusIndicator", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum StatusDataType
    {

        /// <remarks/>
        ACTIVE,

        /// <remarks/>
        INACTIVE,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityExtentUnitOfMeasureCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum ActivityExtentUnitOfMeasureCodeDataType
    {

        /// <remarks/>
        FT,

        /// <remarks/>
        YDS,

        /// <remarks/>
        MI,

        /// <remarks/>
        M,

        /// <remarks/>
        KM,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityExtentDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ActivityExtentDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        // TSM:
        //public decimal ActivityExtentStartMeasure;
        public string ActivityExtentStartMeasure;

        // TSM:
        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ActivityExtentStartMeasureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The length of the measure")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public decimal ActivityExtentLengthMeasure;
        public string ActivityExtentLengthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unit of length for the measurement")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityExtentUnitOfMeasureCodeDataType ActivityExtentUnitOfMeasureCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityIndicatorType", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum ActivityIndicatorDataType
    {

        /// <remarks/>
        PREEMPT,

        /// <remarks/>
        ENTERO,

        /// <remarks/>
        TOTAL_COL,

        /// <remarks/>
        FECAL_COL,

        /// <remarks/>
        ECOLI,

        /// <remarks/>
        RATIO,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityIndicatorDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ActivityIndicatorDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code for the indicator")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityIndicatorDataType ActivityIndicatorType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A short description of the type of indicator")]
        public string ActivityIndicatorDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivitySourceType", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum ActivitySourceDataType
    {

        /// <remarks/>
        AGRICULTURAL,

        /// <remarks/>
        ALGAE,

        /// <remarks/>
        BOAT,

        /// <remarks/>
        CAFO,

        /// <remarks/>
        CSO,

        /// <remarks/>
        POTW,

        /// <remarks/>
        RUNOFF,

        /// <remarks/>
        SEPTIC,

        /// <remarks/>
        SEWER_LINE,

        /// <remarks/>
        SSO,

        /// <remarks/>
        STORM,

        /// <remarks/>
        WILDLIFE,

        /// <remarks/>
        UNKNOWN,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivitySourceDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ActivitySourceDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code for the source of the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivitySourceDataType ActivitySourceType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A short description of the source of the activity")]
        public string ActivitySourceDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityReasonType", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum ActivityReasonDataType
    {

        /// <remarks/>
        ELEV_BACT,

        /// <remarks/>
        RAINFALL,

        /// <remarks/>
        SEWAGE,

        /// <remarks/>
        CHEM_OIL,

        /// <remarks/>
        MODEL,

        /// <remarks/>
        POLICY,

        /// <remarks/>
        OTHER,

        /// <remarks/>
        MODEL_VB,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityReasonDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ActivityReasonDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code for the reason for the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityReasonDataType ActivityReasonType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A short description of the reason for the activity")]
        public string ActivityReasonDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachPollutionSourceCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum BeachPollutionSourceCodeDataType
    {

        /// <remarks/>
        AGRICULTURAL,

        /// <remarks/>
        ALGAE,

        /// <remarks/>
        BOAT,

        /// <remarks/>
        CAFO,

        /// <remarks/>
        CSO,

        /// <remarks/>
        POTW,

        /// <remarks/>
        RUNOFF,

        /// <remarks/>
        SEPTIC,

        /// <remarks/>
        SEWER_LINE,

        /// <remarks/>
        SSO,

        /// <remarks/>
        STORM,

        /// <remarks/>
        WILDLIFE,

        /// <remarks/>
        UNKNOWN,

        /// <remarks/>
        OTHER,

        /// <remarks/>
        TBD,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachPollutionSourceDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachPollutionSourceDetailDataType
    {

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("BeachPollutionSource", typeof(BeachPollutionSourceDataType), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("NoPollutionSourcesIndicator", typeof(bool), Order = 0)]
        //[System.Xml.Serialization.XmlElementAttribute("PollutionSourcesUninvestigatedIndicator", typeof(bool), Order = 0)]
        //[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        //public object[] Items;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public ItemsChoiceType[] ItemsElementName;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachPollutionSource")]
        [System.ComponentModel.DescriptionAttribute("A list of pollution sources.  Only one of the following is allowed: a list of pol" +
            "lution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigat" +
            "ed must be true.")]
        public BeachPollutionSourceDataType[] BeachPollutionSource;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        [System.ComponentModel.DescriptionAttribute("This can only be true.  Only one of the following is allowed: a list of pollution" +
            " sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated mus" +
            "t be true.")]
        public string NoPollutionSourcesIndicator;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        [System.ComponentModel.DescriptionAttribute("This can only be true.  Only one of the following is allowed: a list of pollution" +
            " sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated mus" +
            "t be true.")]
        public string PollutionSourcesUninvestigatedIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachPollutionSource", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachPollutionSourceDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code representing the source of the polution")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public BeachPollutionSourceCodeDataType BeachPollutionSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A short description of the pollution source")]
        public string BeachPollutionSourceDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("A list of pollution sources.  Only one of the following is allowed: a list of pol" +
            "lution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigat" +
            "ed must be true.")]
        BeachPollutionSource,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This can only be true.  Only one of the following is allowed: a list of pollution" +
            " sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated mus" +
            "t be true.")]
        NoPollutionSourcesIndicator,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("This can only be true.  Only one of the following is allowed: a list of pollution" +
            " sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated mus" +
            "t be true.")]
        PollutionSourcesUninvestigatedIndicator,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringFrequencyUnitOfMeasureCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum MonitoringFrequencyUnitOfMeasureCodeDataType
    {

        /// <remarks/>
        PER_DAY,

        /// <remarks/>
        PER_WEEK,

        /// <remarks/>
        PER_MONTH,

        /// <remarks/>
        PER_YEAR,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ReportingFrequencyUnitOfMeasureCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum ReportingFrequencyUnitOfMeasureCodeDataType
    {

        /// <remarks/>
        PER_DAY,

        /// <remarks/>
        PER_WEEK,

        /// <remarks/>
        PER_MONTH,

        /// <remarks/>
        PER_YEAR,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("AdvReportingFrequencyUnitOfMeasureCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum AdvReportingFrequencyUnitOfMeasureCode
    {

        /// <remarks/>
        PER_DAY,

        /// <remarks/>
        PER_WEEK,

        /// <remarks/>
        PER_MONTH,

        /// <remarks/>
        PER_YEAR,
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ReportingFrequencyDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ReportingFrequencyDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the reporting length")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public decimal ReportingFrequencyMeasure;
        public string ReportingFrequencyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The unit of time that is used for the measurements")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ReportingFrequencyUnitOfMeasureCodeDataType ReportingFrequencyUnitOfMeasureCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("AdvReportingFrequencyDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class AdvReportingFrequencyDetail
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the advisory reporting length")]
        // TSM:
        //public decimal AdvReportingFrequencyMeasure;
        public string AdvReportingFrequencyMeasure;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool AdvReportingFrequencyMeasureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The unit of time that is used for the advisory measurements")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(9)]
        public AdvReportingFrequencyUnitOfMeasureCode AdvReportingFrequencyUnitOfMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AdvReportingFrequencyUnitOfMeasureCodeSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringFrequencyDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class MonitoringFrequencyDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the length of the swim season")]
        // TSM:
        //public decimal SwimSeasonFrequencyMeasure;
        public string SwimSeasonFrequencyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the lenght of the off season")]
        // TSM:
        //public decimal OffSeasonFrequencyMeasure;
        public string OffSeasonFrequencyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unit of time that is used for the measurements")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MonitoringFrequencyUnitOfMeasureCodeDataType MonitoringFrequencyUnitOfMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("True if a beach is sporadically monitored.  False in any other case")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public bool MonitoredIrregularly;
        public string MonitoredIrregularly;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Any comments about the monitoring frequency of the beach.")]
        public string MonitoredIrregularlyComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("SwimSeasonUnitOfMeasureCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum SwimSeasonUnitOfMeasureCodeDataType
    {

        /// <remarks/>
        DAYS,

        /// <remarks/>
        WEEKS,

        /// <remarks/>
        MONTHS,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachSwimSeasonLengthDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachSwimSeasonLengthDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The length of the swim season day in hours.")]
        // TSM:
        //public decimal SwimSeasonDayMeasure;
        public string SwimSeasonDayMeasure;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool SwimSeasonDayMeasureSpecified;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SwimSeasonStartDate", typeof(System.DateTime), DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The start date of the swim season")]
        public System.DateTime SwimSeasonStartDate;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SwimSeasonStartDateSpecified;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that descreibes the length of the swim season")]
        //public decimal SwimSeasonLengthMeasure;
        public string SwimSeasonLengthMeasure;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SwimSeasonEndDate", typeof(System.DateTime), DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The end date of the swim season")]
        public System.DateTime SwimSeasonEndDate;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SwimSeasonEndDateSpecified;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SwimSeasonUnitOfMeasureCode", typeof(SwimSeasonUnitOfMeasureCodeDataType), Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure for the length of the swim season")]
        public SwimSeasonUnitOfMeasureCodeDataType SwimSeasonUnitOfMeasureCode;

        // TSM:
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SwimSeasonUnitOfMeasureCodeSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The end date of the swim season")]
        SwimSeasonEndDate,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The number that describes the length of the swim season")]
        SwimSeasonLengthMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The start date of the swim season")]
        SwimSeasonStartDate,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The unit of measure for the length of the swim season")]
        SwimSeasonUnitOfMeasureCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ExtentUnitOfMeasureCode", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum DistanceUnitOfMeasureCodeDataType
    {

        /// <remarks/>
        FT,

        /// <remarks/>
        YDS,

        /// <remarks/>
        MI,

        /// <remarks/>
        M,

        /// <remarks/>
        KM,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachCriterionDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachCriterionDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the criterion name")]
        public IndicatorNameDataType IndicatorName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The water type in which the criterion was tested")]
        public WaterTypeNameDataType WaterTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The criterion measure detail")]
        public CriterionMeasureDataType CriterionMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A short comment on the criterion. Can also contain a URL on how the State decides" +
            " to issue an advisory or closure")]
        public string CriterionComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("IndicatorName", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum IndicatorNameDataType
    {

        /// <remarks/>
        ENTEROCOCCI,

        /// <remarks/>
        FECAL,

        /// <remarks/>
        TOTAL,

        /// <remarks/>
        ECOLI,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("WaterTypeName", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum WaterTypeNameDataType
    {

        /// <remarks/>
        MARINE,

        /// <remarks/>
        FRESH,

        /// <remarks/>
        BOTH,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("CriterionMeasure", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class CriterionMeasureDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type measure done on the criterion")]
        public MeasureTypeNameDataType MeasureTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the criterion measure")]
        // TSM:
        //public decimal MeasureValue;
        public string MeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The units that the criterion was measured")]
        public string MeasureUnitCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureTypeName", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public enum MeasureTypeNameDataType
    {
        /// <remarks/>
        GM,

        /// <remarks/>
        SSM,

        /// <remarks/>
        CFU,

        /// <remarks/>
        STV,

        /// <remarks/>
        qPCR,

        /// <remarks/>
        CCE,

        /// <remarks/>
        BNT,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationNameDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class OrganizationNameDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details the type of agency being described")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Details the name of the organization being described")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A short text description of the organization")]
        public string OrganizationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The abbreviation of the organization being described")]
        public string OrganizationAbbreviationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationMailingAddressDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class MailingAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Details what type the mailing address is")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The first line of the address")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressStreetLine1Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The second line of the address")]
        public string MailingAddressStreetLine2Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The third line of the address")]
        public string MailingAddressStreetLine3Text;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The city name of the address")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The state code of the address")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The zip code of the address")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The date the change becomes effective")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime MailingAddressEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The status that the mailing address will be changed to")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public StatusDataType MailingAddressStatusIndicator;
    }

    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    //[System.Xml.Serialization.XmlRootAttribute("OrganizationElectronicAddressDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    //public partial class ElectronicAddressType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("The type of electronic address being described (ex: EMAIL, URL)")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public string ElectronicAddressTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("The actual address being described")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public string ElectronicAddressText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("The date the change becomes effective")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public System.DateTime ElectronicAddressEffectiveDate;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("The status the address will be changed to")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public StatusDataType ElectronicAddressStatusIndicator;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationTelephoneDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class TelephoneType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of telephone number being described (ex: VOICE, FAX)")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TelephoneTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The actual telephone number being described (Must include \"-\".  ex: xxx-xxx-xxxx)" +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date the number becomes effective")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TelephoneEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The status the number will be changed to (ex: ACTIVE, INACTIVE)")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public StatusDataType TelephoneStatusIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("PersonNameDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class PersonNameDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the person is ACTIVE or INACTIVE")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public StatusDataType PersonStatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The first name of the person")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The last name of the person")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The middle initial of the person")]
        public string PersonMiddleInitial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The person\'s suffix")]
        public string NameSuffixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The person\'s title")]
        public string NamePrefixText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationPersonDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class PersonDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique code that identifies each a person")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PersonIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a person\'s name.")]
        public PersonNameDetailDataType PersonNameDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PersonMailingAddressDetail", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information for the person.")]
        // TSM:
        //public MailingAddressDataType[] PersonMailingAddressDetail;
        public PersonMailingAddressDataType[] PersonMailingAddressDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PersonElectronicAddressDetail", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with a person\'s electronic addresses.")]
        // TSM:
        //public ElectronicAddressType[] PersonElectronicAddressDetail;
        public PersonElectronicAddressType[] PersonElectronicAddressDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PersonTelephoneDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with a person\'s telephone number.")]
        // TSM:
        //public TelephoneType[] PersonTelephoneDetail;
        public PersonTelephoneType[] PersonTelephoneDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationStateContactDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class StateContactDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a contact\'s name.")]
        public ContactNameDetailDataType ContactNameDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Details the name of the state contact\'s agency being described")]
        public string ContactAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The state contact\'s telephone number being described (Must include \"-\".  ex: xxx-" +
            "xxx-xxxx)")]
        public string ContactTelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The state contact\'s electronic address being described")]
        public string ContactElectronicAddressText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("ContactNameDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ContactNameDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The first name of the state contact")]
        public string ContactFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The last name of the state contact")]
        public string ContactLastName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class OrganizationDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique code that identifies each organization")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Details about the organization")]
        public OrganizationNameDetailDataType OrganizationNameDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationMailingAddressDetail", Order = 2)]
        // TSM:
        //public MailingAddressDataType[] OrganizationMailingAddressDetail;
        public OrganizationMailingAddressDataType[] OrganizationMailingAddressDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationElectronicAddressDetail", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with an organization\'s electronic addresses.")]
        // TSM:
        //public ElectronicAddressType[] OrganizationElectronicAddressDetail;
        public OrganizationElectronicAddressType[] OrganizationElectronicAddressDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationTelephoneDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with an organization\'s telephone number.")]
        // TSM:
        //public TelephoneType[] OrganizationTelephoneDetail;
        public OrganizationTelephoneType[] OrganizationTelephoneDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationPersonDetail", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a person.")]
        public PersonDetailDataType[] OrganizationPersonDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationStateContactDetail", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a state contact")]
        public StateContactDetailDataType[] OrganizationStateContactDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachNameDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ProgramInterestDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the program interest")]
        public string ProgramInterestName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A short description of the program interest")]
        public string ProgramInterestDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A comment about the program interest")]
        public string ProgramInterestCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The two letter code fot the state the program interest is located in")]
        public string ProgramInterestStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The FIPS county code for the program interest")]
        public string ProgramInterestFIPSCountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The water body name code for the beach.")]
        public WaterBodyNameCodeDataType WaterBodyNameCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WaterBodyNameCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The water body type code for the beach.")]
        public WaterBodyTypeCodeDataType WaterBodyTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WaterBodyTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Information about the accessibility of the beach")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public BeachAccessibilityDetailDataType BeachAccessibilityDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachExtentDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ExtentDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The length of the object")]
        // TSM:
        //public decimal ExtentLengthMeasure;
        public string ExtentLengthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The unit of measurement")]
        public DistanceUnitOfMeasureCodeDataType ExtentUnitOfMeasureCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachAttributeDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachAttributeDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The year the attribute is effective")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public decimal AttributeEffectiveYear;
        public string AttributeEffectiveYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The length of the beach.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ExtentDetailDataType BeachExtentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The length of the swim season")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public BeachSwimSeasonLengthDetailDataType BeachSwimSeasonLengthDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The frequency the beach is reported")]
        public ReportingFrequencyDetailDataType ReportingFrequencyDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The frequency advisories are reported")]
        public AdvReportingFrequencyDetail AdvReportingFrequencyDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The frequency the beach is monitored")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MonitoringFrequencyDetailDataType MonitoringFrequencyDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Description of the polution source")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public BeachPollutionSourceDetailDataType BeachPollutionSourceDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The tier of the beach")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BeachTierRanking;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("True if the beach qualifies as a BEACH Act beach.  False in any other case")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public bool BeachActBeachIndicator;
        public string BeachActBeachIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("True if the beach qualifies as a dormant beach.  False in any other case")]
        // TSM:
        //public bool BeachDormantIndicator;
        public string BeachDormantIndicator;

        /// <remarks/>
        // TSM:
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool BeachDormantIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachCriterionDetail", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The exceedence that may or may not trigger a beach activity")]
        public BeachCriterionDetailDataType[] BeachCriterionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The state specified website")]
        public string BeachWebsite;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachActivityDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class ActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code for the type of activity being reported (ex: CLOSURE, CONTAM_ADV)")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the activity being reported for the beach")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The start date for the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ActivityActualStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The stop date for the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ActivityActualStopDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Time period of partial day activites, in hours.")]
        // TSM:
        //public decimal ActivityPartialDayAmount;
        public string ActivityPartialDayAmount;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ActivityPartialDayAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityReasonDetail", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The reason for the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityReasonDetailDataType[] ActivityReasonDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivitySourceDetail", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Describes the source of the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivitySourceDetailDataType[] ActivitySourceDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityIndicatorDetail", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The indicator used to test the activity")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityIndicatorDetailDataType[] ActivityIndicatorDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityMonitoringStationIdentifier", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The unique identifier for the monitoring station")]
        public string[] ActivityMonitoringStationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A short description of the activity")]
        public string ActivityDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A comment about the activity")]
        public string ActivityCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The distance of the beach that the activity affects")]
        public ActivityExtentDetailDataType ActivityExtentDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachRoleDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class RoleDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code for the role of the beach (ex: LOCAL, RESPONDENT)")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BeachRoleTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The organization this beach role belongs to")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BeachRoleOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The code for the person associated with the role")]
        public string BeachRolePersonIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date the role becomes effective")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime BeachRoleEffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the role is ACTIVE or INACTIVE")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public StatusDataType BeachRoleStatusIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachCoordinateDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class CoordinateDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Geospatial description of the starting point of a beach.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public BeachCoordinatePointDetailDataType BeachCoordinateStartPointDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Geospatial description of the ending point of a beach.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public BeachCoordinatePointDetailDataType BeachCoordinateEndPointDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A short description of this coordinate point.")]
        public string BeachCoordinateDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique code that identifies the beach")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BeachIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a beach.")]
        public ProgramInterestDataType BeachNameDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with a beach\'s attributes.")]
        public BeachAttributeDetailDataType BeachAttributeDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ActivityCodeNumber", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("All the activity delete codes.")]
        //public decimal[] ActivityDeleteDetail;
        public string[] ActivityDeleteDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachActivityDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with an activity.")]
        public ActivityDataType[] BeachActivityDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachRoleDetail", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a beach role.")]
        // TSM:
        //public RoleDetailDataType[] BeachRoleDetail;
        public OrganizationRoleDetailDataType[] BeachRoleDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachCoordinateDetail", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with a beach coordinate.")]
        //public CoordinateDetailDataType[] BeachCoordinateDetail;
        public CoordinateDetailDataType BeachCoordinateDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachProcedureDetail", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachProcedureDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that identifies the procedure")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProcedureTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The description of the procedure")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProcedureDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The code that identifies the procedure")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProcedureIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcedureBeachIdentifier", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The unique code that identifies the beach")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string[] ProcedureBeachIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("YearCompletionIndicators", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class YearCompletionIndicatorDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The year the status indicators are for.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public decimal CompletionYear;
        public string CompletionYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("True if all Notification Data has been submitted for the year.  False in any othe" +
            "r case")]
        // TSM:
        //public bool NotificiationDataCompleteIndicator;
        public string NotificiationDataCompleteIndicator;

        // TSM:
        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool NotificiationDataCompleteIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("True if all Monitoring Data has been submitted for the year.  False in any other " +
            "case")]
        // TSM:
        //public bool MonitoringDataCompleteIndicator;
        public string MonitoringDataCompleteIndicator;

        // TSM:
        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool MonitoringDataCompleteIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("True if all Location Data has been submitted for the year.  False in any other ca" +
            "se")]
        // TSM:
        //public bool LocationDataCompleteIndicator;
        public string LocationDataCompleteIndicator;

        // TSM:
        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool LocationDataCompleteIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2")]
    [System.Xml.Serialization.XmlRootAttribute("BeachDataSubmission", Namespace = "http://www.exchangenetwork.net/schema/BEACHES/2", IsNullable = false)]
    public partial class BeachDataSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationDetail", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("All the information associated with an organization.")]
        public OrganizationDetailDataType[] OrganizationDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachDetail", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with a beach.")]
        public BeachDetailDataType[] BeachDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BeachProcedureDetail", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("All the information asssociated with a procedure.")]
        public BeachProcedureDetailDataType[] BeachProcedureDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Information about what data has been completely submitted for the year.")]
        public YearCompletionIndicatorDataType YearCompletionIndicators;
    }
}
