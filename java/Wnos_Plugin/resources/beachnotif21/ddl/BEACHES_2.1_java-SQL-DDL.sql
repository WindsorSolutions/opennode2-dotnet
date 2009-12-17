/* This script creates the staging tables for the Beach Notification v2.1 data flow for the Java OpenNode2 */

/* SQL Server */

CREATE TABLE NOTIF_ACTIVITYINDICATOR ( 
	ID                  	INTEGER NOT NULL IDENTITY (1, 1),
	ACTIVITY_ID         	INTEGER NOT NULL,
	INDICATORTYPE       	VARCHAR(60) NOT NULL,
	INDICATORDESCRIPTION	VARCHAR(255) NULL 
	)

CREATE TABLE NOTIF_ACTIVITYREASON ( 
	ID               	INTEGER NOT NULL IDENTITY (1, 1),
	ACTIVITY_ID      	INTEGER NOT NULL,
	REASONTYPE       	VARCHAR(60) NOT NULL,
	REASONDESCRIPTION	VARCHAR(255) NULL 
	)

CREATE TABLE NOTIF_ACTIVITYSOURCE ( 
	ID               	INTEGER NOT NULL IDENTITY (1, 1),
	ACTIVITY_ID      	INTEGER NOT NULL,
	SOURCETYPE       	VARCHAR(60) NOT NULL,
	SOURCEDESCRIPTION	VARCHAR(255) NULL 
	)

CREATE TABLE NOTIF_BEACH ( 
	ID                            	INTEGER NOT NULL IDENTITY (1, 1),
	BEACHIDENTIFIER               	VARCHAR(8) NOT NULL,
	BEACHNAME                     	VARCHAR(60) NOT NULL,
	BEACHDESCRIPTION              	VARCHAR(255) NOT NULL,
	BEACHCOMMENT                  	VARCHAR(255) NULL,
	BEACHSTATECODE                	CHAR(2) NOT NULL,
	BEACHFIPSCOUNTYCODE           	VARCHAR(5) NOT NULL,
	BEACHACCESSTYPE               	VARCHAR(12) NOT NULL,
	BEACHACCESSCOMMENT            	VARCHAR(255) NULL,
	EFFECTIVEYEAR                 	VARCHAR(4) NOT NULL,
	EXTENTLENGTHMEASURE           	INTEGER NOT NULL,
	EXTENTUNITOFMEASURE           	VARCHAR(12) NOT NULL,
	SWIMSEASONSTARTDATE           	VARCHAR(25) NULL,
	SWIMSEASONENDDATE             	VARCHAR(25) NULL,
	SWIMSEASONLENGTH              	INTEGER NULL,
	SWIMSEASONUNITOFMEASURE       	VARCHAR(12) NULL,
	SWIMSEASONFREQUENCYMEASURE    	INTEGER NOT NULL,
	OFFSEASONFREQUENCYMEASURE     	INTEGER NOT NULL,
	MONITORINGFREQUNITOFMEASURE   	VARCHAR(255) NOT NULL,
	MONITOREDIRREGULARLY          	VARCHAR(5) NOT NULL,
	MONITOREDIRREGULARLYCOMMENT   	VARCHAR(255) NULL,
	BEACHTIERRANKING              	VARCHAR(1) NOT NULL,
	BEACHACTBEACHINDICATOR        	VARCHAR(5) NOT NULL,
	NOPOLLUTIONSOURCES            	VARCHAR(5) NULL,
	POLLUTIONSOURCESUNINVESTIGATED	VARCHAR(5) NULL,
	WATERBODYNAMECODE             	VARCHAR(25) NULL,
	WATERBODYTYPECODE             	VARCHAR(25) NULL,
	STARTLATMEASURE               	VARCHAR(25) NULL,
	STARTLONGMEASURE              	VARCHAR(25) NULL,
	ENDLATMEASURE                 	VARCHAR(25) NULL,
	ENDLONGMEASURE                	VARCHAR(25) NULL,
	SOURCEMAPSCALE                	VARCHAR(25) NULL,
	HORIZCOLLMETHOD               	VARCHAR(25) NULL,
	HORIZCOLLDATUM                	VARCHAR(25) NULL 
	)

CREATE TABLE NOTIF_BEACHACTIVITY ( 
	ID                         	INTEGER NOT NULL IDENTITY (1, 1),
	BEACH_ID                   	INTEGER NOT NULL,
	ACTIVITYTYPECODE           	VARCHAR(12) NOT NULL,
	ACTIVITYNAME               	VARCHAR(60) NOT NULL,
	ACTUALSTARTDATE            	VARCHAR(25) NOT NULL,
	ACTUALSTOPDATE             	VARCHAR(25) NOT NULL,
	MONITORINGSTATIONIDENTIFIER	VARCHAR(65) NULL,
	ACTIVITYDESCRIPTION        	VARCHAR(255) NULL,
	ACTIVITYCOMMENT            	VARCHAR(255) NULL,
	EXTENTSTARTMEASURE         	INTEGER NULL,
	EXTENTLENGTHMEASURE        	INTEGER NULL,
	EXTENTUNITOFMEASURE        	VARCHAR(255) NULL,
	SENTTOEPA                  	CHAR(1) NULL 
	)

