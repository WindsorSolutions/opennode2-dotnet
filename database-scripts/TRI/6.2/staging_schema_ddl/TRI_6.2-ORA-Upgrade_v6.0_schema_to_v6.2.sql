/*************************************************************************************************
** ObjectName: TRI_6.2-ORA-Upgrade_v6.0_schema_to_v6.2.sql
**
** Author: Windsor Solutions, Inc.
**
** Company Name: Windsor Solutions, Inc.
**
** Description:  This script will upgrade an existing OpenNode2 TRI 6.0 staging database to TRI v6.2.
**
** Revision History:
** ------------------------------------------------------------------------------------------------
** Date          Name        Description
** ------------------------------------------------------------------------------------------------
** 05/29/2024    Windsor     Created 
**
***************************************************************************************************/

---$ Alter table TRI_CHEM
DECLARE

 v_sql_statement VARCHAR2(255);
  
BEGIN
 
  SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_CHEM'
     AND user_tab_cols.column_name = 'METAL_CMP_RPT_INC_ELM_MTL_IND';
     
   dbms_output.put_line('The column PARENT_COMPANY_NAME_N_S on table TRI_FAC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_CHEM ADD METAL_CMP_RPT_INC_ELM_MTL_IND CHAR(1) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column METAL_CMP_RPT_INC_ELM_MTL_IND was added to the database table TRI_CHEM.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column METAL_CMP_RPT_INC_ELM_MTL_IND to the table TRI_CHEM, please investigate!');
      RAISE; 
END;
/
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_CHEM'
     AND user_tab_cols.column_name = 'LEAD_EXCD_THRSHLD_IND';
     
   dbms_output.put_line('The column LEAD_EXCD_THRSHLD_IND on table TRI_CHEM has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_CHEM ADD LEAD_EXCD_THRSHLD_IND CHAR(1) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column LEAD_EXCD_THRSHLD_IND was added to the database table TRI_CHEM.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column LEAD_EXCD_THRSHLD_IND to the table TRI_CHEM, please investigate!');
      RAISE; 
END;


---$ Alter table TRI_FAC
/
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_FAC'
     AND user_tab_cols.column_name = 'FRGN_PARENT_COMPANY_NAME_NA_IND';
     
   dbms_output.put_line('The column FRGN_PARENT_COMPANY_NAME_NA_IND on table TRI_FAC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_FAC ADD FRGN_PARENT_COMPANY_NAME_NA_IND CHAR(1) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column FRGN_PARENT_COMPANY_NAME_NA_IND was added to the database table TRI_FAC.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column FRGN_PARENT_COMPANY_NAME_NA_IND to the table TRI_FAC, please investigate!');
      RAISE; 
END;

/
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_FAC'
     AND user_tab_cols.column_name = 'FRGN_PARENT_COMPANY_TXT';
     
   dbms_output.put_line('The column FRGN_PARENT_COMPANY_TXT on table TRI_FAC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_FAC ADD FRGN_PARENT_COMPANY_TXT VARCHAR2(100) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column FRGN_PARENT_COMPANY_TXT was added to the database table TRI_FAC.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column FRGN_PARENT_COMPANY_TXT to the table TRI_FAC, please investigate!');
      RAISE; 
END;
/
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_FAC'
     AND user_tab_cols.column_name = 'FRGN_PARENT_COMPANY_NAME_N_S';
     
   dbms_output.put_line('The column FRGN_PARENT_COMPANY_NAME_N_S on table TRI_FAC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_FAC ADD FRGN_PARENT_COMPANY_NAME_N_S CHAR(1) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column FRGN_PARENT_COMPANY_NAME_N_S was added to the database table TRI_FAC.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column FRGN_PARENT_COMPANY_NAME_N_S to the table TRI_FAC, please investigate!');
      RAISE; 
END;
/
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_FAC'
     AND user_tab_cols.column_name = 'FRGN_PARENT_DUN_CODE';
     
   dbms_output.put_line('The column FRGN_PARENT_DUN_CODE on table TRI_FAC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_FAC ADD FRGN_PARENT_DUN_CODE VARCHAR2(100) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column FRGN_PARENT_DUN_CODE was added to the database table TRI_FAC.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column FRGN_PARENT_DUN_CODE to the table TRI_FAC, please investigate!');
      RAISE; 
END;
/

