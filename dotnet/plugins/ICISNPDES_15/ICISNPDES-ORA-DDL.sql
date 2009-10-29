--------------------------------------------------------
--  File created - Wednesday-October-28-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ICIS_CROP_TYPES_HARVESTED
--------------------------------------------------------

  CREATE TABLE "ICIS_CROP_TYPES_HARVESTED" 
   (	"CROP_TYPES_HARVESTED_ID" VARCHAR2(40), 
	"DISCHRG_MONTR_RPT_DATA_ID" VARCHAR2(40), 
	"TXT" VARCHAR2(3)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_CROP_TYPES_PLANTED
--------------------------------------------------------

  CREATE TABLE "ICIS_CROP_TYPES_PLANTED" 
   (	"CROP_TYPES_PLANTED_ID" VARCHAR2(40), 
	"DISCHRG_MONTR_RPT_DATA_ID" VARCHAR2(40), 
	"TXT" VARCHAR2(3)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_DISCHRG_MONTR_RPT_DATA
--------------------------------------------------------

  CREATE TABLE "ICIS_DISCHRG_MONTR_RPT_DATA" 
   (	"DISCHRG_MONTR_RPT_DATA_ID" VARCHAR2(40), 
	"PAYLOAD_DATA_ID" VARCHAR2(40), 
	"TRANS_TYPE" VARCHAR2(1), 
	"TRANS_TIMESTAMP" TIMESTAMP (6), 
	"SIGNATURE_DATE" VARCHAR2(255), 
	"PRINCPL_EXCUTVE_OFFCR_FRST_NME" VARCHAR2(30), 
	"PRINCIPL_EXCUTVE_OFFCR_LST_NME" VARCHAR2(30), 
	"PRINCIPAL_EXCUTIVE_OFFICR_TTLE" VARCHAR2(40), 
	"PRINCIPAL_EXECUTIVE_OFFICR_TLE" VARCHAR2(10), 
	"SIGNATORY_FIRST_NAME" VARCHAR2(30), 
	"SIGNATORY_LAST_NAME" VARCHAR2(30), 
	"SIGNATORY_TELE" VARCHAR2(10), 
	"RPT_CMNT_TXT" VARCHAR2(255), 
	"DMR_NO_DISCHRG_IND" VARCHAR2(50), 
	"DMR_NO_DISCHRG_RCVD_DATE" VARCHAR2(255), 
	"PERM_FEATURE_IDEN" VARCHAR2(4), 
	"LIMIT_SET_DESIGNATOR" VARCHAR2(2), 
	"MONTR_PRD_END_DATE" TIMESTAMP (6), 
	"PERMIT_IDEN" VARCHAR2(9), 
	"POLT_MET_FOR_LAND_APPLICATION" VARCHAR2(10), 
	"PATHOGEN_REDC_IND" VARCHAR2(1), 
	"VECTOR_REDC_IND" VARCHAR2(1), 
	"AGRONOMIC_GALLONS_RATE_FR_FILD" VARCHAR2(5), 
	"AGRONOMIC_DMT_RATE_FOR_FIELD" VARCHAR2(5), 
	"CLASS_A_ALT_USED" VARCHAR2(3), 
	"CLASS_A_ALTERNATIVES_TXT" VARCHAR2(255), 
	"CLASS_B_ALT_USED" VARCHAR2(3), 
	"CLASS_B_ALTERNATIVES_TXT" VARCHAR2(255), 
	"VAR_ALT_USED" VARCHAR2(3), 
	"VAR_ALTERNATIVES_TXT" VARCHAR2(255), 
	"SRFCE_DSPOSL_STE_PTHGN_RDC_IND" VARCHAR2(1), 
	"SURFCE_DSPOSL_STE_VCTR_RDC_IND" VARCHAR2(1), 
	"MANAGEMENT_PRACTICES_IND" VARCHAR2(1), 
	"CERTIFICATION_STATEMENT_IND" VARCHAR2(1), 
	"CERTIFIER_FIRST_NAME" VARCHAR2(1), 
	"CERTIFIER_LAST_NAME" VARCHAR2(1), 
	"SRFCE_DSPSL_STE_CLSS_A_ALT_USD" VARCHAR2(3), 
	"SRFCE_DSPS_STE_CLSS_A_ALTR_TXT" VARCHAR2(255), 
	"SRFCE_DSPSL_STE_CLSS_B_ALT_USD" VARCHAR2(3), 
	"SRFCE_DSPS_STE_CLSS_B_ALTR_TXT" VARCHAR2(255), 
	"SURFACE_DISPOSL_STE_VR_ALT_USD" VARCHAR2(3), 
	"SRFCE_DSPSL_STE_VR_ALTRNTV_TXT" VARCHAR2(255), 
	"BERYLLIUM_COMPL_IND" VARCHAR2(50), 
	"MERCURY_COMPL_IND" VARCHAR2(50), 
	"PART_258_COMPL_IND" VARCHAR2(50), 
	"PAINT_FILTER_TST_RSLT" VARCHAR2(4), 
	"TCLP_TST_RSLT" VARCHAR2(4)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_DOCUMENT
--------------------------------------------------------

  CREATE TABLE "ICIS_DOCUMENT" 
   (	"DOCUMENT_ID" VARCHAR2(40), 
	"ID" VARCHAR2(30), 
	"AUTHOR" VARCHAR2(255), 
	"ORG" VARCHAR2(255), 
	"TITLE" VARCHAR2(255), 
	"CRTN_TIME" TIMESTAMP (6), 
	"CMNT" VARCHAR2(255), 
	"DATA_SERVICE" VARCHAR2(255), 
	"CONTACT_INFO" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_HEADER_PROPERTY
--------------------------------------------------------

  CREATE TABLE "ICIS_HEADER_PROPERTY" 
   (	"PROPERTY_ID" VARCHAR2(40), 
	"DOCUMENT_ID" VARCHAR2(40), 
	"NAME" VARCHAR2(6), 
	"VAL" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_NUMERIC_REPORT
--------------------------------------------------------

  CREATE TABLE "ICIS_NUMERIC_REPORT" 
   (	"NUM_RPT_ID" VARCHAR2(40), 
	"RPT_PARM_ID" VARCHAR2(40), 
	"NUM_RPT_CODE" VARCHAR2(2), 
	"NUM_RPT_RCVD_DATE" VARCHAR2(255), 
	"NUM_RPT_NO_DISCHRG_IND" VARCHAR2(3), 
	"NUM_CONDITION_QNTY" VARCHAR2(255), 
	"NUM_CONDITION_ADJUSTED_QNTY" VARCHAR2(255), 
	"NUM_CONDITION_QUAL" VARCHAR2(3)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_PAYLOAD_DATA
--------------------------------------------------------

  CREATE TABLE "ICIS_PAYLOAD_DATA" 
   (	"PAYLOAD_DATA_ID" VARCHAR2(40), 
	"DOCUMENT_ID" VARCHAR2(40), 
	"LAST_PAYLOAD_UPDATE_DATE" TIMESTAMP (6), 
	"OPER" VARCHAR2(40)
   ) ;
 

   COMMENT ON COLUMN "ICIS_PAYLOAD_DATA"."LAST_PAYLOAD_UPDATE_DATE" IS 'The date and time that this payload was last updated for submission. (LastPayloadUpdateDate)';
--------------------------------------------------------
--  DDL for Table ICIS_RPT_PARM
--------------------------------------------------------

  CREATE TABLE "ICIS_RPT_PARM" 
   (	"RPT_PARM_ID" VARCHAR2(40), 
	"DISCHRG_MONTR_RPT_DATA_ID" VARCHAR2(40), 
	"RPT_SAMPLE_TYPE_TXT" VARCHAR2(3), 
	"RPT_FREQUENCY_CODE" VARCHAR2(5), 
	"RPT_NUM_OF_EXCURSIONS" VARCHAR2(3), 
	"CONCENTRTION_NM_RPT_UNT_MS_CDE" VARCHAR2(2), 
	"QNTY_NUM_RPT_UNIT_MEAS_CODE" VARCHAR2(2), 
	"PARM_CODE" VARCHAR2(5), 
	"MONTR_SITE_DESC_CODE" VARCHAR2(3), 
	"LIMIT_SEASON_NUM" VARCHAR2(2)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_SUBM_HISTORY
--------------------------------------------------------

  CREATE TABLE "ICIS_SUBM_HISTORY" 
   (	"SUBM_HISTORY_ID" VARCHAR2(40), 
	"DOCUMENT_HEADER_ID" VARCHAR2(255), 
	"SUBMIT_DATE" TIMESTAMP (6), 
	"LAST_PAYLOAD_UPDATE_DATE" TIMESTAMP (6), 
	"LOCAL_TRANS_ID" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "ICIS_SUBM_HISTORY"."DOCUMENT_HEADER_ID" IS 'The user id specified in the document header for the submission, corresponding to Document.Header.Id. (DocumentHeaderId)';
 
   COMMENT ON COLUMN "ICIS_SUBM_HISTORY"."SUBMIT_DATE" IS 'The date and time that the payload was submitted to the remote network node. (SubmitDate)';
 
   COMMENT ON COLUMN "ICIS_SUBM_HISTORY"."LAST_PAYLOAD_UPDATE_DATE" IS 'The date and time used to pull data from the staging table (payload data older than this date was pulled). (LastPayloadUpdateDate)';
 
   COMMENT ON COLUMN "ICIS_SUBM_HISTORY"."LOCAL_TRANS_ID" IS 'The transaction id for the submitted data on the local node. (LocalTransactionId)';

---------------------------------------------------
--   DATA FOR TABLE ICIS_CROP_TYPES_HARVESTED
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_CROP_TYPES_HARVESTED

---------------------------------------------------
--   END DATA FOR TABLE ICIS_CROP_TYPES_HARVESTED
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_CROP_TYPES_PLANTED
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_CROP_TYPES_PLANTED

---------------------------------------------------
--   END DATA FOR TABLE ICIS_CROP_TYPES_PLANTED
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_DISCHRG_MONTR_RPT_DATA
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_DISCHRG_MONTR_RPT_DATA

---------------------------------------------------
--   END DATA FOR TABLE ICIS_DISCHRG_MONTR_RPT_DATA
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_DOCUMENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_DOCUMENT

---------------------------------------------------
--   END DATA FOR TABLE ICIS_DOCUMENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_HEADER_PROPERTY
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_HEADER_PROPERTY

---------------------------------------------------
--   END DATA FOR TABLE ICIS_HEADER_PROPERTY
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_NUMERIC_REPORT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_NUMERIC_REPORT

---------------------------------------------------
--   END DATA FOR TABLE ICIS_NUMERIC_REPORT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_PAYLOAD_DATA
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_PAYLOAD_DATA

---------------------------------------------------
--   END DATA FOR TABLE ICIS_PAYLOAD_DATA
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_RPT_PARM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_RPT_PARM

---------------------------------------------------
--   END DATA FOR TABLE ICIS_RPT_PARM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE ICIS_SUBM_HISTORY
--   FILTER = none used
---------------------------------------------------
REM INSERTING into ICIS_SUBM_HISTORY

---------------------------------------------------
--   END DATA FOR TABLE ICIS_SUBM_HISTORY
---------------------------------------------------

--------------------------------------------------------
--  Constraints for Table ICIS_DISCHRG_MONTR_RPT_DATA
--------------------------------------------------------

  ALTER TABLE "ICIS_DISCHRG_MONTR_RPT_DATA" ADD CONSTRAINT "PK_DSC_MNT_RPT_DTA" PRIMARY KEY ("DISCHRG_MONTR_RPT_DATA_ID") ENABLE;
 
  ALTER TABLE "ICIS_DISCHRG_MONTR_RPT_DATA" MODIFY ("DISCHRG_MONTR_RPT_DATA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_DISCHRG_MONTR_RPT_DATA" MODIFY ("PAYLOAD_DATA_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_RPT_PARM
--------------------------------------------------------

  ALTER TABLE "ICIS_RPT_PARM" ADD CONSTRAINT "PK_RPT_PARM" PRIMARY KEY ("RPT_PARM_ID") ENABLE;
 
  ALTER TABLE "ICIS_RPT_PARM" MODIFY ("RPT_PARM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_RPT_PARM" MODIFY ("DISCHRG_MONTR_RPT_DATA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_RPT_PARM" MODIFY ("PARM_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_RPT_PARM" MODIFY ("MONTR_SITE_DESC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_RPT_PARM" MODIFY ("LIMIT_SEASON_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_PAYLOAD_DATA
--------------------------------------------------------

  ALTER TABLE "ICIS_PAYLOAD_DATA" ADD CONSTRAINT "PK_PAYLOAD_DATA" PRIMARY KEY ("PAYLOAD_DATA_ID") ENABLE;
 
  ALTER TABLE "ICIS_PAYLOAD_DATA" MODIFY ("PAYLOAD_DATA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_PAYLOAD_DATA" MODIFY ("DOCUMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_PAYLOAD_DATA" MODIFY ("LAST_PAYLOAD_UPDATE_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_CROP_TYPES_PLANTED
--------------------------------------------------------

  ALTER TABLE "ICIS_CROP_TYPES_PLANTED" ADD CONSTRAINT "PK_CRP_TYPS_PLNTED" PRIMARY KEY ("CROP_TYPES_PLANTED_ID") ENABLE;
 
  ALTER TABLE "ICIS_CROP_TYPES_PLANTED" MODIFY ("CROP_TYPES_PLANTED_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_CROP_TYPES_PLANTED" MODIFY ("DISCHRG_MONTR_RPT_DATA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_CROP_TYPES_PLANTED" MODIFY ("TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_DOCUMENT
--------------------------------------------------------

  ALTER TABLE "ICIS_DOCUMENT" ADD CONSTRAINT "PK_DOCUMENT" PRIMARY KEY ("DOCUMENT_ID") ENABLE;
 
  ALTER TABLE "ICIS_DOCUMENT" MODIFY ("DOCUMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_DOCUMENT" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_CROP_TYPES_HARVESTED
--------------------------------------------------------

  ALTER TABLE "ICIS_CROP_TYPES_HARVESTED" ADD CONSTRAINT "PK_CRP_TYPS_HRVSTD" PRIMARY KEY ("CROP_TYPES_HARVESTED_ID") ENABLE;
 
  ALTER TABLE "ICIS_CROP_TYPES_HARVESTED" MODIFY ("CROP_TYPES_HARVESTED_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_CROP_TYPES_HARVESTED" MODIFY ("DISCHRG_MONTR_RPT_DATA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_CROP_TYPES_HARVESTED" MODIFY ("TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_HEADER_PROPERTY
--------------------------------------------------------

  ALTER TABLE "ICIS_HEADER_PROPERTY" ADD CONSTRAINT "PK_HEADER_PROPERTY" PRIMARY KEY ("PROPERTY_ID") ENABLE;
 
  ALTER TABLE "ICIS_HEADER_PROPERTY" MODIFY ("PROPERTY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_HEADER_PROPERTY" MODIFY ("DOCUMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_HEADER_PROPERTY" MODIFY ("NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_HEADER_PROPERTY" MODIFY ("VAL" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_SUBM_HISTORY
--------------------------------------------------------

  ALTER TABLE "ICIS_SUBM_HISTORY" ADD CONSTRAINT "PK_SUBM_HISTORY" PRIMARY KEY ("SUBM_HISTORY_ID") ENABLE;
 
  ALTER TABLE "ICIS_SUBM_HISTORY" MODIFY ("SUBM_HISTORY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_SUBM_HISTORY" MODIFY ("DOCUMENT_HEADER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_SUBM_HISTORY" MODIFY ("SUBMIT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_SUBM_HISTORY" MODIFY ("LAST_PAYLOAD_UPDATE_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_SUBM_HISTORY" MODIFY ("LOCAL_TRANS_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ICIS_NUMERIC_REPORT
--------------------------------------------------------

  ALTER TABLE "ICIS_NUMERIC_REPORT" ADD CONSTRAINT "PK_NUMERIC_REPORT" PRIMARY KEY ("NUM_RPT_ID") ENABLE;
 
  ALTER TABLE "ICIS_NUMERIC_REPORT" MODIFY ("NUM_RPT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_NUMERIC_REPORT" MODIFY ("RPT_PARM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ICIS_NUMERIC_REPORT" MODIFY ("NUM_RPT_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index IX_HDR_PRPR_DCM_ID
--------------------------------------------------------

  CREATE INDEX "IX_HDR_PRPR_DCM_ID" ON "ICIS_HEADER_PROPERTY" ("DOCUMENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NUMERIC_REPORT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NUMERIC_REPORT" ON "ICIS_NUMERIC_REPORT" ("NUM_RPT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CRP_TYPS_HRVSTD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CRP_TYPS_HRVSTD" ON "ICIS_CROP_TYPES_HARVESTED" ("CROP_TYPES_HARVESTED_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SUBM_HISTORY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SUBM_HISTORY" ON "ICIS_SUBM_HISTORY" ("SUBM_HISTORY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CR_TY_HR_DS_MN
--------------------------------------------------------

  CREATE INDEX "IX_CR_TY_HR_DS_MN" ON "ICIS_CROP_TYPES_HARVESTED" ("DISCHRG_MONTR_RPT_DATA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_DOCUMENT_ID
--------------------------------------------------------

  CREATE INDEX "IX_DOCUMENT_ID" ON "ICIS_DOCUMENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_DOCUMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DOCUMENT" ON "ICIS_DOCUMENT" ("DOCUMENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PYLD_DTA_DCM_ID
--------------------------------------------------------

  CREATE INDEX "IX_PYLD_DTA_DCM_ID" ON "ICIS_PAYLOAD_DATA" ("DOCUMENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_NMR_RP_RP_PR_ID
--------------------------------------------------------

  CREATE INDEX "IX_NMR_RP_RP_PR_ID" ON "ICIS_NUMERIC_REPORT" ("RPT_PARM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PY_DT_LS_PY_UP
--------------------------------------------------------

  CREATE INDEX "IX_PY_DT_LS_PY_UP" ON "ICIS_PAYLOAD_DATA" ("LAST_PAYLOAD_UPDATE_DATE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_RPT_PARM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RPT_PARM" ON "ICIS_RPT_PARM" ("RPT_PARM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RP_PR_DS_MN_RP
--------------------------------------------------------

  CREATE INDEX "IX_RP_PR_DS_MN_RP" ON "ICIS_RPT_PARM" ("DISCHRG_MONTR_RPT_DATA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SBM_HS_DC_HD_ID
--------------------------------------------------------

  CREATE INDEX "IX_SBM_HS_DC_HD_ID" ON "ICIS_SUBM_HISTORY" ("DOCUMENT_HEADER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CR_TY_PL_DS_MN
--------------------------------------------------------

  CREATE INDEX "IX_CR_TY_PL_DS_MN" ON "ICIS_CROP_TYPES_PLANTED" ("DISCHRG_MONTR_RPT_DATA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_DS_MN_RP_DT_PY
--------------------------------------------------------

  CREATE INDEX "IX_DS_MN_RP_DT_PY" ON "ICIS_DISCHRG_MONTR_RPT_DATA" ("PAYLOAD_DATA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_DSC_MNT_RPT_DTA
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DSC_MNT_RPT_DTA" ON "ICIS_DISCHRG_MONTR_RPT_DATA" ("DISCHRG_MONTR_RPT_DATA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CRP_TYPS_PLNTED
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CRP_TYPS_PLNTED" ON "ICIS_CROP_TYPES_PLANTED" ("CROP_TYPES_PLANTED_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PAYLOAD_DATA
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PAYLOAD_DATA" ON "ICIS_PAYLOAD_DATA" ("PAYLOAD_DATA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_HEADER_PROPERTY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_HEADER_PROPERTY" ON "ICIS_HEADER_PROPERTY" ("PROPERTY_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_CROP_TYPES_HARVESTED
--------------------------------------------------------

  ALTER TABLE "ICIS_CROP_TYPES_HARVESTED" ADD CONSTRAINT "FK_CR_TY_HR_DS_MN" FOREIGN KEY ("DISCHRG_MONTR_RPT_DATA_ID")
	  REFERENCES "ICIS_DISCHRG_MONTR_RPT_DATA" ("DISCHRG_MONTR_RPT_DATA_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_CROP_TYPES_PLANTED
--------------------------------------------------------

  ALTER TABLE "ICIS_CROP_TYPES_PLANTED" ADD CONSTRAINT "FK_CR_TY_PL_DS_MN" FOREIGN KEY ("DISCHRG_MONTR_RPT_DATA_ID")
	  REFERENCES "ICIS_DISCHRG_MONTR_RPT_DATA" ("DISCHRG_MONTR_RPT_DATA_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_DISCHRG_MONTR_RPT_DATA
--------------------------------------------------------

  ALTER TABLE "ICIS_DISCHRG_MONTR_RPT_DATA" ADD CONSTRAINT "FK_DS_MN_RP_DT_PY" FOREIGN KEY ("PAYLOAD_DATA_ID")
	  REFERENCES "ICIS_PAYLOAD_DATA" ("PAYLOAD_DATA_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table ICIS_HEADER_PROPERTY
--------------------------------------------------------

  ALTER TABLE "ICIS_HEADER_PROPERTY" ADD CONSTRAINT "FK_HDR_PRPRT_DCMNT" FOREIGN KEY ("DOCUMENT_ID")
	  REFERENCES "ICIS_DOCUMENT" ("DOCUMENT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_NUMERIC_REPORT
--------------------------------------------------------

  ALTER TABLE "ICIS_NUMERIC_REPORT" ADD CONSTRAINT "FK_NMR_RPR_RPT_PRM" FOREIGN KEY ("RPT_PARM_ID")
	  REFERENCES "ICIS_RPT_PARM" ("RPT_PARM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_PAYLOAD_DATA
--------------------------------------------------------

  ALTER TABLE "ICIS_PAYLOAD_DATA" ADD CONSTRAINT "FK_PYLOD_DTA_DCMNT" FOREIGN KEY ("DOCUMENT_ID")
	  REFERENCES "ICIS_DOCUMENT" ("DOCUMENT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_RPT_PARM
--------------------------------------------------------

  ALTER TABLE "ICIS_RPT_PARM" ADD CONSTRAINT "FK_RP_PR_DS_MN_RP" FOREIGN KEY ("DISCHRG_MONTR_RPT_DATA_ID")
	  REFERENCES "ICIS_DISCHRG_MONTR_RPT_DATA" ("DISCHRG_MONTR_RPT_DATA_ID") ON DELETE CASCADE ENABLE;

