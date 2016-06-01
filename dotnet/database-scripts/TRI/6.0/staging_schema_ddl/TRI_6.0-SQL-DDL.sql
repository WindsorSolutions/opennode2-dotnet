/*************************************************************************************************
** ObjectName: TRI_6.0-SQL-DLL.sql
**
** Author: Windsor Solutions, Inc.
**
** Company Name: Windsor Solutions, Inc.
**
** Description:  This script will build the TRI database objects to support the OpenNode2 TRI
**               plug-in.  Run the script from the top if running for the first time, if running
**               in an existing environment you'll need to run the drop statements first, then 
**               run the create statements.  Please note, dropping then recreating the schema 
**               objects will purge all data.
**
** Revision History:
** ------------------------------------------------------------------------------------------------
** Date          Name        Description
** ------------------------------------------------------------------------------------------------
** 10/16/2015    Windsor     Created 
**
***************************************************************************************************/
/* 
ALTER TABLE "TRI_WASTE_TREAT_METH"
	DROP CONSTRAINT "FK_WASTETREATMETH_WTDTL"
GO

ALTER TABLE "TRI_WASTE_TREAT_DTL"
	DROP CONSTRAINT "FK_WASTETREATDTL_REPORT"
GO

ALTER TABLE "TRI_UIC_ID"
	DROP CONSTRAINT "FK_UICID_FAC"
GO

ALTER TABLE "TRI_TRANSFER_Q"
	DROP CONSTRAINT "FK_TRANSFERQ_TRANSFERLOC"
GO

ALTER TABLE "TRI_TRANSFER_LOC"
	DROP CONSTRAINT "FK_TRANSFERLOC_REPORT"
GO

ALTER TABLE "TRI_SRC_RED_METH_CD"
	DROP CONSTRAINT "FK_SRCREDMETHCD_SRCREDACT"
GO

ALTER TABLE "TRI_SRC_RED_ACT"
	DROP CONSTRAINT "FK_SRCREDACT_REPORT"
GO

ALTER TABLE "TRI_REPORT"
	DROP CONSTRAINT "FK_REPORT_SUB"
GO

ALTER TABLE "TRI_REPORT_VALIDATION"
	DROP CONSTRAINT "FK_TRI_REPORT_VALIDATION_TRI_REPORT"
GO

ALTER TABLE "TRI_REPLACED_REPORT_ID"
	DROP CONSTRAINT "FK_REPLACEDREPORTID_REPORT"
GO

ALTER TABLE "TRI_RCRA_ID"
	DROP CONSTRAINT "FK_RCRAID_FAC"
GO

ALTER TABLE "TRI_POTW_WASTE_QUANTITY"
	DROP CONSTRAINT "FK_TRI_RPT_POTW_WQ"
GO

ALTER TABLE "TRI_ONSITE_UIC_DISP_QTY"
	DROP CONSTRAINT "FK_ONSITEUICDISPQTY_REPORT"
GO

ALTER TABLE "TRI_ONSITE_TREATED_Q"
	DROP CONSTRAINT "FK_ONSITETREATEDQ_REPORT"
GO

ALTER TABLE "TRI_ONSITE_RELEASE_Q"
	DROP CONSTRAINT "FK_ONSITERELEASEQ_REPORT"
GO

ALTER TABLE "TRI_ONSITE_RECYCLED_Q"
	DROP CONSTRAINT "FK_ONSITERECYCLEDQ_REPORT"
GO

ALTER TABLE "TRI_ONSITE_RECYCG_PROC"
	DROP CONSTRAINT "FK_ONSITERECYCGPROC_REPORT"
GO

ALTER TABLE "TRI_ONSITE_RCV_PROC"
	DROP CONSTRAINT "FK_ONSITERCVPROC_REPORT"
GO

ALTER TABLE "TRI_ONSITE_ENERGY_RCV_QTY"
	DROP CONSTRAINT "FK_ONSITEENERGYRCVQTY_REPORT"
GO

ALTER TABLE "TRI_ONSITE_DISP_QTY"
	DROP CONSTRAINT "FK_ONSITEDISPQTY_REPORT"
GO

ALTER TABLE "TRI_OFFSITE_UIC_DISP_QTY"
	DROP CONSTRAINT "FK_OFFSITEUICDISPQTY_REPORT"
GO

ALTER TABLE "TRI_OFFSITE_TREATED_Q"
	DROP CONSTRAINT "FK_OFFSITETREATEDQ_REPORT"
GO

ALTER TABLE "TRI_OFFSITE_RECYCLED_Q"
	DROP CONSTRAINT "FK_OFFSITERECYCLEDQ_REPORT"
GO

ALTER TABLE "TRI_OFFSITE_ENERGY_REC_QTY"
	DROP CONSTRAINT "FK_OFFSITEENERGYRECQTY_REPORT"
GO

ALTER TABLE "TRI_OFFSITE_DISP_QTY"
	DROP CONSTRAINT "FK_OFFSITEDISPQTY_REPORT"
GO

ALTER TABLE "TRI_NPDES_ID"
	DROP CONSTRAINT "FK_NPDESID_FAC"
GO

ALTER TABLE "TRI_FAC"
	DROP CONSTRAINT "FK_FAC_SUB"
GO

ALTER TABLE "TRI_FAC_SIC"
	DROP CONSTRAINT "FK_FACSIC_FAC"
GO

ALTER TABLE "TRI_FAC_NAICS"
	DROP CONSTRAINT "FK_FACNAICS_FAC"
GO

ALTER TABLE "TRI_FAC_DUN"
	DROP CONSTRAINT "FK_FACDUN_FAC"
GO

ALTER TABLE "TRI_CHEM"
	DROP CONSTRAINT "FK_CHEM_REPORT"
GO

ALTER TABLE "TRI_COMMENT"
	DROP CONSTRAINT "FK_COMMENT_REP"
GO

ALTER TABLE "TRI_SUB"
	DROP CONSTRAINT "IX_TRI_SUB"
GO

ALTER TABLE "TRI_WASTE_TREAT_METH"
	DROP CONSTRAINT "PK_TRI_COMMENT"
GO

ALTER TABLE "TRI_WASTE_TREAT_METH"
	DROP CONSTRAINT "PK_TRI_WASTE_TREAT_METH"
GO

ALTER TABLE "TRI_WASTE_TREAT_DTL"
	DROP CONSTRAINT "PK_TRI_WASTE_TREAT_DTL"
GO

ALTER TABLE "TRI_UIC_ID"
	DROP CONSTRAINT "PK_TRI_UIC_ID"
GO

ALTER TABLE "TRI_TRANSFER_Q"
	DROP CONSTRAINT "PK_TRI_TRANSFER_Q"
GO

ALTER TABLE "TRI_TRANSFER_LOC"
	DROP CONSTRAINT "PK_TRI_TRANSFER_LOC"
GO

ALTER TABLE "TRI_SUB"
	DROP CONSTRAINT "PK_TRI_SUB"
GO

ALTER TABLE "TRI_SRC_RED_METH_CD"
	DROP CONSTRAINT "PK_TRI_SRC_RED_METH_CD"
GO

ALTER TABLE "TRI_SRC_RED_ACT"
	DROP CONSTRAINT "PK_TRI_SRC_RED_ACT"
GO

ALTER TABLE "TRI_REPORT"
	DROP CONSTRAINT "PK_TRI_REPORT"
GO

ALTER TABLE "TRI_REPORT_VALIDATION"
	DROP CONSTRAINT "PK_TRI_REPORT_VALIDATION"
GO

ALTER TABLE "TRI_REPLACED_REPORT_ID"
	DROP CONSTRAINT "PK_TRI_REPLACED_REPORT_ID"
GO

ALTER TABLE "TRI_RCRA_ID"
	DROP CONSTRAINT "PK_TRI_RCRA_ID"
GO

ALTER TABLE "TRI_POTW_WASTE_QUANTITY"
	DROP CONSTRAINT "PK_TRI_POTW_WASTE_QUANTITY"
GO

ALTER TABLE "TRI_ONSITE_UIC_DISP_QTY"
	DROP CONSTRAINT "PK_TRI_ONSITE_UIC_DISP_QTY"
GO

ALTER TABLE "TRI_ONSITE_TREATED_Q"
	DROP CONSTRAINT "PK_TRI_ONSITE_TREATED_Q"
GO

ALTER TABLE "TRI_ONSITE_RELEASE_Q"
	DROP CONSTRAINT "PK_TRI_ONSITE_RELEASE_Q"
GO

ALTER TABLE "TRI_ONSITE_RECYCLED_Q"
	DROP CONSTRAINT "PK_TRI_ONSITE_RECYCLED_Q"
GO

ALTER TABLE "TRI_ONSITE_RECYCG_PROC"
	DROP CONSTRAINT "PK_TRI_ONSITE_RECYCG_PROC"
GO

ALTER TABLE "TRI_ONSITE_RCV_PROC"
	DROP CONSTRAINT "PK_TRI_ONSITE_RCV_PROC"
GO

ALTER TABLE "TRI_ONSITE_ENERGY_RCV_QTY"
	DROP CONSTRAINT "PK_TRI_ONSITE_ENERGY_RCV_QTY"
GO

ALTER TABLE "TRI_ONSITE_DISP_QTY"
	DROP CONSTRAINT "PK_TRI_ONSITE_DISP_QTY"
GO

ALTER TABLE "TRI_OFFSITE_UIC_DISP_QTY"
	DROP CONSTRAINT "PK_TRI_OFFSITE_UIC_DISP_QTY"
GO

ALTER TABLE "TRI_OFFSITE_TREATED_Q"
	DROP CONSTRAINT "PK_TRI_OFFSITE_TREATED_Q"
GO

ALTER TABLE "TRI_OFFSITE_RECYCLED_Q"
	DROP CONSTRAINT "PK_TRI_OFFSITE_RECYCLED_Q"
GO

ALTER TABLE "TRI_OFFSITE_ENERGY_REC_QTY"
	DROP CONSTRAINT "PK_TRI_OFFSITE_ENERGY_REC_QTY"
GO

ALTER TABLE "TRI_OFFSITE_DISP_QTY"
	DROP CONSTRAINT "PK_TRI_OFFSITE_DISP_QTY"
GO

ALTER TABLE "TRI_NPDES_ID"
	DROP CONSTRAINT "PK_TRI_NPDES_ID"
GO

ALTER TABLE "TRI_FAC"
	DROP CONSTRAINT "PK_TRI_FAC"
GO

ALTER TABLE "TRI_FAC_SIC"
	DROP CONSTRAINT "PK_TRI_FAC_SIC"
GO

ALTER TABLE "TRI_FAC_NAICS"
	DROP CONSTRAINT "PK_TRI_NAICS_SIC"
GO

ALTER TABLE "TRI_FAC_DUN"
	DROP CONSTRAINT "PK_TRI_FAC_DUN"
GO

ALTER TABLE "TRI_CHEM"
	DROP CONSTRAINT "PK_TRI_CHEM"
GO

DROP INDEX "TRI_WASTE_TREAT_METH"."IX_TRI_WASTE_TREAT_METH_FK_GUID"
GO

DROP INDEX "TRI_WASTE_TREAT_DTL"."IX_TRI_WASTE_TREAT_DTL_FK_GUID"
GO

DROP INDEX "TRI_UIC_ID"."IX_TRI_UIC_ID_FK_GUID"
GO

DROP INDEX "TRI_TRANSFER_Q"."IX_TRI_TRANSFER_Q_FK_GUID"
GO

DROP INDEX "TRI_TRANSFER_LOC"."IX_TRI_TRANSFER_LOC_FK_GUID"
GO

DROP INDEX "TRI_SRC_RED_METH_CD"."IX_TRI_SRC_RED_METH_CD_FK_GUID"
GO

DROP INDEX "TRI_SRC_RED_ACT"."IX_TRI_SRC_RED_ACT_FK_GUID"
GO

DROP INDEX "TRI_REPORT"."IX_TRI_REPORT_FK_GUID"
GO

DROP INDEX "TRI_REPORT_VALIDATION"."IX_TRI_REPORT_VALIDATION_FK_GUID"
GO

DROP INDEX "TRI_REPLACED_REPORT_ID"."IX_TRI_REPLACED_REPORT_ID_FK_GUID"
GO

DROP INDEX "TRI_RCRA_ID"."IX_TRI_RCRA_ID_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_UIC_DISP_QTY"."IX_TRI_ONSITE_UIC_DISP_QTY_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_TREATED_Q"."IX_TRI_ONSITE_TREATED_Q_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_RELEASE_Q"."IX_TRI_ONSITE_RELEASE_Q_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_RECYCLED_Q"."IX_TRI_ONSITE_RECYCLED_Q_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_RECYCG_PROC"."IX_TRI_ONSITE_RECYCG_PROC_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_RCV_PROC"."IX_TRI_ONSITE_RCV_PROC_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_ENERGY_RCV_QTY"."IX_TRI_ONSITE_ENERGY_RCV_QTY_FK_GUID"
GO

DROP INDEX "TRI_ONSITE_DISP_QTY"."IX_TRI_ONSITE_DISP_QTY_FK_GUID"
GO

DROP INDEX "TRI_OFFSITE_UIC_DISP_QTY"."IX_TRI_OFFSITE_UIC_DISP_QTY_FK_GUID"
GO

DROP INDEX "TRI_OFFSITE_TREATED_Q"."IX_TRI_OFFSITE_TREATED_Q_FK_GUID"
GO

DROP INDEX "TRI_OFFSITE_RECYCLED_Q"."IX_TRI_OFFSITE_RECYCLED_Q_FK_GUID"
GO

DROP INDEX "TRI_OFFSITE_ENERGY_REC_QTY"."IX_TRI_OFFSITE_ENERGY_REC_QTY_FK_GUID"
GO

DROP INDEX "TRI_OFFSITE_DISP_QTY"."IX_TRI_OFFSITE_DISP_QTY_FK_GUID"
GO

DROP INDEX "TRI_NPDES_ID"."IX_TRI_NPDES_ID_FK_GUID"
GO

DROP INDEX "TRI_FAC"."IX_TRI_FAC_FK_GUID"
GO

DROP INDEX "TRI_FAC"."IX_TRI_FAC_FAC_ID"
GO

DROP INDEX "TRI_FAC_SIC"."IX_TRI_FAC_SIC_FK_GUID"
GO

DROP INDEX "TRI_FAC_NAICS"."IX_TRI_FAC_NAICS_FK_GUID"
GO

DROP INDEX "TRI_FAC_DUN"."IX_TRI_FAC_DUN_FK_GUID"
GO

DROP INDEX "TRI_CHEM"."IX_TRI_CHEM_FK_GUID"
GO

DROP INDEX "TRI_NPDES_ID"."IX_TRI_NPDES_ID_FK_GUID"
GO

DROP INDEX "TRI_COMMENT"."IX_TRI_COMMENT_FK_GUID"
GO

DROP TABLE "TRI_COMMENT"
GO

DROP TABLE "TRI_WASTE_TREAT_METH"
GO

DROP TABLE "TRI_WASTE_TREAT_DTL"
GO

DROP TABLE "TRI_UIC_ID"
GO

DROP TABLE "TRI_TRANSFER_Q"
GO

DROP TABLE "TRI_TRANSFER_LOC"
GO

DROP TABLE "TRI_SUB"
GO

DROP TABLE "TRI_SRC_RED_METH_CD"
GO

DROP TABLE "TRI_SRC_RED_ACT"
GO

DROP TABLE "TRI_REPORT"
GO

DROP TABLE "TRI_REPORT_VALIDATION"
GO

DROP TABLE "TRI_REPLACED_REPORT_ID"
GO

DROP TABLE "TRI_RCRA_ID"
GO

DROP TABLE "TRI_POTW_WASTE_QUANTITY"
GO

DROP TABLE "TRI_ONSITE_UIC_DISP_QTY"
GO

DROP TABLE "TRI_ONSITE_TREATED_Q"
GO

DROP TABLE "TRI_ONSITE_RELEASE_Q"
GO

DROP TABLE "TRI_ONSITE_RECYCLED_Q"
GO

DROP TABLE "TRI_ONSITE_RECYCG_PROC"
GO

DROP TABLE "TRI_ONSITE_RCV_PROC"
GO

DROP TABLE "TRI_ONSITE_ENERGY_RCV_QTY"
GO

DROP TABLE "TRI_ONSITE_DISP_QTY"
GO

DROP TABLE "TRI_OFFSITE_UIC_DISP_QTY"
GO

DROP TABLE "TRI_OFFSITE_TREATED_Q"
GO

DROP TABLE "TRI_OFFSITE_RECYCLED_Q"
GO

DROP TABLE "TRI_OFFSITE_ENERGY_REC_QTY"
GO

DROP TABLE "TRI_OFFSITE_DISP_QTY"
GO

DROP TABLE "TRI_NPDES_ID"
GO

DROP TABLE "TRI_FAC"
GO

DROP TABLE "TRI_FAC_SIC"
GO

DROP TABLE "TRI_FAC_NAICS"
GO

DROP TABLE "TRI_FAC_DUN"
GO

DROP TABLE "TRI_CHEM"
GO

*/