---$ Alter table TRI_POTW_WASTE_QUANTITY
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_POTW_WASTE_QUANTITY'
     AND user_tab_cols.column_name = 'POTW_TRANSFER_TYPE_CODE';
     
   dbms_output.put_line('The column POTW_TRANSFER_TYPE_CODE on table TRI_POTW_WASTE_QUANTITY has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_POTW_WASTE_QUANTITY ADD POTW_TRANSFER_TYPE_CODE VARCHAR2(32) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column POTW_TRANSFER_TYPE_CODE was added to the database table TRI_POTW_WASTE_QUANTITY.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column POTW_TRANSFER_TYPE_CODE to the table TRI_POTW_WASTE_QUANTITY, please investigate!');
      RAISE; 
END;
/
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_POTW_WASTE_QUANTITY'
     AND user_tab_cols.column_name = 'POTW_TRANSFER_SEQ_NUMBER';
     
   dbms_output.put_line('The column POTW_TRANSFER_SEQ_NUMBER on table TRI_POTW_WASTE_QUANTITY has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_POTW_WASTE_QUANTITY ADD POTW_TRANSFER_SEQ_NUMBER VARCHAR2(100) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column POTW_TRANSFER_SEQ_NUMBER was added to the database table TRI_POTW_WASTE_QUANTITY.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column POTW_TRANSFER_SEQ_NUMBER to the table TRI_POTW_WASTE_QUANTITY, please investigate!');
      RAISE; 
END;
/
---$ Alter table TRI_REPORT
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_REPORT'
     AND user_tab_cols.column_name = 'CHEM_PROC_RECYCG_IND';
     
   dbms_output.put_line('The column CHEM_PROC_RECYCG_IND on table TRI_REPORT has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_REPORT ADD CHEM_PROC_RECYCG_IND CHAR(1) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column CHEM_PROC_RECYCG_IND was added to the database table TRI_REPORT.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column CHEM_PROC_RECYCG_IND to the table TRI_REPORT, please investigate!');
      RAISE; 
END;
/

DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_REPORT'
     AND user_tab_cols.column_name = 'FORM_PREP_METH';
     
   dbms_output.put_line('The column FORM_PREP_METH on table TRI_REPORT has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_REPORT ADD FORM_PREP_METH VARCHAR2(32) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column FORM_PREP_METH was added to the database table TRI_REPORT.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column FORM_PREP_METH to the table TRI_REPORT, please investigate!');
      RAISE; 
END;
/

DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_REPORT'
     AND user_tab_cols.column_name = 'WASTE_ROCK_MGD_PILE_IND';
     
   dbms_output.put_line('The column WASTE_ROCK_MGD_PILE_IND on table TRI_REPORT has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_REPORT ADD WASTE_ROCK_MGD_PILE_IND CHAR(1) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column WASTE_ROCK_MGD_PILE_IND was added to the database table TRI_REPORT.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column WASTE_ROCK_MGD_PILE_IND to the table TRI_REPORT, please investigate!');
      RAISE; 
END;
/

DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_REPORT'
     AND user_tab_cols.column_name = 'WASTE_ROCK_QTY';
     
   dbms_output.put_line('The column WASTE_ROCK_QTY on table TRI_REPORT has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_REPORT ADD WASTE_ROCK_QTY VARCHAR2(100) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column WASTE_ROCK_QTY was added to the database table TRI_REPORT.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column WASTE_ROCK_QTY to the table TRI_REPORT, please investigate!');
      RAISE; 
END;
/
---$ Alter table TRI_TRANSFER_LOC
DECLARE

 v_sql_statement VARCHAR2(255);
 
BEGIN
 
SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_TRANSFER_LOC'
     AND user_tab_cols.column_name = 'EPA_REGISTRY_ID';
     
   dbms_output.put_line('The column EPA_REGISTRY_ID on table TRI_TRANSFER_LOC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

     v_sql_statement := 'ALTER TABLE TRI_TRANSFER_LOC ADD EPA_REGISTRY_ID VARCHAR2(32) NULL';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column EPA_REGISTRY_ID was added to the database table TRI_TRANSFER_LOC.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column EPA_REGISTRY_ID to the table TRI_TRANSFER_LOC, please investigate!');
      RAISE; 
END;

CREATE TABLE "TRI_CHEM_ANCLRY_USAGE_SUBCATG" (
	"PK_GUID" VARCHAR2(36) NOT NULL,
	"FK_GUID" VARCHAR2(36) NOT NULL,
	"CHEM_ANCLRY_USAGE_SUBCATG_CODE" VARCHAR2(32) NOT NULL
 );

CREATE TABLE "TRI_CHEM_FRMLN_CMPNT_SUBCATG" (
	"PK_GUID" VARCHAR2(36) NOT NULL,
	"FK_GUID" VARCHAR2(36) NOT NULL,
	"CHEM_FRMLN_CMPNT_SUBCATG_CODE" VARCHAR2(32) NOT NULL
 );

CREATE TABLE "TRI_CHEM_MFG_AID_SUBCATG" (
	"PK_GUID" VARCHAR2(36) NOT NULL,
	"FK_GUID" VARCHAR2(36) NOT NULL,
	"CHEM_MFG_AID_SUBCATG_CODE" VARCHAR2(32) NOT NULL
 );

CREATE TABLE "TRI_CHEM_PRCSS_AID_SUBCATG" (
	"PK_GUID" VARCHAR2(36) NOT NULL,
	"FK_GUID" VARCHAR2(36) NOT NULL,
	"CHEM_PRCSS_AID_SUBCATG_CODE" VARCHAR2(32) NOT NULL
 );

CREATE TABLE "TRI_CHEM_REACTNT_SUBCATG" (
	"PK_GUID" VARCHAR2(36) NOT NULL,
	"FK_GUID" VARCHAR2(36) NOT NULL,
	"CHEM_REACTNT_SUBCATG_CODE" VARCHAR2(32) NOT NULL
 );
 
 CREATE UNIQUE INDEX "PK_TRI_CHEM_ANCLRY_USAGE_SUBCATG"
 ON "TRI_CHEM_ANCLRY_USAGE_SUBCATG"("PK_GUID");
 
CREATE INDEX "IX_TRI_CHEM_ANCLRY_USAGE_SUBCATG"
 ON "TRI_CHEM_ANCLRY_USAGE_SUBCATG"("FK_GUID");

CREATE UNIQUE INDEX "PK_TRI_CHEM_FRMLN_CMPNT_SUBCATG"
 ON "TRI_CHEM_FRMLN_CMPNT_SUBCATG"("PK_GUID");

CREATE INDEX "IX_TRI_CHEM_FRMLN_CMPNT_SUBCATG"
 ON "TRI_CHEM_FRMLN_CMPNT_SUBCATG"("FK_GUID");
 
CREATE UNIQUE INDEX "PK_TRI_CHEM_MFG_AID_SUBCATG"
 ON "TRI_CHEM_MFG_AID_SUBCATG"("PK_GUID");

CREATE INDEX "IX_TRI_CHEM_MFG_AID_SUBCATG"
 ON "TRI_CHEM_MFG_AID_SUBCATG"("FK_GUID");
 
CREATE UNIQUE INDEX "PK_TRI_CHEM_PRCSS_AID_SUBCATG"
 ON "TRI_CHEM_PRCSS_AID_SUBCATG"("PK_GUID");

CREATE INDEX "IX_TRI_CHEM_PRCSS_AID_SUBCATG"
 ON "TRI_CHEM_PRCSS_AID_SUBCATG"("FK_GUID");
 
CREATE UNIQUE INDEX "PK_TRI_CHEM_REACTNT_SUBCATG"
 ON "TRI_CHEM_REACTNT_SUBCATG"("PK_GUID");

CREATE INDEX "IX_TRI_CHEM_REACTNT_SUBCATG"
 ON "TRI_CHEM_REACTNT_SUBCATG"("FK_GUID");


ALTER TABLE "TRI_CHEM_ANCLRY_USAGE_SUBCATG"
 ADD ( CONSTRAINT "PK_TRI_CHEM_ANCLRY_USAGE_SUBCATG"
 PRIMARY KEY ("PK_GUID")
 NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "TRI_CHEM_FRMLN_CMPNT_SUBCATG"
 ADD ( CONSTRAINT "PK_TRI_CHEM_FRMLN_CMPNT_SUBCATG"
 PRIMARY KEY ("PK_GUID")
 NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "TRI_CHEM_MFG_AID_SUBCATG"
 ADD ( CONSTRAINT "PK_TRI_CHEM_MFG_AID_SUBCATG"
 PRIMARY KEY ("PK_GUID")
 NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "TRI_CHEM_PRCSS_AID_SUBCATG"
 ADD ( CONSTRAINT "PK_TRI_CHEM_PRCSS_AID_SUBCATG"
 PRIMARY KEY ("PK_GUID")
 NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "TRI_CHEM_REACTNT_SUBCATG"
 ADD ( CONSTRAINT "PK_TRI_CHEM_REACTNT_SUBCATG"
 PRIMARY KEY ("PK_GUID")
 NOT DEFERRABLE INITIALLY IMMEDIATE );