/*************************************************************************************************
** ObjectName: TRI_6.2-SQL-Upgrade_v6.0_schema_to_v6.2.sql
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


---$ Alter table dbo.TRI_CHEM
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM') AND NAME = 'METAL_CMP_RPT_INC_ELM_MTL_IND')
BEGIN
    ALTER TABLE dbo.TRI_CHEM
        ADD METAL_CMP_RPT_INC_ELM_MTL_IND CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM') AND NAME = 'LEAD_EXCD_THRSHLD_IND')
BEGIN
    ALTER TABLE dbo.TRI_CHEM
        ADD LEAD_EXCD_THRSHLD_IND CHAR(1) NULL
END
GO


---$ Alter table dbo.TRI_FAC
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_FAC') AND NAME = 'FRGN_PARENT_COMPANY_NAME_NA_IND')
BEGIN
    ALTER TABLE dbo.TRI_FAC
        ADD FRGN_PARENT_COMPANY_NAME_NA_IND CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_FAC') AND NAME = 'FRGN_PARENT_COMPANY_TXT')
BEGIN
    ALTER TABLE dbo.TRI_FAC
        ADD FRGN_PARENT_COMPANY_TXT VARCHAR(100) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_FAC') AND NAME = 'FRGN_PARENT_COMPANY_NAME_N_S')
BEGIN
    ALTER TABLE dbo.TRI_FAC
        ADD FRGN_PARENT_COMPANY_NAME_N_S CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_FAC') AND NAME = 'FRGN_PARENT_DUN_CODE')
BEGIN
    ALTER TABLE dbo.TRI_FAC
        ADD FRGN_PARENT_DUN_CODE VARCHAR(100) NULL
END
GO


---$ Alter table dbo.TRI_POTW_WASTE_QUANTITY
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_POTW_WASTE_QUANTITY') AND NAME = 'POTW_TRANSFER_TYPE_CODE')
BEGIN
    ALTER TABLE dbo.TRI_POTW_WASTE_QUANTITY
        ADD POTW_TRANSFER_TYPE_CODE VARCHAR(32) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_POTW_WASTE_QUANTITY') AND NAME = 'POTW_TRANSFER_SEQ_NUMBER')
BEGIN
    ALTER TABLE dbo.TRI_POTW_WASTE_QUANTITY
        ADD POTW_TRANSFER_SEQ_NUMBER VARCHAR(100) NULL
END
GO


---$ Alter table dbo.TRI_REPORT
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_REPORT') AND NAME = 'CHEM_PROC_RECYCG_IND')
BEGIN
    ALTER TABLE dbo.TRI_REPORT
        ADD CHEM_PROC_RECYCG_IND CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_REPORT') AND NAME = 'FORM_PREP_METH')
BEGIN
    ALTER TABLE dbo.TRI_REPORT
        ADD FORM_PREP_METH VARCHAR(32) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_REPORT') AND NAME = 'WASTE_ROCK_MGD_PILE_IND')
BEGIN
    ALTER TABLE dbo.TRI_REPORT
        ADD WASTE_ROCK_MGD_PILE_IND CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_REPORT') AND NAME = 'WASTE_ROCK_QTY')
BEGIN
    ALTER TABLE dbo.TRI_REPORT
        ADD WASTE_ROCK_QTY VARCHAR(100) NULL
END
GO


---$ Alter table dbo.TRI_TRANSFER_LOC
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_TRANSFER_LOC') AND NAME = 'EPA_REGISTRY_ID')
BEGIN
    ALTER TABLE dbo.TRI_TRANSFER_LOC
        ADD EPA_REGISTRY_ID VARCHAR(32) NULL
END
GO


---$ Create table dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG
IF OBJECT_ID(N'dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG') IS NULL
BEGIN
    CREATE TABLE dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG
    (
        PK_GUID VARCHAR(36) NOT NULL,
        FK_GUID VARCHAR(36) NOT NULL,
        CHEM_ANCLRY_USAGE_SUBCATG_CODE VARCHAR(32) NOT NULL
    )
    END
GO


---$ Create table dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG
IF OBJECT_ID(N'dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG') IS NULL
BEGIN
    CREATE TABLE dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG
    (
        PK_GUID VARCHAR(36) NOT NULL,
        FK_GUID VARCHAR(36) NOT NULL,
        CHEM_FRMLN_CMPNT_SUBCATG_CODE VARCHAR(32) NOT NULL
    )
    END
GO


---$ Create table dbo.TRI_CHEM_MFG_AID_SUBCATG
IF OBJECT_ID(N'dbo.TRI_CHEM_MFG_AID_SUBCATG') IS NULL
BEGIN
    CREATE TABLE dbo.TRI_CHEM_MFG_AID_SUBCATG
    (
        PK_GUID VARCHAR(36) NOT NULL,
        FK_GUID VARCHAR(36) NOT NULL,
        CHEM_MFG_AID_SUBCATG_CODE VARCHAR(32) NOT NULL
    )
    END
GO


---$ Create table dbo.TRI_CHEM_PRCSS_AID_SUBCATG
IF OBJECT_ID(N'dbo.TRI_CHEM_PRCSS_AID_SUBCATG') IS NULL
BEGIN
    CREATE TABLE dbo.TRI_CHEM_PRCSS_AID_SUBCATG
    (
        PK_GUID VARCHAR(36) NOT NULL,
        FK_GUID VARCHAR(36) NOT NULL,
        CHEM_PRCSS_AID_SUBCATG_CODE VARCHAR(32) NOT NULL
    )
    END
GO


---$ Create table dbo.TRI_CHEM_REACTNT_SUBCATG
IF OBJECT_ID(N'dbo.TRI_CHEM_REACTNT_SUBCATG') IS NULL
BEGIN
    CREATE TABLE dbo.TRI_CHEM_REACTNT_SUBCATG
    (
        PK_GUID VARCHAR(36) NOT NULL,
        FK_GUID VARCHAR(36) NOT NULL,
        CHEM_REACTNT_SUBCATG_CODE VARCHAR(32) NOT NULL
    )
    END
GO


---$ Create Index/PK: IX_TRI_CHEM_ANCLRY_USAGE_SUBCATG_FK_GUID, Table : dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG
IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG') AND NAME = 'IX_TRI_CHEM_ANCLRY_USAGE_SUBCATG_FK_GUID')
    CREATE  NONCLUSTERED  INDEX IX_TRI_CHEM_ANCLRY_USAGE_SUBCATG_FK_GUID
        ON dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG(FK_GUID)
        WITH(IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = NONE)
GO

---$ Create Index/PK: PK_TRI_CHEM_ANCLRY_USAGE_SUBCATG, Table : dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG
IF OBJECT_ID(N'dbo.PK_TRI_CHEM_ANCLRY_USAGE_SUBCATG') IS NULL
    ALTER TABLE dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG
        ADD CONSTRAINT PK_TRI_CHEM_ANCLRY_USAGE_SUBCATG PRIMARY KEY CLUSTERED(PK_GUID)
GO

---$ Create Index/PK: IX_TRI_CHEM_FRMLN_CMPNT_SUBCATG_FK_GUID, Table : dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG
IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG') AND NAME = 'IX_TRI_CHEM_FRMLN_CMPNT_SUBCATG_FK_GUID')
    CREATE  NONCLUSTERED  INDEX IX_TRI_CHEM_FRMLN_CMPNT_SUBCATG_FK_GUID
        ON dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG(FK_GUID)
        WITH(IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = NONE)
GO

---$ Create Index/PK: PK_TRI_CHEM_FRMLN_CMPNT_SUBCATG, Table : dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG
IF OBJECT_ID(N'dbo.PK_TRI_CHEM_FRMLN_CMPNT_SUBCATG') IS NULL
    ALTER TABLE dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG
        ADD CONSTRAINT PK_TRI_CHEM_FRMLN_CMPNT_SUBCATG PRIMARY KEY CLUSTERED(PK_GUID)
GO

---$ Create Index/PK: IX_TRI_CHEM_MFG_AID_SUBCATG_FK_GUID, Table : dbo.TRI_CHEM_MFG_AID_SUBCATG
IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM_MFG_AID_SUBCATG') AND NAME = 'IX_TRI_CHEM_MFG_AID_SUBCATG_FK_GUID')
    CREATE  NONCLUSTERED  INDEX IX_TRI_CHEM_MFG_AID_SUBCATG_FK_GUID
        ON dbo.TRI_CHEM_MFG_AID_SUBCATG(FK_GUID)
        WITH(IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = NONE)
GO

---$ Create Index/PK: PK_TRI_CHEM_MFG_AID_SUBCATG, Table : dbo.TRI_CHEM_MFG_AID_SUBCATG
IF OBJECT_ID(N'dbo.PK_TRI_CHEM_MFG_AID_SUBCATG') IS NULL
    ALTER TABLE dbo.TRI_CHEM_MFG_AID_SUBCATG
        ADD CONSTRAINT PK_TRI_CHEM_MFG_AID_SUBCATG PRIMARY KEY CLUSTERED(PK_GUID)
GO

---$ Create Index/PK: IX_TRI_CHEM_PRCSS_AID_SUBCATG_FK_GUID, Table : dbo.TRI_CHEM_PRCSS_AID_SUBCATG
IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM_PRCSS_AID_SUBCATG') AND NAME = 'IX_TRI_CHEM_PRCSS_AID_SUBCATG_FK_GUID')
    CREATE  NONCLUSTERED  INDEX IX_TRI_CHEM_PRCSS_AID_SUBCATG_FK_GUID
        ON dbo.TRI_CHEM_PRCSS_AID_SUBCATG(FK_GUID)
        WITH(IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = NONE)
GO

---$ Create Index/PK: PK_TRI_CHEM_PRCSS_AID_SUBCATG, Table : dbo.TRI_CHEM_PRCSS_AID_SUBCATG
IF OBJECT_ID(N'dbo.PK_TRI_CHEM_PRCSS_AID_SUBCATG') IS NULL
    ALTER TABLE dbo.TRI_CHEM_PRCSS_AID_SUBCATG
        ADD CONSTRAINT PK_TRI_CHEM_PRCSS_AID_SUBCATG PRIMARY KEY CLUSTERED(PK_GUID)
GO

---$ Create Index/PK: IX_TRI_CHEM_REACTNT_SUBCATG_FK_GUID, Table : dbo.TRI_CHEM_REACTNT_SUBCATG
IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID(N'dbo.TRI_CHEM_REACTNT_SUBCATG') AND NAME = 'IX_TRI_CHEM_REACTNT_SUBCATG_FK_GUID')
    CREATE  NONCLUSTERED  INDEX IX_TRI_CHEM_REACTNT_SUBCATG_FK_GUID
        ON dbo.TRI_CHEM_REACTNT_SUBCATG(FK_GUID)
        WITH(IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = NONE)
GO

---$ Create Index/PK: PK_TRI_CHEM_REACTNT_SUBCATG, Table : dbo.TRI_CHEM_REACTNT_SUBCATG
IF OBJECT_ID(N'dbo.PK_TRI_CHEM_REACTNT_SUBCATG') IS NULL
    ALTER TABLE dbo.TRI_CHEM_REACTNT_SUBCATG
        ADD CONSTRAINT PK_TRI_CHEM_REACTNT_SUBCATG PRIMARY KEY CLUSTERED(PK_GUID)
GO

---$ Create FK : FK_CHEM_ANCLRY_USAGE_SUBCATG_CODE_REPORT
IF OBJECT_ID(N'dbo.FK_CHEM_ANCLRY_USAGE_SUBCATG_CODE_REPORT') IS NULL
BEGIN
    ALTER TABLE dbo.TRI_CHEM_ANCLRY_USAGE_SUBCATG
        ADD CONSTRAINT FK_CHEM_ANCLRY_USAGE_SUBCATG_CODE_REPORT
            FOREIGN KEY(FK_GUID)
                REFERENCES dbo.TRI_REPORT(PK_GUID)
                    ON DELETE CASCADE
                    ON UPDATE NO ACTION
END
GO

---$ Create FK : FK_CHEM_FRMLN_CMPNT_SUBCATG_CODE_REPORT
IF OBJECT_ID(N'dbo.FK_CHEM_FRMLN_CMPNT_SUBCATG_CODE_REPORT') IS NULL
BEGIN
    ALTER TABLE dbo.TRI_CHEM_FRMLN_CMPNT_SUBCATG
        ADD CONSTRAINT FK_CHEM_FRMLN_CMPNT_SUBCATG_CODE_REPORT
            FOREIGN KEY(FK_GUID)
                REFERENCES dbo.TRI_REPORT(PK_GUID)
                    ON DELETE CASCADE
                    ON UPDATE NO ACTION
END
GO

---$ Create FK : FK_CHEM_MFG_AID_SUBCATG_CODE_REPORT
IF OBJECT_ID(N'dbo.FK_CHEM_MFG_AID_SUBCATG_CODE_REPORT') IS NULL
BEGIN
    ALTER TABLE dbo.TRI_CHEM_MFG_AID_SUBCATG
        ADD CONSTRAINT FK_CHEM_MFG_AID_SUBCATG_CODE_REPORT
            FOREIGN KEY(FK_GUID)
                REFERENCES dbo.TRI_REPORT(PK_GUID)
                    ON DELETE CASCADE
                    ON UPDATE NO ACTION
END
GO

---$ Create FK : FK_CHEM_PRCSS_AID_SUBCATG_CODE_REPORT
IF OBJECT_ID(N'dbo.FK_CHEM_PRCSS_AID_SUBCATG_CODE_REPORT') IS NULL
BEGIN
    ALTER TABLE dbo.TRI_CHEM_PRCSS_AID_SUBCATG
        ADD CONSTRAINT FK_CHEM_PRCSS_AID_SUBCATG_CODE_REPORT
            FOREIGN KEY(FK_GUID)
                REFERENCES dbo.TRI_REPORT(PK_GUID)
                    ON DELETE CASCADE
                    ON UPDATE NO ACTION
END
GO

---$ Create FK : FK_CHEM_REACTNT_SUBCATG_CODE_REPORT
IF OBJECT_ID(N'dbo.FK_CHEM_REACTNT_SUBCATG_CODE_REPORT') IS NULL
BEGIN
    ALTER TABLE dbo.TRI_CHEM_REACTNT_SUBCATG
        ADD CONSTRAINT FK_CHEM_REACTNT_SUBCATG_CODE_REPORT
            FOREIGN KEY(FK_GUID)
                REFERENCES dbo.TRI_REPORT(PK_GUID)
                    ON DELETE CASCADE
                    ON UPDATE NO ACTION
END
GO

