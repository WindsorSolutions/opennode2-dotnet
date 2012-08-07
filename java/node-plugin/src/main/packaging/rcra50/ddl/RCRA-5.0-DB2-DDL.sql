--------------------------------------------------------
--  File created - Wednesday-December-09-2009   
--  10/04/2010  KJames  Added RCRA_SUBMISSIONHISTORY table.
--------------------------------------------------------

--------------------------------------------------------
--  DDL for Table RCRA_SUBMISSIONHISTORY
--------------------------------------------------------
CREATE TABLE RCRA_SUBMISSIONHISTORY 
     ( RECORDID               VARCHAR(50) NOT NULL
     , SCHEDULERUNDATE        DATE NOT NULL
     , TRANSACTIONID          VARCHAR(50) NOT NULL
     , PROCESSINGSTATUS       VARCHAR(50) NOT NULL); 


--------------------------------------------------------
--  DDL for Table RCRA_CME_CITATION
--------------------------------------------------------
Drop table RCRA_CME_CITATION;

  CREATE TABLE RCRA_CME_CITATION 
   (	CITATION_ID VARCHAR(40) NOT NULL, 
	VIOL_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	CITATION_NAME_SEQ_NUM INTEGER NOT NULL, 
	CITATION_NAME VARCHAR(128), 
	CITATION_NAME_OWNER VARCHAR(255), 
	CITATION_NAME_TYPE VARCHAR(255), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_CITATION.CITATION_ID IS 'Parent: Compliance Monitoring and Enforcement Citation Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.VIOL_ID IS 'Parent: Compliance Monitoring and Enforcement Citation Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.CITATION_NAME_SEQ_NUM IS 'Parent: Compliance Monitoring and Enforcement Citation Data (CitationNameSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.CITATION_NAME IS 'The citation(s) of the violations alleged (CME) or of the Authority used (CA). (CitationName)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.CITATION_NAME_OWNER IS 'State postal code (CitationNameOwner)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.CITATION_NAME_TYPE IS 'Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3 (CitationNameType)';
 
   COMMENT ON COLUMN RCRA_CME_CITATION.NOTES IS 'Parent: Compliance Monitoring and Enforcement Citation Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_CITATION  IS 'Schema element: CitationDataType';
   
--  CREATE UNIQUE INDEX PK_RCRA_CME_CTTN ON RCRA_CME_CITATION (CITATION_ID);   
ALTER TABLE RCRA_CME_CITATION ADD CONSTRAINT PK_RCRA_CME_CTTN PRIMARY KEY (CITATION_ID);
--ALTER TABLE RCRA_CME_CITATION MODIFY (CITATION_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_CITATION MODIFY (VIOL_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_CITATION MODIFY (CITATION_NAME_SEQ_NUM NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------
DROP TABLE RCRA_CME_CSNY_DATE;

  CREATE TABLE RCRA_CME_CSNY_DATE 
   (	CSNY_DATE_ID VARCHAR(40) NOT NULL, 
	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	SNY_DATE DATE NOT NULL
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.CSNY_DATE_ID IS 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.SNY_DATE IS 'Date of the SNY that the Action is Addressing (SNYDate)';
 
   COMMENT ON TABLE RCRA_CME_CSNY_DATE  IS 'Schema element: CSNYDateDataType';

--  CREATE UNIQUE INDEX PK_RCR_CME_CSN_DTE ON RCRA_CME_CSNY_DATE (CSNY_DATE_ID);
ALTER TABLE RCRA_CME_CSNY_DATE ADD CONSTRAINT PK_RCR_CME_CSN_DTE PRIMARY KEY (CSNY_DATE_ID);
--ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (CSNY_DATE_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (ENFRC_ACT_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (SNY_DATE NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------
DROP TABLE RCRA_CME_ENFRC_ACT;

  CREATE TABLE RCRA_CME_ENFRC_ACT 
   (	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	CME_FAC_SUBM_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	ENFRC_AGN_LOC_NAME VARCHAR(128) NOT NULL, 
	ENFRC_ACT_IDEN VARCHAR(50) NOT NULL, 
	ENFRC_ACT_DATE DATE NOT NULL, 
	ENFRC_AGN_NAME VARCHAR(128) NOT NULL, 
	ENFRC_DOCKET_NUM VARCHAR(20), 
	ENFRC_ATTRY VARCHAR(255), 
	CORCT_ACT_COMPT VARCHAR(255), 
	CNST_AGMT_FINAL_ORDER_SEQ_NUM INTEGER, 
	APPEAL_INIT_DATE DATE, 
	APPEAL_RSLN_DATE DATE, 
	DISP_STAT_DATE DATE, 
	DISP_STAT_OWNER VARCHAR(255), 
	DISP_STAT VARCHAR(255), 
	ENFRC_OWNER VARCHAR(255), 
	ENFRC_TYPE VARCHAR(255), 
	ENFRC_RESP_PERSON_OWNER VARCHAR(255), 
	ENFRC_RESP_PERSON_IDEN VARCHAR(50), 
	ENFRC_RESP_SUBORG_OWNER VARCHAR(255), 
	ENFRC_RESP_SUBORG VARCHAR(255), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.CME_FAC_SUBM_ID IS 'Parent: Compliance Monitoring and Enforcement Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_AGN_LOC_NAME IS 'The U.S.Postal Service alphabetic code that represents the U.S.State or territory in which a state or local government enforcement agency operates. (EnforcementAgencyLocationName)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_ACT_IDEN IS 'The unique alphanumeric identifier used in the applicable database to identify a specific enforcement action pertaining to a regulated entity or facility. (EnforcementActionIdentifier)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_ACT_DATE IS 'The calendar date the enforcement action was issued or filed. (EnforcementActionDate)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_AGN_NAME IS 'The full name of the agency, department, or organization that submitted the enforcement action data to EPA. (EnforcementAgencyName)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_DOCKET_NUM IS 'Notes the relevant docket number which enforcement staff have assigned for tracking of enforcement actions. (EnforcementDocketNumber)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_ATTRY IS 'Identifies the attorney within the agency responsible for issuing the enforcement action. (EnforcementAttorney)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.CORCT_ACT_COMPT IS 'Parent: Compliance Monitoring and Enforcement Data (CorrectiveActionComponent)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.CNST_AGMT_FINAL_ORDER_SEQ_NUM IS 'Parent: Compliance Monitoring and Enforcement Data (ConsentAgreementFinalOrderSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.APPEAL_INIT_DATE IS 'Parent: Compliance Monitoring and Enforcement Data (AppealInitiatedDate)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.APPEAL_RSLN_DATE IS 'Parent: Compliance Monitoring and Enforcement Data (AppealResolutionDate)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.DISP_STAT_DATE IS 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusDate)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.DISP_STAT_OWNER IS 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusOwner)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.DISP_STAT IS 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatus)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_OWNER IS 'State Postal Code (EnforcementOwner)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_TYPE IS 'A code that identifies the type of action being taken against a handler. (EnforcementType)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_RESP_PERSON_OWNER IS 'Indicates the agency that defines the person identifier. (EnforcementResponsiblePersonOwner)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_RESP_PERSON_IDEN IS 'Code indicating the person within the agency responsible for conducting the enforcement. (EnforcementResponsiblePersonIdentifier)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_RESP_SUBORG_OWNER IS 'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganizationOwner)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.ENFRC_RESP_SUBORG IS 'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganization)';
 
   COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.NOTES IS 'Parent: Compliance Monitoring and Enforcement Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_ENFRC_ACT  IS 'Schema element: EnforcementActionDataType';

--  CREATE UNIQUE INDEX PK_RCR_CME_ENF_ACT ON RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID);   
ALTER TABLE RCRA_CME_ENFRC_ACT ADD CONSTRAINT PK_RCR_CME_ENF_ACT PRIMARY KEY (ENFRC_ACT_ID);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_AGN_LOC_NAME NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_IDEN NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_DATE NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_AGN_NAME NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL
--------------------------------------------------------
DROP TABLE RCRA_CME_EVAL;

  CREATE TABLE RCRA_CME_EVAL 
   (	EVAL_ID VARCHAR(40) NOT NULL, 
	CME_FAC_SUBM_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	EVAL_ACT_LOC VARCHAR(255) NOT NULL, 
	EVAL_IDEN VARCHAR(50) NOT NULL, 
	EVAL_START_DATE DATE NOT NULL, 
	EVAL_RESP_AGN VARCHAR(255) NOT NULL, 
	DAY_ZERO DATE, 
	FOUND_VIOL VARCHAR(255), 
	CTZN_CPLT_IND VARCHAR(50), 
	MULTIMEDIA_IND VARCHAR(50), 
	SAMPL_IND VARCHAR(50), 
	NOT_SUBTL_C_IND VARCHAR(50), 
	EVAL_TYPE_OWNER VARCHAR(255), 
	EVAL_TYPE VARCHAR(255), 
	FOCUS_AREA_OWNER VARCHAR(255), 
	FOCUS_AREA VARCHAR(255), 
	EVAL_RESP_PERSON_IDEN_OWNER VARCHAR(255), 
	EVAL_RESP_PERSON_IDEN VARCHAR(50), 
	EVAL_RESP_SUBORG_OWNER VARCHAR(255), 
	EVAL_RESP_SUBORG VARCHAR(255), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_ID IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.CME_FAC_SUBM_ID IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_ACT_LOC IS 'Indicates the location of the agency regulating the EPA handler. (EvaluationActivityLocation)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_IDEN IS 'Name or number assigned by the implementing agency to identify an evaluation. (EvaluationIdentifier)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_START_DATE IS 'The first day of the inspection or record review regardless of the duration of the inspection. (EvaluationStartDate)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_RESP_AGN IS 'Code indicating the agency responsible for conducting the evaluation. (EvaluationResponsibleAgency)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.DAY_ZERO IS 'Date fo the Last Non-Followup Evaluation (Applies to SNY/SNN Evaluations Only) (DayZero)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.FOUND_VIOL IS 'Flag indicating if a violation was found. (FoundViolation)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.CTZN_CPLT_IND IS 'The inspection or record review was initiated because of a tip/complaint (CitizenComplaintIndicator)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.MULTIMEDIA_IND IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (MultimediaIndicator)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.SAMPL_IND IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (SamplingIndicator)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.NOT_SUBTL_C_IND IS 'The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniation made: sit is Non-Hazardous Waste. (NotSubtitleCIndicator)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_TYPE_OWNER IS 'Indicates the agency that defines the type of evaluation. (EvaluationTypeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_TYPE IS 'Code to report the type of evaluation conducted at the handler. (EvaluationType)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.FOCUS_AREA_OWNER IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusAreaOwner)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.FOCUS_AREA IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusArea)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_RESP_PERSON_IDEN_OWNER IS 'Indicates the agency that defines the person identifier. (EvaluationResponsiblePersonIdentifierOwner)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_RESP_PERSON_IDEN IS 'Code indicating the person within the agency responsible for conducting the evaluation. (EvaluationResponsiblePersonIdentifier)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_RESP_SUBORG_OWNER IS 'Indicates the agency that defines the suborganization identifier. (EvaluationResponsibleSuborganizationOwner)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.EVAL_RESP_SUBORG IS 'Code indicating the branch/district within the agency responsible for conducting the evaluation. (EvaluationResponsibleSuborganization)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL.NOTES IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_EVAL  IS 'Schema element: EvaluationDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_EVAL ON RCRA_CME_EVAL (EVAL_ID);  
ALTER TABLE RCRA_CME_EVAL ADD CONSTRAINT PK_RCRA_CME_EVAL PRIMARY KEY (EVAL_ID);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_ACT_LOC NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_IDEN NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_START_DATE NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_RESP_AGN NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------
DROP TABLE RCRA_CME_EVAL_COMMIT;

  CREATE TABLE RCRA_CME_EVAL_COMMIT 
   (	EVAL_COMMIT_ID VARCHAR(40) NOT NULL, 
	EVAL_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	COMMIT_LEAD VARCHAR(255) NOT NULL, 
	COMMIT_SEQ_NUM INTEGER NOT NULL
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.EVAL_COMMIT_ID IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.EVAL_ID IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.COMMIT_LEAD IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentLead)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.COMMIT_SEQ_NUM IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE RCRA_CME_EVAL_COMMIT  IS 'Schema element: EvaluationCommitmentDataType';
   
--  CREATE UNIQUE INDEX PK_RCR_CME_EVL_CMM ON RCRA_CME_EVAL_COMMIT (EVAL_COMMIT_ID);   
  ALTER TABLE RCRA_CME_EVAL_COMMIT ADD CONSTRAINT PK_RCR_CME_EVL_CMM PRIMARY KEY (EVAL_COMMIT_ID);  
  --ALTER TABLE RCRA_CME_EVAL_COMMIT ALTER COLUMN EVAL_COMMIT_ID SET NOT NULL;
  --ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (EVAL_ID NOT NULL ENABLE);
  --ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (COMMIT_LEAD NOT NULL ENABLE);
  --ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (COMMIT_SEQ_NUM NOT NULL ENABLE);
  
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------
DROP TABLE RCRA_CME_EVAL_VIOL;

  CREATE TABLE RCRA_CME_EVAL_VIOL 
   (	EVAL_VIOL_ID VARCHAR(40) NOT NULL, 
	EVAL_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	VIOL_ACT_LOC VARCHAR(255) NOT NULL, 
	VIOL_SEQ_NUM INTEGER NOT NULL, 
	AGN_WHICH_DTRM_VIOL VARCHAR(255) NOT NULL
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.EVAL_VIOL_ID IS 'Parent: Linking Data for Evaluation and Violation (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.EVAL_ID IS 'Parent: Linking Data for Evaluation and Violation (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.VIOL_ACT_LOC IS 'Parent: Linking Data for Evaluation and Violation (ViolationActivityLocation)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.VIOL_SEQ_NUM IS 'Parent: Linking Data for Evaluation and Violation (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.AGN_WHICH_DTRM_VIOL IS 'Parent: Linking Data for Evaluation and Violation (AgencyWhichDeterminedViolation)';
 
   COMMENT ON TABLE RCRA_CME_EVAL_VIOL  IS 'Schema element: EvaluationViolationDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_EVL_VL ON RCRA_CME_EVAL_VIOL (EVAL_VIOL_ID);   
ALTER TABLE RCRA_CME_EVAL_VIOL ADD CONSTRAINT PK_RCRA_CME_EVL_VL PRIMARY KEY (EVAL_VIOL_ID); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (EVAL_VIOL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (EVAL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (VIOL_ACT_LOC NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------
DROP TABLE RCRA_CME_FAC_SUBM;

  CREATE TABLE RCRA_CME_FAC_SUBM 
   (	CME_FAC_SUBM_ID VARCHAR(40) NOT NULL, 
	HAZRD_WASTE_CME_SUBM_ID VARCHAR(40) NOT NULL, 
	EPA_HDLR_ID VARCHAR(255) NOT NULL
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_FAC_SUBM.CME_FAC_SUBM_ID IS 'Parent: This contains Hbasic Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_FAC_SUBM.HAZRD_WASTE_CME_SUBM_ID IS 'Parent: This contains Hbasic Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_FAC_SUBM.EPA_HDLR_ID IS 'Number that uniquely identifies the EPA handler. (EPAHandlerID)';
 
   COMMENT ON TABLE RCRA_CME_FAC_SUBM  IS 'Schema element: CMEFacilitySubmissionDataType';
   
--  CREATE UNIQUE INDEX PK_RCRA_CME_FC_SBM ON RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID);
  ALTER TABLE RCRA_CME_FAC_SUBM ADD CONSTRAINT PK_RCRA_CME_FC_SBM PRIMARY KEY (CME_FAC_SUBM_ID);
--ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (HAZRD_WASTE_CME_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (EPA_HDLR_ID NOT NULL ENABLE);
  
--------------------------------------------------------
--  DDL for Table RCRA_CME_HAZRD_WASTE_CME_SUBM
--------------------------------------------------------
DROP TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM;

  CREATE TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM 
   (	HAZRD_WASTE_CME_SUBM_ID VARCHAR(40) NOT NULL
   ) ;
 

   COMMENT ON TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM  IS 'Schema element: HazardousWasteCMESubmissionDataType';

--  CREATE UNIQUE INDEX PK_RC_CM_HZ_WS_CM ON RCRA_CME_HAZRD_WASTE_CME_SUBM (HAZRD_WASTE_CME_SUBM_ID);
ALTER TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM ADD CONSTRAINT PK_RC_CM_HZ_WS_CM PRIMARY KEY (HAZRD_WASTE_CME_SUBM_ID);
--ALTER TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM MODIFY (HAZRD_WASTE_CME_SUBM_ID NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_MEDIA
--------------------------------------------------------
DROP TABLE RCRA_CME_MEDIA;

  CREATE TABLE RCRA_CME_MEDIA 
   (	MEDIA_ID VARCHAR(40) NOT NULL, 
	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	MULTIMEDIA_CODE_OWNER VARCHAR(255) NOT NULL, 
	MULTIMEDIA_CODE VARCHAR(50) NOT NULL, 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_MEDIA.MEDIA_ID IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.MULTIMEDIA_CODE_OWNER IS 'Indicates the agency that defines the multimedia code. (MultimediaCodeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.MULTIMEDIA_CODE IS 'Code which indicates the medium or program other than RCRA participating in the enforcement action. (MultimediaCode)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.NOTES IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_MEDIA  IS 'Schema element: MediaDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_MEDIA ON RCRA_CME_MEDIA (MEDIA_ID);   
ALTER TABLE RCRA_CME_MEDIA ADD CONSTRAINT PK_RCRA_CME_MEDIA PRIMARY KEY (MEDIA_ID);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (MEDIA_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (MULTIMEDIA_CODE_OWNER NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (MULTIMEDIA_CODE NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_MILESTONE
--------------------------------------------------------
DROP TABLE RCRA_CME_MILESTONE;

  CREATE TABLE RCRA_CME_MILESTONE 
   (	MILESTONE_ID VARCHAR(40) NOT NULL, 
	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	MILESTONE_SEQ_NUM INTEGER NOT NULL, 
	TECH_RQMT_IDEN VARCHAR(50), 
	TECH_RQMT_DESC VARCHAR(255), 
	MILESTONE_SCHD_COMP_DATE DATE, 
	MILESTONE_ACTL_COMP_DATE DATE, 
	MILESTONE_DFLT_DATE DATE, 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_MILESTONE.MILESTONE_ID IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.MILESTONE_SEQ_NUM IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.TECH_RQMT_IDEN IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementIdentifier)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.TECH_RQMT_DESC IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementDescription)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.MILESTONE_SCHD_COMP_DATE IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneScheduledCompletionDate)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.MILESTONE_ACTL_COMP_DATE IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneActualCompletionDate)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.MILESTONE_DFLT_DATE IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneDefaultedDate)';
 
   COMMENT ON COLUMN RCRA_CME_MILESTONE.NOTES IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_MILESTONE  IS 'Schema element: MilestoneDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_MLSTNE ON RCRA_CME_MILESTONE (MILESTONE_ID);   
ALTER TABLE RCRA_CME_MILESTONE ADD CONSTRAINT PK_RCRA_CME_MLSTNE PRIMARY KEY (MILESTONE_ID);
--ALTER TABLE RCRA_CME_MILESTONE MODIFY (MILESTONE_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MILESTONE MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MILESTONE MODIFY (MILESTONE_SEQ_NUM NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_CME_PNLTY
--------------------------------------------------------
DROP TABLE RCRA_CME_PNLTY;

  CREATE TABLE RCRA_CME_PNLTY 
   (	PNLTY_ID VARCHAR(40) NOT NULL, 
	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	PNLTY_TYPE_OWNER VARCHAR(255) NOT NULL, 
	PNLTY_TYPE VARCHAR(255) NOT NULL, 
	CASH_CIVIL_PNLTY_SOUGHT_AMOUNT DECIMAL(14,6), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_PNLTY.PNLTY_ID IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.PNLTY_TYPE_OWNER IS 'Indicates the agency that defines the penalty type (PenaltyTypeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.PNLTY_TYPE IS 'Code which indicates the type of penalty associated with the penalty amount. (PenaltyType)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT IS 'The dollar amount of any proposed cash civil penalty set forth in a Complaint/Proposed Order. (CashCivilPenaltySoughtAmount)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.NOTES IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_PNLTY  IS 'Schema element: PenaltyDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_PNLTY ON RCRA_CME_PNLTY (PNLTY_ID);
ALTER TABLE RCRA_CME_PNLTY ADD CONSTRAINT PK_RCRA_CME_PNLTY PRIMARY KEY (PNLTY_ID); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (ENFRC_ACT_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_TYPE_OWNER NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_TYPE NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_PYMT
--------------------------------------------------------
DROP TABLE RCRA_CME_PYMT;

  CREATE TABLE RCRA_CME_PYMT 
   (	PYMT_ID VARCHAR(40) NOT NULL, 
	PNLTY_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	PYMT_SEQ_NUM INTEGER NOT NULL, 
	PYMT_DFLT_DATE DATE, 
	SCHD_PYMT_DATE DATE, 
	SCHD_PYMT_AMOUNT DECIMAL(14,6), 
	ACTL_PYMT_DATE DATE, 
	ACTL_PAID_AMOUNT DECIMAL(14,6), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_PYMT.PYMT_ID IS 'Parent: Compliance Monitoring and Enforcement Payment Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.PNLTY_ID IS 'Parent: Compliance Monitoring and Enforcement Payment Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.PYMT_SEQ_NUM IS 'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.PYMT_DFLT_DATE IS 'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentDefaultedDate)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.SCHD_PYMT_DATE IS 'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentDate)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.SCHD_PYMT_AMOUNT IS 'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentAmount)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.ACTL_PYMT_DATE IS 'Parent: Compliance Monitoring and Enforcement Payment Data (ActualPaymentDate)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.ACTL_PAID_AMOUNT IS 'The dollar amount of any cost recovery required to be paid pursuant to a Final Order. (ActualPaidAmount)';
 
   COMMENT ON COLUMN RCRA_CME_PYMT.NOTES IS 'Parent: Compliance Monitoring and Enforcement Payment Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_PYMT  IS 'Schema element: PaymentDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_PYMT ON RCRA_CME_PYMT (PYMT_ID);
ALTER TABLE RCRA_CME_PYMT ADD CONSTRAINT PK_RCRA_CME_PYMT PRIMARY KEY (PYMT_ID); 
--ALTER TABLE RCRA_CME_PYMT MODIFY (PYMT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_PYMT MODIFY (PNLTY_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_PYMT MODIFY (PYMT_SEQ_NUM NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_CME_RQST
--------------------------------------------------------
DROP TABLE RCRA_CME_RQST;

  CREATE TABLE RCRA_CME_RQST 
   (	RQST_ID VARCHAR(40) NOT NULL, 
	EVAL_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	RQST_SEQ_NUM INTEGER NOT NULL, 
	DATE_OF_RQST DATE, 
	DATE_RESP_RCVD DATE, 
	RQST_AGN VARCHAR(255), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_RQST.RQST_ID IS 'Parent: Compliance Monitoring and Enforcement Request Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.EVAL_ID IS 'Parent: Compliance Monitoring and Enforcement Request Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.RQST_SEQ_NUM IS 'Parent: Compliance Monitoring and Enforcement Request Data (RequestSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.DATE_OF_RQST IS 'Parent: Compliance Monitoring and Enforcement Request Data (DateOfRequest)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.DATE_RESP_RCVD IS 'Parent: Compliance Monitoring and Enforcement Request Data (DateResponseReceived)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.RQST_AGN IS 'Parent: Compliance Monitoring and Enforcement Request Data (RequestAgency)';
 
   COMMENT ON COLUMN RCRA_CME_RQST.NOTES IS 'Parent: Compliance Monitoring and Enforcement Request Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_RQST  IS 'Schema element: RequestDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_RQST ON RCRA_CME_RQST (RQST_ID);   
ALTER TABLE RCRA_CME_RQST ADD CONSTRAINT PK_RCRA_CME_RQST PRIMARY KEY (RQST_ID); 
--ALTER TABLE RCRA_CME_RQST MODIFY (RQST_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_RQST MODIFY (EVAL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_RQST MODIFY (RQST_SEQ_NUM NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------
DROP TABLE RCRA_CME_SUPP_ENVR_PRJT;

  CREATE TABLE RCRA_CME_SUPP_ENVR_PRJT 
   (	SUPP_ENVR_PRJT_ID VARCHAR(40) NOT NULL, 
	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	SEP_SEQ_NUM INTEGER NOT NULL, 
	SEP_EXPND_AMOUNT DECIMAL(14,6), 
	SEP_SCHD_COMP_DATE DATE, 
	SEP_ACTL_DATE DATE, 
	SEP_DFLT_DATE DATE, 
	SEP_CODE_OWNER VARCHAR(255), 
	SEP_DESC_TXT VARCHAR(255), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SUPP_ENVR_PRJT_ID IS 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_SEQ_NUM IS 'SEP Sequence Number allowed value 01-99 (SEPSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_EXPND_AMOUNT IS 'Expenditure Amount (SEPExpenditureAmount)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_SCHD_COMP_DATE IS 'Valid date greater than or equal to the Date of Enforcement Action. (SEPScheduledCompletionDate)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_ACTL_DATE IS 'SEP actual completion date (SEPActualDate)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_DFLT_DATE IS 'Date the SEP defaulted (SEPDefaultedDate)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_CODE_OWNER IS 'State postal code (SEPCodeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.SEP_DESC_TXT IS 'The narrative text describing any Supplemental Environmental Projects required to be performed pursuant to a Final Order. (SEPDescriptionText)';
 
   COMMENT ON COLUMN RCRA_CME_SUPP_ENVR_PRJT.NOTES IS 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_SUPP_ENVR_PRJT  IS 'Schema element: SupplementalEnvironmentalProjectDataType';

--  CREATE UNIQUE INDEX PK_RCR_CM_SP_EN_PR ON RCRA_CME_SUPP_ENVR_PRJT (SUPP_ENVR_PRJT_ID);  
ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT ADD CONSTRAINT PK_RCR_CM_SP_EN_PR PRIMARY KEY (SUPP_ENVR_PRJT_ID);
--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (SUPP_ENVR_PRJT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (SEP_SEQ_NUM NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_VIOL
--------------------------------------------------------
DROP TABLE RCRA_CME_VIOL;

  CREATE TABLE RCRA_CME_VIOL 
   (	VIOL_ID VARCHAR(40) NOT NULL, 
	CME_FAC_SUBM_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	VIOL_ACT_LOC VARCHAR(255) NOT NULL, 
	VIOL_SEQ_NUM INTEGER NOT NULL, 
	AGN_WHICH_DTRM_VIOL VARCHAR(255) NOT NULL, 
	VIOL_TYPE_OWNER VARCHAR(255), 
	VIOL_TYPE VARCHAR(255), 
	FORMER_CITATION_NAME VARCHAR(128), 
	VIOL_DTRM_DATE DATE, 
	RTN_COMPL_ACTL_DATE DATE, 
	RTN_TO_COMPL_QUAL VARCHAR(255), 
	VIOL_RESP_AGN VARCHAR(255), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_ID IS 'Parent: Compliance Monitoring and Enforcement Violation Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.CME_FAC_SUBM_ID IS 'Parent: Compliance Monitoring and Enforcement Violation Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_ACT_LOC IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationActivityLocation)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_SEQ_NUM IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.AGN_WHICH_DTRM_VIOL IS 'Parent: Compliance Monitoring and Enforcement Violation Data (AgencyWhichDeterminedViolation)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_TYPE_OWNER IS 'Allowed value HQ (ViolationTypeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_TYPE IS 'Violation Type (ViolationType)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.FORMER_CITATION_NAME IS 'Parent: Compliance Monitoring and Enforcement Violation Data (FormerCitationName)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_DTRM_DATE IS 'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation. (ViolationDeterminedDate)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.RTN_COMPL_ACTL_DATE IS 'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceActualDate)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.RTN_TO_COMPL_QUAL IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ReturnToComplianceQualifier)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.VIOL_RESP_AGN IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationResponsibleAgency)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL.NOTES IS 'Parent: Compliance Monitoring and Enforcement Violation Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_VIOL  IS 'Schema element: ViolationDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_VIOL ON RCRA_CME_VIOL (VIOL_ID);
ALTER TABLE RCRA_CME_VIOL ADD CONSTRAINT PK_RCRA_CME_VIOL PRIMARY KEY (VIOL_ID); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_ACT_LOC NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------
DROP TABLE RCRA_CME_VIOL_ENFRC;

  CREATE TABLE RCRA_CME_VIOL_ENFRC 
   (	VIOL_ENFRC_ID VARCHAR(40) NOT NULL, 
	ENFRC_ACT_ID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	VIOL_SEQ_NUM INTEGER NOT NULL, 
	AGN_WHICH_DTRM_VIOL VARCHAR(255) NOT NULL, 
	RTN_COMPL_SCHD_DATE DATE
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.VIOL_ENFRC_ID IS 'Parent: Linking Data for Violation and Enforcement (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.ENFRC_ACT_ID IS 'Parent: Linking Data for Violation and Enforcement (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.VIOL_SEQ_NUM IS 'Parent: Linking Data for Violation and Enforcement (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.AGN_WHICH_DTRM_VIOL IS 'Parent: Linking Data for Violation and Enforcement (AgencyWhichDeterminedViolation)';
 
   --COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.RTN_COMPL_SCHD_DATE IS 'The calendar date, specified in the Compliance Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)';
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.RTN_COMPL_SCHD_DATE IS 'The date, specified in the Compl Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)';   
 
   COMMENT ON TABLE RCRA_CME_VIOL_ENFRC  IS 'Schema element: ViolationEnforcementDataType';

--  CREATE UNIQUE INDEX PK_RCRA_CME_VL_ENF ON RCRA_CME_VIOL_ENFRC (VIOL_ENFRC_ID);   
ALTER TABLE RCRA_CME_VIOL_ENFRC ADD CONSTRAINT PK_RCRA_CME_VL_ENF PRIMARY KEY (VIOL_ENFRC_ID);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (VIOL_ENFRC_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------
DROP TABLE RCRA_HD_CERTIFICATION;

  CREATE TABLE RCRA_HD_CERTIFICATION 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	CERT_SEQ INTEGER NOT NULL, 
	CERT_SIGNED_DATE VARCHAR(10), 
	CERT_TITLE VARCHAR(45), 
	CERT_FIRST_NAME VARCHAR(15), 
	CERT_MIDDLE_INITIAL CHAR(1), 
	CERT_LAST_NAME VARCHAR(15)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.PK_GUID IS 'Parent: Certification information for the person who certified report to the authorizing agency. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.FK_GUID IS 'Parent: Certification information for the person who certified report to the authorizing agency. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.CERT_SEQ IS 'Sequence number for each certification for the handler. (CertificationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.CERT_SIGNED_DATE IS 'Date on which the handler information was certified by the reporting site. (SignedDate)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.CERT_TITLE IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.CERT_FIRST_NAME IS 'First name of a person. (FirstName)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.CERT_MIDDLE_INITIAL IS 'Middle initial of a person. (MiddleInitial)';
 
   COMMENT ON COLUMN RCRA_HD_CERTIFICATION.CERT_LAST_NAME IS 'Last name of a person. (LastName)';
 
   COMMENT ON TABLE RCRA_HD_CERTIFICATION  IS 'Schema element: CertificationDataType';

--CREATE UNIQUE INDEX PK_RCRA_HD_CERTIFI ON RCRA_HD_CERTIFICATION (PK_GUID);
ALTER TABLE RCRA_HD_CERTIFICATION ADD CONSTRAINT PK_RCRA_HD_CERTIFI PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (CERT_SEQ NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------
DROP TABLE RCRA_HD_ENV_PERMIT;

  CREATE TABLE RCRA_HD_ENV_PERMIT 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	ENV_PERMIT_NUMBER VARCHAR(13) NOT NULL, 
	ENV_PERMIT_OWNER CHAR(2), 
	ENV_PERMIT_TYPE CHAR(1), 
	ENV_PERMIT_DESC VARCHAR(20) NOT NULL
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.PK_GUID IS 'Parent: Information about environmental permits issued to the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.FK_GUID IS 'Parent: Information about environmental permits issued to the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_NUMBER IS 'Identification number of an effective environmental permit issued to the handler, or the number of a filed application for which an environmental permit has not yet been issued. (EnvironmentalPermitID)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_OWNER IS 'Indicates the agency that defines the other permit type. (EnvironmentalPermitOwnerName)';
 
   --COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_TYPE IS 'Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only. (EnvironmentalPermitTypeCode)';
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_TYPE IS 'Code indicating the env program and/or jurisdictional authority under which an env permit was issued to the facility, or under which an appl has been filed for which a permit is not issued. Applicable to TSD facilities only. (EnvironmentalPermitTypeCode)';   
      
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_DESC IS 'Description of any permit type indicated as O (Other) in the Permit Type field. (EnvironmentalPermitDescription)';
 
   COMMENT ON TABLE RCRA_HD_ENV_PERMIT  IS 'Schema element: EnvironmentalPermitDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_ENV_PER ON RCRA_HD_ENV_PERMIT (PK_GUID);
ALTER TABLE RCRA_HD_ENV_PERMIT ADD CONSTRAINT PK_RCRA_HD_ENV_PER PRIMARY KEY (PK_GUID); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (FK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (ENV_PERMIT_NUMBER NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (ENV_PERMIT_DESC NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_HANDLER
--------------------------------------------------------
DROP TABLE RCRA_HD_HANDLER;

  CREATE TABLE RCRA_HD_HANDLER 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	ACTIVITY_LOCATION CHAR(2) NOT NULL, 
	SOURCE_TYPE CHAR(1) NOT NULL, 
	SEQ_NUMBER INTEGER NOT NULL, 
	RECEIVE_DATE VARCHAR(10), 
	HANDLER_NAME VARCHAR(80), 
	ACKNOWLEDGE_DATE VARCHAR(10), 
	NON_NOTIFIER CHAR(1), 
	TSD_DATE VARCHAR(10), 
	OFF_SITE_RECEIPT CHAR(1), 
	ACCESSIBILITY CHAR(1), 
	COUNTY_CODE_OWNER CHAR(2), 
	COUNTY_CODE VARCHAR(5), 
	NOTES VARCHAR(2000), 
	ACKNOWLEDGE_FLAG CHAR(1), 
	LOCATION_STREET1 VARCHAR(30), 
	LOCATION_STREET2 VARCHAR(30), 
	LOCATION_CITY VARCHAR(25), 
	LOCATION_STATE CHAR(2), 
	LOCATION_COUNTRY CHAR(2), 
	LOCATION_ZIP VARCHAR(14), 
	MAIL_STREET1 VARCHAR(30), 
	MAIL_STREET2 VARCHAR(30), 
	MAIL_CITY VARCHAR(25), 
	MAIL_STATE CHAR(2), 
	MAIL_COUNTRY CHAR(2), 
	MAIL_ZIP VARCHAR(14), 
	CONTACT_FIRST_NAME VARCHAR(15), 
	CONTACT_MIDDLE_INITIAL CHAR(1), 
	CONTACT_LAST_NAME VARCHAR(15), 
	CONTACT_ORG_NAME VARCHAR(80), 
	CONTACT_TITLE VARCHAR(80), 
	CONTACT_EMAIL_ADDRESS VARCHAR(240), 
	CONTACT_PHONE VARCHAR(15), 
	CONTACT_PHONE_EXT VARCHAR(6), 
	CONTACT_FAX VARCHAR(15), 
	CONTACT_STREET1 VARCHAR(30), 
	CONTACT_STREET2 VARCHAR(30), 
	CONTACT_CITY VARCHAR(25), 
	CONTACT_STATE CHAR(2), 
	CONTACT_COUNTRY CHAR(2), 
	CONTACT_ZIP VARCHAR(14), 
	PCONTACT_FIRST_NAME VARCHAR(15), 
	PCONTACT_MIDDLE_NAME CHAR(1), 
	PCONTACT_LAST_NAME VARCHAR(15), 
	PCONTACT_ORG_NAME VARCHAR(80), 
	PCONTACT_TITLE VARCHAR(80), 
	PCONTACT_EMAIL_ADDRESS VARCHAR(240), 
	PCONTACT_PHONE VARCHAR(15), 
	PCONTACT_PHONE_EXT VARCHAR(6), 
	PCONTACT_FAX VARCHAR(15), 
	PCONTACT_STREET1 VARCHAR(30), 
	PCONTACT_STREET2 VARCHAR(30), 
	PCONTACT_CITY VARCHAR(25), 
	PCONTACT_STATE CHAR(2), 
	PCONTACT_COUNTRY CHAR(2), 
	PCONTACT_ZIP VARCHAR(14), 
	USED_OIL_BURNER CHAR(1), 
	USED_OIL_PROCESSOR CHAR(1), 
	USED_OIL_REFINER CHAR(1), 
	USED_OIL_MARKET_BURNER CHAR(1), 
	USED_OIL_SPEC_MARKETER CHAR(1), 
	USED_OIL_TRANSFER_FACILITY CHAR(1), 
	USED_OIL_TRANSPORTER CHAR(1), 
	LAND_TYPE CHAR(1), 
	STATE_DISTRICT_OWNER CHAR(2), 
	STATE_DISTRICT VARCHAR(10), 
	IMPORTER_ACTIVITY CHAR(1), 
	MIXED_WASTE_GENERATOR CHAR(1), 
	RECYCLER_ACTIVITY CHAR(1), 
	TRANSPORTER_ACTIVITY CHAR(1), 
	TSD_ACTIVITY CHAR(1), 
	UNDERGROUND_INJECTION_ACTIVITY CHAR(1), 
	UNIVERSAL_WASTE_DEST_FACILITY CHAR(1), 
	ONSITE_BURNER_EXEMPTION CHAR(1), 
	FURNACE_EXEMPTION CHAR(1), 
	SHORT_TERM_GEN_IND VARCHAR(50), 
	TRANSFER_FACILITY_IND VARCHAR(50), 
	STATE_WASTE_GENERATOR_OWNER CHAR(2), 
	STATE_WASTE_GENERATOR CHAR(1), 
	FED_WASTE_GENERATOR_OWNER CHAR(2), 
	FED_WASTE_GENERATOR CHAR(1), 
	COLLEGE_IND VARCHAR(50), 
	HOSPITAL_IND VARCHAR(50), 
	NON_PROFIT_IND VARCHAR(50), 
	WITHDRAWAL_IND VARCHAR(50), 
	TRANS_CODE VARCHAR(50), 
	NOTIFICATION_RSN_CODE VARCHAR(50), 
	FINANCIAL_ASSURANCE_IND VARCHAR(50)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_HANDLER.PK_GUID IS 'Parent: Top level of all information about the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.FK_GUID IS 'Parent: Top level of all information about the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.ACTIVITY_LOCATION IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.SOURCE_TYPE IS 'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.SEQ_NUMBER IS 'Sequence number for each source record about a handler. (SourceRecordSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.RECEIVE_DATE IS 'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.HANDLER_NAME IS 'Name of the Handler (HandlerName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.ACKNOWLEDGE_DATE IS 'Date information was received for the handler. (AcknowledgeReceiptDate)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.NON_NOTIFIER IS 'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.TSD_DATE IS 'The date that operation of the facility commenced, the date construction on the facility commenced, or the date that operation is expected to begin. (TreatmentStorageDisposalDate)';
 
   --COMMENT ON COLUMN RCRA_HD_HANDLER.OFF_SITE_RECEIPT IS 'Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status). (OffsiteWasteReceiptCode)';
   COMMENT ON COLUMN RCRA_HD_HANDLER.OFF_SITE_RECEIPT IS 'Public or Private handler, currently accepts hazardous waste from another site (with a different EPA ID). Info. about accepted processes and wastes is shown by a flag at process unit level (Process Unit Group Commercial Status). (OffsiteWasteReceiptCode)';   
   --COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.RTN_COMPL_SCHD_DATE IS 'The date, specified in the Compl Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)';  
   COMMENT ON COLUMN RCRA_HD_HANDLER.ACCESSIBILITY IS 'Code indicating the reason why the handler is not accessible for normal RCRA tracking and processing (previously called Bankrupt Indicator). (AccessibilityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.COUNTY_CODE_OWNER IS 'Indicates the agency that defines the county code. (CountyCodeOwner)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.COUNTY_CODE IS 'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, Counties and County Equivalents of the States of the United States). (CountyCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.NOTES IS 'Notes regarding the Handler. (HandlerSupplementalInformationText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.ACKNOWLEDGE_FLAG IS 'Parent: Top level of all information about the handler. (AcknowledgeFlag)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LOCATION_STREET1 IS 'Parent: Location address information. (LocationAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LOCATION_STREET2 IS 'Parent: Location address information. (SupplementalLocationText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LOCATION_CITY IS 'Parent: Location address information. (LocalityName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LOCATION_STATE IS 'Parent: Location address information. (StateUSPSCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LOCATION_COUNTRY IS 'Parent: Location address information. (CountryName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LOCATION_ZIP IS 'Parent: Location address information. (LocationZIPCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MAIL_STREET1 IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MAIL_STREET2 IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MAIL_CITY IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MAIL_STATE IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MAIL_COUNTRY IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MAIL_ZIP IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_FIRST_NAME IS 'Parent: Contact information. (FirstName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_MIDDLE_INITIAL IS 'Parent: Contact information. (MiddleInitial)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_LAST_NAME IS 'Parent: Contact information. (LastName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_ORG_NAME IS 'Parent: Contact information. (OrganizationFormalName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_TITLE IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_EMAIL_ADDRESS IS 'Email address data (EmailAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_PHONE IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_PHONE_EXT IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_FAX IS 'Contact fax number (FaxNumberText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_STREET1 IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_STREET2 IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_CITY IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_STATE IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_COUNTRY IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.CONTACT_ZIP IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_FIRST_NAME IS 'Parent: Contact information. (FirstName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_MIDDLE_NAME IS 'Parent: Contact information. (MiddleInitial)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_LAST_NAME IS 'Parent: Contact information. (LastName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_ORG_NAME IS 'Parent: Contact information. (OrganizationFormalName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_TITLE IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_EMAIL_ADDRESS IS 'Email address data (EmailAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_PHONE IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_PHONE_EXT IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_FAX IS 'Contact fax number (FaxNumberText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_STREET1 IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_STREET2 IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_CITY IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_STATE IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_COUNTRY IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.PCONTACT_ZIP IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_BURNER IS 'Code indicating that the handler is engaged in the burning of used oil fuel. (FuelBurnerCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_PROCESSOR IS 'Code indicating that the handler is engaged in processing used oil activities. (ProcessorCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_REFINER IS 'Code indicating that the handler is engaged in re-refining used oil activities. (RefinerCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_MARKET_BURNER IS 'Code indicating that the handler directs shipments of used oil to burners. (MarketBurnerCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_SPEC_MARKETER IS 'Code indicating that the handler is a marketer who first claims the used oil meets the specifications. (SpecificationMarketerCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_TRANSFER_FACILITY IS 'Code indicating that the handler owns or operates a used oil transfer facility. (TransferFacilityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.USED_OIL_TRANSPORTER IS 'Code indicating that the handler is engaged in used oil transportation and/or transfer facility activities. (TransporterCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.LAND_TYPE IS 'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.STATE_DISTRICT_OWNER IS 'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.STATE_DISTRICT IS 'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.IMPORTER_ACTIVITY IS 'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.MIXED_WASTE_GENERATOR IS 'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.RECYCLER_ACTIVITY IS 'Code indicating that the handler is engaged in recycling hazardous waste. (RecyclerActivityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.TRANSPORTER_ACTIVITY IS 'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.TSD_ACTIVITY IS 'Code indicating that the handler is engaged in the treatment, storage, or disposal of hazardous waste. (TreatmentStorageDisposalActivityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.UNDERGROUND_INJECTION_ACTIVITY IS 'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.UNIVERSAL_WASTE_DEST_FACILITY IS 'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.ONSITE_BURNER_EXEMPTION IS 'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.FURNACE_EXEMPTION IS 'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.SHORT_TERM_GEN_IND IS 'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.TRANSFER_FACILITY_IND IS 'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.STATE_WASTE_GENERATOR_OWNER IS 'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.STATE_WASTE_GENERATOR IS 'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.FED_WASTE_GENERATOR_OWNER IS 'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.FED_WASTE_GENERATOR IS 'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.COLLEGE_IND IS 'Indicates whether or not the Handler is a College or University opting into SubPart K. (CollegeIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.HOSPITAL_IND IS 'Indicates whether or not the Handler is a Hospital opting into SubPart K. (HospitalIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.NON_PROFIT_IND IS 'Indicates whether or not the Handler is a Non-Profit opting into SubPart K. (NonProfitIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.WITHDRAWAL_IND IS 'Indicates whether or not the Handler is withdrawing from SubPart K. (WithdrawalIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.NOTIFICATION_RSN_CODE IS 'Indicates the reason for notifying Hazardous Secondary Material (NotificationReasonCode)';
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.FINANCIAL_ASSURANCE_IND IS 'Indicates whether or not the facility has provided Financial Assurance for the HSM Activities (FinancialAssuranceIndicator)';
 
   COMMENT ON TABLE RCRA_HD_HANDLER  IS 'Schema element: HandlerDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_HANDLER ON RCRA_HD_HANDLER (PK_GUID);   
ALTER TABLE RCRA_HD_HANDLER ADD CONSTRAINT PK_RCRA_HD_HANDLER PRIMARY KEY (PK_GUID); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (FK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (ACTIVITY_LOCATION NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (SOURCE_TYPE NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (SEQ_NUMBER NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_HD_HBASIC
--------------------------------------------------------
DROP TABLE RCRA_HD_HBASIC;

  CREATE TABLE RCRA_HD_HBASIC 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	HANDLER_ID VARCHAR(12) NOT NULL, 
	EXTRACT_FLAG CHAR(1), 
	FACILITY_IDENTIFIER VARCHAR(12), 
	LAST_UPDATE_DATE DATE
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_HBASIC.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_HBASIC.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON COLUMN RCRA_HD_HBASIC.EXTRACT_FLAG IS 'Designates that data is available for extract for public use. (PublicUseExtractIndicator)';
 
   --COMMENT ON COLUMN RCRA_HD_HBASIC.FACILITY_IDENTIFIER IS 'Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems. (FacilityRegistryID)';
   COMMENT ON COLUMN RCRA_HD_HBASIC.FACILITY_IDENTIFIER IS 'Computer-generated primary facility-level key in the EPA FINDS data system. used to cross-reference entities regulated under env programs. Agency Facility Id Data Standard (FIDS) requires program offices store this key. (FacilityRegistryID)';   
 
   COMMENT ON TABLE RCRA_HD_HBASIC  IS 'Schema element: FacilitySubmissionDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_HBASIC ON RCRA_HD_HBASIC (PK_GUID);   
ALTER TABLE RCRA_HD_HBASIC ADD CONSTRAINT PK_RCRA_HD_HBASIC PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_HBASIC MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_HBASIC MODIFY (HANDLER_ID NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_HD_NAICS
--------------------------------------------------------
DROP TABLE RCRA_HD_NAICS;

  CREATE TABLE RCRA_HD_NAICS 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	NAICS_SEQ INTEGER NOT NULL, 
	NAICS_OWNER CHAR(2), 
	NAICS_CODE VARCHAR(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_NAICS.PK_GUID IS 'Parent: North American Industry Classification Status codes reported for the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.FK_GUID IS 'Parent: North American Industry Classification Status codes reported for the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.NAICS_SEQ IS 'Sequence number for each NAICS code for the handler. (NAICSSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.NAICS_OWNER IS 'Indicates the agency that defines the NAICS Code. (NAICSOwnerCode)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.NAICS_CODE IS 'The North American Industry Classification System Code that identifies the business activities of the facility. (NAICSCode)';
 
   COMMENT ON TABLE RCRA_HD_NAICS  IS 'Schema element: NAICSIdentityDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_NAICS ON RCRA_HD_NAICS (PK_GUID);   
ALTER TABLE RCRA_HD_NAICS ADD CONSTRAINT PK_RCRA_HD_NAICS PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_NAICS MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_NAICS MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_NAICS MODIFY (NAICS_SEQ NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_OTHER_ID
--------------------------------------------------------
DROP TABLE RCRA_HD_OTHER_ID;

  CREATE TABLE RCRA_HD_OTHER_ID 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	OTHER_ID VARCHAR(12) NOT NULL, 
	RELATIONSHIP_OWNER CHAR(2), 
	RELATIONSHIP_TYPE CHAR(1), 
	SAME_FACILITY CHAR(1), 
	NOTES VARCHAR(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_OTHER_ID.PK_GUID IS 'Parent: Contains alternative identifiers for the facility. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.FK_GUID IS 'Parent: Contains alternative identifiers for the facility. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.OTHER_ID IS 'Alternate facility identifier. (OtherHandlerID)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.RELATIONSHIP_OWNER IS 'Indicates the agency that owns the Relationship. (RelationshipOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.RELATIONSHIP_TYPE IS 'Indicates the type of the relationship. (RelationshipTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.SAME_FACILITY IS 'Indicates whether the alternate Id references the same facility. (SameFacilityIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_OTHER_ID.NOTES IS 'Notes regarding the alternative facility identifier. (OtherIDSupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_HD_OTHER_ID  IS 'Schema element: OtherIDDataType';
   
--  CREATE UNIQUE INDEX PK_RCRA_HD_OTHE_ID ON RCRA_HD_OTHER_ID (PK_GUID);
ALTER TABLE RCRA_HD_OTHER_ID ADD CONSTRAINT PK_RCRA_HD_OTHE_ID PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_OTHER_ID MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OTHER_ID MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OTHER_ID MODIFY (OTHER_ID NOT NULL ENABLE););   
--------------------------------------------------------
--  DDL for Table RCRA_HD_OWNEROP
--------------------------------------------------------
DROP TABLE RCRA_HD_OWNEROP;

  CREATE TABLE RCRA_HD_OWNEROP 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	OWNER_OP_SEQ INTEGER NOT NULL, 
	OWNER_OP_IND CHAR(2), 
	OWNER_OP_TYPE CHAR(1), 
	DATE_BECAME_CURRENT VARCHAR(10), 
	DATE_ENDED_CURRENT VARCHAR(10), 
	NOTES VARCHAR(240), 
	FIRST_NAME VARCHAR(15), 
	MIDDLE_INITIAL CHAR(1), 
	LAST_NAME VARCHAR(15), 
	ORG_NAME VARCHAR(80), 
	TITLE VARCHAR(80), 
	EMAIL_ADDRESS VARCHAR(240), 
	PHONE VARCHAR(15), 
	PHONE_EXT VARCHAR(6), 
	FAX VARCHAR(15), 
	STREET1 VARCHAR(30), 
	STREET2 VARCHAR(30), 
	CITY VARCHAR(25), 
	STATE CHAR(2), 
	COUNTRY CHAR(2), 
	ZIP VARCHAR(14)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_OWNEROP.PK_GUID IS 'Parent: Handler owner and operator information. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.FK_GUID IS 'Parent: Handler owner and operator information. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.OWNER_OP_SEQ IS 'Sequential number used to order multiple occurrences of owners and operators. (OwnerOperatorSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.OWNER_OP_IND IS 'Code indicating whether the data is associated with a current or previous owner or operator. The system will allow multiple current owners and operators. (OwnerOperatorIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.OWNER_OP_TYPE IS 'Code indicating the owner/operator type. (OwnerOperatorTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.DATE_BECAME_CURRENT IS 'Date indicating when the owner/operator became current. (CurrentStartDate)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.DATE_ENDED_CURRENT IS 'Date indicating when the owner/operator changed to a different owner/operator. (CurrentEndDate)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.NOTES IS 'Notes for the facility Owner Operator. (OwnerOperatorSupplementalInformationText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.FIRST_NAME IS 'Parent: Contact information. (FirstName)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.MIDDLE_INITIAL IS 'Parent: Contact information. (MiddleInitial)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.LAST_NAME IS 'Parent: Contact information. (LastName)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.ORG_NAME IS 'Parent: Contact information. (OrganizationFormalName)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.TITLE IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.EMAIL_ADDRESS IS 'Email address data (EmailAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.PHONE IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.PHONE_EXT IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.FAX IS 'Contact fax number (FaxNumberText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.STREET1 IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.STREET2 IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.CITY IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.STATE IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.COUNTRY IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN RCRA_HD_OWNEROP.ZIP IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON TABLE RCRA_HD_OWNEROP  IS 'Schema element: FacilityOwnerOperatorDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_OWNEROP ON RCRA_HD_OWNEROP (PK_GUID);   
ALTER TABLE RCRA_HD_OWNEROP ADD CONSTRAINT PK_RCRA_HD_OWNEROP PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_OWNEROP MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OWNEROP MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OWNEROP MODIFY (OWNER_OP_SEQ NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------
DROP TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY;

  CREATE TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANS_CODE VARCHAR(50), 
	HSM_SEQ_NUM VARCHAR(20) NOT NULL, 
	FAC_CODE_OWNER_NAME VARCHAR(128), 
	FAC_TYPE_CODE VARCHAR(50), 
	ESTIMATED_SHORT_TONS_QNTY DECIMAL(12,6), 
	ACTL_SHORT_TONS_QNTY DECIMAL(12,6), 
	LAND_BASED_UNIT_IND VARCHAR(50)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.PK_GUID IS 'Parent: Hazardous Secondary Material activity of the Handler (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.FK_GUID IS 'Parent: Hazardous Secondary Material activity of the Handler (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.HSM_SEQ_NUM IS 'Unique number identifying the HSM Activity for the Handler (HSMSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.FAC_CODE_OWNER_NAME IS 'Owner of the Facility Code.  Shoule be HQ or the state code (i.e. KS) (FacilityCodeOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.FAC_TYPE_CODE IS 'Type of facility generating Hazardous Secondary Material (FacilityTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.ESTIMATED_SHORT_TONS_QNTY IS 'The estimated amount of HSM generated by the Handler (EstimatedShortTonsQuantity)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.ACTL_SHORT_TONS_QNTY IS 'The actual amount of HSM generated by the Handler (ActualShortTonsQuantity)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_MATERIAL_ACTIVITY.LAND_BASED_UNIT_IND IS 'Code to indicate if the HSM is being managed in a Land Based Unit (LandBasedUnitIndicator)';
 
   COMMENT ON TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY  IS 'Schema element: HazardousSecondaryMaterialActivityDataType';

--  CREATE UNIQUE INDEX PK_RCR_HD_SE_MA_AC ON RCRA_HD_SEC_MATERIAL_ACTIVITY (PK_GUID);   
ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY ADD CONSTRAINT PK_RCR_HD_SE_MA_AC PRIMARY KEY (PK_GUID); 
--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (FK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (HSM_SEQ_NUM NOT NULL ENABLE);

--------------------------------------------------------
--  DDL for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------
DROP TABLE RCRA_HD_SEC_WASTE_CODE;

  CREATE TABLE RCRA_HD_SEC_WASTE_CODE 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	WASTE_CODE_OWNER CHAR(2), 
	WASTE_CODE_TYPE VARCHAR(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.PK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.FK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.WASTE_CODE_OWNER IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.WASTE_CODE_TYPE IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE RCRA_HD_SEC_WASTE_CODE  IS 'Schema element: SecondaryHandlerWasteCodeDataType';

--  CREATE UNIQUE INDEX PK_RCR_HD_SE_WA_CO ON RCRA_HD_SEC_WASTE_CODE (PK_GUID);
ALTER TABLE RCRA_HD_SEC_WASTE_CODE ADD CONSTRAINT PK_RCR_HD_SE_WA_CO PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_SEC_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_SEC_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------
DROP TABLE RCRA_HD_STATE_ACTIVITY;

  CREATE TABLE RCRA_HD_STATE_ACTIVITY 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	STATE_ACTIVITY_OWNER CHAR(2) NOT NULL, 
	STATE_ACTIVITY_TYPE VARCHAR(5) NOT NULL
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.PK_GUID IS 'Parent: State waste activity of the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.FK_GUID IS 'Parent: State waste activity of the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.STATE_ACTIVITY_OWNER IS 'Indicates the agency that defines the state activity type. (StateActivityOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.STATE_ACTIVITY_TYPE IS 'Code indicating the type of state activity. (StateActivityTypeCode)';
 
   COMMENT ON TABLE RCRA_HD_STATE_ACTIVITY  IS 'Schema element: StateActivityDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_STA_ACT ON RCRA_HD_STATE_ACTIVITY (PK_GUID);   
ALTER TABLE RCRA_HD_STATE_ACTIVITY ADD CONSTRAINT PK_RCRA_HD_STA_ACT PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (STATE_ACTIVITY_OWNER NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (STATE_ACTIVITY_TYPE NOT NULL ENABLE   
--------------------------------------------------------
--  DDL for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------
DROP TABLE RCRA_HD_UNIVERSAL_WASTE;

  CREATE TABLE RCRA_HD_UNIVERSAL_WASTE 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	UNIVERSAL_WASTE_OWNER CHAR(2), 
	UNIVERSAL_WASTE_TYPE CHAR(1), 
	ACCUMULATED CHAR(1), 
	GENERATED CHAR(1)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.PK_GUID IS 'Parent: Information about universal waste generated by the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.FK_GUID IS 'Parent: Information about universal waste generated by the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.UNIVERSAL_WASTE_OWNER IS 'Indicates the agency that defines the universal waste type. (UniversalWasteOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.UNIVERSAL_WASTE_TYPE IS 'Code indicating the type of universal waste. (UniversalWasteTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.ACCUMULATED IS 'Code indicating that the handler is engaged in accumulating waste on site. (AccumulatedWasteCode)';
 
   COMMENT ON COLUMN RCRA_HD_UNIVERSAL_WASTE.GENERATED IS 'Code indicating that the handler is engaged in generating waste on site. (GeneratedHandlerCode)';
 
   COMMENT ON TABLE RCRA_HD_UNIVERSAL_WASTE  IS 'Schema element: UniversalWasteActivityDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_UNI_WAS ON RCRA_HD_UNIVERSAL_WASTE (PK_GUID);   
ALTER TABLE RCRA_HD_UNIVERSAL_WASTE ADD CONSTRAINT PK_RCRA_HD_UNI_WAS PRIMARY KEY (PK_GUID);
--ALTER TABLE RCRA_HD_UNIVERSAL_WASTE MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_UNIVERSAL_WASTE MODIFY (FK_GUID NOT NULL ENABLE);   
--------------------------------------------------------
--  DDL for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------
DROP TABLE RCRA_HD_WASTE_CODE;

  CREATE TABLE RCRA_HD_WASTE_CODE 
   (	PK_GUID VARCHAR(40) NOT NULL, 
	FK_GUID VARCHAR(40) NOT NULL, 
	TRANSACTION_CODE CHAR(1), 
	WASTE_CODE_OWNER CHAR(2), 
	WASTE_CODE_TYPE VARCHAR(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.PK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.FK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.WASTE_CODE_OWNER IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.WASTE_CODE_TYPE IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE RCRA_HD_WASTE_CODE  IS 'Schema element: HandlerWasteCodeDataType';

--  CREATE UNIQUE INDEX PK_RCRA_HD_WAS_COD ON RCRA_HD_WASTE_CODE (PK_GUID);  
ALTER TABLE RCRA_HD_WASTE_CODE ADD CONSTRAINT PK_RCRA_HD_WAS_COD PRIMARY KEY (PK_GUID); 
--ALTER TABLE RCRA_HD_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);

--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------
--ALTER TABLE RCRA_CME_EVAL_COMMIT ADD CONSTRAINT PK_RCR_CME_EVL_CMM PRIMARY KEY (EVAL_COMMIT_ID);
--  ALTER TABLE RCRA_CME_EVAL_COMMIT ADD PRIMARY KEY (EVAL_COMMIT_ID);  
--  ALTER TABLE RCRA_CME_EVAL_COMMIT ALTER COLUMN EVAL_COMMIT_ID SET NOT NULL;
--  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (EVAL_ID NOT NULL ENABLE);
--  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (COMMIT_LEAD NOT NULL ENABLE);
--  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (COMMIT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------
--ALTER TABLE RCRA_CME_FAC_SUBM ADD CONSTRAINT PK_RCRA_CME_FC_SBM PRIMARY KEY (CME_FAC_SUBM_ID) ENABLE;
--ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (HAZRD_WASTE_CME_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (EPA_HDLR_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------
--ALTER TABLE RCRA_CME_VIOL_ENFRC ADD CONSTRAINT PK_RCRA_CME_VL_ENF PRIMARY KEY (VIOL_ENFRC_ID) ENABLE;
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (VIOL_ENFRC_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

--ALTER TABLE RCRA_HD_SEC_WASTE_CODE ADD CONSTRAINT PK_RCR_HD_SE_WA_CO PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_SEC_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_SEC_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_NAICS
--------------------------------------------------------

--ALTER TABLE RCRA_HD_NAICS ADD CONSTRAINT PK_RCRA_HD_NAICS PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_NAICS MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_NAICS MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_NAICS MODIFY (NAICS_SEQ NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_CITATION
--------------------------------------------------------

--ALTER TABLE RCRA_CME_CITATION ADD CONSTRAINT PK_RCRA_CME_CTTN PRIMARY KEY (CITATION_ID) ENABLE;
--ALTER TABLE RCRA_CME_CITATION MODIFY (CITATION_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_CITATION MODIFY (VIOL_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_CITATION MODIFY (CITATION_NAME_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_MEDIA
--------------------------------------------------------

--ALTER TABLE RCRA_CME_MEDIA ADD CONSTRAINT PK_RCRA_CME_MEDIA PRIMARY KEY (MEDIA_ID) ENABLE;
--ALTER TABLE RCRA_CME_MEDIA MODIFY (MEDIA_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (MULTIMEDIA_CODE_OWNER NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MEDIA MODIFY (MULTIMEDIA_CODE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

--ALTER TABLE RCRA_CME_ENFRC_ACT ADD CONSTRAINT PK_RCR_CME_ENF_ACT PRIMARY KEY (ENFRC_ACT_ID) ENABLE;
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_AGN_LOC_NAME NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_IDEN NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_DATE NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_AGN_NAME NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_OWNEROP
--------------------------------------------------------

--ALTER TABLE RCRA_HD_OWNEROP ADD CONSTRAINT PK_RCRA_HD_OWNEROP PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_OWNEROP MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OWNEROP MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OWNEROP MODIFY (OWNER_OP_SEQ NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

--ALTER TABLE RCRA_HD_STATE_ACTIVITY ADD CONSTRAINT PK_RCRA_HD_STA_ACT PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (STATE_ACTIVITY_OWNER NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (STATE_ACTIVITY_TYPE NOT NULL ENABLE
--------------------------------------------------------
--  Constraints for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

--ALTER TABLE RCRA_HD_OTHER_ID ADD CONSTRAINT PK_RCRA_HD_OTHE_ID PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_OTHER_ID MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OTHER_ID MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_OTHER_ID MODIFY (OTHER_ID NOT NULL ENABLE););
--------------------------------------------------------
--  Constraints for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

--ALTER TABLE RCRA_HD_UNIVERSAL_WASTE ADD CONSTRAINT PK_RCRA_HD_UNI_WAS PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_UNIVERSAL_WASTE MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_UNIVERSAL_WASTE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT ADD CONSTRAINT PK_RCR_CM_SP_EN_PR PRIMARY KEY (SUPP_ENVR_PRJT_ID) ENABLE;
--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (SUPP_ENVR_PRJT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (SEP_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_MILESTONE
--------------------------------------------------------

--ALTER TABLE RCRA_CME_MILESTONE ADD CONSTRAINT PK_RCRA_CME_MLSTNE PRIMARY KEY (MILESTONE_ID) ENABLE;
--ALTER TABLE RCRA_CME_MILESTONE MODIFY (MILESTONE_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MILESTONE MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_MILESTONE MODIFY (MILESTONE_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

--ALTER TABLE RCRA_CME_CSNY_DATE ADD CONSTRAINT PK_RCR_CME_CSN_DTE PRIMARY KEY (CSNY_DATE_ID) ENABLE;
--ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (CSNY_DATE_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (ENFRC_ACT_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (SNY_DATE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_HAZRD_WASTE_CME_SUBM
--------------------------------------------------------

--ALTER TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM ADD CONSTRAINT PK_RC_CM_HZ_WS_CM PRIMARY KEY (HAZRD_WASTE_CME_SUBM_ID) ENABLE;
--ALTER TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM MODIFY (HAZRD_WASTE_CME_SUBM_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

--ALTER TABLE RCRA_HD_CERTIFICATION ADD CONSTRAINT PK_RCRA_HD_CERTIFI PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (FK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (CERT_SEQ NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL
--------------------------------------------------------

--ALTER TABLE RCRA_CME_EVAL ADD CONSTRAINT PK_RCRA_CME_EVAL PRIMARY KEY (EVAL_ID) ENABLE;
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_ACT_LOC NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_IDEN NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_START_DATE NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_RESP_AGN NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

--ALTER TABLE RCRA_HD_WASTE_CODE ADD CONSTRAINT PK_RCRA_HD_WAS_COD PRIMARY KEY (PK_GUID) ENABLE; 
--ALTER TABLE RCRA_HD_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

--ALTER TABLE RCRA_CME_EVAL_VIOL ADD CONSTRAINT PK_RCRA_CME_EVL_VL PRIMARY KEY (EVAL_VIOL_ID) ENABLE; 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (EVAL_VIOL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (EVAL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (VIOL_ACT_LOC NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_PNLTY
--------------------------------------------------------

--ALTER TABLE RCRA_CME_PNLTY ADD CONSTRAINT PK_RCRA_CME_PNLTY PRIMARY KEY (PNLTY_ID) ENABLE; 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (ENFRC_ACT_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_TYPE_OWNER NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_TYPE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_VIOL
--------------------------------------------------------

--ALTER TABLE RCRA_CME_VIOL ADD CONSTRAINT PK_RCRA_CME_VIOL PRIMARY KEY (VIOL_ID) ENABLE; 
--ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_ACT_LOC NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_VIOL MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

--ALTER TABLE RCRA_HD_ENV_PERMIT ADD CONSTRAINT PK_RCRA_HD_ENV_PER PRIMARY KEY (PK_GUID) ENABLE; 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (FK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (ENV_PERMIT_NUMBER NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (ENV_PERMIT_DESC NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_HANDLER
--------------------------------------------------------

--ALTER TABLE RCRA_HD_HANDLER ADD CONSTRAINT PK_RCRA_HD_HANDLER PRIMARY KEY (PK_GUID) ENABLE; 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (FK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (ACTIVITY_LOCATION NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (SOURCE_TYPE NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_HANDLER MODIFY (SEQ_NUMBER NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_RQST
--------------------------------------------------------

--ALTER TABLE RCRA_CME_RQST ADD CONSTRAINT PK_RCRA_CME_RQST PRIMARY KEY (RQST_ID) ENABLE; 
--ALTER TABLE RCRA_CME_RQST MODIFY (RQST_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_RQST MODIFY (EVAL_ID NOT NULL ENABLE); 
--ALTER TABLE RCRA_CME_RQST MODIFY (RQST_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY ADD CONSTRAINT PK_RCR_HD_SE_MA_AC PRIMARY KEY (PK_GUID) ENABLE; 
--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (PK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (FK_GUID NOT NULL ENABLE); 
--ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (HSM_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_PYMT
--------------------------------------------------------

--ALTER TABLE RCRA_CME_PYMT ADD CONSTRAINT PK_RCRA_CME_PYMT PRIMARY KEY (PYMT_ID) ENABLE; 
--ALTER TABLE RCRA_CME_PYMT MODIFY (PYMT_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_PYMT MODIFY (PNLTY_ID NOT NULL ENABLE);
--ALTER TABLE RCRA_CME_PYMT MODIFY (PYMT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_HBASIC
--------------------------------------------------------

--ALTER TABLE RCRA_HD_HBASIC ADD CONSTRAINT PK_RCRA_HD_HBASIC PRIMARY KEY (PK_GUID) ENABLE;
--ALTER TABLE RCRA_HD_HBASIC MODIFY (PK_GUID NOT NULL ENABLE);
--ALTER TABLE RCRA_HD_HBASIC MODIFY (HANDLER_ID NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_CERTIFI
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_CERTIFI ON RCRA_HD_CERTIFICATION (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_HD_HA_FK_GU
--------------------------------------------------------

  CREATE INDEX IX_RCR_HD_HA_FK_GU ON RCRA_HD_HANDLER (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_CM_PY_PN_ID
--------------------------------------------------------

  CREATE INDEX IX_RCR_CM_PY_PN_ID ON RCRA_CME_PYMT (PNLTY_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_SE_WA_CO
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_SE_WA_CO ON RCRA_HD_SEC_WASTE_CODE (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_EN_AC_CM
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_EN_AC_CM ON RCRA_CME_ENFRC_ACT (CME_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CME_EVL_CMM
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCR_CME_EVL_CMM ON RCRA_CME_EVAL_COMMIT (EVAL_COMMIT_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_HBASIC
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_HBASIC ON RCRA_HD_HBASIC (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_RQST
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_RQST ON RCRA_CME_RQST (RQST_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_VL_EN_EN
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_VL_EN_EN ON RCRA_CME_VIOL_ENFRC (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_EV_CM_FC
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_EV_CM_FC ON RCRA_CME_EVAL (CME_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_VL_ENF
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_VL_ENF ON RCRA_CME_VIOL_ENFRC (VIOL_ENFRC_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_HD_CE_FK_GU
--------------------------------------------------------

  CREATE INDEX IX_RCR_HD_CE_FK_GU ON RCRA_HD_CERTIFICATION (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_UNI_WAS
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_UNI_WAS ON RCRA_HD_UNIVERSAL_WASTE (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_NAICS
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_NAICS ON RCRA_HD_NAICS (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_VIOL
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_VIOL ON RCRA_CME_VIOL (VIOL_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_PYMT
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_PYMT ON RCRA_CME_PYMT (PYMT_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_OT_ID_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_OT_ID_FK ON RCRA_HD_OTHER_ID (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_EVAL
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_EVAL ON RCRA_CME_EVAL (EVAL_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_CS_DT_EN
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_CS_DT_EN ON RCRA_CME_CSNY_DATE (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_EV_CM_EV
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_EV_CM_EV ON RCRA_CME_EVAL_COMMIT (EVAL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_OWNEROP
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_OWNEROP ON RCRA_HD_OWNEROP (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_CTTN
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_CTTN ON RCRA_CME_CITATION (CITATION_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_ST_AC_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_ST_AC_FK ON RCRA_HD_STATE_ACTIVITY (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_FC_SBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_FC_SBM ON RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_SE_MA_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_SE_MA_AC ON RCRA_HD_SEC_MATERIAL_ACTIVITY (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_WAS_COD
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_WAS_COD ON RCRA_HD_WASTE_CODE (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RC_CM_HZ_WS_CM
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RC_CM_HZ_WS_CM ON RCRA_CME_HAZRD_WASTE_CME_SUBM (HAZRD_WASTE_CME_SUBM_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_CM_CT_VL_ID
--------------------------------------------------------

  CREATE INDEX IX_RCR_CM_CT_VL_ID ON RCRA_CME_CITATION (VIOL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_FC_SB_HZ
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_FC_SB_HZ ON RCRA_CME_FAC_SUBM (HAZRD_WASTE_CME_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_SP_EN_PR
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_SP_EN_PR ON RCRA_CME_SUPP_ENVR_PRJT (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_STA_ACT
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_STA_ACT ON RCRA_HD_STATE_ACTIVITY (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_PN_EN_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_PN_EN_AC ON RCRA_CME_PNLTY (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_EVL_VL
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_EVL_VL ON RCRA_CME_EVAL_VIOL (EVAL_VIOL_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CME_ENF_ACT
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCR_CME_ENF_ACT ON RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_EN_PE_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_EN_PE_FK ON RCRA_HD_ENV_PERMIT (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_HD_SE_MA_AC
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCR_HD_SE_MA_AC ON RCRA_HD_SEC_MATERIAL_ACTIVITY (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CME_CSN_DTE
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCR_CME_CSN_DTE ON RCRA_CME_CSNY_DATE (CSNY_DATE_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_HANDLER
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_HANDLER ON RCRA_HD_HANDLER (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_MEDIA
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_MEDIA ON RCRA_CME_MEDIA (MEDIA_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_ML_EN_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_ML_EN_AC ON RCRA_CME_MILESTONE (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_HD_SE_WA_CO
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCR_HD_SE_WA_CO ON RCRA_HD_SEC_WASTE_CODE (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_VL_CM_FC
--------------------------------------------------------

--  CREATE INDEX IX_RC_CM_VL_CM_FC ON RCRA_CME_VIOL (CME_FAC_SUBM_ID) 
--  ;

  CREATE INDEX IX_RC_CM_VL_CM_FC
    ON RCRA_CME_VIOL(CME_FAC_SUBM_ID, VIOL_ACT_LOC, AGN_WHICH_DTRM_VIOL, VIOL_SEQ_NUM)
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_OTHE_ID
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_OTHE_ID ON RCRA_HD_OTHER_ID (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_WA_CO_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_WA_CO_FK ON RCRA_HD_WASTE_CODE (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CM_SP_EN_PR
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCR_CM_SP_EN_PR ON RCRA_CME_SUPP_ENVR_PRJT (SUPP_ENVR_PRJT_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_PNLTY
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_PNLTY ON RCRA_CME_PNLTY (PNLTY_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_CM_RQ_EV_ID
--------------------------------------------------------

  CREATE INDEX IX_RCR_CM_RQ_EV_ID ON RCRA_CME_RQST (EVAL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_ENV_PER
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_HD_ENV_PER ON RCRA_HD_ENV_PERMIT (PK_GUID) 
--  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_MLSTNE
--------------------------------------------------------

--  CREATE UNIQUE INDEX PK_RCRA_CME_MLSTNE ON RCRA_CME_MILESTONE (MILESTONE_ID) 
--  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_UN_WA_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_UN_WA_FK ON RCRA_HD_UNIVERSAL_WASTE (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_HD_NA_FK_GU
--------------------------------------------------------

  CREATE INDEX IX_RCR_HD_NA_FK_GU ON RCRA_HD_NAICS (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_HD_OW_FK_GU
--------------------------------------------------------

  CREATE INDEX IX_RCR_HD_OW_FK_GU ON RCRA_HD_OWNEROP (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_EV_VL_EV
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_EV_VL_EV ON RCRA_CME_EVAL_VIOL (EVAL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_MD_EN_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_MD_EN_AC ON RCRA_CME_MEDIA (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_CITATION
--------------------------------------------------------

  ALTER TABLE RCRA_CME_CITATION ADD CONSTRAINT FK_RC_CM_CT_RC_CM FOREIGN KEY (VIOL_ID)
	  REFERENCES RCRA_CME_VIOL (VIOL_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  ALTER TABLE RCRA_CME_CSNY_DATE ADD CONSTRAINT FK_RC_CM_CS_DT_RC FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_ENFRC_ACT ADD CONSTRAINT FK_RC_CM_EN_AC_RC FOREIGN KEY (CME_FAC_SUBM_ID)
	  REFERENCES RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL ADD CONSTRAINT FK_RC_CM_EV_RC_CM FOREIGN KEY (CME_FAC_SUBM_ID)
	  REFERENCES RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL_COMMIT ADD CONSTRAINT FK_RC_CM_EV_CM_RC FOREIGN KEY (EVAL_ID)
	  REFERENCES RCRA_CME_EVAL (EVAL_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL_VIOL ADD CONSTRAINT FK_RC_CM_EV_VL_RC FOREIGN KEY (EVAL_ID)
	  REFERENCES RCRA_CME_EVAL (EVAL_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CME_FAC_SUBM ADD CONSTRAINT FK_RC_CM_FC_SB_RC FOREIGN KEY (HAZRD_WASTE_CME_SUBM_ID)
	  REFERENCES RCRA_CME_HAZRD_WASTE_CME_SUBM (HAZRD_WASTE_CME_SUBM_ID) ON DELETE CASCADE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_MEDIA
--------------------------------------------------------

  ALTER TABLE RCRA_CME_MEDIA ADD CONSTRAINT FK_RC_CM_MD_RC_CM FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  ALTER TABLE RCRA_CME_MILESTONE ADD CONSTRAINT FK_RC_CM_ML_RC_CM FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_PNLTY
--------------------------------------------------------

  ALTER TABLE RCRA_CME_PNLTY ADD CONSTRAINT FK_RC_CM_PN_RC_CM FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_PYMT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_PYMT ADD CONSTRAINT FK_RC_CM_PY_RC_CM FOREIGN KEY (PNLTY_ID)
	  REFERENCES RCRA_CME_PNLTY (PNLTY_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_RQST
--------------------------------------------------------

  ALTER TABLE RCRA_CME_RQST ADD CONSTRAINT FK_RC_CM_RQ_RC_CM FOREIGN KEY (EVAL_ID)
	  REFERENCES RCRA_CME_EVAL (EVAL_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT ADD CONSTRAINT FK_RC_CM_SP_EN_PR FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_VIOL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_VIOL ADD CONSTRAINT FK_RC_CM_VL_RC_CM FOREIGN KEY (CME_FAC_SUBM_ID)
	  REFERENCES RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  ALTER TABLE RCRA_CME_VIOL_ENFRC ADD CONSTRAINT FK_RC_CM_VL_EN_RC FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  ALTER TABLE RCRA_HD_CERTIFICATION ADD CONSTRAINT FK_RC_HD_CE_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  ALTER TABLE RCRA_HD_ENV_PERMIT ADD CONSTRAINT FK_RC_HD_EN_PE_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_HANDLER
--------------------------------------------------------

  ALTER TABLE RCRA_HD_HANDLER ADD CONSTRAINT FK_RC_HD_HA_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HBASIC (PK_GUID) ON DELETE CASCADE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_NAICS
--------------------------------------------------------

  ALTER TABLE RCRA_HD_NAICS ADD CONSTRAINT FK_RC_HD_NA_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  ALTER TABLE RCRA_HD_OTHER_ID ADD CONSTRAINT FK_RC_HD_OT_ID_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HBASIC (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  ALTER TABLE RCRA_HD_OWNEROP ADD CONSTRAINT FK_RC_HD_OW_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY ADD CONSTRAINT FK_RC_HD_SE_MA_AC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_SEC_WASTE_CODE ADD CONSTRAINT FK_RC_HD_SE_WA_CO FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_SEC_MATERIAL_ACTIVITY (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  ALTER TABLE RCRA_HD_STATE_ACTIVITY ADD CONSTRAINT FK_RC_HD_ST_AC_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_UNIVERSAL_WASTE ADD CONSTRAINT FK_RC_HD_UN_WA_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_WASTE_CODE ADD CONSTRAINT FK_RC_HD_WA_CO_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE;
