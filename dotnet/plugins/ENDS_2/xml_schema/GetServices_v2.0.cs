namespace Windsor.Node2008.WNOSPlugin.ENDS_2
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public partial class NetworkNodeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string NodeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string NodeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI", Order = 2)]
        public string NodeAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string NodeContact;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public NodeVersionCode NodeVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public NodeStageCode NodeDeploymentTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public NodeStatusCode NodeStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NodeProperty", Order = 8)]
        public ObjectPropertyType[] NodeProperty;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public NodeBoundingBoxType BoundingBoxDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 10)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Service", IsNullable = false)]
        public ServiceDescriptionListTypeService[] NodeServiceList;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public enum NodeVersionCode
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1.1")]
        Item11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2.0")]
        Item20,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public enum NodeStageCode
    {

        /// <remarks/>
        Development,

        /// <remarks/>
        Test,

        /// <remarks/>
        Production,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public enum NodeStatusCode
    {

        /// <remarks/>
        Operational,

        /// <remarks/>
        Busy,

        /// <remarks/>
        Offline,

        /// <remarks/>
        Unknown,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public partial class ObjectPropertyType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string PropertyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public object PropertyValue;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public partial class RequestParameterType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterName;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterType;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParameterTypeDescriptor;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool ParameterRequiredIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(EncodingType.None)]
        public EncodingType ParameterEncoding;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ParameterSortIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("1")]
        public string ParameterOccurrenceNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;

        public RequestParameterType()
        {
            this.ParameterRequiredIndicator = true;
            this.ParameterEncoding = EncodingType.None;
            this.ParameterOccurrenceNumber = "1";
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public enum EncodingType
    {

        /// <remarks/>
        Base64,

        /// <remarks/>
        ZIP,

        /// <remarks/>
        Encrypt,

        /// <remarks/>
        Digest,

        /// <remarks/>
        XML,

        /// <remarks/>
        None,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public partial class StyleSheetType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StyleSheetTypeValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "anyURI")]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public partial class NodeBoundingBoxType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal BoundingCoordinateEast;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public decimal BoundingCoordinateNorth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public decimal BoundingCoordinateSouth;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public decimal BoundingCoordinateWest;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public partial class ServiceDescriptionListTypeService
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public NodeMethodTypeCode MethodName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Dataflow;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string ServiceIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string ServiceDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI", Order = 4)]
        public string ServiceDocumentURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ServiceProperty", Order = 5)]
        public ObjectPropertyType[] ServiceProperty;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StyleSheetURL", Order = 6)]
        public StyleSheetType[] StyleSheetURL;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter", Order = 7)]
        public RequestParameterType[] Parameter;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/ends/2")]
    public enum NodeMethodTypeCode
    {

        /// <remarks/>
        Query,

        /// <remarks/>
        Solicit,

        /// <remarks/>
        Submit,

        /// <remarks/>
        Execute,
    }
}
