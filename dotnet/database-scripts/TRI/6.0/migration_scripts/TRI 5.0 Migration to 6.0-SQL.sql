/*************************************************************************************************
** ObjectName: TRI 5.0 Migration to 6.0-SQL.sql
**
** Author: Windsor Solutions, Inc.
**
** Company Name: Windsor Solutions, Inc.
**
** Description:  This script will update an existing TRI 5.0 database to support the TRI 6.0 schema.
**               This script can be run multiple times without issue.
**
** Revision History:
** ------------------------------------------------------------------------------------------------
** Date          Name        Description
** ------------------------------------------------------------------------------------------------
** 10/09/2015    Windsor     Created
** 10/16/2015    TK Conrad   Added index IX_TRI_COMMENT_FK_GUID to TRI_COMMENT.
** 10/16/2015    TK Conrad   Moved EPARecon table changes to TRIDEX 5.0 Migration to 6.0-SQL.sql.
*************************************************************************************************/

BEGIN

 /*
  * Create table TRI_COMMENT 
  */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_COMMENT')
    BEGIN

CREATE TABLE [dbo].[TRI_COMMENT](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[COMMENT_SEQ] [int] NULL,
	[COMMENT_SECTION] [varchar](50) NULL,
	[COMMENT_TYPE_CODE] [varchar](50) NULL,
	[COMMENT_TYPE_DESC] [varchar](255) NULL,
	[COMMENT_TEXT] [varchar](4000) NULL,
	[COMMENT_P2_CLASS] [varchar](100) NULL,

 CONSTRAINT [PK_TRI_COMMENT] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)
) ON [PRIMARY]

      PRINT 'The table TRI_COMMENT was created!';
      
    END
  ELSE
    BEGIN
      PRINT 'The table TRI_COMMENT already existed, schema alteration bypassed!';
    END;

 /*
  * Create table TRI_COMMENT foreign key to TRI_REPORT.
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
                    AND child.name = 'TRI_COMMENT'
                    AND parent.name = 'TRI_REPORT')
    BEGIN

      ALTER TABLE [TRI_COMMENT]
	      ADD CONSTRAINT [FK_COMMENT_REP]
	      FOREIGN KEY([FK_GUID])
	      REFERENCES TRI_REPORT([PK_GUID])
	      ON DELETE CASCADE; 

      PRINT 'The table TRI_COMMENT foreign key to TRI REPORT created!';
    END
  ELSE
    BEGIN
      PRINT 'The table TRI_COMMENT foreign key to TRI REPORT already created, schema alteration bypassed!';
    END;

 /*
  * Create index IX_TRI_COMMENT_FK_GUID for TRI_COMMENT.FK_GUID.
  */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.indexes
                     ON indexes.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_COMMENT'
                    AND indexes.name = 'IX_TRI_COMMENT_FK_GUID')

    BEGIN

	CREATE INDEX "IX_TRI_COMMENT_FK_GUID"
		ON "TRI_COMMENT"("FK_GUID")

      PRINT 'The index IX_TRI_COMMENT_FK_GUID for TRI_COMMENT created!';
    END
  ELSE
    BEGIN
      PRINT 'The index IX_TRI_COMMENT_FK_GUID for TRI_COMMENT already created, schema alteration bypassed!';
    END;

  /* Alter TRI_FAC, add column PARENT_COMPANY_NAME_N_S */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_FAC'
                    AND columns.name = 'PARENT_COMPANY_NAME_N_S')
    BEGIN

      ALTER TABLE TRI_FAC
        ADD PARENT_COMPANY_NAME_N_S CHAR(1) NULL;
        
      PRINT 'The field PARENT_COMPANY_NAME_N_S was added to the table TRI_FAC!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field PARENT_COMPANY_NAME_N_S already existed on TRI_FAC, schema alteration bypassed!';
    END;

  /* Alter TRI_ONSITE_RELEASE_Q, add column STREAM_REACH_CODE */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_ONSITE_RELEASE_Q'
                    AND columns.name = 'STREAM_REACH_CODE')
    BEGIN

      ALTER TABLE TRI_ONSITE_RELEASE_Q
        ADD STREAM_REACH_CODE varchar(100) NULL;
        
      PRINT 'The field STREAM_REACH_CODE was added to the table TRI_ONSITE_RELEASE_Q!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field STREAM_REACH_CODE already existed on TRI_ONSITE_RELEASE_Q, schema alteration bypassed!';
    END;

/* Alter TRI_REPORT, add column TECH_CONT_PHONE_EXT_TXT */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_REPORT'
                    AND columns.name = 'TECH_CONT_PHONE_EXT_TXT')
    BEGIN

      ALTER TABLE TRI_REPORT
        ADD TECH_CONT_PHONE_EXT_TXT varchar(100) NULL;
        
      PRINT 'The field TECH_CONT_PHONE_EXT_TXT was added to the table TRI_REPORT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field TECH_CONT_PHONE_EXT_TXT already existed on TRI_REPORT, schema alteration bypassed!';
    END;

/* Alter TRI_REPORT, add column PUB_CONT_PHONE_EXT_TXT */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_REPORT'
                    AND columns.name = 'PUB_CONT_PHONE_EXT_TXT')
    BEGIN

      ALTER TABLE TRI_REPORT
        ADD PUB_CONT_PHONE_EXT_TXT varchar(100) NULL;
        
      PRINT 'The field PUB_CONT_PHONE_EXT_TXT was added to the table TRI_REPORT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field PUB_CONT_PHONE_EXT_TXT already existed on TRI_REPORT, schema alteration bypassed!';
    END;

/* Alter TRI_REPORT, add column OPT_INF_CATG */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_REPORT'
                    AND columns.name = 'OPT_INF_CATG')
    BEGIN

      ALTER TABLE TRI_REPORT
        ADD OPT_INF_CATG varchar(100) NULL;
        
      PRINT 'The field OPT_INF_CATG was added to the table TRI_REPORT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field OPT_INF_CATG already existed on TRI_REPORT, schema alteration bypassed!';
    END;

/* Alter TRI_REPORT, add column MISC_INF_CATG */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_REPORT'
                    AND columns.name = 'MISC_INF_CATG')
    BEGIN

      ALTER TABLE TRI_REPORT
        ADD MISC_INF_CATG varchar(100) NULL;
        
      PRINT 'The field MISC_INF_CATG was added to the table TRI_REPORT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field MISC_INF_CATG already existed on TRI_REPORT, schema alteration bypassed!';
    END;

/* Alter TRI_REPORT, add column PRODUCTION_RATIO_TYPE */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_REPORT'
                    AND columns.name = 'PRODUCTION_RATIO_TYPE')
    BEGIN

      ALTER TABLE TRI_REPORT
        ADD PRODUCTION_RATIO_TYPE varchar(100) NULL;
        
      PRINT 'The field PRODUCTION_RATIO_TYPE was added to the table TRI_REPORT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field PRODUCTION_RATIO_TYPE already existed on TRI_REPORT, schema alteration bypassed!';
    END;

/* Alter TRI_SRC_RED_ACT, add column SRC_RED_EFF_CODE */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'TRI_SRC_RED_ACT'
                    AND columns.name = 'SRC_RED_EFF_CODE')
    BEGIN

      ALTER TABLE TRI_SRC_RED_ACT
        ADD SRC_RED_EFF_CODE varchar(100) NULL;
        
      PRINT 'The field SRC_RED_EFF_CODE was added to the table TRI_SRC_RED_ACT!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field SRC_RED_EFF_CODE already existed on TRI_SRC_RED_ACT, schema alteration bypassed!';
    END;

END;
