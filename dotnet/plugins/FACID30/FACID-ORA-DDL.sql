--------------------------------------------------------
--  File created - Tuesday-September-29-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table FACID_AFFL
--------------------------------------------------------

  CREATE TABLE "FACID_AFFL" 
   (	"AFFL_ID" VARCHAR2(40), 
	"FAC_DTLS_ID" VARCHAR2(40), 
	"AFFL_IDEN" VARCHAR2(255), 
	"INDV_TITLE_TEXT" VARCHAR2(255), 
	"NAME_PREFIX_TEXT" VARCHAR2(255), 
	"INDV_FULL_NAME" VARCHAR2(255), 
	"FIRST_NAME" VARCHAR2(128), 
	"MIDDLE_NAME" VARCHAR2(128), 
	"LAST_NAME" VARCHAR2(128), 
	"NAME_SUFFIX_TEXT" VARCHAR2(255), 
	"INDV_IDEN_CONT" VARCHAR2(255), 
	"INDV_IDEN_VAL" VARCHAR2(50), 
	"ORG_FORMAL_NAME" VARCHAR2(128), 
	"ORG_IDEN_CONT" VARCHAR2(255), 
	"ORG_IDEN_VAL" VARCHAR2(50), 
	"MAIL_ADDR_TEXT" VARCHAR2(255), 
	"SUPP_ADDR_TEXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"STA_CODE" VARCHAR2(50), 
	"STA_NAME" VARCHAR2(128), 
	"CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CODE_LIST_VERS_AGN_IDEN" VARCHAR2(50), 
	"CODE_LST_VER_VAL" VARCHAR2(50), 
	"ADDR_POST_CODE_CONT" VARCHAR2(50), 
	"ADDR_POST_CODE_VAL" VARCHAR2(50), 
	"CTRY_CODE" VARCHAR2(50), 
	"CTRY_NAME" VARCHAR2(128), 
	"CTRY_IDEN_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CTRY_IDEN_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"CTRY_IDEN_CODE_LST_VER_VAL" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "FACID_AFFL"."AFFL_ID" IS 'Parent: A container for one or more affiliate for a partner. (AffiliateId)';
 
   COMMENT ON COLUMN "FACID_AFFL"."FAC_DTLS_ID" IS 'Parent: A container for one or more affiliate for a partner. (FacilityDetailsId)';
 
   COMMENT ON COLUMN "FACID_AFFL"."AFFL_IDEN" IS 'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)';
 
   COMMENT ON COLUMN "FACID_AFFL"."INDV_TITLE_TEXT" IS 'The title held by a person in an organization. (IndividualTitleText)';
 
   COMMENT ON COLUMN "FACID_AFFL"."NAME_PREFIX_TEXT" IS 'The text that describes the title that precedes an individual''s name. (NamePrefixText)';
 
   COMMENT ON COLUMN "FACID_AFFL"."INDV_FULL_NAME" IS 'Parent: A container for one or more affiliate for a partner. (IndividualFullName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."FIRST_NAME" IS 'Parent: A container for one or more affiliate for a partner. (FirstName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."MIDDLE_NAME" IS 'Parent: A container for one or more affiliate for a partner. (MiddleName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."LAST_NAME" IS 'Parent: A container for one or more affiliate for a partner. (LastName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."NAME_SUFFIX_TEXT" IS 'Additional title that indicates lineage or professional title. (NameSuffixText)';
 
   COMMENT ON COLUMN "FACID_AFFL"."INDV_IDEN_CONT" IS 'Parent: A designator used to uniquely identify an individual within a context. (IndividualIdentifierContext)';
 
   COMMENT ON COLUMN "FACID_AFFL"."INDV_IDEN_VAL" IS 'Parent: A designator used to uniquely identify an individual within a context. (Value)';
 
   COMMENT ON COLUMN "FACID_AFFL"."ORG_FORMAL_NAME" IS 'The legal designator (i.e. formal name) of an organization. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."ORG_IDEN_CONT" IS 'Parent: A designator used to uniquely identify a unique business establishment within a context. (OrganizationIdentifierContext)';
 
   COMMENT ON COLUMN "FACID_AFFL"."ORG_IDEN_VAL" IS 'Parent: A designator used to uniquely identify a unique business establishment within a context. (Value)';
 
   COMMENT ON COLUMN "FACID_AFFL"."MAIL_ADDR_TEXT" IS 'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "FACID_AFFL"."SUPP_ADDR_TEXT" IS 'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "FACID_AFFL"."MAIL_ADDR_CITY_NAME" IS 'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."STA_CODE" IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)';
 
   COMMENT ON COLUMN "FACID_AFFL"."STA_NAME" IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CODE_LIST_VERS_AGN_IDEN" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_AFFL"."ADDR_POST_CODE_CONT" IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)';
 
   COMMENT ON COLUMN "FACID_AFFL"."ADDR_POST_CODE_VAL" IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CTRY_NAME" IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CTRY_IDEN_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CTRY_IDEN_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_AFFL"."CTRY_IDEN_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
--------------------------------------------------------
--  DDL for Table FACID_AFFL_ELEC_ADDR
--------------------------------------------------------

  CREATE TABLE "FACID_AFFL_ELEC_ADDR" 
   (	"AFFL_ELEC_ADDR_ID" VARCHAR2(40), 
	"AFFL_ID" VARCHAR2(40), 
	"ELEC_ADDR_TEXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "FACID_AFFL_ELEC_ADDR"."AFFL_ELEC_ADDR_ID" IS 'Parent: A container for one or more electronic addresses. (AffiliateElectronicAddressId)';
 
   COMMENT ON COLUMN "FACID_AFFL_ELEC_ADDR"."AFFL_ID" IS 'Parent: A container for one or more electronic addresses. (AffiliateId)';
 
   COMMENT ON COLUMN "FACID_AFFL_ELEC_ADDR"."ELEC_ADDR_TEXT" IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "FACID_AFFL_ELEC_ADDR"."ELEC_ADDR_TYPE_NAME" IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)';
--------------------------------------------------------
--  DDL for Table FACID_ALT_NAME
--------------------------------------------------------

  CREATE TABLE "FACID_ALT_NAME" 
   (	"ALT_NAME_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"ALT_NAME_TEXT" VARCHAR2(255), 
	"ALT_NAME_TYPE_TEXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "FACID_ALT_NAME"."ALT_NAME_ID" IS 'Parent: A container for one or more alternative names. (AlternativeNameId)';
 
   COMMENT ON COLUMN "FACID_ALT_NAME"."FAC_ID" IS 'Parent: A container for one or more alternative names. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_ALT_NAME"."ALT_NAME_TEXT" IS 'An alternative, historic or program specific name for the facility site. (AlternativeNameText)';
 
   COMMENT ON COLUMN "FACID_ALT_NAME"."ALT_NAME_TYPE_TEXT" IS 'The type of the alternative, historical, or program-specific name for the facility site (e.g., primary, legal, historical, local). (AlternativeNameTypeText)';
--------------------------------------------------------
--  DDL for Table FACID_ENVR_INTR
--------------------------------------------------------

  CREATE TABLE "FACID_ENVR_INTR" 
   (	"ENVR_INTR_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"ENVR_INTR_URL_TEXT" VARCHAR2(255), 
	"ENVR_INTR_IDEN" VARCHAR2(50), 
	"ENVR_INTR_TYPE_TEXT" VARCHAR2(255), 
	"ENVR_INTR_START_DATE" TIMESTAMP (6), 
	"ENVR_INTR_START_DATE_QUAL_TEXT" VARCHAR2(255), 
	"ENVR_INTR_END_DATE" TIMESTAMP (6), 
	"ENVR_INTR_END_DATE_QUAL_TEXT" VARCHAR2(255), 
	"ENVR_INTR_ACTIVE_INDI" VARCHAR2(1), 
	"LAST_UPDT_DATE" TIMESTAMP (6), 
	"ORIG_PART_NAME" VARCHAR2(128), 
	"INFO_SYS_ACRO_NAME" VARCHAR2(128), 
	"AGN_TYPE_CODE" VARCHAR2(50), 
	"AGN_TYPE_NAME" VARCHAR2(128), 
	"CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CODE_LIST_VERS_AGN_IDEN" VARCHAR2(50), 
	"CODE_LST_VER_VAL" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_ID" IS 'Parent: A container for one or more environmental interests. (EnvironmentalInterestId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."FAC_ID" IS 'Parent: A container for one or more environmental interests. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_URL_TEXT" IS 'The web address where a computer user can access information about the facility. (EnvironmentalInterestURLText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_IDEN" IS 'A designator, such as a permit number, assigned by an information management system that is used to identify an environmental interest (e.g. permit, etc.) for a partner. (EnvironmentalInterestIdentifier)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_TYPE_TEXT" IS 'The environmental permit or regulatory program that applies to the facility site. (EnvironmentalInterestTypeText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_START_DATE" IS 'The date the agency became interested in the facility site for a particular environmental interest type. (EnvironmentalInterestStartDate)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_START_DATE_QUAL_TEXT" IS 'The qualifier that specifies the meaning of  the date being used as an approximation for the environmental interest start date. (EnvironmentalInterestStartDateQualifierText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_END_DATE" IS 'The date the agency ceased to be interested in the facility site for a particular environmental interest type. (EnvironmentalInterestEndDate)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_END_DATE_QUAL_TEXT" IS 'The qualifier that specifies the meaning of  the date being used as an approximation for the environmental interest end date. (EnvironmentalInterestEndDateQualifierText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ENVR_INTR_ACTIVE_INDI" IS 'A designator that indicates whether the Environmental Interest is currently considered to active. (EnvironmentalInterestActiveIndicator)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."LAST_UPDT_DATE" IS 'A value corresponding to the date the facility site or environmental interest was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."ORIG_PART_NAME" IS 'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."INFO_SYS_ACRO_NAME" IS 'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."AGN_TYPE_CODE" IS 'The code that represents a type of federal, state, or local agency. (AgencyTypeCode)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."AGN_TYPE_NAME" IS 'A description of the agency type code. (AgencyTypeName)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."CODE_LIST_VERS_AGN_IDEN" IS 'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR"."CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
--------------------------------------------------------
--  DDL for Table FACID_ENVR_INTR_ALT_IDEN
--------------------------------------------------------

  CREATE TABLE "FACID_ENVR_INTR_ALT_IDEN" 
   (	"ENVR_INTR_ALT_IDEN_ID" VARCHAR2(40), 
	"ENVR_INTR_ID" VARCHAR2(40), 
	"ALT_IDEN_IDEN" VARCHAR2(50), 
	"ALT_IDEN_TYPE_TEXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "FACID_ENVR_INTR_ALT_IDEN"."ENVR_INTR_ALT_IDEN_ID" IS 'Parent: A container for one or more alternative identifiers. (EnvironmentalInterestAlternativeIdentificationId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_ALT_IDEN"."ENVR_INTR_ID" IS 'Parent: A container for one or more alternative identifiers. (EnvironmentalInterestId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_ALT_IDEN"."ALT_IDEN_IDEN" IS 'An alternative, historic or program specific identifier for the facility site or environmental interest. (AlternativeIdentificationIdentifier)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_ALT_IDEN"."ALT_IDEN_TYPE_TEXT" IS 'The type of the alternative, historical, or program-specific identifier for the facility site or environmental interest.  (AlternativeIdentificationTypeText)';
--------------------------------------------------------
--  DDL for Table FACID_ENVR_INTR_ELEC_ADDR
--------------------------------------------------------

  CREATE TABLE "FACID_ENVR_INTR_ELEC_ADDR" 
   (	"ENVR_INTR_ELEC_ADDR_ID" VARCHAR2(40), 
	"ENVR_INTR_ID" VARCHAR2(40), 
	"ELEC_ADDR_TEXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "FACID_ENVR_INTR_ELEC_ADDR"."ENVR_INTR_ELEC_ADDR_ID" IS 'Parent: A container for one or more electronic addresses. (EnvironmentalInterestElectronicAddressId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_ELEC_ADDR"."ENVR_INTR_ID" IS 'Parent: A container for one or more electronic addresses. (EnvironmentalInterestId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_ELEC_ADDR"."ELEC_ADDR_TEXT" IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_ELEC_ADDR"."ELEC_ADDR_TYPE_NAME" IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)';
--------------------------------------------------------
--  DDL for Table FACID_ENVR_INTR_FAC_AFFL
--------------------------------------------------------

  CREATE TABLE "FACID_ENVR_INTR_FAC_AFFL" 
   (	"ENVR_INTR_FAC_AFFL_ID" VARCHAR2(40), 
	"ENVR_INTR_ID" VARCHAR2(40), 
	"AFFL_IDEN" VARCHAR2(255), 
	"AFFL_TYPE_TEXT" VARCHAR2(255), 
	"AFFL_START_DATE" TIMESTAMP (6), 
	"AFFL_END_DATE" TIMESTAMP (6), 
	"AFFL_STAT_TEXT" VARCHAR2(4), 
	"AFFL_STAT_DETR_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."ENVR_INTR_FAC_AFFL_ID" IS 'Parent: A container for one or more affiliations. (EnvironmentalInterestFacilityAffiliationId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."ENVR_INTR_ID" IS 'Parent: A container for one or more affiliations. (EnvironmentalInterestId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."AFFL_IDEN" IS 'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."AFFL_TYPE_TEXT" IS 'The name that describes the capacity or function that an organization or individual serves; or the relationship between an individual or organization and a project or action. (AffiliationTypeText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."AFFL_START_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."AFFL_END_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."AFFL_STAT_TEXT" IS 'The status of an affiliation between an individual or organization and a facility, project, or action. (AffiliationStatusText)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_AFFL"."AFFL_STAT_DETR_DATE" IS 'The date on which the status of an affiliation between an individual or organization and a facility, project, or action is determined. (AffiliationStatusDetermineDate)';
--------------------------------------------------------
--  DDL for Table FACID_ENVR_INTR_FAC_NAICS
--------------------------------------------------------

  CREATE TABLE "FACID_ENVR_INTR_FAC_NAICS" 
   (	"ENVR_INTR_FAC_NAICS_ID" VARCHAR2(40), 
	"ENVR_INTR_ID" VARCHAR2(40), 
	"FAC_NAICS_CODE" VARCHAR2(50), 
	"FAC_NAICS_PRI_INDI" VARCHAR2(9)
   ) ;
 

   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_NAICS"."ENVR_INTR_FAC_NAICS_ID" IS 'Parent: A container for one or more NAICS codes. (EnvironmentalInterestFacilityNAICSId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_NAICS"."ENVR_INTR_ID" IS 'Parent: A container for one or more NAICS codes. (EnvironmentalInterestId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_NAICS"."FAC_NAICS_CODE" IS 'The code that represents a subdivision of an industry that accommodates user needs in the United States. (FacilityNAICSCode)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_NAICS"."FAC_NAICS_PRI_INDI" IS 'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (FacilityNAICSPrimaryIndicator)';
--------------------------------------------------------
--  DDL for Table FACID_ENVR_INTR_FAC_SIC
--------------------------------------------------------

  CREATE TABLE "FACID_ENVR_INTR_FAC_SIC" 
   (	"ENVR_INTR_FAC_SIC_ID" VARCHAR2(40), 
	"ENVR_INTR_ID" VARCHAR2(40), 
	"SIC_CODE" VARCHAR2(50), 
	"SIC_PRI_INDI" VARCHAR2(9)
   ) ;
 

   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_SIC"."ENVR_INTR_FAC_SIC_ID" IS 'Parent: A container for one or more SIC Codes. (EnvironmentalInterestFacilitySICId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_SIC"."ENVR_INTR_ID" IS 'Parent: A container for one or more SIC Codes. (EnvironmentalInterestId)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_SIC"."SIC_CODE" IS 'The code that represents the economic activity of a company. (SICCode)';
 
   COMMENT ON COLUMN "FACID_ENVR_INTR_FAC_SIC"."SIC_PRI_INDI" IS 'The name that indicates whether the associated SIC Code represents the primary activity occurring at the facility site. (SICPrimaryIndicator)';
--------------------------------------------------------
--  DDL for Table FACID_FAC
--------------------------------------------------------

  CREATE TABLE "FACID_FAC" 
   (	"FAC_ID" VARCHAR2(40), 
	"FAC_DTLS_ID" VARCHAR2(40), 
	"FAC_URL_TEXT" VARCHAR2(255), 
	"DELETED_ON_DATE" TIMESTAMP (6), 
	"FAC_ACTIVE_INDI" VARCHAR2(1), 
	"CONG_DIST_NUM_CODE" VARCHAR2(50), 
	"LEGI_DIST_NUM_CODE" VARCHAR2(50), 
	"HUC_CODE" VARCHAR2(50), 
	"FAC_SITE_NAME" VARCHAR2(128), 
	"FED_FAC_INDI" VARCHAR2(4), 
	"FAC_SITE_IDEN_CONT" VARCHAR2(255), 
	"FAC_SITE_IDEN_VAL" VARCHAR2(50), 
	"FAC_SITE_TYPE_CODE" VARCHAR2(50), 
	"FAC_SITE_TYPE_NAME" VARCHAR2(128), 
	"CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CODE_LIST_VERS_AGN_IDEN" VARCHAR2(50), 
	"CODE_LST_VER_VAL" VARCHAR2(50), 
	"LOC_ADDR_TEXT" VARCHAR2(255), 
	"SUPP_LOC_TEXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"TRIB_LAND_NAME" VARCHAR2(128), 
	"TRIB_LAND_INDI" VARCHAR2(4), 
	"LOC_DESC_TEXT" VARCHAR2(255), 
	"STA_CODE" VARCHAR2(50), 
	"STA_NAME" VARCHAR2(128), 
	"LOC_ADDR_CODE_LST_VER_VAL" VARCHAR2(50), 
	"LOC_ADDR_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"LOC_ADDR_CODE_LIST_VER_AGN_IDE" VARCHAR2(50), 
	"ADDR_POST_CODE_VAL" VARCHAR2(50), 
	"ADDR_POST_CODE_CONT" VARCHAR2(50), 
	"CTRY_CODE" VARCHAR2(50), 
	"CTRY_NAME" VARCHAR2(128), 
	"LOC_ADDR_COD_LST_VER_VAL" VARCHAR2(50), 
	"LOC_ADDR_CODE_LIST_VERS_IDE" VARCHAR2(50), 
	"LOC_ADDR_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"CNTY_CODE" VARCHAR2(50), 
	"CNTY_NAME" VARCHAR2(128), 
	"LOC_ADDR_CODE_LIST_VER_IDE" VARCHAR2(50), 
	"LOC_ADDR_COD_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"LOC_ADD_COD_LST_VER_VAL" VARCHAR2(50), 
	"MAIL_ADDR_TEXT" VARCHAR2(255), 
	"SUPP_ADDR_TEXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_STA_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CODE_LST_VER_VAL" VARCHAR2(50), 
	"MAIL_ADDR_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"MAIL_ADDR_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"MAIL_ADDR_ADDR_POST_CODE_VAL" VARCHAR2(50), 
	"MAIL_ADDR_ADDR_POST_CODE_CONT" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_COD_LST_VER_VAL" VARCHAR2(50), 
	"MAIL_ADDR_CODE_LIST_VERS_IDE" VARCHAR2(50), 
	"MAIL_ADDR_COD_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"ORIG_PART_NAME" VARCHAR2(128), 
	"INFO_SYS_ACRO_NAME" VARCHAR2(128), 
	"LAST_UPDT_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC"."FAC_ID" IS 'Parent: A container for one or more facility sites for a partner. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_DTLS_ID" IS 'Parent: A container for one or more facility sites for a partner. (FacilityDetailsId)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_URL_TEXT" IS 'The web address where a computer user can access information about the facility. (FacilityURLText)';
 
   COMMENT ON COLUMN "FACID_FAC"."DELETED_ON_DATE" IS 'The date that this facility was deleted, or null if the facility has not been deleted. (DeletedOnDate)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_ACTIVE_INDI" IS 'A designator that indicates whether the Facility is currently considered to active. (FacilityActiveIndicator)';
 
   COMMENT ON COLUMN "FACID_FAC"."CONG_DIST_NUM_CODE" IS 'A number representing an area within a state that a member of the House of Representatives is elected. (CongressionalDistrictNumberCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."LEGI_DIST_NUM_CODE" IS 'A number representing an area from which senators and General Assembly members are elected. (LegislativeDistrictNumberCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."HUC_CODE" IS 'The hydrologic unit code (HUC) that represents a geographic area representing part or all of a surface drainage basin, a combination of drainage basins, or a distinct hydrologic feature. (HUCCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_SITE_NAME" IS 'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)';
 
   COMMENT ON COLUMN "FACID_FAC"."FED_FAC_INDI" IS 'An indicator identifying facilities owned or operated by a federal government unit. (FederalFacilityIndicator)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_SITE_IDEN_CONT" IS 'Parent: The unique identification number used by a governmental entity to identify a facility site. (FacilitySiteIdentifierContext)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_SITE_IDEN_VAL" IS 'Parent: The unique identification number used by a governmental entity to identify a facility site. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_SITE_TYPE_CODE" IS 'The code that represents the type of site a facility occupies. (FacilitySiteTypeCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."FAC_SITE_TYPE_NAME" IS 'The descriptive name for the type of site the facility occupies. (FacilitySiteTypeName)';
 
   COMMENT ON COLUMN "FACID_FAC"."CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."CODE_LIST_VERS_AGN_IDEN" IS 'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_TEXT" IS 'The address that describes the physical (geographic) location of the front door or main entrance of a facility site, including urban-style street address or rural address. (LocationAddressText)';
 
   COMMENT ON COLUMN "FACID_FAC"."SUPP_LOC_TEXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOCA_NAME" IS 'The name of a city, town, village or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "FACID_FAC"."TRIB_LAND_NAME" IS 'The name of an American Indian or Alaskan native area where the location address exists. (TribalLandName)';
 
   COMMENT ON COLUMN "FACID_FAC"."TRIB_LAND_INDI" IS 'An indicator denoting the location address is a tribal land (TribalLandIndicator)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_DESC_TEXT" IS 'A brief explanation of a location, including navigational directions and/or more descriptive information. (LocationDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC"."STA_CODE" IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."STA_NAME" IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_CODE_LIST_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."ADDR_POST_CODE_VAL" IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."ADDR_POST_CODE_CONT" IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)';
 
   COMMENT ON COLUMN "FACID_FAC"."CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."CTRY_NAME" IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_CODE_LIST_VERS_IDE" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."CNTY_CODE" IS 'The code that represents the county. (CountyCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."CNTY_NAME" IS 'A description of the county code. (CountyName)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_CODE_LIST_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADDR_COD_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."LOC_ADD_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_TEXT" IS 'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "FACID_FAC"."SUPP_ADDR_TEXT" IS 'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CITY_NAME" IS 'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_STA_CODE" IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_STA_NAME" IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_ADDR_POST_CODE_VAL" IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_ADDR_POST_CODE_CONT" IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CTRY_NAME" IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_CODE_LIST_VERS_IDE" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."MAIL_ADDR_COD_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC"."ORIG_PART_NAME" IS 'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)';
 
   COMMENT ON COLUMN "FACID_FAC"."INFO_SYS_ACRO_NAME" IS 'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)';
 
   COMMENT ON COLUMN "FACID_FAC"."LAST_UPDT_DATE" IS 'A value corresponding to the date the facility site or environmental interest was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_ALT_IDEN
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_ALT_IDEN" 
   (	"FAC_ALT_IDEN_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"ALT_IDEN_IDEN" VARCHAR2(50), 
	"ALT_IDEN_TYPE_TEXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_ALT_IDEN"."FAC_ALT_IDEN_ID" IS 'Parent: A container for one or more alternative identifiers. (FacilityAlternativeIdentificationId)';
 
   COMMENT ON COLUMN "FACID_FAC_ALT_IDEN"."FAC_ID" IS 'Parent: A container for one or more alternative identifiers. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_ALT_IDEN"."ALT_IDEN_IDEN" IS 'An alternative, historic or program specific identifier for the facility site or environmental interest. (AlternativeIdentificationIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_ALT_IDEN"."ALT_IDEN_TYPE_TEXT" IS 'The type of the alternative, historical, or program-specific identifier for the facility site or environmental interest.  (AlternativeIdentificationTypeText)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_DTLS
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_DTLS" 
   (	"FAC_DTLS_ID" VARCHAR2(40)
   ) ;
--------------------------------------------------------
--  DDL for Table FACID_FAC_ELEC_ADDR
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_ELEC_ADDR" 
   (	"FAC_ELEC_ADDR_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"ELEC_ADDR_TEXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_ELEC_ADDR"."FAC_ELEC_ADDR_ID" IS 'Parent: A container for one or more electronic addresses. (FacilityElectronicAddressId)';
 
   COMMENT ON COLUMN "FACID_FAC_ELEC_ADDR"."FAC_ID" IS 'Parent: A container for one or more electronic addresses. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_ELEC_ADDR"."ELEC_ADDR_TEXT" IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "FACID_FAC_ELEC_ADDR"."ELEC_ADDR_TYPE_NAME" IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_FAC_AFFL
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_FAC_AFFL" 
   (	"FAC_FAC_AFFL_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"AFFL_IDEN" VARCHAR2(255), 
	"AFFL_TYPE_TEXT" VARCHAR2(255), 
	"AFFL_START_DATE" TIMESTAMP (6), 
	"AFFL_END_DATE" TIMESTAMP (6), 
	"AFFL_STAT_TEXT" VARCHAR2(4), 
	"AFFL_STAT_DETR_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."FAC_FAC_AFFL_ID" IS 'Parent: A container for one or more affiliations. (FacilityFacilityAffiliationId)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."FAC_ID" IS 'Parent: A container for one or more affiliations. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."AFFL_IDEN" IS 'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."AFFL_TYPE_TEXT" IS 'The name that describes the capacity or function that an organization or individual serves; or the relationship between an individual or organization and a project or action. (AffiliationTypeText)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."AFFL_START_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."AFFL_END_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."AFFL_STAT_TEXT" IS 'The status of an affiliation between an individual or organization and a facility, project, or action. (AffiliationStatusText)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_AFFL"."AFFL_STAT_DETR_DATE" IS 'The date on which the status of an affiliation between an individual or organization and a facility, project, or action is determined. (AffiliationStatusDetermineDate)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_FAC_NAICS
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_FAC_NAICS" 
   (	"FAC_FAC_NAICS_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"FAC_NAICS_CODE" VARCHAR2(50), 
	"FAC_NAICS_PRI_INDI" VARCHAR2(9)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_FAC_NAICS"."FAC_FAC_NAICS_ID" IS 'Parent: A container for one or more NAICS codes. (FacilityFacilityNAICSId)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_NAICS"."FAC_ID" IS 'Parent: A container for one or more NAICS codes. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_NAICS"."FAC_NAICS_CODE" IS 'The code that represents a subdivision of an industry that accommodates user needs in the United States. (FacilityNAICSCode)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_NAICS"."FAC_NAICS_PRI_INDI" IS 'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (FacilityNAICSPrimaryIndicator)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_FAC_SIC
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_FAC_SIC" 
   (	"FAC_FAC_SIC_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"SIC_CODE" VARCHAR2(50), 
	"SIC_PRI_INDI" VARCHAR2(9)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_FAC_SIC"."FAC_FAC_SIC_ID" IS 'Parent: A container for one or more SIC Codes. (FacilityFacilitySICId)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_SIC"."FAC_ID" IS 'Parent: A container for one or more SIC Codes. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_SIC"."SIC_CODE" IS 'The code that represents the economic activity of a company. (SICCode)';
 
   COMMENT ON COLUMN "FACID_FAC_FAC_SIC"."SIC_PRI_INDI" IS 'The name that indicates whether the associated SIC Code represents the primary activity occurring at the facility site. (SICPrimaryIndicator)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_GEO_LOC_DESC
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_GEO_LOC_DESC" 
   (	"FAC_GEO_LOC_DESC_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"SRC_MAP_SCALE_NUM" VARCHAR2(20), 
	"DATA_COLL_DATE" TIMESTAMP (6), 
	"LOC_COMM_TEXT" VARCHAR2(255), 
	"SRS_NAME" VARCHAR2(255), 
	"SRS_DIM" VARCHAR2(10), 
	"LATITUDE" NUMBER(19,14), 
	"LONGITUDE" NUMBER(19,14), 
	"ELEVATION" NUMBER(19,14), 
	"MEAS_VAL" VARCHAR2(50), 
	"MEAS_PREC_TEXT" VARCHAR2(50), 
	"MEAS_UNIT_CODE" VARCHAR2(50), 
	"MEAS_UNIT_NAME" VARCHAR2(50), 
	"CODE_LST_VER_VAL" VARCHAR2(50), 
	"CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CODE_LIST_VERS_AGN_IDEN" VARCHAR2(50), 
	"RSLT_QUAL_CODE" VARCHAR2(50), 
	"RSLT_QUAL_NAME" VARCHAR2(128), 
	"RSLT_QUAL_CODE_LST_VER_VAL" VARCHAR2(50), 
	"RSLT_QUAL_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"RSLT_QUAL_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"METH_IDEN_CODE" VARCHAR2(50), 
	"METH_NAME" VARCHAR2(128), 
	"METH_DESC_TEXT" VARCHAR2(255), 
	"METH_DEVI_TEXT" VARCHAR2(255), 
	"HORZ_COLL_METH_COD_LST_VER_VAL" VARCHAR2(50), 
	"HORZ_COLL_METH_COD_LIS_VER_IDE" VARCHAR2(50), 
	"HOR_COL_MET_COD_LIS_VER_AGN_ID" VARCHAR2(50), 
	"GEO_REF_PT_CODE" VARCHAR2(50), 
	"GEO_REF_PT_NAME" VARCHAR2(128), 
	"GEO_REF_PT_CODE_LST_VER_VAL" VARCHAR2(50), 
	"GEO_REF_PT_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"GEO_REF_PT_COD_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"VERT_COLL_METH_METH_IDEN_CODE" VARCHAR2(50), 
	"VERT_COLL_METH_METH_NAME" VARCHAR2(128), 
	"VERT_COLL_METH_METH_DESC_TEXT" VARCHAR2(255), 
	"VERT_COLL_METH_METH_DEVI_TEXT" VARCHAR2(255), 
	"VERT_COLL_METH_COD_LST_VER_VAL" VARCHAR2(50), 
	"VERT_COLL_METH_COD_LIS_VER_IDE" VARCHAR2(50), 
	"VER_COL_MET_COD_LIS_VER_AGN_ID" VARCHAR2(50), 
	"VERF_METH_METH_IDEN_CODE" VARCHAR2(50), 
	"VERF_METH_METH_NAME" VARCHAR2(128), 
	"VERF_METH_METH_DESC_TEXT" VARCHAR2(255), 
	"VERF_METH_METH_DEVI_TEXT" VARCHAR2(255), 
	"VERF_METH_CODE_LST_VER_VAL" VARCHAR2(50), 
	"VERF_METH_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"VERF_METH_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"CORD_DATA_SRC_CODE" VARCHAR2(50), 
	"CORD_DATA_SRC_NAME" VARCHAR2(128), 
	"CORD_DATA_SRC_CODE_LST_VER_VAL" VARCHAR2(50), 
	"CORD_DATA_SRC_CODE_LIS_VER_IDE" VARCHAR2(50), 
	"COR_DAT_SRC_COD_LIS_VER_AGN_ID" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."FAC_GEO_LOC_DESC_ID" IS 'Parent: A container for one or more facility locations. (FacilityGeographicLocationDescriptionId)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."FAC_ID" IS 'Parent: A container for one or more facility locations. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."DATA_COLL_DATE" IS 'The calendar date when data were collected. (DataCollectionDate)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."LOC_COMM_TEXT" IS 'The text that provides additional information about the geographic coordinates. (LocationCommentsText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."SRS_NAME" IS 'Parent: A container for one or more facility locations. (srsName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."SRS_DIM" IS 'Parent: A container for one or more facility locations. (srsDimension)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."LATITUDE" IS 'Parent: A container for one or more facility locations. (Latitude)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."LONGITUDE" IS 'Parent: A container for one or more facility locations. (Longitude)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."ELEVATION" IS 'Parent: A container for one or more facility locations. (Elevation)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."MEAS_VAL" IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."MEAS_PREC_TEXT" IS 'The precision of the recorded value. (MeasurePrecisionText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."MEAS_UNIT_CODE" IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."MEAS_UNIT_NAME" IS 'A description of the unit of measure code. (MeasureUnitName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CODE_LIST_VERS_AGN_IDEN" IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."RSLT_QUAL_CODE" IS 'A code used to identify any qualifying issues that affect the results. (ResultQualifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."RSLT_QUAL_NAME" IS 'A description of the result code of any qualifying issues that affect the results. (ResultQualifierName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."RSLT_QUAL_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."RSLT_QUAL_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."RSLT_QUAL_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (MethodName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."METH_DESC_TEXT" IS 'A brief summary that provides general information about the method. (MethodDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."METH_DEVI_TEXT" IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."HORZ_COLL_METH_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."HORZ_COLL_METH_COD_LIS_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."HOR_COL_MET_COD_LIS_VER_AGN_ID" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."GEO_REF_PT_CODE" IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."GEO_REF_PT_NAME" IS 'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."GEO_REF_PT_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."GEO_REF_PT_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."GEO_REF_PT_COD_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERT_COLL_METH_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERT_COLL_METH_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (MethodName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERT_COLL_METH_METH_DESC_TEXT" IS 'A brief summary that provides general information about the method. (MethodDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERT_COLL_METH_METH_DEVI_TEXT" IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERT_COLL_METH_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERT_COLL_METH_COD_LIS_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VER_COL_MET_COD_LIS_VER_AGN_ID" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (MethodName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_METH_DESC_TEXT" IS 'A brief summary that provides general information about the method. (MethodDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_METH_DEVI_TEXT" IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."VERF_METH_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CORD_DATA_SRC_NAME" IS 'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CORD_DATA_SRC_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."CORD_DATA_SRC_CODE_LIS_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_GEO_LOC_DESC"."COR_DAT_SRC_COD_LIS_VER_AGN_ID" IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
--------------------------------------------------------
--  DDL for Table FACID_FAC_PRI_GEO_LOC_DESC
--------------------------------------------------------

  CREATE TABLE "FACID_FAC_PRI_GEO_LOC_DESC" 
   (	"FAC_PRI_GEO_LOC_DESC_ID" VARCHAR2(40), 
	"FAC_ID" VARCHAR2(40), 
	"SRC_MAP_SCALE_NUM" VARCHAR2(20), 
	"DATA_COLL_DATE" TIMESTAMP (6), 
	"LOC_COMM_TEXT" VARCHAR2(255), 
	"SRS_NAME" VARCHAR2(255), 
	"SRS_DIM" VARCHAR2(10), 
	"LATITUDE" NUMBER(19,14), 
	"LONGITUDE" NUMBER(19,14), 
	"ELEVATION" NUMBER(19,14), 
	"MEAS_VAL" VARCHAR2(50), 
	"MEAS_PREC_TEXT" VARCHAR2(50), 
	"MEAS_UNIT_CODE" VARCHAR2(50), 
	"MEAS_UNIT_NAME" VARCHAR2(50), 
	"CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CODE_LIST_VERS_AGN_IDEN" VARCHAR2(50), 
	"CODE_LST_VER_VAL" VARCHAR2(50), 
	"RSLT_QUAL_CODE" VARCHAR2(50), 
	"RSLT_QUAL_NAME" VARCHAR2(128), 
	"RSLT_QUAL_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"RSLT_QUAL_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"RSLT_QUAL_CODE_LST_VER_VAL" VARCHAR2(50), 
	"METH_IDEN_CODE" VARCHAR2(50), 
	"METH_NAME" VARCHAR2(128), 
	"METH_DESC_TEXT" VARCHAR2(255), 
	"METH_DEVI_TEXT" VARCHAR2(255), 
	"HORZ_COLL_METH_COD_LIS_VER_IDE" VARCHAR2(50), 
	"HOR_COL_MET_COD_LIS_VER_AGN_ID" VARCHAR2(50), 
	"HORZ_COLL_METH_COD_LST_VER_VAL" VARCHAR2(50), 
	"GEO_REF_PT_CODE" VARCHAR2(50), 
	"GEO_REF_PT_NAME" VARCHAR2(128), 
	"GEO_REF_PT_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"GEO_REF_PT_COD_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"GEO_REF_PT_CODE_LST_VER_VAL" VARCHAR2(50), 
	"VERT_COLL_METH_METH_IDEN_CODE" VARCHAR2(50), 
	"VERT_COLL_METH_METH_NAME" VARCHAR2(128), 
	"VERT_COLL_METH_METH_DESC_TEXT" VARCHAR2(255), 
	"VERT_COLL_METH_METH_DEVI_TEXT" VARCHAR2(255), 
	"VERT_COLL_METH_COD_LST_VER_VAL" VARCHAR2(50), 
	"VERT_COLL_METH_COD_LIS_VER_IDE" VARCHAR2(50), 
	"VER_COL_MET_COD_LIS_VER_AGN_ID" VARCHAR2(50), 
	"VERF_METH_METH_IDEN_CODE" VARCHAR2(50), 
	"VERF_METH_METH_NAME" VARCHAR2(128), 
	"VERF_METH_METH_DESC_TEXT" VARCHAR2(255), 
	"VERF_METH_METH_DEVI_TEXT" VARCHAR2(255), 
	"VERF_METH_CODE_LST_VER_VAL" VARCHAR2(50), 
	"VERF_METH_CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"VERF_METH_CODE_LIS_VER_AGN_IDE" VARCHAR2(50), 
	"CORD_DATA_SRC_CODE" VARCHAR2(50), 
	"CORD_DATA_SRC_NAME" VARCHAR2(128), 
	"CORD_DATA_SRC_CODE_LIS_VER_IDE" VARCHAR2(50), 
	"COR_DAT_SRC_COD_LIS_VER_AGN_ID" VARCHAR2(50), 
	"CORD_DATA_SRC_CODE_LST_VER_VAL" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."FAC_PRI_GEO_LOC_DESC_ID" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (FacilityPrimaryGeographicLocationDescriptionId)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."FAC_ID" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (FacilityId)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."DATA_COLL_DATE" IS 'The calendar date when data were collected. (DataCollectionDate)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."LOC_COMM_TEXT" IS 'The text that provides additional information about the geographic coordinates. (LocationCommentsText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."SRS_NAME" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (srsName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."SRS_DIM" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (srsDimension)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."LATITUDE" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Latitude)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."LONGITUDE" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Longitude)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."ELEVATION" IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Elevation)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."MEAS_VAL" IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."MEAS_PREC_TEXT" IS 'The precision of the recorded value. (MeasurePrecisionText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."MEAS_UNIT_CODE" IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."MEAS_UNIT_NAME" IS 'A description of the unit of measure code. (MeasureUnitName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CODE_LIST_VERS_AGN_IDEN" IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."RSLT_QUAL_CODE" IS 'A code used to identify any qualifying issues that affect the results. (ResultQualifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."RSLT_QUAL_NAME" IS 'A description of the result code of any qualifying issues that affect the results. (ResultQualifierName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."RSLT_QUAL_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."RSLT_QUAL_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."RSLT_QUAL_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (MethodName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."METH_DESC_TEXT" IS 'A brief summary that provides general information about the method. (MethodDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."METH_DEVI_TEXT" IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."HORZ_COLL_METH_COD_LIS_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."HOR_COL_MET_COD_LIS_VER_AGN_ID" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."HORZ_COLL_METH_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."GEO_REF_PT_CODE" IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."GEO_REF_PT_NAME" IS 'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."GEO_REF_PT_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."GEO_REF_PT_COD_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."GEO_REF_PT_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERT_COLL_METH_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERT_COLL_METH_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (MethodName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERT_COLL_METH_METH_DESC_TEXT" IS 'A brief summary that provides general information about the method. (MethodDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERT_COLL_METH_METH_DEVI_TEXT" IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERT_COLL_METH_COD_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERT_COLL_METH_COD_LIS_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VER_COL_MET_COD_LIS_VER_AGN_ID" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (MethodName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_METH_DESC_TEXT" IS 'A brief summary that provides general information about the method. (MethodDescriptionText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_METH_DEVI_TEXT" IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."VERF_METH_CODE_LIS_VER_AGN_IDE" IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CORD_DATA_SRC_NAME" IS 'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CORD_DATA_SRC_CODE_LIS_VER_IDE" IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."COR_DAT_SRC_COD_LIS_VER_AGN_ID" IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "FACID_FAC_PRI_GEO_LOC_DESC"."CORD_DATA_SRC_CODE_LST_VER_VAL" IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
--------------------------------------------------------
--  DDL for Table FACID_POS
--------------------------------------------------------

  CREATE TABLE "FACID_POS" 
   (	"POS_ID" VARCHAR2(40), 
	"SHAPE_ID" VARCHAR2(40), 
	"ORDER_INDEX" NUMBER(*,0), 
	"LATITUDE" NUMBER(19,14), 
	"LONGITUDE" NUMBER(19,14), 
	"ELEVATION" NUMBER(19,14)
   ) ;
 

   COMMENT ON COLUMN "FACID_POS"."POS_ID" IS 'Parent: A container for one or more facility locations. (PositionId)';
 
   COMMENT ON COLUMN "FACID_POS"."SHAPE_ID" IS 'Parent: A container for one or more facility locations. (ShapeId)';
 
   COMMENT ON COLUMN "FACID_POS"."ORDER_INDEX" IS 'Parent: A container for one or more facility locations. (OrderIndex)';
 
   COMMENT ON COLUMN "FACID_POS"."LATITUDE" IS 'Parent: A container for one or more facility locations. (Latitude)';
 
   COMMENT ON COLUMN "FACID_POS"."LONGITUDE" IS 'Parent: A container for one or more facility locations. (Longitude)';
 
   COMMENT ON COLUMN "FACID_POS"."ELEVATION" IS 'Parent: A container for one or more facility locations. (Elevation)';
--------------------------------------------------------
--  DDL for Table FACID_SHAPE
--------------------------------------------------------

  CREATE TABLE "FACID_SHAPE" 
   (	"SHAPE_ID" VARCHAR2(40), 
	"FAC_GEO_LOC_DESC_ID" VARCHAR2(40), 
	"TYPE" VARCHAR2(10), 
	"SRS_NAME" VARCHAR2(255), 
	"SRS_DIM" VARCHAR2(10)
   ) ;
 

   COMMENT ON COLUMN "FACID_SHAPE"."SHAPE_ID" IS 'Parent: A container for one or more facility locations. (ShapeId)';
 
   COMMENT ON COLUMN "FACID_SHAPE"."FAC_GEO_LOC_DESC_ID" IS 'Parent: A container for one or more facility locations. (FacilityGeographicLocationDescriptionId)';
 
   COMMENT ON COLUMN "FACID_SHAPE"."TYPE" IS 'Parent: A container for one or more facility locations. (Type)';
 
   COMMENT ON COLUMN "FACID_SHAPE"."SRS_NAME" IS 'Parent: A container for one or more facility locations. (srsName)';
 
   COMMENT ON COLUMN "FACID_SHAPE"."SRS_DIM" IS 'Parent: A container for one or more facility locations. (srsDimension)';
--------------------------------------------------------
--  DDL for Table FACID_TELEPHONIC
--------------------------------------------------------

  CREATE TABLE "FACID_TELEPHONIC" 
   (	"TELEPHONIC_ID" VARCHAR2(40), 
	"AFFL_ID" VARCHAR2(40), 
	"TELE_NUM_TEXT" VARCHAR2(20), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(128), 
	"TELE_EXT_NUM_TEXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "FACID_TELEPHONIC"."TELEPHONIC_ID" IS 'Parent: A container for one or more telephone numbers. (TelephonicId)';
 
   COMMENT ON COLUMN "FACID_TELEPHONIC"."AFFL_ID" IS 'Parent: A container for one or more telephone numbers. (AffiliateId)';
 
   COMMENT ON COLUMN "FACID_TELEPHONIC"."TELE_NUM_TEXT" IS 'The number that identifies a particular telephone connection. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "FACID_TELEPHONIC"."TELE_NUM_TYPE_NAME" IS 'The name that describes a telephone number type. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "FACID_TELEPHONIC"."TELE_EXT_NUM_TEXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';

---------------------------------------------------
--   DATA FOR TABLE FACID_AFFL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_AFFL

---------------------------------------------------
--   END DATA FOR TABLE FACID_AFFL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_AFFL_ELEC_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_AFFL_ELEC_ADDR

---------------------------------------------------
--   END DATA FOR TABLE FACID_AFFL_ELEC_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ALT_NAME
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ALT_NAME

---------------------------------------------------
--   END DATA FOR TABLE FACID_ALT_NAME
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ENVR_INTR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ENVR_INTR

---------------------------------------------------
--   END DATA FOR TABLE FACID_ENVR_INTR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ENVR_INTR_ALT_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ENVR_INTR_ALT_IDEN

---------------------------------------------------
--   END DATA FOR TABLE FACID_ENVR_INTR_ALT_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ENVR_INTR_ELEC_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ENVR_INTR_ELEC_ADDR

---------------------------------------------------
--   END DATA FOR TABLE FACID_ENVR_INTR_ELEC_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ENVR_INTR_FAC_AFFL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ENVR_INTR_FAC_AFFL

---------------------------------------------------
--   END DATA FOR TABLE FACID_ENVR_INTR_FAC_AFFL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ENVR_INTR_FAC_NAICS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ENVR_INTR_FAC_NAICS

---------------------------------------------------
--   END DATA FOR TABLE FACID_ENVR_INTR_FAC_NAICS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_ENVR_INTR_FAC_SIC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_ENVR_INTR_FAC_SIC

---------------------------------------------------
--   END DATA FOR TABLE FACID_ENVR_INTR_FAC_SIC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_ALT_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_ALT_IDEN

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_ALT_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_DTLS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_DTLS

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_DTLS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_ELEC_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_ELEC_ADDR

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_ELEC_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_FAC_AFFL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_FAC_AFFL

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_FAC_AFFL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_FAC_NAICS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_FAC_NAICS

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_FAC_NAICS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_FAC_SIC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_FAC_SIC

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_FAC_SIC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_GEO_LOC_DESC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_GEO_LOC_DESC

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_GEO_LOC_DESC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_FAC_PRI_GEO_LOC_DESC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_FAC_PRI_GEO_LOC_DESC

---------------------------------------------------
--   END DATA FOR TABLE FACID_FAC_PRI_GEO_LOC_DESC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_POS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_POS

---------------------------------------------------
--   END DATA FOR TABLE FACID_POS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_SHAPE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_SHAPE

---------------------------------------------------
--   END DATA FOR TABLE FACID_SHAPE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE FACID_TELEPHONIC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into FACID_TELEPHONIC

---------------------------------------------------
--   END DATA FOR TABLE FACID_TELEPHONIC
---------------------------------------------------

--------------------------------------------------------
--  Constraints for Table FACID_ENVR_INTR
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR" ADD CONSTRAINT "PK_ENVR_INTR" PRIMARY KEY ("ENVR_INTR_ID") ENABLE;
 
  ALTER TABLE "FACID_ENVR_INTR" MODIFY ("ENVR_INTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR" MODIFY ("FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR" MODIFY ("ENVR_INTR_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR" MODIFY ("ENVR_INTR_TYPE_TEXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC" ADD CONSTRAINT "PK_FACILITY_ID" PRIMARY KEY ("FAC_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC" MODIFY ("FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC" MODIFY ("FAC_DTLS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_SHAPE
--------------------------------------------------------

  ALTER TABLE "FACID_SHAPE" ADD CONSTRAINT "PK_SHAPE" PRIMARY KEY ("SHAPE_ID") ENABLE;
 
  ALTER TABLE "FACID_SHAPE" MODIFY ("SHAPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_SHAPE" MODIFY ("FAC_GEO_LOC_DESC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_SHAPE" MODIFY ("TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_ENVR_INTR_ALT_IDEN
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_ALT_IDEN" ADD CONSTRAINT "PK_ENV_INT_ALT_IDE" PRIMARY KEY ("ENVR_INTR_ALT_IDEN_ID") ENABLE;
 
  ALTER TABLE "FACID_ENVR_INTR_ALT_IDEN" MODIFY ("ENVR_INTR_ALT_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR_ALT_IDEN" MODIFY ("ENVR_INTR_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_TELEPHONIC
--------------------------------------------------------

  ALTER TABLE "FACID_TELEPHONIC" ADD CONSTRAINT "PK_TELEPHONIC" PRIMARY KEY ("TELEPHONIC_ID") ENABLE;
 
  ALTER TABLE "FACID_TELEPHONIC" MODIFY ("TELEPHONIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_TELEPHONIC" MODIFY ("AFFL_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_FAC_NAICS
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_FAC_NAICS" ADD CONSTRAINT "PK_FAC_FAC_NAICS" PRIMARY KEY ("FAC_FAC_NAICS_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_FAC_NAICS" MODIFY ("FAC_FAC_NAICS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_FAC_NAICS" MODIFY ("FAC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_ENVR_INTR_FAC_AFFL
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_FAC_AFFL" ADD CONSTRAINT "PK_ENV_INT_FAC_AFF" PRIMARY KEY ("ENVR_INTR_FAC_AFFL_ID") ENABLE;
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_AFFL" MODIFY ("ENVR_INTR_FAC_AFFL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_AFFL" MODIFY ("ENVR_INTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_AFFL" MODIFY ("AFFL_IDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_ELEC_ADDR" ADD CONSTRAINT "PK_FAC_ELEC_ADDR" PRIMARY KEY ("FAC_ELEC_ADDR_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_ELEC_ADDR" MODIFY ("FAC_ELEC_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_ELEC_ADDR" MODIFY ("FAC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_AFFL
--------------------------------------------------------

  ALTER TABLE "FACID_AFFL" ADD CONSTRAINT "PK_AFFL" PRIMARY KEY ("AFFL_ID") ENABLE;
 
  ALTER TABLE "FACID_AFFL" MODIFY ("AFFL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_AFFL" MODIFY ("FAC_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_AFFL" MODIFY ("AFFL_IDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_FAC_AFFL
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_FAC_AFFL" ADD CONSTRAINT "PK_FAC_FAC_AFFL" PRIMARY KEY ("FAC_FAC_AFFL_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_FAC_AFFL" MODIFY ("FAC_FAC_AFFL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_FAC_AFFL" MODIFY ("FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_FAC_AFFL" MODIFY ("AFFL_IDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_POS
--------------------------------------------------------

  ALTER TABLE "FACID_POS" ADD CONSTRAINT "PK_POS" PRIMARY KEY ("POS_ID") ENABLE;
 
  ALTER TABLE "FACID_POS" MODIFY ("POS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_POS" MODIFY ("SHAPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_POS" MODIFY ("ORDER_INDEX" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_GEO_LOC_DESC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_GEO_LOC_DESC" ADD CONSTRAINT "PK_FAC_GEO_LOC_DES" PRIMARY KEY ("FAC_GEO_LOC_DESC_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_GEO_LOC_DESC" MODIFY ("FAC_GEO_LOC_DESC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_GEO_LOC_DESC" MODIFY ("FAC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_ALT_NAME
--------------------------------------------------------

  ALTER TABLE "FACID_ALT_NAME" ADD CONSTRAINT "PK_ALT_NAME" PRIMARY KEY ("ALT_NAME_ID") ENABLE;
 
  ALTER TABLE "FACID_ALT_NAME" MODIFY ("ALT_NAME_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ALT_NAME" MODIFY ("FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ALT_NAME" MODIFY ("ALT_NAME_TEXT" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ALT_NAME" MODIFY ("ALT_NAME_TYPE_TEXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_ALT_IDEN
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_ALT_IDEN" ADD CONSTRAINT "PK_FAC_ALT_IDEN" PRIMARY KEY ("FAC_ALT_IDEN_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_ALT_IDEN" MODIFY ("FAC_ALT_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_ALT_IDEN" MODIFY ("FAC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_ENVR_INTR_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_ELEC_ADDR" ADD CONSTRAINT "PK_ENV_INT_ELE_ADD" PRIMARY KEY ("ENVR_INTR_ELEC_ADDR_ID") ENABLE;
 
  ALTER TABLE "FACID_ENVR_INTR_ELEC_ADDR" MODIFY ("ENVR_INTR_ELEC_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR_ELEC_ADDR" MODIFY ("ENVR_INTR_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_PRI_GEO_LOC_DESC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_PRI_GEO_LOC_DESC" ADD CONSTRAINT "PK_FAC_PR_GE_LO_DE" PRIMARY KEY ("FAC_PRI_GEO_LOC_DESC_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_PRI_GEO_LOC_DESC" MODIFY ("FAC_PRI_GEO_LOC_DESC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_PRI_GEO_LOC_DESC" MODIFY ("FAC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_ENVR_INTR_FAC_SIC
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_FAC_SIC" ADD CONSTRAINT "PK_ENV_INT_FAC_SIC" PRIMARY KEY ("ENVR_INTR_FAC_SIC_ID") ENABLE;
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_SIC" MODIFY ("ENVR_INTR_FAC_SIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_SIC" MODIFY ("ENVR_INTR_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_FAC_SIC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_FAC_SIC" ADD CONSTRAINT "PK_FAC_FAC_SIC" PRIMARY KEY ("FAC_FAC_SIC_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_FAC_SIC" MODIFY ("FAC_FAC_SIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_FAC_FAC_SIC" MODIFY ("FAC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_AFFL_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "FACID_AFFL_ELEC_ADDR" ADD CONSTRAINT "PK_AFFL_ELEC_ADDR" PRIMARY KEY ("AFFL_ELEC_ADDR_ID") ENABLE;
 
  ALTER TABLE "FACID_AFFL_ELEC_ADDR" MODIFY ("AFFL_ELEC_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_AFFL_ELEC_ADDR" MODIFY ("AFFL_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_FAC_DTLS
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_DTLS" ADD CONSTRAINT "PK_FAC_DTLS" PRIMARY KEY ("FAC_DTLS_ID") ENABLE;
 
  ALTER TABLE "FACID_FAC_DTLS" MODIFY ("FAC_DTLS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table FACID_ENVR_INTR_FAC_NAICS
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_FAC_NAICS" ADD CONSTRAINT "PK_ENV_INT_FAC_NAI" PRIMARY KEY ("ENVR_INTR_FAC_NAICS_ID") ENABLE;
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_NAICS" MODIFY ("ENVR_INTR_FAC_NAICS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "FACID_ENVR_INTR_FAC_NAICS" MODIFY ("ENVR_INTR_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index IX_SH_FA_GE_LO_DE
--------------------------------------------------------

  CREATE INDEX "IX_SH_FA_GE_LO_DE" ON "FACID_SHAPE" ("FAC_GEO_LOC_DESC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_PR_GE_LO_04
--------------------------------------------------------

  CREATE INDEX "IX_FA_PR_GE_LO_04" ON "FACID_FAC_PRI_GEO_LOC_DESC" ("ELEVATION") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENV_INT_ALT_IDE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENV_INT_ALT_IDE" ON "FACID_ENVR_INTR_ALT_IDEN" ("ENVR_INTR_ALT_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_FA_AF_FA_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_FA_AF_FA_ID" ON "FACID_FAC_FAC_AFFL" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_POS_LATITUDE
--------------------------------------------------------

  CREATE INDEX "IX_POS_LATITUDE" ON "FACID_POS" ("LATITUDE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_AL_ID_FA_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_AL_ID_FA_ID" ON "FACID_FAC_ALT_IDEN" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_DTLS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_DTLS" ON "FACID_FAC_DTLS" ("FAC_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_CNTY_NAME
--------------------------------------------------------

  CREATE INDEX "IX_FAC_CNTY_NAME" ON "FACID_FAC" ("CNTY_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_ELEC_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_ELEC_ADDR" ON "FACID_FAC_ELEC_ADDR" ("FAC_ELEC_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL" ON "FACID_AFFL" ("AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENV_INT_ELE_ADD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENV_INT_ELE_ADD" ON "FACID_ENVR_INTR_ELEC_ADDR" ("ENVR_INTR_ELEC_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ENV_IN_OR_PA_NA
--------------------------------------------------------

  CREATE INDEX "IX_ENV_IN_OR_PA_NA" ON "FACID_ENVR_INTR" ("ORIG_PART_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IX_POS_LONGITUDE
--------------------------------------------------------

  CREATE INDEX "IX_POS_LONGITUDE" ON "FACID_POS" ("LONGITUDE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_FAC_AFFL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_FAC_AFFL" ON "FACID_FAC_FAC_AFFL" ("FAC_FAC_AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_FA_NA_FA_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_FA_NA_FA_ID" ON "FACID_FAC_FAC_NAICS" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_FAC_DTLS_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_FAC_DTLS_ID" ON "FACID_FAC" ("FAC_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_POS_ELEVATION
--------------------------------------------------------

  CREATE INDEX "IX_POS_ELEVATION" ON "FACID_POS" ("ELEVATION") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_PR_GE_LO_02
--------------------------------------------------------

  CREATE INDEX "IX_FA_PR_GE_LO_02" ON "FACID_FAC_PRI_GEO_LOC_DESC" ("LATITUDE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_TELEPHO_AFFL_ID
--------------------------------------------------------

  CREATE INDEX "IX_TELEPHO_AFFL_ID" ON "FACID_TELEPHONIC" ("AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFF_EL_AD_AF_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFF_EL_AD_AF_ID" ON "FACID_AFFL_ELEC_ADDR" ("AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EN_IN_FA_NA_EN
--------------------------------------------------------

  CREATE INDEX "IX_EN_IN_FA_NA_EN" ON "FACID_ENVR_INTR_FAC_NAICS" ("ENVR_INTR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_POS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_POS" ON "FACID_POS" ("POS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFFL_FAC_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFL_FAC_DTL_ID" ON "FACID_AFFL" ("FAC_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_GE_LO_DE_LO
--------------------------------------------------------

  CREATE INDEX "IX_FAC_GE_LO_DE_LO" ON "FACID_FAC_GEO_LOC_DESC" ("LONGITUDE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EN_IN_FA_SI_EN
--------------------------------------------------------

  CREATE INDEX "IX_EN_IN_FA_SI_EN" ON "FACID_ENVR_INTR_FAC_SIC" ("ENVR_INTR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_LOCA_NAME
--------------------------------------------------------

  CREATE INDEX "IX_FAC_LOCA_NAME" ON "FACID_FAC" ("LOCA_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_LAS_UPD_DAT
--------------------------------------------------------

  CREATE INDEX "IX_FAC_LAS_UPD_DAT" ON "FACID_FAC" ("LAST_UPDT_DATE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_TELEPHONIC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TELEPHONIC" ON "FACID_TELEPHONIC" ("TELEPHONIC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_PR_GE_LO_DE
--------------------------------------------------------

  CREATE INDEX "IX_FA_PR_GE_LO_DE" ON "FACID_FAC_PRI_GEO_LOC_DESC" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_FAC_SIC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_FAC_SIC" ON "FACID_FAC_FAC_SIC" ("FAC_FAC_SIC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_GE_LO_DE_FA
--------------------------------------------------------

  CREATE INDEX "IX_FA_GE_LO_DE_FA" ON "FACID_FAC_GEO_LOC_DESC" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFFL_STA_CODE
--------------------------------------------------------

  CREATE INDEX "IX_AFFL_STA_CODE" ON "FACID_AFFL" ("STA_CODE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_MA_AD_AD_PO
--------------------------------------------------------

  CREATE INDEX "IX_FA_MA_AD_AD_PO" ON "FACID_FAC" ("MAIL_ADDR_ADDR_POST_CODE_VAL") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_PR_GE_LO_DE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_PR_GE_LO_DE" ON "FACID_FAC_PRI_GEO_LOC_DESC" ("FAC_PRI_GEO_LOC_DESC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_AD_PO_CO_VA
--------------------------------------------------------

  CREATE INDEX "IX_FAC_AD_PO_CO_VA" ON "FACID_FAC" ("ADDR_POST_CODE_VAL") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_FAC_SIT_NAM
--------------------------------------------------------

  CREATE INDEX "IX_FAC_FAC_SIT_NAM" ON "FACID_FAC" ("FAC_SITE_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENV_INT_FAC_SIC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENV_INT_FAC_SIC" ON "FACID_ENVR_INTR_FAC_SIC" ("ENVR_INTR_FAC_SIC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_GE_LO_DE_EL
--------------------------------------------------------

  CREATE INDEX "IX_FAC_GE_LO_DE_EL" ON "FACID_FAC_GEO_LOC_DESC" ("ELEVATION") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FACILITY_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FACILITY_ID" ON "FACID_FAC" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_MA_AD_ST_CO
--------------------------------------------------------

  CREATE INDEX "IX_FAC_MA_AD_ST_CO" ON "FACID_FAC" ("MAIL_ADDR_STA_CODE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EN_IN_EL_AD_EN
--------------------------------------------------------

  CREATE INDEX "IX_EN_IN_EL_AD_EN" ON "FACID_ENVR_INTR_ELEC_ADDR" ("ENVR_INTR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EN_IN_AL_ID_EN
--------------------------------------------------------

  CREATE INDEX "IX_EN_IN_AL_ID_EN" ON "FACID_ENVR_INTR_ALT_IDEN" ("ENVR_INTR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENV_INT_FAC_NAI
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENV_INT_FAC_NAI" ON "FACID_ENVR_INTR_FAC_NAICS" ("ENVR_INTR_FAC_NAICS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_FA_SI_FA_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_FA_SI_FA_ID" ON "FACID_FAC_FAC_SIC" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_FA_SI_ID_VA
--------------------------------------------------------

  CREATE INDEX "IX_FAC_FA_SI_ID_VA" ON "FACID_FAC" ("FAC_SITE_IDEN_VAL") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENV_INT_FAC_AFF
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENV_INT_FAC_AFF" ON "FACID_ENVR_INTR_FAC_AFFL" ("ENVR_INTR_FAC_AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_POS_SHAPE_ID
--------------------------------------------------------

  CREATE INDEX "IX_POS_SHAPE_ID" ON "FACID_POS" ("SHAPE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFF_AD_PO_CO_VA
--------------------------------------------------------

  CREATE INDEX "IX_AFF_AD_PO_CO_VA" ON "FACID_AFFL" ("ADDR_POST_CODE_VAL") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EN_IN_IN_SY_AC
--------------------------------------------------------

  CREATE INDEX "IX_EN_IN_IN_SY_AC" ON "FACID_ENVR_INTR" ("INFO_SYS_ACRO_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_FAC_NAICS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_FAC_NAICS" ON "FACID_FAC_FAC_NAICS" ("FAC_FAC_NAICS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENVR_INTR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENVR_INTR" ON "FACID_ENVR_INTR" ("ENVR_INTR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ENVR_INT_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENVR_INT_FAC_ID" ON "FACID_ENVR_INTR" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_IN_SY_AC_NA
--------------------------------------------------------

  CREATE INDEX "IX_FAC_IN_SY_AC_NA" ON "FACID_FAC" ("INFO_SYS_ACRO_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_ELEC_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_ELEC_ADDR" ON "FACID_AFFL_ELEC_ADDR" ("AFFL_ELEC_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ALT_NAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ALT_NAME" ON "FACID_ALT_NAME" ("ALT_NAME_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SHAPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SHAPE" ON "FACID_SHAPE" ("SHAPE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_PR_GE_LO_03
--------------------------------------------------------

  CREATE INDEX "IX_FA_PR_GE_LO_03" ON "FACID_FAC_PRI_GEO_LOC_DESC" ("LONGITUDE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_ALT_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_ALT_IDEN" ON "FACID_FAC_ALT_IDEN" ("FAC_ALT_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_GEO_LOC_DES
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_GEO_LOC_DES" ON "FACID_FAC_GEO_LOC_DESC" ("FAC_GEO_LOC_DESC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EN_IN_FA_AF_EN
--------------------------------------------------------

  CREATE INDEX "IX_EN_IN_FA_AF_EN" ON "FACID_ENVR_INTR_FAC_AFFL" ("ENVR_INTR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_EL_AD_FA_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_EL_AD_FA_ID" ON "FACID_FAC_ELEC_ADDR" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ENV_IN_LA_UP_DA
--------------------------------------------------------

  CREATE INDEX "IX_ENV_IN_LA_UP_DA" ON "FACID_ENVR_INTR" ("LAST_UPDT_DATE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ALT_NAME_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ALT_NAME_FAC_ID" ON "FACID_ALT_NAME" ("FAC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_STA_CODE
--------------------------------------------------------

  CREATE INDEX "IX_FAC_STA_CODE" ON "FACID_FAC" ("STA_CODE") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_ORI_PAR_NAM
--------------------------------------------------------

  CREATE INDEX "IX_FAC_ORI_PAR_NAM" ON "FACID_FAC" ("ORIG_PART_NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FAC_GE_LO_DE_LA
--------------------------------------------------------

  CREATE INDEX "IX_FAC_GE_LO_DE_LA" ON "FACID_FAC_GEO_LOC_DESC" ("LATITUDE") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table FACID_AFFL
--------------------------------------------------------

  ALTER TABLE "FACID_AFFL" ADD CONSTRAINT "FK_AFFL_FAC_DTLS" FOREIGN KEY ("FAC_DTLS_ID")
	  REFERENCES "FACID_FAC_DTLS" ("FAC_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_AFFL_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "FACID_AFFL_ELEC_ADDR" ADD CONSTRAINT "FK_AFF_ELE_ADD_AFF" FOREIGN KEY ("AFFL_ID")
	  REFERENCES "FACID_AFFL" ("AFFL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ALT_NAME
--------------------------------------------------------

  ALTER TABLE "FACID_ALT_NAME" ADD CONSTRAINT "FK_ALT_NAME_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ENVR_INTR
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR" ADD CONSTRAINT "FK_ENVR_INTR_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ENVR_INTR_ALT_IDEN
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_ALT_IDEN" ADD CONSTRAINT "FK_EN_IN_AL_ID_EN" FOREIGN KEY ("ENVR_INTR_ID")
	  REFERENCES "FACID_ENVR_INTR" ("ENVR_INTR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ENVR_INTR_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_ELEC_ADDR" ADD CONSTRAINT "FK_EN_IN_EL_AD_EN" FOREIGN KEY ("ENVR_INTR_ID")
	  REFERENCES "FACID_ENVR_INTR" ("ENVR_INTR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ENVR_INTR_FAC_AFFL
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_FAC_AFFL" ADD CONSTRAINT "FK_EN_IN_FA_AF_EN" FOREIGN KEY ("ENVR_INTR_ID")
	  REFERENCES "FACID_ENVR_INTR" ("ENVR_INTR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ENVR_INTR_FAC_NAICS
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_FAC_NAICS" ADD CONSTRAINT "FK_EN_IN_FA_NA_EN" FOREIGN KEY ("ENVR_INTR_ID")
	  REFERENCES "FACID_ENVR_INTR" ("ENVR_INTR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_ENVR_INTR_FAC_SIC
--------------------------------------------------------

  ALTER TABLE "FACID_ENVR_INTR_FAC_SIC" ADD CONSTRAINT "FK_EN_IN_FA_SI_EN" FOREIGN KEY ("ENVR_INTR_ID")
	  REFERENCES "FACID_ENVR_INTR" ("ENVR_INTR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC" ADD CONSTRAINT "FK_FAC_FAC_DTLS" FOREIGN KEY ("FAC_DTLS_ID")
	  REFERENCES "FACID_FAC_DTLS" ("FAC_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_ALT_IDEN
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_ALT_IDEN" ADD CONSTRAINT "FK_FAC_ALT_IDE_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_ELEC_ADDR" ADD CONSTRAINT "FK_FAC_ELE_ADD_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_FAC_AFFL
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_FAC_AFFL" ADD CONSTRAINT "FK_FAC_FAC_AFF_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_FAC_NAICS
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_FAC_NAICS" ADD CONSTRAINT "FK_FAC_FAC_NAI_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_FAC_SIC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_FAC_SIC" ADD CONSTRAINT "FK_FAC_FAC_SIC_FAC" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_GEO_LOC_DESC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_GEO_LOC_DESC" ADD CONSTRAINT "FK_FAC_GE_LO_DE_FA" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_FAC_PRI_GEO_LOC_DESC
--------------------------------------------------------

  ALTER TABLE "FACID_FAC_PRI_GEO_LOC_DESC" ADD CONSTRAINT "FK_FA_PR_GE_LO_DE" FOREIGN KEY ("FAC_ID")
	  REFERENCES "FACID_FAC" ("FAC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_POS
--------------------------------------------------------

  ALTER TABLE "FACID_POS" ADD CONSTRAINT "FK_POS_SHAPE" FOREIGN KEY ("SHAPE_ID")
	  REFERENCES "FACID_SHAPE" ("SHAPE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_SHAPE
--------------------------------------------------------

  ALTER TABLE "FACID_SHAPE" ADD CONSTRAINT "FK_SHA_FA_GE_LO_DE" FOREIGN KEY ("FAC_GEO_LOC_DESC_ID")
	  REFERENCES "FACID_FAC_GEO_LOC_DESC" ("FAC_GEO_LOC_DESC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACID_TELEPHONIC
--------------------------------------------------------

  ALTER TABLE "FACID_TELEPHONIC" ADD CONSTRAINT "FK_TELEPHONIC_AFFL" FOREIGN KEY ("AFFL_ID")
	  REFERENCES "FACID_AFFL" ("AFFL_ID") ON DELETE CASCADE ENABLE;
