/******************************************************************************************************************************
 ** ObjectName: AQS_2.1_SQL_DLL.sql
 **
 ** Author: Windsor Solutions, Inc.
 **
 ** Company Name: Windsor Solutions, Inc
 **
 ** Description:  This SQL Server script will create the set of AQS data staging tables.
 **
 ** Notes:  Run drops statements only if schema already exists, Otherwise, just run the create statements.
 **
 **
 ** Revision History:      
 ** ----------------------------------------------------------------------------------------------------------------------------
 **  Date         Name        Description
 ** ----------------------------------------------------------------------------------------------------------------------------
 ** 07/11/2013    Windsor     Original                    
 ** 
 ******************************************************************************************************************************/
/*
ALTER TABLE [AQS_TRANS_PROTOCOL]
	DROP CONSTRAINT [FK_MONITOR_ID]
GO

ALTER TABLE [AQS_RES_QUAL_CD]
	DROP CONSTRAINT [FK_RAW_RES]
GO

ALTER TABLE [AQS_RAW_RES]
	DROP CONSTRAINT [FK_TRANS_PROTOCOL]
GO

ALTER TABLE [AQS_RAW_PREC_INFO]
	DROP CONSTRAINT [FK_TRANS_PROTOCOL_PREC_INFO]
GO

ALTER TABLE [AQS_RAW_COMP_INFO]
	DROP CONSTRAINT [FK_TRANS_PROTOCOL_COMP_INFO]
GO

ALTER TABLE [AQS_RAW_ACCU_INFO]
	DROP CONSTRAINT [FK_TRANS_PROTOCOL_ACCU_INFO]
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_SCHD]
	DROP CONSTRAINT [FK_MONITOR_SAMPLE_SCHD]
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_PRD]
	DROP CONSTRAINT [FK_MONITOR_SAMPLE_ID]
GO

ALTER TABLE [AQS_MONITOR_OBJ_INFO]
	DROP CONSTRAINT [FK_MONITOR_OBJ_INFO_ID]
GO

ALTER TABLE [AQS_MONITOR_ID]
	DROP CONSTRAINT [FK_SITE_ID]
GO

ALTER TABLE [AQS_COMP_RES_QUAL_CD]
	DROP CONSTRAINT [FK_COMP_INFO]
GO

ALTER TABLE [AQS_BLANK_RES_QUAL_CD]
	DROP CONSTRAINT [FK_BLANK_INFO]
GO

ALTER TABLE [AQS_BLANK_INFO]
	DROP CONSTRAINT [FK_TRANS_PROTOCOL_BLANK_INFO]
GO

ALTER TABLE [AQS_ANNUAL_SUM_INFO]
	DROP CONSTRAINT [FK_TRANS_PROTOCOL_ANNUAL_SUM]
GO

ALTER TABLE [AQS_TRANS_PROTOCOL]
	DROP CONSTRAINT [PK_TRANS_PROTOCOL]
GO

ALTER TABLE [AQS_SITE_ID]
	DROP CONSTRAINT [PK_SITE_ID]
GO

ALTER TABLE [AQS_RES_QUAL_CD]
	DROP CONSTRAINT [PK_RES_QUAL_CD]
GO

ALTER TABLE [AQS_RAW_RES]
	DROP CONSTRAINT [PK_RAW_RES]
GO

ALTER TABLE [AQS_RAW_PREC_INFO]
	DROP CONSTRAINT [PK_RAW_PREC_INFO]
GO

ALTER TABLE [AQS_RAW_COMP_INFO]
	DROP CONSTRAINT [PK_RAW_COMP_INFO]
GO

ALTER TABLE [AQS_RAW_ACCU_INFO]
	DROP CONSTRAINT [PK_RAW_ACCU_INFO]
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_SCHD]
	DROP CONSTRAINT [PK_MONITOR_SAMPLE_SCHD]
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_PRD]
	DROP CONSTRAINT [PK_MONITOR_SAMPLE_PRD]
GO

ALTER TABLE [AQS_MONITOR_OBJ_INFO]
	DROP CONSTRAINT [PK_MONITOR_OBJ_INFO]
GO

ALTER TABLE [AQS_MONITOR_ID]
	DROP CONSTRAINT [PK_MONITOR_ID]
GO

ALTER TABLE [AQS_METADATA]
	DROP CONSTRAINT [PK_METADATA]
GO

ALTER TABLE [AQS_COMP_RES_QUAL_CD]
	DROP CONSTRAINT [PK_COMP_RES_QUAL_CD]
GO

ALTER TABLE [AQS_BLANK_RES_QUAL_CD]
	DROP CONSTRAINT [PK_BLANK_RES_QUAL_CD]
GO

ALTER TABLE [AQS_BLANK_INFO]
	DROP CONSTRAINT [PK_BLANK_INFO]
GO

ALTER TABLE [AQS_ANNUAL_SUM_INFO]
	DROP CONSTRAINT [PK_ANNUAL_SUM_INFO]
GO

DROP PROCEDURE [AQS_CHECK_METADATA]
GO

DROP TABLE [AQS_TRANS_PROTOCOL]
GO

DROP TABLE [AQS_SITE_ID]
GO

DROP TABLE [AQS_RES_QUAL_CD]
GO

DROP TABLE [AQS_RAW_RES]
GO

DROP TABLE [AQS_RAW_PREC_INFO]
GO

DROP TABLE [AQS_RAW_COMP_INFO]
GO

DROP TABLE [AQS_RAW_ACCU_INFO]
GO

DROP TABLE [AQS_MONITOR_SAMPLE_SCHD]
GO

DROP TABLE [AQS_MONITOR_SAMPLE_PRD]
GO

DROP TABLE [AQS_MONITOR_OBJ_INFO]
GO

DROP TABLE [AQS_MONITOR_ID]
GO

DROP TABLE [AQS_METADATA]
GO

DROP TABLE [AQS_COMP_RES_QUAL_CD]
GO

DROP TABLE [AQS_BLANK_RES_QUAL_CD]
GO

DROP TABLE [AQS_BLANK_INFO]
GO

DROP TABLE [AQS_ANNUAL_SUM_INFO]
GO
*/

