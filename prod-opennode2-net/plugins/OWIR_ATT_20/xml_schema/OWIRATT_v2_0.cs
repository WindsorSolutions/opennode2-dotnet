namespace Windsor.Node2008.WNOSPlugin.OWIR_ATT_20
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("UserCategories", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class UserCategoriesDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UserCategoryDetails", Order = 0)]
        public UserCategoryDetailsDataType[] UserCategoryDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("UserCategoryDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class UserCategoryDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string CategoryID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string CategoryDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentWaters", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentWatersDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentWaterDetails", Order = 0)]
        public AssessmentWaterDetailsDataType[] AssessmentWaterDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentWaterDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentWaterDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(23)]
        //public WaterTypeDataType WaterType;
        public string WaterType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal WaterSize;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("WaterType", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum WaterTypeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Great Lake - Open Water")]
        GreatLakeOpenWater,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Blackwater System")]
        BlackwaterSystem,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Coastal Waters")]
        CoastalWaters,

        /// <remarks/>
        Estuary,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Freshwater Lake")]
        FreshwaterLake,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Freshwater Reservoir")]
        FreshwaterReservoir,

        /// <remarks/>
        Impoundment,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Bay(s) and Harbor")]
        BaysandHarbor,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Great Lakes Shoreline")]
        GreatLakesShoreline,

        /// <remarks/>
        Ocean,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("River, Intermittent")]
        RiverIntermittent,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("River, Perennial")]
        RiverPerennial,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Saline Lake")]
        SalineLake,

        /// <remarks/>
        Spring,

        /// <remarks/>
        Wetland,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Wetlands, Freshwater")]
        WetlandsFreshwater,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Wetlands, Tidal")]
        WetlandsTidal,

        /// <remarks/>
        Creek,

        /// <remarks/>
        Pond,

        /// <remarks/>
        Reservoir,

        /// <remarks/>
        River,

        /// <remarks/>
        Stream,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Ephemeral Stream")]
        EphemeralStream,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Tidal River")]
        TidalRiver,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("CycleTracks", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class CycleTracksDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CycleTrackDetails", Order = 0)]
        public CycleTrackDetailsDataType[] CycleTrackDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("CycleTrackDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class CycleTrackDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string PreID305b;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string PreCycle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public PurposeDataType Purpose;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("Purpose", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum PurposeDataType
    {

        /// <remarks/>
        Split,

        /// <remarks/>
        Rename,

        /// <remarks/>
        Join,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("EPACauseCategory", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum EPACauseCategoryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4a")]
        Item4a,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4b")]
        Item4b,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4c")]
        Item4c,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5m")]
        Item5m,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("Causes", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class CausesDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CauseDetails", Order = 0)]
        public CauseDetailsDataType[] CauseDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("CauseDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class CauseDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string CauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public StringYesNoDataType PollutantFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PollutantFlagSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string CauseComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string UserFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        // TSM:
        //public EPACauseCategoryDataType EPACauseCategory;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string EPACauseCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPACauseCategorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SourceDetails", IsNullable = false)]
        public SourceDetailsDataType[] Sources;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public ConfidenceDataType Confidence;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConfidenceSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string StateCauseCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public StringYNDataType EPAAddedCause;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAAddedCauseSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("PollutantFlag", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum StringYesNoDataType
    {

        /// <remarks/>
        Yes,

        /// <remarks/>
        No,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("SourceDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class SourceDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(250)]
        public string SourceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string SourceComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public StringYNDataType Confirmed;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConfirmedSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("EPAAddedCause", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum StringYNDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("Confidence", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum ConfidenceDataType
    {

        /// <remarks/>
        High,

        /// <remarks/>
        Medium,

        /// <remarks/>
        Low,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("Sources", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class SourcesDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SourceDetails", Order = 0)]
        public SourceDetailsDataType[] SourceDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnitCauses", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentUnitCausesDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentUnitCauseDetails", Order = 0)]
        public AssessmentUnitCauseDetailsDataType[] AssessmentUnitCauseDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnitCauseDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentUnitCauseDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string CauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 1)]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CycleFirstListed;

        // TSM: 
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CycleFirstListedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        public System.DateTime ExpectedToAttainDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExpectedToAttainDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 3)]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string TMDLSchedule;

        // TSM: 
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TMDLScheduleSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public TMDLPriorityDataType TMDLPriority;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TMDLPrioritySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime TMDLCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TMDLCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string TMDLProjectStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string TMDLProjectComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ImplementationActionDetails", IsNullable = false)]
        public ImplementationActionDetailsDataType[] ImplementationActions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 9)]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ConsentDecreeCycle;

        // TSM: 
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConsentDecreeCycleSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(16)]
        //public PollutionSourceTypeDataType PollutionSourceType;
        public string PollutionSourceType;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PollutionSourceTypeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(250)]
        public string JustificationURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string OtherPointSourceID;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 13)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TMDLsDetails", IsNullable = false)]
        public TMDLsDetailsDataType[] TMDLs;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 14)]
        [System.Xml.Serialization.XmlArrayItemAttribute("NPDESDetails", IsNullable = false)]
        public NPDESDetailsDataType[] NPDES;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLPriority", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum TMDLPriorityDataType
    {

        /// <remarks/>
        Low,

        /// <remarks/>
        Medium,

        /// <remarks/>
        High,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("ImplementationActionDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class ImplementationActionDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string ImplementationActionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("PollutionSourceType", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum PollutionSourceTypeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Point Source")]
        PointSource,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Non-Point Source")]
        NonPointSource,

        /// <remarks/>
        Both,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLsDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class TMDLsDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public uint TMDLID;
        public int TMDLID;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    public partial class NPDESDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESID", Order = 0)]
        public string Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("ImplementationActions", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class ImplementationActionsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ImplementationActionDetails", Order = 0)]
        public ImplementationActionDetailsDataType[] ImplementationActionDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLs", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class TMDLsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TMDLsDetails", Order = 0)]
        public TMDLsDetailsDataType[] TMDLsDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("NPDES", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class NPDESDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESDetails", Order = 0)]
        public NPDESDetailsDataType[] NPDESDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateMethodDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateMethodDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssessmentMethodIdentifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The title of the method that appears on the method from the organization that pub" +
            "lished it.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(90)]
        public string AssessmentMethodName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateMethods", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateMethodsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateMethodDetails", Order = 0)]
        public StateMethodDetailsDataType[] StateMethodDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentMethods", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentMethodsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentMethodDetails", Order = 0)]
        public AssessmentMethodDetailsDataType[] AssessmentMethodDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentMethodDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentMethodDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssessmentMethodIdentifierCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQSAttainments", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class WQSAttainmentsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WQSAttainmentDetails", Order = 0)]
        public WQSAttainmentDetailsDataType[] WQSAttainmentDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQSAttainmentDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class WQSAttainmentDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string UseDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public AttainmentDescriptionDataType AttainmentDescription;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(24)]
        public string AttainmentDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public StringYesNoDataType ThreatenedFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThreatenedFlagSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string UseComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        public System.DateTime AssessmentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AssessmentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        public System.DateTime StartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentMethodDetails", IsNullable = false)]
        public AssessmentMethodDetailsDataType[] AssessmentMethods;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentTypeDetails", IsNullable = false)]
        public AssessmentTypeDetailsDataType[] AssessmentTypes;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CauseDetails", IsNullable = false)]
        public CauseDetailsDataType[] Causes;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ObservedEffectDetails", IsNullable = false)]
        public ObservedEffectDetailsDataType[] ObservedEffects;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        public System.DateTime KeyDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KeyDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string Assessor;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public StringYNDataType EPAAddedAttainment;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAAddedAttainmentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string StateUseCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        // TSM:
        //public EPACategory EPAUseCategory;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string EPAUseCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAUseCategorySpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AttainmentDescription", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum AttainmentDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Fully Supporting")]
        FullySupporting,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Insufficient Information")]
        InsufficientInformation,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not Supporting")]
        NotSupporting,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not Assessed")]
        NotAssessed,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentTypeDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentTypeDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public AssessmentTypeTypeDataType AssessmentTypeType;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(30)]
        public string AssessmentTypeType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AssessmentConfidenceDataType AssessmentConfidence;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AssessmentConfidenceSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentTypeType", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum AssessmentTypeTypeDataType
    {

        /// <remarks/>
        Biological,

        /// <remarks/>
        Habitat,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Physical/Chemical")]
        PhysicalChemical,

        /// <remarks/>
        Toxicological,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Pathogen Indicators")]
        PathogenIndicators,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Other Public Health Indicators")]
        OtherPublicHealthIndicators,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Other Aquatic Life Indicators")]
        OtherAquaticLifeIndicators,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentConfidence", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum AssessmentConfidenceDataType
    {

        /// <remarks/>
        Low,

        /// <remarks/>
        Fair,

        /// <remarks/>
        Good,

        /// <remarks/>
        Excellent,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("ObservedEffectDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class ObservedEffectDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string CauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public object ObservedEffectsComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("EPAUseCategory", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum EPACategory
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4a")]
        Item4a,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4b")]
        Item4b,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4c")]
        Item4c,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5m")]
        Item5m,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentTypes", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentTypesDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentTypeDetails", Order = 0)]
        public AssessmentTypeDetailsDataType[] AssessmentTypeDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "ObservedEffectsDataType", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("ObservedEffects", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class ObservedEffectsDataType1 : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ObservedEffectDetails", Order = 0)]
        public ObservedEffectDetailsDataType[] ObservedEffectDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnitDelists", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentUnitDelistsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentUnitDelistDetails", Order = 0)]
        public AssessmentUnitDelistDetailsDataType[] AssessmentUnitDelistDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnitDelistDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentUnitDelistDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(240)]
        public string CauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime DelistingDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DelistingDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        //public DelistingReasonDataType DelistingReason;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(120)]
        public string DelistingReason;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string DelistingComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("DelistingReason", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum DelistingReasonDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TMDL Alternative (4B)")]
        TMDLAlternative4B,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not caused by a pollutant (4C)")]
        Notcausedbyapollutant4C,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TMDL approved or established by EPA (4A)")]
        TMDLapprovedorestablishedbyEPA4A,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Applicable WQS attained; due to restoration activities")]
        ApplicableWQSattainedduetorestorationactivities,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Applicable WQS attained; due to change in WQS")]
        ApplicableWQSattainedduetochangeinWQS,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Applicable WQS attained; according to new assessment method")]
        ApplicableWQSattainedaccordingtonewassessmentmethod,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Applicable WQS attained; threatened water no longer threatened")]
        ApplicableWQSattainedthreatenedwaternolongerthreatened,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Applicable WQS attained; reason for recovery unspecified")]
        ApplicableWQSattainedreasonforrecoveryunspecified,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Applicable WQS attained; original basis for listing was incorrect")]
        ApplicableWQSattainedoriginalbasisforlistingwasincorrect,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Data and/or information lacking to determine water quality status; original basis" +
            " for listing was incorrect (Category 3)")]
        DataandorinformationlackingtodeterminewaterqualitystatusoriginalbasisforlistingwasincorrectCategory3,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnits", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentUnitsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentUnitDetails", Order = 0)]
        public AssessmentUnitDetailsDataType[] AssessmentUnitDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnitDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class AssessmentUnitDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string ID305b;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(60)]
        public string WaterName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(255)]
        public string Location;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public TrophicStatusDataType TrophicStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TrophicStatusSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public StringYesNoDataType PublicLake;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PublicLakeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string MonitoringScheduledYear;

        // TSM: 
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MonitoringScheduledYearSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string ClassName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string ClassDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string Assessor;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(10)]
        public string CategoryID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        // TSM:
        //public EPACategory EPACategory;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(6)]
        public string EPACategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPACategorySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string AssessmentUnitComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(20)]
        public string AssessmentUnitOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 13)]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string CycleLastAssessed;

        // TSM: 
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CycleLastAssessedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public TrendDataType Trend;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TrendSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 15)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentWaterDetails", IsNullable = false)]
        public AssessmentWaterDetailsDataType[] AssessmentWaters;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 16)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CycleTrackDetails", IsNullable = false)]
        public CycleTrackDetailsDataType[] CycleTracks;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 17)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentUnitCauseDetails", IsNullable = false)]
        public AssessmentUnitCauseDetailsDataType[] AssessmentUnitCauses;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 18)]
        [System.Xml.Serialization.XmlArrayItemAttribute("WQSAttainmentDetails", IsNullable = false)]
        public WQSAttainmentDetailsDataType[] WQSAttainments;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 19)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentUnitDelistDetails", IsNullable = false)]
        public AssessmentUnitDelistDetailsDataType[] AssessmentUnitDelists;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        // TSM:
        //public CategoryReportFlagDataType CategoryReportFlag;
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string CategoryReportFlag;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CategoryReportFlagSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        public StringYNDataType EPAAddedAssessmentUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAAddedAssessmentUnitSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        public StringYNDataType Assessed;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AssessedSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("TrophicStatus", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum TrophicStatusDataType
    {

        /// <remarks/>
        Dystrophic,

        /// <remarks/>
        Eutrophic,

        /// <remarks/>
        Hypereutrophic,

        /// <remarks/>
        Mesotrophic,

        /// <remarks/>
        Oligotrophic,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("Trend", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum TrendDataType
    {

        /// <remarks/>
        Degrading,

        /// <remarks/>
        Fluctuating,

        /// <remarks/>
        Improving,

        /// <remarks/>
        Stable,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("CategoryReportFlag", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public enum CategoryReportFlagDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Single Category")]
        SingleCategory,

        /// <remarks/>
        Use,

        /// <remarks/>
        Cause,

        /// <remarks/>
        Both,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateLocationDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateLocationDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string LocationID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(20)]
        public string LocationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string LocationName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateLocations", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateLocationsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateLocationDetails", Order = 0)]
        public StateLocationDetailsDataType[] StateLocationDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("ATLASes", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class ATLASesDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ATLASDetails", Order = 0)]
        public ATLASDetailsDataType[] ATLASDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("ATLASDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class ATLASDetailsDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string TopicID;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TopicOwner;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public decimal TopicSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TopicSizeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string TopicScale;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(40)]
        public string TopicSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string TopicCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string TopicName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(50)]
        public string TopicGroup;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(15)]
        public string TopicSizeUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 9)]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string TopicMajorFlag;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateIdentity", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateIdentityDataType
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
        public StateCodeListIdentifierDataType StateCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a principal administrative subdivision of the United Stat" +
            "es, Canada, or Mexico.")]
        public string StateName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2")]
    [System.Xml.Serialization.XmlRootAttribute("StateAssessmentDetails", Namespace = "http://www.exchangenetwork.net/schema/OWIR/ATT/2", IsNullable = false)]
    public partial class StateAssessmentDetailsDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentityDataType StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 1)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM: 
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string Cycle;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentUnitDetails", IsNullable = false)]
        public AssessmentUnitDetailsDataType[] AssessmentUnits;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UserCategoryDetails", IsNullable = false)]
        public UserCategoryDetailsDataType[] UserCategories;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateMethodDetails", IsNullable = false)]
        public StateMethodDetailsDataType[] StateMethods;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateLocationDetails", IsNullable = false)]
        public StateLocationDetailsDataType[] StateLocations;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ATLASDetails", IsNullable = false)]
        public ATLASDetailsDataType[] ATLASes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4000)]
        public string MercuryComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(250)]
        public string MercuryURL;
    }
}
