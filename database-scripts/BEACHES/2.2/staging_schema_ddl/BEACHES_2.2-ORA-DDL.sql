/* This script creates the staging tables for the Beach Notification v2.2 data flow for OpenNode2 */

-- KJames 06.24.2010 - Added Cascade deletes to the foreign key constraints
-- KJames 06.24.2010 - Added drop statements for the BEACH tables, not sequences...
-- KJames 07.12.2010 - Added triggers
-- KJames 07.13.2010 - Associated sequences with proper triggers.
-- KJames 07.26.2010 - Added NOTIF_SUBMISSIONHISTORY table to schema.
-- KJames 07.29.2010 - Modified NOTIF_SUBMISSIONHISTORY, removed the UPDATEDATE column...
-- KJames 08.03.2010 - Modified NOTIF_SUBMISSIONHISTORY, removed the PARENTID column...
-- KJames 08.13.2010 - Added NOTIF_BEACHACTIVITYMONSTATION to the script and related
--                     objects to the script.
-- KJames 08.13.2010 - Removed column MONITORINGSTATIONIDENTIFIER from the
--                     NOTIF_BEACHACTIVITY table.
-- KJames 08.13.2010 - Removed the table NOTIF_BEACHACTIVITYDATES.
-- KJames 08.13.2010 - Added drop for sequences.
-- KJames 08.15.2010 - Rmoved the object prefix of NODE_FLOW_NH.
-- KJames 08.15.2010 - Altered the position of the drop on NOTIF_BEACHACTIVITY
--                     to better fit the DB RI.
-- KJames 09.01.2010 - Removed relationship between NOTIF_BEACH and NOTIF_BEACHPROCEDURE.  
-- KJames 09.01.2010 - Added new table NOTIF_PROCEDURE
-- KJames 09.01.2010 - Removed PROCEDUREIDENTIFIER, PROCEDURETYPECODE, and PROCEDUREDESCRIPTION
--                     from NOTIF_BEACHPROCEDURE, these columns were moved to the newly
--                     created NOTIF_PROCEDURE table.
-- KJames 09.01.2010 - Added sequence NOTIF_BEACHPROCEDURE_ID_SEQ.
-- KJames 09.01.2010 - Added trigger NOTIF_PROCEDURE.
-- KJames 11.05.2010 - Modified primary keys to VARCHAR from NUMBER to support GUIDS.
-- KJames 11.05.2010 - Removed sequences.
-- KJames 11.05.2010 - Altered triggers to pull SYS_GUID() vs original NEXTVAL from 
--                     the sequence.
-- Brensmith 4/10/2012 - Modified to accomodate schema v2.2 
-- PPatterson Added beaches_submission table for submission tracking, made actualstop date nullable and added lastupdated field in notif_beachactivity table */

/* Drop */

