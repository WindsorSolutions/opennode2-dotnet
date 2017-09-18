using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.EMTS_20
{

    [DefaultTableNamePrefixAttribute("EMTS")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [DefaultDecimalPrecision(5, 2)]
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
                                      "DOCUMENT", "DOC",
                                      "PUBLIC", "PUB"
    )]

    [AppliedAttribute(typeof(FeedstockDetailDataType), "FeedstockQuantity", typeof(ColumnAttribute), 10, 1)]

    [AppliedAttribute(typeof(GenerateTransactionDetailDataType), "EquivalenceValue", typeof(ColumnAttribute), 2, 1)]

    [AppliedAttribute(typeof(SellTransactionDetailDataType), "RINPriceAmount", typeof(ColumnAttribute), 5, 2)]
    [AppliedAttribute(typeof(SellTransactionDetailDataType), "GallonPriceAmount", typeof(ColumnAttribute), 5, 2)]

    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "RINPriceAmount", typeof(ColumnAttribute), 5, 2)]
    [AppliedAttribute(typeof(BuyTransactionDetailDataType), "GallonPriceAmount", typeof(ColumnAttribute), 5, 2)]

    public partial class EMTSDataType
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

    public partial class SellPublicSupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }

    public partial class BuyPublicSupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }

    public partial class GenerateSupportingDocumentDetailDataType : SupportingDocumentDetailDataType
    {
    }
}
