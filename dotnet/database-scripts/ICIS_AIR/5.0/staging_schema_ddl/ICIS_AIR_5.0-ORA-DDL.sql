--------------------------------------------------------
--  File created - Wednesday-July-09-2014   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ICA_CASE_FILE_CMNT_TXT
--------------------------------------------------------

  CREATE TABLE "ICA_CASE_FILE_CMNT_TXT" 
   (	"ICA_CASE_FILE_CMNT_TXT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"CASE_FILE_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_CASE_FILE_CMNT_TXT"."CASE_FILE_CMNT_TXT" IS 'CaseFileCommentText';
 
   COMMENT ON TABLE "ICA_CASE_FILE_CMNT_TXT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_CASE_FILE_LNK
--------------------------------------------------------

  CREATE TABLE "ICA_CASE_FILE_LNK" 
   (	"ICA_CASE_FILE_LNK_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"CASE_FILE_IDENT" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_CASE_FILE_LNK"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_CASE_FILE_LNK"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_CASE_FILE_LNK"."CASE_FILE_IDENT" IS 'CaseFileIdentifier';
 
   COMMENT ON TABLE "ICA_CASE_FILE_LNK"  IS 'Schema element: CaseFileLinkageData';
/
--------------------------------------------------------
--  DDL for Table ICA_CMPL_INSP_TYPE
--------------------------------------------------------

  CREATE TABLE "ICA_CMPL_INSP_TYPE" 
   (	"ICA_CMPL_INSP_TYPE_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"CMPL_INSP_TYPE_CODE" VARCHAR2(3 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_CMPL_INSP_TYPE"."CMPL_INSP_TYPE_CODE" IS 'ComplianceInspectionTypeCode';
 
   COMMENT ON TABLE "ICA_CMPL_INSP_TYPE"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_CMPL_MON_LNK
--------------------------------------------------------

  CREATE TABLE "ICA_CMPL_MON_LNK" 
   (	"ICA_CMPL_MON_LNK_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"CMPL_MON_IDENT" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_CMPL_MON_LNK"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_LNK"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_LNK"."CMPL_MON_IDENT" IS 'ComplianceMonitoringIdentifier';
 
   COMMENT ON TABLE "ICA_CMPL_MON_LNK"  IS 'Schema element: ComplianceMonitoringLinkageData';
/
--------------------------------------------------------
--  DDL for Table ICA_CMPL_MON_STRGY
--------------------------------------------------------

  CREATE TABLE "ICA_CMPL_MON_STRGY" 
   (	"ICA_CMPL_MON_STRGY_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"FAC_IDENT" CHAR(18 BYTE), 
	"CMS_SRC_CATG_CODE" VARCHAR2(3 BYTE), 
	"CMS_MIN_FREQ" NUMBER(10,0), 
	"CMS_START_DATE" TIMESTAMP (6), 
	"ACTIVE_CMS_PLAN_IND" CHAR(1 BYTE), 
	"RMVD_PLAN_DATE" TIMESTAMP (6), 
	"RSN_CHNG_CMS_CMNTS" VARCHAR2(200 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."CMS_SRC_CATG_CODE" IS 'AirCMSSourceCategoryCode';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."CMS_MIN_FREQ" IS 'AirCMSMinimumFrequency';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."CMS_START_DATE" IS 'AirCMSStartDate';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."ACTIVE_CMS_PLAN_IND" IS 'AirActiveCMSPlanIndicator';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."RMVD_PLAN_DATE" IS 'AirRemovedPlanDate';
 
   COMMENT ON COLUMN "ICA_CMPL_MON_STRGY"."RSN_CHNG_CMS_CMNTS" IS 'AirReasonChangingCMSComments';
 
   COMMENT ON TABLE "ICA_CMPL_MON_STRGY"  IS 'Schema element: AirComplianceMonitoringStrategyData';
/
--------------------------------------------------------
--  DDL for Table ICA_CNTCT
--------------------------------------------------------

  CREATE TABLE "ICA_CNTCT" 
   (	"ICA_CNTCT_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"AFFIL_TYPE_TXT" VARCHAR2(3 BYTE), 
	"FIRST_NAME" VARCHAR2(30 BYTE), 
	"MIDDLE_NAME" VARCHAR2(10 BYTE), 
	"LAST_NAME" VARCHAR2(30 BYTE), 
	"INDVL_TITLE_TXT" VARCHAR2(40 BYTE), 
	"ORG_FRML_NAME" VARCHAR2(80 BYTE), 
	"ST_CODE" CHAR(2 BYTE), 
	"RGN_CODE" CHAR(2 BYTE), 
	"ELEC_ADDR_TXT" VARCHAR2(100 BYTE), 
	"START_DATE_OF_CNTCT_ASSC" DATE, 
	"END_DATE_OF_CNTCT_ASSC" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_CNTCT"."AFFIL_TYPE_TXT" IS 'AffiliationTypeText';
 
   COMMENT ON COLUMN "ICA_CNTCT"."FIRST_NAME" IS 'FirstName';
 
   COMMENT ON COLUMN "ICA_CNTCT"."MIDDLE_NAME" IS 'MiddleName';
 
   COMMENT ON COLUMN "ICA_CNTCT"."LAST_NAME" IS 'LastName';
 
   COMMENT ON COLUMN "ICA_CNTCT"."INDVL_TITLE_TXT" IS 'IndividualTitleText';
 
   COMMENT ON COLUMN "ICA_CNTCT"."ORG_FRML_NAME" IS 'OrganizationFormalName';
 
   COMMENT ON COLUMN "ICA_CNTCT"."ST_CODE" IS 'StateCode';
 
   COMMENT ON COLUMN "ICA_CNTCT"."RGN_CODE" IS 'RegionCode';
 
   COMMENT ON COLUMN "ICA_CNTCT"."ELEC_ADDR_TXT" IS 'ElectronicAddressText';
 
   COMMENT ON COLUMN "ICA_CNTCT"."START_DATE_OF_CNTCT_ASSC" IS 'StartDateOfContactAssociation';
 
   COMMENT ON COLUMN "ICA_CNTCT"."END_DATE_OF_CNTCT_ASSC" IS 'EndDateOfContactAssociation';
 
   COMMENT ON TABLE "ICA_CNTCT"  IS 'Schema element: Contact';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_CASE_FILE
--------------------------------------------------------

  CREATE TABLE "ICA_DA_CASE_FILE" 
   (	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"CASE_FILE_IDENT" VARCHAR2(25 BYTE), 
	"CASE_FILE_NAME" VARCHAR2(100 BYTE), 
	"LEAD_AGNCY_CODE" VARCHAR2(3 BYTE), 
	"FAC_IDENT" CHAR(18 BYTE), 
	"OTHR_PROG_DESC_TXT" VARCHAR2(100 BYTE), 
	"SENS_DATA_IND" CHAR(1 BYTE), 
	"LEAD_AGNCY_CHNG_SPRSED_TXT" VARCHAR2(100 BYTE), 
	"ADVISE_METHOD_TYPE_CODE" VARCHAR2(3 BYTE), 
	"ADVISE_METHOD_DATE" DATE, 
	"CASE_FILE_USR_DEF_FLD_1" CHAR(1 BYTE), 
	"CASE_FILE_USR_DEF_FLD_2" VARCHAR2(50 BYTE), 
	"CASE_FILE_USR_DEF_FLD_3" VARCHAR2(50 BYTE), 
	"CASE_FILE_USR_DEF_FLD_4" DATE, 
	"CASE_FILE_USR_DEF_FLD_5" DATE, 
	"CASE_FILE_USR_DEF_FLD_6" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_IDENT" IS 'CaseFileIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_NAME" IS 'CaseFileName';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."LEAD_AGNCY_CODE" IS 'LeadAgencyCode';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."OTHR_PROG_DESC_TXT" IS 'OtherProgramDescriptionText';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."SENS_DATA_IND" IS 'SensitiveDataIndicator';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."LEAD_AGNCY_CHNG_SPRSED_TXT" IS 'LeadAgencyChangeSupersededText';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."ADVISE_METHOD_TYPE_CODE" IS 'AdvisementMethodTypeCode';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."ADVISE_METHOD_DATE" IS 'AdvisementMethodDate';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_USR_DEF_FLD_1" IS 'CaseFileUserDefinedField1';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_USR_DEF_FLD_2" IS 'CaseFileUserDefinedField2';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_USR_DEF_FLD_3" IS 'CaseFileUserDefinedField3';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_USR_DEF_FLD_4" IS 'CaseFileUserDefinedField4';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_USR_DEF_FLD_5" IS 'CaseFileUserDefinedField5';
 
   COMMENT ON COLUMN "ICA_DA_CASE_FILE"."CASE_FILE_USR_DEF_FLD_6" IS 'CaseFileUserDefinedField6';
 
   COMMENT ON TABLE "ICA_DA_CASE_FILE"  IS 'Schema element: AirDACaseFileData';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_CMPL_MON
--------------------------------------------------------

  CREATE TABLE "ICA_DA_CMPL_MON" 
   (	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"CMPL_MON_IDENT" VARCHAR2(25 BYTE), 
	"CMPL_MON_ACTY_TYPE_CODE" VARCHAR2(3 BYTE), 
	"CMPL_MON_DATE" TIMESTAMP (6), 
	"CMPL_MON_START_DATE" DATE, 
	"CMPL_MON_ACTY_NAME" VARCHAR2(100 BYTE), 
	"MULTIMEDIA_IND" CHAR(1 BYTE), 
	"CMPL_MON_PLANNED_START_DATE" DATE, 
	"CMPL_MON_PLANNED_END_DATE" DATE, 
	"DEFICIENCIES_OBS_IND" CHAR(1 BYTE), 
	"LEAD_AGNCY_CODE" VARCHAR2(3 BYTE), 
	"OTHR_PROG_DESC_TXT" VARCHAR2(100 BYTE), 
	"OTHR_AGNCY_INITIATIVE_TXT" VARCHAR2(200 BYTE), 
	"INSP_USR_DEF_FLD_1" CHAR(1 BYTE), 
	"INSP_USR_DEF_FLD_2" VARCHAR2(50 BYTE), 
	"INSP_USR_DEF_FLD_3" VARCHAR2(50 BYTE), 
	"INSP_USR_DEF_FLD_4" DATE, 
	"INSP_USR_DEF_FLD_5" DATE, 
	"INSP_USR_DEF_FLD_6" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_IDENT" IS 'ComplianceMonitoringIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_ACTY_TYPE_CODE" IS 'ComplianceMonitoringActivityTypeCode';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_DATE" IS 'ComplianceMonitoringDate';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_START_DATE" IS 'ComplianceMonitoringStartDate';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_ACTY_NAME" IS 'ComplianceMonitoringActivityName';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."MULTIMEDIA_IND" IS 'MultimediaIndicator';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_PLANNED_START_DATE" IS 'ComplianceMonitoringPlannedStartDate';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."CMPL_MON_PLANNED_END_DATE" IS 'ComplianceMonitoringPlannedEndDate';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."DEFICIENCIES_OBS_IND" IS 'DeficienciesObservedIndicator';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."LEAD_AGNCY_CODE" IS 'LeadAgencyCode';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."OTHR_PROG_DESC_TXT" IS 'OtherProgramDescriptionText';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."OTHR_AGNCY_INITIATIVE_TXT" IS 'OtherAgencyInitiativeText';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."INSP_USR_DEF_FLD_1" IS 'InspectionUserDefinedField1';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."INSP_USR_DEF_FLD_2" IS 'InspectionUserDefinedField2';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."INSP_USR_DEF_FLD_3" IS 'InspectionUserDefinedField3';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."INSP_USR_DEF_FLD_4" IS 'InspectionUserDefinedField4';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."INSP_USR_DEF_FLD_5" IS 'InspectionUserDefinedField5';
 
   COMMENT ON COLUMN "ICA_DA_CMPL_MON"."INSP_USR_DEF_FLD_6" IS 'InspectionUserDefinedField6';
 
   COMMENT ON TABLE "ICA_DA_CMPL_MON"  IS 'Schema element: AirDAComplianceMonitoringData';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_ENFRC_ACTN_LNK
--------------------------------------------------------

  CREATE TABLE "ICA_DA_ENFRC_ACTN_LNK" 
   (	"ICA_DA_ENFRC_ACTN_LNK_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"DA_ENFRC_ACTN_IDENT" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_LNK"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_LNK"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_LNK"."DA_ENFRC_ACTN_IDENT" IS 'AirDAEnforcementActionIdentifier';
 
   COMMENT ON TABLE "ICA_DA_ENFRC_ACTN_LNK"  IS 'Schema element: AirDAEnforcementActionLinkageData';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_ENFRC_ACTN_MILSTN
--------------------------------------------------------

  CREATE TABLE "ICA_DA_ENFRC_ACTN_MILSTN" 
   (	"ICA_DA_ENFRC_ACTN_MILSTN_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"DA_ENFRC_ACTN_IDENT" VARCHAR2(25 BYTE), 
	"MILSTN_TYPE_CODE" VARCHAR2(5 BYTE), 
	"MILSTN_PLANNED_DATE" DATE, 
	"MILSTN_ACTUAL_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_MILSTN"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_MILSTN"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_MILSTN"."DA_ENFRC_ACTN_IDENT" IS 'AirDAEnforcementActionIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_MILSTN"."MILSTN_TYPE_CODE" IS 'MilestoneTypeCode';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_MILSTN"."MILSTN_PLANNED_DATE" IS 'MilestonePlannedDate';
 
   COMMENT ON COLUMN "ICA_DA_ENFRC_ACTN_MILSTN"."MILSTN_ACTUAL_DATE" IS 'MilestoneActualDate';
 
   COMMENT ON TABLE "ICA_DA_ENFRC_ACTN_MILSTN"  IS 'Schema element: AirDAEnforcementActionMilestoneData';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_FINAL_ORDER
--------------------------------------------------------

  CREATE TABLE "ICA_DA_FINAL_ORDER" 
   (	"ICA_DA_FINAL_ORDER_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"FINAL_ORDER_IDENT" NUMBER(10,0), 
	"FINAL_ORDER_TYPE_CODE" VARCHAR2(3 BYTE), 
	"FINAL_ORDER_ISSUED_ENTERD_DATE" DATE, 
	"RSLVD_DATE" DATE, 
	"CASH_CIVIL_PNLTY_REQD_AMT" NUMBER(17,2), 
	"OTHR_CMNTS" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_FINAL_ORDER"."FINAL_ORDER_IDENT" IS 'FinalOrderIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_FINAL_ORDER"."FINAL_ORDER_TYPE_CODE" IS 'FinalOrderTypeCode';
 
   COMMENT ON COLUMN "ICA_DA_FINAL_ORDER"."FINAL_ORDER_ISSUED_ENTERD_DATE" IS 'FinalOrderIssuedEnteredDate';
 
   COMMENT ON COLUMN "ICA_DA_FINAL_ORDER"."RSLVD_DATE" IS 'AirResolvedDate';
 
   COMMENT ON COLUMN "ICA_DA_FINAL_ORDER"."CASH_CIVIL_PNLTY_REQD_AMT" IS 'CashCivilPenaltyRequiredAmount';
 
   COMMENT ON COLUMN "ICA_DA_FINAL_ORDER"."OTHR_CMNTS" IS 'OtherComments';
 
   COMMENT ON TABLE "ICA_DA_FINAL_ORDER"  IS 'Schema element: AirDAFinalOrder';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_FRML_ENFRC_ACTN
--------------------------------------------------------

  CREATE TABLE "ICA_DA_FRML_ENFRC_ACTN" 
   (	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"DA_ENFRC_ACTN_IDENT" VARCHAR2(25 BYTE), 
	"ENFRC_ACTN_NAME" VARCHAR2(100 BYTE), 
	"FORUM" VARCHAR2(3 BYTE), 
	"RESL_TYPE_CODE" VARCHAR2(3 BYTE), 
	"DA_COMB_SPRSED_EAID" VARCHAR2(25 BYTE), 
	"RSN_DEL_REC" VARCHAR2(500 BYTE), 
	"FRML_EA_USR_DEF_FLD_1" CHAR(1 BYTE), 
	"FRML_EA_USR_DEF_FLD_2" VARCHAR2(50 BYTE), 
	"FRML_EA_USR_DEF_FLD_3" VARCHAR2(50 BYTE), 
	"FRML_EA_USR_DEF_FLD_4" DATE, 
	"FRML_EA_USR_DEF_FLD_5" DATE, 
	"FRML_EA_USR_DEF_FLD_6" VARCHAR2(4000 BYTE), 
	"LEAD_AGNCY_CODE" VARCHAR2(3 BYTE), 
	"ENFRC_AGNCY_NAME" VARCHAR2(100 BYTE), 
	"OTHR_AGNCY_INITIATIVE_TXT" VARCHAR2(200 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."DA_ENFRC_ACTN_IDENT" IS 'AirDAEnforcementActionIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."ENFRC_ACTN_NAME" IS 'EnforcementActionName';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FORUM" IS 'Forum';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."RESL_TYPE_CODE" IS 'ResolutionTypeCode';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."DA_COMB_SPRSED_EAID" IS 'AirDACombinedSupersededEAID';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."RSN_DEL_REC" IS 'ReasonDeletingRecord';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FRML_EA_USR_DEF_FLD_1" IS 'FormalEAUserDefinedField1';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FRML_EA_USR_DEF_FLD_2" IS 'FormalEAUserDefinedField2';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FRML_EA_USR_DEF_FLD_3" IS 'FormalEAUserDefinedField3';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FRML_EA_USR_DEF_FLD_4" IS 'FormalEAUserDefinedField4';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FRML_EA_USR_DEF_FLD_5" IS 'FormalEAUserDefinedField5';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."FRML_EA_USR_DEF_FLD_6" IS 'FormalEAUserDefinedField6';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."LEAD_AGNCY_CODE" IS 'LeadAgencyCode';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."ENFRC_AGNCY_NAME" IS 'EnforcementAgencyName';
 
   COMMENT ON COLUMN "ICA_DA_FRML_ENFRC_ACTN"."OTHR_AGNCY_INITIATIVE_TXT" IS 'OtherAgencyInitiativeText';
 
   COMMENT ON TABLE "ICA_DA_FRML_ENFRC_ACTN"  IS 'Schema element: AirDAFormalEnforcementActionData';
/
--------------------------------------------------------
--  DDL for Table ICA_DA_INFRML_ENFRC_ACTN
--------------------------------------------------------

  CREATE TABLE "ICA_DA_INFRML_ENFRC_ACTN" 
   (	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"DA_ENFRC_ACTN_IDENT" VARCHAR2(25 BYTE), 
	"ENFRC_ACTN_TYPE_CODE" VARCHAR2(7 BYTE), 
	"ENFRC_ACTN_NAME" VARCHAR2(100 BYTE), 
	"ACHIEVED_DATE" DATE, 
	"FILE_NUM" VARCHAR2(50 BYTE), 
	"RSN_DEL_REC" VARCHAR2(500 BYTE), 
	"INFRML_EA_USR_DEF_FLD_1" CHAR(1 BYTE), 
	"INFRML_EA_USR_DEF_FLD_2" VARCHAR2(50 BYTE), 
	"INFRML_EA_USR_DEF_FLD_3" VARCHAR2(50 BYTE), 
	"INFRML_EA_USR_DEF_FLD_4" DATE, 
	"INFRML_EA_USR_DEF_FLD_5" DATE, 
	"INFRML_EA_USR_DEF_FLD_6" VARCHAR2(4000 BYTE), 
	"LEAD_AGNCY_CODE" VARCHAR2(3 BYTE), 
	"ENFRC_AGNCY_NAME" VARCHAR2(100 BYTE), 
	"OTHR_AGNCY_INITIATIVE_TXT" VARCHAR2(200 BYTE), 
	"ST_SECTS_VIOL_TXT" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."DA_ENFRC_ACTN_IDENT" IS 'AirDAEnforcementActionIdentifier';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."ENFRC_ACTN_TYPE_CODE" IS 'EnforcementActionTypeCode';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."ENFRC_ACTN_NAME" IS 'EnforcementActionName';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."ACHIEVED_DATE" IS 'AchievedDate';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."FILE_NUM" IS 'FileNumber';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."RSN_DEL_REC" IS 'ReasonDeletingRecord';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."INFRML_EA_USR_DEF_FLD_1" IS 'InformalEAUserDefinedField1';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."INFRML_EA_USR_DEF_FLD_2" IS 'InformalEAUserDefinedField2';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."INFRML_EA_USR_DEF_FLD_3" IS 'InformalEAUserDefinedField3';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."INFRML_EA_USR_DEF_FLD_4" IS 'InformalEAUserDefinedField4';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."INFRML_EA_USR_DEF_FLD_5" IS 'InformalEAUserDefinedField5';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."INFRML_EA_USR_DEF_FLD_6" IS 'InformalEAUserDefinedField6';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."LEAD_AGNCY_CODE" IS 'LeadAgencyCode';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."ENFRC_AGNCY_NAME" IS 'EnforcementAgencyName';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."OTHR_AGNCY_INITIATIVE_TXT" IS 'OtherAgencyInitiativeText';
 
   COMMENT ON COLUMN "ICA_DA_INFRML_ENFRC_ACTN"."ST_SECTS_VIOL_TXT" IS 'StateSectionsViolatedText';
 
   COMMENT ON TABLE "ICA_DA_INFRML_ENFRC_ACTN"  IS 'Schema element: AirDAInformalEnforcementActionData';
/
--------------------------------------------------------
--  DDL for Table ICA_ENFRC_ACTN_CMNT_TXT
--------------------------------------------------------

  CREATE TABLE "ICA_ENFRC_ACTN_CMNT_TXT" 
   (	"ICA_ENFRC_ACTN_CMNT_TXT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ENFRC_ACTN_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_ENFRC_ACTN_CMNT_TXT"."ENFRC_ACTN_CMNT_TXT" IS 'EnforcementActionCommentText';
 
   COMMENT ON TABLE "ICA_ENFRC_ACTN_CMNT_TXT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_ENFRC_ACTN_GOV_CNTCT
--------------------------------------------------------

  CREATE TABLE "ICA_ENFRC_ACTN_GOV_CNTCT" 
   (	"ICA_ENFRC_ACTN_GOV_CNTCT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"AFFIL_TYPE_TXT" VARCHAR2(3 BYTE), 
	"ELEC_ADDR_TXT" VARCHAR2(100 BYTE), 
	"START_DATE_OF_CNTCT_ASSC" DATE, 
	"END_DATE_OF_CNTCT_ASSC" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_ENFRC_ACTN_GOV_CNTCT"."AFFIL_TYPE_TXT" IS 'AffiliationTypeText';
 
   COMMENT ON COLUMN "ICA_ENFRC_ACTN_GOV_CNTCT"."ELEC_ADDR_TXT" IS 'ElectronicAddressText';
 
   COMMENT ON COLUMN "ICA_ENFRC_ACTN_GOV_CNTCT"."START_DATE_OF_CNTCT_ASSC" IS 'StartDateOfContactAssociation';
 
   COMMENT ON COLUMN "ICA_ENFRC_ACTN_GOV_CNTCT"."END_DATE_OF_CNTCT_ASSC" IS 'EndDateOfContactAssociation';
 
   COMMENT ON TABLE "ICA_ENFRC_ACTN_GOV_CNTCT"  IS 'Schema element: EnforcementActionGovernmentContact';
/
--------------------------------------------------------
--  DDL for Table ICA_ENFRC_ACTN_TYPE
--------------------------------------------------------

  CREATE TABLE "ICA_ENFRC_ACTN_TYPE" 
   (	"ICA_ENFRC_ACTN_TYPE_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ENFRC_ACTN_TYPE_CODE" VARCHAR2(7 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_ENFRC_ACTN_TYPE"."ENFRC_ACTN_TYPE_CODE" IS 'EnforcementActionTypeCode';
 
   COMMENT ON TABLE "ICA_ENFRC_ACTN_TYPE"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_ENFRC_AGNCY_TYPE
--------------------------------------------------------

  CREATE TABLE "ICA_ENFRC_AGNCY_TYPE" 
   (	"ICA_ENFRC_AGNCY_TYPE_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ENFRC_AGNCY_TYPE_CODE" VARCHAR2(3 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_ENFRC_AGNCY_TYPE"."ENFRC_AGNCY_TYPE_CODE" IS 'EnforcementAgencyTypeCode';
 
   COMMENT ON TABLE "ICA_ENFRC_AGNCY_TYPE"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_FAC
--------------------------------------------------------

  CREATE TABLE "ICA_FAC" 
   (	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"FAC_IDENT" CHAR(18 BYTE), 
	"FAC_SITE_NAME" VARCHAR2(80 BYTE), 
	"LOC_ADDR_TXT" VARCHAR2(50 BYTE), 
	"SUPPL_LOC_TXT" VARCHAR2(50 BYTE), 
	"LOC_ADDR_CITY_CODE" VARCHAR2(12 BYTE), 
	"LOC_ST_CODE" CHAR(2 BYTE), 
	"LOC_ZIP_CODE" VARCHAR2(14 BYTE), 
	"LCON_CODE" VARCHAR2(3 BYTE), 
	"TRIBAL_LAND_CODE" VARCHAR2(4 BYTE), 
	"FAC_DESC" VARCHAR2(250 BYTE), 
	"FAC_TYPE_OF_OWNER_CODE" VARCHAR2(3 BYTE), 
	"REG_NUM" VARCHAR2(15 BYTE), 
	"SMALL_BUSNSS_IND" CHAR(1 BYTE), 
	"FEDERALLY_REP_IND" CHAR(1 BYTE), 
	"SRC_UNIFM_RSRC_LOCATOR_URL" VARCHAR2(100 BYTE), 
	"ENVR_JUSTICE_CODE" VARCHAR2(3 BYTE), 
	"FAC_CONGR_DISTRICT_NUM" NUMBER(10,0), 
	"FAC_USR_DEF_FLD_1" VARCHAR2(30 BYTE), 
	"FAC_USR_DEF_FLD_2" VARCHAR2(30 BYTE), 
	"FAC_USR_DEF_FLD_3" VARCHAR2(30 BYTE), 
	"FAC_USR_DEF_FLD_4" VARCHAR2(30 BYTE), 
	"FAC_USR_DEF_FLD_5" VARCHAR2(30 BYTE), 
	"FAC_CMNTS" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_FAC"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_FAC"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_SITE_NAME" IS 'FacilitySiteName';
 
   COMMENT ON COLUMN "ICA_FAC"."LOC_ADDR_TXT" IS 'LocationAddressText';
 
   COMMENT ON COLUMN "ICA_FAC"."SUPPL_LOC_TXT" IS 'SupplementalLocationText';
 
   COMMENT ON COLUMN "ICA_FAC"."LOC_ADDR_CITY_CODE" IS 'LocationAddressCityCode';
 
   COMMENT ON COLUMN "ICA_FAC"."LOC_ST_CODE" IS 'LocationStateCode';
 
   COMMENT ON COLUMN "ICA_FAC"."LOC_ZIP_CODE" IS 'LocationZipCode';
 
   COMMENT ON COLUMN "ICA_FAC"."LCON_CODE" IS 'LCONCode';
 
   COMMENT ON COLUMN "ICA_FAC"."TRIBAL_LAND_CODE" IS 'TribalLandCode';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_DESC" IS 'FacilityDescription';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_TYPE_OF_OWNER_CODE" IS 'FacilityTypeOfOwnershipCode';
 
   COMMENT ON COLUMN "ICA_FAC"."REG_NUM" IS 'RegistrationNumber';
 
   COMMENT ON COLUMN "ICA_FAC"."SMALL_BUSNSS_IND" IS 'SmallBusinessIndicator';
 
   COMMENT ON COLUMN "ICA_FAC"."FEDERALLY_REP_IND" IS 'FederallyReportableIndicator';
 
   COMMENT ON COLUMN "ICA_FAC"."SRC_UNIFM_RSRC_LOCATOR_URL" IS 'SourceUniformResourceLocatorURL';
 
   COMMENT ON COLUMN "ICA_FAC"."ENVR_JUSTICE_CODE" IS 'EnvironmentalJusticeCode';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_CONGR_DISTRICT_NUM" IS 'FacilityCongressionalDistrictNumber';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_USR_DEF_FLD_1" IS 'FacilityUserDefinedField1';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_USR_DEF_FLD_2" IS 'FacilityUserDefinedField2';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_USR_DEF_FLD_3" IS 'FacilityUserDefinedField3';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_USR_DEF_FLD_4" IS 'FacilityUserDefinedField4';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_USR_DEF_FLD_5" IS 'FacilityUserDefinedField5';
 
   COMMENT ON COLUMN "ICA_FAC"."FAC_CMNTS" IS 'FacilityComments';
 
   COMMENT ON TABLE "ICA_FAC"  IS 'Schema element: AirFacilityData';
/
--------------------------------------------------------
--  DDL for Table ICA_FAC_ADDR
--------------------------------------------------------

  CREATE TABLE "ICA_FAC_ADDR" 
   (	"ICA_FAC_ADDR_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"AFFIL_TYPE_TXT" VARCHAR2(3 BYTE), 
	"ORG_FRML_NAME" VARCHAR2(80 BYTE), 
	"ORG_DUNS_NUM" CHAR(9 BYTE), 
	"MAILING_ADDR_TXT" VARCHAR2(50 BYTE), 
	"SUPPL_ADDR_TXT" VARCHAR2(50 BYTE), 
	"MAILING_ADDR_CITY_NAME" VARCHAR2(30 BYTE), 
	"MAILING_ADDR_ST_CODE" CHAR(2 BYTE), 
	"MAILING_ADDR_ZIP_CODE" VARCHAR2(14 BYTE), 
	"COUNTY_NAME" VARCHAR2(35 BYTE), 
	"MAILING_ADDR_COUNTRY_CODE" VARCHAR2(3 BYTE), 
	"DIVISION_NAME" VARCHAR2(50 BYTE), 
	"LOC_PROVINCE" VARCHAR2(35 BYTE), 
	"ELEC_ADDR_TXT" VARCHAR2(100 BYTE), 
	"START_DATE_OF_ADDR_ASSC" DATE, 
	"END_DATE_OF_ADDR_ASSC" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_FAC_ADDR"."AFFIL_TYPE_TXT" IS 'AffiliationTypeText';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."ORG_FRML_NAME" IS 'OrganizationFormalName';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."ORG_DUNS_NUM" IS 'OrganizationDUNSNumber';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."MAILING_ADDR_TXT" IS 'MailingAddressText';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."SUPPL_ADDR_TXT" IS 'SupplementalAddressText';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."MAILING_ADDR_CITY_NAME" IS 'MailingAddressCityName';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."MAILING_ADDR_ST_CODE" IS 'MailingAddressStateCode';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."MAILING_ADDR_ZIP_CODE" IS 'MailingAddressZipCode';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."COUNTY_NAME" IS 'CountyName';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."MAILING_ADDR_COUNTRY_CODE" IS 'MailingAddressCountryCode';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."DIVISION_NAME" IS 'DivisionName';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."LOC_PROVINCE" IS 'LocationProvince';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."ELEC_ADDR_TXT" IS 'ElectronicAddressText';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."START_DATE_OF_ADDR_ASSC" IS 'StartDateOfAddressAssociation';
 
   COMMENT ON COLUMN "ICA_FAC_ADDR"."END_DATE_OF_ADDR_ASSC" IS 'EndDateOfAddressAssociation';
 
   COMMENT ON TABLE "ICA_FAC_ADDR"  IS 'Schema element: FacilityAddress';
/
--------------------------------------------------------
--  DDL for Table ICA_FAC_IDENT
--------------------------------------------------------

  CREATE TABLE "ICA_FAC_IDENT" 
   (	"ICA_FAC_IDENT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"FAC_IDENT" CHAR(18 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_FAC_IDENT"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON TABLE "ICA_FAC_IDENT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_FINAL_ORDER_FAC_IDENT
--------------------------------------------------------

  CREATE TABLE "ICA_FINAL_ORDER_FAC_IDENT" 
   (	"ICA_FINAL_ORDER_FAC_IDENT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FINAL_ORDER_ID" VARCHAR2(36 BYTE), 
	"FINAL_ORDER_FAC_IDENT" CHAR(18 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_FINAL_ORDER_FAC_IDENT"."FINAL_ORDER_FAC_IDENT" IS 'FinalOrderAirFacilityIdentifier';
 
   COMMENT ON TABLE "ICA_FINAL_ORDER_FAC_IDENT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_GEO_COORD
--------------------------------------------------------

  CREATE TABLE "ICA_GEO_COORD" 
   (	"ICA_GEO_COORD_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"LAT_MEAS" VARCHAR2(10 BYTE), 
	"LONG_MEAS" VARCHAR2(11 BYTE), 
	"HORZ_ACCURACY_MEAS" NUMBER(10,0), 
	"GEOM_TYPE_CODE" VARCHAR2(3 BYTE), 
	"HORZ_COLL_METHOD_CODE" VARCHAR2(3 BYTE), 
	"HORZ_REF_DATUM_CODE" VARCHAR2(3 BYTE), 
	"REF_POINT_CODE" VARCHAR2(3 BYTE), 
	"SRC_MAP_SCALE_NUM" NUMBER(10,0), 
	"UTM_COORD_1" VARCHAR2(20 BYTE), 
	"UTM_COORD_2" VARCHAR2(20 BYTE), 
	"UTM_COORD_3" VARCHAR2(20 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_GEO_COORD"."LAT_MEAS" IS 'LatitudeMeasure';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."LONG_MEAS" IS 'LongitudeMeasure';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."HORZ_ACCURACY_MEAS" IS 'HorizontalAccuracyMeasure';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."GEOM_TYPE_CODE" IS 'GeometricTypeCode';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."HORZ_COLL_METHOD_CODE" IS 'HorizontalCollectionMethodCode';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."HORZ_REF_DATUM_CODE" IS 'HorizontalReferenceDatumCode';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."REF_POINT_CODE" IS 'ReferencePointCode';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."SRC_MAP_SCALE_NUM" IS 'SourceMapScaleNumber';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."UTM_COORD_1" IS 'UTMCoordinate1';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."UTM_COORD_2" IS 'UTMCoordinate2';
 
   COMMENT ON COLUMN "ICA_GEO_COORD"."UTM_COORD_3" IS 'UTMCoordinate3';
 
   COMMENT ON TABLE "ICA_GEO_COORD"  IS 'Schema element: AirGeographicCoordinateData';
/
--------------------------------------------------------
--  DDL for Table ICA_INFRML_EA_CMNT_TXT
--------------------------------------------------------

  CREATE TABLE "ICA_INFRML_EA_CMNT_TXT" 
   (	"ICA_INFRML_EA_CMNT_TXT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"INFRML_EA_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_INFRML_EA_CMNT_TXT"."INFRML_EA_CMNT_TXT" IS 'InformalEACommentText';
 
   COMMENT ON TABLE "ICA_INFRML_EA_CMNT_TXT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_INSP_CMNT_TXT
--------------------------------------------------------

  CREATE TABLE "ICA_INSP_CMNT_TXT" 
   (	"ICA_INSP_CMNT_TXT_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"INSP_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_INSP_CMNT_TXT"."INSP_CMNT_TXT" IS 'InspectionCommentText';
 
   COMMENT ON TABLE "ICA_INSP_CMNT_TXT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_INSP_GOV_CNTCT
--------------------------------------------------------

  CREATE TABLE "ICA_INSP_GOV_CNTCT" 
   (	"ICA_INSP_GOV_CNTCT_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"AFFIL_TYPE_TXT" VARCHAR2(3 BYTE), 
	"ELEC_ADDR_TXT" VARCHAR2(100 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_INSP_GOV_CNTCT"."AFFIL_TYPE_TXT" IS 'AffiliationTypeText';
 
   COMMENT ON COLUMN "ICA_INSP_GOV_CNTCT"."ELEC_ADDR_TXT" IS 'ElectronicAddressText';
 
   COMMENT ON TABLE "ICA_INSP_GOV_CNTCT"  IS 'Schema element: InspectionGovernmentContact';
/
--------------------------------------------------------
--  DDL for Table ICA_LNK_CASE_FILE
--------------------------------------------------------

  CREATE TABLE "ICA_LNK_CASE_FILE" 
   (	"ICA_LNK_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"ICA_CASE_FILE_LNK_ID" VARCHAR2(36 BYTE), 
	"CASE_FILE_IDENT" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_LNK_CASE_FILE"."CASE_FILE_IDENT" IS 'CaseFileIdentifier';
 
   COMMENT ON TABLE "ICA_LNK_CASE_FILE"  IS 'Schema element: LinkageCaseFile';
/
--------------------------------------------------------
--  DDL for Table ICA_LNK_CMPL_MON
--------------------------------------------------------

  CREATE TABLE "ICA_LNK_CMPL_MON" 
   (	"ICA_LNK_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_CMPL_MON_LNK_ID" VARCHAR2(36 BYTE), 
	"ICA_CASE_FILE_LNK_ID" VARCHAR2(36 BYTE), 
	"CMPL_MON_IDENT" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_LNK_CMPL_MON"."CMPL_MON_IDENT" IS 'ComplianceMonitoringIdentifier';
 
   COMMENT ON TABLE "ICA_LNK_CMPL_MON"  IS 'Schema element: LinkageComplianceMonitoring';
/
--------------------------------------------------------
--  DDL for Table ICA_LNK_DA_ENFRC_ACTN
--------------------------------------------------------

  CREATE TABLE "ICA_LNK_DA_ENFRC_ACTN" 
   (	"ICA_LNK_DA_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_CMPL_MON_LNK_ID" VARCHAR2(36 BYTE), 
	"ICA_CASE_FILE_LNK_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_ENFRC_ACTN_LNK_ID" VARCHAR2(36 BYTE), 
	"DA_ENFRC_ACTN_IDENT" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_LNK_DA_ENFRC_ACTN"."DA_ENFRC_ACTN_IDENT" IS 'AirDAEnforcementActionIdentifier';
 
   COMMENT ON TABLE "ICA_LNK_DA_ENFRC_ACTN"  IS 'Schema element: LinkageAirDAEnforcementAction';
/
--------------------------------------------------------
--  DDL for Table ICA_METHOD
--------------------------------------------------------

  CREATE TABLE "ICA_METHOD" 
   (	"ICA_METHOD_ID" VARCHAR2(36 BYTE), 
	"ICA_TST_RSLTS_ID" VARCHAR2(36 BYTE), 
	"METHOD_CODE" VARCHAR2(3 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_METHOD"."METHOD_CODE" IS 'MethodCode';
 
   COMMENT ON TABLE "ICA_METHOD"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_NAICS_CODE
--------------------------------------------------------

  CREATE TABLE "ICA_NAICS_CODE" 
   (	"ICA_NAICS_CODE_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"NAICS_CODE" CHAR(6 BYTE), 
	"NAICS_PRI_IND_CODE" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_NAICS_CODE"."NAICS_CODE" IS 'NAICSCode';
 
   COMMENT ON COLUMN "ICA_NAICS_CODE"."NAICS_PRI_IND_CODE" IS 'NAICSPrimaryIndicatorCode';
 
   COMMENT ON TABLE "ICA_NAICS_CODE"  IS 'Schema element: NAICSCodeDetails';
/
--------------------------------------------------------
--  DDL for Table ICA_NAT_PRIO
--------------------------------------------------------

  CREATE TABLE "ICA_NAT_PRIO" 
   (	"ICA_NAT_PRIO_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"NAT_PRIO_CODE" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "ICA_NAT_PRIO"."NAT_PRIO_CODE" IS 'NationalPrioritiesCode';
 
   COMMENT ON TABLE "ICA_NAT_PRIO"  IS 'Schema element: CustomXmlStringFormatInt32';
/
--------------------------------------------------------
--  DDL for Table ICA_OTHR_PATHWAY_ACTY
--------------------------------------------------------

  CREATE TABLE "ICA_OTHR_PATHWAY_ACTY" 
   (	"ICA_OTHR_PATHWAY_ACTY_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"OTHR_PATHWAY_CATG_CODE" VARCHAR2(6 BYTE), 
	"OTHR_PATHWAY_TYPE_CODE" VARCHAR2(3 BYTE), 
	"OTHR_PATHWAY_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_OTHR_PATHWAY_ACTY"."OTHR_PATHWAY_CATG_CODE" IS 'OtherPathwayCategoryCode';
 
   COMMENT ON COLUMN "ICA_OTHR_PATHWAY_ACTY"."OTHR_PATHWAY_TYPE_CODE" IS 'OtherPathwayTypeCode';
 
   COMMENT ON COLUMN "ICA_OTHR_PATHWAY_ACTY"."OTHR_PATHWAY_DATE" IS 'OtherPathwayDate';
 
   COMMENT ON TABLE "ICA_OTHR_PATHWAY_ACTY"  IS 'Schema element: OtherPathwayActivityData';
/
--------------------------------------------------------
--  DDL for Table ICA_PAYLOAD
--------------------------------------------------------

  CREATE TABLE "ICA_PAYLOAD" 
   (	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"OPERATION" VARCHAR2(43 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_PAYLOAD"."OPERATION" IS 'Operation';
 
   COMMENT ON TABLE "ICA_PAYLOAD"  IS 'Schema element: Payload';
/
--------------------------------------------------------
--  DDL for Table ICA_POLUT
--------------------------------------------------------

  CREATE TABLE "ICA_POLUT" 
   (	"ICA_POLUT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"POLUT_CODE" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "ICA_POLUT"."POLUT_CODE" IS 'AirPollutantCode';
 
   COMMENT ON TABLE "ICA_POLUT"  IS 'Schema element: CustomXmlStringFormatInt32';
/
--------------------------------------------------------
--  DDL for Table ICA_POLUTS
--------------------------------------------------------

  CREATE TABLE "ICA_POLUTS" 
   (	"ICA_POLUTS_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"FAC_IDENT" CHAR(18 BYTE), 
	"POLUTS_CODE" NUMBER(10,0), 
	"POLUT_STAT_IND" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_POLUTS"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_POLUTS"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_POLUTS"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON COLUMN "ICA_POLUTS"."POLUTS_CODE" IS 'AirPollutantsCode';
 
   COMMENT ON COLUMN "ICA_POLUTS"."POLUT_STAT_IND" IS 'AirPollutantStatusIndicator';
 
   COMMENT ON TABLE "ICA_POLUTS"  IS 'Schema element: AirPollutantsData';
/
--------------------------------------------------------
--  DDL for Table ICA_POLUT_DA_CLASS
--------------------------------------------------------

  CREATE TABLE "ICA_POLUT_DA_CLASS" 
   (	"ICA_POLUT_DA_CLASS_ID" VARCHAR2(36 BYTE), 
	"ICA_POLUTS_ID" VARCHAR2(36 BYTE), 
	"POLUT_DA_CLASS_CODE" VARCHAR2(3 BYTE), 
	"POLUT_DA_CLASS_START_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "ICA_POLUT_DA_CLASS"."POLUT_DA_CLASS_CODE" IS 'AirPollutantDAClassificationCode';
 
   COMMENT ON COLUMN "ICA_POLUT_DA_CLASS"."POLUT_DA_CLASS_START_DATE" IS 'AirPollutantDAClassificationStartDate';
 
   COMMENT ON TABLE "ICA_POLUT_DA_CLASS"  IS 'Schema element: AirPollutantDAClassificationData';
/
--------------------------------------------------------
--  DDL for Table ICA_POLUT_EPA_CLASS
--------------------------------------------------------

  CREATE TABLE "ICA_POLUT_EPA_CLASS" 
   (	"ICA_POLUT_EPA_CLASS_ID" VARCHAR2(36 BYTE), 
	"ICA_POLUTS_ID" VARCHAR2(36 BYTE), 
	"POLUT_EPA_CLASS_CODE" VARCHAR2(3 BYTE), 
	"POLUT_EPA_CLASS_START_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "ICA_POLUT_EPA_CLASS"."POLUT_EPA_CLASS_CODE" IS 'AirPollutantEPAClassificationCode';
 
   COMMENT ON COLUMN "ICA_POLUT_EPA_CLASS"."POLUT_EPA_CLASS_START_DATE" IS 'AirPollutantEPAClassificationStartDate';
 
   COMMENT ON TABLE "ICA_POLUT_EPA_CLASS"  IS 'Schema element: AirPollutantEPAClassificationData';
/
--------------------------------------------------------
--  DDL for Table ICA_PORT_SRC
--------------------------------------------------------

  CREATE TABLE "ICA_PORT_SRC" 
   (	"ICA_PORT_SRC_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"PORT_SRC_IND" CHAR(1 BYTE), 
	"PORT_SRC_SITE_NAME" VARCHAR2(80 BYTE), 
	"PORT_SRC_START_DATE" DATE, 
	"PORT_SRC_END_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_PORT_SRC"."PORT_SRC_IND" IS 'PortableSourceIndicator';
 
   COMMENT ON COLUMN "ICA_PORT_SRC"."PORT_SRC_SITE_NAME" IS 'PortableSourceSiteName';
 
   COMMENT ON COLUMN "ICA_PORT_SRC"."PORT_SRC_START_DATE" IS 'PortableSourceStartDate';
 
   COMMENT ON COLUMN "ICA_PORT_SRC"."PORT_SRC_END_DATE" IS 'PortableSourceEndDate';
 
   COMMENT ON TABLE "ICA_PORT_SRC"  IS 'Schema element: PortableSourceData';
/
--------------------------------------------------------
--  DDL for Table ICA_PROG
--------------------------------------------------------

  CREATE TABLE "ICA_PROG" 
   (	"ICA_PROG_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"PROG_CODE" VARCHAR2(9 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_PROG"."PROG_CODE" IS 'ProgramCode';
 
   COMMENT ON TABLE "ICA_PROG"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_PROGS
--------------------------------------------------------

  CREATE TABLE "ICA_PROGS" 
   (	"ICA_PROGS_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"FAC_IDENT" CHAR(18 BYTE), 
	"PROG_CODE" VARCHAR2(9 BYTE), 
	"OTHR_PROG_DESC_TXT" VARCHAR2(100 BYTE), 
	"PROG_OPER_STAT_CODE" VARCHAR2(5 BYTE), 
	"PROG_OPER_STAT_START_DATE" TIMESTAMP (6)
   ) ;
 

   COMMENT ON COLUMN "ICA_PROGS"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_PROGS"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_PROGS"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON COLUMN "ICA_PROGS"."PROG_CODE" IS 'AirProgramCode';
 
   COMMENT ON COLUMN "ICA_PROGS"."OTHR_PROG_DESC_TXT" IS 'OtherProgramDescriptionText';
 
   COMMENT ON COLUMN "ICA_PROGS"."PROG_OPER_STAT_CODE" IS 'AirProgramOperatingStatusCode';
 
   COMMENT ON COLUMN "ICA_PROGS"."PROG_OPER_STAT_START_DATE" IS 'AirProgramOperatingStatusStartDate';
 
   COMMENT ON TABLE "ICA_PROGS"  IS 'Schema element: AirProgramsData';
/
--------------------------------------------------------
--  DDL for Table ICA_PROGS_VIOL
--------------------------------------------------------

  CREATE TABLE "ICA_PROGS_VIOL" 
   (	"ICA_PROGS_VIOL_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"PROGS_VIOL_CODE" VARCHAR2(9 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_PROGS_VIOL"."PROGS_VIOL_CODE" IS 'ProgramsViolatedCode';
 
   COMMENT ON TABLE "ICA_PROGS_VIOL"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_PROG_SUBPART
--------------------------------------------------------

  CREATE TABLE "ICA_PROG_SUBPART" 
   (	"ICA_PROG_SUBPART_ID" VARCHAR2(36 BYTE), 
	"ICA_PROGS_ID" VARCHAR2(36 BYTE), 
	"PROG_SUBPART_CODE" VARCHAR2(20 BYTE), 
	"PROG_SUBPART_STAT_IND" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_PROG_SUBPART"."PROG_SUBPART_CODE" IS 'AirProgramSubpartCode';
 
   COMMENT ON COLUMN "ICA_PROG_SUBPART"."PROG_SUBPART_STAT_IND" IS 'AirProgramSubpartStatusIndicator';
 
   COMMENT ON TABLE "ICA_PROG_SUBPART"  IS 'Schema element: AirProgramSubpartData';
/
--------------------------------------------------------
--  DDL for Table ICA_RGNL_PRIO
--------------------------------------------------------

  CREATE TABLE "ICA_RGNL_PRIO" 
   (	"ICA_RGNL_PRIO_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"RGNL_PRIO_CODE" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "ICA_RGNL_PRIO"."RGNL_PRIO_CODE" IS 'RegionalPriorityCode';
 
   COMMENT ON TABLE "ICA_RGNL_PRIO"  IS 'Schema element: CustomXmlStringFormatInt32';
/
--------------------------------------------------------
--  DDL for Table ICA_SENS_CMNT_TXT
--------------------------------------------------------

  CREATE TABLE "ICA_SENS_CMNT_TXT" 
   (	"ICA_SENS_CMNT_TXT_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_FRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_INFRML_ENFRC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"SENS_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_SENS_CMNT_TXT"."SENS_CMNT_TXT" IS 'SensitiveCommentText';
 
   COMMENT ON TABLE "ICA_SENS_CMNT_TXT"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_SIC_CODE
--------------------------------------------------------

  CREATE TABLE "ICA_SIC_CODE" 
   (	"ICA_SIC_CODE_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"SIC_CODE" CHAR(4 BYTE), 
	"SIC_PRI_IND_CODE" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_SIC_CODE"."SIC_CODE" IS 'SICCode';
 
   COMMENT ON COLUMN "ICA_SIC_CODE"."SIC_PRI_IND_CODE" IS 'SICPrimaryIndicatorCode';
 
   COMMENT ON TABLE "ICA_SIC_CODE"  IS 'Schema element: SICCodeDetails';
/
--------------------------------------------------------
--  DDL for Table ICA_STCK_TST
--------------------------------------------------------

  CREATE TABLE "ICA_STCK_TST" 
   (	"ICA_STCK_TST_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CMPL_MON_ID" VARCHAR2(36 BYTE), 
	"STCK_TST_STAT_CODE" VARCHAR2(3 BYTE), 
	"STCK_TST_CNDCTR_TYPE_CODE" VARCHAR2(3 BYTE), 
	"STCK_IDENT" VARCHAR2(100 BYTE), 
	"OTHR_STCK_TST_PURPOSE_NAME" VARCHAR2(100 BYTE), 
	"STCK_TST_REP_RCVD_DATE" DATE, 
	"TST_RSLTS_REVIEWED_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "ICA_STCK_TST"."STCK_TST_STAT_CODE" IS 'StackTestStatusCode';
 
   COMMENT ON COLUMN "ICA_STCK_TST"."STCK_TST_CNDCTR_TYPE_CODE" IS 'StackTestConductorTypeCode';
 
   COMMENT ON COLUMN "ICA_STCK_TST"."STCK_IDENT" IS 'StackIdentifier';
 
   COMMENT ON COLUMN "ICA_STCK_TST"."OTHR_STCK_TST_PURPOSE_NAME" IS 'OtherStackTestPurposeName';
 
   COMMENT ON COLUMN "ICA_STCK_TST"."STCK_TST_REP_RCVD_DATE" IS 'StackTestReportReceivedDate';
 
   COMMENT ON COLUMN "ICA_STCK_TST"."TST_RSLTS_REVIEWED_DATE" IS 'TestResultsReviewedDate';
 
   COMMENT ON TABLE "ICA_STCK_TST"  IS 'Schema element: AirStackTestData';
/
--------------------------------------------------------
--  DDL for Table ICA_STCK_TST_OBS_AGNCY_TYPE
--------------------------------------------------------

  CREATE TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE" 
   (	"ICA_STCK_TST_OBS_AGNCY_TYPE_ID" VARCHAR2(36 BYTE), 
	"ICA_STCK_TST_ID" VARCHAR2(36 BYTE), 
	"STCK_TST_OBS_AGNCY_TYPE_CODE" VARCHAR2(3 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_STCK_TST_OBS_AGNCY_TYPE"."STCK_TST_OBS_AGNCY_TYPE_CODE" IS 'StackTestObservedAgencyTypeCode';
 
   COMMENT ON TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_STCK_TST_PURPOSE
--------------------------------------------------------

  CREATE TABLE "ICA_STCK_TST_PURPOSE" 
   (	"ICA_STCK_TST_PURPOSE_ID" VARCHAR2(36 BYTE), 
	"ICA_STCK_TST_ID" VARCHAR2(36 BYTE), 
	"STCK_TST_PURPOSE_CODE" VARCHAR2(3 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_STCK_TST_PURPOSE"."STCK_TST_PURPOSE_CODE" IS 'StackTestPurposeCode';
 
   COMMENT ON TABLE "ICA_STCK_TST_PURPOSE"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_TELEPH
--------------------------------------------------------

  CREATE TABLE "ICA_TELEPH" 
   (	"ICA_TELEPH_ID" VARCHAR2(36 BYTE), 
	"ICA_CNTCT_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ADDR_ID" VARCHAR2(36 BYTE), 
	"TELEPH_NUM_TYPE_CODE" VARCHAR2(3 BYTE), 
	"TELEPH_NUM" VARCHAR2(10 BYTE), 
	"TELEPH_EXT_NUM" VARCHAR2(4 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_TELEPH"."TELEPH_NUM_TYPE_CODE" IS 'TelephoneNumberTypeCode';
 
   COMMENT ON COLUMN "ICA_TELEPH"."TELEPH_NUM" IS 'TelephoneNumber';
 
   COMMENT ON COLUMN "ICA_TELEPH"."TELEPH_EXT_NUM" IS 'TelephoneExtensionNumber';
 
   COMMENT ON TABLE "ICA_TELEPH"  IS 'Schema element: Telephone';
/
--------------------------------------------------------
--  DDL for Table ICA_TST_RSLTS
--------------------------------------------------------

  CREATE TABLE "ICA_TST_RSLTS" 
   (	"ICA_TST_RSLTS_ID" VARCHAR2(36 BYTE), 
	"ICA_STCK_TST_ID" VARCHAR2(36 BYTE), 
	"TESTED_POLUT_CODE" NUMBER(10,0), 
	"TST_RESULT_CODE" VARCHAR2(3 BYTE), 
	"ALLOWABLE_VALUE" NUMBER(10,0), 
	"ALLOWABLE_UNIT_CODE" VARCHAR2(7 BYTE), 
	"ACTUAL_RESULT" NUMBER(10,0), 
	"FAILURE_RSN_CODE" VARCHAR2(3 BYTE), 
	"OTHR_FAILURE_RSN_TXT" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_TST_RSLTS"."TESTED_POLUT_CODE" IS 'AirTestedPollutantCode';
 
   COMMENT ON COLUMN "ICA_TST_RSLTS"."TST_RESULT_CODE" IS 'TestResultCode';
 
   COMMENT ON COLUMN "ICA_TST_RSLTS"."ALLOWABLE_VALUE" IS 'AllowableValue';
 
   COMMENT ON COLUMN "ICA_TST_RSLTS"."ALLOWABLE_UNIT_CODE" IS 'AllowableUnitCode';
 
   COMMENT ON COLUMN "ICA_TST_RSLTS"."ACTUAL_RESULT" IS 'ActualResult';
 
   COMMENT ON COLUMN "ICA_TST_RSLTS"."FAILURE_RSN_CODE" IS 'FailureReasonCode';
 
   COMMENT ON COLUMN "ICA_TST_RSLTS"."OTHR_FAILURE_RSN_TXT" IS 'OtherFailureReasonText';
 
   COMMENT ON TABLE "ICA_TST_RSLTS"  IS 'Schema element: TestResultsData';
/
--------------------------------------------------------
--  DDL for Table ICA_TVACC
--------------------------------------------------------

  CREATE TABLE "ICA_TVACC" 
   (	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"ICA_PAYLOAD_ID" VARCHAR2(36 BYTE), 
	"TRANSACTION_TYPE" CHAR(1 BYTE), 
	"TRANSACTION_TIMESTAMP" TIMESTAMP (6), 
	"CMPL_MON_IDENT" VARCHAR2(25 BYTE), 
	"CMPL_MON_DATE" TIMESTAMP (6), 
	"CMPL_MON_START_DATE" DATE, 
	"CMPL_MON_ACTY_NAME" VARCHAR2(100 BYTE), 
	"MULTIMEDIA_IND" CHAR(1 BYTE), 
	"CMPL_MON_PLANNED_START_DATE" DATE, 
	"CMPL_MON_PLANNED_END_DATE" DATE, 
	"DEFICIENCIES_OBS_IND" CHAR(1 BYTE), 
	"FAC_IDENT" CHAR(18 BYTE), 
	"LEAD_AGNCY_CODE" VARCHAR2(3 BYTE), 
	"OTHR_PROG_DESC_TXT" VARCHAR2(100 BYTE), 
	"OTHR_AGNCY_INITIATIVE_TXT" VARCHAR2(200 BYTE), 
	"INSP_USR_DEF_FLD_1" CHAR(1 BYTE), 
	"INSP_USR_DEF_FLD_2" VARCHAR2(50 BYTE), 
	"INSP_USR_DEF_FLD_3" VARCHAR2(50 BYTE), 
	"INSP_USR_DEF_FLD_4" DATE, 
	"INSP_USR_DEF_FLD_5" DATE, 
	"INSP_USR_DEF_FLD_6" VARCHAR2(4000 BYTE), 
	"PRMT_IDENT" VARCHAR2(100 BYTE), 
	"CERT_PERIOD_START_DATE" DATE, 
	"CERT_PERIOD_END_DATE" DATE, 
	"FAC_REP_CMPL_STAT_CODE" VARCHAR2(3 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_TVACC"."TRANSACTION_TYPE" IS 'TransactionType';
 
   COMMENT ON COLUMN "ICA_TVACC"."TRANSACTION_TIMESTAMP" IS 'TransactionTimestamp';
 
   COMMENT ON COLUMN "ICA_TVACC"."CMPL_MON_IDENT" IS 'ComplianceMonitoringIdentifier';
 
   COMMENT ON COLUMN "ICA_TVACC"."CMPL_MON_DATE" IS 'ComplianceMonitoringDate';
 
   COMMENT ON COLUMN "ICA_TVACC"."CMPL_MON_START_DATE" IS 'ComplianceMonitoringStartDate';
 
   COMMENT ON COLUMN "ICA_TVACC"."CMPL_MON_ACTY_NAME" IS 'ComplianceMonitoringActivityName';
 
   COMMENT ON COLUMN "ICA_TVACC"."MULTIMEDIA_IND" IS 'MultimediaIndicator';
 
   COMMENT ON COLUMN "ICA_TVACC"."CMPL_MON_PLANNED_START_DATE" IS 'ComplianceMonitoringPlannedStartDate';
 
   COMMENT ON COLUMN "ICA_TVACC"."CMPL_MON_PLANNED_END_DATE" IS 'ComplianceMonitoringPlannedEndDate';
 
   COMMENT ON COLUMN "ICA_TVACC"."DEFICIENCIES_OBS_IND" IS 'DeficienciesObservedIndicator';
 
   COMMENT ON COLUMN "ICA_TVACC"."FAC_IDENT" IS 'AirFacilityIdentifier';
 
   COMMENT ON COLUMN "ICA_TVACC"."LEAD_AGNCY_CODE" IS 'LeadAgencyCode';
 
   COMMENT ON COLUMN "ICA_TVACC"."OTHR_PROG_DESC_TXT" IS 'OtherProgramDescriptionText';
 
   COMMENT ON COLUMN "ICA_TVACC"."OTHR_AGNCY_INITIATIVE_TXT" IS 'OtherAgencyInitiativeText';
 
   COMMENT ON COLUMN "ICA_TVACC"."INSP_USR_DEF_FLD_1" IS 'InspectionUserDefinedField1';
 
   COMMENT ON COLUMN "ICA_TVACC"."INSP_USR_DEF_FLD_2" IS 'InspectionUserDefinedField2';
 
   COMMENT ON COLUMN "ICA_TVACC"."INSP_USR_DEF_FLD_3" IS 'InspectionUserDefinedField3';
 
   COMMENT ON COLUMN "ICA_TVACC"."INSP_USR_DEF_FLD_4" IS 'InspectionUserDefinedField4';
 
   COMMENT ON COLUMN "ICA_TVACC"."INSP_USR_DEF_FLD_5" IS 'InspectionUserDefinedField5';
 
   COMMENT ON COLUMN "ICA_TVACC"."INSP_USR_DEF_FLD_6" IS 'InspectionUserDefinedField6';
 
   COMMENT ON COLUMN "ICA_TVACC"."PRMT_IDENT" IS 'AirPermitIdentifier';
 
   COMMENT ON COLUMN "ICA_TVACC"."CERT_PERIOD_START_DATE" IS 'CertificationPeriodStartDate';
 
   COMMENT ON COLUMN "ICA_TVACC"."CERT_PERIOD_END_DATE" IS 'CertificationPeriodEndDate';
 
   COMMENT ON COLUMN "ICA_TVACC"."FAC_REP_CMPL_STAT_CODE" IS 'FacilityReportedComplianceStatusCode';
 
   COMMENT ON TABLE "ICA_TVACC"  IS 'Schema element: AirTVACCData';
/
--------------------------------------------------------
--  DDL for Table ICA_TVACC_REVIEW
--------------------------------------------------------

  CREATE TABLE "ICA_TVACC_REVIEW" 
   (	"ICA_TVACC_REVIEW_ID" VARCHAR2(36 BYTE), 
	"ICA_TVACC_ID" VARCHAR2(36 BYTE), 
	"TVACC_REVIEWED_DATE" DATE, 
	"FAC_REP_DEVIATIONS_IND" CHAR(1 BYTE), 
	"PRMT_CONDS_TXT" VARCHAR2(100 BYTE), 
	"EXCEED_EXCURS_IND" CHAR(1 BYTE), 
	"REVIEWER_AGNCY_CODE" VARCHAR2(3 BYTE), 
	"TVACC_REVIEWER_NAME" VARCHAR2(100 BYTE), 
	"REVIEWER_CMNT" VARCHAR2(100 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."TVACC_REVIEWED_DATE" IS 'TVACCReviewedDate';
 
   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."FAC_REP_DEVIATIONS_IND" IS 'FacilityReportDeviationsIndicator';
 
   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."PRMT_CONDS_TXT" IS 'PermitConditionsText';
 
   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."EXCEED_EXCURS_IND" IS 'ExceedanceExcursionIndicator';
 
   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."REVIEWER_AGNCY_CODE" IS 'ReviewerAgencyCode';
 
   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."TVACC_REVIEWER_NAME" IS 'TVACCReviewerName';
 
   COMMENT ON COLUMN "ICA_TVACC_REVIEW"."REVIEWER_CMNT" IS 'ReviewerComment';
 
   COMMENT ON TABLE "ICA_TVACC_REVIEW"  IS 'Schema element: TVACCReviewData';
/
--------------------------------------------------------
--  DDL for Table ICA_UNIVERSE_IND
--------------------------------------------------------

  CREATE TABLE "ICA_UNIVERSE_IND" 
   (	"ICA_UNIVERSE_IND_ID" VARCHAR2(36 BYTE), 
	"ICA_FAC_ID" VARCHAR2(36 BYTE), 
	"UNIVERSE_IND_CODE" VARCHAR2(10 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ICA_UNIVERSE_IND"."UNIVERSE_IND_CODE" IS 'UniverseIndicatorCode';
 
   COMMENT ON TABLE "ICA_UNIVERSE_IND"  IS 'Schema element: String';
/
--------------------------------------------------------
--  DDL for Table ICA_VIOL
--------------------------------------------------------

  CREATE TABLE "ICA_VIOL" 
   (	"ICA_VIOL_ID" VARCHAR2(36 BYTE), 
	"ICA_DA_CASE_FILE_ID" VARCHAR2(36 BYTE), 
	"VIOL_TYPE_CODE" VARCHAR2(5 BYTE), 
	"VIOL_PROG_CODE" VARCHAR2(9 BYTE), 
	"VIOL_PROG_DESC_TXT" VARCHAR2(1000 BYTE), 
	"VIOL_POLUT_CODE" NUMBER(10,0), 
	"FRV_DTRMN_DATE" DATE, 
	"HPV_DAY_ZERO_DATE" DATE, 
	"OCCURRENCE_START_DATE" DATE, 
	"OCCURRENCE_END_DATE" DATE, 
	"HPV_DESGN_RMVL_TYPE_CODE" VARCHAR2(3 BYTE), 
	"HPV_DESGN_RMVL_DATE" DATE, 
	"CLAIMS_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "ICA_VIOL"."VIOL_TYPE_CODE" IS 'AirViolationTypeCode';
 
   COMMENT ON COLUMN "ICA_VIOL"."VIOL_PROG_CODE" IS 'AirViolationProgramCode';
 
   COMMENT ON COLUMN "ICA_VIOL"."VIOL_PROG_DESC_TXT" IS 'AirViolationProgramDescriptionText';
 
   COMMENT ON COLUMN "ICA_VIOL"."VIOL_POLUT_CODE" IS 'AirViolationPollutantCode';
 
   COMMENT ON COLUMN "ICA_VIOL"."FRV_DTRMN_DATE" IS 'FRVDeterminationDate';
 
   COMMENT ON COLUMN "ICA_VIOL"."HPV_DAY_ZERO_DATE" IS 'HPVDayZeroDate';
 
   COMMENT ON COLUMN "ICA_VIOL"."OCCURRENCE_START_DATE" IS 'OccurrenceStartDate';
 
   COMMENT ON COLUMN "ICA_VIOL"."OCCURRENCE_END_DATE" IS 'OccurrenceEndDate';
 
   COMMENT ON COLUMN "ICA_VIOL"."HPV_DESGN_RMVL_TYPE_CODE" IS 'HPVDesignationRemovalTypeCode';
 
   COMMENT ON COLUMN "ICA_VIOL"."HPV_DESGN_RMVL_DATE" IS 'HPVDesignationRemovalDate';
 
   COMMENT ON COLUMN "ICA_VIOL"."CLAIMS_NUM" IS 'ClaimsNumber';
 
   COMMENT ON TABLE "ICA_VIOL"  IS 'Schema element: AirViolationData';
/
--------------------------------------------------------
--  DDL for Index IX_SIC_CODE_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_SIC_CODE_ICA_FAC_ID" ON "ICA_SIC_CODE" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_FRM_ENF_ACT_DA_ENF_AC_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_DA_FRM_ENF_ACT_DA_ENF_AC_ID" ON "ICA_DA_FRML_ENFRC_ACTN" ("DA_ENFRC_ACTN_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TVACC_CMPL_MON_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_TVACC_CMPL_MON_IDENT" ON "ICA_TVACC" ("CMPL_MON_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_GEO_COORD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GEO_COORD" ON "ICA_GEO_COORD" ("ICA_GEO_COORD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_ADDR_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_ADDR_ICA_FAC_ID" ON "ICA_FAC_ADDR" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_EN_AC_CM_TX_IC_DA_FR_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_EN_AC_CM_TX_IC_DA_FR_EN_AC" ON "ICA_ENFRC_ACTN_CMNT_TXT" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_TST_RSLTS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TST_RSLTS" ON "ICA_TST_RSLTS" ("ICA_TST_RSLTS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_INS_CMN_TXT_ICA_DA_CM_MO_ID
--------------------------------------------------------

  CREATE INDEX "IX_INS_CMN_TXT_ICA_DA_CM_MO_ID" ON "ICA_INSP_CMNT_TXT" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TST_RSLTS_ICA_STCK_TST_ID
--------------------------------------------------------

  CREATE INDEX "IX_TST_RSLTS_ICA_STCK_TST_ID" ON "ICA_TST_RSLTS" ("ICA_STCK_TST_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_CMPL_MON_STRGY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CMPL_MON_STRGY" ON "ICA_CMPL_MON_STRGY" ("ICA_CMPL_MON_STRGY_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_OTHR_PATHWAY_ACTY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_OTHR_PATHWAY_ACTY" ON "ICA_OTHR_PATHWAY_ACTY" ("ICA_OTHR_PATHWAY_ACTY_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_FAC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC" ON "ICA_FAC" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_IDN_ICA_DA_FRM_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_IDN_ICA_DA_FRM_EN_AC_ID" ON "ICA_FAC_IDENT" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_LNK_CMPL_MON
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LNK_CMPL_MON" ON "ICA_LNK_CMPL_MON" ("ICA_LNK_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_STCK_TST
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_STCK_TST" ON "ICA_STCK_TST" ("ICA_STCK_TST_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PROGS_VIOL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PROGS_VIOL" ON "ICA_PROGS_VIOL" ("ICA_PROGS_VIOL_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ENF_AG_TY_IC_DA_IN_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENF_AG_TY_IC_DA_IN_EN_AC_ID" ON "ICA_ENFRC_AGNCY_TYPE" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_STCK_TST_PURPOSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_STCK_TST_PURPOSE" ON "ICA_STCK_TST_PURPOSE" ("ICA_STCK_TST_PURPOSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ENF_AC_TY_IC_DA_FR_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENF_AC_TY_IC_DA_FR_EN_AC_ID" ON "ICA_ENFRC_ACTN_TYPE" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CNTCT_ICA_DA_CMPL_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_CNTCT_ICA_DA_CMPL_MON_ID" ON "ICA_CNTCT" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_ICA_PAYLOAD_ID" ON "ICA_FAC" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LNK_CMP_MON_ICA_CA_FI_LN_ID
--------------------------------------------------------

  CREATE INDEX "IX_LNK_CMP_MON_ICA_CA_FI_LN_ID" ON "ICA_LNK_CMPL_MON" ("ICA_CASE_FILE_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROGS_FAC_IDENT_PROG_CODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_PROGS_FAC_IDENT_PROG_CODE" ON "ICA_PROGS" ("FAC_IDENT", "PROG_CODE") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_EN_AC_GO_CN_IC_DA_IN_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_EN_AC_GO_CN_IC_DA_IN_EN_AC" ON "ICA_ENFRC_ACTN_GOV_CNTCT" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_ENFR_ACTN_MLS_ICA_PYL_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_ENFR_ACTN_MLS_ICA_PYL_ID" ON "ICA_DA_ENFRC_ACTN_MILSTN" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_CMPL_MON_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_CMPL_MON_ICA_PAYLOAD_ID" ON "ICA_DA_CMPL_MON" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_METHOD_ICA_TST_RSLTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_METHOD_ICA_TST_RSLTS_ID" ON "ICA_METHOD" ("ICA_TST_RSLTS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_TVACC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TVACC" ON "ICA_TVACC" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_FRML_ENFR_ACT_ICA_PYL_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_FRML_ENFR_ACT_ICA_PYL_ID" ON "ICA_DA_FRML_ENFRC_ACTN" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_ENFR_ACTN_LNK_ICA_PYL_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_ENFR_ACTN_LNK_ICA_PYL_ID" ON "ICA_DA_ENFRC_ACTN_LNK" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_EN_AC_ML_DA_EN_AC_ID_ML
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_DA_EN_AC_ML_DA_EN_AC_ID_ML" ON "ICA_DA_ENFRC_ACTN_MILSTN" ("DA_ENFRC_ACTN_IDENT", "MILSTN_TYPE_CODE") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PLUT_ICA_DA_FRML_ENF_ACT_ID
--------------------------------------------------------

  CREATE INDEX "IX_PLUT_ICA_DA_FRML_ENF_ACT_ID" ON "ICA_POLUT" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_CASE_FILE_CMNT_TXT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CASE_FILE_CMNT_TXT" ON "ICA_CASE_FILE_CMNT_TXT" ("ICA_CASE_FILE_CMNT_TXT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SEN_CMN_TXT_ICA_DA_CM_MO_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEN_CMN_TXT_ICA_DA_CM_MO_ID" ON "ICA_SENS_CMNT_TXT" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ENF_AG_TY_IC_DA_FR_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENF_AG_TY_IC_DA_FR_EN_AC_ID" ON "ICA_ENFRC_AGNCY_TYPE" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_CASE_FILE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_CASE_FILE" ON "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LNK_CMP_MON_ICA_CM_MO_LN_ID
--------------------------------------------------------

  CREATE INDEX "IX_LNK_CMP_MON_ICA_CM_MO_LN_ID" ON "ICA_LNK_CMPL_MON" ("ICA_CMPL_MON_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_NAICS_CODE_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_NAICS_CODE_ICA_FAC_ID" ON "ICA_NAICS_CODE" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_NAICS_CODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NAICS_CODE" ON "ICA_NAICS_CODE" ("ICA_NAICS_CODE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_ENF_ACT_LNK_DA_ENF_AC_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_DA_ENF_ACT_LNK_DA_ENF_AC_ID" ON "ICA_DA_ENFRC_ACTN_LNK" ("DA_ENFRC_ACTN_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_FINAL_ORDER
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_FINAL_ORDER" ON "ICA_DA_FINAL_ORDER" ("ICA_DA_FINAL_ORDER_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_CMPL_MON_CMPL_MON_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_DA_CMPL_MON_CMPL_MON_IDENT" ON "ICA_DA_CMPL_MON" ("CMPL_MON_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUT_ICA_DA_CASE_FILE_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUT_ICA_DA_CASE_FILE_ID" ON "ICA_POLUT" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_SENS_CMNT_TXT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SENS_CMNT_TXT" ON "ICA_SENS_CMNT_TXT" ("ICA_SENS_CMNT_TXT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LNK_CAS_FIL_ICA_CA_FI_LN_ID
--------------------------------------------------------

  CREATE INDEX "IX_LNK_CAS_FIL_ICA_CA_FI_LN_ID" ON "ICA_LNK_CASE_FILE" ("ICA_CASE_FILE_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_FRML_ENFRC_ACTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_FRML_ENFRC_ACTN" ON "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_IDNT_ICA_DA_CMPL_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_IDNT_ICA_DA_CMPL_MON_ID" ON "ICA_FAC_IDENT" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_IN_EA_CM_TX_IC_DA_IN_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_IN_EA_CM_TX_IC_DA_IN_EN_AC" ON "ICA_INFRML_EA_CMNT_TXT" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_INFRML_EA_CMNT_TXT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INFRML_EA_CMNT_TXT" ON "ICA_INFRML_EA_CMNT_TXT" ("ICA_INFRML_EA_CMNT_TXT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_CASE_FILE_CASE_FILE_IDNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_DA_CASE_FILE_CASE_FILE_IDNT" ON "ICA_DA_CASE_FILE" ("CASE_FILE_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ENFRC_ACTN_CMNT_TXT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENFRC_ACTN_CMNT_TXT" ON "ICA_ENFRC_ACTN_CMNT_TXT" ("ICA_ENFRC_ACTN_CMNT_TXT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUT_DA_CLASS_ICA_PLUTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUT_DA_CLASS_ICA_PLUTS_ID" ON "ICA_POLUT_DA_CLASS" ("ICA_POLUTS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_INSP_GOV_CNTCT_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_INSP_GOV_CNTCT_ICA_TVACC_ID" ON "ICA_INSP_GOV_CNTCT" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_NAT_PRIO_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_NAT_PRIO_ICA_TVACC_ID" ON "ICA_NAT_PRIO" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRG_VIO_ICA_DA_INF_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRG_VIO_ICA_DA_INF_EN_AC_ID" ON "ICA_PROGS_VIOL" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_FAC_ADDR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_ADDR" ON "ICA_FAC_ADDR" ("ICA_FAC_ADDR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_STCK_TST_PRP_ICA_STC_TST_ID
--------------------------------------------------------

  CREATE INDEX "IX_STCK_TST_PRP_ICA_STC_TST_ID" ON "ICA_STCK_TST_PURPOSE" ("ICA_STCK_TST_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_ENFRC_ACTN_LNK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_ENFRC_ACTN_LNK" ON "ICA_DA_ENFRC_ACTN_LNK" ("ICA_DA_ENFRC_ACTN_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_NAT_PRIO_ICA_DA_CMPL_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_NAT_PRIO_ICA_DA_CMPL_MON_ID" ON "ICA_NAT_PRIO" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CMP_INS_TYP_ICA_DA_CM_MO_ID
--------------------------------------------------------

  CREATE INDEX "IX_CMP_INS_TYP_ICA_DA_CM_MO_ID" ON "ICA_CMPL_INSP_TYPE" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUT_ICA_DA_CMPL_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUT_ICA_DA_CMPL_MON_ID" ON "ICA_POLUT" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CMPL_MON_STRGY_ICA_PYLOD_ID
--------------------------------------------------------

  CREATE INDEX "IX_CMPL_MON_STRGY_ICA_PYLOD_ID" ON "ICA_CMPL_MON_STRGY" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PAYLOAD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PAYLOAD" ON "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUTS_FAC_IDENT_PLUTS_CODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_POLUTS_FAC_IDENT_PLUTS_CODE" ON "ICA_POLUTS" ("FAC_IDENT", "POLUTS_CODE") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TELEPH_ICA_CNTCT_ID
--------------------------------------------------------

  CREATE INDEX "IX_TELEPH_ICA_CNTCT_ID" ON "ICA_TELEPH" ("ICA_CNTCT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_IDN_ICA_DA_INF_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_FAC_IDN_ICA_DA_INF_EN_AC_ID" ON "ICA_FAC_IDENT" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_STC_TS_OB_AG_TY_IC_ST_TS_ID
--------------------------------------------------------

  CREATE INDEX "IX_STC_TS_OB_AG_TY_IC_ST_TS_ID" ON "ICA_STCK_TST_OBS_AGNCY_TYPE" ("ICA_STCK_TST_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TELEPH_ICA_FAC_ADDR_ID
--------------------------------------------------------

  CREATE INDEX "IX_TELEPH_ICA_FAC_ADDR_ID" ON "ICA_TELEPH" ("ICA_FAC_ADDR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_OTH_PTH_ACT_ICA_DA_CA_FI_ID
--------------------------------------------------------

  CREATE INDEX "IX_OTH_PTH_ACT_ICA_DA_CA_FI_ID" ON "ICA_OTHR_PATHWAY_ACTY" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PORT_SRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PORT_SRC" ON "ICA_PORT_SRC" ("ICA_PORT_SRC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_SIC_CODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SIC_CODE" ON "ICA_SIC_CODE" ("ICA_SIC_CODE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SEN_CMN_TXT_ICA_DA_CA_FI_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEN_CMN_TXT_ICA_DA_CA_FI_ID" ON "ICA_SENS_CMNT_TXT" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TVACC_REVIEW_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_TVACC_REVIEW_ICA_TVACC_ID" ON "ICA_TVACC_REVIEW" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_RGNL_PRIO_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_RGNL_PRIO_ICA_TVACC_ID" ON "ICA_RGNL_PRIO" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_FAC_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FAC_IDENT" ON "ICA_FAC_IDENT" ("ICA_FAC_IDENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_CASE_FILE_LNK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CASE_FILE_LNK" ON "ICA_CASE_FILE_LNK" ("ICA_CASE_FILE_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_INFR_ENFR_ACT_ICA_PYL_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_INFR_ENFR_ACT_ICA_PYL_ID" ON "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_POLUT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_POLUT" ON "ICA_POLUT" ("ICA_POLUT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CNTCT_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_CNTCT_ICA_TVACC_ID" ON "ICA_CNTCT" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_INSP_GOV_CNTCT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INSP_GOV_CNTCT" ON "ICA_INSP_GOV_CNTCT" ("ICA_INSP_GOV_CNTCT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROG_ICA_DA_CMPL_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_PROG_ICA_DA_CMPL_MON_ID" ON "ICA_PROG" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROG_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_PROG_ICA_TVACC_ID" ON "ICA_PROG" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_FINAL_ORDER_FAC_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FINAL_ORDER_FAC_IDENT" ON "ICA_FINAL_ORDER_FAC_IDENT" ("ICA_FINAL_ORDER_FAC_IDENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LNK_DA_EN_AC_IC_CA_FI_LN_ID
--------------------------------------------------------

  CREATE INDEX "IX_LNK_DA_EN_AC_IC_CA_FI_LN_ID" ON "ICA_LNK_DA_ENFRC_ACTN" ("ICA_CASE_FILE_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_LNK_DA_ENFRC_ACTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LNK_DA_ENFRC_ACTN" ON "ICA_LNK_DA_ENFRC_ACTN" ("ICA_LNK_DA_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_UNIVERSE_IND
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UNIVERSE_IND" ON "ICA_UNIVERSE_IND" ("ICA_UNIVERSE_IND_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_ENFRC_ACTN_MILSTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_ENFRC_ACTN_MILSTN" ON "ICA_DA_ENFRC_ACTN_MILSTN" ("ICA_DA_ENFRC_ACTN_MILSTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PROG_SUBPART
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PROG_SUBPART" ON "ICA_PROG_SUBPART" ("ICA_PROG_SUBPART_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_NAT_PRIO
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NAT_PRIO" ON "ICA_NAT_PRIO" ("ICA_NAT_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_TELEPH
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TELEPH" ON "ICA_TELEPH" ("ICA_TELEPH_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ENFRC_ACTN_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENFRC_ACTN_TYPE" ON "ICA_ENFRC_ACTN_TYPE" ("ICA_ENFRC_ACTN_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SEN_CM_TX_IC_DA_IN_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEN_CM_TX_IC_DA_IN_EN_AC_ID" ON "ICA_SENS_CMNT_TXT" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PROG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PROG" ON "ICA_PROG" ("ICA_PROG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_INF_ENF_ACT_DA_ENF_AC_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_DA_INF_ENF_ACT_DA_ENF_AC_ID" ON "ICA_DA_INFRML_ENFRC_ACTN" ("DA_ENFRC_ACTN_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PROGS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PROGS" ON "ICA_PROGS" ("ICA_PROGS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_CMPL_INSP_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CMPL_INSP_TYPE" ON "ICA_CMPL_INSP_TYPE" ("ICA_CMPL_INSP_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_POLUT_DA_CLASS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_POLUT_DA_CLASS" ON "ICA_POLUT_DA_CLASS" ("ICA_POLUT_DA_CLASS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROG_SUBPART_ICA_PROGS_ID
--------------------------------------------------------

  CREATE INDEX "IX_PROG_SUBPART_ICA_PROGS_ID" ON "ICA_PROG_SUBPART" ("ICA_PROGS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CASE_FILE_LNK_ICA_PAYLOD_ID
--------------------------------------------------------

  CREATE INDEX "IX_CASE_FILE_LNK_ICA_PAYLOD_ID" ON "ICA_CASE_FILE_LNK" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_INSP_CMNT_TXT_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_INSP_CMNT_TXT_ICA_TVACC_ID" ON "ICA_INSP_CMNT_TXT" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_EN_AC_GO_CN_IC_DA_FR_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_EN_AC_GO_CN_IC_DA_FR_EN_AC" ON "ICA_ENFRC_ACTN_GOV_CNTCT" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_UNIVERSE_IND_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_UNIVERSE_IND_ICA_FAC_ID" ON "ICA_UNIVERSE_IND" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_VIOL_ICA_DA_CASE_FILE_ID
--------------------------------------------------------

  CREATE INDEX "IX_VIOL_ICA_DA_CASE_FILE_ID" ON "ICA_VIOL" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_FIN_OR_IC_DA_FR_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_FIN_OR_IC_DA_FR_EN_AC_ID" ON "ICA_DA_FINAL_ORDER" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_STCK_TST_ICA_DA_CMPL_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_STCK_TST_ICA_DA_CMPL_MON_ID" ON "ICA_STCK_TST" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_CMPL_MON_LNK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CMPL_MON_LNK" ON "ICA_CMPL_MON_LNK" ("ICA_CMPL_MON_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DA_CASE_FILE_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_DA_CASE_FILE_ICA_PAYLOAD_ID" ON "ICA_DA_CASE_FILE" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FAC_FAC_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_FAC_FAC_IDENT" ON "ICA_FAC" ("FAC_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CMPL_MON_LNK_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_CMPL_MON_LNK_ICA_PAYLOAD_ID" ON "ICA_CMPL_MON_LNK" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_LNK_CASE_FILE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LNK_CASE_FILE" ON "ICA_LNK_CASE_FILE" ("ICA_LNK_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_INS_GOV_CNT_ICA_DA_CM_MO_ID
--------------------------------------------------------

  CREATE INDEX "IX_INS_GOV_CNT_ICA_DA_CM_MO_ID" ON "ICA_INSP_GOV_CNTCT" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROG_ICA_DA_CASE_FILE_ID
--------------------------------------------------------

  CREATE INDEX "IX_PROG_ICA_DA_CASE_FILE_ID" ON "ICA_PROG" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_POLUTS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_POLUTS" ON "ICA_POLUTS" ("ICA_POLUTS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PLUT_ICA_DA_INFR_ENF_ACT_ID
--------------------------------------------------------

  CREATE INDEX "IX_PLUT_ICA_DA_INFR_ENF_ACT_ID" ON "ICA_POLUT" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_METHOD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_METHOD" ON "ICA_METHOD" ("ICA_METHOD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SEN_CM_TX_IC_DA_FR_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEN_CM_TX_IC_DA_FR_EN_AC_ID" ON "ICA_SENS_CMNT_TXT" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CNTCT_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_CNTCT_ICA_FAC_ID" ON "ICA_CNTCT" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRG_VIO_ICA_DA_FRM_EN_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRG_VIO_ICA_DA_FRM_EN_AC_ID" ON "ICA_PROGS_VIOL" ("ICA_DA_FRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUT_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUT_ICA_TVACC_ID" ON "ICA_POLUT" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_RGNL_PRIO
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RGNL_PRIO" ON "ICA_RGNL_PRIO" ("ICA_RGNL_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUTS_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUTS_ICA_PAYLOAD_ID" ON "ICA_POLUTS" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CMPL_MON_STRGY_FAC_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_CMPL_MON_STRGY_FAC_IDENT" ON "ICA_CMPL_MON_STRGY" ("FAC_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_CMPL_MON
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_CMPL_MON" ON "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ENFRC_ACTN_GOV_CNTCT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENFRC_ACTN_GOV_CNTCT" ON "ICA_ENFRC_ACTN_GOV_CNTCT" ("ICA_ENFRC_ACTN_GOV_CNTCT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TVACC_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_TVACC_ICA_PAYLOAD_ID" ON "ICA_TVACC" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUT_EPA_CLSS_ICA_PLUTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUT_EPA_CLSS_ICA_PLUTS_ID" ON "ICA_POLUT_EPA_CLASS" ("ICA_POLUTS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_STCK_TST_OBS_AGNCY_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_STCK_TST_OBS_AGNCY_TYPE" ON "ICA_STCK_TST_OBS_AGNCY_TYPE" ("ICA_STCK_TST_OBS_AGNCY_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ENFRC_AGNCY_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENFRC_AGNCY_TYPE" ON "ICA_ENFRC_AGNCY_TYPE" ("ICA_ENFRC_AGNCY_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_RGNL_PRIO_ICA_DA_CMP_MON_ID
--------------------------------------------------------

  CREATE INDEX "IX_RGNL_PRIO_ICA_DA_CMP_MON_ID" ON "ICA_RGNL_PRIO" ("ICA_DA_CMPL_MON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_TVACC_REVIEW
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TVACC_REVIEW" ON "ICA_TVACC_REVIEW" ("ICA_TVACC_REVIEW_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DA_INFRML_ENFRC_ACTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DA_INFRML_ENFRC_ACTN" ON "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_INSP_CMNT_TXT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_INSP_CMNT_TXT" ON "ICA_INSP_CMNT_TXT" ("ICA_INSP_CMNT_TXT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROGS_ICA_PAYLOAD_ID
--------------------------------------------------------

  CREATE INDEX "IX_PROGS_ICA_PAYLOAD_ID" ON "ICA_PROGS" ("ICA_PAYLOAD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_GEO_COORD_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_GEO_COORD_ICA_FAC_ID" ON "ICA_GEO_COORD" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CASE_FILE_LNK_CASE_FILE_IDN
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_CASE_FILE_LNK_CASE_FILE_IDN" ON "ICA_CASE_FILE_LNK" ("CASE_FILE_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_FIN_OR_FA_ID_IC_DA_FI_OR_ID
--------------------------------------------------------

  CREATE INDEX "IX_FIN_OR_FA_ID_IC_DA_FI_OR_ID" ON "ICA_FINAL_ORDER_FAC_IDENT" ("ICA_DA_FINAL_ORDER_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CAS_FI_CM_TX_IC_DA_CA_FI_ID
--------------------------------------------------------

  CREATE INDEX "IX_CAS_FI_CM_TX_IC_DA_CA_FI_ID" ON "ICA_CASE_FILE_CMNT_TXT" ("ICA_DA_CASE_FILE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LNK_DA_EN_AC_IC_CM_MO_LN_ID
--------------------------------------------------------

  CREATE INDEX "IX_LNK_DA_EN_AC_IC_CM_MO_LN_ID" ON "ICA_LNK_DA_ENFRC_ACTN" ("ICA_CMPL_MON_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_VIOL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_VIOL" ON "ICA_VIOL" ("ICA_VIOL_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_CMPL_MON_LNK_CMPL_MON_IDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "IX_CMPL_MON_LNK_CMPL_MON_IDENT" ON "ICA_CMPL_MON_LNK" ("CMPL_MON_IDENT") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LN_DA_EN_AC_IC_DA_EN_AC_LN
--------------------------------------------------------

  CREATE INDEX "IX_LN_DA_EN_AC_IC_DA_EN_AC_LN" ON "ICA_LNK_DA_ENFRC_ACTN" ("ICA_DA_ENFRC_ACTN_LNK_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_CNTCT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CNTCT" ON "ICA_CNTCT" ("ICA_CNTCT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SENS_CMNT_TXT_ICA_TVACC_ID
--------------------------------------------------------

  CREATE INDEX "IX_SENS_CMNT_TXT_ICA_TVACC_ID" ON "ICA_SENS_CMNT_TXT" ("ICA_TVACC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_POLUT_EPA_CLASS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_POLUT_EPA_CLASS" ON "ICA_POLUT_EPA_CLASS" ("ICA_POLUT_EPA_CLASS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PORT_SRC_ICA_FAC_ID
--------------------------------------------------------

  CREATE INDEX "IX_PORT_SRC_ICA_FAC_ID" ON "ICA_PORT_SRC" ("ICA_FAC_ID") 
  ;
/
--------------------------------------------------------
--  Constraints for Table ICA_PROGS
--------------------------------------------------------

  ALTER TABLE "ICA_PROGS" ADD CONSTRAINT "PK_PROGS" PRIMARY KEY ("ICA_PROGS_ID") ENABLE;
 
  ALTER TABLE "ICA_PROGS" MODIFY ("ICA_PROGS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROGS" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROGS" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROGS" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROGS" MODIFY ("PROG_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROGS" MODIFY ("PROG_OPER_STAT_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_LNK_DA_ENFRC_ACTN
--------------------------------------------------------

  ALTER TABLE "ICA_LNK_DA_ENFRC_ACTN" ADD CONSTRAINT "PK_LNK_DA_ENFRC_ACTN" PRIMARY KEY ("ICA_LNK_DA_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_LNK_DA_ENFRC_ACTN" MODIFY ("ICA_LNK_DA_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_LNK_DA_ENFRC_ACTN" MODIFY ("DA_ENFRC_ACTN_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_TVACC
--------------------------------------------------------

  ALTER TABLE "ICA_TVACC" ADD CONSTRAINT "PK_TVACC" PRIMARY KEY ("ICA_TVACC_ID") ENABLE;
 
  ALTER TABLE "ICA_TVACC" MODIFY ("ICA_TVACC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TVACC" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TVACC" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TVACC" MODIFY ("CMPL_MON_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TVACC" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_STCK_TST_PURPOSE
--------------------------------------------------------

  ALTER TABLE "ICA_STCK_TST_PURPOSE" ADD CONSTRAINT "PK_STCK_TST_PURPOSE" PRIMARY KEY ("ICA_STCK_TST_PURPOSE_ID") ENABLE;
 
  ALTER TABLE "ICA_STCK_TST_PURPOSE" MODIFY ("ICA_STCK_TST_PURPOSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST_PURPOSE" MODIFY ("ICA_STCK_TST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST_PURPOSE" MODIFY ("STCK_TST_PURPOSE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_PROGS_VIOL
--------------------------------------------------------

  ALTER TABLE "ICA_PROGS_VIOL" ADD CONSTRAINT "PK_PROGS_VIOL" PRIMARY KEY ("ICA_PROGS_VIOL_ID") ENABLE;
 
  ALTER TABLE "ICA_PROGS_VIOL" MODIFY ("ICA_PROGS_VIOL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROGS_VIOL" MODIFY ("PROGS_VIOL_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_OTHR_PATHWAY_ACTY
--------------------------------------------------------

  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" ADD CONSTRAINT "PK_OTHR_PATHWAY_ACTY" PRIMARY KEY ("ICA_OTHR_PATHWAY_ACTY_ID") ENABLE;
 
  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" MODIFY ("ICA_OTHR_PATHWAY_ACTY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" MODIFY ("ICA_DA_CASE_FILE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" MODIFY ("OTHR_PATHWAY_CATG_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" MODIFY ("OTHR_PATHWAY_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" MODIFY ("OTHR_PATHWAY_DATE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_RGNL_PRIO
--------------------------------------------------------

  ALTER TABLE "ICA_RGNL_PRIO" ADD CONSTRAINT "PK_RGNL_PRIO" PRIMARY KEY ("ICA_RGNL_PRIO_ID") ENABLE;
 
  ALTER TABLE "ICA_RGNL_PRIO" MODIFY ("ICA_RGNL_PRIO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_RGNL_PRIO" MODIFY ("RGNL_PRIO_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_TVACC_REVIEW
--------------------------------------------------------

  ALTER TABLE "ICA_TVACC_REVIEW" ADD CONSTRAINT "PK_TVACC_REVIEW" PRIMARY KEY ("ICA_TVACC_REVIEW_ID") ENABLE;
 
  ALTER TABLE "ICA_TVACC_REVIEW" MODIFY ("ICA_TVACC_REVIEW_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TVACC_REVIEW" MODIFY ("ICA_TVACC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TVACC_REVIEW" MODIFY ("TVACC_REVIEWED_DATE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_POLUT_DA_CLASS
--------------------------------------------------------

  ALTER TABLE "ICA_POLUT_DA_CLASS" ADD CONSTRAINT "PK_POLUT_DA_CLASS" PRIMARY KEY ("ICA_POLUT_DA_CLASS_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT_DA_CLASS" MODIFY ("ICA_POLUT_DA_CLASS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUT_DA_CLASS" MODIFY ("ICA_POLUTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUT_DA_CLASS" MODIFY ("POLUT_DA_CLASS_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_CMPL_MON
--------------------------------------------------------

  ALTER TABLE "ICA_DA_CMPL_MON" ADD CONSTRAINT "PK_DA_CMPL_MON" PRIMARY KEY ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_CMPL_MON" MODIFY ("ICA_DA_CMPL_MON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CMPL_MON" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CMPL_MON" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CMPL_MON" MODIFY ("CMPL_MON_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_FINAL_ORDER_FAC_IDENT
--------------------------------------------------------

  ALTER TABLE "ICA_FINAL_ORDER_FAC_IDENT" ADD CONSTRAINT "PK_FINAL_ORDER_FAC_IDENT" PRIMARY KEY ("ICA_FINAL_ORDER_FAC_IDENT_ID") ENABLE;
 
  ALTER TABLE "ICA_FINAL_ORDER_FAC_IDENT" MODIFY ("ICA_FINAL_ORDER_FAC_IDENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FINAL_ORDER_FAC_IDENT" MODIFY ("ICA_DA_FINAL_ORDER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FINAL_ORDER_FAC_IDENT" MODIFY ("FINAL_ORDER_FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_UNIVERSE_IND
--------------------------------------------------------

  ALTER TABLE "ICA_UNIVERSE_IND" ADD CONSTRAINT "PK_UNIVERSE_IND" PRIMARY KEY ("ICA_UNIVERSE_IND_ID") ENABLE;
 
  ALTER TABLE "ICA_UNIVERSE_IND" MODIFY ("ICA_UNIVERSE_IND_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_UNIVERSE_IND" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_UNIVERSE_IND" MODIFY ("UNIVERSE_IND_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_TELEPH
--------------------------------------------------------

  ALTER TABLE "ICA_TELEPH" ADD CONSTRAINT "PK_TELEPH" PRIMARY KEY ("ICA_TELEPH_ID") ENABLE;
 
  ALTER TABLE "ICA_TELEPH" MODIFY ("ICA_TELEPH_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TELEPH" MODIFY ("TELEPH_NUM_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_LNK_CASE_FILE
--------------------------------------------------------

  ALTER TABLE "ICA_LNK_CASE_FILE" ADD CONSTRAINT "PK_LNK_CASE_FILE" PRIMARY KEY ("ICA_LNK_CASE_FILE_ID") ENABLE;
 
  ALTER TABLE "ICA_LNK_CASE_FILE" MODIFY ("ICA_LNK_CASE_FILE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_LNK_CASE_FILE" MODIFY ("ICA_CASE_FILE_LNK_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_LNK_CASE_FILE" MODIFY ("CASE_FILE_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_CNTCT
--------------------------------------------------------

  ALTER TABLE "ICA_CNTCT" ADD CONSTRAINT "PK_CNTCT" PRIMARY KEY ("ICA_CNTCT_ID") ENABLE;
 
  ALTER TABLE "ICA_CNTCT" MODIFY ("ICA_CNTCT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CNTCT" MODIFY ("AFFIL_TYPE_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CNTCT" MODIFY ("FIRST_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CNTCT" MODIFY ("LAST_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CNTCT" MODIFY ("INDVL_TITLE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_ENFRC_ACTN_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_ACTN_TYPE" ADD CONSTRAINT "PK_ENFRC_ACTN_TYPE" PRIMARY KEY ("ICA_ENFRC_ACTN_TYPE_ID") ENABLE;
 
  ALTER TABLE "ICA_ENFRC_ACTN_TYPE" MODIFY ("ICA_ENFRC_ACTN_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_ENFRC_ACTN_TYPE" MODIFY ("ICA_DA_FRML_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_ENFRC_ACTN_TYPE" MODIFY ("ENFRC_ACTN_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_SIC_CODE
--------------------------------------------------------

  ALTER TABLE "ICA_SIC_CODE" ADD CONSTRAINT "PK_SIC_CODE" PRIMARY KEY ("ICA_SIC_CODE_ID") ENABLE;
 
  ALTER TABLE "ICA_SIC_CODE" MODIFY ("ICA_SIC_CODE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_SIC_CODE" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_SIC_CODE" MODIFY ("SIC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_SIC_CODE" MODIFY ("SIC_PRI_IND_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_ENFRC_ACTN_MILSTN
--------------------------------------------------------

  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" ADD CONSTRAINT "PK_DA_ENFRC_ACTN_MILSTN" PRIMARY KEY ("ICA_DA_ENFRC_ACTN_MILSTN_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" MODIFY ("ICA_DA_ENFRC_ACTN_MILSTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" MODIFY ("DA_ENFRC_ACTN_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" MODIFY ("MILSTN_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_CASE_FILE
--------------------------------------------------------

  ALTER TABLE "ICA_DA_CASE_FILE" ADD CONSTRAINT "PK_DA_CASE_FILE" PRIMARY KEY ("ICA_DA_CASE_FILE_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_CASE_FILE" MODIFY ("ICA_DA_CASE_FILE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CASE_FILE" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CASE_FILE" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CASE_FILE" MODIFY ("CASE_FILE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_CASE_FILE" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_CMPL_MON_LNK
--------------------------------------------------------

  ALTER TABLE "ICA_CMPL_MON_LNK" ADD CONSTRAINT "PK_CMPL_MON_LNK" PRIMARY KEY ("ICA_CMPL_MON_LNK_ID") ENABLE;
 
  ALTER TABLE "ICA_CMPL_MON_LNK" MODIFY ("ICA_CMPL_MON_LNK_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_MON_LNK" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_MON_LNK" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_MON_LNK" MODIFY ("CMPL_MON_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_FAC
--------------------------------------------------------

  ALTER TABLE "ICA_FAC" ADD CONSTRAINT "PK_FAC" PRIMARY KEY ("ICA_FAC_ID") ENABLE;
 
  ALTER TABLE "ICA_FAC" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FAC" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FAC" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FAC" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_CMPL_MON_STRGY
--------------------------------------------------------

  ALTER TABLE "ICA_CMPL_MON_STRGY" ADD CONSTRAINT "PK_CMPL_MON_STRGY" PRIMARY KEY ("ICA_CMPL_MON_STRGY_ID") ENABLE;
 
  ALTER TABLE "ICA_CMPL_MON_STRGY" MODIFY ("ICA_CMPL_MON_STRGY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_MON_STRGY" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_MON_STRGY" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_MON_STRGY" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_PROG_SUBPART
--------------------------------------------------------

  ALTER TABLE "ICA_PROG_SUBPART" ADD CONSTRAINT "PK_PROG_SUBPART" PRIMARY KEY ("ICA_PROG_SUBPART_ID") ENABLE;
 
  ALTER TABLE "ICA_PROG_SUBPART" MODIFY ("ICA_PROG_SUBPART_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROG_SUBPART" MODIFY ("ICA_PROGS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROG_SUBPART" MODIFY ("PROG_SUBPART_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_FRML_ENFRC_ACTN
--------------------------------------------------------

  ALTER TABLE "ICA_DA_FRML_ENFRC_ACTN" ADD CONSTRAINT "PK_DA_FRML_ENFRC_ACTN" PRIMARY KEY ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_FRML_ENFRC_ACTN" MODIFY ("ICA_DA_FRML_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_FRML_ENFRC_ACTN" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_FRML_ENFRC_ACTN" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_FRML_ENFRC_ACTN" MODIFY ("DA_ENFRC_ACTN_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_FAC_ADDR
--------------------------------------------------------

  ALTER TABLE "ICA_FAC_ADDR" ADD CONSTRAINT "PK_FAC_ADDR" PRIMARY KEY ("ICA_FAC_ADDR_ID") ENABLE;
 
  ALTER TABLE "ICA_FAC_ADDR" MODIFY ("ICA_FAC_ADDR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FAC_ADDR" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FAC_ADDR" MODIFY ("AFFIL_TYPE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_FINAL_ORDER
--------------------------------------------------------

  ALTER TABLE "ICA_DA_FINAL_ORDER" ADD CONSTRAINT "PK_DA_FINAL_ORDER" PRIMARY KEY ("ICA_DA_FINAL_ORDER_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_FINAL_ORDER" MODIFY ("ICA_DA_FINAL_ORDER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_FINAL_ORDER" MODIFY ("ICA_DA_FRML_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_FINAL_ORDER" MODIFY ("FINAL_ORDER_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_METHOD
--------------------------------------------------------

  ALTER TABLE "ICA_METHOD" ADD CONSTRAINT "PK_METHOD" PRIMARY KEY ("ICA_METHOD_ID") ENABLE;
 
  ALTER TABLE "ICA_METHOD" MODIFY ("ICA_METHOD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_METHOD" MODIFY ("ICA_TST_RSLTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_METHOD" MODIFY ("METHOD_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_INSP_GOV_CNTCT
--------------------------------------------------------

  ALTER TABLE "ICA_INSP_GOV_CNTCT" ADD CONSTRAINT "PK_INSP_GOV_CNTCT" PRIMARY KEY ("ICA_INSP_GOV_CNTCT_ID") ENABLE;
 
  ALTER TABLE "ICA_INSP_GOV_CNTCT" MODIFY ("ICA_INSP_GOV_CNTCT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_INSP_GOV_CNTCT" MODIFY ("AFFIL_TYPE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_LNK_CMPL_MON
--------------------------------------------------------

  ALTER TABLE "ICA_LNK_CMPL_MON" ADD CONSTRAINT "PK_LNK_CMPL_MON" PRIMARY KEY ("ICA_LNK_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_LNK_CMPL_MON" MODIFY ("ICA_LNK_CMPL_MON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_LNK_CMPL_MON" MODIFY ("CMPL_MON_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_ENFRC_AGNCY_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_AGNCY_TYPE" ADD CONSTRAINT "PK_ENFRC_AGNCY_TYPE" PRIMARY KEY ("ICA_ENFRC_AGNCY_TYPE_ID") ENABLE;
 
  ALTER TABLE "ICA_ENFRC_AGNCY_TYPE" MODIFY ("ICA_ENFRC_AGNCY_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_ENFRC_AGNCY_TYPE" MODIFY ("ENFRC_AGNCY_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_INSP_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_INSP_CMNT_TXT" ADD CONSTRAINT "PK_INSP_CMNT_TXT" PRIMARY KEY ("ICA_INSP_CMNT_TXT_ID") ENABLE;
 
  ALTER TABLE "ICA_INSP_CMNT_TXT" MODIFY ("ICA_INSP_CMNT_TXT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_INSP_CMNT_TXT" MODIFY ("INSP_CMNT_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_POLUT_EPA_CLASS
--------------------------------------------------------

  ALTER TABLE "ICA_POLUT_EPA_CLASS" ADD CONSTRAINT "PK_POLUT_EPA_CLASS" PRIMARY KEY ("ICA_POLUT_EPA_CLASS_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT_EPA_CLASS" MODIFY ("ICA_POLUT_EPA_CLASS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUT_EPA_CLASS" MODIFY ("ICA_POLUTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUT_EPA_CLASS" MODIFY ("POLUT_EPA_CLASS_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_ENFRC_ACTN_LNK
--------------------------------------------------------

  ALTER TABLE "ICA_DA_ENFRC_ACTN_LNK" ADD CONSTRAINT "PK_DA_ENFRC_ACTN_LNK" PRIMARY KEY ("ICA_DA_ENFRC_ACTN_LNK_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_LNK" MODIFY ("ICA_DA_ENFRC_ACTN_LNK_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_LNK" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_LNK" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_ENFRC_ACTN_LNK" MODIFY ("DA_ENFRC_ACTN_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_PAYLOAD
--------------------------------------------------------

  ALTER TABLE "ICA_PAYLOAD" ADD CONSTRAINT "PK_PAYLOAD" PRIMARY KEY ("ICA_PAYLOAD_ID") ENABLE;
 
  ALTER TABLE "ICA_PAYLOAD" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_CMPL_INSP_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_CMPL_INSP_TYPE" ADD CONSTRAINT "PK_CMPL_INSP_TYPE" PRIMARY KEY ("ICA_CMPL_INSP_TYPE_ID") ENABLE;
 
  ALTER TABLE "ICA_CMPL_INSP_TYPE" MODIFY ("ICA_CMPL_INSP_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_INSP_TYPE" MODIFY ("ICA_DA_CMPL_MON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CMPL_INSP_TYPE" MODIFY ("CMPL_INSP_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_DA_INFRML_ENFRC_ACTN
--------------------------------------------------------

  ALTER TABLE "ICA_DA_INFRML_ENFRC_ACTN" ADD CONSTRAINT "PK_DA_INFRML_ENFRC_ACTN" PRIMARY KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_DA_INFRML_ENFRC_ACTN" MODIFY ("ICA_DA_INFRML_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_INFRML_ENFRC_ACTN" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_INFRML_ENFRC_ACTN" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_DA_INFRML_ENFRC_ACTN" MODIFY ("DA_ENFRC_ACTN_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_CASE_FILE_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_CASE_FILE_CMNT_TXT" ADD CONSTRAINT "PK_CASE_FILE_CMNT_TXT" PRIMARY KEY ("ICA_CASE_FILE_CMNT_TXT_ID") ENABLE;
 
  ALTER TABLE "ICA_CASE_FILE_CMNT_TXT" MODIFY ("ICA_CASE_FILE_CMNT_TXT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CASE_FILE_CMNT_TXT" MODIFY ("ICA_DA_CASE_FILE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CASE_FILE_CMNT_TXT" MODIFY ("CASE_FILE_CMNT_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_CASE_FILE_LNK
--------------------------------------------------------

  ALTER TABLE "ICA_CASE_FILE_LNK" ADD CONSTRAINT "PK_CASE_FILE_LNK" PRIMARY KEY ("ICA_CASE_FILE_LNK_ID") ENABLE;
 
  ALTER TABLE "ICA_CASE_FILE_LNK" MODIFY ("ICA_CASE_FILE_LNK_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CASE_FILE_LNK" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CASE_FILE_LNK" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_CASE_FILE_LNK" MODIFY ("CASE_FILE_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_SENS_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_SENS_CMNT_TXT" ADD CONSTRAINT "PK_SENS_CMNT_TXT" PRIMARY KEY ("ICA_SENS_CMNT_TXT_ID") ENABLE;
 
  ALTER TABLE "ICA_SENS_CMNT_TXT" MODIFY ("ICA_SENS_CMNT_TXT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_SENS_CMNT_TXT" MODIFY ("SENS_CMNT_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_POLUT
--------------------------------------------------------

  ALTER TABLE "ICA_POLUT" ADD CONSTRAINT "PK_POLUT" PRIMARY KEY ("ICA_POLUT_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT" MODIFY ("ICA_POLUT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUT" MODIFY ("POLUT_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_PORT_SRC
--------------------------------------------------------

  ALTER TABLE "ICA_PORT_SRC" ADD CONSTRAINT "PK_PORT_SRC" PRIMARY KEY ("ICA_PORT_SRC_ID") ENABLE;
 
  ALTER TABLE "ICA_PORT_SRC" MODIFY ("ICA_PORT_SRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PORT_SRC" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PORT_SRC" MODIFY ("PORT_SRC_IND" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PORT_SRC" MODIFY ("PORT_SRC_SITE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PORT_SRC" MODIFY ("PORT_SRC_START_DATE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_ENFRC_ACTN_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_ACTN_CMNT_TXT" ADD CONSTRAINT "PK_ENFRC_ACTN_CMNT_TXT" PRIMARY KEY ("ICA_ENFRC_ACTN_CMNT_TXT_ID") ENABLE;
 
  ALTER TABLE "ICA_ENFRC_ACTN_CMNT_TXT" MODIFY ("ICA_ENFRC_ACTN_CMNT_TXT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_ENFRC_ACTN_CMNT_TXT" MODIFY ("ICA_DA_FRML_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_ENFRC_ACTN_CMNT_TXT" MODIFY ("ENFRC_ACTN_CMNT_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_GEO_COORD
--------------------------------------------------------

  ALTER TABLE "ICA_GEO_COORD" ADD CONSTRAINT "PK_GEO_COORD" PRIMARY KEY ("ICA_GEO_COORD_ID") ENABLE;
 
  ALTER TABLE "ICA_GEO_COORD" MODIFY ("ICA_GEO_COORD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_GEO_COORD" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_POLUTS
--------------------------------------------------------

  ALTER TABLE "ICA_POLUTS" ADD CONSTRAINT "PK_POLUTS" PRIMARY KEY ("ICA_POLUTS_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUTS" MODIFY ("ICA_POLUTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUTS" MODIFY ("ICA_PAYLOAD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUTS" MODIFY ("TRANSACTION_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_POLUTS" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_STCK_TST_OBS_AGNCY_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE" ADD CONSTRAINT "PK_STCK_TST_OBS_AGNCY_TYPE" PRIMARY KEY ("ICA_STCK_TST_OBS_AGNCY_TYPE_ID") ENABLE;
 
  ALTER TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE" MODIFY ("ICA_STCK_TST_OBS_AGNCY_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE" MODIFY ("ICA_STCK_TST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE" MODIFY ("STCK_TST_OBS_AGNCY_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_FAC_IDENT
--------------------------------------------------------

  ALTER TABLE "ICA_FAC_IDENT" ADD CONSTRAINT "PK_FAC_IDENT" PRIMARY KEY ("ICA_FAC_IDENT_ID") ENABLE;
 
  ALTER TABLE "ICA_FAC_IDENT" MODIFY ("ICA_FAC_IDENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_FAC_IDENT" MODIFY ("FAC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_STCK_TST
--------------------------------------------------------

  ALTER TABLE "ICA_STCK_TST" ADD CONSTRAINT "PK_STCK_TST" PRIMARY KEY ("ICA_STCK_TST_ID") ENABLE;
 
  ALTER TABLE "ICA_STCK_TST" MODIFY ("ICA_STCK_TST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST" MODIFY ("ICA_DA_CMPL_MON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST" MODIFY ("STCK_TST_STAT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_STCK_TST" MODIFY ("STCK_TST_CNDCTR_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_NAT_PRIO
--------------------------------------------------------

  ALTER TABLE "ICA_NAT_PRIO" ADD CONSTRAINT "PK_NAT_PRIO" PRIMARY KEY ("ICA_NAT_PRIO_ID") ENABLE;
 
  ALTER TABLE "ICA_NAT_PRIO" MODIFY ("ICA_NAT_PRIO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_NAT_PRIO" MODIFY ("NAT_PRIO_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_TST_RSLTS
--------------------------------------------------------

  ALTER TABLE "ICA_TST_RSLTS" ADD CONSTRAINT "PK_TST_RSLTS" PRIMARY KEY ("ICA_TST_RSLTS_ID") ENABLE;
 
  ALTER TABLE "ICA_TST_RSLTS" MODIFY ("ICA_TST_RSLTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TST_RSLTS" MODIFY ("ICA_STCK_TST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_TST_RSLTS" MODIFY ("TESTED_POLUT_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_VIOL
--------------------------------------------------------

  ALTER TABLE "ICA_VIOL" ADD CONSTRAINT "PK_VIOL" PRIMARY KEY ("ICA_VIOL_ID") ENABLE;
 
  ALTER TABLE "ICA_VIOL" MODIFY ("ICA_VIOL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_VIOL" MODIFY ("ICA_DA_CASE_FILE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_VIOL" MODIFY ("VIOL_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_VIOL" MODIFY ("VIOL_PROG_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_NAICS_CODE
--------------------------------------------------------

  ALTER TABLE "ICA_NAICS_CODE" ADD CONSTRAINT "PK_NAICS_CODE" PRIMARY KEY ("ICA_NAICS_CODE_ID") ENABLE;
 
  ALTER TABLE "ICA_NAICS_CODE" MODIFY ("ICA_NAICS_CODE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_NAICS_CODE" MODIFY ("ICA_FAC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_NAICS_CODE" MODIFY ("NAICS_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_NAICS_CODE" MODIFY ("NAICS_PRI_IND_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_INFRML_EA_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_INFRML_EA_CMNT_TXT" ADD CONSTRAINT "PK_INFRML_EA_CMNT_TXT" PRIMARY KEY ("ICA_INFRML_EA_CMNT_TXT_ID") ENABLE;
 
  ALTER TABLE "ICA_INFRML_EA_CMNT_TXT" MODIFY ("ICA_INFRML_EA_CMNT_TXT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_INFRML_EA_CMNT_TXT" MODIFY ("ICA_DA_INFRML_ENFRC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_INFRML_EA_CMNT_TXT" MODIFY ("INFRML_EA_CMNT_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_PROG
--------------------------------------------------------

  ALTER TABLE "ICA_PROG" ADD CONSTRAINT "PK_PROG" PRIMARY KEY ("ICA_PROG_ID") ENABLE;
 
  ALTER TABLE "ICA_PROG" MODIFY ("ICA_PROG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_PROG" MODIFY ("PROG_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ICA_ENFRC_ACTN_GOV_CNTCT
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_ACTN_GOV_CNTCT" ADD CONSTRAINT "PK_ENFRC_ACTN_GOV_CNTCT" PRIMARY KEY ("ICA_ENFRC_ACTN_GOV_CNTCT_ID") ENABLE;
 
  ALTER TABLE "ICA_ENFRC_ACTN_GOV_CNTCT" MODIFY ("ICA_ENFRC_ACTN_GOV_CNTCT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICA_ENFRC_ACTN_GOV_CNTCT" MODIFY ("AFFIL_TYPE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_CASE_FILE_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_CASE_FILE_CMNT_TXT" ADD CONSTRAINT "FK_CASE_FIL_CMN_TXT_DA_CAS_FIL" FOREIGN KEY ("ICA_DA_CASE_FILE_ID")
	  REFERENCES "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_CASE_FILE_LNK
--------------------------------------------------------

  ALTER TABLE "ICA_CASE_FILE_LNK" ADD CONSTRAINT "FK_CASE_FILE_LNK_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_CMPL_INSP_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_CMPL_INSP_TYPE" ADD CONSTRAINT "FK_CMPL_INSP_TYPE_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_CMPL_MON_LNK
--------------------------------------------------------

  ALTER TABLE "ICA_CMPL_MON_LNK" ADD CONSTRAINT "FK_CMPL_MON_LNK_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_CMPL_MON_STRGY
--------------------------------------------------------

  ALTER TABLE "ICA_CMPL_MON_STRGY" ADD CONSTRAINT "FK_CMPL_MON_STRGY_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_CNTCT
--------------------------------------------------------

  ALTER TABLE "ICA_CNTCT" ADD CONSTRAINT "FK_CNTCT_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_CNTCT" ADD CONSTRAINT "FK_CNTCT_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ENABLE;
 
  ALTER TABLE "ICA_CNTCT" ADD CONSTRAINT "FK_CNTCT_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_CASE_FILE
--------------------------------------------------------

  ALTER TABLE "ICA_DA_CASE_FILE" ADD CONSTRAINT "FK_DA_CASE_FILE_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_CMPL_MON
--------------------------------------------------------

  ALTER TABLE "ICA_DA_CMPL_MON" ADD CONSTRAINT "FK_DA_CMPL_MON_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_ENFRC_ACTN_LNK
--------------------------------------------------------

  ALTER TABLE "ICA_DA_ENFRC_ACTN_LNK" ADD CONSTRAINT "FK_DA_ENFRC_ACTN_LNK_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_ENFRC_ACTN_MILSTN
--------------------------------------------------------

  ALTER TABLE "ICA_DA_ENFRC_ACTN_MILSTN" ADD CONSTRAINT "FK_DA_ENFRC_ACTN_MILSTN_PAYLOD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_FINAL_ORDER
--------------------------------------------------------

  ALTER TABLE "ICA_DA_FINAL_ORDER" ADD CONSTRAINT "FK_DA_FINL_ORDR_DA_FRM_ENF_ACT" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_FRML_ENFRC_ACTN
--------------------------------------------------------

  ALTER TABLE "ICA_DA_FRML_ENFRC_ACTN" ADD CONSTRAINT "FK_DA_FRML_ENFRC_ACTN_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_DA_INFRML_ENFRC_ACTN
--------------------------------------------------------

  ALTER TABLE "ICA_DA_INFRML_ENFRC_ACTN" ADD CONSTRAINT "FK_DA_INFRML_ENFRC_ACTN_PAYLOD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_ENFRC_ACTN_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_ACTN_CMNT_TXT" ADD CONSTRAINT "FK_ENF_ACT_CMN_TXT_DA_FR_EN_AC" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_ENFRC_ACTN_GOV_CNTCT
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_ACTN_GOV_CNTCT" ADD CONSTRAINT "FK_ENF_ACT_GOV_CNT_DA_FR_EN_AC" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_ENFRC_ACTN_GOV_CNTCT" ADD CONSTRAINT "FK_ENF_ACT_GOV_CNT_DA_IN_EN_AC" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_ENFRC_ACTN_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_ACTN_TYPE" ADD CONSTRAINT "FK_ENFR_ACT_TYP_DA_FRM_ENF_ACT" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_ENFRC_AGNCY_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_ENFRC_AGNCY_TYPE" ADD CONSTRAINT "FK_ENFR_AGN_TYP_DA_FRM_ENF_ACT" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_ENFRC_AGNCY_TYPE" ADD CONSTRAINT "FK_ENFR_AGN_TYP_DA_INF_ENF_ACT" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_FAC
--------------------------------------------------------

  ALTER TABLE "ICA_FAC" ADD CONSTRAINT "FK_FAC_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_FAC_ADDR
--------------------------------------------------------

  ALTER TABLE "ICA_FAC_ADDR" ADD CONSTRAINT "FK_FAC_ADDR_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_FAC_IDENT
--------------------------------------------------------

  ALTER TABLE "ICA_FAC_IDENT" ADD CONSTRAINT "FK_FAC_IDENT_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_FAC_IDENT" ADD CONSTRAINT "FK_FAC_IDNT_DA_FRML_ENFRC_ACTN" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_FAC_IDENT" ADD CONSTRAINT "FK_FAC_IDNT_DA_INFRM_ENFR_ACTN" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_FINAL_ORDER_FAC_IDENT
--------------------------------------------------------

  ALTER TABLE "ICA_FINAL_ORDER_FAC_IDENT" ADD CONSTRAINT "FK_FINL_ORD_FAC_IDN_DA_FIN_ORD" FOREIGN KEY ("ICA_DA_FINAL_ORDER_ID")
	  REFERENCES "ICA_DA_FINAL_ORDER" ("ICA_DA_FINAL_ORDER_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_GEO_COORD
--------------------------------------------------------

  ALTER TABLE "ICA_GEO_COORD" ADD CONSTRAINT "FK_GEO_COORD_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_INFRML_EA_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_INFRML_EA_CMNT_TXT" ADD CONSTRAINT "FK_INF_EA_CMN_TXT_DA_INF_EN_AC" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_INSP_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_INSP_CMNT_TXT" ADD CONSTRAINT "FK_INSP_CMNT_TXT_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_INSP_CMNT_TXT" ADD CONSTRAINT "FK_INSP_CMNT_TXT_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_INSP_GOV_CNTCT
--------------------------------------------------------

  ALTER TABLE "ICA_INSP_GOV_CNTCT" ADD CONSTRAINT "FK_INSP_GOV_CNTCT_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_INSP_GOV_CNTCT" ADD CONSTRAINT "FK_INSP_GOV_CNTCT_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_LNK_CASE_FILE
--------------------------------------------------------

  ALTER TABLE "ICA_LNK_CASE_FILE" ADD CONSTRAINT "FK_LNK_CASE_FILE_CASE_FILE_LNK" FOREIGN KEY ("ICA_CASE_FILE_LNK_ID")
	  REFERENCES "ICA_CASE_FILE_LNK" ("ICA_CASE_FILE_LNK_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_LNK_CMPL_MON
--------------------------------------------------------

  ALTER TABLE "ICA_LNK_CMPL_MON" ADD CONSTRAINT "FK_LNK_CMPL_MON_CASE_FILE_LNK" FOREIGN KEY ("ICA_CASE_FILE_LNK_ID")
	  REFERENCES "ICA_CASE_FILE_LNK" ("ICA_CASE_FILE_LNK_ID") ENABLE;
 
  ALTER TABLE "ICA_LNK_CMPL_MON" ADD CONSTRAINT "FK_LNK_CMPL_MON_CMPL_MON_LNK" FOREIGN KEY ("ICA_CMPL_MON_LNK_ID")
	  REFERENCES "ICA_CMPL_MON_LNK" ("ICA_CMPL_MON_LNK_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_LNK_DA_ENFRC_ACTN
--------------------------------------------------------

  ALTER TABLE "ICA_LNK_DA_ENFRC_ACTN" ADD CONSTRAINT "FK_LNK_DA_ENFR_ACT_CAS_FIL_LNK" FOREIGN KEY ("ICA_CASE_FILE_LNK_ID")
	  REFERENCES "ICA_CASE_FILE_LNK" ("ICA_CASE_FILE_LNK_ID") ENABLE;
 
  ALTER TABLE "ICA_LNK_DA_ENFRC_ACTN" ADD CONSTRAINT "FK_LNK_DA_ENFR_ACT_CMP_MON_LNK" FOREIGN KEY ("ICA_CMPL_MON_LNK_ID")
	  REFERENCES "ICA_CMPL_MON_LNK" ("ICA_CMPL_MON_LNK_ID") ENABLE;
 
  ALTER TABLE "ICA_LNK_DA_ENFRC_ACTN" ADD CONSTRAINT "FK_LNK_DA_ENF_ACT_DA_ENF_AC_LN" FOREIGN KEY ("ICA_DA_ENFRC_ACTN_LNK_ID")
	  REFERENCES "ICA_DA_ENFRC_ACTN_LNK" ("ICA_DA_ENFRC_ACTN_LNK_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_METHOD
--------------------------------------------------------

  ALTER TABLE "ICA_METHOD" ADD CONSTRAINT "FK_METHOD_TST_RSLTS" FOREIGN KEY ("ICA_TST_RSLTS_ID")
	  REFERENCES "ICA_TST_RSLTS" ("ICA_TST_RSLTS_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_NAICS_CODE
--------------------------------------------------------

  ALTER TABLE "ICA_NAICS_CODE" ADD CONSTRAINT "FK_NAICS_CODE_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_NAT_PRIO
--------------------------------------------------------

  ALTER TABLE "ICA_NAT_PRIO" ADD CONSTRAINT "FK_NAT_PRIO_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_NAT_PRIO" ADD CONSTRAINT "FK_NAT_PRIO_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_OTHR_PATHWAY_ACTY
--------------------------------------------------------

  ALTER TABLE "ICA_OTHR_PATHWAY_ACTY" ADD CONSTRAINT "FK_OTHR_PTHW_ACTY_DA_CASE_FILE" FOREIGN KEY ("ICA_DA_CASE_FILE_ID")
	  REFERENCES "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_POLUT
--------------------------------------------------------

  ALTER TABLE "ICA_POLUT" ADD CONSTRAINT "FK_POLUT_DA_CASE_FILE" FOREIGN KEY ("ICA_DA_CASE_FILE_ID")
	  REFERENCES "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT" ADD CONSTRAINT "FK_POLUT_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT" ADD CONSTRAINT "FK_POLUT_DA_FRML_ENFRC_ACTN" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT" ADD CONSTRAINT "FK_POLUT_DA_INFRML_ENFRC_ACTN" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_POLUT" ADD CONSTRAINT "FK_POLUT_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_POLUTS
--------------------------------------------------------

  ALTER TABLE "ICA_POLUTS" ADD CONSTRAINT "FK_POLUTS_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_POLUT_DA_CLASS
--------------------------------------------------------

  ALTER TABLE "ICA_POLUT_DA_CLASS" ADD CONSTRAINT "FK_POLUT_DA_CLASS_POLUTS" FOREIGN KEY ("ICA_POLUTS_ID")
	  REFERENCES "ICA_POLUTS" ("ICA_POLUTS_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_POLUT_EPA_CLASS
--------------------------------------------------------

  ALTER TABLE "ICA_POLUT_EPA_CLASS" ADD CONSTRAINT "FK_POLUT_EPA_CLASS_POLUTS" FOREIGN KEY ("ICA_POLUTS_ID")
	  REFERENCES "ICA_POLUTS" ("ICA_POLUTS_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_PORT_SRC
--------------------------------------------------------

  ALTER TABLE "ICA_PORT_SRC" ADD CONSTRAINT "FK_PORT_SRC_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_PROG
--------------------------------------------------------

  ALTER TABLE "ICA_PROG" ADD CONSTRAINT "FK_PROG_DA_CASE_FILE" FOREIGN KEY ("ICA_DA_CASE_FILE_ID")
	  REFERENCES "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") ENABLE;
 
  ALTER TABLE "ICA_PROG" ADD CONSTRAINT "FK_PROG_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_PROG" ADD CONSTRAINT "FK_PROG_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_PROGS
--------------------------------------------------------

  ALTER TABLE "ICA_PROGS" ADD CONSTRAINT "FK_PROGS_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_PROGS_VIOL
--------------------------------------------------------

  ALTER TABLE "ICA_PROGS_VIOL" ADD CONSTRAINT "FK_PRGS_VIOL_DA_FRML_ENFR_ACTN" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_PROGS_VIOL" ADD CONSTRAINT "FK_PRGS_VIOL_DA_INFR_ENFR_ACTN" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_PROG_SUBPART
--------------------------------------------------------

  ALTER TABLE "ICA_PROG_SUBPART" ADD CONSTRAINT "FK_PROG_SUBPART_PROGS" FOREIGN KEY ("ICA_PROGS_ID")
	  REFERENCES "ICA_PROGS" ("ICA_PROGS_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_RGNL_PRIO
--------------------------------------------------------

  ALTER TABLE "ICA_RGNL_PRIO" ADD CONSTRAINT "FK_RGNL_PRIO_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_RGNL_PRIO" ADD CONSTRAINT "FK_RGNL_PRIO_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_SENS_CMNT_TXT
--------------------------------------------------------

  ALTER TABLE "ICA_SENS_CMNT_TXT" ADD CONSTRAINT "FK_SENS_CMNT_TXT_DA_CASE_FILE" FOREIGN KEY ("ICA_DA_CASE_FILE_ID")
	  REFERENCES "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") ENABLE;
 
  ALTER TABLE "ICA_SENS_CMNT_TXT" ADD CONSTRAINT "FK_SENS_CMNT_TXT_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ENABLE;
 
  ALTER TABLE "ICA_SENS_CMNT_TXT" ADD CONSTRAINT "FK_SENS_CMNT_TXT_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ENABLE;
 
  ALTER TABLE "ICA_SENS_CMNT_TXT" ADD CONSTRAINT "FK_SENS_CMN_TXT_DA_FRM_ENF_ACT" FOREIGN KEY ("ICA_DA_FRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_FRML_ENFRC_ACTN" ("ICA_DA_FRML_ENFRC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ICA_SENS_CMNT_TXT" ADD CONSTRAINT "FK_SENS_CMN_TXT_DA_INF_ENF_ACT" FOREIGN KEY ("ICA_DA_INFRML_ENFRC_ACTN_ID")
	  REFERENCES "ICA_DA_INFRML_ENFRC_ACTN" ("ICA_DA_INFRML_ENFRC_ACTN_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_SIC_CODE
--------------------------------------------------------

  ALTER TABLE "ICA_SIC_CODE" ADD CONSTRAINT "FK_SIC_CODE_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_STCK_TST
--------------------------------------------------------

  ALTER TABLE "ICA_STCK_TST" ADD CONSTRAINT "FK_STCK_TST_DA_CMPL_MON" FOREIGN KEY ("ICA_DA_CMPL_MON_ID")
	  REFERENCES "ICA_DA_CMPL_MON" ("ICA_DA_CMPL_MON_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_STCK_TST_OBS_AGNCY_TYPE
--------------------------------------------------------

  ALTER TABLE "ICA_STCK_TST_OBS_AGNCY_TYPE" ADD CONSTRAINT "FK_STC_TST_OBS_AGN_TYP_STC_TST" FOREIGN KEY ("ICA_STCK_TST_ID")
	  REFERENCES "ICA_STCK_TST" ("ICA_STCK_TST_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_STCK_TST_PURPOSE
--------------------------------------------------------

  ALTER TABLE "ICA_STCK_TST_PURPOSE" ADD CONSTRAINT "FK_STCK_TST_PURPOSE_STCK_TST" FOREIGN KEY ("ICA_STCK_TST_ID")
	  REFERENCES "ICA_STCK_TST" ("ICA_STCK_TST_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_TELEPH
--------------------------------------------------------

  ALTER TABLE "ICA_TELEPH" ADD CONSTRAINT "FK_TELEPH_CNTCT" FOREIGN KEY ("ICA_CNTCT_ID")
	  REFERENCES "ICA_CNTCT" ("ICA_CNTCT_ID") ENABLE;
 
  ALTER TABLE "ICA_TELEPH" ADD CONSTRAINT "FK_TELEPH_FAC_ADDR" FOREIGN KEY ("ICA_FAC_ADDR_ID")
	  REFERENCES "ICA_FAC_ADDR" ("ICA_FAC_ADDR_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_TST_RSLTS
--------------------------------------------------------

  ALTER TABLE "ICA_TST_RSLTS" ADD CONSTRAINT "FK_TST_RSLTS_STCK_TST" FOREIGN KEY ("ICA_STCK_TST_ID")
	  REFERENCES "ICA_STCK_TST" ("ICA_STCK_TST_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_TVACC
--------------------------------------------------------

  ALTER TABLE "ICA_TVACC" ADD CONSTRAINT "FK_TVACC_PAYLOAD" FOREIGN KEY ("ICA_PAYLOAD_ID")
	  REFERENCES "ICA_PAYLOAD" ("ICA_PAYLOAD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_TVACC_REVIEW
--------------------------------------------------------

  ALTER TABLE "ICA_TVACC_REVIEW" ADD CONSTRAINT "FK_TVACC_REVIEW_TVACC" FOREIGN KEY ("ICA_TVACC_ID")
	  REFERENCES "ICA_TVACC" ("ICA_TVACC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_UNIVERSE_IND
--------------------------------------------------------

  ALTER TABLE "ICA_UNIVERSE_IND" ADD CONSTRAINT "FK_UNIVERSE_IND_FAC" FOREIGN KEY ("ICA_FAC_ID")
	  REFERENCES "ICA_FAC" ("ICA_FAC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ICA_VIOL
--------------------------------------------------------

  ALTER TABLE "ICA_VIOL" ADD CONSTRAINT "FK_VIOL_DA_CASE_FILE" FOREIGN KEY ("ICA_DA_CASE_FILE_ID")
	  REFERENCES "ICA_DA_CASE_FILE" ("ICA_DA_CASE_FILE_ID") ON DELETE CASCADE ENABLE;
/