CREATE TABLE "TRI_CHEM" ( 
	"PK_GUID"          	varchar(36) NOT NULL,
	"FK_GUID"          	varchar(36) NOT NULL,
	"CAS_CLBER"        	varchar(100) NULL,
	"CHEM_TXT"         	varchar(100) NULL,
	"CHEM_MIXTURE_TXT" 	varchar(100) NULL,
	"CHEM_ID"          	varchar(100) NULL,
	"CHEM_REGISTRY"    	varchar(100) NULL,
	"CHEM_REGISTRY_CTX"	varchar(100) NULL,
	"DIOXIN_DIST1"     	varchar(100) NULL,
	"DIOXIN_DIST2"     	varchar(100) NULL,
	"DIOXIN_DIST3"     	varchar(100) NULL,
	"DIOXIN_DIST4"     	varchar(100) NULL,
	"DIOXIN_DIST5"     	varchar(100) NULL,
	"DIOXIN_DIST6"     	varchar(100) NULL,
	"DIOXIN_DIST7"     	varchar(100) NULL,
	"DIOXIN_DIST8"     	varchar(100) NULL,
	"DIOXIN_DIST9"     	varchar(100) NULL,
	"DIOXIN_DIST10"    	varchar(100) NULL,
	"DIOXIN_DIST11"    	varchar(100) NULL,
	"DIOXIN_DIST12"    	varchar(100) NULL,
	"DIOXIN_DIST13"    	varchar(100) NULL,
	"DIOXIN_DIST14"    	varchar(100) NULL,
	"DIOXIN_DIST15"    	varchar(100) NULL,
	"DIOXIN_DIST16"    	varchar(100) NULL,
	"DIOXIN_DIST17"    	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_FAC_DUN" ( 
	"PK_GUID"     	varchar(36) NOT NULL,
	"FK_GUID"     	varchar(36) NOT NULL,
	"FAC_DUN_CODE"	varchar(9) NULL 
	)
