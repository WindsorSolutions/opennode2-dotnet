--------------------------------------------------------
--  File created - Wednesday-December-01-2010   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table P2R_ACTIVITY_MEASURE
--------------------------------------------------------

  CREATE TABLE "P2R_ACTIVITY_MEASURE" 
   (	"ACTIVITY_MEASURE_ID" VARCHAR2(40), 
	"PROJECT_DETAILS_ID" VARCHAR2(40), 
	"ACTIVITY_MEASURE_IDENTIFIER" VARCHAR2(10), 
	"ACTIVITY_MEASURE_NAME" VARCHAR2(255), 
	"ACTIVITY_MEASURE_DEFINITION" VARCHAR2(1000)
   ) ;
 

   COMMENT ON TABLE "P2R_ACTIVITY_MEASURE"  IS 'Schema element: ActivityMeasureDataType';
--------------------------------------------------------
--  DDL for Table P2R_ACTIVITY_MEASURE_QNT_RSLT
--------------------------------------------------------

  CREATE TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" 
   (	"ACTIVITY_MEASURE_QNT_RSLT_ID" VARCHAR2(40), 
	"ACTIVITY_MEASURE_ID" VARCHAR2(40), 
	"P2R_MEASURE_VALUE" VARCHAR2(25), 
	"UNIT_OF_MEASURE" VARCHAR2(255)
   ) ;
 

   COMMENT ON TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT"  IS 'Schema element: ActivityMeasureQuantitativeResultDataType';
--------------------------------------------------------
--  DDL for Table P2R_BEHAVIORAL_CHANGE
--------------------------------------------------------

  CREATE TABLE "P2R_BEHAVIORAL_CHANGE" 
   (	"BEHAVIORAL_CHANGE_ID" VARCHAR2(40), 
	"PROJECT_DETAILS_ID" VARCHAR2(40), 
	"BEHAVIORAL_CHANGE_IDENTIFIER" VARCHAR2(10), 
	"BEHAVIORAL_CHANGE_NAME" VARCHAR2(255), 
	"BEHAVIORAL_CHANGE_DEFINITION" VARCHAR2(1000)
   ) ;
 

   COMMENT ON TABLE "P2R_BEHAVIORAL_CHANGE"  IS 'Schema element: BehavioralChangeDataType';
--------------------------------------------------------
--  DDL for Table P2R_BEHAVIORAL_CHANGE_QNT_RSLT
--------------------------------------------------------

  CREATE TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" 
   (	"BEHAVIORAL_CHANGE_QNT_RSLT_ID" VARCHAR2(40), 
	"BEHAVIORAL_CHANGE_ID" VARCHAR2(40), 
	"P2R_MEASURE_VALUE" VARCHAR2(25), 
	"UNIT_OF_MEASURE" VARCHAR2(255)
   ) ;
 

   COMMENT ON TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT"  IS 'Schema element: BehavioralChangeQuantitativeResultDataType';
--------------------------------------------------------
--  DDL for Table P2R_INVESTMENT
--------------------------------------------------------

  CREATE TABLE "P2R_INVESTMENT" 
   (	"INVESTMENT_ID" VARCHAR2(40), 
	"PROJECT_DETAILS_ID" VARCHAR2(40), 
	"INVESTMENT_IDENTIFIER" VARCHAR2(10), 
	"INVESTMENT_NAME" VARCHAR2(255), 
	"INVESTMENT_DEFINITION" VARCHAR2(1000), 
	"UNIT_OF_MEASURE" VARCHAR2(255), 
	"INVESTMENT_VALUE" VARCHAR2(25)
   ) ;
 

   COMMENT ON TABLE "P2R_INVESTMENT"  IS 'Schema element: InvestmentDataType';
--------------------------------------------------------
--  DDL for Table P2R_ORG
--------------------------------------------------------

  CREATE TABLE "P2R_ORG" 
   (	"ORG_ID" VARCHAR2(50)
   ) ;
 

   COMMENT ON TABLE "P2R_ORG"  IS 'Schema element: ProgramListType';
