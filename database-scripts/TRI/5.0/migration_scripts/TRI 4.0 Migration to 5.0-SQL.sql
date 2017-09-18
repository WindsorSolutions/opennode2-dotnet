/*************************************************************************************************
** ObjectName: TRI 4.0 Migration to 5.0-SQL.sql
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
    Script Note:  This script will migrate POTW data from the TRI_REPORT table into the newer
                  normalized table TRI_POTW_WASTE_QUANTITY.  Then once the data has been successfully
                  migrated the column source columns will be removed from TRI_REPORT in an effort to 
                  clean-up the schema.
*********************************************************************************************************/
BEGIN

  /* Alter TRI_REPORT, add column MISC_INF_TXT */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_REPORT'
                    AND columns.name = 'MISC_INF_TXT')
    BEGIN

      ALTER TABLE TRI_REPORT
        ADD MISC_INF_TXT VARCHAR(4000) NULL;
        
      PRINT 'The field MISC_INF_TXT was added to the table TRI_REPORT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field MISC_INF_TXT already existed on TRI_REPORT, schema alteration bypassed!';
    END;

 /*
  * Create table TRI_POTW_WASTE_QUANTITY 
  */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_POTW_WASTE_QUANTITY')
    BEGIN

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
        
      PRINT 'The table TRI_POTW_WASTE_QUANTITY was created!';
      
    END
  ELSE
    BEGIN
      PRINT 'The table TRI_POTW_WASTE_QUANTITY already existed, schema alteration bypassed!';
    END;
    
 /*
  * Create table TRI_POTW_WASTE_QUANTITY primary key.
  */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.key_constraints
                     ON key_constraints.parent_object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_POTW_WASTE_QUANTITY'
                    AND key_constraints.type = 'PK')
    BEGIN

      ALTER TABLE "TRI_POTW_WASTE_QUANTITY"
	      ADD CONSTRAINT "PK_TRI_POTW_WASTE_QUANTITY"
	      PRIMARY KEY ("PK_GUID");

        
      PRINT 'The table TRI_POTW_WASTE_QUANTITY primary key created!';
      
    END
  ELSE
    BEGIN
      PRINT 'The table TRI_POTW_WASTE_QUANTITY primary key already existed, schema alteration bypassed!';
    END;
    
 /*
  * Create table TRI_POTW_WASTE_QUANTITY foreign key to TRI_REPORT.
  */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.foreign_keys
                     ON foreign_keys.schema_id = schemas.schema_id
                   JOIN sys.tables parent
                     ON parent.object_id = foreign_keys.referenced_object_id
                   JOIN sys.tables child
                     ON child.object_id = foreign_keys.parent_object_id
                  WHERE schemas.name = 'dbo'
                    AND child.name = 'TRI_POTW_WASTE_QUANTITY'
                    AND parent.name = 'TRI_REPORT')
    BEGIN

      ALTER TABLE "TRI_POTW_WASTE_QUANTITY"
	      ADD CONSTRAINT "FK_TRI_RPT_POTW_WQ"
	      FOREIGN KEY("FK_GUID")
	      REFERENCES TRI_REPORT("PK_GUID")
	      ON DELETE CASCADE; 

      PRINT 'The table TRI_POTW_WASTE_QUANTITY foreign key to TRI REPORT created!';
      
    END
  ELSE
    BEGIN
      PRINT 'The table TRI_POTW_WASTE_QUANTITY foreign key to TRI REPORT already created, schema alteration bypassed!';
    END;
  
  /* ********************************************************************************
   *  Check to ensure POTW colums still exist on TRI_REPORT.  If not exit process 
   * *******************************************************************************/
  IF  EXISTS (SELECT 1 
                FROM sys.objects
                JOIN sys.columns
                  ON (columns.object_id = objects.object_id)
               WHERE objects.type = 'U'
                 AND objects.name = 'TRI_REPORT'
                 AND columns.name = 'TOX_EQ_VAL1_POTW')
    BEGIN

      DECLARE @v_sql VARCHAR(4000);
      PRINT 'Copying POTW data from TRI_REPORT to TRI_POTW_WASTE_QUANTITY, Start';
      
      /* Note this is dynamic so the script can, without failure, once the POTW columns have been
              removed from the table TRI_REPORT
      */
      SET @v_sql = 'INSERT INTO tri_potw_waste_quantity
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
                    SELECT NEWID()
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
      EXECUTE(@v_sql);
      
    PRINT 'Copying POTW data from TRI_REPORT to TRI_POTW_WASTE_QUANTITY, Completed!';
    
    /* Verify data migration, then trigger column pruning on TRI_REPORT */
    IF NOT EXISTS (SELECT 1
                     FROM tri_potw_waste_quantity
                    WHERE NOT EXISTS (SELECT 1 
                                        FROM tri_report
                                       WHERE tri_report.pk_guid = tri_potw_waste_quantity.fk_guid))
                                       
      BEGIN

    
         /* *******************************************************************************************
             The POTW data has been successfully migrated from TRI_REPORT to TRI_POTW_WASTE_QUANTITY 
             now we need to prune the redundant columns from the TRI_REPORT table to clean-up after 
             ourselves.
            *******************************************************************************************/

         /* Drop TRI 4.0 columns from TRI_REPORT */
         ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_ME;
         ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_CATASTROPHIC_MEASURE;
         ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_RANGE_CODE;
         ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_RANGE_NUM_BASIS_VALUE;
         ALTER TABLE TRI_REPORT DROP COLUMN WASTE_Q_ME_NA_IND;
         ALTER TABLE TRI_REPORT DROP COLUMN Q_BASIS_EST_CODE;
         ALTER TABLE TRI_REPORT DROP COLUMN Q_BASIS_EST_NA_IND;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL1_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL2_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL3_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL4_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL5_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL6_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL7_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL8_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL9_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL10_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL11_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL12_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL13_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL14_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL15_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL16_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_VAL17_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN TOX_EQ_NA_IND_POTW;
         ALTER TABLE TRI_REPORT DROP COLUMN Q_DISP_LANDFILL_PERCENT_VALUE;
         ALTER TABLE TRI_REPORT DROP COLUMN Q_DISP_OTHER_PERCENT_VALUE;
         ALTER TABLE TRI_REPORT DROP COLUMN Q_TREATED_PERCENT_VALUE;
         
         PRINT 'All rows accounted for in TRI_POTW_WASTE_QUANTITY from TRI_REPORT, POTW columns successfully removed from TRI_REPORT.';

    END;  -- POTW Columns pruned from TRI_REPORT
  END;  -- POTW Columns existed, data copied
ELSE

  /* The POTW columns are no longer found on the TRI_REPORT table, process ends successfully */
  BEGIN
    PRINT 'The POTW columns do not exist on TRI_REPORT, schema alteration bypassed!';
  END;
  
END; -- Migrate POTW Data