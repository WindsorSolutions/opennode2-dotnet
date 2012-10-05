-- To be used on staging tables if this field does not exist (most WQX staging schemas created before the 2.00 Java OpenNode2 release will be missing this field)
USE NODE_FLOW_WQAR_AR
GO
ALTER TABLE WQX_SUBMISSIONHISTORY ADD ORGID VARCHAR(30) NULL
GO
UPDATE WQX_SUBMISSIONHISTORY set ORGID = ''
GO
ALTER TABLE WQX_SUBMISSIONHISTORY ALTER COLUMN ORGID VARCHAR(30) NOT NULL
GO