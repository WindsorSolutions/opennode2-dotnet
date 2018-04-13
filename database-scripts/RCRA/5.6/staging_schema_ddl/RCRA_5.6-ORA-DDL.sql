/*
Copyright (c) 2016, The Environmental Council of the States (ECOS)
All rights reserved.
 
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:
 
 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.
 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
/*****************************************************************************************************************************   
 *
 *  Script Name:  RCRA_5.4-ORA-DDL.sql
 *
 *  Company:  Windsor Solutions, Inc.
 *  
 *  Purpose:  This script will build the database objects supporting the RCRA v5.4 flow
 *   
 *  Maintenance:
 *  
 *    Analyst         Date            Comment 
 *    ----------      ----------      ------------------------------------------------------------------------------
 *    Bill R          2/4/2016        Adapted v5.2 DDL script for new elements in v5.3
 *    Bill R          3/17/2016       Added 5.4 changes
 *    Bill R          4/11/2016       Adjust decimal data types to match schema
 *    Bill R          11/15/2016      Add three missing address number fields from v5.3
 *    Kev Ja          08/02/2017      Modified location and mail address to VARCHAR2(50) and NOTES to VARCHAR2(2000).
 *    And Ge        	02/06/2018			RCRA 5.6 changes
 *
  ****************************************************************************************************************************   
 */
