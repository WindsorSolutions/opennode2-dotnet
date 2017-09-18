/*  --  SCHEMA DROP STATEMENTS  -- 

ALTER TABLE "OWIR_WQS_ATTAIN_DTLS"
 DROP CONSTRAINT "FK_WQS_ATTN_DTLS_ASMT_UNT_DTLS";

ALTER TABLE "OWIR_USER_CATG_DTLS"
 DROP CONSTRAINT "FK_USR_CTG_DTLS_STTE_ASMT_DTLS";

ALTER TABLE "OWIR_TMD_LS_DTLS"
 DROP CONSTRAINT "FK_TMD_LS_DTLS_ASM_UNT_CSE_DTL";

ALTER TABLE "OWIR_STATE_METH_DTLS"
 DROP CONSTRAINT "FK_STTE_MTH_DTLS_STTE_ASMT_DTL";

ALTER TABLE "OWIR_STATE_LOC_DTLS"
 DROP CONSTRAINT "FK_STTE_LC_DTLS_STTE_ASMT_DTLS";

ALTER TABLE "OWIR_SRC_DTLS"
 DROP CONSTRAINT "FK_SRC_DTLS_CAUSE_DTLS";

ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS"
 DROP CONSTRAINT "FK_OBSR_EFFC_DTLS_WQS_ATTN_DTL";

ALTER TABLE "OWIR_NPDES_DTLS"
 DROP CONSTRAINT "FK_NPDS_DTLS_ASMT_UNT_CSE_DTLS";

ALTER TABLE "OWIR_IMPL_ACT_DTLS"
 DROP CONSTRAINT "FK_IMP_ACT_DTL_ASM_UNT_CSE_DTL";

ALTER TABLE "OWIR_CYCLE_TRACK_DTLS"
 DROP CONSTRAINT "FK_CYCL_TRCK_DTLS_ASMT_UNT_DTL";

ALTER TABLE "OWIR_CAUSE_DTLS"
 DROP CONSTRAINT "FK_CAUSE_DTLS_WQS_ATTAIN_DTLS";

ALTER TABLE "OWIR_ATLAS_DTLS"
 DROP CONSTRAINT "FK_ATLAS_DTLS_STATE_ASMT_DTLS";

ALTER TABLE "OWIR_ASMT_WATER_DTLS"
 DROP CONSTRAINT "FK_ASMT_WTR_DTLS_ASMT_UNT_DTLS";

ALTER TABLE "OWIR_ASMT_UNIT_DTLS"
 DROP CONSTRAINT "FK_ASMT_UNT_DTLS_STTE_ASMT_DTL";

ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS"
 DROP CONSTRAINT "FK_ASM_UNT_DLS_DTL_ASM_UNT_DTL";

ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS"
 DROP CONSTRAINT "FK_ASM_UNT_CSE_DTL_ASM_UNT_DTL";

ALTER TABLE "OWIR_ASMT_TYPE_DTLS"
 DROP CONSTRAINT "FK_ASMT_TYPE_DTLS_WQS_ATTN_DTL";

ALTER TABLE "OWIR_ASMT_METH_DTLS"
 DROP CONSTRAINT "FK_ASMT_MTH_DTLS_WQS_ATTN_DTLS";

ALTER TABLE "OWIR_WQS_ATTAIN_DTLS"
 DROP CONSTRAINT "PK_WQS_ATTAIN_DTLS";

ALTER TABLE "OWIR_USER_CATG_DTLS"
 DROP CONSTRAINT "PK_USER_CATG_DTLS";

ALTER TABLE "OWIR_TMD_LS_DTLS"
 DROP CONSTRAINT "PK_TMD_LS_DTLS";

ALTER TABLE "OWIR_STATE_METH_DTLS"
 DROP CONSTRAINT "PK_STATE_METH_DTLS";

ALTER TABLE "OWIR_STATE_LOC_DTLS"
 DROP CONSTRAINT "PK_STATE_LOC_DTLS";

ALTER TABLE "OWIR_STATE_ASMT_DTLS"
 DROP CONSTRAINT "PK_STATE_ASMT_DTLS";

ALTER TABLE "OWIR_SRC_DTLS"
 DROP CONSTRAINT "PK_SRC_DTLS";

ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS"
 DROP CONSTRAINT "PK_OBSERVED_EFFECT_DTLS";

ALTER TABLE "OWIR_NPDES_DTLS"
 DROP CONSTRAINT "PK_NPDES_DTLS";

ALTER TABLE "OWIR_IMPL_ACT_DTLS"
 DROP CONSTRAINT "PK_IMPL_ACT_DTLS";

ALTER TABLE "OWIR_CYCLE_TRACK_DTLS"
 DROP CONSTRAINT "PK_CYCLE_TRACK_DTLS";

ALTER TABLE "OWIR_CAUSE_DTLS"
 DROP CONSTRAINT "PK_CAUSE_DTLS";

ALTER TABLE "OWIR_ATLAS_DTLS"
 DROP CONSTRAINT "PK_ATLAS_DTLS";

ALTER TABLE "OWIR_ASMT_WATER_DTLS"
 DROP CONSTRAINT "PK_ASMT_WATER_DTLS";

ALTER TABLE "OWIR_ASMT_UNIT_DTLS"
 DROP CONSTRAINT "PK_ASMT_UNIT_DTLS";

ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS"
 DROP CONSTRAINT "PK_ASMT_UNIT_DELIST_DTLS";

ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS"
 DROP CONSTRAINT "PK_ASMT_UNIT_CAUSE_DTLS";

ALTER TABLE "OWIR_ASMT_TYPE_DTLS"
 DROP CONSTRAINT "PK_ASMT_TYPE_DTLS";

ALTER TABLE "OWIR_ASMT_METH_DTLS"
 DROP CONSTRAINT "PK_ASMT_METH_DTLS";

DROP INDEX "IX_WQS_ATTN_DTL_ASM_UNT_DTL_ID";

DROP INDEX "IX_USR_CTG_DTLS_STT_ASM_DTL_ID";

DROP INDEX "IX_TMD_LS_DTL_ASM_UNT_CS_DT_ID";

DROP INDEX "IX_STTE_MTH_DTL_STT_ASM_DTL_ID";

DROP INDEX "IX_STTE_LC_DTLS_STT_ASM_DTL_ID";

DROP INDEX "IX_SRC_DTLS_CAUSE_DTLS_ID";

DROP INDEX "IX_OBSR_EFF_DTL_WQS_ATT_DTL_ID";

DROP INDEX "IX_NPDS_DTL_ASM_UNT_CSE_DTL_ID";

DROP INDEX "IX_IMP_ACT_DTL_ASM_UN_CS_DT_ID";

DROP INDEX "IX_CYCL_TRC_DTL_ASM_UNT_DTL_ID";

DROP INDEX "IX_CUSE_DTLS_WQS_ATTIN_DTLS_ID";

DROP INDEX "IX_ATLS_DTLS_STTE_ASMT_DTLS_ID";

DROP INDEX "IX_ASMT_WTR_DTL_ASM_UNT_DTL_ID";

DROP INDEX "IX_ASMT_UNT_DTL_STT_ASM_DTL_ID";

DROP INDEX "IX_ASM_UNT_DLS_DTL_AS_UN_DT_ID";

DROP INDEX "IX_ASM_UNT_CSE_DTL_AS_UN_DT_ID";

DROP INDEX "IX_ASMT_TYP_DTL_WQS_ATT_DTL_ID";

DROP INDEX "IX_ASMT_MTH_DTL_WQS_ATT_DTL_ID";

DROP TABLE "OWIR_WQS_ATTAIN_DTLS";

DROP TABLE "OWIR_USER_CATG_DTLS";

DROP TABLE "OWIR_TMD_LS_DTLS";

DROP TABLE "OWIR_STATE_METH_DTLS";

DROP TABLE "OWIR_STATE_LOC_DTLS";

DROP TABLE "OWIR_STATE_ASMT_DTLS";

DROP TABLE "OWIR_SRC_DTLS";

DROP TABLE "OWIR_OBSERVED_EFFECT_DTLS";

DROP TABLE "OWIR_NPDES_DTLS";

DROP TABLE "OWIR_IMPL_ACT_DTLS";

DROP TABLE "OWIR_CYCLE_TRACK_DTLS";

DROP TABLE "OWIR_CAUSE_DTLS";

DROP TABLE "OWIR_ATLAS_DTLS";

DROP TABLE "OWIR_ASMT_WATER_DTLS";

DROP TABLE "OWIR_ASMT_UNIT_DTLS";

DROP TABLE "OWIR_ASMT_UNIT_DELIST_DTLS";

DROP TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS";

DROP TABLE "OWIR_ASMT_TYPE_DTLS";

DROP TABLE "OWIR_ASMT_METH_DTLS";

PURGE RECYCLEBIN;

*/

