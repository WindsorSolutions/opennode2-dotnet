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

/* 
 Oracle
 This script updates an existing RCRA v5.2 staging database to v5.4 
 Created 2/4/2016
 Last Updated: 4/11/2016
*/

/* Added element: NonNotifierIndicatorText - this element is used for publishing */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (NON_NOTIFIER_TEXT VARCHAR2(255))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'NON_NOTIFIER_TEXT';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NON_NOTIFIER_TEXT was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NON_NOTIFIER_TEXT was successfully added');
       
    END;
    
END;
/
/* Added element: AccessibilityCodeText - this element is used for publishing */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (ACCESSIBILITY_TEXT VARCHAR2(255))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'ACCESSIBILITY_TEXT';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.ACCESSIBILITY_TEXT was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.ACCESSIBILITY_TEXT was successfully added');
       
    END;
    
END;
/
/* Added element: LocationAddressNumberText - this element is used for publishing */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (LOCATION_STREET_NUMBER VARCHAR2(12))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'LOCATION_STREET_NUMBER';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.LOCATION_STREET_NUMBER was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.LOCATION_STREET_NUMBER was successfully added');
       
    END;
    
END;
/
/* Added element: MailingAddressNumberText - this is to sync up abilities between direct data entry and xml translation */ 
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (MAIL_STREET_NUMBER VARCHAR2(12))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'MAIL_STREET_NUMBER';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.MAIL_STREET_NUMBER was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.MAIL_STREET_NUMBER was successfully added');
       
    END;
    
END;
/
/* Added element: StateDistrictCodeText - this element is used for publishing */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (STATE_DISTRICT_TEXT VARCHAR2(255))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'STATE_DISTRICT_TEXT';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.STATE_DISTRICT_TEXT was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.STATE_DISTRICT_TEXT was successfully added');
       
    END;
    
END;
/
/* Added element: LandBasedUnitIndicatorText - this element is used for publishing */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY ADD (LAND_BASED_UNIT_IND_TEXT VARCHAR2(255))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_SEC_MATERIAL_ACTIVITY'
      AND column_name = 'LAND_BASED_UNIT_IND_TEXT';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_SEC_MATERIAL_ACTIVITY.LAND_BASED_UNIT_IND_TEXT was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_SEC_MATERIAL_ACTIVITY.LAND_BASED_UNIT_IND_TEXT was successfully added');
       
    END;
    
END;
/
/* Increased length of field for OwnerOperatorSupplementalInformationText from 240 to 2000 */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_OWNEROP'
      AND column_name = 'NOTES'
      AND data_type = 'VARCHAR2'
      AND data_length <> 2000;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_OWNEROP MODIFY NOTES VARCHAR2(2000)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.NOTES was successfully modified to VARCHAR2(2000).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.NOTES was already VARCHAR2(2000), schema alteration bypassed!');
       
    END;
    
END;
/
/* Increased length of field EnvironmentalPermitDescription from 20 to 80 */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_ENV_PERMIT'
      AND column_name = 'ENV_PERMIT_DESC'
      AND data_type = 'VARCHAR2'
      AND data_length <> 80;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_ENV_PERMIT MODIFY ENV_PERMIT_DESC VARCHAR2(80)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_ENV_PERMIT.ENV_PERMIT_DESC was successfully modified to VARCHAR2(80).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_ENV_PERMIT.ENV_PERMIT_DESC was already VARCHAR2(80), schema alteration bypassed!');
       
    END;
    
END;
/
/* Added new element RecyclingIndicator in support of new DSW regulation */
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (RECYCLING_IND CHAR(1))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'RECYCLING_IND';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.RECYCLING_IND was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.RECYCLING_IND was successfully added');
       
    END;
    
END;
/
/* Oracle
 This script updates an existing RCRA v5.3 staging database to v5.4
 Created 3/17/2016
*/

--RCRA_FacilityOwnerOperator_v5.4
--Increased length of element OwnerOperatorSupplementalInformationText to 4000

DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_OWNEROP'
      AND column_name = 'NOTES'
      AND data_type = 'VARCHAR2'
      AND data_length <> 4000;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_OWNEROP MODIFY NOTES VARCHAR2(4000)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.NOTES was successfully modified to VARCHAR2(4000).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.NOTES was already VARCHAR2(4000), schema alteration bypassed!');
       
    END;
    
END;
/
--Increased length of element HandlerSupplementalInformationText to 4000 (undocumented change)
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'NOTES'
      AND data_type = 'VARCHAR2'
      AND data_length <> 4000;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY NOTES VARCHAR2(4000)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NOTES was successfully modified to VARCHAR2(4000).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NOTES was already VARCHAR2(4000), schema alteration bypassed!');
       
    END;
    
END;
/
--RCRA_LocationAddress_v5.4.xsd
--Increase length of element LocationAddressText to 50

DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'LOCATION_STREET1'
      AND data_type = 'VARCHAR2'
      AND data_length <> 50;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY LOCATION_STREET1 VARCHAR2(50)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.LOCATION_STREET1 was successfully modified to VARCHAR2(50).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.LOCATION_STREET1 was already VARCHAR2(50), schema alteration bypassed!');
       
    END;
    
