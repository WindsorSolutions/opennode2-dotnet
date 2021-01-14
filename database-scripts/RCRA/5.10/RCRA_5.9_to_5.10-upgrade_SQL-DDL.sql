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
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE goODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/

/*****************************************************************************************************************************
 *
 *  Script Name:  RCRA_5.9_to_5.10-upgrade_SQL-DDL.sql
 *
 *  Company:  Windsor Solutions, Inc.
 *
 *  Purpose:  This script will upgrade RCRA 5.9 schema to support RCRA 5.10.
 *
 *  Maintenance:
 *
 *    Analyst         Date            Comment
 *    ----------      ----------      ------------------------------------------------------------------------------
 *    Windsor         1/14/2021      Created
 *
 ****************************************************************************************************************************
 */
---$ Alter table dbo.RCRA_HD_EPISODIC_EVENT
IF EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_HD_EPISODIC_EVENT') AND NAME = 'EVENT_OTHER_DESC')
BEGIN
    ALTER TABLE dbo.RCRA_HD_EPISODIC_EVENT
        DROP COLUMN EVENT_OTHER_DESC
END
GO


---$ Alter table dbo.RCRA_HD_HANDLER
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_HD_HANDLER') AND NAME = 'LOCATION_LATITUDE')
BEGIN
    ALTER TABLE dbo.RCRA_HD_HANDLER
        ADD LOCATION_LATITUDE DECIMAL(19,14) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_HD_HANDLER') AND NAME = 'LOCATION_LONGITUDE')
BEGIN
    ALTER TABLE dbo.RCRA_HD_HANDLER
        ADD LOCATION_LONGITUDE DECIMAL(19,14) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_HD_HANDLER') AND NAME = 'LOCATION_GIS_PRIM')
BEGIN
    ALTER TABLE dbo.RCRA_HD_HANDLER
        ADD LOCATION_GIS_PRIM CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_HD_HANDLER') AND NAME = 'LOCATION_GIS_ORIG')
BEGIN
    ALTER TABLE dbo.RCRA_HD_HANDLER
        ADD LOCATION_GIS_ORIG CHAR(2) NULL
END
GO


---$ Alter table dbo.RCRA_RU_REPORT_UNIV
IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_RU_REPORT_UNIV') AND NAME = 'LOCATION_LATITUDE')
BEGIN
    ALTER TABLE dbo.RCRA_RU_REPORT_UNIV
        ADD LOCATION_LATITUDE DECIMAL(19,14) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_RU_REPORT_UNIV') AND NAME = 'LOCATION_LONGITUDE')
BEGIN
    ALTER TABLE dbo.RCRA_RU_REPORT_UNIV
        ADD LOCATION_LONGITUDE DECIMAL(19,14) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_RU_REPORT_UNIV') AND NAME = 'LOCATION_GIS_PRIM')
BEGIN
    ALTER TABLE dbo.RCRA_RU_REPORT_UNIV
        ADD LOCATION_GIS_PRIM CHAR(1) NULL
END
GO

IF NOT EXISTS(SELECT * FROM SYS.COLUMNS WHERE OBJECT_ID = OBJECT_ID(N'dbo.RCRA_RU_REPORT_UNIV') AND NAME = 'LOCATION_GIS_ORIG')
BEGIN
    ALTER TABLE dbo.RCRA_RU_REPORT_UNIV
        ADD LOCATION_GIS_ORIG CHAR(2) NULL
END
GO


---$ Create table dbo.RCRA_HD_EPISODIC_PRJT
IF OBJECT_ID(N'dbo.RCRA_HD_EPISODIC_PRJT') IS NULL
BEGIN
    CREATE TABLE dbo.RCRA_HD_EPISODIC_PRJT
    (
        HD_EPISODIC_PRJT_ID VARCHAR(40) NOT NULL,
        HD_EPISODIC_EVENT_ID VARCHAR(40) NOT NULL,
        TRANSACTION_CODE CHAR(1) NULL,
        PRJT_CODE_OWNER CHAR(2) NOT NULL,
        PRJT_CODE CHAR(3) NOT NULL,
        OTHER_PRJT_DESC VARCHAR(80) NULL
    )
    END
GO

