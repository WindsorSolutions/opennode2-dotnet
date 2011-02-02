/*  
 ****************************************************************************************************************************   
 *
 *  Script Name:  FACID_3.0-ORA-DDL.sql
 *
 *  Purpose:  This script will build the required objects to support the FACID data flow.  It will build the FACID staging 
 *            database, and add comments for each column.
 *
 *  Note:  1.  Each object has been referenced with the schema identifier, so this can be executed as SYS.
 *         
 *  Maintenance:
 *  
 *    Analyst         Date            Comment 
 *    ----------      ----------      --------------------------------------------
 *    KJames          01/28/2010      Created
 *    KJames          12/22/2010      Removed the schema prefix from all objects.
 *
 ****************************************************************************************************************************   
 */
 
 
ALTER TABLE FACID_TELEPHONIC
	DROP CONSTRAINT FK_FACID_TELEPHONIC
/

ALTER TABLE FACID_SHAPE
	DROP CONSTRAINT FK_SHA_FA_GE_LO_DE
/

ALTER TABLE FACID_POS
	DROP CONSTRAINT FK_POS_SHAPE
/

ALTER TABLE FACID_FAC
	DROP CONSTRAINT FK_FAC_FAC_DTLS
/

ALTER TABLE FACID_FAC_PRI_GEO_LOC_DESC
	DROP CONSTRAINT FK_FA_PR_GE_LO_DE
/

ALTER TABLE FACID_FAC_GEO_LOC_DESC
	DROP CONSTRAINT FK_FAC_GE_LO_DE_FA
/

ALTER TABLE FACID_FAC_FAC_SIC
	DROP CONSTRAINT FK_FAC_FAC_SIC_FAC
/

ALTER TABLE FACID_FAC_FAC_NAICS
	DROP CONSTRAINT FK_FAC_FAC_NAI_FAC
/

ALTER TABLE FACID_FAC_FAC_AFFL
	DROP CONSTRAINT FK_FAC_FAC_AFL_FAC_AFFL
/

ALTER TABLE FACID_FAC_FAC_AFFL
	DROP CONSTRAINT FK_FAC_FAC_AFF_FAC
/

ALTER TABLE FACID_FAC_ELEC_ADDR
	DROP CONSTRAINT FK_FAC_ELE_ADD_FAC
/

ALTER TABLE FACID_FAC_ALT_IDEN
	DROP CONSTRAINT FK_FAC_ALT_IDE_FAC
/

ALTER TABLE FACID_ENVR_INTR
	DROP CONSTRAINT FK_ENVR_INTR_FAC
/

ALTER TABLE FACID_ENVR_INTR_FAC_SIC
	DROP CONSTRAINT FK_EN_IN_FA_SI_EN
/

ALTER TABLE FACID_ENVR_INTR_FAC_NAICS
	DROP CONSTRAINT FK_EN_IN_FA_NA_EN
/

ALTER TABLE FACID_ENVR_INTR_FAC_AFFL
	DROP CONSTRAINT FK_FAC_ENV_INT_FAC_AFL_FAC_AFL
/

ALTER TABLE FACID_ENVR_INTR_FAC_AFFL
	DROP CONSTRAINT FK_EN_IN_FA_AF_EN
/

ALTER TABLE FACID_ENVR_INTR_ELEC_ADDR
	DROP CONSTRAINT FK_EN_IN_EL_AD_EN
/

ALTER TABLE FACID_ENVR_INTR_ALT_IDEN
	DROP CONSTRAINT FK_EN_IN_AL_ID_EN
/

ALTER TABLE FACID_ALT_NAME
	DROP CONSTRAINT FK_ALT_NAME_FAC
/

ALTER TABLE FACID_AFFL
	DROP CONSTRAINT FK_AFFL_FAC_DTLS
/

ALTER TABLE FACID_AFFL_ELEC_ADDR
	DROP CONSTRAINT FK_FACID_AFFL_ELEC_ADDR
/

ALTER TABLE FACID_AFFL
	DROP CONSTRAINT UK_FACID_AFFL_AFFL_IDEN
/

ALTER TABLE FACID_TELEPHONIC
	DROP CONSTRAINT PK_TELEPHONIC
/

ALTER TABLE FACID_SHAPE
	DROP CONSTRAINT PK_SHAPE
/

ALTER TABLE FACID_POS
	DROP CONSTRAINT PK_POS
/

ALTER TABLE FACID_FAC
	DROP CONSTRAINT PK_FACILITY_ID
/

ALTER TABLE FACID_FAC_PRI_GEO_LOC_DESC
	DROP CONSTRAINT PK_FAC_PR_GE_LO_DE
/

ALTER TABLE FACID_FAC_GEO_LOC_DESC
	DROP CONSTRAINT PK_FAC_GEO_LOC_DES
/

ALTER TABLE FACID_FAC_FAC_SIC
	DROP CONSTRAINT PK_FAC_FAC_SIC
/

ALTER TABLE FACID_FAC_FAC_NAICS
	DROP CONSTRAINT PK_FAC_FAC_NAICS
/

ALTER TABLE FACID_FAC_FAC_AFFL
	DROP CONSTRAINT PK_FAC_FAC_AFFL
/

ALTER TABLE FACID_FAC_ELEC_ADDR
	DROP CONSTRAINT PK_FAC_ELEC_ADDR
/

ALTER TABLE FACID_FAC_DTLS
	DROP CONSTRAINT PK_FAC_DTLS
/

ALTER TABLE FACID_FAC_DEL
	DROP CONSTRAINT PK__FACID_FAC_DEL__5B638405
/

ALTER TABLE FACID_FAC_ALT_IDEN
	DROP CONSTRAINT PK_FAC_ALT_IDEN
/

ALTER TABLE FACID_ENVR_INTR
	DROP CONSTRAINT PK_ENVR_INTR
/

ALTER TABLE FACID_ENVR_INTR_FAC_SIC
	DROP CONSTRAINT PK_ENV_INT_FAC_SIC
/

ALTER TABLE FACID_ENVR_INTR_FAC_NAICS
	DROP CONSTRAINT PK_ENV_INT_FAC_NAI
/

ALTER TABLE FACID_ENVR_INTR_FAC_AFFL
	DROP CONSTRAINT PK_ENV_INT_FAC_AFF
/

ALTER TABLE FACID_ENVR_INTR_ELEC_ADDR
	DROP CONSTRAINT PK_ENV_INT_ELE_ADD
/

ALTER TABLE FACID_ENVR_INTR_ALT_IDEN
	DROP CONSTRAINT PK_ENV_INT_ALT_IDE
/

ALTER TABLE FACID_ALT_NAME
	DROP CONSTRAINT PK_ALT_NAME
/

ALTER TABLE FACID_AFFL
	DROP CONSTRAINT FACID_AFFL_PK
/

ALTER TABLE FACID_AFFL_ELEC_ADDR
	DROP CONSTRAINT PK_AFFL_ELEC_ADDR
/

DROP INDEX PK_TELEPHONIC
/

DROP INDEX IX_TELEPHO_AFFL_ID
/

DROP INDEX PK_SHAPE
/

DROP INDEX IX_SH_FA_GE_LO_DE
/

DROP INDEX IX_POS_SHAPE_ID
/

DROP INDEX IX_POS_LATITUDE
/

DROP INDEX PK_POS
/

DROP INDEX IX_POS_ELEVATION
/

DROP INDEX IX_POS_LONGITUDE
/

DROP INDEX PK_FACILITY_ID
/

DROP INDEX IX_FAC_ORI_PAR_NAM
/

DROP INDEX IX_FAC_LAS_UPD_DAT
/

DROP INDEX IX_FAC_FA_SI_ID_VA
/

DROP INDEX IX_FAC_LOCA_NAME
/

DROP INDEX IX_FAC_IN_SY_AC_NA
/

DROP INDEX IX_FA_MA_AD_AD_PO
/

DROP INDEX IX_FAC_FAC_DTLS_ID
/

DROP INDEX IX_FAC_FAC_SIT_NAM
/

DROP INDEX IX_FAC_STA_CODE
/

DROP INDEX IX_FAC_AD_PO_CO_VA
/

DROP INDEX IX_FAC_CNTY_NAME
/

DROP INDEX IX_FAC_MA_AD_ST_CO
/

DROP INDEX PK_FAC_PR_GE_LO_DE
/

DROP INDEX IX_FA_PR_GE_LO_02
/

DROP INDEX IX_FA_PR_GE_LO_03
/

DROP INDEX IX_FA_PR_GE_LO_04
/

DROP INDEX IX_FA_PR_GE_LO_DE
/

DROP INDEX PK_FAC_GEO_LOC_DES
/

DROP INDEX IX_FAC_GE_LO_DE_LA
/

DROP INDEX IX_FA_GE_LO_DE_FA
/

DROP INDEX IX_FAC_GE_LO_DE_LO
/

DROP INDEX IX_FAC_GE_LO_DE_EL
/

DROP INDEX IX_FAC_FA_SI_FA_ID
/

DROP INDEX PK_FAC_FAC_SIC
/

DROP INDEX IX_FAC_FA_NA_FA_ID
/

DROP INDEX PK_FAC_FAC_NAICS
/

DROP INDEX IX_FAC_FA_AF_FA_ID
/

DROP INDEX IX_FAC_AFFL_IDEN
/

DROP INDEX PK_FAC_FAC_AFFL
/

DROP INDEX PK_FAC_ELEC_ADDR
/

DROP INDEX IX_FAC_EL_AD_FA_ID
/

DROP INDEX PK_FAC_DTLS
/

DROP INDEX PK__FACID_FAC_DEL__5B638405
/

DROP INDEX PK_FAC_ALT_IDEN
/

DROP INDEX IX_FAC_AL_ID_FA_ID
/

DROP INDEX IX_EN_IN_IN_SY_AC
/

DROP INDEX IX_ENVR_INT_FAC_ID
/

DROP INDEX IX_ENV_IN_OR_PA_NA
/

DROP INDEX IX_ENV_IN_LA_UP_DA
/

DROP INDEX PK_ENVR_INTR
/

DROP INDEX IX_ENV_IN_IDEN
/

DROP INDEX PK_ENV_INT_FAC_SIC
/

DROP INDEX IX_EN_IN_FA_SI_EN
/

DROP INDEX IX_EN_IN_FA_NA_EN
/

DROP INDEX PK_ENV_INT_FAC_NAI
/

DROP INDEX IX_EN_IN_FA_AF_EN
/

DROP INDEX PK_ENV_INT_FAC_AFF
/

DROP INDEX IX_EI_AFFL_IDEN
/

DROP INDEX PK_ENV_INT_ELE_ADD
/

