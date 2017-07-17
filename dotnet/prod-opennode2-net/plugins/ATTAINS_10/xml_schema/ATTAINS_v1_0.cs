namespace Windsor.Node2008.WNOSPlugin.ATTAINS_10
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AddressedPriority", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AddressedPriority
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for a priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PriorityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AddressedPriorities", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AddressedPrioritiesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AddressedPriority", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The TMDL or action addresses a state priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AddressedPriority[] AddressedPriority;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Source", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Source
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the source")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string SourceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the source")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SourceCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Sources", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class SourcesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Source", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detail information for Sources")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Source[] Source;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedPollutant", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedPollutant
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the pollutant")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string PollutantName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedPollutants", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedPollutantsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedPollutant", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Associated pollutant that addresses this cause (typically, but not exclusively re" +
            "lated to TMDLs)")]
        public AssociatedPollutant[] AssociatedPollutant;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLNPDES", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class TMDLNPDES
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Waste load allocation assigned to this Permittee")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public decimal WasteLoadAllocationNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unit of measure for waste load allocation")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string WasteLoadAllocationUnitsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("LegacyNPDESDetails", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class LegacyNPDESDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for a permit as assigned by the NPDES program")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string NPDESIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Other state identifier for a permit")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string OtherIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("TMDL releated NPDES data")]
        public TMDLNPDES TMDLNPDES;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("LegacyNPDES", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class LegacyNPDESDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LegacyNPDESDetails", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on a permit")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public LegacyNPDESDetails[] LegacyNPDESDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("SpecificWaterCause", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class SpecificWaterCause
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the cause")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string CauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssociatedPollutant", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of associated pollutants that address this cause (typically, but not exclus" +
            "ively related to TMDLs)")]
        public AssociatedPollutant[] AssociatedPollutants;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("LegacyNPDESDetails", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Legacy point source permits associated with this Action. Ignored on submission, f" +
            "or outbound services only.")]
        public LegacyNPDESDetails[] LegacyNPDES;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("SpecificWaterCauses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class SpecificWaterCausesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SpecificWaterCause", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Cause and its associated pollutants")]
        public SpecificWaterCause[] SpecificWaterCause;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("SpecificWater", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class SpecificWater
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the Assessment Unit by the reporting organization" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AssessmentUnitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the water is an unlisted water.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string UnlistedWaterIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SpecificWaterCause", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of causes and their associated pollutants")]
        public SpecificWaterCause[] SpecificWaterCauses;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Source", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Source types identified during the TMDL")]
        public Source[] Sources;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("SpecificWaters", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class SpecificWatersDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SpecificWater", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on related waters")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public SpecificWater[] SpecificWater;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideCause", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideCause
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of cause")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string StateWideCauseName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideCauses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideCausesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideCause", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Causes of impairment identified as part of the statewide assessment or Action")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideCause[] StateWideCause;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideSource", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of source")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string StateWideSourceName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideSources", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideSourcesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideSource", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Sources identified as part of the statewide Action")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideSource[] StateWideSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideAction", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the statewide assessment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string StateWideAssessmentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Cycle when the statewide assessment was made")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string StateWideCycle;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideCause", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of statewide causes")]
        public StateWideCause[] StateWideCauses;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideSource", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of statewide sources")]
        public StateWideSource[] StateWideSources;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the statewide assessment or action" +
            "")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string StateWideCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideActions", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideActionsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideAction", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed information for the statewide TMDL")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideAction[] StateWideAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedWaters", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedWaters
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideAction", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Actions that apply statewide (i.e. state wide TMDL)")]
        public StateWideAction[] StateWideActions;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SpecificWater", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on related waters")]
        public SpecificWater[] SpecificWaters;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Document", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Document
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier for the Document")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string DocumentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Type of document being provided")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string DocumentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The file extension of the document")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string DocumentFileType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("File of the document. Should be the file name of the document, including the exte" +
            "nsion (.doc, .pdf, etc.). The document must be included in a .zip file with this" +
            " name and included in the submission along with the XML file.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string DocumentFileName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Name of the document")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string DocumentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Description of the document")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string DocumentDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the document.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string DocumentComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Documents", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class DocumentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Document", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on a document")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Document[] Document;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("NPDESDetails", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class NPDESDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for a permit as assigned by the NPDES program")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string NPDESIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Other state identifier for a permit")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(60)]
        public string OtherIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("TMDL releated NPDES data")]
        public TMDLNPDES TMDLNPDES;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("NPDES", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class NPDESDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESDetails", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on a permit")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public NPDESDetails[] NPDESDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Season", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Season
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The month and day for the start of when the parameter was evaluated or when the A" +
            "ction applies (DD/MM)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string SeasonStartText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The month and day for the end of when the parameter was evaluated or when the Act" +
            "ion applies (DD/MM)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string SeasonEndText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Seasons", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class SeasonsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Season", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Season for when this parameter was evaluated or for when the Action applies. If i" +
            "t is year round, then don\'t include this data element")]
        public Season[] Season;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLPollutantDetails", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class TMDLPollutantDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Total load allocation for this pollutant")]
        public decimal TotalLoadAllocationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalLoadAllocationNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unit of measure for total load allocation")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string TotalLoadAllocationUnitsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Total waste load allocation for this pollutant")]
        public decimal TotalWasteLoadAllocationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalWasteLoadAllocationNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unit of measure for total waste load allocation")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string TotalWasteLoadAllocationUnitsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Explicit margin of safety for the load allocation")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string ExplicitMarginofSafetyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Implicit margin of safety for the load allocation")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string ImplicitMarginofSafetyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Free text describing the TMDL End Point")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string TMDLEndPointText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Pollutant", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Pollutant
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the pollutant")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string PollutantName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Are the sources of the pollutant point source, nonpoint source or both.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string PollutantSourceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("URL providing the link to find more information about the 4B activity.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string JustificationURLText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Pollutant details related to a TMDL")]
        public TMDLPollutantDetails TMDLPollutantDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Season", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of Seasons")]
        public Season[] Seasons;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("NPDESDetails", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Point source permits associated with this Action")]
        public NPDESDetails[] NPDES;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Pollutants", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PollutantsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Pollutant", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on a Pollutant")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Pollutant[] Pollutant;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ReviewComment", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ReviewComment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The actual comment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ReviewCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date the comment was made")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime ReviewCommentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The userName of the commenter")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ReviewCommentUserName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the organization. Identifiers would be managed ce" +
            "ntrally by EPA")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string OrganizationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ReviewComments", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ReviewCommentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReviewComment", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A single comment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ReviewComment[] ReviewComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("RelatedTMDLs", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class RelatedTMDLs
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the TMDL Report")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string TMDLReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Free text describing the relationship between the TMDLs")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string ChangeTypeText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLHistory", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class TMDLHistoryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RelatedTMDLs", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Other TMDLs that are related to this TMDL that this TMDL either revises or replac" +
            "es")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public RelatedTMDLs[] RelatedTMDLs;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("TMDLReportDetails", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class TMDLReportDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the TMDL Report")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string TMDLReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Alternative code identifying the TMDL Report (an example could be a state assigne" +
            "d identifier that is different from the ID in TMDLReportIdentifier)")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string TMDLOtherIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name of the TMDL")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string TMDLReportName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Date TMDL was established")]
        public System.DateTime TMDLDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TMDLDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the water is either wholly or partially in Indian country.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string IndianCountryIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("RelatedTMDLs", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Information on how this TMDL may relate to other TMDLs (i.e. replacing a revised " +
            "or withdrawn TMDL).")]
        public RelatedTMDLs[] TMDLHistory;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Action", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Action
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the action")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string ActionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the type of action being taken")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string ActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code indicating actions that EPA has taken on this Action, including the approval" +
            " of TMDLs")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string EPAActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Status of the Action (i.e. Final, Draft, Public Comment, etc.)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ActionStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date the action is planned to be completed")]
        public System.DateTime PlannedCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PlannedCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Completion date for the action")]
        public System.DateTime ActualCompletionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActualCompletionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Document", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Related Documents")]
        public Document[] Documents;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Waters associated with this activity")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssociatedWaters AssociatedWaters;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on a TMDL")]
        public TMDLReportDetails TMDLReportDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Pollutant", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Pollutants identified in this Action")]
        public Pollutant[] Pollutants;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AddressedPriority", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of addressed priorities")]
        public AddressedPriority[] AddressedPriorities;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Free text providing additional comments on the action")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ActionComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 13)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReviewComment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Comments by the reviewer")]
        public ReviewComment[] ReviewComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Actions", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ActionsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Action", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed Information on an action")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Action[] Action;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Location", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Location
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Context for the LocationTypeCode (typically OrganizationIdentifier)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string LocationTypeContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Description of the type of location (i.e. 8-digit HUC, County, etc.)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string LocationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Value for the location")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string LocationText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Locations", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class LocationsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Location", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Reported values for additional location information")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Location[] Location;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PreviousAssessmentUnit", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PreviousAssessmentUnit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the Assessment Unit by the reporting organization" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AssessmentUnitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PreviousAssessmentUnits", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PreviousAssessmentUnitsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PreviousAssessmentUnit", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Other Assessment Units that have been defined in prior cycles that are related to" +
            " this Assessment Unit (i.e. a split of an Assessment Unit)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PreviousAssessmentUnit[] PreviousAssessmentUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Modification", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Modification
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code representing the type of modification that was made.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string ModificationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("First Assessment Cycle when then change occurred")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string ChangeCycleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Text describing the change made to the Assessment Unit")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string ChangeDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PreviousAssessmentUnit", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of previous Assessment Units")]
        public PreviousAssessmentUnit[] PreviousAssessmentUnits;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Modifications", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ModificationsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Modification", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Type of modification that was made")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Modification[] Modification;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringStation", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class MonitoringStation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Organization that conducted the monitoring. For data that is available via STORET" +
            "/WQX or the Water Quality portal, this Organization ID is a unique ID assigned b" +
            "y EPA, or other agency responsible for assigning organizations.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string MonitoringOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for the monitoring location")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(35)]
        public string MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("URL providing the link to the monitoring data for this station. For Water Quality" +
            " Portal data, this link should be the Restful URL that would provide access to t" +
            "he data.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string MonitoringDataLinkText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringStations", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class MonitoringStationsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoringStation", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Monitoring station descriptions")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public MonitoringStation[] MonitoringStation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("UseClass", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class UseClass
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Context for the class code (typically OrganizationIdentifier)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string UseClassContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the use class for this water")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string UseClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("name of the use class for this water")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string UseClassName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("WaterType", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class WaterType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code representing the water type")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string WaterTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Size for this particular water type")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public decimal WaterSizeNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code representing the unit of measure")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string UnitsCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code representing the method used for determining the water size")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string SizeEstimationMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Text describing the source used for estimating the water size.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(100)]
        public string SizeSourceText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Text describing the scale of the source material used for estimating the water si" +
            "ze (i.e. 1:24000)")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SizeSourceScaleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("WaterTypes", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class WaterTypesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WaterType", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Water type for the Assessment Unit")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public WaterType[] WaterType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnit", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentUnit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the Assessment Unit by the reporting organization" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AssessmentUnitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Name of Assessment Unit (i.e. GNIS Name)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string AssessmentUnitName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Text description of the Assessment Unit location (describes the extent of the Ass" +
            "essment Unit)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string LocationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Geographic state within which the Assessment Unit is contained")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicator of whether the Assessment Unit is currently active, or if the identifie" +
            "r has been retired and is being kept for historical tracking purposes and is par" +
            "t of an Assessment Unit History of another Assessment Unit.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string StatusIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("WaterType", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Water types wrapper")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public WaterType[] WaterTypes;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Location", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Additional Location Information")]
        public Location[] Locations;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("MonitoringStation", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Monitoring stations as defined in STORET/WQX, the Water Quality Portal, or other " +
            "system that is available online that are associated with this Assessment Unit")]
        public MonitoringStation[] MonitoringStations;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Use class for this Assessment Unit as defined in the organization\'s water quality" +
            " standards")]
        public UseClass UseClass;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Modification", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Information on changes that have been made to this Assessment Unit over time")]
        public Modification[] Modifications;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Document", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Related Documents")]
        public Document[] Documents;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Text to provide a comment on a specific Assessment Unit")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string AssessmentUnitCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentUnits", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentUnitsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentUnit", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Individual Assessment Unit defined by the organization")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssessmentUnit[] AssessmentUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class MailingAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Mailing Address")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Additional Address Information")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("City or Locality Name")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("State USPS Code (i.e. KS)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string MailingAddressStateUSPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Country Name")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2)]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Zip Code")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(14)]
        public string MailingAddressZIPCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationContact", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class OrganizationContact
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Area of responsibility for this contact (TMDL Program, 303(d) Program, Monitoring" +
            ", Assessment, NPS)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(35)]
        public string ContactType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Organization web link for more information")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string WebURLText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name of the suborganzation who has responsibilty for this area")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string SubOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Email address for requesting additional information")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string EmailAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("First name of a person.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Middle Initial of a person.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string MiddleInitial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Last name of a person.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Title of the contact person.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Telephone Number data")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Telephone number extension")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(6)]
        public string PhoneExtensionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Fax Number")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(15)]
        public string FaxNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Mailing address information")]
        public MailingAddress MailingAddress;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationContacts", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class OrganizationContactsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationContact", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Individual Organization Contact Information: who should be contacted for more inf" +
            "ormation.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public OrganizationContact[] OrganizationContact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorityAssessmentUnit", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorityAssessmentUnit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the Assessment Unit by the reporting organization" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AssessmentUnitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorityAssessmentUnits", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorityAssessmentUnitsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PriorityAssessmentUnit", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Assessment Unit associated with this priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PriorityAssessmentUnit[] PriorityAssessmentUnit;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorityCause", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorityCause
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the cause")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string CauseName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorityCauses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorityCausesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PriorityCause", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Cause associated with this priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PriorityCause[] PriorityCause;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorityUse", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorityUse
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the designated use.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string UseName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorityUses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorityUsesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PriorityUse", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Use associated with this priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PriorityUse[] PriorityUse;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Priority", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Priority
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Status of the Prority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string PriorityStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Date the status was changed")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public System.DateTime PriorityStatusDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for a priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string PriorityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Name for the priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string PriorityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Cycle that is the baseline for the priority (starting cycle)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CycleBaseLine;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Cycle that is the goal for the priority (ending cycle)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CycleGoal;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the type of priority that is being set")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string PriorityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Description of the priority")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(2000)]
        public string PriorityDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Location", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Additional Location Information")]
        public Location[] Locations;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PriorityUse", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of priority uses")]
        public PriorityUse[] PriorityUses;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PriorityCause", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of priority causes")]
        public PriorityCause[] PriorityCauses;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PriorityAssessmentUnit", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of priority assessment units")]
        public PriorityAssessmentUnit[] PriorityAssessmentUnits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Free text providing additional comments on the priority")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string PriorityCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Priorities", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PrioritiesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Priority", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed information on the priorities")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Priority[] Priority;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedAction", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedAction
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the Action that corresponds to this cause.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string AssociatedActionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedActions", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedActionsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedAction", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Information about the actions that have been developed to address this parameter." +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssociatedAction[] AssociatedAction;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedUse", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedUse
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the designated use.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string AssociatedUseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the attainment status for this parameter for this specific use.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ParameterAttainmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code representing the water quality trend for this use or parameter.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string TrendCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Season", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of Seasons")]
        public Season[] Seasons;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedUses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedUsesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedUse", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Designated uses that are related to this cause or observed effect.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssociatedUse[] AssociatedUse;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Category4BInformation", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Category4BInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Cycle by which the Assessment Unit is expected to attain its standards (used to i" +
            "ndicate whether or not this cause should be considered towards category 4B)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CycleExpectedToAttainText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ListingInformation", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ListingInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Flag indicating whether or not the cause is a pollutant")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string PollutantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Cycle the Assessment Unit was first listed for this cause")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CycleFirstListedText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Cycle when the jurisdiction anticipates submitting the TMDL for EPA approval")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CycleScheduledForTMDLText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("CWA 303(d) priority for developing a TMDL (i.e. High, Medium, Low)")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string CWA303dPriorityRankingText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Cycle for which Consent Decree actions are due")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string ConsentDecreeCycleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier for the listed water. Use this identifier ONLY if the listing i" +
            "dentifier is different from the Assessment Unit Identifier")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AlternateListingIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorCause", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorCause
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Prior name for the cause for this Assessment Unit")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string PriorCauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Cycle for the prior cause that is being replaced with or related to the cause.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string PriorCauseCycleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("PriorCauses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class PriorCausesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PriorCause", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Changes in the cause names for this Assessment Unit. For example, the listed caus" +
            "e in a prior cycle was Cause Unknown, and after further analysis it was determin" +
            "ed that the actual cause is Cadmium, so the listing is being changed.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public PriorCause[] PriorCause;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ImpairedWatersInformation", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ImpairedWatersInformation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Information related to the cause if it is part of a 303(d) list")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ListingInformation ListingInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Information related to placing this water in Category 4B")]
        public Category4BInformation Category4BInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PriorCause", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of Changes in the cause names")]
        public PriorCause[] PriorCauses;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateIntegratedReportingCategory", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateIntegratedReportingCategory
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("State Integrated Reporting Category")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(5)]
        public string StateIRCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Description of the State IR Category")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string StateCategoryDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Parameter", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Parameter
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Status for the parameter indicating whether this parameter is a cause, observed e" +
            "ffect, or provided for informational purposes as a monitored parameter.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ParameterStatusName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Name of the parameter")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string ParameterName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Free text providing additional comments for the parameter")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string ParameterCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssociatedUse", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of associated uses")]
        public AssociatedUse[] AssociatedUses;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Information related to the cause")]
        public ImpairedWatersInformation ImpairedWatersInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("State Integrated Reporting Category for this Assessment Unit")]
        public StateIntegratedReportingCategory StateIntegratedReportingCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssociatedAction", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Corresponding actions that have been developed to address this parameter.")]
        public AssociatedAction[] AssociatedActions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Parameters", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ParametersDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed information about an individual parameter")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Parameter[] Parameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedCauseName", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedCauseName
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the cause")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string CauseName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssociatedCauseNames", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssociatedCauseNamesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociatedCauseName", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Causes that are related to this source")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssociatedCauseName[] AssociatedCauseName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ProbableSource", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ProbableSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the source")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string SourceName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicator of whether the source has been confirmed")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string SourceConfirmedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssociatedCauseName", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of AssociatedCauseNames")]
        public AssociatedCauseName[] AssociatedCauseNames;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the source")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string SourceCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ProbableSources", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ProbableSourcesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProbableSource", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detail information for Sources")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public ProbableSource[] ProbableSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentActivity", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentActivity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Day on which the assessment was completed")]
        public System.DateTime AssessmentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AssessmentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Name of the individual performing the assessment")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(80)]
        public string AssessorName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentMethodType", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentMethodType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Context for the MethodTypeName")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string MethodTypeContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code for the Assesment Method")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(20)]
        public string MethodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name of the method used")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string MethodTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentMethodTypes", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentMethodTypesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentMethodType", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Methods used for the assessment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssessmentMethodType[] AssessmentMethodType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentType", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code representing the type of assessment that was performed.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string AssessmentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the confidence in the AssessmentType")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string AssessmentConfidenceCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentTypes", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentTypesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssessmentType", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Type of assessment that was performed")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public AssessmentType[] AssessmentType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringActivity", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class MonitoringActivity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Date on which monitoring began")]
        public System.DateTime MonitoringStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MonitoringStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Date on which monitoring ended")]
        public System.DateTime MonitoringEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MonitoringEndDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("AssessmentMetadata", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentMetadata
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code representing the basis for the assessment; is it based on monitored data, ex" +
            "trapolated data, or both.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string AssessmentBasisCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentType", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of AssessmentTypes")]
        public AssessmentType[] AssessmentTypes;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentMethodType", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of AssessmentMethods")]
        public AssessmentMethodType[] AssessmentMethodTypes;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Additional information related to the monitoring conducted for this assessment un" +
            "it and use, which can include the start date and end date of when the water was " +
            "monitored")]
        public MonitoringActivity MonitoringActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Additional information related to the assessment for this assessment unit and use" +
            ", which can include the assessment date, the assessor, and additional parameters" +
            " that were assessed that were not found to be causes of impairment.")]
        public AssessmentActivity AssessmentActivity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("UseAttainment", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class UseAttainment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the designated use.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string UseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the use attainment for this use")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string UseAttainmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicator identifying whether or not the use is threatened. If this code is set t" +
            "o \'Y\' AttainmentCode should typically be \'Fully Supporting\'. Not reporting this " +
            "data element is equivelent to saying ThreantenedIndicator=\'N\'.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string ThreatenedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code representing the water quality trend for this use or parameter.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string TrendCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("State Integrated Reporting Category for this Assessment Unit")]
        public StateIntegratedReportingCategory StateIntegratedReportingCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Metadata associated with the assessment")]
        public AssessmentMetadata AssessmentMetadata;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the use assessment")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string UseCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("UseAttainments", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class UseAttainmentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UseAttainment", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Individual designated use with use attainment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public UseAttainment[] UseAttainment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Assessment", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Assessment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the Assessment Unit by the reporting organization" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AssessmentUnitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Cycle this Assessment Unit was last assessed, which can include any conclusions r" +
            "elated to this Assessment Unit and can include delisting decisions.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string CycleLastAssessedText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Cycle this Assessment Unit was last monitored")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string YearLastMonitoredText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code representing the trophic status for the Assessment Unit")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string TrophicStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("State Integrated Reporting Category for this Assessment Unit")]
        public StateIntegratedReportingCategory StateIntegratedReportingCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UseAttainment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Designated uses and attainment associated with this assessment.")]
        public UseAttainment[] UseAttainments;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Parameter", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Parameters Assessed for this Assessment Unit")]
        public Parameter[] Parameters;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 8)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ProbableSource", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Probable sources of impairment")]
        public ProbableSource[] ProbableSources;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Document", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Related Documents")]
        public Document[] Documents;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the assessment.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string AssessmentCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 11)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReviewComment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Comments by the reviewer")]
        public ReviewComment[] ReviewComments;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Rationale for the assessment conclusion. This text will be avaialble for the publ" +
            "ic.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string RationaleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Assessments", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class AssessmentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Assessment", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Assessment Information for individual assessment units")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Assessment[] Assessment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("DelistedWaterCause", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class DelistedWaterCause
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the cause")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string CauseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Reason the waterbody/cause is being delisted")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(10)]
        public string DelistingReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the delisting")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string DelistingCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("DelistedWaterCauses", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class DelistedWaterCausesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DelistedWaterCause", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detail information for Causes")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public DelistedWaterCause[] DelistedWaterCause;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("DelistedWater", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class DelistedWater
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the Assessment Unit by the reporting organization" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(50)]
        public string AssessmentUnitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DelistedWaterCause", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of Causes")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public DelistedWaterCause[] DelistedWaterCauses;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("DelistedWaters", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class DelistedWatersDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DelistedWater", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Assessment units that have been delisted in this cycle.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public DelistedWater[] DelistedWater;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideProbableSource", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideProbableSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of probable source")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(240)]
        public string StateWideProbableSourceName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideProbableSources", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideProbableSourcesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideProbableSource", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Probable sources identified as part of the statewide assessment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideProbableSource[] StateWideProbableSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideUseAttainment", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideUseAttainment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the designated use.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string StateWideUseName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the use attainment for this use")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string UseAttainmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicator identifying whether or not the use is threatened. If this code is set t" +
            "o \'Y\' AttainmentCode should typically be \'Fully Supporting\'. Not reporting this " +
            "data element is equivelent to saying ThreantenedIndicator=\'N\'.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string ThreatenedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code representing the water quality trend for this use or parameter.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(25)]
        public string TrendCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal)" +
            "")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(1)]
        public string AgencyCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideUseAttainments", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideUseAttainmentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideUseAttainment", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Individual designated use with use attainment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideUseAttainment[] StateWideUseAttainment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideWaterType", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideWaterType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code representing the water type")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(40)]
        public string StateWideWaterTypeCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideWaterTypes", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideWaterTypesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideWaterType", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Water types for the statewide assessment unit")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideWaterType[] StateWideWaterType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideAssessment", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideAssessment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Common name that this statewide assessment is referred by.")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(255)]
        public string StateWideAssessmentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique code identifying the statewide assessment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(45)]
        public string StateWideAssessmentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideWaterType", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of water types")]
        public StateWideWaterType[] StateWideWaterTypes;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideUseAttainment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Designated uses and attainment associated with this assessment.")]
        public StateWideUseAttainment[] StateWideUseAttainments;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideCause", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of statewide causes")]
        public StateWideCause[] StateWideCauses;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideProbableSource", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of probable sources")]
        public StateWideProbableSource[] StateWideProbableSources;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Free text for providing additional comments on the statewide assessment or action" +
            "")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4000)]
        public string StateWideCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReviewComment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Comments by the reviewer")]
        public ReviewComment[] ReviewComments;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("StateWideAssessments", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class StateWideAssessmentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StateWideAssessment", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Detailed information for the statewide assessment")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public StateWideAssessment[] StateWideAssessment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportingCycle", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ReportingCycle
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Reporting cycle for the Assessments")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(4)]
        public string ReportingCycleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Status of the report or 303(d) list (i.e. Final, Draft, Public Comment, etc.)")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string ReportStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Document", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Related Documents")]
        public Document[] Documents;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Assessment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("All assessment conlcusions for the Integrated Report, including new assessments a" +
            "nd assessments conducted in prior cycles that have not been updated, but still a" +
            "pply to this cycle\'s IR")]
        public Assessment[] Assessments;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("StateWideAssessment", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Assessments that apply statewide (i.e. Fish Consumption Advisory)")]
        public StateWideAssessment[] StateWideAssessments;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DelistedWater", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Delistings for this cycle")]
        public DelistedWater[] DelistedWaters;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("Organization", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class Organization
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique identifier assigned to the organization. Identifiers would be managed ce" +
            "ntrally by EPA")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Name corresponding to unique organization ID (i.e. Utah Division of Water Quality" +
            "); org name will be ignored on submission, for outbound services only")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(150)]
        public string OrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("State/tribe/territory; org name will be ignored on submission, for outbound servi" +
            "ces only")]
        [Windsor.Commons.XsdOrm2.DbMaxColumnSizeAttribute(30)]
        public string OrganizationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("OrganizationContact", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of Organization Contact Information")]
        public OrganizationContact[] OrganizationContacts;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 4)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AssessmentUnit", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Group of Assessment Units defined by the organization")]
        public AssessmentUnit[] AssessmentUnits;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingCycle", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Water Quality Assessments for a particular cycle")]
        public ReportingCycle[] ReportingCycle;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Action", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Actions taken to restore or protect water quality")]
        public Action[] Actions;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Priority", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("Identification of state\'s priorities")]
        public Priority[] Priorities;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/IR/0")]
    [System.Xml.Serialization.XmlRootAttribute("ATTAINS", Namespace = "http://www.exchangenetwork.net/schema/IR/0", IsNullable = false)]
    public partial class ATTAINSDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Organization", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Organization responsible for the data reported.")]
        [Windsor.Commons.XsdOrm2.DbNotNullAttribute()]
        public Organization[] Organization;
    }
}
