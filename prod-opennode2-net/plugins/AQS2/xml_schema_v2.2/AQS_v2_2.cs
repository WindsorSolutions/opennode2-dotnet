#if V_2_2
namespace Windsor.Node2008.WNOSPlugin.AQS2
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class AddressPostalCodeDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class FacilitySiteIdentifierDataType
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("SiteIdentifierDetails", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class SiteIdentifierDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CountyCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NonStateCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("StateCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("TribalCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a governmental entity to identify a faci" +
            "lity site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySiteIdentifierDataType FacilitySiteIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The code that represents the county.")]
        CountyCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Geographic identifier used for site locations not applicable to states or territo" +
            "ries.")]
        NonStateCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a principal administrative subdivision of the " +
            "United States, Canada, or Mexico.")]
        StateCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian tribe or Alaskan Native entity.")]
        TribalCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("ActionCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum ActionCodeType
    {

        /// <remarks/>
        D,

        /// <remarks/>
        I,

        /// <remarks/>
        U,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("LandUseIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum LandUseType
    {

        /// <remarks/>
        AGRICULTURAL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("BLIGHTED AREAS")]
        BLIGHTEDAREAS,

        /// <remarks/>
        COMMERCIAL,

        /// <remarks/>
        DESERT,

        /// <remarks/>
        FOREST,

        /// <remarks/>
        INDUSTRIAL,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("MILITARY RESERVATION")]
        MILITARYRESERVATION,

        /// <remarks/>
        MOBILE,

        /// <remarks/>
        RESIDENTIAL,

        /// <remarks/>
        UNKNOWN,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("LocationSettingIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum LocationSettingIdentifierType
    {

        /// <remarks/>
        RURAL,

        /// <remarks/>
        SUBURBAN,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("URBAN AND CENTER CITY")]
        URBANANDCENTERCITY,

        /// <remarks/>
        UNKNOWN,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteDetails", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class FacilitySiteDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies the agency responsible for the operation of the monitoring site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SupportAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic) location of the front door o" +
            "r main entrance of a facility site, including urban-style street address or rura" +
            "l address.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The city within whose legal boundaries the monitoring site is located.")]
        public string CityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.")]
        public AddressPostalCodeDataType AddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identification code used by a State, Tribe or Local agency, if different from the" +
            " AQS Site ID.")]
        public string LocalIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The locally defined name of the site.")]
        public string LocalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The state-specific geographic/administrative area within which the site is locate" +
            "d.")]
        public string LocalRegionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute(@"The urbanized area within which the monitoring site is located. An urbanized area is a U.S. Census Bureau demographic entity that comprises a place and the adjacent densely-settled surrounding territory that together have a minimum population of 50,000 people.")]
        public string UrbanAreaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Specifies in which of the 247 Air Quality Control Regions (AQCRs) the monitoring " +
            "site is located.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AQCRCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Categorization of the prevalent land use within 1/4 mile of the monitoring site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LandUseIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A description of the environmental setting within which the site is located.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationSettingIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The date on which an air monitoring site began collecting air quality data.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SiteEstablishedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The date on which a monitoring site ceased to operate.")]
        public string SiteTerminatedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The Congressional district within which the site is located.")]
        public string CongressionalDistrictCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The U.S. Census Bureau block within which the site is located.")]
        public string CensusBlockCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The U.S. Census Bureau block group within which the site is located.")]
        public string CensusBlockGroupCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The U.S. Census Bureau census tract/block numbering area within which the site is" +
            " located.")]
        public string CensusTractCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute(@"The Class One Area within which the site is located. A Class One Area is a geographic area recognized by EPA as being of the highest environmental quality and requiring maximum protection.  These lands generally consist of national wildernesses (Forest Service), parks (National Park Service) and wildlife refuges (U.S. Fish & Wildlife Service) in existence at the time the 1977 Clean Air Act Amendment was passed.")]
        public string ClassIAreaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The date on which the most recent headquarters (HQ) evaluation of the site occurr" +
            "ed.")]
        public string HQEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The date on which the most recent regional evaluation of the site for siting crit" +
            "eria occurred.")]
        public string RegionalEvaluationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("A representation of the true, as opposed to magnetic, direction of the site from " +
            "the central business district. If the site is within the central business distri" +
            "ct, it is a representation of the direction the probe faces.")]
        public string DirectionFromCityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("The distance, in kilometers, to the site from the center of the downtown central " +
            "business district of the city in which the site is located.")]
        public string DistanceFromCityMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("The AQS Site ID where meteorological data is collected, if not collected at this " +
            "site.")]
        public string MetSiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("The type of meteorological station identified for the monitoring site. Required f" +
            "or sites with monitors in a Photochemical Assessment Monitoring System (PAMS) ne" +
            "twork.")]
        public string MetSiteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute(@"The distance of the associated meteorological site from the air quality monitoring site, in meters. This information is required if the site has monitors that are part of a Photochemical Assessment Monitoring System (PAMS) network. The associated site need not be an AQS site.")]
        public string DistanceToMetSiteMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("A representation of the true, as opposed to magnetic, direction of the meteorolog" +
            "ical site from this site.")]
        public string DirectionToMetSiteCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("DirectionFromCityCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum CompassSectorCodeType
    {

        /// <remarks/>
        E,

        /// <remarks/>
        ENE,

        /// <remarks/>
        ESE,

        /// <remarks/>
        N,

        /// <remarks/>
        NE,

        /// <remarks/>
        NNE,

        /// <remarks/>
        NNW,

        /// <remarks/>
        NW,

        /// <remarks/>
        S,

        /// <remarks/>
        SE,

        /// <remarks/>
        SSE,

        /// <remarks/>
        SSW,

        /// <remarks/>
        SW,

        /// <remarks/>
        W,

        /// <remarks/>
        WNW,

        /// <remarks/>
        WSW,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MetSiteTypeCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum MetSiteTypeCodeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("ON-SITE MET EQUIP")]
        ONSITEMETEQUIP,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("ON-SITE UA MET")]
        ONSITEUAMET,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("OTHER AIRS SITE")]
        OTHERAIRSSITE,

        /// <remarks/>
        NWS,

        /// <remarks/>
        AIRPORT,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicMonitoringLocation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class GeographicMonitoringLocationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LatitudeMeasure", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("LongitudeMeasure", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("UTMEastingMeasure", typeof(decimal), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("UTMNorthingMeasure", typeof(decimal), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("UTMZoneCode", typeof(string), DataType = "positiveInteger", Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The code indicating the method used to determine the latitude and longitude.  E.g" +
            "., map interpolation, GPS.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The edition of North American Datum used as the basis for determining the site co" +
            "ordinates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalReferenceDatumName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Description of the accuracy of the site coordinates, as a range reported in meter" +
            "s. Only the least accurate measurement needs to be recorded, whether it is latit" +
            "ude or longitude (or UTM easting or northing).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The elevation, in meters, above or below mean sea level (MSL) of the site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string VerticalMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The method used to determine the Locational Data Policy (LDP) vertical measure.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string VerticalMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The edition of North American Datum used as the basis for determining the site co" +
            "ordinates.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string VerticalDatumIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Description of the accuracy of the Vertical Measure, reported in meters.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string VerticalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A standard time zone, as established by section 1 of the Standard Time Act, as am" +
            "ended by section 4 of the Uniform Time Act of 1966 (15 U.S.C. 261).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TimeZoneName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        LatitudeMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        LongitudeMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The easting UTM coordinate, expressed in meters (i.e., the horizontal distance fr" +
            "om the reference edge of the UTM zone) for the site.")]
        UTMEastingMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The northing UTM coordinate expressed in meters (i.e., for the Northern hemispher" +
            "e, the vertical distance from the equator; for the Southern hemisphere, 10,000,0" +
            "00 minus the vertical distance from the equator) for the site.")]
        UTMNorthingMeasure,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute(@"The zone of the universal transverse Mercator (UTM) system in which a site is located. EPA Locational Data Policy requires that coordinates be provided for all sites. AQS will convert the UTM coordinates to latitude/longitude, and store both UTM and latitude/longitude.")]
        UTMZoneCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("TimeZoneName", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum TimeZoneNameType
    {

        /// <remarks/>
        ATLANTIC,

        /// <remarks/>
        EASTERN,

        /// <remarks/>
        CENTRAL,

        /// <remarks/>
        MOUNTAIN,

        /// <remarks/>
        PACIFIC,

        /// <remarks/>
        ALASKA,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("HAWAII-ALEUTIAN")]
        HAWAIIALEUTIAN,

        /// <remarks/>
        GUAM,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("BasicSiteInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class BasicSiteInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to the description of the surroundings of an air quality site (facility).")]
        public FacilitySiteDetailsType FacilitySiteDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to the latitude and longitude of a monitoring site.")]
        public GeographicMonitoringLocationType GeographicMonitoringLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RoadInfluences", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RoadInfluencesType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the number of the street around the site for which the data are being " +
            "submitted. Street number is used to associate detailed street information for th" +
            "e site to streets closest to the monitors at this site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TangentStreetNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the name of the street around the site for which the data are being su" +
            "bmitted.")]
        public string TangentStreetName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The type of road or street being described.")]
        public string RoadTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("An estimate of the daily traffic volume on the roadway.")]
        public string TrafficCountValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The year when the traffic count value was estimated.")]
        public string TrafficCountYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The direction from the site to the street at its nearest point.")]
        public string DirectionToStreetCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The method by which the traffic volume/flow count was obtained.")]
        public string TrafficCountSourceCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("OpenPathMonitoringLocation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class OpenPathMonitoringLocationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An indication that this monitor uses an open path methodology.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OpenPathIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The direction from the receiver to the transmitter at the site.")]
        public string DirectionToTransmitterCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The length of the beam projected between the transmitter and the receiver at the " +
            "site, in meters.")]
        public string BeamLengthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The height of the transmitter above the ground, in meters.")]
        public string TransmitterHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The height of the receiver above the ground, in meters.")]
        public string ReceiverHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The height of the beam (at the lowest point from the ground) being projected betw" +
            "een the receiver and transmitter at the site, in meters.")]
        public string BeamMinimumHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The height of the beam (at the highest point from the ground) being projected bet" +
            "ween the receiver and transmitter at the site, in meters")]
        public string BeamMaximumHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A description of how the area around (and under) and open path monitor is used.")]
        public string OpenPathLocationLandUseText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorIdentifierDetails", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorIdentifierDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A designator used to uniquely identify a substance.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public SubstanceIdentifierDataType SubstanceIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Another name for Parameter Occurrence Code (POC).  If there are multiple monitors" +
            " for the same substance at a single site, each monitor must have a unique substa" +
            "nce occurrence code.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SubstanceOccurrenceCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("BasicMonitoringInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class BasicMonitoringInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code for the type of sampling performed by the monitor.")]
        public string ProjectClassCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The primary source of the pollutant being measured.")]
        public string DominantSourceText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The geographic scope of the air quality measurements made by the monitor.")]
        public string MeasurementScaleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("An indication that this monitor uses an open path methodology.")]
        public string OpenPathIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The location of the sampling probe.")]
        public string ProbeLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The height of the sampling probe from the ground in meters.")]
        public string ProbeHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The horizontal distance, in meters, of the probe from its supports.")]
        public string HorizontalDistanceMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The vertical distance, in meters, of the probe from its supports.")]
        public string VerticalDistanceMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether a Total Suspended Particulate (TSP) monitor serves as a surroga" +
            "te monitor for PM-10.")]
        public string SurrogateIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Indication of whether the flow of air to the monitor is restricted.")]
        public string UnrestrictedAirFlowIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Sample Residence Time is how long it takes for the air to move from the probe to " +
            "the sampling device via conduits/tubing, in seconds.")]
        public string SampleResidenceTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 12)]
        [System.ComponentModel.DescriptionAttribute(@"Within a particular monitoring area, those monitors with the highest PM-10 concentrations must have their worst site type set to ""1"", and are expected to monitor at the recommended collection frequency. Other monitors must be classified as either: ""2"", not worst site monitors; or ""3"", monitoring on an accelerated schedule, but not at the recommended collection frequency.")]
        public string WorstSiteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The applicable NAAQS (National Ambient Air Quality Standards) indicator determine" +
            "s whether the data from a monitor in a monitor planning area should be compared " +
            "to either the short-term or annual NAAQS, or both.")]
        public string ApplicableNAAQSIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether spatial averaging is to be performed for the individual annual " +
            "weighted means for sites that are flagged and in the same community monitoring z" +
            "one.")]
        public string SpatialAverageIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the sampling schedule differs from that required by the standar" +
            "d by approval of the Regional Administrator")]
        public string ScheduleExemptionIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("A sequential number assigned to an optional averaging area with an established, d" +
            "efined boundary within a monitor planning area that has a relatively uniform con" +
            "centration of annual PM-2.5. Community monitoring zones do not cross geographica" +
            "l lines.")]
        public string CommunityMonitoringZoneCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PollutantAreaCode", Order = 17)]
        [System.ComponentModel.DescriptionAttribute(@"Designation of pollutant areas to which the monitor is assigned. Using these fields, up to five pollutant areas can be designated for an individual monitor. Pollutant areas are geographic areas defined by a program office in which a certain pollutant should be closely watched. Most are problem or non-attainment areas, but attainment areas requiring special attention may also be defined. Types of pollutant areas are status areas, monitoring areas, and monitor planning areas.")]
        public string[] PollutantAreaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The date that a monitor ceased to collect data.")]
        public string MonitorCloseDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("DominantSourceText", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum DominantSourceIdentifierType
    {

        /// <remarks/>
        POINT,

        /// <remarks/>
        AREA,

        /// <remarks/>
        MOBILE,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MeasurementScaleIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum MeasurementScaleIdentifierType
    {

        /// <remarks/>
        MICROSCALE,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("MIDDLE SCALE")]
        MIDDLESCALE,

        /// <remarks/>
        NEIGHBORHOOD,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("URBAN SCALE")]
        URBANSCALE,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("REGIONAL SCALE")]
        REGIONALSCALE,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("ProbeLocationCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum ProbeLocationCodeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GROUND LEVEL SUPPORT")]
        GROUNDLEVELSUPPORT,

        /// <remarks/>
        POLE,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SIDE OF BUILDING")]
        SIDEOFBUILDING,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TOP OF BUILDING")]
        TOPOFBUILDING,

        /// <remarks/>
        TOWER,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("SurrogateIndicator", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum YesNoIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("UnrestrictedAirFlowIndicator", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum YesNoWaivedIndicatorType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        W,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("ApplicableNAAQSIndicator", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum NAAQSInicatorType
    {

        /// <remarks/>
        S,

        /// <remarks/>
        A,

        /// <remarks/>
        B,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorSamplingPeriod", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorSamplingPeriodType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date on which a distinct period of operations, i.e., collection of air qualit" +
            "y samples, began for the monitor.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SamplingBeginDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which a distinct period of operations, i.e., collection of air qualit" +
            "y samples, stopped for the monitor.")]
        public string SamplingEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorTypeInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorTypeInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 1)]
        [System.ComponentModel.DescriptionAttribute(@"An administrative classification for the monitor roughly indicating the monitoring network to which the monitor belongs.  A monitor may have more than one type, and there is usually only one space to indicate this information in reports, so a hierarchy is used to select the most prevalent type for inclusion.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the monitor type assignment went into effect.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitorTypeBeginDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which a monitor type assignment ends.")]
        public string MonitorTypeEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorAgencyRole", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorAgencyRoleType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that describes the capacity or function that an organization or individu" +
            "al serves; or the relationship between an individual or organization and a proje" +
            "ct or action.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AffiliationTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a federal, state, or local agency.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action began.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AffiliationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action ended.")]
        public string AffiliationEndDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorObjectiveInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorObjectiveInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identification of the reason for measuring air quality by the monitor.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MonitorObjectiveIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CBSARepresentedCode", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("CMSARepresentedCode", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("CSARepresentedCode", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("MSARepresentedCode", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlElementAttribute("UrbanAreaRepresentedCode", typeof(string), Order = 2)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorObjectiveIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum MonitorObjectiveIdentifierType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("EXTREME DOWNWIND")]
        EXTREMEDOWNWIND,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("GENERAL/BACKGROUND")]
        GENERALBACKGROUND,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("HIGHEST CONCENTRATION")]
        HIGHESTCONCENTRATION,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("INVALID CODE TEST")]
        INVALIDCODETEST,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("MAX OZONE CONCENTRATION")]
        MAXOZONECONCENTRATION,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("MAX PRECURSOR EMISSIONS IMPACT")]
        MAXPRECURSOREMISSIONSIMPACT,

        /// <remarks/>
        OTHER,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("POPULATION EXPOSURE")]
        POPULATIONEXPOSURE,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("REGIONAL TRANSPORT")]
        REGIONALTRANSPORT,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("SOURCE ORIENTED")]
        SOURCEORIENTED,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("UPWIND BACKGROUND")]
        UPWINDBACKGROUND,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("WELFARE RELATED IMPACTS")]
        WELFARERELATEDIMPACTS,

        /// <remarks/>
        UNKNOWN,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The Core Based Statistical Area (CBSA) from which the concentrations originated, " +
            "not the location of the monitor.")]
        CBSARepresentedCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The Consolidated Metropolitan Statistical Area (CMSA) from which the concentratio" +
            "ns originated, not the location of the monitor.")]
        CMSARepresentedCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The Combined Statistical Area (CSA) from which the concentrations originated, not" +
            " the location of the monitor.")]
        CSARepresentedCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The Metropolitan Statistical Area (MSA) from which the concentrations originated," +
            " not the location of the monitor.")]
        MSARepresentedCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The urbanized area from which the concentrations originated (not the location of " +
            "the monitor).")]
        UrbanAreaRepresentedCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorSamplingSchedule", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorSamplingScheduleType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The required collection frequency (RCF) is mandatory for both Photochemical Asses" +
            "sment Monitoring System (PAMS) regulations for organic compounds and PM-2.5 or P" +
            "M-10 monitors.")]
        public string FrequencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the required collection frequency (RCF) went into effect.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string RCFBeginDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the required collection frequency (RCF) ended.")]
        public string RCFEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFJanuaryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFFebruaryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFMarchCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFAprilCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFMayCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFJuneCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFJulyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFAugustCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFSeptemberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFOctoberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "orÆs required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFNovemberCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Specifies the collection frequency required within an indicated month for a monit" +
            "or\'s required collection frequency when that frequency is stratified random, ran" +
            "dom, or seasonal. Twelve slots are available, one for each month in a year.")]
        public string RCFDecemberCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorLocationInfluences", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorLocationInfluencesType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies the number of the street around the site for which the data are being " +
            "submitted. Street number is used to associate detailed street information for th" +
            "e site to streets closest to the monitors at this site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TangentStreetNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The distance in meters between the sensing of air sampling equipment at a monitor" +
            "ing site and the nearest edge of the roadway.")]
        public string DistanceToStreetMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorObstructions", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorObstructionsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Enumeration of 5 codes")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ObstructionTypeCodeType ObstructionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The direction from the monitor to the obstruction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public CompassSectorCodeType DirectionToObstructionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The distance, in meters, between the probe and obstruction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string DistanceToObstructionMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The height, in meters, of the top of the obstruction above the probe.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ObstructionHeightMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("ObstructionTypeCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum ObstructionTypeCodeType
    {

        /// <remarks/>
        BUILDINGS,

        /// <remarks/>
        CLIFFS,

        /// <remarks/>
        RIDGES,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("TREES/BRUSH")]
        TREESBRUSH,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorRegulatoryCompliance", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorRegulatoryComplianceType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a reference to an official printed copy of an environmen" +
            "tal regulation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CitationReferenceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The compliance status of a monitor with respect to an EPA regulation.")]
        public string ComplianceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the current status of the monitorÆs compliance with the regulat" +
            "ion was achieved.")]
        public string ComplianceDate;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceIndicator", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum ComplianceIndicatorType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        W,

        /// <remarks/>
        C,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorCollocationInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorCollocationInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The beginning date of the time period during which a collocated monitor pair reco" +
            "rded precision and accuracy data. Used to determine data completeness.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CollocationBeginDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The ending date of the time period during which a collocated monitor pair recorde" +
            "d precision and accuracy data. Used to determine data completeness.")]
        public string CollocationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The distance, in meters, between a duplicate sampler and the primary sampler in a" +
            " collocated pair.")]
        public string PrimaryMonitorDistanceMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether the monitor is the primary or duplicate monitor in a collocated" +
            " monitor pair.")]
        public string PrimaryMonitorIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionProtocolDetails", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class TransactionProtocolDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CompositeTypeIdentifier", typeof(CompositeTypeIdentifierType), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("DurationCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("FrequencyCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The identification number or code assigned by the method publisher.")]
        public string MethodIdentifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the unit for measuring the item.")]
        public string MeasureUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The method detectable limit defined for the monitor by the reporting agency, whic" +
            "h supersedes the EPA-defined method detectable limit for the designated methodol" +
            "ogy.")]
        public string AlternateMDLValue;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("CompositeTypeIdentifier", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum CompositeTypeIdentifierType
    {

        /// <remarks/>
        ANNUAL,

        /// <remarks/>
        QUARTERLY,

        /// <remarks/>
        SEASONAL,

        /// <remarks/>
        MONTHLY,

        /// <remarks/>
        WEEKLY,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The time period over which samples are composited, or the frequency of submitting" +
            " composite samples.")]
        CompositeTypeIdentifier,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute(@"A code representing the sample duration. The sample duration is the length of time that air passes through the monitoring device before it is analyzed (measured).  So, it represents an averaging period in the atmosphere (for example, a 24-hour sample duration draws ambient air over a collection filter for 24 straight hours).  For continuous monitors, it can represent an averaging time of many samples  (for example, a 1-hour value may be the average of four one-minute samples collected during each quarter of the hour).  This used to be called Sampling Interval.")]
        DurationCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The required collection frequency (RCF) is mandatory for both Photochemical Asses" +
            "sment Monitoring System (PAMS) regulations for organic compounds and PM-2.5 or P" +
            "M-10 monitors.")]
        FrequencyCode,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorProtocol", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorProtocolType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The sequential monitor protocol identification (MP ID) number used to distinguish" +
            " combinations of sample duration, unit, method, collection frequency, composite " +
            "type, and alternate method detectable limit (Alt-MDL) for a monitor.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MPIDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the protocol of a measurement: the sample duration, frequency, units of me" +
            "asure, method, and detection limit.")]
        public TransactionProtocolDetailsType TransactionProtocolDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RawAccuracyInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RawAccuracyInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A sequentially assigned number used to identify (ID) a unique measurement data gr" +
            "oup for a monitor on a specific date.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AccuracyAuditIDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The year represented by the audit.")]
        public string AuditYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The quarter represented by an audit.")]
        public string QuarterRepresentedCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The calendar date for which the accuracy audit is being reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AccuracyDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Description of who performed the audit and how the audit standard was certified.")]
        public string AuditTypeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The source of the local primary standards used for the audit.")]
        public string LocalStandardIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Description of the class of audit taken at the monitor.")]
        public string AuditClassIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A description of the type of accuracy test performed.")]
        public string AccuracyTypeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The unique identity (ID) number of the reference sample used to challenge the ins" +
            "trument.")]
        public string AuditSampleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The expiration date for the local primary standard.")]
        public string LocalStandardExpirationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The initial date that the performance audit was scheduled.")]
        public string AuditScheduledDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The true observation of the parameter value at the prescribed audit level.")]
        public string Level1ActualValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The recorded observation of the parameter value at the prescribed audit level.")]
        public string Level1IndicatedValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The true observation of the parameter value at the prescribed audit level.")]
        public string Level2ActualValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The recorded observation of the parameter value at the prescribed audit level.")]
        public string Level2IndicatedValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The true observation of the parameter value at the prescribed audit level.")]
        public string Level3ActualValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The recorded observation of the parameter value at the prescribed audit level.")]
        public string Level3IndicatedValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The true observation of the parameter value at the prescribed audit level.")]
        public string Level4ActualValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The recorded observation of the parameter value at the prescribed audit level.")]
        public string Level4IndicatedValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("The true observation of the parameter value at the prescribed audit level.")]
        public string Level5ActualValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("The recorded observation of the parameter value at the prescribed audit level.")]
        public string Level5IndicatedValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("A measurement obtained with gas from a zero concentration. Zero span is the obser" +
            "ved value read from the instrument when the concentration of the specific parame" +
            "ter used to test the monitor was zero.")]
        public string ZeroSpanValue;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("QuarterRepresentedCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum QuarterRepresentedCodeType
    {

        /// <remarks/>
        Q1,

        /// <remarks/>
        Q2,

        /// <remarks/>
        Q3,

        /// <remarks/>
        Q4,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RawCompositeInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RawCompositeInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The calendar year for which the observation was reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ObservationYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indicates the time period within the year to which the observation applies. It is" +
            " expressed in units that may be inferred from composite type.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CompositePeriodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Indicates the number of samples that were combined to yield the composite sample " +
            "value.")]
        public string SamplesCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The value of a composite observation.")]
        public string CompositeSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute(@"The measure of method uncertainty associated with the sample data point, which will include components of both the analytical and the volume uncertainty. No blank corrections are assumed (other than laboratory baseline corrections which are an integral part of each analysis).")]
        public string UncertaintyValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResultQualifierCode", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the results.")]
        public string[] ResultQualifierCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RawValueDetails", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RawValueDetailsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MeasureValue", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("NullDataCode", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("UncertaintyValue", typeof(decimal), Order = 0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName", Order = 1)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResultQualifierCode", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A code used to identify any qualifying issues that affect the results.")]
        public string[] ResultQualifierCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This is a field used only by non-AQS data transfers to indicate if the level of v" +
            "alidity of the data.  (This is generally used for state to state exchanges of ne" +
            "ar-real-time air quality data.)")]
        public string DataValidityCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This is a field used only by non-AQS data transfers to indicate if the level of a" +
            "pproval of the data.  (This is generally used for state to state exchanges of ne" +
            "ar-real-time air quality data.)")]
        public string DataApprovalIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("The recorded dimension, capacity, quality, or amount of something ascertained by " +
            "measuring or observing.")]
        MeasureValue,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute("Code to explain why no sample value was reported.")]
        NullDataCode,

        /// <remarks/>
        [System.ComponentModel.DescriptionAttribute(@"The measure of method uncertainty associated with the sample data point, which will include components of both the analytical and the volume uncertainty. No blank corrections are assumed (other than laboratory baseline corrections which are an integral part of each analysis).")]
        UncertaintyValue,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("DataValidityCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum DataValidityType
    {

        /// <remarks/>
        V,

        /// <remarks/>
        I,

        /// <remarks/>
        C,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RawResults", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RawResultsType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date on which a particular sample began being collected.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleCollectionStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The time on which a particular sample began being collected.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleCollectionStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to measured sample values.")]
        public RawValueDetailsType RawValueDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RawPrecisionInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RawPrecisionInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates the type of precision test run.")]
        public string PrecisionTypeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A sequentially assigned number used to identify (ID) a particular precision check" +
            " from others, when multiple checks are performed on the same day.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PrecisionIDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies a particular method for collecting and analyzing samples of the monito" +
            "r\'s parameter.")]
        public string ActualMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The calendar date for which the precision check is being reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PrecisionCheckDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The true value of the parameter concentration with which the monitor was challeng" +
            "ed. For a collocated data pair, the sample value from the primary sampler.")]
        public string ActualValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Identifies the particular method for collecting and analyzing the sample value fr" +
            "om the duplicate sampler. Only applies to collocated data.")]
        public string IndicatedMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The observed value of the parameter concentration with which the monitor was chal" +
            "lenged. For a collocated data pair, the sample value from the duplicate sampler." +
            "")]
        public string IndicatedValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The Parameter Occurrence Code (POC) of the duplicate sampler. Only applies to col" +
            "located data where the duplicate value is a recorded daily raw data point.")]
        public string CollocatedPocIDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The unique identity (ID) number of the reference sample used to challenge the ins" +
            "trument.")]
        public string PrecisionSampleIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The agency submitting precision data resulting from a Federal Reference Method Co" +
            "de (FRM) audit of the manual method for PM-2.5 monitoring. This agency is common" +
            "ly an EPA laboratory or independent laboratory.")]
        public string AuditAgencyCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("AnnualSummaryInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class AnnualSummaryInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The year whose raw data is summarized.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SummaryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Indication of whether exceptional data exists in the year being summarized, and w" +
            "hether such exceptional data is included in the reported summary values.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ExceptionalDataTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The number of raw data values that are the basis for the summary values.")]
        public string ObservationsCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The number of data points in the summarized data set that were qualified by excep" +
            "tional events.")]
        public string EventsCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The highest sample value in the yearly sample value set.")]
        public string HighestSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The earliest date on which the highest sample value in the yearly data set was re" +
            "ported.")]
        public string HighestSampleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The time of day at which the highest sample value in the yearly data set was repo" +
            "rted.")]
        public string HighestSampleTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The second highest sample value in the yearly sample value set.")]
        public string SecondHighestSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute(@"If the second highest value is less than the highest, this identifies the earliest date on which the second highest sample value in the yearly data set was reported; if the second highest is equal to the highest, this identifies the second earliest date on which the value was reported.")]
        public string SecondHighestSampleDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The time of day on which the second highest sample value in the yearly data set w" +
            "as reported.")]
        public string SecondHighestSampleTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The third highest sample value in the yearly sample value set.")]
        public string ThirdHighestSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The fourth highest sample value in the yearly sample value set.")]
        public string FourthHighestSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The fifth highest sample value in the yearly sample value set.")]
        public string FifthHighestSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The lowest sample value in the yearly sample value set.")]
        public string LowestSampleValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The measure of central tendency obtained from the sum of the observed pollutant d" +
            "ata values in the yearly data set divided by the number of values that comprise " +
            "the sum for the yearly data set.")]
        public string ArithmeticMeanValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The measure of the dispersion about the central tendency of a pollutant that is t" +
            "he square root of the arithmetic mean of the squares of the variation of each da" +
            "ta value from the arithmetic mean of the data values of the yearly data set.")]
        public string ArithmeticStandardDevValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The measure of central tendency obtained from the sum of the logarithms of observ" +
            "ed sample values in the yearly data set, divided by the number of values, with t" +
            "hat result applied as an exponent to 10.")]
        public string GeometricMeanValue;

        /// <remarks/>
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The measure of the dispersion about the central tendency of a pollutant that is b" +
            "ased on the variation between the geometric mean of a sample of values and the l" +
            "ogarithms of the values themselves.")]
        public string GeometricStandardDevValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the tenth percentile of the yearly data set when so" +
            "rted from lowest to highest.")]
        public string TenthPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the twenty-fifth percentile of the yearly data set " +
            "when sorted from lowest to highest.")]
        public string TwentyFifthPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the fiftieth percentile of the yearly data set when" +
            " sorted from lowest to highest.")]
        public string FiftiethPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 22)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the seventy-fifth percentile of the yearly data set" +
            " when sorted from lowest to highest.")]
        public string SeventyFifthPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 23)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the ninetieth percentile of the yearly data set whe" +
            "n sorted from lowest to highest.")]
        public string NinetiethPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 24)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the ninety-fifth percentile of the yearly data set " +
            "when sorted from lowest to highest.")]
        public string NinetyFifthPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the ninety-eighth percentile of the yearly data set" +
            " when sorted from lowest to highest.")]
        public string NinetyEighthPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 26)]
        [System.ComponentModel.DescriptionAttribute("The sample value occurring in the ninety-ninth percentile of the yearly data set " +
            "when sorted from lowest to highest.")]
        public string NinetyNinthPercentileValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 27)]
        [System.ComponentModel.DescriptionAttribute("The percent of actual data values that were reported compared to the number of da" +
            "ta values that could have been reported for the year.")]
        public string ObservationPercentValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 28)]
        [System.ComponentModel.DescriptionAttribute("Represents the number of substitutions of one-half the Method Code Detectable Lim" +
            "it value for the year.")]
        public string BelowHalfMDLCount;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("BlankInformation", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class BlankInformationType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An indication of the action to be taken on the transaction by AQS (insert, update" +
            ", or delete).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date on which a particular sample began being collected.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleCollectionStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The time on which a particular sample began being collected.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SampleCollectionStartTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 3)]
        [System.ComponentModel.DescriptionAttribute(@"The blank type describes how the un-exposed filter was handled. It has possible values TRIP and FIELD. A type of TRIP means that the filter was taken to the site, but not placed in the instrument, while a type of FIELD means that the filter was placed in the instrument and removed before operation of the instrument.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BlankTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to measured sample values.")]
        public RawValueDetailsType RawValueDetails;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("AirQualitySubmission", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class AirQualitySubmissionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The reason (destination system) for creating the XML file.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FileGenerationPurposeCodeType FileGenerationPurposeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date and time the XML file was created.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FileGenerationDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteList", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the site, monitor, and sample values.")]
        public FacilitySiteListType[] FacilitySiteList;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public VersionType Version;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("FileGenerationPurposeCode", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public enum FileGenerationPurposeCodeType
    {

        /// <remarks/>
        AQS,

        /// <remarks/>
        AIRNOW,

        /// <remarks/>
        OTHER,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteList", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class FacilitySiteListType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to site identification codes and names.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public SiteIdentifierDetailsType SiteIdentifierDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to physical description of an air quality site (facility).")]
        public BasicSiteInformationType BasicSiteInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RoadInfluences", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to roadways that may influence a monitoring site.")]
        public RoadInfluencesType[] RoadInfluences;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OpenPathMonitoringLocation", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing any open path monitoring.")]
        public OpenPathMonitoringLocationType[] OpenPathMonitoringLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorList", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the monitor, and sample values.")]
        public MonitorListType[] MonitorList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("MonitorList", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class MonitorListType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to monitor identification codes and names.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MonitorIdentifierDetailsType MonitorIdentifierDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to physical description of an air quality sampler (monitor).")]
        public BasicMonitoringInformationType BasicMonitoringInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorSamplingPeriod", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements indic" +
            "ating when a monitor began and ended sampling operations.")]
        public MonitorSamplingPeriodType[] MonitorSamplingPeriod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorTypeInformation", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements indic" +
            "ating when a monitor began and ended operations in for different purposes or as " +
            "part of different networks.")]
        public MonitorTypeInformationType[] MonitorTypeInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorAgencyRole", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Monitor agency role details")]
        public MonitorAgencyRoleType[] MonitorAgencyRole;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorObjectiveInformation", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to the purpose of a monitor and the urban area(s) it represents.")]
        public MonitorObjectiveInformationType[] MonitorObjectiveInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorSamplingSchedule", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the monitor sampling schedule.")]
        public MonitorSamplingScheduleType[] MonitorSamplingSchedule;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorLocationInfluences", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to roadways that may effect the values measured at a monitor.")]
        public MonitorLocationInfluencesType[] MonitorLocationInfluences;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorObstructions", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing structures which may affect the sampling ability of the monitor.")]
        public MonitorObstructionsType[] MonitorObstructions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorRegulatoryCompliance", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Monitor regulatory compliance details")]
        public MonitorRegulatoryComplianceType[] MonitorRegulatoryCompliance;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorCollocationInformation", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements relat" +
            "ed to the description of collocated monitors.")]
        public MonitorCollocationInformationType[] MonitorCollocationInformation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitorProtocol", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the protocol of a monitor: the sample duration, frequency, units of measur" +
            "e, method, and detection limit.")]
        public MonitorProtocolType[] MonitorProtocol;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RawDataList", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the sample values.")]
        public RawDataListType[] RawDataList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    [System.Xml.Serialization.XmlRootAttribute("RawDataList", Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2", IsNullable = false)]
    public partial class RawDataListType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This is a complex element (element grouping) containing all of the elements descr" +
            "ibing the protocol of a measurement: the sample duration, frequency, units of me" +
            "asure, method, and detection limit.")]
        public TransactionProtocolDetailsType TransactionProtocolDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnnualSummaryInformation", typeof(AnnualSummaryInformationType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("BlankInformation", typeof(BlankInformationType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("RawAccuracyInformation", typeof(RawAccuracyInformationType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("RawCompositeInformation", typeof(RawCompositeInformationType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("RawPrecisionInformation", typeof(RawPrecisionInformationType), Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute("RawResults", typeof(RawResultsType), Order = 1)]
        public object[] Items;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/AQS/Submission/2")]
    public enum VersionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.0")]
        Item20,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.1")]
        Item21,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.2")]
        Item22,
    }
}
#endif // V_2_2
