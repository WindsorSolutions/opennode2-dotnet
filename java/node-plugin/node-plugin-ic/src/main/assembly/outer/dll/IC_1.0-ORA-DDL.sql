--------------------------------------------------------
--  File created - Monday-August-12-2013   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table IC_AFFIL
--------------------------------------------------------

  CREATE TABLE "IC_AFFIL" 
   (	"IC_AFFIL_ID" VARCHAR2(36 BYTE), 
	"IC_INSTL_CTRLS_DOC_ID" VARCHAR2(36 BYTE), 
	"AFFIL_IDEN" VARCHAR2(50 BYTE), 
	"MAILING_ADDR_TXT" VARCHAR2(255 BYTE), 
	"SUPPL_ADDR_TXT" VARCHAR2(255 BYTE), 
	"MAILING_ADDR_CITY_NAME" VARCHAR2(50 BYTE), 
	"ST_CODE" VARCHAR2(50 BYTE), 
	"ST_NAME" VARCHAR2(50 BYTE), 
	"ST_LST_IDEN" VARCHAR2(50 BYTE), 
	"ST_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"ST_LST_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"ADDR_POSTAL_CODE_CNTXT" VARCHAR2(50 BYTE), 
	"ADDR_POSTAL_CODE_VALUE" VARCHAR2(25 BYTE), 
	"CNTRY_CODE" VARCHAR2(50 BYTE), 
	"CNTRY_NAME" VARCHAR2(50 BYTE), 
	"CNTRY_LST_IDEN" VARCHAR2(50 BYTE), 
	"CNTRY_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"CNTRY_LST_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"INDVL_TITLE_TXT" VARCHAR2(50 BYTE), 
	"NAME_PREFIX_TXT" VARCHAR2(50 BYTE), 
	"NAME_SUFFIX_TXT" VARCHAR2(50 BYTE), 
	"FIRST_NAME" VARCHAR2(50 BYTE), 
	"INDVL_FULL_NAME" VARCHAR2(100 BYTE), 
	"LAST_NAME" VARCHAR2(50 BYTE), 
	"MIDDLE_NAME" VARCHAR2(50 BYTE), 
	"INDVL_IDEN_CNTXT" VARCHAR2(50 BYTE), 
	"INDVL_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"ORG_FRML_NAME" VARCHAR2(255 BYTE), 
	"ORG_IDEN_CNTXT" VARCHAR2(50 BYTE), 
	"ORG_IDEN_VALUE" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_AFFIL"."AFFIL_IDEN" IS 'A unique identifier prescribed to a person or organization. (AffiliateIdentifier)';
 
   COMMENT ON COLUMN "IC_AFFIL"."MAILING_ADDR_TXT" IS 'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)';
 
   COMMENT ON COLUMN "IC_AFFIL"."SUPPL_ADDR_TXT" IS 'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "IC_AFFIL"."MAILING_ADDR_CITY_NAME" IS 'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "IC_AFFIL"."ST_CODE" IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)';
 
   COMMENT ON COLUMN "IC_AFFIL"."ST_NAME" IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)';
 
   COMMENT ON COLUMN "IC_AFFIL"."ST_LST_IDEN" IS 'StateCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_AFFIL"."ST_LST_AGCY_IDEN" IS 'StateCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_AFFIL"."ST_LST_IDEN_VALUE" IS 'StateCodeListIdentifierValue';
 
   COMMENT ON COLUMN "IC_AFFIL"."ADDR_POSTAL_CODE_CNTXT" IS 'AddressPostalCodeContext';
 
   COMMENT ON COLUMN "IC_AFFIL"."ADDR_POSTAL_CODE_VALUE" IS 'AddressPostalCodeValue';
 
   COMMENT ON COLUMN "IC_AFFIL"."CNTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)';
 
   COMMENT ON COLUMN "IC_AFFIL"."CNTRY_NAME" IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)';
 
   COMMENT ON COLUMN "IC_AFFIL"."CNTRY_LST_IDEN" IS 'CountryCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_AFFIL"."CNTRY_LST_AGCY_IDEN" IS 'CountryCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_AFFIL"."CNTRY_LST_IDEN_VALUE" IS 'CountryCodeListIdentifierValue';
 
   COMMENT ON COLUMN "IC_AFFIL"."INDVL_TITLE_TXT" IS 'The title held by a person in an organization. (IndividualTitleText)';
 
   COMMENT ON COLUMN "IC_AFFIL"."NAME_PREFIX_TXT" IS 'The text that describes the title that precedes an individual''s name. (NamePrefixText)';
 
   COMMENT ON COLUMN "IC_AFFIL"."NAME_SUFFIX_TXT" IS 'Additional title that indicates lineage or professional title. (NameSuffixText)';
 
   COMMENT ON COLUMN "IC_AFFIL"."FIRST_NAME" IS 'FirstName';
 
   COMMENT ON COLUMN "IC_AFFIL"."INDVL_FULL_NAME" IS 'IndividualFullName';
 
   COMMENT ON COLUMN "IC_AFFIL"."LAST_NAME" IS 'LastName';
 
   COMMENT ON COLUMN "IC_AFFIL"."MIDDLE_NAME" IS 'MiddleName';
 
   COMMENT ON COLUMN "IC_AFFIL"."INDVL_IDEN_CNTXT" IS 'IndividualIdentifierContext';
 
   COMMENT ON COLUMN "IC_AFFIL"."INDVL_IDEN_VALUE" IS 'IndividualIdentifierValue';
 
   COMMENT ON COLUMN "IC_AFFIL"."ORG_FRML_NAME" IS 'The legal designator (i.e. formal name) of an organization. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "IC_AFFIL"."ORG_IDEN_CNTXT" IS 'OrganizationIdentifierContext';
 
   COMMENT ON COLUMN "IC_AFFIL"."ORG_IDEN_VALUE" IS 'OrganizationIdentifierValue';
 
   COMMENT ON TABLE "IC_AFFIL"  IS 'Schema element: Affiliate';
/
--------------------------------------------------------
--  DDL for Table IC_AFFIL_TYPE
--------------------------------------------------------

  CREATE TABLE "IC_AFFIL_TYPE" 
   (	"IC_AFFIL_TYPE_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_AFFIL_ID" VARCHAR2(36 BYTE), 
	"IC_EVT_AFFIL_ID" VARCHAR2(36 BYTE), 
	"AFFIL_CODE" VARCHAR2(10 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_AFFIL_TYPE"."AFFIL_CODE" IS 'The type of affiliation between a person or organization and an IC Instrument or Event. (AffiliationTypeCode)';
 
   COMMENT ON TABLE "IC_AFFIL_TYPE"  IS 'Schema element: AffiliationTypeCode';
/
--------------------------------------------------------
--  DDL for Table IC_CNTMT
--------------------------------------------------------

  CREATE TABLE "IC_CNTMT" 
   (	"IC_CNTMT_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"CHEM_CATG_CODE" VARCHAR2(39 BYTE), 
	"OTHR_CHEM_CATG_TXT" VARCHAR2(255 BYTE), 
	"CAS_REG_NUM" VARCHAR2(20 BYTE), 
	"CHEM_SUBST_DEF_TXT" VARCHAR2(255 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_CNTMT"."CHEM_CATG_CODE" IS 'A category that characterizes the type of chemical substance. (ChemicalCategoryCode)';
 
   COMMENT ON COLUMN "IC_CNTMT"."OTHR_CHEM_CATG_TXT" IS 'A text description of the chemical category when "Other" is selected for the Chemical Category Code. (OtherChemicalCategoryText)';
 
   COMMENT ON COLUMN "IC_CNTMT"."CAS_REG_NUM" IS 'The unique number assigned by Chemical Abstracts Service (CAS) to a chemical substance. (CASRegistryNumber)';
 
   COMMENT ON COLUMN "IC_CNTMT"."CHEM_SUBST_DEF_TXT" IS 'The text that provides clarification to the identity of a chemical substance. (ChemicalSubstanceDefinitionText)';
 
   COMMENT ON TABLE "IC_CNTMT"  IS 'Schema element: Contaminant';
/
--------------------------------------------------------
--  DDL for Table IC_ELEC_ADDR
--------------------------------------------------------

  CREATE TABLE "IC_ELEC_ADDR" 
   (	"IC_ELEC_ADDR_ID" VARCHAR2(36 BYTE), 
	"IC_AFFIL_ID" VARCHAR2(36 BYTE), 
	"ELEC_ADDR_TXT" VARCHAR2(255 BYTE), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(8 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_ELEC_ADDR"."ELEC_ADDR_TXT" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "IC_ELEC_ADDR"."ELEC_ADDR_TYPE_NAME" IS 'The name that describes the electronic address type. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "IC_ELEC_ADDR"  IS 'Schema element: ElectronicAddress';
/
--------------------------------------------------------
--  DDL for Table IC_ENGR_CTRL
--------------------------------------------------------

  CREATE TABLE "IC_ENGR_CTRL" 
   (	"IC_ENGR_CTRL_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"ENGR_CTRL_NAME" VARCHAR2(50 BYTE), 
	"ENGR_CTRL_DESC_TXT" VARCHAR2(255 BYTE), 
	"ENGR_CTRL_CODE" VARCHAR2(27 BYTE), 
	"OTHR_ENGR_CTRL_TYPE_TXT" VARCHAR2(255 BYTE), 
	"ENGR_CTRL_MODE_CODE" VARCHAR2(7 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_ENGR_CTRL"."ENGR_CTRL_NAME" IS 'The name assigned to a physical technology implemented to minimize the potential for human exposure to contamination by means of control or remediation. (EngineeringControlName)';
 
   COMMENT ON COLUMN "IC_ENGR_CTRL"."ENGR_CTRL_DESC_TXT" IS 'A description of the engineering control. (EngineeringControlDescriptionText)';
 
   COMMENT ON COLUMN "IC_ENGR_CTRL"."ENGR_CTRL_CODE" IS 'The type of engineering control. (EngineeringControlTypeCode)';
 
   COMMENT ON COLUMN "IC_ENGR_CTRL"."OTHR_ENGR_CTRL_TYPE_TXT" IS 'A text description of the engineering control type when "Other" is selected for the Engineering Control Type Code. (OtherEngineeringControlTypeText)';
 
   COMMENT ON COLUMN "IC_ENGR_CTRL"."ENGR_CTRL_MODE_CODE" IS 'Indicates whether an engineering control is an active or passive system. (EngineeringControlModeCode)';
 
   COMMENT ON TABLE "IC_ENGR_CTRL"  IS 'Schema element: EngineeringControl';
/
--------------------------------------------------------
--  DDL for Table IC_ENGR_CTRL_LOC
--------------------------------------------------------

  CREATE TABLE "IC_ENGR_CTRL_LOC" 
   (	"IC_ENGR_CTRL_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_ENGR_CTRL_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_ENGR_CTRL_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_ENGR_CTRL_LOC"  IS 'Schema element: EngineeringControlLocation';
/
--------------------------------------------------------
--  DDL for Table IC_EVT
--------------------------------------------------------

  CREATE TABLE "IC_EVT" 
   (	"IC_EVT_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"EVT_NAME" VARCHAR2(128 BYTE), 
	"EVT_CODE" VARCHAR2(31 BYTE), 
	"OTHR_EVT_TYPE_TXT" VARCHAR2(255 BYTE), 
	"EVT_DESC_TXT" VARCHAR2(255 BYTE), 
	"EVT_START_DATE" TIMESTAMP (6), 
	"EVT_START_TIME" TIMESTAMP (6), 
	"EVT_END_DATE" TIMESTAMP (6), 
	"EVT_END_TIME" TIMESTAMP (6), 
	"EVT_DATE_QUAL_CODE" VARCHAR2(7 BYTE), 
	"EVT_STAT_TXT" VARCHAR2(50 BYTE), 
	"RECR_EVT_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_EVT"."EVT_NAME" IS 'The name given to an occurrence or action taking place on a specific date or over a period of time. (EventName)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_CODE" IS 'The type of occurrence or action taking place on a specific date or overa period of time. (EventTypeCode)';
 
   COMMENT ON COLUMN "IC_EVT"."OTHR_EVT_TYPE_TXT" IS 'A text description of the event type when "Other" is selected for the Event Type Code. (OtherEventTypeText)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_DESC_TXT" IS 'A text description of the event. (EventDescriptionText)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_START_DATE" IS 'The date an event started or is planned to start. (EventStartDate)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_START_TIME" IS 'The time of day an event started or is planned to start. (EventStartTime)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_END_DATE" IS 'The date an event ended or is planned to end. (EventEndDate)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_END_TIME" IS 'The time of day an event ended or is planned to end. (EventEndTime)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_DATE_QUAL_CODE" IS 'The qualifier that specifies the meaning of the date that the event has taken or will take place. (EventDateQualifierCode)';
 
   COMMENT ON COLUMN "IC_EVT"."EVT_STAT_TXT" IS 'An attribute for describing the status of the event. (EventStatusText)';
 
   COMMENT ON COLUMN "IC_EVT"."RECR_EVT_IDEN" IS 'A unique identifier assigned to a recurring event. (RecurringEventIdentifier)';
 
   COMMENT ON TABLE "IC_EVT"  IS 'Schema element: Event';
/
--------------------------------------------------------
--  DDL for Table IC_EVT_AFFIL
--------------------------------------------------------

  CREATE TABLE "IC_EVT_AFFIL" 
   (	"IC_EVT_AFFIL_ID" VARCHAR2(36 BYTE), 
	"IC_EVT_ID" VARCHAR2(36 BYTE), 
	"AFFIL_IDEN" VARCHAR2(50 BYTE), 
	"OTHR_AFFIL_TYPE_TXT" VARCHAR2(255 BYTE), 
	"AFFIL_START_DATE" TIMESTAMP (6), 
	"AFFIL_END_DATE" TIMESTAMP (6)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_EVT_AFFIL"."AFFIL_IDEN" IS 'A unique identifier prescribed to a person or organization. (AffiliateIdentifier)';
 
   COMMENT ON COLUMN "IC_EVT_AFFIL"."OTHR_AFFIL_TYPE_TXT" IS 'A text description of the affiliation type when "Other" is selected for the Affiliation Type Code. (OtherAffiliationTypeText)';
 
   COMMENT ON COLUMN "IC_EVT_AFFIL"."AFFIL_START_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)';
 
   COMMENT ON COLUMN "IC_EVT_AFFIL"."AFFIL_END_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)';
 
   COMMENT ON TABLE "IC_EVT_AFFIL"  IS 'Schema element: EventAffiliate';
/
--------------------------------------------------------
--  DDL for Table IC_EVT_LOC
--------------------------------------------------------

  CREATE TABLE "IC_EVT_LOC" 
   (	"IC_EVT_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_EVT_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_EVT_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_EVT_LOC"  IS 'Schema element: EventLocation';
/
--------------------------------------------------------
--  DDL for Table IC_FAC
--------------------------------------------------------

  CREATE TABLE "IC_FAC" 
   (	"IC_FAC_ID" VARCHAR2(36 BYTE), 
	"IC_LOC_ID" VARCHAR2(36 BYTE), 
	"FAC_SITE_NAME" VARCHAR2(128 BYTE), 
	"FEDR_FAC_IND" CHAR(1 BYTE), 
	"FAC_SITE_IDEN_CNTXT" VARCHAR2(255 BYTE), 
	"FAC_SITE_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"FAC_SITE_CODE" VARCHAR2(50 BYTE), 
	"FAC_SITE_TYPE_NAME" VARCHAR2(128 BYTE), 
	"FAC_SITE_LST_IDEN" VARCHAR2(50 BYTE), 
	"FAC_SITE_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"FAC_SITE_LST_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"LOC_ADDR_TXT" VARCHAR2(255 BYTE), 
	"SUPPL_LOC_TXT" VARCHAR2(255 BYTE), 
	"LOCALITY_NAME" VARCHAR2(128 BYTE), 
	"TRIBAL_LAND_NAME" VARCHAR2(128 BYTE), 
	"TRIBAL_LAND_IND" CHAR(1 BYTE), 
	"LOC_DESC_TXT" VARCHAR2(255 BYTE), 
	"ST_CODE" VARCHAR2(50 BYTE), 
	"ST_NAME" VARCHAR2(50 BYTE), 
	"ST_LST_IDEN" VARCHAR2(50 BYTE), 
	"ST_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"ST_LST_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"ADDR_POSTAL_CODE_CNTXT" VARCHAR2(50 BYTE), 
	"ADDR_POSTAL_CODE_VALUE" VARCHAR2(25 BYTE), 
	"CNTRY_CODE" VARCHAR2(50 BYTE), 
	"CNTRY_NAME" VARCHAR2(50 BYTE), 
	"CNTRY_LST_IDEN" VARCHAR2(50 BYTE), 
	"CNTRY_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"CNTRY_LST_IDEN_VALUE" VARCHAR2(50 BYTE), 
	"CNTY_CODE" VARCHAR2(50 BYTE), 
	"CNTY_NAME" VARCHAR2(50 BYTE), 
	"CNTY_LST_IDEN" VARCHAR2(50 BYTE), 
	"CNTY_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"CNTY_LST_IDEN_VALUE" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_NAME" IS 'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)';
 
   COMMENT ON COLUMN "IC_FAC"."FEDR_FAC_IND" IS 'An indicator identifying facilities owned or operated by a federal government unit. (FederalFacilityIndicator)';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_IDEN_CNTXT" IS 'FacilitySiteIdentifierContext';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_IDEN_VALUE" IS 'FacilitySiteIdentifierValue';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_CODE" IS 'The code that represents the type of site a facility occupies. (FacilitySiteTypeCode)';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_TYPE_NAME" IS 'The descriptive name for the type of site the facility occupies. (FacilitySiteTypeName)';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_LST_IDEN" IS 'FacilitySiteTypeCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_LST_AGCY_IDEN" IS 'FacilitySiteTypeCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."FAC_SITE_LST_IDEN_VALUE" IS 'FacilitySiteTypeCodeListIdentifierValue';
 
   COMMENT ON COLUMN "IC_FAC"."LOC_ADDR_TXT" IS 'The address that describes the physical (geographic) location of the front door or main entrance of a facility site, including urban-style street address or rural address. (LocationAddressText)';
 
   COMMENT ON COLUMN "IC_FAC"."SUPPL_LOC_TXT" IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name or descriptive text where no formal address is available. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "IC_FAC"."LOCALITY_NAME" IS 'The name of a city, town, village or other locality. (LocalityName)';
 
   COMMENT ON COLUMN "IC_FAC"."TRIBAL_LAND_NAME" IS 'The name of an American Indian or Alaskan native area where the location address exists. (TribalLandName)';
 
   COMMENT ON COLUMN "IC_FAC"."TRIBAL_LAND_IND" IS 'An indicator denoting the location address is a tribal land (TribalLandIndicator)';
 
   COMMENT ON COLUMN "IC_FAC"."LOC_DESC_TXT" IS 'A brief explanation of a location, including navigational directions and/or more descriptive information. (LocationDescriptionText)';
 
   COMMENT ON COLUMN "IC_FAC"."ST_CODE" IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)';
 
   COMMENT ON COLUMN "IC_FAC"."ST_NAME" IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)';
 
   COMMENT ON COLUMN "IC_FAC"."ST_LST_IDEN" IS 'StateCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."ST_LST_AGCY_IDEN" IS 'StateCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."ST_LST_IDEN_VALUE" IS 'StateCodeListIdentifierValue';
 
   COMMENT ON COLUMN "IC_FAC"."ADDR_POSTAL_CODE_CNTXT" IS 'AddressPostalCodeContext';
 
   COMMENT ON COLUMN "IC_FAC"."ADDR_POSTAL_CODE_VALUE" IS 'AddressPostalCodeValue';
 
   COMMENT ON COLUMN "IC_FAC"."CNTRY_CODE" IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)';
 
   COMMENT ON COLUMN "IC_FAC"."CNTRY_NAME" IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)';
 
   COMMENT ON COLUMN "IC_FAC"."CNTRY_LST_IDEN" IS 'CountryCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."CNTRY_LST_AGCY_IDEN" IS 'CountryCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."CNTRY_LST_IDEN_VALUE" IS 'CountryCodeListIdentifierValue';
 
   COMMENT ON COLUMN "IC_FAC"."CNTY_CODE" IS 'The code that represents the county. (CountyCode)';
 
   COMMENT ON COLUMN "IC_FAC"."CNTY_NAME" IS 'A description of the county code. (CountyName)';
 
   COMMENT ON COLUMN "IC_FAC"."CNTY_LST_IDEN" IS 'CountyCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."CNTY_LST_AGCY_IDEN" IS 'CountyCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_FAC"."CNTY_LST_IDEN_VALUE" IS 'CountyCodeListIdentifierValue';
 
   COMMENT ON TABLE "IC_FAC"  IS 'Schema element: FacilityDataType';
/
--------------------------------------------------------
--  DDL for Table IC_GEO_LOC_DESC
--------------------------------------------------------

  CREATE TABLE "IC_GEO_LOC_DESC" 
   (	"IC_GEO_LOC_DESC_ID" VARCHAR2(36 BYTE), 
	"IC_LOC_ID" VARCHAR2(36 BYTE), 
	"SRC_MAP_SCALE_NUM" NUMBER(10,0), 
	"DATA_COLL_DATE" TIMESTAMP (6), 
	"LOC_CMNTS_TXT" VARCHAR2(255 BYTE), 
	"SRS_NAME" VARCHAR2(255 BYTE), 
	"SRS_DIMENSION" NUMBER(10,0), 
	"PT_LAT" NUMBER(19,14), 
	"PT_LON" NUMBER(19,14), 
	"ENVELOPE_UPPER_LAT" NUMBER(19,14), 
	"ENVELOPE_UPPER_LON" NUMBER(19,14), 
	"ENVELOPE_LOWER_LAT" NUMBER(19,14), 
	"ENVELOPE_LOWER_LON" NUMBER(19,14), 
	"LINE_START_LAT" NUMBER(19,14), 
	"LINE_START_LON" NUMBER(19,14), 
	"LINE_END_LAT" NUMBER(19,14), 
	"LINE_END_LON" NUMBER(19,14), 
	"HORZ_MEAS_VALUE" VARCHAR2(50 BYTE), 
	"HORZ_MEAS_PRECISION_TXT" VARCHAR2(50 BYTE), 
	"HORZ_MEAS_UNIT_CODE" VARCHAR2(50 BYTE), 
	"HORZ_MEAS_UNIT_NAME" VARCHAR2(50 BYTE), 
	"HORZ_MEAS_UNIT_LST_IDEN" VARCHAR2(50 BYTE), 
	"HORZ_MEAS_UNIT_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"HORZ_MEAS_UNIT_VALUE" VARCHAR2(50 BYTE), 
	"HORZ_RSLT_QUAL_CODE" VARCHAR2(50 BYTE), 
	"HORZ_RSLT_QUAL_NAME" VARCHAR2(128 BYTE), 
	"HORZ_LST_VERS_IDEN" VARCHAR2(50 BYTE), 
	"HORZ_LST_VERS_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"HORZ_RSLT_QUAL_VALUE" VARCHAR2(50 BYTE), 
	"HORZ_COLL_METH_IDEN_CODE" VARCHAR2(50 BYTE), 
	"HORZ_COLL_METH_NAME" VARCHAR2(128 BYTE), 
	"HORZ_COLL_METH_DESC_TXT" VARCHAR2(255 BYTE), 
	"HORZ_COLL_METH_DEVIATIONS_TXT" VARCHAR2(255 BYTE), 
	"HORZ_COLL_METH_LST_IDEN" VARCHAR2(50 BYTE), 
	"HORZ_COLL_METH_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"HORZ_COLL_METH_VALUE" VARCHAR2(50 BYTE), 
	"GEO_REF_PT_CODE" VARCHAR2(50 BYTE), 
	"GEO_REF_PT_NAME" VARCHAR2(128 BYTE), 
	"GEO_REF_PT_LST_IDEN" VARCHAR2(50 BYTE), 
	"GEO_REF_PT_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"GEO_REF_PT_VALUE" VARCHAR2(50 BYTE), 
	"VERT_COLL_METH_IDEN_CODE" VARCHAR2(50 BYTE), 
	"VERT_COLL_METH_NAME" VARCHAR2(128 BYTE), 
	"VERT_COLL_METH_DESC_TXT" VARCHAR2(255 BYTE), 
	"VERT_COLL_METH_DEVIATIONS_TXT" VARCHAR2(255 BYTE), 
	"VERT_COLL_METH_LST_IDEN" VARCHAR2(50 BYTE), 
	"VERT_COLL_METH_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"VERT_COLL_METH_VALUE" VARCHAR2(50 BYTE), 
	"VERIF_METH_IDEN_CODE" VARCHAR2(50 BYTE), 
	"VERIF_METH_NAME" VARCHAR2(128 BYTE), 
	"VERIF_METH_DESC_TXT" VARCHAR2(255 BYTE), 
	"VERIF_METH_DEVIATIONS_TXT" VARCHAR2(255 BYTE), 
	"VERIF_METH_LST_IDEN" VARCHAR2(50 BYTE), 
	"VERIF_METH_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"VERIF_METH_VALUE" VARCHAR2(50 BYTE), 
	"COORD_DATA_SRC_CODE" VARCHAR2(50 BYTE), 
	"COORD_DATA_SRC_NAME" VARCHAR2(128 BYTE), 
	"COORD_DATA_SRC_LST_IDEN" VARCHAR2(50 BYTE), 
	"COORD_DATA_SRC_LST_AGCY_IDEN" VARCHAR2(50 BYTE), 
	"COORD_DATA_SRC_VALUE" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."DATA_COLL_DATE" IS 'The calendar date when data were collected. (DataCollectionDate)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."LOC_CMNTS_TXT" IS 'The text that provides additional information about the geographic coordinates. (LocationCommentsText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."SRS_NAME" IS 'srsName';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."SRS_DIMENSION" IS 'srsDimension';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."PT_LAT" IS 'PointLatitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."PT_LON" IS 'PointLongitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."ENVELOPE_UPPER_LAT" IS 'EnvelopeUpperLatitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."ENVELOPE_UPPER_LON" IS 'EnvelopeUpperLongitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."ENVELOPE_LOWER_LAT" IS 'EnvelopeLowerLatitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."ENVELOPE_LOWER_LON" IS 'EnvelopeLowerLongitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."LINE_START_LAT" IS 'LineStartLatitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."LINE_START_LON" IS 'LineStartLongitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."LINE_END_LAT" IS 'LineEndLatitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."LINE_END_LON" IS 'LineEndLongitude';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_VALUE" IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (HorizontalAccuracyMeasureValue)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_PRECISION_TXT" IS 'The precision of the recorded value. (HorizontalAccuracyMeasurePrecisionText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_UNIT_CODE" IS 'The code that represents the unit for measuring the item. (HorizontalAccuracyMeasureUnitCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_UNIT_NAME" IS 'A description of the unit of measure code. (HorizontalAccuracyMeasureUnitName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_UNIT_LST_IDEN" IS 'HorizontalAccuracyMeasureUnitCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_UNIT_LST_AGCY_IDEN" IS 'HorizontalAccuracyMeasureUnitCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_MEAS_UNIT_VALUE" IS 'HorizontalAccuracyMeasureUnitValue';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_RSLT_QUAL_CODE" IS 'A code used to identify any qualifying issues that affect the results. (HorizontalAccuracyResultQualifierCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_RSLT_QUAL_NAME" IS 'A description of the result code of any qualifying issues that affect the results. (HorizontalAccuracyResultQualifierName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_LST_VERS_IDEN" IS 'HorizontalAccuracyResultQualifierCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_LST_VERS_AGCY_IDEN" IS 'HorizontalAccuracyResultQualifierCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_RSLT_QUAL_VALUE" IS 'HorizontalAccuracyResultQualifierValue';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (HorizontalCollectionMethodIdentifierCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (HorizontalCollectionMethodName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_DESC_TXT" IS 'A brief summary that provides general information about the method. (HorizontalCollectionMethodDescriptionText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_DEVIATIONS_TXT" IS 'Text that identifies any deviations from the published method reference. (HorizontalCollectionMethodDeviationsText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_LST_IDEN" IS 'HorizontalCollectionMethodCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_LST_AGCY_IDEN" IS 'HorizontalCollectionMethodCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."HORZ_COLL_METH_VALUE" IS 'HorizontalCollectionMethodValue';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."GEO_REF_PT_CODE" IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."GEO_REF_PT_NAME" IS 'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."GEO_REF_PT_LST_IDEN" IS 'GeographicReferencePointCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."GEO_REF_PT_LST_AGCY_IDEN" IS 'GeographicReferencePointCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."GEO_REF_PT_VALUE" IS 'GeographicReferencePointValue';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (VerticalCollectionMethodIdentifierCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (VerticalCollectionMethodName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_DESC_TXT" IS 'A brief summary that provides general information about the method. (VerticalCollectionMethodDescriptionText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_DEVIATIONS_TXT" IS 'Text that identifies any deviations from the published method reference. (VerticalCollectionMethodDeviationsText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_LST_IDEN" IS 'VerticalCollectionMethodCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_LST_AGCY_IDEN" IS 'VerticalCollectionMethodCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERT_COLL_METH_VALUE" IS 'VerticalCollectionMethodValue';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (VerificationMethodIdentifierCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (VerificationMethodName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_DESC_TXT" IS 'A brief summary that provides general information about the method. (VerificationMethodDescriptionText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_DEVIATIONS_TXT" IS 'Text that identifies any deviations from the published method reference. (VerificationMethodDeviationsText)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_LST_IDEN" IS 'VerificationMethodCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_LST_AGCY_IDEN" IS 'VerificationMethodCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."VERIF_METH_VALUE" IS 'VerificationMethodValue';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."COORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."COORD_DATA_SRC_NAME" IS 'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."COORD_DATA_SRC_LST_IDEN" IS 'CoordinateDataSourceCodeListVersionIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."COORD_DATA_SRC_LST_AGCY_IDEN" IS 'CoordinateDataSourceCodeListVersionAgencyIdentifier';
 
   COMMENT ON COLUMN "IC_GEO_LOC_DESC"."COORD_DATA_SRC_VALUE" IS 'CoordinateDataSourceValue';
 
   COMMENT ON TABLE "IC_GEO_LOC_DESC"  IS 'Schema element: ICGeographicLocationDescriptionDataType';
/
--------------------------------------------------------
--  DDL for Table IC_INSTL_CTRLS_DOC
--------------------------------------------------------

  CREATE TABLE "IC_INSTL_CTRLS_DOC" 
   (	"IC_INSTL_CTRLS_DOC_ID" VARCHAR2(36 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON TABLE "IC_INSTL_CTRLS_DOC"  IS 'Schema element: InstitutionalControlsDocumentDataType';
/
--------------------------------------------------------
--  DDL for Table IC_INSTR
--------------------------------------------------------

  CREATE TABLE "IC_INSTR" 
   (	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"IC_INSTL_CTRLS_DOC_ID" VARCHAR2(36 BYTE), 
	"INSTR_IDEN" VARCHAR2(50 BYTE), 
	"INSTR_NAME" VARCHAR2(255 BYTE), 
	"INSTR_CATG_CODE" VARCHAR2(19 BYTE), 
	"OTHR_INSTR_CATG_TXT" VARCHAR2(255 BYTE), 
	"INSTR_CODE" VARCHAR2(36 BYTE), 
	"OTHR_INSTR_TYPE_TXT" VARCHAR2(255 BYTE), 
	"INSTR_LEGAL_DESC_TXT" VARCHAR2(255 BYTE), 
	"OTHR_MEDIA_TYPE_TXT" VARCHAR2(255 BYTE), 
	"ORIG_PARTNER_NAME" VARCHAR2(128 BYTE), 
	"INFO_SYSTM_ACNYM_NAME" VARCHAR2(50 BYTE), 
	"LAST_UPDATED_DATE" TIMESTAMP (6)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_INSTR"."INSTR_IDEN" IS 'A unique identifier assigned to an administrative measure and/or legal mechanism that establishes a specific set of land or resource use restrictions. (InstrumentIdentifier)';
 
   COMMENT ON COLUMN "IC_INSTR"."INSTR_NAME" IS 'The name assigned to an administrative measure and/or legal mechanism that establishes a specific set of land or resource use restrictions. (InstrumentName)';
 
   COMMENT ON COLUMN "IC_INSTR"."INSTR_CATG_CODE" IS 'The major IC classification to which an administrative measure and/or legal mechanism that establishes aspecific set of land or resource use restrictions belongs. (InstrumentCategoryCode)';
 
   COMMENT ON COLUMN "IC_INSTR"."OTHR_INSTR_CATG_TXT" IS 'A text description of the instrument category when "Other" is selected for the Instrument Category Code. (OtherInstrumentCategoryText)';
 
   COMMENT ON COLUMN "IC_INSTR"."INSTR_CODE" IS 'The type of administrative measure and/or legal mechanism that establishes a specific set of land or resource use restrictions. (InstrumentTypeCode)';
 
   COMMENT ON COLUMN "IC_INSTR"."OTHR_INSTR_TYPE_TXT" IS 'A text description of the instrument type when "Other" is selected for the Instrument Type Code. (OtherInstrumentTypeText)';
 
   COMMENT ON COLUMN "IC_INSTR"."INSTR_LEGAL_DESC_TXT" IS 'The legal description of an IC. (InstrumentLegalDescriptionText)';
 
   COMMENT ON COLUMN "IC_INSTR"."OTHR_MEDIA_TYPE_TXT" IS 'A text description of the media type when "Other" is selected for the Media Type Code. (OtherMediaTypeText)';
 
   COMMENT ON COLUMN "IC_INSTR"."ORIG_PARTNER_NAME" IS 'The name of the partner that provided the data. (OriginatingPartnerName)';
 
   COMMENT ON COLUMN "IC_INSTR"."INFO_SYSTM_ACNYM_NAME" IS 'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)';
 
   COMMENT ON COLUMN "IC_INSTR"."LAST_UPDATED_DATE" IS 'A value corresponding to the date the data was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)';
 
   COMMENT ON TABLE "IC_INSTR"  IS 'Schema element: Instrument';
/
--------------------------------------------------------
--  DDL for Table IC_INSTR_AFFIL
--------------------------------------------------------

  CREATE TABLE "IC_INSTR_AFFIL" 
   (	"IC_INSTR_AFFIL_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"AFFIL_IDEN" VARCHAR2(50 BYTE), 
	"OTHR_AFFIL_TYPE_TXT" VARCHAR2(255 BYTE), 
	"AFFIL_START_DATE" TIMESTAMP (6), 
	"AFFIL_END_DATE" TIMESTAMP (6)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_INSTR_AFFIL"."AFFIL_IDEN" IS 'A unique identifier prescribed to a person or organization. (AffiliateIdentifier)';
 
   COMMENT ON COLUMN "IC_INSTR_AFFIL"."OTHR_AFFIL_TYPE_TXT" IS 'A text description of the affiliation type when "Other" is selected for the Affiliation Type Code. (OtherAffiliationTypeText)';
 
   COMMENT ON COLUMN "IC_INSTR_AFFIL"."AFFIL_START_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)';
 
   COMMENT ON COLUMN "IC_INSTR_AFFIL"."AFFIL_END_DATE" IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)';
 
   COMMENT ON TABLE "IC_INSTR_AFFIL"  IS 'Schema element: InstrumentAffiliate';
/
--------------------------------------------------------
--  DDL for Table IC_INSTR_LOC
--------------------------------------------------------

  CREATE TABLE "IC_INSTR_LOC" 
   (	"IC_INSTR_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_INSTR_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_INSTR_LOC"  IS 'Schema element: InstrumentLocation';
/
--------------------------------------------------------
--  DDL for Table IC_LAND_PARCEL
--------------------------------------------------------

  CREATE TABLE "IC_LAND_PARCEL" 
   (	"IC_LAND_PARCEL_ID" VARCHAR2(36 BYTE), 
	"IC_LOC_ID" VARCHAR2(36 BYTE), 
	"LAND_PARCEL_NAMING_SCHEMA" VARCHAR2(255 BYTE), 
	"LAND_PARCEL_SRC" VARCHAR2(255 BYTE), 
	"LAND_PARCEL_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_LAND_PARCEL"."LAND_PARCEL_NAMING_SCHEMA" IS 'Identifies the parcel schema. (LandParcelNamingSchema)';
 
   COMMENT ON COLUMN "IC_LAND_PARCEL"."LAND_PARCEL_SRC" IS 'Identifies the jurisitiction that generated the parcel value, typically a county tax assessor office. (LandParcelSource)';
 
   COMMENT ON COLUMN "IC_LAND_PARCEL"."LAND_PARCEL_IDEN" IS 'Parcel value compliant with parcel schema typically referred to as a Parcel Identification Number (PIN) or Assessors Parcel Number (APN) (LandParcelIdentifier)';
 
   COMMENT ON TABLE "IC_LAND_PARCEL"  IS 'Schema element: LandParcelDataType';
/
--------------------------------------------------------
--  DDL for Table IC_LAT_LON_POLYGON
--------------------------------------------------------

  CREATE TABLE "IC_LAT_LON_POLYGON" 
   (	"IC_LAT_LON_POLYGON_ID" VARCHAR2(36 BYTE), 
	"IC_GEO_LOC_DESC_ID" VARCHAR2(36 BYTE), 
	"LAT" NUMBER(19,14), 
	"LON" NUMBER(19,14)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_LAT_LON_POLYGON"."LAT" IS 'Latitude';
 
   COMMENT ON COLUMN "IC_LAT_LON_POLYGON"."LON" IS 'Longitude';
 
   COMMENT ON TABLE "IC_LAT_LON_POLYGON"  IS 'Schema element: LatitudeLongitudePolygon';
/
--------------------------------------------------------
--  DDL for Table IC_LOC
--------------------------------------------------------

  CREATE TABLE "IC_LOC" 
   (	"IC_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_INSTL_CTRLS_DOC_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_LOC"  IS 'Schema element: ICLocation';
/
--------------------------------------------------------
--  DDL for Table IC_MEDIA_TYPE
--------------------------------------------------------

  CREATE TABLE "IC_MEDIA_TYPE" 
   (	"IC_MEDIA_TYPE_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"MEDIA_CODE" VARCHAR2(15 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_MEDIA_TYPE"."MEDIA_CODE" IS 'The name of the major environmental component contaminated and addressed by the language of the IC instrument. (MediaTypeCode)';
 
   COMMENT ON TABLE "IC_MEDIA_TYPE"  IS 'Schema element: MediaTypeCode';
/
--------------------------------------------------------
--  DDL for Table IC_OBJTV_TXT
--------------------------------------------------------

  CREATE TABLE "IC_OBJTV_TXT" 
   (	"IC_OBJTV_TXT_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"OBJTV_TXT" VARCHAR2(255 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_OBJTV_TXT"."OBJTV_TXT" IS 'The text describing the intended goal of an IC in minimizing the potential for human exposure to remaining contamination and/or protecting the integrity of an engineering control by limiting land or resource use in a particular media. (ObjectiveText)';
 
   COMMENT ON TABLE "IC_OBJTV_TXT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table IC_RECR_EVT
--------------------------------------------------------

  CREATE TABLE "IC_RECR_EVT" 
   (	"IC_RECR_EVT_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"RECR_EVT_IDEN" VARCHAR2(50 BYTE), 
	"EVT_NAME" VARCHAR2(128 BYTE), 
	"EVT_CODE" VARCHAR2(31 BYTE), 
	"OTHR_EVT_TYPE_TXT" VARCHAR2(255 BYTE), 
	"EVT_DESC_TXT" VARCHAR2(255 BYTE), 
	"EVT_FREQ_MEAS" NUMBER(10,0), 
	"EVT_FREQ_UNIT_CODE" VARCHAR2(6 BYTE), 
	"EVT_FREQ_START_DATE" TIMESTAMP (6), 
	"EVT_FREQ_END_DATE" TIMESTAMP (6), 
	"EVT_TRIGGER_TXT" VARCHAR2(255 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_RECR_EVT"."RECR_EVT_IDEN" IS 'A unique identifier assigned to a recurring event. (RecurringEventIdentifier)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_NAME" IS 'The name given to an occurrence or action taking place on a specific date or over a period of time. (EventName)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_CODE" IS 'The type of occurrence or action taking place on a specific date or overa period of time. (EventTypeCode)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."OTHR_EVT_TYPE_TXT" IS 'A text description of the event type when "Other" is selected for the Event Type Code. (OtherEventTypeText)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_DESC_TXT" IS 'A text description of the event. (EventDescriptionText)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_FREQ_MEAS" IS 'The number denoting the time interval between a series of recurring events. (EventFrequencyMeasure)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_FREQ_UNIT_CODE" IS 'The unit of measure associated with a time interval between a series of events allotted to take place. (EventFrequencyUnitCode)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_FREQ_START_DATE" IS 'The date a recurring event started or is scheduled to start. (EventFrequencyStartDate)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_FREQ_END_DATE" IS 'The date a recurring event ended or is scheduled to end. (EventFrequencyEndDate)';
 
   COMMENT ON COLUMN "IC_RECR_EVT"."EVT_TRIGGER_TXT" IS 'Describes the condition that would cause the event to occur. (EventTriggerText)';
 
   COMMENT ON TABLE "IC_RECR_EVT"  IS 'Schema element: RecurringEvent';
/
--------------------------------------------------------
--  DDL for Table IC_RECR_EVT_LOC
--------------------------------------------------------

  CREATE TABLE "IC_RECR_EVT_LOC" 
   (	"IC_RECR_EVT_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_RECR_EVT_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_RECR_EVT_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_RECR_EVT_LOC"  IS 'Schema element: RecurringEventLocation';
/
--------------------------------------------------------
--  DDL for Table IC_RSRC
--------------------------------------------------------

  CREATE TABLE "IC_RSRC" 
   (	"IC_RSRC_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"IC_EVT_ID" VARCHAR2(36 BYTE), 
	"RSRC_NAME" VARCHAR2(50 BYTE), 
	"RSRC_DESC_TXT" VARCHAR2(255 BYTE), 
	"RSRC_TYPE_TXT" VARCHAR2(50 BYTE), 
	"ELEC_ADDR_TXT" VARCHAR2(255 BYTE), 
	"ELEC_ADDR_TYPE_NAME" VARCHAR2(8 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_RSRC"."RSRC_NAME" IS 'A name given to the resource. (ResourceName)';
 
   COMMENT ON COLUMN "IC_RSRC"."RSRC_DESC_TXT" IS 'An account of the content of the resource. (ResourceDescriptionText)';
 
   COMMENT ON COLUMN "IC_RSRC"."RSRC_TYPE_TXT" IS 'The nature or genre of the content of the resource. (ResourceTypeText)';
 
   COMMENT ON COLUMN "IC_RSRC"."ELEC_ADDR_TXT" IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressText)';
 
   COMMENT ON COLUMN "IC_RSRC"."ELEC_ADDR_TYPE_NAME" IS 'The name that describes the electronic address type. (ElectronicAddressTypeName)';
 
   COMMENT ON TABLE "IC_RSRC"  IS 'Schema element: Resource';
/
--------------------------------------------------------
--  DDL for Table IC_RSRC_LOC
--------------------------------------------------------

  CREATE TABLE "IC_RSRC_LOC" 
   (	"IC_RSRC_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_RSRC_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_RSRC_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_RSRC_LOC"  IS 'Schema element: ResourceLocation';
/
--------------------------------------------------------
--  DDL for Table IC_TELE
--------------------------------------------------------

  CREATE TABLE "IC_TELE" 
   (	"IC_TELE_ID" VARCHAR2(36 BYTE), 
	"IC_AFFIL_ID" VARCHAR2(36 BYTE), 
	"TELE_NUM_TXT" VARCHAR2(20 BYTE), 
	"TELE_NUM_TYPE_NAME" VARCHAR2(50 BYTE), 
	"TELE_EXT_NUM_TXT" VARCHAR2(20 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_TELE"."TELE_NUM_TXT" IS 'The number that identifies a particular telephone connection. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "IC_TELE"."TELE_NUM_TYPE_NAME" IS 'The name that describes a telephone number type. (TelephoneNumberTypeName)';
 
   COMMENT ON COLUMN "IC_TELE"."TELE_EXT_NUM_TXT" IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)';
 
   COMMENT ON TABLE "IC_TELE"  IS 'Schema element: Telephonic';
/
--------------------------------------------------------
--  DDL for Table IC_USE_RSTCT
--------------------------------------------------------

  CREATE TABLE "IC_USE_RSTCT" 
   (	"IC_USE_RSTCT_ID" VARCHAR2(36 BYTE), 
	"IC_INSTR_ID" VARCHAR2(36 BYTE), 
	"USE_RSTCT_CODE" VARCHAR2(37 BYTE), 
	"USE_RSTCT_TXT" VARCHAR2(255 BYTE), 
	"USE_RSTCT_START_DATE" TIMESTAMP (6), 
	"USE_RSTCT_END_DATE" TIMESTAMP (6)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_USE_RSTCT"."USE_RSTCT_CODE" IS 'The type of land or resource use specifically prohibited or restricted by the language of the IC instrument. (UseRestrictionTypeCode)';
 
   COMMENT ON COLUMN "IC_USE_RSTCT"."USE_RSTCT_TXT" IS 'Describes a land or resource use specifically prohibited or restricted by the language of the IC instrument. (UseRestrictionText)';
 
   COMMENT ON COLUMN "IC_USE_RSTCT"."USE_RSTCT_START_DATE" IS 'The date when a use restriction takes effect. (UseRestrictionStartDate)';
 
   COMMENT ON COLUMN "IC_USE_RSTCT"."USE_RSTCT_END_DATE" IS 'The date when a use restriction is lifted. (UseRestrictionEndDate)';
 
   COMMENT ON TABLE "IC_USE_RSTCT"  IS 'Schema element: UseRestriction';
/
--------------------------------------------------------
--  DDL for Table IC_USE_RSTCT_LOC
--------------------------------------------------------

  CREATE TABLE "IC_USE_RSTCT_LOC" 
   (	"IC_USE_RSTCT_LOC_ID" VARCHAR2(36 BYTE), 
	"IC_USE_RSTCT_ID" VARCHAR2(36 BYTE), 
	"LOC_IDEN" VARCHAR2(50 BYTE)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
 

   COMMENT ON COLUMN "IC_USE_RSTCT_LOC"."LOC_IDEN" IS 'A unique identifier used to uniquely identify a location. (LocationIdentifier)';
 
   COMMENT ON TABLE "IC_USE_RSTCT_LOC"  IS 'Schema element: UseRestrictionLocation';
/
REM INSERTING into IC_AFFIL
SET DEFINE OFF;
REM INSERTING into IC_AFFIL_TYPE
SET DEFINE OFF;
REM INSERTING into IC_CNTMT
SET DEFINE OFF;
REM INSERTING into IC_ELEC_ADDR
SET DEFINE OFF;
REM INSERTING into IC_ENGR_CTRL
SET DEFINE OFF;
REM INSERTING into IC_ENGR_CTRL_LOC
SET DEFINE OFF;
REM INSERTING into IC_EVT
SET DEFINE OFF;
REM INSERTING into IC_EVT_AFFIL
SET DEFINE OFF;
REM INSERTING into IC_EVT_LOC
SET DEFINE OFF;
REM INSERTING into IC_FAC
SET DEFINE OFF;
REM INSERTING into IC_GEO_LOC_DESC
SET DEFINE OFF;
REM INSERTING into IC_INSTL_CTRLS_DOC
SET DEFINE OFF;
REM INSERTING into IC_INSTR
SET DEFINE OFF;
REM INSERTING into IC_INSTR_AFFIL
SET DEFINE OFF;
REM INSERTING into IC_INSTR_LOC
SET DEFINE OFF;
REM INSERTING into IC_LAND_PARCEL
SET DEFINE OFF;
REM INSERTING into IC_LAT_LON_POLYGON
SET DEFINE OFF;
REM INSERTING into IC_LOC
SET DEFINE OFF;
REM INSERTING into IC_MEDIA_TYPE
SET DEFINE OFF;
REM INSERTING into IC_OBJTV_TXT
SET DEFINE OFF;
REM INSERTING into IC_RECR_EVT
SET DEFINE OFF;
REM INSERTING into IC_RECR_EVT_LOC
SET DEFINE OFF;
REM INSERTING into IC_RSRC
SET DEFINE OFF;
REM INSERTING into IC_RSRC_LOC
SET DEFINE OFF;
REM INSERTING into IC_TELE
SET DEFINE OFF;
REM INSERTING into IC_USE_RSTCT
SET DEFINE OFF;
REM INSERTING into IC_USE_RSTCT_LOC
SET DEFINE OFF;
--------------------------------------------------------
--  DDL for Index PK_AFFIL_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFIL_TYPE" ON "IC_AFFIL_TYPE" ("IC_AFFIL_TYPE_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_LAND_PARCEL_IC_LOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_LAND_PARCEL_IC_LOC_ID" ON "IC_LAND_PARCEL" ("IC_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_EVT_AFFIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVT_AFFIL" ON "IC_EVT_AFFIL" ("IC_EVT_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_TELE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TELE" ON "IC_TELE" ("IC_TELE_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_LOC_IC_INSTL_CTRLS_DOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_LOC_IC_INSTL_CTRLS_DOC_ID" ON "IC_LOC" ("IC_INSTL_CTRLS_DOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_INSTR_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INSTR_LOC" ON "IC_INSTR_LOC" ("IC_INSTR_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_GEO_LOC_DESC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GEO_LOC_DESC" ON "IC_GEO_LOC_DESC" ("IC_GEO_LOC_DESC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_AFFIL_TYPE_IC_EVT_AFFIL_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFIL_TYPE_IC_EVT_AFFIL_ID" ON "IC_AFFIL_TYPE" ("IC_EVT_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_INSTR_AFFIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INSTR_AFFIL" ON "IC_INSTR_AFFIL" ("IC_INSTR_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_RECR_EVT_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_RECR_EVT_IC_INSTR_ID" ON "IC_RECR_EVT" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_INSTR_IC_INSTL_CTRLS_DOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_INSTR_IC_INSTL_CTRLS_DOC_ID" ON "IC_INSTR" ("IC_INSTL_CTRLS_DOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_EVT_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_EVT_IC_INSTR_ID" ON "IC_EVT" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_ENGR_CTRL_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENGR_CTRL_LOC" ON "IC_ENGR_CTRL_LOC" ("IC_ENGR_CTRL_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_ELEC_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ELEC_ADDR" ON "IC_ELEC_ADDR" ("IC_ELEC_ADDR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_LAT_LON_POLYGON
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LAT_LON_POLYGON" ON "IC_LAT_LON_POLYGON" ("IC_LAT_LON_POLYGON_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_INSTR_LOC_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_INSTR_LOC_IC_INSTR_ID" ON "IC_INSTR_LOC" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_INSTR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INSTR" ON "IC_INSTR" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_LAT_LON_PLY_IC_GEO_LO_DE_ID
--------------------------------------------------------

  CREATE INDEX "IX_LAT_LON_PLY_IC_GEO_LO_DE_ID" ON "IC_LAT_LON_POLYGON" ("IC_GEO_LOC_DESC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_ENGR_CTRL_LOC_IC_ENG_CTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENGR_CTRL_LOC_IC_ENG_CTR_ID" ON "IC_ENGR_CTRL_LOC" ("IC_ENGR_CTRL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_RSRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RSRC" ON "IC_RSRC" ("IC_RSRC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_USE_RSTCT_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_USE_RSTCT_LOC" ON "IC_USE_RSTCT_LOC" ("IC_USE_RSTCT_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_AFFIL_TYPE_IC_INSTR_AFFL_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFIL_TYPE_IC_INSTR_AFFL_ID" ON "IC_AFFIL_TYPE" ("IC_INSTR_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_USE_RSTCT_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_USE_RSTCT_IC_INSTR_ID" ON "IC_USE_RSTCT" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_MEDIA_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_MEDIA_TYPE" ON "IC_MEDIA_TYPE" ("IC_MEDIA_TYPE_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_ENGR_CTRL_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENGR_CTRL_IC_INSTR_ID" ON "IC_ENGR_CTRL" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_AFFIL_IC_INSTL_CTRLS_DOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_AFFIL_IC_INSTL_CTRLS_DOC_ID" ON "IC_AFFIL" ("IC_INSTL_CTRLS_DOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_RECR_EVT_LOC_IC_RECR_EVT_ID
--------------------------------------------------------

  CREATE INDEX "IX_RECR_EVT_LOC_IC_RECR_EVT_ID" ON "IC_RECR_EVT_LOC" ("IC_RECR_EVT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_INSTL_CTRLS_DOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INSTL_CTRLS_DOC" ON "IC_INSTL_CTRLS_DOC" ("IC_INSTL_CTRLS_DOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_USE_RSTCT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_USE_RSTCT" ON "IC_USE_RSTCT" ("IC_USE_RSTCT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_EVT_LOC_IC_EVT_ID
--------------------------------------------------------

  CREATE INDEX "IX_EVT_LOC_IC_EVT_ID" ON "IC_EVT_LOC" ("IC_EVT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_USE_RSTC_LOC_IC_USE_RSTC_ID
--------------------------------------------------------

  CREATE INDEX "IX_USE_RSTC_LOC_IC_USE_RSTC_ID" ON "IC_USE_RSTCT_LOC" ("IC_USE_RSTCT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_ELEC_ADDR_IC_AFFIL_ID
--------------------------------------------------------

  CREATE INDEX "IX_ELEC_ADDR_IC_AFFIL_ID" ON "IC_ELEC_ADDR" ("IC_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_MEDIA_TYPE_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_MEDIA_TYPE_IC_INSTR_ID" ON "IC_MEDIA_TYPE" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_ENGR_CTRL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENGR_CTRL" ON "IC_ENGR_CTRL" ("IC_ENGR_CTRL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_RECR_EVT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RECR_EVT" ON "IC_RECR_EVT" ("IC_RECR_EVT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_CNTMT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CNTMT" ON "IC_CNTMT" ("IC_CNTMT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_EVT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVT" ON "IC_EVT" ("IC_EVT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_RSRC_LOC_IC_RSRC_ID
--------------------------------------------------------

  CREATE INDEX "IX_RSRC_LOC_IC_RSRC_ID" ON "IC_RSRC_LOC" ("IC_RSRC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_RSRC_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_RSRC_IC_INSTR_ID" ON "IC_RSRC" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_OBJTV_TXT_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_OBJTV_TXT_IC_INSTR_ID" ON "IC_OBJTV_TXT" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_AFFIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_AFFIL" ON "IC_AFFIL" ("IC_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_LAND_PARCEL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LAND_PARCEL" ON "IC_LAND_PARCEL" ("IC_LAND_PARCEL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_FAC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC" ON "IC_FAC" ("IC_FAC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_GEO_LOC_DESC_IC_LOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_GEO_LOC_DESC_IC_LOC_ID" ON "IC_GEO_LOC_DESC" ("IC_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_TELE_IC_AFFIL_ID
--------------------------------------------------------

  CREATE INDEX "IX_TELE_IC_AFFIL_ID" ON "IC_TELE" ("IC_AFFIL_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_CNTMT_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_CNTMT_IC_INSTR_ID" ON "IC_CNTMT" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LOC" ON "IC_LOC" ("IC_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_RECR_EVT_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RECR_EVT_LOC" ON "IC_RECR_EVT_LOC" ("IC_RECR_EVT_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_OBJTV_TXT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_OBJTV_TXT" ON "IC_OBJTV_TXT" ("IC_OBJTV_TXT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_EVT_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EVT_LOC" ON "IC_EVT_LOC" ("IC_EVT_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index PK_RSRC_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RSRC_LOC" ON "IC_RSRC_LOC" ("IC_RSRC_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_EVT_AFFIL_IC_EVT_ID
--------------------------------------------------------

  CREATE INDEX "IX_EVT_AFFIL_IC_EVT_ID" ON "IC_EVT_AFFIL" ("IC_EVT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_RSRC_IC_EVT_ID
--------------------------------------------------------

  CREATE INDEX "IX_RSRC_IC_EVT_ID" ON "IC_RSRC" ("IC_EVT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_INSTR_AFFIL_IC_INSTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_INSTR_AFFIL_IC_INSTR_ID" ON "IC_INSTR_AFFIL" ("IC_INSTR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_IC_LOC_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_IC_LOC_ID" ON "IC_FAC" ("IC_LOC_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS" ;
/
--------------------------------------------------------
--  Constraints for Table IC_LAND_PARCEL
--------------------------------------------------------

  ALTER TABLE "IC_LAND_PARCEL" ADD CONSTRAINT "PK_LAND_PARCEL" PRIMARY KEY ("IC_LAND_PARCEL_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_LAND_PARCEL" MODIFY ("IC_LAND_PARCEL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAND_PARCEL" MODIFY ("IC_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAND_PARCEL" MODIFY ("LAND_PARCEL_NAMING_SCHEMA" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAND_PARCEL" MODIFY ("LAND_PARCEL_SRC" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAND_PARCEL" MODIFY ("LAND_PARCEL_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_OBJTV_TXT
--------------------------------------------------------

  ALTER TABLE "IC_OBJTV_TXT" ADD CONSTRAINT "PK_OBJTV_TXT" PRIMARY KEY ("IC_OBJTV_TXT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_OBJTV_TXT" MODIFY ("IC_OBJTV_TXT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_OBJTV_TXT" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_OBJTV_TXT" MODIFY ("OBJTV_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_MEDIA_TYPE
--------------------------------------------------------

  ALTER TABLE "IC_MEDIA_TYPE" ADD CONSTRAINT "PK_MEDIA_TYPE" PRIMARY KEY ("IC_MEDIA_TYPE_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_MEDIA_TYPE" MODIFY ("IC_MEDIA_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_MEDIA_TYPE" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_MEDIA_TYPE" MODIFY ("MEDIA_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_LOC
--------------------------------------------------------

  ALTER TABLE "IC_LOC" ADD CONSTRAINT "PK_LOC" PRIMARY KEY ("IC_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_LOC" MODIFY ("IC_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LOC" MODIFY ("IC_INSTL_CTRLS_DOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_GEO_LOC_DESC
--------------------------------------------------------

  ALTER TABLE "IC_GEO_LOC_DESC" ADD CONSTRAINT "PK_GEO_LOC_DESC" PRIMARY KEY ("IC_GEO_LOC_DESC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_GEO_LOC_DESC" MODIFY ("IC_GEO_LOC_DESC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_GEO_LOC_DESC" MODIFY ("IC_LOC_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_RSRC
--------------------------------------------------------

  ALTER TABLE "IC_RSRC" ADD CONSTRAINT "PK_RSRC" PRIMARY KEY ("IC_RSRC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_RSRC" MODIFY ("IC_RSRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RSRC" MODIFY ("RSRC_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_EVT
--------------------------------------------------------

  ALTER TABLE "IC_EVT" ADD CONSTRAINT "PK_EVT" PRIMARY KEY ("IC_EVT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_EVT" MODIFY ("IC_EVT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT" MODIFY ("EVT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT" MODIFY ("EVT_START_DATE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_INSTL_CTRLS_DOC
--------------------------------------------------------

  ALTER TABLE "IC_INSTL_CTRLS_DOC" ADD CONSTRAINT "PK_INSTL_CTRLS_DOC" PRIMARY KEY ("IC_INSTL_CTRLS_DOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_INSTL_CTRLS_DOC" MODIFY ("IC_INSTL_CTRLS_DOC_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_USE_RSTCT_LOC
--------------------------------------------------------

  ALTER TABLE "IC_USE_RSTCT_LOC" ADD CONSTRAINT "PK_USE_RSTCT_LOC" PRIMARY KEY ("IC_USE_RSTCT_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_USE_RSTCT_LOC" MODIFY ("IC_USE_RSTCT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_USE_RSTCT_LOC" MODIFY ("IC_USE_RSTCT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_USE_RSTCT_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_RECR_EVT_LOC
--------------------------------------------------------

  ALTER TABLE "IC_RECR_EVT_LOC" ADD CONSTRAINT "PK_RECR_EVT_LOC" PRIMARY KEY ("IC_RECR_EVT_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_RECR_EVT_LOC" MODIFY ("IC_RECR_EVT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RECR_EVT_LOC" MODIFY ("IC_RECR_EVT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RECR_EVT_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_AFFIL
--------------------------------------------------------

  ALTER TABLE "IC_AFFIL" ADD CONSTRAINT "PK_AFFIL" PRIMARY KEY ("IC_AFFIL_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_AFFIL" MODIFY ("IC_AFFIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_AFFIL" MODIFY ("IC_INSTL_CTRLS_DOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_AFFIL" MODIFY ("AFFIL_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_INSTR_LOC
--------------------------------------------------------

  ALTER TABLE "IC_INSTR_LOC" ADD CONSTRAINT "PK_INSTR_LOC" PRIMARY KEY ("IC_INSTR_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_INSTR_LOC" MODIFY ("IC_INSTR_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR_LOC" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_USE_RSTCT
--------------------------------------------------------

  ALTER TABLE "IC_USE_RSTCT" ADD CONSTRAINT "PK_USE_RSTCT" PRIMARY KEY ("IC_USE_RSTCT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_USE_RSTCT" MODIFY ("IC_USE_RSTCT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_USE_RSTCT" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_USE_RSTCT" MODIFY ("USE_RSTCT_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_EVT_LOC
--------------------------------------------------------

  ALTER TABLE "IC_EVT_LOC" ADD CONSTRAINT "PK_EVT_LOC" PRIMARY KEY ("IC_EVT_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_EVT_LOC" MODIFY ("IC_EVT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT_LOC" MODIFY ("IC_EVT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_INSTR_AFFIL
--------------------------------------------------------

  ALTER TABLE "IC_INSTR_AFFIL" ADD CONSTRAINT "PK_INSTR_AFFIL" PRIMARY KEY ("IC_INSTR_AFFIL_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_INSTR_AFFIL" MODIFY ("IC_INSTR_AFFIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR_AFFIL" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR_AFFIL" MODIFY ("AFFIL_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_LAT_LON_POLYGON
--------------------------------------------------------

  ALTER TABLE "IC_LAT_LON_POLYGON" ADD CONSTRAINT "PK_LAT_LON_POLYGON" PRIMARY KEY ("IC_LAT_LON_POLYGON_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_LAT_LON_POLYGON" MODIFY ("IC_LAT_LON_POLYGON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAT_LON_POLYGON" MODIFY ("IC_GEO_LOC_DESC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAT_LON_POLYGON" MODIFY ("LAT" NOT NULL ENABLE);
 
  ALTER TABLE "IC_LAT_LON_POLYGON" MODIFY ("LON" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_ENGR_CTRL_LOC
--------------------------------------------------------

  ALTER TABLE "IC_ENGR_CTRL_LOC" ADD CONSTRAINT "PK_ENGR_CTRL_LOC" PRIMARY KEY ("IC_ENGR_CTRL_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_ENGR_CTRL_LOC" MODIFY ("IC_ENGR_CTRL_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_ENGR_CTRL_LOC" MODIFY ("IC_ENGR_CTRL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_ENGR_CTRL_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_AFFIL_TYPE
--------------------------------------------------------

  ALTER TABLE "IC_AFFIL_TYPE" ADD CONSTRAINT "PK_AFFIL_TYPE" PRIMARY KEY ("IC_AFFIL_TYPE_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_AFFIL_TYPE" MODIFY ("IC_AFFIL_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_AFFIL_TYPE" MODIFY ("AFFIL_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "IC_ELEC_ADDR" ADD CONSTRAINT "PK_ELEC_ADDR" PRIMARY KEY ("IC_ELEC_ADDR_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_ELEC_ADDR" MODIFY ("IC_ELEC_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_ELEC_ADDR" MODIFY ("IC_AFFIL_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_RECR_EVT
--------------------------------------------------------

  ALTER TABLE "IC_RECR_EVT" ADD CONSTRAINT "PK_RECR_EVT" PRIMARY KEY ("IC_RECR_EVT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_RECR_EVT" MODIFY ("IC_RECR_EVT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RECR_EVT" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RECR_EVT" MODIFY ("EVT_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_ENGR_CTRL
--------------------------------------------------------

  ALTER TABLE "IC_ENGR_CTRL" ADD CONSTRAINT "PK_ENGR_CTRL" PRIMARY KEY ("IC_ENGR_CTRL_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_ENGR_CTRL" MODIFY ("IC_ENGR_CTRL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_ENGR_CTRL" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_ENGR_CTRL" MODIFY ("ENGR_CTRL_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_FAC
--------------------------------------------------------

  ALTER TABLE "IC_FAC" ADD CONSTRAINT "PK_FAC" PRIMARY KEY ("IC_FAC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_FAC" MODIFY ("IC_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_FAC" MODIFY ("IC_LOC_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_EVT_AFFIL
--------------------------------------------------------

  ALTER TABLE "IC_EVT_AFFIL" ADD CONSTRAINT "PK_EVT_AFFIL" PRIMARY KEY ("IC_EVT_AFFIL_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_EVT_AFFIL" MODIFY ("IC_EVT_AFFIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT_AFFIL" MODIFY ("IC_EVT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_EVT_AFFIL" MODIFY ("AFFIL_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_TELE
--------------------------------------------------------

  ALTER TABLE "IC_TELE" ADD CONSTRAINT "PK_TELE" PRIMARY KEY ("IC_TELE_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_TELE" MODIFY ("IC_TELE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_TELE" MODIFY ("IC_AFFIL_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_CNTMT
--------------------------------------------------------

  ALTER TABLE "IC_CNTMT" ADD CONSTRAINT "PK_CNTMT" PRIMARY KEY ("IC_CNTMT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_CNTMT" MODIFY ("IC_CNTMT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_CNTMT" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_CNTMT" MODIFY ("CHEM_CATG_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "IC_CNTMT" MODIFY ("CHEM_SUBST_DEF_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_INSTR
--------------------------------------------------------

  ALTER TABLE "IC_INSTR" ADD CONSTRAINT "PK_INSTR" PRIMARY KEY ("IC_INSTR_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_INSTR" MODIFY ("IC_INSTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR" MODIFY ("IC_INSTL_CTRLS_DOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR" MODIFY ("INSTR_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR" MODIFY ("INSTR_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR" MODIFY ("ORIG_PARTNER_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR" MODIFY ("INFO_SYSTM_ACNYM_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "IC_INSTR" MODIFY ("LAST_UPDATED_DATE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table IC_RSRC_LOC
--------------------------------------------------------

  ALTER TABLE "IC_RSRC_LOC" ADD CONSTRAINT "PK_RSRC_LOC" PRIMARY KEY ("IC_RSRC_LOC_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT)
  TABLESPACE "USERS"  ENABLE;
 
  ALTER TABLE "IC_RSRC_LOC" MODIFY ("IC_RSRC_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RSRC_LOC" MODIFY ("IC_RSRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "IC_RSRC_LOC" MODIFY ("LOC_IDEN" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Ref Constraints for Table IC_AFFIL
--------------------------------------------------------

  ALTER TABLE "IC_AFFIL" ADD CONSTRAINT "FK_AFFIL_INSTL_CTRLS_DOC" FOREIGN KEY ("IC_INSTL_CTRLS_DOC_ID")
	  REFERENCES "IC_INSTL_CTRLS_DOC" ("IC_INSTL_CTRLS_DOC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_AFFIL_TYPE
--------------------------------------------------------

  ALTER TABLE "IC_AFFIL_TYPE" ADD CONSTRAINT "FK_AFFIL_TYPE_EVT_AFFIL" FOREIGN KEY ("IC_EVT_AFFIL_ID")
	  REFERENCES "IC_EVT_AFFIL" ("IC_EVT_AFFIL_ID") ENABLE;
 
  ALTER TABLE "IC_AFFIL_TYPE" ADD CONSTRAINT "FK_AFFIL_TYPE_INSTR_AFFIL" FOREIGN KEY ("IC_INSTR_AFFIL_ID")
	  REFERENCES "IC_INSTR_AFFIL" ("IC_INSTR_AFFIL_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_CNTMT
--------------------------------------------------------

  ALTER TABLE "IC_CNTMT" ADD CONSTRAINT "FK_CNTMT_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_ELEC_ADDR
--------------------------------------------------------

  ALTER TABLE "IC_ELEC_ADDR" ADD CONSTRAINT "FK_ELEC_ADDR_AFFIL" FOREIGN KEY ("IC_AFFIL_ID")
	  REFERENCES "IC_AFFIL" ("IC_AFFIL_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_ENGR_CTRL
--------------------------------------------------------

  ALTER TABLE "IC_ENGR_CTRL" ADD CONSTRAINT "FK_ENGR_CTRL_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_ENGR_CTRL_LOC
--------------------------------------------------------

  ALTER TABLE "IC_ENGR_CTRL_LOC" ADD CONSTRAINT "FK_ENGR_CTRL_LOC_ENGR_CTRL" FOREIGN KEY ("IC_ENGR_CTRL_ID")
	  REFERENCES "IC_ENGR_CTRL" ("IC_ENGR_CTRL_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_EVT
--------------------------------------------------------

  ALTER TABLE "IC_EVT" ADD CONSTRAINT "FK_EVT_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_EVT_AFFIL
--------------------------------------------------------

  ALTER TABLE "IC_EVT_AFFIL" ADD CONSTRAINT "FK_EVT_AFFIL_EVT" FOREIGN KEY ("IC_EVT_ID")
	  REFERENCES "IC_EVT" ("IC_EVT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_EVT_LOC
--------------------------------------------------------

  ALTER TABLE "IC_EVT_LOC" ADD CONSTRAINT "FK_EVT_LOC_EVT" FOREIGN KEY ("IC_EVT_ID")
	  REFERENCES "IC_EVT" ("IC_EVT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_FAC
--------------------------------------------------------

  ALTER TABLE "IC_FAC" ADD CONSTRAINT "FK_FAC_LOC" FOREIGN KEY ("IC_LOC_ID")
	  REFERENCES "IC_LOC" ("IC_LOC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_GEO_LOC_DESC
--------------------------------------------------------

  ALTER TABLE "IC_GEO_LOC_DESC" ADD CONSTRAINT "FK_GEO_LOC_DESC_LOC" FOREIGN KEY ("IC_LOC_ID")
	  REFERENCES "IC_LOC" ("IC_LOC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_INSTR
--------------------------------------------------------

  ALTER TABLE "IC_INSTR" ADD CONSTRAINT "FK_INSTR_INSTL_CTRLS_DOC" FOREIGN KEY ("IC_INSTL_CTRLS_DOC_ID")
	  REFERENCES "IC_INSTL_CTRLS_DOC" ("IC_INSTL_CTRLS_DOC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_INSTR_AFFIL
--------------------------------------------------------

  ALTER TABLE "IC_INSTR_AFFIL" ADD CONSTRAINT "FK_INSTR_AFFIL_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_INSTR_LOC
--------------------------------------------------------

  ALTER TABLE "IC_INSTR_LOC" ADD CONSTRAINT "FK_INSTR_LOC_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_LAND_PARCEL
--------------------------------------------------------

  ALTER TABLE "IC_LAND_PARCEL" ADD CONSTRAINT "FK_LAND_PARCEL_LOC" FOREIGN KEY ("IC_LOC_ID")
	  REFERENCES "IC_LOC" ("IC_LOC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_LAT_LON_POLYGON
--------------------------------------------------------

  ALTER TABLE "IC_LAT_LON_POLYGON" ADD CONSTRAINT "FK_LAT_LON_POLYGN_GEO_LOC_DESC" FOREIGN KEY ("IC_GEO_LOC_DESC_ID")
	  REFERENCES "IC_GEO_LOC_DESC" ("IC_GEO_LOC_DESC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_LOC
--------------------------------------------------------

  ALTER TABLE "IC_LOC" ADD CONSTRAINT "FK_LOC_INSTL_CTRLS_DOC" FOREIGN KEY ("IC_INSTL_CTRLS_DOC_ID")
	  REFERENCES "IC_INSTL_CTRLS_DOC" ("IC_INSTL_CTRLS_DOC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_MEDIA_TYPE
--------------------------------------------------------

  ALTER TABLE "IC_MEDIA_TYPE" ADD CONSTRAINT "FK_MEDIA_TYPE_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_OBJTV_TXT
--------------------------------------------------------

  ALTER TABLE "IC_OBJTV_TXT" ADD CONSTRAINT "FK_OBJTV_TXT_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_RECR_EVT
--------------------------------------------------------

  ALTER TABLE "IC_RECR_EVT" ADD CONSTRAINT "FK_RECR_EVT_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_RECR_EVT_LOC
--------------------------------------------------------

  ALTER TABLE "IC_RECR_EVT_LOC" ADD CONSTRAINT "FK_RECR_EVT_LOC_RECR_EVT" FOREIGN KEY ("IC_RECR_EVT_ID")
	  REFERENCES "IC_RECR_EVT" ("IC_RECR_EVT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_RSRC
--------------------------------------------------------

  ALTER TABLE "IC_RSRC" ADD CONSTRAINT "FK_RSRC_EVT" FOREIGN KEY ("IC_EVT_ID")
	  REFERENCES "IC_EVT" ("IC_EVT_ID") ENABLE;
 
  ALTER TABLE "IC_RSRC" ADD CONSTRAINT "FK_RSRC_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_RSRC_LOC
--------------------------------------------------------

  ALTER TABLE "IC_RSRC_LOC" ADD CONSTRAINT "FK_RSRC_LOC_RSRC" FOREIGN KEY ("IC_RSRC_ID")
	  REFERENCES "IC_RSRC" ("IC_RSRC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_TELE
--------------------------------------------------------

  ALTER TABLE "IC_TELE" ADD CONSTRAINT "FK_TELE_AFFIL" FOREIGN KEY ("IC_AFFIL_ID")
	  REFERENCES "IC_AFFIL" ("IC_AFFIL_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_USE_RSTCT
--------------------------------------------------------

  ALTER TABLE "IC_USE_RSTCT" ADD CONSTRAINT "FK_USE_RSTCT_INSTR" FOREIGN KEY ("IC_INSTR_ID")
	  REFERENCES "IC_INSTR" ("IC_INSTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table IC_USE_RSTCT_LOC
--------------------------------------------------------

  ALTER TABLE "IC_USE_RSTCT_LOC" ADD CONSTRAINT "FK_USE_RSTCT_LOC_USE_RSTCT" FOREIGN KEY ("IC_USE_RSTCT_ID")
	  REFERENCES "IC_USE_RSTCT" ("IC_USE_RSTCT_ID") ON DELETE CASCADE ENABLE;
/
