namespace Windsor.Node2008.WNOSPlugin.NetDMR_10
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/NetDMR/1")]
    [System.Xml.Serialization.XmlRootAttribute("SubmissionResponse", Namespace = "http://www.exchangenetwork.net/schema/NetDMR/1", IsNullable = false)]
    public partial class SubmissionResponseDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An Exchange Network transaction ID issued by a Exchange Network Node.")]
        public string TransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date something was submitted.")]
        public System.DateTime SubmissionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date something was created.")]
        public System.DateTime CreationDate;

        /// <remarks/>
        //[System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        //[System.Xml.Serialization.XmlArrayItemAttribute("SubmissionError", IsNullable = false)]
        //[System.ComponentModel.DescriptionAttribute("Wraps a group of SubmissionError elements. ")]
        //public SubmissionErrorDataType[] SubmissionErrors;
    }
}