--------------------------------------------------------
--  File created - Thursday-September-15-2011   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table OWIR_ASMT_METH_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ASMT_METH_DTLS" 
   (	"ASMT_METH_DTLS_ID" VARCHAR2(40), 
	"WQS_ATTAIN_DTLS_ID" VARCHAR2(40), 
	"ASMT_METH_IDEN_CODE" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "OWIR_ASMT_METH_DTLS"."ASMT_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (AssessmentMethodIdentifierCode)';
 
   COMMENT ON TABLE "OWIR_ASMT_METH_DTLS"  IS 'Schema element: AssessmentMethodDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_ASMT_TYPE_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ASMT_TYPE_DTLS" 
   (	"ASMT_TYPE_DTLS_ID" VARCHAR2(40), 
	"WQS_ATTAIN_DTLS_ID" VARCHAR2(40), 
	"ASMT_TYPE_TYPE" VARCHAR2(30), 
	"ASMT_CONFIDENCE" VARCHAR2(9)
   ) ;
 

   COMMENT ON TABLE "OWIR_ASMT_TYPE_DTLS"  IS 'Schema element: AssessmentTypeDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_ASMT_UNIT_CAUSE_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS" 
   (	"ASMT_UNIT_CAUSE_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_DTLS_ID" VARCHAR2(40), 
	"CAUSE_NAME" VARCHAR2(240), 
	"CYCLE_FIRST_LISTED" NUMBER(10,0), 
	"EXPECTED_TO_ATTAIN_DATE" TIMESTAMP (6), 
	"TMDL_SCHEDULE" NUMBER(10,0), 
	"TMDL_PRI" VARCHAR2(6), 
	"TMDL_COMP_DATE" TIMESTAMP (6), 
	"TMDL_PRJT_STAT" VARCHAR2(255), 
	"TMDL_PRJT_COMMENT" VARCHAR2(4000), 
	"CNST_DECREE_CYCLE" NUMBER(10,0), 
	"POLLUTION_SRC_TYPE" VARCHAR2(16), 
	"JUSTIFICATION_URL" VARCHAR2(250), 
	"OTHER_PT_SRC_ID" VARCHAR2(4000)
   ) ;
 

   COMMENT ON TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS"  IS 'Schema element: AssessmentUnitCauseDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_ASMT_UNIT_DELIST_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" 
   (	"ASMT_UNIT_DELIST_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_DTLS_ID" VARCHAR2(40), 
	"CAUSE_NAME" VARCHAR2(240), 
	"DELISTING_DATE" TIMESTAMP (6), 
	"DELISTING_REASON" VARCHAR2(120), 
	"DELISTING_COMMENT" VARCHAR2(4000)
   ) ;
 

   COMMENT ON TABLE "OWIR_ASMT_UNIT_DELIST_DTLS"  IS 'Schema element: AssessmentUnitDelistDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_ASMT_UNIT_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ASMT_UNIT_DTLS" 
   (	"ASMT_UNIT_DTLS_ID" VARCHAR2(40), 
	"STATE_ASMT_DTLS_ID" VARCHAR2(40), 
	"ID_305B" VARCHAR2(50), 
	"WATER_NAME" VARCHAR2(60), 
	"LOC" VARCHAR2(255), 
	"TROPHIC_STAT" VARCHAR2(14), 
	"PUBLIC_LAKE" VARCHAR2(3), 
	"MONTR_SCHD_YEAR" NUMBER(10,0), 
	"CLASS_NAME" VARCHAR2(100), 
	"CLASS_DESC" VARCHAR2(4000), 
	"ASSESSOR" VARCHAR2(40), 
	"CATG_ID" VARCHAR2(10), 
	"EPA_CATG" VARCHAR2(6), 
	"ASMT_UNIT_COMMENT" VARCHAR2(4000), 
	"ASMT_UNIT_OWNER" VARCHAR2(20), 
	"CYCLE_LAST_ASSESSED" NUMBER(10,0), 
	"TREND" VARCHAR2(11), 
	"CATG_REPORT_FLAG" VARCHAR2(15), 
	"EPA_ADDED_ASMT_UNIT" CHAR(1), 
	"ASSESSED" CHAR(1)
   ) ;
 

   COMMENT ON TABLE "OWIR_ASMT_UNIT_DTLS"  IS 'Schema element: AssessmentUnitDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_ASMT_WATER_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ASMT_WATER_DTLS" 
   (	"ASMT_WATER_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_DTLS_ID" VARCHAR2(40), 
	"WATER_TYPE" VARCHAR2(23), 
	"WATER_SIZE" NUMBER(14,6)
   ) ;
 

   COMMENT ON TABLE "OWIR_ASMT_WATER_DTLS"  IS 'Schema element: AssessmentWaterDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_ATLAS_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_ATLAS_DTLS" 
   (	"ATLAS_DTLS_ID" VARCHAR2(40), 
	"STATE_ASMT_DTLS_ID" VARCHAR2(40), 
	"TOPIC_ID" NUMBER(10,0), 
	"TOPIC_OWNER" VARCHAR2(255), 
	"TOPIC_SIZE" NUMBER(14,6), 
	"TOPIC_SCALE" NUMBER(10,0), 
	"TOPIC_SRC" VARCHAR2(40), 
	"TOPIC_COUNT" NUMBER(10,0), 
	"TOPIC_NAME" VARCHAR2(50), 
	"TOPIC_GROUP" VARCHAR2(50), 
	"TOPIC_SIZE_UNIT" VARCHAR2(15), 
	"TOPIC_MAJOR_FLAG" NUMBER(10,0)
   ) ;
 

   COMMENT ON TABLE "OWIR_ATLAS_DTLS"  IS 'Schema element: ATLASDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_CAUSE_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_CAUSE_DTLS" 
   (	"CAUSE_DTLS_ID" VARCHAR2(40), 
	"WQS_ATTAIN_DTLS_ID" VARCHAR2(40), 
	"CAUSE_NAME" VARCHAR2(240), 
	"POLT_FLAG" VARCHAR2(3), 
	"CAUSE_COMMENT" VARCHAR2(4000), 
	"USER_FLAG" VARCHAR2(15), 
	"EPA_CAUSE_CATG" VARCHAR2(6), 
	"CONFIDENCE" VARCHAR2(6), 
	"STATE_CAUSE_CATG" VARCHAR2(10), 
	"EPA_ADDED_CAUSE" CHAR(1)
   ) ;
 

   COMMENT ON TABLE "OWIR_CAUSE_DTLS"  IS 'Schema element: CauseDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_CYCLE_TRACK_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_CYCLE_TRACK_DTLS" 
   (	"CYCLE_TRACK_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_DTLS_ID" VARCHAR2(40), 
	"PRE_ID_305B" VARCHAR2(50), 
	"PRE_CYCLE" NUMBER(10,0), 
	"PURPOSE" VARCHAR2(6)
   ) ;
 

   COMMENT ON TABLE "OWIR_CYCLE_TRACK_DTLS"  IS 'Schema element: CycleTrackDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_IMPL_ACT_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_IMPL_ACT_DTLS" 
   (	"IMPL_ACT_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_CAUSE_DTLS_ID" VARCHAR2(40), 
	"ACT_DATE" TIMESTAMP (6), 
	"IMPL_ACT_TXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON TABLE "OWIR_IMPL_ACT_DTLS"  IS 'Schema element: ImplementationActionDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_NPDES_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_NPDES_DTLS" 
   (	"NPDES_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_CAUSE_DTLS_ID" VARCHAR2(40), 
	"NPDESID" VARCHAR2(9)
   ) ;
 

   COMMENT ON TABLE "OWIR_NPDES_DTLS"  IS 'Schema element: NPDESDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_OBSERVED_EFFECT_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_OBSERVED_EFFECT_DTLS" 
   (	"OBSERVED_EFFECT_DTLS_ID" VARCHAR2(40), 
	"WQS_ATTAIN_DTLS_ID" VARCHAR2(40), 
	"CAUSE_NAME" VARCHAR2(240)
   ) ;
 

   COMMENT ON TABLE "OWIR_OBSERVED_EFFECT_DTLS"  IS 'Schema element: ObservedEffectDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_SRC_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_SRC_DTLS" 
   (	"SRC_DTLS_ID" VARCHAR2(40), 
	"CAUSE_DTLS_ID" VARCHAR2(40), 
	"SRC_NAME" VARCHAR2(250), 
	"SRC_COMMENT" VARCHAR2(4000), 
	"CONFIRMED" CHAR(1)
   ) ;
 

   COMMENT ON TABLE "OWIR_SRC_DTLS"  IS 'Schema element: SourceDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_STATE_ASMT_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_STATE_ASMT_DTLS" 
   (	"STATE_ASMT_DTLS_ID" VARCHAR2(40), 
	"CYCLE" NUMBER(10,0), 
	"MERCURY_COMMENT" VARCHAR2(4000), 
	"MERCURY_URL" VARCHAR2(250), 
	"STATE_CODE" VARCHAR2(50), 
	"STATE_NAME" VARCHAR2(128), 
	"CODE_LIST_VERS_IDEN" VARCHAR2(50), 
	"CODE_LIST_VERS_AGN_IDEN" VARCHAR2(50), 
	"VAL" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "OWIR_STATE_ASMT_DTLS"."STATE_CODE" IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)';
 
   COMMENT ON COLUMN "OWIR_STATE_ASMT_DTLS"."STATE_NAME" IS 'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)';
 
   COMMENT ON COLUMN "OWIR_STATE_ASMT_DTLS"."CODE_LIST_VERS_IDEN" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)';
 
   COMMENT ON COLUMN "OWIR_STATE_ASMT_DTLS"."CODE_LIST_VERS_AGN_IDEN" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)';
 
   COMMENT ON COLUMN "OWIR_STATE_ASMT_DTLS"."VAL" IS 'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)';
 
   COMMENT ON TABLE "OWIR_STATE_ASMT_DTLS"  IS 'Schema element: StateAssessmentDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_STATE_LOC_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_STATE_LOC_DTLS" 
   (	"STATE_LOC_DTLS_ID" VARCHAR2(40), 
	"STATE_ASMT_DTLS_ID" VARCHAR2(40), 
	"LOC_ID" NUMBER(10,0), 
	"LOC_TYPE" VARCHAR2(20), 
	"LOC_NAME" VARCHAR2(100)
   ) ;
 

   COMMENT ON TABLE "OWIR_STATE_LOC_DTLS"  IS 'Schema element: StateLocationDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_STATE_METH_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_STATE_METH_DTLS" 
   (	"STATE_METH_DTLS_ID" VARCHAR2(40), 
	"STATE_ASMT_DTLS_ID" VARCHAR2(40), 
	"ASMT_METH_IDEN_CODE" NUMBER(10,0), 
	"ASMT_METH_NAME" VARCHAR2(90)
   ) ;
 

   COMMENT ON COLUMN "OWIR_STATE_METH_DTLS"."ASMT_METH_IDEN_CODE" IS 'The identification number or code assigned by the method publisher. (AssessmentMethodIdentifierCode)';
 
   COMMENT ON COLUMN "OWIR_STATE_METH_DTLS"."ASMT_METH_NAME" IS 'The title of the method that appears on the method from the organization that published it. (AssessmentMethodName)';
 
   COMMENT ON TABLE "OWIR_STATE_METH_DTLS"  IS 'Schema element: StateMethodDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_TMD_LS_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_TMD_LS_DTLS" 
   (	"TMD_LS_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_CAUSE_DTLS_ID" VARCHAR2(40), 
	"TMDLID" NUMBER(10,0)
   ) ;
 

   COMMENT ON TABLE "OWIR_TMD_LS_DTLS"  IS 'Schema element: TMDLsDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_USER_CATG_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_USER_CATG_DTLS" 
   (	"USER_CATG_DTLS_ID" VARCHAR2(40), 
	"STATE_ASMT_DTLS_ID" VARCHAR2(40), 
	"CATG_ID" VARCHAR2(10), 
	"CATG_DESC" VARCHAR2(4000)
   ) ;
 

   COMMENT ON TABLE "OWIR_USER_CATG_DTLS"  IS 'Schema element: UserCategoryDetailsDataType';
