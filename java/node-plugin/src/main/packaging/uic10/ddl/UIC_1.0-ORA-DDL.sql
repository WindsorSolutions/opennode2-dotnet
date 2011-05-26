--------------------------------------------------------
--  File created - Tuesday-December-01-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table UIC_CONSTITUENT
--------------------------------------------------------

  CREATE TABLE "UIC_CONSTITUENT" 
   (	"CONSTITUENT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"CONSTITUENT_IDENT" VARCHAR2(20), 
	"MEASURE_VALUE" VARCHAR2(20), 
	"MEASURE_UNIT_CD" VARCHAR2(50), 
	"CONSTITUENT_NAME_TXT" VARCHAR2(50), 
	"CONSTITUENT_WASTE_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_CONSTITUENT"  IS 'Schema element: ConstituentDetailType';
--------------------------------------------------------
--  DDL for Table UIC_CONTACT
--------------------------------------------------------

  CREATE TABLE "UIC_CONTACT" 
   (	"CONTACT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"CONTACT_IDENT" VARCHAR2(20), 
	"TELEPHONE_NUMBER_TXT" VARCHAR2(15), 
	"INDIVIDUAL_FULL_NAME" VARCHAR2(70), 
	"CONTACT_CITY_NAME" VARCHAR2(30), 
	"CONTACT_ADDRESS_STATE_CD" VARCHAR2(50), 
	"CONTACT_ADDRESS_TXT" VARCHAR2(150), 
	"CONTACT_ADDRESS_POSTAL_CD" VARCHAR2(14)
   ) ;
 

   COMMENT ON TABLE "UIC_CONTACT"  IS 'Schema element: ContactDetailType';
--------------------------------------------------------
--  DDL for Table UIC_CORRECTION
--------------------------------------------------------

  CREATE TABLE "UIC_CORRECTION" 
   (	"CORRECTION_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"CORRECTION_IDENT" VARCHAR2(20), 
	"CORRECTION_ACT_TYPE_CD" VARCHAR2(50), 
	"CORRECTION_COMMENT_TXT" VARCHAR2(200), 
	"CORRECTION_INSP_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_CORRECTION"  IS 'Schema element: CorrectionDetailType';
--------------------------------------------------------
--  DDL for Table UIC_ENFORCEMENT
--------------------------------------------------------

  CREATE TABLE "UIC_ENFORCEMENT" 
   (	"ENFORCEMENT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"ENFORCEMENT_IDENT" VARCHAR2(20), 
	"ENFORCEMENT_ACT_DATE" VARCHAR2(8), 
	"ENFORCEMENT_ACT_TYPE" VARCHAR2(3)
   ) ;
 

   COMMENT ON TABLE "UIC_ENFORCEMENT"  IS 'Schema element: EnforcementDetailType';
--------------------------------------------------------
--  DDL for Table UIC_ENGINEERING
--------------------------------------------------------

  CREATE TABLE "UIC_ENGINEERING" 
   (	"ENGR_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"ENGR_IDENT" VARCHAR2(20), 
	"ENGR_MAX_FLOW_RATE_NUM" VARCHAR2(20), 
	"ENGR_PERM_ONSITE_INJ_VOL_NUM" VARCHAR2(20), 
	"ENGR_PERM_OFFSITE_INJ_VOL_NUM" VARCHAR2(20), 
	"ENGR_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_ENGINEERING"  IS 'Schema element: EngineeringDetailType';
--------------------------------------------------------
--  DDL for Table UIC_FACILITY
--------------------------------------------------------

  CREATE TABLE "UIC_FACILITY" 
   (	"FACILITY_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"FACILITY_IDENT" VARCHAR2(20), 
	"LOCALITY_NAME" VARCHAR2(60), 
	"FACILITY_SITE_NAME" VARCHAR2(80), 
	"FACILITY_PETITION_STATUS_CD" VARCHAR2(50), 
	"LOC_ADDRESS_STATE_CD" VARCHAR2(10), 
	"FACILITY_STATE_IDENT" VARCHAR2(50), 
	"LOC_ADDRESS_TXT" VARCHAR2(150), 
	"FACILITY_SITE_TYPE_CD" VARCHAR2(50), 
	"NAICS_CD" VARCHAR2(6), 
	"SIC_CD" VARCHAR2(4), 
	"LOC_ADDRESS_POSTAL_CD" VARCHAR2(14)
   ) ;
 

   COMMENT ON TABLE "UIC_FACILITY"  IS 'Schema element: FacilityDetailType';
--------------------------------------------------------
--  DDL for Table UIC_GEOLOGY
--------------------------------------------------------

  CREATE TABLE "UIC_GEOLOGY" 
   (	"GEO_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"GEO_IDENT" VARCHAR2(20), 
	"GEO_CONF_ZN_NAME" VARCHAR2(100), 
	"GEO_CONF_ZN_TOP_NUM" VARCHAR2(20), 
	"GEO_CONF_ZN_BOT_NUM" VARCHAR2(20), 
	"GEO_LITH_CONF_ZN_TXT" VARCHAR2(100), 
	"GEO_INJ_ZN_FORMATION_NAME" VARCHAR2(100), 
	"GEO_BOT_INJ_ZN_NUM" VARCHAR2(20), 
	"GEO_LITH_INJ_ZN_TXT" VARCHAR2(100), 
	"GEO_TOP_INJ_INTERVAL_NUM" VARCHAR2(20), 
	"GEO_BOT_INJ_INTERVAL_NUM" VARCHAR2(20), 
	"GEO_INJ_ZN_PERM_RATE_NUM" VARCHAR2(20), 
	"GEO_INJ_ZN_POR_PCNT_NUM" VARCHAR2(20), 
	"GEO_USDW_DEPTH_NUM" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_GEOLOGY"  IS 'Schema element: GeologyDetailType';
--------------------------------------------------------
--  DDL for Table UIC_INSPECTION
--------------------------------------------------------

  CREATE TABLE "UIC_INSPECTION" 
   (	"INSP_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"INSP_IDENT" VARCHAR2(20), 
	"INSP_ASSISTANCE_CD" VARCHAR2(50), 
	"INSP_DEFICIENCY_CD" VARCHAR2(50), 
	"INSP_ACT_DATE" VARCHAR2(8), 
	"INSP_ICIS_COMPL_MONTR_RSN_CD" VARCHAR2(50), 
	"INSP_ICIS_COMPL_MONTR_TYPE_CD" VARCHAR2(50), 
	"INSP_ICIS_COMPL_ACT_TYPE_CD" VARCHAR2(50), 
	"INSP_ICIS_MOA_NAME" VARCHAR2(50), 
	"INSP_ICIS_RGN_PRI_NAME" VARCHAR2(12), 
	"INSP_TYPE_ACT_CD" VARCHAR2(2), 
	"INSP_WELL_IDENT" VARCHAR2(20), 
	"INSP_FACILITY_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_INSPECTION"  IS 'Schema element: InspectionDetailType';
--------------------------------------------------------
--  DDL for Table UIC_LOCATION
--------------------------------------------------------

  CREATE TABLE "UIC_LOCATION" 
   (	"LOC_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"LOC_IDENT" VARCHAR2(20), 
	"LOC_ADDRESS_COUNTY" VARCHAR2(35), 
	"LOC_ACCURACY_VALUE_MEASURE" VARCHAR2(20), 
	"GEO_REF_PT_CD" VARCHAR2(50), 
	"HORZ_COORD_REF_SYS_DATUM_CD" VARCHAR2(50), 
	"HORZ_COLLECTION_METHOD_CD" VARCHAR2(50), 
	"LOC_PT_LINE_AREA_CD" VARCHAR2(50), 
	"SRC_MAP_SCALE_NUM" VARCHAR2(50), 
	"LOC_WELL_IDENT" VARCHAR2(20), 
	"LATITUDE_MEASURE" VARCHAR2(20), 
	"LONGITUDE_MEASURE" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_LOCATION"  IS 'Schema element: LocationDetailType';
--------------------------------------------------------
--  DDL for Table UIC_MI_TEST
--------------------------------------------------------

  CREATE TABLE "UIC_MI_TEST" 
   (	"MI_TST_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"MECH_INTEG_TST_IDENT" VARCHAR2(20), 
	"MECH_INTEG_TST_COMPLETED_DATE" VARCHAR2(8), 
	"MECH_INTEG_TST_RESULT_CD" VARCHAR2(2), 
	"MECH_INTEG_TST_TYPE_CD" VARCHAR2(2), 
	"MECH_INTEG_TST_REM_ACT_DATE" VARCHAR2(8), 
	"MECH_INTEG_TST_REM_ACT_TYPE_CD" VARCHAR2(50), 
	"MECH_INTEG_TST_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_MI_TEST"  IS 'Schema element: MITestDetailType';
--------------------------------------------------------
--  DDL for Table UIC_ORG
--------------------------------------------------------

  CREATE TABLE "UIC_ORG" 
   (	"ORG_ID" VARCHAR2(4), 
	"ORG_NAME" VARCHAR2(255)
   ) ;
 

   COMMENT ON TABLE "UIC_ORG"  IS 'Schema element: UICDataType';
--------------------------------------------------------
--  DDL for Table UIC_PERMIT
--------------------------------------------------------

  CREATE TABLE "UIC_PERMIT" 
   (	"PERMIT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"PERMIT_IDENT" VARCHAR2(20), 
	"PERMIT_AOR_WELL_NUMBER_NUM" VARCHAR2(20), 
	"PERMIT_AUTHORIZED_STATUS_CD" VARCHAR2(2), 
	"PERMIT_OWNERSHIP_TYPE_CD" VARCHAR2(50), 
	"PERMIT_AUTHORIZED_IDENT" VARCHAR2(50)
   ) ;
 

   COMMENT ON TABLE "UIC_PERMIT"  IS 'Schema element: PermitDetailType';
--------------------------------------------------------
--  DDL for Table UIC_PERMIT_ACTIVITY
--------------------------------------------------------

  CREATE TABLE "UIC_PERMIT_ACTIVITY" 
   (	"PERMIT_ACT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"PERMIT_ACT_IDENT" VARCHAR2(20), 
	"PERMIT_ACT_ACT_TYPE_CD" VARCHAR2(2), 
	"PERMIT_ACT_DATE" VARCHAR2(8), 
	"PERMIT_ACT_PERMIT_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_PERMIT_ACTIVITY"  IS 'Schema element: PermitActivityDetailType';
--------------------------------------------------------
--  DDL for Table UIC_RESPONSE
--------------------------------------------------------

  CREATE TABLE "UIC_RESPONSE" 
   (	"RESPONSE_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"RESPONSE_ENFORCEMENT_IDENT" VARCHAR2(20), 
	"RESPONSE_VIOLATION_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_RESPONSE"  IS 'Schema element: ResponseDetailDataType';
--------------------------------------------------------
--  DDL for Table UIC_VIOLATION
--------------------------------------------------------

  CREATE TABLE "UIC_VIOLATION" 
   (	"VIOLATION_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"VIOLATION_IDENT" VARCHAR2(20), 
	"VIOLATION_CONTAMINATION_CD" VARCHAR2(50), 
	"VIOLATION_ENDANGERING_CD" VARCHAR2(50), 
	"VIOLATION_RTN_COMPL_DATE" VARCHAR2(8), 
	"VIOLATION_SIGNIFICANT_CD" VARCHAR2(50), 
	"VIOLATION_DETERMINED_DATE" VARCHAR2(8), 
	"VIOLATION_TYPE_CD" VARCHAR2(2), 
	"VIOLATION_WELL_IDENT" VARCHAR2(20), 
	"VIOLATION_FACILITY_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_VIOLATION"  IS 'Schema element: ViolationDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WASTE
--------------------------------------------------------

  CREATE TABLE "UIC_WASTE" 
   (	"WASTE_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"WASTE_IDENT" VARCHAR2(20), 
	"WASTE_CD" VARCHAR2(4), 
	"WASTE_STREAM_CLASSIFICATION_CD" VARCHAR2(100), 
	"WASTE_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_WASTE"  IS 'Schema element: WasteDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL
--------------------------------------------------------

  CREATE TABLE "UIC_WELL" 
   (	"WELL_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"WELL_IDENT" VARCHAR2(20), 
	"WELL_AQUIF_EXEMPT_INJ_CD" VARCHAR2(50), 
	"WELL_TOTAL_DEPTH_NUM" VARCHAR2(20), 
	"WELL_HI_PRI_DESIGNATION_CD" VARCHAR2(50), 
	"WELL_CONTACT_IDENT" VARCHAR2(20), 
	"WELL_FACILITY_IDENT" VARCHAR2(20), 
	"WELL_GEO_IDENT" VARCHAR2(20), 
	"WELL_SITE_AREA_NAME_TXT" VARCHAR2(50), 
	"WELL_PERMIT_IDENT" VARCHAR2(20), 
	"WELL_STATE_IDENT" VARCHAR2(50), 
	"WELL_STATE_TRIBAL_CD" VARCHAR2(3), 
	"WELL_IN_SRC_WATER_AREA_LOC_TXT" VARCHAR2(1), 
	"WELL_NAME" VARCHAR2(80)
   ) ;
 

   COMMENT ON TABLE "UIC_WELL"  IS 'Schema element: WellDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_STATUS
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_STATUS" 
   (	"WELL_STATUS_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"WELL_STATUS_IDENT" VARCHAR2(20), 
	"WELL_STATUS_DATE" VARCHAR2(8), 
	"WELL_STATUS_OPER_STATUS_CD" VARCHAR2(2), 
	"WELL_STATUS_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_WELL_STATUS"  IS 'Schema element: WellStatusDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_TYPE
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_TYPE" 
   (	"WELL_TYPE_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"WELL_TYPE_IDENT" VARCHAR2(20), 
	"WELL_TYPE_CD" VARCHAR2(4), 
	"WELL_TYPE_DATE" VARCHAR2(8), 
	"WELL_TYPE_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON TABLE "UIC_WELL_TYPE"  IS 'Schema element: WellTypeDetailDataType';
--------------------------------------------------------
--  Constraints for Table UIC_FACILITY
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY" ADD CONSTRAINT "PK_UIC_FACILITY" PRIMARY KEY ("FACILITY_ID") ENABLE;
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("FACILITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("FACILITY_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("FACILITY_SITE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("FACILITY_STATE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("LOC_ADDRESS_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY" MODIFY ("LOC_ADDRESS_POSTAL_CD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_CONSTITUENT
--------------------------------------------------------

  ALTER TABLE "UIC_CONSTITUENT" ADD CONSTRAINT "PK_UIC_CONSTITUENT" PRIMARY KEY ("CONSTITUENT_ID") ENABLE;
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("CONSTITUENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("CONSTITUENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("CONSTITUENT_WASTE_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_GEOLOGY
--------------------------------------------------------

  ALTER TABLE "UIC_GEOLOGY" ADD CONSTRAINT "PK_UIC_GEOLOGY" PRIMARY KEY ("GEO_ID") ENABLE;
 
  ALTER TABLE "UIC_GEOLOGY" MODIFY ("GEO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_GEOLOGY" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_GEOLOGY" MODIFY ("GEO_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_LOCATION
--------------------------------------------------------

  ALTER TABLE "UIC_LOCATION" ADD CONSTRAINT "PK_UIC_LOCATION" PRIMARY KEY ("LOC_ID") ENABLE;
 
  ALTER TABLE "UIC_LOCATION" MODIFY ("LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_LOCATION" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_LOCATION" MODIFY ("LOC_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_LOCATION" MODIFY ("LOC_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_CORRECTION
--------------------------------------------------------

  ALTER TABLE "UIC_CORRECTION" ADD CONSTRAINT "PK_UIC_CORRECTION" PRIMARY KEY ("CORRECTION_ID") ENABLE;
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("CORRECTION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("CORRECTION_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("CORRECTION_INSP_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_CONTACT
--------------------------------------------------------

  ALTER TABLE "UIC_CONTACT" ADD CONSTRAINT "PK_UIC_CONTACT" PRIMARY KEY ("CONTACT_ID") ENABLE;
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("INDIVIDUAL_FULL_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_ADDRESS_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_ADDRESS_POSTAL_CD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_STATUS
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_STATUS" ADD CONSTRAINT "PK_UIC_WELL_STATUS" PRIMARY KEY ("WELL_STATUS_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_OPER_STATUS_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WASTE
--------------------------------------------------------

  ALTER TABLE "UIC_WASTE" ADD CONSTRAINT "PK_UIC_WASTE" PRIMARY KEY ("WASTE_ID") ENABLE;
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WASTE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WASTE" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WASTE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WASTE_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_MI_TEST
--------------------------------------------------------

  ALTER TABLE "UIC_MI_TEST" ADD CONSTRAINT "PK_UIC_MI_TEST" PRIMARY KEY ("MI_TST_ID") ENABLE;
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MI_TST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_COMPLETED_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_RESULT_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_TYPE
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_TYPE" ADD CONSTRAINT "PK_UIC_WELL_TYPE" PRIMARY KEY ("WELL_TYPE_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL
--------------------------------------------------------

  ALTER TABLE "UIC_WELL" ADD CONSTRAINT "PK_UIC_WELL" PRIMARY KEY ("WELL_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_CONTACT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_FACILITY_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_PERMIT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_STATE_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_RESPONSE
--------------------------------------------------------

  ALTER TABLE "UIC_RESPONSE" ADD CONSTRAINT "PK_UIC_RESPONSE" PRIMARY KEY ("RESPONSE_ID") ENABLE;
 
  ALTER TABLE "UIC_RESPONSE" MODIFY ("RESPONSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_RESPONSE" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_RESPONSE" MODIFY ("RESPONSE_ENFORCEMENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_RESPONSE" MODIFY ("RESPONSE_VIOLATION_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_PERMIT
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT" ADD CONSTRAINT "PK_UIC_PERMIT" PRIMARY KEY ("PERMIT_ID") ENABLE;
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_AUTHORIZED_STATUS_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_AUTHORIZED_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_ENGINEERING
--------------------------------------------------------

  ALTER TABLE "UIC_ENGINEERING" ADD CONSTRAINT "PK_UIC_ENGINEERING" PRIMARY KEY ("ENGR_ID") ENABLE;
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ENGR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ENGR_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ENGR_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_INSPECTION
--------------------------------------------------------

  ALTER TABLE "UIC_INSPECTION" ADD CONSTRAINT "PK_UIC_INSPECTION" PRIMARY KEY ("INSP_ID") ENABLE;
 
  ALTER TABLE "UIC_INSPECTION" MODIFY ("INSP_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_INSPECTION" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_INSPECTION" MODIFY ("INSP_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_INSPECTION" MODIFY ("INSP_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_INSPECTION" MODIFY ("INSP_TYPE_ACT_CD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_PERMIT_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT_ACTIVITY" ADD CONSTRAINT "PK_UIC_PERMI_ACTIV" PRIMARY KEY ("PERMIT_ACT_ID") ENABLE;
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_ACT_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_PERMIT_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_ENFORCEMENT
--------------------------------------------------------

  ALTER TABLE "UIC_ENFORCEMENT" ADD CONSTRAINT "PK_UIC_ENFORCEMENT" PRIMARY KEY ("ENFORCEMENT_ID") ENABLE;
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_ACT_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_ORG
--------------------------------------------------------

  ALTER TABLE "UIC_ORG" ADD CONSTRAINT "PK_UIC_ORG" PRIMARY KEY ("ORG_ID") ENABLE;
 
  ALTER TABLE "UIC_ORG" MODIFY ("ORG_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_VIOLATION
--------------------------------------------------------

  ALTER TABLE "UIC_VIOLATION" ADD CONSTRAINT "PK_UIC_VIOLATION" PRIMARY KEY ("VIOLATION_ID") ENABLE;
 
  ALTER TABLE "UIC_VIOLATION" MODIFY ("VIOLATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_VIOLATION" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_VIOLATION" MODIFY ("VIOLATION_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_VIOLATION" MODIFY ("VIOLATION_DETERMINED_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_VIOLATION" MODIFY ("VIOLATION_TYPE_CD" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_UIC_ENGINEERING
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_ENGINEERING" ON "UIC_ENGINEERING" ("ENGR_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_FACILITY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_FACILITY" ON "UIC_FACILITY" ("FACILITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_RESPONSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_RESPONSE" ON "UIC_RESPONSE" ("RESPONSE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_INSPECTION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_INSPECTION" ON "UIC_INSPECTION" ("INSP_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_PE_AC_OR_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_PE_AC_OR_ID" ON "UIC_PERMIT_ACTIVITY" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_ENFORCEMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_ENFORCEMENT" ON "UIC_ENFORCEMENT" ("ENFORCEMENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_WASTE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_WASTE" ON "UIC_WASTE" ("WASTE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_VIOL_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_VIOL_ORG_ID" ON "UIC_VIOLATION" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_CONTACT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_CONTACT" ON "UIC_CONTACT" ("CONTACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_CORRECTION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_CORRECTION" ON "UIC_CORRECTION" ("CORRECTION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_CONT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_CONT_ORG_ID" ON "UIC_CONTACT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_FACI_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_FACI_ORG_ID" ON "UIC_FACILITY" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_RESP_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_RESP_ORG_ID" ON "UIC_RESPONSE" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_CONS_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_CONS_ORG_ID" ON "UIC_CONSTITUENT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_ORG" ON "UIC_ORG" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_WE_TY_OR_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_WE_TY_OR_ID" ON "UIC_WELL_TYPE" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_CORR_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_CORR_ORG_ID" ON "UIC_CORRECTION" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_GEOLOGY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_GEOLOGY" ON "UIC_GEOLOGY" ("GEO_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_ENGI_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_ENGI_ORG_ID" ON "UIC_ENGINEERING" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_LOCATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_LOCATION" ON "UIC_LOCATION" ("LOC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_PERM_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_PERM_ORG_ID" ON "UIC_PERMIT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_WELL_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_WELL_ORG_ID" ON "UIC_WELL" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_CONSTITUENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_CONSTITUENT" ON "UIC_CONSTITUENT" ("CONSTITUENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_LOCA_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_LOCA_ORG_ID" ON "UIC_LOCATION" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_MI_TEST
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_MI_TEST" ON "UIC_MI_TEST" ("MI_TST_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_WE_ST_OR_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_WE_ST_OR_ID" ON "UIC_WELL_STATUS" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_WELL_STATUS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_WELL_STATUS" ON "UIC_WELL_STATUS" ("WELL_STATUS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_WELL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_WELL" ON "UIC_WELL" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_INSP_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_INSP_ORG_ID" ON "UIC_INSPECTION" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_WAST_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_WAST_ORG_ID" ON "UIC_WASTE" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_MI_TE_OR_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_MI_TE_OR_ID" ON "UIC_MI_TEST" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_PERMIT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_PERMIT" ON "UIC_PERMIT" ("PERMIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_WELL_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_WELL_TYPE" ON "UIC_WELL_TYPE" ("WELL_TYPE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_VIOLATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_VIOLATION" ON "UIC_VIOLATION" ("VIOLATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_ENFO_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_ENFO_ORG_ID" ON "UIC_ENFORCEMENT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_UIC_GEOL_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_UIC_GEOL_ORG_ID" ON "UIC_GEOLOGY" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_UIC_PERMI_ACTIV
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_UIC_PERMI_ACTIV" ON "UIC_PERMIT_ACTIVITY" ("PERMIT_ACT_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table UIC_CONSTITUENT
--------------------------------------------------------

  ALTER TABLE "UIC_CONSTITUENT" ADD CONSTRAINT "FK_UIC_CON_UIC_O02" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_CONTACT
--------------------------------------------------------

  ALTER TABLE "UIC_CONTACT" ADD CONSTRAINT "FK_UIC_CON_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_CORRECTION
--------------------------------------------------------

  ALTER TABLE "UIC_CORRECTION" ADD CONSTRAINT "FK_UIC_COR_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_ENFORCEMENT
--------------------------------------------------------

  ALTER TABLE "UIC_ENFORCEMENT" ADD CONSTRAINT "FK_UIC_ENF_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_ENGINEERING
--------------------------------------------------------

  ALTER TABLE "UIC_ENGINEERING" ADD CONSTRAINT "FK_UIC_ENG_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_FACILITY
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY" ADD CONSTRAINT "FK_UIC_FAC_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_GEOLOGY
--------------------------------------------------------

  ALTER TABLE "UIC_GEOLOGY" ADD CONSTRAINT "FK_UIC_GEO_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_INSPECTION
--------------------------------------------------------

  ALTER TABLE "UIC_INSPECTION" ADD CONSTRAINT "FK_UIC_INS_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_LOCATION
--------------------------------------------------------

  ALTER TABLE "UIC_LOCATION" ADD CONSTRAINT "FK_UIC_LOC_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_MI_TEST
--------------------------------------------------------

  ALTER TABLE "UIC_MI_TEST" ADD CONSTRAINT "FK_UIC_MI_TE_UI_OR" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table UIC_PERMIT
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT" ADD CONSTRAINT "FK_UIC_PER_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_PERMIT_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT_ACTIVITY" ADD CONSTRAINT "FK_UIC_PE_AC_UI_OR" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_RESPONSE
--------------------------------------------------------

  ALTER TABLE "UIC_RESPONSE" ADD CONSTRAINT "FK_UIC_RES_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_VIOLATION
--------------------------------------------------------

  ALTER TABLE "UIC_VIOLATION" ADD CONSTRAINT "FK_UIC_VIO_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WASTE
--------------------------------------------------------

  ALTER TABLE "UIC_WASTE" ADD CONSTRAINT "FK_UIC_WAS_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL
--------------------------------------------------------

  ALTER TABLE "UIC_WELL" ADD CONSTRAINT "FK_UIC_WEL_UIC_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_STATUS
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_STATUS" ADD CONSTRAINT "FK_UIC_WE_ST_UI_OR" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_TYPE
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_TYPE" ADD CONSTRAINT "FK_UIC_WE_TY_UI_OR" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