DROP INDEX IX_EN_IN_EL_AD_EN
/

DROP INDEX PK_ENV_INT_ALT_IDE
/

DROP INDEX IX_EN_IN_AL_ID_EN
/

DROP INDEX IX_ALT_NAME_FAC_ID
/

DROP INDEX PK_ALT_NAME
/

DROP INDEX UK_FACID_AFFL_AFFL_IDEN
/

DROP INDEX IX_AFF_AD_PO_CO_VA
/

DROP INDEX FACID_AFFL_PK
/

DROP INDEX IX_FACID_AFFL
/

DROP INDEX IX_AFFL_FAC_DTL_ID
/

DROP INDEX IX_AFFL_STA_CODE
/

DROP INDEX PK_AFFL_ELEC_ADDR
/

DROP INDEX IX_AFF_EL_AD_AF_ID
/

DROP MATERIALIZED VIEW FACID_ENVR_INTR_ALT_IDEN
/

DROP MATERIALIZED VIEW FACID_ENVR_INTR_FAC_AFFL
/

DROP MATERIALIZED VIEW FACID_ALT_NAME
/

DROP MATERIALIZED VIEW FACID_ENVR_INTR_FAC_NAICS
/

DROP MATERIALIZED VIEW FACID_ENVR_INTR_FAC_SIC
/

DROP MATERIALIZED VIEW FACID_FAC
/

DROP MATERIALIZED VIEW FACID_FAC_ALT_IDEN
/

DROP MATERIALIZED VIEW FACID_FAC_DTLS
/

DROP MATERIALIZED VIEW FACID_FAC_FAC_AFFL
/

DROP MATERIALIZED VIEW FACID_FAC_FAC_NAICS
/

DROP MATERIALIZED VIEW FACID_FAC_FAC_SIC
/

DROP MATERIALIZED VIEW FACID_FAC_PRI_GEO_LOC_DESC
/

DROP MATERIALIZED VIEW FACID_TELEPHONIC
/

DROP MATERIALIZED VIEW FACID_ENVR_INTR
/

DROP MATERIALIZED VIEW FACID_AFFL_ELEC_ADDR
/

DROP MATERIALIZED VIEW FACID_AFFL
/

DROP TABLE FACID_TELEPHONIC
/

DROP TABLE FACID_SHAPE
/

DROP TABLE FACID_POS
/

DROP TABLE FACID_FAC
/

DROP TABLE FACID_FAC_PRI_GEO_LOC_DESC
/

DROP TABLE FACID_FAC_GEO_LOC_DESC
/

DROP TABLE FACID_FAC_FAC_SIC
/

DROP TABLE FACID_FAC_FAC_NAICS
/

DROP TABLE FACID_FAC_FAC_AFFL
/

DROP TABLE FACID_FAC_ELEC_ADDR
/

DROP TABLE FACID_FAC_DTLS
/

DROP TABLE FACID_FAC_DEL
/

DROP TABLE FACID_FAC_ALT_IDEN
/

DROP TABLE FACID_ENVR_INTR
/

DROP TABLE FACID_ENVR_INTR_FAC_SIC
/

DROP TABLE FACID_ENVR_INTR_FAC_NAICS
/

DROP TABLE FACID_ENVR_INTR_FAC_AFFL
/

DROP TABLE FACID_ENVR_INTR_ELEC_ADDR
/

DROP TABLE FACID_ENVR_INTR_ALT_IDEN
/

DROP TABLE FACID_ALT_NAME
/

DROP TABLE FACID_AFFL
/

DROP TABLE FACID_AFFL_ELEC_ADDR
/

PURGE RECYCLEBIN
/

CREATE TABLE FACID_AFFL_ELEC_ADDR ( 
	AFFL_ELEC_ADDR_ID  	VARCHAR2(40) NOT NULL,
	AFFL_ID            	VARCHAR2(40) NOT NULL,
	ELEC_ADDR_TEXT     	VARCHAR2(255) NULL,
	ELEC_ADDR_TYPE_NAME	VARCHAR2(8) NULL 
	)
/
COMMENT ON COLUMN FACID_AFFL_ELEC_ADDR.AFFL_ELEC_ADDR_ID IS 'Parent: A container for one or more electronic addresses. (AffiliateElectronicAddressId)'
/
COMMENT ON COLUMN FACID_AFFL_ELEC_ADDR.AFFL_ID IS 'Parent: A container for one or more electronic addresses. (AffiliateId)'
/
COMMENT ON COLUMN FACID_AFFL_ELEC_ADDR.ELEC_ADDR_TEXT IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressText)'
/
COMMENT ON COLUMN FACID_AFFL_ELEC_ADDR.ELEC_ADDR_TYPE_NAME IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)'
/

CREATE TABLE FACID_AFFL ( 
	AFFL_ID                       	VARCHAR2(40) NOT NULL,
	FAC_DTLS_ID                   	VARCHAR2(40) NOT NULL,
	AFFL_IDEN                     	VARCHAR2(255) NOT NULL,
	INDV_TITLE_TEXT               	VARCHAR2(255) NULL,
	NAME_PREFIX_TEXT              	VARCHAR2(255) NULL,
	INDV_FULL_NAME                	VARCHAR2(255) NULL,
	FIRST_NAME                    	VARCHAR2(128) NULL,
	MIDDLE_NAME                   	VARCHAR2(128) NULL,
	LAST_NAME                     	VARCHAR2(128) NULL,
	NAME_SUFFIX_TEXT              	VARCHAR2(255) NULL,
	INDV_IDEN_CONT                	VARCHAR2(255) NULL,
	INDV_IDEN_VAL                 	VARCHAR2(50) NULL,
	ORG_FORMAL_NAME               	VARCHAR2(128) NULL,
	ORG_IDEN_CONT                 	VARCHAR2(255) NULL,
	ORG_IDEN_VAL                  	VARCHAR2(50) NULL,
	MAIL_ADDR_TEXT                	VARCHAR2(255) NULL,
	SUPP_ADDR_TEXT                	VARCHAR2(255) NULL,
	MAIL_ADDR_CITY_NAME           	VARCHAR2(128) NULL,
	STA_CODE                      	VARCHAR2(50) NULL,
	STA_NAME                      	VARCHAR2(128) NULL,
	CODE_LIST_VERS_IDEN           	VARCHAR2(50) NULL,
	CODE_LIST_VERS_AGN_IDEN       	VARCHAR2(50) NULL,
	CODE_LST_VER_VAL              	VARCHAR2(50) NULL,
	ADDR_POST_CODE_CONT           	VARCHAR2(50) NULL,
	ADDR_POST_CODE_VAL            	VARCHAR2(50) NULL,
	CTRY_CODE                     	VARCHAR2(50) NULL,
	CTRY_NAME                     	VARCHAR2(128) NULL,
	CTRY_IDEN_CODE_LIST_VERS_IDEN 	VARCHAR2(50) NULL,
	CTRY_IDEN_CODE_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	CTRY_IDEN_CODE_LST_VER_VAL    	VARCHAR2(50) NULL 
	)
/
COMMENT ON COLUMN FACID_AFFL.AFFL_ID IS 'Parent: A container for one or more affiliate for a partner. (AffiliateId)'
/
COMMENT ON COLUMN FACID_AFFL.FAC_DTLS_ID IS 'Parent: A container for one or more affiliate for a partner. (FacilityDetailsId)'
/
COMMENT ON COLUMN FACID_AFFL.AFFL_IDEN IS 'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)'
/
COMMENT ON COLUMN FACID_AFFL.INDV_TITLE_TEXT IS 'The title held by a person in an organization. (IndividualTitleText)'
/
COMMENT ON COLUMN FACID_AFFL.NAME_PREFIX_TEXT IS 'The text that describes the title that precedes an individual''s name. (NamePrefixText)'
/
COMMENT ON COLUMN FACID_AFFL.INDV_FULL_NAME IS 'Parent: A container for one or more affiliate for a partner. (IndividualFullName)'
/
COMMENT ON COLUMN FACID_AFFL.FIRST_NAME IS 'Parent: A container for one or more affiliate for a partner. (FirstName)'
/
COMMENT ON COLUMN FACID_AFFL.MIDDLE_NAME IS 'Parent: A container for one or more affiliate for a partner. (MiddleName)'
/
COMMENT ON COLUMN FACID_AFFL.LAST_NAME IS 'Parent: A container for one or more affiliate for a partner. (LastName)'
/
COMMENT ON COLUMN FACID_AFFL.NAME_SUFFIX_TEXT IS 'Additional title that indicates lineage or professional title. (NameSuffixText)'
/
COMMENT ON COLUMN FACID_AFFL.INDV_IDEN_CONT IS 'Parent: A designator used to uniquely identify an individual within a context. (IndividualIdentifierContext)'
/
COMMENT ON COLUMN FACID_AFFL.INDV_IDEN_VAL IS 'Parent: A designator used to uniquely identify an individual within a context. (Value)'
/
COMMENT ON COLUMN FACID_AFFL.ORG_FORMAL_NAME IS 'The legal designator (i.e. formal name) of an organization. (OrganizationFormalName)'
/
COMMENT ON COLUMN FACID_AFFL.ORG_IDEN_CONT IS 'Parent: A designator used to uniquely identify a unique business establishment within a context. (OrganizationIdentifierContext)'
/
COMMENT ON COLUMN FACID_AFFL.ORG_IDEN_VAL IS 'Parent: A designator used to uniquely identify a unique business establishment within a context. (Value)'
/
COMMENT ON COLUMN FACID_AFFL.MAIL_ADDR_TEXT IS 'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)'
/
COMMENT ON COLUMN FACID_AFFL.SUPP_ADDR_TEXT IS 'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)'
/
COMMENT ON COLUMN FACID_AFFL.MAIL_ADDR_CITY_NAME IS 'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)'
/
COMMENT ON COLUMN FACID_AFFL.STA_CODE IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)'
/
COMMENT ON COLUMN FACID_AFFL.STA_NAME IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)'
/
COMMENT ON COLUMN FACID_AFFL.CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_AFFL.CODE_LIST_VERS_AGN_IDEN IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_AFFL.CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_AFFL.ADDR_POST_CODE_CONT IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)'
/
COMMENT ON COLUMN FACID_AFFL.ADDR_POST_CODE_VAL IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)'
/
COMMENT ON COLUMN FACID_AFFL.CTRY_CODE IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)'
/
COMMENT ON COLUMN FACID_AFFL.CTRY_NAME IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)'
/
COMMENT ON COLUMN FACID_AFFL.CTRY_IDEN_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_AFFL.CTRY_IDEN_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_AFFL.CTRY_IDEN_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/