CREATE TABLE [AQS_ANNUAL_SUM_INFO] ( 
	[AQS_ANNUAL_SUM_INFO_PK] 	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_FK]  	INT NOT NULL,
	[ACTION_CD]              	VARCHAR(1) NOT NULL,
	[SUM_YEAR]               	VARCHAR(4) NOT NULL,
	[EXCEP_DATA_TYPE_CD]     	DECIMAL(1,0) NOT NULL,
	[OBSERVATION_COUNT]      	DECIMAL(5,0) NULL,
	[EVENTS_COUNT]           	DECIMAL(5,0) NULL,
	[HIGH_SMPL_VALUE]        	DECIMAL(10,5) NULL,
	[HIGH_SMPL_DATE]         	VARCHAR(10) NULL,
	[HIGH_SMPL_TIME]         	VARCHAR(8) NULL,
	[SEC_HIGH_SMPL_VALUE]    	DECIMAL(10,5) NULL,
	[SEC_HIGH_SMPL_DATE]     	VARCHAR(10) NULL,
	[SEC_HIGH_SMPL_TIME]     	VARCHAR(8) NULL,
	[THIRD_HIGH_SMPL_VALUE]  	DECIMAL(10,5) NULL,
	[FOURTH_HIGH_SMPL_VALUE] 	DECIMAL(10,5) NULL,
	[FIFTH_HIGH_SMPL_VALUE]  	DECIMAL(10,5) NULL,
	[LOW_SMPL_VALUE]         	DECIMAL(10,5) NULL,
	[ARTH_MEAN_VALUE]        	DECIMAL(10,5) NULL,
	[ARTH_STD_DEV_VALUE]     	DECIMAL(10,5) NULL,
	[GEO_MEAN_VALUE]         	DECIMAL(10,5) NULL,
	[GEO_STD_DEV_VALUE]      	DECIMAL(10,5) NULL,
	[TENTH_PER_VALUE]        	DECIMAL(10,5) NULL,
	[TWENTY_FIFTH_PER_VALUE] 	DECIMAL(10,5) NULL,
	[FIFTIETH_PER_VALUE]     	DECIMAL(10,5) NULL,
	[SEVENTY_FIFTH_PER_VALUE]	DECIMAL(10,5) NULL,
	[NINETIETH_PER_VALUE]    	DECIMAL(10,5) NULL,
	[NINETY_FIFTH_PER_VALUE] 	DECIMAL(10,5) NULL,
	[NINETY_EIGHTH_PER_VALUE]	DECIMAL(10,5) NULL,
	[NINETY_NINTH_PER_VALUE] 	DECIMAL(10,5) NULL,
	[OBSERVATION_PER_VALUE]  	DECIMAL(10,5) NULL,
	[BELOW_HALF_MDL_COUNT]   	DECIMAL(5,0) NULL 
	)
GO

CREATE TABLE [AQS_BLANK_INFO] ( 
	[AQS_BLANK_INFO_PK]    	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_FK]	INT NOT NULL,
	[ACTION_CD]            	VARCHAR(1) NOT NULL,
	[SMPL_COLL_START_DATE] 	VARCHAR(10) NOT NULL,
	[SMPL_COLL_START_TIME] 	VARCHAR(8) NOT NULL,
	[BLANK_TYPE_CD]        	VARCHAR(20) NOT NULL,
	[UNCERTAINTY_VALUE]    	DECIMAL(11,5) NULL,
	[NULL_DATA_CD]         	VARCHAR(2) NULL,
	[DATA_VALIDITY_CD]     	VARCHAR(1) NULL,
	[DATA_APPROVAL_IND]    	VARCHAR(1) NULL,
	[MEASURE_VALUE]        	DECIMAL(11,5) NULL 
	)
GO