--------------------------------------------------------
--  DDL for Table OWIR_WQS_ATTAIN_DTLS
--------------------------------------------------------

  CREATE TABLE "OWIR_WQS_ATTAIN_DTLS" 
   (	"WQS_ATTAIN_DTLS_ID" VARCHAR2(40), 
	"ASMT_UNIT_DTLS_ID" VARCHAR2(40), 
	"USE_DESC" VARCHAR2(4000), 
	"ATTAIN_DESC" VARCHAR2(24), 
	"THREATENED_FLAG" VARCHAR2(3), 
	"USE_COMMENT" VARCHAR2(4000), 
	"ASMT_DATE" TIMESTAMP (6), 
	"START_DATE" TIMESTAMP (6), 
	"END_DATE" TIMESTAMP (6), 
	"KEY_DATE" TIMESTAMP (6), 
	"ASSESSOR" VARCHAR2(40), 
	"EPA_ADDED_ATTAIN" CHAR(1), 
	"STATE_USE_CATG" VARCHAR2(10), 
	"EPA_USE_CATG" VARCHAR2(6)
   ) ;
 

   COMMENT ON TABLE "OWIR_WQS_ATTAIN_DTLS"  IS 'Schema element: WQSAttainmentDetailsDataType';
--------------------------------------------------------
--  Constraints for Table OWIR_ASMT_UNIT_DELIST_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" ADD CONSTRAINT "PK_ASMT_UNIT_DELIST_DTLS" PRIMARY KEY ("ASMT_UNIT_DELIST_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" MODIFY ("ASMT_UNIT_DELIST_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" MODIFY ("ASMT_UNIT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" MODIFY ("CAUSE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" MODIFY ("DELISTING_REASON" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_STATE_LOC_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_STATE_LOC_DTLS" ADD CONSTRAINT "PK_STATE_LOC_DTLS" PRIMARY KEY ("STATE_LOC_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_STATE_LOC_DTLS" MODIFY ("STATE_LOC_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_LOC_DTLS" MODIFY ("STATE_ASMT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_LOC_DTLS" MODIFY ("LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_LOC_DTLS" MODIFY ("LOC_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_LOC_DTLS" MODIFY ("LOC_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_STATE_ASMT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_STATE_ASMT_DTLS" ADD CONSTRAINT "PK_STATE_ASMT_DTLS" PRIMARY KEY ("STATE_ASMT_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_STATE_ASMT_DTLS" MODIFY ("STATE_ASMT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_ASMT_DTLS" MODIFY ("CYCLE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_OBSERVED_EFFECT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS" ADD CONSTRAINT "PK_OBSERVED_EFFECT_DTLS" PRIMARY KEY ("OBSERVED_EFFECT_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS" MODIFY ("OBSERVED_EFFECT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS" MODIFY ("WQS_ATTAIN_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS" MODIFY ("CAUSE_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_IMPL_ACT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_IMPL_ACT_DTLS" ADD CONSTRAINT "PK_IMPL_ACT_DTLS" PRIMARY KEY ("IMPL_ACT_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_IMPL_ACT_DTLS" MODIFY ("IMPL_ACT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_IMPL_ACT_DTLS" MODIFY ("ASMT_UNIT_CAUSE_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_IMPL_ACT_DTLS" MODIFY ("ACT_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_ASMT_METH_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_METH_DTLS" ADD CONSTRAINT "PK_ASMT_METH_DTLS" PRIMARY KEY ("ASMT_METH_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ASMT_METH_DTLS" MODIFY ("ASMT_METH_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_METH_DTLS" MODIFY ("WQS_ATTAIN_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_METH_DTLS" MODIFY ("ASMT_METH_IDEN_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_CAUSE_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_CAUSE_DTLS" ADD CONSTRAINT "PK_CAUSE_DTLS" PRIMARY KEY ("CAUSE_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_CAUSE_DTLS" MODIFY ("CAUSE_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_CAUSE_DTLS" MODIFY ("WQS_ATTAIN_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_CAUSE_DTLS" MODIFY ("CAUSE_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_TMD_LS_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_TMD_LS_DTLS" ADD CONSTRAINT "PK_TMD_LS_DTLS" PRIMARY KEY ("TMD_LS_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_TMD_LS_DTLS" MODIFY ("TMD_LS_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_TMD_LS_DTLS" MODIFY ("ASMT_UNIT_CAUSE_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_TMD_LS_DTLS" MODIFY ("TMDLID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_CYCLE_TRACK_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" ADD CONSTRAINT "PK_CYCLE_TRACK_DTLS" PRIMARY KEY ("CYCLE_TRACK_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" MODIFY ("CYCLE_TRACK_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" MODIFY ("ASMT_UNIT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" MODIFY ("PRE_ID_305B" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" MODIFY ("PRE_CYCLE" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" MODIFY ("PURPOSE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_ATLAS_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ATLAS_DTLS" ADD CONSTRAINT "PK_ATLAS_DTLS" PRIMARY KEY ("ATLAS_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ATLAS_DTLS" MODIFY ("ATLAS_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ATLAS_DTLS" MODIFY ("STATE_ASMT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ATLAS_DTLS" MODIFY ("TOPIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ATLAS_DTLS" MODIFY ("TOPIC_OWNER" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_USER_CATG_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_USER_CATG_DTLS" ADD CONSTRAINT "PK_USER_CATG_DTLS" PRIMARY KEY ("USER_CATG_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_USER_CATG_DTLS" MODIFY ("USER_CATG_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_USER_CATG_DTLS" MODIFY ("STATE_ASMT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_USER_CATG_DTLS" MODIFY ("CATG_DESC" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_ASMT_WATER_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_WATER_DTLS" ADD CONSTRAINT "PK_ASMT_WATER_DTLS" PRIMARY KEY ("ASMT_WATER_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ASMT_WATER_DTLS" MODIFY ("ASMT_WATER_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_WATER_DTLS" MODIFY ("ASMT_UNIT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_WATER_DTLS" MODIFY ("WATER_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_WATER_DTLS" MODIFY ("WATER_SIZE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_WQS_ATTAIN_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_WQS_ATTAIN_DTLS" ADD CONSTRAINT "PK_WQS_ATTAIN_DTLS" PRIMARY KEY ("WQS_ATTAIN_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_WQS_ATTAIN_DTLS" MODIFY ("WQS_ATTAIN_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_WQS_ATTAIN_DTLS" MODIFY ("ASMT_UNIT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_WQS_ATTAIN_DTLS" MODIFY ("USE_DESC" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_WQS_ATTAIN_DTLS" MODIFY ("ATTAIN_DESC" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_ASMT_UNIT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" ADD CONSTRAINT "PK_ASMT_UNIT_DTLS" PRIMARY KEY ("ASMT_UNIT_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" MODIFY ("ASMT_UNIT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" MODIFY ("STATE_ASMT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" MODIFY ("ID_305B" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" MODIFY ("WATER_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" MODIFY ("LOC" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_ASMT_TYPE_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_TYPE_DTLS" ADD CONSTRAINT "PK_ASMT_TYPE_DTLS" PRIMARY KEY ("ASMT_TYPE_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ASMT_TYPE_DTLS" MODIFY ("ASMT_TYPE_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_TYPE_DTLS" MODIFY ("WQS_ATTAIN_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_TYPE_DTLS" MODIFY ("ASMT_TYPE_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_SRC_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_SRC_DTLS" ADD CONSTRAINT "PK_SRC_DTLS" PRIMARY KEY ("SRC_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_SRC_DTLS" MODIFY ("SRC_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_SRC_DTLS" MODIFY ("CAUSE_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_SRC_DTLS" MODIFY ("SRC_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_ASMT_UNIT_CAUSE_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS" ADD CONSTRAINT "PK_ASMT_UNIT_CAUSE_DTLS" PRIMARY KEY ("ASMT_UNIT_CAUSE_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS" MODIFY ("ASMT_UNIT_CAUSE_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS" MODIFY ("ASMT_UNIT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS" MODIFY ("CAUSE_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_NPDES_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_NPDES_DTLS" ADD CONSTRAINT "PK_NPDES_DTLS" PRIMARY KEY ("NPDES_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_NPDES_DTLS" MODIFY ("NPDES_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_NPDES_DTLS" MODIFY ("ASMT_UNIT_CAUSE_DTLS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table OWIR_STATE_METH_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_STATE_METH_DTLS" ADD CONSTRAINT "PK_STATE_METH_DTLS" PRIMARY KEY ("STATE_METH_DTLS_ID") ENABLE;
 
  ALTER TABLE "OWIR_STATE_METH_DTLS" MODIFY ("STATE_METH_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_METH_DTLS" MODIFY ("STATE_ASMT_DTLS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_METH_DTLS" MODIFY ("ASMT_METH_IDEN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "OWIR_STATE_METH_DTLS" MODIFY ("ASMT_METH_NAME" NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Index IX_ATLS_DTLS_STTE_ASMT_DTLS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ATLS_DTLS_STTE_ASMT_DTLS_ID" ON "OWIR_ATLAS_DTLS" ("STATE_ASMT_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_ASMT_UNT_DTL_STT_ASM_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASMT_UNT_DTL_STT_ASM_DTL_ID" ON "OWIR_ASMT_UNIT_DTLS" ("STATE_ASMT_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_USR_CTG_DTLS_STT_ASM_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_USR_CTG_DTLS_STT_ASM_DTL_ID" ON "OWIR_USER_CATG_DTLS" ("STATE_ASMT_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_OBSR_EFF_DTL_WQS_ATT_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_OBSR_EFF_DTL_WQS_ATT_DTL_ID" ON "OWIR_OBSERVED_EFFECT_DTLS" ("WQS_ATTAIN_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_NPDS_DTL_ASM_UNT_CSE_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_NPDS_DTL_ASM_UNT_CSE_DTL_ID" ON "OWIR_NPDES_DTLS" ("ASMT_UNIT_CAUSE_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CUSE_DTLS_WQS_ATTIN_DTLS_ID
--------------------------------------------------------

  CREATE INDEX "IX_CUSE_DTLS_WQS_ATTIN_DTLS_ID" ON "OWIR_CAUSE_DTLS" ("WQS_ATTAIN_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_TMD_LS_DTL_ASM_UNT_CS_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_TMD_LS_DTL_ASM_UNT_CS_DT_ID" ON "OWIR_TMD_LS_DTLS" ("ASMT_UNIT_CAUSE_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SRC_DTLS_CAUSE_DTLS_ID
--------------------------------------------------------

  CREATE INDEX "IX_SRC_DTLS_CAUSE_DTLS_ID" ON "OWIR_SRC_DTLS" ("CAUSE_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ASM_UNT_CSE_DTL_AS_UN_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASM_UNT_CSE_DTL_AS_UN_DT_ID" ON "OWIR_ASMT_UNIT_CAUSE_DTLS" ("ASMT_UNIT_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_ASMT_TYP_DTL_WQS_ATT_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASMT_TYP_DTL_WQS_ATT_DTL_ID" ON "OWIR_ASMT_TYPE_DTLS" ("WQS_ATTAIN_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_STTE_MTH_DTL_STT_ASM_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_STTE_MTH_DTL_STT_ASM_DTL_ID" ON "OWIR_STATE_METH_DTLS" ("STATE_ASMT_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_IMP_ACT_DTL_ASM_UN_CS_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_IMP_ACT_DTL_ASM_UN_CS_DT_ID" ON "OWIR_IMPL_ACT_DTLS" ("ASMT_UNIT_CAUSE_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_STTE_LC_DTLS_STT_ASM_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_STTE_LC_DTLS_STT_ASM_DTL_ID" ON "OWIR_STATE_LOC_DTLS" ("STATE_ASMT_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ASM_UNT_DLS_DTL_AS_UN_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASM_UNT_DLS_DTL_AS_UN_DT_ID" ON "OWIR_ASMT_UNIT_DELIST_DTLS" ("ASMT_UNIT_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_ASMT_MTH_DTL_WQS_ATT_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASMT_MTH_DTL_WQS_ATT_DTL_ID" ON "OWIR_ASMT_METH_DTLS" ("WQS_ATTAIN_DTLS_ID") 
  ;

--------------------------------------------------------
--  DDL for Index IX_WQS_ATTN_DTL_ASM_UNT_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WQS_ATTN_DTL_ASM_UNT_DTL_ID" ON "OWIR_WQS_ATTAIN_DTLS" ("ASMT_UNIT_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CYCL_TRC_DTL_ASM_UNT_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_CYCL_TRC_DTL_ASM_UNT_DTL_ID" ON "OWIR_CYCLE_TRACK_DTLS" ("ASMT_UNIT_DTLS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ASMT_WTR_DTL_ASM_UNT_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASMT_WTR_DTL_ASM_UNT_DTL_ID" ON "OWIR_ASMT_WATER_DTLS" ("ASMT_UNIT_DTLS_ID") 
  ;

--------------------------------------------------------
--  Ref Constraints for Table OWIR_ASMT_METH_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_METH_DTLS" ADD CONSTRAINT "FK_ASMT_MTH_DTLS_WQS_ATTN_DTLS" FOREIGN KEY ("WQS_ATTAIN_DTLS_ID")
	  REFERENCES "OWIR_WQS_ATTAIN_DTLS" ("WQS_ATTAIN_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_ASMT_TYPE_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_TYPE_DTLS" ADD CONSTRAINT "FK_ASMT_TYPE_DTLS_WQS_ATTN_DTL" FOREIGN KEY ("WQS_ATTAIN_DTLS_ID")
	  REFERENCES "OWIR_WQS_ATTAIN_DTLS" ("WQS_ATTAIN_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_ASMT_UNIT_CAUSE_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_UNIT_CAUSE_DTLS" ADD CONSTRAINT "FK_ASM_UNT_CSE_DTL_ASM_UNT_DTL" FOREIGN KEY ("ASMT_UNIT_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_DTLS" ("ASMT_UNIT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_ASMT_UNIT_DELIST_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_UNIT_DELIST_DTLS" ADD CONSTRAINT "FK_ASM_UNT_DLS_DTL_ASM_UNT_DTL" FOREIGN KEY ("ASMT_UNIT_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_DTLS" ("ASMT_UNIT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_ASMT_UNIT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_UNIT_DTLS" ADD CONSTRAINT "FK_ASMT_UNT_DTLS_STTE_ASMT_DTL" FOREIGN KEY ("STATE_ASMT_DTLS_ID")
	  REFERENCES "OWIR_STATE_ASMT_DTLS" ("STATE_ASMT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_ASMT_WATER_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ASMT_WATER_DTLS" ADD CONSTRAINT "FK_ASMT_WTR_DTLS_ASMT_UNT_DTLS" FOREIGN KEY ("ASMT_UNIT_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_DTLS" ("ASMT_UNIT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_ATLAS_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_ATLAS_DTLS" ADD CONSTRAINT "FK_ATLAS_DTLS_STATE_ASMT_DTLS" FOREIGN KEY ("STATE_ASMT_DTLS_ID")
	  REFERENCES "OWIR_STATE_ASMT_DTLS" ("STATE_ASMT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_CAUSE_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_CAUSE_DTLS" ADD CONSTRAINT "FK_CAUSE_DTLS_WQS_ATTAIN_DTLS" FOREIGN KEY ("WQS_ATTAIN_DTLS_ID")
	  REFERENCES "OWIR_WQS_ATTAIN_DTLS" ("WQS_ATTAIN_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_CYCLE_TRACK_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_CYCLE_TRACK_DTLS" ADD CONSTRAINT "FK_CYCL_TRCK_DTLS_ASMT_UNT_DTL" FOREIGN KEY ("ASMT_UNIT_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_DTLS" ("ASMT_UNIT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_IMPL_ACT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_IMPL_ACT_DTLS" ADD CONSTRAINT "FK_IMP_ACT_DTL_ASM_UNT_CSE_DTL" FOREIGN KEY ("ASMT_UNIT_CAUSE_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_CAUSE_DTLS" ("ASMT_UNIT_CAUSE_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_NPDES_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_NPDES_DTLS" ADD CONSTRAINT "FK_NPDS_DTLS_ASMT_UNT_CSE_DTLS" FOREIGN KEY ("ASMT_UNIT_CAUSE_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_CAUSE_DTLS" ("ASMT_UNIT_CAUSE_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_OBSERVED_EFFECT_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_OBSERVED_EFFECT_DTLS" ADD CONSTRAINT "FK_OBSR_EFFC_DTLS_WQS_ATTN_DTL" FOREIGN KEY ("WQS_ATTAIN_DTLS_ID")
	  REFERENCES "OWIR_WQS_ATTAIN_DTLS" ("WQS_ATTAIN_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_SRC_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_SRC_DTLS" ADD CONSTRAINT "FK_SRC_DTLS_CAUSE_DTLS" FOREIGN KEY ("CAUSE_DTLS_ID")
	  REFERENCES "OWIR_CAUSE_DTLS" ("CAUSE_DTLS_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table OWIR_STATE_LOC_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_STATE_LOC_DTLS" ADD CONSTRAINT "FK_STTE_LC_DTLS_STTE_ASMT_DTLS" FOREIGN KEY ("STATE_ASMT_DTLS_ID")
	  REFERENCES "OWIR_STATE_ASMT_DTLS" ("STATE_ASMT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_STATE_METH_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_STATE_METH_DTLS" ADD CONSTRAINT "FK_STTE_MTH_DTLS_STTE_ASMT_DTL" FOREIGN KEY ("STATE_ASMT_DTLS_ID")
	  REFERENCES "OWIR_STATE_ASMT_DTLS" ("STATE_ASMT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_TMD_LS_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_TMD_LS_DTLS" ADD CONSTRAINT "FK_TMD_LS_DTLS_ASM_UNT_CSE_DTL" FOREIGN KEY ("ASMT_UNIT_CAUSE_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_CAUSE_DTLS" ("ASMT_UNIT_CAUSE_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_USER_CATG_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_USER_CATG_DTLS" ADD CONSTRAINT "FK_USR_CTG_DTLS_STTE_ASMT_DTLS" FOREIGN KEY ("STATE_ASMT_DTLS_ID")
	  REFERENCES "OWIR_STATE_ASMT_DTLS" ("STATE_ASMT_DTLS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table OWIR_WQS_ATTAIN_DTLS
--------------------------------------------------------

  ALTER TABLE "OWIR_WQS_ATTAIN_DTLS" ADD CONSTRAINT "FK_WQS_ATTN_DTLS_ASMT_UNT_DTLS" FOREIGN KEY ("ASMT_UNIT_DTLS_ID")
	  REFERENCES "OWIR_ASMT_UNIT_DTLS" ("ASMT_UNIT_DTLS_ID") ON DELETE CASCADE ENABLE;
