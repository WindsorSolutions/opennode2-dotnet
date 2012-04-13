using System;
using System.Data;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.OWIR_ATT_20
{
    [DefaultTableNamePrefixAttribute("OWIR")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [InheritAppliedAttributesAttribute]
    [AdditionalAbbreviationsAttribute("STATE", "STATE",
                                      "ASSESSMENTS", "ASMT",
                                      "IMPLEMENTATION", "IMPL",
                                      "ATTAINMENT", "ATTAIN",
                                      "REASON", "REASON",
                                      "COMMENT", "COMMENT",
                                      "COMMENTS", "COMMENT"
    )]

    [AppliedAttribute(typeof(NPDESDetailsDataType), "Item", typeof(ColumnAttribute), "NPDESID", DbType.AnsiString, 9, true)]

    [AppliedAttribute(typeof(ATLASDetailsDataType), "TopicSize", typeof(ColumnAttribute), DbType.Decimal, 14, 6)]

    public partial class StateAssessmentDetailsDataType
    {
    }
}