CREATE TABLE [AQS_BLANK_RES_QUAL_CD] ( 
	[AQS_BLANK_RES_QUAL_CD_PK]	INT NOT NULL,
	[AQS_BLANK_INFO_FK]       	INT NOT NULL,
	[RES_QUAL_CD]             	VARCHAR(2) NULL 
	)
GO

CREATE TABLE [AQS_COMP_RES_QUAL_CD] ( 
	[AQS_COMP_RES_QUAL_CD_PK]	INT NOT NULL,
	[AQS_COMP_INFO_FK]       	INT NOT NULL,
	[RES_QUAL_CD]            	VARCHAR(2) NULL 
	)
GO

CREATE TABLE [AQS_METADATA] ( 
	[AQS_SITE_ID_PK]       	INT NOT NULL,
	[AQS_MONITOR_ID_PK]    	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_PK]	INT NOT NULL,
	[AQS_RAW_RES_PK]       	INT NOT NULL,
	[FACILITY_SITE_ID]     	VARCHAR(4) NOT NULL,
	[ACTION_CD]            	VARCHAR(1) NOT NULL,
	[SMPL_COLL_START_DATE] 	VARCHAR(10) NOT NULL,
	[COUNTY_CD]            	VARCHAR(3) NULL 
	)
GO

CREATE TABLE [AQS_MONITOR_ID] ( 
	[AQS_MONITOR_ID_PK]   	INT NOT NULL,
	[AQS_SITE_ID_FK]      	INT NOT NULL,
	[ACTION_CD]           	VARCHAR(1) NULL,
	[SUBST_ID]            	VARCHAR(5) NOT NULL,
	[SUBST_OCCURENCE_CD]  	DECIMAL(2,0) NOT NULL,
	[PROJECT_CLASS_CD]    	VARCHAR(2) NULL,
	[DOMINANT_SCR_TXT]    	VARCHAR(6) NULL,
	[MEASUREMENT_SCALE_ID]	VARCHAR(20) NULL,
	[OPEN_PATH_ID]        	INT NULL,
	[PROBE_LOC_CODE]      	VARCHAR(20) NULL,
	[PROBE_HEIGHT_MSR]    	DECIMAL(10,5) NULL,
	[HORIZ_DIST_MSR]      	DECIMAL(10,5) NULL,
	[VERT_DIST_MSR]       	DECIMAL(10,5) NULL,
	[SURROGATE_IND]       	VARCHAR(1) NULL,
	[UNRESTR_AIR_FLOW_IND]	VARCHAR(1) NULL,
	[SAMPLE_RESID_TIME]   	DECIMAL(10,2) NULL,
	[WORST_SITE_TYPE_CD]  	INT NULL,
	[APPLICABLE_NAAQS_IND]	VARCHAR(1) NULL,
	[SPACIAL_AVG_IND]     	VARCHAR(1) NULL,
	[SCHED_EXEMPT_IND]    	VARCHAR(1) NULL,
	[CMNTY_MONITOR_ZONE]  	DECIMAL(4,0) NULL,
	[MONITOR_CLOSE_DATE]  	VARCHAR(10) NULL 
	)
GO

CREATE TABLE [AQS_MONITOR_OBJ_INFO] ( 
	[AQS_MONITOR_OBJ_INFO_PK]	INT NOT NULL,
	[AQS_MONITOR_ID_FK]      	INT NOT NULL,
	[MONITOR_OBJ_ID]         	VARCHAR(50) NOT NULL,
	[ACTION_CD]              	VARCHAR(1) NULL,
	[URBAN_AREA_REP_CD]      	VARCHAR(4) NULL,
	[METRO_SA_REP_CD]        	VARCHAR(4) NULL,
	[COVE_BS_REP_CD]         	VARCHAR(4) NULL,
	[COMBINED_SA_REP_CD]     	VARCHAR(4) NULL 
	)
GO

CREATE TABLE [AQS_MONITOR_SAMPLE_PRD] ( 
	[AQS_MONITOR_SAMPLE_PRD_PK]	INT NOT NULL,
	[AQS_MONITOR_ID_FK]        	INT NOT NULL,
	[SAMPLING_BEGIN_DATE]      	VARCHAR(10) NOT NULL,
	[SAMPLING_END_DATE]        	VARCHAR(10) NULL 
	)
GO

CREATE TABLE [AQS_MONITOR_SAMPLE_SCHD] ( 
	[AQS_MONITOR_SAMPLE_SCHD_PK]	INT NOT NULL,
	[AQS_MONITOR_ID_FK]         	INT NOT NULL,
	[ACTION_CD]                 	VARCHAR(1) NULL,
	[FREQUENCY_CD]              	VARCHAR(2) NULL,
	[RCF_BEGIN_DATE]            	VARCHAR(10) NOT NULL,
	[RCF_END_DATE]              	VARCHAR(10) NULL,
	[RCF_JAN_CD]                	VARCHAR(1) NULL,
	[RCF_FEB_CD]                	VARCHAR(1) NULL,
	[RCF_MAR_CD]                	VARCHAR(1) NULL,
	[RCF_APR_CD]                	VARCHAR(1) NULL,
	[RCR_MAY_CD]                	VARCHAR(1) NULL,
	[RCR_JUN_CD]                	VARCHAR(1) NULL,
	[RCR_JUL_CD]                	VARCHAR(1) NULL,
	[RCR_AUG_CD]                	VARCHAR(1) NULL,
	[RCR_SEP_CD]                	VARCHAR(1) NULL,
	[RCR_OCT_CD]                	VARCHAR(1) NULL,
	[RCR_NOV_CD]                	VARCHAR(1) NULL,
	[RCR_DEC_CD]                	VARCHAR(1) NULL 
	)
