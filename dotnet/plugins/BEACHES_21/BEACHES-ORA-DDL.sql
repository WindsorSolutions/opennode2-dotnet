--------------------------------------------------------
--  File created - Friday-December-18-2009   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------

  CREATE TABLE "NOTIF_ACTIVITYINDICATOR" 
   (	"ID" VARCHAR2(40), 
	"ACTIVITY_ID" VARCHAR2(40), 
	"INDICATORTYPE" VARCHAR2(60), 
	"INDICATORDESCRIPTION" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ACTIVITYINDICATOR"."ID" IS 'Parent: The indicator used to test the activity (Id)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYINDICATOR"."ACTIVITY_ID" IS 'Parent: The indicator used to test the activity (ActivityId)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYINDICATOR"."INDICATORTYPE" IS 'The code for the indicator (ActivityIndicatorType)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYINDICATOR"."INDICATORDESCRIPTION" IS 'A short description of the type of indicator (ActivityIndicatorDescriptionText)';
 
   COMMENT ON TABLE "NOTIF_ACTIVITYINDICATOR"  IS 'Schema element: ActivityIndicatorDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYREASON
--------------------------------------------------------

  CREATE TABLE "NOTIF_ACTIVITYREASON" 
   (	"ID" VARCHAR2(40), 
	"ACTIVITY_ID" VARCHAR2(40), 
	"REASONTYPE" VARCHAR2(60), 
	"REASONDESCRIPTION" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ACTIVITYREASON"."ID" IS 'Parent: The reason for the activity (Id)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYREASON"."ACTIVITY_ID" IS 'Parent: The reason for the activity (ActivityId)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYREASON"."REASONTYPE" IS 'The code for the reason for the activity (ActivityReasonType)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYREASON"."REASONDESCRIPTION" IS 'A short description of the reason for the activity (ActivityReasonDescriptionText)';
 
   COMMENT ON TABLE "NOTIF_ACTIVITYREASON"  IS 'Schema element: ActivityReasonDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_ACTIVITYSOURCE
--------------------------------------------------------

  CREATE TABLE "NOTIF_ACTIVITYSOURCE" 
   (	"ID" VARCHAR2(40), 
	"ACTIVITY_ID" VARCHAR2(40), 
	"SOURCETYPE" VARCHAR2(60), 
	"SOURCEDESCRIPTION" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ACTIVITYSOURCE"."ID" IS 'Parent: Describes the source of the activity (Id)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYSOURCE"."ACTIVITY_ID" IS 'Parent: Describes the source of the activity (ActivityId)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYSOURCE"."SOURCETYPE" IS 'The code for the source of the activity (ActivitySourceType)';
 
   COMMENT ON COLUMN "NOTIF_ACTIVITYSOURCE"."SOURCEDESCRIPTION" IS 'A short description of the source of the activity (ActivitySourceDescriptionText)';
 
   COMMENT ON TABLE "NOTIF_ACTIVITYSOURCE"  IS 'Schema element: ActivitySourceDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_BEACH
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACH" 
   (	"ID" VARCHAR2(40), 
	"BEACHIDENTIFIER" VARCHAR2(8), 
	"BEACHNAME" VARCHAR2(60), 
	"BEACHDESCRIPTION" VARCHAR2(255), 
	"BEACHCOMMENT" VARCHAR2(255), 
	"BEACHSTATECODE" CHAR(2), 
	"BEACHFIPSCOUNTYCODE" VARCHAR2(5), 
	"WATERBODYNAMECODE" VARCHAR2(25), 
	"WATERBODYTYPECODE" VARCHAR2(25), 
	"BEACHACCESSTYPE" VARCHAR2(12), 
	"BEACHACCESSCOMMENT" VARCHAR2(255), 
	"EFFECTIVEYEAR" VARCHAR2(4), 
	"BEACHTIERRANKING" VARCHAR2(1), 
	"BEACHACTBEACHINDICATOR" VARCHAR2(5), 
	"EXTENTLENGTHMEASURE" NUMBER(19,14), 
	"EXTENTUNITOFMEASURE" VARCHAR2(12), 
	"SWIMSEASONSTARTDATE" VARCHAR2(25), 
	"SWIMSEASONLENGTH" NUMBER(19,14), 
	"SWIMSEASONENDDATE" VARCHAR2(25), 
	"SWIMSEASONUNITOFMEASURE" VARCHAR2(12), 
	"SWIMSEASONFREQUENCYMEASURE" NUMBER(19,14), 
	"OFFSEASONFREQUENCYMEASURE" NUMBER(19,14), 
	"MONITORINGFREQUNITOFMEASURE" VARCHAR2(255), 
	"MONITOREDIRREGULARLY" VARCHAR2(5), 
	"MONITOREDIRREGULARLYCOMMENT" VARCHAR2(255), 
	"NOPOLLUTIONSOURCES" VARCHAR2(5), 
	"POLLUTIONSOURCESUNINVESTIGATED" VARCHAR2(5), 
	"STARTLATMEASURE" VARCHAR2(25), 
	"STARTLONGMEASURE" VARCHAR2(25), 
	"SOURCEMAPSCALE" VARCHAR2(25), 
	"HORIZCOLLMETHOD" VARCHAR2(25), 
	"HORIZCOLLDATUM" VARCHAR2(25), 
	"ENDLATMEASURE" VARCHAR2(25), 
	"ENDLONGMEASURE" VARCHAR2(25)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHIDENTIFIER" IS 'The unique code that identifies the beach (BeachIdentifier)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHNAME" IS 'The name of the program interest (ProgramInterestName)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHDESCRIPTION" IS 'A short description of the program interest (ProgramInterestDescriptionText)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHCOMMENT" IS 'A comment about the program interest (ProgramInterestCommentText)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHSTATECODE" IS 'The two letter code fot the state the program interest is located in (ProgramInterestStateCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHFIPSCOUNTYCODE" IS 'The FIPS county code for the program interest (ProgramInterestFIPSCountyCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."WATERBODYNAMECODE" IS 'The water body name code for the beach. (WaterBodyNameCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."WATERBODYTYPECODE" IS 'The water body type code for the beach. (WaterBodyTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHACCESSTYPE" IS 'The accessibility of the beach (ex: PUB_PUB_ACC, PRV_PUB_ACC) (BeachAccessibilityType)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHACCESSCOMMENT" IS 'A short comment about the accessibility of the beach (BeachAccessibilityComment)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."EFFECTIVEYEAR" IS 'The year the attribute is effective (AttributeEffectiveYear)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHTIERRANKING" IS 'The tier of the beach (BeachTierRanking)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."BEACHACTBEACHINDICATOR" IS 'True if the beach qualifies as a BEACH Act beach.  False in any other case (BeachActBeachIndicator)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."EXTENTLENGTHMEASURE" IS 'The length of the object (ExtentLengthMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."EXTENTUNITOFMEASURE" IS 'The unit of measurement (ExtentUnitOfMeasureCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."SWIMSEASONSTARTDATE" IS 'The start date of the swim season (SwimSeasonStartDate)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."SWIMSEASONLENGTH" IS 'The number that descreibes the length of the swim season (SwimSeasonLengthMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."SWIMSEASONENDDATE" IS 'The end date of the swim season (SwimSeasonEndDate)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."SWIMSEASONUNITOFMEASURE" IS 'The unit of measure for the length of the swim season (SwimSeasonUnitOfMeasureCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."SWIMSEASONFREQUENCYMEASURE" IS 'The number that represents the length of the swim season (SwimSeasonFrequencyMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."OFFSEASONFREQUENCYMEASURE" IS 'The number that represents the lenght of the off season (OffSeasonFrequencyMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."MONITORINGFREQUNITOFMEASURE" IS 'The unit of time that is used for the measurements (MonitoringFrequencyUnitOfMeasureCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."MONITOREDIRREGULARLY" IS 'True if a beach is sporadically monitored.  False in any other case (MonitoredIrregularly)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."MONITOREDIRREGULARLYCOMMENT" IS 'Any comments about the monitoring frequency of the beach. (MonitoredIrregularlyComment)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."NOPOLLUTIONSOURCES" IS 'This can only be true.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (NoPollutionSourcesIndicator)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."POLLUTIONSOURCESUNINVESTIGATED" IS 'This can only be true.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (PollutionSourcesUninvestigatedIndicator)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."STARTLATMEASURE" IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."STARTLONGMEASURE" IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."SOURCEMAPSCALE" IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumeric)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."HORIZCOLLMETHOD" IS 'The name that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodName)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."HORIZCOLLDATUM" IS 'The name that describes the reference datum used in determining latitude and longitude coordinates. (HorizontalCoordinateReferenceSystemDatumName)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."ENDLATMEASURE" IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACH"."ENDLONGMEASURE" IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)';
 
   COMMENT ON TABLE "NOTIF_BEACH"  IS 'Schema element: BeachDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHACTIVITY
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHACTIVITY" 
   (	"ID" VARCHAR2(40), 
	"BEACH_ID" VARCHAR2(40), 
	"ACTIVITYTYPECODE" VARCHAR2(12), 
	"ACTIVITYNAME" VARCHAR2(60), 
	"ACTUALSTARTDATE" VARCHAR2(25), 
	"ACTUALSTOPDATE" VARCHAR2(25), 
	"MONITORINGSTATIONIDENTIFIER" VARCHAR2(65), 
	"ACTIVITYDESCRIPTION" VARCHAR2(255), 
	"ACTIVITYCOMMENT" VARCHAR2(255), 
	"SENTTOEPA" CHAR(1), 
	"EXTENTSTARTMEASURE" NUMBER(19,14), 
	"EXTENTLENGTHMEASURE" NUMBER(19,14), 
	"EXTENTUNITOFMEASURE" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ID" IS 'Parent: All the information associated with an activity. (Id)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."BEACH_ID" IS 'Parent: All the information associated with an activity. (BeachId)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ACTIVITYTYPECODE" IS 'The code for the type of activity being reported (ex: CLOSURE, CONTAM_ADV) (ActivityTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ACTIVITYNAME" IS 'The name of the activity being reported for the beach (ActivityName)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ACTUALSTARTDATE" IS 'The start date for the activity (ActivityActualStartDate)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ACTUALSTOPDATE" IS 'The stop date for the activity (ActivityActualStopDate)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."MONITORINGSTATIONIDENTIFIER" IS 'The unique identifier for the monitoring station (ActivityMonitoringStationIdentifier)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ACTIVITYDESCRIPTION" IS 'A short description of the activity (ActivityDescriptionText)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."ACTIVITYCOMMENT" IS 'A comment about the activity (ActivityCommentText)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."SENTTOEPA" IS 'Parent: All the information associated with an activity. (SetToEPA)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."EXTENTSTARTMEASURE" IS 'Parent: The distance of the beach that the activity affects (ActivityExtentStartMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."EXTENTLENGTHMEASURE" IS 'The length of the measure (ActivityExtentLengthMeasure)';
 
   COMMENT ON COLUMN "NOTIF_BEACHACTIVITY"."EXTENTUNITOFMEASURE" IS 'The unit of length for the measurement (ActivityExtentUnitOfMeasureCode)';
 
   COMMENT ON TABLE "NOTIF_BEACHACTIVITY"  IS 'Schema element: ActivityDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHPOLLUTION
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHPOLLUTION" 
   (	"ID" VARCHAR2(40), 
	"BEACH_ID" VARCHAR2(40), 
	"POLLUTIONSOURCECODE" VARCHAR2(12), 
	"POLLUTIONSOURCEDESCRIPTION" VARCHAR2(255)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_BEACHPOLLUTION"."ID" IS 'Parent: A list of pollution sources.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (Id)';
 
   COMMENT ON COLUMN "NOTIF_BEACHPOLLUTION"."BEACH_ID" IS 'Parent: A list of pollution sources.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (BeachId)';
 
   COMMENT ON COLUMN "NOTIF_BEACHPOLLUTION"."POLLUTIONSOURCECODE" IS 'The code representing the source of the polution (BeachPollutionSourceCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACHPOLLUTION"."POLLUTIONSOURCEDESCRIPTION" IS 'A short description of the pollution source (BeachPollutionSourceDescription)';
 
   COMMENT ON TABLE "NOTIF_BEACHPOLLUTION"  IS 'Schema element: BeachPollutionSourceDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_BEACHPROCEDURE
--------------------------------------------------------

  CREATE TABLE "NOTIF_BEACHPROCEDURE" 
   (	"ID" VARCHAR2(40), 
	"PROCEDURETYPECODE" VARCHAR2(12), 
	"PROCEDUREDESCRIPTION" VARCHAR2(255), 
	"PROCEDUREIDENTIFIER" VARCHAR2(8), 
	"BEACH_ID" VARCHAR2(40)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_BEACHPROCEDURE"."PROCEDURETYPECODE" IS 'The code that identifies the procedure (ProcedureTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_BEACHPROCEDURE"."PROCEDUREDESCRIPTION" IS 'The description of the procedure (ProcedureDescriptionText)';
 
   COMMENT ON COLUMN "NOTIF_BEACHPROCEDURE"."PROCEDUREIDENTIFIER" IS 'The code that identifies the procedure (ProcedureIdentifier)';
 
   COMMENT ON TABLE "NOTIF_BEACHPROCEDURE"  IS 'Schema element: BeachProcedureDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATION
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATION" 
   (	"ID" VARCHAR2(40), 
	"ORGANIZATIONIDENTIFIER" VARCHAR2(12), 
	"ORGANIZATIONTYPECODE" VARCHAR2(12), 
	"ORGANIZATIONNAME" VARCHAR2(60), 
	"ORGANIZATIONDESCRIPTION" VARCHAR2(255), 
	"ORGANIZATIONABBREVIATION" VARCHAR2(30)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ORGANIZATION"."ORGANIZATIONIDENTIFIER" IS 'The unique code that identifies each organization (OrganizationIdentifier)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATION"."ORGANIZATIONTYPECODE" IS 'Details the type of agency being described (OrganizationTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATION"."ORGANIZATIONNAME" IS 'Details the name of the organization being described (OrganizationName)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATION"."ORGANIZATIONDESCRIPTION" IS 'A short text description of the organization (OrganizationDescriptionText)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATION"."ORGANIZATIONABBREVIATION" IS 'The abbreviation of the organization being described (OrganizationAbbreviationText)';
 
   COMMENT ON TABLE "NOTIF_ORGANIZATION"  IS 'Schema element: OrganizationDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATIONBEACHROLE" 
   (	"ID" VARCHAR2(40), 
	"BEACH_ID" VARCHAR2(40), 
	"ORGANIZATION_ID" VARCHAR2(40), 
	"ROLETYPECODE" VARCHAR2(12), 
	"ROLEEFFECTIVEDATE" VARCHAR2(25), 
	"ROLESTATUS" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ORGANIZATIONBEACHROLE"."ID" IS 'Parent: All the information associated with a beach role. (Id)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONBEACHROLE"."BEACH_ID" IS 'Parent: All the information associated with a beach role. (BeachId)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONBEACHROLE"."ORGANIZATION_ID" IS 'Parent: All the information associated with a beach role. (OrganizationId)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONBEACHROLE"."ROLETYPECODE" IS 'The code for the role of the beach (ex: LOCAL, RESPONDENT) (BeachRoleTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONBEACHROLE"."ROLEEFFECTIVEDATE" IS 'The date the role becomes effective (BeachRoleEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONBEACHROLE"."ROLESTATUS" IS 'Indicates whether the role is ACTIVE or INACTIVE (BeachRoleStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_ORGANIZATIONBEACHROLE"  IS 'Schema element: OrganizationRoleDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONMAILINGADDR
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATIONMAILINGADDR" 
   (	"ID" VARCHAR2(40), 
	"ORGANIZATION_ID" VARCHAR2(40), 
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
 

   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDRTYPECODE" IS 'Details what type the mailing address is (MailingAddressTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDRLINE1" IS 'The first line of the address (MailingAddressStreetLine1Text)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDRLINE2" IS 'The second line of the address (MailingAddressStreetLine2Text)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDRLINE3" IS 'The third line of the address (MailingAddressStreetLine3Text)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDRCITY" IS 'The city name of the address (MailingAddressCityName)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."STATECODE" IS 'The state code of the address (StateCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."ZIPCODE" IS 'The zip code of the address (AddressPostalCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDREFFECTIVEDATE" IS 'The date the change becomes effective (MailingAddressEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONMAILINGADDR"."MAILINGADDRSTATUS" IS 'The status that the mailing address will be changed to (MailingAddressStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_ORGANIZATIONMAILINGADDR"  IS 'Schema element: OrganizationMailingAddressDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGANIZATIONTELEPHONE" 
   (	"ID" VARCHAR2(40), 
	"ORGANIZATION_ID" VARCHAR2(40), 
	"TELEPHONETYPECODE" VARCHAR2(12), 
	"TELEPHONENUMBER" VARCHAR2(12), 
	"TELEPHONEEFFECTIVEDATE" VARCHAR2(25), 
	"TELEPHONESTATUS" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ORGANIZATIONTELEPHONE"."ID" IS 'Parent: All the information asssociated with an organization''s telephone number. (Id)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONTELEPHONE"."ORGANIZATION_ID" IS 'Parent: All the information asssociated with an organization''s telephone number. (OrganizationId)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONTELEPHONE"."TELEPHONETYPECODE" IS 'The type of telephone number being described (ex: VOICE, FAX) (TelephoneTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONTELEPHONE"."TELEPHONENUMBER" IS 'The actual telephone number being described (Must include "-".  ex: xxx-xxx-xxxx) (TelephoneNumberText)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONTELEPHONE"."TELEPHONEEFFECTIVEDATE" IS 'The date the number becomes effective (TelephoneEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_ORGANIZATIONTELEPHONE"."TELEPHONESTATUS" IS 'The status the number will be changed to (ex: ACTIVE, INACTIVE) (TelephoneStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_ORGANIZATIONTELEPHONE"  IS 'Schema element: OrganizationTelephoneType';
--------------------------------------------------------
--  DDL for Table NOTIF_ORGELECTRONICADDR
--------------------------------------------------------

  CREATE TABLE "NOTIF_ORGELECTRONICADDR" 
   (	"ID" VARCHAR2(40), 
	"ORGANIZATION_ID" VARCHAR2(40), 
	"ELECTRONICADDRTYPECODE" VARCHAR2(12), 
	"ELECTRONICADDR" VARCHAR2(255), 
	"ELECTRONICADDREFFDATE" VARCHAR2(25), 
	"ELECTRONICADDRSTATUS" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_ORGELECTRONICADDR"."ID" IS 'Parent: All the information asssociated with an organization''s electronic addresses. (Id)';
 
   COMMENT ON COLUMN "NOTIF_ORGELECTRONICADDR"."ORGANIZATION_ID" IS 'Parent: All the information asssociated with an organization''s electronic addresses. (OrganizationId)';
 
   COMMENT ON COLUMN "NOTIF_ORGELECTRONICADDR"."ELECTRONICADDRTYPECODE" IS 'The type of electronic address being described (ex: EMAIL, URL) (ElectronicAddressTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_ORGELECTRONICADDR"."ELECTRONICADDR" IS 'The actual address being described (ElectronicAddressText)';
 
   COMMENT ON COLUMN "NOTIF_ORGELECTRONICADDR"."ELECTRONICADDREFFDATE" IS 'The date the change becomes effective (ElectronicAddressEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_ORGELECTRONICADDR"."ELECTRONICADDRSTATUS" IS 'The status the address will be changed to (ElectronicAddressStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_ORGELECTRONICADDR"  IS 'Schema element: OrganizationElectronicAddressType';
--------------------------------------------------------
--  DDL for Table NOTIF_PERSON
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSON" 
   (	"ID" VARCHAR2(40), 
	"ORGANIZATION_ID" VARCHAR2(40), 
	"PERSONIDENTIFIER" VARCHAR2(12), 
	"PERSONSTATUS" VARCHAR2(8), 
	"FIRSTNAME" VARCHAR2(50), 
	"LASTNAME" VARCHAR2(50), 
	"MIDDLEINITIAL" VARCHAR2(2), 
	"SUFFIX" VARCHAR2(5), 
	"TITLE" VARCHAR2(60)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_PERSON"."ID" IS 'Parent: All the information associated with a person. (Id)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."ORGANIZATION_ID" IS 'Parent: All the information associated with a person. (OrganizationId)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."PERSONIDENTIFIER" IS 'The unique code that identifies each a person (PersonIdentifier)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."PERSONSTATUS" IS 'Indicates whether the person is ACTIVE or INACTIVE (PersonStatusIndicator)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."FIRSTNAME" IS 'The first name of the person (FirstName)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."LASTNAME" IS 'The last name of the person (LastName)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."MIDDLEINITIAL" IS 'The middle initial of the person (PersonMiddleInitial)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."SUFFIX" IS 'The person''s suffix (NameSuffixText)';
 
   COMMENT ON COLUMN "NOTIF_PERSON"."TITLE" IS 'The person''s title (NamePrefixText)';
 
   COMMENT ON TABLE "NOTIF_PERSON"  IS 'Schema element: PersonDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONBEACHROLE
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONBEACHROLE" 
   (	"ID" VARCHAR2(40), 
	"BEACH_ID" VARCHAR2(40), 
	"PERSON_ID" VARCHAR2(40), 
	"ROLETYPECODE" VARCHAR2(12), 
	"ROLEEFFECTIVEDATE" VARCHAR2(25), 
	"ROLESTATUS" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_PERSONBEACHROLE"."ROLETYPECODE" IS 'The code for the role of the beach (ex: LOCAL, RESPONDENT) (BeachRoleTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_PERSONBEACHROLE"."ROLEEFFECTIVEDATE" IS 'The date the role becomes effective (BeachRoleEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_PERSONBEACHROLE"."ROLESTATUS" IS 'Indicates whether the role is ACTIVE or INACTIVE (BeachRoleStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_PERSONBEACHROLE"  IS 'Schema element: PersonRoleDetailDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONELECTRONICADDRESS
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONELECTRONICADDRESS" 
   (	"ID" VARCHAR2(40), 
	"PERSON_ID" VARCHAR2(40), 
	"ELECTRONICADDRESSTYPECODE" VARCHAR2(12), 
	"ELECTRONICADDRESS" VARCHAR2(255), 
	"ELECTRONICADDRESSEFFECTIVEDATE" VARCHAR2(25), 
	"ELECTRONICADDRESSSTATUS" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_PERSONELECTRONICADDRESS"."ID" IS 'Parent: All the information asssociated with a person''s electronic addresses. (Id)';
 
   COMMENT ON COLUMN "NOTIF_PERSONELECTRONICADDRESS"."PERSON_ID" IS 'Parent: All the information asssociated with a person''s electronic addresses. (PersonId)';
 
   COMMENT ON COLUMN "NOTIF_PERSONELECTRONICADDRESS"."ELECTRONICADDRESSTYPECODE" IS 'The type of electronic address being described (ex: EMAIL, URL) (ElectronicAddressTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_PERSONELECTRONICADDRESS"."ELECTRONICADDRESS" IS 'The actual address being described (ElectronicAddressText)';
 
   COMMENT ON COLUMN "NOTIF_PERSONELECTRONICADDRESS"."ELECTRONICADDRESSEFFECTIVEDATE" IS 'The date the change becomes effective (ElectronicAddressEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_PERSONELECTRONICADDRESS"."ELECTRONICADDRESSSTATUS" IS 'The status the address will be changed to (ElectronicAddressStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_PERSONELECTRONICADDRESS"  IS 'Schema element: PersonElectronicAddressType';
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONMAILINGADDRESS" 
   (	"ID" VARCHAR2(40), 
	"PERSON_ID" VARCHAR2(40), 
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
 

   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."ID" IS 'Parent: Mailing address information for the person. (Id)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."PERSON_ID" IS 'Parent: Mailing address information for the person. (PersonId)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDRTYPECODE" IS 'Details what type the mailing address is (MailingAddressTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDRLINE1" IS 'The first line of the address (MailingAddressStreetLine1Text)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDRLINE2" IS 'The second line of the address (MailingAddressStreetLine2Text)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDRLINE3" IS 'The third line of the address (MailingAddressStreetLine3Text)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDRCITY" IS 'The city name of the address (MailingAddressCityName)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."STATECODE" IS 'The state code of the address (StateCode)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."ZIPCODE" IS 'The zip code of the address (AddressPostalCode)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDREFFECTIVEDATE" IS 'The date the change becomes effective (MailingAddressEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_PERSONMAILINGADDRESS"."MAILINGADDRSTATUS" IS 'The status that the mailing address will be changed to (MailingAddressStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_PERSONMAILINGADDRESS"  IS 'Schema element: PersonMailingAddressDataType';
--------------------------------------------------------
--  DDL for Table NOTIF_PERSONTELEPHONE
--------------------------------------------------------

  CREATE TABLE "NOTIF_PERSONTELEPHONE" 
   (	"ID" VARCHAR2(40), 
	"PERSON_ID" VARCHAR2(40), 
	"TELEPHONETYPECODE" VARCHAR2(12), 
	"TELEPHONENUMBER" VARCHAR2(12), 
	"TELEPHONEEFFECTIVEDATE" VARCHAR2(25), 
	"TELEPHONESTATUS" VARCHAR2(8)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_PERSONTELEPHONE"."ID" IS 'Parent: All the information asssociated with a person''s telephone number. (Id)';
 
   COMMENT ON COLUMN "NOTIF_PERSONTELEPHONE"."PERSON_ID" IS 'Parent: All the information asssociated with a person''s telephone number. (PersonId)';
 
   COMMENT ON COLUMN "NOTIF_PERSONTELEPHONE"."TELEPHONETYPECODE" IS 'The type of telephone number being described (ex: VOICE, FAX) (TelephoneTypeCode)';
 
   COMMENT ON COLUMN "NOTIF_PERSONTELEPHONE"."TELEPHONENUMBER" IS 'The actual telephone number being described (Must include "-".  ex: xxx-xxx-xxxx) (TelephoneNumberText)';
 
   COMMENT ON COLUMN "NOTIF_PERSONTELEPHONE"."TELEPHONEEFFECTIVEDATE" IS 'The date the number becomes effective (TelephoneEffectiveDate)';
 
   COMMENT ON COLUMN "NOTIF_PERSONTELEPHONE"."TELEPHONESTATUS" IS 'The status the number will be changed to (ex: ACTIVE, INACTIVE) (TelephoneStatusIndicator)';
 
   COMMENT ON TABLE "NOTIF_PERSONTELEPHONE"  IS 'Schema element: PersonTelephoneType';
--------------------------------------------------------
--  DDL for Table NOTIF_YEARCOMPLETION
--------------------------------------------------------

  CREATE TABLE "NOTIF_YEARCOMPLETION" 
   (	"ID" VARCHAR2(40), 
	"COMPLETIONYEAR" VARCHAR2(4), 
	"NOTIFICATIONDATACOMPLETIONIND" VARCHAR2(5), 
	"MONITORINGDATACOMPLETIONIND" VARCHAR2(5), 
	"LOCATIONDATACOMPLETIONIND" VARCHAR2(5)
   ) ;
 

   COMMENT ON COLUMN "NOTIF_YEARCOMPLETION"."COMPLETIONYEAR" IS 'The year the status indicators are for. (CompletionYear)';
 
   COMMENT ON COLUMN "NOTIF_YEARCOMPLETION"."NOTIFICATIONDATACOMPLETIONIND" IS 'True if all Notification Data has been submitted for the year.  False in any other case (NotificiationDataCompleteIndicator)';
 
   COMMENT ON COLUMN "NOTIF_YEARCOMPLETION"."MONITORINGDATACOMPLETIONIND" IS 'True if all Monitoring Data has been submitted for the year.  False in any other case (MonitoringDataCompleteIndicator)';
 
   COMMENT ON COLUMN "NOTIF_YEARCOMPLETION"."LOCATIONDATACOMPLETIONIND" IS 'True if all Location Data has been submitted for the year.  False in any other case (LocationDataCompleteIndicator)';
 
   COMMENT ON TABLE "NOTIF_YEARCOMPLETION"  IS 'Schema element: YearCompletionIndicatorDataType';

---------------------------------------------------
--   DATA FOR TABLE NOTIF_ACTIVITYINDICATOR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ACTIVITYINDICATOR

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ACTIVITYINDICATOR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ACTIVITYREASON
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ACTIVITYREASON

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ACTIVITYREASON
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ACTIVITYSOURCE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ACTIVITYSOURCE

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ACTIVITYSOURCE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_BEACH
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_BEACH

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_BEACH
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_BEACHACTIVITY
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_BEACHACTIVITY

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_BEACHACTIVITY
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_BEACHPOLLUTION
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_BEACHPOLLUTION

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_BEACHPOLLUTION
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_BEACHPROCEDURE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_BEACHPROCEDURE

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_BEACHPROCEDURE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ORGANIZATION
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ORGANIZATION

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ORGANIZATION
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ORGANIZATIONBEACHROLE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ORGANIZATIONBEACHROLE

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ORGANIZATIONBEACHROLE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ORGANIZATIONMAILINGADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ORGANIZATIONMAILINGADDR

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ORGANIZATIONMAILINGADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ORGANIZATIONTELEPHONE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ORGANIZATIONTELEPHONE

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ORGANIZATIONTELEPHONE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_ORGELECTRONICADDR
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_ORGELECTRONICADDR

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_ORGELECTRONICADDR
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_PERSON
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_PERSON

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_PERSON
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_PERSONBEACHROLE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_PERSONBEACHROLE

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_PERSONBEACHROLE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_PERSONELECTRONICADDRESS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_PERSONELECTRONICADDRESS

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_PERSONELECTRONICADDRESS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_PERSONMAILINGADDRESS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_PERSONMAILINGADDRESS

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_PERSONMAILINGADDRESS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_PERSONTELEPHONE
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_PERSONTELEPHONE

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_PERSONTELEPHONE
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE NOTIF_YEARCOMPLETION
--   FILTER = none used
---------------------------------------------------
REM INSERTING into NOTIF_YEARCOMPLETION

---------------------------------------------------
--   END DATA FOR TABLE NOTIF_YEARCOMPLETION
---------------------------------------------------

--------------------------------------------------------
--  Constraints for Table NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" ADD CONSTRAINT "PK_NOT_ORG_BCH_R" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" MODIFY ("BEACH_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" MODIFY ("ORGANIZATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" MODIFY ("ROLETYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" MODIFY ("ROLEEFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" MODIFY ("ROLESTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ACTIVITYREASON
--------------------------------------------------------

  ALTER TABLE "NOTIF_ACTIVITYREASON" ADD CONSTRAINT "PK_NOT_ACT_RSN" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ACTIVITYREASON" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ACTIVITYREASON" MODIFY ("ACTIVITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ACTIVITYREASON" MODIFY ("REASONTYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_PERSONELECTRONICADDRESS
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" ADD CONSTRAINT "PK_NOT_PER_EA" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" MODIFY ("PERSON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" MODIFY ("ELECTRONICADDRESSTYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" MODIFY ("ELECTRONICADDRESS" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" MODIFY ("ELECTRONICADDRESSEFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" MODIFY ("ELECTRONICADDRESSSTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ACTIVITYSOURCE
--------------------------------------------------------

  ALTER TABLE "NOTIF_ACTIVITYSOURCE" ADD CONSTRAINT "PK_NOT_ACT_SRC" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ACTIVITYSOURCE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ACTIVITYSOURCE" MODIFY ("ACTIVITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ACTIVITYSOURCE" MODIFY ("SOURCETYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_BEACHPROCEDURE
--------------------------------------------------------

  ALTER TABLE "NOTIF_BEACHPROCEDURE" ADD CONSTRAINT "PK_NOT_BCH_PRO" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_BEACHPROCEDURE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHPROCEDURE" MODIFY ("PROCEDURETYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHPROCEDURE" MODIFY ("PROCEDUREDESCRIPTION" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHPROCEDURE" MODIFY ("PROCEDUREIDENTIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHPROCEDURE" MODIFY ("BEACH_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_BEACH
--------------------------------------------------------

  ALTER TABLE "NOTIF_BEACH" ADD CONSTRAINT "PK_NOT_BCH" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_BEACH" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACH" MODIFY ("BEACHIDENTIFIER" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_PERSON
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSON" ADD CONSTRAINT "PK_NOT_PER" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_PERSON" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSON" MODIFY ("ORGANIZATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSON" MODIFY ("PERSONIDENTIFIER" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_BEACHACTIVITY
--------------------------------------------------------

  ALTER TABLE "NOTIF_BEACHACTIVITY" ADD CONSTRAINT "PK_NOT_BCH_ACT" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_BEACHACTIVITY" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHACTIVITY" MODIFY ("BEACH_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHACTIVITY" MODIFY ("ACTIVITYTYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHACTIVITY" MODIFY ("ACTIVITYNAME" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHACTIVITY" MODIFY ("ACTUALSTARTDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHACTIVITY" MODIFY ("ACTUALSTOPDATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_PERSONBEACHROLE
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONBEACHROLE" ADD CONSTRAINT "PK_NOT_PER_BCH_R" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_PERSONBEACHROLE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONBEACHROLE" MODIFY ("BEACH_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONBEACHROLE" MODIFY ("PERSON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONBEACHROLE" MODIFY ("ROLETYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONBEACHROLE" MODIFY ("ROLEEFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONBEACHROLE" MODIFY ("ROLESTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------

  ALTER TABLE "NOTIF_ACTIVITYINDICATOR" ADD CONSTRAINT "PK_NOT_ACT_IND" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ACTIVITYINDICATOR" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ACTIVITYINDICATOR" MODIFY ("ACTIVITY_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ACTIVITYINDICATOR" MODIFY ("INDICATORTYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_BEACHPOLLUTION
--------------------------------------------------------

  ALTER TABLE "NOTIF_BEACHPOLLUTION" ADD CONSTRAINT "PK_NOT_BCH_POL" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_BEACHPOLLUTION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHPOLLUTION" MODIFY ("BEACH_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_BEACHPOLLUTION" MODIFY ("POLLUTIONSOURCECODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ORGANIZATION
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATION" ADD CONSTRAINT "PK_NOT_ORG" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ORGANIZATION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATION" MODIFY ("ORGANIZATIONIDENTIFIER" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_YEARCOMPLETION
--------------------------------------------------------

  ALTER TABLE "NOTIF_YEARCOMPLETION" ADD CONSTRAINT "PK_NOT_YR_COM" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_YEARCOMPLETION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_YEARCOMPLETION" MODIFY ("COMPLETIONYEAR" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ORGELECTRONICADDR
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGELECTRONICADDR" ADD CONSTRAINT "PK_NOT_ORG_EA" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ORGELECTRONICADDR" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGELECTRONICADDR" MODIFY ("ORGANIZATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGELECTRONICADDR" MODIFY ("ELECTRONICADDRTYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGELECTRONICADDR" MODIFY ("ELECTRONICADDR" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGELECTRONICADDR" MODIFY ("ELECTRONICADDREFFDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGELECTRONICADDR" MODIFY ("ELECTRONICADDRSTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ORGANIZATIONMAILINGADDR
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" ADD CONSTRAINT "PK_NOT_ORG_MA" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("ORGANIZATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("MAILINGADDRTYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("MAILINGADDRLINE1" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("MAILINGADDRCITY" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("STATECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("ZIPCODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("MAILINGADDREFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" MODIFY ("MAILINGADDRSTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" ADD CONSTRAINT "PK_NOT_PER_MA" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("PERSON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("MAILINGADDRTYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("MAILINGADDRLINE1" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("MAILINGADDRCITY" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("STATECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("ZIPCODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("MAILINGADDREFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" MODIFY ("MAILINGADDRSTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_PERSONTELEPHONE
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONTELEPHONE" ADD CONSTRAINT "PK_NOT_PER_TEL" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_PERSONTELEPHONE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONTELEPHONE" MODIFY ("PERSON_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONTELEPHONE" MODIFY ("TELEPHONETYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONTELEPHONE" MODIFY ("TELEPHONENUMBER" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONTELEPHONE" MODIFY ("TELEPHONEEFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_PERSONTELEPHONE" MODIFY ("TELEPHONESTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" ADD CONSTRAINT "PK_NOT_ORG_TEL" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" MODIFY ("ORGANIZATION_ID" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" MODIFY ("TELEPHONETYPECODE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" MODIFY ("TELEPHONENUMBER" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" MODIFY ("TELEPHONEEFFECTIVEDATE" NOT NULL ENABLE);
 
  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" MODIFY ("TELEPHONESTATUS" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_NOT_BCH_PRO
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_BCH_PRO" ON "NOTIF_BEACHPROCEDURE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_BCHPRCDR_BCH_ID
--------------------------------------------------------

  CREATE INDEX "IX_BCHPRCDR_BCH_ID" ON "NOTIF_BEACHPROCEDURE" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_ORGNZT_ORGNZ_ID
--------------------------------------------------------

  CREATE INDEX "IX_ORGNZT_ORGNZ_ID" ON "NOTIF_ORGANIZATIONBEACHROLE" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ACT_S02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ACT_S02" ON "NOTIF_ACTIVITYSOURCE" ("ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_PER
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_PER" ON "NOTIF_PERSON" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ORG_BCH02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ORG_BCH02" ON "NOTIF_ORGANIZATIONBEACHROLE" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_PER_MA
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_PER_MA" ON "NOTIF_PERSONMAILINGADDRESS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ORG_02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ORG_02" ON "NOTIF_ORGANIZATIONMAILINGADDR" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ACT_IND
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ACT_IND" ON "NOTIF_ACTIVITYINDICATOR" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_BCH_POL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_BCH_POL" ON "NOTIF_BEACHPOLLUTION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_PER_BCH02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_PER_BCH02" ON "NOTIF_PERSONBEACHROLE" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ORG_TEL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ORG_TEL" ON "NOTIF_ORGANIZATIONTELEPHONE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ACT_SRC
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ACT_SRC" ON "NOTIF_ACTIVITYSOURCE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ORG_03
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ORG_03" ON "NOTIF_ORGELECTRONICADDR" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ACT_R02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ACT_R02" ON "NOTIF_ACTIVITYREASON" ("ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_PER_EA
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_PER_EA" ON "NOTIF_PERSONELECTRONICADDRESS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_PER_02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_PER_02" ON "NOTIF_PERSONMAILINGADDRESS" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_P02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_P02" ON "NOTIF_PERSON" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_BCH
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_BCH" ON "NOTIF_BEACH" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ORG_BCH_R
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ORG_BCH_R" ON "NOTIF_ORGANIZATIONBEACHROLE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_BCH_A02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_BCH_A02" ON "NOTIF_BEACHACTIVITY" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_PER_T02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_PER_T02" ON "NOTIF_PERSONTELEPHONE" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ORG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ORG" ON "NOTIF_ORGANIZATION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_PER_03
--------------------------------------------------------

  CREATE INDEX "FK_NOT_PER_03" ON "NOTIF_PERSONELECTRONICADDRESS" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_BCH_ACT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_BCH_ACT" ON "NOTIF_BEACHACTIVITY" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ORG_T02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ORG_T02" ON "NOTIF_ORGANIZATIONTELEPHONE" ("ORGANIZATION_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ACT_RSN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ACT_RSN" ON "NOTIF_ACTIVITYREASON" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_BCH_P02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_BCH_P02" ON "NOTIF_BEACHPOLLUTION" ("BEACH_ID") 
  ;
--------------------------------------------------------
--  DDL for Index FK_NOT_ACT_I02
--------------------------------------------------------

  CREATE INDEX "FK_NOT_ACT_I02" ON "NOTIF_ACTIVITYINDICATOR" ("ACTIVITY_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_PRSNBCH_PRSN_ID
--------------------------------------------------------

  CREATE INDEX "IX_PRSNBCH_PRSN_ID" ON "NOTIF_PERSONBEACHROLE" ("PERSON_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_PER_BCH_R
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_PER_BCH_R" ON "NOTIF_PERSONBEACHROLE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ORG_EA
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ORG_EA" ON "NOTIF_ORGELECTRONICADDR" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_PER_TEL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_PER_TEL" ON "NOTIF_PERSONTELEPHONE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_ORG_MA
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_ORG_MA" ON "NOTIF_ORGANIZATIONMAILINGADDR" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOT_YR_COM
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOT_YR_COM" ON "NOTIF_YEARCOMPLETION" ("ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ACTIVITYINDICATOR
--------------------------------------------------------

  ALTER TABLE "NOTIF_ACTIVITYINDICATOR" ADD CONSTRAINT "FK_NOT_ACT_IND" FOREIGN KEY ("ACTIVITY_ID")
	  REFERENCES "NOTIF_BEACHACTIVITY" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ACTIVITYREASON
--------------------------------------------------------

  ALTER TABLE "NOTIF_ACTIVITYREASON" ADD CONSTRAINT "FK_NOT_ACT_RSN" FOREIGN KEY ("ACTIVITY_ID")
	  REFERENCES "NOTIF_BEACHACTIVITY" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ACTIVITYSOURCE
--------------------------------------------------------

  ALTER TABLE "NOTIF_ACTIVITYSOURCE" ADD CONSTRAINT "FK_NOT_ACT_SRC" FOREIGN KEY ("ACTIVITY_ID")
	  REFERENCES "NOTIF_BEACHACTIVITY" ("ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table NOTIF_BEACHACTIVITY
--------------------------------------------------------

  ALTER TABLE "NOTIF_BEACHACTIVITY" ADD CONSTRAINT "FK_NOT_BCH_ACT" FOREIGN KEY ("BEACH_ID")
	  REFERENCES "NOTIF_BEACH" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_BEACHPOLLUTION
--------------------------------------------------------

  ALTER TABLE "NOTIF_BEACHPOLLUTION" ADD CONSTRAINT "FK_NOT_BCH_POL" FOREIGN KEY ("BEACH_ID")
	  REFERENCES "NOTIF_BEACH" ("ID") ON DELETE CASCADE ENABLE;


--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ORGANIZATIONBEACHROLE
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATIONBEACHROLE" ADD CONSTRAINT "FK_NOT_ORG_BCH_R" FOREIGN KEY ("BEACH_ID")
	  REFERENCES "NOTIF_BEACH" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ORGANIZATIONMAILINGADDR
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATIONMAILINGADDR" ADD CONSTRAINT "FK_NOT_ORG_MA" FOREIGN KEY ("ORGANIZATION_ID")
	  REFERENCES "NOTIF_ORGANIZATION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ORGANIZATIONTELEPHONE
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGANIZATIONTELEPHONE" ADD CONSTRAINT "FK_NOT_ORG_TEL" FOREIGN KEY ("ORGANIZATION_ID")
	  REFERENCES "NOTIF_ORGANIZATION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_ORGELECTRONICADDR
--------------------------------------------------------

  ALTER TABLE "NOTIF_ORGELECTRONICADDR" ADD CONSTRAINT "FK_NOT_ORG_EA" FOREIGN KEY ("ORGANIZATION_ID")
	  REFERENCES "NOTIF_ORGANIZATION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_PERSON
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSON" ADD CONSTRAINT "FK_NOT_PER" FOREIGN KEY ("ORGANIZATION_ID")
	  REFERENCES "NOTIF_ORGANIZATION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_PERSONBEACHROLE
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONBEACHROLE" ADD CONSTRAINT "FK_NOT_PER_BCH_R" FOREIGN KEY ("BEACH_ID")
	  REFERENCES "NOTIF_BEACH" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_PERSONELECTRONICADDRESS
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONELECTRONICADDRESS" ADD CONSTRAINT "FK_NOT_PER_EA" FOREIGN KEY ("PERSON_ID")
	  REFERENCES "NOTIF_PERSON" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_PERSONMAILINGADDRESS
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONMAILINGADDRESS" ADD CONSTRAINT "FK_NOT_PER_MA" FOREIGN KEY ("PERSON_ID")
	  REFERENCES "NOTIF_PERSON" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NOTIF_PERSONTELEPHONE
--------------------------------------------------------

  ALTER TABLE "NOTIF_PERSONTELEPHONE" ADD CONSTRAINT "FK_NOT_PER_TEL" FOREIGN KEY ("PERSON_ID")
	  REFERENCES "NOTIF_PERSON" ("ID") ON DELETE CASCADE ENABLE;

ALTER TABLE NOTIF_BEACHPROCEDURE ADD CONSTRAINT FK_NOT_BCH_PRO FOREIGN KEY(BEACH_ID) REFERENCES NOTIF_BEACH(ID);


ALTER TABLE NOTIF_PERSONBEACHROLE ADD CONSTRAINT FK_NOT_PER_BCH FOREIGN KEY(PERSON_ID) REFERENCES NOTIF_PERSON(ID);


ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE ADD CONSTRAINT FK_NOT_ORG_BCH FOREIGN KEY(ORGANIZATION_ID) REFERENCES NOTIF_ORGANIZATION(ID);