/* 
ALTER TABLE NOTIF_PERSONTELEPHONE
 DROP CONSTRAINT FK_PERSONTELEPHONE_PERSON
/

ALTER TABLE NOTIF_PERSONMAILINGADDRESS
 DROP CONSTRAINT FK_PERSONMAILINGADDRESS_PERSON
/

ALTER TABLE NOTIF_PERSONELECTRONICADDRESS
 DROP CONSTRAINT FK_PERSONELECTRONICADD_PERSON
/

ALTER TABLE NOTIF_PERSONBEACHROLE
 DROP CONSTRAINT FK_PERSONBEACHROLE_PERSON
/

ALTER TABLE NOTIF_PERSONBEACHROLE
 DROP CONSTRAINT FK_PERSONBEACHROLE_BEACH
/

ALTER TABLE NOTIF_PERSON
 DROP CONSTRAINT FK_PERSON_ORGANIZATION
/

ALTER TABLE NOTIF_ORGELECTRONICADDR
 DROP CONSTRAINT FK_ORGELECTRONICADDR_ORG
/

ALTER TABLE NOTIF_ORGANIZATIONTELEPHONE
 DROP CONSTRAINT FK_ORGANIZATIONTELEPHONE_ORG
/

ALTER TABLE NOTIF_ORGANIZATIONMAILINGADDR
 DROP CONSTRAINT FK_ORGANIZATION_ORGMAILINGADDR
/

ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE
 DROP CONSTRAINT FK_ORGANIZATIONBEACHROLE_ORG
/

ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE
 DROP CONSTRAINT FK_ORGANIZATIONBEACHROLE_BEACH
/

ALTER TABLE NOTIF_BEACHPROCEDURE
 DROP CONSTRAINT FK_BEACHPROCEDURE_BEACH
/

ALTER TABLE NOTIF_BEACHPOLLUTION
 DROP CONSTRAINT FK_BEACHPOLLUTION_BEACH
/

ALTER TABLE NOTIF_BEACHACTIVITY
 DROP CONSTRAINT FK_BEACHACTIVITY_BEACH
/

ALTER TABLE NOTIF_ACTIVITYSOURCE
 DROP CONSTRAINT FK_ACTIVITYSOURCE_BEACHACT
/

ALTER TABLE NOTIF_ACTIVITYREASON
 DROP CONSTRAINT FK_ACTIVITYREASON_BEACHACT
/

ALTER TABLE NOTIF_ACTIVITYINDICATOR
 DROP CONSTRAINT FK_ACTIVITYINDICATOR_BEACHACT
/

ALTER TABLE NOTIF_BEACHACTIVITYMONSTATION
 DROP CONSTRAINT FK_NOT_ACT_MON
/

ALTER TABLE NOTIF_BEACHCRITERION
 DROP CONSTRAINT FK_BEACHCRITERION_BEACH
/

ALTER TABLE NOTIF_STATECONTACT
 DROP CONSTRAINT FK_STATECONTACT_ORGANIZATION
/

ALTER TABLE NOTIF_YEARCOMPLETION
 DROP CONSTRAINT PK_NOTIF_YEARCOMPLETION
/

ALTER TABLE NOTIF_PERSONTELEPHONE
 DROP CONSTRAINT PK_NOTIF_PERSONTELEPHONE
/

ALTER TABLE NOTIF_PERSONMAILINGADDRESS
 DROP CONSTRAINT PK_NOTIF_PERSONMAILINGADDRESS
/

ALTER TABLE NOTIF_PERSONELECTRONICADDRESS
 DROP CONSTRAINT PK_NOTIF_PERSONELECTRONICADDR
/

ALTER TABLE NOTIF_PERSONBEACHROLE
 DROP CONSTRAINT PK_NOTIF_PERSONBEACHROLE
/

ALTER TABLE NOTIF_PERSON
 DROP CONSTRAINT PK_NOTIF_PERSON
/

ALTER TABLE NOTIF_ORGELECTRONICADDR
 DROP CONSTRAINT PK_NOTIF_ORGELECTRONICADDR
/

ALTER TABLE NOTIF_ORGANIZATIONTELEPHONE
 DROP CONSTRAINT PK_NOTIF_ORGANIZATIONTELEPHONE
/

ALTER TABLE NOTIF_ORGANIZATIONMAILINGADDR
 DROP CONSTRAINT PK_NOTIF_ORGMAILINGADDR
/

ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE
 DROP CONSTRAINT PK_NOTIF_ORGANIZATIONBEACHROLE
/

ALTER TABLE NOTIF_ORGANIZATION
 DROP CONSTRAINT PK_NOTIF_ORGANIZATION
/

ALTER TABLE NOTIF_BEACHPROCEDURE
 DROP CONSTRAINT PK_NOTIF_BEACHPROCEDURE
/

ALTER TABLE NOTIF_PROCEDURE
 DROP CONSTRAINT PK_NOTIF_PROCEDURE
/

ALTER TABLE NOTIF_BEACHPOLLUTION
 DROP CONSTRAINT PK_NOTIF_BEACHPOLLUTION
/

ALTER TABLE NOTIF_BEACHACTIVITY
 DROP CONSTRAINT PK_NOTIF_BEACHACTIVITY
/

ALTER TABLE NOTIF_BEACH
 DROP CONSTRAINT PK_NOTIF_BEACH
/

ALTER TABLE NOTIF_ACTIVITYSOURCE
 DROP CONSTRAINT PK_NOTIF_ACTIVITYSOURCE
/

ALTER TABLE NOTIF_ACTIVITYREASON
 DROP CONSTRAINT PK_NOTIF_ACTIVITYREASON
/

ALTER TABLE NOTIF_ACTIVITYINDICATOR
 DROP CONSTRAINT PK_NOTIF_ACTIVITYINDICATOR
/

ALTER TABLE NOTIF_BEACHCRITERION
 DROP CONSTRAINT PK_NOTIF_BEACHCRITERION
/

ALTER TABLE NOTIF_STATECONTACT
 DROP CONSTRAINT PK_NOTIF_STATECONTACT
/

DROP INDEX PK_NOTIF_YEARCOMPLETION
/

DROP INDEX NOTIF_PERSONTELEPHONE
/

DROP INDEX PK_NOTIF_PERSONTELEPHONE
/

DROP INDEX PK_NOTIF_PERSONMAILINGADDRESS
/

DROP INDEX NOTIF_PERSONMAILINGADDRESS
/

DROP INDEX PK_NOTIF_PERSONELECTRONICADDR
/

DROP INDEX NOTIF_PERSONELECTRONICADDRESS
/

DROP INDEX PK_NOTIF_PERSONBEACHROLE
/

DROP INDEX NOTIF_PERSONBEACHROLE
/

DROP INDEX PK_NOTIF_PERSON
/

DROP INDEX NOTIF_PERSON
/

DROP INDEX NOTIF_ORGELECTRONICADDR
/

DROP INDEX PK_NOTIF_ORGELECTRONICADDR
/

DROP INDEX PK_NOTIF_ORGANIZATIONTELEPHONE
/

DROP INDEX NOTIF_ORGANIZATIONTELEPHONE
/

DROP INDEX PK_NOTIF_ORGMAILINGADDR
/

DROP INDEX NOTIF_ORGANIZATIONMAILINGADDR
/

DROP INDEX NOTIF_ORGANIZATIONBEACHROLE
/

DROP INDEX PK_NOTIF_ORGANIZATIONBEACHROLE
/

DROP INDEX PK_NOTIF_ORGANIZATION
/

DROP INDEX NOTIF_PROCEDURE_IDX
/

DROP INDEX PK_NOTIF_BEACHPROCEDURE
/

DROP INDEX PK_NOTIF_BEACHPOLLUTION
/

DROP INDEX NOTIF_BEACHPOLLUTION
/

DROP INDEX PK_NOTIF_BEACHACTIVITY
/

DROP INDEX NOTIF_SENTTOEPA
/

DROP INDEX NOTIF_BEACHACTIVITY
/

DROP INDEX PK_NOTIF_BEACH
/

DROP INDEX PK_NOTIF_ACTIVITYSOURCE
/

DROP INDEX NOTIF_ACTIVITYSOURCE
/

DROP INDEX PK_NOTIF_ACTIVITYREASON
/

DROP INDEX NOTIF_ACTIVITYREASON
/

DROP INDEX PK_NOTIF_ACTIVITYINDICATOR
/

DROP INDEX NOTIF_ACTIVITYINDICATOR
/

DROP INDEX PK_NOTIF_BEACHCRITERION
/

DROP INDEX NOTIF_BEACHCRITERION
/

DROP INDEX PK_NOTIF_STATECONTACT
/

DROP INDEX NOTIF_STATECONTACT
/

DROP TABLE NOTIF_YEARCOMPLETION
/

DROP TABLE NOTIF_PERSONTELEPHONE
/

DROP TABLE NOTIF_PERSONMAILINGADDRESS
/

DROP TABLE NOTIF_PERSONELECTRONICADDRESS
/

DROP TABLE NOTIF_PERSONBEACHROLE
/

DROP TABLE NOTIF_PERSON
/

DROP TABLE NOTIF_ORGELECTRONICADDR
/

DROP TABLE NOTIF_ORGANIZATIONTELEPHONE
/

DROP TABLE NOTIF_ORGANIZATIONMAILINGADDR
/

DROP TABLE NOTIF_ORGANIZATIONBEACHROLE
/

DROP TABLE NOTIF_STATECONTACT
/

DROP TABLE NOTIF_ORGANIZATION
/

DROP TABLE NOTIF_BEACHPROCEDURE
/

DROP TABLE NOTIF_PROCEDURE
/

DROP TABLE NOTIF_BEACHPOLLUTION
/

DROP TABLE NOTIF_BEACHACTIVITYMONSTATION
/

DROP TABLE NOTIF_BEACHCRITERION
/

DROP TABLE NOTIF_BEACH
/

DROP TABLE NOTIF_ACTIVITYSOURCE
/

DROP TABLE NOTIF_ACTIVITYREASON
/

DROP TABLE NOTIF_ACTIVITYINDICATOR
/

DROP TABLE NOTIF_SUBMISSIONHISTORY
/

DROP TABLE NOTIF_BEACHACTIVITY
/
*/