CREATE TABLE NOTIF_BEACHPOLLUTION ( 
	ID                        	INTEGER NOT NULL IDENTITY (1, 1),
	BEACH_ID                  	INTEGER NOT NULL,
	POLLUTIONSOURCECODE       	VARCHAR(12) NOT NULL,
	POLLUTIONSOURCEDESCRIPTION	VARCHAR(255) NULL 
	)

CREATE TABLE NOTIF_BEACHPROCEDURE ( 
	ID                  	INTEGER NOT NULL IDENTITY (1, 1),
	BEACH_ID            	INTEGER NOT NULL,
	PROCEDUREIDENTIFIER 	VARCHAR(8) NOT NULL,
	PROCEDURETYPECODE   	VARCHAR(12) NOT NULL,
	PROCEDUREDESCRIPTION	VARCHAR(255) NOT NULL 
	)

CREATE TABLE NOTIF_ORGANIZATION ( 
	ID                      	INTEGER NOT NULL IDENTITY (1, 1),
	ORGANIZATIONIDENTIFIER  	VARCHAR(12) NOT NULL,
	ORGANIZATIONTYPECODE    	VARCHAR(12) NOT NULL,
	ORGANIZATIONNAME        	VARCHAR(60) NOT NULL,
	ORGANIZATIONDESCRIPTION 	VARCHAR(255) NULL,
	ORGANIZATIONABBREVIATION	VARCHAR(30) NULL 
	)