GO

CREATE TABLE [AQS_RAW_ACCU_INFO] ( 
	[AQS_RAW_ACCU_INFO_PK] 	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_FK]	INT NOT NULL,
	[ACTION_CD]            	VARCHAR(1) NOT NULL,
	[ACCU_AUDIT_ID_NUM]    	VARCHAR(2) NOT NULL,
	[AUDIT_YEAR]           	VARCHAR(4) NULL,
	[QTR_REP_CD]           	VARCHAR(2) NULL,
	[ACCU_DATE]            	VARCHAR(10) NOT NULL,
	[AUDIT_TYPE_ID]        	VARCHAR(20) NULL,
	[LOCAL_STAND_ID]       	VARCHAR(30) NULL,
	[AUDIT_CLASS_ID]       	VARCHAR(20) NULL,
	[ACCU_TYPE_ID]         	VARCHAR(20) NULL,
	[AUDIT_SMPL_ID]        	VARCHAR(10) NULL,
	[LOCAL_STAND_EXP_DATE] 	VARCHAR(10) NULL,
	[AUDIT_SCH_DATE]       	VARCHAR(10) NULL,
	[LVL1_ACT_VALUE]       	DECIMAL(10,5) NULL,
	[LVL1_IND_VALUE]       	DECIMAL(10,5) NULL,
	[LVL2_ACT_VALUE]       	DECIMAL(10,5) NULL,
	[LVL2_IND_VALUE]       	DECIMAL(10,5) NULL,
	[LVL3_ACT_VALUE]       	DECIMAL(10,5) NULL,
	[LVL3_IND_VALUE]       	DECIMAL(10,5) NULL,
	[LVL4_ACT_VALUE]       	DECIMAL(10,5) NULL,
	[LVL4_IND_VALUE]       	DECIMAL(10,5) NULL,
	[LVL5_ACT_VALUE]       	DECIMAL(10,5) NULL,
	[LVL5_IND_VALUE]       	DECIMAL(10,5) NULL,
	[ZERO_SPAN_VALUE]      	DECIMAL(10,5) NULL 
	)
GO

CREATE TABLE [AQS_RAW_COMP_INFO] ( 
	[AQS_RAW_COMP_INFO_PK] 	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_FK]	INT NOT NULL,
	[ACTION_CD]            	VARCHAR(1) NOT NULL,
	[OBSERVATION_YEAR]     	VARCHAR(4) NOT NULL,
	[COMP_PERIOD_CD]       	DECIMAL(2,0) NOT NULL,
	[SAMPLES_COUNT]        	DECIMAL(3,0) NULL,
	[COMP_SMPL_VALUE]      	DECIMAL(10,5) NULL,
	[UNCERTAINTY_VALUE]    	DECIMAL(11,5) NULL 
	)
GO

CREATE TABLE [AQS_RAW_PREC_INFO] ( 
	[AQS_RAW_PREC_INFO_PK] 	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_FK]	INT NOT NULL,
	[ACTION_CD]            	VARCHAR(1) NOT NULL,
	[PREC_TYPE_ID]         	VARCHAR(40) NULL,
	[PREC_ID_NUM]          	DECIMAL(2,0) NOT NULL,
	[ACTUAL_METHOD_CD]     	VARCHAR(3) NULL,
	[PREC_CHECK_DATE]      	VARCHAR(10) NOT NULL,
	[ACTUAL_VALUE]         	DECIMAL(10,5) NULL,
	[INDICATED_METHOD_CD]  	VARCHAR(3) NULL,
	[INDICATED_VALUE]      	DECIMAL(10,5) NULL,
	[COL_POC_ID_NUM]       	DECIMAL(2,0) NULL,
	[PREC_SMPL_ID]         	VARCHAR(10) NULL,
	[AUDIT_AGENCY_CD]      	VARCHAR(4) NULL 
	)
GO

CREATE TABLE [AQS_RAW_RES] ( 
	[AQS_RAW_RES_PK]       	INT NOT NULL,
	[AQS_TRANS_PROTOCOL_FK]	INT NOT NULL,
	[ACTION_CD]            	VARCHAR(1) NOT NULL,
	[SMPL_COLL_START_DATE] 	VARCHAR(10) NOT NULL,
	[SMPL_COLL_START_TIME] 	VARCHAR(8) NOT NULL,
	[UNCERTAINTY_VALUE]    	DECIMAL(11,5) NULL,
	[NULL_DATA_CD]         	VARCHAR(2) NULL,
	[DATA_VALIDITY_CD]     	VARCHAR(1) NULL,
	[DATA_APPROVAL_IND]    	VARCHAR(1) NULL,
	[MEASURE_VALUE]        	DECIMAL(11,5) NULL 
	)