GO

CREATE TABLE "TRI_FAC_NAICS" ( 
	"PK_GUID"          	varchar(36) NOT NULL,
	"FK_GUID"          	varchar(36) NOT NULL,
	"FAC_NAICS"        	varchar(100) NULL,
	"NAICS_PRIMARY_IND"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_FAC_SIC" ( 
	"PK_GUID"        	varchar(36) NOT NULL,
	"FK_GUID"        	varchar(36) NOT NULL,
	"FAC_SIC"        	varchar(100) NULL,
	"SIC_PRIMARY_IND"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_FAC" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"FAC_ID"                   	varchar(100) NULL,
	"FAC_SITE"                 	varchar(100) NULL,
	"LOC_ADD_TXT"              	varchar(100) NULL,
	"SUPP_LOC_TXT"             	varchar(100) NULL,
	"LOCALITY"                 	varchar(100) NULL,
	"STATE_CL_ID"              	varchar(100) NULL,
	"STATE_CODE"               	varchar(10) NULL,
	"STATE"                    	varchar(50) NULL,
	"ADD_POSTAL_CODE"          	varchar(50) NULL,
	"COUNTRY_CL_ID"            	varchar(100) NULL,
	"COUNTRY_CODE"             	varchar(10) NULL,
	"COUNTRY"                  	varchar(50) NULL,
	"COUNTY_CL_ID"             	varchar(100) NULL,
	"COUNTY_CODE"              	varchar(100) NULL,
	"COUNTY"                   	varchar(100) NULL,
	"TRIBAL_CL_ID"             	varchar(100) NULL,
	"TRIBAL_CODE"              	varchar(100) NULL,
	"TRIBAL"                   	varchar(100) NULL,
	"TRIBAL_LAND"              	varchar(100) NULL,
	"TRIBAL_LAND_IND"          	varchar(100) NULL,
	"LOC_DESCN_TXT"            	varchar(100) NULL,
	"MAIL_FAC_SITE"            	varchar(100) NULL,
	"MAIL_ADD_TXT"             	varchar(100) NULL,
	"SUPP_MAIL_ADD"            	varchar(100) NULL,
	"MAIL_ADD_CITY"            	varchar(100) NULL,
	"MAIL_ADD_POSTAL_CODE"     	varchar(100) NULL,
	"PROVINCE_TXT"             	varchar(100) NULL,
	"MAIL_ADD_STATE_CDLST"     	varchar(100) NULL,
	"MAIL_ADD_STATE_CODE"      	varchar(10) NULL,
	"MAIL_ADD_STATE"           	varchar(100) NULL,
	"MAIL_ADD_COUNTRY_CDLST"   	varchar(100) NULL,
	"MAIL_ADD_COUNTRY_CODE"    	varchar(10) NULL,
	"MAIL_ADD_COUNTRY"         	varchar(100) NULL,
	"LAT_ME"                   	varchar(20) NULL,
	"LON_ME"                   	varchar(20) NULL,
	"SRC_MAP_SCALE_CLBER"      	varchar(100) NULL,
	"HOR_ME_VALUE"             	varchar(100) NULL,
	"HOR_ME_UNIT_CODE"         	varchar(100) NULL,
	"HOR_ME_UNIT"              	varchar(100) NULL,
	"HOR_ME_PREC_TXT"          	varchar(100) NULL,
	"HOR_RESULT_QFR_CODE"      	varchar(100) NULL,
	"HOR_RESULT_QFR"           	varchar(100) NULL,
	"HOR_METH_ID_CODE"         	varchar(100) NULL,
	"HOR_METH"                 	varchar(100) NULL,
	"HOR_METH_DESCN_TXT"       	varchar(100) NULL,
	"HOR_METH_DEV_TXT"         	varchar(100) NULL,
	"GEO_REF_POINT_CD"         	varchar(100) NULL,
	"GEO_REF_POINT_NM"         	varchar(100) NULL,
	"HOR_REF_DATUM_CD"         	varchar(100) NULL,
	"HOR_REF_DATUM_NM"         	varchar(100) NULL,
	"DATA_COLLECTION_DATE"     	varchar(100) NULL,
	"LOC_COMS_TXT"             	varchar(100) NULL,
	"VER_ME_VALUE"             	varchar(100) NULL,
	"VER_ME_UNIT_CODE"         	varchar(100) NULL,
	"VER_ME_UNIT"              	varchar(100) NULL,
	"VER_ME_PREC_TXT"          	varchar(100) NULL,
	"VER_RESULT_QFR_CODE"      	varchar(100) NULL,
	"VER_RESULT_QFR"           	varchar(100) NULL,
	"VER_METH_ID_CODE"         	varchar(100) NULL,
	"VER_METH"                 	varchar(100) NULL,
	"VER_METH_DESCN_TXT"       	varchar(100) NULL,
	"VER_METH_DEV_TXT"         	varchar(100) NULL,
	"GEO_REF_DATUM_CD"         	varchar(100) NULL,
	"GEO_REF_DATUM_NM"         	varchar(100) NULL,
	"VERIF_METH_ID"            	varchar(100) NULL,
	"VERIF_METH"               	varchar(100) NULL,
	"VERIF_METH_DESC"          	varchar(100) NULL,
	"VERIF_METH_DEV"           	varchar(100) NULL,
	"COORD_DATA_SRC_CODE"      	varchar(100) NULL,
	"COORD_DATA_SRC"           	varchar(100) NULL,
	"GEOMETRIC_TYPE_CODE"      	varchar(100) NULL,
	"GEOMETRIC_TYPE"           	varchar(100) NULL,
	"LAT_DEGREE_ME"            	varchar(100) NULL,
	"LAT_MINUTE_ME"            	varchar(100) NULL,
	"LAT_SECOND_ME"            	varchar(100) NULL,
	"LON_DEGREE_ME"            	varchar(100) NULL,
	"LON_MINUTE_ME"            	varchar(100) NULL,
	"LON_SECOND_ME"            	varchar(100) NULL,
	"PARENT_COMPANY_TXT"       	varchar(100) NULL,
	"PARENT_DUN_CODE"          	varchar(100) NULL,
	"FACILITY_ACCESS_CODE"     	varchar(100) NULL,
	"PRI_YR_TECH_CONTACT_NAME" 	varchar(100) NULL,
	"PRI_YR_TECH_CONTACT_PHONE"	varchar(100) NULL,
	"PARENT_COMPANY_NAME_N_S"	char(1) NULL
	)
