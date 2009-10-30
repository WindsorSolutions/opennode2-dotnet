--------------------------------------------------------
--  File created - Friday-October-09-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ICIS_CROP_TYPES_HARVESTED
--------------------------------------------------------

  CREATE TABLE ICIS_CROP_TYPES_HARVESTED 
   (    CROP_TYPES_HARVESTED_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    DISCHRG_MONTR_RPT_DATA_ID VARCHAR(40) NOT NULL, 
    TXT VARCHAR(3) NOT NULL
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_CROP_TYPES_PLANTED
--------------------------------------------------------

  CREATE TABLE ICIS_CROP_TYPES_PLANTED 
   (    CROP_TYPES_PLANTED_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    DISCHRG_MONTR_RPT_DATA_ID VARCHAR(40) NOT NULL, 
    TXT VARCHAR(3) NOT NULL
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_DISCHRG_MONTR_RPT_DATA
--------------------------------------------------------

  CREATE TABLE ICIS_DISCHRG_MONTR_RPT_DATA 
   (    DISCHRG_MONTR_RPT_DATA_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    PAYLOAD_DATA_ID VARCHAR(40) NOT NULL, 
    TRANS_TYPE VARCHAR(1), 
    TRANS_TIMESTAMP TIMESTAMP (6), 
    SIGNATURE_DATE VARCHAR(255), 
    PRINCPL_EXCUTVE_OFFCR_FRST_NME VARCHAR(128), 
    PRINCIPL_EXCUTVE_OFFCR_LST_NME VARCHAR(128), 
    PRINCIPAL_EXCUTIVE_OFFICR_TTLE VARCHAR(255), 
    PRINCIPAL_EXECUTIVE_OFFICR_TLE VARCHAR(255), 
    SIGNATORY_FIRST_NAME VARCHAR(128), 
    SIGNATORY_LAST_NAME VARCHAR(128), 
    SIGNATORY_TELE VARCHAR(255), 
    RPT_CMNT_TXT VARCHAR(255), 
    DMR_NO_DISCHRG_IND VARCHAR(50), 
    DMR_NO_DISCHRG_RCVD_DATE VARCHAR(255), 
    PERM_FEATURE_IDEN VARCHAR(50), 
    LIMIT_SET_DESIGNATOR VARCHAR(255), 
    MONTR_PRD_END_DATE TIMESTAMP (6), 
    PERMIT_IDEN VARCHAR(50), 
    POLT_MET_FOR_LAND_APPLICATION VARCHAR(255), 
    PATHOGEN_REDC_IND VARCHAR(50), 
    VECTOR_REDC_IND VARCHAR(50), 
    AGRONOMIC_GALLONS_RATE_FR_FILD VARCHAR(255), 
    AGRONOMIC_DMT_RATE_FOR_FIELD VARCHAR(255), 
    CLASS_A_ALT_USED VARCHAR(255), 
    CLASS_A_ALTERNATIVES_TXT VARCHAR(255), 
    CLASS_B_ALT_USED VARCHAR(255), 
    CLASS_B_ALTERNATIVES_TXT VARCHAR(255), 
    VAR_ALT_USED VARCHAR(255), 
    VAR_ALTERNATIVES_TXT VARCHAR(255), 
    SRFCE_DSPOSL_STE_PTHGN_RDC_IND VARCHAR(50), 
    SURFCE_DSPOSL_STE_VCTR_RDC_IND VARCHAR(50), 
    MANAGEMENT_PRACTICES_IND VARCHAR(50), 
    CERTIFICATION_STATEMENT_IND VARCHAR(50), 
    CERTIFIER_FIRST_NAME VARCHAR(128), 
    CERTIFIER_LAST_NAME VARCHAR(128), 
    SRFCE_DSPSL_STE_CLSS_A_ALT_USD VARCHAR(255), 
    SRFCE_DSPS_STE_CLSS_A_ALTR_TXT VARCHAR(255), 
    SRFCE_DSPSL_STE_CLSS_B_ALT_USD VARCHAR(255), 
    SRFCE_DSPS_STE_CLSS_B_ALTR_TXT VARCHAR(255), 
    SURFACE_DISPOSL_STE_VR_ALT_USD VARCHAR(255), 
    SRFCE_DSPSL_STE_VR_ALTRNTV_TXT VARCHAR(255), 
    BERYLLIUM_COMPL_IND VARCHAR(50), 
    MERCURY_COMPL_IND VARCHAR(50), 
    PART_258_COMPL_IND VARCHAR(50), 
    PAINT_FILTER_TST_RSLT VARCHAR(4), 
    TCLP_TST_RSLT VARCHAR(4)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_DOCUMENT
--------------------------------------------------------

  CREATE TABLE ICIS_DOCUMENT 
   (    DOCUMENT_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    ID VARCHAR(255), 
    AUTHOR VARCHAR(255), 
    ORG VARCHAR(255), 
    TITLE VARCHAR(255), 
    CRTN_TIME TIMESTAMP (6), 
    CMNT VARCHAR(255), 
    DATA_SERVICE VARCHAR(255), 
    CONTACT_INFO VARCHAR(255)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_HEADER_PROPERTY
--------------------------------------------------------

  CREATE TABLE ICIS_HEADER_PROPERTY 
   (    PROPERTY_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    DOCUMENT_ID VARCHAR(40) NOT NULL, 
    NAME VARCHAR(6) NOT NULL, 
    VAL VARCHAR(255) NOT NULL
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_NUMERIC_REPORT
--------------------------------------------------------

  CREATE TABLE ICIS_NUMERIC_REPORT 
   (    NUM_RPT_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    RPT_PARM_ID VARCHAR(40) NOT NULL, 
    NUM_RPT_CODE VARCHAR(2) NOT NULL, 
    NUM_RPT_RCVD_DATE VARCHAR(255), 
    NUM_RPT_NO_DISCHRG_IND VARCHAR(50), 
    NUM_CONDITION_QNTY VARCHAR(255), 
    NUM_CONDITION_ADJUSTED_QNTY VARCHAR(255), 
    NUM_CONDITION_QUAL VARCHAR(255)
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_PAYLOAD_DATA
--------------------------------------------------------

  CREATE TABLE ICIS_PAYLOAD_DATA 
   (    PAYLOAD_DATA_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    DOCUMENT_ID VARCHAR(40) NOT NULL, 
    LAST_PAYLOAD_UPDATE_DATE TIMESTAMP NOT NULL, 
    OPER VARCHAR(40)
   ) ;
 
--------------------------------------------------------
--  DDL for Table ICIS_RPT_PARM
--------------------------------------------------------

  CREATE TABLE ICIS_RPT_PARM 
   (    RPT_PARM_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    DISCHRG_MONTR_RPT_DATA_ID VARCHAR(40) NOT NULL, 
    RPT_SAMPLE_TYPE_TXT VARCHAR(255), 
    RPT_FREQUENCY_CODE VARCHAR(50), 
    RPT_NUM_OF_EXCURSIONS VARCHAR(255), 
    CONCENTRTION_NM_RPT_UNT_MS_CDE VARCHAR(50), 
    QNTY_NUM_RPT_UNIT_MEAS_CODE VARCHAR(50), 
    PARM_CODE VARCHAR(50) NOT NULL, 
    MONTR_SITE_DESC_CODE VARCHAR(50) NOT NULL, 
    LIMIT_SEASON_NUM VARCHAR(20) NOT NULL
   ) ;
--------------------------------------------------------
--  DDL for Table ICIS_SUBM_HISTORY
--------------------------------------------------------

  CREATE TABLE ICIS_SUBM_HISTORY 
   (    SUBM_HISTORY_ID VARCHAR(40) PRIMARY KEY NOT NULL, 
    DOCUMENT_HEADER_ID VARCHAR(255) NOT NULL, 
    SUBMIT_DATE TIMESTAMP (6) NOT NULL, 
    LAST_PAYLOAD_UPDATE_DATE TIMESTAMP (6) NOT NULL, 
    LOCAL_TRANS_ID VARCHAR(50) NOT NULL
   ) ;

--------------------------------------------------------
--  DDL for Index IX_HDR_PRPR_DCM_ID
--------------------------------------------------------

  CREATE INDEX IX_HDR_PRPR_DCM_ID ON ICIS_HEADER_PROPERTY (DOCUMENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_NUMERIC_REPORT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_NUMERIC_REPORT ON ICIS_NUMERIC_REPORT (NUM_RPT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_CRP_TYPS_HRVSTD
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_CRP_TYPS_HRVSTD ON ICIS_CROP_TYPES_HARVESTED (CROP_TYPES_HARVESTED_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_SUBM_HISTORY
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_SUBM_HISTORY ON ICIS_SUBM_HISTORY (SUBM_HISTORY_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_CR_TY_HR_DS_MN
--------------------------------------------------------

  CREATE INDEX IX_CR_TY_HR_DS_MN ON ICIS_CROP_TYPES_HARVESTED (DISCHRG_MONTR_RPT_DATA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_DOCUMENT_ID
--------------------------------------------------------

  CREATE INDEX IX_DOCUMENT_ID ON ICIS_DOCUMENT (ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_DOCUMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_DOCUMENT ON ICIS_DOCUMENT (DOCUMENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_PYLD_DTA_DCM_ID
--------------------------------------------------------

  CREATE INDEX IX_PYLD_DTA_DCM_ID ON ICIS_PAYLOAD_DATA (DOCUMENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_NMR_RP_RP_PR_ID
--------------------------------------------------------

  CREATE INDEX IX_NMR_RP_RP_PR_ID ON ICIS_NUMERIC_REPORT (RPT_PARM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_PY_DT_LS_PY_UP
--------------------------------------------------------

  CREATE INDEX IX_PY_DT_LS_PY_UP ON ICIS_PAYLOAD_DATA (LAST_PAYLOAD_UPDATE_DATE) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RPT_PARM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RPT_PARM ON ICIS_RPT_PARM (RPT_PARM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RP_PR_DS_MN_RP
--------------------------------------------------------

  CREATE INDEX IX_RP_PR_DS_MN_RP ON ICIS_RPT_PARM (DISCHRG_MONTR_RPT_DATA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_SBM_HS_DC_HD_ID
--------------------------------------------------------

  CREATE INDEX IX_SBM_HS_DC_HD_ID ON ICIS_SUBM_HISTORY (DOCUMENT_HEADER_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_CR_TY_PL_DS_MN
--------------------------------------------------------

  CREATE INDEX IX_CR_TY_PL_DS_MN ON ICIS_CROP_TYPES_PLANTED (DISCHRG_MONTR_RPT_DATA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_DS_MN_RP_DT_PY
--------------------------------------------------------

  CREATE INDEX IX_DS_MN_RP_DT_PY ON ICIS_DISCHRG_MONTR_RPT_DATA (PAYLOAD_DATA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_DSC_MNT_RPT_DTA
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_DSC_MNT_RPT_DTA ON ICIS_DISCHRG_MONTR_RPT_DATA (DISCHRG_MONTR_RPT_DATA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_CRP_TYPS_PLNTED
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_CRP_TYPS_PLNTED ON ICIS_CROP_TYPES_PLANTED (CROP_TYPES_PLANTED_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_PAYLOAD_DATA
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_PAYLOAD_DATA ON ICIS_PAYLOAD_DATA (PAYLOAD_DATA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_HEADER_PROPERTY
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_HEADER_PROPERTY ON ICIS_HEADER_PROPERTY (PROPERTY_ID) 
  ;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_CROP_TYPES_HARVESTED
--------------------------------------------------------

  ALTER TABLE ICIS_CROP_TYPES_HARVESTED ADD CONSTRAINT FK_CR_TY_HR_DS_MN FOREIGN KEY (DISCHRG_MONTR_RPT_DATA_ID)
      REFERENCES ICIS_DISCHRG_MONTR_RPT_DATA (DISCHRG_MONTR_RPT_DATA_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_CROP_TYPES_PLANTED
--------------------------------------------------------

  ALTER TABLE ICIS_CROP_TYPES_PLANTED ADD CONSTRAINT FK_CR_TY_PL_DS_MN FOREIGN KEY (DISCHRG_MONTR_RPT_DATA_ID)
      REFERENCES ICIS_DISCHRG_MONTR_RPT_DATA (DISCHRG_MONTR_RPT_DATA_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_DISCHRG_MONTR_RPT_DATA
--------------------------------------------------------

  ALTER TABLE ICIS_DISCHRG_MONTR_RPT_DATA ADD CONSTRAINT FK_DS_MN_RP_DT_PY FOREIGN KEY (PAYLOAD_DATA_ID)
      REFERENCES ICIS_PAYLOAD_DATA (PAYLOAD_DATA_ID) ON DELETE CASCADE;

--------------------------------------------------------
--  Ref Constraints for Table ICIS_HEADER_PROPERTY
--------------------------------------------------------

  ALTER TABLE ICIS_HEADER_PROPERTY ADD CONSTRAINT FK_HDR_PRPRT_DCMNT FOREIGN KEY (DOCUMENT_ID)
      REFERENCES ICIS_DOCUMENT (DOCUMENT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_NUMERIC_REPORT
--------------------------------------------------------

  ALTER TABLE ICIS_NUMERIC_REPORT ADD CONSTRAINT FK_NMR_RPR_RPT_PRM FOREIGN KEY (RPT_PARM_ID)
      REFERENCES ICIS_RPT_PARM (RPT_PARM_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_PAYLOAD_DATA
--------------------------------------------------------

  ALTER TABLE ICIS_PAYLOAD_DATA ADD CONSTRAINT FK_PYLOD_DTA_DCMNT FOREIGN KEY (DOCUMENT_ID)
      REFERENCES ICIS_DOCUMENT (DOCUMENT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table ICIS_RPT_PARM
--------------------------------------------------------

  ALTER TABLE ICIS_RPT_PARM ADD CONSTRAINT FK_RP_PR_DS_MN_RP FOREIGN KEY (DISCHRG_MONTR_RPT_DATA_ID)
      REFERENCES ICIS_DISCHRG_MONTR_RPT_DATA (DISCHRG_MONTR_RPT_DATA_ID) ON DELETE CASCADE;