/* ****************************
 *  DROP ALL RCRA 5.3 OBJECTS * 
 * ****************************
 *
ALTER TABLE "RCRA_PRM_WASTE_CODE"
 DROP CONSTRAINT "FK_PR_WS_CD_PR_UN";

ALTER TABLE "RCRA_PRM_UNIT"
 DROP CONSTRAINT "FK_PRM_UN_PR_FC_SB";

ALTER TABLE "RCRA_PRM_UNIT_DETAIL"
 DROP CONSTRAINT "FK_PRM_UN_DT_PR_UN";

ALTER TABLE "RCRA_PRM_SERIES"
 DROP CONSTRAINT "FK_PRM_SR_PR_FC_SB";

ALTER TABLE "RCRA_PRM_RELATED_EVENT"
 DROP CONSTRAINT "FK_PR_RL_EV_PR_UN";

ALTER TABLE "RCRA_PRM_FAC_SUBM"
 DROP CONSTRAINT "FK_PRM_FC_SB_PR_SB";

ALTER TABLE "RCRA_PRM_EVENT"
 DROP CONSTRAINT "FK_PRM_EVN_PRM_SRS";

ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT"
 DROP CONSTRAINT "FK_PRM_EV_CM_PR_EV";

ALTER TABLE "RCRA_HD_WASTE_CODE"
 DROP CONSTRAINT "FK_HD_WAS_CO_HD_HA";

ALTER TABLE "RCRA_HD_UNIVERSAL_WASTE"
 DROP CONSTRAINT "FK_HD_UNI_WA_HD_HA";

ALTER TABLE "RCRA_HD_STATE_ACTIVITY"
 DROP CONSTRAINT "FK_HD_STA_AC_HD_HA";

ALTER TABLE "RCRA_HD_SEC_WASTE_CODE"
 DROP CONSTRAINT "FK_HD_SE_WA_CO_HD";

ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY"
 DROP CONSTRAINT "FK_HD_SE_MA_AC_HD";

ALTER TABLE "RCRA_HD_OWNEROP"
 DROP CONSTRAINT "FK_HD_OWNE_HD_HAND";

ALTER TABLE "RCRA_HD_OTHER_ID"
 DROP CONSTRAINT "FK_HD_OTH_ID_HD_HB";

ALTER TABLE "RCRA_HD_NAICS"
 DROP CONSTRAINT "FK_HD_NAIC_HD_HAND";

ALTER TABLE "RCRA_HD_HBASIC"
 DROP CONSTRAINT "FK_HD_HBAS_HD_SUBM";

ALTER TABLE "RCRA_HD_HANDLER"
 DROP CONSTRAINT "FK_HD_HAND_HD_HBAS";

ALTER TABLE "RCRA_HD_ENV_PERMIT"
 DROP CONSTRAINT "FK_HD_ENV_PE_HD_HA";

ALTER TABLE "RCRA_HD_CERTIFICATION"
 DROP CONSTRAINT "FK_HD_CERT_HD_HAND";

ALTER TABLE "RCRA_GIS_GEO_INFORMATION"
 DROP CONSTRAINT "FK_GS_GO_IN_GS_FC";

ALTER TABLE "RCRA_GIS_FAC_SUBM"
 DROP CONSTRAINT "FK_GS_FC_SBM_GS_SB";

ALTER TABLE "RCRA_FA_MECHANISM"
 DROP CONSTRAINT "FK_FA_MCH_FA_FC_SB";

ALTER TABLE "RCRA_FA_MECHANISM_DETAIL"
 DROP CONSTRAINT "FK_FA_MCH_DT_FA_MC";

ALTER TABLE "RCRA_FA_FAC_SUBM"
 DROP CONSTRAINT "FK_FA_FC_SBM_FA_SB";

ALTER TABLE "RCRA_FA_COST_EST"
 DROP CONSTRAINT "FK_FA_CS_ES_FA_FC";

ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM"
 DROP CONSTRAINT "FK_FA_CS_ES_RL_MC";

ALTER TABLE "RCRA_CME_VIOL"
 DROP CONSTRAINT "FK_CME_VL_CM_FC_SB";

ALTER TABLE "RCRA_CME_VIOL_ENFRC"
 DROP CONSTRAINT "FK_CM_VL_EN_CM_EN";

ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT"
 DROP CONSTRAINT "FK_CM_SP_EN_PR_CM";

ALTER TABLE "RCRA_CME_RQST"
 DROP CONSTRAINT "FK_CME_RQS_CME_EVL";

ALTER TABLE "RCRA_CME_PYMT"
 DROP CONSTRAINT "FK_CME_PYM_CME_PNL";

ALTER TABLE "RCRA_CME_PNLTY"
 DROP CONSTRAINT "FK_CME_PN_CM_EN_AC";

ALTER TABLE "RCRA_CME_MILESTONE"
 DROP CONSTRAINT "FK_CME_ML_CM_EN_AC";

ALTER TABLE "RCRA_CME_MEDIA"
 DROP CONSTRAINT "FK_CME_MD_CM_EN_AC";

ALTER TABLE "RCRA_CME_FAC_SUBM"
 DROP CONSTRAINT "FK_CME_FC_SB_CM_SB";

ALTER TABLE "RCRA_CME_EVAL"
 DROP CONSTRAINT "FK_CME_EV_CM_FC_SB";

ALTER TABLE "RCRA_CME_EVAL_VIOL"
 DROP CONSTRAINT "FK_CME_EV_VL_CM_EV";

ALTER TABLE "RCRA_CME_EVAL_COMMIT"
 DROP CONSTRAINT "FK_CME_EV_CM_CM_EV";

ALTER TABLE "RCRA_CME_ENFRC_ACT"
 DROP CONSTRAINT "FK_CM_EN_AC_CM_FC";

ALTER TABLE "RCRA_CME_CSNY_DATE"
 DROP CONSTRAINT "FK_CM_CS_DT_CM_EN";

ALTER TABLE "RCRA_CME_CITATION"
 DROP CONSTRAINT "FK_CME_CTTN_CME_VL";

ALTER TABLE "RCRA_CA_STATUTORY_CITATION"
 DROP CONSTRAINT "FK_CA_STT_CT_CA_AT";

ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT"
 DROP CONSTRAINT "FK_CA_RL_PR_UN_CA";

ALTER TABLE "RCRA_CA_FAC_SUBM"
 DROP CONSTRAINT "FK_CA_FC_SBM_CA_SB";

ALTER TABLE "RCRA_CA_EVENT"
 DROP CONSTRAINT "FK_CA_EVN_CA_FC_SB";

ALTER TABLE "RCRA_CA_EVENT_COMMITMENT"
 DROP CONSTRAINT "FK_CA_EVN_CM_CA_EV";

ALTER TABLE "RCRA_CA_AUTHORITY"
 DROP CONSTRAINT "FK_CA_ATH_CA_FC_SB";

ALTER TABLE "RCRA_CA_AUTH_REL_EVENT"
 DROP CONSTRAINT "FK_CA_AT_RL_EV_CA";

ALTER TABLE "RCRA_CA_AREA"
 DROP CONSTRAINT "FK_CA_ARA_CA_FC_SB";

ALTER TABLE "RCRA_CA_AREA_REL_EVENT"
 DROP CONSTRAINT "FK_CA_AR_RL_EV_CA";

ALTER TABLE "RCRA_SUBMISSIONHISTORY"
 DROP CONSTRAINT "PK_SUBMISSIONHISTO";

ALTER TABLE "RCRA_PRM_WASTE_CODE"
 DROP CONSTRAINT "PK_PRM_WASTE_CODE";

ALTER TABLE "RCRA_PRM_UNIT"
 DROP CONSTRAINT "PK_PRM_UNIT";

ALTER TABLE "RCRA_PRM_UNIT_DETAIL"
 DROP CONSTRAINT "PK_PRM_UNIT_DETAIL";

ALTER TABLE "RCRA_PRM_SUBM"
 DROP CONSTRAINT "PK_PRM_SUBM";

ALTER TABLE "RCRA_PRM_SERIES"
 DROP CONSTRAINT "PK_PRM_SERIES";

ALTER TABLE "RCRA_PRM_RELATED_EVENT"
 DROP CONSTRAINT "PK_PRM_RELTED_EVNT";

ALTER TABLE "RCRA_PRM_FAC_SUBM"
 DROP CONSTRAINT "PK_PRM_FAC_SUBM";

ALTER TABLE "RCRA_PRM_EVENT"
 DROP CONSTRAINT "PK_PRM_EVENT";

ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT"
 DROP CONSTRAINT "PK_PRM_EVNT_CMMTMN";

ALTER TABLE "RCRA_HD_WASTE_CODE"
 DROP CONSTRAINT "PK_HD_WASTE_CODE";

ALTER TABLE "RCRA_HD_UNIVERSAL_WASTE"
 DROP CONSTRAINT "PK_HD_UNIVER_WASTE";

ALTER TABLE "RCRA_HD_SUBM"
 DROP CONSTRAINT "PK_HD_SUBM";

ALTER TABLE "RCRA_HD_STATE_ACTIVITY"
 DROP CONSTRAINT "PK_HD_STATE_ACTIVI";

ALTER TABLE "RCRA_HD_SEC_WASTE_CODE"
 DROP CONSTRAINT "PK_HD_SEC_WAST_COD";

ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY"
 DROP CONSTRAINT "PK_HD_SEC_MATE_ACT";

ALTER TABLE "RCRA_HD_OWNEROP"
 DROP CONSTRAINT "PK_HD_OWNEROP";

ALTER TABLE "RCRA_HD_OTHER_ID"
 DROP CONSTRAINT "PK_HD_OTHER_ID";

ALTER TABLE "RCRA_HD_NAICS"
 DROP CONSTRAINT "PK_HD_NAICS";

ALTER TABLE "RCRA_HD_HBASIC"
 DROP CONSTRAINT "PK_HD_HBASIC";

ALTER TABLE "RCRA_HD_HANDLER"
 DROP CONSTRAINT "PK_HD_HANDLER";

ALTER TABLE "RCRA_HD_ENV_PERMIT"
 DROP CONSTRAINT "PK_HD_ENV_PERMIT";

ALTER TABLE "RCRA_HD_CERTIFICATION"
 DROP CONSTRAINT "PK_HD_CERTIFICATIO";

ALTER TABLE "RCRA_GIS_SUBM"
 DROP CONSTRAINT "PK_GIS_SUBM";

ALTER TABLE "RCRA_GIS_GEO_INFORMATION"
 DROP CONSTRAINT "PK_GS_GO_INFORMTON";

ALTER TABLE "RCRA_GIS_FAC_SUBM"
 DROP CONSTRAINT "PK_GIS_FAC_SUBM";

ALTER TABLE "RCRA_FA_SUBM"
 DROP CONSTRAINT "PK_FA_SUBM";

ALTER TABLE "RCRA_FA_MECHANISM"
 DROP CONSTRAINT "PK_FA_MECHANISM";

ALTER TABLE "RCRA_FA_MECHANISM_DETAIL"
 DROP CONSTRAINT "PK_FA_MCHNISM_DTIL";

ALTER TABLE "RCRA_FA_FAC_SUBM"
 DROP CONSTRAINT "PK_FA_FAC_SUBM";

ALTER TABLE "RCRA_FA_COST_EST"
 DROP CONSTRAINT "PK_FA_COST_EST";

ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM"
 DROP CONSTRAINT "PK_FA_CST_ES_RL_MC";

ALTER TABLE "RCRA_CME_VIOL"
 DROP CONSTRAINT "PK_CME_VIOL";

ALTER TABLE "RCRA_CME_VIOL_ENFRC"
 DROP CONSTRAINT "PK_CME_VIOL_ENFRC";

ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT"
 DROP CONSTRAINT "PK_CME_SPP_ENV_PRJ";

ALTER TABLE "RCRA_CME_SUBM"
 DROP CONSTRAINT "PK_CME_SUBM";

ALTER TABLE "RCRA_CME_RQST"
 DROP CONSTRAINT "PK_CME_RQST";

ALTER TABLE "RCRA_CME_PYMT"
 DROP CONSTRAINT "PK_CME_PYMT";

ALTER TABLE "RCRA_CME_PNLTY"
 DROP CONSTRAINT "PK_CME_PNLTY";

ALTER TABLE "RCRA_CME_MILESTONE"
 DROP CONSTRAINT "PK_CME_MILESTONE";

ALTER TABLE "RCRA_CME_MEDIA"
 DROP CONSTRAINT "PK_CME_MEDIA";

ALTER TABLE "RCRA_CME_FAC_SUBM"
 DROP CONSTRAINT "PK_CME_FAC_SUBM";

ALTER TABLE "RCRA_CME_EVAL"
 DROP CONSTRAINT "PK_CME_EVAL";

ALTER TABLE "RCRA_CME_EVAL_VIOL"
 DROP CONSTRAINT "PK_CME_EVAL_VIOL";

ALTER TABLE "RCRA_CME_EVAL_COMMIT"
 DROP CONSTRAINT "PK_CME_EVAL_COMMIT";

ALTER TABLE "RCRA_CME_ENFRC_ACT"
 DROP CONSTRAINT "PK_CME_ENFRC_ACT";

ALTER TABLE "RCRA_CME_CSNY_DATE"
 DROP CONSTRAINT "PK_CME_CSNY_DATE";

ALTER TABLE "RCRA_CME_CITATION"
 DROP CONSTRAINT "PK_CME_CITATION";

ALTER TABLE "RCRA_CA_SUBM"
 DROP CONSTRAINT "PK_CA_SUBM";

ALTER TABLE "RCRA_CA_STATUTORY_CITATION"
 DROP CONSTRAINT "PK_CA_STTTRY_CTTON";

ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT"
 DROP CONSTRAINT "PK_CA_RL_PRMIT_UNT";

ALTER TABLE "RCRA_CA_FAC_SUBM"
 DROP CONSTRAINT "PK_CA_FAC_SUBM";

ALTER TABLE "RCRA_CA_EVENT"
 DROP CONSTRAINT "PK_CA_EVENT";

ALTER TABLE "RCRA_CA_EVENT_COMMITMENT"
 DROP CONSTRAINT "PK_CA_EVNT_CMMTMNT";

ALTER TABLE "RCRA_CA_AUTHORITY"
 DROP CONSTRAINT "PK_CA_AUTHORITY";

ALTER TABLE "RCRA_CA_AUTH_REL_EVENT"
 DROP CONSTRAINT "PK_CA_AUTH_RL_EVNT";

ALTER TABLE "RCRA_CA_AREA"
 DROP CONSTRAINT "PK_CA_AREA";

ALTER TABLE "RCRA_CA_AREA_REL_EVENT"
 DROP CONSTRAINT "PK_CA_AREA_RL_EVNT";

--DROP INDEX "PK_SUBMISSIONHISTO";

--DROP INDEX "PK_PRM_WASTE_CODE";

DROP INDEX "IX_PR_WS_CD_PR_UN";

DROP INDEX "IX_PR_UN_PR_FC_SB";

--DROP INDEX "PK_PRM_UNIT";

--DROP INDEX "PK_PRM_UNIT_DETAIL";

DROP INDEX "IX_PR_UN_DT_PR_UN";

--DROP INDEX "PK_PRM_SUBM";

DROP INDEX "IX_PR_SR_PR_FC_SB";

--DROP INDEX "PK_PRM_SERIES";

--DROP INDEX "PK_PRM_RELTED_EVNT";

DROP INDEX "IX_PR_RL_EV_PR_UN";

DROP INDEX "IX_PR_FC_SB_PR_SB";

--DROP INDEX "PK_PRM_FAC_SUBM";

DROP INDEX "IX_PRM_EV_PR_SR_ID";

--DROP INDEX "PK_PRM_EVENT";

--DROP INDEX "PK_PRM_EVNT_CMMTMN";

DROP INDEX "IX_PR_EV_CM_PR_EV";

--DROP INDEX "PK_HD_WASTE_CODE";

DROP INDEX "IX_HD_WA_CO_HD_HA";

DROP INDEX "IX_HD_UN_WA_HD_HA";

--DROP INDEX "PK_HD_UNIVER_WASTE";

--DROP INDEX "PK_HD_SUBM";

DROP INDEX "IX_HD_ST_AC_HD_HA";

--DROP INDEX "PK_HD_STATE_ACTIVI";

--DROP INDEX "PK_HD_SEC_WAST_COD";

DROP INDEX "IX_HD_SE_WA_CO_HD";

DROP INDEX "IX_HD_SE_MA_AC_HD";

--DROP INDEX "PK_HD_SEC_MATE_ACT";

--DROP INDEX "PK_HD_OWNEROP";

DROP INDEX "IX_HD_OWN_HD_HA_ID";

--DROP INDEX "PK_HD_OTHER_ID";

DROP INDEX "IX_HD_OT_ID_HD_HB";

--DROP INDEX "PK_HD_NAICS";

DROP INDEX "IX_HD_NAI_HD_HA_ID";

--DROP INDEX "PK_HD_HBASIC";

DROP INDEX "IX_HD_HBA_HD_SU_ID";

DROP INDEX "IX_HD_HAN_HD_HB_ID";

--DROP INDEX "PK_HD_HANDLER";

--DROP INDEX "PK_HD_ENV_PERMIT";

DROP INDEX "IX_HD_EN_PE_HD_HA";

--DROP INDEX "PK_HD_CERTIFICATIO";

DROP INDEX "IX_HD_CER_HD_HA_ID";

--DROP INDEX "PK_GIS_SUBM";

DROP INDEX "IX_GS_GO_IN_GS_FC";

--DROP INDEX "PK_GS_GO_INFORMTON";

--DROP INDEX "PK_GIS_FAC_SUBM";

DROP INDEX "IX_GS_FC_SB_GS_SB";

--DROP INDEX "PK_FA_SUBM";

--DROP INDEX "PK_FA_MECHANISM";

DROP INDEX "IX_FA_MC_FA_FC_SB";

--DROP INDEX "PK_FA_MCHNISM_DTIL";

DROP INDEX "IX_FA_MC_DT_FA_MC";

--DROP INDEX "PK_FA_FAC_SUBM";

DROP INDEX "IX_FA_FC_SB_FA_SB";

--DROP INDEX "PK_FA_COST_EST";

DROP INDEX "IX_FA_CS_ES_FA_FC";

--DROP INDEX "PK_FA_CST_ES_RL_MC";

DROP INDEX "IX_FA_CS_ES_RL_MC";

--DROP INDEX "PK_CME_VIOL";

DROP INDEX "IX_CM_VL_CM_FC_SB";

DROP INDEX "IX_CM_VL_EN_CM_EN";

--DROP INDEX "PK_CME_VIOL_ENFRC";

--DROP INDEX "PK_CME_SPP_ENV_PRJ";

DROP INDEX "IX_CM_SP_EN_PR_CM";

--DROP INDEX "PK_CME_SUBM";

--DROP INDEX "PK_CME_RQST";

DROP INDEX "IX_CME_RQ_CM_EV_ID";

DROP INDEX "IX_CME_PY_CM_PN_ID";

--DROP INDEX "PK_CME_PYMT";

--DROP INDEX "PK_CME_PNLTY";

DROP INDEX "IX_CM_PN_CM_EN_AC";

--DROP INDEX "PK_CME_MILESTONE";

DROP INDEX "IX_CM_ML_CM_EN_AC";

--DROP INDEX "PK_CME_MEDIA";

DROP INDEX "IX_CM_MD_CM_EN_AC";

DROP INDEX "IX_CM_FC_SB_CM_SB";

--DROP INDEX "PK_CME_FAC_SUBM";

--DROP INDEX "PK_CME_EVAL";

DROP INDEX "IX_CM_EV_CM_FC_SB";

DROP INDEX "IX_CM_EV_VL_CM_EV";

--DROP INDEX "PK_CME_EVAL_VIOL";

DROP INDEX "IX_CM_EV_CM_CM_EV";

--DROP INDEX "PK_CME_EVAL_COMMIT";

--DROP INDEX "PK_CME_ENFRC_ACT";

DROP INDEX "IX_CM_EN_AC_CM_FC";

--DROP INDEX "PK_CME_CSNY_DATE";

DROP INDEX "IX_CM_CS_DT_CM_EN";

DROP INDEX "IX_CME_CT_CM_VL_ID";

--DROP INDEX "PK_CME_CITATION";

--DROP INDEX "PK_CA_SUBM";

--DROP INDEX "PK_CA_STTTRY_CTTON";

DROP INDEX "IX_CA_ST_CT_CA_AT";

--DROP INDEX "PK_CA_RL_PRMIT_UNT";

DROP INDEX "IX_CA_RL_PR_UN_CA";

DROP INDEX "IX_CA_FC_SB_CA_SB";

--DROP INDEX "PK_CA_FAC_SUBM";

DROP INDEX "IX_CA_EV_CA_FC_SB";

--DROP INDEX "PK_CA_EVENT";

--DROP INDEX "PK_CA_EVNT_CMMTMNT";

DROP INDEX "IX_CA_EV_CM_CA_EV";

DROP INDEX "IX_CA_AT_CA_FC_SB";

--DROP INDEX "PK_CA_AUTHORITY";

DROP INDEX "IX_CA_AT_RL_EV_CA";

--DROP INDEX "PK_CA_AUTH_RL_EVNT";

DROP INDEX "IX_CA_AR_CA_FC_SB";

--DROP INDEX "PK_CA_AREA";

--DROP INDEX "PK_CA_AREA_RL_EVNT";

DROP INDEX "IX_CA_AR_RL_EV_CA";

DROP TABLE "RCRA_SUBMISSIONHISTORY";

DROP TABLE "RCRA_PRM_WASTE_CODE";

DROP TABLE "RCRA_PRM_UNIT";

DROP TABLE "RCRA_PRM_UNIT_DETAIL";

DROP TABLE "RCRA_PRM_SUBM";

DROP TABLE "RCRA_PRM_SERIES";

DROP TABLE "RCRA_PRM_RELATED_EVENT";

DROP TABLE "RCRA_PRM_FAC_SUBM";

DROP TABLE "RCRA_PRM_EVENT";

DROP TABLE "RCRA_PRM_EVENT_COMMITMENT";

DROP TABLE "RCRA_HD_WASTE_CODE";

DROP TABLE "RCRA_HD_UNIVERSAL_WASTE";

DROP TABLE "RCRA_HD_SUBM";

DROP TABLE "RCRA_HD_STATE_ACTIVITY";

DROP TABLE "RCRA_HD_SEC_WASTE_CODE";

DROP TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY";

DROP TABLE "RCRA_HD_OWNEROP";

DROP TABLE "RCRA_HD_OTHER_ID";

DROP TABLE "RCRA_HD_NAICS";

DROP TABLE "RCRA_HD_HBASIC";

DROP TABLE "RCRA_HD_HANDLER";

DROP TABLE "RCRA_HD_ENV_PERMIT";

DROP TABLE "RCRA_HD_CERTIFICATION";

DROP TABLE "RCRA_GIS_SUBM";

DROP TABLE "RCRA_GIS_GEO_INFORMATION";

DROP TABLE "RCRA_GIS_FAC_SUBM";

DROP TABLE "RCRA_FA_SUBM";

DROP TABLE "RCRA_FA_MECHANISM";

DROP TABLE "RCRA_FA_MECHANISM_DETAIL";

DROP TABLE "RCRA_FA_FAC_SUBM";

DROP TABLE "RCRA_FA_COST_EST";

DROP TABLE "RCRA_FA_COST_EST_REL_MECHANISM";

DROP TABLE "RCRA_CME_VIOL";

DROP TABLE "RCRA_CME_VIOL_ENFRC";

DROP TABLE "RCRA_CME_SUPP_ENVR_PRJT";

DROP TABLE "RCRA_CME_SUBM";

DROP TABLE "RCRA_CME_RQST";

DROP TABLE "RCRA_CME_PYMT";

DROP TABLE "RCRA_CME_PNLTY";

DROP TABLE "RCRA_CME_MILESTONE";

DROP TABLE "RCRA_CME_MEDIA";

DROP TABLE "RCRA_CME_FAC_SUBM";

DROP TABLE "RCRA_CME_EVAL";

DROP TABLE "RCRA_CME_EVAL_VIOL";

DROP TABLE "RCRA_CME_EVAL_COMMIT";

DROP TABLE "RCRA_CME_ENFRC_ACT";

DROP TABLE "RCRA_CME_CSNY_DATE";

DROP TABLE "RCRA_CME_CITATION";

DROP TABLE "RCRA_CA_SUBM";

DROP TABLE "RCRA_CA_STATUTORY_CITATION";

DROP TABLE "RCRA_CA_REL_PERMIT_UNIT";

DROP TABLE "RCRA_CA_FAC_SUBM";

DROP TABLE "RCRA_CA_EVENT";

DROP TABLE "RCRA_CA_EVENT_COMMITMENT";

DROP TABLE "RCRA_CA_AUTHORITY";

DROP TABLE "RCRA_CA_AUTH_REL_EVENT";

DROP TABLE "RCRA_CA_AREA";

DROP TABLE "RCRA_CA_AREA_REL_EVENT";




purge recyclebin;

*/
--------------------------------------------------------
--  DDL for Table RCRA_CA_AREA
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_AREA" 
   (	"CA_AREA_ID" VARCHAR2(40), 
	"CA_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"AREA_SEQ_NUM" NUMBER(10,0), 
	"FAC_WIDE_IND" CHAR(1), 
	"AREA_NAME" VARCHAR2(40), 
	"AIR_REL_IND" CHAR(1), 
	"GROUNDWATER_REL_IND" CHAR(1), 
	"SOIL_REL_IND" CHAR(1), 
	"SURFACE_WATER_REL_IND" CHAR(1), 
	"REGULATED_UNIT_IND" CHAR(1), 
	"EPA_RESP_PERSON_DATA_OWNER_CDE" CHAR(2), 
	"EPA_RESP_PERSON_ID" VARCHAR2(5), 
	"STA_RESP_PERSON_DATA_OWNER_CDE" CHAR(2), 
	"STA_RESP_PERSON_ID" VARCHAR2(5), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_AREA"."CA_AREA_ID" IS 'Parent: A list of Correction Action Areas for a particluar Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."CA_FAC_SUBM_ID" IS 'Parent: A list of Correction Action Areas for a particluar Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."AREA_SEQ_NUM" IS 'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."FAC_WIDE_IND" IS 'Indicates that the corrective action applies to the entire facility. (FacilityWideIndicator)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."AREA_NAME" IS 'The name of the Corrective Action area. (AreaName)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."AIR_REL_IND" IS 'Indicates that there has been a release to air (either within or beyond the facility boundary) from the unit/area. This may include releases of subsurface gas. (AirReleaseIndicator)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."GROUNDWATER_REL_IND" IS 'Indicates that there has been a release to groundwater from the unit/area. (GroundwaterReleaseIndicator)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."SOIL_REL_IND" IS 'Indicates that there has been a release to soil (either within or beyond the facility boundary) from the unit/area. This may include subsoil contamination beneath the unit/area. (SoilReleaseIndicator)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."SURFACE_WATER_REL_IND" IS 'Indicates that there has been a release to surface water (either within or beyond the facility boundary) from the unit/area. (SurfaceWaterReleaseIndicator)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."REGULATED_UNIT_IND" IS 'Indicates that the corrective action applies to a regulated unit. (RegulatedUnitIndicator)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."EPA_RESP_PERSON_DATA_OWNER_CDE" IS 'Indicates the agency that defines the person identifier. (EPAResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."EPA_RESP_PERSON_ID" IS 'The person currently responsible for the permit at the EPA level. (EPAResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."STA_RESP_PERSON_DATA_OWNER_CDE" IS 'Indicates the agency that defines the person identifier. (StateResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."STA_RESP_PERSON_ID" IS 'The state person currently responsible for overseeing the corrective action area. (StateResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_CA_AREA"  IS 'Schema element: CorrectiveActionAreaDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_AREA_REL_EVENT
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_AREA_REL_EVENT" 
   (	"CA_AREA_REL_EVENT_ID" VARCHAR2(40), 
	"CA_AREA_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"CORCT_ACT_EVENT_DATA_OWNER_CDE" CHAR(2), 
	"CORCT_ACT_EVENT_CODE" VARCHAR2(7), 
	"EVENT_AGN_CODE" CHAR(1), 
	"EVENT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."CA_AREA_REL_EVENT_ID" IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."CA_AREA_ID" IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."CORCT_ACT_EVENT_DATA_OWNER_CDE" IS 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."CORCT_ACT_EVENT_CODE" IS 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."EVENT_AGN_CODE" IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AREA_REL_EVENT"."EVENT_SEQ_NUM" IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_CA_AREA_REL_EVENT"  IS 'Schema element: CorrectiveActionAreaRelatedEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_AUTHORITY
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_AUTHORITY" 
   (	"CA_AUTHORITY_ID" VARCHAR2(40), 
	"CA_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"AUTHORITY_DATA_OWNER_CODE" CHAR(2), 
	"AUTHORITY_TYPE_CODE" CHAR(1), 
	"AUTHORITY_AGN_CODE" CHAR(1), 
	"AUTHORITY_EFFC_DATE" DATE, 
	"ISSUE_DATE" DATE, 
	"END_DATE" DATE, 
	"ESTABLISHED_REPOSITORY_CODE" CHAR(1), 
	"RESP_LEAD_PROG_IDEN" CHAR(1), 
	"AUTHORITY_SUBORG_DATA_OWNR_CDE" CHAR(2), 
	"AUTHORITY_SUBORG_CODE" VARCHAR2(10), 
	"RESP_PERSON_DATA_OWNER_CODE" CHAR(2), 
	"RESP_PERSON_ID" VARCHAR2(5), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."CA_AUTHORITY_ID" IS 'Parent: A list of Correction Action Authorities for a particluar Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."CA_FAC_SUBM_ID" IS 'Parent: A list of Correction Action Authorities for a particluar Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."AUTHORITY_DATA_OWNER_CODE" IS 'Indicates the agency that defines the authority. (AuthorityDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."AUTHORITY_TYPE_CODE" IS 'A code used to indicate whether a permit, administrative order, or other authority has been issued to implement the corrective action process. (AuthorityTypeCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."AUTHORITY_AGN_CODE" IS 'Agency responsible for the Authority. (AuthorityAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."AUTHORITY_EFFC_DATE" IS 'Date that the authority became effective. (AuthorityEffectiveDate)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."ISSUE_DATE" IS 'Date the authorized agency official signs the order, permit, or permit modification. (IssueDate)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."END_DATE" IS 'The date when the corrective action authority is revoked or ended. (EndDate)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."ESTABLISHED_REPOSITORY_CODE" IS 'The action by which the Director requires the owner/operator to establish and maintain an information repository at a location near the facility for the purpose of making accessible to interested parties documents, reports, and other public information relevant to public understanding of the activities, findings, and plans for such corrective action initiatives. (EstablishedRepositoryCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."RESP_LEAD_PROG_IDEN" IS 'Code indicating the program in which the organization establishes the applicable guidance that the authority should be issued. (ResponsibleLeadProgramIdentifier)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."AUTHORITY_SUBORG_DATA_OWNR_CDE" IS 'Authority responsible suborganization owner. (AuthoritySuborganizationDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."AUTHORITY_SUBORG_CODE" IS 'Authority responsible suborganization. (AuthoritySuborganizationCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."RESP_PERSON_DATA_OWNER_CODE" IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."RESP_PERSON_ID" IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTHORITY"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_CA_AUTHORITY"  IS 'Schema element: CorrectiveActionAuthorityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_AUTH_REL_EVENT
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_AUTH_REL_EVENT" 
   (	"CA_AUTH_REL_EVENT_ID" VARCHAR2(40), 
	"CA_AUTHORITY_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"CORCT_ACT_EVENT_DATA_OWNER_CDE" CHAR(2), 
	"CORCT_ACT_EVENT_CODE" VARCHAR2(7), 
	"EVENT_AGN_CODE" CHAR(1), 
	"EVENT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."CA_AUTH_REL_EVENT_ID" IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."CA_AUTHORITY_ID" IS 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."CORCT_ACT_EVENT_DATA_OWNER_CDE" IS 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."CORCT_ACT_EVENT_CODE" IS 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."EVENT_AGN_CODE" IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_CA_AUTH_REL_EVENT"."EVENT_SEQ_NUM" IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_CA_AUTH_REL_EVENT"  IS 'Schema element: CorrectiveActionAuthorityRelatedEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_EVENT
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_EVENT" 
   (	"CA_EVENT_ID" VARCHAR2(40), 
	"CA_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"CORCT_ACT_EVENT_DATA_OWNER_CDE" CHAR(2), 
	"CORCT_ACT_EVENT_CODE" VARCHAR2(7), 
	"EVENT_AGN_CODE" CHAR(1), 
	"EVENT_SEQ_NUM" NUMBER(10,0), 
	"ACTL_DATE" DATE, 
	"ORIGINAL_SCHEDULE_DATE" DATE, 
	"NEW_SCHEDULE_DATE" DATE, 
	"EVENT_SUBORG_DATA_OWNER_CODE" CHAR(2), 
	"EVENT_SUBORG_CODE" VARCHAR2(10), 
	"RESP_PERSON_DATA_OWNER_CODE" CHAR(2), 
	"RESP_PERSON_ID" VARCHAR2(5), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_EVENT"."CA_EVENT_ID" IS 'Parent: A list of Correction Action Events for a particluar Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."CA_FAC_SUBM_ID" IS 'Parent: A list of Correction Action Events for a particluar Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."CORCT_ACT_EVENT_DATA_OWNER_CDE" IS 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."CORCT_ACT_EVENT_CODE" IS 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."EVENT_AGN_CODE" IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."EVENT_SEQ_NUM" IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."ACTL_DATE" IS 'Date on which actual completion of an event occurs. (ActualDate)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."ORIGINAL_SCHEDULE_DATE" IS 'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."NEW_SCHEDULE_DATE" IS 'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."EVENT_SUBORG_DATA_OWNER_CODE" IS 'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."EVENT_SUBORG_CODE" IS 'Event responsible suborganization. (EventSuborganizationCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."RESP_PERSON_DATA_OWNER_CODE" IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."RESP_PERSON_ID" IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_CA_EVENT"  IS 'Schema element: CorrectiveActionEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_EVENT_COMMITMENT
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_EVENT_COMMITMENT" 
   (	"CA_EVENT_COMMITMENT_ID" VARCHAR2(40), 
	"CA_EVENT_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"COMMIT_LEAD" CHAR(2), 
	"COMMIT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_EVENT_COMMITMENT"."CA_EVENT_COMMITMENT_ID" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT_COMMITMENT"."CA_EVENT_ID" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT_COMMITMENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT_COMMITMENT"."COMMIT_LEAD" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)';
 
   COMMENT ON COLUMN "RCRA_CA_EVENT_COMMITMENT"."COMMIT_SEQ_NUM" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_CA_EVENT_COMMITMENT"  IS 'Schema element: EventEventCommitmentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_FAC_SUBM" 
   (	"CA_FAC_SUBM_ID" VARCHAR2(40), 
	"CA_SUBM_ID" VARCHAR2(40), 
	"HANDLER_ID" VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_FAC_SUBM"."CA_FAC_SUBM_ID" IS 'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_FAC_SUBM"."CA_SUBM_ID" IS 'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_FAC_SUBM"."HANDLER_ID" IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE "RCRA_CA_FAC_SUBM"  IS 'Schema element: CorrectiveActionFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_REL_PERMIT_UNIT
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_REL_PERMIT_UNIT" 
   (	"CA_REL_PERMIT_UNIT_ID" VARCHAR2(40), 
	"CA_AREA_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"PERMIT_UNIT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_REL_PERMIT_UNIT"."CA_REL_PERMIT_UNIT_ID" IS 'Parent: A permitted unit related to a corrective action area. (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_REL_PERMIT_UNIT"."CA_AREA_ID" IS 'Parent: A permitted unit related to a corrective action area. (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_REL_PERMIT_UNIT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_REL_PERMIT_UNIT"."PERMIT_UNIT_SEQ_NUM" IS 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_CA_REL_PERMIT_UNIT"  IS 'Schema element: CorrectiveActionRelatedPermitUnitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_STATUTORY_CITATION
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_STATUTORY_CITATION" 
   (	"CA_STATUTORY_CITATION_ID" VARCHAR2(40), 
	"CA_AUTHORITY_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"STATUTORY_CITTION_DTA_OWNR_CDE" CHAR(2), 
	"STATUTORY_CITATION_IDEN" CHAR(1)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CA_STATUTORY_CITATION"."CA_STATUTORY_CITATION_ID" IS 'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_PK)';
 
   COMMENT ON COLUMN "RCRA_CA_STATUTORY_CITATION"."CA_AUTHORITY_ID" IS 'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_FK)';
 
   COMMENT ON COLUMN "RCRA_CA_STATUTORY_CITATION"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CA_STATUTORY_CITATION"."STATUTORY_CITTION_DTA_OWNR_CDE" IS 'Orgnaization responsible for the Statutory Citation (use two-digit postal code) (StatutoryCitationDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_CA_STATUTORY_CITATION"."STATUTORY_CITATION_IDEN" IS 'Identifier that identifies the statutory authority under which the corrective action event occured (StatutoryCitationIdentifier)';
 
   COMMENT ON TABLE "RCRA_CA_STATUTORY_CITATION"  IS 'Schema element: CorrectiveActionStatutoryCitationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CA_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_CA_SUBM" 
   (	"CA_SUBM_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE "RCRA_CA_SUBM"  IS 'Schema element: HazardousWasteCorrectiveActionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_CITATION
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_CITATION" 
   (	"CME_CITATION_ID" VARCHAR2(40), 
	"CME_VIOL_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"CITATION_NAME_SEQ_NUM" NUMBER(10,0), 
	"CITATION_NAME" VARCHAR2(128), 
	"CITATION_NAME_OWNER" VARCHAR2(255), 
	"CITATION_NAME_TYPE" VARCHAR2(255), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_CITATION"."CME_CITATION_ID" IS 'Parent: Compliance Monitoring and Enforcement Citation Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."CME_VIOL_ID" IS 'Parent: Compliance Monitoring and Enforcement Citation Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."CITATION_NAME_SEQ_NUM" IS 'Parent: Compliance Monitoring and Enforcement Citation Data (CitationNameSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."CITATION_NAME" IS 'The citation(s) of the violations alleged (CME) or of the Authority used (CA). (CitationName)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."CITATION_NAME_OWNER" IS 'State postal code (CitationNameOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."CITATION_NAME_TYPE" IS 'Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3 (CitationNameType)';
 
   COMMENT ON COLUMN "RCRA_CME_CITATION"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Citation Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_CITATION"  IS 'Schema element: CitationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_CSNY_DATE" 
   (	"CME_CSNY_DATE_ID" VARCHAR2(40), 
	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"SNY_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_CSNY_DATE"."CME_CSNY_DATE_ID" IS 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_CSNY_DATE"."CME_ENFRC_ACT_ID" IS 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_CSNY_DATE"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_CSNY_DATE"."SNY_DATE" IS 'Date of the SNY that the Action is Addressing (SNYDate)';
 
   COMMENT ON TABLE "RCRA_CME_CSNY_DATE"  IS 'Schema element: CSNYDateDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_ENFRC_ACT" 
   (	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"CME_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"ENFRC_AGN_LOC_NAME" VARCHAR2(128), 
	"ENFRC_ACT_IDEN" VARCHAR2(50), 
	"ENFRC_ACT_DATE" DATE, 
	"ENFRC_AGN_NAME" VARCHAR2(128), 
	"ENFRC_DOCKET_NUM" VARCHAR2(20), 
	"ENFRC_ATTRY" VARCHAR2(255), 
	"CORCT_ACT_COMPT" VARCHAR2(255), 
	"CNST_AGMT_FINAL_ORDER_SEQ_NUM" NUMBER(10,0), 
	"APPEAL_INIT_DATE" DATE, 
	"APPEAL_RSLN_DATE" DATE, 
	"DISP_STAT_DATE" DATE, 
	"DISP_STAT_OWNER" VARCHAR2(255), 
	"DISP_STAT" VARCHAR2(255), 
	"ENFRC_OWNER" VARCHAR2(255), 
	"ENFRC_TYPE" VARCHAR2(255), 
	"ENFRC_RESP_PERSON_OWNER" VARCHAR2(255), 
	"ENFRC_RESP_PERSON_IDEN" VARCHAR2(50), 
	"ENFRC_RESP_SUBORG_OWNER" VARCHAR2(255), 
	"ENFRC_RESP_SUBORG" VARCHAR2(255), 
	"NOTES" VARCHAR2(2000),
	"FA_REQUIRED" CHAR(1)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."CME_ENFRC_ACT_ID" IS 'Parent: Compliance Monitoring and Enforcement Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."CME_FAC_SUBM_ID" IS 'Parent: Compliance Monitoring and Enforcement Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_AGN_LOC_NAME" IS 'The U.S.Postal Service alphabetic code that represents the U.S.State or territory in which a state or local government enforcement agency operates. (EnforcementAgencyLocationName)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_ACT_IDEN" IS 'The unique alphanumeric identifier used in the applicable database to identify a specific enforcement action pertaining to a regulated entity or facility. (EnforcementActionIdentifier)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_ACT_DATE" IS 'The calendar date the enforcement action was issued or filed. (EnforcementActionDate)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_AGN_NAME" IS 'The full name of the agency, department, or organization that submitted the enforcement action data to EPA. (EnforcementAgencyName)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_DOCKET_NUM" IS 'Notes the relevant docket number which enforcement staff have assigned for tracking of enforcement actions. (EnforcementDocketNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_ATTRY" IS 'Identifies the attorney within the agency responsible for issuing the enforcement action. (EnforcementAttorney)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."CORCT_ACT_COMPT" IS 'Parent: Compliance Monitoring and Enforcement Data (CorrectiveActionComponent)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."CNST_AGMT_FINAL_ORDER_SEQ_NUM" IS 'Parent: Compliance Monitoring and Enforcement Data (ConsentAgreementFinalOrderSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."APPEAL_INIT_DATE" IS 'Parent: Compliance Monitoring and Enforcement Data (AppealInitiatedDate)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."APPEAL_RSLN_DATE" IS 'Parent: Compliance Monitoring and Enforcement Data (AppealResolutionDate)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."DISP_STAT_DATE" IS 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusDate)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."DISP_STAT_OWNER" IS 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."DISP_STAT" IS 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatus)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_OWNER" IS 'State Postal Code (EnforcementOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_TYPE" IS 'A code that identifies the type of action being taken against a handler. (EnforcementType)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_RESP_PERSON_OWNER" IS 'Indicates the agency that defines the person identifier. (EnforcementResponsiblePersonOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_RESP_PERSON_IDEN" IS 'Code indicating the person within the agency responsible for conducting the enforcement. (EnforcementResponsiblePersonIdentifier)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_RESP_SUBORG_OWNER" IS 'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganizationOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."ENFRC_RESP_SUBORG" IS 'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganization)';
 
   COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Data (Notes)';

	 COMMENT ON COLUMN "RCRA_CME_ENFRC_ACT"."FA_REQUIRED" IS 'Whether financial responsibility is required. (FinancialAssuranceReqD)';

   COMMENT ON TABLE "RCRA_CME_ENFRC_ACT"  IS 'Schema element: EnforcementActionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_EVAL" 
   (	"CME_EVAL_ID" VARCHAR2(40), 
	"CME_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"EVAL_ACT_LOC" VARCHAR2(255), 
	"EVAL_IDEN" VARCHAR2(50), 
	"EVAL_START_DATE" DATE, 
	"EVAL_RESP_AGN" VARCHAR2(255), 
	"DAY_ZERO" DATE, 
	"FOUND_VIOL" VARCHAR2(255), 
	"CTZN_CPLT_IND" VARCHAR2(50), 
	"MULTIMEDIA_IND" VARCHAR2(50), 
	"SAMPL_IND" VARCHAR2(50), 
	"NOT_SUBTL_C_IND" VARCHAR2(50), 
	"EVAL_TYPE_OWNER" VARCHAR2(255), 
	"EVAL_TYPE" VARCHAR2(255), 
	"FOCUS_AREA_OWNER" VARCHAR2(255), 
	"FOCUS_AREA" VARCHAR2(255), 
	"EVAL_RESP_PERSON_IDEN_OWNER" VARCHAR2(255), 
	"EVAL_RESP_PERSON_IDEN" VARCHAR2(50), 
	"EVAL_RESP_SUBORG_OWNER" VARCHAR2(255), 
	"EVAL_RESP_SUBORG" VARCHAR2(255), 
	"NOTES" VARCHAR2(2000),
	"NOC_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_EVAL"."CME_EVAL_ID" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."CME_FAC_SUBM_ID" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_ACT_LOC" IS 'Indicates the location of the agency regulating the EPA handler. (EvaluationActivityLocation)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_IDEN" IS 'Name or number assigned by the implementing agency to identify an evaluation. (EvaluationIdentifier)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_START_DATE" IS 'The first day of the inspection or record review regardless of the duration of the inspection. (EvaluationStartDate)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_RESP_AGN" IS 'Code indicating the agency responsible for conducting the evaluation. (EvaluationResponsibleAgency)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."DAY_ZERO" IS 'Date fo the Last Non-Followup Evaluation (Applies to SNY/SNN Evaluations Only) (DayZero)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."FOUND_VIOL" IS 'Flag indicating if a violation was found. (FoundViolation)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."CTZN_CPLT_IND" IS 'The inspection or record review was initiated because of a tip/complaint (CitizenComplaintIndicator)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."MULTIMEDIA_IND" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (MultimediaIndicator)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."SAMPL_IND" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (SamplingIndicator)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."NOT_SUBTL_C_IND" IS 'The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniation made: sit is Non-Hazardous Waste. (NotSubtitleCIndicator)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_TYPE_OWNER" IS 'Indicates the agency that defines the type of evaluation. (EvaluationTypeOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_TYPE" IS 'Code to report the type of evaluation conducted at the handler. (EvaluationType)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."FOCUS_AREA_OWNER" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusAreaOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."FOCUS_AREA" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusArea)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_RESP_PERSON_IDEN_OWNER" IS 'Indicates the agency that defines the person identifier. (EvaluationResponsiblePersonIdentifierOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_RESP_PERSON_IDEN" IS 'Code indicating the person within the agency responsible for conducting the evaluation. (EvaluationResponsiblePersonIdentifier)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_RESP_SUBORG_OWNER" IS 'Indicates the agency that defines the suborganization identifier. (EvaluationResponsibleSuborganizationOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."EVAL_RESP_SUBORG" IS 'Code indicating the branch/district within the agency responsible for conducting the evaluation. (EvaluationResponsibleSuborganization)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Evaluation Data (Notes)';

	 COMMENT ON COLUMN "RCRA_CME_EVAL"."NOC_DATE" IS 'NOC Date. (NOCDate)';

   COMMENT ON TABLE "RCRA_CME_EVAL"  IS 'Schema element: EvaluationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_EVAL_COMMIT" 
   (	"CME_EVAL_COMMIT_ID" VARCHAR2(40), 
	"CME_EVAL_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"COMMIT_LEAD" VARCHAR2(255), 
	"COMMIT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_EVAL_COMMIT"."CME_EVAL_COMMIT_ID" IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_COMMIT"."CME_EVAL_ID" IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_COMMIT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_COMMIT"."COMMIT_LEAD" IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentLead)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_COMMIT"."COMMIT_SEQ_NUM" IS 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_CME_EVAL_COMMIT"  IS 'Schema element: EvaluationCommitmentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_EVAL_VIOL" 
   (	"CME_EVAL_VIOL_ID" VARCHAR2(40), 
	"CME_EVAL_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"VIOL_ACT_LOC" VARCHAR2(255), 
	"VIOL_SEQ_NUM" NUMBER(10,0), 
	"AGN_WHICH_DTRM_VIOL" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_EVAL_VIOL"."CME_EVAL_VIOL_ID" IS 'Parent: Linking Data for Evaluation and Violation (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_VIOL"."CME_EVAL_ID" IS 'Parent: Linking Data for Evaluation and Violation (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_VIOL"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_VIOL"."VIOL_ACT_LOC" IS 'Parent: Linking Data for Evaluation and Violation (ViolationActivityLocation)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_VIOL"."VIOL_SEQ_NUM" IS 'Parent: Linking Data for Evaluation and Violation (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_EVAL_VIOL"."AGN_WHICH_DTRM_VIOL" IS 'Parent: Linking Data for Evaluation and Violation (AgencyWhichDeterminedViolation)';
 
   COMMENT ON TABLE "RCRA_CME_EVAL_VIOL"  IS 'Schema element: EvaluationViolationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_FAC_SUBM" 
   (	"CME_FAC_SUBM_ID" VARCHAR2(40), 
	"CME_SUBM_ID" VARCHAR2(40), 
	"EPA_HDLR_ID" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_FAC_SUBM"."CME_FAC_SUBM_ID" IS 'Parent: This contains Hbasic Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_FAC_SUBM"."CME_SUBM_ID" IS 'Parent: This contains Hbasic Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_FAC_SUBM"."EPA_HDLR_ID" IS 'Number that uniquely identifies the EPA handler. (EPAHandlerID)';
 
   COMMENT ON TABLE "RCRA_CME_FAC_SUBM"  IS 'Schema element: CMEFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_MEDIA
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_MEDIA" 
   (	"CME_MEDIA_ID" VARCHAR2(40), 
	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"MULTIMEDIA_CODE_OWNER" VARCHAR2(255), 
	"MULTIMEDIA_CODE" VARCHAR2(50), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_MEDIA"."CME_MEDIA_ID" IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_MEDIA"."CME_ENFRC_ACT_ID" IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_MEDIA"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_MEDIA"."MULTIMEDIA_CODE_OWNER" IS 'Indicates the agency that defines the multimedia code. (MultimediaCodeOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_MEDIA"."MULTIMEDIA_CODE" IS 'Code which indicates the medium or program other than RCRA participating in the enforcement action. (MultimediaCode)';
 
   COMMENT ON COLUMN "RCRA_CME_MEDIA"."NOTES" IS 'Parent: Compliance Monitoring and Enfocement Multimedia Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_MEDIA"  IS 'Schema element: MediaDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_MILESTONE" 
   (	"CME_MILESTONE_ID" VARCHAR2(40), 
	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"MILESTONE_SEQ_NUM" NUMBER(10,0), 
	"TECH_RQMT_IDEN" VARCHAR2(50), 
	"TECH_RQMT_DESC" VARCHAR2(255), 
	"MILESTONE_SCHD_COMP_DATE" DATE, 
	"MILESTONE_ACTL_COMP_DATE" DATE, 
	"MILESTONE_DFLT_DATE" DATE, 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."CME_MILESTONE_ID" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."CME_ENFRC_ACT_ID" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."MILESTONE_SEQ_NUM" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."TECH_RQMT_IDEN" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementIdentifier)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."TECH_RQMT_DESC" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementDescription)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."MILESTONE_SCHD_COMP_DATE" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneScheduledCompletionDate)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."MILESTONE_ACTL_COMP_DATE" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneActualCompletionDate)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."MILESTONE_DFLT_DATE" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneDefaultedDate)';
 
   COMMENT ON COLUMN "RCRA_CME_MILESTONE"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Milestone Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_MILESTONE"  IS 'Schema element: MilestoneDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_PNLTY
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_PNLTY" 
   (	"CME_PNLTY_ID" VARCHAR2(40), 
	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"PNLTY_TYPE_OWNER" VARCHAR2(255), 
	"PNLTY_TYPE" VARCHAR2(255), 
	"CASH_CIVIL_PNLTY_SOUGHT_AMOUNT" NUMBER(13,2), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_PNLTY"."CME_PNLTY_ID" IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_PNLTY"."CME_ENFRC_ACT_ID" IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_PNLTY"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_PNLTY"."PNLTY_TYPE_OWNER" IS 'Indicates the agency that defines the penalty type (PenaltyTypeOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_PNLTY"."PNLTY_TYPE" IS 'Code which indicates the type of penalty associated with the penalty amount. (PenaltyType)';
 
   COMMENT ON COLUMN "RCRA_CME_PNLTY"."CASH_CIVIL_PNLTY_SOUGHT_AMOUNT" IS 'The dollar amount of any proposed cash civil penalty set forth in a Complaint/Proposed Order. (CashCivilPenaltySoughtAmount)';
 
   COMMENT ON COLUMN "RCRA_CME_PNLTY"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Penalty Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_PNLTY"  IS 'Schema element: PenaltyDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_PYMT
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_PYMT" 
   (	"CME_PYMT_ID" VARCHAR2(40), 
	"CME_PNLTY_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"PYMT_SEQ_NUM" NUMBER(10,0), 
	"PYMT_DFLT_DATE" DATE, 
	"SCHD_PYMT_DATE" DATE, 
	"SCHD_PYMT_AMOUNT" NUMBER(13,2), 
	"ACTL_PYMT_DATE" DATE, 
	"ACTL_PAID_AMOUNT" NUMBER(13,2), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_PYMT"."CME_PYMT_ID" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."CME_PNLTY_ID" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."PYMT_SEQ_NUM" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."PYMT_DFLT_DATE" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentDefaultedDate)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."SCHD_PYMT_DATE" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentDate)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."SCHD_PYMT_AMOUNT" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentAmount)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."ACTL_PYMT_DATE" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (ActualPaymentDate)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."ACTL_PAID_AMOUNT" IS 'The dollar amount of any cost recovery required to be paid pursuant to a Final Order. (ActualPaidAmount)';
 
   COMMENT ON COLUMN "RCRA_CME_PYMT"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Payment Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_PYMT"  IS 'Schema element: PaymentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_RQST
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_RQST" 
   (	"CME_RQST_ID" VARCHAR2(40), 
	"CME_EVAL_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"RQST_SEQ_NUM" NUMBER(10,0), 
	"DATE_OF_RQST" DATE, 
	"DATE_RESP_RCVD" DATE, 
	"RQST_AGN" VARCHAR2(255), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_RQST"."CME_RQST_ID" IS 'Parent: Compliance Monitoring and Enforcement Request Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."CME_EVAL_ID" IS 'Parent: Compliance Monitoring and Enforcement Request Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."RQST_SEQ_NUM" IS 'Parent: Compliance Monitoring and Enforcement Request Data (RequestSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."DATE_OF_RQST" IS 'Parent: Compliance Monitoring and Enforcement Request Data (DateOfRequest)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."DATE_RESP_RCVD" IS 'Parent: Compliance Monitoring and Enforcement Request Data (DateResponseReceived)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."RQST_AGN" IS 'Parent: Compliance Monitoring and Enforcement Request Data (RequestAgency)';
 
   COMMENT ON COLUMN "RCRA_CME_RQST"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Request Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_RQST"  IS 'Schema element: RequestDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_SUBM" 
   (	"CME_SUBM_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE "RCRA_CME_SUBM"  IS 'Schema element: HazardousWasteCMESubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_SUPP_ENVR_PRJT" 
   (	"CME_SUPP_ENVR_PRJT_ID" VARCHAR2(40), 
	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"SEP_SEQ_NUM" NUMBER(10,0), 
	"SEP_EXPND_AMOUNT" NUMBER(13,2), 
	"SEP_SCHD_COMP_DATE" DATE, 
	"SEP_ACTL_DATE" DATE, 
	"SEP_DFLT_DATE" DATE, 
	"SEP_CODE_OWNER" VARCHAR2(255), 
	"SEP_DESC_TXT" VARCHAR2(255), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."CME_SUPP_ENVR_PRJT_ID" IS 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."CME_ENFRC_ACT_ID" IS 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_SEQ_NUM" IS 'SEP Sequence Number allowed value 01-99 (SEPSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_EXPND_AMOUNT" IS 'Expenditure Amount (SEPExpenditureAmount)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_SCHD_COMP_DATE" IS 'Valid date greater than or equal to the Date of Enforcement Action. (SEPScheduledCompletionDate)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_ACTL_DATE" IS 'SEP actual completion date (SEPActualDate)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_DFLT_DATE" IS 'Date the SEP defaulted (SEPDefaultedDate)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_CODE_OWNER" IS 'State postal code (SEPCodeOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."SEP_DESC_TXT" IS 'The narrative text describing any Supplemental Environmental Projects required to be performed pursuant to a Final Order. (SEPDescriptionText)';
 
   COMMENT ON COLUMN "RCRA_CME_SUPP_ENVR_PRJT"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_SUPP_ENVR_PRJT"  IS 'Schema element: SupplementalEnvironmentalProjectDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_VIOL
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_VIOL" 
   (	"CME_VIOL_ID" VARCHAR2(40), 
	"CME_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"VIOL_ACT_LOC" VARCHAR2(255), 
	"VIOL_SEQ_NUM" NUMBER(10,0), 
	"AGN_WHICH_DTRM_VIOL" VARCHAR2(255), 
	"VIOL_TYPE_OWNER" VARCHAR2(255), 
	"VIOL_TYPE" VARCHAR2(255), 
	"FORMER_CITATION_NAME" VARCHAR2(128), 
	"VIOL_DTRM_DATE" DATE, 
	"RTN_COMPL_ACTL_DATE" DATE, 
	"RTN_TO_COMPL_QUAL" VARCHAR2(255), 
	"VIOL_RESP_AGN" VARCHAR2(255), 
	"NOTES" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_VIOL"."CME_VIOL_ID" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."CME_FAC_SUBM_ID" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."VIOL_ACT_LOC" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationActivityLocation)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."VIOL_SEQ_NUM" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."AGN_WHICH_DTRM_VIOL" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (AgencyWhichDeterminedViolation)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."VIOL_TYPE_OWNER" IS 'Allowed value HQ (ViolationTypeOwner)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."VIOL_TYPE" IS 'Violation Type (ViolationType)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."FORMER_CITATION_NAME" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (FormerCitationName)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."VIOL_DTRM_DATE" IS 'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation. (ViolationDeterminedDate)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."RTN_COMPL_ACTL_DATE" IS 'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceActualDate)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."RTN_TO_COMPL_QUAL" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ReturnToComplianceQualifier)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."VIOL_RESP_AGN" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationResponsibleAgency)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL"."NOTES" IS 'Parent: Compliance Monitoring and Enforcement Violation Data (Notes)';
 
   COMMENT ON TABLE "RCRA_CME_VIOL"  IS 'Schema element: ViolationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  CREATE TABLE "RCRA_CME_VIOL_ENFRC" 
   (	"CME_VIOL_ENFRC_ID" VARCHAR2(40), 
	"CME_ENFRC_ACT_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"VIOL_SEQ_NUM" NUMBER(10,0), 
	"AGN_WHICH_DTRM_VIOL" VARCHAR2(255), 
	"RTN_COMPL_SCHD_DATE" DATE
   ) ;
 

   COMMENT ON COLUMN "RCRA_CME_VIOL_ENFRC"."CME_VIOL_ENFRC_ID" IS 'Parent: Linking Data for Violation and Enforcement (_PK)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL_ENFRC"."CME_ENFRC_ACT_ID" IS 'Parent: Linking Data for Violation and Enforcement (_FK)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL_ENFRC"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL_ENFRC"."VIOL_SEQ_NUM" IS 'Parent: Linking Data for Violation and Enforcement (ViolationSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL_ENFRC"."AGN_WHICH_DTRM_VIOL" IS 'Parent: Linking Data for Violation and Enforcement (AgencyWhichDeterminedViolation)';
 
   COMMENT ON COLUMN "RCRA_CME_VIOL_ENFRC"."RTN_COMPL_SCHD_DATE" IS 'The calendar date, specified in the Compliance Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)';
 
   COMMENT ON TABLE "RCRA_CME_VIOL_ENFRC"  IS 'Schema element: ViolationEnforcementDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_COST_EST
--------------------------------------------------------

  CREATE TABLE "RCRA_FA_COST_EST" 
   (	"FA_COST_EST_ID" VARCHAR2(40), 
	"FA_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"COST_ESTIMATE_TYPE_CODE" CHAR(1), 
	"COST_ESTIMATE_AGN_CODE" CHAR(1), 
	"COST_ESTIMATE_SEQ_NUM" NUMBER(10,0), 
	"RESP_PERSON_DATA_OWNER_CODE" CHAR(2), 
	"RESP_PERSON_ID" VARCHAR2(5), 
	"COST_ESTIMATE_AMOUNT" NUMBER(13,2), 
	"COST_ESTIMATE_DATE" DATE, 
	"COST_ESTIMATE_RSN_CODE" CHAR(1), 
	"AREA_UNIT_NOTES_TXT" VARCHAR2(240), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_FA_COST_EST"."FA_COST_EST_ID" IS 'Parent: Estimates of the Financial liability costs associated with a given Handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."FA_FAC_SUBM_ID" IS 'Parent: Estimates of the Financial liability costs associated with a given Handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."COST_ESTIMATE_TYPE_CODE" IS 'Indicates what type of Financial Assurance is Required. (CostEstimateTypeCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."COST_ESTIMATE_AGN_CODE" IS 'Code indicating the agency responsible for overseeing the review of the cost estimate. (CostEstimateAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."COST_ESTIMATE_SEQ_NUM" IS 'Unique number that identifies the cost estimate. (CostEstimateSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."RESP_PERSON_DATA_OWNER_CODE" IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."RESP_PERSON_ID" IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."COST_ESTIMATE_AMOUNT" IS 'The dollar amount of the cost estimate for a given financial assurance type. (CostEstimateAmount)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."COST_ESTIMATE_DATE" IS 'The date when the cost estimate for a given financial assurance type was submitted, adjusted, approved, or required to be in place. (CostEstimateDate)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."COST_ESTIMATE_RSN_CODE" IS 'The reason the cost estimate for a financial assurance type is being reported. (CostEstimateReasonCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."AREA_UNIT_NOTES_TXT" IS 'Notes regarding the corrective action area or permit unit that this cost estimate applies. (AreaUnitNotesText)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_FA_COST_EST"  IS 'Schema element: CostEstimateDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_COST_EST_REL_MECHANISM
--------------------------------------------------------

  CREATE TABLE "RCRA_FA_COST_EST_REL_MECHANISM" 
   (	"FA_COST_EST_REL_MECHANISM_ID" VARCHAR2(40), 
	"FA_COST_EST_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"MECHANISM_AGN_CODE" CHAR(1), 
	"MECHANISM_SEQ_NUM" NUMBER(10,0), 
	"MECHANISM_DETAIL_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."FA_COST_EST_REL_MECHANISM_ID" IS 'Parent: Linking Data for Cost Estimates and Related Mechanisms (_PK)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."FA_COST_EST_ID" IS 'Parent: Linking Data for Cost Estimates and Related Mechanisms (_FK)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."MECHANISM_AGN_CODE" IS 'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."MECHANISM_SEQ_NUM" IS 'Unique numerical identier for the mechanism. (MechanismSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_FA_COST_EST_REL_MECHANISM"."MECHANISM_DETAIL_SEQ_NUM" IS 'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_FA_COST_EST_REL_MECHANISM"  IS 'Schema element: CostEstimateRelatedMechanismDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_FA_FAC_SUBM" 
   (	"FA_FAC_SUBM_ID" VARCHAR2(40), 
	"FA_SUBM_ID" VARCHAR2(40), 
	"HANDLER_ID" VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN "RCRA_FA_FAC_SUBM"."FA_FAC_SUBM_ID" IS 'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_FA_FAC_SUBM"."FA_SUBM_ID" IS 'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_FA_FAC_SUBM"."HANDLER_ID" IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE "RCRA_FA_FAC_SUBM"  IS 'Schema element: FinancialAssuranceFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_MECHANISM
--------------------------------------------------------

  CREATE TABLE "RCRA_FA_MECHANISM" 
   (	"FA_MECHANISM_ID" VARCHAR2(40), 
	"FA_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"MECHANISM_AGN_CODE" CHAR(1), 
	"MECHANISM_SEQ_NUM" NUMBER(10,0), 
	"MECHANISM_TYPE_DATA_OWNER_CODE" CHAR(2), 
	"MECHANISM_TYPE_CODE" CHAR(1), 
	"PROVIDER_TXT" VARCHAR2(80), 
	"PROVIDER_FULL_CONTACT_NAME" VARCHAR2(33), 
	"TELE_NUM_TXT" VARCHAR2(15), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."FA_MECHANISM_ID" IS 'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."FA_FAC_SUBM_ID" IS 'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."MECHANISM_AGN_CODE" IS 'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."MECHANISM_SEQ_NUM" IS 'Unique numerical identier for the mechanism. (MechanismSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."MECHANISM_TYPE_DATA_OWNER_CODE" IS 'Indicates the agency that defined the mechanism type. (MechanismTypeDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."MECHANISM_TYPE_CODE" IS 'The type of mechanism that addresses the cost estimate. (MechanismTypeCode)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."PROVIDER_TXT" IS 'The name of the financial institution with which the financial assurance mechanism is held, such as a bank (letter of credit) or a surety (surety bond); also identifies a facility (financial test), or a guarantor (corporate guarantee). (ProviderText)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."PROVIDER_FULL_CONTACT_NAME" IS 'Contact Name of the provider. (ProviderFullContactName)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."TELE_NUM_TXT" IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_FA_MECHANISM"  IS 'Schema element: MechanismDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_MECHANISM_DETAIL
--------------------------------------------------------

  CREATE TABLE "RCRA_FA_MECHANISM_DETAIL" 
   (	"FA_MECHANISM_DETAIL_ID" VARCHAR2(40), 
	"FA_MECHANISM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"MECHANISM_DETAIL_SEQ_NUM" NUMBER(10,0), 
	"MECHANISM_IDEN_TXT" VARCHAR2(40), 
	"FACE_VAL_AMOUNT" NUMBER(13,2), 
	"EFFC_DATE" DATE, 
	"EXPIRATION_DATE" DATE, 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."FA_MECHANISM_DETAIL_ID" IS 'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."FA_MECHANISM_ID" IS 'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."MECHANISM_DETAIL_SEQ_NUM" IS 'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."MECHANISM_IDEN_TXT" IS 'The number assigned to the mechanism, such as a bond number or insurance policy number. (MechanismIdentificationText)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."FACE_VAL_AMOUNT" IS 'The total dollar value of the financial assurance mechanism. (FaceValueAmount)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."EFFC_DATE" IS 'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."EXPIRATION_DATE" IS 'The date the instrument terminates, such as the end of the term of an insurance policy. (ExpirationDate)';
 
   COMMENT ON COLUMN "RCRA_FA_MECHANISM_DETAIL"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_FA_MECHANISM_DETAIL"  IS 'Schema element: MechanismDetailDataType';
--------------------------------------------------------
--  DDL for Table RCRA_FA_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_FA_SUBM" 
   (	"FA_SUBM_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE "RCRA_FA_SUBM"  IS 'Schema element: FinancialAssuranceSubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_GIS_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_GIS_FAC_SUBM" 
   (	"GIS_FAC_SUBM_ID" VARCHAR2(40), 
	"GIS_SUBM_ID" VARCHAR2(40), 
	"HANDLER_ID" VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN "RCRA_GIS_FAC_SUBM"."GIS_FAC_SUBM_ID" IS 'Parent: Supplies all of the relevant GIS Data for a given Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_GIS_FAC_SUBM"."GIS_SUBM_ID" IS 'Parent: Supplies all of the relevant GIS Data for a given Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_GIS_FAC_SUBM"."HANDLER_ID" IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE "RCRA_GIS_FAC_SUBM"  IS 'Schema element: GISFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_GIS_GEO_INFORMATION
--------------------------------------------------------

  CREATE TABLE "RCRA_GIS_GEO_INFORMATION" 
   (	"GIS_GEO_INFORMATION_ID" VARCHAR2(40), 
	"GIS_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"GEO_INFO_OWNER" CHAR(2), 
	"GEO_INFO_SEQ_NUM" NUMBER(10,0), 
	"PERMIT_UNIT_SEQ_NUM" NUMBER(10,0), 
	"AREA_SEQ_NUM" NUMBER(10,0), 
	"LOC_COMM_TXT" VARCHAR2(2000), 
	"AREA_ACREAGE_MEAS" NUMBER(13,2), 
	"AREA_MEAS_SRC_DATA_OWNER_CODE" CHAR(2), 
	"AREA_MEAS_SRC_CODE" VARCHAR2(8), 
	"AREA_MEAS_DATE" DATE, 
	"DATA_COLL_DATE" DATE, 
	"HORZ_ACC_MEAS" NUMBER(10,0), 
	"SRC_MAP_SCALE_NUM" NUMBER(10,0), 
	"COORD_DATA_SRC_DATA_OWNER_CODE" CHAR(2), 
	"COORD_DATA_SRC_CODE" VARCHAR2(3), 
	"GEO_REF_PT_DATA_OWNER_CODE" CHAR(2), 
	"GEO_REF_PT_CODE" VARCHAR2(3), 
	"GEOM_TYPE_DATA_OWNER_CODE" CHAR(2), 
	"GEOM_TYPE_CODE" VARCHAR2(3), 
	"HORZ_COLL_METH_DATA_OWNER_CODE" CHAR(2), 
	"HORZ_COLL_METH_CODE" VARCHAR2(3), 
	"HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE" CHAR(2), 
	"HORZ_COORD_REF_SYS_DATUM_CODE" VARCHAR2(3), 
	"VERF_METH_DATA_OWNER_CODE" CHAR(2), 
	"VERF_METH_CODE" VARCHAR2(3), 
	"LATITUDE" NUMBER(19,14), 
	"LONGITUDE" NUMBER(19,14), 
	"ELEVATION" NUMBER(19,14)
   ) ;
 

   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GIS_GEO_INFORMATION_ID" IS 'Parent: Used to define the geographic coordinates of the Handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GIS_FAC_SUBM_ID" IS 'Parent: Used to define the geographic coordinates of the Handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GEO_INFO_OWNER" IS 'Owner of Geographic Information.  Should match state code (i.e. KS). (GeographicInformationOwner)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GEO_INFO_SEQ_NUM" IS 'Unique identifier for the geographic information. (GeographicInformationSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."PERMIT_UNIT_SEQ_NUM" IS 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."AREA_SEQ_NUM" IS 'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."LOC_COMM_TXT" IS 'The text that provides additional informaiton about the geographic coordinates. (LocationCommentsText)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."AREA_ACREAGE_MEAS" IS 'The number of acres associated with the handler or area. (AreaAcreageMeasure)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."AREA_MEAS_SRC_DATA_OWNER_CODE" IS 'Indicates the agency that defined the AreaMeasureSource. (AreaMeasureSourceDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."AREA_MEAS_SRC_CODE" IS 'The source of information used to determine the number of acres associated with the handler or area. (AreaMeasureSourceCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."AREA_MEAS_DATE" IS 'The date acreage information for the handler or area was collected. (AreaMeasureDate)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."DATA_COLL_DATE" IS 'The calender date when data were collected (DataCollectionDate)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."HORZ_ACC_MEAS" IS 'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."SRC_MAP_SCALE_NUM" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumeric)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."COORD_DATA_SRC_DATA_OWNER_CODE" IS 'The owner of the code.  If provided, it should be HQ. (CoordinateDataSourceDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."COORD_DATA_SRC_CODE" IS 'The code that represents the party responsible for proiding the latitude and longitude coordinates. (CoordinateDataSourceCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GEO_REF_PT_DATA_OWNER_CODE" IS 'The owner of the code.  If provided, it should be HQ. (GeographicReferencePointDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GEO_REF_PT_CODE" IS 'The code that represents the place for which the geographic codes were established (GeographicReferencePointCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GEOM_TYPE_DATA_OWNER_CODE" IS 'The owner of the code.  If provided, it should be HQ. (GeometricTypeDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."GEOM_TYPE_CODE" IS 'The code that represents the geometric entity represented by one point or a sequence of points (GeometricTypeCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."HORZ_COLL_METH_DATA_OWNER_CODE" IS 'The owner of the code.  If provided, it should be HQ. (HorizontalCollectionMethodDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."HORZ_COLL_METH_CODE" IS 'The code that represents the method used to deterimine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE" IS 'The owner of the code.  If provided, it should be HQ. (HorizontalCoordinateReferenceSystemDatumDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."HORZ_COORD_REF_SYS_DATUM_CODE" IS 'The code that represents the datum used in determining latitude and longitude coordinates (HorizontalCoordinateReferenceSystemDatumCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."VERF_METH_DATA_OWNER_CODE" IS 'The owner of the code.  If provided, it should be HQ. (VerificationMethodDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."VERF_METH_CODE" IS 'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."LATITUDE" IS 'Parent: Geometry property element of a GeoRSS GML instance (Latitude)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."LONGITUDE" IS 'Parent: Geometry property element of a GeoRSS GML instance (Longitude)';
 
   COMMENT ON COLUMN "RCRA_GIS_GEO_INFORMATION"."ELEVATION" IS 'Parent: Geometry property element of a GeoRSS GML instance (Elevation)';
 
   COMMENT ON TABLE "RCRA_GIS_GEO_INFORMATION"  IS 'Schema element: GeographicInformationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_GIS_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_GIS_SUBM" 
   (	"GIS_SUBM_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE "RCRA_GIS_SUBM"  IS 'Schema element: GeographicInformationSubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_CERTIFICATION" 
   (	"HD_CERTIFICATION_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"CERT_SEQ" NUMBER(10,0), 
	"CERT_SIGNED_DATE" VARCHAR2(10), 
	"CERT_TITLE" VARCHAR2(45), 
	"CERT_FIRST_NAME" VARCHAR2(38), 
	"CERT_MIDDLE_INITIAL" CHAR(1), 
	"CERT_LAST_NAME" VARCHAR2(38),
    "CERT_EMAIL_TEXT" VARCHAR2(80)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."HD_CERTIFICATION_ID" IS 'Parent: Certification information for the person who certified report to the authorizing agency. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."HD_HANDLER_ID" IS 'Parent: Certification information for the person who certified report to the authorizing agency. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."CERT_SEQ" IS 'Sequence number for each certification for the handler. (CertificationSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."CERT_SIGNED_DATE" IS 'Date on which the handler information was certified by the reporting site. (SignedDate)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."CERT_TITLE" IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."CERT_FIRST_NAME" IS 'First name of a person. (FirstName)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."CERT_MIDDLE_INITIAL" IS 'Middle initial of a person. (MiddleInitial)';
 
   COMMENT ON COLUMN "RCRA_HD_CERTIFICATION"."CERT_LAST_NAME" IS 'Last name of a person. (LastName)';
 
   COMMENT ON TABLE "RCRA_HD_CERTIFICATION"  IS 'Schema element: CertificationDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_ENV_PERMIT" 
   (	"HD_ENV_PERMIT_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"ENV_PERMIT_NUMBER" VARCHAR2(13), 
	"ENV_PERMIT_OWNER" CHAR(2), 
	"ENV_PERMIT_TYPE" CHAR(1), 
	"ENV_PERMIT_DESC" VARCHAR2(80)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."HD_ENV_PERMIT_ID" IS 'Parent: Information about environmental permits issued to the handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."HD_HANDLER_ID" IS 'Parent: Information about environmental permits issued to the handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."ENV_PERMIT_NUMBER" IS 'Identification number of an effective environmental permit issued to the handler, or the number of a filed application for which an environmental permit has not yet been issued. (EnvironmentalPermitID)';
 
   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."ENV_PERMIT_OWNER" IS 'Indicates the agency that defines the other permit type. (EnvironmentalPermitOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."ENV_PERMIT_TYPE" IS 'Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only. (EnvironmentalPermitTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_ENV_PERMIT"."ENV_PERMIT_DESC" IS 'Description of any permit type indicated as O (Other) in the Permit Type field. (EnvironmentalPermitDescription)';
 
   COMMENT ON TABLE "RCRA_HD_ENV_PERMIT"  IS 'Schema element: EnvironmentalPermitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_HANDLER
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_HANDLER" 
   (	"HD_HANDLER_ID" VARCHAR2(40), 
	"HD_HBASIC_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"ACTIVITY_LOCATION" CHAR(2), 
	"SOURCE_TYPE" CHAR(1), 
	"SEQ_NUMBER" NUMBER(10,0), 
	"RECEIVE_DATE" VARCHAR2(10), 
	"HANDLER_NAME" VARCHAR2(80), 
	"ACKNOWLEDGE_DATE" VARCHAR2(10), 
	"NON_NOTIFIER" CHAR(1), 
	"TSD_DATE" VARCHAR2(10), 
	"OFF_SITE_RECEIPT" CHAR(1), 
	"ACCESSIBILITY" CHAR(1), 
	"COUNTY_CODE_OWNER" CHAR(2), 
	"COUNTY_CODE" VARCHAR2(5), 
	"NOTES" VARCHAR2(4000), 
	"ACKNOWLEDGE_FLAG" CHAR(1), 
	"LOCATION_STREET1" VARCHAR2(50), 
	"LOCATION_STREET2" VARCHAR2(50), 
	"LOCATION_CITY" VARCHAR2(25), 
	"LOCATION_STATE" CHAR(2), 
	"LOCATION_COUNTRY" CHAR(2), 
	"LOCATION_ZIP" VARCHAR2(14), 
	"MAIL_STREET1" VARCHAR2(50), 
	"MAIL_STREET2" VARCHAR2(50), 
	"MAIL_CITY" VARCHAR2(25), 
	"MAIL_STATE" CHAR(2), 
	"MAIL_COUNTRY" CHAR(2), 
	"MAIL_ZIP" VARCHAR2(14), 
	"CONTACT_FIRST_NAME" VARCHAR2(38), 
	"CONTACT_MIDDLE_INITIAL" CHAR(1), 
	"CONTACT_LAST_NAME" VARCHAR2(38), 
	"CONTACT_ORG_NAME" VARCHAR2(80), 
	"CONTACT_TITLE" VARCHAR2(80), 
	"CONTACT_EMAIL_ADDRESS" VARCHAR2(80), 
	"CONTACT_PHONE" VARCHAR2(15), 
	"CONTACT_PHONE_EXT" VARCHAR2(6), 
	"CONTACT_FAX" VARCHAR2(15), 
    "CONTACT_STREET_NUMBER" VARCHAR2(12), 
	"CONTACT_STREET1" VARCHAR2(50), 
	"CONTACT_STREET2" VARCHAR2(50), 
	"CONTACT_CITY" VARCHAR2(25), 
	"CONTACT_STATE" CHAR(2), 
	"CONTACT_COUNTRY" CHAR(2), 
	"CONTACT_ZIP" VARCHAR2(14), 
	"PCONTACT_FIRST_NAME" VARCHAR2(38), 
	"PCONTACT_MIDDLE_NAME" CHAR(1), 
	"PCONTACT_LAST_NAME" VARCHAR2(38), 
	"PCONTACT_ORG_NAME" VARCHAR2(80), 
	"PCONTACT_TITLE" VARCHAR2(80), 
	"PCONTACT_EMAIL_ADDRESS" VARCHAR2(80), 
	"PCONTACT_PHONE" VARCHAR2(15), 
	"PCONTACT_PHONE_EXT" VARCHAR2(6), 
	"PCONTACT_FAX" VARCHAR2(15), 
    "PCONTACT_STREET_NUMBER" VARCHAR2(12), 
	"PCONTACT_STREET1" VARCHAR2(50), 
	"PCONTACT_STREET2" VARCHAR2(50), 
	"PCONTACT_CITY" VARCHAR2(25), 
	"PCONTACT_STATE" CHAR(2), 
	"PCONTACT_COUNTRY" CHAR(2), 
	"PCONTACT_ZIP" VARCHAR2(14), 
	"USED_OIL_BURNER" CHAR(1), 
	"USED_OIL_PROCESSOR" CHAR(1), 
	"USED_OIL_REFINER" CHAR(1), 
	"USED_OIL_MARKET_BURNER" CHAR(1), 
	"USED_OIL_SPEC_MARKETER" CHAR(1), 
	"USED_OIL_TRANSFER_FACILITY" CHAR(1), 
	"USED_OIL_TRANSPORTER" CHAR(1), 
	"LAND_TYPE" CHAR(1), 
	"STATE_DISTRICT_OWNER" CHAR(2), 
	"STATE_DISTRICT" VARCHAR2(10), 
	"IMPORTER_ACTIVITY" CHAR(1), 
	"MIXED_WASTE_GENERATOR" CHAR(1), 
	"RECYCLER_ACTIVITY" CHAR(1), 
	"TRANSPORTER_ACTIVITY" CHAR(1), 
	"TSD_ACTIVITY" CHAR(1), 
	"UNDERGROUND_INJECTION_ACTIVITY" CHAR(1), 
	"UNIVERSAL_WASTE_DEST_FACILITY" CHAR(1), 
	"ONSITE_BURNER_EXEMPTION" CHAR(1), 
	"FURNACE_EXEMPTION" CHAR(1), 
	"SHORT_TERM_GEN_IND"  CHAR(1), 
	"TRANSFER_FACILITY_IND"  CHAR(1), 
	"STATE_WASTE_GENERATOR_OWNER" CHAR(2), 
	"STATE_WASTE_GENERATOR" CHAR(1), 
	"FED_WASTE_GENERATOR_OWNER" CHAR(2), 
	"FED_WASTE_GENERATOR" CHAR(1), 
	"COLLEGE_IND" CHAR(1), 
	"HOSPITAL_IND" CHAR(1), 
	"NON_PROFIT_IND" CHAR(1), 
	"WITHDRAWAL_IND" CHAR(1), 
	"TRANS_CODE"  CHAR(1), 
	"NOTIFICATION_RSN_CODE" CHAR(1), 
	"EFFC_DATE" TIMESTAMP (6), 
	"FINANCIAL_ASSURANCE_IND" CHAR(1),
  --Added for v5.3
  "RECYCLING_IND" CHAR(1),
  "MAIL_STREET_NUMBER" VARCHAR2(12),
  "LOCATION_STREET_NUMBER" VARCHAR2(12),
  "NON_NOTIFIER_TEXT" VARCHAR2(255),
  "ACCESSIBILITY_TEXT" VARCHAR2(255),
  "STATE_DISTRICT_TEXT" VARCHAR2(255),
  --Added for v5.4
  "INTRNL_NOTES" VARCHAR2(4000),
  "SHORT_TERM_INTRNL_NOTES" VARCHAR2(4000),
  "NATURE_OF_BUSINESS_TEXT" VARCHAR2(4000),
	-- Added for v5.6
	"RECOGNIZED_TRADER_IMPORTER_IND" CHAR(1),
	"RECOGNIZED_TRADER_EXPORTER_IND" CHAR(1),
	"SLAB_IMPORTER_IND" CHAR(1),
	"SLAB_EXPORTER_IND" CHAR(1),
	"RECYCLER_ACT_NONSTORAGE" CHAR(1),
	"MANIFEST_BROKER" CHAR(1),
	"RECYCLER_NOTES" VARCHAR2(4000) NULL -- this was actually added in 5.4
   ) ;


   COMMENT ON COLUMN "RCRA_HD_HANDLER"."HD_HANDLER_ID" IS 'Parent: Top level of all information about the handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."HD_HBASIC_ID" IS 'Parent: Top level of all information about the handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."ACTIVITY_LOCATION" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."SOURCE_TYPE" IS 'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."SEQ_NUMBER" IS 'Sequence number for each source record about a handler. (SourceRecordSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECEIVE_DATE" IS 'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."HANDLER_NAME" IS 'Name of the Handler (HandlerName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."ACKNOWLEDGE_DATE" IS 'Date information was received for the handler. (AcknowledgeReceiptDate)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."NON_NOTIFIER" IS 'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."TSD_DATE" IS 'The date that operation of the facility commenced, the date construction on the facility commenced, or the date that operation is expected to begin. (TreatmentStorageDisposalDate)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."OFF_SITE_RECEIPT" IS 'Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status). (OffsiteWasteReceiptCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."ACCESSIBILITY" IS 'Code indicating the reason why the handler is not accessible for normal RCRA tracking and processing (previously called Bankrupt Indicator). (AccessibilityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."COUNTY_CODE_OWNER" IS 'Indicates the agency that defines the county code. (CountyCodeOwner)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."COUNTY_CODE" IS 'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."NOTES" IS 'Notes regarding the Handler. (HandlerSupplementalInformationText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."ACKNOWLEDGE_FLAG" IS 'Parent: Top level of all information about the handler. (AcknowledgeFlag)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_STREET1" IS 'Parent: Location address information. (LocationAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_STREET2" IS 'Parent: Location address information. (SupplementalLocationText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_CITY" IS 'Parent: Location address information. (LocalityName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_STATE" IS 'Parent: Location address information. (StateUSPSCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_COUNTRY" IS 'Parent: Location address information. (CountryName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_ZIP" IS 'Parent: Location address information. (LocationZIPCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_STREET1" IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_STREET2" IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_CITY" IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_STATE" IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_COUNTRY" IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_ZIP" IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_FIRST_NAME" IS 'Parent: Contact information. (FirstName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_MIDDLE_INITIAL" IS 'Parent: Contact information. (MiddleInitial)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_LAST_NAME" IS 'Parent: Contact information. (LastName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_ORG_NAME" IS 'Parent: Contact information. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_TITLE" IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_EMAIL_ADDRESS" IS 'Email address data (EmailAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_PHONE" IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_PHONE_EXT" IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_FAX" IS 'Contact fax number (FaxNumberText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_STREET_NUMBER" IS 'Contact Address Street Number';

   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_STREET1" IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_STREET2" IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_CITY" IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_STATE" IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_COUNTRY" IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."CONTACT_ZIP" IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_FIRST_NAME" IS 'Parent: Contact information. (FirstName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_MIDDLE_NAME" IS 'Parent: Contact information. (MiddleInitial)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_LAST_NAME" IS 'Parent: Contact information. (LastName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_ORG_NAME" IS 'Parent: Contact information. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_TITLE" IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_EMAIL_ADDRESS" IS 'Email address data (EmailAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_PHONE" IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_PHONE_EXT" IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_FAX" IS 'Contact fax number (FaxNumberText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_STREET_NUMBER" IS 'Permit Contact Address Street Number';

   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_STREET1" IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_STREET2" IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_CITY" IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_STATE" IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_COUNTRY" IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."PCONTACT_ZIP" IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_BURNER" IS 'Code indicating that the handler is engaged in the burning of used oil fuel. (FuelBurnerCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_PROCESSOR" IS 'Code indicating that the handler is engaged in processing used oil activities. (ProcessorCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_REFINER" IS 'Code indicating that the handler is engaged in re-refining used oil activities. (RefinerCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_MARKET_BURNER" IS 'Code indicating that the handler directs shipments of used oil to burners. (MarketBurnerCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_SPEC_MARKETER" IS 'Code indicating that the handler is a marketer who first claims the used oil meets the specifications. (SpecificationMarketerCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_TRANSFER_FACILITY" IS 'Code indicating that the handler owns or operates a used oil transfer facility. (TransferFacilityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."USED_OIL_TRANSPORTER" IS 'Code indicating that the handler is engaged in used oil transportation and/or transfer facility activities. (TransporterCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LAND_TYPE" IS 'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."STATE_DISTRICT_OWNER" IS 'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."STATE_DISTRICT" IS 'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."IMPORTER_ACTIVITY" IS 'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MIXED_WASTE_GENERATOR" IS 'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECYCLER_ACTIVITY" IS 'Code indicating that the handler is engaged in recycling hazardous waste. (RecyclerActivityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."TRANSPORTER_ACTIVITY" IS 'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."TSD_ACTIVITY" IS 'Code indicating that the handler is engaged in the treatment, storage, or disposal of hazardous waste. (TreatmentStorageDisposalActivityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."UNDERGROUND_INJECTION_ACTIVITY" IS 'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."UNIVERSAL_WASTE_DEST_FACILITY" IS 'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."ONSITE_BURNER_EXEMPTION" IS 'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."FURNACE_EXEMPTION" IS 'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."SHORT_TERM_GEN_IND" IS 'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."TRANSFER_FACILITY_IND" IS 'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."STATE_WASTE_GENERATOR_OWNER" IS 'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."STATE_WASTE_GENERATOR" IS 'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."FED_WASTE_GENERATOR_OWNER" IS 'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."FED_WASTE_GENERATOR" IS 'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."COLLEGE_IND" IS 'Indicates whether or not the Handler is a College or University opting into SubPart K. (CollegeIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."HOSPITAL_IND" IS 'Indicates whether or not the Handler is a Hospital opting into SubPart K. (HospitalIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."NON_PROFIT_IND" IS 'Indicates whether or not the Handler is a Non-Profit opting into SubPart K. (NonProfitIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."WITHDRAWAL_IND" IS 'Indicates whether or not the Handler is withdrawing from SubPart K. (WithdrawalIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."NOTIFICATION_RSN_CODE" IS 'Indicates the reason for notifying Hazardous Secondary Material (NotificationReasonCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."EFFC_DATE" IS 'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."FINANCIAL_ASSURANCE_IND" IS 'Indicates whether or not the facility has provided Financial Assurance for the HSM Activities (FinancialAssuranceIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECYCLING_IND" IS 'Indicates the facility has a recycling process which the product has levels of hazardous constituents that are not comparable to or unable to be compared to a legitimate product or intermediate but that the recycling is still legitimate';
   
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."MAIL_STREET_NUMBER" IS 'Mailing Address Street Number';
   
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."LOCATION_STREET_NUMBER" IS 'Location Address Street Number';
   
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."NON_NOTIFIER_TEXT" IS 'Descriptive text describing Notification source (Data publishing only)';

   COMMENT ON COLUMN "RCRA_HD_HANDLER"."ACCESSIBILITY_TEXT" IS 'Descriptive text describing reason facility is not accessible (Data publishing only)';
   
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."STATE_DISTRICT_TEXT" IS 'Descriptive text describing the code indicating the state-designated legislative district(s) in which the site is located (Data publishing only)';
   
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."INTRNL_NOTES" IS '(HandlerSupplementalInformationText)';
 
   COMMENT ON COLUMN "RCRA_HD_HANDLER"."SHORT_TERM_INTRNL_NOTES" IS '(ShortTermSupplementalInformationText)';

   COMMENT ON COLUMN "RCRA_HD_HANDLER"."NATURE_OF_BUSINESS_TEXT" IS 'Notes regarding Handler Part-A submissions. (NatureOfBusinessText)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECOGNIZED_TRADER_IMPORTER_IND" IS 'Indicates that the Handler is participating in Import Trading activity. (RecognizedTraderImporterIndicator)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECOGNIZED_TRADER_EXPORTER_IND" IS 'Indicates that the Handler is participating in Export Trading activity. (RecognizedTraderExporterIndicator)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."SLAB_IMPORTER_IND" IS 'Indicates that the Handler is participating in Slab Import activity. (SlabImporterIndicator)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."SLAB_EXPORTER_IND" IS 'Indicates that the Handler is participating in Slab Export activity. (SlabExporterIndicator)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECYCLER_ACT_NONSTORAGE" IS 'Identifies that Handler participates in Nonstorage Recycler Activity. (RecyclerActivityNonstorage)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."MANIFEST_BROKER" IS 'Identifies that Handler is ManifestBroker. (ManifestBroker)';

	 COMMENT ON COLUMN "RCRA_HD_HANDLER"."RECYCLER_NOTES" IS 'Notes for recycling hazardous waste. (RecyclerNotes)';

   COMMENT ON TABLE "RCRA_HD_HANDLER"  IS 'Schema element: HandlerDataType';

--------------------------------------------------------
--  DDL for Table RCRA_HD_HBASIC
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_HBASIC" 
   (	"HD_HBASIC_ID" VARCHAR2(40), 
	"HD_SUBM_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"HANDLER_ID" VARCHAR2(12), 
	"EXTRACT_FLAG" CHAR(1), 
	"FACILITY_IDENTIFIER" VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_HBASIC"."HD_HBASIC_ID" IS 'Parent: Details of facility submission. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_HBASIC"."HD_SUBM_ID" IS 'Parent: Details of facility submission. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_HBASIC"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_HBASIC"."HANDLER_ID" IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON COLUMN "RCRA_HD_HBASIC"."EXTRACT_FLAG" IS 'Designates that data is available for extract for public use. (PublicUseExtractIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_HBASIC"."FACILITY_IDENTIFIER" IS 'Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems. (FacilityRegistryID)';
 
   COMMENT ON TABLE "RCRA_HD_HBASIC"  IS 'Schema element: FacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_NAICS
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_NAICS" 
   (	"HD_NAICS_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"NAICS_SEQ" NUMBER(10,0), 
	"NAICS_OWNER" CHAR(2), 
	"NAICS_CODE" VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_NAICS"."HD_NAICS_ID" IS 'Parent: North American Industry Classification Status codes reported for the handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_NAICS"."HD_HANDLER_ID" IS 'Parent: North American Industry Classification Status codes reported for the handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_NAICS"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_NAICS"."NAICS_SEQ" IS 'Sequence number for each NAICS code for the handler. (NAICSSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_HD_NAICS"."NAICS_OWNER" IS 'Indicates the agency that defines the NAICS Code. (NAICSOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_HD_NAICS"."NAICS_CODE" IS 'The North American Industry Classification System Code that identifies the business activities of the facility. (NAICSCode)';
 
   COMMENT ON TABLE "RCRA_HD_NAICS"  IS 'Schema element: NAICSIdentityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_OTHER_ID" 
   (	"HD_OTHER_ID_ID" VARCHAR2(40), 
	"HD_HBASIC_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"OTHER_ID" VARCHAR2(12), 
	"RELATIONSHIP_OWNER" CHAR(2), 
	"RELATIONSHIP_TYPE" CHAR(1), 
	"SAME_FACILITY" CHAR(1), 
	"NOTES" VARCHAR2(4000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."HD_OTHER_ID_ID" IS 'Parent: Contains alternative identifiers for the facility. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."HD_HBASIC_ID" IS 'Parent: Contains alternative identifiers for the facility. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."OTHER_ID" IS 'Alternate facility identifier. (OtherHandlerID)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."RELATIONSHIP_OWNER" IS 'Indicates the agency that owns the Relationship. (RelationshipOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."RELATIONSHIP_TYPE" IS 'Indicates the type of the relationship. (RelationshipTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."SAME_FACILITY" IS 'Indicates whether the alternate Id references the same facility. (SameFacilityIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_OTHER_ID"."NOTES" IS 'Notes regarding the alternative facility identifier. (OtherIDSupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_HD_OTHER_ID"  IS 'Schema element: OtherIDDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_OWNEROP" 
   (	"HD_OWNEROP_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"OWNER_OP_SEQ" NUMBER(10,0), 
	"OWNER_OP_IND" CHAR(2), 
	"OWNER_OP_TYPE" CHAR(1), 
	"DATE_BECAME_CURRENT" VARCHAR2(10), 
	"DATE_ENDED_CURRENT" VARCHAR2(10), 
	"NOTES" VARCHAR2(4000),
	"FIRST_NAME" VARCHAR2(38), 
	"MIDDLE_INITIAL" CHAR(1), 
	"LAST_NAME" VARCHAR2(38), 
	"ORG_NAME" VARCHAR2(80), 
	"TITLE" VARCHAR2(80), 
	"EMAIL_ADDRESS" VARCHAR2(80), 
	"PHONE" VARCHAR2(15), 
	"PHONE_EXT" VARCHAR2(6), 
	"FAX" VARCHAR2(15), 
    "MAIL_ADDR_NUM_TXT" VARCHAR2(12), 
	"STREET1" VARCHAR2(50),
	"STREET2" VARCHAR2(50),
	"CITY" VARCHAR2(25), 
	"STATE" CHAR(2), 
	"COUNTRY" CHAR(2), 
	"ZIP" VARCHAR2(14)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."HD_OWNEROP_ID" IS 'Parent: Handler owner and operator information. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."HD_HANDLER_ID" IS 'Parent: Handler owner and operator information. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."OWNER_OP_SEQ" IS 'Sequential number used to order multiple occurrences of owners and operators. (OwnerOperatorSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."OWNER_OP_IND" IS 'Code indicating whether the data is associated with a current or previous owner or operator. The system will allow multiple current owners and operators. (OwnerOperatorIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."OWNER_OP_TYPE" IS 'Code indicating the owner/operator type. (OwnerOperatorTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."DATE_BECAME_CURRENT" IS 'Date indicating when the owner/operator became current. (CurrentStartDate)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."DATE_ENDED_CURRENT" IS 'Date indicating when the owner/operator changed to a different owner/operator. (CurrentEndDate)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."NOTES" IS 'Notes for the facility Owner Operator. (OwnerOperatorSupplementalInformationText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."FIRST_NAME" IS 'Parent: Contact information. (FirstName)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."MIDDLE_INITIAL" IS 'Parent: Contact information. (MiddleInitial)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."LAST_NAME" IS 'Parent: Contact information. (LastName)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."ORG_NAME" IS 'Parent: Contact information. (OrganizationFormalName)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."TITLE" IS 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."EMAIL_ADDRESS" IS 'Email address data (EmailAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."PHONE" IS 'Telephone Number data (TelephoneNumberText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."PHONE_EXT" IS 'Telephone number extension (PhoneExtensionText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."FAX" IS 'Contact fax number (FaxNumberText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."MAIL_ADDR_NUM_TXT" IS 'Owner/Operator Address Street Number';

   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."STREET1" IS 'Parent: Mailing address information. (MailingAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."STREET2" IS 'Parent: Mailing address information. (SupplementalAddressText)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."CITY" IS 'Parent: Mailing address information. (MailingAddressCityName)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."STATE" IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."COUNTRY" IS 'Parent: Mailing address information. (MailingAddressCountryName)';
 
   COMMENT ON COLUMN "RCRA_HD_OWNEROP"."ZIP" IS 'Parent: Mailing address information. (MailingAddressZIPCode)';
 
   COMMENT ON TABLE "RCRA_HD_OWNEROP"  IS 'Schema element: FacilityOwnerOperatorDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY" 
   (	"HD_SEC_MATERIAL_ACTIVITY_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANS_CODE" VARCHAR2(50), 
	"HSM_SEQ_NUM" VARCHAR2(20), 
	"FAC_CODE_OWNER_NAME" VARCHAR2(128), 
	"FAC_TYPE_CODE" VARCHAR2(50), 
	"ESTIMATED_SHORT_TONS_QNTY" NUMBER(10,0), 
	"ACTL_SHORT_TONS_QNTY" NUMBER(10,0), 
	"LAND_BASED_UNIT_IND" VARCHAR2(50),
  "LAND_BASED_UNIT_IND_TEXT" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."HD_SEC_MATERIAL_ACTIVITY_ID" IS 'Parent: Hazardous Secondary Material activity of the Handler (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."HD_HANDLER_ID" IS 'Parent: Hazardous Secondary Material activity of the Handler (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."HSM_SEQ_NUM" IS 'Unique number identifying the HSM Activity for the Handler (HSMSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."FAC_CODE_OWNER_NAME" IS 'Owner of the Facility Code.  Shoule be HQ or the state code (i.e. KS) (FacilityCodeOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."FAC_TYPE_CODE" IS 'Type of facility generating Hazardous Secondary Material (FacilityTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."ESTIMATED_SHORT_TONS_QNTY" IS 'The estimated amount of HSM generated by the Handler (EstimatedShortTonsQuantity)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."ACTL_SHORT_TONS_QNTY" IS 'The actual amount of HSM generated by the Handler (ActualShortTonsQuantity)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."LAND_BASED_UNIT_IND" IS 'Code to indicate if the HSM is being managed in a Land Based Unit (LandBasedUnitIndicator)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_MATERIAL_ACTIVITY"."LAND_BASED_UNIT_IND_TEXT" IS 'Descriptive text describing the code to indicate if the HSM is being managed in a Land Based Unit (Data publishing only)';
 
   COMMENT ON TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY"  IS 'Schema element: HazardousSecondaryMaterialActivityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_SEC_WASTE_CODE" 
   (	"HD_SEC_WASTE_CODE_ID" VARCHAR2(40), 
	"HD_SEC_MATERIAL_ACTIVITY_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"WASTE_CODE_OWNER" CHAR(2), 
	"WASTE_CODE_TYPE" VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_SEC_WASTE_CODE"."HD_SEC_WASTE_CODE_ID" IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_WASTE_CODE"."HD_SEC_MATERIAL_ACTIVITY_ID" IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_WASTE_CODE"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_WASTE_CODE"."WASTE_CODE_OWNER" IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_SEC_WASTE_CODE"."WASTE_CODE_TYPE" IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE "RCRA_HD_SEC_WASTE_CODE"  IS 'Schema element: SecondaryHandlerWasteCodeDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_STATE_ACTIVITY" 
   (	"HD_STATE_ACTIVITY_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"STATE_ACTIVITY_OWNER" CHAR(2), 
	"STATE_ACTIVITY_TYPE" VARCHAR2(5)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_STATE_ACTIVITY"."HD_STATE_ACTIVITY_ID" IS 'Parent: State waste activity of the handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_STATE_ACTIVITY"."HD_HANDLER_ID" IS 'Parent: State waste activity of the handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_STATE_ACTIVITY"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_STATE_ACTIVITY"."STATE_ACTIVITY_OWNER" IS 'Indicates the agency that defines the state activity type. (StateActivityOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_STATE_ACTIVITY"."STATE_ACTIVITY_TYPE" IS 'Code indicating the type of state activity. (StateActivityTypeCode)';
 
   COMMENT ON TABLE "RCRA_HD_STATE_ACTIVITY"  IS 'Schema element: StateActivityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_SUBM" 
   (	"HD_SUBM_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE "RCRA_HD_SUBM"  IS 'Schema element: HazardousWasteHandlerSubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_UNIVERSAL_WASTE" 
   (	"HD_UNIVERSAL_WASTE_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"UNIVERSAL_WASTE_OWNER" CHAR(2), 
	"UNIVERSAL_WASTE_TYPE" CHAR(1), 
	"ACCUMULATED" CHAR(1), 
	"GENERATED" CHAR(1)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."HD_UNIVERSAL_WASTE_ID" IS 'Parent: Information about universal waste generated by the handler. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."HD_HANDLER_ID" IS 'Parent: Information about universal waste generated by the handler. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."UNIVERSAL_WASTE_OWNER" IS 'Indicates the agency that defines the universal waste type. (UniversalWasteOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."UNIVERSAL_WASTE_TYPE" IS 'Code indicating the type of universal waste. (UniversalWasteTypeCode)';
 
   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."ACCUMULATED" IS 'Code indicating that the handler is engaged in accumulating waste on site. (AccumulatedWasteCode)';
 
   COMMENT ON COLUMN "RCRA_HD_UNIVERSAL_WASTE"."GENERATED" IS 'Code indicating that the handler is engaged in generating waste on site. (GeneratedHandlerCode)';
 
   COMMENT ON TABLE "RCRA_HD_UNIVERSAL_WASTE"  IS 'Schema element: UniversalWasteActivityDataType';
--------------------------------------------------------
--  DDL for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  CREATE TABLE "RCRA_HD_WASTE_CODE" 
   (	"HD_WASTE_CODE_ID" VARCHAR2(40), 
	"HD_HANDLER_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"WASTE_CODE_OWNER" CHAR(2), 
	"WASTE_CODE_TYPE" VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN "RCRA_HD_WASTE_CODE"."HD_WASTE_CODE_ID" IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)';
 
   COMMENT ON COLUMN "RCRA_HD_WASTE_CODE"."HD_HANDLER_ID" IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)';
 
   COMMENT ON COLUMN "RCRA_HD_WASTE_CODE"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_HD_WASTE_CODE"."WASTE_CODE_OWNER" IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN "RCRA_HD_WASTE_CODE"."WASTE_CODE_TYPE" IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE "RCRA_HD_WASTE_CODE"  IS 'Schema element: HandlerWasteCodeDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_EVENT
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_EVENT" 
   (	"PRM_EVENT_ID" VARCHAR2(40), 
	"PRM_SERIES_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"PERMIT_EVENT_DATA_OWNER_CODE" CHAR(2), 
	"PERMIT_EVENT_CODE" VARCHAR2(7), 
	"EVENT_AGN_CODE" CHAR(1), 
	"EVENT_SEQ_NUM" NUMBER(10,0), 
	"ACTL_DATE" DATE, 
	"ORIGINAL_SCHEDULE_DATE" DATE, 
	"NEW_SCHEDULE_DATE" DATE, 
	"RESP_PERSON_DATA_OWNER_CODE" CHAR(2), 
	"RESP_PERSON_ID" VARCHAR2(5), 
	"EVENT_SUBORG_DATA_OWNER_CODE" CHAR(2), 
	"EVENT_SUBORG_CODE" VARCHAR2(10), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_EVENT"."PRM_EVENT_ID" IS 'Parent: Permit event Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."PRM_SERIES_ID" IS 'Parent: Permit event Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."PERMIT_EVENT_DATA_OWNER_CODE" IS 'Indicates the agency that defines the event. (PermitEventDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."PERMIT_EVENT_CODE" IS 'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."EVENT_AGN_CODE" IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."EVENT_SEQ_NUM" IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."ACTL_DATE" IS 'Date on which actual completion of an event occurs. (ActualDate)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."ORIGINAL_SCHEDULE_DATE" IS 'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."NEW_SCHEDULE_DATE" IS 'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."RESP_PERSON_DATA_OWNER_CODE" IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."RESP_PERSON_ID" IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."EVENT_SUBORG_DATA_OWNER_CODE" IS 'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."EVENT_SUBORG_CODE" IS 'Event responsible suborganization. (EventSuborganizationCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_PRM_EVENT"  IS 'Schema element: PermitEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_EVENT_COMMITMENT
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_EVENT_COMMITMENT" 
   (	"PRM_EVENT_COMMITMENT_ID" VARCHAR2(40), 
	"PRM_EVENT_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"COMMIT_LEAD" CHAR(2), 
	"COMMIT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_EVENT_COMMITMENT"."PRM_EVENT_COMMITMENT_ID" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT_COMMITMENT"."PRM_EVENT_ID" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT_COMMITMENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT_COMMITMENT"."COMMIT_LEAD" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)';
 
   COMMENT ON COLUMN "RCRA_PRM_EVENT_COMMITMENT"."COMMIT_SEQ_NUM" IS 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_PRM_EVENT_COMMITMENT"  IS 'Schema element: PermitEventCommitmentDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_FAC_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_FAC_SUBM" 
   (	"PRM_FAC_SUBM_ID" VARCHAR2(40), 
	"PRM_SUBM_ID" VARCHAR2(40), 
	"HANDLER_ID" VARCHAR2(12)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_FAC_SUBM"."PRM_FAC_SUBM_ID" IS 'Parent: 
	This is the root element for this flow XML Schema.
	 (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_FAC_SUBM"."PRM_SUBM_ID" IS 'Parent: 
	This is the root element for this flow XML Schema.
	 (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_FAC_SUBM"."HANDLER_ID" IS 'Code that uniquely identifies the handler. (HandlerID)';
 
   COMMENT ON TABLE "RCRA_PRM_FAC_SUBM"  IS 'Schema element: PermitFacilitySubmissionDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_RELATED_EVENT
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_RELATED_EVENT" 
   (	"PRM_RELATED_EVENT_ID" VARCHAR2(40), 
	"PRM_UNIT_DETAIL_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"ACT_LOC_CODE" CHAR(2), 
	"PERMIT_SERIES_SEQ_NUM" NUMBER(10,0), 
	"PERMIT_EVENT_DATA_OWNER_CODE" CHAR(2), 
	"PERMIT_EVENT_CODE" VARCHAR2(7), 
	"EVENT_AGN_CODE" CHAR(1), 
	"EVENT_SEQ_NUM" NUMBER(10,0)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."PRM_RELATED_EVENT_ID" IS 'Parent: Linking Data for Permitted Units and Permitting Events (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."PRM_UNIT_DETAIL_ID" IS 'Parent: Linking Data for Permitted Units and Permitting Events (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."ACT_LOC_CODE" IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."PERMIT_SERIES_SEQ_NUM" IS 'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."PERMIT_EVENT_DATA_OWNER_CODE" IS 'Indicates the agency that defines the event. (PermitEventDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."PERMIT_EVENT_CODE" IS 'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."EVENT_AGN_CODE" IS 'Agency responsible for the event. (EventAgencyCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_RELATED_EVENT"."EVENT_SEQ_NUM" IS 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)';
 
   COMMENT ON TABLE "RCRA_PRM_RELATED_EVENT"  IS 'Schema element: PermitRelatedEventDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_SERIES
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_SERIES" 
   (	"PRM_SERIES_ID" VARCHAR2(40), 
	"PRM_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"PERMIT_SERIES_SEQ_NUM" NUMBER(10,0), 
	"PERMIT_SERIES_NAME" VARCHAR2(40), 
	"RESP_PERSON_DATA_OWNER_CODE" CHAR(2), 
	"RESP_PERSON_ID" VARCHAR2(5), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_SERIES"."PRM_SERIES_ID" IS 'Parent: Permit series Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."PRM_FAC_SUBM_ID" IS 'Parent: Permit series Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."PERMIT_SERIES_SEQ_NUM" IS 'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."PERMIT_SERIES_NAME" IS 'Name or number assigned by the implementing agency. (PermitSeriesName)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."RESP_PERSON_DATA_OWNER_CODE" IS 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."RESP_PERSON_ID" IS 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)';
 
   COMMENT ON COLUMN "RCRA_PRM_SERIES"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_PRM_SERIES"  IS 'Schema element: PermitSeriesDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_SUBM
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_SUBM" 
   (	"PRM_SUBM_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON TABLE "RCRA_PRM_SUBM"  IS 'Schema element: HazardousWastePermitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_UNIT
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_UNIT" 
   (	"PRM_UNIT_ID" VARCHAR2(40), 
	"PRM_FAC_SUBM_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"PERMIT_UNIT_SEQ_NUM" NUMBER(10,0), 
	"PERMIT_UNIT_NAME" VARCHAR2(40), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_UNIT"."PRM_UNIT_ID" IS 'Parent: Permit Unit Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT"."PRM_FAC_SUBM_ID" IS 'Parent: Permit Unit Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT"."PERMIT_UNIT_SEQ_NUM" IS 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT"."PERMIT_UNIT_NAME" IS 'Name or number assigned by the implementing agency to identify a process unit group. (PermitUnitName)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_PRM_UNIT"  IS 'Schema element: PermitUnitDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_UNIT_DETAIL
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_UNIT_DETAIL" 
   (	"PRM_UNIT_DETAIL_ID" VARCHAR2(40), 
	"PRM_UNIT_ID" VARCHAR2(40), 
	"TRANS_CODE" CHAR(1), 
	"PERMIT_UNIT_DETAIL_SEQ_NUM" NUMBER(10,0), 
	"PROC_UNIT_DATA_OWNER_CODE" CHAR(2), 
	"PROC_UNIT_CODE" VARCHAR2(3), 
	"PERMIT_STAT_EFFC_DATE" DATE, 
	"PERMIT_UNIT_CAP_QNTY" NUMBER(14,3), 
	"CAP_TYPE_CODE" CHAR(1), 
	"COMMER_STAT_CODE" CHAR(1), 
	"LEGAL_OPER_STAT_DATA_OWNER_CDE" CHAR(2), 
	"LEGAL_OPER_STAT_CODE" VARCHAR2(4), 
	"MEASUREMENT_UNIT_DATA_OWNR_CDE" CHAR(2), 
	"MEASUREMENT_UNIT_CODE" CHAR(1), 
	"NUM_OF_UNITS_COUNT" NUMBER(10,0), 
	"STANDARD_PERMIT_IND" CHAR(1), 
	"SUPP_INFO_TXT" VARCHAR2(2000)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PRM_UNIT_DETAIL_ID" IS 'Parent: Permit Unit Detail Data (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PRM_UNIT_ID" IS 'Parent: Permit Unit Detail Data (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."TRANS_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PERMIT_UNIT_DETAIL_SEQ_NUM" IS 'System-generated value used to uniquely identify a process unit detail. (PermitUnitDetailSequenceNumber)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PROC_UNIT_DATA_OWNER_CODE" IS 'Indicates the agency that defines the process code. (ProcessUnitDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PROC_UNIT_CODE" IS 'Code specifying the unit group''s current waste treatment, storage, or disposal process. (ProcessUnitCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PERMIT_STAT_EFFC_DATE" IS 'Date specifying when the other information in the process detail data record (i.e., process, capacity, and operating and legal status) became effective. (PermitStatusEffectiveDate)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."PERMIT_UNIT_CAP_QNTY" IS 'Permitted capacity of the unit (PermitUnitCapacityQuantity)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."CAP_TYPE_CODE" IS 'Code indicating the type of capacity. (CapacityTypeCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."COMMER_STAT_CODE" IS 'Code indicating that the facility, whether public or private, accepts hazardous waste for the process unit group from a third party. (CommercialStatusCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."LEGAL_OPER_STAT_DATA_OWNER_CDE" IS 'Indicates the agency that defines the legal/operating status code. (LegalOperatingStatusDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."LEGAL_OPER_STAT_CODE" IS 'Code used to indicate programmatic (operating and legal status) conditions that reflect RCRA program activity requirements of a unit. (LegalOperatingStatusCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."MEASUREMENT_UNIT_DATA_OWNR_CDE" IS 'Indicates the agency that defines the unit of measure. (MeasurementUnitDataOwnerCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."MEASUREMENT_UNIT_CODE" IS 'Indicates the unit of measure. (MeasurementUnitCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."NUM_OF_UNITS_COUNT" IS 'Total number of units of the same process grouped together to form a single process unit group. (NumberOfUnitsCount)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."STANDARD_PERMIT_IND" IS 'Indicates whether or not the permit is a standardized permit. (StandardPermitIndicator)';
 
   COMMENT ON COLUMN "RCRA_PRM_UNIT_DETAIL"."SUPP_INFO_TXT" IS 'Notes providing more information. (SupplementalInformationText)';
 
   COMMENT ON TABLE "RCRA_PRM_UNIT_DETAIL"  IS 'Schema element: PermitUnitDetailDataType';
--------------------------------------------------------
--  DDL for Table RCRA_PRM_WASTE_CODE
--------------------------------------------------------

  CREATE TABLE "RCRA_PRM_WASTE_CODE" 
   (	"PRM_WASTE_CODE_ID" VARCHAR2(40), 
	"PRM_UNIT_DETAIL_ID" VARCHAR2(40), 
	"TRANSACTION_CODE" CHAR(1), 
	"WASTE_CODE_OWNER" CHAR(2), 
	"WASTE_CODE_TYPE" VARCHAR2(6)
   ) ;
 

   COMMENT ON COLUMN "RCRA_PRM_WASTE_CODE"."PRM_WASTE_CODE_ID" IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)';
 
   COMMENT ON COLUMN "RCRA_PRM_WASTE_CODE"."PRM_UNIT_DETAIL_ID" IS 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)';
 
   COMMENT ON COLUMN "RCRA_PRM_WASTE_CODE"."TRANSACTION_CODE" IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';
 
   COMMENT ON COLUMN "RCRA_PRM_WASTE_CODE"."WASTE_CODE_OWNER" IS 'Indicates the agency that owns the data record. (WasteCodeOwnerName)';
 
   COMMENT ON COLUMN "RCRA_PRM_WASTE_CODE"."WASTE_CODE_TYPE" IS 'Code used to describe hazardous waste. (WasteCode)';
 
   COMMENT ON TABLE "RCRA_PRM_WASTE_CODE"  IS 'Schema element: PermitHandlerWasteCodeDataType';
--------------------------------------------------------
--  DDL for Table RCRA_SUBMISSIONHISTORY
--------------------------------------------------------

  CREATE TABLE "RCRA_SUBMISSIONHISTORY" 
   (	"SUBMISSIONHISTORY_ID" VARCHAR2(40), 
	"SCHEDULERUNDATE" DATE, 
	"TRANSACTIONID" VARCHAR2(50), 
	"PROCESSINGSTATUS" VARCHAR2(50),
	"SUBMISSIONTYPE" VARCHAR2(50)
   ) ;
 

   COMMENT ON TABLE "RCRA_SUBMISSIONHISTORY"  IS 'Schema element: SubmissionHistoryDataType';

--------------------------------------------------------
--  Constraints for Table RCRA_PRM_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_FAC_SUBM" ADD CONSTRAINT "PK_PRM_FAC_SUBM" PRIMARY KEY ("PRM_FAC_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_FAC_SUBM" MODIFY ("PRM_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_FAC_SUBM" MODIFY ("PRM_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_FAC_SUBM" MODIFY ("HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_SEC_WASTE_CODE" ADD CONSTRAINT "PK_HD_SEC_WAST_COD" PRIMARY KEY ("HD_SEC_WASTE_CODE_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_SEC_WASTE_CODE" MODIFY ("HD_SEC_WASTE_CODE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_SEC_WASTE_CODE" MODIFY ("HD_SEC_MATERIAL_ACTIVITY_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_GIS_GEO_INFORMATION
--------------------------------------------------------

  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" ADD CONSTRAINT "PK_GS_GO_INFORMTON" PRIMARY KEY ("GIS_GEO_INFORMATION_ID") ENABLE;
 
  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" MODIFY ("GIS_GEO_INFORMATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" MODIFY ("GIS_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" MODIFY ("GEO_INFO_OWNER" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" MODIFY ("GEO_INFO_SEQ_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" MODIFY ("DATA_COLL_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_ENV_PERMIT" ADD CONSTRAINT "PK_HD_ENV_PERMIT" PRIMARY KEY ("HD_ENV_PERMIT_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_ENV_PERMIT" MODIFY ("HD_ENV_PERMIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_ENV_PERMIT" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_ENV_PERMIT" MODIFY ("ENV_PERMIT_NUMBER" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_ENV_PERMIT" MODIFY ("ENV_PERMIT_DESC" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_MECHANISM_DETAIL
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_MECHANISM_DETAIL" ADD CONSTRAINT "PK_FA_MCHNISM_DTIL" PRIMARY KEY ("FA_MECHANISM_DETAIL_ID") ENABLE;
 
  ALTER TABLE "RCRA_FA_MECHANISM_DETAIL" MODIFY ("FA_MECHANISM_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_MECHANISM_DETAIL" MODIFY ("FA_MECHANISM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_MECHANISM_DETAIL" MODIFY ("MECHANISM_DETAIL_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_MILESTONE" ADD CONSTRAINT "PK_CME_MILESTONE" PRIMARY KEY ("CME_MILESTONE_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_MILESTONE" MODIFY ("CME_MILESTONE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_MILESTONE" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_MILESTONE" MODIFY ("MILESTONE_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_EVENT" ADD CONSTRAINT "PK_CA_EVENT" PRIMARY KEY ("CA_EVENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("CA_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("CA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("CORCT_ACT_EVENT_DATA_OWNER_CDE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("CORCT_ACT_EVENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("EVENT_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT" MODIFY ("EVENT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_CSNY_DATE" ADD CONSTRAINT "PK_CME_CSNY_DATE" PRIMARY KEY ("CME_CSNY_DATE_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_CSNY_DATE" MODIFY ("CME_CSNY_DATE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_CSNY_DATE" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_CSNY_DATE" MODIFY ("SNY_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AUTHORITY
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AUTHORITY" ADD CONSTRAINT "PK_CA_AUTHORITY" PRIMARY KEY ("CA_AUTHORITY_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("CA_AUTHORITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("CA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("AUTHORITY_DATA_OWNER_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("AUTHORITY_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("AUTHORITY_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTHORITY" MODIFY ("AUTHORITY_EFFC_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_RELATED_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_RELATED_EVENT" ADD CONSTRAINT "PK_PRM_RELTED_EVNT" PRIMARY KEY ("PRM_RELATED_EVENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("PRM_RELATED_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("PRM_UNIT_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("PERMIT_SERIES_SEQ_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("PERMIT_EVENT_DATA_OWNER_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("PERMIT_EVENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("EVENT_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_RELATED_EVENT" MODIFY ("EVENT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_EVENT_COMMITMENT" ADD CONSTRAINT "PK_CA_EVNT_CMMTMNT" PRIMARY KEY ("CA_EVENT_COMMITMENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_EVENT_COMMITMENT" MODIFY ("CA_EVENT_COMMITMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT_COMMITMENT" MODIFY ("CA_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT_COMMITMENT" MODIFY ("COMMIT_LEAD" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_EVENT_COMMITMENT" MODIFY ("COMMIT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_CERTIFICATION" ADD CONSTRAINT "PK_HD_CERTIFICATIO" PRIMARY KEY ("HD_CERTIFICATION_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_CERTIFICATION" MODIFY ("HD_CERTIFICATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_CERTIFICATION" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_CERTIFICATION" MODIFY ("CERT_SEQ" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_EVENT" ADD CONSTRAINT "PK_PRM_EVENT" PRIMARY KEY ("PRM_EVENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("PRM_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("PRM_SERIES_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("PERMIT_EVENT_DATA_OWNER_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("PERMIT_EVENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("EVENT_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT" MODIFY ("EVENT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_WASTE_CODE" ADD CONSTRAINT "PK_PRM_WASTE_CODE" PRIMARY KEY ("PRM_WASTE_CODE_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_WASTE_CODE" MODIFY ("PRM_WASTE_CODE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_WASTE_CODE" MODIFY ("PRM_UNIT_DETAIL_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_SUBM" ADD CONSTRAINT "PK_HD_SUBM" PRIMARY KEY ("HD_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_SUBM" MODIFY ("HD_SUBM_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_MEDIA
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_MEDIA" ADD CONSTRAINT "PK_CME_MEDIA" PRIMARY KEY ("CME_MEDIA_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_MEDIA" MODIFY ("CME_MEDIA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_MEDIA" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_MEDIA" MODIFY ("MULTIMEDIA_CODE_OWNER" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_MEDIA" MODIFY ("MULTIMEDIA_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_STATE_ACTIVITY" ADD CONSTRAINT "PK_HD_STATE_ACTIVI" PRIMARY KEY ("HD_STATE_ACTIVITY_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_STATE_ACTIVITY" MODIFY ("HD_STATE_ACTIVITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_STATE_ACTIVITY" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_STATE_ACTIVITY" MODIFY ("STATE_ACTIVITY_OWNER" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_STATE_ACTIVITY" MODIFY ("STATE_ACTIVITY_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_EVAL_COMMIT" ADD CONSTRAINT "PK_CME_EVAL_COMMIT" PRIMARY KEY ("CME_EVAL_COMMIT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_EVAL_COMMIT" MODIFY ("CME_EVAL_COMMIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_COMMIT" MODIFY ("CME_EVAL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_COMMIT" MODIFY ("COMMIT_LEAD" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_COMMIT" MODIFY ("COMMIT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_GIS_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_GIS_FAC_SUBM" ADD CONSTRAINT "PK_GIS_FAC_SUBM" PRIMARY KEY ("GIS_FAC_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_GIS_FAC_SUBM" MODIFY ("GIS_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_GIS_FAC_SUBM" MODIFY ("GIS_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_GIS_FAC_SUBM" MODIFY ("HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_HANDLER
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_HANDLER" ADD CONSTRAINT "PK_HD_HANDLER" PRIMARY KEY ("HD_HANDLER_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_HANDLER" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_HANDLER" MODIFY ("HD_HBASIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_HANDLER" MODIFY ("ACTIVITY_LOCATION" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_HANDLER" MODIFY ("SOURCE_TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_HANDLER" MODIFY ("SEQ_NUMBER" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_RQST
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_RQST" ADD CONSTRAINT "PK_CME_RQST" PRIMARY KEY ("CME_RQST_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_RQST" MODIFY ("CME_RQST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_RQST" MODIFY ("CME_EVAL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_RQST" MODIFY ("RQST_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_SUBM" ADD CONSTRAINT "PK_CME_SUBM" PRIMARY KEY ("CME_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_SUBM" MODIFY ("CME_SUBM_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT" ADD CONSTRAINT "PK_CME_SPP_ENV_PRJ" PRIMARY KEY ("CME_SUPP_ENVR_PRJT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT" MODIFY ("CME_SUPP_ENVR_PRJT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT" MODIFY ("SEP_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_OTHER_ID" ADD CONSTRAINT "PK_HD_OTHER_ID" PRIMARY KEY ("HD_OTHER_ID_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_OTHER_ID" MODIFY ("HD_OTHER_ID_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_OTHER_ID" MODIFY ("HD_HBASIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_OTHER_ID" MODIFY ("OTHER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_STATUTORY_CITATION
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_STATUTORY_CITATION" ADD CONSTRAINT "PK_CA_STTTRY_CTTON" PRIMARY KEY ("CA_STATUTORY_CITATION_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_STATUTORY_CITATION" MODIFY ("CA_STATUTORY_CITATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_STATUTORY_CITATION" MODIFY ("CA_AUTHORITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_STATUTORY_CITATION" MODIFY ("STATUTORY_CITTION_DTA_OWNR_CDE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_STATUTORY_CITATION" MODIFY ("STATUTORY_CITATION_IDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_VIOL
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_VIOL" ADD CONSTRAINT "PK_CME_VIOL" PRIMARY KEY ("CME_VIOL_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_VIOL" MODIFY ("CME_VIOL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL" MODIFY ("CME_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL" MODIFY ("VIOL_ACT_LOC" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL" MODIFY ("VIOL_SEQ_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL" MODIFY ("AGN_WHICH_DTRM_VIOL" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT" ADD CONSTRAINT "PK_PRM_EVNT_CMMTMN" PRIMARY KEY ("PRM_EVENT_COMMITMENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT" MODIFY ("PRM_EVENT_COMMITMENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT" MODIFY ("PRM_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT" MODIFY ("COMMIT_LEAD" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT" MODIFY ("COMMIT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_NAICS
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_NAICS" ADD CONSTRAINT "PK_HD_NAICS" PRIMARY KEY ("HD_NAICS_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_NAICS" MODIFY ("HD_NAICS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_NAICS" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_NAICS" MODIFY ("NAICS_SEQ" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_WASTE_CODE" ADD CONSTRAINT "PK_HD_WASTE_CODE" PRIMARY KEY ("HD_WASTE_CODE_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_WASTE_CODE" MODIFY ("HD_WASTE_CODE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_WASTE_CODE" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_REL_PERMIT_UNIT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT" ADD CONSTRAINT "PK_CA_RL_PRMIT_UNT" PRIMARY KEY ("CA_REL_PERMIT_UNIT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT" MODIFY ("CA_REL_PERMIT_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT" MODIFY ("CA_AREA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT" MODIFY ("PERMIT_UNIT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_FAC_SUBM" ADD CONSTRAINT "PK_CME_FAC_SUBM" PRIMARY KEY ("CME_FAC_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_FAC_SUBM" MODIFY ("CME_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_FAC_SUBM" MODIFY ("CME_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_FAC_SUBM" MODIFY ("EPA_HDLR_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_UNIVERSAL_WASTE" ADD CONSTRAINT "PK_HD_UNIVER_WASTE" PRIMARY KEY ("HD_UNIVERSAL_WASTE_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_UNIVERSAL_WASTE" MODIFY ("HD_UNIVERSAL_WASTE_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_UNIVERSAL_WASTE" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_SUBM" ADD CONSTRAINT "PK_PRM_SUBM" PRIMARY KEY ("PRM_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_SUBM" MODIFY ("PRM_SUBM_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AREA
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AREA" ADD CONSTRAINT "PK_CA_AREA" PRIMARY KEY ("CA_AREA_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_AREA" MODIFY ("CA_AREA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA" MODIFY ("CA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA" MODIFY ("AREA_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_SERIES
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_SERIES" ADD CONSTRAINT "PK_PRM_SERIES" PRIMARY KEY ("PRM_SERIES_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_SERIES" MODIFY ("PRM_SERIES_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_SERIES" MODIFY ("PRM_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_SERIES" MODIFY ("PERMIT_SERIES_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_ENFRC_ACT" ADD CONSTRAINT "PK_CME_ENFRC_ACT" PRIMARY KEY ("CME_ENFRC_ACT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_ENFRC_ACT" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_ENFRC_ACT" MODIFY ("CME_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_ENFRC_ACT" MODIFY ("ENFRC_AGN_LOC_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_ENFRC_ACT" MODIFY ("ENFRC_ACT_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_ENFRC_ACT" MODIFY ("ENFRC_ACT_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_ENFRC_ACT" MODIFY ("ENFRC_AGN_NAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_GIS_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_GIS_SUBM" ADD CONSTRAINT "PK_GIS_SUBM" PRIMARY KEY ("GIS_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_GIS_SUBM" MODIFY ("GIS_SUBM_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_FAC_SUBM" ADD CONSTRAINT "PK_CA_FAC_SUBM" PRIMARY KEY ("CA_FAC_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_FAC_SUBM" MODIFY ("CA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_FAC_SUBM" MODIFY ("CA_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_FAC_SUBM" MODIFY ("HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_PNLTY
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_PNLTY" ADD CONSTRAINT "PK_CME_PNLTY" PRIMARY KEY ("CME_PNLTY_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_PNLTY" MODIFY ("CME_PNLTY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_PNLTY" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_PNLTY" MODIFY ("PNLTY_TYPE_OWNER" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_PNLTY" MODIFY ("PNLTY_TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_COST_EST_REL_MECHANISM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" ADD CONSTRAINT "PK_FA_CST_ES_RL_MC" PRIMARY KEY ("FA_COST_EST_REL_MECHANISM_ID") ENABLE;
 
  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" MODIFY ("FA_COST_EST_REL_MECHANISM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" MODIFY ("FA_COST_EST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" MODIFY ("MECHANISM_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" MODIFY ("MECHANISM_SEQ_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" MODIFY ("MECHANISM_DETAIL_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AUTH_REL_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" ADD CONSTRAINT "PK_CA_AUTH_RL_EVNT" PRIMARY KEY ("CA_AUTH_REL_EVENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("CA_AUTH_REL_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("CA_AUTHORITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("CORCT_ACT_EVENT_DATA_OWNER_CDE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("CORCT_ACT_EVENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("EVENT_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" MODIFY ("EVENT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_COST_EST
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_COST_EST" ADD CONSTRAINT "PK_FA_COST_EST" PRIMARY KEY ("FA_COST_EST_ID") ENABLE;
 
  ALTER TABLE "RCRA_FA_COST_EST" MODIFY ("FA_COST_EST_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST" MODIFY ("FA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST" MODIFY ("COST_ESTIMATE_TYPE_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST" MODIFY ("COST_ESTIMATE_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_COST_EST" MODIFY ("COST_ESTIMATE_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_UNIT_DETAIL
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_UNIT_DETAIL" ADD CONSTRAINT "PK_PRM_UNIT_DETAIL" PRIMARY KEY ("PRM_UNIT_DETAIL_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_UNIT_DETAIL" MODIFY ("PRM_UNIT_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_UNIT_DETAIL" MODIFY ("PRM_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_UNIT_DETAIL" MODIFY ("PERMIT_UNIT_DETAIL_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_HBASIC
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_HBASIC" ADD CONSTRAINT "PK_HD_HBASIC" PRIMARY KEY ("HD_HBASIC_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_HBASIC" MODIFY ("HD_HBASIC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_HBASIC" MODIFY ("HD_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_HBASIC" MODIFY ("HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_EVAL" ADD CONSTRAINT "PK_CME_EVAL" PRIMARY KEY ("CME_EVAL_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_EVAL" MODIFY ("CME_EVAL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL" MODIFY ("CME_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL" MODIFY ("EVAL_ACT_LOC" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL" MODIFY ("EVAL_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL" MODIFY ("EVAL_START_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL" MODIFY ("EVAL_RESP_AGN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_PRM_UNIT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_UNIT" ADD CONSTRAINT "PK_PRM_UNIT" PRIMARY KEY ("PRM_UNIT_ID") ENABLE;
 
  ALTER TABLE "RCRA_PRM_UNIT" MODIFY ("PRM_UNIT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_UNIT" MODIFY ("PRM_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_PRM_UNIT" MODIFY ("PERMIT_UNIT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_CITATION
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_CITATION" ADD CONSTRAINT "PK_CME_CITATION" PRIMARY KEY ("CME_CITATION_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_CITATION" MODIFY ("CME_CITATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_CITATION" MODIFY ("CME_VIOL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_CITATION" MODIFY ("CITATION_NAME_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_SUBMISSIONHISTORY
--------------------------------------------------------

  ALTER TABLE "RCRA_SUBMISSIONHISTORY" ADD CONSTRAINT "PK_SUBMISSIONHISTO" PRIMARY KEY ("SUBMISSIONHISTORY_ID") ENABLE;
 
  ALTER TABLE "RCRA_SUBMISSIONHISTORY" MODIFY ("SUBMISSIONHISTORY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_SUBMISSIONHISTORY" MODIFY ("SCHEDULERUNDATE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_SUBMISSIONHISTORY" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_SUBMISSIONHISTORY" MODIFY ("PROCESSINGSTATUS" NOT NULL ENABLE);

  ALTER TABLE "RCRA_SUBMISSIONHISTORY" MODIFY ("SUBMISSIONTYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_SUBM" ADD CONSTRAINT "PK_CA_SUBM" PRIMARY KEY ("CA_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_SUBM" MODIFY ("CA_SUBM_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CA_AREA_REL_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" ADD CONSTRAINT "PK_CA_AREA_RL_EVNT" PRIMARY KEY ("CA_AREA_REL_EVENT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("CA_AREA_REL_EVENT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("CA_AREA_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("CORCT_ACT_EVENT_DATA_OWNER_CDE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("CORCT_ACT_EVENT_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("EVENT_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" MODIFY ("EVENT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_SUBM" ADD CONSTRAINT "PK_FA_SUBM" PRIMARY KEY ("FA_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_FA_SUBM" MODIFY ("FA_SUBM_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_OWNEROP" ADD CONSTRAINT "PK_HD_OWNEROP" PRIMARY KEY ("HD_OWNEROP_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_OWNEROP" MODIFY ("HD_OWNEROP_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_OWNEROP" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_OWNEROP" MODIFY ("OWNER_OP_SEQ" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_PYMT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_PYMT" ADD CONSTRAINT "PK_CME_PYMT" PRIMARY KEY ("CME_PYMT_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_PYMT" MODIFY ("CME_PYMT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_PYMT" MODIFY ("CME_PNLTY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_PYMT" MODIFY ("PYMT_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_FAC_SUBM" ADD CONSTRAINT "PK_FA_FAC_SUBM" PRIMARY KEY ("FA_FAC_SUBM_ID") ENABLE;
 
  ALTER TABLE "RCRA_FA_FAC_SUBM" MODIFY ("FA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_FAC_SUBM" MODIFY ("FA_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_FAC_SUBM" MODIFY ("HANDLER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_FA_MECHANISM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_MECHANISM" ADD CONSTRAINT "PK_FA_MECHANISM" PRIMARY KEY ("FA_MECHANISM_ID") ENABLE;
 
  ALTER TABLE "RCRA_FA_MECHANISM" MODIFY ("FA_MECHANISM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_MECHANISM" MODIFY ("FA_FAC_SUBM_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_MECHANISM" MODIFY ("ACT_LOC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_MECHANISM" MODIFY ("MECHANISM_AGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_FA_MECHANISM" MODIFY ("MECHANISM_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_EVAL_VIOL" ADD CONSTRAINT "PK_CME_EVAL_VIOL" PRIMARY KEY ("CME_EVAL_VIOL_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_EVAL_VIOL" MODIFY ("CME_EVAL_VIOL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_VIOL" MODIFY ("CME_EVAL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_VIOL" MODIFY ("VIOL_ACT_LOC" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_VIOL" MODIFY ("VIOL_SEQ_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_EVAL_VIOL" MODIFY ("AGN_WHICH_DTRM_VIOL" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY" ADD CONSTRAINT "PK_HD_SEC_MATE_ACT" PRIMARY KEY ("HD_SEC_MATERIAL_ACTIVITY_ID") ENABLE;
 
  ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY" MODIFY ("HD_SEC_MATERIAL_ACTIVITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY" MODIFY ("HD_HANDLER_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY" MODIFY ("HSM_SEQ_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_VIOL_ENFRC" ADD CONSTRAINT "PK_CME_VIOL_ENFRC" PRIMARY KEY ("CME_VIOL_ENFRC_ID") ENABLE;
 
  ALTER TABLE "RCRA_CME_VIOL_ENFRC" MODIFY ("CME_VIOL_ENFRC_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL_ENFRC" MODIFY ("CME_ENFRC_ACT_ID" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL_ENFRC" MODIFY ("VIOL_SEQ_NUM" NOT NULL ENABLE);
 
  ALTER TABLE "RCRA_CME_VIOL_ENFRC" MODIFY ("AGN_WHICH_DTRM_VIOL" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_CME_ENFRC_ACT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_ENFRC_ACT" ON "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_FA_MCHNISM_DTIL
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_FA_MCHNISM_DTIL" ON "RCRA_FA_MECHANISM_DETAIL" ("FA_MECHANISM_DETAIL_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_HBA_HD_SU_ID
--------------------------------------------------------

  CREATE INDEX "IX_HD_HBA_HD_SU_ID" ON "RCRA_HD_HBASIC" ("HD_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_RELTED_EVNT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_RELTED_EVNT" ON "RCRA_PRM_RELATED_EVENT" ("PRM_RELATED_EVENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_SUBM" ON "RCRA_CME_SUBM" ("CME_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CA_AREA
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_AREA" ON "RCRA_CA_AREA" ("CA_AREA_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_SEC_WAST_COD
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_SEC_WAST_COD" ON "RCRA_HD_SEC_WASTE_CODE" ("HD_SEC_WASTE_CODE_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_FA_COST_EST
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_FA_COST_EST" ON "RCRA_FA_COST_EST" ("FA_COST_EST_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_PYMT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_PYMT" ON "RCRA_CME_PYMT" ("CME_PYMT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CA_EV_CA_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_CA_EV_CA_FC_SB" ON "RCRA_CA_EVENT" ("CA_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_EV_VL_CM_EV
--------------------------------------------------------

  CREATE INDEX "IX_CM_EV_VL_CM_EV" ON "RCRA_CME_EVAL_VIOL" ("CME_EVAL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_FAC_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_FAC_SUBM" ON "RCRA_CME_FAC_SUBM" ("CME_FAC_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_PR_RL_EV_PR_UN
--------------------------------------------------------

  CREATE INDEX "IX_PR_RL_EV_PR_UN" ON "RCRA_PRM_RELATED_EVENT" ("PRM_UNIT_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_HD_NAICS
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_NAICS" ON "RCRA_HD_NAICS" ("HD_NAICS_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_PR_UN_PR_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_PR_UN_PR_FC_SB" ON "RCRA_PRM_UNIT" ("PRM_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_HD_OWNEROP
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_OWNEROP" ON "RCRA_HD_OWNEROP" ("HD_OWNEROP_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_FA_CST_ES_RL_MC
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_FA_CST_ES_RL_MC" ON "RCRA_FA_COST_EST_REL_MECHANISM" ("FA_COST_EST_REL_MECHANISM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_EVNT_CMMTMN
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_EVNT_CMMTMN" ON "RCRA_PRM_EVENT_COMMITMENT" ("PRM_EVENT_COMMITMENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_SEC_MATE_ACT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_SEC_MATE_ACT" ON "RCRA_HD_SEC_MATERIAL_ACTIVITY" ("HD_SEC_MATERIAL_ACTIVITY_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_HAN_HD_HB_ID
--------------------------------------------------------

  CREATE INDEX "IX_HD_HAN_HD_HB_ID" ON "RCRA_HD_HANDLER" ("HD_HBASIC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_VIOL
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_VIOL" ON "RCRA_CME_VIOL" ("CME_VIOL_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_CITATION
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_CITATION" ON "RCRA_CME_CITATION" ("CME_CITATION_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_ENV_PERMIT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_ENV_PERMIT" ON "RCRA_HD_ENV_PERMIT" ("HD_ENV_PERMIT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_GIS_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_GIS_SUBM" ON "RCRA_GIS_SUBM" ("GIS_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_MEDIA
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_MEDIA" ON "RCRA_CME_MEDIA" ("CME_MEDIA_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CA_AUTHORITY
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_AUTHORITY" ON "RCRA_CA_AUTHORITY" ("CA_AUTHORITY_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_WASTE_CODE
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_WASTE_CODE" ON "RCRA_HD_WASTE_CODE" ("HD_WASTE_CODE_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_STATE_ACTIVI
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_STATE_ACTIVI" ON "RCRA_HD_STATE_ACTIVITY" ("HD_STATE_ACTIVITY_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_SERIES
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_SERIES" ON "RCRA_PRM_SERIES" ("PRM_SERIES_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CA_RL_PRMIT_UNT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_RL_PRMIT_UNT" ON "RCRA_CA_REL_PERMIT_UNIT" ("CA_REL_PERMIT_UNIT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CME_CT_CM_VL_ID
--------------------------------------------------------

  CREATE INDEX "IX_CME_CT_CM_VL_ID" ON "RCRA_CME_CITATION" ("CME_VIOL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PR_FC_SB_PR_SB
--------------------------------------------------------

  CREATE INDEX "IX_PR_FC_SB_PR_SB" ON "RCRA_PRM_FAC_SUBM" ("PRM_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_EN_AC_CM_FC
--------------------------------------------------------

  CREATE INDEX "IX_CM_EN_AC_CM_FC" ON "RCRA_CME_ENFRC_ACT" ("CME_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FA_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_FA_SUBM" ON "RCRA_FA_SUBM" ("FA_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CA_AUTH_RL_EVNT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_AUTH_RL_EVNT" ON "RCRA_CA_AUTH_REL_EVENT" ("CA_AUTH_REL_EVENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_ST_AC_HD_HA
--------------------------------------------------------

  CREATE INDEX "IX_HD_ST_AC_HD_HA" ON "RCRA_HD_STATE_ACTIVITY" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_HD_HBASIC
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_HBASIC" ON "RCRA_HD_HBASIC" ("HD_HBASIC_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_UNIT_DETAIL
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_UNIT_DETAIL" ON "RCRA_PRM_UNIT_DETAIL" ("PRM_UNIT_DETAIL_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_WASTE_CODE
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_WASTE_CODE" ON "RCRA_PRM_WASTE_CODE" ("PRM_WASTE_CODE_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_UN_WA_HD_HA
--------------------------------------------------------

  CREATE INDEX "IX_HD_UN_WA_HD_HA" ON "RCRA_HD_UNIVERSAL_WASTE" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_CS_ES_RL_MC
--------------------------------------------------------

  CREATE INDEX "IX_FA_CS_ES_RL_MC" ON "RCRA_FA_COST_EST_REL_MECHANISM" ("FA_COST_EST_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_HD_NAI_HD_HA_ID
--------------------------------------------------------

  CREATE INDEX "IX_HD_NAI_HD_HA_ID" ON "RCRA_HD_NAICS" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FA_MECHANISM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_FA_MECHANISM" ON "RCRA_FA_MECHANISM" ("FA_MECHANISM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CME_RQ_CM_EV_ID
--------------------------------------------------------

  CREATE INDEX "IX_CME_RQ_CM_EV_ID" ON "RCRA_CME_RQST" ("CME_EVAL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_SUBM" ON "RCRA_PRM_SUBM" ("PRM_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CA_AR_CA_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_CA_AR_CA_FC_SB" ON "RCRA_CA_AREA" ("CA_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CA_FC_SB_CA_SB
--------------------------------------------------------

  CREATE INDEX "IX_CA_FC_SB_CA_SB" ON "RCRA_CA_FAC_SUBM" ("CA_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_UNIT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_UNIT" ON "RCRA_PRM_UNIT" ("PRM_UNIT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_MILESTONE
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_MILESTONE" ON "RCRA_CME_MILESTONE" ("CME_MILESTONE_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CM_FC_SB_CM_SB
--------------------------------------------------------

  CREATE INDEX "IX_CM_FC_SB_CM_SB" ON "RCRA_CME_FAC_SUBM" ("CME_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CA_EV_CM_CA_EV
--------------------------------------------------------

  CREATE INDEX "IX_CA_EV_CM_CA_EV" ON "RCRA_CA_EVENT_COMMITMENT" ("CA_EVENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_CS_DT_CM_EN
--------------------------------------------------------

  CREATE INDEX "IX_CM_CS_DT_CM_EN" ON "RCRA_CME_CSNY_DATE" ("CME_ENFRC_ACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_CS_ES_FA_FC
--------------------------------------------------------

  CREATE INDEX "IX_FA_CS_ES_FA_FC" ON "RCRA_FA_COST_EST" ("FA_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PR_WS_CD_PR_UN
--------------------------------------------------------

  CREATE INDEX "IX_PR_WS_CD_PR_UN" ON "RCRA_PRM_WASTE_CODE" ("PRM_UNIT_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CA_EVNT_CMMTMNT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_EVNT_CMMTMNT" ON "RCRA_CA_EVENT_COMMITMENT" ("CA_EVENT_COMMITMENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_SE_WA_CO_HD
--------------------------------------------------------

  CREATE INDEX "IX_HD_SE_WA_CO_HD" ON "RCRA_HD_SEC_WASTE_CODE" ("HD_SEC_MATERIAL_ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_EV_CM_CM_EV
--------------------------------------------------------

  CREATE INDEX "IX_CM_EV_CM_CM_EV" ON "RCRA_CME_EVAL_COMMIT" ("CME_EVAL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_HD_SE_MA_AC_HD
--------------------------------------------------------

  CREATE INDEX "IX_HD_SE_MA_AC_HD" ON "RCRA_HD_SEC_MATERIAL_ACTIVITY" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CA_FAC_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_FAC_SUBM" ON "RCRA_CA_FAC_SUBM" ("CA_FAC_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_FA_MC_FA_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_FA_MC_FA_FC_SB" ON "RCRA_FA_MECHANISM" ("FA_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_EV_CM_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_CM_EV_CM_FC_SB" ON "RCRA_CME_EVAL" ("CME_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CA_RL_PR_UN_CA
--------------------------------------------------------

  CREATE INDEX "IX_CA_RL_PR_UN_CA" ON "RCRA_CA_REL_PERMIT_UNIT" ("CA_AREA_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_EVENT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_EVENT" ON "RCRA_PRM_EVENT" ("PRM_EVENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_WA_CO_HD_HA
--------------------------------------------------------

  CREATE INDEX "IX_HD_WA_CO_HD_HA" ON "RCRA_HD_WASTE_CODE" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_HD_CERTIFICATIO
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_CERTIFICATIO" ON "RCRA_HD_CERTIFICATION" ("HD_CERTIFICATION_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CA_STTTRY_CTTON
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_STTTRY_CTTON" ON "RCRA_CA_STATUTORY_CITATION" ("CA_STATUTORY_CITATION_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_EN_PE_HD_HA
--------------------------------------------------------

  CREATE INDEX "IX_HD_EN_PE_HD_HA" ON "RCRA_HD_ENV_PERMIT" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CA_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_SUBM" ON "RCRA_CA_SUBM" ("CA_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_OWN_HD_HA_ID
--------------------------------------------------------

  CREATE INDEX "IX_HD_OWN_HD_HA_ID" ON "RCRA_HD_OWNEROP" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_PN_CM_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_CM_PN_CM_EN_AC" ON "RCRA_CME_PNLTY" ("CME_ENFRC_ACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_PNLTY
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_PNLTY" ON "RCRA_CME_PNLTY" ("CME_PNLTY_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_UNIVER_WASTE
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_UNIVER_WASTE" ON "RCRA_HD_UNIVERSAL_WASTE" ("HD_UNIVERSAL_WASTE_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CA_EVENT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_EVENT" ON "RCRA_CA_EVENT" ("CA_EVENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_SUBMISSIONHISTO
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_SUBMISSIONHISTO" ON "RCRA_SUBMISSIONHISTORY" ("SUBMISSIONHISTORY_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CA_ST_CT_CA_AT
--------------------------------------------------------

  CREATE INDEX "IX_CA_ST_CT_CA_AT" ON "RCRA_CA_STATUTORY_CITATION" ("CA_AUTHORITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CA_AT_RL_EV_CA
--------------------------------------------------------

  CREATE INDEX "IX_CA_AT_RL_EV_CA" ON "RCRA_CA_AUTH_REL_EVENT" ("CA_AUTHORITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_VIOL_ENFRC
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_VIOL_ENFRC" ON "RCRA_CME_VIOL_ENFRC" ("CME_VIOL_ENFRC_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_GS_GO_INFORMTON
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_GS_GO_INFORMTON" ON "RCRA_GIS_GEO_INFORMATION" ("GIS_GEO_INFORMATION_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_PR_EV_CM_PR_EV
--------------------------------------------------------

  CREATE INDEX "IX_PR_EV_CM_PR_EV" ON "RCRA_PRM_EVENT_COMMITMENT" ("PRM_EVENT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PR_UN_DT_PR_UN
--------------------------------------------------------

  CREATE INDEX "IX_PR_UN_DT_PR_UN" ON "RCRA_PRM_UNIT_DETAIL" ("PRM_UNIT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CA_AREA_RL_EVNT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CA_AREA_RL_EVNT" ON "RCRA_CA_AREA_REL_EVENT" ("CA_AREA_REL_EVENT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CM_MD_CM_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_CM_MD_CM_EN_AC" ON "RCRA_CME_MEDIA" ("CME_ENFRC_ACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_SPP_ENV_PRJ
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_SPP_ENV_PRJ" ON "RCRA_CME_SUPP_ENVR_PRJT" ("CME_SUPP_ENVR_PRJT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_OTHER_ID
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_OTHER_ID" ON "RCRA_HD_OTHER_ID" ("HD_OTHER_ID_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_EVAL_VIOL
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_EVAL_VIOL" ON "RCRA_CME_EVAL_VIOL" ("CME_EVAL_VIOL_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CM_VL_EN_CM_EN
--------------------------------------------------------

  CREATE INDEX "IX_CM_VL_EN_CM_EN" ON "RCRA_CME_VIOL_ENFRC" ("CME_ENFRC_ACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_VL_CM_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_CM_VL_CM_FC_SB" ON "RCRA_CME_VIOL" ("CME_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_HD_OT_ID_HD_HB
--------------------------------------------------------

  CREATE INDEX "IX_HD_OT_ID_HD_HB" ON "RCRA_HD_OTHER_ID" ("HD_HBASIC_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_GS_FC_SB_GS_SB
--------------------------------------------------------

  CREATE INDEX "IX_GS_FC_SB_GS_SB" ON "RCRA_GIS_FAC_SUBM" ("GIS_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PRM_EV_PR_SR_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRM_EV_PR_SR_ID" ON "RCRA_PRM_EVENT" ("PRM_SERIES_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PRM_FAC_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_PRM_FAC_SUBM" ON "RCRA_PRM_FAC_SUBM" ("PRM_FAC_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CM_SP_EN_PR_CM
--------------------------------------------------------

  CREATE INDEX "IX_CM_SP_EN_PR_CM" ON "RCRA_CME_SUPP_ENVR_PRJT" ("CME_ENFRC_ACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_FC_SB_FA_SB
--------------------------------------------------------

  CREATE INDEX "IX_FA_FC_SB_FA_SB" ON "RCRA_FA_FAC_SUBM" ("FA_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_EVAL
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_EVAL" ON "RCRA_CME_EVAL" ("CME_EVAL_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_FA_FAC_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_FA_FAC_SUBM" ON "RCRA_FA_FAC_SUBM" ("FA_FAC_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_CME_PY_CM_PN_ID
--------------------------------------------------------

  CREATE INDEX "IX_CME_PY_CM_PN_ID" ON "RCRA_CME_PYMT" ("CME_PNLTY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CM_ML_CM_EN_AC
--------------------------------------------------------

  CREATE INDEX "IX_CM_ML_CM_EN_AC" ON "RCRA_CME_MILESTONE" ("CME_ENFRC_ACT_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CA_AT_CA_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_CA_AT_CA_FC_SB" ON "RCRA_CA_AUTHORITY" ("CA_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CME_CSNY_DATE
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_CSNY_DATE" ON "RCRA_CME_CSNY_DATE" ("CME_CSNY_DATE_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_GIS_FAC_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_GIS_FAC_SUBM" ON "RCRA_GIS_FAC_SUBM" ("GIS_FAC_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_HD_SUBM
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_SUBM" ON "RCRA_HD_SUBM" ("HD_SUBM_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_GS_GO_IN_GS_FC
--------------------------------------------------------

  CREATE INDEX "IX_GS_GO_IN_GS_FC" ON "RCRA_GIS_GEO_INFORMATION" ("GIS_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FA_MC_DT_FA_MC
--------------------------------------------------------

  CREATE INDEX "IX_FA_MC_DT_FA_MC" ON "RCRA_FA_MECHANISM_DETAIL" ("FA_MECHANISM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PR_SR_PR_FC_SB
--------------------------------------------------------

  CREATE INDEX "IX_PR_SR_PR_FC_SB" ON "RCRA_PRM_SERIES" ("PRM_FAC_SUBM_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_HD_HANDLER
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_HD_HANDLER" ON "RCRA_HD_HANDLER" ("HD_HANDLER_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_RQST
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_RQST" ON "RCRA_CME_RQST" ("CME_RQST_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index PK_CME_EVAL_COMMIT
--------------------------------------------------------

--  CREATE UNIQUE INDEX "PK_CME_EVAL_COMMIT" ON "RCRA_CME_EVAL_COMMIT" ("CME_EVAL_COMMIT_ID") 
--  ;
--------------------------------------------------------
--  DDL for Index IX_HD_CER_HD_HA_ID
--------------------------------------------------------

  CREATE INDEX "IX_HD_CER_HD_HA_ID" ON "RCRA_HD_CERTIFICATION" ("HD_HANDLER_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CA_AR_RL_EV_CA
--------------------------------------------------------

  CREATE INDEX "IX_CA_AR_RL_EV_CA" ON "RCRA_CA_AREA_REL_EVENT" ("CA_AREA_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AREA
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AREA" ADD CONSTRAINT "FK_CA_ARA_CA_FC_SB" FOREIGN KEY ("CA_FAC_SUBM_ID")
	  REFERENCES "RCRA_CA_FAC_SUBM" ("CA_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AREA_REL_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AREA_REL_EVENT" ADD CONSTRAINT "FK_CA_AR_RL_EV_CA" FOREIGN KEY ("CA_AREA_ID")
	  REFERENCES "RCRA_CA_AREA" ("CA_AREA_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AUTHORITY
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AUTHORITY" ADD CONSTRAINT "FK_CA_ATH_CA_FC_SB" FOREIGN KEY ("CA_FAC_SUBM_ID")
	  REFERENCES "RCRA_CA_FAC_SUBM" ("CA_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_AUTH_REL_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_AUTH_REL_EVENT" ADD CONSTRAINT "FK_CA_AT_RL_EV_CA" FOREIGN KEY ("CA_AUTHORITY_ID")
	  REFERENCES "RCRA_CA_AUTHORITY" ("CA_AUTHORITY_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_EVENT" ADD CONSTRAINT "FK_CA_EVN_CA_FC_SB" FOREIGN KEY ("CA_FAC_SUBM_ID")
	  REFERENCES "RCRA_CA_FAC_SUBM" ("CA_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_EVENT_COMMITMENT" ADD CONSTRAINT "FK_CA_EVN_CM_CA_EV" FOREIGN KEY ("CA_EVENT_ID")
	  REFERENCES "RCRA_CA_EVENT" ("CA_EVENT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_FAC_SUBM" ADD CONSTRAINT "FK_CA_FC_SBM_CA_SB" FOREIGN KEY ("CA_SUBM_ID")
	  REFERENCES "RCRA_CA_SUBM" ("CA_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_REL_PERMIT_UNIT
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_REL_PERMIT_UNIT" ADD CONSTRAINT "FK_CA_RL_PR_UN_CA" FOREIGN KEY ("CA_AREA_ID")
	  REFERENCES "RCRA_CA_AREA" ("CA_AREA_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CA_STATUTORY_CITATION
--------------------------------------------------------

  ALTER TABLE "RCRA_CA_STATUTORY_CITATION" ADD CONSTRAINT "FK_CA_STT_CT_CA_AT" FOREIGN KEY ("CA_AUTHORITY_ID")
	  REFERENCES "RCRA_CA_AUTHORITY" ("CA_AUTHORITY_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_CITATION
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_CITATION" ADD CONSTRAINT "FK_CME_CTTN_CME_VL" FOREIGN KEY ("CME_VIOL_ID")
	  REFERENCES "RCRA_CME_VIOL" ("CME_VIOL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_CSNY_DATE
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_CSNY_DATE" ADD CONSTRAINT "FK_CM_CS_DT_CM_EN" FOREIGN KEY ("CME_ENFRC_ACT_ID")
	  REFERENCES "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_ENFRC_ACT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_ENFRC_ACT" ADD CONSTRAINT "FK_CM_EN_AC_CM_FC" FOREIGN KEY ("CME_FAC_SUBM_ID")
	  REFERENCES "RCRA_CME_FAC_SUBM" ("CME_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_EVAL" ADD CONSTRAINT "FK_CME_EV_CM_FC_SB" FOREIGN KEY ("CME_FAC_SUBM_ID")
	  REFERENCES "RCRA_CME_FAC_SUBM" ("CME_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL_COMMIT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_EVAL_COMMIT" ADD CONSTRAINT "FK_CME_EV_CM_CM_EV" FOREIGN KEY ("CME_EVAL_ID")
	  REFERENCES "RCRA_CME_EVAL" ("CME_EVAL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_EVAL_VIOL
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_EVAL_VIOL" ADD CONSTRAINT "FK_CME_EV_VL_CM_EV" FOREIGN KEY ("CME_EVAL_ID")
	  REFERENCES "RCRA_CME_EVAL" ("CME_EVAL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_FAC_SUBM" ADD CONSTRAINT "FK_CME_FC_SB_CM_SB" FOREIGN KEY ("CME_SUBM_ID")
	  REFERENCES "RCRA_CME_SUBM" ("CME_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_MEDIA
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_MEDIA" ADD CONSTRAINT "FK_CME_MD_CM_EN_AC" FOREIGN KEY ("CME_ENFRC_ACT_ID")
	  REFERENCES "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_MILESTONE
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_MILESTONE" ADD CONSTRAINT "FK_CME_ML_CM_EN_AC" FOREIGN KEY ("CME_ENFRC_ACT_ID")
	  REFERENCES "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_PNLTY
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_PNLTY" ADD CONSTRAINT "FK_CME_PN_CM_EN_AC" FOREIGN KEY ("CME_ENFRC_ACT_ID")
	  REFERENCES "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_PYMT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_PYMT" ADD CONSTRAINT "FK_CME_PYM_CME_PNL" FOREIGN KEY ("CME_PNLTY_ID")
	  REFERENCES "RCRA_CME_PNLTY" ("CME_PNLTY_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_RQST
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_RQST" ADD CONSTRAINT "FK_CME_RQS_CME_EVL" FOREIGN KEY ("CME_EVAL_ID")
	  REFERENCES "RCRA_CME_EVAL" ("CME_EVAL_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_SUPP_ENVR_PRJT
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_SUPP_ENVR_PRJT" ADD CONSTRAINT "FK_CM_SP_EN_PR_CM" FOREIGN KEY ("CME_ENFRC_ACT_ID")
	  REFERENCES "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_VIOL
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_VIOL" ADD CONSTRAINT "FK_CME_VL_CM_FC_SB" FOREIGN KEY ("CME_FAC_SUBM_ID")
	  REFERENCES "RCRA_CME_FAC_SUBM" ("CME_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_CME_VIOL_ENFRC
--------------------------------------------------------

  ALTER TABLE "RCRA_CME_VIOL_ENFRC" ADD CONSTRAINT "FK_CM_VL_EN_CM_EN" FOREIGN KEY ("CME_ENFRC_ACT_ID")
	  REFERENCES "RCRA_CME_ENFRC_ACT" ("CME_ENFRC_ACT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_COST_EST
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_COST_EST" ADD CONSTRAINT "FK_FA_CS_ES_FA_FC" FOREIGN KEY ("FA_FAC_SUBM_ID")
	  REFERENCES "RCRA_FA_FAC_SUBM" ("FA_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_COST_EST_REL_MECHANISM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_COST_EST_REL_MECHANISM" ADD CONSTRAINT "FK_FA_CS_ES_RL_MC" FOREIGN KEY ("FA_COST_EST_ID")
	  REFERENCES "RCRA_FA_COST_EST" ("FA_COST_EST_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_FAC_SUBM" ADD CONSTRAINT "FK_FA_FC_SBM_FA_SB" FOREIGN KEY ("FA_SUBM_ID")
	  REFERENCES "RCRA_FA_SUBM" ("FA_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_MECHANISM
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_MECHANISM" ADD CONSTRAINT "FK_FA_MCH_FA_FC_SB" FOREIGN KEY ("FA_FAC_SUBM_ID")
	  REFERENCES "RCRA_FA_FAC_SUBM" ("FA_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_FA_MECHANISM_DETAIL
--------------------------------------------------------

  ALTER TABLE "RCRA_FA_MECHANISM_DETAIL" ADD CONSTRAINT "FK_FA_MCH_DT_FA_MC" FOREIGN KEY ("FA_MECHANISM_ID")
	  REFERENCES "RCRA_FA_MECHANISM" ("FA_MECHANISM_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_GIS_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_GIS_FAC_SUBM" ADD CONSTRAINT "FK_GS_FC_SBM_GS_SB" FOREIGN KEY ("GIS_SUBM_ID")
	  REFERENCES "RCRA_GIS_SUBM" ("GIS_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_GIS_GEO_INFORMATION
--------------------------------------------------------

  ALTER TABLE "RCRA_GIS_GEO_INFORMATION" ADD CONSTRAINT "FK_GS_GO_IN_GS_FC" FOREIGN KEY ("GIS_FAC_SUBM_ID")
	  REFERENCES "RCRA_GIS_FAC_SUBM" ("GIS_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_CERTIFICATION
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_CERTIFICATION" ADD CONSTRAINT "FK_HD_CERT_HD_HAND" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_ENV_PERMIT
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_ENV_PERMIT" ADD CONSTRAINT "FK_HD_ENV_PE_HD_HA" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_HANDLER
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_HANDLER" ADD CONSTRAINT "FK_HD_HAND_HD_HBAS" FOREIGN KEY ("HD_HBASIC_ID")
	  REFERENCES "RCRA_HD_HBASIC" ("HD_HBASIC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_HBASIC
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_HBASIC" ADD CONSTRAINT "FK_HD_HBAS_HD_SUBM" FOREIGN KEY ("HD_SUBM_ID")
	  REFERENCES "RCRA_HD_SUBM" ("HD_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_NAICS
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_NAICS" ADD CONSTRAINT "FK_HD_NAIC_HD_HAND" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_OTHER_ID
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_OTHER_ID" ADD CONSTRAINT "FK_HD_OTH_ID_HD_HB" FOREIGN KEY ("HD_HBASIC_ID")
	  REFERENCES "RCRA_HD_HBASIC" ("HD_HBASIC_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_OWNEROP
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_OWNEROP" ADD CONSTRAINT "FK_HD_OWNE_HD_HAND" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_SEC_MATERIAL_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_SEC_MATERIAL_ACTIVITY" ADD CONSTRAINT "FK_HD_SE_MA_AC_HD" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_SEC_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_SEC_WASTE_CODE" ADD CONSTRAINT "FK_HD_SE_WA_CO_HD" FOREIGN KEY ("HD_SEC_MATERIAL_ACTIVITY_ID")
	  REFERENCES "RCRA_HD_SEC_MATERIAL_ACTIVITY" ("HD_SEC_MATERIAL_ACTIVITY_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_STATE_ACTIVITY
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_STATE_ACTIVITY" ADD CONSTRAINT "FK_HD_STA_AC_HD_HA" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_UNIVERSAL_WASTE
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_UNIVERSAL_WASTE" ADD CONSTRAINT "FK_HD_UNI_WA_HD_HA" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_HD_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE "RCRA_HD_WASTE_CODE" ADD CONSTRAINT "FK_HD_WAS_CO_HD_HA" FOREIGN KEY ("HD_HANDLER_ID")
	  REFERENCES "RCRA_HD_HANDLER" ("HD_HANDLER_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_EVENT" ADD CONSTRAINT "FK_PRM_EVN_PRM_SRS" FOREIGN KEY ("PRM_SERIES_ID")
	  REFERENCES "RCRA_PRM_SERIES" ("PRM_SERIES_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_EVENT_COMMITMENT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_EVENT_COMMITMENT" ADD CONSTRAINT "FK_PRM_EV_CM_PR_EV" FOREIGN KEY ("PRM_EVENT_ID")
	  REFERENCES "RCRA_PRM_EVENT" ("PRM_EVENT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_FAC_SUBM
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_FAC_SUBM" ADD CONSTRAINT "FK_PRM_FC_SB_PR_SB" FOREIGN KEY ("PRM_SUBM_ID")
	  REFERENCES "RCRA_PRM_SUBM" ("PRM_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_RELATED_EVENT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_RELATED_EVENT" ADD CONSTRAINT "FK_PR_RL_EV_PR_UN" FOREIGN KEY ("PRM_UNIT_DETAIL_ID")
	  REFERENCES "RCRA_PRM_UNIT_DETAIL" ("PRM_UNIT_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_SERIES
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_SERIES" ADD CONSTRAINT "FK_PRM_SR_PR_FC_SB" FOREIGN KEY ("PRM_FAC_SUBM_ID")
	  REFERENCES "RCRA_PRM_FAC_SUBM" ("PRM_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_UNIT
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_UNIT" ADD CONSTRAINT "FK_PRM_UN_PR_FC_SB" FOREIGN KEY ("PRM_FAC_SUBM_ID")
	  REFERENCES "RCRA_PRM_FAC_SUBM" ("PRM_FAC_SUBM_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_UNIT_DETAIL
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_UNIT_DETAIL" ADD CONSTRAINT "FK_PRM_UN_DT_PR_UN" FOREIGN KEY ("PRM_UNIT_ID")
	  REFERENCES "RCRA_PRM_UNIT" ("PRM_UNIT_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table RCRA_PRM_WASTE_CODE
--------------------------------------------------------

  ALTER TABLE "RCRA_PRM_WASTE_CODE" ADD CONSTRAINT "FK_PR_WS_CD_PR_UN" FOREIGN KEY ("PRM_UNIT_DETAIL_ID")
	  REFERENCES "RCRA_PRM_UNIT_DETAIL" ("PRM_UNIT_DETAIL_ID") ON DELETE CASCADE ENABLE;

	/****** Object:  Table RCRA_HD_LQG_CLOSURE    Script Date: 11/3/2017 4:03:18 PM ******/

	CREATE TABLE RCRA_HD_LQG_CLOSURE(
		HD_LQG_CLOSURE_ID varchar2(40) NOT NULL,
		HD_HANDLER_ID varchar2(40) NOT NULL,
		TRANSACTION_CODE char(1) NULL,
		CLOSURE_TYPE char(1) NULL,
		EXPECTED_CLOSURE_DATE DATE NULL,
		NEW_CLOSURE_DATE DATE NULL,
		DATE_CLOSED DATE NULL,
		IN_COMPLIANCE_IND char(1) NULL,
		CONSTRAINT PK_HD_LQG_CLOSURE PRIMARY KEY
			(
				HD_LQG_CLOSURE_ID
			)
	);

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.HD_LQG_CLOSURE_ID IS 'Parent: LQG closure info for a Handler';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.HD_HANDLER_ID IS 'Parent: Handler data (_FK)';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.CLOSURE_TYPE IS 'Type of the closure. (ClosureType)';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.EXPECTED_CLOSURE_DATE IS 'Date of expected closure. (ExpectedClosureDate)';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.NEW_CLOSURE_DATE IS 'New closure date. (NewClosureDate)';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.DATE_CLOSED IS 'Date of closed. (DateClosed)';

	COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.IN_COMPLIANCE_IND IS 'Type of in compliance. (InComplianceIndicator)';

	/****** Object:  Table RCRA_HD_LQG_CONSOLIDATION    Script Date: 11/3/2017 4:03:59 PM ******/

	CREATE TABLE RCRA_HD_LQG_CONSOLIDATION(
		HD_LQG_CONSOLIDATION_ID varchar2(40) NOT NULL,
		HD_HANDLER_ID varchar2(40) NOT NULL,
		TRANSACTION_CODE char(1) NULL,
		SEQ_NUMBER int NOT NULL,
		HANDLER_ID varchar2(12) NOT NULL,
		HANDLER_NAME varchar2(80) NULL,
		MAIL_STREET_NUMBER varchar2(12) NULL,
		MAIL_STREET1 varchar2(50) NULL,
		MAIL_STREET2 varchar2(50) NULL,
		MAIL_CITY varchar2(25) NULL,
		MAIL_STATE char(2) NULL,
		MAIL_COUNTRY char(2) NULL,
		MAIL_ZIP varchar2(14) NULL,
		CONTACT_FIRST_NAME varchar2(38) NULL,
		CONTACT_MIDDLE_INITIAL char(1) NULL,
		CONTACT_LAST_NAME varchar2(38) NULL,
		CONTACT_ORG_NAME varchar2(80) NULL,
		CONTACT_TITLE varchar2(80) NULL,
		CONTACT_EMAIL_ADDRESS varchar2(80) NULL,
		CONTACT_PHONE varchar2(15) NULL,
		CONTACT_PHONE_EXT varchar2(6) NULL,
		CONTACT_FAX varchar2(15) NULL,
		CONSTRAINT PK_HD_LQG_CONSOLIDATION PRIMARY KEY
			(
				HD_LQG_CONSOLIDATION_ID
			)
	);

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HD_LQG_CONSOLIDATION_ID IS 'Parent: LQG consolidation info for a Handler';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HD_HANDLER_ID IS 'Parent: Handler data (_FK)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.SEQ_NUMBER IS 'Unique number that identifies the Consolidation. (ConsolidationSequenceNumber)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HANDLER_NAME IS 'Name of the Handler (HandlerName)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET_NUMBER IS 'Parent: Mailing address information. (MailingAddressNumberText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET1 IS 'Parent: Mailing address information. (MailingAddressText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET2 IS 'Parent: Mailing address information. (SupplementalAddressText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_CITY IS 'Parent: Mailing address information. (MailingAddressCityName)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STATE IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_COUNTRY IS 'Parent: Mailing address information. (MailingAddressCountryName)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_ZIP IS 'Parent: Mailing address information. (MailingAddressZIPCode)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_FIRST_NAME IS 'Parent: First name of the contact. (FirstName)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_MIDDLE_INITIAL IS 'Parent: Middle initial of the contact. (MiddleInitial)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_LAST_NAME IS 'Parent: Last name of the contact. (LastName)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_ORG_NAME IS 'Parent: Name of the contact organization. (OrganizationFormalName)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_TITLE IS 'Title of the contact person (IndividualTitleText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_EMAIL_ADDRESS IS 'Email address data (EmailAddressText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_PHONE IS 'Telephone Number data (TelephoneNumberText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_PHONE_EXT IS 'Telephone number extension (PhoneExtensionText)';

	COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_FAX IS 'Contact fax number (FaxNumberText)';

	/****** Object:  Table RCRA_HD_EPISODIC_EVENT    Script Date: 11/3/2017 3:54:39 PM ******/

	CREATE TABLE RCRA_HD_EPISODIC_EVENT(
		HD_EPISODIC_EVENT_ID varchar2(40) NOT NULL,
		HD_HANDLER_ID varchar2(40) NOT NULL,
		TRANSACTION_CODE char(1) NULL,
		EVENT_OWNER char(2) NULL,
		EVENT_TYPE varchar2(3) NULL,
		EVENT_OTHER_DESC varchar2(80) NULL,
		CONTACT_FIRST_NAME varchar2(38) NULL,
		CONTACT_MIDDLE_INITIAL char(1) NULL,
		CONTACT_LAST_NAME varchar2(38) NULL,
		CONTACT_ORG_NAME varchar2(80) NULL,
		CONTACT_TITLE varchar2(80) NULL,
		CONTACT_EMAIL_ADDRESS varchar2(80) NULL,
		CONTACT_PHONE varchar2(15) NULL,
		CONTACT_PHONE_EXT varchar2(6) NULL,
		CONTACT_FAX varchar2(15) NULL,
		START_DATE DATE NULL,
		END_DATE DATE NULL,
		CONSTRAINT PK_HD_EPISODIC_EVENT PRIMARY KEY
			(
				HD_EPISODIC_EVENT_ID
			)
	);

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.HD_EPISODIC_EVENT_ID IS 'Parent: Episodic event info for a Handler';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.HD_HANDLER_ID IS 'Parent: Handler data (_FK)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.EVENT_OWNER IS 'Owner of the episodic event. (EpisodicEventOwner)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.EVENT_TYPE IS 'Type of the episodic event. (EpisodicEventType)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.EVENT_OTHER_DESC IS 'Other description of the episodic event. (EpisodicEventOtherDescription)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_FIRST_NAME IS 'First name of the contact. (FirstName)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_MIDDLE_INITIAL IS 'Middle initial of the contact. (MiddleInitial)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_LAST_NAME IS 'Last name of the contact. (LastName)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_ORG_NAME IS 'Contact organization name. (OrganizationFormalName)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_TITLE IS 'Title of the contact. (IndividualTitleText)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_EMAIL_ADDRESS IS 'Email address of the contact. (EmailAddressText)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_PHONE IS 'Telephone number of the contact. (TelephoneNumberText)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_PHONE_EXT IS 'Phone extension of the contact. (PhoneExtensionText)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_FAX IS 'Fax number of the contact. (FaxNumberText)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.START_DATE IS 'Episodic event start event. (EpisodicEventStartDate)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.END_DATE IS 'Episodic event end event. (EpisodicEventEndDate)';

	/****** Object:  Table RCRA_HD_EPISODIC_WASTE    Script Date: 11/3/2017 3:57:52 PM ******/

	CREATE TABLE RCRA_HD_EPISODIC_WASTE(
		HD_EPISODIC_WASTE_ID varchar2(40) NOT NULL,
		HD_EPISODIC_EVENT_ID varchar2(40) NOT NULL,
		TRANSACTION_CODE char(1) NULL,
		SEQ_NUMBER int NULL,
		WASTE_DESC varchar2(4000) NULL,
		EST_QNTY int NULL,
		CONSTRAINT PK_HD_EPISODIC_WASTE PRIMARY KEY
			(
				HD_EPISODIC_WASTE_ID
			)
	);

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.HD_EPISODIC_WASTE_ID IS 'Parent: Episodic waste info for a Handler Episodic Event';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.HD_EPISODIC_EVENT_ID IS 'Parent: Episode event data (_FK)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.SEQ_NUMBER IS 'Unique number that identifies the episodic waste. (EpisodicWasteSequenceNumber)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.WASTE_DESC IS 'Waste description. (WasteDescription)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.EST_QNTY IS 'The quantity of waste that is handled by each process code. This element pertains only to Part A submissions. (EstimatedQuantity)';

	/****** Object:  Table RCRA_HD_EPISODIC_WASTE_CODE    Script Date: 11/3/2017 3:59:31 PM ******/

	CREATE TABLE RCRA_HD_EPISODIC_WASTE_CODE(
		HD_EPISODIC_WASTE_CODE_ID varchar2(40) NOT NULL,
		HD_EPISODIC_WASTE_ID varchar2(40) NOT NULL,
		TRANSACTION_CODE char(1) NULL,
		WASTE_CODE_OWNER char(2) NULL,
		WASTE_CODE varchar2(6) NULL,
		WASTE_CODE_TEXT varchar2(80) NULL,
		CONSTRAINT PK_HD_EPISODIC_WASTE_CODE PRIMARY KEY
			(
				HD_EPISODIC_WASTE_CODE_ID
			)
	);

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.HD_EPISODIC_WASTE_CODE_ID IS 'Parent: Episodic waste code details for Handler Episodic Waste';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.HD_EPISODIC_WASTE_ID IS 'Parent: Episodic waste data (_FK)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE_OWNER IS 'Owner and definer of the waste code. (WasteCodeOwnerName)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE IS 'Code used to describe hazardous waste. (WasteCode)';

	COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE_TEXT IS 'Descriptive text describing the Waste Code (Data publishing only). (WasteCodeText)';

	/****** Object:  Table RCRA_RU_SUBM    Script Date: 11/3/2017 4:00:19 PM ******/

	CREATE TABLE RCRA_RU_SUBM(
		RU_SUBM_ID varchar2(40) NOT NULL,
		DATA_ACCESS varchar2(10),
		CONSTRAINT PK_RU_SUBM PRIMARY KEY
			(
				RU_SUBM_ID
			)
	);

	COMMENT ON COLUMN RCRA_RU_SUBM.RU_SUBM_ID IS 'Parent: Universal waste report submission';

	/****** Object:  Table RCRA_RU_REPORT_UNIV_SUBM    Script Date: 11/3/2017 4:00:19 PM ******/

	CREATE TABLE RCRA_RU_REPORT_UNIV_SUBM(
		RU_REPORT_UNIV_SUBM_ID varchar2(40) NOT NULL,
		RU_SUBM_ID varchar2(40) NOT NULL,
		CONSTRAINT PK_RU_REPORT_UNIV_SUBM PRIMARY KEY
			(
				RU_REPORT_UNIV_SUBM_ID
			)
	);

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV_SUBM.RU_REPORT_UNIV_SUBM_ID IS 'Parent: Universal waste report submission. (_PK)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV_SUBM.RU_SUBM_ID IS 'Parent: Universal waste report submission. (_FK)';

	/****** Object:  Table RCRA_RU_REPORT_UNIV    Script Date: 11/3/2017 4:00:11 PM ******/

	CREATE TABLE RCRA_RU_REPORT_UNIV(
		RU_REPORT_UNIV_ID varchar2(40) NOT NULL,
		RU_REPORT_UNIV_SUBM_ID varchar2(40) NOT NULL,
		HANDLER_ID varchar2(12) NOT NULL,
		ACTIVITY_LOCATION char(2) NOT NULL,
		SOURCE_TYPE char(1) NULL,
		SEQ_NUMBER int NULL,
		RECEIVE_DATE DATE NULL,
		HANDLER_NAME varchar2(80) NULL,
		NON_NOTIFIER_IND char(1) NULL,
		ACCESSIBILITY char(1) NULL,
		REPORT_CYCLE int NULL,
		REGION char(2) NULL,
		STATE char(2) NULL,
		EXTRACT_FLAG char(1) NULL,
		ACTIVE_SITE varchar2(5) NULL,
		COUNTY_CODE varchar2(5) NULL,
		COUNTY_NAME varchar2(80) NULL,
		LOCATION_STREET_NUMBER varchar2(12) NULL,
		LOCATION_STREET1 varchar2(50) NULL,
		LOCATION_STREET2 varchar2(50) NULL,
		LOCATION_CITY varchar2(25) NULL,
		LOCATION_STATE char(2) NULL,
		LOCATION_COUNTRY char(2) NULL,
		LOCATION_ZIP char(14) NULL,
		MAIL_STREET_NUMBER varchar2(12) NULL,
		MAIL_STREET1 varchar2(50) NULL,
		MAIL_STREET2 varchar2(50) NULL,
		MAIL_CITY varchar2(25) NULL,
		MAIL_STATE char(2) NULL,
		MAIL_COUNTRY char(2) NULL,
		MAIL_ZIP varchar2(14) NULL,
		CONTACT_STREET_NUMBER varchar2(12) NULL,
		CONTACT_STREET1 varchar2(50) NULL,
		CONTACT_STREET2 varchar2(50) NULL,
		CONTACT_CITY varchar2(25) NULL,
		CONTACT_STATE char(2) NULL,
		CONTACT_COUNTRY char(2) NULL,
		CONTACT_ZIP varchar2(14) NULL,
		CONTACT_NAME varchar2(80) NULL,
		CONTACT_PHONE varchar2(22) NULL,
		CONTACT_FAX varchar2(15) NULL,
		CONTACT_EMAIL varchar2(80) NULL,
		CONTACT_TITLE varchar2(45) NULL,
		OWNER_NAME varchar2(80) NULL,
		OWNER_TYPE char(1) NULL,
		OWNER_SEQ_NUM int NULL,
		OPER_NAME varchar2(80) NULL,
		OPER_TYPE char(1) NULL,
		OPER_SEQ_NUM int NULL,
		NAIC1_CODE varchar2(6) NULL,
		NAIC2_CODE varchar2(6) NULL,
		NAIC3_CODE varchar2(6) NULL,
		NAIC4_CODE varchar2(6) NULL,
		IN_HANDLER_UNIVERSE char(1) NULL,
		IN_A_UNIVERSE char(1) NULL,
		FED_WASTE_GENERATOR_OWNER char(2) NULL,
		FED_WASTE_GENERATOR char(1) NULL,
		STATE_WASTE_GENERATOR_OWNER char(2) NULL,
		STATE_WASTE_GENERATOR char(1) NULL,
		GEN_STATUS varchar2(3) NULL,
		UNIV_WASTE char(1) NULL,
		LAND_TYPE char(1) NULL,
		STATE_DISTRICT_OWNER char(2) NULL,
		STATE_DISTRICT varchar2(10) NULL,
		SHORT_TERM_GEN_IND char(1) NULL,
		IMPORTER_ACTIVITY char(1) NULL,
		MIXED_WASTE_GENERATOR char(1) NULL,
		TRANSPORTER_ACTIVITY char(1) NULL,
		TRANSFER_FACILITY_IND char(1) NULL,
		RECYCLER_ACTIVITY char(1) NULL,
		ONSITE_BURNER_EXEMPTION char(1) NULL,
		FURNACE_EXEMPTION char(1) NULL,
		UNDERGROUND_INJECTION_ACTIVITY char(1) NULL,
		UNIVERSAL_WASTE_DEST_FACILITY char(1) NULL,
		OFFSITE_WASTE_RECEIPT char(1) NULL,
		USED_OIL varchar(7) NULL,
		FEDERAL_UNIVERSAL_WASTE char(1) NULL,
		AS_FEDERAL_REGULATED_TSDF varchar2(6) NULL,
		AS_CONVERTED_TSDF varchar2(6) NULL,
		AS_STATE_REGULATED_TSDF varchar2(9) NULL,
		FEDERAL_IND varchar2(3) NULL,
		HSM char(2) NULL,
		SUBPART_K varchar2(4) NULL,
		COMMERCIAL_TSD char(1) NULL,
		TSD varchar2(5) NULL,
		GPRA_PERMIT char(1) NULL,
		GPRA_RENEWAL char(1) NULL,
		PERMIT_RENEWAL_WRKLD varchar2(6) NULL,
		PERM_WRKLD varchar2(6) NULL,
		PERM_PROG varchar2(6) NULL,
		PC_WRKLD varchar2(6) NULL,
		CLOS_WRKLD varchar2(6) NULL,
		GPRACA char(1) NULL,
		CA_WRKLD char(1) NULL,
		SUBJ_CA char(1) NULL,
		SUBJ_CA_NON_TSD char(1) NULL,
		SUBJ_CA_TSD_3004 char(1) NULL,
		SUBJ_CA_DISCRETION char(1) NULL,
		NCAPS char(1) NULL,
		EC_IND char(1) NULL,
		IC_IND char(1) NULL,
		CA_725_IND char(1) NULL,
		CA_750_IND char(1) NULL,
		OPERATING_TSDF varchar2(6) NULL,
		FULL_ENFORCEMENT varchar2(6) NULL,
		SNC char(1) NULL,
		BOY_SNC char(1) NULL,
		BOY_STATE_UNADDRESSED_SNC char(1) NULL,
		STATE_UNADDRESSED char(1) NULL,
		STATE_ADDRESSED char(1) NULL,
		BOY_STATE_ADDRESSED char(1) NULL,
		STATE_SNC_WITH_COMP_SCHED char(1) NULL,
		BOY_STATE_SNC_WITH_COMP_SCHED char(1) NULL,
		EPA_UNADDRESSED char(1) NULL,
		BOY_EPA_UNADDRESSED char(1) NULL,
		EPA_ADDRESSED char(1) NULL,
		BOY_EPA_ADDRESSED char(1) NULL,
		EPA_SNC_WITH_COMP_SCHED char(1) NULL,
		BOY_EPA_SNC_WITH_COMP_SCHED char(1) NULL,
		FA_REQUIRED varchar(5) NULL,
		HHANDLER_LAST_CHANGE_DATE DATE NULL,
		PUBLIC_NOTES varchar2(4000) NULL,
		NOTES varchar2(4000) NULL,
		RECOGNIZED_TRADER_IMPORTER_IND char(1) NULL,
		RECOGNIZED_TRADER_EXPORTER_IND char(1) NULL,
		SLAB_IMPORTER_IND char(1) NULL,
		SLAB_EXPORTER_IND char(1) NULL,
		RECYCLER_NON_STORAGE_IND char(1) NULL,
		MANIFEST_BROKER_IND char(1) NULL,
		CONSTRAINT PK_RU_REPORT_UNIV PRIMARY KEY
			(
				RU_REPORT_UNIV_ID
			)
	);

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RU_REPORT_UNIV_ID IS 'Parent: Universal waste report details';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RU_REPORT_UNIV_SUBM_ID IS 'Parent: Universal waste report submission. (_FK)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerIdCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ACTIVITY_LOCATION IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SOURCE_TYPE IS 'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SEQ_NUMBER IS 'Sequence number for each source record about a handler. (SequenceNumber)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECEIVE_DATE IS 'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HANDLER_NAME IS 'Name of the Handler (HandlerName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NON_NOTIFIER_IND IS 'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ACCESSIBILITY IS 'Reason why the handler is not accessible for normal processing (Bankrupt Indicator). (Accessibility)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.REPORT_CYCLE IS 'Report cycle. (ReportCycle)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.REGION IS 'Region (Region)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE IS 'State (State)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EXTRACT_FLAG IS 'Extract flag (ExtractFlag)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ACTIVE_SITE IS 'Active site (ActiveSite)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.COUNTY_CODE IS 'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.COUNTY_NAME IS 'Descriptive text describing the County Name(Data publishing only). (CountyName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STREET_NUMBER IS 'Number portion of the location street address of the handler. (LocationAddressNumberText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STREET1 IS 'Street address of the handler. (LocationAddressText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STREET2 IS 'Supplemental address of the handler. (SupplementalLocationText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_CITY IS 'City in which the handler is located. (LocalityName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STATE IS 'State in which the handler is located. (StateUSPSCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_COUNTRY IS 'Country in which the handler is located. (CountryName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_ZIP IS 'ZIP code in which the handler is located. (LocationZIPCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STREET_NUMBER IS 'Number portion of the mailing address of the handler. (MailingAddressNumberText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STREET1 IS 'Street address of the handler mailing address. (MailingAddressText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STREET2 IS 'Supplemental address of the handler mailing address. (SupplementalLocationText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_CITY IS 'City of the handler mailing address. (MailingAddressCityName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STATE IS 'State of the handler mailing address. (MailingAddressStateUSPSCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_COUNTRY IS 'Country of the handler mailing address. (MailingAddressCountryName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_ZIP IS 'ZIP code of the handler mailing address. (MailingAddressZIPCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STREET_NUMBER IS 'Number portion of the mailing address of the handler contact. (MailingAddressNumberText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STREET1 IS 'Street address of the handler contact mailing address. (MailingAddressText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STREET2 IS 'Supplemental address of the handler contact mailing address. (SupplementalLocationText)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_CITY IS 'City of the handler contact mailing address. (MailingAddressCityName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STATE IS 'State of the handler contact mailing address. (MailingAddressStateUSPSCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_COUNTRY IS 'Country of the handler contact mailing address. (MailingAddressCountryName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_ZIP IS 'ZIP code of the handler contact mailing address. (MailingAddressZIPCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_NAME IS 'Handler contact name (first + last). (ContactNameCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_PHONE IS 'Handler contact phone number. (ContactPhoneCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_FAX IS 'Handler contact fax number. (ContactFaxCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_EMAIL IS 'Handler contact email address. (ContactEmailCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_TITLE IS 'Handler contact title. (ContactTitleCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OWNER_NAME IS 'Handler owner name. (OwnerNameCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OWNER_TYPE IS 'Handler owner type. (OwnerTypeCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OWNER_SEQ_NUM IS 'Handler owner sequence number. (OwnerSeqCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPER_NAME IS 'Handler operator name. (OperatorNameCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPER_TYPE IS 'Handler operator type. (OperatorTypeCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPER_SEQ_NUM IS 'Handler operator sequence number. (OperatorSeqCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC1_CODE IS 'NAIC 1 code (NAIC1Code)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC2_CODE IS 'NAIC 2 code (NAIC2Code)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC3_CODE IS 'NAIC 3 code (NAIC3Code)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC4_CODE IS 'NAIC 4 code (NAIC4Code)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IN_HANDLER_UNIVERSE IS 'In handler universe (InHandlerUniverseCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IN_A_UNIVERSE IS 'In a universe (InAUniverseCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FED_WASTE_GENERATOR_OWNER IS 'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorOwner)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FED_WASTE_GENERATOR IS 'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_WASTE_GENERATOR_OWNER IS 'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorOwner)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_WASTE_GENERATOR IS 'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GEN_STATUS IS 'Gen status (GENSTATUS)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.UNIV_WASTE IS 'Univ waste (UNIVWASTE)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LAND_TYPE IS 'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_DISTRICT_OWNER IS 'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_DISTRICT IS 'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SHORT_TERM_GEN_IND IS 'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IMPORTER_ACTIVITY IS 'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MIXED_WASTE_GENERATOR IS 'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.TRANSPORTER_ACTIVITY IS 'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.TRANSFER_FACILITY_IND IS 'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECYCLER_ACTIVITY IS 'Code for recycling hazardous waste. (RecyclerActivityCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ONSITE_BURNER_EXEMPTION IS 'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FURNACE_EXEMPTION IS 'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.UNDERGROUND_INJECTION_ACTIVITY IS 'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.UNIVERSAL_WASTE_DEST_FACILITY IS 'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OFFSITE_WASTE_RECEIPT IS 'Off site waste receipt (OffSiteWasteReceiptCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.USED_OIL IS 'Used oil code (UsedOilCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FEDERAL_UNIVERSAL_WASTE IS 'Federal universal waste (FederalUniversalWasteCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.AS_FEDERAL_REGULATED_TSDF IS 'As federal regulated TSDF (AsFederalRegulatedTSDFCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.AS_CONVERTED_TSDF IS 'As converter TSDF (AsConverterTSDFCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.AS_STATE_REGULATED_TSDF IS 'As state regulated TSDF (AsStateRegulatedTSDFCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FEDERAL_IND IS 'Federal indicator (FederalIndicatorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HSM IS 'HSM code (HSMCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBPART_K IS 'Subpart K code (SubpartKCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.COMMERCIAL_TSD IS 'Commercial TSD code (CommercialTSDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.TSD IS 'TSD type (TSDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GPRA_PERMIT IS 'GPRA permit (GPRAPermitCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GPRA_RENEWAL IS 'GPRA renewal code (GPRARenewalCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PERMIT_RENEWAL_WRKLD IS 'Permit renewal WRKLD (PermitRenewalWRKLDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PERM_WRKLD IS 'Perm WRKLD (PermWRKLDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PERM_PROG IS 'Perm PROG (PermPROGCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PC_WRKLD IS 'PC WRKLD (PCWRKLDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CLOS_WRKLD IS 'Clos WRKLD (ClosWRKLDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GPRACA IS 'GPRACA (GPRACACode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CA_WRKLD IS 'CAWRKLD (CAWRKLDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA IS 'Subj CA (SubjCACode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA_NON_TSD IS 'Subj CA non TSD (SubjCANonTSDCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA_TSD_3004 IS 'Subj CA TSD 3004 (SubjCATSD3004Code)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA_DISCRETION IS 'Subj CA discretion (SubjCADiscretionCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NCAPS IS 'NCAPS (NCAPSCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EC_IND IS 'EC indicator (ECIndicatorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IC_IND IS 'IC indicator (ICIndicatorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CA_725_IND IS 'CA 725 indicator (CA725IndicatorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CA_750_IND IS 'CA 750 indicator (CA750IndicatorCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPERATING_TSDF IS 'Operating TSDF (OperatingTSDFCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FULL_ENFORCEMENT IS 'Full enforcement (FullEnforcementCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SNC IS 'SNC (SNCCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_SNC IS 'BOY SNC (BOYSNCCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_STATE_UNADDRESSED_SNC IS 'BOY state unaddressed SNC (BOYStateUnaddressedSNCCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_UNADDRESSED IS 'State unaddressed (StateUnaddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_ADDRESSED IS 'State addressed (StateAddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_STATE_ADDRESSED IS 'BOY state addressed (BOYStateAddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_SNC_WITH_COMP_SCHED IS 'State SNC with comp sched (StateSNCWithCompSchedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_STATE_SNC_WITH_COMP_SCHED IS 'BOY state SNC with comp sched (BOYStateSNCWithCompSchedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EPA_UNADDRESSED IS 'EPA unaddressed (EPAUnaddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_EPA_UNADDRESSED IS 'BOY EPA unaddressed (BOYEPAUnaddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EPA_ADDRESSED IS 'EPA addressed (EPAAddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_EPA_ADDRESSED IS 'BOY EPA addressed (BOYEPAAddressedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EPA_SNC_WITH_COMP_SCHED IS 'EPA SNC with comp sched (EPASNCWithcompSchedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_EPA_SNC_WITH_COMP_SCHED IS 'BOY EPA SNC with comp sched (BOYEPASNCWithcompSchedCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FA_REQUIRED IS 'FA required (FARequiredCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HHANDLER_LAST_CHANGE_DATE IS 'HHandler last change date (HHandlerLastChangeDate)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PUBLIC_NOTES IS 'Notes (PublicNotesCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NOTES IS 'Notes (NotesCode)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECOGNIZED_TRADER_IMPORTER_IND IS 'Indicates that the Handler is participating in Import Trading activity. Possible values are: Y/N (RecognizedTraderImporterIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECOGNIZED_TRADER_EXPORTER_IND IS 'Indicates that the Handler is participating in Export Trading activity. Possible values are: Y/N (RecognizedTraderExporterIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SLAB_IMPORTER_IND IS 'Indicates that the Handler is participating in Slab Import activity. Possible values are: Y/N (SlabImporterIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SLAB_EXPORTER_IND IS 'Indicates that the Handler is participating in Slab Export activity. Possible values are: Y/N (SlabExporterIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECYCLER_NON_STORAGE_IND IS 'Recycle non storage (RecyclerNonStorageIndicator)';

	COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MANIFEST_BROKER_IND IS 'Manifest broker (ManifestBrokerIndicator)';

	ALTER TABLE RCRA_HD_LQG_CONSOLIDATION  ADD  CONSTRAINT FK_HD_LQG_CONSOL_HANDLER_ID FOREIGN KEY(HD_HANDLER_ID)
	REFERENCES RCRA_HD_HANDLER (HD_HANDLER_ID)
		ON DELETE CASCADE;

	ALTER TABLE RCRA_HD_LQG_CLOSURE  ADD  CONSTRAINT FK_HD_LQG_CLOS_HANDLER_ID FOREIGN KEY(HD_HANDLER_ID)
	REFERENCES RCRA_HD_HANDLER (HD_HANDLER_ID)
		ON DELETE CASCADE;

	ALTER TABLE RCRA_HD_EPISODIC_EVENT  ADD  CONSTRAINT FK_HD_EPIS_EVT_HANDLER_ID FOREIGN KEY(HD_HANDLER_ID)
	REFERENCES RCRA_HD_HANDLER (HD_HANDLER_ID)
		ON DELETE CASCADE;

	ALTER TABLE RCRA_HD_EPISODIC_WASTE  ADD  CONSTRAINT FK_HD_EPIS_WASTE_EVT_ID FOREIGN KEY(HD_EPISODIC_EVENT_ID)
	REFERENCES RCRA_HD_EPISODIC_EVENT (HD_EPISODIC_EVENT_ID)
		ON DELETE CASCADE;

	ALTER TABLE RCRA_HD_EPISODIC_WASTE_CODE  ADD  CONSTRAINT FK_HD_EPIS_WASTE_CD_WASTE_ID FOREIGN KEY(HD_EPISODIC_WASTE_ID)
	REFERENCES RCRA_HD_EPISODIC_WASTE (HD_EPISODIC_WASTE_ID)
		ON DELETE CASCADE;

	ALTER TABLE RCRA_RU_REPORT_UNIV_SUBM  ADD CONSTRAINT FK_RU_REPORT_UNIV_SUBM_PAR_ID FOREIGN KEY(RU_SUBM_ID)
	REFERENCES RCRA_RU_SUBM (RU_SUBM_ID)
		ON DELETE CASCADE;

	ALTER TABLE RCRA_RU_REPORT_UNIV ADD CONSTRAINT FK_RU_REPORT_UNIV_PARENT_ID FOREIGN KEY(RU_REPORT_UNIV_SUBM_ID)
	REFERENCES RCRA_RU_REPORT_UNIV_SUBM (RU_REPORT_UNIV_SUBM_ID)
		ON DELETE CASCADE;