CREATE TABLE FACID_ALT_NAME ( 
	ALT_NAME_ID       	VARCHAR2(40) NOT NULL,
	FAC_ID            	VARCHAR2(40) NOT NULL,
	ALT_NAME_TEXT     	VARCHAR2(255) NOT NULL,
	ALT_NAME_TYPE_TEXT	VARCHAR2(255) NOT NULL 
	)
/
COMMENT ON COLUMN FACID_ALT_NAME.ALT_NAME_ID IS 'Parent: A container for one or more alternative names. (AlternativeNameId)'
/
COMMENT ON COLUMN FACID_ALT_NAME.FAC_ID IS 'Parent: A container for one or more alternative names. (FacilityId)'
/
COMMENT ON COLUMN FACID_ALT_NAME.ALT_NAME_TEXT IS 'An alternative, historic or program specific name for the facility site. (AlternativeNameText)'
/
COMMENT ON COLUMN FACID_ALT_NAME.ALT_NAME_TYPE_TEXT IS 'The type of the alternative, historical, or program-specific name for the facility site (e.g., primary, legal, historical, local). (AlternativeNameTypeText)'
/

CREATE TABLE FACID_ENVR_INTR_ALT_IDEN ( 
	ENVR_INTR_ALT_IDEN_ID	VARCHAR2(40) NOT NULL,
	ENVR_INTR_ID         	VARCHAR2(40) NOT NULL,
	ALT_IDEN_IDEN        	VARCHAR2(50) NULL,
	ALT_IDEN_TYPE_TEXT   	VARCHAR2(255) NULL 
	)
