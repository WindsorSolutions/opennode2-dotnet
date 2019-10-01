------------------------------------------------------------------------------
--
-- This script will update an existing OpenNode2 BEACHES dataflow v2.2 to v2.4
--
-- Date     Description
-- -------- --------------------------------
-- 20190925 Created
--
------------------------------------------------------------------------------

ALTER TABLE dbo.NOTIF_BEACH
    ALTER COLUMN BEACHTIERRANKING CHAR(1) NULL
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.NOTIF_BEACH') AND NAME = 'SWIMSEASONDAYMEASURE')
BEGIN
    ALTER TABLE dbo.NOTIF_BEACH
        ADD SWIMSEASONDAYMEASURE DECIMAL(16,6) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.NOTIF_BEACH') AND NAME = 'ADVREPORTINGFREQUENCYMEASURE')
BEGIN
    ALTER TABLE dbo.NOTIF_BEACH
        ADD ADVREPORTINGFREQUENCYMEASURE DECIMAL(16,6) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.NOTIF_BEACH') AND NAME = 'ADVREPORTINGFREQUNITOFMEASURE')
BEGIN
    ALTER TABLE dbo.NOTIF_BEACH
        ADD ADVREPORTINGFREQUNITOFMEASURE VARCHAR(9) NULL
END
GO


---$ Alter table dbo.NOTIF_BEACHACTIVITY
ALTER TABLE dbo.NOTIF_BEACHACTIVITY
    ALTER COLUMN ACTUALSTOPDATE VARCHAR(25) NOT NULL
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.NOTIF_BEACHACTIVITY') AND NAME = 'ACTIVITYPARTIALDAYAMOUNT')
BEGIN
    ALTER TABLE dbo.NOTIF_BEACHACTIVITY
        ADD ACTIVITYPARTIALDAYAMOUNT DECIMAL(16,6) NULL
END
GO


---$ Create table dbo.NOTIF_BEACHACTIVITYDELETE
IF OBJECT_ID(N'dbo.NOTIF_BEACHACTIVITYDELETE') IS NULL
BEGIN
    CREATE TABLE dbo.NOTIF_BEACHACTIVITYDELETE
    (
        [ID] VARCHAR(40) NOT NULL,
        BEACH_ID VARCHAR(40) NOT NULL,
        ACTIVITYCODENUMBER DECIMAL(16,6) NOT NULL
    )
    END
GO


---$ Alter table dbo.NOTIF_BEACHCRITERION
ALTER TABLE dbo.NOTIF_BEACHCRITERION
    ALTER COLUMN MEASURETYPENAME VARCHAR(5) NOT NULL
GO


---$ Alter table dbo.NOTIF_PROCEDURE
ALTER TABLE dbo.NOTIF_PROCEDURE
    ALTER COLUMN PROCEDUREIDENTIFIER VARCHAR(12) NOT NULL
GO


---$ Create Index/PK: FK_NOT_BCHACT002, Table : dbo.NOTIF_BEACHACTIVITYDELETE
IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE OBJECT_ID = OBJECT_ID(N'dbo.NOTIF_BEACHACTIVITYDELETE') AND NAME = 'FK_NOT_BCHACT002')
    CREATE  NONCLUSTERED  INDEX FK_NOT_BCHACT002
        ON dbo.NOTIF_BEACHACTIVITYDELETE(BEACH_ID)
        WITH(IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = NONE)
GO

---$ Create Index/PK: PK_NOT_BCHACTDEL, Table : dbo.NOTIF_BEACHACTIVITYDELETE
IF OBJECT_ID(N'dbo.PK_NOT_BCHACTDEL') IS NULL
    ALTER TABLE dbo.NOTIF_BEACHACTIVITYDELETE
        ADD CONSTRAINT PK_NOT_BCHACTDEL PRIMARY KEY CLUSTERED(ID)
GO

