--------------------------------------------------------
--  File created - Friday-October-02-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence NOTIF_ACTIVITYINDICATOR_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ACTIVITYINDICATOR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ACTIVITYREASON_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ACTIVITYREASON_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ACTIVITYSOURCE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ACTIVITYSOURCE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACHACTIVITY_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_BEACHACTIVITY_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 162 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACHPOLLUTION_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_BEACHPOLLUTION_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1231 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACHPROCEDURE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_BEACHPROCEDURE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1231 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_BEACH_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_BEACH_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 124 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGANIZATION_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ORGANIZATION_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGBEACHROLE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ORGBEACHROLE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1149 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGELECTRONICADDR_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ORGELECTRONICADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGMAILINGADDR_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ORGMAILINGADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_ORGTELEPHONE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_ORGTELEPHONE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONBEACHROLE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_PERSONBEACHROLE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1149 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONELECTRADDR_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_PERSONELECTRADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONMAILINGADDR_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_PERSONMAILINGADDR_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSONTELEPHONE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_PERSONTELEPHONE_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_PERSON_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_PERSON_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 29 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence NOTIF_YEARCOMPLETION_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "NOTIF_YEARCOMPLETION_ID_SEQ"  MINVALUE 0 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 31 NOCACHE  ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------

  CREATE TABLE "NOTIF_ACTIVITYINDICATOR" 
   (	"ID" NUMBER, 
	"ACTIVITY_ID" NUMBER, 
	"INDICATORTYPE" VARCHAR2(60), 
	"INDICATORDESCRIPTION" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYREASON
--------------------------------------------------------

  CREATE TABLE "NOTIF_ACTIVITYREASON" 
   (	"ID" NUMBER, 
	"ACTIVITY_ID" NUMBER, 
	"REASONTYPE" VARCHAR2(60), 
	"REASONDESCRIPTION" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYSOURCE
--------------------------------------------------------

  CREATE TABLE "NOTIF_ACTIVITYSOURCE" 
   (	"ID" NUMBER, 
	"ACTIVITY_ID" NUMBER, 
	"SOURCETYPE" VARCHAR2(60), 
	"SOURCEDESCRIPTION" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACH
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACH" 
   (	"ID" NUMBER, 
	"BEACHIDENTIFIER" VARCHAR2(8), 
	"BEACHNAME" VARCHAR2(60), 
	"BEACHDESCRIPTION" VARCHAR2(255), 
	"BEACHCOMMENT" VARCHAR2(255), 
	"BEACHSTATECODE" CHAR(2), 
	"BEACHFIPSCOUNTYCODE" VARCHAR2(5), 
	"BEACHACCESSTYPE" VARCHAR2(12), 
	"BEACHACCESSCOMMENT" VARCHAR2(255), 
	"EFFECTIVEYEAR" VARCHAR2(4), 
	"EXTENTLENGTHMEASURE" NUMBER, 
	"EXTENTUNITOFMEASURE" VARCHAR2(12), 
	"SWIMSEASONSTARTDATE" VARCHAR2(25), 
	"SWIMSEASONENDDATE" VARCHAR2(25), 
	"SWIMSEASONLENGTH" NUMBER, 
	"SWIMSEASONUNITOFMEASURE" VARCHAR2(12), 
	"SWIMSEASONFREQUENCYMEASURE" NUMBER, 
	"OFFSEASONFREQUENCYMEASURE" NUMBER, 
	"MONITORINGFREQUNITOFMEASURE" VARCHAR2(255), 
	"MONITOREDIRREGULARLY" VARCHAR2(5), 
	"MONITOREDIRREGULARLYCOMMENT" VARCHAR2(255), 
	"BEACHTIERRANKING" VARCHAR2(1), 
	"BEACHACTBEACHINDICATOR" VARCHAR2(5), 
	"NOPOLLUTIONSOURCES" VARCHAR2(5), 
	"POLLUTIONSOURCESUNINVESTIGATED" VARCHAR2(5), 
	"WATERBODYNAMECODE" VARCHAR2(25), 
	"WATERBODYTYPECODE" VARCHAR2(25), 
	"STARTLATMEASURE" VARCHAR2(25), 
	"STARTLONGMEASURE" VARCHAR2(25), 
	"ENDLATMEASURE" VARCHAR2(25), 
	"ENDLONGMEASURE" VARCHAR2(25), 
	"SOURCEMAPSCALE" VARCHAR2(25), 
	"HORIZCOLLMETHOD" VARCHAR2(25), 
	"HORIZCOLLDATUM" VARCHAR2(25)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHACTIVITY
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHACTIVITY" 
   (	"ID" NUMBER, 
	"BEACH_ID" NUMBER, 
	"ACTIVITYTYPECODE" VARCHAR2(12), 
	"ACTIVITYNAME" VARCHAR2(60), 
	"ACTUALSTARTDATE" VARCHAR2(25), 
	"ACTUALSTOPDATE" VARCHAR2(25), 
	"MONITORINGSTATIONIDENTIFIER" VARCHAR2(65), 
	"ACTIVITYDESCRIPTION" VARCHAR2(255), 
	"ACTIVITYCOMMENT" VARCHAR2(255), 
	"EXTENTSTARTMEASURE" NUMBER, 
	"EXTENTLENGTHMEASURE" NUMBER, 
	"EXTENTUNITOFMEASURE" VARCHAR2(255), 
	"SENTTOEPA" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHACTIVITYDATES
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHACTIVITYDATES" 
   (	"BEACH_ID" VARCHAR2(8), 
	"STARTDATE" DATE, 
	"ENDDATE" DATE
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHPOLLUTION
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHPOLLUTION" 
   (	"ID" NUMBER, 
	"BEACH_ID" NUMBER, 
	"POLLUTIONSOURCECODE" VARCHAR2(12), 
	"POLLUTIONSOURCEDESCRIPTION" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHPROCEDURE
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHPROCEDURE" 
   (	"ID" NUMBER, 
	"BEACH_ID" NUMBER, 
	"PROCEDUREIDENTIFIER" VARCHAR2(8), 
	"PROCEDURETYPECODE" VARCHAR2(12), 
	"PROCEDUREDESCRIPTION" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATION
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATION" 
   (	"ID" NUMBER, 
	"ORGANIZATIONIDENTIFIER" VARCHAR2(12), 
	"ORGANIZATIONTYPECODE" VARCHAR2(12), 
	"ORGANIZATIONNAME" VARCHAR2(60), 
	"ORGANIZATIONDESCRIPTION" VARCHAR2(255), 
	"ORGANIZATIONABBREVIATION" VARCHAR2(30)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATIONBEACHROLE" 
   (	"ID" NUMBER, 
	"BEACH_ID" NUMBER, 
	"ORGANIZATION_ID" NUMBER, 
	"ROLETYPECODE" VARCHAR2(12), 
	"ROLEEFFECTIVEDATE" VARCHAR2(25), 
	"ROLESTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONMAILINGADDR
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATIONMAILINGADDR" 
   (	"ID" NUMBER, 
	"ORGANIZATION_ID" NUMBER, 
	"MAILINGADDRTYPECODE" VARCHAR2(12), 
	"MAILINGADDRLINE1" VARCHAR2(100), 
	"MAILINGADDRLINE2" VARCHAR2(100), 
	"MAILINGADDRLINE3" VARCHAR2(100), 
	"MAILINGADDRCITY" VARCHAR2(50), 
	"STATECODE" CHAR(2), 
	"ZIPCODE" VARCHAR2(12), 
	"MAILINGADDREFFECTIVEDATE" VARCHAR2(25), 
	"MAILINGADDRSTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATIONTELEPHONE" 
   (	"ID" NUMBER, 
	"ORGANIZATION_ID" NUMBER, 
	"TELEPHONETYPECODE" VARCHAR2(12), 
	"TELEPHONENUMBER" VARCHAR2(12), 
	"TELEPHONEEFFECTIVEDATE" VARCHAR2(25), 
	"TELEPHONESTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_ORGELECTRONICADDR
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGELECTRONICADDR" 
   (	"ID" NUMBER, 
	"ORGANIZATION_ID" NUMBER, 
	"ELECTRONICADDRTYPECODE" VARCHAR2(12), 
	"ELECTRONICADDR" VARCHAR2(255), 
	"ELECTRONICADDREFFDATE" VARCHAR2(25), 
	"ELECTRONICADDRSTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSON
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSON" 
   (	"ID" NUMBER, 
	"ORGANIZATION_ID" NUMBER, 
	"PERSONIDENTIFIER" VARCHAR2(12), 
	"PERSONSTATUS" VARCHAR2(8), 
	"FIRSTNAME" VARCHAR2(50), 
	"LASTNAME" VARCHAR2(50), 
	"MIDDLEINITIAL" VARCHAR2(2), 
	"SUFFIX" VARCHAR2(5), 
	"TITLE" VARCHAR2(60)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONBEACHROLE
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONBEACHROLE" 
   (	"ID" NUMBER, 
	"BEACH_ID" NUMBER, 
	"PERSON_ID" NUMBER, 
	"ROLETYPECODE" VARCHAR2(12), 
	"ROLEEFFECTIVEDATE" VARCHAR2(25), 
	"ROLESTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONELECTRONICADDRESS
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONELECTRONICADDRESS" 
   (	"ID" NUMBER, 
	"PERSON_ID" NUMBER, 
	"ELECTRONICADDRESSTYPECODE" VARCHAR2(12), 
	"ELECTRONICADDRESS" VARCHAR2(255), 
	"ELECTRONICADDRESSEFFECTIVEDATE" VARCHAR2(25), 
	"ELECTRONICADDRESSSTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONMAILINGADDRESS" 
   (	"ID" NUMBER, 
	"PERSON_ID" NUMBER, 
	"MAILINGADDRTYPECODE" VARCHAR2(12), 
	"MAILINGADDRLINE1" VARCHAR2(100), 
	"MAILINGADDRLINE2" VARCHAR2(100), 
	"MAILINGADDRLINE3" VARCHAR2(100), 
	"MAILINGADDRCITY" VARCHAR2(50), 
	"STATECODE" CHAR(2), 
	"ZIPCODE" VARCHAR2(12), 
	"MAILINGADDREFFECTIVEDATE" VARCHAR2(25), 
	"MAILINGADDRSTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONTELEPHONE
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONTELEPHONE" 
   (	"ID" NUMBER, 
	"PERSON_ID" NUMBER, 
	"TELEPHONETYPECODE" VARCHAR2(12), 
	"TELEPHONENUMBER" VARCHAR2(12), 
	"TELEPHONEEFFECTIVEDATE" VARCHAR2(25), 
	"TELEPHONESTATUS" VARCHAR2(8)
   ) ;
--------------------------------------------------------
--  DDL for Table NOTIF_YEARCOMPLETION
--------------------------------------------------------

  CREATE TABLE "NOTIF_YEARCOMPLETION" 
   (	"ID" NUMBER, 
	"COMPLETIONYEAR" NUMBER, 
	"NOTIFICATIONDATACOMPLETIONIND" VARCHAR2(5), 
	"MONITORINGDATACOMPLETIONIND" VARCHAR2(5), 
	"LOCATIONDATACOMPLETIONIND" VARCHAR2(5)
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
  ;
