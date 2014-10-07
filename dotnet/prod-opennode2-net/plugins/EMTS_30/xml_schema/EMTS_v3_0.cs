namespace Windsor.Node2008.WNOSPlugin.EMTS_30
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("GenerateSupportingDocumentDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class SupportingDocumentDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of document to which the document number applies.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string SupportingDocumentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The identification number for the supporting document.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string SupportingDocumentNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("FeedstockDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class FeedstockDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the feedstock used to produce the renewable fuel associate" +
            "d with the batch number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FeedstockCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An indicator of whether the feedstock used qualifies as renewable biomass.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public bool RenewableBiomassIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Total amount of feedstock used in the production of the fuel.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal FeedstockQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure associated with the volume of feedstock used in the productio" +
            "n of renewable fuel.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string FeedstockMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the Feedstock.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string FeedstockDetailCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("CoProductDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class CoProductDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the co-product created for the renewable fuel process.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string CoProductCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the CoProduct.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string CoProductDetailCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("SellOriginatingSourceDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class OriginatingSourceDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The OTAQReg identifier for the organization that generated the fuel.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string GenerateOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The facility identifier, as registered in OTAQReg, for the facility that produced" +
            " the fuel.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string GenerateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The batch number for the renewable fuel as designated by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(20)]
        public string BatchNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("GenerateTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class GenerateTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel type as described in section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date the renewable fuel was produced as designated by the producing facility." +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ProductionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the process used for producing the renewable fuel.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string ProcessCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The volume of non-renewable fuel added to a volume of ethanol to create the Batch" +
            "Volume for a given BatchNumber of renewable fuel.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string DenaturantVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("A multiplier applied to BatchVolume to determine the number of RINs that will be " +
            "generated per gallon of renewable fuel produced. The EquivalenceValue is directl" +
            "y related to FuelCategoryCode as defined in Section 80.1415.")]
        public decimal EquivalenceValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EquivalenceValueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The public facility identifier of the plant where the fuel was imported.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string ImportFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GenerateSupportingDocumentDetail", Order = 11)]
        //TSM:
        //public SupportingDocumentDetailDataType[] GenerateSupportingDocumentDetail;
        public GenerateSupportingDocumentDetailDataType[] GenerateSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public OriginatingSourceDetailDataType GenerateOriginatingSourceDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FeedstockDetail", Order = 13)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FeedstockDetailDataType[] FeedstockDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CoProductDetail", Order = 14)]
        public CoProductDetailDataType[] CoProductDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("SeparateTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class SeparateTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a separate transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string SeparateReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The date of the RIN transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransactionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The public organization identifier of the small Blender.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string BlenderOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name of the small blender that is blending the fuel.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(125)]
        public string BlenderOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeparateSupportingDocumentDetail", Order = 10)]
        //TSM:
        //public SupportingDocumentDetailDataType[] SeparateSupportingDocumentDetail;
        public SeparateSupportingDocumentDetailDataType[] SeparateSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public OriginatingSourceDetailDataType SeparateOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("SellTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class SellTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This identifies the buyer organization for a sell transaction or the selling orga" +
            "nization for the buy transaction using the OrganizationIdentifier designated by " +
            "OTAQReg.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string TransactionPartnerOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the organization trading partner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(125)]
        public string TransactionPartnerOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssignmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a sell transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string SellReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Price paid per RIN.")]
        public decimal RINPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RINPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Price paid per gallon of renewable fuel.")]
        public decimal GallonPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GallonPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The date the RINs change hands. This is normally the date they are received by th" +
            "e purchaser.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransferDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The PTD number associated with the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string PTDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The EMTS transaction identification number that matches the submitted buy or sell" +
            " transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string MatchingTransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PublicSupportingDocumentDetail", Order = 14)]
        //TSM:
        //public SupportingDocumentDetailDataType[] PublicSupportingDocumentDetail;
        public SellPublicSupportingDocumentDetailDataType[] PublicSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SellSupportingDocumentDetail", Order = 16)]
        //TSM:
        //public SupportingDocumentDetailDataType[] SellSupportingDocumentDetail;
        public SellSupportingDocumentDetailDataType[] SellSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public OriginatingSourceDetailDataType SellOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("BuyTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class BuyTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This identifies the buyer organization for a sell transaction or the selling orga" +
            "nization for the buy transaction using the OrganizationIdentifier designated by " +
            "OTAQReg.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string TransactionPartnerOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the organization trading partner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(125)]
        public string TransactionPartnerOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssignmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a buy transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string BuyReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Price paid per RIN.")]
        public decimal RINPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RINPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Price paid per gallon of renewable fuel.")]
        public decimal GallonPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GallonPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The date the RINs change hands. This is normally the date they are received by th" +
            "e purchaser.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransferDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The PTD number associated with the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string PTDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The EMTS transaction identification number that matches the submitted buy or sell" +
            " transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string MatchingTransactionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PublicSupportingDocumentDetail", Order = 14)]
        //TSM:
        //public SupportingDocumentDetailDataType[] PublicSupportingDocumentDetail;
        public BuyPublicSupportingDocumentDetailDataType[] PublicSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BuySupportingDocumentDetail", Order = 16)]
        //TSM:
        //public SupportingDocumentDetailDataType[] BuySupportingDocumentDetail;
        public BuySupportingDocumentDetailDataType[] BuySupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        public OriginatingSourceDetailDataType BuyOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("RetireTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class RetireTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssignmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a retire transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string RetireReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The date of the RIN transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransactionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The compliance year for which the transaction is applied.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string ComplianceYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The compliance basis for the submitting organization: Facility, Aggregated Import" +
            "er, Aggregated Refiner, Aggregated Exporter, Non-Obligated Party.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(3)]
        public string ComplianceLevelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The The facility identifier, as registered in OTAQReg, for the facility that has " +
            "a compliance obligation.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string ComplianceFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RetireSupportingDocumentDetail", Order = 12)]
        //TSM:
        //public SupportingDocumentDetailDataType[] RetireSupportingDocumentDetail;
        public RetireSupportingDocumentDetailDataType[] RetireSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public OriginatingSourceDetailDataType RetireOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("LockTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class LockTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public OriginatingSourceDetailDataType LockOriginatingSourceDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssignmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The OTAQReg identifier for the organization that QAPped the RINs.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string QapProviderOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("UnlockTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class UnlockTransactionDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public OriginatingSourceDetailDataType UnlockOriginatingSourceDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string AssignmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbColumnTypeAttribute("Int32")]
        public string RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The QAPServiceTypeCode indicates what level of QAP certification is desired for t" +
            "he RINs involved in the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(4)]
        public string QAPServiceTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The OTAQReg identifier for the organization that QAPped the RINs.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string QapProviderOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string TransactionDetailCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/3")]
    [System.Xml.Serialization.XmlRootAttribute("EMTS", Namespace = "http://www.exchangenetwork.net/schema/emts/3", IsNullable = false)]
    public partial class EMTSDataType : Windsor.Commons.XsdOrm.BaseDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The CDX user login of the party responsible for preparing the submission file.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(100)]
        public string UserLoginText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date that the submission file was created.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SubmittalCreationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The public identification number for the organization as designated by OTAQReg. T" +
            "his must be reported if a OrganizationRINPin is not supplied.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(12)]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on submission file.")]
        [Windsor.Commons.XsdOrm.DbMaxColumnSizeAttribute(400)]
        public string SubmittalCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GenerateTransactionDetail", Order = 4)]
        public GenerateTransactionDetailDataType[] GenerateTransactionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeparateTransactionDetail", Order = 5)]
        public SeparateTransactionDetailDataType[] SeparateTransactionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SellTransactionDetail", Order = 6)]
        public SellTransactionDetailDataType[] SellTransactionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BuyTransactionDetail", Order = 7)]
        public BuyTransactionDetailDataType[] BuyTransactionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RetireTransactionDetail", Order = 8)]
        public RetireTransactionDetailDataType[] RetireTransactionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LockTransactionDetail", Order = 9)]
        public LockTransactionDetailDataType[] LockTransactionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UnlockTransactionDetail", Order = 10)]
        public UnlockTransactionDetailDataType[] UnlockTransactionDetail;
    }
}
