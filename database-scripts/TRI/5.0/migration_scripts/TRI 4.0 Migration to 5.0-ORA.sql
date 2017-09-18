/*************************************************************************************************
** ObjectName: TRI 4.0 Migration to 5.0-ORA.sql
**
** Author: Windsor Solutions, Inc.
**
** Company Name: Windsor Solutions, Inc.
**
** Description:  This script will update an existing TRI 4.0 database to support the TRI 5.0.  
**               This script can be run multiple times without issue.
**
** Revision History:
** ------------------------------------------------------------------------------------------------
** Date          Name        Description
** ------------------------------------------------------------------------------------------------
** 12/04/2012    Windsor     Created
*************************************************************************************************/

/********************************************************************************************************  
    Script Note:  This anoymous block will determine the columns called TOX_EQ_NA_IND that have been 
                  defined as VARCHAR2(100) and Modify those columns to TRIDEX 5.0 standard of CHAR(01).
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  FOR ddls IN (SELECT 'ALTER TABLE ' || user_tab_cols.table_name || ' MODIFY ' || user_tab_cols.column_name || ' CHAR(01)' AS statements
                   , user_tab_cols.table_name
                   , user_tab_cols.column_name
                FROM user_tab_cols
               WHERE user_tab_cols.column_name LIKE 'TOX_EQ_NA_IND%'
                 AND user_tab_cols.data_type = 'VARCHAR2'
                 AND user_tab_cols.data_length = 100
                 AND SUBSTR(user_tab_cols.table_name,1,2) <> 'V_'
                 ) LOOP
                 
      EXECUTE IMMEDIATE ddls.statements;
      
      DBMS_OUTPUT.PUT_LINE( 'The field ' || ddls.column_name || ' was modified to CHAR(01) on table ' || ddls.table_name || '.');

  END LOOP;
    
END;
/

/********************************************************************************************************  
    Script Note:  This anoymous block will determine if the column called TRANSACTION_ID has been 
                  defined NOT AS as VARCHAR2(50) and Modify that column to VARCHAR2(50).
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  FOR ddls IN (SELECT 'ALTER TABLE ' || user_tab_cols.table_name || ' MODIFY ' || user_tab_cols.column_name || ' VARCHAR2(50)' AS statements
                   , user_tab_cols.table_name
                   , user_tab_cols.column_name
                FROM user_tab_cols
               WHERE user_tab_cols.table_name = 'TRI_SUB'
                 AND user_tab_cols.column_name = 'TRANSACTION_ID'
                 AND user_tab_cols.data_type = 'VARCHAR2'
                 AND user_tab_cols.data_length <> 50) LOOP
  
    EXECUTE IMMEDIATE ddls.statements;
    
    DBMS_OUTPUT.PUT_LINE( 'The field ' || ddls.column_name || ' was modified to VARCHAR2(50) on table ' || ddls.table_name || '.');

  END LOOP;
    
END;
/

/********************************************************************************************************  
    Script Note:  This anonymous block will determine if the column MISC_INF_TXT exists on the database
                  table TRI_REPORT.  If it does not exist the table TRI_REPORT will be altered and the
                  new column MISC_INF_TXT will be added.
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  /*  Check to see if MISC_INF_TXT column exists on the database table TRI_REPORT  */
   SELECT 1
     INTO v_object_ind
     FROM user_tables
     JOIN user_tab_cols
       ON user_tab_cols.table_name = user_tables.table_name
    WHERE user_tables.table_name = 'TRI_REPORT'
      AND user_tab_cols.column_name = 'MISC_INF_TXT';
   
   /* The column already exists in schema, bypass creation */
    DBMS_OUTPUT.PUT_LINE( 'The field MISC_INF_TXT already existed on TRI_REPORT, schema alteration bypassed!');

EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      v_sql_statement := 'ALTER TABLE TRI_REPORT ADD MISC_INF_TXT VARCHAR(4000) NULL';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The field MISC_INF_TXT was added to the table TRI_REPORT!');
       
     END;  -- MISC_INF_TXT
        
END;
/
    

/********************************************************************************************************  
    Script Note:  This anonymous block will determine if the current schema contains the database table
                  TRI_POTW_WASTE_QUANTITY. If it does not exist then it is created, along with it's
                  related primary and foreign key constraints.
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  /*  Check to see if TRI_POTW_WASTE_QUANTITY exists in the schema  */
  SELECT 1
    INTO v_object_ind
    FROM user_tables
   WHERE user_tables.table_name = 'TRI_POTW_WASTE_QUANTITY';
   
   /* The table already exists in schema, bypass creation */
      DBMS_OUTPUT.PUT_LINE( 'The table TRI_POTW_WASTE_QUANTITY already existed, schema alteration bypassed!');

EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    /* Create Table:  TRI_POTW_WASTE_QUANTITY */
    BEGIN
      v_sql_statement := ' CREATE TABLE TRI_POTW_WASTE_QUANTITY   ' ||
                         '  ( PK_GUID                       varchar(36) NOT NULL  ' ||
                         '  , FK_GUID                       varchar(36) NOT NULL  ' ||
                         '  , POTW_SEQ_NO                   varchar(100) NULL  ' ||
                         '  , WASTE_Q_ME                    varchar(100) NULL  ' ||
                         '  , WASTE_Q_CATASTROPHIC_MEASURE  varchar(100) NULL  ' ||
                         '  , WASTE_Q_RANGE_CODE            varchar(100) NULL  ' ||
                         '  , WASTE_Q_RANGE_NUM_BASIS_VALUE varchar(100) NULL  ' ||
                         '  , WASTE_Q_ME_NA_IND             char(1) NULL       ' ||
                         '  , Q_BASIS_EST_CODE              varchar(100) NULL  ' ||
                         '  , Q_BASIS_EST_NA_IND            char(1) NULL       ' ||
                         '  , TOX_EQ_VAL1                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL2                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL3                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL4                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL5                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL6                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL7                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL8                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL9                   varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL10                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL11                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL12                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL13                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL14                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL15                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL16                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_VAL17                  varchar(100) NULL  ' ||
                         '  , TOX_EQ_NA_IND                 char(1) NULL       ' ||
                         '  , Q_DISP_LANDFILL_PERCENT_VALUE varchar(100) NULL  ' ||
                         '  , Q_DISP_OTHER_PERCENT_VALUE    varchar(100) NULL  ' ||
                         '  , Q_TREATED_PERCENT_VALUE       varchar(100) NULL) ';

          EXECUTE IMMEDIATE v_sql_statement;   
          DBMS_OUTPUT.PUT_LINE( 'The table TRI_POTW_WASTE_QUANTITY was created!');
       
        END;  -- TRI_POTW_WASTE_QUANTITY
        
        /* Create Primary Key:  PK_TRI_POTW_WASTE_QUANTITY  */
        BEGIN
        
          v_sql_statement:= 'ALTER TABLE TRI_POTW_WASTE_QUANTITY ADD CONSTRAINT PK_TRI_POTW_WASTE_QUANTITY PRIMARY KEY (PK_GUID)';
          EXECUTE IMMEDIATE v_sql_statement;   
          DBMS_OUTPUT.PUT_LINE('The table TRI_POTW_WASTE_QUANTITY primary key created!');
          
        END;  -- PK_TRI_POTW_WASTE_QUANTITY
        
        /* Create Primary Key:  PK_TRI_POTW_WASTE_QUANTITY  */
        BEGIN
        
          v_sql_statement :=  'ALTER TABLE TRI_POTW_WASTE_QUANTITY ADD CONSTRAINT FK_TRI_RPT_POTW_WQ ' || 
                              'FOREIGN KEY(FK_GUID) REFERENCES TRI_REPORT(PK_GUID) ON DELETE CASCADE ';
          EXECUTE IMMEDIATE v_sql_statement;   
          DBMS_OUTPUT.PUT_LINE('The table TRI_POTW_WASTE_QUANTITY foreign key to TRI REPORT created!');
          
        END;  -- PK_TRI_POTW_WASTE_QUANTITY
        
END;
/


/********************************************************************************************************  
    Script Note:  This anonymous block will migrate POTW data from the TRI_REPORT table into the newer
                  normalized table TRI_POTW_WASTE_QUANTITY.  Then once the data has been successfully
                  migrated the column source columns will be removed from TRI_REPORT in an effort to 
                  clean-up the schema.
*********************************************************************************************************/
DECLARE

v_sql VARCHAR2(4000);
v_record_count NUMBER(1,0) := 0 ;
v_column_count NUMBER(1,0) := 0 ;

e_end_process EXCEPTION;

