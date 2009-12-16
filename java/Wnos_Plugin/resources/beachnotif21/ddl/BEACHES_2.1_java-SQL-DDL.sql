--------------------------------------------------------
--  File created - Friday-October-02-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence NOTIF_ACTIVITYINDICATOR_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ACTIVITYINDICATOR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ACTIVITYREASON_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ACTIVITYREASON_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ACTIVITYSOURCE_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ACTIVITYSOURCE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACHACTIVITY_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_BEACHACTIVITY_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACHPOLLUTION_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_BEACHPOLLUTION_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1231 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACHPROCEDURE_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_BEACHPROCEDURE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1231 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACH_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_BEACH_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 124 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGANIZATION_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ORGANIZATION_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGBEACHROLE_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ORGBEACHROLE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1149 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGELECTRONICADDR_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ORGELECTRONICADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGMAILINGADDR_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ORGMAILINGADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGTELEPHONE_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_ORGTELEPHONE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONBEACHROLE_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_PERSONBEACHROLE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1149 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONELECTRADDR_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_PERSONELECTRADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONMAILINGADDR_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_PERSONMAILINGADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONTELEPHONE_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_PERSONTELEPHONE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSON_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_PERSON_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_YEARCOMPLETION_ID_SEQ
--------------------------------------------------------
 
   --CREATE SEQUENCE  "NOTIF_YEARCOMPLETION_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 31 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------

IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ACTIVITYINDICATOR') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ACTIVITYINDICATOR
GO
 
  CREATE TABLE "NOTIF_ACTIVITYINDICATOR" 
   (	"ID" int identity(1,1) not null, 
	"ACTIVITY_ID" int, 
	"INDICATORTYPE" VARCHAR(60), 
	"INDICATORDESCRIPTION" VARCHAR(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYREASON
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ACTIVITYREASON') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ACTIVITYREASON
GO
 
  CREATE TABLE "NOTIF_ACTIVITYREASON" 
   (	"ID" int identity(1,1) not null, 
	"ACTIVITY_ID" int, 
	"REASONTYPE" varchar(60), 
	"REASONDESCRIPTION" varchar(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYSOURCE
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ACTIVITYSOURCE') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ACTIVITYSOURCE
GO
 
  CREATE TABLE "NOTIF_ACTIVITYSOURCE" 
   (	"ID" int identity(1,1) not null, 
	"ACTIVITY_ID" int, 
	"SOURCETYPE" varchar(60), 
	"SOURCEDESCRIPTION" varchar(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACH
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_BEACH') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_BEACH
GO
 
  CREATE TABLE "NOTIF_BEACH" 
   (	"ID" int identity(1,1) not null, 
	"BEACHIDENTIFIER" varchar(8), 
	"BEACHNAME" varchar(60), 
	"BEACHDESCRIPTION" varchar(255), 
	"BEACHCOMMENT" varchar(255), 
	"BEACHSTATECODE" CHAR(2), 
	"BEACHFIPSCOUNTYCODE" varchar(5), 
	"BEACHACCESSTYPE" varchar(12), 
	"BEACHACCESSCOMMENT" varchar(255), 
	"EFFECTIVEYEAR" varchar(4), 
	"EXTENTLENGTHMEASURE" int, 
	"EXTENTUNITOFMEASURE" varchar(12), 
	"SWIMSEASONSTARTDATE" varchar(25), 
	"SWIMSEASONENDDATE" varchar(25), 
	"SWIMSEASONLENGTH" int, 
	"SWIMSEASONUNITOFMEASURE" varchar(12), 
	"SWIMSEASONFREQUENCYMEASURE" int, 
	"OFFSEASONFREQUENCYMEASURE" int, 
	"MONITORINGFREQUNITOFMEASURE" varchar(255), 
	"MONITOREDIRREGULARLY" varchar(5), 
	"MONITOREDIRREGULARLYCOMMENT" varchar(255), 
	"BEACHTIERRANKING" varchar(1), 
	"BEACHACTBEACHINDICATOR" varchar(5), 
	"NOPOLLUTIONSOURCES" varchar(5), 
	"POLLUTIONSOURCESUNINVESTIGATED" varchar(5), 
	"WATERBODYNAMECODE" varchar(25), 
	"WATERBODYTYPECODE" varchar(25), 
	"STARTLATMEASURE" varchar(25), 
	"STARTLONGMEASURE" varchar(25), 
	"ENDLATMEASURE" varchar(25), 
	"ENDLONGMEASURE" varchar(25), 
	"SOURCEMAPSCALE" varchar(25), 
	"HORIZCOLLMETHOD" varchar(25), 
	"HORIZCOLLDATUM" varchar(25)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHACTIVITY
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_BEACHACTIVITY') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_BEACHACTIVITY
GO
 
  CREATE TABLE "NOTIF_BEACHACTIVITY" 
   (	"ID" int identity(1,1) not null, 
	"BEACH_ID" int, 
	"ACTIVITYTYPECODE" varchar(12), 
	"ACTIVITYNAME" varchar(60), 
	"ACTUALSTARTDATE" varchar(25), 
	"ACTUALSTOPDATE" varchar(25), 
	"MONITORINGSTATIONIDENTIFIER" varchar(65), 
	"ACTIVITYDESCRIPTION" varchar(255), 
	"ACTIVITYCOMMENT" varchar(255), 
	"EXTENTSTARTMEASURE" int, 
	"EXTENTLENGTHMEASURE" int, 
	"EXTENTUNITOFMEASURE" varchar(255), 
	"SENTTOEPA" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHACTIVITYDATES
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_BEACHACTIVITYDATES') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_BEACHACTIVITYDATES
GO
 
  CREATE TABLE "NOTIF_BEACHACTIVITYDATES" 
   (	"BEACH_ID" varchar(8), 
	"STARTDATE" DATETIME, 
	"ENDDATE" DATETIME
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHPOLLUTION
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_BEACHPOLLUTION') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_BEACHPOLLUTION
GO
 
  CREATE TABLE "NOTIF_BEACHPOLLUTION" 
   (	"ID" int identity(1,1) not null, 
	"BEACH_ID" int, 
	"POLLUTIONSOURCECODE" varchar(12), 
	"POLLUTIONSOURCEDESCRIPTION" varchar(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHPROCEDURE
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_BEACHPROCEDURE') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_BEACHPROCEDURE
GO
 
  CREATE TABLE "NOTIF_BEACHPROCEDURE" 
   (	"ID" int identity(1,1) not null, 
	"BEACH_ID" int, 
	"PROCEDUREIDENTIFIER" varchar(8), 
	"PROCEDURETYPECODE" varchar(12), 
	"PROCEDUREDESCRIPTION" varchar(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATION
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ORGANIZATION') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ORGANIZATION
GO
 
  CREATE TABLE "NOTIF_ORGANIZATION" 
   (	"ID" int identity(1,1) not null, 
	"ORGANIZATIONIDENTIFIER" varchar(12), 
	"ORGANIZATIONTYPECODE" varchar(12), 
	"ORGANIZATIONNAME" varchar(60), 
	"ORGANIZATIONDESCRIPTION" varchar(255), 
	"ORGANIZATIONABBREVIATION" varchar(30)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ORGANIZATIONBEACHROLE') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ORGANIZATIONBEACHROLE
GO
 
  CREATE TABLE "NOTIF_ORGANIZATIONBEACHROLE" 
   (	"ID" int identity(1,1) not null, 
	"BEACH_ID" int, 
	"ORGANIZATION_ID" int, 
	"ROLETYPECODE" varchar(12), 
	"ROLEEFFECTIVEDATE" varchar(25), 
	"ROLESTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONMAILINGADDR
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ORGANIZATIONMAILINGADDR') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ORGANIZATIONMAILINGADDR
GO
 
  CREATE TABLE "NOTIF_ORGANIZATIONMAILINGADDR" 
   (	"ID" int identity(1,1) not null, 
	"ORGANIZATION_ID" int, 
	"MAILINGADDRTYPECODE" varchar(12), 
	"MAILINGADDRLINE1" varchar(100), 
	"MAILINGADDRLINE2" varchar(100), 
	"MAILINGADDRLINE3" varchar(100), 
	"MAILINGADDRCITY" varchar(50), 
	"STATECODE" CHAR(2), 
	"ZIPCODE" varchar(12), 
	"MAILINGADDREFFECTIVEDATE" varchar(25), 
	"MAILINGADDRSTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ORGANIZATIONTELEPHONE') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ORGANIZATIONTELEPHONE
GO
 
  CREATE TABLE "NOTIF_ORGANIZATIONTELEPHONE" 
   (	"ID" int identity(1,1) not null, 
	"ORGANIZATION_ID" int, 
	"TELEPHONETYPECODE" varchar(12), 
	"TELEPHONEint" varchar(12), 
	"TELEPHONEEFFECTIVEDATE" varchar(25), 
	"TELEPHONESTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGELECTRONICADDR
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_ORGELECTRONICADDR') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_ORGELECTRONICADDR
GO
 
  CREATE TABLE "NOTIF_ORGELECTRONICADDR" 
   (	"ID" int identity(1,1) not null, 
	"ORGANIZATION_ID" int, 
	"ELECTRONICADDRTYPECODE" varchar(12), 
	"ELECTRONICADDR" varchar(255), 
	"ELECTRONICADDREFFDATE" varchar(25), 
	"ELECTRONICADDRSTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSON
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_PERSON') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_PERSON
GO
 
  CREATE TABLE "NOTIF_PERSON" 
   (	"ID" int identity(1,1) not null, 
	"ORGANIZATION_ID" int, 
	"PERSONIDENTIFIER" varchar(12), 
	"PERSONSTATUS" varchar(8), 
	"FIRSTNAME" varchar(50), 
	"LASTNAME" varchar(50), 
	"MIDDLEINITIAL" varchar(2), 
	"SUFFIX" varchar(5), 
	"TITLE" varchar(60)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONBEACHROLE
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_PERSONBEACHROLE') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_PERSONBEACHROLE
GO
 
  CREATE TABLE "NOTIF_PERSONBEACHROLE" 
   (	"ID" int identity(1,1) not null, 
	"BEACH_ID" int, 
	"PERSON_ID" int, 
	"ROLETYPECODE" varchar(12), 
	"ROLEEFFECTIVEDATE" varchar(25), 
	"ROLESTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONELECTRONICADDRESS
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_PERSONELECTRONICADDRESS') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_PERSONELECTRONICADDRESS
GO
 
  CREATE TABLE "NOTIF_PERSONELECTRONICADDRESS" 
   (	"ID" int identity(1,1) not null, 
	"PERSON_ID" int, 
	"ELECTRONICADDRESSTYPECODE" varchar(12), 
	"ELECTRONICADDRESS" varchar(255), 
	"ELECTRONICADDRESSEFFECTIVEDATE" varchar(25), 
	"ELECTRONICADDRESSSTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_PERSONMAILINGADDRESS') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_PERSONMAILINGADDRESS
GO
 
  CREATE TABLE "NOTIF_PERSONMAILINGADDRESS" 
   (	"ID" int identity(1,1) not null, 
	"PERSON_ID" int, 
	"MAILINGADDRTYPECODE" varchar(12), 
	"MAILINGADDRLINE1" varchar(100), 
	"MAILINGADDRLINE2" varchar(100), 
	"MAILINGADDRLINE3" varchar(100), 
	"MAILINGADDRCITY" varchar(50), 
	"STATECODE" CHAR(2), 
	"ZIPCODE" varchar(12), 
	"MAILINGADDREFFECTIVEDATE" varchar(25), 
	"MAILINGADDRSTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONTELEPHONE
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_PERSONTELEPHONE') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_PERSONTELEPHONE
GO
 
  CREATE TABLE "NOTIF_PERSONTELEPHONE" 
   (	"ID" int identity(1,1) not null, 
	"PERSON_ID" int, 
	"TELEPHONETYPECODE" varchar(12), 
	"TELEPHONEint" varchar(12), 
	"TELEPHONEEFFECTIVEDATE" varchar(25), 
	"TELEPHONESTATUS" varchar(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_YEARCOMPLETION
--------------------------------------------------------
IF  EXISTS (SELECT * 
			  FROM sys.objects 
			 WHERE object_id = OBJECT_ID(N'NOTIF_YEARCOMPLETION') 
			   AND TYPE IN (N'U'))

DROP TABLE NOTIF_YEARCOMPLETION
GO
 
  CREATE TABLE "NOTIF_YEARCOMPLETION" 
   (	"ID" int identity(1,1) not null, 
	"COMPLETIONYEAR" int, 
	"NOTIFICATIONDATACOMPLETIONIND" varchar(5), 
	"MONITORINGDATACOMPLETIONIND" varchar(5), 
	"LOCATIONDATACOMPLETIONIND" varchar(5)
   ) ;
--------------------------------------------------------
--  DDL for Index NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ACTIVITYINDICATOR" ON "NOTIF_ACTIVITYINDICATOR" ("ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_ACTIVITYREASON
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ACTIVITYREASON" ON "NOTIF_ACTIVITYREASON" ("ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_ACTIVITYSOURCE
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ACTIVITYSOURCE" ON "NOTIF_ACTIVITYSOURCE" ("ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_BEACHACTIVITY
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_BEACHACTIVITY" ON "NOTIF_BEACHACTIVITY" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_BEACHPOLLUTION
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_BEACHPOLLUTION" ON "NOTIF_BEACHPOLLUTION" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_BEACHPROCEDURE
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_BEACHPROCEDURE" ON "NOTIF_BEACHPROCEDURE" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ORGANIZATIONBEACHROLE" ON "NOTIF_ORGANIZATIONBEACHROLE" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_ORGANIZATIONMAILINGADDR
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ORGANIZATIONMAILINGADDR" ON "NOTIF_ORGANIZATIONMAILINGADDR" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ORGANIZATIONTELEPHONE" ON "NOTIF_ORGANIZATIONTELEPHONE" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_ORGELECTRONICADDR
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_ORGELECTRONICADDR" ON "NOTIF_ORGELECTRONICADDR" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_PERSON
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_PERSON" ON "NOTIF_PERSON" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_PERSONBEACHROLE
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_PERSONBEACHROLE" ON "NOTIF_PERSONBEACHROLE" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_PERSONELECTRONICADDRESS
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_PERSONELECTRONICADDRESS" ON "NOTIF_PERSONELECTRONICADDRESS" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_PERSONMAILINGADDRESS" ON "NOTIF_PERSONMAILINGADDRESS" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_PERSONTELEPHONE
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_PERSONTELEPHONE" ON "NOTIF_PERSONTELEPHONE" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index NOTIF_SENTTOEPA
--------------------------------------------------------
 
  CREATE INDEX "NOTIF_SENTTOEPA" ON "NOTIF_BEACHACTIVITY" ("SENTTOEPA") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ACTIVITYINDICATOR" ON "NOTIF_ACTIVITYINDICATOR" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ACTIVITYREASON
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ACTIVITYREASON" ON "NOTIF_ACTIVITYREASON" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ACTIVITYSOURCE
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ACTIVITYSOURCE" ON "NOTIF_ACTIVITYSOURCE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_BEACH
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_BEACH" ON "NOTIF_BEACH" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_BEACHACTIVITY
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_BEACHACTIVITY" ON "NOTIF_BEACHACTIVITY" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_BEACHPOLLUTION
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_BEACHPOLLUTION" ON "NOTIF_BEACHPOLLUTION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_BEACHPROCEDURE
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_BEACHPROCEDURE" ON "NOTIF_BEACHPROCEDURE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ORGANIZATION
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ORGANIZATION" ON "NOTIF_ORGANIZATION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ORGANIZATIONBEACHROLE" ON "NOTIF_ORGANIZATIONBEACHROLE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ORGANIZATIONTELEPHONE" ON "NOTIF_ORGANIZATIONTELEPHONE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ORGELECTRONICADDR
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ORGELECTRONICADDR" ON "NOTIF_ORGELECTRONICADDR" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_ORGMAILINGADDR
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_ORGMAILINGADDR" ON "NOTIF_ORGANIZATIONMAILINGADDR" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_PERSON
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_PERSON" ON "NOTIF_PERSON" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_PERSONBEACHROLE
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_PERSONBEACHROLE" ON "NOTIF_PERSONBEACHROLE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_PERSONELECTRONICADDR
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_PERSONELECTRONICADDR" ON "NOTIF_PERSONELECTRONICADDRESS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_PERSONMAILINGADDRESS" ON "NOTIF_PERSONMAILINGADDRESS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_PERSONTELEPHONE
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_PERSONTELEPHONE" ON "NOTIF_PERSONTELEPHONE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIF_YEARCOMPLETION
--------------------------------------------------------
 
  CREATE UNIQUE INDEX "PK_NOTIF_YEARCOMPLETION" ON "NOTIF_YEARCOMPLETION" ("ID") 