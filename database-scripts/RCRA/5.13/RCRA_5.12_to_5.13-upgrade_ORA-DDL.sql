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
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/

/*****************************************************************************************************************************
 *
 *  Script Name:  RCRA_5.12_to_5.13-upgrade_ORA-DDL.sql
 *
 *  Company:  Windsor Solutions, Inc.
 *
 *  Purpose:  This DDL script will alter the Oracle database objects supporting the RCRA v5.12 data flow to conform with
 *            the RCRA v5.13 schema.
 *
 *  Maintenance:
 *
 *    Analyst         Date            Comment
 *    ----------      ----------      ------------------------------------------------------------------------------
 *    Windsor         03/20/2024      Created
 *
 ****************************************************************************************************************************
 */

DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_EPISODIC_EVENT' AND COLUMN_NAME = 'CONTACT_LANG_CODE';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_EPISODIC_EVENT ADD CONTACT_LANG_CODE CHAR(2)';
    END IF;
    
END;
/



DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_EPISODIC_EVENT' AND COLUMN_NAME = 'CONTACT_LANG_DESC';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_EPISODIC_EVENT ADD CONTACT_LANG_DESC VARCHAR(50) NULL';
    END IF;
    
END;
/





DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_HANDLER' AND COLUMN_NAME = 'CONTACT_LANG_CODE';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_HANDLER ADD CONTACT_LANG_CODE CHAR(2) NULL';
    END IF;
    
END;
/


DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_HANDLER' AND COLUMN_NAME = 'CONTACT_LANG_DESC';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_HANDLER ADD CONTACT_LANG_DESC VARCHAR(50) NULL';
    END IF;
    
END;
/



DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_HANDLER' AND COLUMN_NAME = 'PCONTACT_LANG_CODE';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_HANDLER ADD PCONTACT_LANG_CODE CHAR(2) NULL';
    END IF;
    
END;
/


DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_HANDLER' AND COLUMN_NAME = 'PCONTACT_LANG_DESC';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_HANDLER ADD PCONTACT_LANG_DESC VARCHAR(50) NULL';
    END IF;
    
END;
/


DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_LQG_CONSOLIDATION' AND COLUMN_NAME = 'CONTACT_LANG_CODE';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_LQG_CONSOLIDATION ADD CONTACT_LANG_CODE CHAR(2) NULL';
    END IF;
    
END;
/

DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_LQG_CONSOLIDATION' AND COLUMN_NAME = 'CONTACT_LANG_DESC';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_LQG_CONSOLIDATION ADD CONTACT_LANG_DESC VARCHAR(50) NULL';
    END IF;
    
END;
/



DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_OWNEROP' AND COLUMN_NAME = 'LANG_CODE';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_OWNEROP ADD LANG_CODE CHAR(2) NULL';
    END IF;
    
END;
/


DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_HD_OWNEROP' AND COLUMN_NAME = 'LANG_DESC';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_OWNEROP ADD LANG_DESC VARCHAR(50) NULL';
    END IF;
    
END;
/



DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_RU_REPORT_UNIV' AND COLUMN_NAME = 'CONTACT_LANG_CODE';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_RU_REPORT_UNIV ADD CONTACT_LANG_CODE CHAR(2) NULL';
    END IF;
    
END;
/


DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = 'RCRA_RU_REPORT_UNIV' AND COLUMN_NAME = 'CONTACT_LANG_DESC';
    
    IF v_count = 0 THEN
      EXECUTE IMMEDIATE 'ALTER TABLE RCRA_RU_REPORT_UNIV ADD CONTACT_LANG_DESC VARCHAR(50) NULL';
    END IF;
    
END;
/



DECLARE
    v_count NUMBER;
BEGIN
    SELECT COUNT(*) INTO v_count FROM user_tables WHERE table_name = 'RCRA_HD_ADD_CONTACT';
    
    IF v_count = 0 THEN
        EXECUTE IMMEDIATE 'CREATE TABLE RCRA_HD_ADD_CONTACT (
            HD_ADD_CONTACT_ID VARCHAR2(40) NOT NULL,
            HD_HANDLER_ID VARCHAR2(40) NOT NULL,
            TRANSACTION_CODE CHAR(1),
            ADD_CONTACT_SEQ NUMBER(10) NOT NULL,
            CONTACT_TYPE CHAR(2),
            CONTACT_TYPE_OWNER CHAR(2),
            CONTACT_FIRST_NAME VARCHAR2(38),
            CONTACT_MIDDLE_INITIAL CHAR(1),
            CONTACT_LAST_NAME VARCHAR2(38),
            CONTACT_STREET_NUMBER VARCHAR2(12),
            CONTACT_STREET_1 VARCHAR2(50),
            CONTACT_STREET_2 VARCHAR2(50),
            CONTACT_CITY VARCHAR2(25),
            CONTACT_STATE CHAR(2),
            CONTACT_ZIP VARCHAR2(14),
            CONTACT_COUNTRY CHAR(2),
            CONTACT_PHONE VARCHAR2(15),
            CONTACT_PHONE_EXT VARCHAR2(6),
            CONTACT_FAX VARCHAR2(15),
            CONTACT_EMAIL VARCHAR2(80),
            CONTACT_TITLE VARCHAR2(45),
            CONTACT_LANG_CODE CHAR(2),
            CONTACT_LANG_DESC VARCHAR2(50)
        )';
    END IF;
END;
/


BEGIN
    EXECUTE IMMEDIATE 'CREATE INDEX IX_HD_ADD_CONTACT_HD_HANDLE_ID 
                        ON RCRA_HD_ADD_CONTACT(HD_HANDLER_ID)';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -955 THEN
            RAISE;
        END IF;
END;
/


DECLARE
    v_constraint_count NUMBER;
BEGIN
    SELECT COUNT(*)
    INTO v_constraint_count
    FROM user_constraints
    WHERE table_name = 'RCRA_HD_ADD_CONTACT'
    AND constraint_name = 'PK_HD_ADD_CONTACT'
    AND constraint_type = 'P';

    IF v_constraint_count = 0 THEN
        EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_ADD_CONTACT ADD CONSTRAINT PK_HD_ADD_CONTACT PRIMARY KEY (HD_ADD_CONTACT_ID)';
    END IF;
END;
/

DECLARE
    v_constraint_count NUMBER;
BEGIN
    SELECT COUNT(*)
    INTO v_constraint_count
    FROM user_constraints
    WHERE table_name = 'RCRA_HD_ADD_CONTACT'
    AND constraint_name = 'FK_HD_ADD_CONTACT_HD_HANDLER'
    AND constraint_type = 'R';

    IF v_constraint_count = 0 THEN
        EXECUTE IMMEDIATE 'ALTER TABLE RCRA_HD_ADD_CONTACT
                           ADD CONSTRAINT FK_HD_ADD_CONTACT_HD_HANDLER
                           FOREIGN KEY(HD_HANDLER_ID)
                           REFERENCES RCRA_HD_HANDLER(HD_HANDLER_ID)
                           ON DELETE CASCADE';
    END IF;
END;
/
