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
 *  Script Name:  RCRA_5.9_to_5.10-upgrade_ORA-DDL.sql
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

--  Alter Table:  RCRA_HD_EPISODIC_EVENT
ALTER TABLE RCRA_HD_EPISODIC_EVENT MODIFY EVENT_TYPE CHAR(1);
ALTER TABLE RCRA_HD_EPISODIC_EVENT DROP COLUMN EVENT_OTHER_DESC;



--  Alter Table:  RCRA_HD_HANDLER
ALTER TABLE RCRA_HD_HANDLER ADD LOCATION_LATITUDE DECIMAL(19,14) NULL;
ALTER TABLE RCRA_HD_HANDLER ADD LOCATION_LONGITUDE DECIMAL(19,14) NULL;
ALTER TABLE RCRA_HD_HANDLER ADD LOCATION_GIS_PRIM CHAR(1) NULL;
ALTER TABLE RCRA_HD_HANDLER ADD LOCATION_GIS_ORIG CHAR(2) NULL;


--  Alter Table:  RCRA_RU_REPORT_UNIV
ALTER TABLE RCRA_RU_REPORT_UNIV ADD LOCATION_LATITUDE DECIMAL(19,14) NULL;
ALTER TABLE RCRA_RU_REPORT_UNIV ADD LOCATION_LONGITUDE DECIMAL(19,14) NULL;
ALTER TABLE RCRA_RU_REPORT_UNIV ADD LOCATION_GIS_PRIM CHAR(1) NULL;
ALTER TABLE RCRA_RU_REPORT_UNIV ADD LOCATION_GIS_ORIG CHAR(2) NULL;



--  Alter Table:  RCRA_RU_REPORT_UNIV
CREATE TABLE RCRA_HD_EPISODIC_PRJT
    (
        HD_EPISODIC_PRJT_ID VARCHAR2(40) NOT NULL,
        HD_EPISODIC_EVENT_ID VARCHAR2(40) NOT NULL,
        TRANSACTION_CODE CHAR(1) NULL,
        PRJT_CODE_OWNER CHAR(2) NOT NULL,
        PRJT_CODE CHAR(3) NOT NULL,
        OTHER_PRJT_DESC VARCHAR2(255) NULL
    );
CREATE INDEX IX_HD_EPIS_PRJT_HD_EPIS_EVE_ID ON RCRA_HD_EPISODIC_PRJT(HD_EPISODIC_EVENT_ID);


--  Alter Table:  RCRA_HD_EPISODIC_PRJT, add Primary Key
ALTER TABLE RCRA_HD_EPISODIC_PRJT ADD CONSTRAINT PK_HD_EPISODIC_PRJT PRIMARY KEY (HD_EPISODIC_PRJT_ID);


--  Alter Table:  RCRA_HD_EPISODIC_PRJT, add Foreign Key
ALTER TABLE RCRA_HD_EPISODIC_PRJT ADD CONSTRAINT FK_HD_EPISO_PRJT_HD_EPISO_EVEN
FOREIGN KEY(HD_EPISODIC_EVENT_ID) REFERENCES RCRA_HD_EPISODIC_EVENT(HD_EPISODIC_EVENT_ID)
ON DELETE CASCADE;