GO

CREATE TABLE [AQS_RES_QUAL_CD] ( 
	[AQS_RES_QUAL_CD_PK]	INT NOT NULL,
	[AQS_RAW_RES_FK]    	INT NOT NULL,
	[RES_QUAL_CD]       	VARCHAR(2) NULL 
	)
GO

CREATE TABLE [AQS_SITE_ID] ( 
	[AQS_SITE_ID_PK]      	INT NOT NULL,
	[ACTION_CD]           	VARCHAR(1) NULL,
	[FACILITY_SITE_ID]    	VARCHAR(4) NOT NULL,
	[STATE_CD]            	VARCHAR(2) NULL,
	[NON_STATE_CD]        	VARCHAR(2) NULL,
	[COUNTY_CD]           	VARCHAR(3) NULL,
	[TRIBAL_CD]           	VARCHAR(3) NULL,
	[SUPPORT_AGENCY_CD]   	VARCHAR(4) NULL,
	[LOC_ADDR_TEXT]       	VARCHAR(100) NULL,
	[CITY_CD]             	VARCHAR(10) NULL,
	[POSTAL_CODE]         	VARCHAR(10) NULL,
	[LOCAL_ID]            	VARCHAR(40) NULL,
	[LOCAL_NAME]          	VARCHAR(70) NULL,
	[LOCAL_REGION_CD]     	VARCHAR(8) NULL,
	[URBAN_AREA_CD]       	VARCHAR(4) NULL,
	[AQCR_CD]             	VARCHAR(3) NULL,
	[LAND_USE_ID]         	VARCHAR(25) NULL,
	[LOC_SETTING_ID]      	VARCHAR(25) NULL,
	[SITE_EST_DATE]       	VARCHAR(10) NULL,
	[SITE_TERM_DATE]      	VARCHAR(10) NULL,
	[CONG_DIST_CODE]      	DECIMAL(2,0) NULL,
	[CENSUS_BLOCK_CD]     	DECIMAL(4,0) NULL,
	[CENSUS_BLOCK_GRP_CD] 	DECIMAL(1,0) NULL,
	[CENSUS_TRACT_CD]     	DECIMAL(6,0) NULL,
	[CLASS_AREA_CD]       	DECIMAL(6,0) NULL,
	[HQ_EVAL_DATE]        	VARCHAR(10) NULL,
	[REG_EVAL_DATE]       	VARCHAR(10) NULL,
	[DIR_FROM_CITY_CD]    	VARCHAR(3) NULL,
	[DIST_FROM_CITY_MSR]  	DECIMAL(10,5) NULL,
	[MET_SITE_ID]         	VARCHAR(9) NULL,
	[MET_SITE_TYPE_CD]    	VARCHAR(25) NULL,
	[DIST_TO_MET_SITE_MSR]	DECIMAL(10,5) NULL,
	[DIR_TO_MET_SITE_CODE]	VARCHAR(3) NULL,
	[LATITUDE]            	DECIMAL(11,5) NULL,
	[LONGITUDE]           	DECIMAL(11,5) NULL,
	[UTM_ZONE_CD]         	DECIMAL(2,0) NULL,
	[UTM_EASTING]         	DECIMAL(10,2) NULL,
	[UTM_NORTHING]        	DECIMAL(10,2) NULL,
	[HORIZ_COL_MTHD]      	VARCHAR(3) NULL,
	[HORIZ_REF_DATUM]     	VARCHAR(120) NULL,
	[SRC_MAP_SCALE_NBR]   	INT NULL,
	[HORIZONTAL_ACCURACY] 	DECIMAL(10,5) NULL,
	[VERTICAL_MEASURE]    	DECIMAL(10,5) NULL,
	[VERTICAL_MTHD_CD]    	VARCHAR(3) NULL,
	[VERTICAL_DATUM_ID]   	VARCHAR(60) NULL,
	[VERTICAL_ACCR_MSR]   	DECIMAL(10,5) NULL,
	[TIME_ZONE_NAME]      	VARCHAR(25) NULL 
	)
GO

CREATE TABLE [AQS_TRANS_PROTOCOL] ( 
	[AQS_TRANS_PROTOCOL_PK]	INT NOT NULL,
	[AQS_MONITOR_ID_FK]    	INT NOT NULL,
	[COMPOSITE_TYPE_ID]    	VARCHAR(9) NULL,
	[DURATION_CD]          	VARCHAR(1) NULL,
	[FREQUENCY_CD]         	VARCHAR(2) NULL,
	[METHOD_ID_CD]         	VARCHAR(3) NULL,
	[MEASURE_UNIT_CD]      	VARCHAR(3) NULL,
	[ALTERNATE_MDL_VALUE]  	DECIMAL(10,5) NULL 
	)
GO



