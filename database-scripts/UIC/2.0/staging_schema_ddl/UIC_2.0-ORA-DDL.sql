--------------------------------------------------------
--  File created - Wednesday-April-06-2011   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table UIC_CONSTITUENT
--------------------------------------------------------

  CREATE TABLE "UIC_CONSTITUENT" 
   (	"CONSTITUENT_ID" VARCHAR2(40), 
	"WASTE_ID" VARCHAR2(40), 
	"CONSTITUENT_IDENT" VARCHAR2(20), 
	"MEASURE_VALUE" VARCHAR2(20), 
	"MEASURE_UNIT_CD" VARCHAR2(50), 
	"CONSTITUENT_NAME_TXT" VARCHAR2(255), 
	"CONSTITUENT_WASTE_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_CONSTITUENT"."CONSTITUENT_ID" IS 'Parent: Container for Constituent information. (_PK)';
 
   COMMENT ON COLUMN "UIC_CONSTITUENT"."WASTE_ID" IS 'Parent: Container for Constituent information. (_FK)';
 
   COMMENT ON COLUMN "UIC_CONSTITUENT"."CONSTITUENT_IDENT" IS 'Unique identification of Constituent  table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying constituent information (e.g. WYEQ0000000000 000389, ?). (ConstituentIdentifier)';
 
   COMMENT ON COLUMN "UIC_CONSTITUENT"."MEASURE_VALUE" IS 'The concentration of the individual waste constituent as reported by EPA Regional staff and/or state agency staff (measured in mg/l or pCi/l). (MeasureValue)';
 
   COMMENT ON COLUMN "UIC_CONSTITUENT"."MEASURE_UNIT_CD" IS 'Unit of measuring concentration (mg/l or pCi/l). (MeasureUnitCode)';
 
   COMMENT ON COLUMN "UIC_CONSTITUENT"."CONSTITUENT_NAME_TXT" IS 'The chemical name or a description of the waste, in accordance with EPA Chemical/Biological Internal Tracking Name (http://www.epa.gov/srs/). (ConstituentNameText)';
 
   COMMENT ON COLUMN "UIC_CONSTITUENT"."CONSTITUENT_WASTE_IDENT" IS 'Unique identification for waste records. (ConstituentWasteIdentifier)';
 
   COMMENT ON TABLE "UIC_CONSTITUENT"  IS 'Schema element: ConstituentDetailType';
--------------------------------------------------------
--  DDL for Table UIC_CONTACT
--------------------------------------------------------

  CREATE TABLE "UIC_CONTACT" 
   (	"CONTACT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"CONTACT_IDENT" VARCHAR2(20), 
	"TELEPHONE_NUMBER_TXT" VARCHAR2(20), 
	"INDIVIDUAL_FULL_NAME" VARCHAR2(70), 
	"CONTACT_CITY_NAME" VARCHAR2(50), 
	"CONTACT_ADDRESS_STATE_CD" VARCHAR2(20), 
	"CONTACT_ADDRESS_TXT" VARCHAR2(150), 
	"CONTACT_ADDRESS_POSTAL_CD" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_CONTACT"."CONTACT_ID" IS 'Parent: Container for Contact information. (_PK)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."ORG_ID" IS 'Parent: Container for Contact information. (_FK)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."CONTACT_IDENT" IS 'Unique identification of Contact table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique contact for a well. (e.g. NMNR30005003490000). (ContactIdentifier)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."TELEPHONE_NUMBER_TXT" IS 'The phone number of a contact for the well. (TelephoneNumberText)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."INDIVIDUAL_FULL_NAME" IS 'The legal and complete name of a contact person (including first name, middle name or initial, and surname) for the well. (IndividualFullName)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."CONTACT_CITY_NAME" IS 'The name of the city, town, or village of the contact for a well. (ContactCityName)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."CONTACT_ADDRESS_STATE_CD" IS 'The name of the state where the contact is located or the name of the country, if outside the U.S.  (ContactAddressStateCode)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."CONTACT_ADDRESS_TXT" IS 'The street address of the contact for a well.  This can be physical location or a mailing address. (ContactAddressText)';
 
   COMMENT ON COLUMN "UIC_CONTACT"."CONTACT_ADDRESS_POSTAL_CD" IS 'The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.  (ContactAddressPostalCode)';
 
   COMMENT ON TABLE "UIC_CONTACT"  IS 'Schema element: ContactDetailType';
--------------------------------------------------------
--  DDL for Table UIC_CORRECTION
--------------------------------------------------------

  CREATE TABLE "UIC_CORRECTION" 
   (	"CORRECTION_ID" VARCHAR2(40), 
	"WELL_INSPECTION_ID" VARCHAR2(40), 
	"CORRECTION_IDENT" VARCHAR2(20), 
	"CORRECTION_ACT_TYPE_CD" VARCHAR2(50), 
	"CORRECTION_COMMENT_TXT" VARCHAR2(255), 
	"CORRECTION_INSP_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_CORRECTION"."CORRECTION_ID" IS 'Parent: Container for Correction information. (_PK)';
 
   COMMENT ON COLUMN "UIC_CORRECTION"."WELL_INSPECTION_ID" IS 'Parent: Container for Correction information. (_FK)';
 
   COMMENT ON COLUMN "UIC_CORRECTION"."CORRECTION_IDENT" IS 'Unique identification of Correction table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only identifying the unique  corrective action (e.g. 04DI00000139, ?). (CorrectionIdentifier)';
 
   COMMENT ON COLUMN "UIC_CORRECTION"."CORRECTION_ACT_TYPE_CD" IS 'Type of actions taken to correct deficiencies. (CorrectionActionTypeCode)';
 
   COMMENT ON COLUMN "UIC_CORRECTION"."CORRECTION_COMMENT_TXT" IS 'Narrative description of actions taken by the facility or assistance to help the facility come into compliance. (CorrectionCommentText)';
 
   COMMENT ON COLUMN "UIC_CORRECTION"."CORRECTION_INSP_IDENT" IS 'The unique identification of Inspection table. (CorrectionInspectionIdentifier)';
 
   COMMENT ON TABLE "UIC_CORRECTION"  IS 'Schema element: CorrectionDetailType';
--------------------------------------------------------
--  DDL for Table UIC_ENFORCEMENT
--------------------------------------------------------

  CREATE TABLE "UIC_ENFORCEMENT" 
   (	"ENFORCEMENT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"ENFORCEMENT_IDENT" VARCHAR2(20), 
	"ENFORCEMENT_ACT_DATE" CHAR(8), 
	"ENFORCEMENT_ACT_TYPE" VARCHAR2(3)
   ) ;
 

   COMMENT ON COLUMN "UIC_ENFORCEMENT"."ENFORCEMENT_ID" IS 'Parent: Container for Enforcement information. (_PK)';
 
   COMMENT ON COLUMN "UIC_ENFORCEMENT"."ORG_ID" IS 'Parent: Container for Enforcement information. (_FK)';
 
   COMMENT ON COLUMN "UIC_ENFORCEMENT"."ENFORCEMENT_IDENT" IS 'Unique identification of Enforcement table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique  enforcement action (e.g. 08DI000566, ?). (EnforcementIdentifier)';
 
   COMMENT ON COLUMN "UIC_ENFORCEMENT"."ENFORCEMENT_ACT_DATE" IS 'The calendar date the enforcement action was issued or filed (YYYYMMDD). (EnforcementActionDate)';
 
   COMMENT ON COLUMN "UIC_ENFORCEMENT"."ENFORCEMENT_ACT_TYPE" IS 'The type of enforcement action taken by the EPA or states. (EnforcementActionType)';
 
   COMMENT ON TABLE "UIC_ENFORCEMENT"  IS 'Schema element: EnforcementDetailType';
--------------------------------------------------------
--  DDL for Table UIC_ENGINEERING
--------------------------------------------------------

  CREATE TABLE "UIC_ENGINEERING" 
   (	"ENGINEERING_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"ENGR_IDENT" VARCHAR2(20), 
	"ENGR_MAX_FLOW_RATE_NUM" VARCHAR2(20), 
	"ENGR_PERM_ONSITE_INJ_VOL_NUM" VARCHAR2(20), 
	"ENGR_PERM_OFFSITE_INJ_VOL_NUM" VARCHAR2(20), 
	"ENGR_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_ENGINEERING"."ENGINEERING_ID" IS 'Parent: Container for Engineering information. (_PK)';
 
   COMMENT ON COLUMN "UIC_ENGINEERING"."WELL_ID" IS 'Parent: Container for Engineering information. (_FK)';
 
   COMMENT ON COLUMN "UIC_ENGINEERING"."ENGR_IDENT" IS 'Unique identification of Engineering table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only identifying unique engineering information  (e.g. WYEQ00000543, ?). (EngineeringIdentifier)';
 
   COMMENT ON COLUMN "UIC_ENGINEERING"."ENGR_MAX_FLOW_RATE_NUM" IS 'Maximum flow rate of injectate in the current quartermeasured in gallons per minute. (EngineeringMaximumFlowRateNumeric)';
 
   COMMENT ON COLUMN "UIC_ENGINEERING"."ENGR_PERM_ONSITE_INJ_VOL_NUM" IS 'Permitted on-site injected volume measured in million gallon per month. (EngineeringPermittedOnsiteInjectionVolumeNumeric)';
 
   COMMENT ON COLUMN "UIC_ENGINEERING"."ENGR_PERM_OFFSITE_INJ_VOL_NUM" IS 'Permitted off-site injected volume measured in million gallon per month. (EngineeringPermittedOffsiteInjectionVolumeNumeric)';
 
   COMMENT ON COLUMN "UIC_ENGINEERING"."ENGR_WELL_IDENT" IS 'Unique identification of an injection well. (EngineeringWellIdentifier)';
 
   COMMENT ON TABLE "UIC_ENGINEERING"  IS 'Schema element: EngineeringDetailType';
--------------------------------------------------------
--  DDL for Table UIC_FACILITY
--------------------------------------------------------

  CREATE TABLE "UIC_FACILITY" 
   (	"FACILITY_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"FACILITY_IDENT" VARCHAR2(20), 
	"LOCALITY_NAME" VARCHAR2(128), 
	"FACILITY_SITE_NAME" VARCHAR2(80), 
	"FACILITY_PETITION_STATUS_CD" VARCHAR2(128), 
	"LOC_ADDRESS_STATE_CD" VARCHAR2(128), 
	"FACILITY_STATE_IDENT" VARCHAR2(50), 
	"LOC_ADDRESS_TXT" VARCHAR2(150), 
	"FACILITY_SITE_TYPE_CD" VARCHAR2(128), 
	"NAICS_CD" VARCHAR2(128), 
	"SIC_CD" VARCHAR2(128), 
	"LOC_ADDRESS_POSTAL_CD" VARCHAR2(14)
   ) ;
 

   COMMENT ON COLUMN "UIC_FACILITY"."FACILITY_ID" IS 'Parent: Container for multiple Facility information submissions. (_PK)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."ORG_ID" IS 'Parent: Container for multiple Facility information submissions. (_FK)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."FACILITY_IDENT" IS 'Unique identification of Facility table - The first four characters are the primacy agency code (appendix D).  The rest is DI program or State?s choice (letters and numbers only) identifying unique facility (e.g. DENR0000197590, ?). (FacilityIdentifier)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."LOCALITY_NAME" IS 'The name of the city, town, or village where the facility is located. (LocalityName)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."FACILITY_SITE_NAME" IS 'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."FACILITY_PETITION_STATUS_CD" IS 'Status of review of no-migration petition (this is a technical demonstration required before Class I hazardous waste injection facilities may begin operating). (FacilityPetitionStatusCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."LOC_ADDRESS_STATE_CD" IS 'The U.S. Postal Service abbreviation that represents the state. (LocationAddressStateCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."FACILITY_STATE_IDENT" IS 'Facility identification assigned by DI program or primacy state. (FacilityStateIdentifier)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."LOC_ADDRESS_TXT" IS 'The address that describes the physical (geographic) location of the main entrance of a facility site, including urban-style street address or rural address, well field entrance, etc. (LocationAddressText)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."FACILITY_SITE_TYPE_CD" IS 'Class I well waste is disposed in either of two types of facilities: (1) Commercial- where the waste is generated offsite but transported to the disposal facility, or (2) Non-commercial-where the waste is generated onsite and disposed there also. (FacilitySiteTypeCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."NAICS_CD" IS 'The NAICS code that represents a subdivision of an industry that accommodates user needs in the United States (6-digits)--(Only primary code). (NAICSCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."SIC_CD" IS 'The code that represents the economic activity of a company (4-digits)--(only the primary code). (SICCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY"."LOC_ADDRESS_POSTAL_CD" IS 'The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location. (LocationAddressPostalCode)';
 
   COMMENT ON TABLE "UIC_FACILITY"  IS 'Schema element: FacilityListType';
--------------------------------------------------------
--  DDL for Table UIC_FACILITY_INSPECTION
--------------------------------------------------------

  CREATE TABLE "UIC_FACILITY_INSPECTION" 
   (	"FACILITY_INSPECTION_ID" VARCHAR2(40), 
	"FACILITY_ID" VARCHAR2(40), 
	"INSP_IDENT" VARCHAR2(20), 
	"INSP_ACT_DATE" CHAR(8), 
	"INSP_TYPE_ACT_CD" CHAR(2), 
	"INSP_FACILITY_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_FACILITY_INSPECTION"."FACILITY_INSPECTION_ID" IS 'Parent: Container for Facility Inspection information. (_PK)';
 
   COMMENT ON COLUMN "UIC_FACILITY_INSPECTION"."FACILITY_ID" IS 'Parent: Container for Facility Inspection information. (_FK)';
 
   COMMENT ON COLUMN "UIC_FACILITY_INSPECTION"."INSP_IDENT" IS 'Unique identification of Inspection table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique  inspection (e.g. WYEQ00 000566, ?). (InspectionIdentifier)';
 
   COMMENT ON COLUMN "UIC_FACILITY_INSPECTION"."INSP_ACT_DATE" IS 'The date inspection action was completed (YYYYMMDD). (InspectionActionDate)';
 
   COMMENT ON COLUMN "UIC_FACILITY_INSPECTION"."INSP_TYPE_ACT_CD" IS 'The type of inspection action that was conducted. (InspectionTypeActionCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY_INSPECTION"."INSP_FACILITY_IDENT" IS 'Unique identification of Facility table- This field ONLY applies for Class V ?No Well? inspection. (InspectionFacilityIdentifier)';
 
   COMMENT ON TABLE "UIC_FACILITY_INSPECTION"  IS 'Schema element: FacilityInspectionDetailType';
--------------------------------------------------------
--  DDL for Table UIC_FACILITY_RESPONSE
--------------------------------------------------------

  CREATE TABLE "UIC_FACILITY_RESPONSE" 
   (	"FACILITY_RESPONSE_ID" VARCHAR2(40), 
	"FACILITY_VIOLATION_ID" VARCHAR2(40), 
	"RESPONSE_ENFORCEMENT_IDENT" VARCHAR2(20), 
	"RESPONSE_VIOLATION_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_FACILITY_RESPONSE"."FACILITY_RESPONSE_ID" IS 'Parent: Container for Response information. (_PK)';
 
   COMMENT ON COLUMN "UIC_FACILITY_RESPONSE"."FACILITY_VIOLATION_ID" IS 'Parent: Container for Response information. (_FK)';
 
   COMMENT ON COLUMN "UIC_FACILITY_RESPONSE"."RESPONSE_ENFORCEMENT_IDENT" IS 'Unique identification of Enforcement table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State?s choice (letters and numbers only identifying unique  enforcement action (e.g. 08DI000766, ?). (ResponseEnforcementIdentifier)';
 
   COMMENT ON COLUMN "UIC_FACILITY_RESPONSE"."RESPONSE_VIOLATION_IDENT" IS 'Unique identification of Violation table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State?s choice (letters and numbers only identifying unique violation (e.g. 08DI000905, ?). (ResponseViolationIdentifier)';
 
   COMMENT ON TABLE "UIC_FACILITY_RESPONSE"  IS 'Schema element: FacilityResponseDetailDataType';
--------------------------------------------------------
--  DDL for Table UIC_FACILITY_VIOLATION
--------------------------------------------------------

  CREATE TABLE "UIC_FACILITY_VIOLATION" 
   (	"FACILITY_VIOLATION_ID" VARCHAR2(40), 
	"FACILITY_ID" VARCHAR2(40), 
	"VIOLATION_IDENT" VARCHAR2(20), 
	"VIOLATION_CONTAMINATION_CD" VARCHAR2(128), 
	"VIOLATION_ENDANGERING_CD" VARCHAR2(128), 
	"VIOLATION_RTN_COMPL_DATE" CHAR(8), 
	"VIOLATION_SIGNIFICANT_CD" VARCHAR2(128), 
	"VIOLATION_DETERMINED_DATE" CHAR(8), 
	"VIOLATION_TYPE_CD" CHAR(2), 
	"VIOLATION_FACILITY_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."FACILITY_VIOLATION_ID" IS 'Parent: Container for Facility Violation information. (_PK)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."FACILITY_ID" IS 'Parent: Container for Facility Violation information. (_FK)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_IDENT" IS 'Unique identification of Violation table - The first four characters are the primacy agency code (appendix D).  The rest is DI program or State?s choice (letters and numbers only) identifying unique  violation (e.g. 08DI000366, ?). (ViolationIdentifier)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_CONTAMINATION_CD" IS 'Well in noncompliance has allegedly contaminated an underground source of drinking water (USDW) this year to date. (ViolationContaminationCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_ENDANGERING_CD" IS 'A violation that results in the well potentially or actually endangering the USDW.  The endangering fluid contaminant from the well is in violation of RCRA or SDWA or applicable regulations. (ViolationEndangeringCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_RTN_COMPL_DATE" IS 'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the violation determined date (YYYYMMDD). (ViolationReturnComplianceDate)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_SIGNIFICANT_CD" IS 'The indication whether or not the violation is in Significant Non-Compliance (SNC). (ViolationSignificantCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_DETERMINED_DATE" IS 'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation (YYYYMMDD). (ViolationDeterminedDate)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_TYPE_CD" IS 'The type of violation that is the subject of the Violation Date. (ViolationTypeCode)';
 
   COMMENT ON COLUMN "UIC_FACILITY_VIOLATION"."VIOLATION_FACILITY_IDENT" IS 'Unique identification of Facility table-  This field ONLY applies for Class V violations at FACILITY. (ViolationFacilityIdentifier)';
 
   COMMENT ON TABLE "UIC_FACILITY_VIOLATION"  IS 'Schema element: FacilityViolationDetailType';
--------------------------------------------------------
--  DDL for Table UIC_GEOLOGY
--------------------------------------------------------

  CREATE TABLE "UIC_GEOLOGY" 
   (	"GEOLOGY_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"GEO_IDENT" VARCHAR2(20), 
	"GEO_CONF_ZN_NAME" VARCHAR2(255), 
	"GEO_CONF_ZN_TOP_NUM" VARCHAR2(20), 
	"GEO_CONF_ZN_BOT_NUM" VARCHAR2(20), 
	"GEO_LITH_CONF_ZN_TXT" VARCHAR2(255), 
	"GEO_INJ_ZN_FORMATION_NAME" VARCHAR2(255), 
	"GEO_BOT_INJ_ZN_NUM" VARCHAR2(20), 
	"GEO_LITH_INJ_ZN_TXT" VARCHAR2(255), 
	"GEO_TOP_INJ_INTERVAL_NUM" VARCHAR2(20), 
	"GEO_BOT_INJ_INTERVAL_NUM" VARCHAR2(20), 
	"GEO_INJ_ZN_PERM_RATE_NUM" VARCHAR2(20), 
	"GEO_INJ_ZN_POR_PCNT_NUM" VARCHAR2(20), 
	"GEO_USDW_DEPTH_NUM" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_GEOLOGY"."GEOLOGY_ID" IS 'Parent: Container for Geology information. (_PK)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."ORG_ID" IS 'Parent: Container for Geology information. (_FK)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_IDENT" IS 'Unique identification of Geology table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique geology information (e.g. 04DI0000000000 000566, ?). (GeologyIdentifier)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_CONF_ZN_NAME" IS 'Geologic formation name. (GeologyConfiningZoneName)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_CONF_ZN_TOP_NUM" IS 'The top of the geologic arresting layer that keeps injectate confined in the injection zone measured in feet below surface. (GeologyConfiningZoneTopNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_CONF_ZN_BOT_NUM" IS 'The bottom of the geologic arresting layer that keeps injectate confined in the injection zone OR:The top of the vertical dimension of the zone in which waste is injected. -- measured in feet below surface. (GeologyConfiningZoneBottomNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_LITH_CONF_ZN_TXT" IS 'Confining zone data in the form of a simple lithologic description of the formation. (GeologyLithologicConfiningZoneText)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_INJ_ZN_FORMATION_NAME" IS 'Geologic formation name for injection zone. (GeologyInjectionZoneFormationName)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_BOT_INJ_ZN_NUM" IS 'The bottom of the vertical dimension of the zone in which waste is injected, measured in feet below surface. (GeologyBottomInjectionZoneNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_LITH_INJ_ZN_TXT" IS 'Injection zone data in the form of a simple lithologic description of the formation. (GeologyLithologicInjectionZoneText)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_TOP_INJ_INTERVAL_NUM" IS 'The top of the vertical dimension of the specific layer(s) of the Injection. (GeologyTopInjectionIntervalNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_BOT_INJ_INTERVAL_NUM" IS 'The bottom of the vertical dimension of the specific layer(s) of the Injection Zone in which waste is authorized to be injected into, measured in feet below surface. (GeologyBottomInjectionIntervalNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_INJ_ZN_PERM_RATE_NUM" IS 'The rate of diffusion of fluids (in this case liquid waste) under pressure through porous material (formation rock) that is measured in millidarcies (mD). (GeologyInjectioneZonePermeabilityRateNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_INJ_ZN_POR_PCNT_NUM" IS 'The percent of pore space the injection zone formation rock contains (measured in %). (GeologyInjectionZonePorosityPercentNumeric)';
 
   COMMENT ON COLUMN "UIC_GEOLOGY"."GEO_USDW_DEPTH_NUM" IS 'The depth (in feet) to the base of the underground source of drinking water (USDW). (GeologyUSDWDepthNumeric)';
 
   COMMENT ON TABLE "UIC_GEOLOGY"  IS 'Schema element: GeologyDetailType';
--------------------------------------------------------
--  DDL for Table UIC_MI_TEST
--------------------------------------------------------

  CREATE TABLE "UIC_MI_TEST" 
   (	"MI_TEST_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"MECH_INTEG_TST_IDENT" VARCHAR2(20), 
	"MECH_INTEG_TST_COMPLETED_DATE" CHAR(8), 
	"MECH_INTEG_TST_RESULT_CD" CHAR(2), 
	"MECH_INTEG_TST_TYPE_CD" CHAR(2), 
	"MECH_INTEG_TST_REM_ACT_DATE" CHAR(8), 
	"MECH_INTEG_TST_REM_ACT_TYPE_CD" VARCHAR2(50), 
	"MECH_INTEG_TST_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_MI_TEST"."MI_TEST_ID" IS 'Parent: Container for MI Test information. (_PK)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."WELL_ID" IS 'Parent: Container for MI Test information. (_FK)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_IDENT" IS 'Unique identification of Mechanical Integrity Test table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique MIT (e.g. 03DIVA000235, ?). (MechanicalIntegrityTestIdentifier)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_COMPLETED_DATE" IS 'The date that mechanical integrity test was completed (YYYYMMDD). (MechanicalIntegrityTestCompletedDate)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_RESULT_CD" IS 'The result of mechanical integrity test on that date (see above). (MechanicalIntegrityTestResultCode)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_TYPE_CD" IS 'Type of mechanical integrity test. (MechanicalIntegrityTestTypeCode)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_REM_ACT_DATE" IS 'The date (corresponding to Remedial Action Type) when a well that failed an MI test received successful remedial action (YYYYMMDD). (MechanicalIntegrityTestRemedialActionDate)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_REM_ACT_TYPE_CD" IS 'Type of successful remedial action that well has received on the remedial action date. (MechanicalIntegrityTestRemedialActionTypeCode)';
 
   COMMENT ON COLUMN "UIC_MI_TEST"."MECH_INTEG_TST_WELL_IDENT" IS 'Unique identification of Well table. (MechanicalIntegrityTestWellIdentifier)';
 
   COMMENT ON TABLE "UIC_MI_TEST"  IS 'Schema element: MITestDetailType';
--------------------------------------------------------
--  DDL for Table UIC_ORG
--------------------------------------------------------

  CREATE TABLE "UIC_ORG" 
   (	"ORG_ID" VARCHAR2(4), 
	"PRIMACY_AGENCY_CD" VARCHAR2(50), 
	"ORG_NAME" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "UIC_ORG"."PRIMACY_AGENCY_CD" IS '4 character code of the Primacy Agency making the submission. (PrimacyAgencyCode)';
 
   COMMENT ON TABLE "UIC_ORG"  IS 'Schema element: UICDataType';
--------------------------------------------------------
--  DDL for Table UIC_PERMIT
--------------------------------------------------------

  CREATE TABLE "UIC_PERMIT" 
   (	"PERMIT_ID" VARCHAR2(40), 
	"ORG_ID" VARCHAR2(4), 
	"PERMIT_IDENT" VARCHAR2(20), 
	"PERMIT_AOR_WELL_NUMBER_NUM" VARCHAR2(20), 
	"PERMIT_AUTHORIZED_STATUS_CD" CHAR(2), 
	"PERMIT_OWNERSHIP_TYPE_CD" VARCHAR2(50), 
	"PERMIT_AUTHORIZED_IDENT" VARCHAR2(50)
   ) ;
 

   COMMENT ON COLUMN "UIC_PERMIT"."PERMIT_ID" IS 'Parent: Container for Permit information. (_PK)';
 
   COMMENT ON COLUMN "UIC_PERMIT"."ORG_ID" IS 'Parent: Container for Permit information. (_FK)';
 
   COMMENT ON COLUMN "UIC_PERMIT"."PERMIT_IDENT" IS 'Unique identification of Permit table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique permit(e.g. 04DI0000000000WDW366, ?). (PermitIdentifier)';
 
   COMMENT ON COLUMN "UIC_PERMIT"."PERMIT_AOR_WELL_NUMBER_NUM" IS 'Number of wells identified in area of review (AOR) requiring corrective action. (PermitAORWellNumberNumeric)';
 
   COMMENT ON COLUMN "UIC_PERMIT"."PERMIT_AUTHORIZED_STATUS_CD" IS 'Identification of whether well is permitted or rule authorized.  If the well is permitted, the acceptable authorization types are individual, area, general, or emergency permits. (PermitAuthorizedStatusCode)';
 
   COMMENT ON COLUMN "UIC_PERMIT"."PERMIT_OWNERSHIP_TYPE_CD" IS 'Type of ownership for a UIC well. (PermitOwnershipTypeCode)';
 
   COMMENT ON COLUMN "UIC_PERMIT"."PERMIT_AUTHORIZED_IDENT" IS 'Identification assigned by DI program or primacy state to permit or rule authorized well. (PermitAuthorizedIdentifier)';
 
   COMMENT ON TABLE "UIC_PERMIT"  IS 'Schema element: PermitDetailType';
--------------------------------------------------------
--  DDL for Table UIC_PERMIT_ACTIVITY
--------------------------------------------------------

  CREATE TABLE "UIC_PERMIT_ACTIVITY" 
   (	"PERMIT_ACTIVITY_ID" VARCHAR2(40), 
	"PERMIT_ID" VARCHAR2(40), 
	"PERMIT_ACT_IDENT" VARCHAR2(20), 
	"PERMIT_ACT_ACT_TYPE_CD" CHAR(2), 
	"PERMIT_ACT_DATE" CHAR(8), 
	"PERMIT_ACT_PERMIT_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_PERMIT_ACTIVITY"."PERMIT_ACTIVITY_ID" IS 'Parent: Container for Permit Activity information. (_PK)';
 
   COMMENT ON COLUMN "UIC_PERMIT_ACTIVITY"."PERMIT_ID" IS 'Parent: Container for Permit Activity information. (_FK)';
 
   COMMENT ON COLUMN "UIC_PERMIT_ACTIVITY"."PERMIT_ACT_IDENT" IS 'Unique identification of Permit Activity table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying the unique permit activity (e.g. TXRC0000000000WDW567, ?). (PermitActivityIdentifier)';
 
   COMMENT ON COLUMN "UIC_PERMIT_ACTIVITY"."PERMIT_ACT_ACT_TYPE_CD" IS 'Type of permit action or authorization by rule. (PermitActivityActionTypeCode)';
 
   COMMENT ON COLUMN "UIC_PERMIT_ACTIVITY"."PERMIT_ACT_DATE" IS 'The calendar date (YYYYMMDD) corresponding to each acceptable value of Permit Action Type includes:

- Application Date for Permit Issuance: Date of receipt of an application by state or DI program for permit issued.

- Application Date for Major Permit Modification: Date of receipt of an application by the state or DI program for major permit modification.

- Permit Issued Date: Date of signature (approval) by state/DI official for the issuance/denial/ withdrawal of permit.

- Permit Denied/Withdrawn Date: Date of signature by state/DI official for the denial/withdrawal of permit.

- Approved Major Permit Modification Date: Approval date of a major permit modification.  This is a date where an approved major modification requires a complete technical review, public notification or review, and a final decision document signed by the regulating authority.

- File Review Date (Class II only): Date of rule-authorized file review to determine whether the well is in compliance with UIC regulatory requirements.
			 (PermitActivityDate)';
 
   COMMENT ON COLUMN "UIC_PERMIT_ACTIVITY"."PERMIT_ACT_PERMIT_IDENT" IS 'Unique identification of Permit table. (PermitActivityPermitIdentifier)';
 
   COMMENT ON TABLE "UIC_PERMIT_ACTIVITY"  IS 'Schema element: PermitActivityDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WASTE
--------------------------------------------------------

  CREATE TABLE "UIC_WASTE" 
   (	"WASTE_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"WASTE_IDENT" VARCHAR2(20), 
	"WASTE_CD" VARCHAR2(50), 
	"WASTE_STREAM_CLASSIFICATION_CD" VARCHAR2(50), 
	"WASTE_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_WASTE"."WASTE_ID" IS 'Parent: Container for Waste information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WASTE"."WELL_ID" IS 'Parent: Container for Waste information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WASTE"."WASTE_IDENT" IS 'Unique identification for waste records - The first four characters are primacy agency code (appendix D) and followed by 8 additional characters identifying unique waste (e.g. WYEQ00000543, ?). (WasteIdentifier)';
 
   COMMENT ON COLUMN "UIC_WASTE"."WASTE_CD" IS 'The RCRA or state waste code included when the constituent has been assigned a code. (WasteCode)';
 
   COMMENT ON COLUMN "UIC_WASTE"."WASTE_STREAM_CLASSIFICATION_CD" IS 'A classification of the waste stream that contains various constituents and waste codes in various concentrations.  These are liquids waste approved to go down the well. (WasteStreamClassificationCode)';
 
   COMMENT ON COLUMN "UIC_WASTE"."WASTE_WELL_IDENT" IS 'Unique identification of an injection well. (WasteWellIdentifier)';
 
   COMMENT ON TABLE "UIC_WASTE"  IS 'Schema element: WasteDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL
--------------------------------------------------------

  CREATE TABLE "UIC_WELL" 
   (	"WELL_ID" VARCHAR2(40), 
	"FACILITY_ID" VARCHAR2(40), 
	"WELL_IDENT" VARCHAR2(20), 
	"WELL_AQUIF_EXEMPT_INJ_CD" VARCHAR2(128), 
	"WELL_TOTAL_DEPTH_NUM" VARCHAR2(128), 
	"WELL_HI_PRI_DESIGNATION_CD" VARCHAR2(128), 
	"WELL_CONTACT_IDENT" VARCHAR2(20), 
	"WELL_FACILITY_IDENT" VARCHAR2(20), 
	"WELL_GEO_IDENT" VARCHAR2(20), 
	"WELL_SITE_AREA_NAME_TXT" VARCHAR2(128), 
	"WELL_PERMIT_IDENT" VARCHAR2(20), 
	"WELL_STATE_IDENT" VARCHAR2(20), 
	"WELL_STATE_TRIBAL_CD" VARCHAR2(128), 
	"WELL_IN_SRC_WATER_AREA_LOC_TXT" VARCHAR2(128), 
	"WELL_NAME" VARCHAR2(128), 
	"LOC_IDENT" VARCHAR2(20), 
	"LOC_ADDRESS_COUNTY" VARCHAR2(128), 
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
 

   COMMENT ON COLUMN "UIC_WELL"."WELL_ID" IS 'Parent: Container for Well information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WELL"."FACILITY_ID" IS 'Parent: Container for Well information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_IDENT" IS 'Unique identification of Well table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique well (e.g. TXEQWDW366, ?). (WellIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_AQUIF_EXEMPT_INJ_CD" IS 'Well injects into exempting aquifer. (WellAquiferExemptionInjectionCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_TOTAL_DEPTH_NUM" IS 'The vertical depth (in feet) from the surface to the bottom of injection well. (WellTotalDepthNumeric)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_HI_PRI_DESIGNATION_CD" IS 'High priority Class V wells include all active motor vehicle waste disposal wells (MVWDWs) and large-capacity cesspools regulated under the 1999 Class V Rule, industrial wells, plus all other Class V wells identified as high priority by State Directors. (WellHighPriorityDesignationCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_CONTACT_IDENT" IS 'Unique identification of Contact record. (WellContactIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_FACILITY_IDENT" IS 'Unique identification of Facility record. (WellFacilityIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_GEO_IDENT" IS 'Unique identification for Geology record. (WellGeologyIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_SITE_AREA_NAME_TXT" IS 'Name of the area where many Class III, IV, or V ( storm water drainage) injection wells are physically located or conducted. (WellSiteAreaNameText)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_PERMIT_IDENT" IS 'Unique identification of Permit table. (WellPermitIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_STATE_IDENT" IS 'The well identification assigned by primacy state or direct implementation (DI) program. (WellStateIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_STATE_TRIBAL_CD" IS 'State postal code or tribal code (for American Indian or Alaska Native) indicating a program Directly Implemented by an EPA region (for DI programs). (WellStateTribalCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_IN_SRC_WATER_AREA_LOC_TXT" IS 'The well location in relation to the boundary of the ground water based source water area (SWA) delineated by the primacy state under the State Source Water Assessment Program (SWAP). (WellInSourceWaterAreaLocationText)';
 
   COMMENT ON COLUMN "UIC_WELL"."WELL_NAME" IS 'The name that designates the well. (WellName)';
 
   COMMENT ON COLUMN "UIC_WELL"."LOC_IDENT" IS 'Unique identification of Location table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only identifying unique location (e.g. 03DI0000000000M00905). (LocationIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."LOC_ADDRESS_COUNTY" IS 'The name of the U.S. county or county equivalent in which the regulated well is physically located. (LocationAddressCounty)';
 
   COMMENT ON COLUMN "UIC_WELL"."LOC_ACCURACY_VALUE_MEASURE" IS 'Quantitative measurement of the amount of deviation from true value in a measurement for latitude or longitude (estimate of error).  It describes the correctness of the latitude/longitude measurement, in meters.  Only the least accurate measurement is recorded, regardless whether it is for longitude or latitude. (LocationAccuracyValueMeasure)';
 
   COMMENT ON COLUMN "UIC_WELL"."GEO_REF_PT_CD" IS 'Code representing the category of the feature referenced by the latitude and longitude. (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."HORZ_COORD_REF_SYS_DATUM_CD" IS 'Code representing the reference standard for three dimensional and horizontal positioning established by the U.S. National Geodetic Survey (NGS) and other bodies. (HorizontalCoordinateReferenceSystemDatumCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."HORZ_COLLECTION_METHOD_CD" IS 'Code representing the method used to determine the latitude/longitude.  This represents the primary source of the data. (HorizontalCollectionMethodCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."LOC_PT_LINE_AREA_CD" IS 'Code representing the value indicating whether the latitude and longitude coordinates represent a point, multiple points on a line, or an area. (LocationPointLineAreaCode)';
 
   COMMENT ON COLUMN "UIC_WELL"."SRC_MAP_SCALE_NUM" IS 'Code representing the scale of the map used to determine the latitude and longitude coordinates. (SourceMapScaleNumeric)';
 
   COMMENT ON COLUMN "UIC_WELL"."LOC_WELL_IDENT" IS 'Unique identification of Well table. (LocationWellIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL"."LATITUDE_MEASURE" IS 'Coordinate representing a location on the surface of the earth, using the earth''s Equator as the origin, reported in decimal format.  If an area permit is being requested, give the latitude and longitude of the approximate center of the area. (LatitudeMeasure)';
 
   COMMENT ON COLUMN "UIC_WELL"."LONGITUDE_MEASURE" IS 'Coordinate representing a location on the surface of the earth, using the Prime Meridian (Greenwich, England) as the origin, reported in decimal format. If an area permit is being requested, give the latitude and longitude of the approximate center of the area. (LongitudeMeasure)';
 
   COMMENT ON TABLE "UIC_WELL"  IS 'Schema element: WellDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_INSPECTION
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_INSPECTION" 
   (	"WELL_INSPECTION_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"INSP_IDENT" VARCHAR2(20), 
	"INSP_ASSISTANCE_CD" VARCHAR2(50), 
	"INSP_DEFICIENCY_CD" VARCHAR2(50), 
	"INSP_ACT_DATE" CHAR(8), 
	"INSP_ICIS_COMPL_MONTR_RSN_CD" VARCHAR2(50), 
	"INSP_ICIS_COMPL_MONTR_TYPE_CD" VARCHAR2(50), 
	"INSP_ICIS_COMPL_ACT_TYPE_CD" VARCHAR2(50), 
	"INSP_ICIS_MOA_NAME" VARCHAR2(128), 
	"INSP_ICIS_RGN_PRI_NAME" VARCHAR2(128), 
	"INSP_TYPE_ACT_CD" CHAR(2), 
	"INSP_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."WELL_INSPECTION_ID" IS 'Parent: Container for Well Inspection information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."WELL_ID" IS 'Parent: Container for Well Inspection information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_IDENT" IS 'Unique identification of Inspection table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique  inspection (e.g. WYEQ00 000566, ?). (InspectionIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ASSISTANCE_CD" IS 'Compliance assistance provided by the inspector based on national policy:

-- General Assistance: involves distributing prepared information on regulatory compliance, P2 or other written materials/websites.

-- Site-specific Assistance: involves on-site assistance by the inspector to support actions taken to address deficiencies. (InspectionAssistanceCode)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_DEFICIENCY_CD" IS 'Potential violations found by EPA inspector during inspection. (InspectionDeficiencyCode)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ACT_DATE" IS 'The date inspection action was completed (YYYYMMDD). (InspectionActionDate)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ICIS_COMPL_MONTR_RSN_CD" IS 'The reason for performing a Compliance Monitoring action:

-- Agency Priority: The compliance monitoring action was performed in furtherance of a priority or initiative of the Compliance Monitoring Agency or a partner agency.

-- Core Program: The compliance monitoring action was performed as part of the Compliance Monitoring Agency''s core programmatic activities.

-- Selected Monitoring Action: The Compliance Monitoring Agency selected the facility or regulated entity for compliance monitoring in response to a referral from another unit. 
 (InspectionICISComplianceMonitoringReasonCode)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ICIS_COMPL_MONTR_TYPE_CD" IS 'Type of compliance monitoring taken by a regulatory agency. (InspectionICISComplianceMonitoringTypeCode)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ICIS_COMPL_ACT_TYPE_CD" IS 'Type of compliance activity taken by a regulatory agency. (InspectionICISComplianceActivityTypeCode)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ICIS_MOA_NAME" IS 'The name of Memorandum of Agreement (MOA) associated with the activity. (InspectionICISMOAName)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_ICIS_RGN_PRI_NAME" IS 'The name of regional priority associated with the activity. (InspectionICISRegionalPriorityName)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_TYPE_ACT_CD" IS 'The type of inspection action that was conducted. (InspectionTypeActionCode)';
 
   COMMENT ON COLUMN "UIC_WELL_INSPECTION"."INSP_WELL_IDENT" IS 'Unique identification of Well table. (InspectionWellIdentifier)';
 
   COMMENT ON TABLE "UIC_WELL_INSPECTION"  IS 'Schema element: WellInspectionDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_RESPONSE
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_RESPONSE" 
   (	"WELL_RESPONSE_ID" VARCHAR2(40), 
	"WELL_VIOLATION_ID" VARCHAR2(40), 
	"RESPONSE_ENFORCEMENT_IDENT" VARCHAR2(20), 
	"RESPONSE_VIOLATION_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_WELL_RESPONSE"."WELL_RESPONSE_ID" IS 'Parent: Container for Response information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WELL_RESPONSE"."WELL_VIOLATION_ID" IS 'Parent: Container for Response information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WELL_RESPONSE"."RESPONSE_ENFORCEMENT_IDENT" IS 'Unique identification of Enforcement table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State?s choice (letters and numbers only identifying unique  enforcement action (e.g. 08DI000766, ?). (ResponseEnforcementIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL_RESPONSE"."RESPONSE_VIOLATION_IDENT" IS 'Unique identification of Violation table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State?s choice (letters and numbers only identifying unique violation (e.g. 08DI000905, ?). (ResponseViolationIdentifier)';
 
   COMMENT ON TABLE "UIC_WELL_RESPONSE"  IS 'Schema element: WellResponseDetailDataType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_STATUS
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_STATUS" 
   (	"WELL_STATUS_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"WELL_STATUS_IDENT" VARCHAR2(20), 
	"WELL_STATUS_DATE" CHAR(8), 
	"WELL_STATUS_OPER_STATUS_CD" CHAR(2), 
	"WELL_STATUS_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_WELL_STATUS"."WELL_STATUS_ID" IS 'Parent: Container for Well Status information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WELL_STATUS"."WELL_ID" IS 'Parent: Container for Well Status information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WELL_STATUS"."WELL_STATUS_IDENT" IS 'Unique identification of Well Status table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only identifying the unique Well Status (e.g. TXEQ WDW369, ?). (WellStatusIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL_STATUS"."WELL_STATUS_DATE" IS 'Date that well status is determined (YYYYMMDD). (WellStatusDate)';
 
   COMMENT ON COLUMN "UIC_WELL_STATUS"."WELL_STATUS_OPER_STATUS_CD" IS 'The current operating status of well. (WellStatusOperatingStatusCode)';
 
   COMMENT ON COLUMN "UIC_WELL_STATUS"."WELL_STATUS_WELL_IDENT" IS 'Unique identification of Well table. (WellStatusWellIdentifier)';
 
   COMMENT ON TABLE "UIC_WELL_STATUS"  IS 'Schema element: WellStatusDetailType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_TYPE
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_TYPE" 
   (	"WELL_TYPE_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"WELL_TYPE_IDENT" VARCHAR2(20), 
	"WELL_TYPE_CD" VARCHAR2(20), 
	"WELL_TYPE_DATE" CHAR(8), 
	"WELL_TYPE_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_WELL_TYPE"."WELL_TYPE_ID" IS 'Parent: Container for Well Type information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WELL_TYPE"."WELL_ID" IS 'Parent: Container for Well Type information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WELL_TYPE"."WELL_TYPE_IDENT" IS 'Unique identification of Well Type table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State?s choice (letters and numbers only) identifying unique well type (e.g. TXEQWDW369, ?). (WellTypeIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL_TYPE"."WELL_TYPE_CD" IS 'Type of injection wells located at the listed facility. (WellTypeCode)';
 
   COMMENT ON COLUMN "UIC_WELL_TYPE"."WELL_TYPE_DATE" IS 'Date that well type is determined (YYYYMMDD).  This field ONLY applies when the well changes from one well type to another well type (e.g. converted from injection to production). (WellTypeDate)';
 
   COMMENT ON COLUMN "UIC_WELL_TYPE"."WELL_TYPE_WELL_IDENT" IS 'Unique identification of Well table. (WellTypeWellIdentifier)';
 
   COMMENT ON TABLE "UIC_WELL_TYPE"  IS 'Schema element: WellTypeDetailDataType';
--------------------------------------------------------
--  DDL for Table UIC_WELL_VIOLATION
--------------------------------------------------------

  CREATE TABLE "UIC_WELL_VIOLATION" 
   (	"WELL_VIOLATION_ID" VARCHAR2(40), 
	"WELL_ID" VARCHAR2(40), 
	"VIOLATION_IDENT" VARCHAR2(20), 
	"VIOLATION_CONTAMINATION_CD" VARCHAR2(50), 
	"VIOLATION_ENDANGERING_CD" VARCHAR2(50), 
	"VIOLATION_RTN_COMPL_DATE" CHAR(8), 
	"VIOLATION_SIGNIFICANT_CD" VARCHAR2(50), 
	"VIOLATION_DETERMINED_DATE" CHAR(8), 
	"VIOLATION_TYPE_CD" CHAR(2), 
	"VIOLATION_WELL_IDENT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."WELL_VIOLATION_ID" IS 'Parent: Container for Well Violation information. (_PK)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."WELL_ID" IS 'Parent: Container for Well Violation information. (_FK)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_IDENT" IS 'Unique identification of Violation table - The first four characters are the primacy agency code (appendix D).  The rest is DI program or State?s choice (letters and numbers only) identifying unique  violation (e.g. 08DI000366, ?). (ViolationIdentifier)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_CONTAMINATION_CD" IS 'Well in noncompliance has allegedly contaminated an underground source of drinking water (USDW) this year to date. (ViolationContaminationCode)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_ENDANGERING_CD" IS 'A violation that results in the well potentially or actually endangering the USDW.  The endangering fluid contaminant from the well is in violation of RCRA or SDWA or applicable regulations. (ViolationEndangeringCode)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_RTN_COMPL_DATE" IS 'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the violation determined date (YYYYMMDD). (ViolationReturnComplianceDate)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_SIGNIFICANT_CD" IS 'The indication whether or not the violation is in Significant Non-Compliance (SNC). (ViolationSignificantCode)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_DETERMINED_DATE" IS 'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation (YYYYMMDD). (ViolationDeterminedDate)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_TYPE_CD" IS 'The type of violation that is the subject of the Violation Date. (ViolationTypeCode)';
 
   COMMENT ON COLUMN "UIC_WELL_VIOLATION"."VIOLATION_WELL_IDENT" IS 'Unique identification of Well table. (ViolationWellIdentifier)';
 
   COMMENT ON TABLE "UIC_WELL_VIOLATION"  IS 'Schema element: WellViolationDetailType';
--------------------------------------------------------
--  Constraints for Table UIC_ENFORCEMENT
--------------------------------------------------------

  ALTER TABLE "UIC_ENFORCEMENT" ADD CONSTRAINT "PK_ENFORCEMENT" PRIMARY KEY ("ENFORCEMENT_ID") ENABLE;
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENFORCEMENT" MODIFY ("ENFORCEMENT_ACT_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_GEOLOGY
--------------------------------------------------------

  ALTER TABLE "UIC_GEOLOGY" ADD CONSTRAINT "PK_GEOLOGY" PRIMARY KEY ("GEOLOGY_ID") ENABLE;
 
  ALTER TABLE "UIC_GEOLOGY" MODIFY ("GEOLOGY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_GEOLOGY" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_GEOLOGY" MODIFY ("GEO_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_PERMIT_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT_ACTIVITY" ADD CONSTRAINT "PK_PERMIT_ACTIVITY" PRIMARY KEY ("PERMIT_ACTIVITY_ID") ENABLE;
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACTIVITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_ACT_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT_ACTIVITY" MODIFY ("PERMIT_ACT_PERMIT_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_INSPECTION
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_INSPECTION" ADD CONSTRAINT "PK_WELL_INSPECTION" PRIMARY KEY ("WELL_INSPECTION_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_INSPECTION" MODIFY ("WELL_INSPECTION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_INSPECTION" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_INSPECTION" MODIFY ("INSP_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_INSPECTION" MODIFY ("INSP_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_INSPECTION" MODIFY ("INSP_TYPE_ACT_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_INSPECTION" MODIFY ("INSP_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_ENGINEERING
--------------------------------------------------------

  ALTER TABLE "UIC_ENGINEERING" ADD CONSTRAINT "PK_ENGINEERING" PRIMARY KEY ("ENGINEERING_ID") ENABLE;
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ENGINEERING_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ENGR_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ENGINEERING" MODIFY ("ENGR_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_RESPONSE
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_RESPONSE" ADD CONSTRAINT "PK_WELL_RESPONSE" PRIMARY KEY ("WELL_RESPONSE_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_RESPONSE" MODIFY ("WELL_RESPONSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_RESPONSE" MODIFY ("WELL_VIOLATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_RESPONSE" MODIFY ("RESPONSE_ENFORCEMENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_RESPONSE" MODIFY ("RESPONSE_VIOLATION_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_ORG
--------------------------------------------------------

  ALTER TABLE "UIC_ORG" ADD CONSTRAINT "PK_ORG" PRIMARY KEY ("ORG_ID") ENABLE;
 
  ALTER TABLE "UIC_ORG" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_ORG" MODIFY ("PRIMACY_AGENCY_CD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL
--------------------------------------------------------

  ALTER TABLE "UIC_WELL" ADD CONSTRAINT "PK_WELL" PRIMARY KEY ("WELL_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("FACILITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_CONTACT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_FACILITY_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_PERMIT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("WELL_STATE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("LOC_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL" MODIFY ("LOC_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WASTE
--------------------------------------------------------

  ALTER TABLE "UIC_WASTE" ADD CONSTRAINT "PK_WASTE" PRIMARY KEY ("WASTE_ID") ENABLE;
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WASTE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WASTE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WASTE" MODIFY ("WASTE_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_CORRECTION
--------------------------------------------------------

  ALTER TABLE "UIC_CORRECTION" ADD CONSTRAINT "PK_CORRECTION" PRIMARY KEY ("CORRECTION_ID") ENABLE;
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("CORRECTION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("WELL_INSPECTION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("CORRECTION_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CORRECTION" MODIFY ("CORRECTION_INSP_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_FACILITY_INSPECTION
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY_INSPECTION" ADD CONSTRAINT "PK_FCILTY_INSPCTON" PRIMARY KEY ("FACILITY_INSPECTION_ID") ENABLE;
 
  ALTER TABLE "UIC_FACILITY_INSPECTION" MODIFY ("FACILITY_INSPECTION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_INSPECTION" MODIFY ("FACILITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_INSPECTION" MODIFY ("INSP_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_INSPECTION" MODIFY ("INSP_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_INSPECTION" MODIFY ("INSP_TYPE_ACT_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_INSPECTION" MODIFY ("INSP_FACILITY_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_CONTACT
--------------------------------------------------------

  ALTER TABLE "UIC_CONTACT" ADD CONSTRAINT "PK_CONTACT" PRIMARY KEY ("CONTACT_ID") ENABLE;
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("INDIVIDUAL_FULL_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_ADDRESS_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONTACT" MODIFY ("CONTACT_ADDRESS_POSTAL_CD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_VIOLATION
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_VIOLATION" ADD CONSTRAINT "PK_WELL_VIOLATION" PRIMARY KEY ("WELL_VIOLATION_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_VIOLATION" MODIFY ("WELL_VIOLATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_VIOLATION" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_VIOLATION" MODIFY ("VIOLATION_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_VIOLATION" MODIFY ("VIOLATION_DETERMINED_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_VIOLATION" MODIFY ("VIOLATION_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_VIOLATION" MODIFY ("VIOLATION_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_FACILITY
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY" ADD CONSTRAINT "PK_FACILITY" PRIMARY KEY ("FACILITY_ID") ENABLE;
 
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

  ALTER TABLE "UIC_CONSTITUENT" ADD CONSTRAINT "PK_CONSTITUENT" PRIMARY KEY ("CONSTITUENT_ID") ENABLE;
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("CONSTITUENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("WASTE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("CONSTITUENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_CONSTITUENT" MODIFY ("CONSTITUENT_WASTE_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_STATUS
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_STATUS" ADD CONSTRAINT "PK_WELL_STATUS" PRIMARY KEY ("WELL_STATUS_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_OPER_STATUS_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_STATUS" MODIFY ("WELL_STATUS_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_WELL_TYPE
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_TYPE" ADD CONSTRAINT "PK_WELL_TYPE" PRIMARY KEY ("WELL_TYPE_ID") ENABLE;
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_WELL_TYPE" MODIFY ("WELL_TYPE_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_FACILITY_RESPONSE
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY_RESPONSE" ADD CONSTRAINT "PK_FCILITY_RSPONSE" PRIMARY KEY ("FACILITY_RESPONSE_ID") ENABLE;
 
  ALTER TABLE "UIC_FACILITY_RESPONSE" MODIFY ("FACILITY_RESPONSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_RESPONSE" MODIFY ("FACILITY_VIOLATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_RESPONSE" MODIFY ("RESPONSE_ENFORCEMENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_RESPONSE" MODIFY ("RESPONSE_VIOLATION_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_PERMIT
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT" ADD CONSTRAINT "PK_PERMIT" PRIMARY KEY ("PERMIT_ID") ENABLE;
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_AUTHORIZED_STATUS_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_PERMIT" MODIFY ("PERMIT_AUTHORIZED_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_FACILITY_VIOLATION
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY_VIOLATION" ADD CONSTRAINT "PK_FCILITY_VIOLTON" PRIMARY KEY ("FACILITY_VIOLATION_ID") ENABLE;
 
  ALTER TABLE "UIC_FACILITY_VIOLATION" MODIFY ("FACILITY_VIOLATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_VIOLATION" MODIFY ("FACILITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_VIOLATION" MODIFY ("VIOLATION_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_VIOLATION" MODIFY ("VIOLATION_DETERMINED_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_VIOLATION" MODIFY ("VIOLATION_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_FACILITY_VIOLATION" MODIFY ("VIOLATION_FACILITY_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table UIC_MI_TEST
--------------------------------------------------------

  ALTER TABLE "UIC_MI_TEST" ADD CONSTRAINT "PK_MI_TEST" PRIMARY KEY ("MI_TEST_ID") ENABLE;
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MI_TEST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("WELL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_COMPLETED_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_RESULT_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_TYPE_CD" NOT NULL ENABLE);
 
  ALTER TABLE "UIC_MI_TEST" MODIFY ("MECH_INTEG_TST_WELL_IDENT" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index IX_PRMT_ACT_PRM_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRMT_ACT_PRM_ID" ON "UIC_PERMIT_ACTIVITY" ("PERMIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WELL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WELL" ON "UIC_WELL" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CORRECTION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CORRECTION" ON "UIC_CORRECTION" ("CORRECTION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_GEOLOGY_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_GEOLOGY_ORG_ID" ON "UIC_GEOLOGY" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FACILITY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FACILITY" ON "UIC_FACILITY" ("FACILITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FCILTY_INSPCTON
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FCILTY_INSPCTON" ON "UIC_FACILITY_INSPECTION" ("FACILITY_INSPECTION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CONTACT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_CONTACT_ORG_ID" ON "UIC_CONTACT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CNSTTNT_WSTE_ID
--------------------------------------------------------

  CREATE INDEX "IX_CNSTTNT_WSTE_ID" ON "UIC_CONSTITUENT" ("WASTE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CONSTITUENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CONSTITUENT" ON "UIC_CONSTITUENT" ("CONSTITUENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FCLT_INS_FCL_ID
--------------------------------------------------------

  CREATE INDEX "IX_FCLT_INS_FCL_ID" ON "UIC_FACILITY_INSPECTION" ("FACILITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WLL_STTS_WLL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WLL_STTS_WLL_ID" ON "UIC_WELL_STATUS" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENFORCEMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENFORCEMENT" ON "UIC_ENFORCEMENT" ("ENFORCEMENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WLL_RS_WL_VL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WLL_RS_WL_VL_ID" ON "UIC_WELL_RESPONSE" ("WELL_VIOLATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WELL_STATUS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WELL_STATUS" ON "UIC_WELL_STATUS" ("WELL_STATUS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ENGINEERING
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ENGINEERING" ON "UIC_ENGINEERING" ("ENGINEERING_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WELL_FCILITY_ID
--------------------------------------------------------

  CREATE INDEX "IX_WELL_FCILITY_ID" ON "UIC_WELL" ("FACILITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ENFRCMNT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENFRCMNT_ORG_ID" ON "UIC_ENFORCEMENT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_MI_TEST_WELL_ID
--------------------------------------------------------

  CREATE INDEX "IX_MI_TEST_WELL_ID" ON "UIC_MI_TEST" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WELL_INSPECTION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WELL_INSPECTION" ON "UIC_WELL_INSPECTION" ("WELL_INSPECTION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PERMIT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_PERMIT_ORG_ID" ON "UIC_PERMIT" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WLL_INSP_WLL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WLL_INSP_WLL_ID" ON "UIC_WELL_INSPECTION" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PERMIT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PERMIT" ON "UIC_PERMIT" ("PERMIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_MI_TEST
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_MI_TEST" ON "UIC_MI_TEST" ("MI_TEST_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WASTE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WASTE" ON "UIC_WASTE" ("WASTE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WASTE_WELL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WASTE_WELL_ID" ON "UIC_WASTE" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FACILITY_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_FACILITY_ORG_ID" ON "UIC_FACILITY" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ORG" ON "UIC_ORG" ("ORG_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WLL_VLTN_WLL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WLL_VLTN_WLL_ID" ON "UIC_WELL_VIOLATION" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_WLL_TYPE_WLL_ID
--------------------------------------------------------

  CREATE INDEX "IX_WLL_TYPE_WLL_ID" ON "UIC_WELL_TYPE" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WELL_VIOLATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WELL_VIOLATION" ON "UIC_WELL_VIOLATION" ("WELL_VIOLATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WELL_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WELL_TYPE" ON "UIC_WELL_TYPE" ("WELL_TYPE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FCILITY_RSPONSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FCILITY_RSPONSE" ON "UIC_FACILITY_RESPONSE" ("FACILITY_RESPONSE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CONTACT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CONTACT" ON "UIC_CONTACT" ("CONTACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_WELL_RESPONSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WELL_RESPONSE" ON "UIC_WELL_RESPONSE" ("WELL_RESPONSE_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CRRC_WLL_INS_ID
--------------------------------------------------------

  CREATE INDEX "IX_CRRC_WLL_INS_ID" ON "UIC_CORRECTION" ("WELL_INSPECTION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_GEOLOGY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GEOLOGY" ON "UIC_GEOLOGY" ("GEOLOGY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FCILITY_VIOLTON
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FCILITY_VIOLTON" ON "UIC_FACILITY_VIOLATION" ("FACILITY_VIOLATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FCLT_VLT_FCL_ID
--------------------------------------------------------

  CREATE INDEX "IX_FCLT_VLT_FCL_ID" ON "UIC_FACILITY_VIOLATION" ("FACILITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FCL_RS_FC_VL_ID
--------------------------------------------------------

  CREATE INDEX "IX_FCL_RS_FC_VL_ID" ON "UIC_FACILITY_RESPONSE" ("FACILITY_VIOLATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ENGINRNG_WLL_ID
--------------------------------------------------------

  CREATE INDEX "IX_ENGINRNG_WLL_ID" ON "UIC_ENGINEERING" ("WELL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PERMIT_ACTIVITY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PERMIT_ACTIVITY" ON "UIC_PERMIT_ACTIVITY" ("PERMIT_ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table UIC_CONSTITUENT
--------------------------------------------------------

  ALTER TABLE "UIC_CONSTITUENT" ADD CONSTRAINT "FK_CONSTITUNT_WSTE" FOREIGN KEY ("WASTE_ID")
	  REFERENCES "UIC_WASTE" ("WASTE_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_CONTACT
--------------------------------------------------------

  ALTER TABLE "UIC_CONTACT" ADD CONSTRAINT "FK_CONTACT_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_CORRECTION
--------------------------------------------------------

  ALTER TABLE "UIC_CORRECTION" ADD CONSTRAINT "FK_CRRCT_WLL_INSPC" FOREIGN KEY ("WELL_INSPECTION_ID")
	  REFERENCES "UIC_WELL_INSPECTION" ("WELL_INSPECTION_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_ENFORCEMENT
--------------------------------------------------------

  ALTER TABLE "UIC_ENFORCEMENT" ADD CONSTRAINT "FK_ENFORCEMENT_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_ENGINEERING
--------------------------------------------------------

  ALTER TABLE "UIC_ENGINEERING" ADD CONSTRAINT "FK_ENGINEERING_WLL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_FACILITY
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY" ADD CONSTRAINT "FK_FACILITY_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_FACILITY_INSPECTION
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY_INSPECTION" ADD CONSTRAINT "FK_FCLTY_INSP_FCLT" FOREIGN KEY ("FACILITY_ID")
	  REFERENCES "UIC_FACILITY" ("FACILITY_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_FACILITY_RESPONSE
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY_RESPONSE" ADD CONSTRAINT "FK_FCL_RSP_FCL_VLT" FOREIGN KEY ("FACILITY_VIOLATION_ID")
	  REFERENCES "UIC_FACILITY_VIOLATION" ("FACILITY_VIOLATION_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_FACILITY_VIOLATION
--------------------------------------------------------

  ALTER TABLE "UIC_FACILITY_VIOLATION" ADD CONSTRAINT "FK_FCLTY_VLTN_FCLT" FOREIGN KEY ("FACILITY_ID")
	  REFERENCES "UIC_FACILITY" ("FACILITY_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_GEOLOGY
--------------------------------------------------------

  ALTER TABLE "UIC_GEOLOGY" ADD CONSTRAINT "FK_GEOLOGY_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_MI_TEST
--------------------------------------------------------

  ALTER TABLE "UIC_MI_TEST" ADD CONSTRAINT "FK_MI_TEST_WELL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table UIC_PERMIT
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT" ADD CONSTRAINT "FK_PERMIT_ORG" FOREIGN KEY ("ORG_ID")
	  REFERENCES "UIC_ORG" ("ORG_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_PERMIT_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "UIC_PERMIT_ACTIVITY" ADD CONSTRAINT "FK_PRMT_ACTVT_PRMT" FOREIGN KEY ("PERMIT_ID")
	  REFERENCES "UIC_PERMIT" ("PERMIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WASTE
--------------------------------------------------------

  ALTER TABLE "UIC_WASTE" ADD CONSTRAINT "FK_WASTE_WELL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL
--------------------------------------------------------

  ALTER TABLE "UIC_WELL" ADD CONSTRAINT "FK_WELL_FACILITY" FOREIGN KEY ("FACILITY_ID")
	  REFERENCES "UIC_FACILITY" ("FACILITY_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_INSPECTION
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_INSPECTION" ADD CONSTRAINT "FK_WLL_INSPCTN_WLL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_RESPONSE
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_RESPONSE" ADD CONSTRAINT "FK_WLL_RSP_WLL_VLT" FOREIGN KEY ("WELL_VIOLATION_ID")
	  REFERENCES "UIC_WELL_VIOLATION" ("WELL_VIOLATION_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_STATUS
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_STATUS" ADD CONSTRAINT "FK_WELL_STATUS_WLL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_TYPE
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_TYPE" ADD CONSTRAINT "FK_WELL_TYPE_WELL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table UIC_WELL_VIOLATION
--------------------------------------------------------

  ALTER TABLE "UIC_WELL_VIOLATION" ADD CONSTRAINT "FK_WLL_VIOLTON_WLL" FOREIGN KEY ("WELL_ID")
	  REFERENCES "UIC_WELL" ("WELL_ID") ON DELETE CASCADE ENABLE;
