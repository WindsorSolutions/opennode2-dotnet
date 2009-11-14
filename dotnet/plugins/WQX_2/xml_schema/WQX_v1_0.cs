namespace Windsor.Node2008.WNOSPlugin.WQX1XsdOrm
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("AddressTypeName", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public enum AddressTypeNameDataType
    {

        /// <remarks/>
        Location,

        /// <remarks/>
        Mailing,

        /// <remarks/>
        Shipping,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddressTypeName", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public enum ElectronicAddressTypeNameDataType
    {

        /// <remarks/>
        Email,

        /// <remarks/>
        Internet,

        /// <remarks/>
        Intranet,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultDetectionConditionText", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public enum ResultDetectionConditionTextDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Detected Not Quantified")]
        DetectedNotQuantified,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not Reported")]
        NotReported,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Present Above Quantification Limit")]
        PresentAboveQuantificationLimit,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not Detected")]
        NotDetected,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Present Below Quantification Limit")]
        PresentBelowQuantificationLimit,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultStatusIdentifier", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public enum ResultStatusIdentifierDataType
    {

        /// <remarks/>
        Accepted,

        /// <remarks/>
        Validated,

        /// <remarks/>
        Rejected,

        /// <remarks/>
        Preliminary,

        /// <remarks/>
        Final,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("TelephoneNumberTypeName", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public enum TelephoneNumberTypeNameDataType
    {

        /// <remarks/>
        Fax,

        /// <remarks/>
        Home,

        /// <remarks/>
        Mobile,

        /// <remarks/>
        Office,

        /// <remarks/>
        Pager,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddress", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        public ElectronicAddressTypeNameDataType ElectronicAddressTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElectronicAddressTypeNameSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("Telephonic", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public partial class TelephonicDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that identifies a particular telephone connection.")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes a telephone number type.")]
        public TelephoneNumberTypeNameDataType TelephoneNumberTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TelephoneNumberTypeNameSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number assigned within an organization to an individual telephone that extend" +
            "s the external telephone number.")]
        public string TelephoneExtensionNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationAddress", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public partial class OrganizationAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Categorizes an address as either location, shipping, or mailing address.")]
        public AddressTypeNameDataType AddressTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AddressTypeNameSpecified;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("AttachedBinaryObject", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("Project", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public ProjectAttachedBinaryObjectDataType[] AttachedBinaryObject;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("AlternateMonitoringLocationIdentity", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentity", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureCompact", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationGeospatial", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The measure of elevation (i.e., the altitude), above or below a reference datum.")]
        public MeasureCompactDataType VerticalMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the method used to collect the vertical measure (i.e. th" +
            "e altitude) of a reference point.")]
        public string VerticalCollectionMethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name of the reference datum used to determine the vertical measure (i.e., the" +
            " altitude).")]
        public string VerticalCoordinateReferenceSystemDatumName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string CountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a principal administrative subdivision of the " +
            "United States, Canada, or Mexico.")]
        public string StateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a U.S. county or county equivalent.")]
        public string CountyCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocation", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public MonitoringLocationAttachedBinaryObjectDataType[] AttachedBinaryObject;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXTime", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityLocation", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReferenceMethod", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("SamplePreparation", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("SampleDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public partial class SampleDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute(@"Identifies sample collection or measurement method procedures. Where a documented sample collection method has been employed, this enables the data provider to indicate the documented method that was employed during the field sample collection. Otherwise, the sample collection procedure will best be described in a freeform text.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ReferenceMethodDataType SampleCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the organism from which a tissue sample was taken.")]
        public string SampleTissueTaxonomicName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the anatomy from which a tissue sample was taken.")]
        public string SampleTissueAnatomyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name for the equipment used in collecting the sample.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleCollectionEquipmentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments further describing the sample collection equipmen" +
            "t.")]
        public string SampleCollectionEquipmentCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Describes a sample preparation procedure which may be conducted on an initial Sam" +
            "ple or on subsequent subsamples.")]
        public SamplePreparationDataType SamplePreparation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("Measure", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("DataQuality", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultDescription", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        public ResultDetectionConditionTextDataType ResultDetectionConditionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultDetectionConditionTextSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The object, property, or substance which is evaluated or enumerated by either a d" +
            "irect field measurement, a direct field observation, or by laboratory analysis o" +
            "f material collected in the field.")]
        public string CharacteristicName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The text name of the portion of the sample associated with results obtained from " +
            "a physically-partitioned sample.")]
        public string ResultSampleFractionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The reportable measure of the result for the chemical, microbiological or other c" +
            "haracteristic being analyzed.")]
        public MeasureDataType ResultMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates the acceptability of the result with respect to QA/QC criteria.")]
        public ResultStatusIdentifierDataType ResultStatusIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultStatusIdentifierSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The code for the method used to calculate derived results.")]
        public string StatisticalBaseCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("A name that qualifies the process which was used in the determination of the resu" +
            "lt value (e.g., actual, estimated, calculated).")]
        public string ResultValueTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name that represents the form of the sample or portion of the sample which is" +
            " associated with the result value (e.g., wet weight, dry weight, ash-free dry we" +
            "ight).")]
        public string ResultWeightBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The period of time (in days) over which a measurement was made. For example, BOD " +
            "can be measured as 5 day or 20 day BOD.")]
        public string ResultTimeBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The name that represents the controlled temperature at which the sample was maint" +
            "ained during analysis, e.g. 25 deg BOD analysis.")]
        public string ResultTemperatureBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("User defined free text describing the particle size class for which the associate" +
            "d result is defined.")]
        public string ResultParticleSizeBasisText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The quantitative statistics and qualitative descriptors that are used to interpre" +
            "t the degree of acceptability or utility of data to the user.")]
        public DataQualityDataType DataQuality;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Free text with general comments concerning the result.")]
        public string ResultCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("A measurement of the vertical location (measured from a reference point) at which" +
            " a result is obtained.")]
        public MeasureCompactDataType ResultDepthHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The reference used to indicate the datum or reference used to establish the depth" +
            "/altitude of a result.")]
        public string ResultDepthAltitudeReferencePointText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultAnalyticalMethod", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("DetectionQuantitationLimit", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ResultLabInformation", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("LabSamplePreparation", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("Result", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public partial class ResultDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Describes the results of a field measurement, observation, or laboratory analysis" +
            ".")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ResultDescriptionDataType ResultDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public ResultAttachedBinaryObjectDataType[] AttachedBinaryObject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the procedures, processes, and references required to determine the an" +
            "alytical methods used to obtain a result.")]
        public ResultAnalyticalMethodDataType ResultAnalyticalMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Describes information obtained by a laboratory related to a specific laboratory a" +
            "nalysis.")]
        public ResultLabInformationDataType ResultLabInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LabSamplePreparation", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Describes Lab Sample Preparation procedures which may alter the original state of" +
            " the Sample and produce Lab subsamples.  These Lab Subsamples are analyized and " +
            "reported by the Lab as Sample results.")]
        public LabSamplePreparationDataType[] LabSamplePreparation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("Activity", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        [System.ComponentModel.DescriptionAttribute("Basic identification information for the sample collected as part of a monitoring" +
            " activity.")]
        public SampleDescriptionDataType SampleDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AttachedBinaryObject", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Reference document, image, photo, GIS data layer, laboratory material or other el" +
            "ectronic object attached within a data exchange, as well as information used to " +
            "describe the object.")]
        //TSM:
        //public AttachedBinaryObjectDataType[] AttachedBinaryObject;
        public ActivityAttachedBinaryObjectDataType[] AttachedBinaryObject;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identifies the number of result records that exist for a particular activity.")]
        public string ResultCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Result", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Describes the results of a field measurement, observation, or laboratory analysis" +
            ".")]
        public ResultDataType[] Result;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("ActivityGroup", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("Organization", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        [System.Xml.Serialization.XmlElementAttribute("Activity", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Allows for the reporting of monitoring activities conducted at a Monitoring Locat" +
            "ion.")]
        public ActivityDataType[] Activity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ActivityGroup", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Allows for the grouping of activities.")]
        public ActivityGroupDataType[] ActivityGroup;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQX", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationDelete", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXDelete", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXElementRowColumn", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXDomainValueList", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXElement", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXElementRow", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionRecord", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
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
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/wqx/1")]
    [System.Xml.Serialization.XmlRootAttribute("WQXTransactionHistory", Namespace = "http://www.exchangenetwork.net/schema/wqx/1", IsNullable = false)]
    public partial class WQXTransactionHistoryDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransactionRecord", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A record of a prior WQX submission transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TransactionRecordDataType[] TransactionRecord;
    }
}