/* Oracle */

/*Added first table below*/


CREATE TABLE "NOTIF_ACTIVITYINDICATOR" ( 
	"ID"                  	VARCHAR2(40) NOT NULL,
	"ACTIVITY_ID"         	VARCHAR2(40) NOT NULL,
	"INDICATORTYPE"       	VARCHAR2(60) NOT NULL,
	"INDICATORDESCRIPTION"	VARCHAR2(255) NULL 
	);

CREATE TABLE "NOTIF_ACTIVITYREASON" ( 
	"ID"               	VARCHAR2(40) NOT NULL,
	"ACTIVITY_ID"      	VARCHAR2(40) NOT NULL,
	"REASONTYPE"       	VARCHAR2(60) NOT NULL,
	"REASONDESCRIPTION"	VARCHAR2(255) NULL 
	);

CREATE TABLE "NOTIF_ACTIVITYSOURCE" ( 
	"ID"               	VARCHAR2(40) NOT NULL,
	"ACTIVITY_ID"      	VARCHAR2(40) NOT NULL,
	"SOURCETYPE"       	VARCHAR2(60) NOT NULL,
	"SOURCEDESCRIPTION"	VARCHAR2(255) NULL 
	);

CREATE TABLE "NOTIF_BEACH" ( 
	"ID"                            	VARCHAR2(40) NOT NULL,
	"BEACHIDENTIFIER"               	VARCHAR2(8) NOT NULL,
	"BEACHNAME"                     	VARCHAR2(60) NULL,
	"BEACHDESCRIPTION"              	VARCHAR2(255) NULL,
	"BEACHCOMMENT"                  	VARCHAR2(255) NULL,
	"BEACHSTATECODE"                	CHAR(2) NULL,
	"BEACHFIPSCOUNTYCODE"           	VARCHAR2(5) NULL,
	"BEACHACCESSTYPE"               	VARCHAR2(12) NULL,
	"BEACHACCESSCOMMENT"            	VARCHAR2(255) NULL,
	"EFFECTIVEYEAR"                 	VARCHAR2(4) NULL,
	"EXTENTLENGTHMEASURE"           	DECIMAL(16,6) NULL,
	"EXTENTUNITOFMEASURE"           	VARCHAR2(12) NULL,
	"SWIMSEASONSTARTDATE"           	VARCHAR2(25) NULL,
	"SWIMSEASONENDDATE"             	VARCHAR2(25) NULL,
	"SWIMSEASONLENGTH"              	DECIMAL(16,6) NULL,
	"SWIMSEASONUNITOFMEASURE"       	VARCHAR2(12) NULL,
	"SWIMSEASONFREQUENCYMEASURE"    	DECIMAL(16,6) NULL,
	"OFFSEASONFREQUENCYMEASURE"     	DECIMAL(16,6) NULL,
	"MONITORINGFREQUNITOFMEASURE"   	VARCHAR2(255) NULL,
	"MONITOREDIRREGULARLY"          	VARCHAR2(5) NULL,
	"MONITOREDIRREGULARLYCOMMENT"   	VARCHAR2(255) NULL,
	"BEACHTIERRANKING"              	VARCHAR2(1) NULL,
	"BEACHACTBEACHINDICATOR"        	VARCHAR2(5) NULL,
	"NOPOLLUTIONSOURCES"            	VARCHAR2(5) NULL,
	"POLLUTIONSOURCESUNINVESTIGATED"	VARCHAR2(5) NULL,
	"WATERBODYNAMECODE"             	VARCHAR2(25) NULL,
	"WATERBODYTYPECODE"             	VARCHAR2(25) NULL,
	"STARTLATMEASURE"               	VARCHAR2(25) NULL,
	"STARTLONGMEASURE"              	VARCHAR2(25) NULL,
	"ENDLATMEASURE"                 	VARCHAR2(25) NULL,
	"ENDLONGMEASURE"                	VARCHAR2(25) NULL,
	"SOURCEMAPSCALE"                	VARCHAR2(25) NULL,
	"HORIZCOLLMETHOD"               	VARCHAR2(25) NULL,
	"HORIZCOLLDATUM"                	VARCHAR2(25) NULL,
	"BEACHDORMANTINDICATOR"				VARCHAR2(5) NULL,
	"BEACHWEBSITE"						VARCHAR2(255) NULL,
	"REPORTINGFREQUENCYMEASURE"			NUMBER NULL,
	"REPORTINGFREQUNITOFMEASURE"		VARCHAR2(9) NULL 
	);

CREATE TABLE "NOTIF_BEACHCRITERION" (
    "ID"							VARCHAR2(40) NOT NULL,
    "BEACH_ID"						VARCHAR2(40) NOT NULL,
    "INDICATORNAME"					VARCHAR2(11) NOT NULL,
    "WATERTYPENAME"					VARCHAR2(6) NOT NULL,
    "CRITERIONCOMMENT"				VARCHAR2(255) NULL,
    "MEASURETYPENAME"				VARCHAR2(4) NOT NULL,
    "MEASUREVALUE"					DECIMAL(16,6) NOT NULL,
    "MEASUREUNITCODE"				VARCHAR2(12) NOT NULL
    );