GO

CREATE TABLE "TRI_NPDES_ID" ( 
	"PK_GUID"       	varchar(36) NOT NULL,
	"FK_GUID"       	varchar(36) NOT NULL,
	"NPDES_ID_CLBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_OFFSITE_DISP_QTY" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_OFFSITE_ENERGY_REC_QTY" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_OFFSITE_RECYCLED_Q" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_OFFSITE_TREATED_Q" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_OFFSITE_UIC_DISP_QTY" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_DISP_QTY" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_ENERGY_RCV_QTY" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_RCV_PROC" ( 
	"PK_GUID"             	varchar(36) NOT NULL,
	"FK_GUID"             	varchar(36) NOT NULL,
	"ENERGY_RCV_METH_CODE"	varchar(100) NULL,
	"ENERGY_RCV_NA_IND"   	char(1) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_RECYCG_PROC" ( 
	"PK_GUID"                	varchar(36) NOT NULL,
	"FK_GUID"                	varchar(36) NOT NULL,
	"ONSITE_RECYCG_METH_CODE"	varchar(100) NULL,
	"ONSITE_RECYCG_NA_IND"   	char(1) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_RECYCLED_Q" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_RELEASE_Q" ( 
	"PK_GUID"                      	varchar(36) NOT NULL,
	"FK_GUID"                      	varchar(36) NOT NULL,
	"EI_MEDIUM_CODE"               	varchar(100) NULL,
	"WASTE_Q_ME"                   	varchar(100) NULL,
	"WASTE_Q_NA_IND"               	char(1) NULL,
	"WASTE_Q_RANGE_CODE"           	varchar(100) NULL,
	"Q_BASIS_EST_CD"               	varchar(100) NULL,
	"Q_BASIS_NA_IND"               	char(1) NULL,
	"WATER_SEQ_CLBER"              	varchar(100) NULL,
	"STREAM"                       	varchar(100) NULL,
	"RELEASE_STORM_WATER"          	varchar(100) NULL,
	"RELEASE_STORM_NA_IND"         	char(1) NULL,
	"TOX_EQ_VAL1"                  	varchar(100) NULL,
	"TOX_EQ_VAL2"                  	varchar(100) NULL,
	"TOX_EQ_VAL3"                  	varchar(100) NULL,
	"TOX_EQ_VAL4"                  	varchar(100) NULL,
	"TOX_EQ_VAL5"                  	varchar(100) NULL,
	"TOX_EQ_VAL6"                  	varchar(100) NULL,
	"TOX_EQ_VAL7"                  	varchar(100) NULL,
	"TOX_EQ_VAL8"                  	varchar(100) NULL,
	"TOX_EQ_VAL9"                  	varchar(100) NULL,
	"TOX_EQ_VAL10"                 	varchar(100) NULL,
	"TOX_EQ_VAL11"                 	varchar(100) NULL,
	"TOX_EQ_VAL12"                 	varchar(100) NULL,
	"TOX_EQ_VAL13"                 	varchar(100) NULL,
	"TOX_EQ_VAL14"                 	varchar(100) NULL,
	"TOX_EQ_VAL15"                 	varchar(100) NULL,
	"TOX_EQ_VAL16"                 	varchar(100) NULL,
	"TOX_EQ_VAL17"                 	varchar(100) NULL,
	"TOX_EQ_NA_IND"                	char(1) NULL,
	"WASTE_Q_CATASTROPHIC_MEASURE" 	varchar(100) NULL,
	"WASTE_Q_RANGE_NUM_BASIS_VALUE"	varchar(100) NULL,
	"STREAM_REACH_CODE"             varchar(100) NULL
)
GO

CREATE TABLE "TRI_ONSITE_TREATED_Q" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NOT NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_ONSITE_UIC_DISP_QTY" ( 
	"PK_GUID"                  	varchar(36) NOT NULL,
	"FK_GUID"                  	varchar(36) NULL,
	"YEAR_OFFSET_ME"           	varchar(100) NULL,
	"TOTAL_Q"                  	varchar(100) NULL,
	"TOTAL_Q_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"              	varchar(100) NULL,
	"TOX_EQ_VAL2"              	varchar(100) NULL,
	"TOX_EQ_VAL3"              	varchar(100) NULL,
	"TOX_EQ_VAL4"              	varchar(100) NULL,
	"TOX_EQ_VAL5"              	varchar(100) NULL,
	"TOX_EQ_VAL6"              	varchar(100) NULL,
	"TOX_EQ_VAL7"              	varchar(100) NULL,
	"TOX_EQ_VAL8"              	varchar(100) NULL,
	"TOX_EQ_VAL9"              	varchar(100) NULL,
	"TOX_EQ_VAL10"             	varchar(100) NULL,
	"TOX_EQ_VAL11"             	varchar(100) NULL,
	"TOX_EQ_VAL12"             	varchar(100) NULL,
	"TOX_EQ_VAL13"             	varchar(100) NULL,
	"TOX_EQ_VAL14"             	varchar(100) NULL,
	"TOX_EQ_VAL15"             	varchar(100) NULL,
	"TOX_EQ_VAL16"             	varchar(100) NULL,
	"TOX_EQ_VAL17"             	varchar(100) NULL,
	"TOX_EQ_NA_IND"            	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_POTW_WASTE_QUANTITY" ( 
	"PK_GUID"                      	varchar(36) NOT NULL,
	"FK_GUID"                      	varchar(36) NOT NULL,
	"POTW_SEQ_NO"                  	varchar(100) NULL,
	"WASTE_Q_ME"                   	varchar(100) NULL,
	"WASTE_Q_CATASTROPHIC_MEASURE" 	varchar(100) NULL,
	"WASTE_Q_RANGE_CODE"           	varchar(100) NULL,
	"WASTE_Q_RANGE_NUM_BASIS_VALUE"	varchar(100) NULL,
	"WASTE_Q_ME_NA_IND"            	char(1) NULL,
	"Q_BASIS_EST_CODE"             	varchar(100) NULL,
	"Q_BASIS_EST_NA_IND"           	char(1) NULL,
	"TOX_EQ_VAL1"                  	varchar(100) NULL,
	"TOX_EQ_VAL2"                  	varchar(100) NULL,
	"TOX_EQ_VAL3"                  	varchar(100) NULL,
	"TOX_EQ_VAL4"                  	varchar(100) NULL,
	"TOX_EQ_VAL5"                  	varchar(100) NULL,
	"TOX_EQ_VAL6"                  	varchar(100) NULL,
	"TOX_EQ_VAL7"                  	varchar(100) NULL,
	"TOX_EQ_VAL8"                  	varchar(100) NULL,
	"TOX_EQ_VAL9"                  	varchar(100) NULL,
	"TOX_EQ_VAL10"                 	varchar(100) NULL,
	"TOX_EQ_VAL11"                 	varchar(100) NULL,
	"TOX_EQ_VAL12"                 	varchar(100) NULL,
	"TOX_EQ_VAL13"                 	varchar(100) NULL,
	"TOX_EQ_VAL14"                 	varchar(100) NULL,
	"TOX_EQ_VAL15"                 	varchar(100) NULL,
	"TOX_EQ_VAL16"                 	varchar(100) NULL,
	"TOX_EQ_VAL17"                 	varchar(100) NULL,
	"TOX_EQ_NA_IND"                	char(1) NULL,
	"Q_DISP_LANDFILL_PERCENT_VALUE"	varchar(100) NULL,
	"Q_DISP_OTHER_PERCENT_VALUE"   	varchar(100) NULL,
	"Q_TREATED_PERCENT_VALUE"      	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_RCRA_ID" ( 
	"PK_GUID"      	varchar(36) NOT NULL,
	"FK_GUID"      	varchar(36) NOT NULL,
	"RCRA_ID_CLBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_REPLACED_REPORT_ID" ( 
	"PK_GUID"           	varchar(36) NOT NULL,
	"FK_GUID"           	varchar(36) NOT NULL,
	"REPLACED_REPORT_ID"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_REPORT_VALIDATION" ( 
	"PK_GUID"                    	varchar(36) NOT NULL,
	"FK_GUID"                    	varchar(36) NOT NULL,
	"VALIDATION_ENTITY_NAME_TEXT"	varchar(100) NULL,
	"VALIDATION_MESSAGE_CODE"    	varchar(100) NULL,
	"VALIDATION_MESSAGE_TEXT"    	varchar(100) NULL,
	"EPA_ERROR_SEVERITY_CODE"    	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_REPORT" ( 
	"PK_GUID"                       	varchar(36) NOT NULL,
	"FK_GUID"                       	varchar(36) NOT NULL,
	"REPORT_ID"                     	varchar(100) NULL,
	"REPORT_POST_DATE"              	varchar(50) NULL,
	"REPORT_REC_DATE"               	varchar(50) NULL,
	"REPORT_ORIG_POST_DATE"         	varchar(50) NULL,
	"REPORT_ORIG_REC_DATE"          	varchar(50) NULL,
	"REPORT_SUB_METH_CODE"          	varchar(100) NULL,
	"REPORT_EPA_PASSED_VALID_IND"   	char(1) NULL,
	"REPORT_EPA_PROCESSING_STATUS_C"	varchar(100) NULL,
	"UNALTERED_REPORT_IND"          	varchar(100) NULL,
	"REPORT_TYPE_CODE"              	varchar(100) NULL,
	"SUB_REP_YEAR"                  	varchar(100) NULL,
	"REPORT_DUE_DATE"               	varchar(50) NULL,
	"REVISION_IND"                  	varchar(100) NULL,
	"CHEM_TRADE_SECRET_IND"         	varchar(100) NULL,
	"SUB_SANITIZED_IND"             	varchar(100) NULL,
	"CERTIFIER"                     	varchar(100) NULL,
	"CERTIFIER_TIT_TXT"             	varchar(100) NULL,
	"CERT_SIGNED_DATE"              	varchar(100) NULL,
	"SUB_ENTIRE_FAC_IND"            	varchar(100) NULL,
	"SUB_PARTIAL_FAC_ID"            	varchar(100) NULL,
	"SUB_FEDERAL_FAC_ID"            	varchar(100) NULL,
	"SUB_CO_FAC_INDIC"              	varchar(100) NULL,
	"TECH_CONT"                     	varchar(100) NULL,
	"TECH_CONT_PHONE_TXT"           	varchar(100) NULL,
	"TECH_CONT_EMAIL_ADDRES"        	varchar(100) NULL,
	"PUB_CONT_ID"                   	varchar(100) NULL,
	"PUB_CONT_TIT_TXT"              	varchar(100) NULL,
	"PUB_CONT"                      	varchar(100) NULL,
	"PUB_CONT_PHONE_TXT"            	varchar(50) NULL,
	"CHEM_ANC_USAGE_IND"            	varchar(100) NULL,
	"CHEM_ARTICLE_COMP_ID"          	varchar(100) NULL,
	"CHEM_BYPRODUCT_IND"            	varchar(100) NULL,
	"CHEM_FORMULATION_COMP"         	varchar(100) NULL,
	"CHEM_IMPORTED_IND"             	varchar(100) NULL,
	"CHEM_MANUFACTURE_AID_ID"       	varchar(100) NULL,
	"CHEM_MANUFACTURE_IMPURITY"     	varchar(100) NULL,
	"CHEM_PROC_IMPURITY_ID"         	varchar(100) NULL,
	"CHEM_PROCING_AID_ID"           	varchar(100) NULL,
	"CHEM_PRODUCED_IND"             	varchar(100) NULL,
	"CHEM_REACTANT_IND"             	varchar(100) NULL,
	"CHEM_REP_IND"                  	varchar(100) NULL,
	"CHEM_SALES_DIST_ID"            	varchar(100) NULL,
	"CHEM_USED_PROCED_ID"           	varchar(100) NULL,
	"MAX_CHEM_AMOUNT_CODE"          	varchar(100) NULL,
	--"WASTE_Q_ME"                    	varchar(100) NULL,
	--"WASTE_Q_ME_NA_IND"             	char(1) NULL,
	--"WASTE_Q_RANGE_CODE"            	varchar(100) NULL,
	--"Q_BASIS_EST_CODE"              	varchar(100) NULL,
	--"Q_BASIS_EST_NA_IND"            	char(1) NULL,
	"ONE_TIME_RELEASE_Q"            	varchar(100) NULL,
	"ONE_TIME_NA_IND"               	char(1) NULL,
	"PRODUCTION_RATIO_ME"           	varchar(100) NULL,
	"PRODUCTION_RATIO_NA_IND"       	char(1) NULL,
	"SUB_ADDITIONAL_DATA_ID"        	varchar(100) NULL,
	"OPT_INF_TXT"                   	varchar(4000) NULL,
	"PUB_CONT_EMAIL_ADDRES"         	varchar(100) NULL,
	"CHEM_RPT_REV_CD_1"             	varchar(100) NULL,
	"CHEM_RPT_REV_CD_2"             	varchar(100) NULL,
	"CHEM_RPT_WD_CD_1"              	varchar(100) NULL,
	"CHEM_RPT_WD_CD_2"              	varchar(100) NULL,
	--"TOX_EQ_VAL1_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL2_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL3_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL4_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL5_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL6_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL7_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL8_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL9_POTW"              	varchar(100) NULL,
	--"TOX_EQ_VAL10_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL11_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL12_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL13_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL14_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL15_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL16_POTW"             	varchar(100) NULL,
	--"TOX_EQ_VAL17_POTW"             	varchar(100) NULL,
	--"TOX_EQ_NA_IND_POTW"            	char(1) NULL,
--	"WASTE_Q_CATASTROPHIC_MEASURE"  	varchar(100) NULL,
	--"WASTE_Q_RANGE_NUM_BASIS_VALUE" 	varchar(100) NULL,
	--"Q_DISP_LANDFILL_PERCENT_VALUE" 	varchar(100) NULL,
	--"Q_DISP_OTHER_PERCENT_VALUE"    	varchar(100) NULL,
	--"Q_TREATED_PERCENT_VALUE"       	varchar(100) NULL,
	"TOX_EQ_VAL1_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL2_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL3_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL4_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL5_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL6_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL7_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL8_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL9_ONETIME"           	varchar(100) NULL,
	"TOX_EQ_VAL10_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL11_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL12_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL13_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL14_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL15_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL16_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_VAL17_ONETIME"          	varchar(100) NULL,
	"TOX_EQ_NA_IND_ONETIME"         	char(1) NULL,
	"CALC_ROUNDING_HINT_NUMBER"     	varchar(100) NULL,
	"MISC_INF_TXT"                  	varchar(4000) NULL, 
	"TECH_CONT_PHONE_EXT_TXT"           varchar(100) NULL,
	"PUB_CONT_PHONE_EXT_TXT"            varchar(100) NULL,
	"OPT_INF_CATG"                      varchar(100) NULL,
	"MISC_INF_CATG"                     varchar(100) NULL,
	"PRODUCTION_RATIO_TYPE"             varchar(100) NULL
	)
GO

CREATE TABLE "TRI_SRC_RED_ACT" ( 
	"PK_GUID"         	varchar(36) NOT NULL,
	"FK_GUID"         	varchar(36) NOT NULL,
	"SRC_RED_SEQ_CL"  	varchar(100) NULL,
	"SRC_RED_ACT_CODE"	varchar(100) NULL,
	"SRC_RED_NA_IND"  	char(1) NULL,
	"SRC_RED_EFF_CODE" 	varchar(100) NULL
	)
GO

CREATE TABLE "TRI_SRC_RED_METH_CD" ( 
	"PK_GUID"          	varchar(36) NOT NULL,
	"FK_GUID"          	varchar(36) NOT NULL,
	"SRC_RED_METH_CODE"	varchar(100) NULL,
	"SRC_RED_NA_IND"   	char(1) NULL 
	)
GO

CREATE TABLE "TRI_SUB" ( 
	"PK_GUID"       	varchar(36) NOT NULL,
	"TRI_SUB_ID"    	varchar(255) NOT NULL,
	"INSERTED_DATE" 	datetime NOT NULL CONSTRAINT "DF__TRI_SUB__INSERTE__3B75D760"  DEFAULT (getdate()),
	"TRANSACTION_ID"	varchar(50) NOT NULL 
	)
GO

CREATE TABLE "TRI_TRANSFER_LOC" ( 
	"PK_GUID"            	varchar(36) NOT NULL,
	"FK_GUID"            	varchar(36) NOT NULL,
	"TRANSFER_LOC_SEQ_CL"	varchar(100) NULL,
	"POTW_IND"           	varchar(100) NULL,
	"FAC_SITE"           	varchar(100) NULL,
	"LOC_ADD_TXT"        	varchar(100) NULL,
	"SUPP_LOC_TXT"       	varchar(100) NULL,
	"LOCALITY"           	varchar(100) NULL,
	"STATE"              	varchar(100) NULL,
	"ADD_POSTAL_CODE"    	varchar(100) NULL,
	"COUNTY"             	varchar(100) NULL,
	"CONTROLLED_LOC_IND" 	varchar(100) NULL,
	"RCRA_ID_CLBER"      	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_TRANSFER_Q" ( 
	"PK_GUID"                      	varchar(36) NOT NULL,
	"FK_GUID"                      	varchar(36) NOT NULL,
	"TRANSFER_SEQ_CLBER"           	varchar(100) NULL,
	"WASTE_Q_ME"                   	varchar(100) NULL,
	"WASTE_Q_RANGE_CODE"           	varchar(100) NULL,
	"WASTE_Q_NA_IND"               	char(1) NULL,
	"Q_BASIS_EST_CODE"             	varchar(100) NULL,
	"Q_BASIS_EST_NA_IND"           	char(1) NULL,
	"WASTE_MANAGEMENT_CODE"        	varchar(100) NULL,
	"TOX_EQ_VAL1"                  	varchar(100) NULL,
	"TOX_EQ_VAL2"                  	varchar(100) NULL,
	"TOX_EQ_VAL3"                  	varchar(100) NULL,
	"TOX_EQ_VAL4"                  	varchar(100) NULL,
	"TOX_EQ_VAL5"                  	varchar(100) NULL,
	"TOX_EQ_VAL6"                  	varchar(100) NULL,
	"TOX_EQ_VAL7"                  	varchar(100) NULL,
	"TOX_EQ_VAL8"                  	varchar(100) NULL,
	"TOX_EQ_VAL9"                  	varchar(100) NULL,
	"TOX_EQ_VAL10"                 	varchar(100) NULL,
	"TOX_EQ_VAL11"                 	varchar(100) NULL,
	"TOX_EQ_VAL12"                 	varchar(100) NULL,
	"TOX_EQ_VAL13"                 	varchar(100) NULL,
	"TOX_EQ_VAL14"                 	varchar(100) NULL,
	"TOX_EQ_VAL15"                 	varchar(100) NULL,
	"TOX_EQ_VAL16"                 	varchar(100) NULL,
	"TOX_EQ_VAL17"                 	varchar(100) NULL,
	"TOX_EQ_NA_IND"                	char(1) NULL,
	"WASTE_Q_CATASTROPHIC_MEASURE" 	varchar(100) NULL,
	"WASTE_Q_RANGE_NUM_BASIS_VALUE"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_UIC_ID" ( 
	"PK_GUID"     	varchar(36) NOT NULL,
	"FK_GUID"     	varchar(36) NOT NULL,
	"UIC_ID_CLBER"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_WASTE_TREAT_DTL" ( 
	"PK_GUID"               	varchar(36) NOT NULL,
	"FK_GUID"               	varchar(36) NOT NULL,
	"WASTE_STREAM_SEQ_CLBER"	varchar(100) NULL,
	"WASTE_STREAM_TYPE_CODE"	varchar(100) NULL,
	"INFLUENT_CONC_RANGE_C" 	varchar(100) NULL,
	"TREAT_EFF_EST_PCT"     	varchar(100) NULL,
	"TREAT_EFF_RANGE_CD"    	varchar(100) NULL,
	"TREAT_EFF_NA_IND"      	char(1) NULL,
	"OPERATING_DATA_IND"    	varchar(100) NULL,
	"WASTE_TREAT_NA_IND"    	char(1) NULL 
	)
GO

CREATE TABLE "TRI_WASTE_TREAT_METH" ( 
	"PK_GUID"              	varchar(36) NOT NULL,
	"FK_GUID"              	varchar(36) NOT NULL,
	"WASTE_TREAT_SEQ_CL"   	varchar(100) NULL,
	"WASTE_TREAT_METH_CODE"	varchar(100) NULL 
	)
GO

CREATE TABLE "TRI_COMMENT" ( 
     "PK_GUID"           varchar(36) NOT NULL, 
     "FK_GUID"           varchar(36) NOT NULL, 
     "COMMENT_SEQ"       int NULL, 
     "COMMENT_SECTION"   varchar(50) NULL, 
     "COMMENT_TYPE_CODE" varchar(50) NULL, 
     "COMMENT_TYPE_DESC" varchar(255) NULL, 
     "COMMENT_TEXT"      varchar(4000) NULL, 
     "COMMENT_P2_CLASS"  varchar(100) NULL 
  ) 
GO

CREATE INDEX "IX_TRI_CHEM_FK_GUID"
	ON "TRI_CHEM"("FK_GUID")
GO

CREATE INDEX "IX_TRI_FAC_DUN_FK_GUID"
	ON "TRI_FAC_DUN"("FK_GUID")
GO

CREATE INDEX "IX_TRI_FAC_NAICS_FK_GUID"
	ON "TRI_FAC_NAICS"("FK_GUID")
GO

CREATE INDEX "IX_TRI_FAC_SIC_FK_GUID"
	ON "TRI_FAC_SIC"("FK_GUID")
GO

CREATE INDEX "IX_TRI_FAC_FK_GUID"
	ON "TRI_FAC"("FK_GUID")
GO

CREATE INDEX "IX_TRI_FAC_FAC_ID"
	ON "TRI_FAC"("FAC_ID")
GO

CREATE INDEX "IX_TRI_NPDES_ID_FK_GUID"
	ON "TRI_NPDES_ID"("FK_GUID")
GO

CREATE INDEX "IX_TRI_OFFSITE_DISP_QTY_FK_GUID"
	ON "TRI_OFFSITE_DISP_QTY"("FK_GUID")
GO

CREATE INDEX "IX_TRI_OFFSITE_ENERGY_REC_QTY_FK_GUID"
	ON "TRI_OFFSITE_ENERGY_REC_QTY"("FK_GUID")
GO

CREATE INDEX "IX_TRI_OFFSITE_RECYCLED_Q_FK_GUID"
	ON "TRI_OFFSITE_RECYCLED_Q"("FK_GUID")
GO

CREATE INDEX "IX_TRI_OFFSITE_TREATED_Q_FK_GUID"
	ON "TRI_OFFSITE_TREATED_Q"("FK_GUID")
GO

CREATE INDEX "IX_TRI_OFFSITE_UIC_DISP_QTY_FK_GUID"
	ON "TRI_OFFSITE_UIC_DISP_QTY"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_DISP_QTY_FK_GUID"
	ON "TRI_ONSITE_DISP_QTY"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_ENERGY_RCV_QTY_FK_GUID"
	ON "TRI_ONSITE_ENERGY_RCV_QTY"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_RCV_PROC_FK_GUID"
	ON "TRI_ONSITE_RCV_PROC"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_RECYCG_PROC_FK_GUID"
	ON "TRI_ONSITE_RECYCG_PROC"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_RECYCLED_Q_FK_GUID"
	ON "TRI_ONSITE_RECYCLED_Q"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_RELEASE_Q_FK_GUID"
	ON "TRI_ONSITE_RELEASE_Q"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_TREATED_Q_FK_GUID"
	ON "TRI_ONSITE_TREATED_Q"("FK_GUID")
GO

CREATE INDEX "IX_TRI_ONSITE_UIC_DISP_QTY_FK_GUID"
	ON "TRI_ONSITE_UIC_DISP_QTY"("FK_GUID")
GO

CREATE INDEX "IX_TRI_RCRA_ID_FK_GUID"
	ON "TRI_RCRA_ID"("FK_GUID")
GO

CREATE INDEX "IX_TRI_REPLACED_REPORT_ID_FK_GUID"
	ON "TRI_REPLACED_REPORT_ID"("FK_GUID")
GO

CREATE INDEX "IX_TRI_REPORT_VALIDATION_FK_GUID"
	ON "TRI_REPORT_VALIDATION"("FK_GUID")
GO

CREATE INDEX "IX_TRI_REPORT_FK_GUID"
	ON "TRI_REPORT"("FK_GUID")
GO

CREATE INDEX "IX_TRI_SRC_RED_ACT_FK_GUID"
	ON "TRI_SRC_RED_ACT"("FK_GUID")
GO

CREATE INDEX "IX_TRI_SRC_RED_METH_CD_FK_GUID"
	ON "TRI_SRC_RED_METH_CD"("FK_GUID")
GO

CREATE INDEX "IX_TRI_TRANSFER_LOC_FK_GUID"
	ON "TRI_TRANSFER_LOC"("FK_GUID")
GO

CREATE INDEX "IX_TRI_TRANSFER_Q_FK_GUID"
	ON "TRI_TRANSFER_Q"("FK_GUID")
GO

CREATE INDEX "IX_TRI_UIC_ID_FK_GUID"
	ON "TRI_UIC_ID"("FK_GUID")
GO

CREATE INDEX "IX_TRI_WASTE_TREAT_DTL_FK_GUID"
	ON "TRI_WASTE_TREAT_DTL"("FK_GUID")
GO

CREATE INDEX "IX_TRI_WASTE_TREAT_METH_FK_GUID"
	ON "TRI_WASTE_TREAT_METH"("FK_GUID")
GO

CREATE INDEX "IX_TRI_COMMENT_FK_GUID"
	ON "TRI_COMMENT"("FK_GUID")
GO

ALTER TABLE "TRI_CHEM"
	ADD CONSTRAINT "PK_TRI_CHEM"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_FAC_DUN"
	ADD CONSTRAINT "PK_TRI_FAC_DUN"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_FAC_NAICS"
	ADD CONSTRAINT "PK_TRI_NAICS_SIC"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_FAC_SIC"
	ADD CONSTRAINT "PK_TRI_FAC_SIC"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_FAC"
	ADD CONSTRAINT "PK_TRI_FAC"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_NPDES_ID"
	ADD CONSTRAINT "PK_TRI_NPDES_ID"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_OFFSITE_DISP_QTY"
	ADD CONSTRAINT "PK_TRI_OFFSITE_DISP_QTY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_OFFSITE_ENERGY_REC_QTY"
	ADD CONSTRAINT "PK_TRI_OFFSITE_ENERGY_REC_QTY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_OFFSITE_RECYCLED_Q"
	ADD CONSTRAINT "PK_TRI_OFFSITE_RECYCLED_Q"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_OFFSITE_TREATED_Q"
	ADD CONSTRAINT "PK_TRI_OFFSITE_TREATED_Q"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_OFFSITE_UIC_DISP_QTY"
	ADD CONSTRAINT "PK_TRI_OFFSITE_UIC_DISP_QTY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_DISP_QTY"
	ADD CONSTRAINT "PK_TRI_ONSITE_DISP_QTY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_ENERGY_RCV_QTY"
	ADD CONSTRAINT "PK_TRI_ONSITE_ENERGY_RCV_QTY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_RCV_PROC"
	ADD CONSTRAINT "PK_TRI_ONSITE_RCV_PROC"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_RECYCG_PROC"
	ADD CONSTRAINT "PK_TRI_ONSITE_RECYCG_PROC"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_RECYCLED_Q"
	ADD CONSTRAINT "PK_TRI_ONSITE_RECYCLED_Q"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_RELEASE_Q"
	ADD CONSTRAINT "PK_TRI_ONSITE_RELEASE_Q"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_TREATED_Q"
	ADD CONSTRAINT "PK_TRI_ONSITE_TREATED_Q"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_ONSITE_UIC_DISP_QTY"
	ADD CONSTRAINT "PK_TRI_ONSITE_UIC_DISP_QTY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_POTW_WASTE_QUANTITY"
	ADD CONSTRAINT "PK_TRI_POTW_WASTE_QUANTITY"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_RCRA_ID"
	ADD CONSTRAINT "PK_TRI_RCRA_ID"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_REPLACED_REPORT_ID"
	ADD CONSTRAINT "PK_TRI_REPLACED_REPORT_ID"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_REPORT_VALIDATION"
	ADD CONSTRAINT "PK_TRI_REPORT_VALIDATION"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_REPORT"
	ADD CONSTRAINT "PK_TRI_REPORT"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_SRC_RED_ACT"
	ADD CONSTRAINT "PK_TRI_SRC_RED_ACT"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_SRC_RED_METH_CD"
	ADD CONSTRAINT "PK_TRI_SRC_RED_METH_CD"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_SUB"
	ADD CONSTRAINT "PK_TRI_SUB"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_TRANSFER_LOC"
	ADD CONSTRAINT "PK_TRI_TRANSFER_LOC"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_TRANSFER_Q"
	ADD CONSTRAINT "PK_TRI_TRANSFER_Q"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_UIC_ID"
	ADD CONSTRAINT "PK_TRI_UIC_ID"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_WASTE_TREAT_DTL"
	ADD CONSTRAINT "PK_TRI_WASTE_TREAT_DTL"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_WASTE_TREAT_METH"
	ADD CONSTRAINT "PK_TRI_WASTE_TREAT_METH"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_COMMENT"
	ADD CONSTRAINT "PK_TRI_COMMENT"
	PRIMARY KEY ("PK_GUID")
GO

ALTER TABLE "TRI_SUB"
	ADD CONSTRAINT "IX_TRI_SUB"
	UNIQUE ("TRI_SUB_ID")
GO

ALTER TABLE "TRI_CHEM"
	ADD CONSTRAINT "FK_CHEM_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_FAC_DUN"
	ADD CONSTRAINT "FK_FACDUN_FAC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_FAC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_FAC_NAICS"
	ADD CONSTRAINT "FK_FACNAICS_FAC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_FAC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_FAC_SIC"
	ADD CONSTRAINT "FK_FACSIC_FAC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_FAC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_FAC"
	ADD CONSTRAINT "FK_FAC_SUB"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_SUB("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_NPDES_ID"
	ADD CONSTRAINT "FK_NPDESID_FAC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_FAC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_OFFSITE_DISP_QTY"
	ADD CONSTRAINT "FK_OFFSITEDISPQTY_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_OFFSITE_ENERGY_REC_QTY"
	ADD CONSTRAINT "FK_OFFSITEENERGYRECQTY_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_OFFSITE_RECYCLED_Q"
	ADD CONSTRAINT "FK_OFFSITERECYCLEDQ_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_OFFSITE_TREATED_Q"
	ADD CONSTRAINT "FK_OFFSITETREATEDQ_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_OFFSITE_UIC_DISP_QTY"
	ADD CONSTRAINT "FK_OFFSITEUICDISPQTY_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_DISP_QTY"
	ADD CONSTRAINT "FK_ONSITEDISPQTY_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_ENERGY_RCV_QTY"
	ADD CONSTRAINT "FK_ONSITEENERGYRCVQTY_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_RCV_PROC"
	ADD CONSTRAINT "FK_ONSITERCVPROC_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_RECYCG_PROC"
	ADD CONSTRAINT "FK_ONSITERECYCGPROC_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_RECYCLED_Q"
	ADD CONSTRAINT "FK_ONSITERECYCLEDQ_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_RELEASE_Q"
	ADD CONSTRAINT "FK_ONSITERELEASEQ_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_TREATED_Q"
	ADD CONSTRAINT "FK_ONSITETREATEDQ_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_ONSITE_UIC_DISP_QTY"
	ADD CONSTRAINT "FK_ONSITEUICDISPQTY_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_POTW_WASTE_QUANTITY"
	ADD CONSTRAINT "FK_TRI_RPT_POTW_WQ"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_RCRA_ID"
	ADD CONSTRAINT "FK_RCRAID_FAC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_FAC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_REPLACED_REPORT_ID"
	ADD CONSTRAINT "FK_REPLACEDREPORTID_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_REPORT_VALIDATION"
	ADD CONSTRAINT "FK_TRI_REPORT_VALIDATION_TRI_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE CASCADE 
GO

ALTER TABLE "TRI_REPORT"
	ADD CONSTRAINT "FK_REPORT_SUB"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_SUB("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_SRC_RED_ACT"
	ADD CONSTRAINT "FK_SRCREDACT_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_SRC_RED_METH_CD"
	ADD CONSTRAINT "FK_SRCREDMETHCD_SRCREDACT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_SRC_RED_ACT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_TRANSFER_LOC"
	ADD CONSTRAINT "FK_TRANSFERLOC_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_TRANSFER_Q"
	ADD CONSTRAINT "FK_TRANSFERQ_TRANSFERLOC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_TRANSFER_LOC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_UIC_ID"
	ADD CONSTRAINT "FK_UICID_FAC"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_FAC("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_WASTE_TREAT_DTL"
	ADD CONSTRAINT "FK_WASTETREATDTL_REPORT"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_WASTE_TREAT_METH"
	ADD CONSTRAINT "FK_WASTETREATMETH_WTDTL"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_WASTE_TREAT_DTL("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE "TRI_COMMENT"
	ADD CONSTRAINT "FK_COMMENT_REP"
	FOREIGN KEY("FK_GUID")
	REFERENCES TRI_REPORT("PK_GUID")
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO
