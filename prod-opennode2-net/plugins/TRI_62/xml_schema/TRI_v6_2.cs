namespace Windsor.Node2008.WNOSPlugin.TRI62
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "MailingAddressDataType", Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class MailingAddress : MailingAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the province for a non-US address.")]
        public string ProvinceNameText;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MailingAddressDataType1))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MailingAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MailingAddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The exact address where a mail piece is intended to be delivered, including urban" +
            "-style street address, rural route, and PO Box.")]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information to facilitate the delivery of a mai" +
            "l piece, including building name, secondary units, and mail stop or local box nu" +
            "mbers not serviced by the U.S. Postal Service.")]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the city, town, or village where the mail is delivered.")]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentity StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCode AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentity CountryIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("StateIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class StateIdentity
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
        public StateCodeListIdentifier StateCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a principal administrative subdivision of the United Stat" +
            "es, Canada, or Mexico.")]
        public string StateName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class StateCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountryCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CountryCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountryIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CountryIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string CountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a country code. Can be used " +
            "to identify the URL of a source that defines the set of currently approved permi" +
            "tted values.")]
        public CountryCodeListIdentifier CountryCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A name used to identify a primary geopolitical unit of the world.")]
        public string CountryName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AddressPostalCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AddressPostalCodeContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "GeographicLocationDescriptionDataType", Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class GeographicLocationDescription : GeographicLocationDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The location of a facility in latitude degrees, [-90,90], integer.")]
        public string LatitudeDegreeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The location of a facility in latitude minutes, [0,59], integer.")]
        public string LatitudeMinuteMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The location of a facility in latitude seconds, [0,59], integer.")]
        public string LatitudeSecondMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The location of a facility in longitude degrees, [-180,180), integer.")]
        public string LongitudeDegreeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The location of a facility in longitude minutes, [0,59], integer.")]
        public string LongitudeMinuteMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The location of a facility in longitude seconds, [0,59], integer.")]
        public string LongitudeSecondMeasure;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GeographicLocationDescriptionDataType1))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeographicLocationDescriptionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The measure of the accuracy of the latitude and longitude coordinates.")]
        public HorizontalAccuracyMeasure HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to determine the latitude and longitud" +
            "e coordinates for a point on the earth.")]
        public HorizontalCollectionMethod HorizontalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geographic reference poin" +
            "t.")]
        public GeographicReferencePoint GeographicReferencePoint;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the reference datum used in determining latitude and l" +
            "ongitude coordinates.")]
        public HorizontalReferenceDatum HorizontalReferenceDatum;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when data were collected.")]
        public System.DateTime DataCollectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about the geographic coordinates.")]
        public string LocationCommentsText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The measure of elevation (i.e. the altitude) above or below are reference datum.")]
        public HorizontalAccuracyMeasure VerticalMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method used to collect the vertical measure(i.e., " +
            "the altitude) of a reference point.")]
        public HorizontalCollectionMethod VerticalCollectionMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the reference datum used to determine the vertical mea" +
            "sure (i.e., the altitude).")]
        public HorizontalReferenceDatum VerticalReferenceDatum;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Information that describes the method or process used to verify the latitude and " +
            "longitude coordinates.")]
        public HorizontalCollectionMethod VerificationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a data source of coordinate" +
            " data.")]
        public CoordinateDataSource CoordinateDataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a geometric entity represen" +
            "ted by one point or a sequence of points.")]
        public GeometricType GeometricType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("Measure", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class HorizontalAccuracyMeasure
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The recorded dimension, capacity, quality, or amount of something ascertained by " +
            "measuring or observing.")]
        public string MeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a unit of measurement.")]
        public MeasureUnit MeasureUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The precision of the recorded value.")]
        public string MeasurePrecisionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify any qualifying issues that " +
            "affect results.")]
        public ResultQualifier ResultQualifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnit", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MeasureUnit
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        public string MeasureUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a measurement unit code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public MeasureUnitCodeListIdentifier MeasureUnitCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the unit of measure code.")]
        public string MeasureUnitName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnitCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MeasureUnitCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ResultQualifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the results.")]
        public string ResultQualifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a result qualifier code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public ResultQualifierCodeListIdentifier ResultQualifierCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the result code of any qualifying issues that affect the results" +
            ".")]
        public string ResultQualifierName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifierCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ResultQualifierCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReferenceMethod", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class HorizontalCollectionMethod
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        public string MethodIdentifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a reference method code. Can" +
            " be used to identify the URL of a source that defines the set of currently appro" +
            "ved permitted values.")]
        public MethodIdentifierCodeListIdentifier MethodIdentifierCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The title of the method that appears on the method from the organization that pub" +
            "lished it.")]
        public string MethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A brief summary that provides general information about the method.")]
        public string MethodDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Text that identifies any deviations from the published method reference.")]
        public string MethodDeviationsText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MethodIdentifierCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MethodIdentifierCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferencePoint", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeographicReferencePoint
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geographic reference point" +
            " code. Can be used to identify the URL of a source that defines the set of curre" +
            "ntly approved permitted values.")]
        public ReferencePointCodeListIdentifier ReferencePointCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text that identifies the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReferencePointCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ReferencePointCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatum", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class HorizontalReferenceDatum
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the reference datum used in determining latitude and lon" +
            "gitude coordinates or vertical measure.")]
        public string GeographicReferenceDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geographic reference datum" +
            " code.Can be used to identify the URL of a source that defines the set of curren" +
            "tly approved permitted values.")]
        public GeographicReferenceDatumCodeListIdentifier GeographicReferenceDatumCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the reference datum used in determining latitude and long" +
            "itude coordinates or vertical measure.")]
        public string GeographicReferenceDatumName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatumCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeographicReferenceDatumCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSource", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CoordinateDataSource
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the party responsible for providing the latitude and lon" +
            "gitude coordinates.")]
        public string CoordinateDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a coordinate milestone type " +
            "code. Can be used to identify the URL of a source that defines the set of curren" +
            "tly approved permitted values.")]
        public CoordinateDataSourceCodeListIdentifier CoordinateDataSourceCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the party responsible for providing the latitude and longitude coordi" +
            "nates.")]
        public string CoordinateDataSourceName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSourceCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CoordinateDataSourceCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricType", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeometricType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the geometric entity represented by one point or a seque" +
            "nce of latitude and longitude points.")]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a geometric type code. Can b" +
            "e used to identify the URL of a source that defines the set of currently approve" +
            "d permitted values.")]
        public GeometricTypeCodeListIdentifier GeometricTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the geometric entity represented by one point or a seque" +
            "nce of latitude and longitude points.")]
        public string GeometricTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeometricTypeCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("Facility", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class Facility
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityIdentifier", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A unique number assigned to the facility. The context attribute indicates which s" +
            "ystem the identifier refers to, such as TRI or FRS.")]
        public FacilityIdentifier[] FacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A facility can be accessed either by providing the current Facility Access Key th" +
            "at is provided via CDX registration, or by providing the prior year Technical Co" +
            "ntact name and phone number from any form associated with the corresponding TRIF" +
            "ID.")]
        public FacilityAccessDetails FacilityAccessDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The physical location of an individual or organization.")]
        public LocationAddress LocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The name which the facility or establishment uses for receiving mail.")]
        public string MailingFacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The standard address used to send mail to an individual or organization.")]
        public MailingAddress MailingAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySIC", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The Standard Industrial Classification (SIC) code or codes which best describes t" +
            "he activities conducted at the facility.")]
        public FacilitySIC[] FacilitySIC;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityNAICS", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The North American Industry Classification System (NAICS) code or codes which bes" +
            "t describes the activities conducted at the facility.")]
        public FacilityNAICS[] FacilityNAICS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Extensive list of geographic identifiers used to clearly mark an object\'s precise" +
            " location.")]
        public GeographicLocationDescription GeographicLocationDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the N/A box was checked for the parent company name on the TRI rep" +
            "orting form.")]
        public bool ParentCompanyNameNAIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ParentCompanyNameNAIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Name of the corporation or other business company that is the ultimate parent com" +
            "pany of the facility or establishment submitting the data.")]
        public string ParentCompanyNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the parent company name was not the EPA provided standardized name" +
            ".")]
        public bool ParentCompanyNameNotStandard;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ParentCompanyNameNotStandardSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The number which has been assigned to the parent company by Dun and Bradstreet.")]
        public string ParentDunBradstreetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the N/A box was checked for the foreign parent company name on the" +
            " TRI reporting form.")]
        public bool ForeignParentCompanyNameNAIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForeignParentCompanyNameNAIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Name of the highest-level foreign parent company in the facility\'s ownership hier" +
            "archy as of December 31 of the year for which data are being reported.")]
        public string ForeignParentCompanyNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the foreign parent company name was not the EPA provided standardi" +
            "zed name.")]
        public bool ForeignParentCompanyNameNotStandard;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ForeignParentCompanyNameNotStandardSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The number which has been assigned to the foreign parent company by Dun and Brads" +
            "treet.")]
        public string ForeignParentDunBradstreetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityDunBradstreetCode", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The number which has been assigned to a company by Dun and Bradstreet.")]
        public string[] FacilityDunBradstreetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RCRAIdentificationNumber", Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the Resource Conservat" +
            "ion and Recovery Act (RCRA).")]
        public string[] RCRAIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NPDESIdentificationNumber", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the National Pollutant" +
            " Discharge Elimination System (NPDES) program.")]
        public string[] NPDESIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UICIdentificationNumber", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the Undergrounf Inject" +
            "ion Well Code (UIC) program.")]
        public string[] UICIdentificationNumber;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityIdentifier", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class FacilityIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FacilitySiteIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityAccessDetails", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class FacilityAccessDetails
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityAccessCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("PriorYearTechnicalContactDetails", typeof(PriorYearTechnicalContactDetailsDataType), Order = 0)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("PriorYearTechnicalContactDetails", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class PriorYearTechnicalContactDetailsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The technical contact name from any form associated with the corresponding TRIFID" +
            ".")]
        public string PriorYearTechnicalContactNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The technical contact phone number from any form associated with the correspondin" +
            "g TRIFID.")]
        public string PriorYearTechnicalContactTelephoneNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class LocationAddress
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic) location of the front door o" +
            "r main entrance of a facility site, including urban-style street address or rura" +
            "l address.")]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about a place, including a building" +
            " name with its secondary unit and number, an industrial park name, an installati" +
            "on name or descriptive text where no formal address is available.")]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of a city, town, village or other locality.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a principal administrative " +
            "subdivision of the United States, Canada, or Mexico.")]
        public StateIdentity StateIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCode AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a primary geopolitical unit" +
            " of the world.")]
        public CountryIdentity CountryIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a U.S. county or county equ" +
            "ivalent.")]
        public CountyIdentity CountyIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute(@"Identification information concerning recognized entities that possess immunities and privileges available as a federally acknowledged American Indian tribes or Alaskan Native entities by virtue of their government-to-government relationship with the Federal Government of the United States.")]
        public TribalIdentity TribalIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name of an American Indian or Alaskan native area where the location address " +
            "exists.")]
        public string TribalLandName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("An indicator denoting the location address is a tribal land")]
        public TribalLandIndicator TribalLandIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TribalLandIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A brief explanation of a location, including navigational directions and/or more " +
            "descriptive information.")]
        public string LocationDescriptionText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountyIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CountyIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the county.")]
        public string CountyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a county code. Can be used t" +
            "o identify the URL of a source that defines the set of currently approved permit" +
            "ted values.")]
        public CountyCodeListIdentifier CountyCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the county code.")]
        public string CountyName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountyCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CountyCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TribalIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class TribalIdentity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian tribe or Alaskan Native entity.")]
        public string TribalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a tribal code.Can be used to" +
            " identify the URL of a source that defines the set of currently approved permitt" +
            "ed values.")]
        public TribalCodeListIdentifier TribalCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the American Indian tribe or Alaskan Native entity.")]
        public string TribalName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TribalCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class TribalCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TribalLandIndicator", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum TribalLandIndicator
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySIC", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class FacilitySIC
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the economic activity of a company.")]
        public string SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that indicates whether the associated SIC Code represents the primary ac" +
            "tivity occurring at the facility site.")]
        public SICPrimaryIndicator SICPrimaryIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SICPrimaryIndicator", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum SICPrimaryIndicator
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityNAICS", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class FacilityNAICS
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a subdivision of an industry that accommodates user need" +
            "s in the United States.")]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that indicates whether the associated NAICS Code represents the primary " +
            "activity occurring at the facility site.")]
        public NAICSPrimaryIndicator NAICSPrimaryIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("NAICSPrimaryIndicator", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum NAICSPrimaryIndicator
    {

        /// <remarks/>
        Primary,

        /// <remarks/>
        Secondary,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ReportType", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class ReportType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify a type of report.")]
        public ReportTypeCode ReportTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportTypeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a report type code. Can be u" +
            "sed to identify the URL of a source that defines the set of currently approved p" +
            "ermitted values.")]
        public ReportTypeCodeListIdentifier ReportTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A description of the report type code.")]
        public string ReportTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ReportTypeCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum ReportTypeCode
    {

        /// <remarks/>
        TRI_FORM_R,

        /// <remarks/>
        TRI_FORM_A,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ReportTypeCodeListIdentifier
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("SourceReductionActivity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class SourceReductionActivityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Sequence in which a source reduction method is reported on a submission.")]
        public int SourceReductionSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SourceReductionSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the type of source reduction activity implemented at the facility durin" +
            "g the reporting year.")]
        public string SourceReductionActivityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SourceReductionMethodCode", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the method or methods used at the facility to identify the possibility " +
            "for a source reduction activity implementation at the facility.")]
        public SourceReductionMethodCode[] SourceReductionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the estimated annual reduction in chemical waste.")]
        public string SourceReductionEfficiencyCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("SourceReductionMethodCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum SourceReductionMethodCode
    {

        /// <remarks/>
        T01,

        /// <remarks/>
        T02,

        /// <remarks/>
        T03,

        /// <remarks/>
        T04,

        /// <remarks/>
        T05,

        /// <remarks/>
        T06,

        /// <remarks/>
        T07,

        /// <remarks/>
        T08,

        /// <remarks/>
        T09,

        /// <remarks/>
        T10,

        /// <remarks/>
        T11,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ToxicEquivalencyIdentification", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class ToxicEquivalencyIdentification
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 2,3,7,8-Tetrachlorodibenzo-p-dioxin (CAS Number: 01746-01-6) i" +
            "n the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency1Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency1ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,7,8-Pentachlorodibenzo-p-dioxin (CAS Number: 40321-76-4)" +
            " in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency2Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency2ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,7,8-Hexachlorodibenzo-p-dioxin (CAS Number: 39227-28-6" +
            ") in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency3Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency3ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,6,7,8-Hexachlorodibenzo-p-dioxin (CAS Number: 57653-85-7" +
            ") in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency4Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency4ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,7,8,9-Hexachlorodibenzo-p-dioxin (CAS Number: 19408-74-3" +
            ") in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency5Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency5ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,6,7,8-Heptachlorodibenzo-p-dioxin (CAS Number: 35822-4" +
            "6-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency6Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency6ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,6,7,8,9-Octachlorodibenzo-p-dioxin (CAS Number: 03268-" +
            "87-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency7Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency7ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 2,3,7,8-Tetrachlorodibenzofuran (CAS Number: 51207-31-9) in th" +
            "e reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency8Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency8ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,7,8-Pentachlorodibenzofuran (CAS Number: 57117-41-6) in " +
            "the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency9Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency9ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 2,3,4,7,8-Pentachlorodibenzofuran (CAS Number: 57117-31-4) in " +
            "the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency10Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency10ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,7,8-Hexachlorodibenzofuran (CAS Number: 70648-26-9) in" +
            " the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency11Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency11ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,6,7,8-Hexachlorodibenzofuran (CAS Number: 57117-44-9) in" +
            " the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency12Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency12ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,7,8,9-Hexachlorodibenzofuran (CAS Number: 72918-21-9) in" +
            " the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency13Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency13ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 2,3,4,6,7,8-Hexachlorodibenzofuran (CAS Number: 60851-34-5) in" +
            " the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency14Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency14ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,6,7,8-Heptachlorodibenzofuran (CAS Number: 67562-39-4)" +
            " in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency15Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency15ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,7,8,9-Heptachlorodibenzofuran (CAS Number: 55673-89-7)" +
            " in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency16Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency16ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Indicates grams of 1,2,3,4,6,7,8,9-Octachlorodibenzofuran (CAS Number: 39001-02-0" +
            ") in the reported dioxin or dioxin-like compounds.")]
        public decimal ToxicEquivalency17Value;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalency17ValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether \'NA\' (Not Applicable) was entered on Form R for the distributio" +
            "n of each member of the dioxin and dioxin-like compounds category.")]
        public bool ToxicEquivalencyNAIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalencyNAIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("QuantityBasisEstimationCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum QuantityBasisEstimationCodeType
    {

        /// <remarks/>
        C,

        /// <remarks/>
        M,

        /// <remarks/>
        M1,

        /// <remarks/>
        M2,

        /// <remarks/>
        E,

        /// <remarks/>
        E1,

        /// <remarks/>
        E2,

        /// <remarks/>
        O,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("WasteQuantityRangeCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum WasteQuantityRangeCodeType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        B,

        /// <remarks/>
        C,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("SourceReductionQuantity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class SourceReductionQuantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteUICDisposalQuantity", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical disposed/released (or expected" +
            " to be disposed/released) to Underground Injection Control Wells onsite during a" +
            " given calendar year.")]
        public OnsiteUICDisposalQuantity[] OnsiteUICDisposalQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteOtherDisposalQuantity", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical disposed/released (or expected" +
            " to be disposed/released) by means other than UIC wells onsite during a given ca" +
            "lendar year.")]
        public OnsiteUICDisposalQuantity[] OnsiteOtherDisposalQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OffsiteUICDisposalQuantity", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical disposed/released (or expected" +
            " to be disposed/released) to Underground Injection Control Wells offsite during " +
            "a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OffsiteUICDisposalQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OffsiteOtherDisposalQuantity", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical disposed/released (or expected" +
            " to be disposed/released) by means other than UIC wells offsite during a given c" +
            "alendar year.")]
        public OnsiteUICDisposalQuantity[] OffsiteOtherDisposalQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteEnergyRecoveryQuantity", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical in waste burned (or expected t" +
            "o be burned) for energy recovery onsite during a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OnsiteEnergyRecoveryQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OffsiteEnergyRecoveryQuantity", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical in waste sent (or expected to " +
            "be sent) offsite to be burned for energy recovery during a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OffsiteEnergyRecoveryQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteRecycledQuantity", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical recycled (or expected to be re" +
            "cycled) during a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OnsiteRecycledQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OffsiteRecycledQuantity", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical sent (or expected to be sent) " +
            "offsite for recycling during a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OffsiteRecycledQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteTreatedQuantity", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical treated (or expected to be tre" +
            "ated) onsite during a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OnsiteTreatedQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OffsiteTreatedQuantity", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical sent (or expected to be sent) " +
            "offsite for treatment during a given calendar year.")]
        public OnsiteUICDisposalQuantity[] OffsiteTreatedQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CalculatorRoundingHintNumber", typeof(string), DataType = "integer", Order = 10)]
        [System.Xml.Serialization.XmlElementAttribute("OneTimeReleaseNAIndicator", typeof(bool), Order = 10)]
        [System.Xml.Serialization.XmlElementAttribute("OneTimeReleaseQuantity", typeof(decimal), Order = 10)]
        [System.Xml.Serialization.XmlElementAttribute("ToxicEquivalencyIdentification", typeof(ToxicEquivalencyIdentificationType), Order = 10)]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProductionRatioMeasure", typeof(decimal), Order = 11)]
        [System.Xml.Serialization.XmlElementAttribute("ProductionRatioNAIndicator", typeof(bool), Order = 11)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the ratio provided is a production or activity ratio.")]
        public string ProductionRatioType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("OnsiteUICDisposalQuantity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class OnsiteUICDisposalQuantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute(@"A value which when added to the reporting year for the current submission will equal the year for which the total quantity is reported. This value is used to calcuate the column on Form R Section 8 to which the total quantity values correspond. (i.e. -1 = Proir Year)")]
        public int YearOffsetMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool YearOffsetMeasureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CalculatorRoundingHintNumber", typeof(string), DataType = "integer", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("TotalQuantity", typeof(decimal), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("TotalQuantityNAIndicator", typeof(bool), Order = 1)]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identification of the toxic equivalency (for Form R Schedule-1) for dioxin and di" +
            "oxin-like chemicals.")]
        public ToxicEquivalencyIdentification ToxicEquivalencyIdentification;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("OnsiteRecyclingProcess", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class OnsiteRecyclingProcess
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteRecyclingMethodCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("OnsiteRecyclingNAIndicator", typeof(bool), Order = 0)]
        public object[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("OnsiteRecoveryProcess", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class OnsiteRecoveryProcess
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnergyRecoveryMethodCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("EnergyRecoveryNAIndicator", typeof(bool), Order = 0)]
        public object[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("WasteTreatmentMethod", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class WasteTreatmentMethod
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Sequence in which a treatment method was entered on TRI Form R.")]
        public int WasteTreatmentSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WasteTreatmentSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The waste treatment activity that is applied to the waste stream containing the t" +
            "oxic chemical.")]
        public string WasteTreatmentMethodCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("WasteTreatmentDetails", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class WasteTreatmentDetailsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Sequence in which an on-site waste treatment process is reported on a Form R subm" +
            "ission.")]
        public int WasteStreamSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WasteStreamSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the general waste stream type containing the toxic chemical.")]
        public string WasteStreamTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteTreatmentMethod", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Waste treatment information.")]
        public WasteTreatmentMethod[] WasteTreatmentMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the range of concentration of the toxic chemical in the waste stream as" +
            " it typically enters the waste treatment step or sequence. Unused starting RY200" +
            "5.")]
        public InfluentConcentrationRangeCode InfluentConcentrationRangeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InfluentConcentrationRangeCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TreatmentEfficiencyEstimatePercent", typeof(decimal), Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute("TreatmentEfficiencyNAIndicator", typeof(bool), Order = 4)]
        [System.Xml.Serialization.XmlElementAttribute("TreatmentEfficiencyRangeCode", typeof(string), Order = 4)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the waste treatment efficiency estimate is based on actual operating" +
            " data. Unused starting RY2005.")]
        public bool OperatingDataIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OperatingDataIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("InfluentConcentrationRangeCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum InfluentConcentrationRangeCode
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
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("TransferQuantity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TransferQuantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Sequence in which an off-site transfer amount is reported on a submission.")]
        public int TransferSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TransferSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Captures a quantity of waste and how the was quantity was determined by the repor" +
            "ter.")]
        public TransferWasteQuantity TransferWasteQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of waste treatment, disposal, recycling, or energy recovery methods the " +
            "off-site location uses to manage the toxic chemical.")]
        public WasteManagementTypeCode WasteManagementTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WasteManagementTypeCodeSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("TransferWasteQuantity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TransferWasteQuantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityCatastrophicMeasure", typeof(decimal), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityMeasure", typeof(decimal), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityNAIndicator", typeof(bool), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeCode", typeof(WasteQuantityRangeCodeType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeNumericBasisValue", typeof(decimal), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsElementName[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationCode", typeof(QuantityBasisEstimationCodeType), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationNAIndicator", typeof(bool), Order = 2)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identification of the toxic equivalency (for Form R Schedule-1) for dioxin and di" +
            "oxin-like chemicals.")]
        public ToxicEquivalencyIdentification ToxicEquivalencyIdentification;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IncludeInSchema = false)]
    public enum ItemsElementName
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Non-production value due to catastrophic events, used in calculating Section 8 va" +
            "lues.")]
        WasteQuantityCatastrophicMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical transferred from the reporting" +
            " facility to the receiving facility. For dioxin or dioxin-like compunds, report " +
            "in grams/year.")]
        WasteQuantityMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Indicates that \'NA\' (Not Applicable) was entered on the Form R for the quantity t" +
            "otal transfers.")]
        WasteQuantityNAIndicator,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Code that corresponds to the amount of toxic chemical released annually by the re" +
            "porting facility.")]
        WasteQuantityRangeCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("A decimal value used during calculations for a Waste Quantity that was reported u" +
            "sing a range code.")]
        WasteQuantityRangeNumericBasisValue,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("WasteManagementTypeCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum WasteManagementTypeCode
    {

        /// <remarks/>
        INV,

        /// <remarks/>
        M10,

        /// <remarks/>
        M20,

        /// <remarks/>
        M24,

        /// <remarks/>
        M26,

        /// <remarks/>
        M28,

        /// <remarks/>
        M40,

        /// <remarks/>
        M41,

        /// <remarks/>
        M50,

        /// <remarks/>
        M54,

        /// <remarks/>
        M56,

        /// <remarks/>
        M61,

        /// <remarks/>
        M62,

        /// <remarks/>
        M63,

        /// <remarks/>
        M64,

        /// <remarks/>
        M65,

        /// <remarks/>
        M66,

        /// <remarks/>
        M67,

        /// <remarks/>
        M69,

        /// <remarks/>
        M71,

        /// <remarks/>
        M72,

        /// <remarks/>
        M73,

        /// <remarks/>
        M79,

        /// <remarks/>
        M81,

        /// <remarks/>
        M82,

        /// <remarks/>
        M90,

        /// <remarks/>
        M91,

        /// <remarks/>
        M92,

        /// <remarks/>
        M93,

        /// <remarks/>
        M94,

        /// <remarks/>
        M95,

        /// <remarks/>
        M99,

        /// <remarks/>
        NA,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("TransferLocation", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TransferLocation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The sequence in which an off-site transfer is reported on a Form R submission.")]
        public int TransferLocationSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TransferLocationSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the transfer site is a POTW.")]
        public bool POTWIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool POTWIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The physical location of an individual or organization.")]
        public LocationAddress LocationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicator that shows whether the off-site location to which toxic chemicals are t" +
            "ransferred in wastes is owned or controlled by the facility.")]
        public bool ControlledLocationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ControlledLocationIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the Resource Conservat" +
            "ion and Recovery Act (RCRA).")]
        public string RCRAIdentificationNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The EPA Registry Id number assigned to this facility, this is used for internal p" +
            "urposes.")]
        public string EPARegistryIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransferQuantity", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The quantity of material transfered to a receiving facility and how it was treate" +
            "d, recycled ,or otherwise disposed.")]
        public TransferQuantity[] TransferQuantity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("WaterStream", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class WaterStream
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Sequence in which a release to water is reported on a Form R submission.")]
        public int WaterSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WaterSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the stream, river, lake, or other water body to which the chemical is" +
            " discharged.")]
        public string StreamName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The reach code of the stream, river, lake, or other water body to which the chemi" +
            "cal is discharged.")]
        public string StreamReachCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleaseStormWaterNAIndicator", typeof(bool), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("ReleaseStormWaterPercent", typeof(decimal), Order = 3)]
        public object Item;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("OnsiteReleaseQuantity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class OnsiteReleaseQuantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code indicating the environmental medium to which the toxic chemical is released " +
            "from the facility.")]
        public EnvironmentalMediumCode EnvironmentalMediumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Captures a quantity of waste and how the waste quantity was determined by the rep" +
            "orter.")]
        public TransferWasteQuantity OnsiteWasteQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The names of the streams, rivers, lakes, or other water bodies to which the chemi" +
            "cal is discharged and percent of which comes from stormwater.")]
        public WaterStream WaterStream;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("EnvironmentalMediumCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum EnvironmentalMediumCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("AIR FUG")]
        AIRFUG,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("AIR STACK")]
        AIRSTACK,

        /// <remarks/>
        WATER,

        /// <remarks/>
        UNINJ8795,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("UNINJ I")]
        UNINJI,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("UNINJ IIV")]
        UNINJIIV,

        /// <remarks/>
        LANDF8795,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RCRA C")]
        RCRAC,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("OTH LANDF")]
        OTHLANDF,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("LAND TREA")]
        LANDTREA,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SURF IMP")]
        SURFIMP,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SI 5.5.3A")]
        SI553A,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SI 5.5.3B")]
        SI553B,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("OTH DISP")]
        OTHDISP,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalActivitiesAndUses", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class ChemicalActivitiesAndUses
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical is used at the facility for purposes other than as a" +
            " manufacturing aid or chemical processing aid, such as cleaners, degreasers, lub" +
            "ricants, fuels, etc.")]
        public bool ChemicalAncillaryUsageIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalAncillaryUsageIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical becomes an integral part of an article distributed i" +
            "nto commerce.")]
        public bool ChemicalArticleComponentIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalArticleComponentIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical is produced coincidentally during the manufacture, p" +
            "rocess, or otherwise use of another chemical substance or mixture and, following" +
            " its production, is separated from that other chemical substance or mixture.")]
        public bool ChemicalByproductIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalByproductIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical is used as an ingredient in a product mixture to enh" +
            "ance performance of the product during its use.")]
        public bool ChemicalFormulationComponentIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalFormulationComponentIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical was imported into the Customs Territory of the Unite" +
            "d States by the facility.")]
        public bool ChemicalImportedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalImportedIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical is used to aid in the manufacturing process but does" +
            " not come into contact with the product during manufacture.")]
        public bool ChemicalManufactureAidIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalManufactureAidIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Indicator that shows whether the facility produces the reported chemical as a res" +
            "ult of the manufacture, processing, or otherwise use of another chemical.")]
        public bool ChemicalManufactureImpurityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalManufactureImpurityIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicator that shows whether the facility processed the reported chemical but did" +
            " not separate it and it remains as an impurity in the primary the mixture or tra" +
            "de name product.")]
        public bool ChemicalProcessImpurityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalProcessImpurityIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical is used to aid in the manufacture or synthesis of an" +
            "other chemical substance.")]
        public bool ChemicalProcessingAidIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalProcessingAidIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical was created by the facility.")]
        public bool ChemicalProducedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalProducedIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical is used in chemical reactions to create another chem" +
            "ical substance or product that is then sold or otherwise distributed to other fa" +
            "cilities.")]
        public bool ChemicalReactantIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalReactantIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical has been received by the facility and subsequently p" +
            "repared for distribution into commerce in a different form, state, or quantity t" +
            "han it was received.")]
        public bool ChemicalRepackagingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalRepackagingIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical was produced or imported by the facility specificall" +
            "y to be sold or distributed to other outside facilities.")]
        public bool ChemicalSalesDistributionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalSalesDistributionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates the toxic chemical was produced or imported by the facility and then fu" +
            "rther processed or otherwise used at the same facility.")]
        public bool ChemicalUsedProcessedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalUsedProcessedIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicator that shows whether the facility processed the reported chemical through" +
            " recycling.")]
        public bool ChemicalProcessRecyclingIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalProcessRecyclingIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalAncillaryUsageSubcategory", Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A 4-character subcategory code that identifies the activity that uses the chemica" +
            "l for ancillary usage.")]
        public string[] ChemicalAncillaryUsageSubcategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalFormulationComponentSubcategory", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("A 4-character subcategory code that identifies the activity that uses the chemica" +
            "l as a formulation component.")]
        public string[] ChemicalFormulationComponentSubcategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalManufactureAidSubcategory", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("A 4-character subcategory code that identifies the activity that uses the chemica" +
            "l as a manufacture aid.")]
        public string[] ChemicalManufactureAidSubcategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalProcessingAidSubcategory", Order = 18)]
        [System.ComponentModel.DescriptionAttribute("A 4-character subcategory code that identifies the activity that uses the chemica" +
            "l as a processing aid.")]
        public string[] ChemicalProcessingAidSubcategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalReactantSubcategory", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("A 4-character subcategory code that identifies the activity that uses the chemica" +
            "l as a reactant.")]
        public string[] ChemicalReactantSubcategory;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalIdentification", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class ChemicalIdentification
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique number assigned by Chemical Abstracts Service (CAS) to a chemical subs" +
            "tance.")]
        public string CASNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the toxic chemical. If reporting for a chemical category, then the ch" +
            "emical category name should be used.")]
        public string ChemicalNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The generic chemical name provided by the supplier.")]
        public string ChemicalMixtureNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The metal compound form includes release totals for both the metal compound and e" +
            "lemental metal.")]
        public bool MetalCompoundReportIncludeElementalMetalIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MetalCompoundReportIncludeElementalMetalIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The lead report EXCEEDS the 100 lb threshold for lead not contained in stainless " +
            "steel, brass, or bronze allows (i.e., triggers PBT reporting threshold).")]
        public bool LeadExceedsThresholdIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LeadExceedsThresholdIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The unique number assigned to all chemical substances and chemical groupings for " +
            "which a CAS Registry Number does not exist and cannot be assigned.")]
        public string EPAChemicalIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The name that the Environmental Protection Agency has selected as its preferred n" +
            "ame for a chemical substance.")]
        public string EPAChemicalRegistryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The type of source for the Environmental Protection Agency chemical registry name" +
            ".")]
        public string EPAChemicalRegistryNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,6,7,8-Heptachlorodibenzofuran " +
            "(CAS Number: 67562-39-4) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution1Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution1PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,7,8,9-Heptachlorodibenzofuran " +
            "(CAS Number: 55673-89-7) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution2Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution2PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,7,8-Hexachlorodibenzofuran (CA" +
            "S Number: 70648-26-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution3Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution3PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,6,7,8-Hexachlorodibenzofuran (CA" +
            "S Number: 57117-44-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution4Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution4PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,7,8,9-Hexachlorodibenzofuran (CA" +
            "S Number: 72918-21-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution5Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution5PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 2,3,4,6,7,8-Hexachlorodibenzofuran (CA" +
            "S Number: 60851-34-5) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution6Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution6PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,7,8-Hexachlorodibenzo-p-dioxin" +
            " (CAS Number: 39227-28-6) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution7Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution7PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,6,7,8-Hexachlorodibenzo-p-dioxin" +
            " (CAS Number: 57653-85-7) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution8Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution8PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,7,8,9-Hexachlorodibenzo-p-dioxin" +
            " (CAS Number: 19408-74-3) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution9Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution9PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,6,7,8-Heptachlorodibenzo-p-dio" +
            "xin (CAS Number: 35822-46-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution10Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution10PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,6,7,8,9-Octachlorodibenzofuran" +
            " (CAS Number: 39001-02-0) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution11Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution11PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,4,6,7,8,9-Octachlorodibenzo-p-di" +
            "oxin (CAS Number: 03268-87-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution12Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution12PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,7,8-Pentachlorodibenzofuran (CAS" +
            " Number: 57117-41-6) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution13Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution13PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 2,3,4,7,8-Pentachlorodibenzofuran (CAS" +
            " Number: 57117-31-4) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution14Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution14PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 1,2,3,7,8-Pentachlorodibenzo-p-dioxin " +
            "(CAS Number: 40321-76-4) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution15Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution15PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 2,3,7,8-Tetrachlorodibenzofuran (CAS N" +
            "umber: 51207-31-9) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution16Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution16PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("Indicates the distribution (percentage) of 2,3,7,8-Tetrachlorodibenzo-p-dioxin (C" +
            "AS Number: 01746-01-6) in the reported dioxin or dioxin-like compounds.")]
        public decimal DioxinDistribution17Percent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistribution17PercentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether \'NA\' (Not Applicable) was entered on the Form R for the Distrib" +
            "ution of Each Member of the Dioxin and Dioxin-like Compounds Category.")]
        public bool DioxinDistributionNAIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DioxinDistributionNAIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ReportValidation", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class ReportValidation
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The name of the organization which created the validation error, warning or comme" +
            "nt.")]
        public string ValidationEntityNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code corresponding to a error, warning or comment.")]
        public string ValidationMessageCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The description of the error, warning or comment.")]
        public string ValidationMessageText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the severity of the error reported from TRIMEweb or TRIPS.")]
        public EPAErrorSeverityCode EPAErrorSeverityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAErrorSeverityCodeSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("EPAErrorSeverityCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum EPAErrorSeverityCode
    {

        /// <remarks/>
        NOSE,

        /// <remarks/>
        NOTE,

        /// <remarks/>
        NON,

        /// <remarks/>
        Possible,

        /// <remarks/>
        DQA,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Facility identification data.")]
        Facility,

        /// <remarks/>
        Critical,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ReportMetaData", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class ReportMetaData
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The postmark date for this submission (if by mail).")]
        public System.DateTime ReportPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportPostmarkDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The actual date the report was received by the report recipient.")]
        public System.DateTime ReportReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The original postmark date for a submission for this chemical from this facility " +
            "and this reporting year. Applies to revisions only.")]
        public System.DateTime ReportOriginalPostmarkDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportOriginalPostmarkDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The original received date for a submission for this chemical from this facility " +
            "and this reporting year. Applies to revisions only.")]
        public System.DateTime ReportOriginalReceivedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportOriginalReceivedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The means by which the report was transmitted to the EPA from a reporting facilit" +
            "y.")]
        public ReportSubmissionMethodCode ReportSubmissionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportSubmissionMethodCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the report has passed EPA validation.")]
        public bool EPAPassedValidationIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAPassedValidationIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The EPA processing status of the submission: -1 = unknown 0 = inactive submission" +
            " 1 = active submission 2 = submission needs manual review 3 = hold active 4 = ho" +
            "ld inactive 5 = withdrawn 6 = inactive withdrawal")]
        public EPAProcessingStatusCode EPAProcessingStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EPAProcessingStatusCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the data in the XML TRI report has not been altered, representing " +
            "an original TRI submission from a reporting facility.")]
        public bool UnalteredReportIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnalteredReportIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The method the facility used to create the form: 1 = import form using a XML file" +
            " 2 = import data from the TRIPS prior year form 3 = direct data entry in TRIMEwe" +
            "b")]
        public FormPreparationMethod FormPreparationMethod;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FormPreparationMethodSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportValidation", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Errors, warnings or comments which resulted from validating the contents of the T" +
            "RI report.")]
        public ReportValidation[] ReportValidation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("ReportSubmissionMethodCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum ReportSubmissionMethodCode
    {

        /// <remarks/>
        MAIL,

        /// <remarks/>
        CDX_WEB,

        /// <remarks/>
        TRIME_WEB,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("EPAProcessingStatusCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum EPAProcessingStatusCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("-1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("FormPreparationMethod", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum FormPreparationMethod
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("TRIComment", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TRIComment
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates the sequence of the comment.")]
        public int TRICommentSequence;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TRICommentSequenceSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the section of the comment data.")]
        public string TRICommentSection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the type of the comment data.")]
        public string TRICommentType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Full version of the comment type")]
        public string TRICommentTypeDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Narrative provided by the facility as optional comment data.")]
        public string TRICommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Indicates the P2 classification of the comment text.")]
        public string TRICommentP2Classification;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("Report", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class Report
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Data which supplements the information in a TRI report, such as the result of dat" +
            "a processing operations by the receiver.")]
        public ReportMetaData ReportMetaData;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The unique tracking number or name assigned by a system or program that identifie" +
            "s a report.")]
        public ReportIdentifier[] ReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReplacedReportIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The previous Report Identifier this report intends to replace (for revision only)" +
            ".")]
        public string[] ReplacedReportIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to identify a type of report.")]
        public ReportType ReportType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The year for which the form was submitted.")]
        public string SubmissionReportingYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The date that the report is due to the report recipient.")]
        public System.DateTime ReportDueDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReportDueDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("An indicator to show whether the report is an original submission or a revision.")]
        public RevisionIndicator RevisionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RevisionIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Indicator that shows whether the identity of the toxic chemical has been claimed " +
            "a trade secret.")]
        public bool ChemicalTradeSecretIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ChemicalTradeSecretIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicator that shows whether the submission \'Sanitized Trade Secret\' box was chec" +
            "ked by the submitter.")]
        public bool SubmissionSanitizedIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionSanitizedIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The name of the owner, operator, or senior management official who is certifying " +
            "the submission.")]
        public string CertifierName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The title of the owner, operator, or senior management official who is certifying" +
            " the submission.")]
        public string CertifierTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The date that the senior management official signed the certification statement.")]
        public System.DateTime CertificationSignedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CertificationSignedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Indicates that only one Form R was filed for this chemical for the entire facilit" +
            "y.")]
        public bool SubmissionEntireFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionEntireFacilityIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Indicates that the facility has chosen to report by establishment or groups of es" +
            "tablishments.")]
        public bool SubmissionPartialFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionPartialFacilityIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the \'Federal\' box was checked on the submission.")]
        public SubmissionFederalFacilityIndicator SubmissionFederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionFederalFacilityIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the \'GOCO\' box was checked on the submission.")]
        public bool SubmissionGOCOFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionGOCOFacilityIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The name of the technical contact for the TRI report.")]
        public TechnicalContactNameText TechnicalContactNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The phone number of the technical contact for the TRI report.")]
        public string TechnicalContactPhoneText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The phone extension number of the technical contact for the TRI report.")]
        public string TechnicalContactPhoneExtText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The email address of the technical contact for the TRI report.")]
        public string TechnicalContactEmailAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("The name of the public contact for the TRI report.")]
        public TechnicalContactNameText PublicContactNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("The phone number of the public contact for the TRI report.")]
        public string PublicContactPhoneText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("The phone extension number of the public contact for the TRI report.")]
        public string PublicContactPhoneExtText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("The email address of the public contact for the TRI report.")]
        public string PublicContactEmailAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalReportRevisionCode", Order = 24)]
        [System.ComponentModel.DescriptionAttribute("The three character code indicating revisions to the TRI report.")]
        public string[] ChemicalReportRevisionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalReportWithdrawalCode", Order = 25)]
        [System.ComponentModel.DescriptionAttribute("The three character code indicating withdrawals from the TRI report.")]
        public string[] ChemicalReportWithdrawalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalIdentification", Order = 26)]
        [System.ComponentModel.DescriptionAttribute("Identification of the chemical (for Form R) or chemicals (for Form A) on the TRI " +
            "reporting form.")]
        public ChemicalIdentification[] ChemicalIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("The type of manufacturing activity of the toxic chemical at the facility as repor" +
            "ted on EPA Form R.")]
        public ChemicalActivitiesAndUses ChemicalActivitiesAndUses;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 28)]
        [System.ComponentModel.DescriptionAttribute("The two digit code indicating a range for the maximum amount of the chemical pres" +
            "ent at the facility at any one time during the calendar year.")]
        public MaximumChemicalAmountCode MaximumChemicalAmountCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaximumChemicalAmountCodeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnsiteReleaseQuantity", Order = 29)]
        [System.ComponentModel.DescriptionAttribute("The total annual release quantities of the chemical to air, water, on-site land, " +
            "and underground injection wells.")]
        public OnsiteReleaseQuantity[] OnsiteReleaseQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 30)]
        [System.ComponentModel.DescriptionAttribute("Indicates that part of the land releases went to waste rock piles.")]
        public bool WasteRockManagedPileIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WasteRockManagedPileIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 31)]
        [System.ComponentModel.DescriptionAttribute("The total amount of the toxic chemical that is in the waste rock pile.")]
        public decimal WasteRockQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WasteRockQuantitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("POTWWasteQuantity", Order = 32)]
        [System.ComponentModel.DescriptionAttribute("Total quantity of waste transfered to POTWs and basis of quantity determination.")]
        public POTWWasteQuantity[] POTWWasteQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransferLocation", Order = 33)]
        [System.ComponentModel.DescriptionAttribute("Identification of off-site locations including Publicly Owned Treatment Works (PO" +
            "TW) to which the chemical in wastes are transferred.")]
        public TransferLocation[] TransferLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteTreatmentDetails", typeof(WasteTreatmentDetailsDataType), Order = 34)]
        [System.Xml.Serialization.XmlElementAttribute("WasteTreatmentNAIndicator", typeof(bool), Order = 34)]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 35)]
        [System.ComponentModel.DescriptionAttribute("The on-site energy recovery methods used on the chemical.")]
        public OnsiteRecoveryProcess OnsiteRecoveryProcess;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 36)]
        [System.ComponentModel.DescriptionAttribute("The on-site recycling methods used on the chemical.")]
        public OnsiteRecyclingProcess OnsiteRecyclingProcess;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 37)]
        [System.ComponentModel.DescriptionAttribute("Annual quantities of the chemical associated with all source reduction and recycl" +
            "ing activities.")]
        public SourceReductionQuantity SourceReductionQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SourceReductionActivity", typeof(SourceReductionActivityDataType), Order = 38)]
        [System.Xml.Serialization.XmlElementAttribute("SourceReductionNAIndicator", typeof(bool), Order = 38)]
        public object[] Items1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 39)]
        [System.ComponentModel.DescriptionAttribute(@"For reporting years beginning in 1991, the indicator that shows whether additional optional information on source reduction, pollution control, or recycling activities implemented during the reporting year or prior years has been attached to the submission.")]
        public bool SubmissionAdditionalDataIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionAdditionalDataIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 40)]
        [System.ComponentModel.DescriptionAttribute("Narrative describing additional activities performed by the reporting facility. A" +
            "dded for RY2005.")]
        public string OptionalInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 41)]
        [System.ComponentModel.DescriptionAttribute("Indicates the category of the optional text provided.")]
        public string OptionalInformationCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 42)]
        [System.ComponentModel.DescriptionAttribute("Narrative describing miscellaneous information about the reporting facility. Adde" +
            "d for RY2011.")]
        public string MiscellaneousInformationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 43)]
        [System.ComponentModel.DescriptionAttribute("Indicates the category of the miscellaneous text provided.")]
        public string MiscellaneousInformationCategory;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TRIComment", Order = 44)]
        [System.ComponentModel.DescriptionAttribute("Comments collected to supplement data entered on the TRI forms.")]
        public TRIComment[] TRIComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ReportIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ReportIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("RevisionIndicator", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum RevisionIndicator
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionFederalFacilityIndicator", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum SubmissionFederalFacilityIndicator
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TechnicalContactNameText", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TechnicalContactNameText
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify an individual within a context.")]
        public IndividualIdentifier IndividualIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The text that describes the title that precedes an individual\'s name.")]
        public string NamePrefixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FirstName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("IndividualFullName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("LastName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("MiddleName", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 4)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsElementName[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Additional title that indicates lineage or professional title.")]
        public string NameSuffixText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class IndividualIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IndividualIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0", IncludeInSchema = false)]
    public enum ItemsElementName
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
        FirstName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The complete name of a person, potentially including first name, middle name or i" +
            "nitial, and or surname.")]
        IndividualFullName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
        LastName,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
        MiddleName,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("MaximumChemicalAmountCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum MaximumChemicalAmountCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("18")]
        Item18,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("20")]
        Item20,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("POTWWasteQuantity", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class POTWWasteQuantity
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The sequence in which a POTW is reported on a Form R submission.")]
        public int POTWSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool POTWSequenceNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityCatastrophicMeasure", typeof(decimal), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityMeasure", typeof(decimal), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityNAIndicator", typeof(bool), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeCode", typeof(WasteQuantityRangeCodeType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeNumericBasisValue", typeof(decimal), Order = 1)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 2)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsElementName[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationCode", typeof(QuantityBasisEstimationCodeType), Order = 3)]
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationNAIndicator", typeof(bool), Order = 3)]
        public object Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identification of the toxic equivalency (for Form R Schedule-1) for dioxin and di" +
            "oxin-like chemicals.")]
        public ToxicEquivalencyIdentification ToxicEquivalencyIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The percent of the Section 6.1 quantity that was ultimately disposed in a Class I" +
            " UIC or landfill.")]
        public decimal QuantityDisposedLandfillPercentValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityDisposedLandfillPercentValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The percent of the Section 6.1 quantity that was ultimately otherwise disposed or" +
            " released.")]
        public decimal QuantityDisposedOtherPercentValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityDisposedOtherPercentValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The percent of the Section 6.1 quantity that was ultimately treated.")]
        public decimal QuantityTreatedPercentValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityTreatedPercentValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The transfer type code for the POTW, this code defines the ultimate disposition o" +
            "f toxic chemicals at POTWs.")]
        public string POTWTransferTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The sequence of the POTW Transfer location that corresponds to the POTW amount an" +
            "d transfer type code.")]
        public int POTWTransferSequenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool POTWTransferSequenceNumberSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IncludeInSchema = false)]
    public enum ItemsElementName
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Non-production value due to catastrophic events, used in calculating Section 8 va" +
            "lues.")]
        WasteQuantityCatastrophicMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The total amount (in pounds) of the toxic chemical transferred from the reporting" +
            " facility to the receiving facility. For dioxin or dioxin-like compunds, report " +
            "in grams/year.")]
        WasteQuantityMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Indicates that \'NA\' (Not Applicable) was entered on the Form R for the quantity t" +
            "otal transfers.")]
        WasteQuantityNAIndicator,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Code that corresponds to the amount of toxic chemical released annually by the re" +
            "porting facility.")]
        WasteQuantityRangeCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("A decimal value used during calculations for a Waste Quantity that was reported u" +
            "sing a range code.")]
        WasteQuantityRangeNumericBasisValue,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("CertifierSignatureTypeCode", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public enum CertifierSignatureTypeCodeType
    {

        /// <remarks/>
        O,

        /// <remarks/>
        P,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("TRI", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TRIDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Submission", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A container for one or more TRI Reports for a given facility.")]
        public Submission[] Submission;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("Submission", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class Submission
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A number used to uniquely identify a TRI submission, which contains data for one " +
            "facility and one or more chemicals.")]
        public TRISubmissionIdentifier TRISubmissionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Facility identification data.")]
        public Facility Facility;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Report", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A TRI Form R or Form A Report instance.")]
        public Report[] Report;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/TRI/6")]
    [System.Xml.Serialization.XmlRootAttribute("TRISubmissionIdentifier", Namespace = "http://www.exchangenetwork.net/schema/TRI/6", IsNullable = false)]
    public partial class TRISubmissionIdentifier
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubmissionIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AccreditationAuthorityIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AccreditationAuthorityIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AccreditationAuthorityIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationStatusText", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum AffiliationStatusTextDataType
    {

        /// <remarks/>
        A,

        /// <remarks/>
        I,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AgencyCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AgencyTypeCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalGroupName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalGroupNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalGroupNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSynonymName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalSynonymNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalSynonymNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSystematicName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalSystematicNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalSystematicNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalVernacularName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalVernacularNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BiologicalVernacularNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ComplianceMilestoneIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComplianceMilestoneIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneStatusText", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum ComplianceMilestoneStatusTextDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Implemented by Due Date(s)")]
        ImplementedbyDueDates,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Implemented by Determination Date, but Later than Due Date(s)")]
        ImplementedbyDeterminationDatebutLaterthanDueDates,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Not Implemented by Due Date(s) or Determination Date")]
        NotImplementedbyDueDatesorDeterminationDate,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ComplianceMilestoneTypeCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneViolationResponseIndicator", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum ComplianceMilestoneViolationResponseIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ComplianceScheduleIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ComplianceScheduleIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIndicator", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum ComplianceScheduleIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ConditionIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ConditionIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ConditionIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddressTypeName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public enum ElectronicAddressTypeName
    {

        /// <remarks/>
        Email,

        /// <remarks/>
        Internet,

        /// <remarks/>
        Intranet,

        /// <remarks/>
        HTTP,

        /// <remarks/>
        FTP,

        /// <remarks/>
        Telnet,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementActionIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class EnforcementActionIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EnforcementActionIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityManagementTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class FacilityManagementTypeCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class FacilitySiteTypeCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FormIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class FormIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("InjunctiveReliefIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class InjunctiveReliefIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InjunctiveReliefIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("LaboratoryIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class LaboratoryIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LaboratoryIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MonitoringLocationIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MonitoringLocationIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class OrganizationIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OrganizationIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OtherPermitIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class OtherPermitIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OtherPermitIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PenaltyIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PenaltyIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PenaltyIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermitIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PermitIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermittedFeatureIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermittedFeatureIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PermittedFeatureIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermitTypeCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class SubstanceIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubstanceIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class SubstanceNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubstanceNameContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationIdentifer", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ViolationIdentiferDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ViolationIdentiferContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ViolationTypeCodeListIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ElectronicAddress", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
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
        public ElectronicAddressTypeName ElectronicAddressTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElectronicAddressTypeNameSpecified;
    }
}
