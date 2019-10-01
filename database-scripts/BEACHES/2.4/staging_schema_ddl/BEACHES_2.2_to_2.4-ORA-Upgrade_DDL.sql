/* Oracle */

/* This script updates an existing BEACHES v2.2 staging database to work with the v2.4 schema for the .NET OpenNode2 */

/* 9/26/2019 BRensmith Created */

ALTER TABLE NOTIF_BEACH
    ADD (SWIMSEASONDAYMEASURE DECIMAL(16,6) NULL);
    
ALTER TABLE NOTIF_BEACH
    ADD (ADVREPORTINGFREQUENCYMEASURE DECIMAL(16,6) NULL);
    
ALTER TABLE NOTIF_BEACH
    ADD (ADVREPORTINGFREQUNITOFMEASURE VARCHAR2(9) NULL);
    
ALTER TABLE NOTIF_BEACHACTIVITY MODIFY ACTUALSTOPDATE VARCHAR2(25) NOT NULL; --Not Nullable

ALTER TABLE NOTIF_BEACH
    ADD (ACTIVITYPARTIALDAYAMOUNT DECIMAL(16,6) NULL);
    
CREATE TABLE "NOTIF_BEACHACTIVITYDELETE" 
( "ID"                          VARCHAR2(40) NOT NULL, 
 "BEACH_ID"                    VARCHAR2(40) NOT NULL, 
 "ACTIVITYCODENUMBER"          DECIMAL(16,6) NOT NULL
);    

CREATE UNIQUE INDEX "PK_NOTIF_BEACHACTIVITYDELETE"
	ON "NOTIF_BEACHACTIVITYDELETE"("ID");

CREATE INDEX "NOTIF_BEACHACTIVITYDELETE_IDX"
	ON "NOTIF_BEACHACTIVITYDELETE"("BEACH_ID");
    