CREATE TABLE "NOTIF_STATECONTACT" (
    "ID"							VARCHAR2(40) NOT NULL,
    "ORGANIZATION_ID"				VARCHAR2(40) NOT NULL,
    "AGENCYNAME"					VARCHAR2(60) NOT NULL,
    "TELEPHONENUMBER"				VARCHAR2(12) NOT NULL,
    "ELECTRONICADDR"				VARCHAR2(255) NOT NULL,
    "FIRSTNAME"						VARCHAR2(50) NOT NULL,
    "LASTNAME"						VARCHAR2(50) NOT NULL
	);
	
CREATE TABLE "NOTIF_BEACHACTIVITY" ( 
	"ID"                         	VARCHAR2(40) NOT NULL,
	"BEACH_ID"                   	VARCHAR2(40) NOT NULL,
	"ACTIVITYTYPECODE"           	VARCHAR2(12) NOT NULL,
	"ACTIVITYNAME"               	VARCHAR2(60) NOT NULL,
	"ACTUALSTARTDATE"            	VARCHAR2(25) NOT NULL,
	"ACTUALSTOPDATE"             	VARCHAR2(25)  NULL,     /*Changed to NULL*/
	"ACTIVITYDESCRIPTION"        	VARCHAR2(255) NULL,
	"ACTIVITYCOMMENT"            	VARCHAR2(255) NULL,
	"EXTENTSTARTMEASURE"         	DECIMAL(16,6) NULL,
	"EXTENTLENGTHMEASURE"        	DECIMAL(16,6) NULL,
	"EXTENTUNITOFMEASURE"        	VARCHAR2(255) NULL,
	"SENTTOEPA"                  	CHAR(1)       NULL,
	"NOTIFUPDATEUPDATE"           DATE          NULL      
	);

--------------------------------------------------------
--  DDL for Table NOTIF_BEACHACTIVITYMONSTATION
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHACTIVITYMONSTATION" 
   ( "ID"                          VARCHAR2(40) NOT NULL, 
	 "ACTIVITY_ID"                    VARCHAR2(40) NOT NULL, 
	 "MONITORINGSTATIONIDENTIFIER"    VARCHAR2(65) NOT NULL
   );
 

	COMMENT ON COLUMN "NOTIF_BEACHACTIVITYMONSTATION"."ID" IS 'Parent: All the information associated with an activity. (Id)';

	COMMENT ON COLUMN "NOTIF_BEACHACTIVITYMONSTATION"."ACTIVITY_ID" IS 'Parent: All the information associated with an activity. (ActivityId)';

	COMMENT ON COLUMN "NOTIF_BEACHACTIVITYMONSTATION"."MONITORINGSTATIONIDENTIFIER" IS 'Parent: All the information associated with an activity. (Identifier)';

	COMMENT ON TABLE "NOTIF_BEACHACTIVITYMONSTATION"  IS 'Schema element: ActivityMonitoringStationIdentifierDataType';	

CREATE TABLE "NOTIF_BEACHPOLLUTION" ( 
	"ID"                        	VARCHAR2(40) NOT NULL,
	"BEACH_ID"                  	VARCHAR2(40) NOT NULL,
	"POLLUTIONSOURCECODE"       	VARCHAR2(12) NOT NULL,
	"POLLUTIONSOURCEDESCRIPTION"	VARCHAR2(255) NULL 
	);

CREATE TABLE "NOTIF_BEACHPROCEDURE" ( 
	"ID"                  	VARCHAR2(40) NOT NULL,
	"BEACH_ID"            	VARCHAR2(40) NOT NULL,
	"PROCEDURE_ID"        	VARCHAR2(40) NOT NULL	
 );
 
  CREATE TABLE "NOTIF_PROCEDURE" ( 
 "ID"                   VARCHAR2(40) NOT NULL,
 "PROCEDUREIDENTIFIER"  VARCHAR2(8) NOT NULL,
 "PROCEDURETYPECODE"    VARCHAR2(12) NOT NULL,
 "PROCEDUREDESCRIPTION" VARCHAR2(255) NOT NULL 
 );

CREATE TABLE "NOTIF_ORGANIZATION" ( 
	"ID"                      	VARCHAR2(40) NOT NULL,
	"ORGANIZATIONIDENTIFIER"  	VARCHAR2(12) NOT NULL,
	"ORGANIZATIONTYPECODE"    	VARCHAR2(12) NOT NULL,
	"ORGANIZATIONNAME"        	VARCHAR2(60) NOT NULL,
	"ORGANIZATIONDESCRIPTION" 	VARCHAR2(255) NULL,
	"ORGANIZATIONABBREVIATION"	VARCHAR2(30) NULL 
	);

