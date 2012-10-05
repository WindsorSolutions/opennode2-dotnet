-- To be used on staging tables if this field does not exist (most WQX staging schemas created before the 2.00 Java OpenNode2 release will be missing this field)
ALTER TABLE WQX_SUBMISSIONHISTORY ADD (ORGID VARCHAR2(30) NULL);

UPDATE WQX_SUBMISSIONHISTORY set ORGID = '';

ALTER TABLE WQX_SUBMISSIONHISTORY MODIFY ORGID VARCHAR2(30) NOT NULL; 