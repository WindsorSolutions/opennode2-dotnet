using System.Xml.Serialization;
using System.Data;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using System.ComponentModel;

namespace Windsor.Node2008.WNOSPlugin.TRI4
{
    public class BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PK_GUID;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FK_GUID;
    }

    [DefaultTableNamePrefixAttribute("TRI")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [DefaultStringDbValues(DbType.AnsiString, 100)]

    // TRI_SUB
    [AppliedAttribute(typeof(SubmissionDataType), "Facility", typeof(OneToOneAttribute))]

    // TRI_FAC
    [AppliedAttribute(typeof(FacilitySiteIdentifierDataType), "Value", typeof(ColumnAttribute), "FAC_ID")]
    [AppliedAttribute(typeof(FacilityDataType), "FacilitySiteName", typeof(ColumnAttribute), "FAC_SITE")]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationAddressText", typeof(ColumnAttribute), "LOC_ADD_TXT")]
    [AppliedAttribute(typeof(LocationAddressDataType), "SupplementalLocationText", typeof(ColumnAttribute), "SUPP_LOC_TXT")]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocalityName", typeof(ColumnAttribute), "LOCALITY")]
    [AppliedAttribute(typeof(StateCodeListIdentifierDataType), "Value", typeof(ColumnAttribute), "STATE_CL_ID")]
    [AppliedAttribute(typeof(StateIdentityDataType), "StateCode", typeof(ColumnAttribute), "STATE_CODE", 10)]
    [AppliedAttribute(typeof(StateIdentityDataType), "StateName", typeof(ColumnAttribute), "STATE", 50)]
    [AppliedAttribute(typeof(AddressPostalCodeDataType), "Value", typeof(ColumnAttribute), "ADD_POSTAL_CODE", 50)]
    [AppliedAttribute(typeof(CountryCodeListIdentifierDataType), "Value", typeof(ColumnAttribute), "COUNTRY_CL_ID")]
    [AppliedAttribute(typeof(CountryIdentityDataType), "CountryCode", typeof(ColumnAttribute), "COUNTRY_CODE", 10)]
    [AppliedAttribute(typeof(CountryIdentityDataType), "CountryName", typeof(ColumnAttribute), "COUNTRY", 50)]
    [AppliedAttribute(typeof(CountyCodeListIdentifierDataType), "Value", typeof(ColumnAttribute), "COUNTY_CL_ID")]
    [AppliedAttribute(typeof(CountyIdentityDataType), "CountyCode", typeof(ColumnAttribute), "COUNTY_CODE")]
    [AppliedAttribute(typeof(CountyIdentityDataType), "CountyName", typeof(ColumnAttribute), "COUNTY")]
    [AppliedAttribute(typeof(TribalCodeListIdentifierDataType), "Value", typeof(ColumnAttribute), "TRIBAL_CL_ID")]
    [AppliedAttribute(typeof(TribalIdentityCodeDataType), "TribalCode", typeof(ColumnAttribute), "TRIBAL_CODE")]
    [AppliedAttribute(typeof(TribalIdentityCodeDataType), "TribalName", typeof(ColumnAttribute), "TRIBAL")]
    [AppliedAttribute(typeof(LocationAddressDataType), "TribalLandName", typeof(ColumnAttribute), "TRIBAL_LAND")]
    [AppliedAttribute(typeof(LocationAddressDataType), "TribalLandIndicator", typeof(ColumnAttribute), "TRIBAL_LAND_IND")]
    [AppliedAttribute(typeof(LocationAddressDataType), "LocationDescriptionText", typeof(ColumnAttribute), "LOC_DESCN_TXT")]
    [AppliedAttribute(typeof(FacilityDataType), "MailingFacilitySiteName", typeof(ColumnAttribute), "MAIL_FAC_SITE")]
    [AppliedAttribute(typeof(MailingAddressDataType1), "MailingAddressText", typeof(ColumnAttribute), "MAIL_ADD_TXT")]
    [AppliedAttribute(typeof(MailingAddressDataType1), "SupplementalAddressText", typeof(ColumnAttribute), "SUPP_MAIL_ADD")]
    [AppliedAttribute(typeof(MailingAddressDataType1), "MailingAddressCityName", typeof(ColumnAttribute), "MAIL_ADD_CITY")]
    [AppliedPathAttribute("MailingAddress.AddressPostalCode.Value", typeof(ColumnAttribute), "MAIL_ADD_POSTAL_CODE")]
    [AppliedAttribute(typeof(MailingAddressDataType1), "ProvinceNameText", typeof(ColumnAttribute), "PROVINCE_TXT")]
    [AppliedPathAttribute("MailingAddress.StateIdentity.StateCodeListIdentifier.Value", typeof(ColumnAttribute), "MAIL_ADD_STATE_CDLST")]
    [AppliedPathAttribute("MailingAddress.StateIdentity.StateCode", typeof(ColumnAttribute), "MAIL_ADD_STATE_CODE", 10)]
    [AppliedPathAttribute("MailingAddress.StateIdentity.StateName", typeof(ColumnAttribute), "MAIL_ADD_STATE")]
    [AppliedPathAttribute("MailingAddress.CountryIdentity.CountryCodeListIdentifier.Value", typeof(ColumnAttribute), "MAIL_ADD_COUNTRY_CDLST")]
    [AppliedPathAttribute("MailingAddress.CountryIdentity.CountryCode", typeof(ColumnAttribute), "MAIL_ADD_COUNTRY_CODE", 10)]
    [AppliedPathAttribute("MailingAddress.CountryIdentity.CountryName", typeof(ColumnAttribute), "MAIL_ADD_COUNTRY")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LatitudeMeasure", typeof(ColumnAttribute), "LAT_ME", 20)]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LongitudeMeasure", typeof(ColumnAttribute), "LON_ME", 20)]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "SourceMapScaleNumber", typeof(ColumnAttribute), "SRC_MAP_SCALE_CLBER")]
    [AppliedPathAttribute("HorizontalAccuracyMeasure.MeasureValue", typeof(ColumnAttribute), "HOR_ME_VALUE")]
    [AppliedPathAttribute("HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitCode", typeof(ColumnAttribute), "HOR_ME_UNIT_CODE")]
    [AppliedPathAttribute("HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitName", typeof(ColumnAttribute), "HOR_ME_UNIT")]
    [AppliedPathAttribute("HorizontalAccuracyMeasure.MeasurePrecisionText", typeof(ColumnAttribute), "HOR_ME_PREC_TXT")]
    [AppliedPathAttribute("HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierCode", typeof(ColumnAttribute), "HOR_RESULT_QFR_CODE")]
    [AppliedPathAttribute("HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierName", typeof(ColumnAttribute), "HOR_RESULT_QFR")]
    [AppliedPathAttribute("HorizontalCollectionMethod.MethodIdentifierCode", typeof(ColumnAttribute), "HOR_METH_ID_CODE")]
    [AppliedPathAttribute("HorizontalCollectionMethod.MethodName", typeof(ColumnAttribute), "HOR_METH")]
    [AppliedPathAttribute("HorizontalCollectionMethod.MethodDescriptionText", typeof(ColumnAttribute), "HOR_METH_DESCN_TXT")]
    [AppliedPathAttribute("HorizontalCollectionMethod.MethodDeviationsText", typeof(ColumnAttribute), "HOR_METH_DEV_TXT")]
    [AppliedAttribute(typeof(GeographicReferencePointDataType), "GeographicReferencePointCode", typeof(ColumnAttribute), "GEO_REF_POINT_CD")]
    [AppliedAttribute(typeof(GeographicReferencePointDataType), "GeographicReferencePointName", typeof(ColumnAttribute), "GEO_REF_POINT_NM")]
    [AppliedPathAttribute("HorizontalReferenceDatum.GeographicReferenceDatumCode", typeof(ColumnAttribute), "HOR_REF_DATUM_CD")]
    [AppliedPathAttribute("HorizontalReferenceDatum.GeographicReferenceDatumName", typeof(ColumnAttribute), "HOR_REF_DATUM_NM")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType), "DataCollectionDate", typeof(ColumnAttribute), "DATA_COLLECTION_DATE")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType), "LocationCommentsText", typeof(ColumnAttribute), "LOC_COMS_TXT")]
    [AppliedPathAttribute("VerticalMeasure.MeasureValue", typeof(ColumnAttribute), "VER_ME_VALUE")]
    [AppliedPathAttribute("VerticalMeasure.MeasureUnit.MeasureUnitCode", typeof(ColumnAttribute), "VER_ME_UNIT_CODE")]
    [AppliedPathAttribute("VerticalMeasure.MeasureUnit.MeasureUnitName", typeof(ColumnAttribute), "VER_ME_UNIT")]
    [AppliedPathAttribute("VerticalMeasure.MeasurePrecisionText", typeof(ColumnAttribute), "VER_ME_PREC_TXT")]
    [AppliedPathAttribute("VerticalMeasure.ResultQualifier.ResultQualifierCode", typeof(ColumnAttribute), "VER_RESULT_QFR_CODE")]
    [AppliedPathAttribute("VerticalMeasure.ResultQualifier.ResultQualifierName", typeof(ColumnAttribute), "VER_RESULT_QFR")]
    [AppliedPathAttribute("VerticalCollectionMethod.MethodIdentifierCode", typeof(ColumnAttribute), "VER_METH_ID_CODE")]
    [AppliedPathAttribute("VerticalCollectionMethod.MethodName", typeof(ColumnAttribute), "VER_METH")]
    [AppliedPathAttribute("VerticalCollectionMethod.MethodDescriptionText", typeof(ColumnAttribute), "VER_METH_DESCN_TXT")]
    [AppliedPathAttribute("VerticalCollectionMethod.MethodDeviationsText", typeof(ColumnAttribute), "VER_METH_DEV_TXT")]
    [AppliedPathAttribute("VerticalReferenceDatum.GeographicReferenceDatumCode", typeof(ColumnAttribute), "GEO_REF_DATUM_CD")]
    [AppliedPathAttribute("VerticalReferenceDatum.GeographicReferenceDatumName", typeof(ColumnAttribute), "GEO_REF_DATUM_NM")]
    [AppliedPathAttribute("VerificationMethod.MethodIdentifierCode", typeof(ColumnAttribute), "VERIF_METH_ID")]
    [AppliedPathAttribute("VerificationMethod.MethodName", typeof(ColumnAttribute), "VERIF_METH")]
    [AppliedPathAttribute("VerificationMethod.MethodDescriptionText", typeof(ColumnAttribute), "VERIF_METH_DESC")]
    [AppliedPathAttribute("VerificationMethod.MethodDeviationsText", typeof(ColumnAttribute), "VERIF_METH_DEV")]
    [AppliedAttribute(typeof(CoordinateDataSourceDataType), "CoordinateDataSourceCode", typeof(ColumnAttribute), "COORD_DATA_SRC_CODE")]
    [AppliedAttribute(typeof(CoordinateDataSourceDataType), "CoordinateDataSourceName", typeof(ColumnAttribute), "COORD_DATA_SRC")]
    [AppliedAttribute(typeof(GeometricTypeDataType), "GeometricTypeCode", typeof(ColumnAttribute), "GEOMETRIC_TYPE_CODE")]
    [AppliedAttribute(typeof(GeometricTypeDataType), "GeometricTypeName", typeof(ColumnAttribute), "GEOMETRIC_TYPE")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LatitudeDegreeMeasure", typeof(ColumnAttribute), "LAT_DEGREE_ME")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LatitudeMinuteMeasure", typeof(ColumnAttribute), "LAT_MINUTE_ME")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LatitudeSecondMeasure", typeof(ColumnAttribute), "LAT_SECOND_ME")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LongitudeDegreeMeasure", typeof(ColumnAttribute), "LON_DEGREE_ME")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LongitudeMinuteMeasure", typeof(ColumnAttribute), "LON_MINUTE_ME")]
    [AppliedAttribute(typeof(GeographicLocationDescriptionDataType1), "LongitudeSecondMeasure", typeof(ColumnAttribute), "LON_SECOND_ME")]
    [AppliedAttribute(typeof(CoordinateDataSourceDataType), "ParentCompanyNameText", typeof(ColumnAttribute), "PARENT_COMPANY_TXT")]
    [AppliedAttribute(typeof(CoordinateDataSourceDataType), "ParentDunBradstreetCode", typeof(ColumnAttribute), "PARENT_DUN_CODE")]
    [AppliedAttribute(typeof(FacilityAccessDetailsDataType), "FacilityAccessCode", typeof(ColumnAttribute), "FACILITY_ACCESS_CODE")]
    [AppliedAttribute(typeof(PriorYearTechnicalContactDetailsDataType), "PriorYearTechnicalContactNameText", typeof(ColumnAttribute), "PRI_YR_TECH_CONTACT_NAME")]
    [AppliedAttribute(typeof(PriorYearTechnicalContactDetailsDataType), "PriorYearTechnicalContactTelephoneNumberText", typeof(ColumnAttribute), "PRI_YR_TECH_CONTACT_PHONE")]

    [AppliedAttribute(typeof(FacilityDataType), "ParentCompanyNameNAIndicator", typeof(DbIgnoreAttribute))]//??
    [AppliedAttribute(typeof(StateCodeListIdentifierDataType), "CodeListVersionIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(StateCodeListIdentifierDataType), "CodeListVersionAgencyIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(AddressPostalCodeDataType), "AddressPostalCodeContext", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CountryCodeListIdentifierDataType), "CodeListVersionIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CountryCodeListIdentifierDataType), "CodeListVersionAgencyIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CountyCodeListIdentifierDataType), "CodeListVersionIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CountyCodeListIdentifierDataType), "CodeListVersionAgencyIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(TribalCodeListIdentifierDataType), "CodeListVersionIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(TribalCodeListIdentifierDataType), "CodeListVersionAgencyIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(GeographicReferencePointDataType), "ReferencePointCodeListIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("HorizontalReferenceDatum.GeographicReferenceDatumDataType", typeof(DbIgnoreAttribute))]
    [AppliedPathAttribute("VerticalReferenceDatum.GeographicReferenceDatumDataType", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(CoordinateDataSourceDataType), "CoordinateDataSourceCodeListIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(FacilitySiteIdentifierDataType), "FacilitySiteIdentifierContext", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(FacilityDataType), "FacilityDunBradstreetCode", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(FacilityDataType), "RCRAIdentificationNumber", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(FacilityDataType), "NPDESIdentificationNumber", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(FacilityDataType), "UICIdentificationNumber", typeof(DbIgnoreAttribute))]

    // TRI_FAC_SIC
    [AppliedAttribute(typeof(FacilitySICDataType), "SICCode", typeof(ColumnAttribute), "FAC_SIC")]
    [AppliedAttribute(typeof(FacilitySICDataType), "SICPrimaryIndicator", typeof(ColumnAttribute), "SIC_PRIMARY_IND")]

    // TRI_FAC_NAICS
    [AppliedAttribute(typeof(FacilityNAICSDataType), "NAICSCode", typeof(ColumnAttribute), "FAC_NAICS")]
    [AppliedAttribute(typeof(FacilityNAICSDataType), "NAICSPrimaryIndicator", typeof(ColumnAttribute), "NAICS_PRIMARY_IND")]

    // TRI_REPORT
    /*
	[CHEM_ANC_USAGE_IND] [varchar](100) NULL,
	[CHEM_ARTICLE_COMP_ID] [varchar](100) NULL,
	[CHEM_BYPRODUCT_IND] [varchar](100) NULL,
	[CHEM_FORMULATION_COMP] [varchar](100) NULL,
	[CHEM_IMPORTED_IND] [varchar](100) NULL,
	[CHEM_MANUFACTURE_AID_ID] [varchar](100) NULL,
	[CHEM_MANUFACTURE_IMPURITY] [varchar](100) NULL,
	[CHEM_PROC_IMPURITY_ID] [varchar](100) NULL,
	[CHEM_PROCING_AID_ID] [varchar](100) NULL,
	[CHEM_PRODUCED_IND] [varchar](100) NULL,
	[CHEM_REACTANT_IND] [varchar](100) NULL,
	[CHEM_REP_IND] [varchar](100) NULL,
	[CHEM_SALES_DIST_ID] [varchar](100) NULL,
	[CHEM_USED_PROCED_ID] [varchar](100) NULL,
	[MAX_CHEM_AMOUNT_CODE] [varchar](100) NULL,
	[WASTE_Q_ME] [varchar](100) NULL,
	[WASTE_Q_ME_NA_IND] [char](1) NULL,
	[WASTE_Q_RANGE_CODE] [varchar](100) NULL,
	[Q_BASIS_EST_CODE] [varchar](100) NULL,
	[Q_BASIS_EST_NA_IND] [char](1) NULL,
	[ONE_TIME_RELEASE_Q] [varchar](100) NULL,
	[ONE_TIME_NA_IND] [char](1) NULL,
	[PRODUCTION_RATIO_ME] [varchar](100) NULL,
	[PRODUCTION_RATIO_NA_IND] [char](1) NULL,
	[SUB_ADDITIONAL_DATA_ID] [varchar](100) NULL,
	[OPT_INF_TXT] [varchar](4000) NULL,
	[PUB_CONT_EMAIL_ADDRES] [varchar](100) NULL,
	[CHEM_RPT_REV_CD_1] [varchar](100) NULL,
	[CHEM_RPT_REV_CD_2] [varchar](100) NULL,
	[CHEM_RPT_WD_CD_1] [varchar](100) NULL,
	[CHEM_RPT_WD_CD_2] [varchar](100) NULL,
	[TOX_EQ_VAL1_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL2_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL3_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL4_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL5_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL6_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL7_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL8_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL9_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL10_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL11_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL12_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL13_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL14_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL15_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL16_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL17_POTW] [varchar](100) NULL,
	[TOX_EQ_NA_IND_POTW] [char](1) NULL,
	[WASTE_Q_CATASTROPHIC_MEASURE] [varchar](100) NULL,
	[WASTE_Q_RANGE_NUM_BASIS_VALUE] [varchar](100) NULL,
	[Q_DISP_LANDFILL_PERCENT_VALUE] [varchar](100) NULL,
	[Q_DISP_OTHER_PERCENT_VALUE] [varchar](100) NULL,
	[Q_TREATED_PERCENT_VALUE] [varchar](100) NULL,
	[TOX_EQ_VAL1_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL2_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL3_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL4_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL5_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL6_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL7_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL8_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL9_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL10_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL11_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL12_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL13_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL14_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL15_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL16_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL17_ONETIME] [varchar](100) NULL,
	[TOX_EQ_NA_IND_ONETIME] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
    */
    [AppliedAttribute(typeof(ReportIdentifierDataType), "Value", typeof(ColumnAttribute), "REPORT_ID")]
    [AppliedAttribute(typeof(ReportMetaDataType), "ReportPostmarkDate", typeof(ColumnAttribute), "REPORT_POST_DATE", 50)]
    [AppliedAttribute(typeof(ReportMetaDataType), "ReportReceivedDate", typeof(ColumnAttribute), "REPORT_REC_DATE", 50)]
    [AppliedAttribute(typeof(ReportMetaDataType), "ReportOriginalPostmarkDate", typeof(ColumnAttribute), "REPORT_ORIG_POST_DATE", 50)]
    [AppliedAttribute(typeof(ReportMetaDataType), "ReportOriginalReceivedDate", typeof(ColumnAttribute), "REPORT_ORIG_REC_DATE", 50)]
    [AppliedAttribute(typeof(ReportMetaDataType), "ReportSubmissionMethodCode", typeof(ColumnAttribute), "REPORT_SUB_METH_CODE")]
    [AppliedAttribute(typeof(ReportMetaDataType), "EPAPassedValidationIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "REPORT_EPA_PASSED_VALID_IND", 1)]
    [AppliedAttribute(typeof(ReportMetaDataType), "EPAProcessingStatusCode", typeof(ColumnAttribute), "REPORT_EPA_PROCESSING_STATUS_C")]
    [AppliedAttribute(typeof(ReportMetaDataType), "UnalteredReportIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "UNALTERED_REPORT_IND", 1)]
    [AppliedAttribute(typeof(ReportTypeDataType), "ReportTypeCode", typeof(ColumnAttribute), "REPORT_TYPE_CODE")]
    
    [AppliedAttribute(typeof(ReportDataType), "SubmissionReportingYear", typeof(ColumnAttribute), "SUB_REP_YEAR")]
    [AppliedAttribute(typeof(ReportDataType), "ReportDueDate", typeof(ColumnAttribute), "REPORT_DUE_DATE")]
    [AppliedAttribute(typeof(ReportDataType), "RevisionIndicator", typeof(ColumnAttribute), "REVISION_IND")]
    [AppliedAttribute(typeof(ReportDataType), "ChemicalTradeSecretIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "CHEM_TRADE_SECRET_IND", 1)]
    [AppliedAttribute(typeof(ReportDataType), "SubmissionSanitizedIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "SUB_SANITIZED_IND", 1)]
    [AppliedAttribute(typeof(ReportDataType), "CertifierName", typeof(ColumnAttribute), "CERTIFIER")]
    [AppliedAttribute(typeof(ReportDataType), "CertifierTitleText", typeof(ColumnAttribute), "CERTIFIER_TIT_TXT")]
    [AppliedAttribute(typeof(ReportDataType), "CertificationSignedDate", typeof(ColumnAttribute), "CERT_SIGNED_DATE")]
    [AppliedAttribute(typeof(ReportDataType), "SubmissionEntireFacilityIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "SUB_ENTIRE_FAC_IND", 1)]
    [AppliedAttribute(typeof(ReportDataType), "SubmissionPartialFacilityIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "SUB_PARTIAL_FAC_ID", 1)]
    [AppliedAttribute(typeof(ReportDataType), "SubmissionFederalFacilityIndicator", typeof(ColumnAttribute), "SUB_FEDERAL_FAC_ID")]
    [AppliedAttribute(typeof(ReportDataType), "SubmissionGOCOFacilityIndicator", typeof(ColumnAttribute), DbType.AnsiStringFixedLength, "SUB_CO_FAC_INDIC", 1)]
    //?? Still need to do: [AppliedAttribute(typeof(ReportDataType), "TechnicalContactNameText", typeof(ColumnAttribute), "TECH_CONT")]
    [AppliedAttribute(typeof(ReportDataType), "TechnicalContactPhoneText", typeof(ColumnAttribute), "TECH_CONT_PHONE_TXT")]
    [AppliedAttribute(typeof(ReportDataType), "TechnicalContactEmailAddressText", typeof(ColumnAttribute), "TECH_CONT_EMAIL_ADDRES")]
    //?? [AppliedPathAttribute("PublicContactNameText.IndividualIdentifier.Value", typeof(ColumnAttribute), "PUB_CONT_ID")]
    //?? [AppliedPathAttribute("PublicContactNameText.IndividualTitleText", typeof(ColumnAttribute), "PUB_CONT_TIT_TXT")]
    //?? [AppliedPathAttribute("PublicContactNameText.IndividualFullName", typeof(ColumnAttribute), "PUB_CONT")]
    [AppliedAttribute(typeof(ReportDataType), "PublicContactPhoneText", typeof(ColumnAttribute), "PUB_CONT_PHONE_TXT", 50)]
    [AppliedAttribute(typeof(ReportDataType), "PublicContactEmailAddressText", typeof(ColumnAttribute), "PUB_CONT_PHONE_TXT", 50)]


    [AppliedAttribute(typeof(ReportMetaDataType), "ReportValidation", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportIdentifierDataType), "ReportIdentifierContext", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportDataType), "ReplacedReportIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportDataType), "ChemicalReportRevisionCode", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportDataType), "ChemicalReportWithdrawalCode", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportDataType), "Items", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportDataType), "Items1", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportTypeDataType), "ReportTypeCodeListIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportTypeDataType), "ReportTypeName", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportTypeDataType), "TechnicalContactNameText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportTypeDataType), "PublicContactNameText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ReportDataType), "PublicContactEmailAddressText", typeof(DbIgnoreAttribute))]

    public partial class TRIDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PK_GUID;
    }

    public partial class SubmissionDataType : BaseTableClass
    {
    }

    [Table("TRI_FAC")]
    public partial class FacilityDataType : BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        public FacilityDunBradstreetCodeDataType[] FacilityDunBradstreetCodeList;

        [System.Xml.Serialization.XmlIgnore]
        public RCRAIdentificationNumberDataType[] RCRAIdentificationNumberList;

        [System.Xml.Serialization.XmlIgnore]
        public NPDESIdentificationNumberDataType[] NPDESIdentificationNumberList;

        [System.Xml.Serialization.XmlIgnore]
        public UICIdentificationNumberDataType[] UICIdentificationNumberList;
    }

    [Table("TRI_REPORT")]
    public partial class ReportDataType : BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        public ReplacedReportIdentifierDataType[] ReplacedReportIdentifierList;

        [System.ComponentModel.DescriptionAttribute("The three character code indicating revisions to the TRI report.")]
        [System.Xml.Serialization.XmlIgnore]
        [Column("CHEM_RPT_REV_CD_1")]
        public string ChemicalReportRevisionCode1;

        [System.ComponentModel.DescriptionAttribute("The three character code indicating revisions to the TRI report.")]
        [Column("CHEM_RPT_REV_CD_2")]
        public string ChemicalReportRevisionCode2;

        [System.ComponentModel.DescriptionAttribute("The three character code indicating withdrawals from the TRI report.")]
        [Column("CHEM_RPT_WD_CD_1")]
        public string ChemicalReportWithdrawalCode1;

        [System.ComponentModel.DescriptionAttribute("The three character code indicating withdrawals from the TRI report.")]
        [Column("CHEM_RPT_WD_CD_2")]
        public string ChemicalReportWithdrawalCode2;
    }

    [Table("TRI_FAC_SIC")]
    public partial class FacilitySICDataType : BaseTableClass
    {
    }

    [Table("TRI_FAC_NAICS")]
    public partial class FacilityNAICSDataType : BaseTableClass
    {
    }

    [Table("TRI_FAC_DUN")]
    public class FacilityDunBradstreetCodeDataType : BaseTableClass
    {
        [System.ComponentModel.DescriptionAttribute("The number which has been assigned to a company by Dun and Bradstreet.")]
        [Column("FAC_DUN_CODE", 9)]
        public string Code;
    }

    [Table("TRI_RCRA_ID")]
    public class RCRAIdentificationNumberDataType : BaseTableClass
    {
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the Resource Conservat" +
            "ion and Recovery Act (RCRA).")]
        [Column("RCRA_ID_CLBER")]
        public string Id;
    }

    [Table("TRI_NPDES_ID")]
    public class NPDESIdentificationNumberDataType : BaseTableClass
    {
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the National Pollutant" +
            " Discharge Elimination System (NPDES) program.")]
        [Column("NPDES_ID_CLBER")]
        public string Id;
    }

    [Table("TRI_UIC_ID")]
    public class UICIdentificationNumberDataType : BaseTableClass
    {
        [System.ComponentModel.DescriptionAttribute("The number assigned to the facility by EPA for purposes of the Undergrounf Inject" +
            "ion Well Code (UIC) program.")]
        [Column("UIC_ID_CLBER")]
        public string Id;
    }

    [Table("TRI_REPLACED_REPORT_ID")]
    public class ReplacedReportIdentifierDataType : BaseTableClass
    {
        [System.ComponentModel.DescriptionAttribute("The previous Report Identifier this report intends to replace (for revision only)" +
            ".")]
        [Column("REPLACED_REPORT_ID")]
        public string Id;
    }

    [Table("TRI_CHEM")]
    public partial class ChemicalIdentificationDataType : BaseTableClass
    {
    }

    [Table("TRI_ONSITE_RELEASE_Q")]
    public partial class OnsiteReleaseQuantityDataType : BaseTableClass
    {
    }

    [Table("TRI_TRANSFER_LOC")]
    public partial class TransferLocationDataType : BaseTableClass
    {
    }
}
