using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.EMTS_10
{


    [DefaultTableNamePrefixAttribute("EMTS")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [AdditionalAbbreviationsAttribute("REPORT", "RPT",
                                      "SUPPORTING", "SUPRT",
                                      "GENERATE", "GENR",
                                      "FEEDSTOCK", "FDSTK",
                                      "SEPARATE", "SEPR",
                                      "PRODUCT", "PROD",
                                      "PRODUCTION", "PROD",
                                      "ASSIGNMENT", "ASSIGN",
                                      "AMOUNT", "AMT",
                                      "RENEWABLE", "RENEW",
                                      "DOCUMENT", "DOC"
    )]

    [AppliedAttribute(typeof(EMTSDataType), "UserLoginText", typeof(ColumnAttribute), 100)]
    [AppliedAttribute(typeof(EMTSDataType), "OrganizationIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(EMTSDataType), "SubmittalCreationDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(EMTSDataType), "SubmittalCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "FuelCode", typeof(ColumnAttribute), 100)]//??
    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "ProcessCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "ProductionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "FuelCategoryCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "EquivalenceValue", typeof(ColumnAttribute), 2, 1)]
    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "ImportFacilityIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "TransactionDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(SeparateTransactionDetailDataType), "FuelCode", typeof(ColumnAttribute), 100)]//??
    [AppliedAttribute(typeof(SeparateTransactionDetailDataType), "SeparateReasonCode", typeof(ColumnAttribute), 100)]//??
    [AppliedAttribute(typeof(SeparateTransactionDetailDataType), "BlenderOrganizationIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(SeparateTransactionDetailDataType), "BlenderOrganizationName", typeof(ColumnAttribute), 125)]
    [AppliedAttribute(typeof(SeparateTransactionDetailDataType), "TransactionDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(SellTransactionDetailDataType), "TransactionPartnerOrganizationIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "TransactionPartnerOrganizationName", typeof(ColumnAttribute), 125)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "FuelCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "AssignmentCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "SellReasonCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "RINPriceAmount", typeof(ColumnAttribute), 5, 2)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "GallonPriceAmount", typeof(ColumnAttribute), 5, 2)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "TransactionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "PTDNumber", typeof(ColumnAttribute), 100)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "TransactionDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "TransactionPartnerOrganizationIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "TransactionPartnerOrganizationName", typeof(ColumnAttribute), 125)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "FuelCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "AssignmentCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "BuyReasonCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "RINPriceAmount", typeof(ColumnAttribute), 5, 2)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "GallonPriceAmount", typeof(ColumnAttribute), 5, 2)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "TransactionDate", typeof(ColumnAttribute), DbType.Date)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "PTDNumber", typeof(ColumnAttribute), 100)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "TransactionDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(RetireTransactionDetailDataType), "FuelCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(RetireTransactionDetailDataType), "AssignmentCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(RetireTransactionDetailDataType), "RetireReasonCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(RetireTransactionDetailDataType), "ComplianceLevelCode", typeof(ColumnAttribute), 100)] //??
    [AppliedAttribute(typeof(RetireTransactionDetailDataType), "ComplianceFacilityIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(RetireTransactionDetailDataType), "TransactionDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(FeedstockDetailDataType), "FeedstockCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(FeedstockDetailDataType), "FeedstockVolume", typeof(ColumnAttribute), 10, 1)]
    [AppliedAttribute(typeof(FeedstockDetailDataType), "FeedstockMeasureCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(FeedstockDetailDataType), "FeedstockDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(CoProductDetailDataType), "CoProductCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(CoProductDetailDataType), "CoProductDetailCommentText", typeof(ColumnAttribute), 400)]

    [AppliedAttribute(typeof(SupportingDocumentDetailDataType), "SupportingDocumentText", typeof(ColumnAttribute), 100)]
    [AppliedAttribute(typeof(SupportingDocumentDetailDataType), "SupportingDocumentNumberText", typeof(ColumnAttribute), 100)]

    [AppliedAttribute(typeof(OriginatingSourceDetailDataType), "GenerateOrganizationIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(OriginatingSourceDetailDataType), "GenerateFacilityIdentifier", typeof(ColumnAttribute), 12)]
    [AppliedAttribute(typeof(OriginatingSourceDetailDataType), "BatchNumberText", typeof(ColumnAttribute), 20)]

    public partial class EMTSDataType : BaseDataType
    {
    }

    public partial class GenerateTransactionDetailDataType : BaseChildDataType
    {
    }

    public partial class SeparateTransactionDetailDataType : BaseChildDataType
    {
    }

    public partial class SellTransactionDetailDataType : BaseChildDataType
    {
    }

    public partial class BuyTransactionDetailDataType : BaseChildDataType
    {
    }

    public partial class RetireTransactionDetailDataType : BaseChildDataType
    {
    }

    public partial class FeedstockDetailDataType : BaseChildDataType
    {
    }

    public partial class CoProductDetailDataType : BaseChildDataType
    {
    }

    public partial class SupportingDocumentDetailDataType : BaseChildDataType
    {
    }

    public partial class SeparateSupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }

    public partial class SellSupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }

    public partial class BuySupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }

    public partial class RetireSupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }
}