CREATE PROCEDURE [AQS_CHECK_METADATA] AS

BEGIN TRY BEGIN TRANSACTION AQS_CHECK_METADATA

	IF NOT EXISTS (SELECT NULL FROM AQS_METADATA)
	BEGIN

		INSERT INTO AQS_METADATA (
			AQS_SITE_ID_PK, AQS_MONITOR_ID_PK, AQS_TRANS_PROTOCOL_PK, AQS_RAW_RES_PK, FACILITY_SITE_ID, ACTION_CD, SMPL_COLL_START_DATE, COUNTY_CD)
		SELECT S.AQS_SITE_ID_PK, M.AQS_MONITOR_ID_PK, T.AQS_TRANS_PROTOCOL_PK, R.AQS_RAW_RES_PK, S.FACILITY_SITE_ID, R.ACTION_CD, R.SMPL_COLL_START_DATE, S.COUNTY_CD
			FROM AQS_RAW_RES R
				INNER JOIN AQS_TRANS_PROTOCOL T ON T.AQS_TRANS_PROTOCOL_PK = R.AQS_TRANS_PROTOCOL_FK
				INNER JOIN AQS_MONITOR_ID M ON M.AQS_MONITOR_ID_PK = T.AQS_MONITOR_ID_FK
				INNER JOIN AQS_SITE_ID S ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_FK;

		INSERT INTO AQS_METADATA (
			AQS_SITE_ID_PK, AQS_MONITOR_ID_PK, AQS_TRANS_PROTOCOL_PK, AQS_RAW_RES_PK, FACILITY_SITE_ID, ACTION_CD, SMPL_COLL_START_DATE, COUNTY_CD)
		SELECT S.AQS_SITE_ID_PK, M.AQS_MONITOR_ID_PK, T.AQS_TRANS_PROTOCOL_PK, R.AQS_RAW_PREC_INFO_PK, S.FACILITY_SITE_ID, R.ACTION_CD, R.PREC_CHECK_DATE, S.COUNTY_CD
			FROM AQS_RAW_PREC_INFO R
				INNER JOIN AQS_TRANS_PROTOCOL T ON T.AQS_TRANS_PROTOCOL_PK = R.AQS_TRANS_PROTOCOL_FK
				INNER JOIN AQS_MONITOR_ID M ON M.AQS_MONITOR_ID_PK = T.AQS_MONITOR_ID_FK
				INNER JOIN AQS_SITE_ID S ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_FK;

		INSERT INTO AQS_METADATA (
			AQS_SITE_ID_PK, AQS_MONITOR_ID_PK, AQS_TRANS_PROTOCOL_PK, AQS_RAW_RES_PK, FACILITY_SITE_ID, ACTION_CD, SMPL_COLL_START_DATE, COUNTY_CD)
		SELECT S.AQS_SITE_ID_PK, M.AQS_MONITOR_ID_PK, T.AQS_TRANS_PROTOCOL_PK, R.AQS_RAW_ACCU_INFO_PK, S.FACILITY_SITE_ID, R.ACTION_CD, R.ACCU_DATE, S.COUNTY_CD
			FROM AQS_RAW_ACCU_INFO R
				INNER JOIN AQS_TRANS_PROTOCOL T ON T.AQS_TRANS_PROTOCOL_PK = R.AQS_TRANS_PROTOCOL_FK
				INNER JOIN AQS_MONITOR_ID M ON M.AQS_MONITOR_ID_PK = T.AQS_MONITOR_ID_FK
				INNER JOIN AQS_SITE_ID S ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_FK;

		INSERT INTO AQS_METADATA (
			AQS_SITE_ID_PK, AQS_MONITOR_ID_PK, AQS_TRANS_PROTOCOL_PK, AQS_RAW_RES_PK, FACILITY_SITE_ID, ACTION_CD, SMPL_COLL_START_DATE, COUNTY_CD)
		SELECT S.AQS_SITE_ID_PK, M.AQS_MONITOR_ID_PK, T.AQS_TRANS_PROTOCOL_PK, R.AQS_ANNUAL_SUM_INFO_PK, S.FACILITY_SITE_ID, R.ACTION_CD, '01-01-' + R.SUM_YEAR, S.COUNTY_CD
			FROM AQS_ANNUAL_SUM_INFO R
				INNER JOIN AQS_TRANS_PROTOCOL T ON T.AQS_TRANS_PROTOCOL_PK = R.AQS_TRANS_PROTOCOL_FK
				INNER JOIN AQS_MONITOR_ID M ON M.AQS_MONITOR_ID_PK = T.AQS_MONITOR_ID_FK
				INNER JOIN AQS_SITE_ID S ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_FK;

		INSERT INTO AQS_METADATA (
			AQS_SITE_ID_PK, AQS_MONITOR_ID_PK, AQS_TRANS_PROTOCOL_PK, AQS_RAW_RES_PK, FACILITY_SITE_ID, ACTION_CD, SMPL_COLL_START_DATE, COUNTY_CD)
		SELECT S.AQS_SITE_ID_PK, M.AQS_MONITOR_ID_PK, T.AQS_TRANS_PROTOCOL_PK, R.AQS_RAW_COMP_INFO_PK, S.FACILITY_SITE_ID, R.ACTION_CD, '01-01-' + R.OBSERVATION_YEAR, S.COUNTY_CD
			FROM AQS_RAW_COMP_INFO R
				INNER JOIN AQS_TRANS_PROTOCOL T ON T.AQS_TRANS_PROTOCOL_PK = R.AQS_TRANS_PROTOCOL_FK
				INNER JOIN AQS_MONITOR_ID M ON M.AQS_MONITOR_ID_PK = T.AQS_MONITOR_ID_FK
				INNER JOIN AQS_SITE_ID S ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_FK;

		INSERT INTO AQS_METADATA (
			AQS_SITE_ID_PK, AQS_MONITOR_ID_PK, AQS_TRANS_PROTOCOL_PK, AQS_RAW_RES_PK, FACILITY_SITE_ID, ACTION_CD, SMPL_COLL_START_DATE, COUNTY_CD)
		SELECT S.AQS_SITE_ID_PK, M.AQS_MONITOR_ID_PK, T.AQS_TRANS_PROTOCOL_PK, R.AQS_BLANK_INFO_PK, S.FACILITY_SITE_ID, R.ACTION_CD, R.SMPL_COLL_START_DATE, S.COUNTY_CD
			FROM AQS_BLANK_INFO R
				INNER JOIN AQS_TRANS_PROTOCOL T ON T.AQS_TRANS_PROTOCOL_PK = R.AQS_TRANS_PROTOCOL_FK
				INNER JOIN AQS_MONITOR_ID M ON M.AQS_MONITOR_ID_PK = T.AQS_MONITOR_ID_FK
				INNER JOIN AQS_SITE_ID S ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_FK;
	END;
	COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;

	DECLARE @errmsg   nvarchar(2048),
			@severity tinyint,
			@state    tinyint;
	           
	SELECT @errmsg = error_message(), @severity = error_severity(),   
		   @state  = error_state();

	RAISERROR(@errmsg, @severity, @state);
