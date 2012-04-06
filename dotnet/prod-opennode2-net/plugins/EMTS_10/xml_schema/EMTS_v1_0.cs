namespace Windsor.Node2008.WNOSPlugin.EMTS_10
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("FeedstockDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class FeedstockDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("AA code that identifies the feedstock used to produce the renewable fuel associat" +
            "ed with the batch number.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FeedstockCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An indicator whether the feedstock used qualifies as renewable biomass.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        public bool RenewableBiomassIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Total volume of feedstock used in the production of the fuel.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal FeedstockVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure associated with the volume of feedstock used in the productio" +
            "n of renewable fuel.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FeedstockMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the Feedstock.")]
        public string FeedstockDetailCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("CoProductDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class CoProductDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the co-product created fro the renewable fuel process.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CoProductCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the CoProduct.")]
        public string CoProductDetailCommentText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("SellOriginatingSourceDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class OriginatingSourceDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The OTAQREg identifier for the organization that generated the fuel.")]
        public string GenerateOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The facility identifier, as registered in OTAQReg, for the facility that produced" +
            " the fuel.")]
        public string GenerateFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The batch number for the renewable fuel as designated by the producing facility.")]
        public string BatchNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("GenerateTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class GenerateTransactionDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A code that identifies the process used for producing the renewable fuel.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProcessCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date the renewable fuel was produced as designated by the producing facility." +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime ProductionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel typeas described in section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FuelCategoryCode;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string BatchVolume;
        public int BatchVolume;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The volume of non-renewable fuel added to a volume of ethanol to create the Batch" +
            "Volume for a given BatchNumber of renewable fuel.")]
        //TSM:
        //public string DenaturantVolume;
        public int DenaturantVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DenaturantVolumeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A multiplier applied to BatchVolume to determine the number of RINs that will be " +
            "generated per gallon of renewable fuel produced.  The EquivalenceValue is direct" +
            "ly related to FuelCode as defined in Section 80.1415.")]
        public decimal EquivalenceValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EquivalenceValueSpecified;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINQuantity;
        public int RINQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The public facility identifier of the plant where the fuel was imported.")]
        public string ImportFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public OriginatingSourceDetailDataType GenerateOriginatingSourceDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FeedstockDetail", Order = 11)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FeedstockDetailDataType[] FeedstockDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CoProductDetail", Order = 12)]
        public CoProductDetailDataType[] CoProductDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("BuySupportingDocumentDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class SupportingDocumentDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of document to which the document number applies.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SupportingDocumentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The identification number for the supporting document.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SupportingDocumentNumberText;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("SeparateTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class SeparateTransactionDetailDataType
    {

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINQuantity;
        public int RINQuantity;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string BatchVolume;
        public int BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a separate transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SeparateReasonCode;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="gYear", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINYear;
        public int RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The public organization identifer of the small Blender.")]
        public string BlenderOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The name of the small blender that is blending the fuel. ")]
        public string BlenderOrganizationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SeparateSupportingDocumentDetail", Order = 8)]
        //TSM:
        //public SupportingDocumentDetailDataType[] SeparateSupportingDocumentDetail;
        public SeparateSupportingDocumentDetailDataType[] SeparateSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public OriginatingSourceDetailDataType SeparateOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("SellTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class SellTransactionDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This identifies the buyer organization for a sell transaction or the selling orga" +
            "nization for the buy transaction using either the OrganizationIdentifier designa" +
            "ted by OTAQReg.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TransactionPartnerOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the organization trading partner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TransactionPartnerOrganizationName;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINQuantity;
        public int RINQuantity;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        //TSM:
        //public string BatchVolume;
        public int BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchVolumeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AssignmentCode;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="gYear", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINYear;
        public int RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a sell transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SellReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Price paid per RIN.")]
        public decimal RINPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RINPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Price paid per gallon of renewable fuel.")]
        public decimal GallonPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GallonPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date of the RIN transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransactionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The PTD number associated with the transaction.")]
        public string PTDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SellSupportingDocumentDetail", Order = 13)]
        //TSM:
        //public SupportingDocumentDetailDataType[] SellSupportingDocumentDetail;
        public SellSupportingDocumentDetailDataType[] SellSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public OriginatingSourceDetailDataType SellOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("BuyTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class BuyTransactionDetailDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("This identifies the buyer organization for a sell transaction or the selling orga" +
            "nization for the buy transaction using either the OrganizationIdentifier designa" +
            "ted by OTAQReg.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TransactionPartnerOrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the organization trading partner.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TransactionPartnerOrganizationName;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINQuantity;
        public int RINQuantity;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        //TSM:
        //public string BatchVolume;
        public int BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchVolumeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AssignmentCode;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="gYear", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINYear;
        public int RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a buy transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string BuyReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Price paid per RIN.")]
        public decimal RINPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RINPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Price paid per gallon of renewable fuel.")]
        public decimal GallonPriceAmount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GallonPriceAmountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date of the RIN transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime TransactionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The PTD number associated with the transaction.")]
        public string PTDNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BuySupportingDocumentDetail", Order = 13)]
        //TSM:
        //public SupportingDocumentDetailDataType[] BuySupportingDocumentDetail;
        public BuySupportingDocumentDetailDataType[] BuySupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public OriginatingSourceDetailDataType BuyOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("RetireTransactionDetail", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class RetireTransactionDetailDataType
    {

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total number of RINs specified in the transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINQuantity;
        public int RINQuantity;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The volume, in gallons, of renewable fuel associated with a batch number designat" +
            "ed by the producing facility.")]
        //TSM:
        //public string BatchVolume;
        public int BatchVolume;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BatchVolumeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The renewable fuel code for the batch as defined in Part M Section 80.1426.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FuelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code that indicates whether the RIN is transacting as an assigned RIN or a sepa" +
            "rated RIN.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AssignmentCode;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="gYear", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The RINYear is the year in which the fuel is produced.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        //TSM:
        //public string RINYear;
        public int RINYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("This code identifies the reason for a retire transaction.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string RetireReasonCode;

        /// <remarks/>
        //TSM:
        //[System.Xml.Serialization.XmlElementAttribute(DataType="gYear", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The compliance year for which the transaction is applied.")]
        //TSM:
        //public string ComplianceYear;
        public int ComplianceYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ComplianceYearSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The compliance basis for the submitting organization: Facility, Aggregated Import" +
            "er, Aggregated Refiner, Aggregated Exporter, Non-Obligated Party.")]
        public string ComplianceLevelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The The facility identifier, as registered in OTAQReg, for the facility that has " +
            "a compliance obligation.")]
        public string ComplianceFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on the transaction.")]
        public string TransactionDetailCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RetireSupportingDocumentDetail", Order = 10)]
        //TSM:
        //public SupportingDocumentDetailDataType[] RetireSupportingDocumentDetail;
        public RetireSupportingDocumentDetailDataType[] RetireSupportingDocumentDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        public OriginatingSourceDetailDataType RetireOriginatingSourceDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/emts/1")]
    [System.Xml.Serialization.XmlRootAttribute("EMTS", Namespace = "http://www.exchangenetwork.net/schema/emts/1", IsNullable = false)]
    public partial class EMTSDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The CDX user login of the party responsible for preparing the submission file.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string UserLoginText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date that the submission file was created.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime SubmittalCreationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The public identification number for the organization as designated by OTAQReg.  " +
            "This must be reported if a OrganizationRINPin is not supplied.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Comment provided by the user on submission file.")]
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
    }
}
