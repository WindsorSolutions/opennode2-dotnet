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