END CATCH;
GO

ALTER TABLE [AQS_ANNUAL_SUM_INFO]
	ADD  CONSTRAINT [PK_ANNUAL_SUM_INFO]
	PRIMARY KEY ([AQS_ANNUAL_SUM_INFO_PK])
GO

ALTER TABLE [AQS_BLANK_INFO]
	ADD  CONSTRAINT [PK_BLANK_INFO]
	PRIMARY KEY ([AQS_BLANK_INFO_PK])
GO

ALTER TABLE [AQS_BLANK_RES_QUAL_CD]
	ADD  CONSTRAINT [PK_BLANK_RES_QUAL_CD]
	PRIMARY KEY ([AQS_BLANK_RES_QUAL_CD_PK])
GO

ALTER TABLE [AQS_COMP_RES_QUAL_CD]
	ADD  CONSTRAINT [PK_COMP_RES_QUAL_CD]
	PRIMARY KEY ([AQS_COMP_RES_QUAL_CD_PK])
GO

ALTER TABLE [AQS_METADATA]
	ADD  CONSTRAINT [PK_METADATA]
	PRIMARY KEY ([AQS_TRANS_PROTOCOL_PK], [AQS_SITE_ID_PK], [SMPL_COLL_START_DATE], [AQS_MONITOR_ID_PK], [AQS_RAW_RES_PK], [ACTION_CD])
GO

ALTER TABLE [AQS_MONITOR_ID]
	ADD  CONSTRAINT [PK_MONITOR_ID]
	PRIMARY KEY ([AQS_MONITOR_ID_PK])
GO

ALTER TABLE [AQS_MONITOR_OBJ_INFO]
	ADD  CONSTRAINT [PK_MONITOR_OBJ_INFO]
	PRIMARY KEY ([AQS_MONITOR_OBJ_INFO_PK])
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_PRD]
	ADD  CONSTRAINT [PK_MONITOR_SAMPLE_PRD]
	PRIMARY KEY ([AQS_MONITOR_SAMPLE_PRD_PK])
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_SCHD]
	ADD  CONSTRAINT [PK_MONITOR_SAMPLE_SCHD]
	PRIMARY KEY ([AQS_MONITOR_SAMPLE_SCHD_PK])
GO

ALTER TABLE [AQS_RAW_ACCU_INFO]
	ADD  CONSTRAINT [PK_RAW_ACCU_INFO]
	PRIMARY KEY ([AQS_RAW_ACCU_INFO_PK])
GO

ALTER TABLE [AQS_RAW_COMP_INFO]
	ADD  CONSTRAINT [PK_RAW_COMP_INFO]
	PRIMARY KEY ([AQS_RAW_COMP_INFO_PK])
GO

ALTER TABLE [AQS_RAW_PREC_INFO]
	ADD  CONSTRAINT [PK_RAW_PREC_INFO]
	PRIMARY KEY ([AQS_RAW_PREC_INFO_PK])
