/* SQL Server */

/* This script updates an existing BEACHES v2.1 staging database to work with the v2.2 schema for the .NET OpenNode2 */

/* 4/10/2012 BRensmith Created */

ALTER TABLE dbo.NOTIF_BEACH
    ADD BEACHDORMANTINDICATOR VARCHAR(5) NULL
GO

ALTER TABLE dbo.NOTIF_BEACH
    ADD BEACHWEBSITE VARCHAR(255) NULL
GO

ALTER TABLE dbo.NOTIF_BEACH
    ADD REPORTINGFREQUENCYMEASURE DECIMAL(16,6) NULL
GO

ALTER TABLE dbo.NOTIF_BEACH
    ADD REPORTINGFREQUNITOFMEASURE VARCHAR(9) NULL
GO

ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN BEACHNAME VARCHAR(60) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN BEACHDESCRIPTION VARCHAR(255) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN BEACHSTATECODE CHAR(2) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN BEACHFIPSCOUNTYCODE VARCHAR(5) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN BEACHACCESSTYPE VARCHAR(12) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN EXTENTLENGTHMEASURE DECIMAL(16,6) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN SWIMSEASONLENGTH DECIMAL(16,6) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN SWIMSEASONFREQUENCYMEASURE DECIMAL(16,6) NULL --Changed Datatype
GO
ALTER TABLE dbo.NOTIF_BEACH ALTER COLUMN OFFSEASONFREQUENCYMEASURE DECIMAL(16,6) NULL --Changed Datatype
GO

ALTER TABLE dbo.NOTIF_PERSON ALTER COLUMN FIRSTNAME VARCHAR(50) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_PERSON ALTER COLUMN LASTNAME  VARCHAR(50) NULL --Nullable
GO
ALTER TABLE dbo.NOTIF_PERSON ALTER COLUMN PERSONSTATUS VARCHAR(8) NULL --Nullable
GO

ALTER TABLE dbo.NOTIF_BEACHACTIVITY ALTER COLUMN EXTENTSTARTMEASURE DECIMAL(16,6) NULL --Changed Datatype
GO 
ALTER TABLE dbo.NOTIF_BEACHACTIVITY ALTER COLUMN EXTENTLENGTHMEASURE DECIMAL(16,6) NULL --Changed Datatype
GO

CREATE TABLE NOTIF_BEACHCRITERION (
    [ID] VARCHAR(40) NOT NULL,
    BEACH_ID VARCHAR(40) NOT NULL,
    INDICATORNAME VARCHAR(12) NOT NULL,
    WATERTYPENAME VARCHAR(12) NOT NULL,
    CRITERIONCOMMENT VARCHAR(255) NULL,
    MEASURETYPENAME VARCHAR(12) NOT NULL,
    MEASUREVALUE DECIMAL(16,6) NOT NULL,
    MEASUREUNITCODE VARCHAR(12) NOT NULL
    )
GO

CREATE TABLE NOTIF_STATECONTACT (
    [ID] VARCHAR(40) NOT NULL,
    ORGANIZATION_ID VARCHAR(40) NOT NULL,
    AGENCYNAME VARCHAR(60) NOT NULL,
    TELEPHONENUMBER VARCHAR(12) NOT NULL,
    ELECTRONICADDR VARCHAR(255) NOT NULL,
    FIRSTNAME VARCHAR(50) NOT NULL,
    LASTNAME VARCHAR(50) NOT NULL
	)

GO

ALTER TABLE NOTIF_BEACHCRITERION
    ADD CONSTRAINT PK_NOT_BCH_CRI PRIMARY KEY ([ID])
GO

ALTER TABLE NOTIF_STATECONTACT
    ADD CONSTRAINT PK_NOT_STCNTCT PRIMARY KEY ([ID])
GO

ALTER TABLE NOTIF_BEACHCRITERION
	ADD CONSTRAINT FK_NOT_BCH_CRI
    FOREIGN KEY(BEACH_ID)
    REFERENCES NOTIF_BEACH(ID)
	ON DELETE CASCADE
	ON UPDATE NO ACTION
GO

ALTER TABLE NOTIF_STATECONTACT
	ADD CONSTRAINT FK_NOT_STCNTCT
    FOREIGN KEY(ORGANIZATION_ID)
    REFERENCES NOTIF_ORGANIZATION(ID)
    ON DELETE CASCADE
    ON UPDATE NO ACTION
GO