BEGIN

  /* 
      Check for existence of POTW columns on TRI_REPORT, If found continue, otherwise
      NO_DATA_FOUND occurs and process ends here.
   */
  SELECT 1
    INTO v_column_count
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_REPORT'
     AND user_tab_cols.column_name = 'TOX_EQ_VAL1_POTW';

  DBMS_OUTPUT.PUT_LINE('Copying POTW data from TRI_REPORT to TRI_POTW_WASTE_QUANTITY, Start');
  
  BEGIN
  
    /* 
       Dynamically copy data from TRI_REPORT to TRI_POTW_WASTE_QUANTITY.  If this is not 
       dynamic SQL this script fails once the columns have been pruned on subsequent runs. 
     */
    v_sql := 'INSERT INTO tri_potw_waste_quantity
                   ( pk_guid
                   , fk_guid
                   , potw_seq_no
                   , waste_q_me
                   , waste_q_catastrophic_measure
                   , waste_q_range_code
                   , waste_q_range_num_basis_value
                   , waste_q_me_na_ind
                   , q_basis_est_code
                   , q_basis_est_na_ind
                   , tox_eq_val1
                   , tox_eq_val2
                   , tox_eq_val3
                   , tox_eq_val4
                   , tox_eq_val5
                   , tox_eq_val6
                   , tox_eq_val7
                   , tox_eq_val8
                   , tox_eq_val9
                   , tox_eq_val10
                   , tox_eq_val11
                   , tox_eq_val12
                   , tox_eq_val13
                   , tox_eq_val14
                   , tox_eq_val15
                   , tox_eq_val16
                   , tox_eq_val17
                   , tox_eq_na_ind
                   , q_disp_landfill_percent_value
                   , q_disp_other_percent_value
                   , q_treated_percent_value) 
              SELECT SYS_GUID()
                   , tri_report.pk_guid 
                   , 1
                   , tri_report.waste_q_me
                   , tri_report.waste_q_catastrophic_measure
                   , tri_report.waste_q_range_code
                   , tri_report.waste_q_range_num_basis_value
                   , tri_report.waste_q_me_na_ind
                   , tri_report.q_basis_est_code
                   , tri_report.q_basis_est_na_ind
                   , tri_report.tox_eq_val1_potw
                   , tri_report.tox_eq_val2_potw
                   , tri_report.tox_eq_val3_potw
                   , tri_report.tox_eq_val4_potw
                   , tri_report.tox_eq_val5_potw
                   , tri_report.tox_eq_val6_potw
                   , tri_report.tox_eq_val7_potw
                   , tri_report.tox_eq_val8_potw
                   , tri_report.tox_eq_val9_potw
                   , tri_report.tox_eq_val10_potw
                   , tri_report.tox_eq_val11_potw
                   , tri_report.tox_eq_val12_potw
                   , tri_report.tox_eq_val13_potw
                   , tri_report.tox_eq_val14_potw
                   , tri_report.tox_eq_val15_potw
                   , tri_report.tox_eq_val16_potw
                   , tri_report.tox_eq_val17_potw
                   , tri_report.tox_eq_na_ind_potw
                   , tri_report.q_disp_landfill_percent_value
                   , tri_report.q_disp_other_percent_value
                   , tri_report.q_treated_percent_value
                FROM tri_report
               WHERE tri_report.waste_q_me IS NOT NULL';                                                 
                   
    /* Run INSERT statement */                  
    EXECUTE IMMEDIATE v_sql;
      
    /* Commit data changes */
    COMMIT;
      
    DBMS_OUTPUT.PUT_LINE('Copying POTW data from TRI_REPORT to TRI_POTW_WASTE_QUANTITY, Completed!');
  
  EXCEPTION
    WHEN OTHERS THEN
    
      DBMS_OUTPUT.PUT_LINE('An error occured while copying the POTW data to TRI_POTW_WASTE_QUANTITY, please investigate.');
      RAISE e_end_process;
  
  END;


  /* Check to ensure all data was properly migrated */
  SELECT COUNT(1)
    INTO v_record_count
    FROM tri_potw_waste_quantity
   WHERE NOT EXISTS (SELECT 1 
                       FROM tri_report
                      WHERE tri_report.pk_guid = tri_potw_waste_quantity.fk_guid);
  
  IF v_record_count = 0 THEN
    
    DBMS_OUTPUT.PUT_LINE('All rows accounted for in TRI_POTW_WASTE_QUANTITY from TRI_REPORT, beginning column pruning process.');
    
    /* *******************************************************************************************
       The POTW data has been successfully migrated from TRI_REPORT to TRI_POTW_WASTE_QUANTITY 
       now we need to prune the redundant columns from the TRI_REPORT table to clean-up after 
       ourselves.
    **********************************************************************************************/     
           
    /* Drop TRI 4.0 columns from TRI_REPORT */
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_ME';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_CATASTROPHIC_MEASURE';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_RANGE_CODE';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_RANGE_NUM_BASIS_VALUE';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_ME_NA_IND';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN Q_BASIS_EST_CODE';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN Q_BASIS_EST_NA_IND';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL1_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL2_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL3_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL4_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL5_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL6_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL7_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL8_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL9_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL10_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL11_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL12_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL13_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL14_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL15_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL16_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL17_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_NA_IND_POTW';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN Q_DISP_LANDFILL_PERCENT_VALUE';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN Q_DISP_OTHER_PERCENT_VALUE';
    EXECUTE IMMEDIATE 'ALTER TABLE TRI_REPORT DROP COLUMN Q_TREATED_PERCENT_VALUE';
          
    DBMS_OUTPUT.PUT_LINE('Pruning POTW columns from TRI_REPORT table, Completed.');

  END IF;  -- Data check TRI_REPORT vs. TRI_POTW_WASTE_QUANTITY
  
