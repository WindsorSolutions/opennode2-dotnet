--------------------------------------------------------
--  File created - Monday-May-09-2016   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ATT_ACTN
--------------------------------------------------------

  CREATE TABLE "ATT_ACTN" 
   (	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"ATT_ORG_ID" VARCHAR2(36 BYTE), 
	"ACTN_IDENT" VARCHAR2(45 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"ACTN_TYPE_CODE" VARCHAR2(25 BYTE), 
	"EPA_ACTN_CODE" VARCHAR2(30 BYTE), 
	"ACTN_STAT_CODE" VARCHAR2(30 BYTE), 
	"PLANNED_CMPL_DATE" TIMESTAMP (6), 
	"ACTUAL_CMPL_DATE" TIMESTAMP (6), 
	"ACTN_CMNT" VARCHAR2(4000 BYTE), 
	"TMDL_REP_IDENT" VARCHAR2(45 BYTE), 
	"TMDL_OTHR_IDENT" VARCHAR2(45 BYTE), 
	"TMDL_REP_NAME" VARCHAR2(255 BYTE), 
	"TMDL_DATE" TIMESTAMP (6), 
	"INDIAN_COUNTRY_IND" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ACTN"."ACTN_IDENT" IS 'Unique code identifying the action (ActionIdentifier)';
 
   COMMENT ON COLUMN "ATT_ACTN"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_ACTN"."ACTN_TYPE_CODE" IS 'Code identifying the type of action being taken (ActionTypeCode)';
 
   COMMENT ON COLUMN "ATT_ACTN"."EPA_ACTN_CODE" IS 'Code indicating actions that EPA has taken on this Action, including the approval of TMDLs (EPAActionCode)';
 
   COMMENT ON COLUMN "ATT_ACTN"."ACTN_STAT_CODE" IS 'Status of the Action (i.e. Final, Draft, Public Comment, etc.) (ActionStatusCode)';
 
   COMMENT ON COLUMN "ATT_ACTN"."PLANNED_CMPL_DATE" IS 'Date the action is planned to be completed (PlannedCompletionDate)';
 
   COMMENT ON COLUMN "ATT_ACTN"."ACTUAL_CMPL_DATE" IS 'Completion date for the action (ActualCompletionDate)';
 
   COMMENT ON COLUMN "ATT_ACTN"."ACTN_CMNT" IS 'Free text providing additional comments on the action (ActionComment)';
 
   COMMENT ON COLUMN "ATT_ACTN"."TMDL_REP_IDENT" IS 'Unique code identifying the TMDL Report (TMDLReportIdentifier)';
 
   COMMENT ON COLUMN "ATT_ACTN"."TMDL_OTHR_IDENT" IS 'Alternative code identifying the TMDL Report (an example could be a state assigned identifier that is different from the ID in TMDLReportIdentifier) (TMDLOtherIdentifier)';
 
   COMMENT ON COLUMN "ATT_ACTN"."TMDL_REP_NAME" IS 'Name of the TMDL (TMDLReportName)';
 
   COMMENT ON COLUMN "ATT_ACTN"."TMDL_DATE" IS 'Date TMDL was established (TMDLDate)';
 
   COMMENT ON COLUMN "ATT_ACTN"."INDIAN_COUNTRY_IND" IS 'Indicates if the water is either wholly or partially in Indian country. (IndianCountryIndicator)';
 
   COMMENT ON TABLE "ATT_ACTN"  IS 'Schema element: Action';
/
--------------------------------------------------------
--  DDL for Table ATT_ADDRESSED_PRIO
--------------------------------------------------------

  CREATE TABLE "ATT_ADDRESSED_PRIO" 
   (	"ATT_ADDRESSED_PRIO_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"PRIO_IDENT" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ADDRESSED_PRIO"."PRIO_IDENT" IS 'Unique identifier for a priority (PriorityIdentifier)';
 
   COMMENT ON TABLE "ATT_ADDRESSED_PRIO"  IS 'Schema element: AddressedPriority';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSC_ACTN
--------------------------------------------------------

  CREATE TABLE "ATT_ASSC_ACTN" 
   (	"ATT_ASSC_ACTN_ID" VARCHAR2(36 BYTE), 
	"ATT_PARAM_ID" VARCHAR2(36 BYTE), 
	"ASSC_ACTN_IDENT" VARCHAR2(45 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSC_ACTN"."ASSC_ACTN_IDENT" IS 'Unique code identifying the Action that corresponds to this cause. (AssociatedActionIdentifier)';
 
   COMMENT ON TABLE "ATT_ASSC_ACTN"  IS 'Schema element: AssociatedAction';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSC_CAUSE_NAME
--------------------------------------------------------

  CREATE TABLE "ATT_ASSC_CAUSE_NAME" 
   (	"ATT_ASSC_CAUSE_NAME_ID" VARCHAR2(36 BYTE), 
	"ATT_PROBABLE_SRC_ID" VARCHAR2(36 BYTE), 
	"CAUSE_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSC_CAUSE_NAME"."CAUSE_NAME" IS 'Name of the cause (CauseName)';
 
   COMMENT ON TABLE "ATT_ASSC_CAUSE_NAME"  IS 'Schema element: AssociatedCauseName';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSC_POLUT
--------------------------------------------------------

  CREATE TABLE "ATT_ASSC_POLUT" 
   (	"ATT_ASSC_POLUT_ID" VARCHAR2(36 BYTE), 
	"ATT_SPECIFIC_WTR_CAUSE_ID" VARCHAR2(36 BYTE), 
	"POLUT_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSC_POLUT"."POLUT_NAME" IS 'Name of the pollutant (PollutantName)';
 
   COMMENT ON TABLE "ATT_ASSC_POLUT"  IS 'Schema element: AssociatedPollutant';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSC_USE
--------------------------------------------------------

  CREATE TABLE "ATT_ASSC_USE" 
   (	"ATT_ASSC_USE_ID" VARCHAR2(36 BYTE), 
	"ATT_PARAM_ID" VARCHAR2(36 BYTE), 
	"ASSC_USE_NAME" VARCHAR2(255 BYTE), 
	"PARAM_ATTAINMENT_CODE" VARCHAR2(30 BYTE), 
	"TREND_CODE" VARCHAR2(25 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSC_USE"."ASSC_USE_NAME" IS 'Name of the designated use. (AssociatedUseName)';
 
   COMMENT ON COLUMN "ATT_ASSC_USE"."PARAM_ATTAINMENT_CODE" IS 'Code indicating the attainment status for this parameter for this specific use. (ParameterAttainmentCode)';
 
   COMMENT ON COLUMN "ATT_ASSC_USE"."TREND_CODE" IS 'Code representing the water quality trend for this use or parameter. (TrendCode)';
 
   COMMENT ON TABLE "ATT_ASSC_USE"  IS 'Schema element: AssociatedUse';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSESSMNT
--------------------------------------------------------

  CREATE TABLE "ATT_ASSESSMNT" 
   (	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_REP_CYCLE_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_UNIT_IDENT" VARCHAR2(50 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"CYCLE_LAST_ASSESSED_TXT" VARCHAR2(4 BYTE), 
	"YEAR_LAST_MONITORED_TXT" VARCHAR2(4 BYTE), 
	"TROPHIC_STAT_CODE" VARCHAR2(30 BYTE), 
	"ASSESSMNT_CMNTS_TXT" VARCHAR2(4000 BYTE), 
	"RATIONALE_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSESSMNT"."ASSESSMNT_UNIT_IDENT" IS 'A unique identifier assigned to the Assessment Unit by the reporting organization (AssessmentUnitIdentifier)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT"."CYCLE_LAST_ASSESSED_TXT" IS 'Cycle this Assessment Unit was last assessed, which can include any conclusions related to this Assessment Unit and can include delisting decisions. (CycleLastAssessedText)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT"."YEAR_LAST_MONITORED_TXT" IS 'Cycle this Assessment Unit was last monitored (YearLastMonitoredText)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT"."TROPHIC_STAT_CODE" IS 'Code representing the trophic status for the Assessment Unit (TrophicStatusCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT"."ASSESSMNT_CMNTS_TXT" IS 'Free text for providing additional comments on the assessment. (AssessmentCommentsText)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT"."RATIONALE_TXT" IS 'Rationale for the assessment conclusion. This text will be avaialble for the public. (RationaleText)';
 
   COMMENT ON TABLE "ATT_ASSESSMNT"  IS 'Schema element: Assessment';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSESSMNT_METHOD_TYPE
--------------------------------------------------------

  CREATE TABLE "ATT_ASSESSMNT_METHOD_TYPE" 
   (	"ATT_ASSESSMNT_METHOD_TYPE_ID" VARCHAR2(36 BYTE), 
	"ATT_USE_ATTAINMENT_ID" VARCHAR2(36 BYTE), 
	"METHOD_TYPE_CNTXT" VARCHAR2(30 BYTE), 
	"METHOD_TYPE_CODE" VARCHAR2(20 BYTE), 
	"METHOD_TYPE_NAME" VARCHAR2(150 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSESSMNT_METHOD_TYPE"."METHOD_TYPE_CNTXT" IS 'Context for the MethodTypeName (MethodTypeContext)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_METHOD_TYPE"."METHOD_TYPE_CODE" IS 'Code for the Assesment Method (MethodTypeCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_METHOD_TYPE"."METHOD_TYPE_NAME" IS 'Name of the method used (MethodTypeName)';
 
   COMMENT ON TABLE "ATT_ASSESSMNT_METHOD_TYPE"  IS 'Schema element: AssessmentMethodType';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSESSMNT_TYPE
--------------------------------------------------------

  CREATE TABLE "ATT_ASSESSMNT_TYPE" 
   (	"ATT_ASSESSMNT_TYPE_ID" VARCHAR2(36 BYTE), 
	"ATT_USE_ATTAINMENT_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_TYPE_CODE" VARCHAR2(30 BYTE), 
	"ASSESSMNT_CONFIDENCE_CODE" VARCHAR2(30 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSESSMNT_TYPE"."ASSESSMNT_TYPE_CODE" IS 'Code representing the type of assessment that was performed. (AssessmentTypeCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_TYPE"."ASSESSMNT_CONFIDENCE_CODE" IS 'Code indicating the confidence in the AssessmentType (AssessmentConfidenceCode)';
 
   COMMENT ON TABLE "ATT_ASSESSMNT_TYPE"  IS 'Schema element: AssessmentType';
/
--------------------------------------------------------
--  DDL for Table ATT_ASSESSMNT_UNIT
--------------------------------------------------------

  CREATE TABLE "ATT_ASSESSMNT_UNIT" 
   (	"ATT_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"ATT_ORG_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_UNIT_IDENT" VARCHAR2(50 BYTE), 
	"ASSESSMNT_UNIT_NAME" VARCHAR2(255 BYTE), 
	"LOC_DESC_TXT" VARCHAR2(2000 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"ST_CODE" VARCHAR2(2 BYTE), 
	"STAT_IND" CHAR(1 BYTE), 
	"ASSESSMNT_UNIT_CMNT_TXT" VARCHAR2(4000 BYTE), 
	"USE_CLASS_CNTXT" VARCHAR2(30 BYTE), 
	"USE_CLASS_CODE" VARCHAR2(15 BYTE), 
	"USE_CLASS_NAME" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."ASSESSMNT_UNIT_IDENT" IS 'A unique identifier assigned to the Assessment Unit by the reporting organization (AssessmentUnitIdentifier)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."ASSESSMNT_UNIT_NAME" IS 'Name of Assessment Unit (i.e. GNIS Name) (AssessmentUnitName)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."LOC_DESC_TXT" IS 'Text description of the Assessment Unit location (describes the extent of the Assessment Unit) (LocationDescriptionText)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."ST_CODE" IS 'Geographic state within which the Assessment Unit is contained (StateCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."STAT_IND" IS 'Indicator of whether the Assessment Unit is currently active, or if the identifier has been retired and is being kept for historical tracking purposes and is part of an Assessment Unit History of another Assessment Unit. (StatusIndicator)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."ASSESSMNT_UNIT_CMNT_TXT" IS 'Text to provide a comment on a specific Assessment Unit (AssessmentUnitCommentText)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."USE_CLASS_CNTXT" IS 'Context for the class code (typically OrganizationIdentifier) (UseClassContext)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."USE_CLASS_CODE" IS 'Unique code identifying the use class for this water (UseClassCode)';
 
   COMMENT ON COLUMN "ATT_ASSESSMNT_UNIT"."USE_CLASS_NAME" IS 'name of the use class for this water (UseClassName)';
 
   COMMENT ON TABLE "ATT_ASSESSMNT_UNIT"  IS 'Schema element: AssessmentUnit';
/
--------------------------------------------------------
--  DDL for Table ATT_DELISTED_WTR
--------------------------------------------------------

  CREATE TABLE "ATT_DELISTED_WTR" 
   (	"ATT_DELISTED_WTR_ID" VARCHAR2(36 BYTE), 
	"ATT_REP_CYCLE_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_UNIT_IDENT" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_DELISTED_WTR"."ASSESSMNT_UNIT_IDENT" IS 'A unique identifier assigned to the Assessment Unit by the reporting organization (AssessmentUnitIdentifier)';
 
   COMMENT ON TABLE "ATT_DELISTED_WTR"  IS 'Schema element: DelistedWater';
/
--------------------------------------------------------
--  DDL for Table ATT_DELISTED_WTR_CAUSE
--------------------------------------------------------

  CREATE TABLE "ATT_DELISTED_WTR_CAUSE" 
   (	"ATT_DELISTED_WTR_CAUSE_ID" VARCHAR2(36 BYTE), 
	"ATT_DELISTED_WTR_ID" VARCHAR2(36 BYTE), 
	"CAUSE_NAME" VARCHAR2(240 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"DELISTING_REASON_CODE" VARCHAR2(10 BYTE), 
	"DELISTING_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_DELISTED_WTR_CAUSE"."CAUSE_NAME" IS 'Name of the cause (CauseName)';
 
   COMMENT ON COLUMN "ATT_DELISTED_WTR_CAUSE"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_DELISTED_WTR_CAUSE"."DELISTING_REASON_CODE" IS 'Reason the waterbody/cause is being delisted (DelistingReasonCode)';
 
   COMMENT ON COLUMN "ATT_DELISTED_WTR_CAUSE"."DELISTING_CMNT_TXT" IS 'Free text for providing additional comments on the delisting (DelistingCommentText)';
 
   COMMENT ON TABLE "ATT_DELISTED_WTR_CAUSE"  IS 'Schema element: DelistedWaterCause';
/
--------------------------------------------------------
--  DDL for Table ATT_DOCUMENT
--------------------------------------------------------

  CREATE TABLE "ATT_DOCUMENT" 
   (	"ATT_DOCUMENT_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"ATT_REP_CYCLE_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"DOCUMENT_IDENT" VARCHAR2(30 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"DOCUMENT_TYPE_CODE" VARCHAR2(30 BYTE), 
	"DOCUMENT_FILE_TYPE" VARCHAR2(255 BYTE), 
	"DOCUMENT_FILE_NAME" VARCHAR2(80 BYTE), 
	"DOCUMENT_NAME" VARCHAR2(255 BYTE), 
	"DOCUMENT_DESC" VARCHAR2(255 BYTE), 
	"DOCUMENT_CMNTS" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_IDENT" IS 'A unique identifier for the Document (DocumentIdentifier)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_TYPE_CODE" IS 'Type of document being provided (DocumentTypeCode)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_FILE_TYPE" IS 'The file extension of the document (DocumentFileType)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_FILE_NAME" IS 'File of the document. Should be the file name of the document, including the extension (.doc, .pdf, etc.). The document must be included in a .zip file with this name and included in the submission along with the XML file. (DocumentFileName)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_NAME" IS 'Name of the document (DocumentName)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_DESC" IS 'Description of the document (DocumentDescription)';
 
   COMMENT ON COLUMN "ATT_DOCUMENT"."DOCUMENT_CMNTS" IS 'Free text for providing additional comments on the document. (DocumentComments)';
 
   COMMENT ON TABLE "ATT_DOCUMENT"  IS 'Schema element: Document';
/
--------------------------------------------------------
--  DDL for Table ATT_LEGACY_NPDES
--------------------------------------------------------

  CREATE TABLE "ATT_LEGACY_NPDES" 
   (	"ATT_LEGACY_NPDES_ID" VARCHAR2(36 BYTE), 
	"ATT_SPECIFIC_WTR_CAUSE_ID" VARCHAR2(36 BYTE), 
	"NPDES_IDENT" VARCHAR2(60 BYTE), 
	"OTHR_IDENT" VARCHAR2(60 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_LEGACY_NPDES"."NPDES_IDENT" IS 'Unique identifier for a permit as assigned by the NPDES program (NPDESIdentifier)';
 
   COMMENT ON COLUMN "ATT_LEGACY_NPDES"."OTHR_IDENT" IS 'Other state identifier for a permit (OtherIdentifier)';
 
   COMMENT ON TABLE "ATT_LEGACY_NPDES"  IS 'Schema element: LegacyNPDESDetails';
/
--------------------------------------------------------
--  DDL for Table ATT_LOC
--------------------------------------------------------

  CREATE TABLE "ATT_LOC" 
   (	"ATT_LOC_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"ATT_PRIO_ID" VARCHAR2(36 BYTE), 
	"LOC_TYPE_CNTXT" VARCHAR2(30 BYTE), 
	"LOC_TYPE_CODE" VARCHAR2(20 BYTE), 
	"LOC_TXT" VARCHAR2(100 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_LOC"."LOC_TYPE_CNTXT" IS 'Context for the LocationTypeCode (typically OrganizationIdentifier) (LocationTypeContext)';
 
   COMMENT ON COLUMN "ATT_LOC"."LOC_TYPE_CODE" IS 'Description of the type of location (i.e. 8-digit HUC, County, etc.) (LocationTypeCode)';
 
   COMMENT ON COLUMN "ATT_LOC"."LOC_TXT" IS 'Value for the location (LocationText)';
 
   COMMENT ON TABLE "ATT_LOC"  IS 'Schema element: Location';
/
--------------------------------------------------------
--  DDL for Table ATT_MOD
--------------------------------------------------------

  CREATE TABLE "ATT_MOD" 
   (	"ATT_MOD_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"MOD_TYPE_CODE" VARCHAR2(25 BYTE), 
	"CHANGE_CYCLE_TXT" VARCHAR2(4 BYTE), 
	"CHANGE_DESC_TXT" VARCHAR2(255 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_MOD"."MOD_TYPE_CODE" IS 'Code representing the type of modification that was made. (ModificationTypeCode)';
 
   COMMENT ON COLUMN "ATT_MOD"."CHANGE_CYCLE_TXT" IS 'First Assessment Cycle when then change occurred (ChangeCycleText)';
 
   COMMENT ON COLUMN "ATT_MOD"."CHANGE_DESC_TXT" IS 'Text describing the change made to the Assessment Unit (ChangeDescriptionText)';
 
   COMMENT ON TABLE "ATT_MOD"  IS 'Schema element: Modification';
/
--------------------------------------------------------
--  DDL for Table ATT_MON_STATION
--------------------------------------------------------

  CREATE TABLE "ATT_MON_STATION" 
   (	"ATT_MON_STATION_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"MON_ORG_IDENT" VARCHAR2(30 BYTE), 
	"MON_LOC_IDENT" VARCHAR2(35 BYTE), 
	"MON_DATA_LINK_TXT" VARCHAR2(255 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_MON_STATION"."MON_ORG_IDENT" IS 'Organization that conducted the monitoring. For data that is available via STORET/WQX or the Water Quality portal, this Organization ID is a unique ID assigned by EPA, or other agency responsible for assigning organizations. (MonitoringOrganizationIdentifier)';
 
   COMMENT ON COLUMN "ATT_MON_STATION"."MON_LOC_IDENT" IS 'Unique identifier for the monitoring location (MonitoringLocationIdentifier)';
 
   COMMENT ON COLUMN "ATT_MON_STATION"."MON_DATA_LINK_TXT" IS 'URL providing the link to the monitoring data for this station. For Water Quality Portal data, this link should be the Restful URL that would provide access to the data. (MonitoringDataLinkText)';
 
   COMMENT ON TABLE "ATT_MON_STATION"  IS 'Schema element: MonitoringStation';
/
--------------------------------------------------------
--  DDL for Table ATT_NPDES
--------------------------------------------------------

  CREATE TABLE "ATT_NPDES" 
   (	"ATT_NPDES_ID" VARCHAR2(36 BYTE), 
	"ATT_POLUT_ID" VARCHAR2(36 BYTE), 
	"NPDES_IDENT" VARCHAR2(60 BYTE), 
	"OTHR_IDENT" VARCHAR2(60 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_NPDES"."NPDES_IDENT" IS 'Unique identifier for a permit as assigned by the NPDES program (NPDESIdentifier)';
 
   COMMENT ON COLUMN "ATT_NPDES"."OTHR_IDENT" IS 'Other state identifier for a permit (OtherIdentifier)';
 
   COMMENT ON TABLE "ATT_NPDES"  IS 'Schema element: NPDESDetails';
/
--------------------------------------------------------
--  DDL for Table ATT_ORG
--------------------------------------------------------

  CREATE TABLE "ATT_ORG" 
   (	"ATT_ORG_ID" VARCHAR2(36 BYTE), 
	"ORG_IDENT" VARCHAR2(30 BYTE), 
	"ORG_NAME" VARCHAR2(150 BYTE), 
	"ORG_TYPE" VARCHAR2(30 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ORG"."ORG_IDENT" IS 'A unique identifier assigned to the organization. Identifiers would be managed centrally by EPA (OrganizationIdentifier)';
 
   COMMENT ON COLUMN "ATT_ORG"."ORG_NAME" IS 'Name corresponding to unique organization ID (i.e. Utah Division of Water Quality); org name will be ignored on submission, for outbound services only (OrganizationName)';
 
   COMMENT ON COLUMN "ATT_ORG"."ORG_TYPE" IS 'State/tribe/territory; org name will be ignored on submission, for outbound services only (OrganizationType)';
 
   COMMENT ON TABLE "ATT_ORG"  IS 'Schema element: Organization';
/
--------------------------------------------------------
--  DDL for Table ATT_ORG_CONTACT
--------------------------------------------------------

  CREATE TABLE "ATT_ORG_CONTACT" 
   (	"ATT_ORG_CONTACT_ID" VARCHAR2(36 BYTE), 
	"ATT_ORG_ID" VARCHAR2(36 BYTE), 
	"CONTACT_TYPE" VARCHAR2(35 BYTE), 
	"WEB_URL_TXT" VARCHAR2(255 BYTE), 
	"SUB_ORG_NAME" VARCHAR2(150 BYTE), 
	"EMAIL_ADDR_TXT" VARCHAR2(240 BYTE), 
	"FIRST_NAME" VARCHAR2(15 BYTE), 
	"MIDDLE_INITIAL" CHAR(1 BYTE), 
	"LAST_NAME" VARCHAR2(15 BYTE), 
	"INDVL_TITLE_TXT" VARCHAR2(45 BYTE), 
	"TELEPH_NUM_TXT" VARCHAR2(15 BYTE), 
	"PHONE_EXT_TXT" VARCHAR2(6 BYTE), 
	"FAX_NUM_TXT" VARCHAR2(15 BYTE), 
	"MAILING_ADDR_TXT" VARCHAR2(30 BYTE), 
	"SUPPL_ADDR_TXT" VARCHAR2(30 BYTE), 
	"MAILING_ADDR_CITY_NAME" VARCHAR2(25 BYTE), 
	"MAILING_ADDR_ST_USPS_CODE" VARCHAR2(2 BYTE), 
	"MAILING_ADDR_COUNTRY_CODE" VARCHAR2(2 BYTE), 
	"MAILING_ADDR_ZIP_CODE" VARCHAR2(14 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ORG_CONTACT"."CONTACT_TYPE" IS 'Area of responsibility for this contact (TMDL Program, 303(d) Program, Monitoring, Assessment, NPS) (ContactType)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."WEB_URL_TXT" IS 'Organization web link for more information (WebURLText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."SUB_ORG_NAME" IS 'Name of the suborganzation who has responsibilty for this area (SubOrganizationName)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."EMAIL_ADDR_TXT" IS 'Email address for requesting additional information (EmailAddressText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."FIRST_NAME" IS 'First name of a person. (FirstName)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."MIDDLE_INITIAL" IS 'Middle Initial of a person. (MiddleInitial)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."LAST_NAME" IS 'Last name of a person. (LastName)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."INDVL_TITLE_TXT" IS 'Title of the contact person. (IndividualTitleText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."TELEPH_NUM_TXT" IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."PHONE_EXT_TXT" IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."FAX_NUM_TXT" IS 'Fax Number (FaxNumberText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."MAILING_ADDR_TXT" IS 'Mailing Address (MailingAddressText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."SUPPL_ADDR_TXT" IS 'Additional Address Information (SupplementalAddressText)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."MAILING_ADDR_CITY_NAME" IS 'City or Locality Name (MailingAddressCityName)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."MAILING_ADDR_ST_USPS_CODE" IS 'State USPS Code (i.e. KS) (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."MAILING_ADDR_COUNTRY_CODE" IS 'Country Name (MailingAddressCountryCode)';
 
   COMMENT ON COLUMN "ATT_ORG_CONTACT"."MAILING_ADDR_ZIP_CODE" IS 'Zip Code (MailingAddressZIPCode)';
 
   COMMENT ON TABLE "ATT_ORG_CONTACT"  IS 'Schema element: OrganizationContact';
/
--------------------------------------------------------
--  DDL for Table ATT_PARAM
--------------------------------------------------------

  CREATE TABLE "ATT_PARAM" 
   (	"ATT_PARAM_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"PARAM_STAT_NAME" VARCHAR2(30 BYTE), 
	"PARAM_NAME" VARCHAR2(240 BYTE), 
	"PARAM_CMNT_TXT" VARCHAR2(4000 BYTE), 
	"POLUT_IND" CHAR(1 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"CYCLE_FIRST_LISTED_TXT" VARCHAR2(4 BYTE), 
	"CYCLE_SCHD_FOR_TMDL_TXT" VARCHAR2(4 BYTE), 
	"CWA_303D_PRIO_RANKING_TXT" VARCHAR2(25 BYTE), 
	"CONSENT_DECREE_CYCLE_TXT" VARCHAR2(4 BYTE), 
	"ALTERNATE_LISTING_IDENT" VARCHAR2(50 BYTE), 
	"CYCLE_EXPECTED_TO_ATTAIN_TXT" VARCHAR2(4 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PARAM"."PARAM_STAT_NAME" IS 'Status for the parameter indicating whether this parameter is a cause, observed effect, or provided for informational purposes as a monitored parameter. (ParameterStatusName)';
 
   COMMENT ON COLUMN "ATT_PARAM"."PARAM_NAME" IS 'Name of the parameter (ParameterName)';
 
   COMMENT ON COLUMN "ATT_PARAM"."PARAM_CMNT_TXT" IS 'Free text providing additional comments for the parameter (ParameterCommentText)';
 
   COMMENT ON COLUMN "ATT_PARAM"."POLUT_IND" IS 'Flag indicating whether or not the cause is a pollutant (PollutantIndicator)';
 
   COMMENT ON COLUMN "ATT_PARAM"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_PARAM"."CYCLE_FIRST_LISTED_TXT" IS 'Cycle the Assessment Unit was first listed for this cause (CycleFirstListedText)';
 
   COMMENT ON COLUMN "ATT_PARAM"."CYCLE_SCHD_FOR_TMDL_TXT" IS 'Cycle when the jurisdiction anticipates submitting the TMDL for EPA approval (CycleScheduledForTMDLText)';
 
   COMMENT ON COLUMN "ATT_PARAM"."CWA_303D_PRIO_RANKING_TXT" IS 'CWA 303(d) priority for developing a TMDL (i.e. High, Medium, Low) (CWA303dPriorityRankingText)';
 
   COMMENT ON COLUMN "ATT_PARAM"."CONSENT_DECREE_CYCLE_TXT" IS 'Cycle for which Consent Decree actions are due (ConsentDecreeCycleText)';
 
   COMMENT ON COLUMN "ATT_PARAM"."ALTERNATE_LISTING_IDENT" IS 'Unique identifier for the listed water. Use this identifier ONLY if the listing identifier is different from the Assessment Unit Identifier (AlternateListingIdentifier)';
 
   COMMENT ON COLUMN "ATT_PARAM"."CYCLE_EXPECTED_TO_ATTAIN_TXT" IS 'Cycle by which the Assessment Unit is expected to attain its standards (used to indicate whether or not this cause should be considered towards category 4B) (CycleExpectedToAttainText)';
 
   COMMENT ON TABLE "ATT_PARAM"  IS 'Schema element: Parameter';
/
--------------------------------------------------------
--  DDL for Table ATT_POLUT
--------------------------------------------------------

  CREATE TABLE "ATT_POLUT" 
   (	"ATT_POLUT_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"POLUT_NAME" VARCHAR2(240 BYTE), 
	"POLUT_SRC_TYPE_CODE" VARCHAR2(40 BYTE), 
	"JUSTIFICATION_URL_TXT" VARCHAR2(255 BYTE), 
	"TTL_LOAD_ALLOCTN_NUM" NUMBER(12,6), 
	"TTL_LOAD_ALLOCTN_UNTS_TXT" VARCHAR2(20 BYTE), 
	"TTL_WSTE_LOAD_ALLOCTN_NUM" NUMBER(12,6), 
	"TTL_WSTE_LOAD_ALLOCTN_UNTS_TXT" VARCHAR2(20 BYTE), 
	"EXPLICIT_MARGINOF_SAFETY_TXT" VARCHAR2(255 BYTE), 
	"IMPLICIT_MARGINOF_SAFETY_TXT" VARCHAR2(255 BYTE), 
	"TMDL_END_POINT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_POLUT"."POLUT_NAME" IS 'Name of the pollutant (PollutantName)';
 
   COMMENT ON COLUMN "ATT_POLUT"."POLUT_SRC_TYPE_CODE" IS 'Are the sources of the pollutant point source, nonpoint source or both. (PollutantSourceTypeCode)';
 
   COMMENT ON COLUMN "ATT_POLUT"."JUSTIFICATION_URL_TXT" IS 'URL providing the link to find more information about the 4B activity. (JustificationURLText)';
 
   COMMENT ON COLUMN "ATT_POLUT"."TTL_LOAD_ALLOCTN_NUM" IS 'Total load allocation for this pollutant (TotalLoadAllocationNumber)';
 
   COMMENT ON COLUMN "ATT_POLUT"."TTL_LOAD_ALLOCTN_UNTS_TXT" IS 'Unit of measure for total load allocation (TotalLoadAllocationUnitsText)';
 
   COMMENT ON COLUMN "ATT_POLUT"."TTL_WSTE_LOAD_ALLOCTN_NUM" IS 'Total waste load allocation for this pollutant (TotalWasteLoadAllocationNumber)';
 
   COMMENT ON COLUMN "ATT_POLUT"."TTL_WSTE_LOAD_ALLOCTN_UNTS_TXT" IS 'Unit of measure for total waste load allocation (TotalWasteLoadAllocationUnitsText)';
 
   COMMENT ON COLUMN "ATT_POLUT"."EXPLICIT_MARGINOF_SAFETY_TXT" IS 'Explicit margin of safety for the load allocation (ExplicitMarginofSafetyText)';
 
   COMMENT ON COLUMN "ATT_POLUT"."IMPLICIT_MARGINOF_SAFETY_TXT" IS 'Implicit margin of safety for the load allocation (ImplicitMarginofSafetyText)';
 
   COMMENT ON COLUMN "ATT_POLUT"."TMDL_END_POINT_TXT" IS 'Free text describing the TMDL End Point (TMDLEndPointText)';
 
   COMMENT ON TABLE "ATT_POLUT"  IS 'Schema element: Pollutant';
/
--------------------------------------------------------
--  DDL for Table ATT_PREVIOUS_ASSESSMNT_UNIT
--------------------------------------------------------

  CREATE TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT" 
   (	"ATT_PREVIOUS_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"ATT_MOD_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_UNIT_IDENT" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PREVIOUS_ASSESSMNT_UNIT"."ASSESSMNT_UNIT_IDENT" IS 'A unique identifier assigned to the Assessment Unit by the reporting organization (AssessmentUnitIdentifier)';
 
   COMMENT ON TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT"  IS 'Schema element: PreviousAssessmentUnit';
/
--------------------------------------------------------
--  DDL for Table ATT_PRIO
--------------------------------------------------------

  CREATE TABLE "ATT_PRIO" 
   (	"ATT_PRIO_ID" VARCHAR2(36 BYTE), 
	"ATT_ORG_ID" VARCHAR2(36 BYTE), 
	"PRIO_STAT" VARCHAR2(255 BYTE), 
	"PRIO_STAT_DATE" TIMESTAMP (6), 
	"PRIO_IDENT" VARCHAR2(50 BYTE), 
	"PRIO_NAME" VARCHAR2(240 BYTE), 
	"CYCLE_BASE_LINE" VARCHAR2(4 BYTE), 
	"CYCLE_GOAL" VARCHAR2(4 BYTE), 
	"PRIO_TYPE_CODE" VARCHAR2(25 BYTE), 
	"PRIO_DESC" VARCHAR2(2000 BYTE), 
	"PRIO_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PRIO"."PRIO_STAT" IS 'Status of the Prority (PriorityStatus)';
 
   COMMENT ON COLUMN "ATT_PRIO"."PRIO_STAT_DATE" IS 'Date the status was changed (PriorityStatusDate)';
 
   COMMENT ON COLUMN "ATT_PRIO"."PRIO_IDENT" IS 'Unique identifier for a priority (PriorityIdentifier)';
 
   COMMENT ON COLUMN "ATT_PRIO"."PRIO_NAME" IS 'Name for the priority (PriorityName)';
 
   COMMENT ON COLUMN "ATT_PRIO"."CYCLE_BASE_LINE" IS 'Cycle that is the baseline for the priority (starting cycle) (CycleBaseLine)';
 
   COMMENT ON COLUMN "ATT_PRIO"."CYCLE_GOAL" IS 'Cycle that is the goal for the priority (ending cycle) (CycleGoal)';
 
   COMMENT ON COLUMN "ATT_PRIO"."PRIO_TYPE_CODE" IS 'Code identifying the type of priority that is being set (PriorityTypeCode)';
 
   COMMENT ON COLUMN "ATT_PRIO"."PRIO_DESC" IS 'Description of the priority (PriorityDescription)';
 
   COMMENT ON COLUMN "ATT_PRIO"."PRIO_CMNT_TXT" IS 'Free text providing additional comments on the priority (PriorityCommentText)';
 
   COMMENT ON TABLE "ATT_PRIO"  IS 'Schema element: Priority';
/
--------------------------------------------------------
--  DDL for Table ATT_PRIOR_CAUSE
--------------------------------------------------------

  CREATE TABLE "ATT_PRIOR_CAUSE" 
   (	"ATT_PRIOR_CAUSE_ID" VARCHAR2(36 BYTE), 
	"ATT_PARAM_ID" VARCHAR2(36 BYTE), 
	"PRIOR_CAUSE_NAME" VARCHAR2(240 BYTE), 
	"PRIOR_CAUSE_CYCLE_TXT" VARCHAR2(4 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PRIOR_CAUSE"."PRIOR_CAUSE_NAME" IS 'Prior name for the cause for this Assessment Unit (PriorCauseName)';
 
   COMMENT ON COLUMN "ATT_PRIOR_CAUSE"."PRIOR_CAUSE_CYCLE_TXT" IS 'Cycle for the prior cause that is being replaced with or related to the cause. (PriorCauseCycleText)';
 
   COMMENT ON TABLE "ATT_PRIOR_CAUSE"  IS 'Schema element: PriorCause';
/
--------------------------------------------------------
--  DDL for Table ATT_PRIO_ASSESSMNT_UNIT
--------------------------------------------------------

  CREATE TABLE "ATT_PRIO_ASSESSMNT_UNIT" 
   (	"ATT_PRIO_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"ATT_PRIO_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_UNIT_IDENT" VARCHAR2(50 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PRIO_ASSESSMNT_UNIT"."ASSESSMNT_UNIT_IDENT" IS 'A unique identifier assigned to the Assessment Unit by the reporting organization (AssessmentUnitIdentifier)';
 
   COMMENT ON TABLE "ATT_PRIO_ASSESSMNT_UNIT"  IS 'Schema element: PriorityAssessmentUnit';
/
--------------------------------------------------------
--  DDL for Table ATT_PRIO_CAUSE
--------------------------------------------------------

  CREATE TABLE "ATT_PRIO_CAUSE" 
   (	"ATT_PRIO_CAUSE_ID" VARCHAR2(36 BYTE), 
	"ATT_PRIO_ID" VARCHAR2(36 BYTE), 
	"CAUSE_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PRIO_CAUSE"."CAUSE_NAME" IS 'Name of the cause (CauseName)';
 
   COMMENT ON TABLE "ATT_PRIO_CAUSE"  IS 'Schema element: PriorityCause';
/
--------------------------------------------------------
--  DDL for Table ATT_PRIO_USE
--------------------------------------------------------

  CREATE TABLE "ATT_PRIO_USE" 
   (	"ATT_PRIO_USE_ID" VARCHAR2(36 BYTE), 
	"ATT_PRIO_ID" VARCHAR2(36 BYTE), 
	"USE_NAME" VARCHAR2(255 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PRIO_USE"."USE_NAME" IS 'Name of the designated use. (UseName)';
 
   COMMENT ON TABLE "ATT_PRIO_USE"  IS 'Schema element: PriorityUse';
/
--------------------------------------------------------
--  DDL for Table ATT_PROBABLE_SRC
--------------------------------------------------------

  CREATE TABLE "ATT_PROBABLE_SRC" 
   (	"ATT_PROBABLE_SRC_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"SRC_NAME" VARCHAR2(240 BYTE), 
	"SRC_CONFIRMED_IND" CHAR(1 BYTE), 
	"SRC_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_PROBABLE_SRC"."SRC_NAME" IS 'Name of the source (SourceName)';
 
   COMMENT ON COLUMN "ATT_PROBABLE_SRC"."SRC_CONFIRMED_IND" IS 'Indicator of whether the source has been confirmed (SourceConfirmedIndicator)';
 
   COMMENT ON COLUMN "ATT_PROBABLE_SRC"."SRC_CMNT_TXT" IS 'Free text for providing additional comments on the source (SourceCommentText)';
 
   COMMENT ON TABLE "ATT_PROBABLE_SRC"  IS 'Schema element: ProbableSource';
/
--------------------------------------------------------
--  DDL for Table ATT_RELATED_TMD_LS
--------------------------------------------------------

  CREATE TABLE "ATT_RELATED_TMD_LS" 
   (	"ATT_RELATED_TMD_LS_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"TMDL_REP_IDENT" VARCHAR2(45 BYTE), 
	"CHANGE_TYPE_TXT" VARCHAR2(255 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_RELATED_TMD_LS"."TMDL_REP_IDENT" IS 'Unique code identifying the TMDL Report (TMDLReportIdentifier)';
 
   COMMENT ON COLUMN "ATT_RELATED_TMD_LS"."CHANGE_TYPE_TXT" IS 'Free text describing the relationship between the TMDLs (ChangeTypeText)';
 
   COMMENT ON TABLE "ATT_RELATED_TMD_LS"  IS 'Schema element: RelatedTMDLs';
/
--------------------------------------------------------
--  DDL for Table ATT_REP_CYCLE
--------------------------------------------------------

  CREATE TABLE "ATT_REP_CYCLE" 
   (	"ATT_REP_CYCLE_ID" VARCHAR2(36 BYTE), 
	"ATT_ORG_ID" VARCHAR2(36 BYTE), 
	"REP_CYCLE_TXT" VARCHAR2(4 BYTE), 
	"REP_STAT_CODE" VARCHAR2(30 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_REP_CYCLE"."REP_CYCLE_TXT" IS 'Reporting cycle for the Assessments (ReportingCycleText)';
 
   COMMENT ON COLUMN "ATT_REP_CYCLE"."REP_STAT_CODE" IS 'Status of the report or 303(d) list (i.e. Final, Draft, Public Comment, etc.) (ReportStatusCode)';
 
   COMMENT ON TABLE "ATT_REP_CYCLE"  IS 'Schema element: ReportingCycle';
/
--------------------------------------------------------
--  DDL for Table ATT_REVIEW_CMNT
--------------------------------------------------------

  CREATE TABLE "ATT_REVIEW_CMNT" 
   (	"ATT_REVIEW_CMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"REVIEW_CMNT_TXT" VARCHAR2(4000 BYTE), 
	"REVIEW_CMNT_DATE" TIMESTAMP (6), 
	"REVIEW_CMNT_USR_NAME" VARCHAR2(30 BYTE), 
	"ORG_IDENT" VARCHAR2(30 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_REVIEW_CMNT"."REVIEW_CMNT_TXT" IS 'The actual comment (ReviewCommentText)';
 
   COMMENT ON COLUMN "ATT_REVIEW_CMNT"."REVIEW_CMNT_DATE" IS 'The date the comment was made (ReviewCommentDate)';
 
   COMMENT ON COLUMN "ATT_REVIEW_CMNT"."REVIEW_CMNT_USR_NAME" IS 'The userName of the commenter (ReviewCommentUserName)';
 
   COMMENT ON COLUMN "ATT_REVIEW_CMNT"."ORG_IDENT" IS 'A unique identifier assigned to the organization. Identifiers would be managed centrally by EPA (OrganizationIdentifier)';
 
   COMMENT ON TABLE "ATT_REVIEW_CMNT"  IS 'Schema element: ReviewComment';
/
--------------------------------------------------------
--  DDL for Table ATT_SEASON
--------------------------------------------------------

  CREATE TABLE "ATT_SEASON" 
   (	"ATT_SEASON_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSC_USE_ID" VARCHAR2(36 BYTE), 
	"ATT_POLUT_ID" VARCHAR2(36 BYTE), 
	"SEASON_START_TXT" VARCHAR2(5 BYTE), 
	"SEASON_END_TXT" VARCHAR2(5 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_SEASON"."SEASON_START_TXT" IS 'The month and day for the start of when the parameter was evaluated or when the Action applies (DD/MM) (SeasonStartText)';
 
   COMMENT ON COLUMN "ATT_SEASON"."SEASON_END_TXT" IS 'The month and day for the end of when the parameter was evaluated or when the Action applies (DD/MM) (SeasonEndText)';
 
   COMMENT ON TABLE "ATT_SEASON"  IS 'Schema element: Season';
/
--------------------------------------------------------
--  DDL for Table ATT_SPECIFIC_WTR
--------------------------------------------------------

  CREATE TABLE "ATT_SPECIFIC_WTR" 
   (	"ATT_SPECIFIC_WTR_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"ASSESSMNT_UNIT_IDENT" VARCHAR2(50 BYTE), 
	"UNLISTED_WTR_IND" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_SPECIFIC_WTR"."ASSESSMNT_UNIT_IDENT" IS 'A unique identifier assigned to the Assessment Unit by the reporting organization (AssessmentUnitIdentifier)';
 
   COMMENT ON COLUMN "ATT_SPECIFIC_WTR"."UNLISTED_WTR_IND" IS 'Indicates if the water is an unlisted water. (UnlistedWaterIndicator)';
 
   COMMENT ON TABLE "ATT_SPECIFIC_WTR"  IS 'Schema element: SpecificWater';
/
--------------------------------------------------------
--  DDL for Table ATT_SPECIFIC_WTR_CAUSE
--------------------------------------------------------

  CREATE TABLE "ATT_SPECIFIC_WTR_CAUSE" 
   (	"ATT_SPECIFIC_WTR_CAUSE_ID" VARCHAR2(36 BYTE), 
	"ATT_SPECIFIC_WTR_ID" VARCHAR2(36 BYTE), 
	"CAUSE_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_SPECIFIC_WTR_CAUSE"."CAUSE_NAME" IS 'Name of the cause (CauseName)';
 
   COMMENT ON TABLE "ATT_SPECIFIC_WTR_CAUSE"  IS 'Schema element: SpecificWaterCause';
/
--------------------------------------------------------
--  DDL for Table ATT_SRC
--------------------------------------------------------

  CREATE TABLE "ATT_SRC" 
   (	"ATT_SRC_ID" VARCHAR2(36 BYTE), 
	"ATT_SPECIFIC_WTR_ID" VARCHAR2(36 BYTE), 
	"SRC_NAME" VARCHAR2(240 BYTE), 
	"SRC_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_SRC"."SRC_NAME" IS 'Name of the source (SourceName)';
 
   COMMENT ON COLUMN "ATT_SRC"."SRC_CMNT_TXT" IS 'Free text for providing additional comments on the source (SourceCommentText)';
 
   COMMENT ON TABLE "ATT_SRC"  IS 'Schema element: Source';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_INTEGRATED_REP_CATG
--------------------------------------------------------

  CREATE TABLE "ATT_ST_INTEGRATED_REP_CATG" 
   (	"ATT_ST_INTEGRATED_REP_CATG_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_USE_ATTAINMENT_ID" VARCHAR2(36 BYTE), 
	"ATT_PARAM_ID" VARCHAR2(36 BYTE), 
	"ST_IR_CATG_CODE" VARCHAR2(5 BYTE), 
	"ST_CATG_DESC_TXT" VARCHAR2(255 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_INTEGRATED_REP_CATG"."ST_IR_CATG_CODE" IS 'State Integrated Reporting Category (StateIRCategoryCode)';
 
   COMMENT ON COLUMN "ATT_ST_INTEGRATED_REP_CATG"."ST_CATG_DESC_TXT" IS 'Description of the State IR Category (StateCategoryDescriptionText)';
 
   COMMENT ON TABLE "ATT_ST_INTEGRATED_REP_CATG"  IS 'Schema element: StateIntegratedReportingCategory';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_ACTN
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_ACTN" 
   (	"ATT_ST_WIDE_ACTN_ID" VARCHAR2(36 BYTE), 
	"ATT_ACTN_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_ASSESSMNT_IDENT" VARCHAR2(45 BYTE), 
	"ST_WIDE_CYCLE" VARCHAR2(4 BYTE), 
	"ST_WIDE_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_ACTN"."ST_WIDE_ASSESSMNT_IDENT" IS 'Unique code identifying the statewide assessment (StateWideAssessmentIdentifier)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_ACTN"."ST_WIDE_CYCLE" IS 'Cycle when the statewide assessment was made (StateWideCycle)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_ACTN"."ST_WIDE_CMNT_TXT" IS 'Free text for providing additional comments on the statewide assessment or action (StateWideCommentText)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_ACTN"  IS 'Schema element: StateWideAction';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_ASSESSMNT
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_ASSESSMNT" 
   (	"ATT_ST_WIDE_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_REP_CYCLE_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_ASSESSMNT_NAME" VARCHAR2(255 BYTE), 
	"ST_WIDE_ASSESSMNT_IDENT" VARCHAR2(45 BYTE), 
	"ST_WIDE_CMNT_TXT" VARCHAR2(4000 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_ASSESSMNT"."ST_WIDE_ASSESSMNT_NAME" IS 'Common name that this statewide assessment is referred by. (StateWideAssessmentName)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_ASSESSMNT"."ST_WIDE_ASSESSMNT_IDENT" IS 'Unique code identifying the statewide assessment (StateWideAssessmentIdentifier)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_ASSESSMNT"."ST_WIDE_CMNT_TXT" IS 'Free text for providing additional comments on the statewide assessment or action (StateWideCommentText)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_ASSESSMNT"  IS 'Schema element: StateWideAssessment';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_CAUSE
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_CAUSE" 
   (	"ATT_ST_WIDE_CAUSE_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ACTN_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_CAUSE_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_CAUSE"."ST_WIDE_CAUSE_NAME" IS 'Name of cause (StateWideCauseName)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_CAUSE"  IS 'Schema element: StateWideCause';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_PROBABLE_SRC
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_PROBABLE_SRC" 
   (	"ATT_ST_WIDE_PROBABLE_SRC_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_PROBABLE_SRC_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_PROBABLE_SRC"."ST_WIDE_PROBABLE_SRC_NAME" IS 'Name of probable source (StateWideProbableSourceName)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_PROBABLE_SRC"  IS 'Schema element: StateWideProbableSource';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_SRC
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_SRC" 
   (	"ATT_ST_WIDE_SRC_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ACTN_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_SRC_NAME" VARCHAR2(240 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_SRC"."ST_WIDE_SRC_NAME" IS 'Name of source (StateWideSourceName)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_SRC"  IS 'Schema element: StateWideSource';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_USE_ATTAINMENT
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_USE_ATTAINMENT" 
   (	"ATT_ST_WIDE_USE_ATTAINMENT_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_USE_NAME" VARCHAR2(255 BYTE), 
	"USE_ATTAINMENT_CODE" CHAR(1 BYTE), 
	"THREATENED_IND" CHAR(1 BYTE), 
	"TREND_CODE" VARCHAR2(25 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_USE_ATTAINMENT"."ST_WIDE_USE_NAME" IS 'Name of the designated use. (StateWideUseName)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_USE_ATTAINMENT"."USE_ATTAINMENT_CODE" IS 'Code identifying the use attainment for this use (UseAttainmentCode)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_USE_ATTAINMENT"."THREATENED_IND" IS 'Indicator identifying whether or not the use is threatened. If this code is set to ''Y'' AttainmentCode should typically be ''Fully Supporting''. Not reporting this data element is equivelent to saying ThreantenedIndicator=''N''. (ThreatenedIndicator)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_USE_ATTAINMENT"."TREND_CODE" IS 'Code representing the water quality trend for this use or parameter. (TrendCode)';
 
   COMMENT ON COLUMN "ATT_ST_WIDE_USE_ATTAINMENT"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_USE_ATTAINMENT"  IS 'Schema element: StateWideUseAttainment';
/
--------------------------------------------------------
--  DDL for Table ATT_ST_WIDE_WTR_TYPE
--------------------------------------------------------

  CREATE TABLE "ATT_ST_WIDE_WTR_TYPE" 
   (	"ATT_ST_WIDE_WTR_TYPE_ID" VARCHAR2(36 BYTE), 
	"ATT_ST_WIDE_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"ST_WIDE_WTR_TYPE_CODE" VARCHAR2(40 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_ST_WIDE_WTR_TYPE"."ST_WIDE_WTR_TYPE_CODE" IS 'Code representing the water type (StateWideWaterTypeCode)';
 
   COMMENT ON TABLE "ATT_ST_WIDE_WTR_TYPE"  IS 'Schema element: StateWideWaterType';
/
--------------------------------------------------------
--  DDL for Table ATT_TMDLNPDES
--------------------------------------------------------

  CREATE TABLE "ATT_TMDLNPDES" 
   (	"ATT_TMDLNPDES_ID" VARCHAR2(36 BYTE), 
	"ATT_LEGACY_NPDES_ID" VARCHAR2(36 BYTE), 
	"ATT_NPDES_ID" VARCHAR2(36 BYTE), 
	"WSTE_LOAD_ALLOCTN_NUM" NUMBER(12,6), 
	"WSTE_LOAD_ALLOCTN_UNTS_TXT" VARCHAR2(20 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_TMDLNPDES"."WSTE_LOAD_ALLOCTN_NUM" IS 'Waste load allocation assigned to this Permittee (WasteLoadAllocationNumeric)';
 
   COMMENT ON COLUMN "ATT_TMDLNPDES"."WSTE_LOAD_ALLOCTN_UNTS_TXT" IS 'Unit of measure for waste load allocation (WasteLoadAllocationUnitsText)';
 
   COMMENT ON TABLE "ATT_TMDLNPDES"  IS 'Schema element: TMDLNPDES';
/
--------------------------------------------------------
--  DDL for Table ATT_USE_ATTAINMENT
--------------------------------------------------------

  CREATE TABLE "ATT_USE_ATTAINMENT" 
   (	"ATT_USE_ATTAINMENT_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_ID" VARCHAR2(36 BYTE), 
	"USE_NAME" VARCHAR2(255 BYTE), 
	"USE_ATTAINMENT_CODE" CHAR(1 BYTE), 
	"THREATENED_IND" CHAR(1 BYTE), 
	"TREND_CODE" VARCHAR2(25 BYTE), 
	"AGNCY_CODE" CHAR(1 BYTE), 
	"USE_CMNT_TXT" VARCHAR2(4000 BYTE), 
	"ASSESSMNT_BASIS_CODE" VARCHAR2(30 BYTE), 
	"MON_START_DATE" TIMESTAMP (6), 
	"MON_END_DATE" TIMESTAMP (6), 
	"ASSESSMNT_DATE" TIMESTAMP (6), 
	"ASSESSOR_NAME" VARCHAR2(80 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."USE_NAME" IS 'Name of the designated use. (UseName)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."USE_ATTAINMENT_CODE" IS 'Code identifying the use attainment for this use (UseAttainmentCode)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."THREATENED_IND" IS 'Indicator identifying whether or not the use is threatened. If this code is set to ''Y'' AttainmentCode should typically be ''Fully Supporting''. Not reporting this data element is equivelent to saying ThreantenedIndicator=''N''. (ThreatenedIndicator)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."TREND_CODE" IS 'Code representing the water quality trend for this use or parameter. (TrendCode)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."AGNCY_CODE" IS 'Code identifying the agency responsible for the action (S=State, E=EPA, T=Tribal) (AgencyCode)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."USE_CMNT_TXT" IS 'Free text for providing additional comments on the use assessment (UseCommentText)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."ASSESSMNT_BASIS_CODE" IS 'Code representing the basis for the assessment; is it based on monitored data, extrapolated data, or both. (AssessmentBasisCode)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."MON_START_DATE" IS 'Date on which monitoring began (MonitoringStartDate)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."MON_END_DATE" IS 'Date on which monitoring ended (MonitoringEndDate)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."ASSESSMNT_DATE" IS 'Day on which the assessment was completed (AssessmentDate)';
 
   COMMENT ON COLUMN "ATT_USE_ATTAINMENT"."ASSESSOR_NAME" IS 'Name of the individual performing the assessment (AssessorName)';
 
   COMMENT ON TABLE "ATT_USE_ATTAINMENT"  IS 'Schema element: UseAttainment';
/
--------------------------------------------------------
--  DDL for Table ATT_WTR_TYPE
--------------------------------------------------------

  CREATE TABLE "ATT_WTR_TYPE" 
   (	"ATT_WTR_TYPE_ID" VARCHAR2(36 BYTE), 
	"ATT_ASSESSMNT_UNIT_ID" VARCHAR2(36 BYTE), 
	"WTR_TYPE_CODE" VARCHAR2(40 BYTE), 
	"WTR_SIZE_NUM" NUMBER(12,6), 
	"UNTS_CODE" VARCHAR2(15 BYTE), 
	"SIZE_ESTIMATION_METHOD_CODE" VARCHAR2(45 BYTE), 
	"SIZE_SRC_TXT" VARCHAR2(100 BYTE), 
	"SIZE_SRC_SCALE_TXT" VARCHAR2(30 BYTE)
   ) ;
 

   COMMENT ON COLUMN "ATT_WTR_TYPE"."WTR_TYPE_CODE" IS 'Code representing the water type (WaterTypeCode)';
 
   COMMENT ON COLUMN "ATT_WTR_TYPE"."WTR_SIZE_NUM" IS 'Size for this particular water type (WaterSizeNumber)';
 
   COMMENT ON COLUMN "ATT_WTR_TYPE"."UNTS_CODE" IS 'Code representing the unit of measure (UnitsCode)';
 
   COMMENT ON COLUMN "ATT_WTR_TYPE"."SIZE_ESTIMATION_METHOD_CODE" IS 'Code representing the method used for determining the water size (SizeEstimationMethodCode)';
 
   COMMENT ON COLUMN "ATT_WTR_TYPE"."SIZE_SRC_TXT" IS 'Text describing the source used for estimating the water size. (SizeSourceText)';
 
   COMMENT ON COLUMN "ATT_WTR_TYPE"."SIZE_SRC_SCALE_TXT" IS 'Text describing the scale of the source material used for estimating the water size (i.e. 1:24000) (SizeSourceScaleText)';
 
   COMMENT ON TABLE "ATT_WTR_TYPE"  IS 'Schema element: WaterType';
/
--------------------------------------------------------
--  DDL for Index PK_NPDES
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NPDES" ON "ATT_NPDES" ("ATT_NPDES_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DELISTED_WTR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DELISTED_WTR" ON "ATT_DELISTED_WTR" ("ATT_DELISTED_WTR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSC_POLUT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSC_POLUT" ON "ATT_ASSC_POLUT" ("ATT_ASSC_POLUT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DOCUMENT_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_DOCUMENT_ATT_ACTN_ID" ON "ATT_DOCUMENT" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_USE_ATTAINMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_USE_ATTAINMENT" ON "ATT_USE_ATTAINMENT" ("ATT_USE_ATTAINMENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSESSMNT_ATT_REP_CYCLE_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSESSMNT_ATT_REP_CYCLE_ID" ON "ATT_ASSESSMNT" ("ATT_REP_CYCLE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SPCF_WTR_CUS_ATT_SPC_WTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_SPCF_WTR_CUS_ATT_SPC_WTR_ID" ON "ATT_SPECIFIC_WTR_CAUSE" ("ATT_SPECIFIC_WTR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSESSMNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSESSMNT" ON "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_RELATED_TMD_LS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RELATED_TMD_LS" ON "ATT_RELATED_TMD_LS" ("ATT_RELATED_TMD_LS_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PREVIOUS_ASSESSMNT_UNIT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PREVIOUS_ASSESSMNT_UNIT" ON "ATT_PREVIOUS_ASSESSMNT_UNIT" ("ATT_PREVIOUS_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LOC_ATT_PRIO_ID
--------------------------------------------------------

  CREATE INDEX "IX_LOC_ATT_PRIO_ID" ON "ATT_LOC" ("ATT_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_INTEGRATED_REP_CATG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_INTEGRATED_REP_CATG" ON "ATT_ST_INTEGRATED_REP_CATG" ("ATT_ST_INTEGRATED_REP_CATG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WID_CUS_ATT_ST_WID_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WID_CUS_ATT_ST_WID_AC_ID" ON "ATT_ST_WIDE_CAUSE" ("ATT_ST_WIDE_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_REVIEW_CMNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REVIEW_CMNT" ON "ATT_REVIEW_CMNT" ("ATT_REVIEW_CMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PROBABLE_SRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PROBABLE_SRC" ON "ATT_PROBABLE_SRC" ("ATT_PROBABLE_SRC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TMDLNPDES_ATT_NPDES_ID
--------------------------------------------------------

  CREATE INDEX "IX_TMDLNPDES_ATT_NPDES_ID" ON "ATT_TMDLNPDES" ("ATT_NPDES_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_TMDLNPDES
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TMDLNPDES" ON "ATT_TMDLNPDES" ("ATT_TMDLNPDES_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_MON_STTN_ATT_ASSSSM_UNIT_ID
--------------------------------------------------------

  CREATE INDEX "IX_MON_STTN_ATT_ASSSSM_UNIT_ID" ON "ATT_MON_STATION" ("ATT_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_ASSESSMNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_ASSESSMNT" ON "ATT_ST_WIDE_ASSESSMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PRIOR_CAUSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PRIOR_CAUSE" ON "ATT_PRIOR_CAUSE" ("ATT_PRIOR_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSS_MTH_TYP_ATT_USE_ATT_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSS_MTH_TYP_ATT_USE_ATT_ID" ON "ATT_ASSESSMNT_METHOD_TYPE" ("ATT_USE_ATTAINMENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_SPECIFIC_WTR
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SPECIFIC_WTR" ON "ATT_SPECIFIC_WTR" ("ATT_SPECIFIC_WTR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WID_WT_TY_AT_ST_WI_AS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WID_WT_TY_AT_ST_WI_AS_ID" ON "ATT_ST_WIDE_WTR_TYPE" ("ATT_ST_WIDE_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSESSMNT_UNIT_ATT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSESSMNT_UNIT_ATT_ORG_ID" ON "ATT_ASSESSMNT_UNIT" ("ATT_ORG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSC_USE_ATT_PARAM_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSC_USE_ATT_PARAM_ID" ON "ATT_ASSC_USE" ("ATT_PARAM_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DOCUMENT_ATT_REP_CYCLE_ID
--------------------------------------------------------

  CREATE INDEX "IX_DOCUMENT_ATT_REP_CYCLE_ID" ON "ATT_DOCUMENT" ("ATT_REP_CYCLE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PARAM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PARAM" ON "ATT_PARAM" ("ATT_PARAM_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRVS_ASSSSM_UNIT_ATT_MOD_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRVS_ASSSSM_UNIT_ATT_MOD_ID" ON "ATT_PREVIOUS_ASSESSMNT_UNIT" ("ATT_MOD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PARAM_ATT_ASSESSMNT_ID
--------------------------------------------------------

  CREATE INDEX "IX_PARAM_ATT_ASSESSMNT_ID" ON "ATT_PARAM" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ORG" ON "ATT_ORG" ("ATT_ORG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSESSMNT_METHOD_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSESSMNT_METHOD_TYPE" ON "ATT_ASSESSMNT_METHOD_TYPE" ("ATT_ASSESSMNT_METHOD_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PROBBLE_SRC_ATT_ASSSSMNT_ID
--------------------------------------------------------

  CREATE INDEX "IX_PROBBLE_SRC_ATT_ASSSSMNT_ID" ON "ATT_PROBABLE_SRC" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WIDE_ACTN_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WIDE_ACTN_ATT_ACTN_ID" ON "ATT_ST_WIDE_ACTN" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_CAUSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_CAUSE" ON "ATT_ST_WIDE_CAUSE" ("ATT_ST_WIDE_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_SRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_SRC" ON "ATT_ST_WIDE_SRC" ("ATT_ST_WIDE_SRC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_REP_CYCLE_ATT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_REP_CYCLE_ATT_ORG_ID" ON "ATT_REP_CYCLE" ("ATT_ORG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_SRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SRC" ON "ATT_SRC" ("ATT_SRC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WID_PR_SR_AT_ST_WI_AS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WID_PR_SR_AT_ST_WI_AS_ID" ON "ATT_ST_WIDE_PROBABLE_SRC" ("ATT_ST_WIDE_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_INTG_REP_CATG_ATT_ASS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_INTG_REP_CATG_ATT_ASS_ID" ON "ATT_ST_INTEGRATED_REP_CATG" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSESSMNT_UNIT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSESSMNT_UNIT" ON "ATT_ASSESSMNT_UNIT" ("ATT_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSC_ACTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSC_ACTN" ON "ATT_ASSC_ACTN" ("ATT_ASSC_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_REVIEW_CMNT_ATT_ASSSSMNT_ID
--------------------------------------------------------

  CREATE INDEX "IX_REVIEW_CMNT_ATT_ASSSSMNT_ID" ON "ATT_REVIEW_CMNT" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LOC_ATT_ASSESSMNT_UNIT_ID
--------------------------------------------------------

  CREATE INDEX "IX_LOC_ATT_ASSESSMNT_UNIT_ID" ON "ATT_LOC" ("ATT_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_LOC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LOC" ON "ATT_LOC" ("ATT_LOC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_MOD_ATT_ASSESSMNT_UNIT_ID
--------------------------------------------------------

  CREATE INDEX "IX_MOD_ATT_ASSESSMNT_UNIT_ID" ON "ATT_MOD" ("ATT_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WIDE_ASSS_ATT_REP_CYC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WIDE_ASSS_ATT_REP_CYC_ID" ON "ATT_ST_WIDE_ASSESSMNT" ("ATT_REP_CYCLE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PRIO_CAUSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PRIO_CAUSE" ON "ATT_PRIO_CAUSE" ("ATT_PRIO_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SEASON_ATT_POLUT_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEASON_ATT_POLUT_ID" ON "ATT_SEASON" ("ATT_POLUT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WID_SRC_ATT_ST_WID_AC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WID_SRC_ATT_ST_WID_AC_ID" ON "ATT_ST_WIDE_SRC" ("ATT_ST_WIDE_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_TMDLNPDES_ATT_LEGCY_NPDS_ID
--------------------------------------------------------

  CREATE INDEX "IX_TMDLNPDES_ATT_LEGCY_NPDS_ID" ON "ATT_TMDLNPDES" ("ATT_LEGACY_NPDES_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DLISTD_WTR_ATT_REP_CYCLE_ID
--------------------------------------------------------

  CREATE INDEX "IX_DLISTD_WTR_ATT_REP_CYCLE_ID" ON "ATT_DELISTED_WTR" ("ATT_REP_CYCLE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_REP_CYCLE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REP_CYCLE" ON "ATT_REP_CYCLE" ("ATT_REP_CYCLE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_SEASON
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SEASON" ON "ATT_SEASON" ("ATT_SEASON_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_USE_ATTNMNT_ATT_ASSSSMNT_ID
--------------------------------------------------------

  CREATE INDEX "IX_USE_ATTNMNT_ATT_ASSSSMNT_ID" ON "ATT_USE_ATTAINMENT" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ORG_CONTACT_ATT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_ORG_CONTACT_ATT_ORG_ID" ON "ATT_ORG_CONTACT" ("ATT_ORG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_PROBABLE_SRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_PROBABLE_SRC" ON "ATT_ST_WIDE_PROBABLE_SRC" ("ATT_ST_WIDE_PROBABLE_SRC_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSC_CAUSE_NAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSC_CAUSE_NAME" ON "ATT_ASSC_CAUSE_NAME" ("ATT_ASSC_CAUSE_NAME_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_USE_ATTAINMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_USE_ATTAINMENT" ON "ATT_ST_WIDE_USE_ATTAINMENT" ("ATT_ST_WIDE_USE_ATTAINMENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DCUMNT_ATT_ASSSSMNT_UNIT_ID
--------------------------------------------------------

  CREATE INDEX "IX_DCUMNT_ATT_ASSSSMNT_UNIT_ID" ON "ATT_DOCUMENT" ("ATT_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PRIO_ASSESSMNT_UNIT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PRIO_ASSESSMNT_UNIT" ON "ATT_PRIO_ASSESSMNT_UNIT" ("ATT_PRIO_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_ACTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_ACTN" ON "ATT_ST_WIDE_ACTN" ("ATT_ST_WIDE_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSSS_TYPE_ATT_USE_ATTNM_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSSS_TYPE_ATT_USE_ATTNM_ID" ON "ATT_ASSESSMNT_TYPE" ("ATT_USE_ATTAINMENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_LGCY_NPD_ATT_SPC_WTR_CUS_ID
--------------------------------------------------------

  CREATE INDEX "IX_LGCY_NPD_ATT_SPC_WTR_CUS_ID" ON "ATT_LEGACY_NPDES" ("ATT_SPECIFIC_WTR_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ORG_CONTACT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ORG_CONTACT" ON "ATT_ORG_CONTACT" ("ATT_ORG_CONTACT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ACTN_ATT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_ACTN_ATT_ORG_ID" ON "ATT_ACTN" ("ATT_ORG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_NPDES_ATT_POLUT_ID
--------------------------------------------------------

  CREATE INDEX "IX_NPDES_ATT_POLUT_ID" ON "ATT_NPDES" ("ATT_POLUT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SPECIFIC_WTR_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_SPECIFIC_WTR_ATT_ACTN_ID" ON "ATT_SPECIFIC_WTR" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_MON_STATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_MON_STATION" ON "ATT_MON_STATION" ("ATT_MON_STATION_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSC_USE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSC_USE" ON "ATT_ASSC_USE" ("ATT_ASSC_USE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WID_CUS_ATT_ST_WID_AS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WID_CUS_ATT_ST_WID_AS_ID" ON "ATT_ST_WIDE_CAUSE" ("ATT_ST_WIDE_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_WTR_TYPE_ATT_ASSSSM_UNIT_ID
--------------------------------------------------------

  CREATE INDEX "IX_WTR_TYPE_ATT_ASSSSM_UNIT_ID" ON "ATT_WTR_TYPE" ("ATT_ASSESSMNT_UNIT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_LEGACY_NPDES
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_LEGACY_NPDES" ON "ATT_LEGACY_NPDES" ("ATT_LEGACY_NPDES_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_INTG_REP_CATG_ATT_PAR_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_INTG_REP_CATG_ATT_PAR_ID" ON "ATT_ST_INTEGRATED_REP_CATG" ("ATT_PARAM_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRIO_ASSSS_UNIT_ATT_PRIO_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRIO_ASSSS_UNIT_ATT_PRIO_ID" ON "ATT_PRIO_ASSESSMNT_UNIT" ("ATT_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PRIO
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PRIO" ON "ATT_PRIO" ("ATT_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRIO_CAUSE_ATT_PRIO_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRIO_CAUSE_ATT_PRIO_ID" ON "ATT_PRIO_CAUSE" ("ATT_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRIO_ATT_ORG_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRIO_ATT_ORG_ID" ON "ATT_PRIO" ("ATT_ORG_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_POLUT_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_POLUT_ATT_ACTN_ID" ON "ATT_POLUT" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSC_PLU_ATT_SPC_WTR_CUS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSC_PLU_ATT_SPC_WTR_CUS_ID" ON "ATT_ASSC_POLUT" ("ATT_SPECIFIC_WTR_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DELISTED_WTR_CAUSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DELISTED_WTR_CAUSE" ON "ATT_DELISTED_WTR_CAUSE" ("ATT_DELISTED_WTR_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRIOR_CAUSE_ATT_PARAM_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRIOR_CAUSE_ATT_PARAM_ID" ON "ATT_PRIOR_CAUSE" ("ATT_PARAM_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_RELATED_TMD_LS_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_RELATED_TMD_LS_ATT_ACTN_ID" ON "ATT_RELATED_TMD_LS" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ST_WIDE_WTR_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ST_WIDE_WTR_TYPE" ON "ATT_ST_WIDE_WTR_TYPE" ("ATT_ST_WIDE_WTR_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_PRIO_USE_ATT_PRIO_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRIO_USE_ATT_PRIO_ID" ON "ATT_PRIO_USE" ("ATT_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ADDRESSED_PRIO_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_ADDRESSED_PRIO_ATT_ACTN_ID" ON "ATT_ADDRESSED_PRIO" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_MOD
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_MOD" ON "ATT_MOD" ("ATT_MOD_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ADDRESSED_PRIO
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ADDRESSED_PRIO" ON "ATT_ADDRESSED_PRIO" ("ATT_ADDRESSED_PRIO_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSC_ACTN_ATT_PARAM_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSC_ACTN_ATT_PARAM_ID" ON "ATT_ASSC_ACTN" ("ATT_PARAM_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ASSESSMNT_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ASSESSMNT_TYPE" ON "ATT_ASSESSMNT_TYPE" ("ATT_ASSESSMNT_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_WID_US_AT_AT_ST_WI_AS_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_WID_US_AT_AT_ST_WI_AS_ID" ON "ATT_ST_WIDE_USE_ATTAINMENT" ("ATT_ST_WIDE_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_REVIEW_CMNT_ATT_ACTN_ID
--------------------------------------------------------

  CREATE INDEX "IX_REVIEW_CMNT_ATT_ACTN_ID" ON "ATT_REVIEW_CMNT" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SRC_ATT_SPECIFIC_WTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_SRC_ATT_SPECIFIC_WTR_ID" ON "ATT_SRC" ("ATT_SPECIFIC_WTR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_WTR_TYPE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_WTR_TYPE" ON "ATT_WTR_TYPE" ("ATT_WTR_TYPE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_ACTN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ACTN" ON "ATT_ACTN" ("ATT_ACTN_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_SPECIFIC_WTR_CAUSE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SPECIFIC_WTR_CAUSE" ON "ATT_SPECIFIC_WTR_CAUSE" ("ATT_SPECIFIC_WTR_CAUSE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_RVIW_CMNT_ATT_ST_WID_ASS_ID
--------------------------------------------------------

  CREATE INDEX "IX_RVIW_CMNT_ATT_ST_WID_ASS_ID" ON "ATT_REVIEW_CMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_DOCUMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DOCUMENT" ON "ATT_DOCUMENT" ("ATT_DOCUMENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DOCUMENT_ATT_ASSESSMNT_ID
--------------------------------------------------------

  CREATE INDEX "IX_DOCUMENT_ATT_ASSESSMNT_ID" ON "ATT_DOCUMENT" ("ATT_ASSESSMNT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_SEASON_ATT_ASSC_USE_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEASON_ATT_ASSC_USE_ID" ON "ATT_SEASON" ("ATT_ASSC_USE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_PRIO_USE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PRIO_USE" ON "ATT_PRIO_USE" ("ATT_PRIO_USE_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_DLST_WTR_CUS_ATT_DLS_WTR_ID
--------------------------------------------------------

  CREATE INDEX "IX_DLST_WTR_CUS_ATT_DLS_WTR_ID" ON "ATT_DELISTED_WTR_CAUSE" ("ATT_DELISTED_WTR_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ST_INT_REP_CAT_ATT_US_AT_ID
--------------------------------------------------------

  CREATE INDEX "IX_ST_INT_REP_CAT_ATT_US_AT_ID" ON "ATT_ST_INTEGRATED_REP_CATG" ("ATT_USE_ATTAINMENT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index PK_POLUT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_POLUT" ON "ATT_POLUT" ("ATT_POLUT_ID") 
  ;
/
--------------------------------------------------------
--  DDL for Index IX_ASSC_CUS_NAM_ATT_PRB_SRC_ID
--------------------------------------------------------

  CREATE INDEX "IX_ASSC_CUS_NAM_ATT_PRB_SRC_ID" ON "ATT_ASSC_CAUSE_NAME" ("ATT_PROBABLE_SRC_ID") 
  ;
/
--------------------------------------------------------
--  Constraints for Table ATT_LOC
--------------------------------------------------------

  ALTER TABLE "ATT_LOC" ADD CONSTRAINT "PK_LOC" PRIMARY KEY ("ATT_LOC_ID") ENABLE;
 
  ALTER TABLE "ATT_LOC" MODIFY ("ATT_LOC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_LOC" MODIFY ("LOC_TYPE_CNTXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_LOC" MODIFY ("LOC_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_LOC" MODIFY ("LOC_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PARAM
--------------------------------------------------------

  ALTER TABLE "ATT_PARAM" ADD CONSTRAINT "PK_PARAM" PRIMARY KEY ("ATT_PARAM_ID") ENABLE;
 
  ALTER TABLE "ATT_PARAM" MODIFY ("ATT_PARAM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PARAM" MODIFY ("ATT_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PARAM" MODIFY ("PARAM_STAT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PARAM" MODIFY ("PARAM_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PARAM" MODIFY ("CYCLE_EXPECTED_TO_ATTAIN_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_MON_STATION
--------------------------------------------------------

  ALTER TABLE "ATT_MON_STATION" ADD CONSTRAINT "PK_MON_STATION" PRIMARY KEY ("ATT_MON_STATION_ID") ENABLE;
 
  ALTER TABLE "ATT_MON_STATION" MODIFY ("ATT_MON_STATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_MON_STATION" MODIFY ("ATT_ASSESSMNT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_MON_STATION" MODIFY ("MON_ORG_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_MON_STATION" MODIFY ("MON_LOC_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_CAUSE" ADD CONSTRAINT "PK_ST_WIDE_CAUSE" PRIMARY KEY ("ATT_ST_WIDE_CAUSE_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_CAUSE" MODIFY ("ATT_ST_WIDE_CAUSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_CAUSE" MODIFY ("ST_WIDE_CAUSE_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSC_USE
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_USE" ADD CONSTRAINT "PK_ASSC_USE" PRIMARY KEY ("ATT_ASSC_USE_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSC_USE" MODIFY ("ATT_ASSC_USE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSC_USE" MODIFY ("ATT_PARAM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSC_USE" MODIFY ("ASSC_USE_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_SPECIFIC_WTR
--------------------------------------------------------

  ALTER TABLE "ATT_SPECIFIC_WTR" ADD CONSTRAINT "PK_SPECIFIC_WTR" PRIMARY KEY ("ATT_SPECIFIC_WTR_ID") ENABLE;
 
  ALTER TABLE "ATT_SPECIFIC_WTR" MODIFY ("ATT_SPECIFIC_WTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SPECIFIC_WTR" MODIFY ("ATT_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SPECIFIC_WTR" MODIFY ("ASSESSMNT_UNIT_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_DELISTED_WTR
--------------------------------------------------------

  ALTER TABLE "ATT_DELISTED_WTR" ADD CONSTRAINT "PK_DELISTED_WTR" PRIMARY KEY ("ATT_DELISTED_WTR_ID") ENABLE;
 
  ALTER TABLE "ATT_DELISTED_WTR" MODIFY ("ATT_DELISTED_WTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DELISTED_WTR" MODIFY ("ATT_REP_CYCLE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DELISTED_WTR" MODIFY ("ASSESSMNT_UNIT_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSC_ACTN
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_ACTN" ADD CONSTRAINT "PK_ASSC_ACTN" PRIMARY KEY ("ATT_ASSC_ACTN_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSC_ACTN" MODIFY ("ATT_ASSC_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSC_ACTN" MODIFY ("ATT_PARAM_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_PROBABLE_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_PROBABLE_SRC" ADD CONSTRAINT "PK_ST_WIDE_PROBABLE_SRC" PRIMARY KEY ("ATT_ST_WIDE_PROBABLE_SRC_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_PROBABLE_SRC" MODIFY ("ATT_ST_WIDE_PROBABLE_SRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_PROBABLE_SRC" MODIFY ("ATT_ST_WIDE_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_PROBABLE_SRC" MODIFY ("ST_WIDE_PROBABLE_SRC_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_ACTN
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_ACTN" ADD CONSTRAINT "PK_ST_WIDE_ACTN" PRIMARY KEY ("ATT_ST_WIDE_ACTN_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_ACTN" MODIFY ("ATT_ST_WIDE_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_ACTN" MODIFY ("ATT_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_ACTN" MODIFY ("ST_WIDE_ASSESSMNT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_ACTN" MODIFY ("ST_WIDE_CYCLE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSESSMNT
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT" ADD CONSTRAINT "PK_ASSESSMNT" PRIMARY KEY ("ATT_ASSESSMNT_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSESSMNT" MODIFY ("ATT_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT" MODIFY ("ATT_REP_CYCLE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT" MODIFY ("ASSESSMNT_UNIT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT" MODIFY ("CYCLE_LAST_ASSESSED_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ADDRESSED_PRIO
--------------------------------------------------------

  ALTER TABLE "ATT_ADDRESSED_PRIO" ADD CONSTRAINT "PK_ADDRESSED_PRIO" PRIMARY KEY ("ATT_ADDRESSED_PRIO_ID") ENABLE;
 
  ALTER TABLE "ATT_ADDRESSED_PRIO" MODIFY ("ATT_ADDRESSED_PRIO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ADDRESSED_PRIO" MODIFY ("ATT_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ADDRESSED_PRIO" MODIFY ("PRIO_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_DOCUMENT
--------------------------------------------------------

  ALTER TABLE "ATT_DOCUMENT" ADD CONSTRAINT "PK_DOCUMENT" PRIMARY KEY ("ATT_DOCUMENT_ID") ENABLE;
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("ATT_DOCUMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("DOCUMENT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("DOCUMENT_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("DOCUMENT_FILE_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("DOCUMENT_FILE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DOCUMENT" MODIFY ("DOCUMENT_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_ASSESSMNT
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_ASSESSMNT" ADD CONSTRAINT "PK_ST_WIDE_ASSESSMNT" PRIMARY KEY ("ATT_ST_WIDE_ASSESSMNT_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_ASSESSMNT" MODIFY ("ATT_ST_WIDE_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_ASSESSMNT" MODIFY ("ATT_REP_CYCLE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_ASSESSMNT" MODIFY ("ST_WIDE_ASSESSMNT_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PROBABLE_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_PROBABLE_SRC" ADD CONSTRAINT "PK_PROBABLE_SRC" PRIMARY KEY ("ATT_PROBABLE_SRC_ID") ENABLE;
 
  ALTER TABLE "ATT_PROBABLE_SRC" MODIFY ("ATT_PROBABLE_SRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PROBABLE_SRC" MODIFY ("ATT_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PROBABLE_SRC" MODIFY ("SRC_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PROBABLE_SRC" MODIFY ("SRC_CONFIRMED_IND" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_RELATED_TMD_LS
--------------------------------------------------------

  ALTER TABLE "ATT_RELATED_TMD_LS" ADD CONSTRAINT "PK_RELATED_TMD_LS" PRIMARY KEY ("ATT_RELATED_TMD_LS_ID") ENABLE;
 
  ALTER TABLE "ATT_RELATED_TMD_LS" MODIFY ("ATT_RELATED_TMD_LS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_RELATED_TMD_LS" MODIFY ("ATT_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_RELATED_TMD_LS" MODIFY ("TMDL_REP_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_RELATED_TMD_LS" MODIFY ("CHANGE_TYPE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PRIO
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO" ADD CONSTRAINT "PK_PRIO" PRIMARY KEY ("ATT_PRIO_ID") ENABLE;
 
  ALTER TABLE "ATT_PRIO" MODIFY ("ATT_PRIO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("ATT_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("PRIO_STAT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("PRIO_STAT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("PRIO_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("PRIO_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("CYCLE_BASE_LINE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("CYCLE_GOAL" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("PRIO_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO" MODIFY ("PRIO_DESC" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSESSMNT_UNIT
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT_UNIT" ADD CONSTRAINT "PK_ASSESSMNT_UNIT" PRIMARY KEY ("ATT_ASSESSMNT_UNIT_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("ATT_ASSESSMNT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("ATT_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("ASSESSMNT_UNIT_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("ASSESSMNT_UNIT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("LOC_DESC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("ST_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("STAT_IND" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("USE_CLASS_CNTXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_UNIT" MODIFY ("USE_CLASS_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_MOD
--------------------------------------------------------

  ALTER TABLE "ATT_MOD" ADD CONSTRAINT "PK_MOD" PRIMARY KEY ("ATT_MOD_ID") ENABLE;
 
  ALTER TABLE "ATT_MOD" MODIFY ("ATT_MOD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_MOD" MODIFY ("ATT_ASSESSMNT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_MOD" MODIFY ("MOD_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_MOD" MODIFY ("CHANGE_CYCLE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSESSMNT_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT_TYPE" ADD CONSTRAINT "PK_ASSESSMNT_TYPE" PRIMARY KEY ("ATT_ASSESSMNT_TYPE_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSESSMNT_TYPE" MODIFY ("ATT_ASSESSMNT_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_TYPE" MODIFY ("ATT_USE_ATTAINMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_TYPE" MODIFY ("ASSESSMNT_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_TYPE" MODIFY ("ASSESSMNT_CONFIDENCE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_SRC" ADD CONSTRAINT "PK_ST_WIDE_SRC" PRIMARY KEY ("ATT_ST_WIDE_SRC_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_SRC" MODIFY ("ATT_ST_WIDE_SRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_SRC" MODIFY ("ATT_ST_WIDE_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_SRC" MODIFY ("ST_WIDE_SRC_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSESSMNT_METHOD_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" ADD CONSTRAINT "PK_ASSESSMNT_METHOD_TYPE" PRIMARY KEY ("ATT_ASSESSMNT_METHOD_TYPE_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" MODIFY ("ATT_ASSESSMNT_METHOD_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" MODIFY ("ATT_USE_ATTAINMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" MODIFY ("METHOD_TYPE_CNTXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" MODIFY ("METHOD_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" MODIFY ("METHOD_TYPE_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_SPECIFIC_WTR_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_SPECIFIC_WTR_CAUSE" ADD CONSTRAINT "PK_SPECIFIC_WTR_CAUSE" PRIMARY KEY ("ATT_SPECIFIC_WTR_CAUSE_ID") ENABLE;
 
  ALTER TABLE "ATT_SPECIFIC_WTR_CAUSE" MODIFY ("ATT_SPECIFIC_WTR_CAUSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SPECIFIC_WTR_CAUSE" MODIFY ("ATT_SPECIFIC_WTR_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_USE_ATTAINMENT
--------------------------------------------------------

  ALTER TABLE "ATT_USE_ATTAINMENT" ADD CONSTRAINT "PK_USE_ATTAINMENT" PRIMARY KEY ("ATT_USE_ATTAINMENT_ID") ENABLE;
 
  ALTER TABLE "ATT_USE_ATTAINMENT" MODIFY ("ATT_USE_ATTAINMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_USE_ATTAINMENT" MODIFY ("ATT_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_USE_ATTAINMENT" MODIFY ("USE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_USE_ATTAINMENT" MODIFY ("USE_ATTAINMENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_USE_ATTAINMENT" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_WTR_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_WTR_TYPE" ADD CONSTRAINT "PK_ST_WIDE_WTR_TYPE" PRIMARY KEY ("ATT_ST_WIDE_WTR_TYPE_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_WTR_TYPE" MODIFY ("ATT_ST_WIDE_WTR_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_WTR_TYPE" MODIFY ("ATT_ST_WIDE_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_WTR_TYPE" MODIFY ("ST_WIDE_WTR_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ORG
--------------------------------------------------------

  ALTER TABLE "ATT_ORG" ADD CONSTRAINT "PK_ORG" PRIMARY KEY ("ATT_ORG_ID") ENABLE;
 
  ALTER TABLE "ATT_ORG" MODIFY ("ATT_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ORG" MODIFY ("ORG_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PRIO_USE
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO_USE" ADD CONSTRAINT "PK_PRIO_USE" PRIMARY KEY ("ATT_PRIO_USE_ID") ENABLE;
 
  ALTER TABLE "ATT_PRIO_USE" MODIFY ("ATT_PRIO_USE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO_USE" MODIFY ("ATT_PRIO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO_USE" MODIFY ("USE_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_POLUT
--------------------------------------------------------

  ALTER TABLE "ATT_POLUT" ADD CONSTRAINT "PK_POLUT" PRIMARY KEY ("ATT_POLUT_ID") ENABLE;
 
  ALTER TABLE "ATT_POLUT" MODIFY ("ATT_POLUT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_POLUT" MODIFY ("ATT_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_POLUT" MODIFY ("POLUT_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_POLUT" MODIFY ("POLUT_SRC_TYPE_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PREVIOUS_ASSESSMNT_UNIT
--------------------------------------------------------

  ALTER TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT" ADD CONSTRAINT "PK_PREVIOUS_ASSESSMNT_UNIT" PRIMARY KEY ("ATT_PREVIOUS_ASSESSMNT_UNIT_ID") ENABLE;
 
  ALTER TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT" MODIFY ("ATT_PREVIOUS_ASSESSMNT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT" MODIFY ("ATT_MOD_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT" MODIFY ("ASSESSMNT_UNIT_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ORG_CONTACT
--------------------------------------------------------

  ALTER TABLE "ATT_ORG_CONTACT" ADD CONSTRAINT "PK_ORG_CONTACT" PRIMARY KEY ("ATT_ORG_CONTACT_ID") ENABLE;
 
  ALTER TABLE "ATT_ORG_CONTACT" MODIFY ("ATT_ORG_CONTACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ORG_CONTACT" MODIFY ("ATT_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ORG_CONTACT" MODIFY ("CONTACT_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ORG_CONTACT" MODIFY ("WEB_URL_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PRIO_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO_CAUSE" ADD CONSTRAINT "PK_PRIO_CAUSE" PRIMARY KEY ("ATT_PRIO_CAUSE_ID") ENABLE;
 
  ALTER TABLE "ATT_PRIO_CAUSE" MODIFY ("ATT_PRIO_CAUSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO_CAUSE" MODIFY ("ATT_PRIO_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_INTEGRATED_REP_CATG
--------------------------------------------------------

  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" ADD CONSTRAINT "PK_ST_INTEGRATED_REP_CATG" PRIMARY KEY ("ATT_ST_INTEGRATED_REP_CATG_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" MODIFY ("ATT_ST_INTEGRATED_REP_CATG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" MODIFY ("ST_IR_CATG_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" MODIFY ("ST_CATG_DESC_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_WTR_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_WTR_TYPE" ADD CONSTRAINT "PK_WTR_TYPE" PRIMARY KEY ("ATT_WTR_TYPE_ID") ENABLE;
 
  ALTER TABLE "ATT_WTR_TYPE" MODIFY ("ATT_WTR_TYPE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_WTR_TYPE" MODIFY ("ATT_ASSESSMNT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_WTR_TYPE" MODIFY ("WTR_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_WTR_TYPE" MODIFY ("WTR_SIZE_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_WTR_TYPE" MODIFY ("UNTS_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PRIOR_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_PRIOR_CAUSE" ADD CONSTRAINT "PK_PRIOR_CAUSE" PRIMARY KEY ("ATT_PRIOR_CAUSE_ID") ENABLE;
 
  ALTER TABLE "ATT_PRIOR_CAUSE" MODIFY ("ATT_PRIOR_CAUSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIOR_CAUSE" MODIFY ("ATT_PARAM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIOR_CAUSE" MODIFY ("PRIOR_CAUSE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIOR_CAUSE" MODIFY ("PRIOR_CAUSE_CYCLE_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_SRC" ADD CONSTRAINT "PK_SRC" PRIMARY KEY ("ATT_SRC_ID") ENABLE;
 
  ALTER TABLE "ATT_SRC" MODIFY ("ATT_SRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SRC" MODIFY ("ATT_SPECIFIC_WTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SRC" MODIFY ("SRC_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_NPDES
--------------------------------------------------------

  ALTER TABLE "ATT_NPDES" ADD CONSTRAINT "PK_NPDES" PRIMARY KEY ("ATT_NPDES_ID") ENABLE;
 
  ALTER TABLE "ATT_NPDES" MODIFY ("ATT_NPDES_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_NPDES" MODIFY ("ATT_POLUT_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ACTN
--------------------------------------------------------

  ALTER TABLE "ATT_ACTN" ADD CONSTRAINT "PK_ACTN" PRIMARY KEY ("ATT_ACTN_ID") ENABLE;
 
  ALTER TABLE "ATT_ACTN" MODIFY ("ATT_ACTN_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ACTN" MODIFY ("ATT_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ACTN" MODIFY ("ACTN_IDENT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ACTN" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ACTN" MODIFY ("ACTN_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ACTN" MODIFY ("ACTN_STAT_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_TMDLNPDES
--------------------------------------------------------

  ALTER TABLE "ATT_TMDLNPDES" ADD CONSTRAINT "PK_TMDLNPDES" PRIMARY KEY ("ATT_TMDLNPDES_ID") ENABLE;
 
  ALTER TABLE "ATT_TMDLNPDES" MODIFY ("ATT_TMDLNPDES_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_TMDLNPDES" MODIFY ("WSTE_LOAD_ALLOCTN_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_TMDLNPDES" MODIFY ("WSTE_LOAD_ALLOCTN_UNTS_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_SEASON
--------------------------------------------------------

  ALTER TABLE "ATT_SEASON" ADD CONSTRAINT "PK_SEASON" PRIMARY KEY ("ATT_SEASON_ID") ENABLE;
 
  ALTER TABLE "ATT_SEASON" MODIFY ("ATT_SEASON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SEASON" MODIFY ("SEASON_START_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_SEASON" MODIFY ("SEASON_END_TXT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSC_POLUT
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_POLUT" ADD CONSTRAINT "PK_ASSC_POLUT" PRIMARY KEY ("ATT_ASSC_POLUT_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSC_POLUT" MODIFY ("ATT_ASSC_POLUT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSC_POLUT" MODIFY ("ATT_SPECIFIC_WTR_CAUSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSC_POLUT" MODIFY ("POLUT_NAME" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ASSC_CAUSE_NAME
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_CAUSE_NAME" ADD CONSTRAINT "PK_ASSC_CAUSE_NAME" PRIMARY KEY ("ATT_ASSC_CAUSE_NAME_ID") ENABLE;
 
  ALTER TABLE "ATT_ASSC_CAUSE_NAME" MODIFY ("ATT_ASSC_CAUSE_NAME_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ASSC_CAUSE_NAME" MODIFY ("ATT_PROBABLE_SRC_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_ST_WIDE_USE_ATTAINMENT
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" ADD CONSTRAINT "PK_ST_WIDE_USE_ATTAINMENT" PRIMARY KEY ("ATT_ST_WIDE_USE_ATTAINMENT_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" MODIFY ("ATT_ST_WIDE_USE_ATTAINMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" MODIFY ("ATT_ST_WIDE_ASSESSMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" MODIFY ("ST_WIDE_USE_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" MODIFY ("USE_ATTAINMENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_DELISTED_WTR_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_DELISTED_WTR_CAUSE" ADD CONSTRAINT "PK_DELISTED_WTR_CAUSE" PRIMARY KEY ("ATT_DELISTED_WTR_CAUSE_ID") ENABLE;
 
  ALTER TABLE "ATT_DELISTED_WTR_CAUSE" MODIFY ("ATT_DELISTED_WTR_CAUSE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DELISTED_WTR_CAUSE" MODIFY ("ATT_DELISTED_WTR_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DELISTED_WTR_CAUSE" MODIFY ("AGNCY_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_DELISTED_WTR_CAUSE" MODIFY ("DELISTING_REASON_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_REP_CYCLE
--------------------------------------------------------

  ALTER TABLE "ATT_REP_CYCLE" ADD CONSTRAINT "PK_REP_CYCLE" PRIMARY KEY ("ATT_REP_CYCLE_ID") ENABLE;
 
  ALTER TABLE "ATT_REP_CYCLE" MODIFY ("ATT_REP_CYCLE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REP_CYCLE" MODIFY ("ATT_ORG_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REP_CYCLE" MODIFY ("REP_CYCLE_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REP_CYCLE" MODIFY ("REP_STAT_CODE" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_PRIO_ASSESSMNT_UNIT
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO_ASSESSMNT_UNIT" ADD CONSTRAINT "PK_PRIO_ASSESSMNT_UNIT" PRIMARY KEY ("ATT_PRIO_ASSESSMNT_UNIT_ID") ENABLE;
 
  ALTER TABLE "ATT_PRIO_ASSESSMNT_UNIT" MODIFY ("ATT_PRIO_ASSESSMNT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO_ASSESSMNT_UNIT" MODIFY ("ATT_PRIO_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_PRIO_ASSESSMNT_UNIT" MODIFY ("ASSESSMNT_UNIT_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_LEGACY_NPDES
--------------------------------------------------------

  ALTER TABLE "ATT_LEGACY_NPDES" ADD CONSTRAINT "PK_LEGACY_NPDES" PRIMARY KEY ("ATT_LEGACY_NPDES_ID") ENABLE;
 
  ALTER TABLE "ATT_LEGACY_NPDES" MODIFY ("ATT_LEGACY_NPDES_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_LEGACY_NPDES" MODIFY ("ATT_SPECIFIC_WTR_CAUSE_ID" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Constraints for Table ATT_REVIEW_CMNT
--------------------------------------------------------

  ALTER TABLE "ATT_REVIEW_CMNT" ADD CONSTRAINT "PK_REVIEW_CMNT" PRIMARY KEY ("ATT_REVIEW_CMNT_ID") ENABLE;
 
  ALTER TABLE "ATT_REVIEW_CMNT" MODIFY ("ATT_REVIEW_CMNT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REVIEW_CMNT" MODIFY ("REVIEW_CMNT_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REVIEW_CMNT" MODIFY ("REVIEW_CMNT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REVIEW_CMNT" MODIFY ("REVIEW_CMNT_USR_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "ATT_REVIEW_CMNT" MODIFY ("ORG_IDENT" NOT NULL ENABLE);
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ACTN
--------------------------------------------------------

  ALTER TABLE "ATT_ACTN" ADD CONSTRAINT "FK_ACTN_ORG" FOREIGN KEY ("ATT_ORG_ID")
	  REFERENCES "ATT_ORG" ("ATT_ORG_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ADDRESSED_PRIO
--------------------------------------------------------

  ALTER TABLE "ATT_ADDRESSED_PRIO" ADD CONSTRAINT "FK_ADDRESSED_PRIO_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSC_ACTN
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_ACTN" ADD CONSTRAINT "FK_ASSC_ACTN_PARAM" FOREIGN KEY ("ATT_PARAM_ID")
	  REFERENCES "ATT_PARAM" ("ATT_PARAM_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSC_CAUSE_NAME
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_CAUSE_NAME" ADD CONSTRAINT "FK_ASSC_CAUSE_NAME_PROBBLE_SRC" FOREIGN KEY ("ATT_PROBABLE_SRC_ID")
	  REFERENCES "ATT_PROBABLE_SRC" ("ATT_PROBABLE_SRC_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSC_POLUT
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_POLUT" ADD CONSTRAINT "FK_ASSC_POLUT_SPCIFIC_WTR_CUSE" FOREIGN KEY ("ATT_SPECIFIC_WTR_CAUSE_ID")
	  REFERENCES "ATT_SPECIFIC_WTR_CAUSE" ("ATT_SPECIFIC_WTR_CAUSE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSC_USE
--------------------------------------------------------

  ALTER TABLE "ATT_ASSC_USE" ADD CONSTRAINT "FK_ASSC_USE_PARAM" FOREIGN KEY ("ATT_PARAM_ID")
	  REFERENCES "ATT_PARAM" ("ATT_PARAM_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSESSMNT
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT" ADD CONSTRAINT "FK_ASSESSMNT_REP_CYCLE" FOREIGN KEY ("ATT_REP_CYCLE_ID")
	  REFERENCES "ATT_REP_CYCLE" ("ATT_REP_CYCLE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSESSMNT_METHOD_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT_METHOD_TYPE" ADD CONSTRAINT "FK_ASSSSMN_MTHD_TYPE_USE_ATTNM" FOREIGN KEY ("ATT_USE_ATTAINMENT_ID")
	  REFERENCES "ATT_USE_ATTAINMENT" ("ATT_USE_ATTAINMENT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSESSMNT_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT_TYPE" ADD CONSTRAINT "FK_ASSSSMNT_TYPE_USE_ATTINMENT" FOREIGN KEY ("ATT_USE_ATTAINMENT_ID")
	  REFERENCES "ATT_USE_ATTAINMENT" ("ATT_USE_ATTAINMENT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ASSESSMNT_UNIT
--------------------------------------------------------

  ALTER TABLE "ATT_ASSESSMNT_UNIT" ADD CONSTRAINT "FK_ASSESSMNT_UNIT_ORG" FOREIGN KEY ("ATT_ORG_ID")
	  REFERENCES "ATT_ORG" ("ATT_ORG_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_DELISTED_WTR
--------------------------------------------------------

  ALTER TABLE "ATT_DELISTED_WTR" ADD CONSTRAINT "FK_DELISTED_WTR_REP_CYCLE" FOREIGN KEY ("ATT_REP_CYCLE_ID")
	  REFERENCES "ATT_REP_CYCLE" ("ATT_REP_CYCLE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_DELISTED_WTR_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_DELISTED_WTR_CAUSE" ADD CONSTRAINT "FK_DELISTD_WTR_CUSE_DLISTD_WTR" FOREIGN KEY ("ATT_DELISTED_WTR_ID")
	  REFERENCES "ATT_DELISTED_WTR" ("ATT_DELISTED_WTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_DOCUMENT
--------------------------------------------------------

  ALTER TABLE "ATT_DOCUMENT" ADD CONSTRAINT "FK_DOCUMENT_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ENABLE;
 
  ALTER TABLE "ATT_DOCUMENT" ADD CONSTRAINT "FK_DOCUMENT_ASSESSMNT" FOREIGN KEY ("ATT_ASSESSMNT_ID")
	  REFERENCES "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") ENABLE;
 
  ALTER TABLE "ATT_DOCUMENT" ADD CONSTRAINT "FK_DOCUMENT_ASSESSMNT_UNIT" FOREIGN KEY ("ATT_ASSESSMNT_UNIT_ID")
	  REFERENCES "ATT_ASSESSMNT_UNIT" ("ATT_ASSESSMNT_UNIT_ID") ENABLE;
 
  ALTER TABLE "ATT_DOCUMENT" ADD CONSTRAINT "FK_DOCUMENT_REP_CYCLE" FOREIGN KEY ("ATT_REP_CYCLE_ID")
	  REFERENCES "ATT_REP_CYCLE" ("ATT_REP_CYCLE_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_LEGACY_NPDES
--------------------------------------------------------

  ALTER TABLE "ATT_LEGACY_NPDES" ADD CONSTRAINT "FK_LEGCY_NPDS_SPCIFIC_WTR_CUSE" FOREIGN KEY ("ATT_SPECIFIC_WTR_CAUSE_ID")
	  REFERENCES "ATT_SPECIFIC_WTR_CAUSE" ("ATT_SPECIFIC_WTR_CAUSE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_LOC
--------------------------------------------------------

  ALTER TABLE "ATT_LOC" ADD CONSTRAINT "FK_LOC_ASSESSMNT_UNIT" FOREIGN KEY ("ATT_ASSESSMNT_UNIT_ID")
	  REFERENCES "ATT_ASSESSMNT_UNIT" ("ATT_ASSESSMNT_UNIT_ID") ENABLE;
 
  ALTER TABLE "ATT_LOC" ADD CONSTRAINT "FK_LOC_PRIO" FOREIGN KEY ("ATT_PRIO_ID")
	  REFERENCES "ATT_PRIO" ("ATT_PRIO_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_MOD
--------------------------------------------------------

  ALTER TABLE "ATT_MOD" ADD CONSTRAINT "FK_MOD_ASSESSMNT_UNIT" FOREIGN KEY ("ATT_ASSESSMNT_UNIT_ID")
	  REFERENCES "ATT_ASSESSMNT_UNIT" ("ATT_ASSESSMNT_UNIT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_MON_STATION
--------------------------------------------------------

  ALTER TABLE "ATT_MON_STATION" ADD CONSTRAINT "FK_MON_STATION_ASSESSMNT_UNIT" FOREIGN KEY ("ATT_ASSESSMNT_UNIT_ID")
	  REFERENCES "ATT_ASSESSMNT_UNIT" ("ATT_ASSESSMNT_UNIT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_NPDES
--------------------------------------------------------

  ALTER TABLE "ATT_NPDES" ADD CONSTRAINT "FK_NPDES_POLUT" FOREIGN KEY ("ATT_POLUT_ID")
	  REFERENCES "ATT_POLUT" ("ATT_POLUT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ORG_CONTACT
--------------------------------------------------------

  ALTER TABLE "ATT_ORG_CONTACT" ADD CONSTRAINT "FK_ORG_CONTACT_ORG" FOREIGN KEY ("ATT_ORG_ID")
	  REFERENCES "ATT_ORG" ("ATT_ORG_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PARAM
--------------------------------------------------------

  ALTER TABLE "ATT_PARAM" ADD CONSTRAINT "FK_PARAM_ASSESSMNT" FOREIGN KEY ("ATT_ASSESSMNT_ID")
	  REFERENCES "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_POLUT
--------------------------------------------------------

  ALTER TABLE "ATT_POLUT" ADD CONSTRAINT "FK_POLUT_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PREVIOUS_ASSESSMNT_UNIT
--------------------------------------------------------

  ALTER TABLE "ATT_PREVIOUS_ASSESSMNT_UNIT" ADD CONSTRAINT "FK_PREVIOUS_ASSESSMNT_UNIT_MOD" FOREIGN KEY ("ATT_MOD_ID")
	  REFERENCES "ATT_MOD" ("ATT_MOD_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PRIO
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO" ADD CONSTRAINT "FK_PRIO_ORG" FOREIGN KEY ("ATT_ORG_ID")
	  REFERENCES "ATT_ORG" ("ATT_ORG_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PRIOR_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_PRIOR_CAUSE" ADD CONSTRAINT "FK_PRIOR_CAUSE_PARAM" FOREIGN KEY ("ATT_PARAM_ID")
	  REFERENCES "ATT_PARAM" ("ATT_PARAM_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PRIO_ASSESSMNT_UNIT
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO_ASSESSMNT_UNIT" ADD CONSTRAINT "FK_PRIO_ASSESSMNT_UNIT_PRIO" FOREIGN KEY ("ATT_PRIO_ID")
	  REFERENCES "ATT_PRIO" ("ATT_PRIO_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PRIO_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO_CAUSE" ADD CONSTRAINT "FK_PRIO_CAUSE_PRIO" FOREIGN KEY ("ATT_PRIO_ID")
	  REFERENCES "ATT_PRIO" ("ATT_PRIO_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PRIO_USE
--------------------------------------------------------

  ALTER TABLE "ATT_PRIO_USE" ADD CONSTRAINT "FK_PRIO_USE_PRIO" FOREIGN KEY ("ATT_PRIO_ID")
	  REFERENCES "ATT_PRIO" ("ATT_PRIO_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_PROBABLE_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_PROBABLE_SRC" ADD CONSTRAINT "FK_PROBABLE_SRC_ASSESSMNT" FOREIGN KEY ("ATT_ASSESSMNT_ID")
	  REFERENCES "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_RELATED_TMD_LS
--------------------------------------------------------

  ALTER TABLE "ATT_RELATED_TMD_LS" ADD CONSTRAINT "FK_RELATED_TMD_LS_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_REP_CYCLE
--------------------------------------------------------

  ALTER TABLE "ATT_REP_CYCLE" ADD CONSTRAINT "FK_REP_CYCLE_ORG" FOREIGN KEY ("ATT_ORG_ID")
	  REFERENCES "ATT_ORG" ("ATT_ORG_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_REVIEW_CMNT
--------------------------------------------------------

  ALTER TABLE "ATT_REVIEW_CMNT" ADD CONSTRAINT "FK_REVIEW_CMNT_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ENABLE;
 
  ALTER TABLE "ATT_REVIEW_CMNT" ADD CONSTRAINT "FK_REVIEW_CMNT_ASSESSMNT" FOREIGN KEY ("ATT_ASSESSMNT_ID")
	  REFERENCES "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") ENABLE;
 
  ALTER TABLE "ATT_REVIEW_CMNT" ADD CONSTRAINT "FK_REVIW_CMNT_ST_WIDE_ASSSSMNT" FOREIGN KEY ("ATT_ST_WIDE_ASSESSMNT_ID")
	  REFERENCES "ATT_ST_WIDE_ASSESSMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_SEASON
--------------------------------------------------------

  ALTER TABLE "ATT_SEASON" ADD CONSTRAINT "FK_SEASON_ASSC_USE" FOREIGN KEY ("ATT_ASSC_USE_ID")
	  REFERENCES "ATT_ASSC_USE" ("ATT_ASSC_USE_ID") ENABLE;
 
  ALTER TABLE "ATT_SEASON" ADD CONSTRAINT "FK_SEASON_POLUT" FOREIGN KEY ("ATT_POLUT_ID")
	  REFERENCES "ATT_POLUT" ("ATT_POLUT_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_SPECIFIC_WTR
--------------------------------------------------------

  ALTER TABLE "ATT_SPECIFIC_WTR" ADD CONSTRAINT "FK_SPECIFIC_WTR_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_SPECIFIC_WTR_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_SPECIFIC_WTR_CAUSE" ADD CONSTRAINT "FK_SPCIFIC_WTR_CUSE_SPCIFC_WTR" FOREIGN KEY ("ATT_SPECIFIC_WTR_ID")
	  REFERENCES "ATT_SPECIFIC_WTR" ("ATT_SPECIFIC_WTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_SRC" ADD CONSTRAINT "FK_SRC_SPECIFIC_WTR" FOREIGN KEY ("ATT_SPECIFIC_WTR_ID")
	  REFERENCES "ATT_SPECIFIC_WTR" ("ATT_SPECIFIC_WTR_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_INTEGRATED_REP_CATG
--------------------------------------------------------

  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" ADD CONSTRAINT "FK_ST_INTEGRATED_REP_CATG_PARM" FOREIGN KEY ("ATT_PARAM_ID")
	  REFERENCES "ATT_PARAM" ("ATT_PARAM_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" ADD CONSTRAINT "FK_ST_INTGRTD_REP_CATG_ASSSSMN" FOREIGN KEY ("ATT_ASSESSMNT_ID")
	  REFERENCES "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_INTEGRATED_REP_CATG" ADD CONSTRAINT "FK_ST_INTGR_REP_CATG_USE_ATTNM" FOREIGN KEY ("ATT_USE_ATTAINMENT_ID")
	  REFERENCES "ATT_USE_ATTAINMENT" ("ATT_USE_ATTAINMENT_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_ACTN
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_ACTN" ADD CONSTRAINT "FK_ST_WIDE_ACTN_ACTN" FOREIGN KEY ("ATT_ACTN_ID")
	  REFERENCES "ATT_ACTN" ("ATT_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_ASSESSMNT
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_ASSESSMNT" ADD CONSTRAINT "FK_ST_WIDE_ASSESSMNT_REP_CYCLE" FOREIGN KEY ("ATT_REP_CYCLE_ID")
	  REFERENCES "ATT_REP_CYCLE" ("ATT_REP_CYCLE_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_CAUSE
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_CAUSE" ADD CONSTRAINT "FK_ST_WIDE_CAUSE_ST_WIDE_ACTN" FOREIGN KEY ("ATT_ST_WIDE_ACTN_ID")
	  REFERENCES "ATT_ST_WIDE_ACTN" ("ATT_ST_WIDE_ACTN_ID") ENABLE;
 
  ALTER TABLE "ATT_ST_WIDE_CAUSE" ADD CONSTRAINT "FK_ST_WIDE_CUSE_ST_WIDE_ASSSSM" FOREIGN KEY ("ATT_ST_WIDE_ASSESSMNT_ID")
	  REFERENCES "ATT_ST_WIDE_ASSESSMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_PROBABLE_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_PROBABLE_SRC" ADD CONSTRAINT "FK_ST_WIDE_PRBB_SRC_ST_WID_ASS" FOREIGN KEY ("ATT_ST_WIDE_ASSESSMNT_ID")
	  REFERENCES "ATT_ST_WIDE_ASSESSMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_SRC
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_SRC" ADD CONSTRAINT "FK_ST_WIDE_SRC_ST_WIDE_ACTN" FOREIGN KEY ("ATT_ST_WIDE_ACTN_ID")
	  REFERENCES "ATT_ST_WIDE_ACTN" ("ATT_ST_WIDE_ACTN_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_USE_ATTAINMENT
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_USE_ATTAINMENT" ADD CONSTRAINT "FK_ST_WIDE_USE_ATTN_ST_WID_ASS" FOREIGN KEY ("ATT_ST_WIDE_ASSESSMNT_ID")
	  REFERENCES "ATT_ST_WIDE_ASSESSMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_ST_WIDE_WTR_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_ST_WIDE_WTR_TYPE" ADD CONSTRAINT "FK_ST_WIDE_WTR_TYPE_ST_WID_ASS" FOREIGN KEY ("ATT_ST_WIDE_ASSESSMNT_ID")
	  REFERENCES "ATT_ST_WIDE_ASSESSMNT" ("ATT_ST_WIDE_ASSESSMNT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_TMDLNPDES
--------------------------------------------------------

  ALTER TABLE "ATT_TMDLNPDES" ADD CONSTRAINT "FK_TMDLNPDES_LEGACY_NPDES" FOREIGN KEY ("ATT_LEGACY_NPDES_ID")
	  REFERENCES "ATT_LEGACY_NPDES" ("ATT_LEGACY_NPDES_ID") ENABLE;
 
  ALTER TABLE "ATT_TMDLNPDES" ADD CONSTRAINT "FK_TMDLNPDES_NPDES" FOREIGN KEY ("ATT_NPDES_ID")
	  REFERENCES "ATT_NPDES" ("ATT_NPDES_ID") ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_USE_ATTAINMENT
--------------------------------------------------------

  ALTER TABLE "ATT_USE_ATTAINMENT" ADD CONSTRAINT "FK_USE_ATTAINMENT_ASSESSMNT" FOREIGN KEY ("ATT_ASSESSMNT_ID")
	  REFERENCES "ATT_ASSESSMNT" ("ATT_ASSESSMNT_ID") ON DELETE CASCADE ENABLE;
/
--------------------------------------------------------
--  Ref Constraints for Table ATT_WTR_TYPE
--------------------------------------------------------

  ALTER TABLE "ATT_WTR_TYPE" ADD CONSTRAINT "FK_WTR_TYPE_ASSESSMNT_UNIT" FOREIGN KEY ("ATT_ASSESSMNT_UNIT_ID")
	  REFERENCES "ATT_ASSESSMNT_UNIT" ("ATT_ASSESSMNT_UNIT_ID") ON DELETE CASCADE ENABLE;
/