--------------------------------------------------------
--  DDL for Table P2R_OUTCOME_MEASURE
--------------------------------------------------------

  CREATE TABLE "P2R_OUTCOME_MEASURE" 
   (	"OUTCOME_MEASURE_ID" VARCHAR2(40), 
	"PROJECT_DETAILS_ID" VARCHAR2(40), 
	"OUTCOME_MEASURE_IDENTIFIER" VARCHAR2(10), 
	"OUTCOME_MEASURE_NAME" VARCHAR2(255), 
	"OUTCOME_MEASURE_DEFINITION" VARCHAR2(1000), 
	"OUTCOME_MEASURE_SAVING" VARCHAR2(25), 
	"OUTCOME_MEASURE_INITIAL_COST" VARCHAR2(25), 
	"OUTCOME_MEASURE_RECURRING_YEAR" VARCHAR2(25)
   ) ;
 

   COMMENT ON TABLE "P2R_OUTCOME_MEASURE"  IS 'Schema element: OutcomeMeasureDataType';
--------------------------------------------------------
--  DDL for Table P2R_OUTCOME_MEASURE_RESULT
--------------------------------------------------------

  CREATE TABLE "P2R_OUTCOME_MEASURE_RESULT" 
   (	"OUTCOME_MEASURE_RESULT_ID" VARCHAR2(40), 
	"OUTCOME_MEASURE_ID" VARCHAR2(40), 
	"MEDIA_TYPE_TEXT" VARCHAR2(1000), 
	"OUTCOME_MEASURE_RESULT_VALUE" VARCHAR2(25), 
	"UNIT_OF_MEASURE" VARCHAR2(255), 
	"METRIC_TEXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON TABLE "P2R_OUTCOME_MEASURE_RESULT"  IS 'Schema element: OutcomeMeasureResultDataType';
--------------------------------------------------------
--  DDL for Table P2R_PROGRAM_DETAILS
--------------------------------------------------------

  CREATE TABLE "P2R_PROGRAM_DETAILS" 
   (	"PROGRAM_DETAILS_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(50), 
	"PROGRAM_IDENTIFIER" VARCHAR2(120), 
	"PROGRAM_NAME" VARCHAR2(255), 
	"PROGRAM_DESCRIPTION" VARCHAR2(1000), 
	"PROGRAM_ADDRESS" VARCHAR2(255), 
	"PROGRAM_CITY" VARCHAR2(255), 
	"PROGRAM_STATE" VARCHAR2(255), 
	"PROGRAM_ZIP_CODE" VARCHAR2(10), 
	"PROGRAM_PHONE_NUMBER" VARCHAR2(255), 
	"PROGRAM_CONTACT_PERSON" VARCHAR2(255)
   ) ;
 

   COMMENT ON TABLE "P2R_PROGRAM_DETAILS"  IS 'Schema element: ProgramDetailsDataType';
--------------------------------------------------------
--  DDL for Table P2R_PROJECT_DETAILS
--------------------------------------------------------

  CREATE TABLE "P2R_PROJECT_DETAILS" 
   (	"PROJECT_DETAILS_ID" VARCHAR2(40), 
	"PROGRAM_DETAILS_ID" VARCHAR2(40), 
	"PROJECT_IDENTIFIER" VARCHAR2(120), 
	"PROJECT_NAME" VARCHAR2(255), 
	"PROJECT_DESCRIPTION" VARCHAR2(1000), 
	"SCOPE_AREA_TEXT" VARCHAR2(255), 
	"PROJECT_START_DATE" TIMESTAMP (6), 
	"PROJECT_END_DATE" TIMESTAMP (6), 
	"PROJECT_INPUT_PERSON" VARCHAR2(255), 
	"PROJECT_DATE_ENTERED" TIMESTAMP (6)
   ) ;
 

   COMMENT ON TABLE "P2R_PROJECT_DETAILS"  IS 'Schema element: ProjectDetailsDataType';
--------------------------------------------------------
--  DDL for Table P2R_PROJECT_DETAILS_SECTOR
--------------------------------------------------------

  CREATE TABLE "P2R_PROJECT_DETAILS_SECTOR" 
   (	"PROJECT_DETAILS_SECTOR_ID" VARCHAR2(40), 
	"PROJECT_DETAILS_ID" VARCHAR2(40), 
	"SECTOR_TEXT" VARCHAR2(50)
   ) ;
 

   COMMENT ON TABLE "P2R_PROJECT_DETAILS_SECTOR"  IS 'Schema element: ProjectDetailsSectorDataType';
--------------------------------------------------------
--  Constraints for Table P2R_BEHAVIORAL_CHANGE
--------------------------------------------------------

  ALTER TABLE "P2R_BEHAVIORAL_CHANGE" ADD CONSTRAINT "PK_P2R_BEHAV_CHANG" PRIMARY KEY ("BEHAVIORAL_CHANGE_ID") ENABLE;
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE" MODIFY ("BEHAVIORAL_CHANGE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE" MODIFY ("PROJECT_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE" MODIFY ("BEHAVIORAL_CHANGE_IDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE" MODIFY ("BEHAVIORAL_CHANGE_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_ACTIVITY_MEASURE
--------------------------------------------------------

  ALTER TABLE "P2R_ACTIVITY_MEASURE" ADD CONSTRAINT "PK_P2R_ACTIV_MEASU" PRIMARY KEY ("ACTIVITY_MEASURE_ID") ENABLE;
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE" MODIFY ("ACTIVITY_MEASURE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE" MODIFY ("PROJECT_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE" MODIFY ("ACTIVITY_MEASURE_IDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE" MODIFY ("ACTIVITY_MEASURE_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_INVESTMENT
--------------------------------------------------------

  ALTER TABLE "P2R_INVESTMENT" ADD CONSTRAINT "PK_P2R_INVESTMENT" PRIMARY KEY ("INVESTMENT_ID") ENABLE;
 
  ALTER TABLE "P2R_INVESTMENT" MODIFY ("INVESTMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_INVESTMENT" MODIFY ("PROJECT_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_INVESTMENT" MODIFY ("INVESTMENT_IDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_INVESTMENT" MODIFY ("INVESTMENT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_INVESTMENT" MODIFY ("UNIT_OF_MEASURE" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_INVESTMENT" MODIFY ("INVESTMENT_VALUE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_PROJECT_DETAILS
--------------------------------------------------------

  ALTER TABLE "P2R_PROJECT_DETAILS" ADD CONSTRAINT "PK_P2R_PROJE_DETAI" PRIMARY KEY ("PROJECT_DETAILS_ID") ENABLE;
 
  ALTER TABLE "P2R_PROJECT_DETAILS" MODIFY ("PROJECT_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROJECT_DETAILS" MODIFY ("PROGRAM_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROJECT_DETAILS" MODIFY ("PROJECT_IDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROJECT_DETAILS" MODIFY ("PROJECT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROJECT_DETAILS" MODIFY ("PROJECT_START_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_ORG
--------------------------------------------------------

  ALTER TABLE "P2R_ORG" ADD CONSTRAINT "PK_P2R_ORG" PRIMARY KEY ("ORG_ID") ENABLE;
 
  ALTER TABLE "P2R_ORG" MODIFY ("ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_BEHAVIORAL_CHANGE_QNT_RSLT
--------------------------------------------------------

  ALTER TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" ADD CONSTRAINT "PK_P2R_BE_CH_QN_RS" PRIMARY KEY ("BEHAVIORAL_CHANGE_QNT_RSLT_ID") ENABLE;
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" MODIFY ("BEHAVIORAL_CHANGE_QNT_RSLT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" MODIFY ("BEHAVIORAL_CHANGE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" MODIFY ("P2R_MEASURE_VALUE" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" MODIFY ("UNIT_OF_MEASURE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_OUTCOME_MEASURE
--------------------------------------------------------

  ALTER TABLE "P2R_OUTCOME_MEASURE" ADD CONSTRAINT "PK_P2R_OUTCO_MEASU" PRIMARY KEY ("OUTCOME_MEASURE_ID") ENABLE;
 
  ALTER TABLE "P2R_OUTCOME_MEASURE" MODIFY ("OUTCOME_MEASURE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE" MODIFY ("PROJECT_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE" MODIFY ("OUTCOME_MEASURE_IDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE" MODIFY ("OUTCOME_MEASURE_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_PROGRAM_DETAILS
--------------------------------------------------------

  ALTER TABLE "P2R_PROGRAM_DETAILS" ADD CONSTRAINT "PK_P2R_PROGR_DETAI" PRIMARY KEY ("PROGRAM_DETAILS_ID") ENABLE;
 
  ALTER TABLE "P2R_PROGRAM_DETAILS" MODIFY ("PROGRAM_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROGRAM_DETAILS" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROGRAM_DETAILS" MODIFY ("PROGRAM_IDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROGRAM_DETAILS" MODIFY ("PROGRAM_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_ACTIVITY_MEASURE_QNT_RSLT
--------------------------------------------------------

  ALTER TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" ADD CONSTRAINT "PK_P2R_AC_ME_QN_RS" PRIMARY KEY ("ACTIVITY_MEASURE_QNT_RSLT_ID") ENABLE;
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" MODIFY ("ACTIVITY_MEASURE_QNT_RSLT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" MODIFY ("ACTIVITY_MEASURE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" MODIFY ("P2R_MEASURE_VALUE" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" MODIFY ("UNIT_OF_MEASURE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_PROJECT_DETAILS_SECTOR
--------------------------------------------------------

  ALTER TABLE "P2R_PROJECT_DETAILS_SECTOR" ADD CONSTRAINT "PK_P2R_PRO_DET_SEC" PRIMARY KEY ("PROJECT_DETAILS_SECTOR_ID") ENABLE;
 
  ALTER TABLE "P2R_PROJECT_DETAILS_SECTOR" MODIFY ("PROJECT_DETAILS_SECTOR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROJECT_DETAILS_SECTOR" MODIFY ("PROJECT_DETAILS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_PROJECT_DETAILS_SECTOR" MODIFY ("SECTOR_TEXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table P2R_OUTCOME_MEASURE_RESULT
--------------------------------------------------------

  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" ADD CONSTRAINT "PK_P2R_OUT_MEA_RES" PRIMARY KEY ("OUTCOME_MEASURE_RESULT_ID") ENABLE;
 
  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" MODIFY ("OUTCOME_MEASURE_RESULT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" MODIFY ("OUTCOME_MEASURE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" MODIFY ("MEDIA_TYPE_TEXT" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" MODIFY ("OUTCOME_MEASURE_RESULT_VALUE" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" MODIFY ("UNIT_OF_MEASURE" NOT NULL ENABLE);
 
  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" MODIFY ("METRIC_TEXT" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index IX_P2R_IN_PR_DE_ID
--------------------------------------------------------

  CREATE INDEX "IX_P2R_IN_PR_DE_ID" ON "P2R_INVESTMENT" ("PROJECT_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2R_PR_DE_OR_ID
--------------------------------------------------------

  CREATE INDEX "IX_P2R_PR_DE_OR_ID" ON "P2R_PROGRAM_DETAILS" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_ORG" ON "P2R_ORG" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_PROJE_DETAI
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_PROJE_DETAI" ON "P2R_PROJECT_DETAILS" ("PROJECT_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_BE_CH_QN_RS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_BE_CH_QN_RS" ON "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" ("BEHAVIORAL_CHANGE_QNT_RSLT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_PRO_DET_SEC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_PRO_DET_SEC" ON "P2R_PROJECT_DETAILS_SECTOR" ("PROJECT_DETAILS_SECTOR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_PR_DE_PR_DE
--------------------------------------------------------

  CREATE INDEX "IX_P2_PR_DE_PR_DE" ON "P2R_PROJECT_DETAILS" ("PROGRAM_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_AC_ME_QN_RS
--------------------------------------------------------

  CREATE INDEX "IX_P2_AC_ME_QN_RS" ON "P2R_ACTIVITY_MEASURE_QNT_RSLT" ("ACTIVITY_MEASURE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_BE_CH_PR_DE
--------------------------------------------------------

  CREATE INDEX "IX_P2_BE_CH_PR_DE" ON "P2R_BEHAVIORAL_CHANGE" ("PROJECT_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_ACTIV_MEASU
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_ACTIV_MEASU" ON "P2R_ACTIVITY_MEASURE" ("ACTIVITY_MEASURE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_BE_CH_QN_RS
--------------------------------------------------------

  CREATE INDEX "IX_P2_BE_CH_QN_RS" ON "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" ("BEHAVIORAL_CHANGE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_BEHAV_CHANG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_BEHAV_CHANG" ON "P2R_BEHAVIORAL_CHANGE" ("BEHAVIORAL_CHANGE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_AC_ME_QN_RS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_AC_ME_QN_RS" ON "P2R_ACTIVITY_MEASURE_QNT_RSLT" ("ACTIVITY_MEASURE_QNT_RSLT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_OUTCO_MEASU
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_OUTCO_MEASU" ON "P2R_OUTCOME_MEASURE" ("OUTCOME_MEASURE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_PR_DE_SE_PR
--------------------------------------------------------

  CREATE INDEX "IX_P2_PR_DE_SE_PR" ON "P2R_PROJECT_DETAILS_SECTOR" ("PROJECT_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_AC_ME_PR_DE
--------------------------------------------------------

  CREATE INDEX "IX_P2_AC_ME_PR_DE" ON "P2R_ACTIVITY_MEASURE" ("PROJECT_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_OU_ME_PR_DE
--------------------------------------------------------

  CREATE INDEX "IX_P2_OU_ME_PR_DE" ON "P2R_OUTCOME_MEASURE" ("PROJECT_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_PROGR_DETAI
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_PROGR_DETAI" ON "P2R_PROGRAM_DETAILS" ("PROGRAM_DETAILS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_P2_OU_ME_RE_OU
--------------------------------------------------------

  CREATE INDEX "IX_P2_OU_ME_RE_OU" ON "P2R_OUTCOME_MEASURE_RESULT" ("OUTCOME_MEASURE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_INVESTMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_INVESTMENT" ON "P2R_INVESTMENT" ("INVESTMENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_P2R_OUT_MEA_RES
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_P2R_OUT_MEA_RES" ON "P2R_OUTCOME_MEASURE_RESULT" ("OUTCOME_MEASURE_RESULT_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table P2R_ACTIVITY_MEASURE
--------------------------------------------------------

  ALTER TABLE "P2R_ACTIVITY_MEASURE" ADD CONSTRAINT "FK_P2_AC_ME_P2_PR" FOREIGN KEY ("PROJECT_DETAILS_ID")
	  REFERENCES "P2R_PROJECT_DETAILS" ("PROJECT_DETAILS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_ACTIVITY_MEASURE_QNT_RSLT
--------------------------------------------------------

  ALTER TABLE "P2R_ACTIVITY_MEASURE_QNT_RSLT" ADD CONSTRAINT "FK_P2_AC_ME_QN_RS" FOREIGN KEY ("ACTIVITY_MEASURE_ID")
	  REFERENCES "P2R_ACTIVITY_MEASURE" ("ACTIVITY_MEASURE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_BEHAVIORAL_CHANGE
--------------------------------------------------------

  ALTER TABLE "P2R_BEHAVIORAL_CHANGE" ADD CONSTRAINT "FK_P2_BE_CH_P2_PR" FOREIGN KEY ("PROJECT_DETAILS_ID")
	  REFERENCES "P2R_PROJECT_DETAILS" ("PROJECT_DETAILS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_BEHAVIORAL_CHANGE_QNT_RSLT
--------------------------------------------------------

  ALTER TABLE "P2R_BEHAVIORAL_CHANGE_QNT_RSLT" ADD CONSTRAINT "FK_P2_BE_CH_QN_RS" FOREIGN KEY ("BEHAVIORAL_CHANGE_ID")
	  REFERENCES "P2R_BEHAVIORAL_CHANGE" ("BEHAVIORAL_CHANGE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_INVESTMENT
--------------------------------------------------------

  ALTER TABLE "P2R_INVESTMENT" ADD CONSTRAINT "FK_P2R_IN_P2_PR_DE" FOREIGN KEY ("PROJECT_DETAILS_ID")
	  REFERENCES "P2R_PROJECT_DETAILS" ("PROJECT_DETAILS_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table P2R_OUTCOME_MEASURE
--------------------------------------------------------

  ALTER TABLE "P2R_OUTCOME_MEASURE" ADD CONSTRAINT "FK_P2_OU_ME_P2_PR" FOREIGN KEY ("PROJECT_DETAILS_ID")
	  REFERENCES "P2R_PROJECT_DETAILS" ("PROJECT_DETAILS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_OUTCOME_MEASURE_RESULT
--------------------------------------------------------

  ALTER TABLE "P2R_OUTCOME_MEASURE_RESULT" ADD CONSTRAINT "FK_P2_OU_ME_RE_P2" FOREIGN KEY ("OUTCOME_MEASURE_ID")
	  REFERENCES "P2R_OUTCOME_MEASURE" ("OUTCOME_MEASURE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_PROGRAM_DETAILS
--------------------------------------------------------

  ALTER TABLE "P2R_PROGRAM_DETAILS" ADD CONSTRAINT "FK_P2R_PR_DE_P2_OR" FOREIGN KEY ("ORG_ID")
	  REFERENCES "P2R_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_PROJECT_DETAILS
--------------------------------------------------------

  ALTER TABLE "P2R_PROJECT_DETAILS" ADD CONSTRAINT "FK_P2_PR_DE_P2_PR" FOREIGN KEY ("PROGRAM_DETAILS_ID")
	  REFERENCES "P2R_PROGRAM_DETAILS" ("PROGRAM_DETAILS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table P2R_PROJECT_DETAILS_SECTOR
--------------------------------------------------------

  ALTER TABLE "P2R_PROJECT_DETAILS_SECTOR" ADD CONSTRAINT "FK_P2_PR_DE_SE_P2" FOREIGN KEY ("PROJECT_DETAILS_ID")
	  REFERENCES "P2R_PROJECT_DETAILS" ("PROJECT_DETAILS_ID") ON DELETE CASCADE ENABLE;
