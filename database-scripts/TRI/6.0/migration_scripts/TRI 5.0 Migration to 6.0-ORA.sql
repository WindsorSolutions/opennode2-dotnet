/* ******************************
 *
 *   TRI_COMMENT
 *
 *********************************/
DECLARE

  v_object_ind NUMBER(01) := 0;
  
  v_create_table VARCHAR2(4000) := 'CREATE TABLE TRI_COMMENT(
                                      PK_GUID VARCHAR2(36) NOT NULL,
                                      FK_GUID VARCHAR2(36) NOT NULL,
                                      COMMENT_SEQ int NULL,
                                      COMMENT_SECTION VARCHAR2(50) NULL,
                                      COMMENT_TYPE_CODE VARCHAR2(50) NULL,
                                      COMMENT_TYPE_DESC VARCHAR2(255) NULL,
                                      COMMENT_TEXT VARCHAR2(4000) NULL,
                                      COMMENT_P2_CLASS VARCHAR2(100) NULL)';
                                                                         
BEGIN

  SELECT 1
    INTO v_object_ind
    FROM user_tables
   WHERE user_tables.table_name = 'TRI_COMMENT';
   
   /* The table already exists in schema, bypass creation */
   DBMS_OUTPUT.PUT_LINE( 'The table TRI_COMMENT already exists, schema alteration bypassed!');
  
EXCEPTION

  WHEN NO_DATA_FOUND THEN
  
    EXECUTE IMMEDIATE v_create_table;   
    
    DBMS_OUTPUT.PUT_LINE( 'The table TRI_COMMENT was created!');

END;
/

DECLARE                                                                                                                                                                                
                                                                                                                                                                                       
  v_object_ind NUMBER(01) := 0;                                                                                                                                                        
  v_drop_ddl                 VARCHAR2(4000);                                                                                                                                           
  v_ddl VARCHAR2(4000) :=                                                                                                                                                              
 ' ALTER TABLE "TRI_COMMENT"
    ADD ( CONSTRAINT "PK_TRI_COMMENT"
    PRIMARY KEY ("PK_GUID")
    NOT DEFERRABLE INITIALLY IMMEDIATE )
 ';                                                                                                                                                       
                                                                                                                                                                                       
BEGIN                                                                                                                                                                                  
                                                                                                                                                                                       
  /*                                                                                                                                                                                   
   * Check to see if the constraint already exists in the target database schema.                                                                                                           
   */                                                                                                                                                                                  
   SELECT 1                                                                                                                                                                            
     INTO v_object_ind                                                                                                                                                                 
     FROM user_constraints                                                                                                                                                                   
    WHERE user_constraints.constraint_name = 'PK_TRI_COMMENT';
                                                                                                                                                                                       
    /*                                                                                                                                                                                 
     *  constraint exists, bypass creation, but alert the calling process.                                                                                                                  
     */                                                                                                                                                                                
    DBMS_OUTPUT.PUT_LINE( 'The constraint PK_TRI_COMMENT already exists, constraint creation statement has been bypassed!');
                                                                                                                                                                                       
EXCEPTION                                                                                                                                                                              
  WHEN NO_DATA_FOUND THEN                                                                                                                                                              
                                                                                                                                                                                       
   /*                                                                                                                                                                                  
    *  constraint does not exist, execute the DDL statement to create the constraint in the target environment                                                                                   
    */                                                                                                                                                                                 
    DBMS_OUTPUT.PUT_LINE('The constraint PK_TRI_COMMENT was created!');                                               
    EXECUTE IMMEDIATE v_ddl;                                                                                                                                                           

