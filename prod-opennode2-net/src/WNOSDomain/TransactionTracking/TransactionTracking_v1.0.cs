namespace Windsor.Node2008.WNOSDomain.TransactionTracking
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "TransactionListType", Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionList", Namespace = "http://www.exchangenetwork.net/schema/tts/1", IsNullable = false)]
    public partial class TransactionListType1
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transaction", Order = 0)]
        public TransactionType[] Transaction;
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TransactionDetailType))]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    public partial class TransactionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string TransactionId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DataflowName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransactionType", Order = 2)]
        public string TransactionType1;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string TransactionStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string StatusDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public System.DateTime CreationDateTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string UserId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string Organization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string Contact;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    public partial class DocumentType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string DocumentId;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string DocumentName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string FileName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DocumentType", Order = 3)]
        public string DocumentType1;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    public partial class ActivityType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ActivityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ActivityStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string Message;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public System.DateTime Timestamp;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    public partial class NameValuePair
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/tts/1", IsNullable = false)]
    public partial class TransactionDetailType : TransactionType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Property", IsNullable = false)]
        public NameValuePair[] Properties;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Activity", IsNullable = false)]
        public ActivityType[] ActivityList;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Document", IsNullable = false)]
        public DocumentType[] DocumentList;
    }
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(TypeName = "TransactionListType", Namespace = "http://www.exchangenetwork.net/schema/tts/1")]
    [System.Xml.Serialization.XmlRootAttribute("TransactionCount", Namespace = "http://www.exchangenetwork.net/schema/tts/1", IsNullable = false)]
    public partial class TransactionCount
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.ComponentModel.DescriptionAttribute("The number of transactions returned by the GetTransactionCount method.")]
        public int Value;
    }
}
