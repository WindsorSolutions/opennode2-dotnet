--------------------------------------------------------
--  File created - Wednesday-December-09-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table RCRA_CME_CITATION
--------------------------------------------------------

  CREATE TABLE RCRA_CME_CITATION 
   (	CITATION_ID VARCHAR2(40), 
	VIOL_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	CITATION_NAME_SEQ_NUM NUMBER(10,0), 
	CITATION_NAME VARCHAR2(128), 
	CITATION_NAME_OWNER VARCHAR2(255), 
	CITATION_NAME_TYPE VARCHAR2(255), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  CREATE TABLE RCRA_CME_CSNY_DATE 
   (	CSNY_DATE_ID VARCHAR2(40), 
	ENFRC_ACT_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	SNY_DATE DATE
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.CSNY_DATE_ID IS 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_CSNY_DATE.SNY_DATE IS 'Date of the SNY that the Action is Addressing (SNYDate)';
 
   COMMENT ON TABLE RCRA_CME_CSNY_DATE  IS 'Schema element: CSNYDateDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  CREATE TABLE RCRA_CME_ENFRC_ACT 
   (	ENFRC_ACT_ID VARCHAR2(40), 
	CME_FAC_SUBM_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	ENFRC_AGN_LOC_NAME VARCHAR2(128), 
	ENFRC_ACT_IDEN VARCHAR2(50), 
	ENFRC_ACT_DATE DATE, 
	ENFRC_AGN_NAME VARCHAR2(128), 
	ENFRC_DOCKET_NUM VARCHAR2(20), 
	ENFRC_ATTRY VARCHAR2(255), 
	CORCT_ACT_COMPT VARCHAR2(255), 
	CNST_AGMT_FINAL_ORDER_SEQ_NUM NUMBER(10,0), 
	APPEAL_INIT_DATE DATE, 
	APPEAL_RSLN_DATE DATE, 
	DISP_STAT_DATE DATE, 
	DISP_STAT_OWNER VARCHAR2(255), 
	DISP_STAT VARCHAR2(255), 
	ENFRC_OWNER VARCHAR2(255), 
	ENFRC_TYPE VARCHAR2(255), 
	ENFRC_RESP_PERSON_OWNER VARCHAR2(255), 
	ENFRC_RESP_PERSON_IDEN VARCHAR2(50), 
	ENFRC_RESP_SUBORG_OWNER VARCHAR2(255), 
	ENFRC_RESP_SUBORG VARCHAR2(255), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL
--------------------------------------------------------

  CREATE TABLE RCRA_CME_EVAL 
   (	EVAL_ID VARCHAR2(40), 
	CME_FAC_SUBM_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	EVAL_ACT_LOC VARCHAR2(255), 
	EVAL_IDEN VARCHAR2(50), 
	EVAL_START_DATE DATE, 
	EVAL_RESP_AGN VARCHAR2(255), 
	DAY_ZERO DATE, 
	FOUND_VIOL VARCHAR2(255), 
	CTZN_CPLT_IND VARCHAR2(50), 
	MULTIMEDIA_IND VARCHAR2(50), 
	SAMPL_IND VARCHAR2(50), 
	NOT_SUBTL_C_IND VARCHAR2(50), 
	EVAL_TYPE_OWNER VARCHAR2(255), 
	EVAL_TYPE VARCHAR2(255), 
	FOCUS_AREA_OWNER VARCHAR2(255), 
	FOCUS_AREA VARCHAR2(255), 
	EVAL_RESP_PERSON_IDEN_OWNER VARCHAR2(255), 
	EVAL_RESP_PERSON_IDEN VARCHAR2(50), 
	EVAL_RESP_SUBORG_OWNER VARCHAR2(255), 
	EVAL_RESP_SUBORG VARCHAR2(255), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  CREATE TABLE RCRA_CME_EVAL_COMMIT 
   (	EVAL_COMMIT_ID VARCHAR2(40), 
	EVAL_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	COMMIT_LEAD VARCHAR2(255), 
	COMMIT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.EVAL_COMMIT_ID IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.EVAL_ID IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.COMMIT_LEAD IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentLead)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_COMMIT.COMMIT_SEQ_NUM IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE RCRA_CME_EVAL_COMMIT  IS 'Schema element: EvaluationCommitmentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  CREATE TABLE RCRA_CME_EVAL_VIOL 
   (	EVAL_VIOL_ID VARCHAR2(40), 
	EVAL_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	VIOL_ACT_LOC VARCHAR2(255), 
	VIOL_SEQ_NUM NUMBER(10,0), 
	AGN_WHICH_DTRM_VIOL VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.EVAL_VIOL_ID IS 'Parent: Linking Data for Evaluation and Violation (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.EVAL_ID IS 'Parent: Linking Data for Evaluation and Violation (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.VIOL_ACT_LOC IS 'Parent: Linking Data for Evaluation and Violation (ViolationActivityLocation)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.VIOL_SEQ_NUM IS 'Parent: Linking Data for Evaluation and Violation (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_EVAL_VIOL.AGN_WHICH_DTRM_VIOL IS 'Parent: Linking Data for Evaluation and Violation (AgencyWhichDeterminedViolation)';
 
   COMMENT ON TABLE RCRA_CME_EVAL_VIOL  IS 'Schema element: EvaluationViolationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_CME_FAC_SUBM 
   (	CME_FAC_SUBM_ID VARCHAR2(40), 
	HAZRD_WASTE_CME_SUBM_ID VARCHAR2(40), 
	EPA_HDLR_ID VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_FAC_SUBM.CME_FAC_SUBM_ID IS 'Parent: This contains Hbasic Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_FAC_SUBM.HAZRD_WASTE_CME_SUBM_ID IS 'Parent: This contains Hbasic Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_FAC_SUBM.EPA_HDLR_ID IS 'Number that uniquely identifies the EPA handler. (EPAHandlerID)';
 
   COMMENT ON TABLE RCRA_CME_FAC_SUBM  IS 'Schema element: CMEFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_HAZRD_WASTE_CME_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM 
   (	HAZRD_WASTE_CME_SUBM_ID VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM  IS 'Schema element: HazardousWasteCMESubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_MEDIA
--------------------------------------------------------

  CREATE TABLE RCRA_CME_MEDIA 
   (	MEDIA_ID VARCHAR2(40), 
	ENFRC_ACT_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	MULTIMEDIA_CODE_OWNER VARCHAR2(255), 
	MULTIMEDIA_CODE VARCHAR2(50), 
	NOTES VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_MEDIA.MEDIA_ID IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.MULTIMEDIA_CODE_OWNER IS 'Indicates the agency that defines the multimedia code. (MultimediaCodeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.MULTIMEDIA_CODE IS 'Code which indicates the medium or program other than RCRA participating in the enforcement action. (MultimediaCode)';
 
   COMMENT ON COLUMN RCRA_CME_MEDIA.NOTES IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_MEDIA  IS 'Schema element: MediaDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  CREATE TABLE RCRA_CME_MILESTONE 
   (	MILESTONE_ID VARCHAR2(40), 
	ENFRC_ACT_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	MILESTONE_SEQ_NUM NUMBER(10,0), 
	TECH_RQMT_IDEN VARCHAR2(50), 
	TECH_RQMT_DESC VARCHAR2(255), 
	MILESTONE_SCHD_COMP_DATE DATE, 
	MILESTONE_ACTL_COMP_DATE DATE, 
	MILESTONE_DFLT_DATE DATE, 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_PNLTY
--------------------------------------------------------

  CREATE TABLE RCRA_CME_PNLTY 
   (	PNLTY_ID VARCHAR2(40), 
	ENFRC_ACT_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	PNLTY_TYPE_OWNER VARCHAR2(255), 
	PNLTY_TYPE VARCHAR2(255), 
	CASH_CIVIL_PNLTY_SOUGHT_AMOUNT NUMBER(14,6), 
	NOTES VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_PNLTY.PNLTY_ID IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.ENFRC_ACT_ID IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.PNLTY_TYPE_OWNER IS 'Indicates the agency that defines the penalty type (PenaltyTypeOwner)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.PNLTY_TYPE IS 'Code which indicates the type of penalty associated with the penalty amount. (PenaltyType)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT IS 'The dollar amount of any proposed cash civil penalty set forth in a Complaint/Proposed Order. (CashCivilPenaltySoughtAmount)';
 
   COMMENT ON COLUMN RCRA_CME_PNLTY.NOTES IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (Notes)';
 
   COMMENT ON TABLE RCRA_CME_PNLTY  IS 'Schema element: PenaltyDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_PYMT
--------------------------------------------------------

  CREATE TABLE RCRA_CME_PYMT 
   (	PYMT_ID VARCHAR2(40), 
	PNLTY_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	PYMT_SEQ_NUM NUMBER(10,0), 
	PYMT_DFLT_DATE DATE, 
	SCHD_PYMT_DATE DATE, 
	SCHD_PYMT_AMOUNT NUMBER(14,6), 
	ACTL_PYMT_DATE DATE, 
	ACTL_PAID_AMOUNT NUMBER(14,6), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_RQST
--------------------------------------------------------

  CREATE TABLE RCRA_CME_RQST 
   (	RQST_ID VARCHAR2(40), 
	EVAL_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	RQST_SEQ_NUM NUMBER(10,0), 
	DATE_OF_RQST DATE, 
	DATE_RESP_RCVD DATE, 
	RQST_AGN VARCHAR2(255), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  CREATE TABLE RCRA_CME_SUPP_ENVR_PRJT 
   (	SUPP_ENVR_PRJT_ID VARCHAR2(40), 
	ENFRC_ACT_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	SEP_SEQ_NUM NUMBER(10,0), 
	SEP_EXPND_AMOUNT NUMBER(14,6), 
	SEP_SCHD_COMP_DATE DATE, 
	SEP_ACTL_DATE DATE, 
	SEP_DFLT_DATE DATE, 
	SEP_CODE_OWNER VARCHAR2(255), 
	SEP_DESC_TXT VARCHAR2(255), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_VIOL
--------------------------------------------------------

  CREATE TABLE RCRA_CME_VIOL 
   (	VIOL_ID VARCHAR2(40), 
	CME_FAC_SUBM_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	VIOL_ACT_LOC VARCHAR2(255), 
	VIOL_SEQ_NUM NUMBER(10,0), 
	AGN_WHICH_DTRM_VIOL VARCHAR2(255), 
	VIOL_TYPE_OWNER VARCHAR2(255), 
	VIOL_TYPE VARCHAR2(255), 
	FORMER_CITATION_NAME VARCHAR2(128), 
	VIOL_DTRM_DATE DATE, 
	RTN_COMPL_ACTL_DATE DATE, 
	RTN_TO_COMPL_QUAL VARCHAR2(255), 
	VIOL_RESP_AGN VARCHAR2(255), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  CREATE TABLE RCRA_CME_VIOL_ENFRC 
   (	VIOL_ENFRC_ID VARCHAR2(40), 
	ENFRC_ACT_ID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	VIOL_SEQ_NUM NUMBER(10,0), 
	AGN_WHICH_DTRM_VIOL VARCHAR2(255), 
	RTN_COMPL_SCHD_DATE DATE
   ) ;
 

   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.VIOL_ENFRC_ID IS 'Parent: Linking Data for Violation and Enforcement (_PK)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.ENFRC_ACT_ID IS 'Parent: Linking Data for Violation and Enforcement (_FK)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.VIOL_SEQ_NUM IS 'Parent: Linking Data for Violation and Enforcement (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.AGN_WHICH_DTRM_VIOL IS 'Parent: Linking Data for Violation and Enforcement (AgencyWhichDeterminedViolation)';
 
   COMMENT ON COLUMN RCRA_CME_VIOL_ENFRC.RTN_COMPL_SCHD_DATE IS 'The calendar date, specified in the Compliance Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)';
 
   COMMENT ON TABLE RCRA_CME_VIOL_ENFRC  IS 'Schema element: ViolationEnforcementDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  CREATE TABLE RCRA_HD_CERTIFICATION 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	CERT_SEQ NUMBER(10,0), 
	CERT_SIGNED_DATE VARCHAR2(10), 
	CERT_TITLE VARCHAR2(45), 
	CERT_FIRST_NAME VARCHAR2(15), 
	CERT_MIDDLE_INITIAL CHAR(1), 
	CERT_LAST_NAME VARCHAR2(15)
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
--------------------------------------------------------
--  DDL for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  CREATE TABLE RCRA_HD_ENV_PERMIT 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	ENV_PERMIT_NUMBER VARCHAR2(13), 
	ENV_PERMIT_OWNER CHAR(2), 
	ENV_PERMIT_TYPE CHAR(1), 
	ENV_PERMIT_DESC VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.PK_GUID IS 'Parent: Information about environmental permits issued to the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.FK_GUID IS 'Parent: Information about environmental permits issued to the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_NUMBER IS 'Identification number of an effective environmental permit issued to the handler, or the number of a filed application for which an environmental permit has not yet been issued. (EnvironmentalPermitID)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_OWNER IS 'Indicates the agency that defines the other permit type. (EnvironmentalPermitOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_TYPE IS 'Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only. (EnvironmentalPermitTypeCode)';
 
   COMMENT ON COLUMN RCRA_HD_ENV_PERMIT.ENV_PERMIT_DESC IS 'Description of any permit type indicated as O (Other) in the Permit Type field. (EnvironmentalPermitDescription)';
 
   COMMENT ON TABLE RCRA_HD_ENV_PERMIT  IS 'Schema element: EnvironmentalPermitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_HANDLER
--------------------------------------------------------

  CREATE TABLE RCRA_HD_HANDLER 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	ACTIVITY_LOCATION CHAR(2), 
	SOURCE_TYPE CHAR(1), 
	SEQ_NUMBER NUMBER(10,0), 
	RECEIVE_DATE VARCHAR2(10), 
	HANDLER_NAME VARCHAR2(80), 
	ACKNOWLEDGE_DATE VARCHAR2(10), 
	NON_NOTIFIER CHAR(1), 
	TSD_DATE VARCHAR2(10), 
	OFF_SITE_RECEIPT CHAR(1), 
	ACCESSIBILITY CHAR(1), 
	COUNTY_CODE_OWNER CHAR(2), 
	COUNTY_CODE VARCHAR2(5), 
	NOTES VARCHAR2(2000), 
	ACKNOWLEDGE_FLAG CHAR(1), 
	LOCATION_STREET1 VARCHAR2(30), 
	LOCATION_STREET2 VARCHAR2(30), 
	LOCATION_CITY VARCHAR2(25), 
	LOCATION_STATE CHAR(2), 
	LOCATION_COUNTRY CHAR(2), 
	LOCATION_ZIP VARCHAR2(14), 
	MAIL_STREET1 VARCHAR2(30), 
	MAIL_STREET2 VARCHAR2(30), 
	MAIL_CITY VARCHAR2(25), 
	MAIL_STATE CHAR(2), 
	MAIL_COUNTRY CHAR(2), 
	MAIL_ZIP VARCHAR2(14), 
	CONTACT_FIRST_NAME VARCHAR2(15), 
	CONTACT_MIDDLE_INITIAL CHAR(1), 
	CONTACT_LAST_NAME VARCHAR2(15), 
	CONTACT_ORG_NAME VARCHAR2(80), 
	CONTACT_TITLE VARCHAR2(80), 
	CONTACT_EMAIL_ADDRESS VARCHAR2(240), 
	CONTACT_PHONE VARCHAR2(15), 
	CONTACT_PHONE_EXT VARCHAR2(6), 
	CONTACT_FAX VARCHAR2(15), 
	CONTACT_STREET1 VARCHAR2(30), 
	CONTACT_STREET2 VARCHAR2(30), 
	CONTACT_CITY VARCHAR2(25), 
	CONTACT_STATE CHAR(2), 
	CONTACT_COUNTRY CHAR(2), 
	CONTACT_ZIP VARCHAR2(14), 
	PCONTACT_FIRST_NAME VARCHAR2(15), 
	PCONTACT_MIDDLE_NAME CHAR(1), 
	PCONTACT_LAST_NAME VARCHAR2(15), 
	PCONTACT_ORG_NAME VARCHAR2(80), 
	PCONTACT_TITLE VARCHAR2(80), 
	PCONTACT_EMAIL_ADDRESS VARCHAR2(240), 
	PCONTACT_PHONE VARCHAR2(15), 
	PCONTACT_PHONE_EXT VARCHAR2(6), 
	PCONTACT_FAX VARCHAR2(15), 
	PCONTACT_STREET1 VARCHAR2(30), 
	PCONTACT_STREET2 VARCHAR2(30), 
	PCONTACT_CITY VARCHAR2(25), 
	PCONTACT_STATE CHAR(2), 
	PCONTACT_COUNTRY CHAR(2), 
	PCONTACT_ZIP VARCHAR2(14), 
	USED_OIL_BURNER CHAR(1), 
	USED_OIL_PROCESSOR CHAR(1), 
	USED_OIL_REFINER CHAR(1), 
	USED_OIL_MARKET_BURNER CHAR(1), 
	USED_OIL_SPEC_MARKETER CHAR(1), 
	USED_OIL_TRANSFER_FACILITY CHAR(1), 
	USED_OIL_TRANSPORTER CHAR(1), 
	LAND_TYPE CHAR(1), 
	STATE_DISTRICT_OWNER CHAR(2), 
	STATE_DISTRICT VARCHAR2(10), 
	IMPORTER_ACTIVITY CHAR(1), 
	MIXED_WASTE_GENERATOR CHAR(1), 
	RECYCLER_ACTIVITY CHAR(1), 
	TRANSPORTER_ACTIVITY CHAR(1), 
	TSD_ACTIVITY CHAR(1), 
	UNDERGROUND_INJECTION_ACTIVITY CHAR(1), 
	UNIVERSAL_WASTE_DEST_FACILITY CHAR(1), 
	ONSITE_BURNER_EXEMPTION CHAR(1), 
	FURNACE_EXEMPTION CHAR(1), 
	SHORT_TERM_GEN_IND VARCHAR2(50), 
	TRANSFER_FACILITY_IND VARCHAR2(50), 
	STATE_WASTE_GENERATOR_OWNER CHAR(2), 
	STATE_WASTE_GENERATOR CHAR(1), 
	FED_WASTE_GENERATOR_OWNER CHAR(2), 
	FED_WASTE_GENERATOR CHAR(1), 
	COLLEGE_IND VARCHAR2(50), 
	HOSPITAL_IND VARCHAR2(50), 
	NON_PROFIT_IND VARCHAR2(50), 
	WITHDRAWAL_IND VARCHAR2(50), 
	TRANS_CODE VARCHAR2(50), 
	NOTIFICATION_RSN_CODE VARCHAR2(50), 
	FINANCIAL_ASSURANCE_IND VARCHAR2(50)
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
 
   COMMENT ON COLUMN RCRA_HD_HANDLER.OFF_SITE_RECEIPT IS 'Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status). (OffsiteWasteReceiptCode)';
 
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
--------------------------------------------------------
--  DDL for Table RCRA_HD_HBASIC
--------------------------------------------------------

  CREATE TABLE RCRA_HD_HBASIC 
   (	PK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	HANDLER_ID VARCHAR2(12), 
	EXTRACT_FLAG CHAR(1), 
	FACILITY_IDENTIFIER VARCHAR2(12), 
	LAST_UPDATE_DATE DATE
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_HBASIC.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_HBASIC.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON COLUMN RCRA_HD_HBASIC.EXTRACT_FLAG IS 'Designates that data is available for extract for public use. (PublicUseExtractIndicator)';
 
   COMMENT ON COLUMN RCRA_HD_HBASIC.FACILITY_IDENTIFIER IS 'Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems. (FacilityRegistryID)';
 
   COMMENT ON TABLE RCRA_HD_HBASIC  IS 'Schema element: FacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_NAICS
--------------------------------------------------------

  CREATE TABLE RCRA_HD_NAICS 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	NAICS_SEQ NUMBER(10,0), 
	NAICS_OWNER CHAR(2), 
	NAICS_CODE VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_NAICS.PK_GUID IS 'Parent: North American Industry Classification Status codes reported for the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.FK_GUID IS 'Parent: North American Industry Classification Status codes reported for the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.NAICS_SEQ IS 'Sequence number for each NAICS code for the handler. (NAICSSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.NAICS_OWNER IS 'Indicates the agency that defines the NAICS Code. (NAICSOwnerCode)';
 
   COMMENT ON COLUMN RCRA_HD_NAICS.NAICS_CODE IS 'The North American Industry Classification System Code that identifies the business activities of the facility. (NAICSCode)';
 
   COMMENT ON TABLE RCRA_HD_NAICS  IS 'Schema element: NAICSIdentityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  CREATE TABLE RCRA_HD_OTHER_ID 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	OTHER_ID VARCHAR2(12), 
	RELATIONSHIP_OWNER CHAR(2), 
	RELATIONSHIP_TYPE CHAR(1), 
	SAME_FACILITY CHAR(1), 
	NOTES VARCHAR2(2000)
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
--------------------------------------------------------
--  DDL for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  CREATE TABLE RCRA_HD_OWNEROP 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	OWNER_OP_SEQ NUMBER(10,0), 
	OWNER_OP_IND CHAR(2), 
	OWNER_OP_TYPE CHAR(1), 
	DATE_BECAME_CURRENT VARCHAR2(10), 
	DATE_ENDED_CURRENT VARCHAR2(10), 
	NOTES VARCHAR2(240), 
	FIRST_NAME VARCHAR2(15), 
	MIDDLE_INITIAL CHAR(1), 
	LAST_NAME VARCHAR2(15), 
	ORG_NAME VARCHAR2(80), 
	TITLE VARCHAR2(80), 
	EMAIL_ADDRESS VARCHAR2(240), 
	PHONE VARCHAR2(15), 
	PHONE_EXT VARCHAR2(6), 
	FAX VARCHAR2(15), 
	STREET1 VARCHAR2(30), 
	STREET2 VARCHAR2(30), 
	CITY VARCHAR2(25), 
	STATE CHAR(2), 
	COUNTRY CHAR(2), 
	ZIP VARCHAR2(14)
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
--------------------------------------------------------
--  DDL for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  CREATE TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANS_CODE VARCHAR2(50), 
	HSM_SEQ_NUM VARCHAR2(20), 
	FAC_CODE_OWNER_NAME VARCHAR2(128), 
	FAC_TYPE_CODE VARCHAR2(50), 
	ESTIMATED_SHORT_TONS_QNTY NUMBER(10,0), 
	ACTL_SHORT_TONS_QNTY NUMBER(10,0), 
	LAND_BASED_UNIT_IND VARCHAR2(50)
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
--------------------------------------------------------
--  DDL for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  CREATE TABLE RCRA_HD_SEC_WASTE_CODE 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	WASTE_CODE_OWNER CHAR(2), 
	WASTE_CODE_TYPE VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.PK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.FK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.WASTE_CODE_OWNER IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_SEC_WASTE_CODE.WASTE_CODE_TYPE IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE RCRA_HD_SEC_WASTE_CODE  IS 'Schema element: SecondaryHandlerWasteCodeDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  CREATE TABLE RCRA_HD_STATE_ACTIVITY 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	STATE_ACTIVITY_OWNER CHAR(2), 
	STATE_ACTIVITY_TYPE VARCHAR2(5)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.PK_GUID IS 'Parent: State waste activity of the handler. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.FK_GUID IS 'Parent: State waste activity of the handler. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.STATE_ACTIVITY_OWNER IS 'Indicates the agency that defines the state activity type. (StateActivityOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_STATE_ACTIVITY.STATE_ACTIVITY_TYPE IS 'Code indicating the type of state activity. (StateActivityTypeCode)';
 
   COMMENT ON TABLE RCRA_HD_STATE_ACTIVITY  IS 'Schema element: StateActivityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  CREATE TABLE RCRA_HD_UNIVERSAL_WASTE 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
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
--------------------------------------------------------
--  DDL for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  CREATE TABLE RCRA_HD_WASTE_CODE 
   (	PK_GUID VARCHAR2(40), 
	FK_GUID VARCHAR2(40), 
	TRANSACTION_CODE CHAR(1), 
	WASTE_CODE_OWNER CHAR(2), 
	WASTE_CODE_TYPE VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.PK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.FK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.WASTE_CODE_OWNER IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN RCRA_HD_WASTE_CODE.WASTE_CODE_TYPE IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE RCRA_HD_WASTE_CODE  IS 'Schema element: HandlerWasteCodeDataType';

--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_CERTIFI
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_CERTIFI ON RCRA_HD_CERTIFICATION (PK_GUID) 
  ;
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

  CREATE UNIQUE INDEX PK_RCR_CME_EVL_CMM ON RCRA_CME_EVAL_COMMIT (EVAL_COMMIT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_HBASIC
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_HBASIC ON RCRA_HD_HBASIC (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_RQST
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_RQST ON RCRA_CME_RQST (RQST_ID) 
  ;
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

  CREATE UNIQUE INDEX PK_RCRA_CME_VL_ENF ON RCRA_CME_VIOL_ENFRC (VIOL_ENFRC_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_HD_CE_FK_GU
--------------------------------------------------------

  CREATE INDEX IX_RCR_HD_CE_FK_GU ON RCRA_HD_CERTIFICATION (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_UNI_WAS
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_UNI_WAS ON RCRA_HD_UNIVERSAL_WASTE (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_NAICS
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_NAICS ON RCRA_HD_NAICS (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_VIOL
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_VIOL ON RCRA_CME_VIOL (VIOL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_PYMT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_PYMT ON RCRA_CME_PYMT (PYMT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_OT_ID_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_OT_ID_FK ON RCRA_HD_OTHER_ID (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_EVAL
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_EVAL ON RCRA_CME_EVAL (EVAL_ID) 
  ;
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

  CREATE UNIQUE INDEX PK_RCRA_HD_OWNEROP ON RCRA_HD_OWNEROP (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_CTTN
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_CTTN ON RCRA_CME_CITATION (CITATION_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_ST_AC_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_ST_AC_FK ON RCRA_HD_STATE_ACTIVITY (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_FC_SBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_FC_SBM ON RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_SE_MA_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_SE_MA_AC ON RCRA_HD_SEC_MATERIAL_ACTIVITY (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_WAS_COD
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_WAS_COD ON RCRA_HD_WASTE_CODE (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RC_CM_HZ_WS_CM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RC_CM_HZ_WS_CM ON RCRA_CME_HAZRD_WASTE_CME_SUBM (HAZRD_WASTE_CME_SUBM_ID) 
  ;
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

  CREATE UNIQUE INDEX PK_RCRA_HD_STA_ACT ON RCRA_HD_STATE_ACTIVITY (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_PN_EN_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_PN_EN_AC ON RCRA_CME_PNLTY (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_EVL_VL
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_EVL_VL ON RCRA_CME_EVAL_VIOL (EVAL_VIOL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CME_ENF_ACT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_CME_ENF_ACT ON RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_EN_PE_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_EN_PE_FK ON RCRA_HD_ENV_PERMIT (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_HD_SE_MA_AC
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_HD_SE_MA_AC ON RCRA_HD_SEC_MATERIAL_ACTIVITY (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CME_CSN_DTE
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_CME_CSN_DTE ON RCRA_CME_CSNY_DATE (CSNY_DATE_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_HANDLER
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_HANDLER ON RCRA_HD_HANDLER (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_MEDIA
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_MEDIA ON RCRA_CME_MEDIA (MEDIA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_ML_EN_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CM_ML_EN_AC ON RCRA_CME_MILESTONE (ENFRC_ACT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_HD_SE_WA_CO
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_HD_SE_WA_CO ON RCRA_HD_SEC_WASTE_CODE (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CM_VL_CM_FC
--------------------------------------------------------

--  CREATE INDEX IX_RC_CM_VL_CM_FC ON RCRA_CME_VIOL (CME_FAC_SUBM_ID) 
--  ;
  CREATE INDEX IX_RC_CM_VL_CM_FC ON RCRA_CME_VIOL (CME_FAC_SUBM_ID, VIOL_ACT_LOC, AGN_WHICH_DTRM_VIOL, VIOL_SEQ_NUM)
  ;    
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_OTHE_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_OTHE_ID ON RCRA_HD_OTHER_ID (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_HD_WA_CO_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_HD_WA_CO_FK ON RCRA_HD_WASTE_CODE (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CM_SP_EN_PR
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_CM_SP_EN_PR ON RCRA_CME_SUPP_ENVR_PRJT (SUPP_ENVR_PRJT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_PNLTY
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_PNLTY ON RCRA_CME_PNLTY (PNLTY_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RCR_CM_RQ_EV_ID
--------------------------------------------------------

  CREATE INDEX IX_RCR_CM_RQ_EV_ID ON RCRA_CME_RQST (EVAL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_HD_ENV_PER
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_HD_ENV_PER ON RCRA_HD_ENV_PERMIT (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CME_MLSTNE
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CME_MLSTNE ON RCRA_CME_MILESTONE (MILESTONE_ID) 
  ;
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
--  Constraints for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL_COMMIT ADD CONSTRAINT PK_RCR_CME_EVL_CMM PRIMARY KEY (EVAL_COMMIT_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (EVAL_COMMIT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (EVAL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (COMMIT_LEAD NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_COMMIT MODIFY (COMMIT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CME_FAC_SUBM ADD CONSTRAINT PK_RCRA_CME_FC_SBM PRIMARY KEY (CME_FAC_SUBM_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (HAZRD_WASTE_CME_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_FAC_SUBM MODIFY (EPA_HDLR_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  ALTER TABLE RCRA_CME_VIOL_ENFRC ADD CONSTRAINT PK_RCRA_CME_VL_ENF PRIMARY KEY (VIOL_ENFRC_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (VIOL_ENFRC_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL_ENFRC MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_SEC_WASTE_CODE ADD CONSTRAINT PK_RCR_HD_SE_WA_CO PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_SEC_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_SEC_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_NAICS
--------------------------------------------------------

  ALTER TABLE RCRA_HD_NAICS ADD CONSTRAINT PK_RCRA_HD_NAICS PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_NAICS MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_NAICS MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_NAICS MODIFY (NAICS_SEQ NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_CITATION
--------------------------------------------------------

  ALTER TABLE RCRA_CME_CITATION ADD CONSTRAINT PK_RCRA_CME_CTTN PRIMARY KEY (CITATION_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_CITATION MODIFY (CITATION_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_CITATION MODIFY (VIOL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_CITATION MODIFY (CITATION_NAME_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_MEDIA
--------------------------------------------------------

  ALTER TABLE RCRA_CME_MEDIA ADD CONSTRAINT PK_RCRA_CME_MEDIA PRIMARY KEY (MEDIA_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_MEDIA MODIFY (MEDIA_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_MEDIA MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_MEDIA MODIFY (MULTIMEDIA_CODE_OWNER NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_MEDIA MODIFY (MULTIMEDIA_CODE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_ENFRC_ACT ADD CONSTRAINT PK_RCR_CME_ENF_ACT PRIMARY KEY (ENFRC_ACT_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_AGN_LOC_NAME NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_IDEN NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_ACT_DATE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_ENFRC_ACT MODIFY (ENFRC_AGN_NAME NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  ALTER TABLE RCRA_HD_OWNEROP ADD CONSTRAINT PK_RCRA_HD_OWNEROP PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_OWNEROP MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_OWNEROP MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_OWNEROP MODIFY (OWNER_OP_SEQ NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  ALTER TABLE RCRA_HD_STATE_ACTIVITY ADD CONSTRAINT PK_RCRA_HD_STA_ACT PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (STATE_ACTIVITY_OWNER NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_STATE_ACTIVITY MODIFY (STATE_ACTIVITY_TYPE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  ALTER TABLE RCRA_HD_OTHER_ID ADD CONSTRAINT PK_RCRA_HD_OTHE_ID PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_OTHER_ID MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_OTHER_ID MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_OTHER_ID MODIFY (OTHER_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_UNIVERSAL_WASTE ADD CONSTRAINT PK_RCRA_HD_UNI_WAS PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_UNIVERSAL_WASTE MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_UNIVERSAL_WASTE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT ADD CONSTRAINT PK_RCR_CM_SP_EN_PR PRIMARY KEY (SUPP_ENVR_PRJT_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (SUPP_ENVR_PRJT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY (SEP_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  ALTER TABLE RCRA_CME_MILESTONE ADD CONSTRAINT PK_RCRA_CME_MLSTNE PRIMARY KEY (MILESTONE_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_MILESTONE MODIFY (MILESTONE_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_MILESTONE MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_MILESTONE MODIFY (MILESTONE_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  ALTER TABLE RCRA_CME_CSNY_DATE ADD CONSTRAINT PK_RCR_CME_CSN_DTE PRIMARY KEY (CSNY_DATE_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (CSNY_DATE_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_CSNY_DATE MODIFY (SNY_DATE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_HAZRD_WASTE_CME_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM ADD CONSTRAINT PK_RC_CM_HZ_WS_CM PRIMARY KEY (HAZRD_WASTE_CME_SUBM_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_HAZRD_WASTE_CME_SUBM MODIFY (HAZRD_WASTE_CME_SUBM_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  ALTER TABLE RCRA_HD_CERTIFICATION ADD CONSTRAINT PK_RCRA_HD_CERTIFI PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_CERTIFICATION MODIFY (CERT_SEQ NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL ADD CONSTRAINT PK_RCRA_CME_EVAL PRIMARY KEY (EVAL_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_ACT_LOC NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_IDEN NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_START_DATE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL MODIFY (EVAL_RESP_AGN NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_WASTE_CODE ADD CONSTRAINT PK_RCRA_HD_WAS_COD PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL_VIOL ADD CONSTRAINT PK_RCRA_CME_EVL_VL PRIMARY KEY (EVAL_VIOL_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (EVAL_VIOL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (EVAL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (VIOL_ACT_LOC NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_EVAL_VIOL MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_PNLTY
--------------------------------------------------------

  ALTER TABLE RCRA_CME_PNLTY ADD CONSTRAINT PK_RCRA_CME_PNLTY PRIMARY KEY (PNLTY_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_PNLTY MODIFY (ENFRC_ACT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_TYPE_OWNER NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_PNLTY MODIFY (PNLTY_TYPE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_VIOL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_VIOL ADD CONSTRAINT PK_RCRA_CME_VIOL PRIMARY KEY (VIOL_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL MODIFY (CME_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_ACT_LOC NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL MODIFY (VIOL_SEQ_NUM NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_VIOL MODIFY (AGN_WHICH_DTRM_VIOL NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  ALTER TABLE RCRA_HD_ENV_PERMIT ADD CONSTRAINT PK_RCRA_HD_ENV_PER PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (ENV_PERMIT_NUMBER NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY (ENV_PERMIT_DESC NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_HANDLER
--------------------------------------------------------

  ALTER TABLE RCRA_HD_HANDLER ADD CONSTRAINT PK_RCRA_HD_HANDLER PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_HANDLER MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_HANDLER MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_HANDLER MODIFY (ACTIVITY_LOCATION NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_HANDLER MODIFY (SOURCE_TYPE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_HANDLER MODIFY (SEQ_NUMBER NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_RQST
--------------------------------------------------------

  ALTER TABLE RCRA_CME_RQST ADD CONSTRAINT PK_RCRA_CME_RQST PRIMARY KEY (RQST_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_RQST MODIFY (RQST_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_RQST MODIFY (EVAL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_RQST MODIFY (RQST_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY ADD CONSTRAINT PK_RCR_HD_SE_MA_AC PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (FK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY MODIFY (HSM_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_PYMT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_PYMT ADD CONSTRAINT PK_RCRA_CME_PYMT PRIMARY KEY (PYMT_ID) ENABLE;
 
  ALTER TABLE RCRA_CME_PYMT MODIFY (PYMT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_PYMT MODIFY (PNLTY_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CME_PYMT MODIFY (PYMT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_HBASIC
--------------------------------------------------------

  ALTER TABLE RCRA_HD_HBASIC ADD CONSTRAINT PK_RCRA_HD_HBASIC PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_HD_HBASIC MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_HD_HBASIC MODIFY (HANDLER_ID NOT NULL ENABLE);

--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_CITATION
--------------------------------------------------------

  ALTER TABLE RCRA_CME_CITATION ADD CONSTRAINT FK_RC_CM_CT_RC_CM FOREIGN KEY (VIOL_ID)
	  REFERENCES RCRA_CME_VIOL (VIOL_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  ALTER TABLE RCRA_CME_CSNY_DATE ADD CONSTRAINT FK_RC_CM_CS_DT_RC FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_ENFRC_ACT ADD CONSTRAINT FK_RC_CM_EN_AC_RC FOREIGN KEY (CME_FAC_SUBM_ID)
	  REFERENCES RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL ADD CONSTRAINT FK_RC_CM_EV_RC_CM FOREIGN KEY (CME_FAC_SUBM_ID)
	  REFERENCES RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL_COMMIT ADD CONSTRAINT FK_RC_CM_EV_CM_RC FOREIGN KEY (EVAL_ID)
	  REFERENCES RCRA_CME_EVAL (EVAL_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_EVAL_VIOL ADD CONSTRAINT FK_RC_CM_EV_VL_RC FOREIGN KEY (EVAL_ID)
	  REFERENCES RCRA_CME_EVAL (EVAL_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CME_FAC_SUBM ADD CONSTRAINT FK_RC_CM_FC_SB_RC FOREIGN KEY (HAZRD_WASTE_CME_SUBM_ID)
	  REFERENCES RCRA_CME_HAZRD_WASTE_CME_SUBM (HAZRD_WASTE_CME_SUBM_ID) ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_MEDIA
--------------------------------------------------------

  ALTER TABLE RCRA_CME_MEDIA ADD CONSTRAINT FK_RC_CM_MD_RC_CM FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  ALTER TABLE RCRA_CME_MILESTONE ADD CONSTRAINT FK_RC_CM_ML_RC_CM FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_PNLTY
--------------------------------------------------------

  ALTER TABLE RCRA_CME_PNLTY ADD CONSTRAINT FK_RC_CM_PN_RC_CM FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_PYMT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_PYMT ADD CONSTRAINT FK_RC_CM_PY_RC_CM FOREIGN KEY (PNLTY_ID)
	  REFERENCES RCRA_CME_PNLTY (PNLTY_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_RQST
--------------------------------------------------------

  ALTER TABLE RCRA_CME_RQST ADD CONSTRAINT FK_RC_CM_RQ_RC_CM FOREIGN KEY (EVAL_ID)
	  REFERENCES RCRA_CME_EVAL (EVAL_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT ADD CONSTRAINT FK_RC_CM_SP_EN_PR FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_VIOL
--------------------------------------------------------

  ALTER TABLE RCRA_CME_VIOL ADD CONSTRAINT FK_RC_CM_VL_RC_CM FOREIGN KEY (CME_FAC_SUBM_ID)
	  REFERENCES RCRA_CME_FAC_SUBM (CME_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  ALTER TABLE RCRA_CME_VIOL_ENFRC ADD CONSTRAINT FK_RC_CM_VL_EN_RC FOREIGN KEY (ENFRC_ACT_ID)
	  REFERENCES RCRA_CME_ENFRC_ACT (ENFRC_ACT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  ALTER TABLE RCRA_HD_CERTIFICATION ADD CONSTRAINT FK_RC_HD_CE_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  ALTER TABLE RCRA_HD_ENV_PERMIT ADD CONSTRAINT FK_RC_HD_EN_PE_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_HANDLER
--------------------------------------------------------

  ALTER TABLE RCRA_HD_HANDLER ADD CONSTRAINT FK_RC_HD_HA_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HBASIC (PK_GUID) ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_NAICS
--------------------------------------------------------

  ALTER TABLE RCRA_HD_NAICS ADD CONSTRAINT FK_RC_HD_NA_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  ALTER TABLE RCRA_HD_OTHER_ID ADD CONSTRAINT FK_RC_HD_OT_ID_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HBASIC (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  ALTER TABLE RCRA_HD_OWNEROP ADD CONSTRAINT FK_RC_HD_OW_RC_HD FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY ADD CONSTRAINT FK_RC_HD_SE_MA_AC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_SEC_WASTE_CODE ADD CONSTRAINT FK_RC_HD_SE_WA_CO FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_SEC_MATERIAL_ACTIVITY (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  ALTER TABLE RCRA_HD_STATE_ACTIVITY ADD CONSTRAINT FK_RC_HD_ST_AC_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_UNIVERSAL_WASTE ADD CONSTRAINT FK_RC_HD_UN_WA_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_HD_WASTE_CODE ADD CONSTRAINT FK_RC_HD_WA_CO_RC FOREIGN KEY (FK_GUID)
	  REFERENCES RCRA_HD_HANDLER (PK_GUID) ON DELETE CASCADE ENABLE;


--------------------------------------------------------
--  File created - Friday-January-22-2010   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table RCRA_CA_AREA
--------------------------------------------------------

  CREATE TABLE RCRA_CA_AREA 
   (  CORCT_ACT_AREA_ID VARCHAR2(40), 
  CORCT_ACT_FAC_SUBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  AREA_SEQ_NUM NUMBER(10,0), 
  FAC_WIDE_IND CHAR(1), 
  AREA_NAME VARCHAR2(40), 
  AIR_REL_IND CHAR(1), 
  GROUNDWATER_REL_IND CHAR(1), 
  SOIL_REL_IND CHAR(1), 
  SURFACE_WATER_REL_IND CHAR(1), 
  REGULATED_UNIT_IND CHAR(1), 
  EPA_RESP_PERSON_DATA_OWNER_CDE CHAR(2), 
  EPA_RESP_PERSON_ID VARCHAR2(5), 
  STA_RESP_PERSON_DATA_OWNER_CDE CHAR(2), 
  STA_RESP_PERSON_ID VARCHAR2(5), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_AREA.CORCT_ACT_AREA_ID IS 'Parent: A list of Correction Action Areas for a particluar Handler (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.CORCT_ACT_FAC_SUBM_ID IS 'Parent: A list of Correction Action Areas for a particluar Handler (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.AREA_SEQ_NUM IS 'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.FAC_WIDE_IND IS 'Indicates that the corrective action applies to the entire facility. (FacilityWideIndicator)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.AREA_NAME IS 'The name of the Corrective Action area. (AreaName)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.AIR_REL_IND IS 'Indicates that there has been a release to air (either within or beyond the facility boundary) from the unit/area. This may include releases of subsurface gas. (AirReleaseIndicator)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.GROUNDWATER_REL_IND IS 'Indicates that there has been a release to groundwater from the unit/area. (GroundwaterReleaseIndicator)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.SOIL_REL_IND IS 'Indicates that there has been a release to soil (either within or beyond the facility boundary) from the unit/area. This may include subsoil contamination beneath the unit/area. (SoilReleaseIndicator)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.SURFACE_WATER_REL_IND IS 'Indicates that there has been a release to surface water (either within or beyond the facility boundary) from the unit/area. (SurfaceWaterReleaseIndicator)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.REGULATED_UNIT_IND IS 'Indicates that the corrective action applies to a regulated unit. (RegulatedUnitIndicator)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.EPA_RESP_PERSON_DATA_OWNER_CDE IS 'Indicates the agency that defines the person identifier. (EPAResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.EPA_RESP_PERSON_ID IS 'The person currently responsible for the permit at the EPA level. (EPAResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.STA_RESP_PERSON_DATA_OWNER_CDE IS 'Indicates the agency that defines the person identifier. (StateResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.STA_RESP_PERSON_ID IS 'The state person currently responsible for overseeing the corrective action area. (StateResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_CA_AREA.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_CA_AREA  IS 'Schema element: CorrectiveActionAreaDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_AREA_REL_EVENT
--------------------------------------------------------

  CREATE TABLE RCRA_CA_AREA_REL_EVENT 
   (  CORCT_ACT_AREA_RELATED_EVNT_ID VARCHAR2(40), 
  CORCT_ACT_AREA_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  CORCT_ACT_EVENT_DATA_OWNER_CDE CHAR(2), 
  CORCT_ACT_EVENT_CODE VARCHAR2(7), 
  EVENT_AGN_CODE CHAR(1), 
  EVENT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.CORCT_ACT_AREA_RELATED_EVNT_ID IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.CORCT_ACT_AREA_ID IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.CORCT_ACT_EVENT_DATA_OWNER_CDE IS 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.CORCT_ACT_EVENT_CODE IS 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.EVENT_AGN_CODE IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN RCRA_CA_AREA_REL_EVENT.EVENT_SEQ_NUM IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON TABLE RCRA_CA_AREA_REL_EVENT  IS 'Schema element: CorrectiveActionAreaRelatedEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_AUTHORITY
--------------------------------------------------------

  CREATE TABLE RCRA_CA_AUTHORITY 
   (  CORCT_ACT_AUTHORITY_ID VARCHAR2(40), 
  CORCT_ACT_FAC_SUBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  AUTHORITY_DATA_OWNER_CODE CHAR(2), 
  AUTHORITY_TYPE_CODE CHAR(1), 
  AUTHORITY_AGN_CODE CHAR(1), 
  AUTHORITY_EFFC_DATE DATE, 
  ISSUE_DATE DATE, 
  END_DATE DATE, 
  ESTABLISHED_REPOSITORY_CODE CHAR(1), 
  RESP_LEAD_PROG_IDEN CHAR(1), 
  AUTHORITY_SUBORG_DATA_OWNR_CDE CHAR(2), 
  AUTHORITY_SUBORG_CODE VARCHAR2(10), 
  RESP_PERSON_DATA_OWNER_CODE CHAR(2), 
  RESP_PERSON_ID VARCHAR2(5), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_AUTHORITY.CORCT_ACT_AUTHORITY_ID IS 'Parent: A list of Correction Action Authorities for a particluar Handler (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.CORCT_ACT_FAC_SUBM_ID IS 'Parent: A list of Correction Action Authorities for a particluar Handler (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.AUTHORITY_DATA_OWNER_CODE IS 'Indicates the agency that defines the authority. (AuthorityDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.AUTHORITY_TYPE_CODE IS 'A code used to indicate whether a permit, administrative order, or other authority has been issued to implement the corrective action process. (AuthorityTypeCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.AUTHORITY_AGN_CODE IS 'Agency responsible for the Authority. (AuthorityAgencyCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.AUTHORITY_EFFC_DATE IS 'Date that the authority became effective. (AuthorityEffectiveDate)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.ISSUE_DATE IS 'Date the authorized agency official signs the order, permit, or permit modification. (IssueDate)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.END_DATE IS 'The date when the corrective action authority is revoked or ended. (EndDate)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.ESTABLISHED_REPOSITORY_CODE IS 'The action by which the Director requires the owner/operator to establish and maintain an information repository at a location near the facility for the purpose of making accessible to interested parties documents, reports, and other public information relevant to public understanding of the activities, findings, and plans for such corrective action initiatives. (EstablishedRepositoryCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.RESP_LEAD_PROG_IDEN IS 'Code indicating the program in which the organization establishes the applicable guidance that the authority should be issued. (ResponsibleLeadProgramIdentifier)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.AUTHORITY_SUBORG_DATA_OWNR_CDE IS 'Authority responsible suborganization owner. (AuthoritySuborganizationDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.AUTHORITY_SUBORG_CODE IS 'Authority responsible suborganization. (AuthoritySuborganizationCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.RESP_PERSON_DATA_OWNER_CODE IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.RESP_PERSON_ID IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_CA_AUTHORITY.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_CA_AUTHORITY  IS 'Schema element: CorrectiveActionAuthorityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_AUTH_REL_EVENT
--------------------------------------------------------

  CREATE TABLE RCRA_CA_AUTH_REL_EVENT 
   (  CRCT_ACT_AUTHRTY_RELTD_EVNT_ID VARCHAR2(40), 
  CORCT_ACT_AUTHORITY_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  CORCT_ACT_EVENT_DATA_OWNER_CDE CHAR(2), 
  CORCT_ACT_EVENT_CODE VARCHAR2(7), 
  EVENT_AGN_CODE CHAR(1), 
  EVENT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.CRCT_ACT_AUTHRTY_RELTD_EVNT_ID IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.CORCT_ACT_AUTHORITY_ID IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.CORCT_ACT_EVENT_DATA_OWNER_CDE IS 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.CORCT_ACT_EVENT_CODE IS 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.EVENT_AGN_CODE IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN RCRA_CA_AUTH_REL_EVENT.EVENT_SEQ_NUM IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON TABLE RCRA_CA_AUTH_REL_EVENT  IS 'Schema element: CorrectiveActionAuthorityRelatedEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_EVENT
--------------------------------------------------------

  CREATE TABLE RCRA_CA_EVENT 
   (  CORCT_ACT_EVENT_ID VARCHAR2(40), 
  CORCT_ACT_FAC_SUBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  CORCT_ACT_EVENT_DATA_OWNER_CDE CHAR(2), 
  CORCT_ACT_EVENT_CODE VARCHAR2(7), 
  EVENT_AGN_CODE CHAR(1), 
  EVENT_SEQ_NUM NUMBER(10,0), 
  ACTL_DATE DATE, 
  ORIGINAL_SCHEDULE_DATE DATE, 
  NEW_SCHEDULE_DATE DATE, 
  EVENT_SUBORG_DATA_OWNER_CODE CHAR(2), 
  EVENT_SUBORG_CODE VARCHAR2(10), 
  RESP_PERSON_DATA_OWNER_CODE CHAR(2), 
  RESP_PERSON_ID VARCHAR2(5), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_EVENT.CORCT_ACT_EVENT_ID IS 'Parent: A list of Correction Action Events for a particluar Handler (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.CORCT_ACT_FAC_SUBM_ID IS 'Parent: A list of Correction Action Events for a particluar Handler (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.CORCT_ACT_EVENT_DATA_OWNER_CDE IS 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.CORCT_ACT_EVENT_CODE IS 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.EVENT_AGN_CODE IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.EVENT_SEQ_NUM IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.ACTL_DATE IS 'Date on which actual completion of an event occurs. (ActualDate)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.ORIGINAL_SCHEDULE_DATE IS 'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.NEW_SCHEDULE_DATE IS 'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.EVENT_SUBORG_DATA_OWNER_CODE IS 'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.EVENT_SUBORG_CODE IS 'Event responsible suborganization. (EventSuborganizationCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.RESP_PERSON_DATA_OWNER_CODE IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.RESP_PERSON_ID IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_CA_EVENT  IS 'Schema element: CorrectiveActionEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_EVENT_COMMITMENT
--------------------------------------------------------

  CREATE TABLE RCRA_CA_EVENT_COMMITMENT 
   (  EVENT_EVENT_COMMIT_ID VARCHAR2(40), 
  CORCT_ACT_EVENT_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  COMMIT_LEAD CHAR(2), 
  COMMIT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_EVENT_COMMITMENT.EVENT_EVENT_COMMIT_ID IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT_COMMITMENT.CORCT_ACT_EVENT_ID IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT_COMMITMENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT_COMMITMENT.COMMIT_LEAD IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)';
 
   COMMENT ON COLUMN RCRA_CA_EVENT_COMMITMENT.COMMIT_SEQ_NUM IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE RCRA_CA_EVENT_COMMITMENT  IS 'Schema element: EventEventCommitmentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_CA_FAC_SUBM 
   (  CORCT_ACT_FAC_SUBM_ID VARCHAR2(40), 
  PK_GUID VARCHAR2(40), 
  HANDLER_ID VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_FAC_SUBM.CORCT_ACT_FAC_SUBM_ID IS 'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_FAC_SUBM.PK_GUID IS 'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_FAC_SUBM.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE RCRA_CA_FAC_SUBM  IS 'Schema element: CorrectiveActionFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_REL_PERMIT_UNIT
--------------------------------------------------------

  CREATE TABLE RCRA_CA_REL_PERMIT_UNIT 
   (  CORCT_ACT_RELATED_PRMIT_UNT_ID VARCHAR2(40), 
  CORCT_ACT_AREA_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  PERMIT_UNIT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_REL_PERMIT_UNIT.CORCT_ACT_RELATED_PRMIT_UNT_ID IS 'Parent: A permitted unit related to a corrective action area. (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_REL_PERMIT_UNIT.CORCT_ACT_AREA_ID IS 'Parent: A permitted unit related to a corrective action area. (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_REL_PERMIT_UNIT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_REL_PERMIT_UNIT.PERMIT_UNIT_SEQ_NUM IS 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)';
 
   COMMENT ON TABLE RCRA_CA_REL_PERMIT_UNIT  IS 'Schema element: CorrectiveActionRelatedPermitUnitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_STATUTORY_CITATION
--------------------------------------------------------

  CREATE TABLE RCRA_CA_STATUTORY_CITATION 
   (  CORCT_ACT_STATUTORY_CITTION_ID VARCHAR2(40), 
  CORCT_ACT_AUTHORITY_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  STATUTORY_CITTION_DTA_OWNR_CDE CHAR(2), 
  STATUTORY_CITATION_IDEN CHAR(1)
   ) ;
 

   COMMENT ON COLUMN RCRA_CA_STATUTORY_CITATION.CORCT_ACT_STATUTORY_CITTION_ID IS 'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_PK)';
 
   COMMENT ON COLUMN RCRA_CA_STATUTORY_CITATION.CORCT_ACT_AUTHORITY_ID IS 'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_FK)';
 
   COMMENT ON COLUMN RCRA_CA_STATUTORY_CITATION.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_CA_STATUTORY_CITATION.STATUTORY_CITTION_DTA_OWNR_CDE IS 'Orgnaization responsible for the Statutory Citation (use two-digit postal code) (StatutoryCitationDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_CA_STATUTORY_CITATION.STATUTORY_CITATION_IDEN IS 'Identifier that identifies the statutory authority under which the corrective action event occured (StatutoryCitationIdentifier)';
 
   COMMENT ON TABLE RCRA_CA_STATUTORY_CITATION  IS 'Schema element: CorrectiveActionStatutoryCitationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_CA_SUBM 
   (  PK_GUID VARCHAR2(40), 
  LAST_UPDATE_DATE DATE
   ) ;
 

   COMMENT ON TABLE RCRA_CA_SUBM  IS 'Schema element: HazardousWasteCorrectiveActionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_COST_EST
--------------------------------------------------------

  CREATE TABLE RCRA_FA_COST_EST 
   (  COST_ESTIMATE_ID VARCHAR2(40), 
  FINANCIAL_ASSURANCE_FAC_SBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  COST_ESTIMATE_TYPE_CODE CHAR(1), 
  COST_ESTIMATE_AGN_CODE CHAR(1), 
  COST_ESTIMATE_SEQ_NUM NUMBER(10,0), 
  RESP_PERSON_DATA_OWNER_CODE CHAR(2), 
  RESP_PERSON_ID VARCHAR2(5), 
  COST_ESTIMATE_AMOUNT NUMBER(14,6), 
  COST_ESTIMATE_DATE DATE, 
  COST_ESTIMATE_RSN_CODE CHAR(1), 
  AREA_UNIT_NOTES_TXT VARCHAR2(240), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_ID IS 'Parent: Estimates of the Financial liability costs associated with a given Handler. (_PK)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.FINANCIAL_ASSURANCE_FAC_SBM_ID IS 'Parent: Estimates of the Financial liability costs associated with a given Handler. (_FK)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_TYPE_CODE IS 'Indicates what type of Financial Assurance is Required. (CostEstimateTypeCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_AGN_CODE IS 'Code indicating the agency responsible for overseeing the review of the cost estimate. (CostEstimateAgencyCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_SEQ_NUM IS 'Unique number that identifies the cost estimate. (CostEstimateSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.RESP_PERSON_DATA_OWNER_CODE IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.RESP_PERSON_ID IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_AMOUNT IS 'The dollar amount of the cost estimate for a given financial assurance type. (CostEstimateAmount)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_DATE IS 'The date when the cost estimate for a given financial assurance type was submitted, adjusted, approved, or required to be in place. (CostEstimateDate)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.COST_ESTIMATE_RSN_CODE IS 'The reason the cost estimate for a financial assurance type is being reported. (CostEstimateReasonCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.AREA_UNIT_NOTES_TXT IS 'Notes regarding the corrective action area or permit unit that this cost estimate applies. (AreaUnitNotesText)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_FA_COST_EST  IS 'Schema element: CostEstimateDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_COST_EST_REL_MECHANISM
--------------------------------------------------------

  CREATE TABLE RCRA_FA_COST_EST_REL_MECHANISM 
   (  CST_ESTIMTE_RELTED_MECHNISM_ID VARCHAR2(40), 
  COST_ESTIMATE_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  MECHANISM_AGN_CODE CHAR(1), 
  MECHANISM_SEQ_NUM NUMBER(10,0), 
  MECHANISM_DETAIL_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.CST_ESTIMTE_RELTED_MECHNISM_ID IS 'Parent: Linking Data for Cost Estimates and Related Mechanisms (_PK)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.COST_ESTIMATE_ID IS 'Parent: Linking Data for Cost Estimates and Related Mechanisms (_FK)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.MECHANISM_AGN_CODE IS 'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.MECHANISM_SEQ_NUM IS 'Unique numerical identier for the mechanism. (MechanismSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_FA_COST_EST_REL_MECHANISM.MECHANISM_DETAIL_SEQ_NUM IS 'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)';
 
   COMMENT ON TABLE RCRA_FA_COST_EST_REL_MECHANISM  IS 'Schema element: CostEstimateRelatedMechanismDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_FA_FAC_SUBM 
   (  FINANCIAL_ASSURANCE_FAC_SBM_ID VARCHAR2(40), 
  PK_GUID VARCHAR2(40), 
  HANDLER_ID VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN RCRA_FA_FAC_SUBM.FINANCIAL_ASSURANCE_FAC_SBM_ID IS 'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_PK)';
 
   COMMENT ON COLUMN RCRA_FA_FAC_SUBM.PK_GUID IS 'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_FK)';
 
   COMMENT ON COLUMN RCRA_FA_FAC_SUBM.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE RCRA_FA_FAC_SUBM  IS 'Schema element: FinancialAssuranceFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_MECHANISM
--------------------------------------------------------

  CREATE TABLE RCRA_FA_MECHANISM 
   (  MECHANISM_ID VARCHAR2(40), 
  FINANCIAL_ASSURANCE_FAC_SBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  MECHANISM_AGN_CODE CHAR(1), 
  MECHANISM_SEQ_NUM NUMBER(10,0), 
  MECHANISM_TYPE_DATA_OWNER_CODE CHAR(2), 
  MECHANISM_TYPE_CODE CHAR(1), 
  PROVIDER_TXT VARCHAR2(80), 
  PROVIDER_FULL_CONTACT_NAME VARCHAR2(33), 
  TELE_NUM_TXT VARCHAR2(15), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_FA_MECHANISM.MECHANISM_ID IS 'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_PK)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.FINANCIAL_ASSURANCE_FAC_SBM_ID IS 'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_FK)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.MECHANISM_AGN_CODE IS 'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.MECHANISM_SEQ_NUM IS 'Unique numerical identier for the mechanism. (MechanismSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.MECHANISM_TYPE_DATA_OWNER_CODE IS 'Indicates the agency that defined the mechanism type. (MechanismTypeDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.MECHANISM_TYPE_CODE IS 'The type of mechanism that addresses the cost estimate. (MechanismTypeCode)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.PROVIDER_TXT IS 'The name of the financial institution with which the financial assurance mechanism is held, such as a bank (letter of credit) or a surety (surety bond); also identifies a facility (financial test), or a guarantor (corporate guarantee). (ProviderText)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.PROVIDER_FULL_CONTACT_NAME IS 'Contact Name of the provider. (ProviderFullContactName)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.TELE_NUM_TXT IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_FA_MECHANISM  IS 'Schema element: MechanismDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_MECHANISM_DETAIL
--------------------------------------------------------

  CREATE TABLE RCRA_FA_MECHANISM_DETAIL 
   (  MECHANISM_DETAIL_ID VARCHAR2(40), 
  MECHANISM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  MECHANISM_DETAIL_SEQ_NUM NUMBER(10,0), 
  MECHANISM_IDEN_TXT VARCHAR2(40), 
  FACE_VAL_AMOUNT NUMBER(14,6), 
  EFFC_DATE DATE, 
  EXPIRATION_DATE DATE, 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.MECHANISM_DETAIL_ID IS 'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_PK)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.MECHANISM_ID IS 'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_FK)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.MECHANISM_DETAIL_SEQ_NUM IS 'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.MECHANISM_IDEN_TXT IS 'The number assigned to the mechanism, such as a bond number or insurance policy number. (MechanismIdentificationText)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.FACE_VAL_AMOUNT IS 'The total dollar value of the financial assurance mechanism. (FaceValueAmount)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.EFFC_DATE IS 'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.EXPIRATION_DATE IS 'The date the instrument terminates, such as the end of the term of an insurance policy. (ExpirationDate)';
 
   COMMENT ON COLUMN RCRA_FA_MECHANISM_DETAIL.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_FA_MECHANISM_DETAIL  IS 'Schema element: MechanismDetailDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_FA_SUBM 
   (  PK_GUID VARCHAR2(40), 
  LAST_UPDATE_DATE DATE
   ) ;
 

   COMMENT ON TABLE RCRA_FA_SUBM  IS 'Schema element: FinancialAssuranceSubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_GIS_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_GIS_FAC_SUBM 
   (  GIS_FAC_SUBM_ID VARCHAR2(40), 
  PK_GUID VARCHAR2(40), 
  HANDLER_ID VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN RCRA_GIS_FAC_SUBM.GIS_FAC_SUBM_ID IS 'Parent: Supplies all of the relevant GIS Data for a given Handler (_PK)';
 
   COMMENT ON COLUMN RCRA_GIS_FAC_SUBM.PK_GUID IS 'Parent: Supplies all of the relevant GIS Data for a given Handler (_FK)';
 
   COMMENT ON COLUMN RCRA_GIS_FAC_SUBM.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE RCRA_GIS_FAC_SUBM  IS 'Schema element: GISFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_GIS_GEO_INFORMATION
--------------------------------------------------------

  CREATE TABLE RCRA_GIS_GEO_INFORMATION 
   (  GEO_INFO_ID VARCHAR2(40), 
  GIS_FAC_SUBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  GEO_INFO_OWNER CHAR(2), 
  GEO_INFO_SEQ_NUM NUMBER(10,0), 
  PERMIT_UNIT_SEQ_NUM NUMBER(10,0), 
  AREA_SEQ_NUM NUMBER(10,0), 
  LOC_COMM_TXT VARCHAR2(2000), 
  AREA_ACREAGE_MEAS NUMBER(14,6), 
  AREA_MEAS_SRC_DATA_OWNER_CODE CHAR(2), 
  AREA_MEAS_SRC_CODE VARCHAR2(8), 
  AREA_MEAS_DATE DATE, 
  DATA_COLL_DATE DATE, 
  HORZ_ACC_MEAS NUMBER(10,0), 
  SRC_MAP_SCALE_NUM NUMBER(10,0), 
  COORD_DATA_SRC_DATA_OWNER_CODE CHAR(2), 
  COORD_DATA_SRC_CODE VARCHAR2(3), 
  GEO_REF_PT_DATA_OWNER_CODE CHAR(2), 
  GEO_REF_PT_CODE VARCHAR2(3), 
  GEOM_TYPE_DATA_OWNER_CODE CHAR(2), 
  GEOM_TYPE_CODE VARCHAR2(3), 
  HORZ_COLL_METH_DATA_OWNER_CODE CHAR(2), 
  HORZ_COLL_METH_CODE VARCHAR2(3), 
  HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE CHAR(2), 
  HORZ_COORD_REF_SYS_DATUM_CODE VARCHAR2(3), 
  VERF_METH_DATA_OWNER_CODE CHAR(2), 
  VERF_METH_CODE VARCHAR2(3), 
  LATITUDE NUMBER(19,14), 
  LONGITUDE NUMBER(19,14), 
  ELEVATION NUMBER(19,14)
   ) ;
 

   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEO_INFO_ID IS 'Parent: Used to define the geographic coordinates of the Handler. (_PK)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GIS_FAC_SUBM_ID IS 'Parent: Used to define the geographic coordinates of the Handler. (_FK)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEO_INFO_OWNER IS 'Owner of Geographic Information.  Should match state code (i.e. KS). (GeographicInformationOwner)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEO_INFO_SEQ_NUM IS 'Unique identifier for the geographic information. (GeographicInformationSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.PERMIT_UNIT_SEQ_NUM IS 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.AREA_SEQ_NUM IS 'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.LOC_COMM_TXT IS 'The text that provides additional informaiton about the geographic coordinates. (LocationCommentsText)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.AREA_ACREAGE_MEAS IS 'The number of acres associated with the handler or area. (AreaAcreageMeasure)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.AREA_MEAS_SRC_DATA_OWNER_CODE IS 'Indicates the agency that defined the AreaMeasureSource. (AreaMeasureSourceDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.AREA_MEAS_SRC_CODE IS 'The source of information used to determine the number of acres associated with the handler or area. (AreaMeasureSourceCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.AREA_MEAS_DATE IS 'The date acreage information for the handler or area was collected. (AreaMeasureDate)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.DATA_COLL_DATE IS 'The calender date when data were collected (DataCollectionDate)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.HORZ_ACC_MEAS IS 'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.SRC_MAP_SCALE_NUM IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumeric)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.COORD_DATA_SRC_DATA_OWNER_CODE IS 'The owner of the code.  If provided, it should be HQ. (CoordinateDataSourceDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.COORD_DATA_SRC_CODE IS 'The code that represents the party responsible for proiding the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEO_REF_PT_DATA_OWNER_CODE IS 'The owner of the code.  If provided, it should be HQ. (GeographicReferencePointDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEO_REF_PT_CODE IS 'The code that represents the place for which the geographic codes were established (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEOM_TYPE_DATA_OWNER_CODE IS 'The owner of the code.  If provided, it should be HQ. (GeometricTypeDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.GEOM_TYPE_CODE IS 'The code that represents the geometric entity represented by one point or a sequence of points (GeometricTypeCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.HORZ_COLL_METH_DATA_OWNER_CODE IS 'The owner of the code.  If provided, it should be HQ. (HorizontalCollectionMethodDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.HORZ_COLL_METH_CODE IS 'The code that represents the method used to deterimine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE IS 'The owner of the code.  If provided, it should be HQ. (HorizontalCoordinateReferenceSystemDatumDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.HORZ_COORD_REF_SYS_DATUM_CODE IS 'The code that represents the datum used in determining latitude and longitude coordinates (HorizontalCoordinateReferenceSystemDatumCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.VERF_METH_DATA_OWNER_CODE IS 'The owner of the code.  If provided, it should be HQ. (VerificationMethodDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.VERF_METH_CODE IS 'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.LATITUDE IS 'Parent: Geometry property element of a GeoRSS GML instance (Latitude)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.LONGITUDE IS 'Parent: Geometry property element of a GeoRSS GML instance (Longitude)';
 
   COMMENT ON COLUMN RCRA_GIS_GEO_INFORMATION.ELEVATION IS 'Parent: Geometry property element of a GeoRSS GML instance (Elevation)';
 
   COMMENT ON TABLE RCRA_GIS_GEO_INFORMATION  IS 'Schema element: GeographicInformationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_GIS_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_GIS_SUBM 
   (  PK_GUID VARCHAR2(40), 
  LAST_UPDATE_DATE DATE
   ) ;
 

   COMMENT ON TABLE RCRA_GIS_SUBM  IS 'Schema element: GeographicInformationSubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_EVENT
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_EVENT 
   (  PERMIT_EVENT_ID VARCHAR2(40), 
  PERMIT_SERIES_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  PERMIT_EVENT_DATA_OWNER_CODE CHAR(2), 
  PERMIT_EVENT_CODE VARCHAR2(7), 
  EVENT_AGN_CODE CHAR(1), 
  EVENT_SEQ_NUM NUMBER(10,0), 
  ACTL_DATE DATE, 
  ORIGINAL_SCHEDULE_DATE DATE, 
  NEW_SCHEDULE_DATE DATE, 
  RESP_PERSON_DATA_OWNER_CODE CHAR(2), 
  RESP_PERSON_ID VARCHAR2(5), 
  EVENT_SUBORG_DATA_OWNER_CODE CHAR(2), 
  EVENT_SUBORG_CODE VARCHAR2(10), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_EVENT.PERMIT_EVENT_ID IS 'Parent: Permit event Data (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.PERMIT_SERIES_ID IS 'Parent: Permit event Data (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.PERMIT_EVENT_DATA_OWNER_CODE IS 'Indicates the agency that defines the event. (PermitEventDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.PERMIT_EVENT_CODE IS 'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.EVENT_AGN_CODE IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.EVENT_SEQ_NUM IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.ACTL_DATE IS 'Date on which actual completion of an event occurs. (ActualDate)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.ORIGINAL_SCHEDULE_DATE IS 'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.NEW_SCHEDULE_DATE IS 'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.RESP_PERSON_DATA_OWNER_CODE IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.RESP_PERSON_ID IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.EVENT_SUBORG_DATA_OWNER_CODE IS 'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.EVENT_SUBORG_CODE IS 'Event responsible suborganization. (EventSuborganizationCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_PRM_EVENT  IS 'Schema element: PermitEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_EVENT_COMMITMENT
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_EVENT_COMMITMENT 
   (  PERMIT_EVENT_COMMIT_ID VARCHAR2(40), 
  PERMIT_EVENT_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  COMMIT_LEAD CHAR(2), 
  COMMIT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_EVENT_COMMITMENT.PERMIT_EVENT_COMMIT_ID IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT_COMMITMENT.PERMIT_EVENT_ID IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT_COMMITMENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT_COMMITMENT.COMMIT_LEAD IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)';
 
   COMMENT ON COLUMN RCRA_PRM_EVENT_COMMITMENT.COMMIT_SEQ_NUM IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE RCRA_PRM_EVENT_COMMITMENT  IS 'Schema element: PermitEventCommitmentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_FAC_SUBM 
   (  PERMIT_FAC_SUBM_ID VARCHAR2(40), 
  PK_GUID VARCHAR2(40), 
  HANDLER_ID VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_FAC_SUBM.PERMIT_FAC_SUBM_ID IS 'Parent: 
  This is the root element for this flow XML Schema.
   (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_FAC_SUBM.PK_GUID IS 'Parent: 
  This is the root element for this flow XML Schema.
   (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_FAC_SUBM.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE RCRA_PRM_FAC_SUBM  IS 'Schema element: PermitFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_RELATED_EVENT
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_RELATED_EVENT 
   (  PERMIT_RELATED_EVENT_ID VARCHAR2(40), 
  PERMIT_UNIT_DETAIL_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  ACT_LOC_CODE CHAR(2), 
  PERMIT_SERIES_SEQ_NUM NUMBER(10,0), 
  PERMIT_EVENT_DATA_OWNER_CODE CHAR(2), 
  PERMIT_EVENT_CODE VARCHAR2(7), 
  EVENT_AGN_CODE CHAR(1), 
  EVENT_SEQ_NUM NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.PERMIT_RELATED_EVENT_ID IS 'Parent: Linking Data for Permitted Units and Permitting Events (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.PERMIT_UNIT_DETAIL_ID IS 'Parent: Linking Data for Permitted Units and Permitting Events (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.ACT_LOC_CODE IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.PERMIT_SERIES_SEQ_NUM IS 'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.PERMIT_EVENT_DATA_OWNER_CODE IS 'Indicates the agency that defines the event. (PermitEventDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.PERMIT_EVENT_CODE IS 'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.EVENT_AGN_CODE IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN RCRA_PRM_RELATED_EVENT.EVENT_SEQ_NUM IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON TABLE RCRA_PRM_RELATED_EVENT  IS 'Schema element: PermitRelatedEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_SERIES
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_SERIES 
   (  PERMIT_SERIES_ID VARCHAR2(40), 
  PERMIT_FAC_SUBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  PERMIT_SERIES_SEQ_NUM NUMBER(10,0), 
  PERMIT_SERIES_NAME VARCHAR2(40), 
  RESP_PERSON_DATA_OWNER_CODE CHAR(2), 
  RESP_PERSON_ID VARCHAR2(5), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_SERIES.PERMIT_SERIES_ID IS 'Parent: Permit series Data (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.PERMIT_FAC_SUBM_ID IS 'Parent: Permit series Data (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.PERMIT_SERIES_SEQ_NUM IS 'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.PERMIT_SERIES_NAME IS 'Name or number assigned by the implementing agency. (PermitSeriesName)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.RESP_PERSON_DATA_OWNER_CODE IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.RESP_PERSON_ID IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN RCRA_PRM_SERIES.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_PRM_SERIES  IS 'Schema element: PermitSeriesDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_SUBM
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_SUBM 
   (  PK_GUID VARCHAR2(40), 
  LAST_UPDATE_DATE DATE
   ) ;
 

   COMMENT ON TABLE RCRA_PRM_SUBM  IS 'Schema element: HazardousWastePermitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_UNIT
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_UNIT 
   (  PERMIT_UNIT_ID VARCHAR2(40), 
  PERMIT_FAC_SUBM_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  PERMIT_UNIT_SEQ_NUM NUMBER(10,0), 
  PERMIT_UNIT_NAME VARCHAR2(40), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_UNIT.PERMIT_UNIT_ID IS 'Parent: Permit Unit Data (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT.PERMIT_FAC_SUBM_ID IS 'Parent: Permit Unit Data (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT.PERMIT_UNIT_SEQ_NUM IS 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT.PERMIT_UNIT_NAME IS 'Name or number assigned by the implementing agency to identify a process unit group. (PermitUnitName)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_PRM_UNIT  IS 'Schema element: PermitUnitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_UNIT_DETAIL
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_UNIT_DETAIL 
   (  PERMIT_UNIT_DETAIL_ID VARCHAR2(40), 
  PERMIT_UNIT_ID VARCHAR2(40), 
  TRANS_CODE CHAR(1), 
  PERMIT_UNIT_DETAIL_SEQ_NUM NUMBER(10,0), 
  PROC_UNIT_DATA_OWNER_CODE CHAR(2), 
  PROC_UNIT_CODE VARCHAR2(3), 
  PERMIT_STAT_EFFC_DATE DATE, 
  PERMIT_UNIT_CAP_QNTY NUMBER(14,6), 
  CAP_TYPE_CODE CHAR(1), 
  COMMER_STAT_CODE CHAR(1), 
  LEGAL_OPER_STAT_DATA_OWNER_CDE CHAR(2), 
  LEGAL_OPER_STAT_CODE VARCHAR2(4), 
  MEASUREMENT_UNIT_DATA_OWNR_CDE CHAR(2), 
  MEASUREMENT_UNIT_CODE CHAR(1), 
  NUM_OF_UNITS_COUNT NUMBER(10,0), 
  STANDARD_PERMIT_IND CHAR(1), 
  SUPP_INFO_TXT VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_DETAIL_ID IS 'Parent: Permit Unit Detail Data (_PK)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_ID IS 'Parent: Permit Unit Detail Data (_FK)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.TRANS_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_DETAIL_SEQ_NUM IS 'System-generated value used to uniquely identify a process unit detail. (PermitUnitDetailSequenceNumber)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PROC_UNIT_DATA_OWNER_CODE IS 'Indicates the agency that defines the process code. (ProcessUnitDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PROC_UNIT_CODE IS 'Code specifying the unit group''s current waste treatment, storage, or disposal process. (ProcessUnitCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PERMIT_STAT_EFFC_DATE IS 'Date specifying when the other information in the process detail data record (i.e., process, capacity, and operating and legal status) became effective. (PermitStatusEffectiveDate)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_CAP_QNTY IS 'Permitted capacity of the unit (PermitUnitCapacityQuantity)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.CAP_TYPE_CODE IS 'Code indicating the type of capacity. (CapacityTypeCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.COMMER_STAT_CODE IS 'Code indicating that the facility, whether public or private, accepts hazardous waste for the process unit group from a third party. (CommercialStatusCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.LEGAL_OPER_STAT_DATA_OWNER_CDE IS 'Indicates the agency that defines the legal/operating status code. (LegalOperatingStatusDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.LEGAL_OPER_STAT_CODE IS 'Code used to indicate programmatic (operating and legal status) conditions that reflect RCRA program activity requirements of a unit. (LegalOperatingStatusCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.MEASUREMENT_UNIT_DATA_OWNR_CDE IS 'Indicates the agency that defines the unit of measure. (MeasurementUnitDataOwnerCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.MEASUREMENT_UNIT_CODE IS 'Indicates the unit of measure. (MeasurementUnitCode)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.NUM_OF_UNITS_COUNT IS 'Total number of units of the same process grouped together to form a single process unit group. (NumberOfUnitsCount)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.STANDARD_PERMIT_IND IS 'Indicates whether or not the permit is a standardized permit. (StandardPermitIndicator)';
 
   COMMENT ON COLUMN RCRA_PRM_UNIT_DETAIL.SUPP_INFO_TXT IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE RCRA_PRM_UNIT_DETAIL  IS 'Schema element: PermitUnitDetailDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_WASTE_CODE
--------------------------------------------------------

  CREATE TABLE RCRA_PRM_WASTE_CODE 
   (  PK_GUID VARCHAR2(40), 
  FK_GUID VARCHAR2(40), 
  TRANSACTION_CODE CHAR(1), 
  WASTE_CODE_OWNER CHAR(2), 
  WASTE_CODE_TYPE VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN RCRA_PRM_WASTE_CODE.PK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (PkGuid)';
 
   COMMENT ON COLUMN RCRA_PRM_WASTE_CODE.FK_GUID IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (FkGuid)';
 
   COMMENT ON COLUMN RCRA_PRM_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN RCRA_PRM_WASTE_CODE.WASTE_CODE_OWNER IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN RCRA_PRM_WASTE_CODE.WASTE_CODE_TYPE IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE RCRA_PRM_WASTE_CODE  IS 'Schema element: PermitHandlerWasteCodeDataType';

---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_AREA
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_AREA

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_AREA
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_AREA_REL_EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_AREA_REL_EVENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_AREA_REL_EVENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_AUTHORITY
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_AUTHORITY

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_AUTHORITY
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_AUTH_REL_EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_AUTH_REL_EVENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_AUTH_REL_EVENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_EVENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_EVENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_EVENT_COMMITMENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_EVENT_COMMITMENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_EVENT_COMMITMENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_FAC_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_FAC_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_FAC_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_REL_PERMIT_UNIT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_REL_PERMIT_UNIT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_REL_PERMIT_UNIT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_STATUTORY_CITATION
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_STATUTORY_CITATION

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_STATUTORY_CITATION
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_CA_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_CA_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_CA_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_FA_COST_EST
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_FA_COST_EST

---------------------------------------------------
--   END DATA FOR TABLE RCRA_FA_COST_EST
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_FA_COST_EST_REL_MECHANISM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_FA_COST_EST_REL_MECHANISM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_FA_COST_EST_REL_MECHANISM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_FA_FAC_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_FA_FAC_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_FA_FAC_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_FA_MECHANISM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_FA_MECHANISM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_FA_MECHANISM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_FA_MECHANISM_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_FA_MECHANISM_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE RCRA_FA_MECHANISM_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_FA_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_FA_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_FA_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_GIS_FAC_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_GIS_FAC_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_GIS_FAC_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_GIS_GEO_INFORMATION
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_GIS_GEO_INFORMATION

---------------------------------------------------
--   END DATA FOR TABLE RCRA_GIS_GEO_INFORMATION
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_GIS_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_GIS_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_GIS_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_EVENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_EVENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_EVENT_COMMITMENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_EVENT_COMMITMENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_EVENT_COMMITMENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_FAC_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_FAC_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_FAC_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_RELATED_EVENT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_RELATED_EVENT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_RELATED_EVENT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_SERIES
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_SERIES

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_SERIES
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_SUBM
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_SUBM

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_SUBM
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_UNIT
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_UNIT

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_UNIT
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_UNIT_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_UNIT_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_UNIT_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE RCRA_PRM_WASTE_CODE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into RCRA_PRM_WASTE_CODE

---------------------------------------------------
--   END DATA FOR TABLE RCRA_PRM_WASTE_CODE
---------------------------------------------------

--------------------------------------------------------
--  DDL for Index IX_RC_FA_MC_FN_AS
--------------------------------------------------------

  CREATE INDEX IX_RC_FA_MC_FN_AS ON RCRA_FA_MECHANISM (FINANCIAL_ASSURANCE_FAC_SBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_ST_CT_CR
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_ST_CT_CR ON RCRA_CA_STATUTORY_CITATION (CORCT_ACT_AUTHORITY_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_PRM_UNIT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_PRM_UNIT ON RCRA_PRM_UNIT (PERMIT_UNIT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_SUBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_SUBM ON RCRA_CA_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_PRM_EVENT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_PRM_EVENT ON RCRA_PRM_EVENT (PERMIT_EVENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_AUTHRTY
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_AUTHRTY ON RCRA_CA_AUTHORITY (CORCT_ACT_AUTHORITY_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_FA_SUBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_FA_SUBM ON RCRA_FA_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_SR_PR_FC
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_SR_PR_FC ON RCRA_PRM_SERIES (PERMIT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_AREA
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_AREA ON RCRA_CA_AREA (CORCT_ACT_AREA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_AT_RL_EV
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_AT_RL_EV ON RCRA_CA_AUTH_REL_EVENT (CORCT_ACT_AUTHORITY_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_FA_CST_EST
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_FA_CST_EST ON RCRA_FA_COST_EST (COST_ESTIMATE_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_FA_CS_ES_RL
--------------------------------------------------------

  CREATE INDEX IX_RC_FA_CS_ES_RL ON RCRA_FA_COST_EST_REL_MECHANISM (COST_ESTIMATE_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_PRM_FC_SBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_PRM_FC_SBM ON RCRA_PRM_FAC_SUBM (PERMIT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_EV_CM_PR
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_EV_CM_PR ON RCRA_PRM_EVENT_COMMITMENT (PERMIT_EVENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_EVN_CMM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_EVN_CMM ON RCRA_CA_EVENT_COMMITMENT (EVENT_EVENT_COMMIT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_GS_GO_INFR
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_GS_GO_INFR ON RCRA_GIS_GEO_INFORMATION (GEO_INFO_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_GS_GO_IN_GS
--------------------------------------------------------

  CREATE INDEX IX_RC_GS_GO_IN_GS ON RCRA_GIS_GEO_INFORMATION (GIS_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CA_AR_RL_EV
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_CA_AR_RL_EV ON RCRA_CA_AREA_REL_EVENT (CORCT_ACT_AREA_RELATED_EVNT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_AR_CR_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_AR_CR_AC ON RCRA_CA_AREA (CORCT_ACT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_FA_CS_ES_FN
--------------------------------------------------------

  CREATE INDEX IX_RC_FA_CS_ES_FN ON RCRA_FA_COST_EST (FINANCIAL_ASSURANCE_FAC_SBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_GIS_FC_SBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_GIS_FC_SBM ON RCRA_GIS_FAC_SUBM (GIS_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_FA_MC_DT_MC
--------------------------------------------------------

  CREATE INDEX IX_RC_FA_MC_DT_MC ON RCRA_FA_MECHANISM_DETAIL (MECHANISM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_FC_SB_PK
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_FC_SB_PK ON RCRA_PRM_FAC_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_UN_PR_FC
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_UN_PR_FC ON RCRA_PRM_UNIT (PERMIT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_RL_PR_UN
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_RL_PR_UN ON RCRA_CA_REL_PERMIT_UNIT (CORCT_ACT_AREA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_EV_CR_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_EV_CR_AC ON RCRA_CA_EVENT (CORCT_ACT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RC_FA_CS_ES_RL
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RC_FA_CS_ES_RL ON RCRA_FA_COST_EST_REL_MECHANISM (CST_ESTIMTE_RELTED_MECHNISM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_PRM_RLT_EVN
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_PRM_RLT_EVN ON RCRA_PRM_RELATED_EVENT (PERMIT_RELATED_EVENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_PRM_SERIES
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_PRM_SERIES ON RCRA_PRM_SERIES (PERMIT_SERIES_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_PRM_UNT_DTL
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_PRM_UNT_DTL ON RCRA_PRM_UNIT_DETAIL (PERMIT_UNIT_DETAIL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_AR_RL_EV
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_AR_RL_EV ON RCRA_CA_AREA_REL_EVENT (CORCT_ACT_AREA_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_STT_CTT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_STT_CTT ON RCRA_CA_STATUTORY_CITATION (CORCT_ACT_STATUTORY_CITTION_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_EV_PR_SR
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_EV_PR_SR ON RCRA_PRM_EVENT (PERMIT_SERIES_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CA_RL_PR_UN
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_CA_RL_PR_UN ON RCRA_CA_REL_PERMIT_UNIT (CORCT_ACT_RELATED_PRMIT_UNT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_FC_SB_PK
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_FC_SB_PK ON RCRA_CA_FAC_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_FAC_SBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_FAC_SBM ON RCRA_CA_FAC_SUBM (CORCT_ACT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_GS_FC_SB_PK
--------------------------------------------------------

  CREATE INDEX IX_RC_GS_FC_SB_PK ON RCRA_GIS_FAC_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_WS_CD_FK
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_WS_CD_FK ON RCRA_PRM_WASTE_CODE (FK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_CA_EVENT
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_CA_EVENT ON RCRA_CA_EVENT (CORCT_ACT_EVENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_AT_CR_AC
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_AT_CR_AC ON RCRA_CA_AUTHORITY (CORCT_ACT_FAC_SUBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_FA_FAC_SBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_FA_FAC_SBM ON RCRA_FA_FAC_SUBM (FINANCIAL_ASSURANCE_FAC_SBM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_CA_EV_CM_CR
--------------------------------------------------------

  CREATE INDEX IX_RC_CA_EV_CM_CR ON RCRA_CA_EVENT_COMMITMENT (CORCT_ACT_EVENT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_CA_AT_RL_EV
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_CA_AT_RL_EV ON RCRA_CA_AUTH_REL_EVENT (CRCT_ACT_AUTHRTY_RELTD_EVNT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_UN_DT_PR
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_UN_DT_PR ON RCRA_PRM_UNIT_DETAIL (PERMIT_UNIT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_GIS_SUBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_GIS_SUBM ON RCRA_GIS_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_FA_MCHNISM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_FA_MCHNISM ON RCRA_FA_MECHANISM (MECHANISM_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_PRM_EVN_CMM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_PRM_EVN_CMM ON RCRA_PRM_EVENT_COMMITMENT (PERMIT_EVENT_COMMIT_ID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_PRM_SUBM
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_PRM_SUBM ON RCRA_PRM_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_PR_RL_EV_PR
--------------------------------------------------------

  CREATE INDEX IX_RC_PR_RL_EV_PR ON RCRA_PRM_RELATED_EVENT (PERMIT_UNIT_DETAIL_ID) 
  ;
--------------------------------------------------------
--  DDL for Index IX_RC_FA_FC_SB_PK
--------------------------------------------------------

  CREATE INDEX IX_RC_FA_FC_SB_PK ON RCRA_FA_FAC_SUBM (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCR_PRM_WST_CDE
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCR_PRM_WST_CDE ON RCRA_PRM_WASTE_CODE (PK_GUID) 
  ;
--------------------------------------------------------
--  DDL for Index PK_RCRA_FA_MCH_DTL
--------------------------------------------------------

  CREATE UNIQUE INDEX PK_RCRA_FA_MCH_DTL ON RCRA_FA_MECHANISM_DETAIL (MECHANISM_DETAIL_ID) 
  ;
  
--------------------------------------------------------
--  Constraints for Table RCRA_CA_STATUTORY_CITATION
--------------------------------------------------------

  ALTER TABLE RCRA_CA_STATUTORY_CITATION ADD CONSTRAINT PK_RCRA_CA_STT_CTT PRIMARY KEY (CORCT_ACT_STATUTORY_CITTION_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_STATUTORY_CITATION MODIFY (CORCT_ACT_STATUTORY_CITTION_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_STATUTORY_CITATION MODIFY (CORCT_ACT_AUTHORITY_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_STATUTORY_CITATION MODIFY (STATUTORY_CITTION_DTA_OWNR_CDE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_STATUTORY_CITATION MODIFY (STATUTORY_CITATION_IDEN NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_SUBM ADD CONSTRAINT PK_RCRA_FA_SUBM PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_FA_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_EVENT ADD CONSTRAINT PK_RCRA_CA_EVENT PRIMARY KEY (CORCT_ACT_EVENT_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (CORCT_ACT_EVENT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (CORCT_ACT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (CORCT_ACT_EVENT_DATA_OWNER_CDE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (CORCT_ACT_EVENT_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (EVENT_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT MODIFY (EVENT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_GIS_GEO_INFORMATION
--------------------------------------------------------

  ALTER TABLE RCRA_GIS_GEO_INFORMATION ADD CONSTRAINT PK_RCRA_GS_GO_INFR PRIMARY KEY (GEO_INFO_ID) ENABLE;
 
  ALTER TABLE RCRA_GIS_GEO_INFORMATION MODIFY (GEO_INFO_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_GIS_GEO_INFORMATION MODIFY (GIS_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_GIS_GEO_INFORMATION MODIFY (GEO_INFO_OWNER NOT NULL ENABLE);
 
  ALTER TABLE RCRA_GIS_GEO_INFORMATION MODIFY (GEO_INFO_SEQ_NUM NOT NULL ENABLE);
 
  ALTER TABLE RCRA_GIS_GEO_INFORMATION MODIFY (DATA_COLL_DATE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AREA_REL_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AREA_REL_EVENT ADD CONSTRAINT PK_RCR_CA_AR_RL_EV PRIMARY KEY (CORCT_ACT_AREA_RELATED_EVNT_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (CORCT_ACT_AREA_RELATED_EVNT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (CORCT_ACT_AREA_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (CORCT_ACT_EVENT_DATA_OWNER_CDE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (CORCT_ACT_EVENT_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (EVENT_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA_REL_EVENT MODIFY (EVENT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_FAC_SUBM ADD CONSTRAINT PK_RCRA_FA_FAC_SBM PRIMARY KEY (FINANCIAL_ASSURANCE_FAC_SBM_ID) ENABLE;
 
  ALTER TABLE RCRA_FA_FAC_SUBM MODIFY (FINANCIAL_ASSURANCE_FAC_SBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_FAC_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_FAC_SUBM MODIFY (HANDLER_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AUTH_REL_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AUTH_REL_EVENT ADD CONSTRAINT PK_RCR_CA_AT_RL_EV PRIMARY KEY (CRCT_ACT_AUTHRTY_RELTD_EVNT_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (CRCT_ACT_AUTHRTY_RELTD_EVNT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (CORCT_ACT_AUTHORITY_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (CORCT_ACT_EVENT_DATA_OWNER_CDE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (CORCT_ACT_EVENT_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (EVENT_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTH_REL_EVENT MODIFY (EVENT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_FAC_SUBM ADD CONSTRAINT PK_RCRA_PRM_FC_SBM PRIMARY KEY (PERMIT_FAC_SUBM_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_FAC_SUBM MODIFY (PERMIT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_FAC_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_FAC_SUBM MODIFY (HANDLER_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_REL_PERMIT_UNIT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_REL_PERMIT_UNIT ADD CONSTRAINT PK_RCR_CA_RL_PR_UN PRIMARY KEY (CORCT_ACT_RELATED_PRMIT_UNT_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_REL_PERMIT_UNIT MODIFY (CORCT_ACT_RELATED_PRMIT_UNT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_REL_PERMIT_UNIT MODIFY (CORCT_ACT_AREA_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_REL_PERMIT_UNIT MODIFY (PERMIT_UNIT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CA_FAC_SUBM ADD CONSTRAINT PK_RCRA_CA_FAC_SBM PRIMARY KEY (CORCT_ACT_FAC_SUBM_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_FAC_SUBM MODIFY (CORCT_ACT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_FAC_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_FAC_SUBM MODIFY (HANDLER_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_RELATED_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_RELATED_EVENT ADD CONSTRAINT PK_RCR_PRM_RLT_EVN PRIMARY KEY (PERMIT_RELATED_EVENT_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (PERMIT_RELATED_EVENT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (PERMIT_UNIT_DETAIL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (PERMIT_SERIES_SEQ_NUM NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (PERMIT_EVENT_DATA_OWNER_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (PERMIT_EVENT_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (EVENT_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_RELATED_EVENT MODIFY (EVENT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_MECHANISM_DETAIL
--------------------------------------------------------

  ALTER TABLE RCRA_FA_MECHANISM_DETAIL ADD CONSTRAINT PK_RCRA_FA_MCH_DTL PRIMARY KEY (MECHANISM_DETAIL_ID) ENABLE;
 
  ALTER TABLE RCRA_FA_MECHANISM_DETAIL MODIFY (MECHANISM_DETAIL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_MECHANISM_DETAIL MODIFY (MECHANISM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_MECHANISM_DETAIL MODIFY (MECHANISM_DETAIL_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CA_SUBM ADD CONSTRAINT PK_RCRA_CA_SUBM PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_CA_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_MECHANISM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_MECHANISM ADD CONSTRAINT PK_RCRA_FA_MCHNISM PRIMARY KEY (MECHANISM_ID) ENABLE;
 
  ALTER TABLE RCRA_FA_MECHANISM MODIFY (MECHANISM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_MECHANISM MODIFY (FINANCIAL_ASSURANCE_FAC_SBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_MECHANISM MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_MECHANISM MODIFY (MECHANISM_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_MECHANISM MODIFY (MECHANISM_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_UNIT_DETAIL
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_UNIT_DETAIL ADD CONSTRAINT PK_RCR_PRM_UNT_DTL PRIMARY KEY (PERMIT_UNIT_DETAIL_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_UNIT_DETAIL MODIFY (PERMIT_UNIT_DETAIL_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_UNIT_DETAIL MODIFY (PERMIT_UNIT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_UNIT_DETAIL MODIFY (PERMIT_UNIT_DETAIL_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_COST_EST
--------------------------------------------------------

  ALTER TABLE RCRA_FA_COST_EST ADD CONSTRAINT PK_RCRA_FA_CST_EST PRIMARY KEY (COST_ESTIMATE_ID) ENABLE;
 
  ALTER TABLE RCRA_FA_COST_EST MODIFY (COST_ESTIMATE_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST MODIFY (FINANCIAL_ASSURANCE_FAC_SBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST MODIFY (COST_ESTIMATE_TYPE_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST MODIFY (COST_ESTIMATE_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST MODIFY (COST_ESTIMATE_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AUTHORITY
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AUTHORITY ADD CONSTRAINT PK_RCRA_CA_AUTHRTY PRIMARY KEY (CORCT_ACT_AUTHORITY_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (CORCT_ACT_AUTHORITY_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (CORCT_ACT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (AUTHORITY_DATA_OWNER_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (AUTHORITY_TYPE_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (AUTHORITY_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AUTHORITY MODIFY (AUTHORITY_EFFC_DATE NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_GIS_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_GIS_SUBM ADD CONSTRAINT PK_RCRA_GIS_SUBM PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_GIS_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_SUBM ADD CONSTRAINT PK_RCRA_PRM_SUBM PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_PRM_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_COST_EST_REL_MECHANISM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM ADD CONSTRAINT PK_RC_FA_CS_ES_RL PRIMARY KEY (CST_ESTIMTE_RELTED_MECHNISM_ID) ENABLE;
 
  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM MODIFY (CST_ESTIMTE_RELTED_MECHNISM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM MODIFY (COST_ESTIMATE_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM MODIFY (MECHANISM_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM MODIFY (MECHANISM_SEQ_NUM NOT NULL ENABLE);
 
  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM MODIFY (MECHANISM_DETAIL_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_UNIT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_UNIT ADD CONSTRAINT PK_RCRA_PRM_UNIT PRIMARY KEY (PERMIT_UNIT_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_UNIT MODIFY (PERMIT_UNIT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_UNIT MODIFY (PERMIT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_UNIT MODIFY (PERMIT_UNIT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_EVENT_COMMITMENT ADD CONSTRAINT PK_RCR_PRM_EVN_CMM PRIMARY KEY (PERMIT_EVENT_COMMIT_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_EVENT_COMMITMENT MODIFY (PERMIT_EVENT_COMMIT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT_COMMITMENT MODIFY (PERMIT_EVENT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT_COMMITMENT MODIFY (COMMIT_LEAD NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT_COMMITMENT MODIFY (COMMIT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_WASTE_CODE ADD CONSTRAINT PK_RCR_PRM_WST_CDE PRIMARY KEY (PK_GUID) ENABLE;
 
  ALTER TABLE RCRA_PRM_WASTE_CODE MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_WASTE_CODE MODIFY (FK_GUID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AREA
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AREA ADD CONSTRAINT PK_RCRA_CA_AREA PRIMARY KEY (CORCT_ACT_AREA_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_AREA MODIFY (CORCT_ACT_AREA_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA MODIFY (CORCT_ACT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_AREA MODIFY (AREA_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_EVENT_COMMITMENT ADD CONSTRAINT PK_RCRA_CA_EVN_CMM PRIMARY KEY (EVENT_EVENT_COMMIT_ID) ENABLE;
 
  ALTER TABLE RCRA_CA_EVENT_COMMITMENT MODIFY (EVENT_EVENT_COMMIT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT_COMMITMENT MODIFY (CORCT_ACT_EVENT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT_COMMITMENT MODIFY (COMMIT_LEAD NOT NULL ENABLE);
 
  ALTER TABLE RCRA_CA_EVENT_COMMITMENT MODIFY (COMMIT_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_SERIES
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_SERIES ADD CONSTRAINT PK_RCRA_PRM_SERIES PRIMARY KEY (PERMIT_SERIES_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_SERIES MODIFY (PERMIT_SERIES_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_SERIES MODIFY (PERMIT_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_SERIES MODIFY (PERMIT_SERIES_SEQ_NUM NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_GIS_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_GIS_FAC_SUBM ADD CONSTRAINT PK_RCRA_GIS_FC_SBM PRIMARY KEY (GIS_FAC_SUBM_ID) ENABLE;
 
  ALTER TABLE RCRA_GIS_FAC_SUBM MODIFY (GIS_FAC_SUBM_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_GIS_FAC_SUBM MODIFY (PK_GUID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_GIS_FAC_SUBM MODIFY (HANDLER_ID NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_EVENT ADD CONSTRAINT PK_RCRA_PRM_EVENT PRIMARY KEY (PERMIT_EVENT_ID) ENABLE;
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (PERMIT_EVENT_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (PERMIT_SERIES_ID NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (ACT_LOC_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (PERMIT_EVENT_DATA_OWNER_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (PERMIT_EVENT_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (EVENT_AGN_CODE NOT NULL ENABLE);
 
  ALTER TABLE RCRA_PRM_EVENT MODIFY (EVENT_SEQ_NUM NOT NULL ENABLE);

--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AREA
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AREA ADD CONSTRAINT FK_RC_CA_AR_RC_CA FOREIGN KEY (CORCT_ACT_FAC_SUBM_ID)
    REFERENCES RCRA_CA_FAC_SUBM (CORCT_ACT_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AREA_REL_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AREA_REL_EVENT ADD CONSTRAINT FK_RC_CA_AR_RL_EV FOREIGN KEY (CORCT_ACT_AREA_ID)
    REFERENCES RCRA_CA_AREA (CORCT_ACT_AREA_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AUTHORITY
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AUTHORITY ADD CONSTRAINT FK_RC_CA_AT_RC_CA FOREIGN KEY (CORCT_ACT_FAC_SUBM_ID)
    REFERENCES RCRA_CA_FAC_SUBM (CORCT_ACT_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AUTH_REL_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_AUTH_REL_EVENT ADD CONSTRAINT FK_RC_CA_AT_RL_EV FOREIGN KEY (CORCT_ACT_AUTHORITY_ID)
    REFERENCES RCRA_CA_AUTHORITY (CORCT_ACT_AUTHORITY_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_EVENT ADD CONSTRAINT FK_RC_CA_EV_RC_CA FOREIGN KEY (CORCT_ACT_FAC_SUBM_ID)
    REFERENCES RCRA_CA_FAC_SUBM (CORCT_ACT_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_EVENT_COMMITMENT ADD CONSTRAINT FK_RC_CA_EV_CM_RC FOREIGN KEY (CORCT_ACT_EVENT_ID)
    REFERENCES RCRA_CA_EVENT (CORCT_ACT_EVENT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_CA_FAC_SUBM ADD CONSTRAINT FK_RC_CA_FC_SB_RC FOREIGN KEY (PK_GUID)
    REFERENCES RCRA_CA_SUBM (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_REL_PERMIT_UNIT
--------------------------------------------------------

  ALTER TABLE RCRA_CA_REL_PERMIT_UNIT ADD CONSTRAINT FK_RC_CA_RL_PR_UN FOREIGN KEY (CORCT_ACT_AREA_ID)
    REFERENCES RCRA_CA_AREA (CORCT_ACT_AREA_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_STATUTORY_CITATION
--------------------------------------------------------

  ALTER TABLE RCRA_CA_STATUTORY_CITATION ADD CONSTRAINT FK_RC_CA_ST_CT_RC FOREIGN KEY (CORCT_ACT_AUTHORITY_ID)
    REFERENCES RCRA_CA_AUTHORITY (CORCT_ACT_AUTHORITY_ID) ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_COST_EST
--------------------------------------------------------

  ALTER TABLE RCRA_FA_COST_EST ADD CONSTRAINT FK_RC_FA_CS_ES_RC FOREIGN KEY (FINANCIAL_ASSURANCE_FAC_SBM_ID)
    REFERENCES RCRA_FA_FAC_SUBM (FINANCIAL_ASSURANCE_FAC_SBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_COST_EST_REL_MECHANISM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_COST_EST_REL_MECHANISM ADD CONSTRAINT FK_RC_FA_CS_ES_RL FOREIGN KEY (COST_ESTIMATE_ID)
    REFERENCES RCRA_FA_COST_EST (COST_ESTIMATE_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_FAC_SUBM ADD CONSTRAINT FK_RC_FA_FC_SB_RC FOREIGN KEY (PK_GUID)
    REFERENCES RCRA_FA_SUBM (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_MECHANISM
--------------------------------------------------------

  ALTER TABLE RCRA_FA_MECHANISM ADD CONSTRAINT FK_RC_FA_MC_RC_FA FOREIGN KEY (FINANCIAL_ASSURANCE_FAC_SBM_ID)
    REFERENCES RCRA_FA_FAC_SUBM (FINANCIAL_ASSURANCE_FAC_SBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_MECHANISM_DETAIL
--------------------------------------------------------

  ALTER TABLE RCRA_FA_MECHANISM_DETAIL ADD CONSTRAINT FK_RC_FA_MC_DT_RC FOREIGN KEY (MECHANISM_ID)
    REFERENCES RCRA_FA_MECHANISM (MECHANISM_ID) ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_GIS_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_GIS_FAC_SUBM ADD CONSTRAINT FK_RC_GS_FC_SB_RC FOREIGN KEY (PK_GUID)
    REFERENCES RCRA_GIS_SUBM (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_GIS_GEO_INFORMATION
--------------------------------------------------------

  ALTER TABLE RCRA_GIS_GEO_INFORMATION ADD CONSTRAINT FK_RC_GS_GO_IN_RC FOREIGN KEY (GIS_FAC_SUBM_ID)
    REFERENCES RCRA_GIS_FAC_SUBM (GIS_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_EVENT ADD CONSTRAINT FK_RC_PR_EV_RC_PR FOREIGN KEY (PERMIT_SERIES_ID)
    REFERENCES RCRA_PRM_SERIES (PERMIT_SERIES_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_EVENT_COMMITMENT ADD CONSTRAINT FK_RC_PR_EV_CM_RC FOREIGN KEY (PERMIT_EVENT_ID)
    REFERENCES RCRA_PRM_EVENT (PERMIT_EVENT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_FAC_SUBM ADD CONSTRAINT FK_RC_PR_FC_SB_RC FOREIGN KEY (PK_GUID)
    REFERENCES RCRA_PRM_SUBM (PK_GUID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_RELATED_EVENT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_RELATED_EVENT ADD CONSTRAINT FK_RC_PR_RL_EV_RC FOREIGN KEY (PERMIT_UNIT_DETAIL_ID)
    REFERENCES RCRA_PRM_UNIT_DETAIL (PERMIT_UNIT_DETAIL_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_SERIES
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_SERIES ADD CONSTRAINT FK_RC_PR_SR_RC_PR FOREIGN KEY (PERMIT_FAC_SUBM_ID)
    REFERENCES RCRA_PRM_FAC_SUBM (PERMIT_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_UNIT
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_UNIT ADD CONSTRAINT FK_RC_PR_UN_RC_PR FOREIGN KEY (PERMIT_FAC_SUBM_ID)
    REFERENCES RCRA_PRM_FAC_SUBM (PERMIT_FAC_SUBM_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_UNIT_DETAIL
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_UNIT_DETAIL ADD CONSTRAINT FK_RC_PR_UN_DT_RC FOREIGN KEY (PERMIT_UNIT_ID)
    REFERENCES RCRA_PRM_UNIT (PERMIT_UNIT_ID) ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE RCRA_PRM_WASTE_CODE ADD CONSTRAINT FK_RC_PR_WS_CD_RC FOREIGN KEY (FK_GUID)
    REFERENCES RCRA_PRM_UNIT_DETAIL (PERMIT_UNIT_DETAIL_ID) ON DELETE CASCADE ENABLE;