CREATE TABLE "NOTIF_ORGANIZATIONBEACHROLE" ( 
	"ID"               	VARCHAR2(40) NOT NULL,
	"BEACH_ID"         	VARCHAR2(40) NOT NULL,
	"ORGANIZATION_ID"  	VARCHAR2(40) NOT NULL,
	"ROLETYPECODE"     	VARCHAR2(12) NOT NULL,
	"ROLEEFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"ROLESTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_ORGANIZATIONMAILINGADDR" ( 
	"ID"                      	VARCHAR2(40) NOT NULL,
	"ORGANIZATION_ID"         	VARCHAR2(40) NOT NULL,
	"MAILINGADDRTYPECODE"     	VARCHAR2(12) NOT NULL,
	"MAILINGADDRLINE1"        	VARCHAR2(100) NOT NULL,
	"MAILINGADDRLINE2"        	VARCHAR2(100) NULL,
	"MAILINGADDRLINE3"        	VARCHAR2(100) NULL,
	"MAILINGADDRCITY"         	VARCHAR2(50) NOT NULL,
	"STATECODE"               	CHAR(2) NOT NULL,
	"ZIPCODE"                 	VARCHAR2(12) NOT NULL,
	"MAILINGADDREFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"MAILINGADDRSTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_ORGANIZATIONTELEPHONE" ( 
	"ID"                    	VARCHAR2(40) NOT NULL,
	"ORGANIZATION_ID"       	VARCHAR2(40) NOT NULL,
	"TELEPHONETYPECODE"     	VARCHAR2(12) NOT NULL,
	"TELEPHONENUMBER"       	VARCHAR2(12) NOT NULL,
	"TELEPHONEEFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"TELEPHONESTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_ORGELECTRONICADDR" ( 
	"ID"                    	VARCHAR2(40) NOT NULL,
	"ORGANIZATION_ID"       	VARCHAR2(40) NOT NULL,
	"ELECTRONICADDRTYPECODE"	VARCHAR2(12) NOT NULL,
	"ELECTRONICADDR"        	VARCHAR2(255) NOT NULL,
	"ELECTRONICADDREFFDATE" 	VARCHAR2(25) NOT NULL,
	"ELECTRONICADDRSTATUS"  	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_PERSON" ( 
	"ID"              	VARCHAR2(40) NOT NULL,
	"ORGANIZATION_ID" 	VARCHAR2(40) NOT NULL,
	"PERSONIDENTIFIER"	VARCHAR2(12) NOT NULL,
	"PERSONSTATUS"    	VARCHAR2(8) NULL,
	"FIRSTNAME"       	VARCHAR2(50) NULL,
	"LASTNAME"        	VARCHAR2(50) NULL,
	"MIDDLEINITIAL"   	VARCHAR2(2) NULL,
	"SUFFIX"          	VARCHAR2(5) NULL,
	"TITLE"           	VARCHAR2(60) NULL 
	);

CREATE TABLE "NOTIF_PERSONBEACHROLE" ( 
	"ID"               	VARCHAR2(40) NOT NULL,
	"BEACH_ID"         	VARCHAR2(40) NOT NULL,
	"PERSON_ID"        	VARCHAR2(40) NOT NULL,
	"ROLETYPECODE"     	VARCHAR2(12) NOT NULL,
	"ROLEEFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"ROLESTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_PERSONELECTRONICADDRESS" ( 
	"ID"                            	VARCHAR2(40) NOT NULL,
	"PERSON_ID"                     	VARCHAR2(40) NOT NULL,
	"ELECTRONICADDRESSTYPECODE"     	VARCHAR2(12) NOT NULL,
	"ELECTRONICADDRESS"             	VARCHAR2(255) NOT NULL,
	"ELECTRONICADDRESSEFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"ELECTRONICADDRESSSTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_PERSONMAILINGADDRESS" ( 
	"ID"                      	VARCHAR2(40) NOT NULL,
	"PERSON_ID"               	VARCHAR2(40) NOT NULL,
	"MAILINGADDRTYPECODE"     	VARCHAR2(12) NOT NULL,
	"MAILINGADDRLINE1"        	VARCHAR2(100) NOT NULL,
	"MAILINGADDRLINE2"        	VARCHAR2(100) NULL,
	"MAILINGADDRLINE3"        	VARCHAR2(100) NULL,
	"MAILINGADDRCITY"         	VARCHAR2(50) NOT NULL,
	"STATECODE"               	CHAR(2) NOT NULL,
	"ZIPCODE"                 	VARCHAR2(12) NOT NULL,
	"MAILINGADDREFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"MAILINGADDRSTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_PERSONTELEPHONE" ( 
	"ID"                    	VARCHAR2(40) NOT NULL,
	"PERSON_ID"             	VARCHAR2(40) NOT NULL,
	"TELEPHONETYPECODE"     	VARCHAR2(12) NOT NULL,
	"TELEPHONENUMBER"       	VARCHAR2(12) NOT NULL,
	"TELEPHONEEFFECTIVEDATE"	VARCHAR2(25) NOT NULL,
	"TELEPHONESTATUS"       	VARCHAR2(8) NOT NULL 
	);

CREATE TABLE "NOTIF_YEARCOMPLETION" ( 
	"ID"                           	VARCHAR2(40) NOT NULL,
	"COMPLETIONYEAR"               	NUMBER NOT NULL,
	"NOTIFICATIONDATACOMPLETIONIND"	VARCHAR2(5) NULL,
	"MONITORINGDATACOMPLETIONIND"  	VARCHAR2(5) NULL,
	"LOCATIONDATACOMPLETIONIND"    	VARCHAR2(5) NULL 
	);
 
CREATE TABLE "NOTIF_SUBMISSIONHISTORY" ( 
 "RECORDID"               VARCHAR2(40) NOT NULL,
 "SCHEDULERUNDATE"        DATE NOT NULL,
 "TRANSACTIONID"          VARCHAR2(50) NOT NULL,
 "PROCESSINGSTATUS"       VARCHAR2(50) NOT NULL 
 ); 

CREATE UNIQUE INDEX "PK_NOTIF_ACTIVITYINDICATOR"
	ON "NOTIF_ACTIVITYINDICATOR"("ID");

CREATE INDEX "NOTIF_ACTIVITYINDICATOR"
	ON "NOTIF_ACTIVITYINDICATOR"("ACTIVITY_ID");

CREATE UNIQUE INDEX "PK_NOTIF_ACTIVITYREASON"
	ON "NOTIF_ACTIVITYREASON"("ID");

CREATE INDEX "NOTIF_ACTIVITYREASON"
	ON "NOTIF_ACTIVITYREASON"("ACTIVITY_ID");

CREATE UNIQUE INDEX "PK_NOTIF_ACTIVITYSOURCE"
	ON "NOTIF_ACTIVITYSOURCE"("ID");

CREATE INDEX "NOTIF_ACTIVITYSOURCE"
	ON "NOTIF_ACTIVITYSOURCE"("ACTIVITY_ID");

CREATE UNIQUE INDEX "PK_NOTIF_BEACH"
	ON "NOTIF_BEACH"("ID");

CREATE INDEX "NOTIF_SENTTOEPA"
	ON "NOTIF_BEACHACTIVITY"("SENTTOEPA");