CREATE TABLE NOTIF_ORGANIZATIONBEACHROLE ( 
	ID               	INTEGER NOT NULL IDENTITY (1, 1),
	BEACH_ID         	INTEGER NOT NULL,
	ORGANIZATION_ID  	INTEGER NOT NULL,
	ROLETYPECODE     	VARCHAR(12) NOT NULL,
	ROLEEFFECTIVEDATE	VARCHAR(25) NOT NULL,
	ROLESTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_ORGANIZATIONMAILINGADDR ( 
	ID                      	INTEGER NOT NULL IDENTITY (1, 1),
	ORGANIZATION_ID         	INTEGER NOT NULL,
	MAILINGADDRTYPECODE     	VARCHAR(12) NOT NULL,
	MAILINGADDRLINE1        	VARCHAR(100) NOT NULL,
	MAILINGADDRLINE2        	VARCHAR(100) NULL,
	MAILINGADDRLINE3        	VARCHAR(100) NULL,
	MAILINGADDRCITY         	VARCHAR(50) NOT NULL,
	STATECODE               	CHAR(2) NOT NULL,
	ZIPCODE                 	VARCHAR(12) NOT NULL,
	MAILINGADDREFFECTIVEDATE	VARCHAR(25) NOT NULL,
	MAILINGADDRSTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_ORGANIZATIONTELEPHONE ( 
	ID                    	INTEGER NOT NULL IDENTITY (1, 1),
	ORGANIZATION_ID       	INTEGER NOT NULL,
	TELEPHONETYPECODE     	VARCHAR(12) NOT NULL,
	TELEPHONEINTEGER       	VARCHAR(12) NOT NULL,
	TELEPHONEEFFECTIVEDATE	VARCHAR(25) NOT NULL,
	TELEPHONESTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_ORGELECTRONICADDR ( 
	ID                    	INTEGER NOT NULL IDENTITY (1, 1),
	ORGANIZATION_ID       	INTEGER NOT NULL,
	ELECTRONICADDRTYPECODE	VARCHAR(12) NOT NULL,
	ELECTRONICADDR        	VARCHAR(255) NOT NULL,
	ELECTRONICADDREFFDATE 	VARCHAR(25) NOT NULL,
	ELECTRONICADDRSTATUS  	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_PERSON ( 
	ID              	INTEGER NOT NULL IDENTITY (1, 1),
	ORGANIZATION_ID 	INTEGER NOT NULL,
	PERSONIDENTIFIER	VARCHAR(12) NOT NULL,
	PERSONSTATUS    	VARCHAR(8) NOT NULL,
	FIRSTNAME       	VARCHAR(50) NOT NULL,
	LASTNAME        	VARCHAR(50) NOT NULL,
	MIDDLEINITIAL   	VARCHAR(2) NULL,
	SUFFIX          	VARCHAR(5) NULL,
	TITLE           	VARCHAR(60) NULL 
	)

CREATE TABLE NOTIF_PERSONBEACHROLE ( 
	ID               	INTEGER NOT NULL IDENTITY (1, 1),
	BEACH_ID         	INTEGER NOT NULL,
	PERSON_ID        	INTEGER NOT NULL,
	ROLETYPECODE     	VARCHAR(12) NOT NULL,
	ROLEEFFECTIVEDATE	VARCHAR(25) NOT NULL,
	ROLESTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_PERSONELECTRONICADDRESS ( 
	ID                            	INTEGER NOT NULL IDENTITY (1, 1),
	PERSON_ID                     	INTEGER NOT NULL,
	ELECTRONICADDRESSTYPECODE     	VARCHAR(12) NOT NULL,
	ELECTRONICADDRESS             	VARCHAR(255) NOT NULL,
	ELECTRONICADDRESSEFFECTIVEDATE	VARCHAR(25) NOT NULL,
	ELECTRONICADDRESSSTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_PERSONMAILINGADDRESS ( 
	ID                      	INTEGER NOT NULL IDENTITY (1, 1),
	PERSON_ID               	INTEGER NOT NULL,
	MAILINGADDRTYPECODE     	VARCHAR(12) NOT NULL,
	MAILINGADDRLINE1        	VARCHAR(100) NOT NULL,
	MAILINGADDRLINE2        	VARCHAR(100) NULL,
	MAILINGADDRLINE3        	VARCHAR(100) NULL,
	MAILINGADDRCITY         	VARCHAR(50) NOT NULL,
	STATECODE               	CHAR(2) NOT NULL,
	ZIPCODE                 	VARCHAR(12) NOT NULL,
	MAILINGADDREFFECTIVEDATE	VARCHAR(25) NOT NULL,
	MAILINGADDRSTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_PERSONTELEPHONE ( 
	ID                    	INTEGER NOT NULL IDENTITY (1, 1),
	PERSON_ID             	INTEGER NOT NULL,
	TELEPHONETYPECODE     	VARCHAR(12) NOT NULL,
	TELEPHONEINTEGER       	VARCHAR(12) NOT NULL,
	TELEPHONEEFFECTIVEDATE	VARCHAR(25) NOT NULL,
	TELEPHONESTATUS       	VARCHAR(8) NOT NULL 
	)

CREATE TABLE NOTIF_YEARCOMPLETION ( 
	ID                           	INTEGER NOT NULL IDENTITY (1, 1),
	COMPLETIONYEAR               	INTEGER NOT NULL,
	NOTIFICATIONDATACOMPLETIONIND	VARCHAR(5) NULL,
	MONITORINGDATACOMPLETIONIND  	VARCHAR(5) NULL,
	LOCATIONDATACOMPLETIONIND    	VARCHAR(5) NULL 
	)


ALTER TABLE NOTIF_ACTIVITYINDICATOR
	ADD CONSTRAINT PK_NOTIF_ACTIVITYINDICATOR
	PRIMARY KEY (ID)


ALTER TABLE NOTIF_ACTIVITYREASON
	ADD CONSTRAINT PK_NOTIF_ACTIVITYREASON
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_ACTIVITYSOURCE
	ADD CONSTRAINT PK_NOTIF_ACTIVITYSOURCE
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_BEACH
	ADD CONSTRAINT PK_NOTIF_BEACH
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_BEACHACTIVITY
	ADD CONSTRAINT PK_NOTIF_BEACHACTIVITY
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_BEACHPOLLUTION
	ADD CONSTRAINT PK_NOTIF_BEACHPOLLUTION
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_BEACHPROCEDURE
	ADD CONSTRAINT PK_NOTIF_BEACHPROCEDURE
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_ORGANIZATION
	ADD CONSTRAINT PK_NOTIF_ORGANIZATION
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE
	ADD CONSTRAINT PK_NOTIF_ORGANIZATIONBEACHROLE
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_ORGANIZATIONMAILINGADDR
	ADD CONSTRAINT PK_NOTIF_ORGMAILINGADDR
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_ORGANIZATIONTELEPHONE
	ADD CONSTRAINT PK_NOTIF_ORGANIZATIONTELEPHONE
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_ORGELECTRONICADDR
	ADD CONSTRAINT PK_NOTIF_ORGELECTRONICADDR
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_PERSON
	ADD CONSTRAINT PK_NOTIF_PERSON
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_PERSONBEACHROLE
	ADD CONSTRAINT PK_NOTIF_PERSONBEACHROLE
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_PERSONELECTRONICADDRESS
	ADD CONSTRAINT PK_NOTIF_PERSONELECTRONICADDR
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_PERSONMAILINGADDRESS
	ADD CONSTRAINT PK_NOTIF_PERSONMAILINGADDRESS
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_PERSONTELEPHONE
	ADD CONSTRAINT PK_NOTIF_PERSONTELEPHONE
	PRIMARY KEY (ID)
	

ALTER TABLE NOTIF_YEARCOMPLETION
	ADD CONSTRAINT PK_NOTIF_YEARCOMPLETION
	PRIMARY KEY (ID)
	



ALTER TABLE NOTIF_ACTIVITYINDICATOR
	ADD CONSTRAINT FK_ACTIVITYINDICATOR_BEACHACT
	FOREIGN KEY(ACTIVITY_ID)
	REFERENCES NOTIF_BEACHACTIVITY(ID)


ALTER TABLE NOTIF_ACTIVITYREASON
	ADD CONSTRAINT FK_ACTIVITYREASON_BEACHACT
	FOREIGN KEY(ACTIVITY_ID)
	REFERENCES NOTIF_BEACHACTIVITY(ID)


ALTER TABLE NOTIF_ACTIVITYSOURCE
	ADD CONSTRAINT FK_ACTIVITYSOURCE_BEACHACT
	FOREIGN KEY(ACTIVITY_ID)
	REFERENCES NOTIF_BEACHACTIVITY(ID)


ALTER TABLE NOTIF_BEACHACTIVITY
	ADD CONSTRAINT FK_BEACHACTIVITY_BEACH
	FOREIGN KEY(BEACH_ID)
	REFERENCES NOTIF_BEACH(ID)


ALTER TABLE NOTIF_BEACHPOLLUTION
	ADD CONSTRAINT FK_BEACHPOLLUTION_BEACH
	FOREIGN KEY(BEACH_ID)
	REFERENCES NOTIF_BEACH(ID)


ALTER TABLE NOTIF_BEACHPROCEDURE
	ADD CONSTRAINT FK_BEACHPROCEDURE_BEACH
	FOREIGN KEY(BEACH_ID)
	REFERENCES NOTIF_BEACH(ID)


ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE
	ADD CONSTRAINT FK_ORGANIZATIONBEACHROLE_ORG
	FOREIGN KEY(ORGANIZATION_ID)
	REFERENCES NOTIF_ORGANIZATION(ID)


ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE
	ADD CONSTRAINT FK_ORGANIZATIONBEACHROLE_BEACH
	FOREIGN KEY(BEACH_ID)
	REFERENCES NOTIF_BEACH(ID)


ALTER TABLE NOTIF_ORGANIZATIONMAILINGADDR
	ADD CONSTRAINT FK_ORGANIZATION_ORGMAILINGADDR
	FOREIGN KEY(ORGANIZATION_ID)
	REFERENCES NOTIF_ORGANIZATION(ID)


ALTER TABLE NOTIF_ORGANIZATIONTELEPHONE
	ADD CONSTRAINT FK_ORGANIZATIONTELEPHONE_ORG
	FOREIGN KEY(ORGANIZATION_ID)
	REFERENCES NOTIF_ORGANIZATION(ID)


ALTER TABLE NOTIF_ORGELECTRONICADDR
	ADD CONSTRAINT FK_ORGELECTRONICADDR_ORG
	FOREIGN KEY(ORGANIZATION_ID)
	REFERENCES NOTIF_ORGANIZATION(ID)


ALTER TABLE NOTIF_PERSON
	ADD CONSTRAINT FK_PERSON_ORGANIZATION
	FOREIGN KEY(ORGANIZATION_ID)
	REFERENCES NOTIF_ORGANIZATION(ID)


ALTER TABLE NOTIF_PERSONBEACHROLE
	ADD CONSTRAINT FK_PERSONBEACHROLE_PERSON
	FOREIGN KEY(PERSON_ID)
	REFERENCES NOTIF_PERSON(ID)


ALTER TABLE NOTIF_PERSONBEACHROLE
	ADD CONSTRAINT FK_PERSONBEACHROLE_BEACH
	FOREIGN KEY(BEACH_ID)
	REFERENCES NOTIF_BEACH(ID)


ALTER TABLE NOTIF_PERSONELECTRONICADDRESS
	ADD CONSTRAINT FK_PERSONELECTRONICADD_PERSON
	FOREIGN KEY(PERSON_ID)
	REFERENCES NOTIF_PERSON(ID)


ALTER TABLE NOTIF_PERSONMAILINGADDRESS
	ADD CONSTRAINT FK_PERSONMAILINGADDRESS_PERSON
	FOREIGN KEY(PERSON_ID)
	REFERENCES NOTIF_PERSON(ID)


ALTER TABLE NOTIF_PERSONTELEPHONE
	ADD CONSTRAINT FK_PERSONTELEPHONE_PERSON
	FOREIGN KEY(PERSON_ID)
	REFERENCES NOTIF_PERSON(ID)