END;                                                                                                                                                                                   
/
      
                                                              
DECLARE                                                                                                                                                                                
                                                                                                                                                                                       
  v_object_ind NUMBER(01) := 0;                                                                                                                                                        
  v_drop_ddl                 VARCHAR2(4000);                                                                                                                                           
  v_ddl VARCHAR2(4000) :=  ' ALTER TABLE "TRI_COMMENT"
                              ADD ( CONSTRAINT "FK_COMMENT_REP"
                              FOREIGN KEY ("FK_GUID")
                              REFERENCES "TRI_REPORT"("PK_GUID")
                              ON DELETE CASCADE )
                           ';                                                                                                                                                       
  
                                                                                                                                                                               
BEGIN                                                                                                                                                                                  
                                                                                                                                                                                       
  /*                                                                                                                                                                                   
   * Check to see if the constraint already exists in the target database schema.                                                                                                           
   */                                                                                                                                                                                  
   SELECT 1                                                                                                                                                                            
     INTO v_object_ind                                                                                                                                                                 
     FROM user_constraints                                                                                                                                                                   
    WHERE user_constraints.constraint_name = 'FK_COMMENT_REP';
                                                                                                                                                                                       
    /*                                                                                                                                                                                 
     *  constraint exists, bypass creation, but alert the calling process.                                                                                                                  
     */                                                                                                                                                                                
    DBMS_OUTPUT.PUT_LINE( 'The constraint FK_COMMENT_REP already exists, constraint creation statement has been bypassed!');
                                                                                                                                                                                       
EXCEPTION                                                                                                                                                                              
  WHEN NO_DATA_FOUND THEN                                                                                                                                                              
                                                                                                                                                                                       
   /*                                                                                                                                                                                  
    *  constraint does not exist, execute the DDL statement to create the constraint in the target environment                                                                                   
    */                                                                                                                                                                                 
    DBMS_OUTPUT.PUT_LINE('The constraint FK_COMMENT_REP was created!');                                               
    EXECUTE IMMEDIATE v_ddl;                                                                                                                                                           

END;                                                                                                                                                                                   
/   


DECLARE                                                                                                                                                                                
                                                                                                                                                                                       
  v_object_ind NUMBER(01) := 0;                                                                                                                                                        
  v_drop_ddl                 VARCHAR2(1000);                                                                                                                                           
  v_ddl VARCHAR2(4000) :=  ' CREATE INDEX IX_TRI_COMMENT_FK_GUID ON TRI_COMMENT(FK_GUID) ';                                                                                                                                                       
  
  
                                                                                                                                                                                       
BEGIN                                                                                                                                                                                  
                                                                                                                                                                                       
  /*                                                                                                                                                                                   
   * Check to see if the index already exists in the target database schema.                                                                                                           
   */                                                                                                                                                                                  
   SELECT 1                                                                                                                                                                            
     INTO v_object_ind                                                                                                                                                                 
     FROM user_indexes                                                                                                                                                                   
    WHERE user_indexes.index_name = 'IX_TRI_COMMENT_FK_GUID';
                                                                                                                                                                                       
    /*                                                                                                                                                                                 
     *  Index exists, bypass creation, but alert the calling process.                                                                                                                  
     */                                                                                                                                                                                
    DBMS_OUTPUT.PUT_LINE( 'The index IX_TRI_COMMENT_FK_GUID already exists, index creation statement has been bypassed!');
                                                                                                                                                                                       
EXCEPTION                                                                                                                                                                              
  WHEN NO_DATA_FOUND THEN                                                                                                                                                              
                                                                                                                                                                                       
   /*                                                                                                                                                                                  
    *  Index does not exist, execute the DDL statement to create the index in the target environment                                                                                   
    */                                                                                                                                                                                 
    DBMS_OUTPUT.PUT_LINE('The index IX_TRI_COMMENT_FK_GUID was created!');                                               
    EXECUTE IMMEDIATE v_ddl;                                                                                                                                                           

END;                                                                                                                                                                                   
/    




/*  
 *  Add Column:  TRI_FAC (PARENT_COMPANY_NAME_N_S)
 */
DECLARE

 v_sql_statement VARCHAR2(255);
  