CREATE INDEX "NOTIF_BEACHACTIVITY"
	ON "NOTIF_BEACHACTIVITY"("BEACH_ID");

CREATE UNIQUE INDEX "PK_NOTIF_BEACHACTIVITY"
	ON "NOTIF_BEACHACTIVITY"("ID");
	
CREATE INDEX "NOTIF_BEACHACTMONITOR_IDX"
   ON "NOTIF_BEACHACTIVITYMONSTATION" ("ACTIVITY_ID");	

CREATE UNIQUE INDEX "PK_NOTIF_BEACHPOLLUTION"
	ON "NOTIF_BEACHPOLLUTION"("ID");

CREATE INDEX "NOTIF_BEACHPOLLUTION"
	ON "NOTIF_BEACHPOLLUTION"("BEACH_ID");

CREATE INDEX "NOTIF_BEACHPROCEDURE_IDX"
	ON "NOTIF_BEACHPROCEDURE"("BEACH_ID");
 
CREATE INDEX "NOTIF_PROCEDURE_IDX"
 ON "NOTIF_BEACHPROCEDURE"("PROCEDURE_ID");

CREATE UNIQUE INDEX "PK_NOTIF_BEACHPROCEDURE"
	ON "NOTIF_BEACHPROCEDURE"("ID");
 
CREATE UNIQUE INDEX "PK_NOTIF_PROCEDURE"
 ON "NOTIF_PROCEDURE"("ID");

CREATE UNIQUE INDEX "PK_NOTIF_ORGANIZATION"
	ON "NOTIF_ORGANIZATION"("ID");

CREATE INDEX "NOTIF_ORGANIZATIONBEACHROLE"
	ON "NOTIF_ORGANIZATIONBEACHROLE"("ORGANIZATION_ID");

CREATE UNIQUE INDEX "PK_NOTIF_ORGANIZATIONBEACHROLE"
	ON "NOTIF_ORGANIZATIONBEACHROLE"("ID");

CREATE INDEX "NOTIF_ORGANIZATIONMAILINGADDR"
	ON "NOTIF_ORGANIZATIONMAILINGADDR"("ORGANIZATION_ID");

CREATE UNIQUE INDEX "PK_NOTIF_ORGMAILINGADDR"
	ON "NOTIF_ORGANIZATIONMAILINGADDR"("ID");

CREATE UNIQUE INDEX "PK_NOTIF_ORGANIZATIONTELEPHONE"
	ON "NOTIF_ORGANIZATIONTELEPHONE"("ID");

CREATE INDEX "NOTIF_ORGANIZATIONTELEPHONE"
	ON "NOTIF_ORGANIZATIONTELEPHONE"("ORGANIZATION_ID");

CREATE UNIQUE INDEX "PK_NOTIF_ORGELECTRONICADDR"
	ON "NOTIF_ORGELECTRONICADDR"("ID");

CREATE INDEX "NOTIF_ORGELECTRONICADDR"
	ON "NOTIF_ORGELECTRONICADDR"("ORGANIZATION_ID");

CREATE INDEX "NOTIF_PERSON"
	ON "NOTIF_PERSON"("ORGANIZATION_ID");

CREATE UNIQUE INDEX "PK_NOTIF_PERSON"
	ON "NOTIF_PERSON"("ID");

CREATE UNIQUE INDEX "PK_NOTIF_PERSONBEACHROLE"
	ON "NOTIF_PERSONBEACHROLE"("ID");

CREATE INDEX "NOTIF_PERSONBEACHROLE"
	ON "NOTIF_PERSONBEACHROLE"("BEACH_ID");

CREATE UNIQUE INDEX "PK_NOTIF_PERSONELECTRONICADDR"
	ON "NOTIF_PERSONELECTRONICADDRESS"("ID");

CREATE INDEX "NOTIF_PERSONELECTRONICADDRESS"
	ON "NOTIF_PERSONELECTRONICADDRESS"("PERSON_ID");

CREATE INDEX "NOTIF_PERSONMAILINGADDRESS"
	ON "NOTIF_PERSONMAILINGADDRESS"("PERSON_ID");

CREATE UNIQUE INDEX "PK_NOTIF_PERSONMAILINGADDRESS"
	ON "NOTIF_PERSONMAILINGADDRESS"("ID");

CREATE INDEX "NOTIF_PERSONTELEPHONE"
	ON "NOTIF_PERSONTELEPHONE"("PERSON_ID");

CREATE UNIQUE INDEX "PK_NOTIF_PERSONTELEPHONE"
	ON "NOTIF_PERSONTELEPHONE"("ID");

CREATE UNIQUE INDEX "PK_NOTIF_YEARCOMPLETION"
	ON "NOTIF_YEARCOMPLETION"("ID");

CREATE INDEX "NOTIF_BEACHCRITERION"
  ON "NOTIF_BEACHCRITERION"("BEACH_ID");

CREATE UNIQUE INDEX "PK_NOTIF_BEACHCRITERION"
	ON "NOTIF_BEACHCRITERION"("ID");

CREATE INDEX "NOTIF_STATECONTACT"
  ON "NOTIF_STATECONTACT"("ORGANIZATION_ID");
  
CREATE UNIQUE INDEX "PK_NOTIF_STATECONTACT"
	ON "NOTIF_STATECONTACT"("ID");

