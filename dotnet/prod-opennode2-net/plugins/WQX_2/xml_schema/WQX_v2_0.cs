namespace Windsor.Node2008.WNOSPlugin.WQX2XsdOrm
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class OrganizationDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a unique business establishment within a c" +
            "ontext.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The legal designator (i.e. formal name) of an organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Information that further describes an organization.")]
        public string OrganizationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian tribe or Alaskan Native entity.")]
        public string TribalCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddress", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ElectronicAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A resource address, usually consisting of the access protocol, the domain name, a" +
            "nd optionally, the path to a file or location.")]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the electronic address type.")]
        public string ElectronicAddressTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("Telephonic", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class TelephonicDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationAddress", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class OrganizationAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Categorizes an address as either location, shipping, or mailing address.")]
        public string AddressTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic), shipping, or mailing locati" +
            "on of an organization.")]
        public string AddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about an address, including a build" +
            "ing name with its secondary unit and number, an industrial park name, an install" +
            "ation name or descriptive text where no formal address is available.")]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name of a city, town, village or other locality.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a principal administrative subdivision of the " +
            "United States, Canada, or Mexico.")]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public string PostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string CountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a U.S. county or county equivalent.")]
        public string CountyCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("AttachedBinaryObject", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class AttachedBinaryObjectDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The text describing the descriptive name used to represent the file, including fi" +
            "le extension.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BinaryObjectFileName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text or acronym describing the binary content type of a file.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BinaryObjectFileTypeCode;

        //TSM:
        [System.Xml.Serialization.XmlIgnore]
        public byte[] BinaryContent;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureCompact", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class MeasureCompactDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The recorded dimension, capacity, quality, or amount of something ascertained by " +
            "measuring or observing.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MeasureUnitCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("BibliographicReference", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class BibliographicReferenceDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A name given to the resource.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ResourceTitleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An entity primarily responible for making the content of the resource.")]
        public string ResourceCreatorName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A topic of the content of the resource.")]
        public string ResourceSubjectText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An entity responsible for making the resource available.")]
        public string ResourcePublisherName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A date of an event in the lifecycle of the resource.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ResourceDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("An unambiguous reference to the resource within a given context.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ResourceIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ProjectMonitoringLocationWeighting", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ProjectMonitoringLocationWeightingDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the monitoring location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the monitoring location selection weighting factor.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MeasureCompactDataType LocationWeightingFactorMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the statistical stratum applied to this site.")]
        public string StatisticalStratumText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Free text describing a category of naturally similar site types, such as high-gra" +
            "dient.")]
        public string LocationCategoryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether this site is active and available for sampling.")]
        public string LocationStatusName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Identifies whether this site is a reference or control site by specifying the ref" +
            "erence location type.")]
        public string ReferenceLocationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the monitoring location started being used as a refere" +
            "nce site.")]
        public System.DateTime ReferenceLocationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferenceLocationStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the monitoring location stopped being used as a refere" +
            "nce site.")]
        public System.DateTime ReferenceLocationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferenceLocationEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Identifes the source that created or defined the Reference Location.")]
        public BibliographicReferenceDataType ReferenceLocationCitation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments.")]
        public string CommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("Project", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ProjectDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a data collection project within a context" +
            " of an organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name assigned by the Organization (project leader or principal investigator) " +
            "to the project.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProjectName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Project description, which may include a description of the project purpose, summ" +
            "ary of the objectives, or brief summary of the results of the project.")]
        public string ProjectDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify the type of sampling design employed for this project to " +
            "ensure that sampling activities can support project objectives.")]
        public string SamplingDesignTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether a Quality Assurance Project Plan (QAPP) has been approved for t" +
            "he submitted project.")]
        public bool QAPPApprovedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QAPPApprovedIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("An outside approval authority identifier for the QAPP (e.g. EPA or State Organiza" +
            "tion).")]
        public string QAPPApprovalAgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public ProjectAttachedBinaryObjectDataType[] AttachedBinaryObject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectMonitoringLocationWeighting", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Describes the probability weighting information for a given Project / Monitoring " +
            "Location Assignment.")]
        public ProjectMonitoringLocationWeightingDataType[] ProjectMonitoringLocationWeighting;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("AlternateMonitoringLocationIdentity", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class AlternateMonitoringLocationIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the monitoring location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the source or data system that created or defined the monitoring locat" +
            "ion identifier.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationIdentifierContext;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentity", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class MonitoringLocationIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the monitoring location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The designator specified by the sampling organization for the site at which sampl" +
            "ing or other activities are conducted.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The descriptive name for a type of monitoring location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Text description of the monitoring location.")]
        public string MonitoringLocationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The 8 digit federal code used to identify the hydrologic unit of the monitoring l" +
            "ocation to the cataloging unit level of precision.")]
        public string HUCEightDigitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The 12 digit federal code used to identify the hydrologic unit of the monitoring " +
            "location to the subwatershed level of precision.")]
        public string HUCTwelveDigitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("An indicator denoting whether the location is on a tribal land.")]
        public bool TribalLandIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TribalLandIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name of an American Indian or Alaskan native area where the location exists.")]
        public string TribalLandName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AlternateMonitoringLocationIdentity", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Alternate identifications of a monitoring location.")]
        public AlternateMonitoringLocationIdentityDataType[] AlternateMonitoringLocationIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationGeospatial", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class MonitoringLocationGeospatialDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The horizontal measure of the relative accuracy of the latitude and longitude coo" +
            "rdinates.")]
        public MeasureCompactDataType HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the method used to determine the latitude and longitude " +
            "coordinates for a point on the earth.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the reference datum used in determining latitude and long" +
            "itude coordinates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCoordinateReferenceSystemDatumName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The measure of elevation (i.e., the altitude), above or below a reference datum.")]
        public MeasureCompactDataType VerticalMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the method used to collect the vertical measure (i.e. th" +
            "e altitude) of a reference point.")]
        public string VerticalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name of the reference datum used to determine the vertical measure (i.e., the" +
            " altitude).")]
        public string VerticalCoordinateReferenceSystemDatumName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string CountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a principal administrative subdivision of the " +
            "United States, Canada, or Mexico.")]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a U.S. county or county equivalent.")]
        public string CountyCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellInformation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WellInformationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies the primary well type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Name of the aquifer in which the well is completed.")]
        public string AquiferName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name of the primary formation or soils unit, in which the well is completed.")]
        public string FormationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Depth below land surface datum (LSD) to the bottom of the hole on completion of d" +
            "rilling.")]
        public MeasureCompactDataType WellHoleDepthMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class MonitoringLocationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Basic identification information for the location/site that is monitored or used " +
            "for sampling.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MonitoringLocationIdentityDataType MonitoringLocationIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Monitoring location geographic location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MonitoringLocationGeospatialDataType MonitoringLocationGeospatial;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Description of the attributes of a well.")]
        public WellInformationDataType WellInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public MonitoringLocationAttachedBinaryObjectDataType[] AttachedBinaryObject;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXTime", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXTimeDataType
    {

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "time", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The time of day that is reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public System.DateTime Time;
        public string Time;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The time zone for which the time of day is reported. Any of the longitudinal divi" +
            "sions of the earth\'s surface in which a standard time is kept.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TimeZoneCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ActivityDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Designator that uniquely identifies an activity within an organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text describing the type of activity.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name or code indicating the environmental medium where the sample was taken.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityMediaName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Name or code indicating the environmental matrix as a subdivision of the sample m" +
            "edia.")]
        public string ActivityMediaSubdivisionName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the field activity was started.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ActivityStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The measure of clock time when the field activity began.")]
        public WQXTimeDataType ActivityStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when the field activity was completed.")]
        public System.DateTime ActivityEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActivityEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The measure of clock time when the field activity ended.")]
        public WQXTimeDataType ActivityEndTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name that indicates the approximate location within the water column at which" +
            " the activity occurred. ")]
        public string ActivityRelativeDepthName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the vertical location (measured from a reference point) at which" +
            " an activity occurred.")]
        public MeasureCompactDataType ActivityDepthHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the upper vertical location of a vertical location range (measur" +
            "ed from a reference point) at which an activity occurred.")]
        public MeasureCompactDataType ActivityTopDepthHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the lower vertical location of a vertical location range (measur" +
            "ed from a reference point) at which an activity occurred.")]
        public MeasureCompactDataType ActivityBottomDepthHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The reference used to indicate the datum or reference used to establish the depth" +
            "/altitude of an activity.")]
        public string ActivityDepthAltitudeReferencePointText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectIdentifier", Order = 13)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a data collection project within a context" +
            " of an organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string[] ProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityConductingOrganizationText", Order = 14)]
        [System.ComponentModel.DescriptionAttribute("A name of the Organization conducting an activity.")]
        public string[] ActivityConductingOrganizationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the monitoring location.")]
        public string MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("General comments concerning the activity.")]
        public string ActivityCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityLocation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ActivityLocationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The horizontal measure of the relative accuracy of the latitude and longitude coo" +
            "rdinates.")]
        public MeasureCompactDataType HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the method used to determine the latitude and longitude " +
            "coordinates for a point on the earth.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the reference datum used in determining latitude and long" +
            "itude coordinates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCoordinateReferenceSystemDatumName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("NetInformation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class NetInformationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The text describing the type of net.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string NetTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the effective surface area of the net used during biological mon" +
            "itoring sample collection.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MeasureCompactDataType NetSurfaceAreaMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the mesh size of the net used during biological monitoring sampl" +
            "e collection.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MeasureCompactDataType NetMeshSizeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the boat speed during biological monitoring sample collection.")]
        public MeasureCompactDataType BoatSpeedMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the current during biological monitoring sample collection.")]
        public MeasureCompactDataType CurrentSpeedMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalHabitatCollectionInformation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class BiologicalHabitatCollectionInformationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The length of time a collection procedure or protocol was performed (e.g. total e" +
            "nergized time for electrofishing, or total time kick net used).")]
        public MeasureCompactDataType CollectionDuration;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Single entity within a sampling frame at which a collection procedure or protocol" +
            " was performed (e.g. transect, plot point).")]
        public string SamplingComponentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The order in which a component within the sampling frame was visited in relation " +
            "to other components.")]
        public string SamplingComponentPlaceInSeriesNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the water body length distance in which the procedure or protoco" +
            "l was performed.")]
        public MeasureCompactDataType ReachLengthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the reach width during collection procedures.")]
        public MeasureCompactDataType ReachWidthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The number of passes through the water from which the sample was collected.")]
        public string PassCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Allows for the reporting of net sample collection information.")]
        public NetInformationDataType NetInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalActivityDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class BiologicalActivityDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An association of interacting populations of organisms in a given waterbody.")]
        public string AssemblageSampledName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Allows for the reporting of biological habitat sample collection information.")]
        public BiologicalHabitatCollectionInformationDataType BiologicalHabitatCollectionInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the type of toxicity as either Acute or Chronic.")]
        public string ToxicityTestType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ReferenceMethod", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ReferenceMethodDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MethodIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the source or data system that created or defined the identifier.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MethodIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The title that appears on the method from the method publisher.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifier of type of method that identifies it as reference, equivalent, or othe" +
            "r.")]
        public string MethodQualifierTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A brief summary that provides general information about the method.")]
        public string MethodDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("SamplePreparation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class SamplePreparationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifying information about the method(s) followed to prepare a sample for anal" +
            "ysis.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ReferenceMethodDataType SamplePreparationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text describing the sample container type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleContainerTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text describing the sample container color.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleContainerColorName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Information describing the chemical means to preserve the sample.")]
        public string ChemicalPreservativeUsedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Information describing the temperature means used to preserve the sample.")]
        public string ThermalPreservativeUsedName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The text describing sample handling and transport procedures used.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleTransportStorageDescription;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("SampleDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class SampleDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute(@"Identifies sample collection or measurement method procedures. Where a documented sample collection method has been employed, this enables the data provider to indicate the documented method that was employed during the field sample collection. Otherwise, the sample collection procedure will best be described in a freeform text.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ReferenceMethodDataType SampleCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name for the equipment used in collecting the sample.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleCollectionEquipmentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments further describing the sample collection equipmen" +
            "t.")]
        public string SampleCollectionEquipmentCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Describes a sample preparation procedure which may be conducted on an initial Sam" +
            "ple or on subsequent subsamples.")]
        public SamplePreparationDataType SamplePreparation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityMetricType", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ActivityMetricTypeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the metric (Organization specific).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MetricTypeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the source or data system that created or defined the metric.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MetricTypeIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name of the activity metric.")]
        public string MetricTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Provides additional description of the source that created or defined the metric." +
            "")]
        public BibliographicReferenceDataType MetricTypeCitation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Provides a description of the scale used for the activity metric.")]
        public string MetricTypeScaleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Provides a description of the formula used to calculate the activity metric score" +
            ".")]
        public string FormulaDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityMetric", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ActivityMetricDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This section identifies the metric type reported as part of an activity metric.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityMetricTypeDataType ActivityMetricType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A non-scaled value calculated from raw results that may be scaled into a metric s" +
            "core.")]
        public MeasureCompactDataType MetricValueMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Provides the scaled or calculated score for the activity metric.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MetricScoreNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments concerning the metric.")]
        public string MetricCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndexIdentifier", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A unique designator used to identify a unique index record that the activity metr" +
            "ic is associated with.")]
        //TSM:
        //public string[] IndexIdentifier;
        public string IndexIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("Measure", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class MeasureDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The reportable measure of the result for the chemical, microbiological or other c" +
            "haracteristic being analyzed.")]
        public string ResultMeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        public string MeasureUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the results.")]
        public string MeasureQualifierCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("DataQuality", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class DataQualityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A measure of mutual agreement among individual measurements of the same property " +
            "usually under prescribed similar conditions.")]
        public string PrecisionValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The systematic or persistent distortion of a measurement process which causes err" +
            "or in one direction.")]
        public string BiasValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A range of values constructed so that this range has a specified probability of i" +
            "ncluding the true population mean.")]
        public string ConfidenceIntervalValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Value of the upper end of the confidence interval.")]
        public string UpperConfidenceLimitValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Value of the lower end of the confidence interval.")]
        public string LowerConfidenceLimitValue;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ResultDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ResultDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique line identifier from a data logger result text file, normally a date/t" +
            "ime format but could be any user defined name, e.g. \"surface\", \"midwinter\", and " +
            "or \"bottom\".)")]
        public string DataLoggerLineName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The textual descriptor of a result.")]
        public string ResultDetectionConditionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The object, property, or substance which is evaluated or enumerated by either a d" +
            "irect field measurement, a direct field observation, or by laboratory analysis o" +
            "f material collected in the field.")]
        public string CharacteristicName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies the chemical speciation in which the measured result is expressed.")]
        public string MethodSpeciationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The text name of the portion of the sample associated with results obtained from " +
            "a physically-partitioned sample.")]
        public string ResultSampleFractionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The reportable measure of the result for the chemical, microbiological or other c" +
            "haracteristic being analyzed.")]
        public MeasureDataType ResultMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Indicates the acceptability of the result with respect to QA/QC criteria.")]
        public string ResultStatusIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The code for the method used to calculate derived results.")]
        public string StatisticalBaseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A name that qualifies the process which was used in the determination of the resu" +
            "lt value (e.g., actual, estimated, calculated).")]
        public string ResultValueTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The name that represents the form of the sample or portion of the sample which is" +
            " associated with the result value (e.g., wet weight, dry weight, ash-free dry we" +
            "ight).")]
        public string ResultWeightBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The period of time (in days) over which a measurement was made. For example, BOD " +
            "can be measured as 5 day or 20 day BOD.")]
        public string ResultTimeBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The name that represents the controlled temperature at which the sample was maint" +
            "ained during analysis, e.g. 25 deg BOD analysis.")]
        public string ResultTemperatureBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("User defined free text describing the particle size class for which the associate" +
            "d result is defined.")]
        public string ResultParticleSizeBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The quantitative statistics and qualitative descriptors that are used to interpre" +
            "t the degree of acceptability or utility of data to the user.")]
        public DataQualityDataType DataQuality;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments concerning the result.")]
        public string ResultCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the vertical location (measured from a reference point) at which" +
            " a result is obtained.")]
        public MeasureCompactDataType ResultDepthHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The reference used to indicate the datum or reference used to establish the depth" +
            "/altitude of a result.")]
        public string ResultDepthAltitudeReferencePointText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Single point name within a sampling frame or protocol that is associated with the" +
            " reported result.")]
        public string ResultSamplingPointName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("TaxonomicDetails", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class TaxonomicDetailsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the cell form for phytoplankton organisms expressed as a result. A si" +
            "ngle phytoplankton species may have a result value for any or all of these cell " +
            "forms.")]
        public string CellFormName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The cell shape of the phytoplankton organism.")]
        public string CellShapeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HabitName", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The position that the characteristic occupies in a food chain.")]
        //TSM:
        [Windsor.Commons.XsdOrm.DbIgnore]
        public string[] HabitName;

        //TSM:
        [System.Xml.Serialization.XmlIgnore]
        public string HabitNameDBValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The number of broods or generations of the characteristic in a year.")]
        public string VoltinismName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("For entries representing taxa, a code representing the ability of the reported ta" +
            "xon to tolerate pollution.")]
        public string TaxonomicPollutionTolerance;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Provides a description of the scale used for the taxonomic pollution tolerance va" +
            "lue.")]
        public string TaxonomicPollutionToleranceScaleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("For entries representing taxa, a code representing the trophic level with which t" +
            "he reported taxon is typically assigned.")]
        public string TrophicLevelName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FunctionalFeedingGroupName", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("For entries representing taxa, a code representing the functional feeding group w" +
            "ith which the reported taxon is typically associated.")]
        //TSM:
        [Windsor.Commons.XsdOrm.DbIgnore]
        public string[] FunctionalFeedingGroupName;

        //TSM:
        [System.Xml.Serialization.XmlIgnore]
        public string FunctionalFeedingGroupNameDBValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Identifes the source that created or defined the Taxonomic Details.")]
        public BibliographicReferenceDataType TaxonomicDetailsCitation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("FrequencyClassInformation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class FrequencyClassInformationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code that describes the frequency class, either as a life stage, abnormality, g" +
            "ender, or measurable characteristic (i.e. length, weight) used to categorize a b" +
            "iological population count.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FrequencyClassDescriptorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        public string FrequencyClassDescriptorUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This described the lower bound for a frequency class descriptor.")]
        public string LowerClassBoundValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This described the upper bound for a frequency class descriptor.")]
        public string UpperClassBoundValue;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalResultDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class BiologicalResultDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The primary reason the biological monitoring has occurred.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BiologicalIntentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A number uniquely identifying the individual in accordance with the total number " +
            "of individuals reported by the user.")]
        public string BiologicalIndividualIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the organism sampled as part of a biological sample.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SubjectTaxonomicName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A number or name assigned as a part of a taxonomic identification. Used with a va" +
            "lid genus name to indicate a unique species has been observed but not taxonomica" +
            "lly identified.")]
        public string UnidentifiedSpeciesIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The name of the anatomy from which a tissue sample was taken.")]
        public string SampleTissueAnatomyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Captures the total count or total sample weight for a Group Summary.")]
        public MeasureCompactDataType GroupSummaryCountWeight;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This section allows for the further definition of user-defined details for taxa.")]
        public TaxonomicDetailsDataType TaxonomicDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FrequencyClassInformation", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("This section allows for the definition of a subgroup of biological communities by" +
            " life stage, physical attribute, or abnormality to support frequency class studi" +
            "es.")]
        //TSM:
        //public FrequencyClassInformationDataType[] FrequencyClassInformation;
        public FrequencyClassInformationDataType FrequencyClassInformation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ResultAnalyticalMethod", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ResultAnalyticalMethodDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MethodIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the source or data system that created or defined the identifier.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MethodIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The title that appears on the method from the method publisher.")]
        public string MethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifier of type of method that identifies it as reference, equivalent, or othe" +
            "r.")]
        public string MethodQualifierTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A brief summary that provides general information about the method.")]
        public string MethodDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("DetectionQuantitationLimit", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class DetectionQuantitationLimitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Text describing the type of detection or quantitation level used in the analysis " +
            "of a characteristic.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string DetectionQuantitationLimitTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Constituent concentration that, when processed through the complete method, produ" +
            "ces a signal that is statistically different from a blank.")]
        public MeasureCompactDataType DetectionQuantitationLimitMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ResultLabInformation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ResultLabInformationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of Lab responsible for the result.")]
        public string LaboratoryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the analysis began.")]
        public System.DateTime AnalysisStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AnalysisStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The local time and relative time zone when the analysis began.")]
        public WQXTimeDataType AnalysisStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the analysis was finished.")]
        public System.DateTime AnalysisEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AnalysisEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The local time and relative time zone when the analysis was finished.")]
        public WQXTimeDataType AnalysisEndTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Remarks which further describe the laboratory procedures which produced the resul" +
            "t.")]
        public string ResultLaboratoryCommentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResultDetectionQuantitationLimit", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Information that describes one of a variety of detection or quantitation levels d" +
            "etermined in a laboratory.")]
        public DetectionQuantitationLimitDataType[] ResultDetectionQuantitationLimit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the laboratory is accredited.")]
        public bool LaboratoryAccreditationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LaboratoryAccreditationIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("An outside accreditation authority identifier.")]
        public string LaboratoryAccreditationAuthorityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the taxonomist is accredited.")]
        public bool TaxonomistAccreditationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TaxonomistAccreditationIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("An outside accreditation authority identifier for the taxonomist.")]
        public string TaxonomistAccreditationAuthorityName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("LabSamplePreparation", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class LabSamplePreparationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifying information about the method followed to prepare a sample for analysi" +
            "s.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ReferenceMethodDataType LabSamplePreparationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when the preparation/extraction of the sample for analysis bega" +
            "n.")]
        public System.DateTime PreparationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PreparationStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The local time when the preparation/extraction of the sample for analysis began.")]
        public WQXTimeDataType PreparationStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when the preparation/extraction of the sample for analysis was " +
            "finished.")]
        public System.DateTime PreparationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PreparationEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The local time when the preparation/extraction of the sample for analysis was fin" +
            "ished.")]
        public WQXTimeDataType PreparationEndTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The overall dilution of the substance subjected to this analysis.")]
        public string SubstanceDilutionFactorNumeric;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("Result", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ResultDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Describes the results of a field measurement, observation, or laboratory analysis" +
            ".")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ResultDescriptionDataType ResultDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Allows for the reporting of biological result information.")]
        public BiologicalResultDescriptionDataType BiologicalResultDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public ResultAttachedBinaryObjectDataType[] AttachedBinaryObject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies the procedures, processes, and references required to determine the an" +
            "alytical methods used to obtain a result.")]
        public ResultAnalyticalMethodDataType ResultAnalyticalMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Describes information obtained by a laboratory related to a specific laboratory a" +
            "nalysis.")]
        public ResultLabInformationDataType ResultLabInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LabSamplePreparation", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Describes Lab Sample Preparation procedures which may alter the original state of" +
            " the Sample and produce Lab subsamples.  These Lab Subsamples are analyized and " +
            "reported by the Lab as Sample results.")]
        public LabSamplePreparationDataType[] LabSamplePreparation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("Activity", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Basic identification information for an activity conducted within a project.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ActivityDescriptionDataType ActivityDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Geospatial description of monitoring site, if it is different from that described" +
            " in the station description.")]
        public ActivityLocationDataType ActivityLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Allows for the reporting of biological monitoring activities conducted at a Monit" +
            "oring Location.")]
        public BiologicalActivityDescriptionDataType BiologicalActivityDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Basic identification information for the sample collected as part of a monitoring" +
            " activity.")]
        public SampleDescriptionDataType SampleDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityMetric", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This section allows for the reporting of metrics to support habitat or biotic int" +
            "egrity indices.")]
        public ActivityMetricDataType[] ActivityMetric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public ActivityAttachedBinaryObjectDataType[] AttachedBinaryObject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Identifies the number of result records that exist for a particular activity.")]
        public string ResultCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Result", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Describes the results of a field measurement, observation, or laboratory analysis" +
            ".")]
        public ResultDataType[] Result;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityGroup", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class ActivityGroupDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Designator that uniquely identifies a grouping of activities within an organizati" +
            "on.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityGroupIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A name of an activity group.")]
        public string ActivityGroupName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the type of grouping of a set of activities.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActivityGroupTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityIdentifier", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Designator that uniquely identifies an activity within an organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string[] ActivityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("IndexType", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class IndexTypeDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the index (Organization specific).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string IndexTypeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the source or data system that created or defined the index.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string IndexTypeIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Name of the habitat or biotic integrity index.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string IndexTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Provides additional description of the source that created or defined the index.")]
        public BibliographicReferenceDataType IndexTypeCitation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Provides a description of the scale used for the index.")]
        public string IndexTypeScaleText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalHabitatIndex", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class BiologicalHabitatIndexDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique designator used to identify a unique index record that the activity metr" +
            "ic is associated with.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string IndexIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This section identifies the index type reported as part of a biological or habita" +
            "t index.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public IndexTypeDataType IndexType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Provides the score for the index.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string IndexScoreNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the index.")]
        public string IndexQualifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments concerning the index.")]
        public string IndexCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date on which the index was calcualted.")]
        public System.DateTime IndexCalculatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IndexCalculatedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the monitoring location.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitoringLocationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("Organization", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class OrganizationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The particular word(s) regularly connected with a unique framework of authority w" +
            "ithin which a person or persons act, or are designated to act, towards some purp" +
            "ose.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public OrganizationDescriptionDataType OrganizationDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ElectronicAddress", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A location within a system of worldwide electronic communication where a computer" +
            " user can access information or receive electronic mail.")]
        public ElectronicAddressDataType[] ElectronicAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Telephonic", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("An identification of a telephone connection.")]
        public TelephonicDataType[] Telephonic;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationAddress", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The physical address of an organization.")]
        public OrganizationAddressDataType[] OrganizationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Project", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("An environmental data collection effort that has a stated purpose and puts a seri" +
            "es of samples and results into a meaningful context.")]
        public ProjectDataType[] Project;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoringLocation", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("An identifiable location where an environmental sample, onsite measurement, and/o" +
            "r observation is determined.")]
        public MonitoringLocationDataType[] MonitoringLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BiologicalHabitatIndex", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This section allows for the reporting of habitat and biotic integrity indices as " +
            "a representation of water quality conditions.")]
        public BiologicalHabitatIndexDataType[] BiologicalHabitatIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Activity", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Allows for the reporting of monitoring activities conducted at a Monitoring Locat" +
            "ion.")]
        public ActivityDataType[] Activity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityGroup", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Allows for the grouping of activities.")]
        public ActivityGroupDataType[] ActivityGroup;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQX", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Schema used to transfer organization information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public OrganizationDataType Organization;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationDelete", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class OrganizationDeleteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a unique business establishment within a c" +
            "ontext.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectIdentifier", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a data collection project within a context" +
            " of an organization.")]
        public string[] ProjectIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoringLocationIdentifier", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A designator used to describe the unique name, number, or code assigned to identi" +
            "fy the monitoring location.")]
        public string[] MonitoringLocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityIdentifier", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Designator that uniquely identifies an activity within an organization.")]
        public string[] ActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityGroupIdentifier", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Designator that uniquely identifies a grouping of activities within an organizati" +
            "on.")]
        public string[] ActivityGroupIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndexIdentifier", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A unique designator used to identify a unique index record that the activity metr" +
            "ic is associated with.")]
        public string[] IndexIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXDelete", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXDeleteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationDelete", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Schema used to delete organization information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public OrganizationDeleteDataType[] OrganizationDelete;
        public OrganizationDeleteDataType OrganizationDelete;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXElementRowColumn", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXElementRowColumnDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string colname;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXDomainValueList", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXDomainValueListDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WQXElement", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An element in the WQX namespace that has a corresponding listing of valid domain " +
            "values.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public WQXElementDataType[] WQXElement;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXElement", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXElementDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of an element in the WQX schema that has a domain value list.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WQXElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("WQXElementRowColumn", typeof(WQXElementRowColumnDataType), IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("An individual valid value from a WQX domain value listing for one element.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public WQXElementRowColumnDataType[][] WQXElementRow;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXElementRow", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXElementRowDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WQXElementRowColumn", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A column value for one row corresponding to a WQX domain value list.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public WQXElementRowColumnDataType[] WQXElementRowColumn;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionRecord", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class TransactionRecordDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The Organization ID for this transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TransactionOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the Exchange Network account used to initiate the WQX service request" +
            ".")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TransactionUserName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The transaction ID generated by the Node for this transaction.")]
        public string TransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the web service request began processing.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransactionStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The time on which the web service request began processing.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransactionStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The calendar date on which the web service request finished processing.")]
        public System.DateTime TransactionEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TransactionEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The time on which the web service request finished processing.")]
        public System.DateTime TransactionEndTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TransactionEndTimeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name of the Exchange Network service method (i.e. Submit, Solicit, etc.) for " +
            "this transaction.")]
        public string TransactionTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The latest status logged for this Exchange Network transaction.")]
        public string TransactionStatusName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The author supplied in the header portion of the WQX submission, which correspond" +
            "s to the individual who generated the WQX XML submission.")]
        public string TransactionHeaderAuthor;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The Operation supplied in the document header, which corresponds to the operation" +
            " to be performed on the payload.")]
        public string TransactionPayloadOperationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Any additional comments related to the processing of this transaction record.")]
        public string TransactionCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/2")]
    [System.Xml.Serialization.XmlRootAttribute("WQXTransactionHistory", Namespace = "http://www.exchangenetwork.net/schema/wqx/2", IsNullable = false)]
    public partial class WQXTransactionHistoryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransactionRecord", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A record of a prior WQX submission transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TransactionRecordDataType[] TransactionRecord;
    }
}