/
COMMENT ON COLUMN FACID_ENVR_INTR_ALT_IDEN.ENVR_INTR_ALT_IDEN_ID IS 'Parent: A container for one or more alternative identifiers. (EnvironmentalInterestAlternativeIdentificationId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_ALT_IDEN.ENVR_INTR_ID IS 'Parent: A container for one or more alternative identifiers. (EnvironmentalInterestId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_ALT_IDEN.ALT_IDEN_IDEN IS 'An alternative, historic or program specific identifier for the facility site or environmental interest. (AlternativeIdentificationIdentifier)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_ALT_IDEN.ALT_IDEN_TYPE_TEXT IS 'The type of the alternative, historical, or program-specific identifier for the facility site or environmental interest.  (AlternativeIdentificationTypeText)'
/

CREATE TABLE FACID_ENVR_INTR_ELEC_ADDR ( 
	ENVR_INTR_ELEC_ADDR_ID	VARCHAR2(40) NOT NULL,
	ENVR_INTR_ID          	VARCHAR2(40) NOT NULL,
	ELEC_ADDR_TEXT        	VARCHAR2(255) NULL,
	ELEC_ADDR_TYPE_NAME   	VARCHAR2(8) NULL 
	)
/
COMMENT ON COLUMN FACID_ENVR_INTR_ELEC_ADDR.ENVR_INTR_ELEC_ADDR_ID IS 'Parent: A container for one or more electronic addresses. (EnvironmentalInterestElectronicAddressId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_ELEC_ADDR.ENVR_INTR_ID IS 'Parent: A container for one or more electronic addresses. (EnvironmentalInterestId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_ELEC_ADDR.ELEC_ADDR_TEXT IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_ELEC_ADDR.ELEC_ADDR_TYPE_NAME IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)'
/

CREATE TABLE FACID_ENVR_INTR_FAC_AFFL ( 
	ENVR_INTR_FAC_AFFL_ID	VARCHAR2(40) NOT NULL,
	ENVR_INTR_ID         	VARCHAR2(40) NOT NULL,
	AFFL_IDEN            	VARCHAR2(255) NOT NULL,
	AFFL_TYPE_TEXT       	VARCHAR2(255) NULL,
	AFFL_START_DATE      	DATE NULL,
	AFFL_END_DATE        	DATE NULL,
	AFFL_STAT_TEXT       	VARCHAR2(4) NULL,
	AFFL_STAT_DETR_DATE  	DATE NULL 
	)
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.ENVR_INTR_FAC_AFFL_ID IS 'Parent: A container for one or more affiliations. (EnvironmentalInterestFacilityAffiliationId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.ENVR_INTR_ID IS 'Parent: A container for one or more affiliations. (EnvironmentalInterestId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.AFFL_IDEN IS 'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.AFFL_TYPE_TEXT IS 'The name that describes the capacity or function that an organization or individual serves; or the relationship between an individual or organization and a project or action. (AffiliationTypeText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.AFFL_START_DATE IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.AFFL_END_DATE IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.AFFL_STAT_TEXT IS 'The status of an affiliation between an individual or organization and a facility, project, or action. (AffiliationStatusText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_AFFL.AFFL_STAT_DETR_DATE IS 'The date on which the status of an affiliation between an individual or organization and a facility, project, or action is determined. (AffiliationStatusDetermineDate)'
/

CREATE TABLE FACID_ENVR_INTR_FAC_NAICS ( 
	ENVR_INTR_FAC_NAICS_ID	VARCHAR2(40) NOT NULL,
	ENVR_INTR_ID          	VARCHAR2(40) NOT NULL,
	FAC_NAICS_CODE        	VARCHAR2(50) NULL,
	FAC_NAICS_PRI_INDI    	VARCHAR2(9) NULL 
	)
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_NAICS.ENVR_INTR_FAC_NAICS_ID IS 'Parent: A container for one or more NAICS codes. (EnvironmentalInterestFacilityNAICSId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_NAICS.ENVR_INTR_ID IS 'Parent: A container for one or more NAICS codes. (EnvironmentalInterestId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_NAICS.FAC_NAICS_CODE IS 'The code that represents a subdivision of an industry that accommodates user needs in the United States. (FacilityNAICSCode)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_NAICS.FAC_NAICS_PRI_INDI IS 'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (FacilityNAICSPrimaryIndicator)'
/

CREATE TABLE FACID_ENVR_INTR_FAC_SIC ( 
	ENVR_INTR_FAC_SIC_ID	VARCHAR2(40) NOT NULL,
	ENVR_INTR_ID        	VARCHAR2(40) NOT NULL,
	SIC_CODE            	VARCHAR2(50) NULL,
	SIC_PRI_INDI        	VARCHAR2(9) NULL 
	)
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_SIC.ENVR_INTR_FAC_SIC_ID IS 'Parent: A container for one or more SIC Codes. (EnvironmentalInterestFacilitySICId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_SIC.ENVR_INTR_ID IS 'Parent: A container for one or more SIC Codes. (EnvironmentalInterestId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_SIC.SIC_CODE IS 'The code that represents the economic activity of a company. (SICCode)'
/
COMMENT ON COLUMN FACID_ENVR_INTR_FAC_SIC.SIC_PRI_INDI IS 'The name that indicates whether the associated SIC Code represents the primary activity occurring at the facility site. (SICPrimaryIndicator)'
/

CREATE TABLE FACID_ENVR_INTR ( 
	ENVR_INTR_ID                  	VARCHAR2(40) NOT NULL,
	FAC_ID                        	VARCHAR2(40) NOT NULL,
	ENVR_INTR_IDEN                	VARCHAR2(50) NOT NULL,
	ENVR_INTR_TYPE_TEXT           	VARCHAR2(255) NOT NULL,
	ENVR_INTR_START_DATE          	DATE NULL,
	ENVR_INTR_START_DATE_QUAL_TEXT	VARCHAR2(255) NULL,
	ENVR_INTR_END_DATE            	DATE NULL,
	ENVR_INTR_END_DATE_QUAL_TEXT  	VARCHAR2(255) NULL,
	ENVR_INTR_ACTIVE_INDI         	VARCHAR2(1) NULL,
	ENVR_INTR_URL_TEXT            	VARCHAR2(255) NULL,
	ORIG_PART_NAME                	VARCHAR2(128) NULL,
	INFO_SYS_ACRO_NAME            	VARCHAR2(128) NULL,
	LAST_UPDT_DATE                	DATE NULL,
	AGN_TYPE_CODE                 	VARCHAR2(50) NULL,
	AGN_TYPE_NAME                 	VARCHAR2(128) NULL,
	CODE_LIST_VERS_IDEN           	VARCHAR2(50) NULL,
	CODE_LIST_VERS_AGN_IDEN       	VARCHAR2(50) NULL,
	CODE_LST_VER_VAL              	VARCHAR2(50) NULL 
	)
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_ID IS 'Parent: A container for one or more environmental interests. (EnvironmentalInterestId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.FAC_ID IS 'Parent: A container for one or more environmental interests. (FacilityId)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_IDEN IS 'A designator, such as a permit number, assigned by an information management system that is used to identify an environmental interest (e.g. permit, etc.) for a partner. (EnvironmentalInterestIdentifier)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_TYPE_TEXT IS 'The environmental permit or regulatory program that applies to the facility site. (EnvironmentalInterestTypeText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_START_DATE IS 'The date the agency became interested in the facility site for a particular environmental interest type. (EnvironmentalInterestStartDate)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_START_DATE_QUAL_TEXT IS 'The qualifier that specifies the meaning of  the date being used as an approximation for the environmental interest start date. (EnvironmentalInterestStartDateQualifierText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_END_DATE IS 'The date the agency ceased to be interested in the facility site for a particular environmental interest type. (EnvironmentalInterestEndDate)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_END_DATE_QUAL_TEXT IS 'The qualifier that specifies the meaning of  the date being used as an approximation for the environmental interest end date. (EnvironmentalInterestEndDateQualifierText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_ACTIVE_INDI IS 'A designator that indicates whether the Environmental Interest is currently considered to active. (EnvironmentalInterestActiveIndicator)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ENVR_INTR_URL_TEXT IS 'The web address where a computer user can access information about the facility. (EnvironmentalInterestURLText)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.ORIG_PART_NAME IS 'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.INFO_SYS_ACRO_NAME IS 'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.LAST_UPDT_DATE IS 'A value corresponding to the date the facility site or environmental interest was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.AGN_TYPE_CODE IS 'The code that represents a type of federal, state, or local agency. (AgencyTypeCode)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.AGN_TYPE_NAME IS 'A description of the agency type code. (AgencyTypeName)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.CODE_LIST_VERS_AGN_IDEN IS 'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_ENVR_INTR.CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/

CREATE TABLE FACID_FAC_ALT_IDEN ( 
	FAC_ALT_IDEN_ID   	VARCHAR2(40) NOT NULL,
	FAC_ID            	VARCHAR2(40) NOT NULL,
	ALT_IDEN_IDEN     	VARCHAR2(50) NULL,
	ALT_IDEN_TYPE_TEXT	VARCHAR2(255) NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_ALT_IDEN.FAC_ALT_IDEN_ID IS 'Parent: A container for one or more alternative identifiers. (FacilityAlternativeIdentificationId)'
/
COMMENT ON COLUMN FACID_FAC_ALT_IDEN.FAC_ID IS 'Parent: A container for one or more alternative identifiers. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_ALT_IDEN.ALT_IDEN_IDEN IS 'An alternative, historic or program specific identifier for the facility site or environmental interest. (AlternativeIdentificationIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_ALT_IDEN.ALT_IDEN_TYPE_TEXT IS 'The type of the alternative, historical, or program-specific identifier for the facility site or environmental interest.  (AlternativeIdentificationTypeText)'
/

CREATE TABLE FACID_FAC_DEL ( 
	FAC_SITE_IDEN_VAL 	VARCHAR2(50) NOT NULL,
	FAC_SITE_IDEN_CONT	VARCHAR2(255) NULL,
	FAC_SITE_NAME     	VARCHAR2(128) NULL,
	INFO_SYS_ACRO_NAME	VARCHAR2(128) NULL,
	ORIG_PART_NAME    	VARCHAR2(128) NULL,
	DELETED_ON_DATE   	DATE NULL,
	LAST_UPDT_DATE    	DATE NULL 
	)
/

CREATE TABLE FACID_FAC_DTLS ( 
	FAC_DTLS_ID	VARCHAR2(40) NOT NULL 
	)
/

CREATE TABLE FACID_FAC_ELEC_ADDR ( 
	FAC_ELEC_ADDR_ID   	VARCHAR2(40) NOT NULL,
	FAC_ID             	VARCHAR2(40) NOT NULL,
	ELEC_ADDR_TEXT     	VARCHAR2(255) NULL,
	ELEC_ADDR_TYPE_NAME	VARCHAR2(8) NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_ELEC_ADDR.FAC_ELEC_ADDR_ID IS 'Parent: A container for one or more electronic addresses. (FacilityElectronicAddressId)'
/
COMMENT ON COLUMN FACID_FAC_ELEC_ADDR.FAC_ID IS 'Parent: A container for one or more electronic addresses. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_ELEC_ADDR.ELEC_ADDR_TEXT IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressText)'
/
COMMENT ON COLUMN FACID_FAC_ELEC_ADDR.ELEC_ADDR_TYPE_NAME IS 'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)'
/

CREATE TABLE FACID_FAC_FAC_AFFL ( 
	FAC_FAC_AFFL_ID    	VARCHAR2(40) NOT NULL,
	FAC_ID             	VARCHAR2(40) NOT NULL,
	AFFL_IDEN          	VARCHAR2(255) NOT NULL,
	AFFL_TYPE_TEXT     	VARCHAR2(255) NULL,
	AFFL_START_DATE    	DATE NULL,
	AFFL_END_DATE      	DATE NULL,
	AFFL_STAT_TEXT     	VARCHAR2(4) NULL,
	AFFL_STAT_DETR_DATE	DATE NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.FAC_FAC_AFFL_ID IS 'Parent: A container for one or more affiliations. (FacilityFacilityAffiliationId)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.FAC_ID IS 'Parent: A container for one or more affiliations. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.AFFL_IDEN IS 'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.AFFL_TYPE_TEXT IS 'The name that describes the capacity or function that an organization or individual serves; or the relationship between an individual or organization and a project or action. (AffiliationTypeText)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.AFFL_START_DATE IS 'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.AFFL_END_DATE IS 'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.AFFL_STAT_TEXT IS 'The status of an affiliation between an individual or organization and a facility, project, or action. (AffiliationStatusText)'
/
COMMENT ON COLUMN FACID_FAC_FAC_AFFL.AFFL_STAT_DETR_DATE IS 'The date on which the status of an affiliation between an individual or organization and a facility, project, or action is determined. (AffiliationStatusDetermineDate)'
/

CREATE TABLE FACID_FAC_FAC_NAICS ( 
	FAC_FAC_NAICS_ID  	VARCHAR2(40) NOT NULL,
	FAC_ID            	VARCHAR2(40) NOT NULL,
	FAC_NAICS_CODE    	VARCHAR2(50) NULL,
	FAC_NAICS_PRI_INDI	VARCHAR2(9) NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_FAC_NAICS.FAC_FAC_NAICS_ID IS 'Parent: A container for one or more NAICS codes. (FacilityFacilityNAICSId)'
/
COMMENT ON COLUMN FACID_FAC_FAC_NAICS.FAC_ID IS 'Parent: A container for one or more NAICS codes. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_FAC_NAICS.FAC_NAICS_CODE IS 'The code that represents a subdivision of an industry that accommodates user needs in the United States. (FacilityNAICSCode)'
/
COMMENT ON COLUMN FACID_FAC_FAC_NAICS.FAC_NAICS_PRI_INDI IS 'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (FacilityNAICSPrimaryIndicator)'
/

CREATE TABLE FACID_FAC_FAC_SIC ( 
	FAC_FAC_SIC_ID	VARCHAR2(40) NOT NULL,
	FAC_ID        	VARCHAR2(40) NOT NULL,
	SIC_CODE      	VARCHAR2(50) NULL,
	SIC_PRI_INDI  	VARCHAR2(9) NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_FAC_SIC.FAC_FAC_SIC_ID IS 'Parent: A container for one or more SIC Codes. (FacilityFacilitySICId)'
/
COMMENT ON COLUMN FACID_FAC_FAC_SIC.FAC_ID IS 'Parent: A container for one or more SIC Codes. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_FAC_SIC.SIC_CODE IS 'The code that represents the economic activity of a company. (SICCode)'
/
COMMENT ON COLUMN FACID_FAC_FAC_SIC.SIC_PRI_INDI IS 'The name that indicates whether the associated SIC Code represents the primary activity occurring at the facility site. (SICPrimaryIndicator)'
/

CREATE TABLE FACID_FAC_GEO_LOC_DESC ( 
	FAC_GEO_LOC_DESC_ID           	VARCHAR2(40) NOT NULL,
	FAC_ID                        	VARCHAR2(40) NOT NULL,
	SRC_MAP_SCALE_NUM             	VARCHAR2(20) NULL,
	DATA_COLL_DATE                	DATE NULL,
	LOC_COMM_TEXT                 	VARCHAR2(255) NULL,
	SRS_NAME                      	VARCHAR2(255) NULL,
	SRS_DIM                       	VARCHAR2(10) NULL,
	LATITUDE                      	NUMBER(19,14) NULL,
	LONGITUDE                     	NUMBER(19,14) NULL,
	ELEVATION                     	NUMBER(19,14) NULL,
	MEAS_VAL                      	VARCHAR2(50) NULL,
	MEAS_PREC_TEXT                	VARCHAR2(50) NULL,
	MEAS_UNIT_CODE                	VARCHAR2(50) NULL,
	MEAS_UNIT_NAME                	VARCHAR2(50) NULL,
	CODE_LST_VER_VAL              	VARCHAR2(50) NULL,
	CODE_LIST_VERS_IDEN           	VARCHAR2(50) NULL,
	CODE_LIST_VERS_AGN_IDEN       	VARCHAR2(50) NULL,
	RSLT_QUAL_CODE                	VARCHAR2(50) NULL,
	RSLT_QUAL_NAME                	VARCHAR2(128) NULL,
	RSLT_QUAL_CODE_LST_VER_VAL    	VARCHAR2(50) NULL,
	RSLT_QUAL_CODE_LIST_VERS_IDEN 	VARCHAR2(50) NULL,
	RSLT_QUAL_CODE_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	METH_IDEN_CODE                	VARCHAR2(50) NULL,
	METH_NAME                     	VARCHAR2(128) NULL,
	METH_DESC_TEXT                	VARCHAR2(255) NULL,
	METH_DEVI_TEXT                	VARCHAR2(255) NULL,
	HORZ_COLL_METH_COD_LST_VER_VAL	VARCHAR2(50) NULL,
	HORZ_COLL_METH_COD_LIS_VER_IDE	VARCHAR2(50) NULL,
	HOR_COL_MET_COD_LIS_VER_AGN_ID	VARCHAR2(50) NULL,
	GEO_REF_PT_CODE               	VARCHAR2(50) NULL,
	GEO_REF_PT_NAME               	VARCHAR2(128) NULL,
	GEO_REF_PT_CODE_LST_VER_VAL   	VARCHAR2(50) NULL,
	GEO_REF_PT_CODE_LIST_VERS_IDEN	VARCHAR2(50) NULL,
	GEO_REF_PT_COD_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	VERT_COLL_METH_METH_IDEN_CODE 	VARCHAR2(50) NULL,
	VERT_COLL_METH_METH_NAME      	VARCHAR2(128) NULL,
	VERT_COLL_METH_METH_DESC_TEXT 	VARCHAR2(255) NULL,
	VERT_COLL_METH_METH_DEVI_TEXT 	VARCHAR2(255) NULL,
	VERT_COLL_METH_COD_LST_VER_VAL	VARCHAR2(50) NULL,
	VERT_COLL_METH_COD_LIS_VER_IDE	VARCHAR2(50) NULL,
	VER_COL_MET_COD_LIS_VER_AGN_ID	VARCHAR2(50) NULL,
	VERF_METH_METH_IDEN_CODE      	VARCHAR2(50) NULL,
	VERF_METH_METH_NAME           	VARCHAR2(128) NULL,
	VERF_METH_METH_DESC_TEXT      	VARCHAR2(255) NULL,
	VERF_METH_METH_DEVI_TEXT      	VARCHAR2(255) NULL,
	VERF_METH_CODE_LST_VER_VAL    	VARCHAR2(50) NULL,
	VERF_METH_CODE_LIST_VERS_IDEN 	VARCHAR2(50) NULL,
	VERF_METH_CODE_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	CORD_DATA_SRC_CODE            	VARCHAR2(50) NULL,
	CORD_DATA_SRC_NAME            	VARCHAR2(128) NULL,
	CORD_DATA_SRC_CODE_LST_VER_VAL	VARCHAR2(50) NULL,
	CORD_DATA_SRC_CODE_LIS_VER_IDE	VARCHAR2(50) NULL,
	COR_DAT_SRC_COD_LIS_VER_AGN_ID	VARCHAR2(50) NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.FAC_GEO_LOC_DESC_ID IS 'Parent: A container for one or more facility locations. (FacilityGeographicLocationDescriptionId)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.FAC_ID IS 'Parent: A container for one or more facility locations. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.SRC_MAP_SCALE_NUM IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.DATA_COLL_DATE IS 'The calendar date when data were collected. (DataCollectionDate)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.LOC_COMM_TEXT IS 'The text that provides additional information about the geographic coordinates. (LocationCommentsText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.SRS_NAME IS 'Parent: A container for one or more facility locations. (srsName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.SRS_DIM IS 'Parent: A container for one or more facility locations. (srsDimension)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.LATITUDE IS 'Parent: A container for one or more facility locations. (Latitude)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.LONGITUDE IS 'Parent: A container for one or more facility locations. (Longitude)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.ELEVATION IS 'Parent: A container for one or more facility locations. (Elevation)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.MEAS_VAL IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.MEAS_PREC_TEXT IS 'The precision of the recorded value. (MeasurePrecisionText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.MEAS_UNIT_CODE IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.MEAS_UNIT_NAME IS 'A description of the unit of measure code. (MeasureUnitName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CODE_LIST_VERS_AGN_IDEN IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.RSLT_QUAL_CODE IS 'A code used to identify any qualifying issues that affect the results. (ResultQualifierCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.RSLT_QUAL_NAME IS 'A description of the result code of any qualifying issues that affect the results. (ResultQualifierName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.RSLT_QUAL_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.RSLT_QUAL_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.RSLT_QUAL_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.METH_IDEN_CODE IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.METH_NAME IS 'The title of the method that appears on the method from the organization that published it. (MethodName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.METH_DESC_TEXT IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.METH_DEVI_TEXT IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.HORZ_COLL_METH_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.HORZ_COLL_METH_COD_LIS_VER_IDE IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.HOR_COL_MET_COD_LIS_VER_AGN_ID IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.GEO_REF_PT_CODE IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.GEO_REF_PT_NAME IS 'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.GEO_REF_PT_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.GEO_REF_PT_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.GEO_REF_PT_COD_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERT_COLL_METH_METH_IDEN_CODE IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERT_COLL_METH_METH_NAME IS 'The title of the method that appears on the method from the organization that published it. (MethodName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERT_COLL_METH_METH_DESC_TEXT IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERT_COLL_METH_METH_DEVI_TEXT IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERT_COLL_METH_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERT_COLL_METH_COD_LIS_VER_IDE IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VER_COL_MET_COD_LIS_VER_AGN_ID IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_METH_IDEN_CODE IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_METH_NAME IS 'The title of the method that appears on the method from the organization that published it. (MethodName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_METH_DESC_TEXT IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_METH_DEVI_TEXT IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.VERF_METH_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CORD_DATA_SRC_CODE IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CORD_DATA_SRC_NAME IS 'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CORD_DATA_SRC_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.CORD_DATA_SRC_CODE_LIS_VER_IDE IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_GEO_LOC_DESC.COR_DAT_SRC_COD_LIS_VER_AGN_ID IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/

CREATE TABLE FACID_FAC_PRI_GEO_LOC_DESC ( 
	FAC_PRI_GEO_LOC_DESC_ID       	VARCHAR2(40) NOT NULL,
	FAC_ID                        	VARCHAR2(40) NOT NULL,
	SRC_MAP_SCALE_NUM             	VARCHAR2(20) NULL,
	DATA_COLL_DATE                	DATE NULL,
	LOC_COMM_TEXT                 	VARCHAR2(255) NULL,
	SRS_NAME                      	VARCHAR2(255) NULL,
	SRS_DIM                       	VARCHAR2(10) NULL,
	LATITUDE                      	NUMBER(19,14) NULL,
	LONGITUDE                     	NUMBER(19,14) NULL,
	ELEVATION                     	NUMBER(19,14) NULL,
	MEAS_VAL                      	VARCHAR2(50) NULL,
	MEAS_PREC_TEXT                	VARCHAR2(50) NULL,
	MEAS_UNIT_CODE                	VARCHAR2(50) NULL,
	MEAS_UNIT_NAME                	VARCHAR2(50) NULL,
	CODE_LIST_VERS_IDEN           	VARCHAR2(50) NULL,
	CODE_LIST_VERS_AGN_IDEN       	VARCHAR2(50) NULL,
	CODE_LST_VER_VAL              	VARCHAR2(50) NULL,
	RSLT_QUAL_CODE                	VARCHAR2(50) NULL,
	RSLT_QUAL_NAME                	VARCHAR2(128) NULL,
	RSLT_QUAL_CODE_LIST_VERS_IDEN 	VARCHAR2(50) NULL,
	RSLT_QUAL_CODE_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	RSLT_QUAL_CODE_LST_VER_VAL    	VARCHAR2(50) NULL,
	METH_IDEN_CODE                	VARCHAR2(50) NULL,
	METH_NAME                     	VARCHAR2(128) NULL,
	METH_DESC_TEXT                	VARCHAR2(255) NULL,
	METH_DEVI_TEXT                	VARCHAR2(255) NULL,
	HORZ_COLL_METH_COD_LIS_VER_IDE	VARCHAR2(50) NULL,
	HOR_COL_MET_COD_LIS_VER_AGN_ID	VARCHAR2(50) NULL,
	HORZ_COLL_METH_COD_LST_VER_VAL	VARCHAR2(50) NULL,
	GEO_REF_PT_CODE               	VARCHAR2(50) NULL,
	GEO_REF_PT_NAME               	VARCHAR2(128) NULL,
	GEO_REF_PT_CODE_LIST_VERS_IDEN	VARCHAR2(50) NULL,
	GEO_REF_PT_COD_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	GEO_REF_PT_CODE_LST_VER_VAL   	VARCHAR2(50) NULL,
	VERT_COLL_METH_METH_IDEN_CODE 	VARCHAR2(50) NULL,
	VERT_COLL_METH_METH_NAME      	VARCHAR2(128) NULL,
	VERT_COLL_METH_METH_DESC_TEXT 	VARCHAR2(255) NULL,
	VERT_COLL_METH_METH_DEVI_TEXT 	VARCHAR2(255) NULL,
	VERT_COLL_METH_COD_LST_VER_VAL	VARCHAR2(50) NULL,
	VERT_COLL_METH_COD_LIS_VER_IDE	VARCHAR2(50) NULL,
	VER_COL_MET_COD_LIS_VER_AGN_ID	VARCHAR2(50) NULL,
	VERF_METH_METH_IDEN_CODE      	VARCHAR2(50) NULL,
	VERF_METH_METH_NAME           	VARCHAR2(128) NULL,
	VERF_METH_METH_DESC_TEXT      	VARCHAR2(255) NULL,
	VERF_METH_METH_DEVI_TEXT      	VARCHAR2(255) NULL,
	VERF_METH_CODE_LST_VER_VAL    	VARCHAR2(50) NULL,
	VERF_METH_CODE_LIST_VERS_IDEN 	VARCHAR2(50) NULL,
	VERF_METH_CODE_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	CORD_DATA_SRC_CODE            	VARCHAR2(50) NULL,
	CORD_DATA_SRC_NAME            	VARCHAR2(128) NULL,
	CORD_DATA_SRC_CODE_LIS_VER_IDE	VARCHAR2(50) NULL,
	COR_DAT_SRC_COD_LIS_VER_AGN_ID	VARCHAR2(50) NULL,
	CORD_DATA_SRC_CODE_LST_VER_VAL	VARCHAR2(50) NULL 
	)
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.FAC_PRI_GEO_LOC_DESC_ID IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (FacilityPrimaryGeographicLocationDescriptionId)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.FAC_ID IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.SRC_MAP_SCALE_NUM IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.DATA_COLL_DATE IS 'The calendar date when data were collected. (DataCollectionDate)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.LOC_COMM_TEXT IS 'The text that provides additional information about the geographic coordinates. (LocationCommentsText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.SRS_NAME IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (srsName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.SRS_DIM IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (srsDimension)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.LATITUDE IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Latitude)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.LONGITUDE IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Longitude)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.ELEVATION IS 'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Elevation)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.MEAS_VAL IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.MEAS_PREC_TEXT IS 'The precision of the recorded value. (MeasurePrecisionText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.MEAS_UNIT_CODE IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.MEAS_UNIT_NAME IS 'A description of the unit of measure code. (MeasureUnitName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CODE_LIST_VERS_AGN_IDEN IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.RSLT_QUAL_CODE IS 'A code used to identify any qualifying issues that affect the results. (ResultQualifierCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.RSLT_QUAL_NAME IS 'A description of the result code of any qualifying issues that affect the results. (ResultQualifierName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.RSLT_QUAL_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.RSLT_QUAL_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.RSLT_QUAL_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.METH_IDEN_CODE IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.METH_NAME IS 'The title of the method that appears on the method from the organization that published it. (MethodName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.METH_DESC_TEXT IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.METH_DEVI_TEXT IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.HORZ_COLL_METH_COD_LIS_VER_IDE IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.HOR_COL_MET_COD_LIS_VER_AGN_ID IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.HORZ_COLL_METH_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.GEO_REF_PT_CODE IS 'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.GEO_REF_PT_NAME IS 'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.GEO_REF_PT_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.GEO_REF_PT_COD_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.GEO_REF_PT_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERT_COLL_METH_METH_IDEN_CODE IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERT_COLL_METH_METH_NAME IS 'The title of the method that appears on the method from the organization that published it. (MethodName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERT_COLL_METH_METH_DESC_TEXT IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERT_COLL_METH_METH_DEVI_TEXT IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERT_COLL_METH_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERT_COLL_METH_COD_LIS_VER_IDE IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VER_COL_MET_COD_LIS_VER_AGN_ID IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_METH_IDEN_CODE IS 'The identification number or code assigned by the method publisher. (MethodIdentifierCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_METH_NAME IS 'The title of the method that appears on the method from the organization that published it. (MethodName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_METH_DESC_TEXT IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_METH_DEVI_TEXT IS 'Text that identifies any deviations from the published method reference. (MethodDeviationsText)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.VERF_METH_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CORD_DATA_SRC_CODE IS 'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CORD_DATA_SRC_NAME IS 'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CORD_DATA_SRC_CODE_LIS_VER_IDE IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.COR_DAT_SRC_COD_LIS_VER_AGN_ID IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC_PRI_GEO_LOC_DESC.CORD_DATA_SRC_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/

CREATE TABLE FACID_FAC ( 
	FAC_ID                        	VARCHAR2(40) NOT NULL,
	FAC_DTLS_ID                   	VARCHAR2(40) NOT NULL,
	CONG_DIST_NUM_CODE            	VARCHAR2(50) NULL,
	LEGI_DIST_NUM_CODE            	VARCHAR2(50) NULL,
	HUC_CODE                      	VARCHAR2(50) NULL,
	FAC_URL_TEXT                  	VARCHAR2(255) NULL,
	DELETED_ON_DATE               	DATE NULL,
	FAC_ACTIVE_INDI               	VARCHAR2(1) NULL,
	FAC_SITE_NAME                 	VARCHAR2(128) NULL,
	FED_FAC_INDI                  	VARCHAR2(4) NULL,
	FAC_SITE_IDEN_CONT            	VARCHAR2(255) NULL,
	FAC_SITE_IDEN_VAL             	VARCHAR2(50) NULL,
	FAC_SITE_TYPE_CODE            	VARCHAR2(50) NULL,
	FAC_SITE_TYPE_NAME            	VARCHAR2(128) NULL,
	CODE_LIST_VERS_IDEN           	VARCHAR2(50) NULL,
	CODE_LIST_VERS_AGN_IDEN       	VARCHAR2(50) NULL,
	CODE_LST_VER_VAL              	VARCHAR2(50) NULL,
	LOC_ADDR_TEXT                 	VARCHAR2(255) NULL,
	SUPP_LOC_TEXT                 	VARCHAR2(255) NULL,
	LOCA_NAME                     	VARCHAR2(128) NULL,
	TRIB_LAND_NAME                	VARCHAR2(128) NULL,
	TRIB_LAND_INDI                	VARCHAR2(4) NULL,
	LOC_DESC_TEXT                 	VARCHAR2(255) NULL,
	STA_CODE                      	VARCHAR2(50) NULL,
	STA_NAME                      	VARCHAR2(128) NULL,
	LOC_ADDR_CODE_LST_VER_VAL     	VARCHAR2(50) NULL,
	LOC_ADDR_CODE_LIST_VERS_IDEN  	VARCHAR2(50) NULL,
	LOC_ADDR_CODE_LIST_VER_AGN_IDE	VARCHAR2(50) NULL,
	ADDR_POST_CODE_VAL            	VARCHAR2(50) NULL,
	ADDR_POST_CODE_CONT           	VARCHAR2(50) NULL,
	CTRY_CODE                     	VARCHAR2(50) NULL,
	CTRY_NAME                     	VARCHAR2(128) NULL,
	LOC_ADDR_COD_LST_VER_VAL      	VARCHAR2(50) NULL,
	LOC_ADDR_CODE_LIST_VERS_IDE   	VARCHAR2(50) NULL,
	LOC_ADDR_CODE_LIS_VER_AGN_IDE 	VARCHAR2(50) NULL,
	CNTY_CODE                     	VARCHAR2(50) NULL,
	CNTY_NAME                     	VARCHAR2(128) NULL,
	LOC_ADDR_CODE_LIST_VER_IDE    	VARCHAR2(50) NULL,
	LOC_ADDR_COD_LIS_VER_AGN_IDE  	VARCHAR2(50) NULL,
	LOC_ADD_COD_LST_VER_VAL       	VARCHAR2(50) NULL,
	MAIL_ADDR_TEXT                	VARCHAR2(255) NULL,
	SUPP_ADDR_TEXT                	VARCHAR2(255) NULL,
	MAIL_ADDR_CITY_NAME           	VARCHAR2(128) NULL,
	MAIL_ADDR_STA_CODE            	VARCHAR2(50) NULL,
	MAIL_ADDR_STA_NAME            	VARCHAR2(128) NULL,
	MAIL_ADDR_CODE_LST_VER_VAL    	VARCHAR2(50) NULL,
	MAIL_ADDR_CODE_LIST_VERS_IDEN 	VARCHAR2(50) NULL,
	MAIL_ADDR_CODE_LIS_VER_AGN_IDE	VARCHAR2(50) NULL,
	MAIL_ADDR_ADDR_POST_CODE_VAL  	VARCHAR2(50) NULL,
	MAIL_ADDR_ADDR_POST_CODE_CONT 	VARCHAR2(50) NULL,
	MAIL_ADDR_CTRY_CODE           	VARCHAR2(50) NULL,
	MAIL_ADDR_CTRY_NAME           	VARCHAR2(128) NULL,
	MAIL_ADDR_COD_LST_VER_VAL     	VARCHAR2(50) NULL,
	MAIL_ADDR_CODE_LIST_VERS_IDE  	VARCHAR2(50) NULL,
	MAIL_ADDR_COD_LIS_VER_AGN_IDE 	VARCHAR2(50) NULL,
	ORIG_PART_NAME                	VARCHAR2(128) NULL,
	INFO_SYS_ACRO_NAME            	VARCHAR2(128) NULL,
	LAST_UPDT_DATE                	DATE NULL 
	)
/
COMMENT ON COLUMN FACID_FAC.FAC_ID IS 'Parent: A container for one or more facility sites for a partner. (FacilityId)'
/
COMMENT ON COLUMN FACID_FAC.FAC_DTLS_ID IS 'Parent: A container for one or more facility sites for a partner. (FacilityDetailsId)'
/
COMMENT ON COLUMN FACID_FAC.CONG_DIST_NUM_CODE IS 'A number representing an area within a state that a member of the House of Representatives is elected. (CongressionalDistrictNumberCode)'
/
COMMENT ON COLUMN FACID_FAC.LEGI_DIST_NUM_CODE IS 'A number representing an area from which senators and General Assembly members are elected. (LegislativeDistrictNumberCode)'
/
COMMENT ON COLUMN FACID_FAC.HUC_CODE IS 'The hydrologic unit code (HUC) that represents a geographic area representing part or all of a surface drainage basin, a combination of drainage basins, or a distinct hydrologic feature. (HUCCode)'
/
COMMENT ON COLUMN FACID_FAC.FAC_URL_TEXT IS 'The web address where a computer user can access information about the facility. (FacilityURLText)'
/
COMMENT ON COLUMN FACID_FAC.DELETED_ON_DATE IS 'The date that this facility was deleted, or null if the facility has not been deleted. (DeletedOnDate)'
/
COMMENT ON COLUMN FACID_FAC.FAC_ACTIVE_INDI IS 'A designator that indicates whether the Facility is currently considered to active. (FacilityActiveIndicator)'
/
COMMENT ON COLUMN FACID_FAC.FAC_SITE_NAME IS 'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)'
/
COMMENT ON COLUMN FACID_FAC.FED_FAC_INDI IS 'An indicator identifying facilities owned or operated by a federal government unit. (FederalFacilityIndicator)'
/
COMMENT ON COLUMN FACID_FAC.FAC_SITE_IDEN_CONT IS 'Parent: The unique identification number used by a governmental entity to identify a facility site. (FacilitySiteIdentifierContext)'
/
COMMENT ON COLUMN FACID_FAC.FAC_SITE_IDEN_VAL IS 'Parent: The unique identification number used by a governmental entity to identify a facility site. (Value)'
/
COMMENT ON COLUMN FACID_FAC.FAC_SITE_TYPE_CODE IS 'The code that represents the type of site a facility occupies. (FacilitySiteTypeCode)'
/
COMMENT ON COLUMN FACID_FAC.FAC_SITE_TYPE_NAME IS 'The descriptive name for the type of site the facility occupies. (FacilitySiteTypeName)'
/
COMMENT ON COLUMN FACID_FAC.CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.CODE_LIST_VERS_AGN_IDEN IS 'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_TEXT IS 'The address that describes the physical (geographic) location of the front door or main entrance of a facility site, including urban-style street address or rural address. (LocationAddressText)'
/
COMMENT ON COLUMN FACID_FAC.SUPP_LOC_TEXT IS 'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name or descriptive text where no formal address is available. (SupplementalLocationText)'
/
COMMENT ON COLUMN FACID_FAC.LOCA_NAME IS 'The name of a city, town, village or other locality. (LocalityName)'
/
COMMENT ON COLUMN FACID_FAC.TRIB_LAND_NAME IS 'The name of an American Indian or Alaskan native area where the location address exists. (TribalLandName)'
/
COMMENT ON COLUMN FACID_FAC.TRIB_LAND_INDI IS 'An indicator denoting the location address is a tribal land (TribalLandIndicator)'
/
COMMENT ON COLUMN FACID_FAC.LOC_DESC_TEXT IS 'A brief explanation of a location, including navigational directions and/or more descriptive information. (LocationDescriptionText)'
/
COMMENT ON COLUMN FACID_FAC.STA_CODE IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)'
/
COMMENT ON COLUMN FACID_FAC.STA_NAME IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_CODE_LIST_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.ADDR_POST_CODE_VAL IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)'
/
COMMENT ON COLUMN FACID_FAC.ADDR_POST_CODE_CONT IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)'
/
COMMENT ON COLUMN FACID_FAC.CTRY_CODE IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)'
/
COMMENT ON COLUMN FACID_FAC.CTRY_NAME IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_CODE_LIST_VERS_IDE IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.CNTY_CODE IS 'The code that represents the county. (CountyCode)'
/
COMMENT ON COLUMN FACID_FAC.CNTY_NAME IS 'A description of the county code. (CountyName)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_CODE_LIST_VER_IDE IS 'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADDR_COD_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.LOC_ADD_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_TEXT IS 'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)'
/
COMMENT ON COLUMN FACID_FAC.SUPP_ADDR_TEXT IS 'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CITY_NAME IS 'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_STA_CODE IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_STA_NAME IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CODE_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CODE_LIST_VERS_IDEN IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CODE_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_ADDR_POST_CODE_VAL IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_ADDR_POST_CODE_CONT IS 'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CTRY_CODE IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CTRY_NAME IS 'A name used to identify a primary geopolitical unit of the world. (CountryName)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_COD_LST_VER_VAL IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_CODE_LIST_VERS_IDE IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.MAIL_ADDR_COD_LIS_VER_AGN_IDE IS 'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)'
/
COMMENT ON COLUMN FACID_FAC.ORIG_PART_NAME IS 'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)'
/
COMMENT ON COLUMN FACID_FAC.INFO_SYS_ACRO_NAME IS 'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)'
/
COMMENT ON COLUMN FACID_FAC.LAST_UPDT_DATE IS 'A value corresponding to the date the facility site or environmental interest was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)'
/

CREATE TABLE FACID_POS ( 
	POS_ID     	VARCHAR2(40) NOT NULL,
	SHAPE_ID   	VARCHAR2(40) NOT NULL,
	ORDER_INDEX	NUMBER NOT NULL,
	LATITUDE   	NUMBER(19,14) NULL,
	LONGITUDE  	NUMBER(19,14) NULL,
	ELEVATION  	NUMBER(19,14) NULL 
	)
/
COMMENT ON COLUMN FACID_POS.POS_ID IS 'Parent: A container for one or more facility locations. (PositionId)'
/
COMMENT ON COLUMN FACID_POS.SHAPE_ID IS 'Parent: A container for one or more facility locations. (ShapeId)'
/
COMMENT ON COLUMN FACID_POS.ORDER_INDEX IS 'Parent: A container for one or more facility locations. (OrderIndex)'
/
COMMENT ON COLUMN FACID_POS.LATITUDE IS 'Parent: A container for one or more facility locations. (Latitude)'
/
COMMENT ON COLUMN FACID_POS.LONGITUDE IS 'Parent: A container for one or more facility locations. (Longitude)'
/
COMMENT ON COLUMN FACID_POS.ELEVATION IS 'Parent: A container for one or more facility locations. (Elevation)'
/

CREATE TABLE FACID_SHAPE ( 
	SHAPE_ID           	VARCHAR2(40) NOT NULL,
	FAC_GEO_LOC_DESC_ID	VARCHAR2(40) NOT NULL,
	TYPE               	VARCHAR2(10) NOT NULL,
	SRS_NAME           	VARCHAR2(255) NULL,
	SRS_DIM            	VARCHAR2(10) NULL 
	)
/
COMMENT ON COLUMN FACID_SHAPE.SHAPE_ID IS 'Parent: A container for one or more facility locations. (ShapeId)'
/
COMMENT ON COLUMN FACID_SHAPE.FAC_GEO_LOC_DESC_ID IS 'Parent: A container for one or more facility locations. (FacilityGeographicLocationDescriptionId)'
/
COMMENT ON COLUMN FACID_SHAPE.TYPE IS 'Parent: A container for one or more facility locations. (Type)'
/
COMMENT ON COLUMN FACID_SHAPE.SRS_NAME IS 'Parent: A container for one or more facility locations. (srsName)'
/
COMMENT ON COLUMN FACID_SHAPE.SRS_DIM IS 'Parent: A container for one or more facility locations. (srsDimension)'
/

CREATE TABLE FACID_TELEPHONIC ( 
	TELEPHONIC_ID     	VARCHAR2(40) NOT NULL,
	AFFL_ID           	VARCHAR2(40) NOT NULL,
	TELE_NUM_TEXT     	VARCHAR2(20) NULL,
	TELE_NUM_TYPE_NAME	VARCHAR2(128) NULL,
	TELE_EXT_NUM_TEXT 	VARCHAR2(20) NULL 
	)
/
COMMENT ON COLUMN FACID_TELEPHONIC.TELEPHONIC_ID IS 'Parent: A container for one or more telephone numbers. (TelephonicId)'
/
COMMENT ON COLUMN FACID_TELEPHONIC.AFFL_ID IS 'Parent: A container for one or more telephone numbers. (AffiliateId)'
/
COMMENT ON COLUMN FACID_TELEPHONIC.TELE_NUM_TEXT IS 'The number that identifies a particular telephone connection. (TelephoneNumberText)'
/
COMMENT ON COLUMN FACID_TELEPHONIC.TELE_NUM_TYPE_NAME IS 'The name that describes a telephone number type. (TelephoneNumberTypeName)'
/
COMMENT ON COLUMN FACID_TELEPHONIC.TELE_EXT_NUM_TEXT IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)'
/


CREATE UNIQUE INDEX PK_AFFL_ELEC_ADDR
	ON FACID_AFFL_ELEC_ADDR(AFFL_ELEC_ADDR_ID)
/

CREATE INDEX IX_AFF_EL_AD_AF_ID
	ON FACID_AFFL_ELEC_ADDR(AFFL_ID)
/

CREATE UNIQUE INDEX UK_FACID_AFFL_AFFL_IDEN
	ON FACID_AFFL(AFFL_IDEN)
/

CREATE INDEX IX_AFF_AD_PO_CO_VA
	ON FACID_AFFL(ADDR_POST_CODE_VAL)
/

CREATE UNIQUE INDEX FACID_AFFL_PK
	ON FACID_AFFL(AFFL_ID)
/

CREATE INDEX IX_FACID_AFFL
	ON FACID_AFFL(MIDDLE_NAME)
/

CREATE INDEX IX_AFFL_FAC_DTL_ID
	ON FACID_AFFL(FAC_DTLS_ID)
/

CREATE INDEX IX_AFFL_STA_CODE
	ON FACID_AFFL(STA_CODE)
/

CREATE INDEX IX_ALT_NAME_FAC_ID
	ON FACID_ALT_NAME(FAC_ID)
/

CREATE UNIQUE INDEX PK_ALT_NAME
	ON FACID_ALT_NAME(ALT_NAME_ID)
/

CREATE UNIQUE INDEX PK_ENV_INT_ALT_IDE
	ON FACID_ENVR_INTR_ALT_IDEN(ENVR_INTR_ALT_IDEN_ID)
/

CREATE INDEX IX_EN_IN_AL_ID_EN
	ON FACID_ENVR_INTR_ALT_IDEN(ENVR_INTR_ID)
/

CREATE UNIQUE INDEX PK_ENV_INT_ELE_ADD
	ON FACID_ENVR_INTR_ELEC_ADDR(ENVR_INTR_ELEC_ADDR_ID)
/

CREATE INDEX IX_EN_IN_EL_AD_EN
	ON FACID_ENVR_INTR_ELEC_ADDR(ENVR_INTR_ID)
/

CREATE INDEX IX_EN_IN_FA_AF_EN
	ON FACID_ENVR_INTR_FAC_AFFL(ENVR_INTR_ID)
/

CREATE UNIQUE INDEX PK_ENV_INT_FAC_AFF
	ON FACID_ENVR_INTR_FAC_AFFL(ENVR_INTR_FAC_AFFL_ID)
/

CREATE INDEX IX_EI_AFFL_IDEN
	ON FACID_ENVR_INTR_FAC_AFFL(AFFL_IDEN)
/

CREATE INDEX IX_EN_IN_FA_NA_EN
	ON FACID_ENVR_INTR_FAC_NAICS(ENVR_INTR_ID)
/

CREATE UNIQUE INDEX PK_ENV_INT_FAC_NAI
	ON FACID_ENVR_INTR_FAC_NAICS(ENVR_INTR_FAC_NAICS_ID)
/

CREATE UNIQUE INDEX PK_ENV_INT_FAC_SIC
	ON FACID_ENVR_INTR_FAC_SIC(ENVR_INTR_FAC_SIC_ID)
/

CREATE INDEX IX_EN_IN_FA_SI_EN
	ON FACID_ENVR_INTR_FAC_SIC(ENVR_INTR_ID)
/

CREATE INDEX IX_EN_IN_IN_SY_AC
	ON FACID_ENVR_INTR(INFO_SYS_ACRO_NAME)
/

CREATE INDEX IX_ENVR_INT_FAC_ID
	ON FACID_ENVR_INTR(FAC_ID)
/

CREATE INDEX IX_ENV_IN_OR_PA_NA
	ON FACID_ENVR_INTR(ORIG_PART_NAME)
/

CREATE INDEX IX_ENV_IN_LA_UP_DA
	ON FACID_ENVR_INTR(LAST_UPDT_DATE)
/

CREATE UNIQUE INDEX PK_ENVR_INTR
	ON FACID_ENVR_INTR(ENVR_INTR_ID)
/

CREATE INDEX IX_ENV_IN_IDEN
	ON FACID_ENVR_INTR(ENVR_INTR_IDEN)
/

CREATE UNIQUE INDEX PK_FAC_ALT_IDEN
	ON FACID_FAC_ALT_IDEN(FAC_ALT_IDEN_ID)
/

CREATE INDEX IX_FAC_AL_ID_FA_ID
	ON FACID_FAC_ALT_IDEN(FAC_ID)
/

CREATE UNIQUE INDEX PK__FACID_FAC_DEL__5B638405
	ON FACID_FAC_DEL(FAC_SITE_IDEN_VAL)
/

CREATE UNIQUE INDEX PK_FAC_DTLS
	ON FACID_FAC_DTLS(FAC_DTLS_ID)
/

CREATE UNIQUE INDEX PK_FAC_ELEC_ADDR
	ON FACID_FAC_ELEC_ADDR(FAC_ELEC_ADDR_ID)
/

CREATE INDEX IX_FAC_EL_AD_FA_ID
	ON FACID_FAC_ELEC_ADDR(FAC_ID)
/

CREATE INDEX IX_FAC_FA_AF_FA_ID
	ON FACID_FAC_FAC_AFFL(FAC_ID)
/

CREATE INDEX IX_FAC_AFFL_IDEN
	ON FACID_FAC_FAC_AFFL(AFFL_IDEN)
/

CREATE UNIQUE INDEX PK_FAC_FAC_AFFL
	ON FACID_FAC_FAC_AFFL(FAC_FAC_AFFL_ID)
/

CREATE INDEX IX_FAC_FA_NA_FA_ID
	ON FACID_FAC_FAC_NAICS(FAC_ID)
/

CREATE UNIQUE INDEX PK_FAC_FAC_NAICS
	ON FACID_FAC_FAC_NAICS(FAC_FAC_NAICS_ID)
/

CREATE INDEX IX_FAC_FA_SI_FA_ID
	ON FACID_FAC_FAC_SIC(FAC_ID)
/

CREATE UNIQUE INDEX PK_FAC_FAC_SIC
	ON FACID_FAC_FAC_SIC(FAC_FAC_SIC_ID)
/

CREATE UNIQUE INDEX PK_FAC_GEO_LOC_DES
	ON FACID_FAC_GEO_LOC_DESC(FAC_GEO_LOC_DESC_ID)
/

CREATE INDEX IX_FAC_GE_LO_DE_LA
	ON FACID_FAC_GEO_LOC_DESC(LATITUDE)
/

CREATE INDEX IX_FA_GE_LO_DE_FA
	ON FACID_FAC_GEO_LOC_DESC(FAC_ID)
/

CREATE INDEX IX_FAC_GE_LO_DE_LO
	ON FACID_FAC_GEO_LOC_DESC(LONGITUDE)
/

CREATE INDEX IX_FAC_GE_LO_DE_EL
	ON FACID_FAC_GEO_LOC_DESC(ELEVATION)
/

CREATE UNIQUE INDEX PK_FAC_PR_GE_LO_DE
	ON FACID_FAC_PRI_GEO_LOC_DESC(FAC_PRI_GEO_LOC_DESC_ID)
/

CREATE INDEX IX_FA_PR_GE_LO_02
	ON FACID_FAC_PRI_GEO_LOC_DESC(LATITUDE)
/

CREATE INDEX IX_FA_PR_GE_LO_03
	ON FACID_FAC_PRI_GEO_LOC_DESC(LONGITUDE)
/

CREATE INDEX IX_FA_PR_GE_LO_04
	ON FACID_FAC_PRI_GEO_LOC_DESC(ELEVATION)
/

CREATE INDEX IX_FA_PR_GE_LO_DE
	ON FACID_FAC_PRI_GEO_LOC_DESC(FAC_ID)
/

CREATE UNIQUE INDEX PK_FACILITY_ID
	ON FACID_FAC(FAC_ID)
/

CREATE INDEX IX_FAC_ORI_PAR_NAM
	ON FACID_FAC(ORIG_PART_NAME)
/

CREATE INDEX IX_FAC_LAS_UPD_DAT
	ON FACID_FAC(LAST_UPDT_DATE)
/

CREATE INDEX IX_FAC_FA_SI_ID_VA
	ON FACID_FAC(FAC_SITE_IDEN_VAL)
/

CREATE INDEX IX_FAC_LOCA_NAME
	ON FACID_FAC(LOCA_NAME)
/

CREATE INDEX IX_FAC_IN_SY_AC_NA
	ON FACID_FAC(INFO_SYS_ACRO_NAME)
/

CREATE INDEX IX_FA_MA_AD_AD_PO
	ON FACID_FAC(MAIL_ADDR_ADDR_POST_CODE_VAL)
/

CREATE INDEX IX_FAC_FAC_DTLS_ID
	ON FACID_FAC(FAC_DTLS_ID)
/

CREATE INDEX IX_FAC_FAC_SIT_NAM
	ON FACID_FAC(FAC_SITE_NAME)
/

CREATE INDEX IX_FAC_STA_CODE
	ON FACID_FAC(STA_CODE)
/

CREATE INDEX IX_FAC_AD_PO_CO_VA
	ON FACID_FAC(ADDR_POST_CODE_VAL)
/

CREATE INDEX IX_FAC_CNTY_NAME
	ON FACID_FAC(CNTY_NAME)
/

CREATE INDEX IX_FAC_MA_AD_ST_CO
	ON FACID_FAC(MAIL_ADDR_STA_CODE)
/

CREATE INDEX IX_POS_SHAPE_ID
	ON FACID_POS(SHAPE_ID)
/

CREATE INDEX IX_POS_LATITUDE
	ON FACID_POS(LATITUDE)
/

CREATE UNIQUE INDEX PK_POS
	ON FACID_POS(POS_ID)
/

CREATE INDEX IX_POS_ELEVATION
	ON FACID_POS(ELEVATION)
/

CREATE INDEX IX_POS_LONGITUDE
	ON FACID_POS(LONGITUDE)
/

CREATE UNIQUE INDEX PK_SHAPE
	ON FACID_SHAPE(SHAPE_ID)
/

CREATE INDEX IX_SH_FA_GE_LO_DE
	ON FACID_SHAPE(FAC_GEO_LOC_DESC_ID)
/

CREATE UNIQUE INDEX PK_TELEPHONIC
	ON FACID_TELEPHONIC(TELEPHONIC_ID)
/

CREATE INDEX IX_TELEPHO_AFFL_ID
	ON FACID_TELEPHONIC(AFFL_ID)
/

ALTER TABLE FACID_AFFL_ELEC_ADDR
	ADD ( CONSTRAINT PK_AFFL_ELEC_ADDR
	PRIMARY KEY (AFFL_ELEC_ADDR_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_AFFL
	ADD ( CONSTRAINT FACID_AFFL_PK
	PRIMARY KEY (AFFL_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ALT_NAME
	ADD ( CONSTRAINT PK_ALT_NAME
	PRIMARY KEY (ALT_NAME_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ENVR_INTR_ALT_IDEN
	ADD ( CONSTRAINT PK_ENV_INT_ALT_IDE
	PRIMARY KEY (ENVR_INTR_ALT_IDEN_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ENVR_INTR_ELEC_ADDR
	ADD ( CONSTRAINT PK_ENV_INT_ELE_ADD
	PRIMARY KEY (ENVR_INTR_ELEC_ADDR_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_AFFL
	ADD ( CONSTRAINT PK_ENV_INT_FAC_AFF
	PRIMARY KEY (ENVR_INTR_FAC_AFFL_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_NAICS
	ADD ( CONSTRAINT PK_ENV_INT_FAC_NAI
	PRIMARY KEY (ENVR_INTR_FAC_NAICS_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_SIC
	ADD ( CONSTRAINT PK_ENV_INT_FAC_SIC
	PRIMARY KEY (ENVR_INTR_FAC_SIC_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_ENVR_INTR
	ADD ( CONSTRAINT PK_ENVR_INTR
	PRIMARY KEY (ENVR_INTR_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_ALT_IDEN
	ADD ( CONSTRAINT PK_FAC_ALT_IDEN
	PRIMARY KEY (FAC_ALT_IDEN_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_DEL
	ADD ( CONSTRAINT PK__FACID_FAC_DEL__5B638405
	PRIMARY KEY (FAC_SITE_IDEN_VAL)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_DTLS
	ADD ( CONSTRAINT PK_FAC_DTLS
	PRIMARY KEY (FAC_DTLS_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_ELEC_ADDR
	ADD ( CONSTRAINT PK_FAC_ELEC_ADDR
	PRIMARY KEY (FAC_ELEC_ADDR_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_FAC_AFFL
	ADD ( CONSTRAINT PK_FAC_FAC_AFFL
	PRIMARY KEY (FAC_FAC_AFFL_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_FAC_NAICS
	ADD ( CONSTRAINT PK_FAC_FAC_NAICS
	PRIMARY KEY (FAC_FAC_NAICS_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_FAC_SIC
	ADD ( CONSTRAINT PK_FAC_FAC_SIC
	PRIMARY KEY (FAC_FAC_SIC_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_GEO_LOC_DESC
	ADD ( CONSTRAINT PK_FAC_GEO_LOC_DES
	PRIMARY KEY (FAC_GEO_LOC_DESC_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC_PRI_GEO_LOC_DESC
	ADD ( CONSTRAINT PK_FAC_PR_GE_LO_DE
	PRIMARY KEY (FAC_PRI_GEO_LOC_DESC_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_FAC
	ADD ( CONSTRAINT PK_FACILITY_ID
	PRIMARY KEY (FAC_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_POS
	ADD ( CONSTRAINT PK_POS
	PRIMARY KEY (POS_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_SHAPE
	ADD ( CONSTRAINT PK_SHAPE
	PRIMARY KEY (SHAPE_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_TELEPHONIC
	ADD ( CONSTRAINT PK_TELEPHONIC
	PRIMARY KEY (TELEPHONIC_ID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_AFFL
	ADD ( CONSTRAINT UK_FACID_AFFL_AFFL_IDEN
	UNIQUE (AFFL_IDEN)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE FACID_AFFL_ELEC_ADDR
	ADD ( CONSTRAINT FK_FACID_AFFL_ELEC_ADDR
	FOREIGN KEY(AFFL_ID)
	REFERENCES FACID_AFFL(AFFL_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_AFFL
	ADD ( CONSTRAINT FK_AFFL_FAC_DTLS
	FOREIGN KEY(FAC_DTLS_ID)
	REFERENCES FACID_FAC_DTLS(FAC_DTLS_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ALT_NAME
	ADD ( CONSTRAINT FK_ALT_NAME_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR_ALT_IDEN
	ADD ( CONSTRAINT FK_EN_IN_AL_ID_EN
	FOREIGN KEY(ENVR_INTR_ID)
	REFERENCES FACID_ENVR_INTR(ENVR_INTR_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR_ELEC_ADDR
	ADD ( CONSTRAINT FK_EN_IN_EL_AD_EN
	FOREIGN KEY(ENVR_INTR_ID)
	REFERENCES FACID_ENVR_INTR(ENVR_INTR_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_AFFL
	ADD ( CONSTRAINT FK_FAC_ENV_INT_FAC_AFL_FAC_AFL
	FOREIGN KEY(AFFL_IDEN)
	REFERENCES FACID_AFFL(AFFL_IDEN)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_AFFL
	ADD ( CONSTRAINT FK_EN_IN_FA_AF_EN
	FOREIGN KEY(ENVR_INTR_ID)
	REFERENCES FACID_ENVR_INTR(ENVR_INTR_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_NAICS
	ADD ( CONSTRAINT FK_EN_IN_FA_NA_EN
	FOREIGN KEY(ENVR_INTR_ID)
	REFERENCES FACID_ENVR_INTR(ENVR_INTR_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR_FAC_SIC
	ADD ( CONSTRAINT FK_EN_IN_FA_SI_EN
	FOREIGN KEY(ENVR_INTR_ID)
	REFERENCES FACID_ENVR_INTR(ENVR_INTR_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_ENVR_INTR
	ADD ( CONSTRAINT FK_ENVR_INTR_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_ALT_IDEN
	ADD ( CONSTRAINT FK_FAC_ALT_IDE_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_ELEC_ADDR
	ADD ( CONSTRAINT FK_FAC_ELE_ADD_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_FAC_AFFL
	ADD ( CONSTRAINT FK_FAC_FAC_AFL_FAC_AFFL
	FOREIGN KEY(AFFL_IDEN)
	REFERENCES FACID_AFFL(AFFL_IDEN)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_FAC_AFFL
	ADD ( CONSTRAINT FK_FAC_FAC_AFF_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_FAC_NAICS
	ADD ( CONSTRAINT FK_FAC_FAC_NAI_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_FAC_SIC
	ADD ( CONSTRAINT FK_FAC_FAC_SIC_FAC
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_GEO_LOC_DESC
	ADD ( CONSTRAINT FK_FAC_GE_LO_DE_FA
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC_PRI_GEO_LOC_DESC
	ADD ( CONSTRAINT FK_FA_PR_GE_LO_DE
	FOREIGN KEY(FAC_ID)
	REFERENCES FACID_FAC(FAC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_FAC
	ADD ( CONSTRAINT FK_FAC_FAC_DTLS
	FOREIGN KEY(FAC_DTLS_ID)
	REFERENCES FACID_FAC_DTLS(FAC_DTLS_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_POS
	ADD ( CONSTRAINT FK_POS_SHAPE
	FOREIGN KEY(SHAPE_ID)
	REFERENCES FACID_SHAPE(SHAPE_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_SHAPE
	ADD ( CONSTRAINT FK_SHA_FA_GE_LO_DE
	FOREIGN KEY(FAC_GEO_LOC_DESC_ID)
	REFERENCES FACID_FAC_GEO_LOC_DESC(FAC_GEO_LOC_DESC_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE FACID_TELEPHONIC
	ADD ( CONSTRAINT FK_FACID_TELEPHONIC
	FOREIGN KEY(AFFL_ID)
	REFERENCES FACID_AFFL(AFFL_ID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