EXCEPTION
  WHEN NO_DATA_FOUND THEN
  
    DBMS_OUTPUT.PUT_LINE('The POTW columns do not exist on TRI_REPORT any longer, process completed but no changes have occured.');

  WHEN E_END_PROCESS THEN
  
    DBMS_OUTPUT.PUT_LINE('An error occured when migrating the POTW data and pruning the POTW columns from TRI_REPORT, the process immediately ended');
    
  WHEN OTHERS THEN
  
    DBMS_OUTPUT.PUT_LINE('An error occured when migrating the POTW data and pruning the POTW columns from TRI_REPORT, please investigate');
         
END;  -- Migrate POTW Data
/


/********************************************************************************************************  
    Script Note:  This script will determine if a unique contraint exists on the column TRI_SUB_ID on the
                  database table TRI_SUB.  If it does not exist the unique constraint will be added to
                  allow related database tables to create foreign key contraints back to TRI_SUB.
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  /*  Check to see if the unique constraint IX_TRI_SUB exists on the database table TRI_SUB */
   SELECT 1
     INTO v_object_ind
     FROM user_constraints
    WHERE user_constraints.table_name = 'TRI_SUB'
      AND user_constraints.constraint_type = 'U'
      AND user_constraints.constraint_name = 'IX_TRI_SUB';
   
   /* The column already exists in schema, bypass creation */
    DBMS_OUTPUT.PUT_LINE( 'The unique constraint IX_TRI_SUB already exists on TRI_SUB, schema alteration bypassed!');

EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      v_sql_statement := 'ALTER TABLE "TRI_SUB" ADD ( CONSTRAINT "IX_TRI_SUB" UNIQUE ("TRI_SUB_ID") NOT DEFERRABLE INITIALLY IMMEDIATE )';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The unique constraint IX_TRI_SUB was added to the table TRI_SUB!');
       
     END;  -- IX_TRI_SUB
        
END;
/
    

/********************************************************************************************************  
    Script Note:  This script will determine if a primary key contraint exists on the column TRI_SUB_ID 
                  on the database table TRI_CHEM.  If it does not exist the primary key constraint will 
                  be added to allow related database tables to create foreign key contraints back to 
                  TRI_SUB.
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  /*  Check to see if the unique constraint IX_TRI_SUB exists on the database table TRI_SUB */
   SELECT 1
     INTO v_object_ind
     FROM user_constraints
    WHERE user_constraints.table_name = 'TRI_CHEM'
      AND user_constraints.constraint_type = 'P';
   
   /* The column already exists in schema, bypass creation */
    DBMS_OUTPUT.PUT_LINE( 'The primary key constraint PK_TRI_CHEM already exists on TRI_CHEM, schema alteration bypassed!');

EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      v_sql_statement := 'ALTER TABLE TRI_CHEM ADD ( CONSTRAINT PK_TRI_CHEM PRIMARY KEY (PK_GUID) NOT DEFERRABLE INITIALLY IMMEDIATE )';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The unique constraint PK_TRI_CHEM was added to the table TRI_CHEM!');
       
     END;  -- PK_TRI_CHEM
        
END;
/

/********************************************************************************************************  
    Script Note:  This script will determine if in index exists on the column FAC_ID 
                  on the database table TRI_FAC.  If it does not exist the index will 
                  be created.
*********************************************************************************************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

  /*  Check to see if the unique constraint IX_TRI_SUB exists on the database table TRI_SUB */
   SELECT 1
     INTO v_object_ind
     FROM user_ind_columns
    WHERE user_ind_columns.table_name = 'TRI_FAC'
      AND user_ind_columns.column_name = 'FAC_ID';
   
   /* The column already exists in schema, bypass creation */
    DBMS_OUTPUT.PUT_LINE( 'The index IX_TRI_FAC_FAC_ID on table TRI_FAC column FAC_ID already exists, schema alteration bypassed!');

EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      v_sql_statement := 'CREATE INDEX IX_TRI_FAC_FAC_ID ON TRI_FAC(FAC_ID)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The index IX_TRI_FAC_FAC_ID was created on the table TRI_FAC, column FAC_ID!');
       
     END;  -- IX_TRI_FAC_FAC_ID
        
END;
/