END;
/
--Increase length of element SupplementalLocationText to 50
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'LOCATION_STREET2'
      AND data_type = 'VARCHAR2'
      AND data_length <> 50;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY LOCATION_STREET2 VARCHAR2(50)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.LOCATION_STREET2 was successfully modified to VARCHAR2(50).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.LOCATION_STREET2 was already VARCHAR2(50), schema alteration bypassed!');
       
    END;
    
END;
/
--RCRA_MailingAddress_v5.4.xsd
--Increase length of element MailingAddressText to 50
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'MAIL_STREET1'
      AND data_type = 'VARCHAR2'
      AND data_length <> 50;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY MAIL_STREET1 VARCHAR2(50)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.MAIL_STREET1 was successfully modified to VARCHAR2(50).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.MAIL_STREET1 was already VARCHAR2(50), schema alteration bypassed!');
       
    END;
    
END;
/
--Increase length of element SupplementalAddressText to 50
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'MAIL_STREET2'
      AND data_type = 'VARCHAR2'
      AND data_length <> 50;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY MAIL_STREET2 VARCHAR2(50)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.MAIL_STREET2 was successfully modified to VARCHAR2(50).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.MAIL_STREET2 was already VARCHAR2(50), schema alteration bypassed!');
       
    END;
    
END;
/
--RCRA_Shared_v5.4.xsd
--Increase length of element FirstName to 38
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'CONTACT_FIRST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY CONTACT_FIRST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.CONTACT_FIRST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.CONTACT_FIRST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'PCONTACT_FIRST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY PCONTACT_FIRST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.PCONTACT_FIRST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.PCONTACT_FIRST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_CERTIFICATION'
      AND column_name = 'CERT_FIRST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_CERTIFICATION MODIFY CERT_FIRST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_CERTIFICATION.CERT_FIRST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_CERTIFICATION.CERT_FIRST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_OWNEROP'
      AND column_name = 'FIRST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_OWNEROP MODIFY FIRST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.FIRST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.FIRST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
--Increase length of element LastName to 38
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'CONTACT_LAST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY CONTACT_LAST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.CONTACT_LAST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.CONTACT_LAST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'PCONTACT_LAST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY PCONTACT_LAST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.PCONTACT_LAST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.PCONTACT_LAST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_CERTIFICATION'
      AND column_name = 'CERT_LAST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_CERTIFICATION MODIFY CERT_LAST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_CERTIFICATION.CERT_LAST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_CERTIFICATION.CERT_LAST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_OWNEROP'
      AND column_name = 'LAST_NAME'
      AND data_type = 'VARCHAR2'
      AND data_length <> 38;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_OWNEROP MODIFY LAST_NAME VARCHAR2(38)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.LAST_NAME was successfully modified to VARCHAR2(38).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OWNEROP.LAST_NAME was already VARCHAR2(38), schema alteration bypassed!');
       
    END;
    
END;
/
--RCRA_Handler_v5.4.xsd
--Added optional element: HandlerInternalSupplementalInformationText to capture internal notes
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000) := 'ALTER TABLE RCRA_HD_HANDLER ADD (INTRNL_NOTES VARCHAR2(4000))';

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'INTRNL_NOTES';
      
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.INTRNL_NOTES was already added, schema alteration bypassed!');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      EXECUTE IMMEDIATE v_sql_statement;
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.INTRNL_NOTES was successfully added');
       
    END;
    
END;
/
--RCRA_OtherID_v5.4
--Increased length of element OtherIDSupplementalInformationText to 4000

DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_OTHER_ID'
      AND column_name = 'NOTES'
      AND data_type = 'VARCHAR2'
      AND data_length <> 4000;
      
      v_sql_statement := 'ALTER TABLE RCRA_HD_OTHER_ID MODIFY NOTES VARCHAR2(4000)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OTHER_ID.NOTES was successfully modified to VARCHAR2(4000).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_OTHER_ID.NOTES was already VARCHAR2(4000), schema alteration bypassed!');
       
    END;
    