ALTER TABLE "NOTIF_ACTIVITYINDICATOR"
	ADD ( CONSTRAINT "PK_NOTIF_ACTIVITYINDICATOR"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ACTIVITYREASON"
	ADD ( CONSTRAINT "PK_NOTIF_ACTIVITYREASON"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ACTIVITYSOURCE"
	ADD ( CONSTRAINT "PK_NOTIF_ACTIVITYSOURCE"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_BEACH"
	ADD ( CONSTRAINT "PK_NOTIF_BEACH"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_BEACHACTIVITY"
	ADD ( CONSTRAINT "PK_NOTIF_BEACHACTIVITY"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );
	
ALTER TABLE "NOTIF_BEACHACTIVITYMONSTATION"
	ADD ( CONSTRAINT "PK_NOTIF_BEACHACTMONITOR"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );
	
ALTER TABLE "NOTIF_BEACHPOLLUTION"
	ADD ( CONSTRAINT "PK_NOTIF_BEACHPOLLUTION"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_BEACHPROCEDURE"
	ADD ( CONSTRAINT "PK_NOTIF_BEACHPROCEDURE"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_PROCEDURE"
 ADD ( CONSTRAINT "PK_NOTIF_PROCEDURE"
 PRIMARY KEY ("ID")
 NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ORGANIZATION"
	ADD ( CONSTRAINT "PK_NOTIF_ORGANIZATION"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE"
	ADD ( CONSTRAINT "PK_NOTIF_ORGANIZATIONBEACHROLE"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR"
	ADD ( CONSTRAINT "PK_NOTIF_ORGMAILINGADDR"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE"
	ADD ( CONSTRAINT "PK_NOTIF_ORGANIZATIONTELEPHONE"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ORGELECTRONICADDR"
	ADD ( CONSTRAINT "PK_NOTIF_ORGELECTRONICADDR"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_PERSON"
	ADD ( CONSTRAINT "PK_NOTIF_PERSON"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_PERSONBEACHROLE"
	ADD ( CONSTRAINT "PK_NOTIF_PERSONBEACHROLE"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS"
	ADD ( CONSTRAINT "PK_NOTIF_PERSONELECTRONICADDR"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_PERSONMAILINGADDRESS"
	ADD ( CONSTRAINT "PK_NOTIF_PERSONMAILINGADDRESS"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_PERSONTELEPHONE"
	ADD ( CONSTRAINT "PK_NOTIF_PERSONTELEPHONE"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_YEARCOMPLETION"
	ADD ( CONSTRAINT "PK_NOTIF_YEARCOMPLETION"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_BEACHCRITERION"
	ADD ( CONSTRAINT "PK_NOTIF_BEACHCRITERION"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_STATECONTACT"
	ADD ( CONSTRAINT "PK_NOTIF_STATECONTACT"
	PRIMARY KEY ("ID")
	NOT DEFERRABLE INITIALLY IMMEDIATE );

ALTER TABLE "NOTIF_ACTIVITYINDICATOR"
	ADD ( CONSTRAINT "FK_ACTIVITYINDICATOR_BEACHACT"
	FOREIGN KEY("ACTIVITY_ID")
	REFERENCES "NOTIF_BEACHACTIVITY"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ACTIVITYREASON"
	ADD ( CONSTRAINT "FK_ACTIVITYREASON_BEACHACT"
	FOREIGN KEY("ACTIVITY_ID")
	REFERENCES "NOTIF_BEACHACTIVITY"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ACTIVITYSOURCE"
	ADD ( CONSTRAINT "FK_ACTIVITYSOURCE_BEACHACT"
	FOREIGN KEY("ACTIVITY_ID")
	REFERENCES "NOTIF_BEACHACTIVITY"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_BEACHACTIVITY"
	ADD ( CONSTRAINT "FK_BEACHACTIVITY_BEACH"
	FOREIGN KEY("BEACH_ID")
	REFERENCES "NOTIF_BEACH"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );
	
ALTER TABLE "NOTIF_BEACHACTIVITYMONSTATION"
	ADD ( CONSTRAINT "FK_NOT_ACT_MON"
	FOREIGN KEY("ACTIVITY_ID")
	REFERENCES "NOTIF_BEACHACTIVITY"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );
 
ALTER TABLE "NOTIF_BEACHPOLLUTION"
	ADD ( CONSTRAINT "FK_BEACHPOLLUTION_BEACH"
	FOREIGN KEY("BEACH_ID")
	REFERENCES "NOTIF_BEACH"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_BEACHPROCEDURE"
	ADD ( CONSTRAINT "FK_BEACHPROCEDURE_PROCEDURE"
	FOREIGN KEY("PROCEDURE_ID")
	REFERENCES "NOTIF_PROCEDURE"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_BEACHPROCEDURE"
	ADD ( CONSTRAINT "FK_BEACHPROCEDURE_BEACH"
	FOREIGN KEY("BEACH_ID")
	REFERENCES "NOTIF_BEACH"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE"
	ADD ( CONSTRAINT "FK_ORGANIZATIONBEACHROLE_ORG"
	FOREIGN KEY("ORGANIZATION_ID")
	REFERENCES "NOTIF_ORGANIZATION"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE"
	ADD ( CONSTRAINT "FK_ORGANIZATIONBEACHROLE_BEACH"
	FOREIGN KEY("BEACH_ID")
	REFERENCES "NOTIF_BEACH"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR"
	ADD ( CONSTRAINT "FK_ORGANIZATION_ORGMAILINGADDR"
	FOREIGN KEY("ORGANIZATION_ID")
	REFERENCES "NOTIF_ORGANIZATION"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE"
	ADD ( CONSTRAINT "FK_ORGANIZATIONTELEPHONE_ORG"
	FOREIGN KEY("ORGANIZATION_ID")
	REFERENCES "NOTIF_ORGANIZATION"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_ORGELECTRONICADDR"
	ADD ( CONSTRAINT "FK_ORGELECTRONICADDR_ORG"
	FOREIGN KEY("ORGANIZATION_ID")
	REFERENCES "NOTIF_ORGANIZATION"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_PERSON"
	ADD ( CONSTRAINT "FK_PERSON_ORGANIZATION"
	FOREIGN KEY("ORGANIZATION_ID")
	REFERENCES "NOTIF_ORGANIZATION"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_PERSONBEACHROLE"
	ADD ( CONSTRAINT "FK_PERSONBEACHROLE_PERSON"
	FOREIGN KEY("PERSON_ID")
	REFERENCES "NOTIF_PERSON"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_PERSONBEACHROLE"
	ADD ( CONSTRAINT "FK_PERSONBEACHROLE_BEACH"
	FOREIGN KEY("BEACH_ID")
	REFERENCES "NOTIF_BEACH"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS"
	ADD ( CONSTRAINT "FK_PERSONELECTRONICADD_PERSON"
	FOREIGN KEY("PERSON_ID")
	REFERENCES "NOTIF_PERSON"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_PERSONMAILINGADDRESS"
	ADD ( CONSTRAINT "FK_PERSONMAILINGADDRESS_PERSON"
	FOREIGN KEY("PERSON_ID")
	REFERENCES "NOTIF_PERSON"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_PERSONTELEPHONE"
	ADD ( CONSTRAINT "FK_PERSONTELEPHONE_PERSON"
	FOREIGN KEY("PERSON_ID")
	REFERENCES "NOTIF_PERSON"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );
	
ALTER TABLE "NOTIF_BEACHCRITERION"
	ADD ( CONSTRAINT "FK_BEACHCRITERION_BEACH"
	FOREIGN KEY("BEACH_ID")
	REFERENCES "NOTIF_BEACH"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

ALTER TABLE "NOTIF_STATECONTACT"
	ADD ( CONSTRAINT "FK_STATECONTACT_ORGANIZATION"
	FOREIGN KEY("ORGANIZATION_ID")
	REFERENCES "NOTIF_ORGANIZATION"("ID")
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE );

-- NOTIF_PERSONTELEPHONE
CREATE OR REPLACE TRIGGER NOTIF_PERSONTELEPHONE 
  BEFORE INSERT ON NOTIF_PERSONTELEPHONE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID() 
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/
-- NOTIF_PERSONMAILINGADDRESS
CREATE OR REPLACE TRIGGER NOTIF_PERSONMAILINGADDRESS 
  BEFORE INSERT ON NOTIF_PERSONMAILINGADDRESS 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ACTIVITYREASON
CREATE OR REPLACE TRIGGER NOTIF_ACTIVITYREASON 
  BEFORE INSERT ON NOTIF_ACTIVITYREASON 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ACTIVITYINDICATOR
CREATE OR REPLACE TRIGGER NOTIF_ACTIVITYINDICATOR 
  BEFORE INSERT ON NOTIF_ACTIVITYINDICATOR 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ACTIVITYSOURCE
CREATE OR REPLACE TRIGGER NOTIF_ACTIVITYSOURCE 
  BEFORE INSERT ON NOTIF_ACTIVITYSOURCE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_BEACHACTIVITY
CREATE OR REPLACE TRIGGER NOTIF_BEACHACTIVITY 
  BEFORE INSERT ON NOTIF_BEACHACTIVITY 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_BEACHACTIVITYMONSTATION
CREATE OR REPLACE TRIGGER NOTIF_BEACHACTIVITYMONSTATION 
  BEFORE INSERT ON NOTIF_BEACHACTIVITYMONSTATION 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_BEACHPROCEDURE
CREATE OR REPLACE TRIGGER NOTIF_BEACHPROCEDURE 
  BEFORE INSERT ON NOTIF_BEACHPROCEDURE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_BEACHPROCEDURE
CREATE OR REPLACE TRIGGER NOTIF_PROCEDURE 
  BEFORE INSERT ON NOTIF_PROCEDURE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_BEACHPOLLUTION
CREATE OR REPLACE TRIGGER NOTIF_BEACHPOLLUTION 
  BEFORE INSERT ON NOTIF_BEACHPOLLUTION 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ORGANIZATION
CREATE OR REPLACE TRIGGER NOTIF_ORGANIZATION 
  BEFORE INSERT ON NOTIF_ORGANIZATION 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_BEACH
CREATE OR REPLACE TRIGGER NOTIF_BEACH 
  BEFORE INSERT ON NOTIF_BEACH 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ORGANIZATIONTELEPHONE
CREATE OR REPLACE TRIGGER NOTIF_ORGANIZATIONTELEPHONE 
  BEFORE INSERT ON NOTIF_ORGANIZATIONTELEPHONE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ORGANIZATIONMAILINGADDR
CREATE OR REPLACE TRIGGER NOTIF_ORGANIZATIONMAILINGADDR 
  BEFORE INSERT ON NOTIF_ORGANIZATIONMAILINGADDR 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_PERSONBEACHROLE
CREATE OR REPLACE TRIGGER NOTIF_PERSONBEACHROLE 
  BEFORE INSERT ON NOTIF_PERSONBEACHROLE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_PERSON
CREATE OR REPLACE TRIGGER NOTIF_PERSON 
  BEFORE INSERT ON NOTIF_PERSON 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ORGELECTRONICADDR
CREATE OR REPLACE TRIGGER NOTIF_ORGELECTRONICADDR 
  BEFORE INSERT ON NOTIF_ORGELECTRONICADDR 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_PERSONELECTRONICADDRESS
CREATE OR REPLACE TRIGGER NOTIF_PERSONELECTRONICADDRESS 
  BEFORE INSERT ON NOTIF_PERSONELECTRONICADDRESS 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_ORGANIZATIONBEACHROLE
CREATE OR REPLACE TRIGGER NOTIF_ORGANIZATIONBEACHROLE 
  BEFORE INSERT ON NOTIF_ORGANIZATIONBEACHROLE 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

-- NOTIF_YEARCOMPLETION
CREATE OR REPLACE TRIGGER NOTIF_YEARCOMPLETION 
  BEFORE INSERT ON NOTIF_YEARCOMPLETION 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

--NOTIF_BEACHCRITERION
CREATE OR REPLACE TRIGGER NOTIF_BEACHCRITERION
  BEFORE INSERT ON NOTIF_BEACHCRITERION 
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/

--NOTIF_STATECONTACT
CREATE OR REPLACE TRIGGER NOTIF_STATECONTACT
  BEFORE INSERT ON NOTIF_STATECONTACT
    FOR EACH ROW BEGIN 
      IF INSERTING 
      THEN 
        IF :NEW.ID IS NULL
         THEN SELECT SYS_GUID()  
                INTO :NEW.ID 
                FROM dual; 
        END IF; 
      END IF; 
    END;
/