BEGIN
 
  SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_FAC'
     AND user_tab_cols.column_name = 'PARENT_COMPANY_NAME_N_S';
     
   dbms_output.put_line('The column PARENT_COMPANY_NAME_N_S on table TRI_FAC has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

    /*
     *  Add new column to the database table.
     */
     v_sql_statement := 'ALTER TABLE TRI_FAC ADD PARENT_COMPANY_NAME_N_S CHAR(01)';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column PARENT_COMPANY_NAME_N_S was added to the database table TRI_FAC.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column PARENT_COMPANY_NAME_N_S to the table TRI_FAC, please investigate!');
      RAISE; 
END;
/




/*  
 *  Add Column:  TRI_ONSITE_RELEASE_Q (STREAM_REACH_CODE)
 */
DECLARE

 v_sql_statement VARCHAR2(255);
  
BEGIN
 
  SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_ONSITE_RELEASE_Q'
     AND user_tab_cols.column_name = 'STREAM_REACH_CODE';
     
   dbms_output.put_line('The column STREAM_REACH_CODE on table TRI_ONSITE_RELEASE_Q has already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

    /*
     *  Add new column to the database table.
     */
     v_sql_statement := 'ALTER TABLE TRI_ONSITE_RELEASE_Q ADD STREAM_REACH_CODE VARCHAR2(100)';
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line(v_sql_statement);
     
     dbms_output.put_line('The column STREAM_REACH_CODE was added to the database table TRI_ONSITE_RELEASE_Q.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column STREAM_REACH_CODE to the table TRI_ONSITE_RELEASE_Q, please investigate!');
      RAISE; 
END;
/



/*  
 *  Add Column:  TRI_REPORT (PUB_CONT_PHONE_EXT_TXT)
 */
DECLARE

 v_sql_statement VARCHAR2(1000);
  
BEGIN
 
  SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_REPORT'
     AND user_tab_cols.column_name = 'PUB_CONT_PHONE_EXT_TXT';
     
   dbms_output.put_line('Columns on table TRI_REPORT have already been added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

    /*
     *  Add new column to the database table.
     */
     v_sql_statement := 'ALTER TABLE TRI_REPORT ADD ( TECH_CONT_PHONE_EXT_TXT VARCHAR2(100) NULL
                           , PUB_CONT_PHONE_EXT_TXT VARCHAR2(100) NULL
                           , OPT_INF_CATG VARCHAR2(100) NULL
                           , MISC_INF_CATG VARCHAR2(100) NULL
                           , PRODUCTION_RATIO_TYPE VARCHAR2(100) NULL)';
                           
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line('Columns were added to the database table TRI_REPORT.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding columns to the table TRI_REPORT, please investigate!');
      RAISE; 
END;
/


/*  
 *  Add Column:  TRI_SRC_RED_ACT (SRC_RED_EFF_CODE)
 */
DECLARE

 v_sql_statement VARCHAR2(1000);
  
BEGIN
 
  SELECT 1
    INTO v_sql_statement 
    FROM user_tab_cols
   WHERE user_tab_cols.table_name = 'TRI_SRC_RED_ACT'
     AND user_tab_cols.column_name = 'SRC_RED_EFF_CODE';
     
   dbms_output.put_line('The SRC_RED_EFF_CODE on table TRI_SRC_RED_ACT was already added, no changes required!');

EXCEPTION
  WHEN NO_DATA_FOUND THEN

    /*
     *  Add new column to the database table.
     */
     v_sql_statement := 'ALTER TABLE TRI_SRC_RED_ACT ADD SRC_RED_EFF_CODE VARCHAR2(100) NULL';                           
     EXECUTE IMMEDIATE v_sql_statement;
     dbms_output.put_line('Column SRC_RED_EFF_CODE was added to the database table TRI_SRC_RED_ACT.');
   
  WHEN OTHERS THEN
      dbms_output.put_line('An error occurred while adding the column SRC_RED_EFF_CODE to the table TRI_SRC_RED_ACT, please investigate!');
      RAISE; 
END;
/