END;
/
--Other Fixes to staging tables unrelated to EPA schema change
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'SHORT_TERM_GEN_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET SHORT_TERM_GEN_IND = SUBSTR(SHORT_TERM_GEN_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY SHORT_TERM_GEN_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.SHORT_TERM_GEN_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.SHORT_TERM_GEN_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'TRANSFER_FACILITY_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET TRANSFER_FACILITY_IND = SUBSTR(TRANSFER_FACILITY_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY TRANSFER_FACILITY_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.TRANSFER_FACILITY_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.TRANSFER_FACILITY_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'COLLEGE_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET COLLEGE_IND = SUBSTR(COLLEGE_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY COLLEGE_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.COLLEGE_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.COLLEGE_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'HOSPITAL_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET HOSPITAL_IND = SUBSTR(HOSPITAL_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY HOSPITAL_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.HOSPITAL_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.HOSPITAL_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'NON_PROFIT_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET NON_PROFIT_IND = SUBSTR(NON_PROFIT_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY NON_PROFIT_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NON_PROFIT_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NON_PROFIT_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'WITHDRAWAL_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET WITHDRAWAL_IND = SUBSTR(WITHDRAWAL_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY WITHDRAWAL_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.WITHDRAWAL_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.WITHDRAWAL_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'TRANS_CODE'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET TRANS_CODE = SUBSTR(TRANS_CODE, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY TRANS_CODE CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.TRANS_CODE was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.TRANS_CODE was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'NOTIFICATION_RSN_CODE'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET NOTIFICATION_RSN_CODE = SUBSTR(NOTIFICATION_RSN_CODE, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY NOTIFICATION_RSN_CODE CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NOTIFICATION_RSN_CODE was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.NOTIFICATION_RSN_CODE was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_HD_HANDLER'
      AND column_name = 'FINANCIAL_ASSURANCE_IND'
      AND data_type = 'VARCHAR2';
      
      v_sql_statement := 'UPDATE RCRA_HD_HANDLER SET FINANCIAL_ASSURANCE_IND = SUBSTR(FINANCIAL_ASSURANCE_IND, 1, 1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      v_sql_statement := 'ALTER TABLE RCRA_HD_HANDLER MODIFY FINANCIAL_ASSURANCE_IND CHAR(1)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.FINANCIAL_ASSURANCE_IND was successfully modified to CHAR(1).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_HD_HANDLER.FINANCIAL_ASSURANCE_IND was already CHAR(1), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_GIS_GEO_INFORMATION'
      AND column_name = 'AREA_ACREAGE_MEAS'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_GIS_GEO_INFORMATION MODIFY AREA_ACREAGE_MEAS NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_GIS_GEO_INFORMATION.RCRA_GIS_GEO_INFORMATION was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_GIS_GEO_INFORMATION.RCRA_GIS_GEO_INFORMATION was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_FA_COST_EST'
      AND column_name = 'COST_ESTIMATE_AMOUNT'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_FA_COST_EST MODIFY COST_ESTIMATE_AMOUNT NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_FA_COST_EST.COST_ESTIMATE_AMOUNT was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_FA_COST_EST.COST_ESTIMATE_AMOUNT was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_CME_PNLTY'
      AND column_name = 'CASH_CIVIL_PNLTY_SOUGHT_AMOUNT'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_CME_PNLTY MODIFY CASH_CIVIL_PNLTY_SOUGHT_AMOUNT NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_PNLTY.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_PNLTY.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;   
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_FA_MECHANISM_DETAIL'
      AND column_name = 'FACE_VAL_AMOUNT'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_FA_MECHANISM_DETAIL MODIFY FACE_VAL_AMOUNT NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_FA_MECHANISM_DETAIL.FACE_VAL_AMOUNT was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_FA_MECHANISM_DETAIL.FACE_VAL_AMOUNT was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;   
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_CME_SUPP_ENVR_PRJT'
      AND column_name = 'SEP_EXPND_AMOUNT'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT MODIFY SEP_EXPND_AMOUNT NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_SUPP_ENVR_PRJT.SEP_EXPND_AMOUNT was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_SUPP_ENVR_PRJT.SEP_EXPND_AMOUNT was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;   
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_CME_PYMT'
      AND column_name = 'SCHD_PYMT_AMOUNT'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_CME_PYMT MODIFY SCHD_PYMT_AMOUNT NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_PYMT.SCHD_PYMT_AMOUNT was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_PYMT.SCHD_PYMT_AMOUNT was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;   
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_CME_PYMT'
      AND column_name = 'ACTL_PAID_AMOUNT'
      AND data_type = 'NUMBER'
      AND data_precision = '14';
      
      v_sql_statement := 'ALTER TABLE RCRA_CME_PYMT MODIFY ACTL_PAID_AMOUNT NUMBER(13, 2)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_PYMT.ACTL_PAID_AMOUNT was successfully modified to NUMBER(13, 2).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_CME_PYMT.ACTL_PAID_AMOUNT was already NUMBER(13, 2), schema alteration bypassed!');

    END;
    
END;   
/
DECLARE

  v_object_ind NUMBER(01) := 0;
  v_sql_statement VARCHAR2(4000);

BEGIN 

   SELECT 1
     INTO v_object_ind
     FROM all_tab_columns
    WHERE table_name = 'RCRA_PRM_UNIT_DETAIL'
      AND column_name = 'PERMIT_UNIT_CAP_QNTY'
      AND data_type = 'NUMBER'
      AND data_precision = '14'
      AND data_scale = '6';
      
      v_sql_statement := 'ALTER TABLE RCRA_PRM_UNIT_DETAIL MODIFY PERMIT_UNIT_CAP_QNTY NUMBER(14, 3)';
      EXECUTE IMMEDIATE v_sql_statement;   
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_CAP_QNTY was successfully modified to NUMBER(14, 3).');
   
EXCEPTION

  WHEN NO_DATA_FOUND THEN  
  
    BEGIN
       
      DBMS_OUTPUT.PUT_LINE( 'The column RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_CAP_QNTY was already NUMBER(14, 3), schema alteration bypassed!');

    END;
    
END;  