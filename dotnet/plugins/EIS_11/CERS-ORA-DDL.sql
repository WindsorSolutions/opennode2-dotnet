--------------------------------------------------------
--  File created - Wednesday-November-04-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table CERS_AFFL
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL" 
   (	"AFFL_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"AFFL_TYPE_CODE" VARCHAR2(50), 
	"AFFL_START_DATE" TIMESTAMP (6), 
	"AFFL_END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL"."AFFL_TYPE_CODE" IS 'Identifies the function that an organization or individual serves, or the relationship between an individual or organization and the facility site.  Examples include: Internal Reviewer, Lead Verifier, Verifying Body. (AffiliationTypeCode)';
 
   COMMENT ON COLUMN "CERS_AFFL"."AFFL_START_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)';
 
   COMMENT ON COLUMN "CERS_AFFL"."AFFL_END_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)';
 
   COMMENT ON TABLE "CERS_AFFL"  IS 'Schema element: AffiliationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_INDV
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_INDV" 
   (	"AFFL_INDV_ID" VARCHAR2(40), 
	"AFFL_ID" VARCHAR2(40), 
	"INDV_TITLE_TXT" VARCHAR2(255), 
	"NAME_PREFIX_TXT" VARCHAR2(255), 
	"FIRST_NAME" VARCHAR2(128), 
	"MIDDLE_NAME" VARCHAR2(128), 
	"LAST_NAME" VARCHAR2(128), 
	"NAME_SUFFIX_TXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_INDV"."INDV_TITLE_TXT" IS 'The title held by a person in an organization. (IndividualTitleText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV"."NAME_PREFIX_TXT" IS 'The text that precedes an individual''s name. (NamePrefixText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV"."FIRST_NAME" IS 'The given name of an individual. (FirstName)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV"."MIDDLE_NAME" IS 'The middle name or initial of an individual. (MiddleName)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV"."LAST_NAME" IS 'The surname of an individual. (LastName)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV"."NAME_SUFFIX_TXT" IS 'the text that follows an individuals name. (NameSuffixText)';
 
   COMMENT ON TABLE "CERS_AFFL_INDV"  IS 'Schema element: AffiliationIndividualDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_INDV_ADDR
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_INDV_ADDR" 
   (	"AFFL_INDV_ADDR_ID" VARCHAR2(40), 
	"AFFL_INDV_ID" VARCHAR2(40), 
	"MAIL_ADDR_TXT" VARCHAR2(255), 
	"SUPP_ADDR_TXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CNTY_TXT" VARCHAR2(255), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_POST_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"LOC_ADDR_TXT" VARCHAR2(255), 
	"SUPP_LOC_TXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"LOC_ADDR_STA_CODE" VARCHAR2(50), 
	"LOC_ADDR_POST_CODE" VARCHAR2(50), 
	"LOC_ADDR_CTRY_CODE" VARCHAR2(50), 
	"ADDR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."MAIL_ADDR_TXT" IS 'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."SUPP_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."MAIL_ADDR_CITY_NAME" IS 'The name of the city or town. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."MAIL_ADDR_CNTY_TXT" IS 'The name of the county. (MailingAddressCountyText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."MAIL_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."MAIL_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."LOC_ADDR_TXT" IS 'The physical location of a facility site or organization. (LocationAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."SUPP_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."LOCA_NAME" IS 'The name of the city, town, village, or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."LOC_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."LOC_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."LOC_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_ADDR"."ADDR_CMNT" IS 'Any comments regarding the address information. (AddressComment)';
 
   COMMENT ON TABLE "CERS_AFFL_INDV_ADDR"  IS 'Schema element: AffiliationIndividualAddressDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_INDV_COMMUN
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_INDV_COMMUN" 
   (	"AFFL_INDV_COMMUN_ID" VARCHAR2(40), 
	"AFFL_INDV_ID" VARCHAR2(40), 
	"TELE_NUM_TXT" VARCHAR2(20), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(128), 
	"TELE_EXT_NUM_TXT" VARCHAR2(20), 
	"ELEC_ADDR_TXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(128)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_INDV_COMMUN"."TELE_NUM_TXT" IS 'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_COMMUN"."TELE_NUM_TYPE_NAME" IS 'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_COMMUN"."TELE_EXT_NUM_TXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_COMMUN"."ELEC_ADDR_TXT" IS 'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_COMMUN"."ELEC_ADDR_TYPE_NAME" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "CERS_AFFL_INDV_COMMUN"  IS 'Schema element: AffiliationIndividualCommunicationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_INDV_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_INDV_IDEN" 
   (	"AFFL_INDV_IDEN_ID" VARCHAR2(40), 
	"AFFL_INDV_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_INDV_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_AFFL_INDV_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_AFFL_INDV_IDEN"  IS 'Schema element: AffiliationIndividualIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG" 
   (	"AFFL_ORG_ID" VARCHAR2(40), 
	"AFFL_ID" VARCHAR2(40), 
	"ORG_FORMAL_NAME" VARCHAR2(128), 
	"PCNT_OWNER" NUMBER(12,6), 
	"CONS_METH" VARCHAR2(255), 
	"ATCH_FILE_CONT" BLOB, 
	"ATCH_FILE_NAME" VARCHAR2(128), 
	"ATCH_FILE_DESC" VARCHAR2(255), 
	"ATCH_FILE_SIZE" VARCHAR2(255), 
	"ATCH_FILE_CONT_TYPE_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG"."ORG_FORMAL_NAME" IS 'Name of the organization. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."PCNT_OWNER" IS 'Contains information on the percentage of ownership an organization has for a facility site. (PercentOwnership)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."CONS_METH" IS 'Consolidation methodology for an organization, including:  operation control, financial control, operation control and equity share, financial control and equity share, equity share. (ConsolidationMethodology)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."ATCH_FILE_CONT" IS 'The data content of a file. (AttachmentFileContent)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."ATCH_FILE_NAME" IS 'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."ATCH_FILE_DESC" IS 'Description of file. (AttachmentFileDescription)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."ATCH_FILE_SIZE" IS 'The size of the attached file. (AttachmentFileSize)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG"."ATCH_FILE_CONT_TYPE_CODE" IS 'A code describing the content type of a file. (AttachmentFileContentTypeCode)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG"  IS 'Schema element: AffiliationOrganizationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_ADDR
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_ADDR" 
   (	"AFFL_ORG_ADDR_ID" VARCHAR2(40), 
	"AFFL_ORG_ID" VARCHAR2(40), 
	"MAIL_ADDR_TXT" VARCHAR2(255), 
	"SUPP_ADDR_TXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CNTY_TXT" VARCHAR2(255), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_POST_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"LOC_ADDR_TXT" VARCHAR2(255), 
	"SUPP_LOC_TXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"LOC_ADDR_STA_CODE" VARCHAR2(50), 
	"LOC_ADDR_POST_CODE" VARCHAR2(50), 
	"LOC_ADDR_CTRY_CODE" VARCHAR2(50), 
	"ADDR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."MAIL_ADDR_TXT" IS 'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."SUPP_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."MAIL_ADDR_CITY_NAME" IS 'The name of the city or town. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."MAIL_ADDR_CNTY_TXT" IS 'The name of the county. (MailingAddressCountyText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."MAIL_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."MAIL_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."LOC_ADDR_TXT" IS 'The physical location of a facility site or organization. (LocationAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."SUPP_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."LOCA_NAME" IS 'The name of the city, town, village, or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."LOC_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."LOC_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."LOC_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_ADDR"."ADDR_CMNT" IS 'Any comments regarding the address information. (AddressComment)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_ADDR"  IS 'Schema element: AffiliationOrganizationAddressDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_COMMUN
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_COMMUN" 
   (	"AFFL_ORG_COMMUN_ID" VARCHAR2(40), 
	"AFFL_ORG_ID" VARCHAR2(40), 
	"TELE_NUM_TXT" VARCHAR2(20), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(128), 
	"TELE_EXT_NUM_TXT" VARCHAR2(20), 
	"ELEC_ADDR_TXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(128)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_COMMUN"."TELE_NUM_TXT" IS 'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_COMMUN"."TELE_NUM_TYPE_NAME" IS 'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_COMMUN"."TELE_EXT_NUM_TXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_COMMUN"."ELEC_ADDR_TXT" IS 'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_COMMUN"."ELEC_ADDR_TYPE_NAME" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_COMMUN"  IS 'Schema element: AffiliationOrganizationCommunicationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_IDEN" 
   (	"AFFL_ORG_IDEN_ID" VARCHAR2(40), 
	"AFFL_ORG_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_IDEN"  IS 'Schema element: AffiliationOrganizationIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_INDV
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_INDV" 
   (	"AFFL_ORG_INDV_ID" VARCHAR2(40), 
	"AFFL_ORG_ID" VARCHAR2(40), 
	"INDV_TITLE_TXT" VARCHAR2(255), 
	"NAME_PREFIX_TXT" VARCHAR2(255), 
	"FIRST_NAME" VARCHAR2(128), 
	"MIDDLE_NAME" VARCHAR2(128), 
	"LAST_NAME" VARCHAR2(128), 
	"NAME_SUFFIX_TXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV"."INDV_TITLE_TXT" IS 'The title held by a person in an organization. (IndividualTitleText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV"."NAME_PREFIX_TXT" IS 'The text that precedes an individual''s name. (NamePrefixText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV"."FIRST_NAME" IS 'The given name of an individual. (FirstName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV"."MIDDLE_NAME" IS 'The middle name or initial of an individual. (MiddleName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV"."LAST_NAME" IS 'The surname of an individual. (LastName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV"."NAME_SUFFIX_TXT" IS 'the text that follows an individuals name. (NameSuffixText)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_INDV"  IS 'Schema element: AffiliationOrganizationIndividualDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_INDV_ADDR
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_INDV_ADDR" 
   (	"AFFL_ORG_INDV_ADDR_ID" VARCHAR2(40), 
	"AFFL_ORG_INDV_ID" VARCHAR2(40), 
	"MAIL_ADDR_TXT" VARCHAR2(255), 
	"SUPP_ADDR_TXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CNTY_TXT" VARCHAR2(255), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_POST_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"LOC_ADDR_TXT" VARCHAR2(255), 
	"SUPP_LOC_TXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"LOC_ADDR_STA_CODE" VARCHAR2(50), 
	"LOC_ADDR_POST_CODE" VARCHAR2(50), 
	"LOC_ADDR_CTRY_CODE" VARCHAR2(50), 
	"ADDR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."MAIL_ADDR_TXT" IS 'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."SUPP_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."MAIL_ADDR_CITY_NAME" IS 'The name of the city or town. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."MAIL_ADDR_CNTY_TXT" IS 'The name of the county. (MailingAddressCountyText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."MAIL_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."MAIL_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."LOC_ADDR_TXT" IS 'The physical location of a facility site or organization. (LocationAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."SUPP_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."LOCA_NAME" IS 'The name of the city, town, village, or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."LOC_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."LOC_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."LOC_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_ADDR"."ADDR_CMNT" IS 'Any comments regarding the address information. (AddressComment)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_INDV_ADDR"  IS 'Schema element: AffiliationOrganizationIndividualAddressDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_INDV_COMMUN
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_INDV_COMMUN" 
   (	"AFFL_ORG_INDV_COMMUN_ID" VARCHAR2(40), 
	"AFFL_ORG_INDV_ID" VARCHAR2(40), 
	"TELE_NUM_TXT" VARCHAR2(20), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(128), 
	"TELE_EXT_NUM_TXT" VARCHAR2(20), 
	"ELEC_ADDR_TXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(128)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_COMMUN"."TELE_NUM_TXT" IS 'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_COMMUN"."TELE_NUM_TYPE_NAME" IS 'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_COMMUN"."TELE_EXT_NUM_TXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_COMMUN"."ELEC_ADDR_TXT" IS 'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_COMMUN"."ELEC_ADDR_TYPE_NAME" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_INDV_COMMUN"  IS 'Schema element: AffiliationOrganizationIndividualCommunicationDataType';
--------------------------------------------------------
--  DDL for Table CERS_AFFL_ORG_INDV_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_AFFL_ORG_INDV_IDEN" 
   (	"AFFL_ORG_INDV_IDEN_ID" VARCHAR2(40), 
	"AFFL_ORG_INDV_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_AFFL_ORG_INDV_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_AFFL_ORG_INDV_IDEN"  IS 'Schema element: AffiliationOrganizationIndividualIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_ALT_FAC_NAME
--------------------------------------------------------

  CREATE TABLE "CERS_ALT_FAC_NAME" 
   (	"ALT_FAC_NAME_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"ALT_NAME" VARCHAR2(128), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"ALT_NAME_TYPE_TXT" VARCHAR2(255), 
	"EFFC_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_ALT_FAC_NAME"."ALT_NAME" IS 'An alternative, historic, or program-specific name for the facility site. (AlternativeName)';
 
   COMMENT ON COLUMN "CERS_ALT_FAC_NAME"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_ALT_FAC_NAME"."ALT_NAME_TYPE_TXT" IS 'The type of alternative, historical, or program-specific name for the facility site (e.g., primary, legal, historical, local).  (AlternativeNameTypeText)';
 
   COMMENT ON COLUMN "CERS_ALT_FAC_NAME"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON TABLE "CERS_ALT_FAC_NAME"  IS 'Schema element: AlternativeFacilityNameDataType';
--------------------------------------------------------
--  DDL for Table CERS_CERS
--------------------------------------------------------

  CREATE TABLE "CERS_CERS" 
   (	"CERS_ID" VARCHAR2(40), 
	"DATA_CATEGORY" VARCHAR2(21), 
	"USER_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EMIS_YEAR" NUMBER(10,0), 
	"MODEL" VARCHAR2(255), 
	"MODEL_VERS" VARCHAR2(20), 
	"EMIS_CRTN_DATE" TIMESTAMP (6), 
	"SUBM_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_CERS"."USER_IDEN" IS 'Unique identifier of a user record.  This identifier is assigned by the receiving system and is unique for each user.  Permissions for updating data are granted based on the user identification. (UserIdentifier)';
 
   COMMENT ON COLUMN "CERS_CERS"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_CERS"."EMIS_YEAR" IS 'The year of the submitted emissions. (EmissionsYear)';
 
   COMMENT ON COLUMN "CERS_CERS"."MODEL" IS 'The name of the model or the conversion tool used for generating the emissions data. (Model)';
 
   COMMENT ON COLUMN "CERS_CERS"."MODEL_VERS" IS 'The version of the model or conversion tool. (ModelVersion)';
 
   COMMENT ON COLUMN "CERS_CERS"."EMIS_CRTN_DATE" IS 'Date that the data being submitted were created, or the date when the model generating the data was run. (EmissionsCreationDate)';
 
   COMMENT ON COLUMN "CERS_CERS"."SUBM_CMNT" IS 'Any comments regarding the file submission. (SubmittalComment)';
 
   COMMENT ON TABLE "CERS_CERS"  IS 'Schema element: CERSDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT" 
   (	"EMIS_UNIT_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"SCOPE" VARCHAR2(255), 
	"UNIT_DESC" VARCHAR2(255), 
	"UNIT_TYPE_CODE" VARCHAR2(50), 
	"UNIT_SRC_LOC" VARCHAR2(255), 
	"INSIG_SRC_IND" VARCHAR2(50), 
	"UNIT_DSGN_CAP" VARCHAR2(255), 
	"UNIT_DSGN_CAP_UNT_MEAS_CODE" VARCHAR2(50), 
	"UNIT_STAT_CODE" VARCHAR2(50), 
	"UNIT_STAT_CODE_YEAR" NUMBER(10,0), 
	"UNIT_OPER_DATE" TIMESTAMP (6), 
	"UNIT_COMMER_OPER_DATE" TIMESTAMP (6), 
	"UNIT_CMNT" VARCHAR2(255), 
	"CTRL_APCH_DESC" VARCHAR2(255), 
	"PCNT_CTRL_APCH_CAP_EFCY" NUMBER(12,6), 
	"PCNT_CTRL_APCH_EFCT" NUMBER(12,6), 
	"PCNT_CTRL_APCH_PEN" NUMBER(12,6), 
	"FIRST_INVEN_YEAR" NUMBER(10,0), 
	"LAST_INVEN_YEAR" NUMBER(10,0), 
	"CTRL_APCH_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT"."SCOPE" IS 'The code that identifies the scope of emissions data that are reported. Examples include Scope 1 - Stationary Combustion, Scope 1 - Mobile Combustion, Scope 2 - Purchased Electricity, and Scope 3 - Indirect. (Scope)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_DESC" IS 'Text description of the emissions unit. (UnitDescription)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_TYPE_CODE" IS 'Code that identifies the type of emissions unit activity. (UnitTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_SRC_LOC" IS 'The location or building number of the emissions source. (UnitSourceLocation)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."INSIG_SRC_IND" IS 'Indicates if the emissions source is insignificant. (InsignificantSourceIndicator)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_DSGN_CAP" IS 'The measure of the size of the unit based on the maximum continuous throughput capacity of the unit. (UnitDesignCapacity)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_DSGN_CAP_UNT_MEAS_CODE" IS 'Unit of measure for the design capacity of the emissions unit. (UnitDesignCapacityUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_STAT_CODE" IS 'Code that identifies the operating status of the emissions unit. (UnitStatusCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_STAT_CODE_YEAR" IS 'The year in which the unit status became applicable. (UnitStatusCodeYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_OPER_DATE" IS 'The date on which unit activity became operational. (UnitOperationDate)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_COMMER_OPER_DATE" IS 'The date in which the unit commenced operational activities (UnitCommercialOperationDate)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."UNIT_CMNT" IS 'Any comments regarding the emissions unit activity. (UnitComment)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."CTRL_APCH_DESC" IS 'Description of the overall control system or approach applied to an emissions unit or process. (ControlApproachDescription)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."PCNT_CTRL_APCH_CAP_EFCY" IS 'An estimate of that portion of an affected emission stream that is collected and routed to the control measures when the capture or collection system is operating as designed, reported as a percent. (PercentControlApproachCaptureEfficiency)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."PCNT_CTRL_APCH_EFCT" IS 'An estimate of the portion of the reporting period''s activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary). (PercentControlApproachEffectiveness)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."PCNT_CTRL_APCH_PEN" IS 'An estimate of the percent value of the nonpoint activity throughput that is affected by a rule or voluntary approach for the given location.  (Nonpoint only.) (PercentControlApproachPenetration)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."FIRST_INVEN_YEAR" IS 'The inventory year for which the controls were implemented.  (Point only.) (FirstInventoryYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."LAST_INVEN_YEAR" IS 'The last inventory year for which the controls were active.  (Point only.) (LastInventoryYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT"."CTRL_APCH_CMNT" IS 'Comments regarding the control approach. (ControlApproachComment)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT"  IS 'Schema element: EmissionsUnitDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_IDEN" 
   (	"EMIS_UNIT_IDEN_ID" VARCHAR2(40), 
	"EMIS_UNIT_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_IDEN"  IS 'Schema element: EmissionsUnitIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_PROC
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_PROC" 
   (	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"EMIS_UNIT_ID" VARCHAR2(40), 
	"SRC_CLASS_CODE" VARCHAR2(50), 
	"EMIS_TYPE_CODE" VARCHAR2(50), 
	"AIRCRAFT_ENGINE_TYPE_CODE" VARCHAR2(50), 
	"PROC_TYPE_CODE" VARCHAR2(50), 
	"PROC_DESC" VARCHAR2(255), 
	"LAST_EMIS_YEAR" NUMBER(10,0), 
	"PROC_CMNT" VARCHAR2(255), 
	"CTRL_APCH_DESC" VARCHAR2(255), 
	"PCNT_CTRL_APCH_CAP_EFCY" NUMBER(12,6), 
	"PCNT_CTRL_APCH_EFCT" NUMBER(12,6), 
	"PCNT_CTRL_APCH_PEN" NUMBER(12,6), 
	"FIRST_INVEN_YEAR" NUMBER(10,0), 
	"LAST_INVEN_YEAR" NUMBER(10,0), 
	"CTRL_APCH_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."SRC_CLASS_CODE" IS 'EPA Source Classification Code that identifies an emissions process. (SourceClassificationCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."EMIS_TYPE_CODE" IS 'Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mobile sources only. Examples include exhaust, evaporative and tire wear. (EmissionsTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."AIRCRAFT_ENGINE_TYPE_CODE" IS 'Identifies the combination of aircraft and engine type for airport emissions. (AircraftEngineTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."PROC_TYPE_CODE" IS 'Defines the type of emissions produced by GHG processes. Examples included for a Scope 1 Stationary Combustion might be oil, gas, coal. (ProcessTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."PROC_DESC" IS 'A text description of the emissions process. (ProcessDescription)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."LAST_EMIS_YEAR" IS 'The last year in which emissions occurred for this process. (LastEmissionsYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."PROC_CMNT" IS 'Any comments regarding the emissions process. (ProcessComment)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."CTRL_APCH_DESC" IS 'Description of the overall control system or approach applied to an emissions unit or process. (ControlApproachDescription)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."PCNT_CTRL_APCH_CAP_EFCY" IS 'An estimate of that portion of an affected emission stream that is collected and routed to the control measures when the capture or collection system is operating as designed, reported as a percent. (PercentControlApproachCaptureEfficiency)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."PCNT_CTRL_APCH_EFCT" IS 'An estimate of the portion of the reporting period''s activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary). (PercentControlApproachEffectiveness)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."PCNT_CTRL_APCH_PEN" IS 'An estimate of the percent value of the nonpoint activity throughput that is affected by a rule or voluntary approach for the given location.  (Nonpoint only.) (PercentControlApproachPenetration)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."FIRST_INVEN_YEAR" IS 'The inventory year for which the controls were implemented.  (Point only.) (FirstInventoryYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."LAST_INVEN_YEAR" IS 'The last inventory year for which the controls were active.  (Point only.) (LastInventoryYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC"."CTRL_APCH_CMNT" IS 'Comments regarding the control approach. (ControlApproachComment)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_PROC"  IS 'Schema element: EmissionsUnitProcessDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_PROC_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_PROC_IDEN" 
   (	"EMIS_UNIT_PROC_IDEN_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_PROC_IDEN"  IS 'Schema element: EmissionsUnitProcessIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_PROC_RGLN
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_PROC_RGLN" 
   (	"EMIS_UNIT_PROC_RGLN_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"RGTRY_CODE" VARCHAR2(50), 
	"AGN_CODE_TXT" VARCHAR2(255), 
	"RGTRY_START_YEAR" NUMBER(10,0), 
	"RGTRY_END_YEAR" NUMBER(10,0), 
	"RGLN_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RGLN"."RGTRY_CODE" IS 'The code that describes the regulation applicable to the emissions unit activity or process. (RegulatoryCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RGLN"."AGN_CODE_TXT" IS 'Text describing the non-federal regulation applicable to the emissions unit or process. (AgencyCodeText)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RGLN"."RGTRY_START_YEAR" IS 'The year in which the enissions unit or process became subject to the regulation. (RegulatoryStartYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RGLN"."RGTRY_END_YEAR" IS 'The year in which the enissions unit or process was no longer effected by the regulation. (RegulatoryEndYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RGLN"."RGLN_CMNT" IS 'Comments regarding the regulation. (RegulationComment)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_PROC_RGLN"  IS 'Schema element: EmissionsUnitProcessRegulationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_PROC_RPT_PRD
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD" 
   (	"EMIS_UNIT_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"RPT_PRD_TYPE_CODE" VARCHAR2(50), 
	"EMIS_OPER_TYPE_CODE" VARCHAR2(50), 
	"START_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6), 
	"CALC_PARM_TYPE_CODE" VARCHAR2(50), 
	"CALC_PARM_VAL" VARCHAR2(50), 
	"CALC_PARM_UNT_MEAS" VARCHAR2(255), 
	"CALC_MATERIAL_CODE" VARCHAR2(50), 
	"CALC_DATA_YEAR" NUMBER(10,0), 
	"CALC_DATA_SRC" VARCHAR2(255), 
	"RPT_PRD_CMNT" VARCHAR2(255), 
	"ACTL_HOURS_PER_PRD" VARCHAR2(255), 
	"AVE_DAYS_PER_WEEK" VARCHAR2(255), 
	"AVE_HOURS_PER_DAY" VARCHAR2(255), 
	"AVE_WEEKS_PER_PRD" VARCHAR2(255), 
	"PCNT_WINTER_ACT" NUMBER(12,6), 
	"PCNT_SPRING_ACT" NUMBER(12,6), 
	"PCNT_SUMMER_ACT" NUMBER(12,6), 
	"PCNT_FALL_ACT" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."RPT_PRD_TYPE_CODE" IS 'The time period type for which emissions are reported. (ReportingPeriodTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."EMIS_OPER_TYPE_CODE" IS 'Code identifying the operating state for the emissions being reported. (EmissionOperatingTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."START_DATE" IS 'The date on which the reporting period began.  Applies to the reporting of episodic or event emissions only. (StartDate)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."CALC_PARM_TYPE_CODE" IS 'Code indicating whether the material measured is an input to the process, an output of the process or a static count (not a throughput).  (CalculationParameterTypeCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."CALC_PARM_VAL" IS 'Activity or throughput of the process for a given time period. (CalculationParameterValue)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."CALC_PARM_UNT_MEAS" IS 'Code for the unit of measure for calculation parameter value. (CalculationParameterUnitofMeasure)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."CALC_MATERIAL_CODE" IS 'Code for material or fuel processed. (CalculationMaterialCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."CALC_DATA_YEAR" IS 'The actual year represented by the data if it is different from the emissions year. (CalculationDataYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."CALC_DATA_SRC" IS 'The source of the data used. (CalculationDataSource)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."RPT_PRD_CMNT" IS 'Any comments regarding the reporting period. (ReportingPeriodComment)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."ACTL_HOURS_PER_PRD" IS 'Actual number of hours the process is active or operating during for the reporting period. (ActualHoursPerPeriod)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."AVE_DAYS_PER_WEEK" IS 'The average number of days per week that the emissions process is active within the reporting period. (AverageDaysPerWeek)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."AVE_HOURS_PER_DAY" IS 'The average number of hours per day that the emissions process is active within the reporting period. (AverageHoursPerDay)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."AVE_WEEKS_PER_PRD" IS 'The average number of weeks that the emissions process is active within the reporting period. (AverageWeeksPerPeriod)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."PCNT_WINTER_ACT" IS 'The percentage of the annual activity that occurred during the Winter months (December, January, February). (PercentWinterActivity)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."PCNT_SPRING_ACT" IS 'The percentage of the annual activity that occurred during the Spring months (March, April, May). (PercentSpringActivity)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."PCNT_SUMMER_ACT" IS 'The percentage of the annual activity that occurred during the Summer months (June, July, August). (PercentSummerActivity)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_PROC_RPT_PRD"."PCNT_FALL_ACT" IS 'The percentage of the annual activity that occurred during the Fall months (September, October, November). (PercentFallActivity)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD"  IS 'Schema element: EmissionsUnitProcessReportingPeriodDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_QLTY_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_QLTY_IDEN" 
   (	"EMIS_UNIT_QLTY_IDEN_ID" VARCHAR2(40), 
	"EMIS_UNIT_ID" VARCHAR2(40), 
	"QLTY_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_QLTY_IDEN"."QLTY_IDEN" IS 'An identifier for the quality finding. (QualityIdentifier)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_QLTY_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_QLTY_IDEN"  IS 'Schema element: EmissionsUnitQualityIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMIS_UNIT_RGLN
--------------------------------------------------------

  CREATE TABLE "CERS_EMIS_UNIT_RGLN" 
   (	"EMIS_UNIT_RGLN_ID" VARCHAR2(40), 
	"EMIS_UNIT_ID" VARCHAR2(40), 
	"RGTRY_CODE" VARCHAR2(50), 
	"AGN_CODE_TXT" VARCHAR2(255), 
	"RGTRY_START_YEAR" NUMBER(10,0), 
	"RGTRY_END_YEAR" NUMBER(10,0), 
	"RGLN_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMIS_UNIT_RGLN"."RGTRY_CODE" IS 'The code that describes the regulation applicable to the emissions unit activity or process. (RegulatoryCode)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_RGLN"."AGN_CODE_TXT" IS 'Text describing the non-federal regulation applicable to the emissions unit or process. (AgencyCodeText)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_RGLN"."RGTRY_START_YEAR" IS 'The year in which the enissions unit or process became subject to the regulation. (RegulatoryStartYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_RGLN"."RGTRY_END_YEAR" IS 'The year in which the enissions unit or process was no longer effected by the regulation. (RegulatoryEndYear)';
 
   COMMENT ON COLUMN "CERS_EMIS_UNIT_RGLN"."RGLN_CMNT" IS 'Comments regarding the regulation. (RegulationComment)';
 
   COMMENT ON TABLE "CERS_EMIS_UNIT_RGLN"  IS 'Schema element: EmissionsUnitRegulationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_CTRL_APCH_CTRL_MS
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" 
   (	"EMS_UNT_CTRL_APCH_CTRL_MS_ID" VARCHAR2(40), 
	"EMIS_UNIT_ID" VARCHAR2(40), 
	"CTRL_MEAS_CODE" VARCHAR2(50), 
	"CTRL_MEAS_SEQ" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_CTRL_APCH_CTRL_MS"."CTRL_MEAS_CODE" IS 'Code that identifies the piece of equipment or practice that is used to reduce one or more pollutants. (ControlMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_CTRL_APCH_CTRL_MS"."CTRL_MEAS_SEQ" IS 'The sequnce in which the pollutant stream passes through the various devices in the control group. (ControlMeasureSequence)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS"  IS 'Schema element: EmissionsUnitControlApproachControlMeasureDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_CTRL_APCH_CTR_PLT
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" 
   (	"EMS_UNT_CTRL_APCH_CTRL_PLT_ID" VARCHAR2(40), 
	"EMIS_UNIT_ID" VARCHAR2(40), 
	"POLT_CODE" VARCHAR2(50), 
	"PCNT_CTRL_MEAS_REDC_EFCY" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_CTRL_APCH_CTR_PLT"."POLT_CODE" IS 'Code identifying the pollutant for which emissions are reported. (PollutantCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_CTRL_APCH_CTR_PLT"."PCNT_CTRL_MEAS_REDC_EFCY" IS 'The percent reduction achieved for the pollutant when all control measures are operating as designed. (PercentControlMeasuresReductionEfficiency)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT"  IS 'Schema element: EmissionsUnitControlApproachControlPollutantDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PRC_CTR_APC_CT_MS
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" 
   (	"EMS_UNT_PRC_CTRL_APC_CTR_MS_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"CTRL_MEAS_CODE" VARCHAR2(50), 
	"CTRL_MEAS_SEQ" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_CTR_APC_CT_MS"."CTRL_MEAS_CODE" IS 'Code that identifies the piece of equipment or practice that is used to reduce one or more pollutants. (ControlMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_CTR_APC_CT_MS"."CTRL_MEAS_SEQ" IS 'The sequnce in which the pollutant stream passes through the various devices in the control group. (ControlMeasureSequence)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS"  IS 'Schema element: EmissionsUnitProcessControlApproachControlMeasureDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PRC_CTR_APC_CT_PL
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" 
   (	"EMS_UNT_PRC_CTR_APC_CTR_PLT_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"POLT_CODE" VARCHAR2(50), 
	"PCNT_CTRL_MEAS_REDC_EFCY" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_CTR_APC_CT_PL"."POLT_CODE" IS 'Code identifying the pollutant for which emissions are reported. (PollutantCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_CTR_APC_CT_PL"."PCNT_CTRL_MEAS_REDC_EFCY" IS 'The percent reduction achieved for the pollutant when all control measures are operating as designed. (PercentControlMeasuresReductionEfficiency)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL"  IS 'Schema element: EmissionsUnitProcessControlApproachControlPollutantDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PRC_RL_PT_APPR
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR" 
   (	"EMIS_UNIT_PROC_REL_PT_APPR_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_ID" VARCHAR2(40), 
	"AVE_PCNT_EMIS" NUMBER(12,6), 
	"REL_PT_APPR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RL_PT_APPR"."AVE_PCNT_EMIS" IS 'The average annual percent of an emissions process that is vented through a release point. (AveragePercentEmissions)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RL_PT_APPR"."REL_PT_APPR_CMNT" IS 'Comment regarding the average apportionment of emissions vented through a release point. (ReleasePointApportionmentComment)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR"  IS 'Schema element: EmissionsUnitProcessReleasePointApportionmentDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PRC_RL_PT_APP_IDN
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" 
   (	"EMS_UNT_PRC_RL_PT_APPR_IDN_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_REL_PT_APPR_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RL_PT_APP_IDN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RL_PT_APP_IDN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RL_PT_APP_IDN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RL_PT_APP_IDN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN"  IS 'Schema element: EmissionsUnitProcessReleasePointApportionmentIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PRC_RPT_PRD_EMS
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" 
   (	"EMIS_UNIT_PROC_RPT_PRD_EMIS_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"POLT_CODE" VARCHAR2(50), 
	"TOTAL_EMIS" VARCHAR2(255), 
	"EMIS_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC" VARCHAR2(255), 
	"EMIS_FAC_NUM_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC_DEN_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC_FORM_CODE" VARCHAR2(50), 
	"EMIS_FAC_TXT" VARCHAR2(255), 
	"EMIS_CALC_METH_CODE" VARCHAR2(50), 
	"EMIS_FAC_REF_TXT" VARCHAR2(255), 
	"ALGOR_FORM_TXT" VARCHAR2(255), 
	"ALGOR_CMNT" VARCHAR2(255), 
	"CALC_METH_ACC_ASMT_CODE" VARCHAR2(50), 
	"EMIS_DE_MINIMIS_STAT" VARCHAR2(255), 
	"EMIS_CMNT" VARCHAR2(255), 
	"CO_2E" VARCHAR2(255), 
	"CO_2E_UNT_MEAS_CODE" VARCHAR2(50), 
	"CO_2_CONV_FAC" VARCHAR2(255), 
	"CO_2_CONV_FAC_SRC" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."POLT_CODE" IS 'Code identifying the pollutant for which emissions are reported. (PollutantCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."TOTAL_EMIS" IS 'Total calculated or estimated amount of the pollutant. (TotalEmissions)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_UNT_MEAS_CODE" IS 'Unit of measure for reported emissions. (EmissionsUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_FAC" IS 'The emission factor used for the emissions value if a calculated value was provided. (EmissionFactor)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_FAC_NUM_UNT_MEAS_CODE" IS 'The numerator for the unit of measure of the reported emission factor. (EmissionFactorNumeratorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_FAC_DEN_UNT_MEAS_CODE" IS 'The denominator for the unit of measure of the reported emission factor. (EmissionFactorDenominatorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_FAC_FORM_CODE" IS 'Code that identifies the emission factor formula used to calculate emissions. (EmissionFactorFormulaCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_FAC_TXT" IS 'Explanation for emission factor. (EmissionFactorText)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_CALC_METH_CODE" IS 'Code that defines the method used to calculate emissions. (EmissionCalculationMethodCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_FAC_REF_TXT" IS 'Reference given for the emission factor used in the calculation. (EmissionFactorReferenceText)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."ALGOR_FORM_TXT" IS 'The formula used to calculate emissions. (AlgorithmFormulaText)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."ALGOR_CMNT" IS 'Information about the algorithm, including units of measure, for the calculation method. (AlgorithmComment)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."CALC_METH_ACC_ASMT_CODE" IS 'The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C, CARB, Part 75, etc.  (CalculationMethodAccuracyAssessmentCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_DE_MINIMIS_STAT" IS 'Status indicating if emissions are de minimis. (EmissionsDeMinimisStatus)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."EMIS_CMNT" IS 'Any comments regarding the emissions, method of calculation, or emission factor. (EmissionsComment)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."CO_2E" IS 'The total CO2 equivalent emissions. (CO2e)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."CO_2E_UNT_MEAS_CODE" IS 'The unit of measure for the CO2 equivalent emissions. (CO2eUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."CO_2_CONV_FAC" IS 'Global warming potential (GWP) used to calculate CO2e. (CO2ConversionFactor)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_EMS"."CO_2_CONV_FAC_SRC" IS 'The source of reference for the GWP value. (CO2ConversionFactorSource)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS"  IS 'Schema element: EmissionsUnitProcessReportingPeriodEmissionsDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PRC_RPT_PRD_QL_ID
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" 
   (	"EMS_UNT_PRC_RPT_PRD_QLT_IDN_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"QLTY_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID"."QLTY_IDEN" IS 'An identifier for the quality finding. (QualityIdentifier)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID"  IS 'Schema element: EmissionsUnitProcessReportingPeriodQualityIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EMS_UNT_PR_RP_PR_SP_CL_PR
--------------------------------------------------------

  CREATE TABLE "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" 
   (	"EMS_UNT_PRC_RPT_PR_SP_CL_PR_ID" VARCHAR2(40), 
	"EMIS_UNIT_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"SUPP_CALC_PARM_TYPE" VARCHAR2(255), 
	"SUPP_CALC_PARM_VAL" VARCHAR2(50), 
	"SPP_CLC_PRM_NM_UNT_MS_CDE" VARCHAR2(50), 
	"SPP_CLC_PRM_DN_UNT_MS_CDE" VARCHAR2(50), 
	"SUPP_CALC_PARM_DATA_YEAR" NUMBER(10,0), 
	"SUPP_CALC_PARM_DATA_SRC" VARCHAR2(255), 
	"SUPP_CALC_PARM_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SUPP_CALC_PARM_TYPE" IS 'Name of the parameter that describes the type of activity, throughput or input used in the calculation. (SupplementalCalculationParameterType)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SUPP_CALC_PARM_VAL" IS 'The value of the parameter. (SupplementalCalculationParameterValue)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SPP_CLC_PRM_NM_UNT_MS_CDE" IS 'The numerator unit of measure for the parameter. (SupplementalCalculationParameterNumeratorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SPP_CLC_PRM_DN_UNT_MS_CDE" IS 'The denominator unit of measure for the parameter. (SupplementalCalculationParameterDenominatorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SUPP_CALC_PARM_DATA_YEAR" IS 'The year represented by the supplemental data if it is different from the emissions year. (SupplementalCalculationParameterDataYear)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SUPP_CALC_PARM_DATA_SRC" IS 'The source of the supplemental parameter data used. (SupplementalCalculationParameterDataSource)';
 
   COMMENT ON COLUMN "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"."SUPP_CALC_PARM_CMNT" IS 'Any comments regarding the parameter. (SupplementalCalculationParameterComment)';
 
   COMMENT ON TABLE "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR"  IS 'Schema element: EmissionsUnitProcessReportingPeriodSupplementalCalculationParameterDataType';
--------------------------------------------------------
--  DDL for Table CERS_EVENT
--------------------------------------------------------

  CREATE TABLE "CERS_EVENT" 
   (	"EVENT_ID" VARCHAR2(40), 
	"CERS_ID" VARCHAR2(40), 
	"EVENT_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EVENT_NAME" VARCHAR2(128), 
	"LAND_MGR" VARCHAR2(255), 
	"LOC_DESC" VARCHAR2(255), 
	"EVENT_CLASS_CODE" VARCHAR2(50), 
	"EVENT_SIZE_SRC_CODE" VARCHAR2(50), 
	"CONT_DATE" TIMESTAMP (6), 
	"RECUR_IND_CODE" VARCHAR2(50), 
	"RECUR_YEAR" NUMBER(10,0), 
	"GRND_BASED_DATA_SRC_CODE" VARCHAR2(50), 
	"REMOTE_SENSING_DATA_SRC_CODE" VARCHAR2(50), 
	"FUEL_CONS_AND_EMIS_MODEL_CODE" VARCHAR2(50), 
	"FUEL_TYPE_MODEL_CODE" VARCHAR2(50), 
	"FUEL_SELC_CODE" VARCHAR2(50), 
	"IGNIT_METH_CODE" VARCHAR2(50), 
	"IGNIT_LOC_CODE" VARCHAR2(50), 
	"IGNIT_ORIEN_CODE" VARCHAR2(50), 
	"EVENT_CMNT" VARCHAR2(255), 
	"ATCH_FILE_CONT" BLOB, 
	"ATCH_FILE_NAME" VARCHAR2(128), 
	"ATCH_FILE_DESC" VARCHAR2(255), 
	"ATCH_FILE_SIZE" VARCHAR2(255), 
	"ATCH_FILE_CONT_TYPE_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_EVENT"."EVENT_IDEN" IS 'An identifier provided by the land or event manager that identifies an event.  This identifier is unique for each event. (EventIdentifier)';
 
   COMMENT ON COLUMN "CERS_EVENT"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."EVENT_NAME" IS 'The name of the event. (EventName)';
 
   COMMENT ON COLUMN "CERS_EVENT"."LAND_MGR" IS 'Identifies the Federal, State, Private, Municipal, County, Tribal agency or land owner that is managing the fire or responding to event. (LandManager)';
 
   COMMENT ON COLUMN "CERS_EVENT"."LOC_DESC" IS 'Description of the location of the event. (LocationDescription)';
 
   COMMENT ON COLUMN "CERS_EVENT"."EVENT_CLASS_CODE" IS 'Code that identifies the classification of the fire. (EventClassificationCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."EVENT_SIZE_SRC_CODE" IS 'The code that identifies the method used to determine the size of the event. (EventSizeSourceCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."CONT_DATE" IS 'The date on which the event was contained. (ContainmentDate)';
 
   COMMENT ON COLUMN "CERS_EVENT"."RECUR_IND_CODE" IS 'Indicates whether a prescribed or agricultural fire has occurred previously at this location (Y/N). (RecurrenceIndicatorCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."RECUR_YEAR" IS 'The most recent year in which the fire recurred in this location. (RecurrenceYear)';
 
   COMMENT ON COLUMN "CERS_EVENT"."GRND_BASED_DATA_SRC_CODE" IS 'Indicates whether ground-based data were included and if so, identifies their source. (GroundBasedDataSourceCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."REMOTE_SENSING_DATA_SRC_CODE" IS 'Indicates whether remotely-sensed data were included and if so, identifies their source. (RemoteSensingDataSourceCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."FUEL_CONS_AND_EMIS_MODEL_CODE" IS 'The model(s) used to calculate fuel consumption and emissions estimates. (FuelConsumptionAndEmissionsModelCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."FUEL_TYPE_MODEL_CODE" IS 'The fuel model used to characterize available fuel beds (e.g., FCCS or NFDRS). (FuelTypeModelCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."FUEL_SELC_CODE" IS 'The method used (on-site survey vs. GIS overlay) to select the appropriate fuel beds (e.g., red spruce, chaparral, sawgrass, or logging slash). (FuelSelectionCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."IGNIT_METH_CODE" IS 'The method used to ignite the fire (i.e., DAID, helitorch, or driptorch). (IgnitionMethodCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."IGNIT_LOC_CODE" IS 'The location and distribution of the ignition points within the burn area (e.g., center or multiple). (IgnitionLocationCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."IGNIT_ORIEN_CODE" IS 'The  technique used to direct the orientation of the fire''s movement with respect to the wind (i.e., backing, strip-heading, or flanking). (IgnitionOrientationCode)';
 
   COMMENT ON COLUMN "CERS_EVENT"."EVENT_CMNT" IS 'Any comments regarding the event. (EventComment)';
 
   COMMENT ON COLUMN "CERS_EVENT"."ATCH_FILE_CONT" IS 'The data content of a file. (AttachmentFileContent)';
 
   COMMENT ON COLUMN "CERS_EVENT"."ATCH_FILE_NAME" IS 'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)';
 
   COMMENT ON COLUMN "CERS_EVENT"."ATCH_FILE_DESC" IS 'Description of file. (AttachmentFileDescription)';
 
   COMMENT ON COLUMN "CERS_EVENT"."ATCH_FILE_SIZE" IS 'The size of the attached file. (AttachmentFileSize)';
 
   COMMENT ON COLUMN "CERS_EVENT"."ATCH_FILE_CONT_TYPE_CODE" IS 'A code describing the content type of a file. (AttachmentFileContentTypeCode)';
 
   COMMENT ON TABLE "CERS_EVENT"  IS 'Schema element: EventDataType';
--------------------------------------------------------
--  DDL for Table CERS_EVENT_EMIS_EMIS
--------------------------------------------------------

  CREATE TABLE "CERS_EVENT_EMIS_EMIS" 
   (	"EVENT_EMIS_EMIS_ID" VARCHAR2(40), 
	"EVENT_EMIS_PROC_ID" VARCHAR2(40), 
	"POLT_CODE" VARCHAR2(50), 
	"TOTAL_EMIS" VARCHAR2(255), 
	"EMIS_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC" VARCHAR2(255), 
	"EMIS_FAC_NUM_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC_DEN_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC_FORM_CODE" VARCHAR2(50), 
	"EMIS_FAC_TXT" VARCHAR2(255), 
	"EMIS_CALC_METH_CODE" VARCHAR2(50), 
	"EMIS_FAC_REF_TXT" VARCHAR2(255), 
	"ALGOR_FORM_TXT" VARCHAR2(255), 
	"ALGOR_CMNT" VARCHAR2(255), 
	"CALC_METH_ACC_ASMT_CODE" VARCHAR2(50), 
	"EMIS_DE_MINIMIS_STAT" VARCHAR2(255), 
	"EMIS_CMNT" VARCHAR2(255), 
	"CO_2E" VARCHAR2(255), 
	"CO_2E_UNT_MEAS_CODE" VARCHAR2(50), 
	"CO_2_CONV_FAC" VARCHAR2(255), 
	"CO_2_CONV_FAC_SRC" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."POLT_CODE" IS 'Code identifying the pollutant for which emissions are reported. (PollutantCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."TOTAL_EMIS" IS 'Total calculated or estimated amount of the pollutant. (TotalEmissions)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_UNT_MEAS_CODE" IS 'Unit of measure for reported emissions. (EmissionsUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_FAC" IS 'The emission factor used for the emissions value if a calculated value was provided. (EmissionFactor)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_FAC_NUM_UNT_MEAS_CODE" IS 'The numerator for the unit of measure of the reported emission factor. (EmissionFactorNumeratorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_FAC_DEN_UNT_MEAS_CODE" IS 'The denominator for the unit of measure of the reported emission factor. (EmissionFactorDenominatorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_FAC_FORM_CODE" IS 'Code that identifies the emission factor formula used to calculate emissions. (EmissionFactorFormulaCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_FAC_TXT" IS 'Explanation for emission factor. (EmissionFactorText)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_CALC_METH_CODE" IS 'Code that defines the method used to calculate emissions. (EmissionCalculationMethodCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_FAC_REF_TXT" IS 'Reference given for the emission factor used in the calculation. (EmissionFactorReferenceText)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."ALGOR_FORM_TXT" IS 'The formula used to calculate emissions. (AlgorithmFormulaText)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."ALGOR_CMNT" IS 'Information about the algorithm, including units of measure, for the calculation method. (AlgorithmComment)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."CALC_METH_ACC_ASMT_CODE" IS 'The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C, CARB, Part 75, etc.  (CalculationMethodAccuracyAssessmentCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_DE_MINIMIS_STAT" IS 'Status indicating if emissions are de minimis. (EmissionsDeMinimisStatus)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."EMIS_CMNT" IS 'Any comments regarding the emissions, method of calculation, or emission factor. (EmissionsComment)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."CO_2E" IS 'The total CO2 equivalent emissions. (CO2e)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."CO_2E_UNT_MEAS_CODE" IS 'The unit of measure for the CO2 equivalent emissions. (CO2eUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."CO_2_CONV_FAC" IS 'Global warming potential (GWP) used to calculate CO2e. (CO2ConversionFactor)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_EMIS"."CO_2_CONV_FAC_SRC" IS 'The source of reference for the GWP value. (CO2ConversionFactorSource)';
 
   COMMENT ON TABLE "CERS_EVENT_EMIS_EMIS"  IS 'Schema element: EventEmissionsEmissionsDataType';
--------------------------------------------------------
--  DDL for Table CERS_EVENT_EMIS_PROC
--------------------------------------------------------

  CREATE TABLE "CERS_EVENT_EMIS_PROC" 
   (	"EVENT_EMIS_PROC_ID" VARCHAR2(40), 
	"EVENT_LOC_ID" VARCHAR2(40), 
	"SRC_CLASS_CODE" VARCHAR2(50), 
	"FUEL_CONFIG_CODE" VARCHAR2(50), 
	"FUEL_LOADING" VARCHAR2(255), 
	"FUEL_LOADING_UNT_MEAS_CODE" VARCHAR2(50), 
	"AMT_FUEL_CONS" VARCHAR2(255), 
	"AMT_FUEL_CONS_UNT_MEAS_CODE" VARCHAR2(50), 
	"PCNT_TEN_HOUR_FUEL_MOIS" NUMBER(12,6), 
	"PCNT_ONE_THSD_HOUR_FUEL_MOIS" NUMBER(12,6), 
	"PCNT_LIVE_FUEL_MOIS" NUMBER(12,6), 
	"PCNT_DUFF_FUEL_MOIS" NUMBER(12,6), 
	"HEAT_REL" VARCHAR2(255), 
	"HEAT_REL_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_REDC_TECHNIQUE_CODE" VARCHAR2(50), 
	"EVENT_EMIS_PROC_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."SRC_CLASS_CODE" IS 'EPA Source Classification Code that identifies an emissions process. (SourceClassificationCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."FUEL_CONFIG_CODE" IS 'The predominant configuration of the fuel burned (i.e., pile, windrow, broadcast or natural). (FuelConfigurationCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."FUEL_LOADING" IS 'Fuel per acre available to consume. (FuelLoading)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."FUEL_LOADING_UNT_MEAS_CODE" IS 'Code that identifies the numerator of the unit of measure for the fuel loading. (FuelLoadingUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."AMT_FUEL_CONS" IS 'For a given day, the amount of fuel consumed in the defined geographic area. (AmountofFuelConsumed)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."AMT_FUEL_CONS_UNT_MEAS_CODE" IS 'Code that identifies the unit of measure for the amount of fuel consumed. (AmountofFuelConsumedUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."PCNT_TEN_HOUR_FUEL_MOIS" IS 'The ten-hour fuel moisture for the location, on the particular day the fire or smoldering occurred, in percent. (PercentTenHourFuelMoisture)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."PCNT_ONE_THSD_HOUR_FUEL_MOIS" IS 'The one-thousand-hour fuel moisture for the location, on the particular day the fire or smoldering occurred, in percent. (PercentOneThousandHourFuelMoisture)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."PCNT_LIVE_FUEL_MOIS" IS 'The amount of water expressed as the percent of oven dry weight of living plant matter. (PercentLiveFuelMoisture)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."PCNT_DUFF_FUEL_MOIS" IS 'The amount of water expressed as the percent of the oven dry weight of any cured or dead plant part.  This may include dead plant matter still attached to living plants. (PercentDuffFuelMoisture)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."HEAT_REL" IS 'The amount of effective thermal energy (measured in million BTUs per hour or day) available to provide buoyant plume rise. (HeatRelease)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."HEAT_REL_UNT_MEAS_CODE" IS 'Code that identifies the unit of measure for heat release. (HeatReleaseUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."EMIS_REDC_TECHNIQUE_CODE" IS 'Code identifying the method used for reducing emissions from prescribed fires, agricultural fires, Native American Fires and Wildland Use fires emissions. (EmissionReductionTechniqueCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_EMIS_PROC"."EVENT_EMIS_PROC_CMNT" IS 'Any comments regarding the event emissions process. (EventEmissionsProcessComment)';
 
   COMMENT ON TABLE "CERS_EVENT_EMIS_PROC"  IS 'Schema element: EventEmissionsProcessDataType';
--------------------------------------------------------
--  DDL for Table CERS_EVENT_LOC
--------------------------------------------------------

  CREATE TABLE "CERS_EVENT_LOC" 
   (	"EVENT_LOC_ID" VARCHAR2(40), 
	"EVENT_RPT_PRD_ID" VARCHAR2(40), 
	"STA_AND_CNTY_FIPS_CODE" VARCHAR2(50), 
	"TRIB_CODE" VARCHAR2(50), 
	"STA_AND_CTRY_FIPS_CODE" VARCHAR2(50), 
	"LAT_MEAS" VARCHAR2(255), 
	"LONG_MEAS" VARCHAR2(255), 
	"SRC_MAP_SCALE_NUM" VARCHAR2(20), 
	"HORZ_ACC_MEAS" VARCHAR2(255), 
	"HORZ_ACC_UNT_MEAS" VARCHAR2(255), 
	"HORZ_COLL_METH_CODE" VARCHAR2(50), 
	"HORZ_REF_DATUM_CODE" VARCHAR2(50), 
	"GEO_REF_PT_CODE" VARCHAR2(50), 
	"DATA_COLL_DATE" TIMESTAMP (6), 
	"GEO_CMNT" VARCHAR2(255), 
	"VERT_MEAS" VARCHAR2(255), 
	"VERT_UNT_MEAS_CODE" VARCHAR2(50), 
	"VERT_COLL_METH_CODE" VARCHAR2(50), 
	"VERT_REF_DATUM_CODE" VARCHAR2(50), 
	"VERF_METH_CODE" VARCHAR2(50), 
	"COORD_DATA_SRC_CODE" VARCHAR2(50), 
	"GEOM_TYPE_CODE" VARCHAR2(50), 
	"AREA_WTIN_PERM" VARCHAR2(255), 
	"AREA_WTIN_PERM_UNT_MEAS_CODE" VARCHAR2(50), 
	"PCNT_AREA_PROD_EMIS" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_EVENT_LOC"."STA_AND_CNTY_FIPS_CODE" IS 'The list is from FIPS Counties codes used for the identification of the Counties and County equivalents of the United States. (StateAndCountyFIPSCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."TRIB_CODE" IS 'The code that represents the American Indian Tribe or Alaskan Native entity. (TribalCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."STA_AND_CTRY_FIPS_CODE" IS 'The code that represents a State and Country for States in Mexico and Provinces in Canada. (StateAndCountryFIPSCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."LAT_MEAS" IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."LONG_MEAS" IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."HORZ_ACC_MEAS" IS 'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."HORZ_ACC_UNT_MEAS" IS 'The horizonal accuracy unit of measure. (HorizontalAccuracyUnitofMeasure)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."HORZ_COLL_METH_CODE" IS 'The code that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."HORZ_REF_DATUM_CODE" IS 'The code that represents the reference datum used in determining latitude and longitude coordinates. (HorizontalReferenceDatumCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."GEO_REF_PT_CODE" IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."DATA_COLL_DATE" IS 'The calendar date when data were collected. (DataCollectionDate)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."GEO_CMNT" IS 'The text that provides additional information about the geographic coordinates. (GeographicComment)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."VERT_MEAS" IS 'The measure of elevation (i.e., the altitude), above or below a reference datum. (VerticalMeasure)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."VERT_UNT_MEAS_CODE" IS 'The vertical unit of measure. (VerticalUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."VERT_COLL_METH_CODE" IS 'The code that identifies the method used to collect the vertical measure (i.e., the altitude) of a reference point. (VerticalCollectionMethodCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."VERT_REF_DATUM_CODE" IS 'The code that represents the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalReferenceDatumCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."VERF_METH_CODE" IS 'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."COORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."GEOM_TYPE_CODE" IS 'The code that represents the geometric entity represented by one point or a sequence of latitude and longitude points. (GeometricTypeCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."AREA_WTIN_PERM" IS 'Total area that is contained within the event perimeter for the reporting period. (AreaWithinPerimeter)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."AREA_WTIN_PERM_UNT_MEAS_CODE" IS 'Code that identifies the unit of measure for the area within the event perimeter. (AreaWithinPerimeterUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_LOC"."PCNT_AREA_PROD_EMIS" IS 'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)';
 
   COMMENT ON TABLE "CERS_EVENT_LOC"  IS 'Schema element: EventLocationDataType';
--------------------------------------------------------
--  DDL for Table CERS_EVENT_RPT_PRD
--------------------------------------------------------

  CREATE TABLE "CERS_EVENT_RPT_PRD" 
   (	"EVENT_RPT_PRD_ID" VARCHAR2(40), 
	"EVENT_ID" VARCHAR2(40), 
	"EVENT_BEGIN_DATE" TIMESTAMP (6), 
	"EVENT_END_DATE" TIMESTAMP (6), 
	"EVENT_STAGE_CODE" VARCHAR2(50), 
	"BEGIN_HOUR" VARCHAR2(255), 
	"END_HOUR" VARCHAR2(255), 
	"EVENT_RPT_PRD_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EVENT_RPT_PRD"."EVENT_BEGIN_DATE" IS 'The first day for which emissions are reported for the reporting period. (EventBeginDate)';
 
   COMMENT ON COLUMN "CERS_EVENT_RPT_PRD"."EVENT_END_DATE" IS 'The last day for which emissions are reported for the reporting period. (EventEndDate)';
 
   COMMENT ON COLUMN "CERS_EVENT_RPT_PRD"."EVENT_STAGE_CODE" IS 'Identifies whether emissions reported are due to flaming, smoldering, or both. (EventStageCode)';
 
   COMMENT ON COLUMN "CERS_EVENT_RPT_PRD"."BEGIN_HOUR" IS 'The hour of the day in which the event began.  The hour is reported as a value between 00 and 23 inclusive, representing the hours of the day in 24 increments. (BeginHour)';
 
   COMMENT ON COLUMN "CERS_EVENT_RPT_PRD"."END_HOUR" IS 'The hour of the day in which the event ended.  The hour is reported as a value between 00 and 23 inclusive, representing the hours of the day in 24 increments. (EndHour)';
 
   COMMENT ON COLUMN "CERS_EVENT_RPT_PRD"."EVENT_RPT_PRD_CMNT" IS 'Any comments regarding the event reporting period. (EventReportingPeriodComment)';
 
   COMMENT ON TABLE "CERS_EVENT_RPT_PRD"  IS 'Schema element: EventReportingPeriodDataType';
--------------------------------------------------------
--  DDL for Table CERS_EXCL_LOC_PARM
--------------------------------------------------------

  CREATE TABLE "CERS_EXCL_LOC_PARM" 
   (	"EXCL_LOC_PARM_ID" VARCHAR2(40), 
	"LOC_ID" VARCHAR2(40), 
	"LOC_TYPE_CODE" VARCHAR2(50), 
	"LOC_PARM" VARCHAR2(255), 
	"LOC_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_EXCL_LOC_PARM"."LOC_TYPE_CODE" IS 'Identifies the type of code or identifier that is being excluded. (LocationTypeCode)';
 
   COMMENT ON COLUMN "CERS_EXCL_LOC_PARM"."LOC_PARM" IS 'The code value or the identifier for the location type code. (LocationParameter)';
 
   COMMENT ON COLUMN "CERS_EXCL_LOC_PARM"."LOC_CMNT" IS 'Any comments regarding the location. (LocationComment)';
 
   COMMENT ON TABLE "CERS_EXCL_LOC_PARM"  IS 'Schema element: ExcludedLocationParameterDataType';
--------------------------------------------------------
--  DDL for Table CERS_FAC_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_FAC_IDEN" 
   (	"FAC_IDEN_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"FAC_SITE_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"STA_AND_CNTY_FIPS_CODE" VARCHAR2(50), 
	"TRIB_CODE" VARCHAR2(50), 
	"STA_AND_CTRY_FIPS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_FAC_IDEN"."FAC_SITE_IDEN" IS 'An identifier by which the facility site is referred to by a system. (FacilitySiteIdentifier)';
 
   COMMENT ON COLUMN "CERS_FAC_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_FAC_IDEN"."STA_AND_CNTY_FIPS_CODE" IS 'The list is from FIPS Counties codes used for the identification of the Counties and County equivalents of the United States. (StateAndCountyFIPSCode)';
 
   COMMENT ON COLUMN "CERS_FAC_IDEN"."TRIB_CODE" IS 'The code that represents the American Indian Tribe or Alaskan Native entity. (TribalCode)';
 
   COMMENT ON COLUMN "CERS_FAC_IDEN"."STA_AND_CTRY_FIPS_CODE" IS 'The code that represents a State and Country for States in Mexico and Provinces in Canada. (StateAndCountryFIPSCode)';
 
   COMMENT ON COLUMN "CERS_FAC_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_FAC_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_FAC_IDEN"  IS 'Schema element: FacilityIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_FAC_NAICS
--------------------------------------------------------

  CREATE TABLE "CERS_FAC_NAICS" 
   (	"FAC_NAICS_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"NAICS_CODE" VARCHAR2(50), 
	"NAICS_PRI_IND" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_FAC_NAICS"."NAICS_CODE" IS 'The code that represents a subdivision of an industry that accommodates user needs in the United States. (NAICSCode)';
 
   COMMENT ON COLUMN "CERS_FAC_NAICS"."NAICS_PRI_IND" IS 'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (NAICSPrimaryIndicator)';
 
   COMMENT ON TABLE "CERS_FAC_NAICS"  IS 'Schema element: FacilityNAICSDataType';
--------------------------------------------------------
--  DDL for Table CERS_FAC_SITE
--------------------------------------------------------

  CREATE TABLE "CERS_FAC_SITE" 
   (	"FAC_SITE_ID" VARCHAR2(40), 
	"CERS_ID" VARCHAR2(40), 
	"FAC_CATG_CODE" VARCHAR2(50), 
	"FAC_SITE_NAME" VARCHAR2(128), 
	"FAC_SITE_DESC" VARCHAR2(255), 
	"FAC_SITE_STAT_CODE" VARCHAR2(50), 
	"FAC_SITE_STAT_CODE_YEAR" NUMBER(10,0), 
	"SECT_TYPE_CODE" VARCHAR2(50), 
	"AGN_NAME" VARCHAR2(128), 
	"FAC_SITE_CMNT" VARCHAR2(255), 
	"LAT_MEAS" VARCHAR2(255), 
	"LONG_MEAS" VARCHAR2(255), 
	"SRC_MAP_SCALE_NUM" VARCHAR2(20), 
	"HORZ_ACC_MEAS" VARCHAR2(255), 
	"HORZ_ACC_UNT_MEAS" VARCHAR2(255), 
	"HORZ_COLL_METH_CODE" VARCHAR2(50), 
	"HORZ_REF_DATUM_CODE" VARCHAR2(50), 
	"GEO_REF_PT_CODE" VARCHAR2(50), 
	"DATA_COLL_DATE" TIMESTAMP (6), 
	"GEO_CMNT" VARCHAR2(255), 
	"VERT_MEAS" VARCHAR2(255), 
	"VERT_UNT_MEAS_CODE" VARCHAR2(50), 
	"VERT_COLL_METH_CODE" VARCHAR2(50), 
	"VERT_REF_DATUM_CODE" VARCHAR2(50), 
	"VERF_METH_CODE" VARCHAR2(50), 
	"COORD_DATA_SRC_CODE" VARCHAR2(50), 
	"GEOM_TYPE_CODE" VARCHAR2(50), 
	"AREA_WTIN_PERM" VARCHAR2(255), 
	"AREA_WTIN_PERM_UNT_MEAS_CODE" VARCHAR2(50), 
	"PCNT_AREA_PROD_EMIS" NUMBER(12,6), 
	"ATCH_FILE_CONT" BLOB, 
	"ATCH_FILE_NAME" VARCHAR2(128), 
	"ATCH_FILE_DESC" VARCHAR2(255), 
	"ATCH_FILE_SIZE" VARCHAR2(255), 
	"ATCH_FILE_CONT_TYPE_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_FAC_SITE"."FAC_CATG_CODE" IS 'Code that identifies the Clean Air Act Stationary Source designation.  Examples include major, minor, and synthetic minor. (FacilityCategoryCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."FAC_SITE_NAME" IS 'The name assigned to the facility site by the reporter. (FacilitySiteName)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."FAC_SITE_DESC" IS 'Supplemental text that describes the facility site. (FacilitySiteDescription)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."FAC_SITE_STAT_CODE" IS 'Code that identifies the operating status of the facility site. (FacilitySiteStatusCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."FAC_SITE_STAT_CODE_YEAR" IS 'The year in which the operating status became applicable. (FacilitySiteStatusCodeYear)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."SECT_TYPE_CODE" IS 'The associated primary sector for a facility site.  Examples include:  General Stationary Combustion, Energy Production, Cement Production, Waste Water Treatment, etc. (SectorTypeCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."AGN_NAME" IS 'The name of the regulatory state or region where the facility is located in. (AgencyName)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."FAC_SITE_CMNT" IS 'Any comments regarding the facility site. (FacilitySiteComment)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."LAT_MEAS" IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."LONG_MEAS" IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."HORZ_ACC_MEAS" IS 'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."HORZ_ACC_UNT_MEAS" IS 'The horizonal accuracy unit of measure. (HorizontalAccuracyUnitofMeasure)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."HORZ_COLL_METH_CODE" IS 'The code that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."HORZ_REF_DATUM_CODE" IS 'The code that represents the reference datum used in determining latitude and longitude coordinates. (HorizontalReferenceDatumCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."GEO_REF_PT_CODE" IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."DATA_COLL_DATE" IS 'The calendar date when data were collected. (DataCollectionDate)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."GEO_CMNT" IS 'The text that provides additional information about the geographic coordinates. (GeographicComment)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."VERT_MEAS" IS 'The measure of elevation (i.e., the altitude), above or below a reference datum. (VerticalMeasure)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."VERT_UNT_MEAS_CODE" IS 'The vertical unit of measure. (VerticalUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."VERT_COLL_METH_CODE" IS 'The code that identifies the method used to collect the vertical measure (i.e., the altitude) of a reference point. (VerticalCollectionMethodCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."VERT_REF_DATUM_CODE" IS 'The code that represents the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalReferenceDatumCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."VERF_METH_CODE" IS 'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."COORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."GEOM_TYPE_CODE" IS 'The code that represents the geometric entity represented by one point or a sequence of latitude and longitude points. (GeometricTypeCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."AREA_WTIN_PERM" IS 'Total area that is contained within the event perimeter for the reporting period. (AreaWithinPerimeter)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."AREA_WTIN_PERM_UNT_MEAS_CODE" IS 'Code that identifies the unit of measure for the area within the event perimeter. (AreaWithinPerimeterUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."PCNT_AREA_PROD_EMIS" IS 'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."ATCH_FILE_CONT" IS 'The data content of a file. (AttachmentFileContent)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."ATCH_FILE_NAME" IS 'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."ATCH_FILE_DESC" IS 'Description of file. (AttachmentFileDescription)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."ATCH_FILE_SIZE" IS 'The size of the attached file. (AttachmentFileSize)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE"."ATCH_FILE_CONT_TYPE_CODE" IS 'A code describing the content type of a file. (AttachmentFileContentTypeCode)';
 
   COMMENT ON TABLE "CERS_FAC_SITE"  IS 'Schema element: FacilitySiteDataType';
--------------------------------------------------------
--  DDL for Table CERS_FAC_SITE_ADDR
--------------------------------------------------------

  CREATE TABLE "CERS_FAC_SITE_ADDR" 
   (	"FAC_SITE_ADDR_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"MAIL_ADDR_TXT" VARCHAR2(255), 
	"SUPP_ADDR_TXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CNTY_TXT" VARCHAR2(255), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_POST_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"LOC_ADDR_TXT" VARCHAR2(255), 
	"SUPP_LOC_TXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"LOC_ADDR_STA_CODE" VARCHAR2(50), 
	"LOC_ADDR_POST_CODE" VARCHAR2(50), 
	"LOC_ADDR_CTRY_CODE" VARCHAR2(50), 
	"ADDR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."MAIL_ADDR_TXT" IS 'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."SUPP_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."MAIL_ADDR_CITY_NAME" IS 'The name of the city or town. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."MAIL_ADDR_CNTY_TXT" IS 'The name of the county. (MailingAddressCountyText)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."MAIL_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."MAIL_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."LOC_ADDR_TXT" IS 'The physical location of a facility site or organization. (LocationAddressText)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."SUPP_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."LOCA_NAME" IS 'The name of the city, town, village, or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."LOC_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."LOC_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."LOC_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_ADDR"."ADDR_CMNT" IS 'Any comments regarding the address information. (AddressComment)';
 
   COMMENT ON TABLE "CERS_FAC_SITE_ADDR"  IS 'Schema element: FacilitySiteAddressDataType';
--------------------------------------------------------
--  DDL for Table CERS_FAC_SITE_QLTY_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_FAC_SITE_QLTY_IDEN" 
   (	"FAC_SITE_QLTY_IDEN_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"QLTY_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_FAC_SITE_QLTY_IDEN"."QLTY_IDEN" IS 'An identifier for the quality finding. (QualityIdentifier)';
 
   COMMENT ON COLUMN "CERS_FAC_SITE_QLTY_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON TABLE "CERS_FAC_SITE_QLTY_IDEN"  IS 'Schema element: FacilitySiteQualityIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_GEOSPATIAL_PARAMS
--------------------------------------------------------

  CREATE TABLE "CERS_GEOSPATIAL_PARAMS" 
   (	"GEOSPATIAL_PARAMS_ID" VARCHAR2(40), 
	"EVENT_LOC_ID" VARCHAR2(40), 
	"SHAPE_FILE_IDEN" VARCHAR2(50), 
	"AREA_WTIN_SHAPE" VARCHAR2(255), 
	"AREA_WTIN_SHAPE_UNT_MEAS_CODE" VARCHAR2(50), 
	"PCNT_AREA_PROD_EMIS" NUMBER(12,6), 
	"GEOSPATIAL_PARAMS_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_GEOSPATIAL_PARAMS"."SHAPE_FILE_IDEN" IS 'An identifier provided by the reporting agency that identifies the geospatial shape file for the reported emissions. (ShapeFileIdentifier)';
 
   COMMENT ON COLUMN "CERS_GEOSPATIAL_PARAMS"."AREA_WTIN_SHAPE" IS 'Total area that is contained within the event shape for the reporting period. (AreaWithinShape)';
 
   COMMENT ON COLUMN "CERS_GEOSPATIAL_PARAMS"."AREA_WTIN_SHAPE_UNT_MEAS_CODE" IS 'Code that identifies the unit of measure for the area within the shape file. (AreaWithinShapeUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_GEOSPATIAL_PARAMS"."PCNT_AREA_PROD_EMIS" IS 'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)';
 
   COMMENT ON COLUMN "CERS_GEOSPATIAL_PARAMS"."GEOSPATIAL_PARAMS_CMNT" IS 'Any comments regarding the geospatial parameters. (GeospatialParametersComment)';
 
   COMMENT ON TABLE "CERS_GEOSPATIAL_PARAMS"  IS 'Schema element: GeospatialParametersDataType';
--------------------------------------------------------
--  DDL for Table CERS_LC_PRC_CTRL_APCH_CTRL_MS
--------------------------------------------------------

  CREATE TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS" 
   (	"LC_PRC_CTRL_APCH_CTRL_MS_ID" VARCHAR2(40), 
	"LOC_PROC_ID" VARCHAR2(40), 
	"CTRL_MEAS_CODE" VARCHAR2(50), 
	"CTRL_MEAS_SEQ" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_LC_PRC_CTRL_APCH_CTRL_MS"."CTRL_MEAS_CODE" IS 'Code that identifies the piece of equipment or practice that is used to reduce one or more pollutants. (ControlMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_CTRL_APCH_CTRL_MS"."CTRL_MEAS_SEQ" IS 'The sequnce in which the pollutant stream passes through the various devices in the control group. (ControlMeasureSequence)';
 
   COMMENT ON TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS"  IS 'Schema element: LocationProcessControlApproachControlMeasureDataType';
--------------------------------------------------------
--  DDL for Table CERS_LC_PRC_CTRL_APCH_CTRL_PLT
--------------------------------------------------------

  CREATE TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" 
   (	"LC_PRC_CTRL_APCH_CTRL_PLT_ID" VARCHAR2(40), 
	"LOC_PROC_ID" VARCHAR2(40), 
	"POLT_CODE" VARCHAR2(50), 
	"PCNT_CTRL_MEAS_REDC_EFCY" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_LC_PRC_CTRL_APCH_CTRL_PLT"."POLT_CODE" IS 'Code identifying the pollutant for which emissions are reported. (PollutantCode)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_CTRL_APCH_CTRL_PLT"."PCNT_CTRL_MEAS_REDC_EFCY" IS 'The percent reduction achieved for the pollutant when all control measures are operating as designed. (PercentControlMeasuresReductionEfficiency)';
 
   COMMENT ON TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT"  IS 'Schema element: LocationProcessControlApproachControlPollutantDataType';
--------------------------------------------------------
--  DDL for Table CERS_LC_PRC_RPT_PRD_QLTY_IDN
--------------------------------------------------------

  CREATE TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" 
   (	"LOC_PROC_RPT_PRD_QLTY_IDEN_ID" VARCHAR2(40), 
	"LOC_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"QLTY_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_QLTY_IDN"."QLTY_IDEN" IS 'An identifier for the quality finding. (QualityIdentifier)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_QLTY_IDN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN"  IS 'Schema element: LocationProcessReportingPeriodQualityIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_LC_PRC_RPT_PRD_SPP_CLC_PR
--------------------------------------------------------

  CREATE TABLE "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" 
   (	"LC_PRC_RPT_PRD_SPP_CLC_PRM_ID" VARCHAR2(40), 
	"LOC_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"SUPP_CALC_PARM_TYPE" VARCHAR2(255), 
	"SUPP_CALC_PARM_VAL" VARCHAR2(50), 
	"SPP_CLC_PRM_NM_UNT_MS_CDE" VARCHAR2(50), 
	"SPP_CLC_PRM_DN_UNT_MS_CDE" VARCHAR2(50), 
	"SUPP_CALC_PARM_DATA_YEAR" NUMBER(10,0), 
	"SUPP_CALC_PARM_DATA_SRC" VARCHAR2(255), 
	"SUPP_CALC_PARM_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SUPP_CALC_PARM_TYPE" IS 'Name of the parameter that describes the type of activity, throughput or input used in the calculation. (SupplementalCalculationParameterType)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SUPP_CALC_PARM_VAL" IS 'The value of the parameter. (SupplementalCalculationParameterValue)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SPP_CLC_PRM_NM_UNT_MS_CDE" IS 'The numerator unit of measure for the parameter. (SupplementalCalculationParameterNumeratorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SPP_CLC_PRM_DN_UNT_MS_CDE" IS 'The denominator unit of measure for the parameter. (SupplementalCalculationParameterDenominatorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SUPP_CALC_PARM_DATA_YEAR" IS 'The year represented by the supplemental data if it is different from the emissions year. (SupplementalCalculationParameterDataYear)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SUPP_CALC_PARM_DATA_SRC" IS 'The source of the supplemental parameter data used. (SupplementalCalculationParameterDataSource)';
 
   COMMENT ON COLUMN "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"."SUPP_CALC_PARM_CMNT" IS 'Any comments regarding the parameter. (SupplementalCalculationParameterComment)';
 
   COMMENT ON TABLE "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR"  IS 'Schema element: LocationProcessReportingPeriodSupplementalCalculationParameterDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC
--------------------------------------------------------

  CREATE TABLE "CERS_LOC" 
   (	"LOC_ID" VARCHAR2(40), 
	"CERS_ID" VARCHAR2(40), 
	"STA_AND_CNTY_FIPS_CODE" VARCHAR2(50), 
	"TRIB_CODE" VARCHAR2(50), 
	"STA_AND_CTRY_FIPS_CODE" VARCHAR2(50), 
	"CENSUS_BLOCK_IDEN" VARCHAR2(50), 
	"CENSUS_TRACT_IDEN" VARCHAR2(50), 
	"SHAPE_IDEN" VARCHAR2(50), 
	"LOC_CMNT" VARCHAR2(255), 
	"ATCH_FILE_CONT" BLOB, 
	"ATCH_FILE_NAME" VARCHAR2(128), 
	"ATCH_FILE_DESC" VARCHAR2(255), 
	"ATCH_FILE_SIZE" VARCHAR2(255), 
	"ATCH_FILE_CONT_TYPE_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC"."STA_AND_CNTY_FIPS_CODE" IS 'The list is from FIPS Counties codes used for the identification of the Counties and County equivalents of the United States. (StateAndCountyFIPSCode)';
 
   COMMENT ON COLUMN "CERS_LOC"."TRIB_CODE" IS 'The code that represents the American Indian Tribe or Alaskan Native entity. (TribalCode)';
 
   COMMENT ON COLUMN "CERS_LOC"."STA_AND_CTRY_FIPS_CODE" IS 'The code that represents a State and Country for States in Mexico and Provinces in Canada. (StateAndCountryFIPSCode)';
 
   COMMENT ON COLUMN "CERS_LOC"."CENSUS_BLOCK_IDEN" IS 'The identifier that represents the post 1990 census block, which is the smallest geographic entity recognized by the census. (CensusBlockIdentifier)';
 
   COMMENT ON COLUMN "CERS_LOC"."CENSUS_TRACT_IDEN" IS 'The identifier that represents the post 1990 census tract, which is ideally a neighborhood within a city. (CensusTractIdentifier)';
 
   COMMENT ON COLUMN "CERS_LOC"."SHAPE_IDEN" IS 'The shape file identifier issued by EPA for a predefined geospatial shape. (ShapeIdentifier)';
 
   COMMENT ON COLUMN "CERS_LOC"."LOC_CMNT" IS 'Any comments regarding the location. (LocationComment)';
 
   COMMENT ON COLUMN "CERS_LOC"."ATCH_FILE_CONT" IS 'The data content of a file. (AttachmentFileContent)';
 
   COMMENT ON COLUMN "CERS_LOC"."ATCH_FILE_NAME" IS 'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)';
 
   COMMENT ON COLUMN "CERS_LOC"."ATCH_FILE_DESC" IS 'Description of file. (AttachmentFileDescription)';
 
   COMMENT ON COLUMN "CERS_LOC"."ATCH_FILE_SIZE" IS 'The size of the attached file. (AttachmentFileSize)';
 
   COMMENT ON COLUMN "CERS_LOC"."ATCH_FILE_CONT_TYPE_CODE" IS 'A code describing the content type of a file. (AttachmentFileContentTypeCode)';
 
   COMMENT ON TABLE "CERS_LOC"  IS 'Schema element: LocationDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC" 
   (	"LOC_PROC_ID" VARCHAR2(40), 
	"LOC_ID" VARCHAR2(40), 
	"SRC_CLASS_CODE" VARCHAR2(50), 
	"EMIS_TYPE_CODE" VARCHAR2(50), 
	"AIRCRAFT_ENGINE_TYPE_CODE" VARCHAR2(50), 
	"PROC_TYPE_CODE" VARCHAR2(50), 
	"PROC_DESC" VARCHAR2(255), 
	"LAST_EMIS_YEAR" NUMBER(10,0), 
	"PROC_CMNT" VARCHAR2(255), 
	"CTRL_APCH_DESC" VARCHAR2(255), 
	"PCNT_CTRL_APCH_CAP_EFCY" NUMBER(12,6), 
	"PCNT_CTRL_APCH_EFCT" NUMBER(12,6), 
	"PCNT_CTRL_APCH_PEN" NUMBER(12,6), 
	"FIRST_INVEN_YEAR" NUMBER(10,0), 
	"LAST_INVEN_YEAR" NUMBER(10,0), 
	"CTRL_APCH_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC"."SRC_CLASS_CODE" IS 'EPA Source Classification Code that identifies an emissions process. (SourceClassificationCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."EMIS_TYPE_CODE" IS 'Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mobile sources only. Examples include exhaust, evaporative and tire wear. (EmissionsTypeCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."AIRCRAFT_ENGINE_TYPE_CODE" IS 'Identifies the combination of aircraft and engine type for airport emissions. (AircraftEngineTypeCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."PROC_TYPE_CODE" IS 'Defines the type of emissions produced by GHG processes. Examples included for a Scope 1 Stationary Combustion might be oil, gas, coal. (ProcessTypeCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."PROC_DESC" IS 'A text description of the emissions process. (ProcessDescription)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."LAST_EMIS_YEAR" IS 'The last year in which emissions occurred for this process. (LastEmissionsYear)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."PROC_CMNT" IS 'Any comments regarding the emissions process. (ProcessComment)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."CTRL_APCH_DESC" IS 'Description of the overall control system or approach applied to an emissions unit or process. (ControlApproachDescription)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."PCNT_CTRL_APCH_CAP_EFCY" IS 'An estimate of that portion of an affected emission stream that is collected and routed to the control measures when the capture or collection system is operating as designed, reported as a percent. (PercentControlApproachCaptureEfficiency)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."PCNT_CTRL_APCH_EFCT" IS 'An estimate of the portion of the reporting period''s activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary). (PercentControlApproachEffectiveness)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."PCNT_CTRL_APCH_PEN" IS 'An estimate of the percent value of the nonpoint activity throughput that is affected by a rule or voluntary approach for the given location.  (Nonpoint only.) (PercentControlApproachPenetration)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."FIRST_INVEN_YEAR" IS 'The inventory year for which the controls were implemented.  (Point only.) (FirstInventoryYear)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."LAST_INVEN_YEAR" IS 'The last inventory year for which the controls were active.  (Point only.) (LastInventoryYear)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC"."CTRL_APCH_CMNT" IS 'Comments regarding the control approach. (ControlApproachComment)';
 
   COMMENT ON TABLE "CERS_LOC_PROC"  IS 'Schema element: LocationProcessDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC_IDEN" 
   (	"LOC_PROC_IDEN_ID" VARCHAR2(40), 
	"LOC_PROC_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_LOC_PROC_IDEN"  IS 'Schema element: LocationProcessIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC_REL_PT_APPR
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC_REL_PT_APPR" 
   (	"LOC_PROC_REL_PT_APPR_ID" VARCHAR2(40), 
	"LOC_PROC_ID" VARCHAR2(40), 
	"AVE_PCNT_EMIS" NUMBER(12,6), 
	"REL_PT_APPR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC_REL_PT_APPR"."AVE_PCNT_EMIS" IS 'The average annual percent of an emissions process that is vented through a release point. (AveragePercentEmissions)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_REL_PT_APPR"."REL_PT_APPR_CMNT" IS 'Comment regarding the average apportionment of emissions vented through a release point. (ReleasePointApportionmentComment)';
 
   COMMENT ON TABLE "CERS_LOC_PROC_REL_PT_APPR"  IS 'Schema element: LocationProcessReleasePointApportionmentDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC_REL_PT_APPR_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" 
   (	"LOC_PROC_REL_PT_APPR_IDEN_ID" VARCHAR2(40), 
	"LOC_PROC_REL_PT_APPR_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC_REL_PT_APPR_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_REL_PT_APPR_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_REL_PT_APPR_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_REL_PT_APPR_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN"  IS 'Schema element: LocationProcessReleasePointApportionmentIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC_RGLN
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC_RGLN" 
   (	"LOC_PROC_RGLN_ID" VARCHAR2(40), 
	"LOC_PROC_ID" VARCHAR2(40), 
	"RGTRY_CODE" VARCHAR2(50), 
	"AGN_CODE_TXT" VARCHAR2(255), 
	"RGTRY_START_YEAR" NUMBER(10,0), 
	"RGTRY_END_YEAR" NUMBER(10,0), 
	"RGLN_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC_RGLN"."RGTRY_CODE" IS 'The code that describes the regulation applicable to the emissions unit activity or process. (RegulatoryCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RGLN"."AGN_CODE_TXT" IS 'Text describing the non-federal regulation applicable to the emissions unit or process. (AgencyCodeText)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RGLN"."RGTRY_START_YEAR" IS 'The year in which the enissions unit or process became subject to the regulation. (RegulatoryStartYear)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RGLN"."RGTRY_END_YEAR" IS 'The year in which the enissions unit or process was no longer effected by the regulation. (RegulatoryEndYear)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RGLN"."RGLN_CMNT" IS 'Comments regarding the regulation. (RegulationComment)';
 
   COMMENT ON TABLE "CERS_LOC_PROC_RGLN"  IS 'Schema element: LocationProcessRegulationDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC_RPT_PRD
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC_RPT_PRD" 
   (	"LOC_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"LOC_PROC_ID" VARCHAR2(40), 
	"RPT_PRD_TYPE_CODE" VARCHAR2(50), 
	"EMIS_OPER_TYPE_CODE" VARCHAR2(50), 
	"START_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6), 
	"CALC_PARM_TYPE_CODE" VARCHAR2(50), 
	"CALC_PARM_VAL" VARCHAR2(50), 
	"CALC_PARM_UNT_MEAS" VARCHAR2(255), 
	"CALC_MATERIAL_CODE" VARCHAR2(50), 
	"CALC_DATA_YEAR" NUMBER(10,0), 
	"CALC_DATA_SRC" VARCHAR2(255), 
	"RPT_PRD_CMNT" VARCHAR2(255), 
	"ACTL_HOURS_PER_PRD" VARCHAR2(255), 
	"AVE_DAYS_PER_WEEK" VARCHAR2(255), 
	"AVE_HOURS_PER_DAY" VARCHAR2(255), 
	"AVE_WEEKS_PER_PRD" VARCHAR2(255), 
	"PCNT_WINTER_ACT" NUMBER(12,6), 
	"PCNT_SPRING_ACT" NUMBER(12,6), 
	"PCNT_SUMMER_ACT" NUMBER(12,6), 
	"PCNT_FALL_ACT" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."RPT_PRD_TYPE_CODE" IS 'The time period type for which emissions are reported. (ReportingPeriodTypeCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."EMIS_OPER_TYPE_CODE" IS 'Code identifying the operating state for the emissions being reported. (EmissionOperatingTypeCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."START_DATE" IS 'The date on which the reporting period began.  Applies to the reporting of episodic or event emissions only. (StartDate)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."CALC_PARM_TYPE_CODE" IS 'Code indicating whether the material measured is an input to the process, an output of the process or a static count (not a throughput).  (CalculationParameterTypeCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."CALC_PARM_VAL" IS 'Activity or throughput of the process for a given time period. (CalculationParameterValue)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."CALC_PARM_UNT_MEAS" IS 'Code for the unit of measure for calculation parameter value. (CalculationParameterUnitofMeasure)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."CALC_MATERIAL_CODE" IS 'Code for material or fuel processed. (CalculationMaterialCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."CALC_DATA_YEAR" IS 'The actual year represented by the data if it is different from the emissions year. (CalculationDataYear)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."CALC_DATA_SRC" IS 'The source of the data used. (CalculationDataSource)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."RPT_PRD_CMNT" IS 'Any comments regarding the reporting period. (ReportingPeriodComment)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."ACTL_HOURS_PER_PRD" IS 'Actual number of hours the process is active or operating during for the reporting period. (ActualHoursPerPeriod)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."AVE_DAYS_PER_WEEK" IS 'The average number of days per week that the emissions process is active within the reporting period. (AverageDaysPerWeek)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."AVE_HOURS_PER_DAY" IS 'The average number of hours per day that the emissions process is active within the reporting period. (AverageHoursPerDay)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."AVE_WEEKS_PER_PRD" IS 'The average number of weeks that the emissions process is active within the reporting period. (AverageWeeksPerPeriod)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."PCNT_WINTER_ACT" IS 'The percentage of the annual activity that occurred during the Winter months (December, January, February). (PercentWinterActivity)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."PCNT_SPRING_ACT" IS 'The percentage of the annual activity that occurred during the Spring months (March, April, May). (PercentSpringActivity)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."PCNT_SUMMER_ACT" IS 'The percentage of the annual activity that occurred during the Summer months (June, July, August). (PercentSummerActivity)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD"."PCNT_FALL_ACT" IS 'The percentage of the annual activity that occurred during the Fall months (September, October, November). (PercentFallActivity)';
 
   COMMENT ON TABLE "CERS_LOC_PROC_RPT_PRD"  IS 'Schema element: LocationProcessReportingPeriodDataType';
--------------------------------------------------------
--  DDL for Table CERS_LOC_PROC_RPT_PRD_EMIS
--------------------------------------------------------

  CREATE TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" 
   (	"LOC_PROC_RPT_PRD_EMIS_ID" VARCHAR2(40), 
	"LOC_PROC_RPT_PRD_ID" VARCHAR2(40), 
	"POLT_CODE" VARCHAR2(50), 
	"TOTAL_EMIS" VARCHAR2(255), 
	"EMIS_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC" VARCHAR2(255), 
	"EMIS_FAC_NUM_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC_DEN_UNT_MEAS_CODE" VARCHAR2(50), 
	"EMIS_FAC_FORM_CODE" VARCHAR2(50), 
	"EMIS_FAC_TXT" VARCHAR2(255), 
	"EMIS_CALC_METH_CODE" VARCHAR2(50), 
	"EMIS_FAC_REF_TXT" VARCHAR2(255), 
	"ALGOR_FORM_TXT" VARCHAR2(255), 
	"ALGOR_CMNT" VARCHAR2(255), 
	"CALC_METH_ACC_ASMT_CODE" VARCHAR2(50), 
	"EMIS_DE_MINIMIS_STAT" VARCHAR2(255), 
	"EMIS_CMNT" VARCHAR2(255), 
	"CO_2E" VARCHAR2(255), 
	"CO_2E_UNT_MEAS_CODE" VARCHAR2(50), 
	"CO_2_CONV_FAC" VARCHAR2(255), 
	"CO_2_CONV_FAC_SRC" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."POLT_CODE" IS 'Code identifying the pollutant for which emissions are reported. (PollutantCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."TOTAL_EMIS" IS 'Total calculated or estimated amount of the pollutant. (TotalEmissions)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_UNT_MEAS_CODE" IS 'Unit of measure for reported emissions. (EmissionsUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_FAC" IS 'The emission factor used for the emissions value if a calculated value was provided. (EmissionFactor)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_FAC_NUM_UNT_MEAS_CODE" IS 'The numerator for the unit of measure of the reported emission factor. (EmissionFactorNumeratorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_FAC_DEN_UNT_MEAS_CODE" IS 'The denominator for the unit of measure of the reported emission factor. (EmissionFactorDenominatorUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_FAC_FORM_CODE" IS 'Code that identifies the emission factor formula used to calculate emissions. (EmissionFactorFormulaCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_FAC_TXT" IS 'Explanation for emission factor. (EmissionFactorText)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_CALC_METH_CODE" IS 'Code that defines the method used to calculate emissions. (EmissionCalculationMethodCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_FAC_REF_TXT" IS 'Reference given for the emission factor used in the calculation. (EmissionFactorReferenceText)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."ALGOR_FORM_TXT" IS 'The formula used to calculate emissions. (AlgorithmFormulaText)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."ALGOR_CMNT" IS 'Information about the algorithm, including units of measure, for the calculation method. (AlgorithmComment)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."CALC_METH_ACC_ASMT_CODE" IS 'The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C, CARB, Part 75, etc.  (CalculationMethodAccuracyAssessmentCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_DE_MINIMIS_STAT" IS 'Status indicating if emissions are de minimis. (EmissionsDeMinimisStatus)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."EMIS_CMNT" IS 'Any comments regarding the emissions, method of calculation, or emission factor. (EmissionsComment)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."CO_2E" IS 'The total CO2 equivalent emissions. (CO2e)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."CO_2E_UNT_MEAS_CODE" IS 'The unit of measure for the CO2 equivalent emissions. (CO2eUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."CO_2_CONV_FAC" IS 'Global warming potential (GWP) used to calculate CO2e. (CO2ConversionFactor)';
 
   COMMENT ON COLUMN "CERS_LOC_PROC_RPT_PRD_EMIS"."CO_2_CONV_FAC_SRC" IS 'The source of reference for the GWP value. (CO2ConversionFactorSource)';
 
   COMMENT ON TABLE "CERS_LOC_PROC_RPT_PRD_EMIS"  IS 'Schema element: LocationProcessReportingPeriodEmissionsDataType';
--------------------------------------------------------
--  DDL for Table CERS_MERGED_EVENTS
--------------------------------------------------------

  CREATE TABLE "CERS_MERGED_EVENTS" 
   (	"MERGED_EVENTS_ID" VARCHAR2(40), 
	"EVENT_ID" VARCHAR2(40), 
	"EVENT_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"MERGED_DATE" TIMESTAMP (6), 
	"MERGED_EVENTS_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_MERGED_EVENTS"."EVENT_IDEN" IS 'An identifier provided by the land or event manager that identifies an event.  This identifier is unique for each event. (EventIdentifier)';
 
   COMMENT ON COLUMN "CERS_MERGED_EVENTS"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_MERGED_EVENTS"."MERGED_DATE" IS 'The first data that the discrete event is reported with the complex event. (MergedDate)';
 
   COMMENT ON COLUMN "CERS_MERGED_EVENTS"."MERGED_EVENTS_CMNT" IS 'Any comments regarding the merged event. (MergedEventsComment)';
 
   COMMENT ON TABLE "CERS_MERGED_EVENTS"  IS 'Schema element: MergedEventsDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND" 
   (	"QLTY_FIND_ID" VARCHAR2(40), 
	"CERS_ID" VARCHAR2(40), 
	"QLTY_IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"QLTY_VERF_TYPE" VARCHAR2(255), 
	"QLTY_TYPE_CODE" VARCHAR2(50), 
	"QLTY_EXCPT" VARCHAR2(255), 
	"QLTY_STAT_CODE" VARCHAR2(50), 
	"QLTY_LEVELOF_ASSURANCE_CODE" VARCHAR2(50), 
	"QLTY_STANDARDS_SRC" VARCHAR2(255), 
	"QLTY_DETERMINATION_DATE" TIMESTAMP (6), 
	"ATCH_FILE_CONT" BLOB, 
	"ATCH_FILE_NAME" VARCHAR2(128), 
	"ATCH_FILE_DESC" VARCHAR2(255), 
	"ATCH_FILE_SIZE" VARCHAR2(255), 
	"ATCH_FILE_CONT_TYPE_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_IDEN" IS 'An identifier for the quality finding. (QualityIdentifier)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_VERF_TYPE" IS 'Identifies the type of verification, such as entity inventory or emissions reduction project.  (QualityVerificationType)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_TYPE_CODE" IS 'The nature of the verification report issued. Examples include: adverse or qualified. (QualityTypeCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_EXCPT" IS 'Any exceptions that the verifier has reported. (QualityExceptions)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_STAT_CODE" IS 'The quality or verification status of the facility site, emissions unit or emissions. Examples include:  verified or unverified. (QualityStatusCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_LEVELOF_ASSURANCE_CODE" IS 'The degree of assurance the intended user required in the verification findings.  Examples include:  reasonable and limited. (QualityLevelofAssuranceCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_STANDARDS_SRC" IS 'The source of the standard such as ISO 14064-3, TCR GVP, CCAR GVP, etc. (QualityStandardsSource)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."QLTY_DETERMINATION_DATE" IS 'Date on which status was determined. (QualityDeterminationDate)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."ATCH_FILE_CONT" IS 'The data content of a file. (AttachmentFileContent)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."ATCH_FILE_NAME" IS 'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."ATCH_FILE_DESC" IS 'Description of file. (AttachmentFileDescription)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."ATCH_FILE_SIZE" IS 'The size of the attached file. (AttachmentFileSize)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND"."ATCH_FILE_CONT_TYPE_CODE" IS 'A code describing the content type of a file. (AttachmentFileContentTypeCode)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND"  IS 'Schema element: QualityFindingDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG" 
   (	"QLTY_FIND_ORG_ID" VARCHAR2(40), 
	"QLTY_FIND_ID" VARCHAR2(40), 
	"ORG_FORMAL_NAME" VARCHAR2(128), 
	"PCNT_OWNER" NUMBER(12,6), 
	"CONS_METH" VARCHAR2(255), 
	"ATCH_FILE_CONT" BLOB, 
	"ATCH_FILE_NAME" VARCHAR2(128), 
	"ATCH_FILE_DESC" VARCHAR2(255), 
	"ATCH_FILE_SIZE" VARCHAR2(255), 
	"ATCH_FILE_CONT_TYPE_CODE" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."ORG_FORMAL_NAME" IS 'Name of the organization. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."PCNT_OWNER" IS 'Contains information on the percentage of ownership an organization has for a facility site. (PercentOwnership)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."CONS_METH" IS 'Consolidation methodology for an organization, including:  operation control, financial control, operation control and equity share, financial control and equity share, equity share. (ConsolidationMethodology)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."ATCH_FILE_CONT" IS 'The data content of a file. (AttachmentFileContent)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."ATCH_FILE_NAME" IS 'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."ATCH_FILE_DESC" IS 'Description of file. (AttachmentFileDescription)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."ATCH_FILE_SIZE" IS 'The size of the attached file. (AttachmentFileSize)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG"."ATCH_FILE_CONT_TYPE_CODE" IS 'A code describing the content type of a file. (AttachmentFileContentTypeCode)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG"  IS 'Schema element: QualityFindingOrganizationDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_ADDR
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_ADDR" 
   (	"QLTY_FIND_ORG_ADDR_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_ID" VARCHAR2(40), 
	"MAIL_ADDR_TXT" VARCHAR2(255), 
	"SUPP_ADDR_TXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CNTY_TXT" VARCHAR2(255), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_POST_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"LOC_ADDR_TXT" VARCHAR2(255), 
	"SUPP_LOC_TXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"LOC_ADDR_STA_CODE" VARCHAR2(50), 
	"LOC_ADDR_POST_CODE" VARCHAR2(50), 
	"LOC_ADDR_CTRY_CODE" VARCHAR2(50), 
	"ADDR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."MAIL_ADDR_TXT" IS 'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."SUPP_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."MAIL_ADDR_CITY_NAME" IS 'The name of the city or town. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."MAIL_ADDR_CNTY_TXT" IS 'The name of the county. (MailingAddressCountyText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."MAIL_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."MAIL_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."LOC_ADDR_TXT" IS 'The physical location of a facility site or organization. (LocationAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."SUPP_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."LOCA_NAME" IS 'The name of the city, town, village, or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."LOC_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."LOC_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."LOC_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_ADDR"."ADDR_CMNT" IS 'Any comments regarding the address information. (AddressComment)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_ADDR"  IS 'Schema element: QualityFindingOrganizationAddressDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_COMMUN
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_COMMUN" 
   (	"QLTY_FIND_ORG_COMMUN_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_ID" VARCHAR2(40), 
	"TELE_NUM_TXT" VARCHAR2(20), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(128), 
	"TELE_EXT_NUM_TXT" VARCHAR2(20), 
	"ELEC_ADDR_TXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(128)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_COMMUN"."TELE_NUM_TXT" IS 'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_COMMUN"."TELE_NUM_TYPE_NAME" IS 'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_COMMUN"."TELE_EXT_NUM_TXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_COMMUN"."ELEC_ADDR_TXT" IS 'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_COMMUN"."ELEC_ADDR_TYPE_NAME" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_COMMUN"  IS 'Schema element: QualityFindingOrganizationCommunicationDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_IDEN" 
   (	"QLTY_FIND_ORG_IDEN_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_IDEN"  IS 'Schema element: QualityFindingOrganizationIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_INDV
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_INDV" 
   (	"QLTY_FIND_ORG_INDV_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_ID" VARCHAR2(40), 
	"INDV_TITLE_TXT" VARCHAR2(255), 
	"NAME_PREFIX_TXT" VARCHAR2(255), 
	"FIRST_NAME" VARCHAR2(128), 
	"MIDDLE_NAME" VARCHAR2(128), 
	"LAST_NAME" VARCHAR2(128), 
	"NAME_SUFFIX_TXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV"."INDV_TITLE_TXT" IS 'The title held by a person in an organization. (IndividualTitleText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV"."NAME_PREFIX_TXT" IS 'The text that precedes an individual''s name. (NamePrefixText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV"."FIRST_NAME" IS 'The given name of an individual. (FirstName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV"."MIDDLE_NAME" IS 'The middle name or initial of an individual. (MiddleName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV"."LAST_NAME" IS 'The surname of an individual. (LastName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV"."NAME_SUFFIX_TXT" IS 'the text that follows an individuals name. (NameSuffixText)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_INDV"  IS 'Schema element: QualityFindingOrganizationIndividualDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_INDV_ADDR
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_INDV_ADDR" 
   (	"QLTY_FIND_ORG_INDV_ADDR_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_INDV_ID" VARCHAR2(40), 
	"MAIL_ADDR_TXT" VARCHAR2(255), 
	"SUPP_ADDR_TXT" VARCHAR2(255), 
	"MAIL_ADDR_CITY_NAME" VARCHAR2(128), 
	"MAIL_ADDR_CNTY_TXT" VARCHAR2(255), 
	"MAIL_ADDR_STA_CODE" VARCHAR2(50), 
	"MAIL_ADDR_POST_CODE" VARCHAR2(50), 
	"MAIL_ADDR_CTRY_CODE" VARCHAR2(50), 
	"LOC_ADDR_TXT" VARCHAR2(255), 
	"SUPP_LOC_TXT" VARCHAR2(255), 
	"LOCA_NAME" VARCHAR2(128), 
	"LOC_ADDR_STA_CODE" VARCHAR2(50), 
	"LOC_ADDR_POST_CODE" VARCHAR2(50), 
	"LOC_ADDR_CTRY_CODE" VARCHAR2(50), 
	"ADDR_CMNT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."MAIL_ADDR_TXT" IS 'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."SUPP_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."MAIL_ADDR_CITY_NAME" IS 'The name of the city or town. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."MAIL_ADDR_CNTY_TXT" IS 'The name of the county. (MailingAddressCountyText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."MAIL_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."MAIL_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."MAIL_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."LOC_ADDR_TXT" IS 'The physical location of a facility site or organization. (LocationAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."SUPP_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."LOCA_NAME" IS 'The name of the city, town, village, or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."LOC_ADDR_STA_CODE" IS 'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."LOC_ADDR_POST_CODE" IS 'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."LOC_ADDR_CTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_ADDR"."ADDR_CMNT" IS 'Any comments regarding the address information. (AddressComment)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_INDV_ADDR"  IS 'Schema element: QualityFindingOrganizationIndividualAddressDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_INDV_COMMUN
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_INDV_COMMUN" 
   (	"QLTY_FIND_ORG_INDV_COMMUN_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_INDV_ID" VARCHAR2(40), 
	"TELE_NUM_TXT" VARCHAR2(20), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(128), 
	"TELE_EXT_NUM_TXT" VARCHAR2(20), 
	"ELEC_ADDR_TXT" VARCHAR2(255), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(128)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_COMMUN"."TELE_NUM_TXT" IS 'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_COMMUN"."TELE_NUM_TYPE_NAME" IS 'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_COMMUN"."TELE_EXT_NUM_TXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_COMMUN"."ELEC_ADDR_TXT" IS 'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_COMMUN"."ELEC_ADDR_TYPE_NAME" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_INDV_COMMUN"  IS 'Schema element: QualityFindingOrganizationIndividualCommunicationDataType';
--------------------------------------------------------
--  DDL for Table CERS_QLTY_FIND_ORG_INDV_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" 
   (	"QLTY_FIND_ORG_INDV_IDEN_ID" VARCHAR2(40), 
	"QLTY_FIND_ORG_INDV_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_QLTY_FIND_ORG_INDV_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN"  IS 'Schema element: QualityFindingOrganizationIndividualIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_REL_PT
--------------------------------------------------------

  CREATE TABLE "CERS_REL_PT" 
   (	"REL_PT_ID" VARCHAR2(40), 
	"FAC_SITE_ID" VARCHAR2(40), 
	"REL_PT_TYPE_CODE" VARCHAR2(50), 
	"REL_PT_DESC" VARCHAR2(255), 
	"REL_PT_STK_HGT_MEAS" VARCHAR2(255), 
	"REL_PT_STK_HGT_UNT_MEAS_CODE" VARCHAR2(50), 
	"REL_PT_STK_DIA_MEAS" VARCHAR2(255), 
	"REL_PT_STK_DIA_UNT_MEAS_CODE" VARCHAR2(50), 
	"REL_PT_EXIT_GAS_VEL_MEAS" VARCHAR2(255), 
	"RL_PT_EXT_GS_VL_UNT_MS_CDE" VARCHAR2(50), 
	"REL_PT_EXIT_GAS_FLOW_RATE_MEAS" VARCHAR2(255), 
	"RL_PT_EXT_GS_FLW_RTE_UNT_MS_CD" VARCHAR2(50), 
	"REL_PT_EXIT_GAS_TMP_MEAS" VARCHAR2(255), 
	"REL_PT_FENCE_LINE_DIST_MEAS" VARCHAR2(255), 
	"RL_PT_FNCE_LNE_DST_UNT_MS_CDE" VARCHAR2(50), 
	"REL_PT_FGTV_HGT_MEAS" VARCHAR2(255), 
	"REL_PT_FGTV_HGT_UNT_MEAS_CODE" VARCHAR2(50), 
	"REL_PT_FGTV_WID_MEAS" VARCHAR2(255), 
	"REL_PT_FGTV_WID_UNT_MEAS_CODE" VARCHAR2(50), 
	"REL_PT_FGTV_LEN_MEAS" VARCHAR2(255), 
	"REL_PT_FGTV_LEN_UNT_MEAS_CODE" VARCHAR2(50), 
	"REL_PT_FGTV_ANGLE_MEAS" VARCHAR2(255), 
	"REL_PT_CMNT" VARCHAR2(255), 
	"REL_PT_STAT_CODE" VARCHAR2(50), 
	"REL_PT_STAT_CODE_YEAR" NUMBER(10,0), 
	"LAT_MEAS" VARCHAR2(255), 
	"LONG_MEAS" VARCHAR2(255), 
	"SRC_MAP_SCALE_NUM" VARCHAR2(20), 
	"HORZ_ACC_MEAS" VARCHAR2(255), 
	"HORZ_ACC_UNT_MEAS" VARCHAR2(255), 
	"HORZ_COLL_METH_CODE" VARCHAR2(50), 
	"HORZ_REF_DATUM_CODE" VARCHAR2(50), 
	"GEO_REF_PT_CODE" VARCHAR2(50), 
	"DATA_COLL_DATE" TIMESTAMP (6), 
	"GEO_CMNT" VARCHAR2(255), 
	"VERT_MEAS" VARCHAR2(255), 
	"VERT_UNT_MEAS_CODE" VARCHAR2(50), 
	"VERT_COLL_METH_CODE" VARCHAR2(50), 
	"VERT_REF_DATUM_CODE" VARCHAR2(50), 
	"VERF_METH_CODE" VARCHAR2(50), 
	"COORD_DATA_SRC_CODE" VARCHAR2(50), 
	"GEOM_TYPE_CODE" VARCHAR2(50), 
	"AREA_WTIN_PERM" VARCHAR2(255), 
	"AREA_WTIN_PERM_UNT_MEAS_CODE" VARCHAR2(50), 
	"PCNT_AREA_PROD_EMIS" NUMBER(12,6)
   ) ;
 

   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_TYPE_CODE" IS 'Code that identifies the type of release point. (ReleasePointTypeCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_DESC" IS 'Text description of release point. (ReleasePointDescription)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_STK_HGT_MEAS" IS 'The height of the stack from the ground. (ReleasePointStackHeightMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_STK_HGT_UNT_MEAS_CODE" IS 'The stack height unit of measure. (ReleasePointStackHeightUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_STK_DIA_MEAS" IS 'The internal diameter of the stack (measured in feet) at the release height. (ReleasePointStackDiameterMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_STK_DIA_UNT_MEAS_CODE" IS 'the stack diameter unit of measure. (ReleasePointStackDiameterUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_EXIT_GAS_VEL_MEAS" IS 'The velocity of an exit gas stream. (ReleasePointExitGasVelocityMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."RL_PT_EXT_GS_VL_UNT_MS_CDE" IS 'The unit of measure for the velocity of an exit gas stream value.   (ReleasePointExitGasVelocityUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_EXIT_GAS_FLOW_RATE_MEAS" IS 'The value of the stack gas flow rate. (ReleasePointExitGasFlowRateMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."RL_PT_EXT_GS_FLW_RTE_UNT_MS_CD" IS 'The unit of measure for the stack gas flow rate value.   (ReleasePointExitGasFlowRateUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_EXIT_GAS_TMP_MEAS" IS 'The temperature of an exit gas stream (measured in degrees Fahrenheit). (ReleasePointExitGasTemperatureMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FENCE_LINE_DIST_MEAS" IS 'The measure of the horizontal distance to the nearest fence line of a property within which the release point is located. (ReleasePointFenceLineDistanceMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."RL_PT_FNCE_LNE_DST_UNT_MS_CDE" IS 'The fence line distance unit of measure. (ReleasePointFenceLineDistanceUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_HGT_MEAS" IS 'The fugitive release height above terrain of fugitive emissions. (ReleasePointFugitiveHeightMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_HGT_UNT_MEAS_CODE" IS 'The fugitive release height unit of measure. (ReleasePointFugitiveHeightUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_WID_MEAS" IS 'The width of the fugitive release in the East-West direction as if the angle is zero degrees. (ReleasePointFugitiveWidthMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_WID_UNT_MEAS_CODE" IS 'The fugitive width unit of measure code. (ReleasePointFugitiveWidthUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_LEN_MEAS" IS 'The length (measured in feet) of the fugitive release in the North-South direction as if the angle is zero degrees. (ReleasePointFugitiveLengthMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_LEN_UNT_MEAS_CODE" IS 'The fugitive length unit of measure code. (ReleasePointFugitiveLengthUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_FGTV_ANGLE_MEAS" IS 'The orientation angle for the area in degrees from North, measured positive in the clockwise direction. (ReleasePointFugitiveAngleMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_CMNT" IS 'Any comments regarding the release point. (ReleasePointComment)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_STAT_CODE" IS 'Code that identifies the operating status of the release point. (ReleasePointStatusCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."REL_PT_STAT_CODE_YEAR" IS 'The year in which the release point status became applicable. (ReleasePointStatusCodeYear)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."LAT_MEAS" IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."LONG_MEAS" IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."HORZ_ACC_MEAS" IS 'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."HORZ_ACC_UNT_MEAS" IS 'The horizonal accuracy unit of measure. (HorizontalAccuracyUnitofMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."HORZ_COLL_METH_CODE" IS 'The code that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."HORZ_REF_DATUM_CODE" IS 'The code that represents the reference datum used in determining latitude and longitude coordinates. (HorizontalReferenceDatumCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."GEO_REF_PT_CODE" IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."DATA_COLL_DATE" IS 'The calendar date when data were collected. (DataCollectionDate)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."GEO_CMNT" IS 'The text that provides additional information about the geographic coordinates. (GeographicComment)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."VERT_MEAS" IS 'The measure of elevation (i.e., the altitude), above or below a reference datum. (VerticalMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."VERT_UNT_MEAS_CODE" IS 'The vertical unit of measure. (VerticalUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."VERT_COLL_METH_CODE" IS 'The code that identifies the method used to collect the vertical measure (i.e., the altitude) of a reference point. (VerticalCollectionMethodCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."VERT_REF_DATUM_CODE" IS 'The code that represents the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalReferenceDatumCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."VERF_METH_CODE" IS 'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."COORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."GEOM_TYPE_CODE" IS 'The code that represents the geometric entity represented by one point or a sequence of latitude and longitude points. (GeometricTypeCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."AREA_WTIN_PERM" IS 'Total area that is contained within the event perimeter for the reporting period. (AreaWithinPerimeter)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."AREA_WTIN_PERM_UNT_MEAS_CODE" IS 'Code that identifies the unit of measure for the area within the event perimeter. (AreaWithinPerimeterUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT"."PCNT_AREA_PROD_EMIS" IS 'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)';
 
   COMMENT ON TABLE "CERS_REL_PT"  IS 'Schema element: ReleasePointDataType';
--------------------------------------------------------
--  DDL for Table CERS_REL_PT_IDEN
--------------------------------------------------------

  CREATE TABLE "CERS_REL_PT_IDEN" 
   (	"REL_PT_IDEN_ID" VARCHAR2(40), 
	"REL_PT_ID" VARCHAR2(40), 
	"IDEN" VARCHAR2(50), 
	"PROG_SYS_CODE" VARCHAR2(50), 
	"EFFC_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_REL_PT_IDEN"."IDEN" IS 'An identifier by which an element is referred to in another system. (Identifier)';
 
   COMMENT ON COLUMN "CERS_REL_PT_IDEN"."PROG_SYS_CODE" IS 'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT_IDEN"."EFFC_DATE" IS 'The date on which the identifier became effective. (EffectiveDate)';
 
   COMMENT ON COLUMN "CERS_REL_PT_IDEN"."END_DATE" IS 'The date on which the identifier is no longer applicable. (EndDate)';
 
   COMMENT ON TABLE "CERS_REL_PT_IDEN"  IS 'Schema element: ReleasePointIdentificationDataType';
--------------------------------------------------------
--  DDL for Table CERS_REL_PT_TST
--------------------------------------------------------

  CREATE TABLE "CERS_REL_PT_TST" 
   (	"REL_PT_TST_ID" VARCHAR2(40), 
	"REL_PT_ID" VARCHAR2(40), 
	"REL_PT_PLUME_HGT_MEAS" VARCHAR2(255), 
	"REL_PT_PLUME_HGT_UNT_MEAS_CODE" VARCHAR2(50), 
	"PCNT_OXYGEN_CONT" NUMBER(12,6), 
	"PCNT_MOIS_CONT" NUMBER(12,6), 
	"REL_PT_TST_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "CERS_REL_PT_TST"."REL_PT_PLUME_HGT_MEAS" IS 'The height of the plume rise from the release point above sea level.  (ReleasePointPlumeHeightMeasure)';
 
   COMMENT ON COLUMN "CERS_REL_PT_TST"."REL_PT_PLUME_HGT_UNT_MEAS_CODE" IS 'The plume height unit of measure. (ReleasePointPlumeHeightUnitofMeasureCode)';
 
   COMMENT ON COLUMN "CERS_REL_PT_TST"."PCNT_OXYGEN_CONT" IS 'The percent of oxygen content present in the stack test. (PercentOxygenContent)';
 
   COMMENT ON COLUMN "CERS_REL_PT_TST"."PCNT_MOIS_CONT" IS 'The percent of moisture content present in the stack test. (PercentMoistureContent)';
 
   COMMENT ON COLUMN "CERS_REL_PT_TST"."REL_PT_TST_DATE" IS 'Date in which stack test was taken. (ReleasePointTestDate)';
 
   COMMENT ON TABLE "CERS_REL_PT_TST"  IS 'Schema element: ReleasePointTestDataType';

---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_INDV
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_INDV

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_INDV
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_INDV_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_INDV_ADDR

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_INDV_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_INDV_COMMUN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_INDV_COMMUN

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_INDV_COMMUN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_INDV_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_INDV_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_INDV_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_ADDR

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_COMMUN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_COMMUN

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_COMMUN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_INDV
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_INDV

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_INDV
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_INDV_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_INDV_ADDR

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_INDV_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_INDV_COMMUN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_INDV_COMMUN

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_INDV_COMMUN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_AFFL_ORG_INDV_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_AFFL_ORG_INDV_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_AFFL_ORG_INDV_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_ALT_FAC_NAME
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_ALT_FAC_NAME

---------------------------------------------------
--   END DATA FOR TABLE CERS_ALT_FAC_NAME
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_CERS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_CERS

---------------------------------------------------
--   END DATA FOR TABLE CERS_CERS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_PROC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_PROC

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_PROC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_PROC_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_PROC_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_PROC_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_PROC_RGLN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_PROC_RGLN

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_PROC_RGLN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_PROC_RPT_PRD
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_PROC_RPT_PRD

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_PROC_RPT_PRD
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_QLTY_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_QLTY_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_QLTY_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMIS_UNIT_RGLN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMIS_UNIT_RGLN

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMIS_UNIT_RGLN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_CTRL_APCH_CTRL_MS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_CTRL_APCH_CTRL_MS

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_CTRL_APCH_CTRL_MS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_CTRL_APCH_CTR_PLT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_CTRL_APCH_CTR_PLT

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_CTRL_APCH_CTR_PLT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PRC_CTR_APC_CT_MS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PRC_CTR_APC_CT_MS

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PRC_CTR_APC_CT_MS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PRC_CTR_APC_CT_PL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PRC_CTR_APC_CT_PL

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PRC_CTR_APC_CT_PL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PRC_RL_PT_APPR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PRC_RL_PT_APPR

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PRC_RL_PT_APPR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PRC_RL_PT_APP_IDN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PRC_RL_PT_APP_IDN

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PRC_RL_PT_APP_IDN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PRC_RPT_PRD_EMS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PRC_RPT_PRD_EMS

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PRC_RPT_PRD_EMS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PRC_RPT_PRD_QL_ID
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PRC_RPT_PRD_QL_ID

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PRC_RPT_PRD_QL_ID
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EMS_UNT_PR_RP_PR_SP_CL_PR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EMS_UNT_PR_RP_PR_SP_CL_PR

---------------------------------------------------
--   END DATA FOR TABLE CERS_EMS_UNT_PR_RP_PR_SP_CL_PR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EVENT

---------------------------------------------------
--   END DATA FOR TABLE CERS_EVENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EVENT_EMIS_EMIS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EVENT_EMIS_EMIS

---------------------------------------------------
--   END DATA FOR TABLE CERS_EVENT_EMIS_EMIS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EVENT_EMIS_PROC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EVENT_EMIS_PROC

---------------------------------------------------
--   END DATA FOR TABLE CERS_EVENT_EMIS_PROC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EVENT_LOC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EVENT_LOC

---------------------------------------------------
--   END DATA FOR TABLE CERS_EVENT_LOC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EVENT_RPT_PRD
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EVENT_RPT_PRD

---------------------------------------------------
--   END DATA FOR TABLE CERS_EVENT_RPT_PRD
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_EXCL_LOC_PARM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_EXCL_LOC_PARM

---------------------------------------------------
--   END DATA FOR TABLE CERS_EXCL_LOC_PARM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_FAC_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_FAC_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_FAC_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_FAC_NAICS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_FAC_NAICS

---------------------------------------------------
--   END DATA FOR TABLE CERS_FAC_NAICS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_FAC_SITE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_FAC_SITE

---------------------------------------------------
--   END DATA FOR TABLE CERS_FAC_SITE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_FAC_SITE_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_FAC_SITE_ADDR

---------------------------------------------------
--   END DATA FOR TABLE CERS_FAC_SITE_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_FAC_SITE_QLTY_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_FAC_SITE_QLTY_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_FAC_SITE_QLTY_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_GEOSPATIAL_PARAMS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_GEOSPATIAL_PARAMS

---------------------------------------------------
--   END DATA FOR TABLE CERS_GEOSPATIAL_PARAMS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LC_PRC_CTRL_APCH_CTRL_MS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LC_PRC_CTRL_APCH_CTRL_MS

---------------------------------------------------
--   END DATA FOR TABLE CERS_LC_PRC_CTRL_APCH_CTRL_MS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LC_PRC_CTRL_APCH_CTRL_PLT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LC_PRC_CTRL_APCH_CTRL_PLT

---------------------------------------------------
--   END DATA FOR TABLE CERS_LC_PRC_CTRL_APCH_CTRL_PLT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LC_PRC_RPT_PRD_QLTY_IDN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LC_PRC_RPT_PRD_QLTY_IDN

---------------------------------------------------
--   END DATA FOR TABLE CERS_LC_PRC_RPT_PRD_QLTY_IDN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LC_PRC_RPT_PRD_SPP_CLC_PR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LC_PRC_RPT_PRD_SPP_CLC_PR

---------------------------------------------------
--   END DATA FOR TABLE CERS_LC_PRC_RPT_PRD_SPP_CLC_PR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC_REL_PT_APPR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC_REL_PT_APPR

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC_REL_PT_APPR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC_REL_PT_APPR_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC_REL_PT_APPR_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC_REL_PT_APPR_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC_RGLN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC_RGLN

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC_RGLN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC_RPT_PRD
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC_RPT_PRD

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC_RPT_PRD
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_LOC_PROC_RPT_PRD_EMIS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_LOC_PROC_RPT_PRD_EMIS

---------------------------------------------------
--   END DATA FOR TABLE CERS_LOC_PROC_RPT_PRD_EMIS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_MERGED_EVENTS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_MERGED_EVENTS

---------------------------------------------------
--   END DATA FOR TABLE CERS_MERGED_EVENTS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_ADDR

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_COMMUN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_COMMUN

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_COMMUN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_INDV

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV_ADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_INDV_ADDR

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV_ADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV_COMMUN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_INDV_COMMUN

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV_COMMUN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_QLTY_FIND_ORG_INDV_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_QLTY_FIND_ORG_INDV_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_REL_PT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_REL_PT

---------------------------------------------------
--   END DATA FOR TABLE CERS_REL_PT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_REL_PT_IDEN
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_REL_PT_IDEN

---------------------------------------------------
--   END DATA FOR TABLE CERS_REL_PT_IDEN
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE CERS_REL_PT_TST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into CERS_REL_PT_TST

---------------------------------------------------
--   END DATA FOR TABLE CERS_REL_PT_TST
---------------------------------------------------

--------------------------------------------------------
--  Constraints for Table CERS_FAC_SITE
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_SITE" ADD CONSTRAINT "PK_FAC_SITE" PRIMARY KEY ("FAC_SITE_ID") ENABLE;
 
  ALTER TABLE "CERS_FAC_SITE" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_SITE" MODIFY ("CERS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_QLTY_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_QLTY_IDEN" ADD CONSTRAINT "PK_EMS_UNT_QLT_IDN" PRIMARY KEY ("EMIS_UNIT_QLTY_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_QLTY_IDEN" MODIFY ("EMIS_UNIT_QLTY_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_QLTY_IDEN" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_QLTY_IDEN" MODIFY ("QLTY_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_QLTY_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PRC_CTR_APC_CT_PL
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" ADD CONSTRAINT "PK_EM_UN_PR_CT_02" PRIMARY KEY ("EMS_UNT_PRC_CTR_APC_CTR_PLT_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" MODIFY ("EMS_UNT_PRC_CTR_APC_CTR_PLT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" MODIFY ("POLT_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_REL_PT_TST
--------------------------------------------------------

  ALTER TABLE "CERS_REL_PT_TST" ADD CONSTRAINT "PK_REL_PT_TST" PRIMARY KEY ("REL_PT_TST_ID") ENABLE;
 
  ALTER TABLE "CERS_REL_PT_TST" MODIFY ("REL_PT_TST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_REL_PT_TST" MODIFY ("REL_PT_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_INDV
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV" ADD CONSTRAINT "PK_AFFL_ORG_INDV" PRIMARY KEY ("AFFL_ORG_INDV_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_INDV" MODIFY ("AFFL_ORG_INDV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_INDV" MODIFY ("AFFL_ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_CTRL_APCH_CTRL_MS
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" ADD CONSTRAINT "PK_EM_UN_CT_AP_CT" PRIMARY KEY ("EMS_UNT_CTRL_APCH_CTRL_MS_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" MODIFY ("EMS_UNT_CTRL_APCH_CTRL_MS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" MODIFY ("CTRL_MEAS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG" ADD CONSTRAINT "PK_QLTY_FIND_ORG" PRIMARY KEY ("QLTY_FIND_ORG_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG" MODIFY ("QLTY_FIND_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG" MODIFY ("QLTY_FIND_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG" MODIFY ("ORG_FORMAL_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_PROC_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC_IDEN" ADD CONSTRAINT "PK_EMS_UNT_PRC_IDN" PRIMARY KEY ("EMIS_UNIT_PROC_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_IDEN" MODIFY ("EMIS_UNIT_PROC_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_IDEN" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC" ADD CONSTRAINT "PK_LOC_PROC" PRIMARY KEY ("LOC_PROC_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC" MODIFY ("LOC_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_INDV_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_COMMUN" ADD CONSTRAINT "PK_QLT_FN_OR_IN_CM" PRIMARY KEY ("QLTY_FIND_ORG_INDV_COMMUN_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_COMMUN" MODIFY ("QLTY_FIND_ORG_INDV_COMMUN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_COMMUN" MODIFY ("QLTY_FIND_ORG_INDV_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG" ADD CONSTRAINT "PK_AFFL_ORG" PRIMARY KEY ("AFFL_ORG_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG" MODIFY ("AFFL_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG" MODIFY ("AFFL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG" MODIFY ("ORG_FORMAL_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LC_PRC_CTRL_APCH_CTRL_MS
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS" ADD CONSTRAINT "PK_LC_PR_CT_AP_CT" PRIMARY KEY ("LC_PRC_CTRL_APCH_CTRL_MS_ID") ENABLE;
 
  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS" MODIFY ("LC_PRC_CTRL_APCH_CTRL_MS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS" MODIFY ("CTRL_MEAS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EVENT
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT" ADD CONSTRAINT "PK_EVENT" PRIMARY KEY ("EVENT_ID") ENABLE;
 
  ALTER TABLE "CERS_EVENT" MODIFY ("EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT" MODIFY ("CERS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT" MODIFY ("EVENT_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_COMMUN" ADD CONSTRAINT "PK_QLT_FND_ORG_CMM" PRIMARY KEY ("QLTY_FIND_ORG_COMMUN_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_COMMUN" MODIFY ("QLTY_FIND_ORG_COMMUN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_COMMUN" MODIFY ("QLTY_FIND_ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_IDEN" ADD CONSTRAINT "PK_QLT_FND_ORG_IDN" PRIMARY KEY ("QLTY_FIND_ORG_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_IDEN" MODIFY ("QLTY_FIND_ORG_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_IDEN" MODIFY ("QLTY_FIND_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EVENT_LOC
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_LOC" ADD CONSTRAINT "PK_EVENT_LOC" PRIMARY KEY ("EVENT_LOC_ID") ENABLE;
 
  ALTER TABLE "CERS_EVENT_LOC" MODIFY ("EVENT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_LOC" MODIFY ("EVENT_RPT_PRD_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_IDEN" ADD CONSTRAINT "PK_EMIS_UNIT_IDEN" PRIMARY KEY ("EMIS_UNIT_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_IDEN" MODIFY ("EMIS_UNIT_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_IDEN" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EXCL_LOC_PARM
--------------------------------------------------------

  ALTER TABLE "CERS_EXCL_LOC_PARM" ADD CONSTRAINT "PK_EXCL_LOC_PARM" PRIMARY KEY ("EXCL_LOC_PARM_ID") ENABLE;
 
  ALTER TABLE "CERS_EXCL_LOC_PARM" MODIFY ("EXCL_LOC_PARM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EXCL_LOC_PARM" MODIFY ("LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EXCL_LOC_PARM" MODIFY ("LOC_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EXCL_LOC_PARM" MODIFY ("LOC_PARM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL" ADD CONSTRAINT "PK_AFFL" PRIMARY KEY ("AFFL_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL" MODIFY ("AFFL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL" MODIFY ("AFFL_TYPE_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LC_PRC_RPT_PRD_QLTY_IDN
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" ADD CONSTRAINT "PK_LC_PR_RP_PR_QL" PRIMARY KEY ("LOC_PROC_RPT_PRD_QLTY_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" MODIFY ("LOC_PROC_RPT_PRD_QLTY_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" MODIFY ("LOC_PROC_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" MODIFY ("QLTY_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_INDV
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV" ADD CONSTRAINT "PK_AFFL_INDV" PRIMARY KEY ("AFFL_INDV_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_INDV" MODIFY ("AFFL_INDV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_INDV" MODIFY ("AFFL_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_INDV_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV_IDEN" ADD CONSTRAINT "PK_AFFL_INDV_IDEN" PRIMARY KEY ("AFFL_INDV_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_INDV_IDEN" MODIFY ("AFFL_INDV_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_INDV_IDEN" MODIFY ("AFFL_INDV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_INDV_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_INDV_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC
--------------------------------------------------------

  ALTER TABLE "CERS_LOC" ADD CONSTRAINT "PK_LOC" PRIMARY KEY ("LOC_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC" MODIFY ("LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC" MODIFY ("CERS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EVENT_EMIS_PROC
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_EMIS_PROC" ADD CONSTRAINT "PK_EVENT_EMIS_PROC" PRIMARY KEY ("EVENT_EMIS_PROC_ID") ENABLE;
 
  ALTER TABLE "CERS_EVENT_EMIS_PROC" MODIFY ("EVENT_EMIS_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_EMIS_PROC" MODIFY ("EVENT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_EMIS_PROC" MODIFY ("SRC_CLASS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EVENT_EMIS_EMIS
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_EMIS_EMIS" ADD CONSTRAINT "PK_EVENT_EMIS_EMIS" PRIMARY KEY ("EVENT_EMIS_EMIS_ID") ENABLE;
 
  ALTER TABLE "CERS_EVENT_EMIS_EMIS" MODIFY ("EVENT_EMIS_EMIS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_EMIS_EMIS" MODIFY ("EVENT_EMIS_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_EMIS_EMIS" MODIFY ("POLT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_EMIS_EMIS" MODIFY ("TOTAL_EMIS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PRC_RPT_PRD_EMS
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" ADD CONSTRAINT "PK_EM_UN_PR_RP_03" PRIMARY KEY ("EMIS_UNIT_PROC_RPT_PRD_EMIS_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" MODIFY ("EMIS_UNIT_PROC_RPT_PRD_EMIS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" MODIFY ("EMIS_UNIT_PROC_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" MODIFY ("POLT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" MODIFY ("TOTAL_EMIS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_FAC_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_IDEN" ADD CONSTRAINT "PK_FAC_IDEN" PRIMARY KEY ("FAC_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_FAC_IDEN" MODIFY ("FAC_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_IDEN" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_IDEN" MODIFY ("FAC_SITE_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PR_RP_PR_SP_CL_PR
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" ADD CONSTRAINT "PK_EM_UN_PR_RP_02" PRIMARY KEY ("EMS_UNT_PRC_RPT_PR_SP_CL_PR_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" MODIFY ("EMS_UNT_PRC_RPT_PR_SP_CL_PR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" MODIFY ("EMIS_UNIT_PROC_RPT_PRD_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_REL_PT_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_REL_PT_IDEN" ADD CONSTRAINT "PK_REL_PT_IDEN" PRIMARY KEY ("REL_PT_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_REL_PT_IDEN" MODIFY ("REL_PT_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_REL_PT_IDEN" MODIFY ("REL_PT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_REL_PT_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_REL_PT_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_ADDR" ADD CONSTRAINT "PK_QLT_FND_ORG_ADD" PRIMARY KEY ("QLTY_FIND_ORG_ADDR_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_ADDR" MODIFY ("QLTY_FIND_ORG_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_ADDR" MODIFY ("QLTY_FIND_ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_INDV
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV" ADD CONSTRAINT "PK_QLT_FND_ORG_IND" PRIMARY KEY ("QLTY_FIND_ORG_INDV_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV" MODIFY ("QLTY_FIND_ORG_INDV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV" MODIFY ("QLTY_FIND_ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND" ADD CONSTRAINT "PK_QLTY_FIND" PRIMARY KEY ("QLTY_FIND_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND" MODIFY ("QLTY_FIND_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND" MODIFY ("CERS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND" MODIFY ("QLTY_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_FAC_SITE_QLTY_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_SITE_QLTY_IDEN" ADD CONSTRAINT "PK_FC_STE_QLTY_IDN" PRIMARY KEY ("FAC_SITE_QLTY_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_FAC_SITE_QLTY_IDEN" MODIFY ("FAC_SITE_QLTY_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_SITE_QLTY_IDEN" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_SITE_QLTY_IDEN" MODIFY ("QLTY_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_SITE_QLTY_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_REL_PT
--------------------------------------------------------

  ALTER TABLE "CERS_REL_PT" ADD CONSTRAINT "PK_REL_PT" PRIMARY KEY ("REL_PT_ID") ENABLE;
 
  ALTER TABLE "CERS_REL_PT" MODIFY ("REL_PT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_REL_PT" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC_RGLN
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_RGLN" ADD CONSTRAINT "PK_LOC_PROC_RGLN" PRIMARY KEY ("LOC_PROC_RGLN_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC_RGLN" MODIFY ("LOC_PROC_RGLN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RGLN" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RGLN" MODIFY ("RGTRY_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_CERS
--------------------------------------------------------

  ALTER TABLE "CERS_CERS" ADD CONSTRAINT "PK_CERS" PRIMARY KEY ("CERS_ID") ENABLE;
 
  ALTER TABLE "CERS_CERS" MODIFY ("CERS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_CERS" MODIFY ("DATA_CATEGORY" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_CERS" MODIFY ("USER_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_CERS" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_CERS" MODIFY ("EMIS_YEAR" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_FAC_NAICS
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_NAICS" ADD CONSTRAINT "PK_FAC_NAICS" PRIMARY KEY ("FAC_NAICS_ID") ENABLE;
 
  ALTER TABLE "CERS_FAC_NAICS" MODIFY ("FAC_NAICS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_NAICS" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_PROC_RPT_PRD
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD" ADD CONSTRAINT "PK_EMS_UN_PR_RP_PR" PRIMARY KEY ("EMIS_UNIT_PROC_RPT_PRD_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD" MODIFY ("EMIS_UNIT_PROC_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD" MODIFY ("RPT_PRD_TYPE_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC_RPT_PRD
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_RPT_PRD" ADD CONSTRAINT "PK_LC_PRC_RPT_PRD" PRIMARY KEY ("LOC_PROC_RPT_PRD_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD" MODIFY ("LOC_PROC_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD" MODIFY ("RPT_PRD_TYPE_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_COMMUN" ADD CONSTRAINT "PK_AFFL_ORG_COMMUN" PRIMARY KEY ("AFFL_ORG_COMMUN_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_COMMUN" MODIFY ("AFFL_ORG_COMMUN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_COMMUN" MODIFY ("AFFL_ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_IDEN" ADD CONSTRAINT "PK_LOC_PROC_IDEN" PRIMARY KEY ("LOC_PROC_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC_IDEN" MODIFY ("LOC_PROC_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_IDEN" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC_REL_PT_APPR_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" ADD CONSTRAINT "PK_LC_PR_RL_PT_AP" PRIMARY KEY ("LOC_PROC_REL_PT_APPR_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" MODIFY ("LOC_PROC_REL_PT_APPR_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" MODIFY ("LOC_PROC_REL_PT_APPR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC_RPT_PRD_EMIS
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" ADD CONSTRAINT "PK_LC_PRC_RP_PR_EM" PRIMARY KEY ("LOC_PROC_RPT_PRD_EMIS_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" MODIFY ("LOC_PROC_RPT_PRD_EMIS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" MODIFY ("LOC_PROC_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" MODIFY ("POLT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" MODIFY ("TOTAL_EMIS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LC_PRC_CTRL_APCH_CTRL_PLT
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" ADD CONSTRAINT "PK_LC_PR_CT_AP_02" PRIMARY KEY ("LC_PRC_CTRL_APCH_CTRL_PLT_ID") ENABLE;
 
  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" MODIFY ("LC_PRC_CTRL_APCH_CTRL_PLT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" MODIFY ("POLT_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PRC_RL_PT_APPR
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR" ADD CONSTRAINT "PK_EM_UN_PR_RL_PT" PRIMARY KEY ("EMIS_UNIT_PROC_REL_PT_APPR_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR" MODIFY ("EMIS_UNIT_PROC_REL_PT_APPR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR" MODIFY ("AVE_PCNT_EMIS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PRC_RPT_PRD_QL_ID
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" ADD CONSTRAINT "PK_EM_UN_PR_RP_PR" PRIMARY KEY ("EMS_UNT_PRC_RPT_PRD_QLT_IDN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" MODIFY ("EMS_UNT_PRC_RPT_PRD_QLT_IDN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" MODIFY ("EMIS_UNIT_PROC_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" MODIFY ("QLTY_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_PROC
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC" ADD CONSTRAINT "PK_EMIS_UNIT_PROC" PRIMARY KEY ("EMIS_UNIT_PROC_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PRC_CTR_APC_CT_MS
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" ADD CONSTRAINT "PK_EM_UN_PR_CT_AP" PRIMARY KEY ("EMS_UNT_PRC_CTRL_APC_CTR_MS_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" MODIFY ("EMS_UNT_PRC_CTRL_APC_CTR_MS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" MODIFY ("CTRL_MEAS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_INDV_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV_COMMUN" ADD CONSTRAINT "PK_AFF_ORG_IND_CMM" PRIMARY KEY ("AFFL_ORG_INDV_COMMUN_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_COMMUN" MODIFY ("AFFL_ORG_INDV_COMMUN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_COMMUN" MODIFY ("AFFL_ORG_INDV_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_INDV_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV_COMMUN" ADD CONSTRAINT "PK_AFFL_INDV_CMMN" PRIMARY KEY ("AFFL_INDV_COMMUN_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_INDV_COMMUN" MODIFY ("AFFL_INDV_COMMUN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_INDV_COMMUN" MODIFY ("AFFL_INDV_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EVENT_RPT_PRD
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_RPT_PRD" ADD CONSTRAINT "PK_EVENT_RPT_PRD" PRIMARY KEY ("EVENT_RPT_PRD_ID") ENABLE;
 
  ALTER TABLE "CERS_EVENT_RPT_PRD" MODIFY ("EVENT_RPT_PRD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_RPT_PRD" MODIFY ("EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_RPT_PRD" MODIFY ("EVENT_BEGIN_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_RPT_PRD" MODIFY ("EVENT_END_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EVENT_RPT_PRD" MODIFY ("EVENT_STAGE_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_MERGED_EVENTS
--------------------------------------------------------

  ALTER TABLE "CERS_MERGED_EVENTS" ADD CONSTRAINT "PK_MERGED_EVENTS" PRIMARY KEY ("MERGED_EVENTS_ID") ENABLE;
 
  ALTER TABLE "CERS_MERGED_EVENTS" MODIFY ("MERGED_EVENTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_MERGED_EVENTS" MODIFY ("EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_MERGED_EVENTS" MODIFY ("EVENT_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_MERGED_EVENTS" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_ADDR" ADD CONSTRAINT "PK_AFFL_ORG_ADDR" PRIMARY KEY ("AFFL_ORG_ADDR_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_ADDR" MODIFY ("AFFL_ORG_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_ADDR" MODIFY ("AFFL_ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_INDV_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV_ADDR" ADD CONSTRAINT "PK_AFF_ORG_IND_ADD" PRIMARY KEY ("AFFL_ORG_INDV_ADDR_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_ADDR" MODIFY ("AFFL_ORG_INDV_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_ADDR" MODIFY ("AFFL_ORG_INDV_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_GEOSPATIAL_PARAMS
--------------------------------------------------------

  ALTER TABLE "CERS_GEOSPATIAL_PARAMS" ADD CONSTRAINT "PK_GSPTL_PRMS" PRIMARY KEY ("GEOSPATIAL_PARAMS_ID") ENABLE;
 
  ALTER TABLE "CERS_GEOSPATIAL_PARAMS" MODIFY ("GEOSPATIAL_PARAMS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_GEOSPATIAL_PARAMS" MODIFY ("EVENT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_GEOSPATIAL_PARAMS" MODIFY ("SHAPE_FILE_IDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LOC_PROC_REL_PT_APPR
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR" ADD CONSTRAINT "PK_LC_PRC_RL_PT_AP" PRIMARY KEY ("LOC_PROC_REL_PT_APPR_ID") ENABLE;
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR" MODIFY ("LOC_PROC_REL_PT_APPR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR" MODIFY ("LOC_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR" MODIFY ("AVE_PCNT_EMIS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_RGLN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_RGLN" ADD CONSTRAINT "PK_EMIS_UNIT_RGLN" PRIMARY KEY ("EMIS_UNIT_RGLN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_RGLN" MODIFY ("EMIS_UNIT_RGLN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_RGLN" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_RGLN" MODIFY ("RGTRY_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_IDEN" ADD CONSTRAINT "PK_AFFL_ORG_IDEN" PRIMARY KEY ("AFFL_ORG_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_IDEN" MODIFY ("AFFL_ORG_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_IDEN" MODIFY ("AFFL_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_ALT_FAC_NAME
--------------------------------------------------------

  ALTER TABLE "CERS_ALT_FAC_NAME" ADD CONSTRAINT "PK_ALT_FAC_NAME" PRIMARY KEY ("ALT_FAC_NAME_ID") ENABLE;
 
  ALTER TABLE "CERS_ALT_FAC_NAME" MODIFY ("ALT_FAC_NAME_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_ALT_FAC_NAME" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_ALT_FAC_NAME" MODIFY ("ALT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_ALT_FAC_NAME" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_INDV_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV_ADDR" ADD CONSTRAINT "PK_AFFL_INDV_ADDR" PRIMARY KEY ("AFFL_INDV_ADDR_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_INDV_ADDR" MODIFY ("AFFL_INDV_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_INDV_ADDR" MODIFY ("AFFL_INDV_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT" ADD CONSTRAINT "PK_EMIS_UNIT" PRIMARY KEY ("EMIS_UNIT_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_INDV_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_ADDR" ADD CONSTRAINT "PK_QLT_FN_OR_IN_AD" PRIMARY KEY ("QLTY_FIND_ORG_INDV_ADDR_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_ADDR" MODIFY ("QLTY_FIND_ORG_INDV_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_ADDR" MODIFY ("QLTY_FIND_ORG_INDV_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_FAC_SITE_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_SITE_ADDR" ADD CONSTRAINT "PK_FAC_SITE_ADDR" PRIMARY KEY ("FAC_SITE_ADDR_ID") ENABLE;
 
  ALTER TABLE "CERS_FAC_SITE_ADDR" MODIFY ("FAC_SITE_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_FAC_SITE_ADDR" MODIFY ("FAC_SITE_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_QLTY_FIND_ORG_INDV_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" ADD CONSTRAINT "PK_QLT_FN_OR_IN_ID" PRIMARY KEY ("QLTY_FIND_ORG_INDV_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" MODIFY ("QLTY_FIND_ORG_INDV_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" MODIFY ("QLTY_FIND_ORG_INDV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_CTRL_APCH_CTR_PLT
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" ADD CONSTRAINT "PK_EM_UN_CT_AP_02" PRIMARY KEY ("EMS_UNT_CTRL_APCH_CTRL_PLT_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" MODIFY ("EMS_UNT_CTRL_APCH_CTRL_PLT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" MODIFY ("EMIS_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" MODIFY ("POLT_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_AFFL_ORG_INDV_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV_IDEN" ADD CONSTRAINT "PK_AFF_ORG_IND_IDN" PRIMARY KEY ("AFFL_ORG_INDV_IDEN_ID") ENABLE;
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_IDEN" MODIFY ("AFFL_ORG_INDV_IDEN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_IDEN" MODIFY ("AFFL_ORG_INDV_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_IDEN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_AFFL_ORG_INDV_IDEN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMS_UNT_PRC_RL_PT_APP_IDN
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" ADD CONSTRAINT "PK_EM_UN_PR_RL_02" PRIMARY KEY ("EMS_UNT_PRC_RL_PT_APPR_IDN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" MODIFY ("EMS_UNT_PRC_RL_PT_APPR_IDN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" MODIFY ("EMIS_UNIT_PROC_REL_PT_APPR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" MODIFY ("IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" MODIFY ("PROG_SYS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_LC_PRC_RPT_PRD_SPP_CLC_PR
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" ADD CONSTRAINT "PK_LC_PR_RP_PR_SP" PRIMARY KEY ("LC_PRC_RPT_PRD_SPP_CLC_PRM_ID") ENABLE;
 
  ALTER TABLE "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" MODIFY ("LC_PRC_RPT_PRD_SPP_CLC_PRM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" MODIFY ("LOC_PROC_RPT_PRD_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CERS_EMIS_UNIT_PROC_RGLN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC_RGLN" ADD CONSTRAINT "PK_EMS_UNT_PRC_RGL" PRIMARY KEY ("EMIS_UNIT_PROC_RGLN_ID") ENABLE;
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_RGLN" MODIFY ("EMIS_UNIT_PROC_RGLN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_RGLN" MODIFY ("EMIS_UNIT_PROC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "CERS_EMIS_UNIT_PROC_RGLN" MODIFY ("RGTRY_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_AFFL_INDV
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_INDV" ON "CERS_AFFL_INDV" ("AFFL_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EVENT_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVENT_LOC" ON "CERS_EVENT_LOC" ("EVENT_LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PR_CT_AP_02
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PR_CT_AP_02" ON "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" ("LC_PRC_CTRL_APCH_CTRL_PLT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_ORG_INDV
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_ORG_INDV" ON "CERS_AFFL_ORG_INDV" ("AFFL_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RP_02
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RP_02" ON "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" ("EMIS_UNIT_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_RL_PT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_RL_PT" ON "CERS_EMS_UNT_PRC_RL_PT_APPR" ("EMIS_UNIT_PROC_REL_PT_APPR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_CT_AP
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_CT_AP" ON "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_RP_PR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_RP_PR" ON "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" ("EMS_UNT_PRC_RPT_PRD_QLT_IDN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_IN_CM_AF_IN
--------------------------------------------------------

  CREATE INDEX "IX_AF_IN_CM_AF_IN" ON "CERS_AFFL_INDV_COMMUN" ("AFFL_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LOC" ON "CERS_LOC" ("LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_GSP_PR_EV_LC_ID
--------------------------------------------------------

  CREATE INDEX "IX_GSP_PR_EV_LC_ID" ON "CERS_GEOSPATIAL_PARAMS" ("EVENT_LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_AD_AF_OR
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_AD_AF_OR" ON "CERS_AFFL_ORG_ADDR" ("AFFL_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EVENT_RPT_PRD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVENT_RPT_PRD" ON "CERS_EVENT_RPT_PRD" ("EVENT_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFFL_IND_AFF_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFL_IND_AFF_ID" ON "CERS_AFFL_INDV" ("AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FC_IDN_FC_ST_ID
--------------------------------------------------------

  CREATE INDEX "IX_FC_IDN_FC_ST_ID" ON "CERS_FAC_IDEN" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_CT_02
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_CT_02" ON "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_RP_02
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_RP_02" ON "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" ("EMS_UNT_PRC_RPT_PR_SP_CL_PR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_CT_AP_CT
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_CT_AP_CT" ON "CERS_LC_PRC_CTRL_APCH_CTRL_MS" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_RG_EM_UN
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_RG_EM_UN" ON "CERS_EMIS_UNIT_RGLN" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMS_UNT_PRC_IDN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMS_UNT_PRC_IDN" ON "CERS_EMIS_UNIT_PROC_IDEN" ("EMIS_UNIT_PROC_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EMS_UN_FC_ST_ID
--------------------------------------------------------

  CREATE INDEX "IX_EMS_UN_FC_ST_ID" ON "CERS_EMIS_UNIT" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FC_STE_CRS_ID
--------------------------------------------------------

  CREATE INDEX "IX_FC_STE_CRS_ID" ON "CERS_FAC_SITE" ("CERS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CRS_DTA_CTGRY
--------------------------------------------------------

  CREATE INDEX "IX_CRS_DTA_CTGRY" ON "CERS_CERS" ("DATA_CATEGORY") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_IN_AF_OR
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_IN_AF_OR" ON "CERS_AFFL_ORG_INDV" ("AFFL_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CERS_EMIS_YEAR
--------------------------------------------------------

  CREATE INDEX "IX_CERS_EMIS_YEAR" ON "CERS_CERS" ("EMIS_YEAR") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FND_ORG_IND
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FND_ORG_IND" ON "CERS_QLTY_FIND_ORG_INDV" ("QLTY_FIND_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FN_OR_IN_CM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FN_OR_IN_CM" ON "CERS_QLTY_FIND_ORG_INDV_COMMUN" ("QLTY_FIND_ORG_INDV_COMMUN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FND_ORG_IDN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FND_ORG_IDN" ON "CERS_QLTY_FIND_ORG_IDEN" ("QLTY_FIND_ORG_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_QL_FN
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_QL_FN" ON "CERS_QLTY_FIND_ORG" ("QLTY_FIND_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LOC_PROC_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LOC_PROC_IDEN" ON "CERS_LOC_PROC_IDEN" ("LOC_PROC_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_IN_QL
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_IN_QL" ON "CERS_QLTY_FIND_ORG_INDV" ("QLTY_FIND_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_ORG_COMMUN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_ORG_COMMUN" ON "CERS_AFFL_ORG_COMMUN" ("AFFL_ORG_COMMUN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RP_PR
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RP_PR" ON "CERS_EMIS_UNIT_PROC_RPT_PRD" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RP_04
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RP_04" ON "CERS_EMS_UNT_PRC_RPT_PRD_EMS" ("EMIS_UNIT_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EV_EM_EM_EV_EM
--------------------------------------------------------

  CREATE INDEX "IX_EV_EM_EM_EV_EM" ON "CERS_EVENT_EMIS_EMIS" ("EVENT_EMIS_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PR_RP_PR_SP
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PR_RP_PR_SP" ON "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" ("LC_PRC_RPT_PRD_SPP_CLC_PRM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CERS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CERS" ON "CERS_CERS" ("CERS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMS_UNT_PRC_RGL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMS_UNT_PRC_RGL" ON "CERS_EMIS_UNIT_PROC_RGLN" ("EMIS_UNIT_PROC_RGLN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMIS_UNIT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMIS_UNIT" ON "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FND_ORG_CMM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FND_ORG_CMM" ON "CERS_QLTY_FIND_ORG_COMMUN" ("QLTY_FIND_ORG_COMMUN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFF_ORG_IND_ADD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFF_ORG_IND_ADD" ON "CERS_AFFL_ORG_INDV_ADDR" ("AFFL_ORG_INDV_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_CT_AP_CT
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_CT_AP_CT" ON "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EVENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVENT" ON "CERS_EVENT" ("EVENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFF_ORG_IND_CMM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFF_ORG_IND_CMM" ON "CERS_AFFL_ORG_INDV_COMMUN" ("AFFL_ORG_INDV_COMMUN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_IN_AD_AF
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_IN_AD_AF" ON "CERS_AFFL_ORG_INDV_ADDR" ("AFFL_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL" ON "CERS_AFFL" ("AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EVENT_EMIS_EMIS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVENT_EMIS_EMIS" ON "CERS_EVENT_EMIS_EMIS" ("EVENT_EMIS_EMIS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_SITE_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_SITE_ADDR" ON "CERS_FAC_SITE_ADDR" ("FAC_SITE_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FN_OR_IN_AD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FN_OR_IN_AD" ON "CERS_QLTY_FIND_ORG_INDV_ADDR" ("QLTY_FIND_ORG_INDV_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_CT_02
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_CT_02" ON "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" ("EMS_UNT_PRC_CTR_APC_CTR_PLT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_IDEN" ON "CERS_FAC_IDEN" ("FAC_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RL_PT
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RL_PT" ON "CERS_EMS_UNT_PRC_RL_PT_APPR" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_SITE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_SITE" ON "CERS_FAC_SITE" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_INDV_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_INDV_IDEN" ON "CERS_AFFL_INDV_IDEN" ("AFFL_INDV_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_ORG_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_ORG_ADDR" ON "CERS_AFFL_ORG_ADDR" ("AFFL_ORG_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_CT_AP_02
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_CT_AP_02" ON "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" ("EMS_UNT_CTRL_APCH_CTRL_PLT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_ID_LC_PR
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_ID_LC_PR" ON "CERS_LOC_PROC_IDEN" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_CT_AP_CT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_CT_AP_CT" ON "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" ("EMS_UNT_CTRL_APCH_CTRL_MS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PR_CT_AP_CT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PR_CT_AP_CT" ON "CERS_LC_PRC_CTRL_APCH_CTRL_MS" ("LC_PRC_CTRL_APCH_CTRL_MS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_ID_QL
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_ID_QL" ON "CERS_QLTY_FIND_ORG_IDEN" ("QLTY_FIND_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RL_PT_AP
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RL_PT_AP" ON "CERS_LOC_PROC_REL_PT_APPR" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLTY_FIND_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLTY_FIND_ORG" ON "CERS_QLTY_FIND_ORG" ("QLTY_FIND_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RP_03
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RP_03" ON "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" ("EMIS_UNIT_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RL_PT_02
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RL_PT_02" ON "CERS_LOC_PROC_REL_PT_APPR_IDEN" ("LOC_PROC_REL_PT_APPR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FC_ST_AD_FC_ST
--------------------------------------------------------

  CREATE INDEX "IX_FC_ST_AD_FC_ST" ON "CERS_FAC_SITE_ADDR" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_RL_02
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_RL_02" ON "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" ("EMS_UNT_PRC_RL_PT_APPR_IDN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMIS_UNIT_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMIS_UNIT_IDEN" ON "CERS_EMIS_UNIT_IDEN" ("EMIS_UNIT_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_IN_ID_AF
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_IN_ID_AF" ON "CERS_AFFL_ORG_INDV_IDEN" ("AFFL_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_QL_ID_EM
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_QL_ID_EM" ON "CERS_EMIS_UNIT_QLTY_IDEN" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LOC_PROC_RGLN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LOC_PROC_RGLN" ON "CERS_LOC_PROC_RGLN" ("LOC_PROC_RGLN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_CM_AF_OR
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_CM_AF_OR" ON "CERS_AFFL_ORG_COMMUN" ("AFFL_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_IN_AD
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_IN_AD" ON "CERS_QLTY_FIND_ORG_INDV_ADDR" ("QLTY_FIND_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_AD_QL
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_AD_QL" ON "CERS_QLTY_FIND_ORG_ADDR" ("QLTY_FIND_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FN_OR_IN_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FN_OR_IN_ID" ON "CERS_QLTY_FIND_ORG_INDV_IDEN" ("QLTY_FIND_ORG_INDV_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMIS_UNIT_RGLN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMIS_UNIT_RGLN" ON "CERS_EMIS_UNIT_RGLN" ("EMIS_UNIT_RGLN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FAC_NAICS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_NAICS" ON "CERS_FAC_NAICS" ("FAC_NAICS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFFL_FC_STE_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFL_FC_STE_ID" ON "CERS_AFFL" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_INDV_CMMN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_INDV_CMMN" ON "CERS_AFFL_INDV_COMMUN" ("AFFL_INDV_COMMUN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RL_02
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RL_02" ON "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" ("EMIS_UNIT_PROC_REL_PT_APPR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_CM_QL
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_CM_QL" ON "CERS_QLTY_FIND_ORG_COMMUN" ("QLTY_FIND_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FC_ST_QL_ID_FC
--------------------------------------------------------

  CREATE INDEX "IX_FC_ST_QL_ID_FC" ON "CERS_FAC_SITE_QLTY_IDEN" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_REL_PT_TST
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REL_PT_TST" ON "CERS_REL_PT_TST" ("REL_PT_TST_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_EM_UN
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_EM_UN" ON "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EV_LC_EV_RP_PR
--------------------------------------------------------

  CREATE INDEX "IX_EV_LC_EV_RP_PR" ON "CERS_EVENT_LOC" ("EVENT_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_MERGED_EVENTS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_MERGED_EVENTS" ON "CERS_MERGED_EVENTS" ("MERGED_EVENTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_IN_CM_AF
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_IN_CM_AF" ON "CERS_AFFL_ORG_INDV_COMMUN" ("AFFL_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_ID_EM_UN
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_ID_EM_UN" ON "CERS_EMIS_UNIT_IDEN" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_IN_ID
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_IN_ID" ON "CERS_QLTY_FIND_ORG_INDV_IDEN" ("QLTY_FIND_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FC_NCS_FC_ST_ID
--------------------------------------------------------

  CREATE INDEX "IX_FC_NCS_FC_ST_ID" ON "CERS_FAC_NAICS" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AFFL_ORG_AFF_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFL_ORG_AFF_ID" ON "CERS_AFFL_ORG" ("AFFL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EV_EM_PR_EV_LC
--------------------------------------------------------

  CREATE INDEX "IX_EV_EM_PR_EV_LC" ON "CERS_EVENT_EMIS_PROC" ("EVENT_LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_RG_EM
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_RG_EM" ON "CERS_EMIS_UNIT_PROC_RGLN" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_REL_PT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REL_PT" ON "CERS_REL_PT" ("REL_PT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LOC_PROC_LOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_LOC_PROC_LOC_ID" ON "CERS_LOC_PROC" ("LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLT_FND_ORG_ADD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLT_FND_ORG_ADD" ON "CERS_QLTY_FIND_ORG_ADDR" ("QLTY_FIND_ORG_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMIS_UNIT_PROC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMIS_UNIT_PROC" ON "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_ORG_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_ORG_IDEN" ON "CERS_AFFL_ORG_IDEN" ("AFFL_ORG_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EXC_LC_PR_LC_ID
--------------------------------------------------------

  CREATE INDEX "IX_EXC_LC_PR_LC_ID" ON "CERS_EXCL_LOC_PARM" ("LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RP_PR_SP
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RP_PR_SP" ON "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" ("LOC_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_GSPTL_PRMS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GSPTL_PRMS" ON "CERS_GEOSPATIAL_PARAMS" ("GEOSPATIAL_PARAMS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RL_PT_TS_RL_PT
--------------------------------------------------------

  CREATE INDEX "IX_RL_PT_TS_RL_PT" ON "CERS_REL_PT_TST" ("REL_PT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_IN_AD_AF_IN
--------------------------------------------------------

  CREATE INDEX "IX_AF_IN_AD_AF_IN" ON "CERS_AFFL_INDV_ADDR" ("AFFL_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PR_RL_PT_AP
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PR_RL_PT_AP" ON "CERS_LOC_PROC_REL_PT_APPR_IDEN" ("LOC_PROC_REL_PT_APPR_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RL_PT_ID_RL_PT
--------------------------------------------------------

  CREATE INDEX "IX_RL_PT_ID_RL_PT" ON "CERS_REL_PT_IDEN" ("REL_PT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FC_STE_QLTY_IDN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FC_STE_QLTY_IDN" ON "CERS_FAC_SITE_QLTY_IDEN" ("FAC_SITE_QLTY_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RG_LC_PR
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RG_LC_PR" ON "CERS_LOC_PROC_RGLN" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RP_PR_EM
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RP_PR_EM" ON "CERS_LOC_PROC_RPT_PRD_EMIS" ("LOC_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_RP_03
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_RP_03" ON "CERS_EMS_UNT_PRC_RPT_PRD_EMS" ("EMIS_UNIT_PROC_RPT_PRD_EMIS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_IN_ID_AF_IN
--------------------------------------------------------

  CREATE INDEX "IX_AF_IN_ID_AF_IN" ON "CERS_AFFL_INDV_IDEN" ("AFFL_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PRC_RP_PR_EM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PRC_RP_PR_EM" ON "CERS_LOC_PROC_RPT_PRD_EMIS" ("LOC_PROC_RPT_PRD_EMIS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_CT_AP_02
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_CT_AP_02" ON "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RL_PT_FC_STE_ID
--------------------------------------------------------

  CREATE INDEX "IX_RL_PT_FC_STE_ID" ON "CERS_REL_PT" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_CT_AP_02
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_CT_AP_02" ON "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" ("EMIS_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RP_PR_LC
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RP_PR_LC" ON "CERS_LOC_PROC_RPT_PRD" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QL_FN_OR_IN_CM
--------------------------------------------------------

  CREATE INDEX "IX_QL_FN_OR_IN_CM" ON "CERS_QLTY_FIND_ORG_INDV_COMMUN" ("QLTY_FIND_ORG_INDV_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LOC_PROC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LOC_PROC" ON "CERS_LOC_PROC" ("LOC_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PRC_RL_PT_AP
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PRC_RL_PT_AP" ON "CERS_LOC_PROC_REL_PT_APPR" ("LOC_PROC_REL_PT_APPR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EVN_RP_PR_EV_ID
--------------------------------------------------------

  CREATE INDEX "IX_EVN_RP_PR_EV_ID" ON "CERS_EVENT_RPT_PRD" ("EVENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMS_UNT_QLT_IDN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMS_UNT_QLT_IDN" ON "CERS_EMIS_UNIT_QLTY_IDEN" ("EMIS_UNIT_QLTY_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_INDV_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_INDV_ADDR" ON "CERS_AFFL_INDV_ADDR" ("AFFL_INDV_ADDR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PR_RP_PR_QL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PR_RP_PR_QL" ON "CERS_LC_PRC_RPT_PRD_QLTY_IDN" ("LOC_PROC_RPT_PRD_QLTY_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMS_UN_PR_RP_PR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMS_UN_PR_RP_PR" ON "CERS_EMIS_UNIT_PROC_RPT_PRD" ("EMIS_UNIT_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EVENT_CERS_ID
--------------------------------------------------------

  CREATE INDEX "IX_EVENT_CERS_ID" ON "CERS_EVENT" ("CERS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AL_FC_NM_FC_ST
--------------------------------------------------------

  CREATE INDEX "IX_AL_FC_NM_FC_ST" ON "CERS_ALT_FAC_NAME" ("FAC_SITE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_AF_OR_ID_AF_OR
--------------------------------------------------------

  CREATE INDEX "IX_AF_OR_ID_AF_OR" ON "CERS_AFFL_ORG_IDEN" ("AFFL_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LOC_CERS_ID
--------------------------------------------------------

  CREATE INDEX "IX_LOC_CERS_ID" ON "CERS_LOC" ("CERS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFFL_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFL_ORG" ON "CERS_AFFL_ORG" ("AFFL_ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_LC_PRC_RPT_PRD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LC_PRC_RPT_PRD" ON "CERS_LOC_PROC_RPT_PRD" ("LOC_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EM_UN_PR_CT_AP
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EM_UN_PR_CT_AP" ON "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" ("EMS_UNT_PRC_CTRL_APC_CTR_MS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ALT_FAC_NAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ALT_FAC_NAME" ON "CERS_ALT_FAC_NAME" ("ALT_FAC_NAME_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_QLTY_FIND
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_QLTY_FIND" ON "CERS_QLTY_FIND" ("QLTY_FIND_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_QLTY_FND_CRS_ID
--------------------------------------------------------

  CREATE INDEX "IX_QLTY_FND_CRS_ID" ON "CERS_QLTY_FIND" ("CERS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EVENT_EMIS_PROC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVENT_EMIS_PROC" ON "CERS_EVENT_EMIS_PROC" ("EVENT_EMIS_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_REL_PT_IDEN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REL_PT_IDEN" ON "CERS_REL_PT_IDEN" ("REL_PT_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_AFF_ORG_IND_IDN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFF_ORG_IND_IDN" ON "CERS_AFFL_ORG_INDV_IDEN" ("AFFL_ORG_INDV_IDEN_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EXCL_LOC_PARM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EXCL_LOC_PARM" ON "CERS_EXCL_LOC_PARM" ("EXCL_LOC_PARM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_LC_PR_RP_PR_QL
--------------------------------------------------------

  CREATE INDEX "IX_LC_PR_RP_PR_QL" ON "CERS_LC_PRC_RPT_PRD_QLTY_IDN" ("LOC_PROC_RPT_PRD_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_EM_UN_PR_ID_EM
--------------------------------------------------------

  CREATE INDEX "IX_EM_UN_PR_ID_EM" ON "CERS_EMIS_UNIT_PROC_IDEN" ("EMIS_UNIT_PROC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_MRGD_EVN_EVN_ID
--------------------------------------------------------

  CREATE INDEX "IX_MRGD_EVN_EVN_ID" ON "CERS_MERGED_EVENTS" ("EVENT_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL" ADD CONSTRAINT "FK_AFFL_FAC_SITE" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_INDV
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV" ADD CONSTRAINT "FK_AFFL_INDV_AFFL" FOREIGN KEY ("AFFL_ID")
	  REFERENCES "CERS_AFFL" ("AFFL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_INDV_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV_ADDR" ADD CONSTRAINT "FK_AFF_IN_AD_AF_IN" FOREIGN KEY ("AFFL_INDV_ID")
	  REFERENCES "CERS_AFFL_INDV" ("AFFL_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_INDV_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV_COMMUN" ADD CONSTRAINT "FK_AFF_IN_CM_AF_IN" FOREIGN KEY ("AFFL_INDV_ID")
	  REFERENCES "CERS_AFFL_INDV" ("AFFL_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_INDV_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_INDV_IDEN" ADD CONSTRAINT "FK_AFF_IN_ID_AF_IN" FOREIGN KEY ("AFFL_INDV_ID")
	  REFERENCES "CERS_AFFL_INDV" ("AFFL_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG" ADD CONSTRAINT "FK_AFFL_ORG_AFFL" FOREIGN KEY ("AFFL_ID")
	  REFERENCES "CERS_AFFL" ("AFFL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_ADDR" ADD CONSTRAINT "FK_AFF_OR_AD_AF_OR" FOREIGN KEY ("AFFL_ORG_ID")
	  REFERENCES "CERS_AFFL_ORG" ("AFFL_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_COMMUN" ADD CONSTRAINT "FK_AFF_OR_CM_AF_OR" FOREIGN KEY ("AFFL_ORG_ID")
	  REFERENCES "CERS_AFFL_ORG" ("AFFL_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_IDEN" ADD CONSTRAINT "FK_AFF_OR_ID_AF_OR" FOREIGN KEY ("AFFL_ORG_ID")
	  REFERENCES "CERS_AFFL_ORG" ("AFFL_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_INDV
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV" ADD CONSTRAINT "FK_AFF_OR_IN_AF_OR" FOREIGN KEY ("AFFL_ORG_ID")
	  REFERENCES "CERS_AFFL_ORG" ("AFFL_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_INDV_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV_ADDR" ADD CONSTRAINT "FK_AF_OR_IN_AD_AF" FOREIGN KEY ("AFFL_ORG_INDV_ID")
	  REFERENCES "CERS_AFFL_ORG_INDV" ("AFFL_ORG_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_INDV_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV_COMMUN" ADD CONSTRAINT "FK_AF_OR_IN_CM_AF" FOREIGN KEY ("AFFL_ORG_INDV_ID")
	  REFERENCES "CERS_AFFL_ORG_INDV" ("AFFL_ORG_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_AFFL_ORG_INDV_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_AFFL_ORG_INDV_IDEN" ADD CONSTRAINT "FK_AF_OR_IN_ID_AF" FOREIGN KEY ("AFFL_ORG_INDV_ID")
	  REFERENCES "CERS_AFFL_ORG_INDV" ("AFFL_ORG_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_ALT_FAC_NAME
--------------------------------------------------------

  ALTER TABLE "CERS_ALT_FAC_NAME" ADD CONSTRAINT "FK_ALT_FC_NM_FC_ST" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT" ADD CONSTRAINT "FK_EMS_UNT_FC_STE" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_IDEN" ADD CONSTRAINT "FK_EMS_UN_ID_EM_UN" FOREIGN KEY ("EMIS_UNIT_ID")
	  REFERENCES "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_PROC
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC" ADD CONSTRAINT "FK_EMS_UN_PR_EM_UN" FOREIGN KEY ("EMIS_UNIT_ID")
	  REFERENCES "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_PROC_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC_IDEN" ADD CONSTRAINT "FK_EM_UN_PR_ID_EM" FOREIGN KEY ("EMIS_UNIT_PROC_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_PROC_RGLN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC_RGLN" ADD CONSTRAINT "FK_EM_UN_PR_RG_EM" FOREIGN KEY ("EMIS_UNIT_PROC_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_PROC_RPT_PRD
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_PROC_RPT_PRD" ADD CONSTRAINT "FK_EM_UN_PR_RP_PR" FOREIGN KEY ("EMIS_UNIT_PROC_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_QLTY_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_QLTY_IDEN" ADD CONSTRAINT "FK_EM_UN_QL_ID_EM" FOREIGN KEY ("EMIS_UNIT_ID")
	  REFERENCES "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMIS_UNIT_RGLN
--------------------------------------------------------

  ALTER TABLE "CERS_EMIS_UNIT_RGLN" ADD CONSTRAINT "FK_EMS_UN_RG_EM_UN" FOREIGN KEY ("EMIS_UNIT_ID")
	  REFERENCES "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_CTRL_APCH_CTRL_MS
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTRL_MS" ADD CONSTRAINT "FK_EM_UN_CT_AP_CT" FOREIGN KEY ("EMIS_UNIT_ID")
	  REFERENCES "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_CTRL_APCH_CTR_PLT
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_CTRL_APCH_CTR_PLT" ADD CONSTRAINT "FK_EM_UN_CT_AP_02" FOREIGN KEY ("EMIS_UNIT_ID")
	  REFERENCES "CERS_EMIS_UNIT" ("EMIS_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PRC_CTR_APC_CT_MS
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_MS" ADD CONSTRAINT "FK_EM_UN_PR_CT_AP" FOREIGN KEY ("EMIS_UNIT_PROC_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PRC_CTR_APC_CT_PL
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_CTR_APC_CT_PL" ADD CONSTRAINT "FK_EM_UN_PR_CT_02" FOREIGN KEY ("EMIS_UNIT_PROC_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PRC_RL_PT_APPR
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APPR" ADD CONSTRAINT "FK_EM_UN_PR_RL_PT" FOREIGN KEY ("EMIS_UNIT_PROC_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC" ("EMIS_UNIT_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PRC_RL_PT_APP_IDN
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RL_PT_APP_IDN" ADD CONSTRAINT "FK_EM_UN_PR_RL_02" FOREIGN KEY ("EMIS_UNIT_PROC_REL_PT_APPR_ID")
	  REFERENCES "CERS_EMS_UNT_PRC_RL_PT_APPR" ("EMIS_UNIT_PROC_REL_PT_APPR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PRC_RPT_PRD_EMS
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_EMS" ADD CONSTRAINT "FK_EM_UN_PR_RP_04" FOREIGN KEY ("EMIS_UNIT_PROC_RPT_PRD_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC_RPT_PRD" ("EMIS_UNIT_PROC_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PRC_RPT_PRD_QL_ID
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PRC_RPT_PRD_QL_ID" ADD CONSTRAINT "FK_EM_UN_PR_RP_02" FOREIGN KEY ("EMIS_UNIT_PROC_RPT_PRD_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC_RPT_PRD" ("EMIS_UNIT_PROC_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EMS_UNT_PR_RP_PR_SP_CL_PR
--------------------------------------------------------

  ALTER TABLE "CERS_EMS_UNT_PR_RP_PR_SP_CL_PR" ADD CONSTRAINT "FK_EM_UN_PR_RP_03" FOREIGN KEY ("EMIS_UNIT_PROC_RPT_PRD_ID")
	  REFERENCES "CERS_EMIS_UNIT_PROC_RPT_PRD" ("EMIS_UNIT_PROC_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EVENT
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT" ADD CONSTRAINT "FK_EVENT_CERS" FOREIGN KEY ("CERS_ID")
	  REFERENCES "CERS_CERS" ("CERS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EVENT_EMIS_EMIS
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_EMIS_EMIS" ADD CONSTRAINT "FK_EV_EM_EM_EV_EM" FOREIGN KEY ("EVENT_EMIS_PROC_ID")
	  REFERENCES "CERS_EVENT_EMIS_PROC" ("EVENT_EMIS_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EVENT_EMIS_PROC
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_EMIS_PROC" ADD CONSTRAINT "FK_EVN_EM_PR_EV_LC" FOREIGN KEY ("EVENT_LOC_ID")
	  REFERENCES "CERS_EVENT_LOC" ("EVENT_LOC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EVENT_LOC
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_LOC" ADD CONSTRAINT "FK_EVN_LC_EV_RP_PR" FOREIGN KEY ("EVENT_RPT_PRD_ID")
	  REFERENCES "CERS_EVENT_RPT_PRD" ("EVENT_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EVENT_RPT_PRD
--------------------------------------------------------

  ALTER TABLE "CERS_EVENT_RPT_PRD" ADD CONSTRAINT "FK_EVN_RPT_PRD_EVN" FOREIGN KEY ("EVENT_ID")
	  REFERENCES "CERS_EVENT" ("EVENT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_EXCL_LOC_PARM
--------------------------------------------------------

  ALTER TABLE "CERS_EXCL_LOC_PARM" ADD CONSTRAINT "FK_EXCL_LC_PRM_LC" FOREIGN KEY ("LOC_ID")
	  REFERENCES "CERS_LOC" ("LOC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_FAC_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_IDEN" ADD CONSTRAINT "FK_FC_IDN_FC_STE" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_FAC_NAICS
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_NAICS" ADD CONSTRAINT "FK_FC_NCS_FC_STE" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_FAC_SITE
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_SITE" ADD CONSTRAINT "FK_FAC_SITE_CERS" FOREIGN KEY ("CERS_ID")
	  REFERENCES "CERS_CERS" ("CERS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_FAC_SITE_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_SITE_ADDR" ADD CONSTRAINT "FK_FC_STE_AD_FC_ST" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_FAC_SITE_QLTY_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_FAC_SITE_QLTY_IDEN" ADD CONSTRAINT "FK_FC_ST_QL_ID_FC" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_GEOSPATIAL_PARAMS
--------------------------------------------------------

  ALTER TABLE "CERS_GEOSPATIAL_PARAMS" ADD CONSTRAINT "FK_GSPT_PRM_EVN_LC" FOREIGN KEY ("EVENT_LOC_ID")
	  REFERENCES "CERS_EVENT_LOC" ("EVENT_LOC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LC_PRC_CTRL_APCH_CTRL_MS
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_MS" ADD CONSTRAINT "FK_LC_PR_CT_AP_CT" FOREIGN KEY ("LOC_PROC_ID")
	  REFERENCES "CERS_LOC_PROC" ("LOC_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LC_PRC_CTRL_APCH_CTRL_PLT
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_CTRL_APCH_CTRL_PLT" ADD CONSTRAINT "FK_LC_PR_CT_AP_02" FOREIGN KEY ("LOC_PROC_ID")
	  REFERENCES "CERS_LOC_PROC" ("LOC_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LC_PRC_RPT_PRD_QLTY_IDN
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_RPT_PRD_QLTY_IDN" ADD CONSTRAINT "FK_LC_PR_RP_PR_QL" FOREIGN KEY ("LOC_PROC_RPT_PRD_ID")
	  REFERENCES "CERS_LOC_PROC_RPT_PRD" ("LOC_PROC_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LC_PRC_RPT_PRD_SPP_CLC_PR
--------------------------------------------------------

  ALTER TABLE "CERS_LC_PRC_RPT_PRD_SPP_CLC_PR" ADD CONSTRAINT "FK_LC_PR_RP_PR_SP" FOREIGN KEY ("LOC_PROC_RPT_PRD_ID")
	  REFERENCES "CERS_LOC_PROC_RPT_PRD" ("LOC_PROC_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC
--------------------------------------------------------

  ALTER TABLE "CERS_LOC" ADD CONSTRAINT "FK_LOC_CERS" FOREIGN KEY ("CERS_ID")
	  REFERENCES "CERS_CERS" ("CERS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC" ADD CONSTRAINT "FK_LOC_PROC_LOC" FOREIGN KEY ("LOC_ID")
	  REFERENCES "CERS_LOC" ("LOC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_IDEN" ADD CONSTRAINT "FK_LC_PRC_ID_LC_PR" FOREIGN KEY ("LOC_PROC_ID")
	  REFERENCES "CERS_LOC_PROC" ("LOC_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC_REL_PT_APPR
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR" ADD CONSTRAINT "FK_LC_PR_RL_PT_AP" FOREIGN KEY ("LOC_PROC_ID")
	  REFERENCES "CERS_LOC_PROC" ("LOC_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC_REL_PT_APPR_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_REL_PT_APPR_IDEN" ADD CONSTRAINT "FK_LC_PR_RL_PT_02" FOREIGN KEY ("LOC_PROC_REL_PT_APPR_ID")
	  REFERENCES "CERS_LOC_PROC_REL_PT_APPR" ("LOC_PROC_REL_PT_APPR_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC_RGLN
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_RGLN" ADD CONSTRAINT "FK_LC_PRC_RG_LC_PR" FOREIGN KEY ("LOC_PROC_ID")
	  REFERENCES "CERS_LOC_PROC" ("LOC_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC_RPT_PRD
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_RPT_PRD" ADD CONSTRAINT "FK_LC_PR_RP_PR_LC" FOREIGN KEY ("LOC_PROC_ID")
	  REFERENCES "CERS_LOC_PROC" ("LOC_PROC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_LOC_PROC_RPT_PRD_EMIS
--------------------------------------------------------

  ALTER TABLE "CERS_LOC_PROC_RPT_PRD_EMIS" ADD CONSTRAINT "FK_LC_PR_RP_PR_EM" FOREIGN KEY ("LOC_PROC_RPT_PRD_ID")
	  REFERENCES "CERS_LOC_PROC_RPT_PRD" ("LOC_PROC_RPT_PRD_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_MERGED_EVENTS
--------------------------------------------------------

  ALTER TABLE "CERS_MERGED_EVENTS" ADD CONSTRAINT "FK_MRGD_EVNTS_EVNT" FOREIGN KEY ("EVENT_ID")
	  REFERENCES "CERS_EVENT" ("EVENT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND" ADD CONSTRAINT "FK_QLTY_FIND_CERS" FOREIGN KEY ("CERS_ID")
	  REFERENCES "CERS_CERS" ("CERS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG" ADD CONSTRAINT "FK_QLT_FN_OR_QL_FN" FOREIGN KEY ("QLTY_FIND_ID")
	  REFERENCES "CERS_QLTY_FIND" ("QLTY_FIND_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_ADDR" ADD CONSTRAINT "FK_QL_FN_OR_AD_QL" FOREIGN KEY ("QLTY_FIND_ORG_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG" ("QLTY_FIND_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_COMMUN" ADD CONSTRAINT "FK_QL_FN_OR_CM_QL" FOREIGN KEY ("QLTY_FIND_ORG_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG" ("QLTY_FIND_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_IDEN" ADD CONSTRAINT "FK_QL_FN_OR_ID_QL" FOREIGN KEY ("QLTY_FIND_ORG_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG" ("QLTY_FIND_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_INDV
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV" ADD CONSTRAINT "FK_QL_FN_OR_IN_QL" FOREIGN KEY ("QLTY_FIND_ORG_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG" ("QLTY_FIND_ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_INDV_ADDR
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_ADDR" ADD CONSTRAINT "FK_QL_FN_OR_IN_AD" FOREIGN KEY ("QLTY_FIND_ORG_INDV_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG_INDV" ("QLTY_FIND_ORG_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_INDV_COMMUN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_COMMUN" ADD CONSTRAINT "FK_QL_FN_OR_IN_CM" FOREIGN KEY ("QLTY_FIND_ORG_INDV_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG_INDV" ("QLTY_FIND_ORG_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_QLTY_FIND_ORG_INDV_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_QLTY_FIND_ORG_INDV_IDEN" ADD CONSTRAINT "FK_QL_FN_OR_IN_ID" FOREIGN KEY ("QLTY_FIND_ORG_INDV_ID")
	  REFERENCES "CERS_QLTY_FIND_ORG_INDV" ("QLTY_FIND_ORG_INDV_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_REL_PT
--------------------------------------------------------

  ALTER TABLE "CERS_REL_PT" ADD CONSTRAINT "FK_REL_PT_FAC_SITE" FOREIGN KEY ("FAC_SITE_ID")
	  REFERENCES "CERS_FAC_SITE" ("FAC_SITE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_REL_PT_IDEN
--------------------------------------------------------

  ALTER TABLE "CERS_REL_PT_IDEN" ADD CONSTRAINT "FK_RL_PT_IDN_RL_PT" FOREIGN KEY ("REL_PT_ID")
	  REFERENCES "CERS_REL_PT" ("REL_PT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table CERS_REL_PT_TST
--------------------------------------------------------

  ALTER TABLE "CERS_REL_PT_TST" ADD CONSTRAINT "FK_RL_PT_TST_RL_PT" FOREIGN KEY ("REL_PT_ID")
	  REFERENCES "CERS_REL_PT" ("REL_PT_ID") ON DELETE CASCADE ENABLE;