GO

ALTER TABLE [AQS_RAW_RES]
	ADD  CONSTRAINT [PK_RAW_RES]
	PRIMARY KEY ([AQS_RAW_RES_PK])
GO

ALTER TABLE [AQS_RES_QUAL_CD]
	ADD  CONSTRAINT [PK_RES_QUAL_CD]
	PRIMARY KEY ([AQS_RES_QUAL_CD_PK])
GO

ALTER TABLE [AQS_SITE_ID]
	ADD  CONSTRAINT [PK_SITE_ID]
	PRIMARY KEY ([AQS_SITE_ID_PK])
GO

ALTER TABLE [AQS_TRANS_PROTOCOL]
	ADD  CONSTRAINT [PK_TRANS_PROTOCOL]
	PRIMARY KEY ([AQS_TRANS_PROTOCOL_PK])
GO

ALTER TABLE [AQS_ANNUAL_SUM_INFO]
	ADD  CONSTRAINT [FK_TRANS_PROTOCOL_ANNUAL_SUM]
	FOREIGN KEY([AQS_TRANS_PROTOCOL_FK])
	REFERENCES AQS_TRANS_PROTOCOL([AQS_TRANS_PROTOCOL_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_BLANK_INFO]
	ADD  CONSTRAINT [FK_TRANS_PROTOCOL_BLANK_INFO]
	FOREIGN KEY([AQS_TRANS_PROTOCOL_FK])
	REFERENCES AQS_TRANS_PROTOCOL([AQS_TRANS_PROTOCOL_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_BLANK_RES_QUAL_CD]
	ADD  CONSTRAINT [FK_BLANK_INFO]
	FOREIGN KEY([AQS_BLANK_INFO_FK])
	REFERENCES AQS_BLANK_INFO([AQS_BLANK_INFO_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_COMP_RES_QUAL_CD]
	ADD  CONSTRAINT [FK_COMP_INFO]
	FOREIGN KEY([AQS_COMP_INFO_FK])
	REFERENCES AQS_RAW_COMP_INFO([AQS_RAW_COMP_INFO_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_MONITOR_ID]
	ADD  CONSTRAINT [FK_SITE_ID]
	FOREIGN KEY([AQS_SITE_ID_FK])
	REFERENCES AQS_SITE_ID([AQS_SITE_ID_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_MONITOR_OBJ_INFO]
	ADD  CONSTRAINT [FK_MONITOR_OBJ_INFO_ID]
	FOREIGN KEY([AQS_MONITOR_ID_FK])
	REFERENCES AQS_MONITOR_ID([AQS_MONITOR_ID_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_PRD]
	ADD  CONSTRAINT [FK_MONITOR_SAMPLE_ID]
	FOREIGN KEY([AQS_MONITOR_ID_FK])
	REFERENCES AQS_MONITOR_ID([AQS_MONITOR_ID_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_MONITOR_SAMPLE_SCHD]
	ADD  CONSTRAINT [FK_MONITOR_SAMPLE_SCHD]
	FOREIGN KEY([AQS_MONITOR_ID_FK])
	REFERENCES AQS_MONITOR_ID([AQS_MONITOR_ID_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_RAW_ACCU_INFO]
	ADD  CONSTRAINT [FK_TRANS_PROTOCOL_ACCU_INFO]
	FOREIGN KEY([AQS_TRANS_PROTOCOL_FK])
	REFERENCES AQS_TRANS_PROTOCOL([AQS_TRANS_PROTOCOL_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_RAW_COMP_INFO]
	ADD  CONSTRAINT [FK_TRANS_PROTOCOL_COMP_INFO]
	FOREIGN KEY([AQS_TRANS_PROTOCOL_FK])
	REFERENCES AQS_TRANS_PROTOCOL([AQS_TRANS_PROTOCOL_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_RAW_PREC_INFO]
	ADD  CONSTRAINT [FK_TRANS_PROTOCOL_PREC_INFO]
	FOREIGN KEY([AQS_TRANS_PROTOCOL_FK])
	REFERENCES AQS_TRANS_PROTOCOL([AQS_TRANS_PROTOCOL_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_RAW_RES]
	ADD  CONSTRAINT [FK_TRANS_PROTOCOL]
	FOREIGN KEY([AQS_TRANS_PROTOCOL_FK])
	REFERENCES AQS_TRANS_PROTOCOL([AQS_TRANS_PROTOCOL_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_RES_QUAL_CD]
	ADD  CONSTRAINT [FK_RAW_RES]
	FOREIGN KEY([AQS_RAW_RES_FK])
	REFERENCES AQS_RAW_RES([AQS_RAW_RES_PK])
	ON DELETE CASCADE
GO

ALTER TABLE [AQS_TRANS_PROTOCOL]
	ADD  CONSTRAINT [FK_MONITOR_ID]
	FOREIGN KEY([AQS_MONITOR_ID_FK])
	REFERENCES AQS_MONITOR_ID([AQS_MONITOR_ID_PK])
	ON DELETE CASCADE
GO

