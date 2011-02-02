--------------------------------------------------------
--  File created - Thursday-January-13-2011   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table NACCOUNT
--------------------------------------------------------

  CREATE TABLE "NACCOUNT" 
   (	"ID" VARCHAR2(50), 
	"NAASACCOUNT" VARCHAR2(500), 
	"ISACTIVE" CHAR(1), 
	"SYSTEMROLE" VARCHAR2(50), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"ISDELETED" CHAR(1), 
	"ISDEMOUSER" CHAR(1), 
	"PASSWORDHASH" VARCHAR2(50)
   ) ;
--------------------------------------------------------
--  DDL for Table NACCOUNTAUTHREQUEST
--------------------------------------------------------

  CREATE TABLE "NACCOUNTAUTHREQUEST" 
   (	"ID" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"REQUESTGENERATEDON" DATE, 
	"REQUESTTYPE" VARCHAR2(255), 
	"NAASACCOUNT" VARCHAR2(500), 
	"FULLNAME" VARCHAR2(500), 
	"ORGANIZATIONAFFILIATION" VARCHAR2(500), 
	"TELEPHONENUMBER" VARCHAR2(25), 
	"EMAILADDRESS" VARCHAR2(500), 
	"AFFILIATEDNODEID" VARCHAR2(50), 
	"AFFILIATEDCOUNTY" VARCHAR2(255), 
	"PURPOSEDESCRIPTION" VARCHAR2(4000), 
	"REQUESTEDNODEIDS" VARCHAR2(1000), 
	"AUTHORIZATIONACCOUNTID" VARCHAR2(50), 
	"AUTHORIZATIONCOMMENTS" VARCHAR2(4000), 
	"AUTHORIZATIONGENERATEDON" DATE, 
	"DIDCREATEINNAAS" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NACCOUNTAUTHREQUESTFLOW
--------------------------------------------------------

  CREATE TABLE "NACCOUNTAUTHREQUESTFLOW" 
   (	"ID" VARCHAR2(50), 
	"ACCOUNTAUTHREQUESTID" VARCHAR2(50), 
	"FLOWNAME" VARCHAR2(255), 
	"ACCESSGRANTED" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NACCOUNTPOLICY
--------------------------------------------------------

  CREATE TABLE "NACCOUNTPOLICY" 
   (	"ID" VARCHAR2(50), 
	"ACCOUNTID" VARCHAR2(50), 
	"TYPE" VARCHAR2(50), 
	"QUALIFIER" VARCHAR2(500), 
	"ISALLOWED" CHAR(1), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE
   ) ;
--------------------------------------------------------
--  DDL for Table NACTIVITY
--------------------------------------------------------

  CREATE TABLE "NACTIVITY" 
   (	"ID" VARCHAR2(50), 
	"TYPE" VARCHAR2(128), 
	"TRANSACTIONID" VARCHAR2(50), 
	"IP" VARCHAR2(64), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"WEBMETHOD" VARCHAR2(50), 
	"FLOWNAME" VARCHAR2(255), 
	"OPERATION" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NACTIVITYDETAIL
--------------------------------------------------------

  CREATE TABLE "NACTIVITYDETAIL" 
   (	"ID" VARCHAR2(50), 
	"ACTIVITYID" VARCHAR2(50), 
	"DETAIL" VARCHAR2(4000), 
	"MODIFIEDON" DATE, 
	"ORDERINDEX" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table NCONFIG
--------------------------------------------------------

  CREATE TABLE "NCONFIG" 
   (	"ID" VARCHAR2(255), 
	"VALUE" VARCHAR2(4000), 
	"DESCRIPTION" VARCHAR2(500), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"ISEDITABLE" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NCONNECTION
--------------------------------------------------------

  CREATE TABLE "NCONNECTION" 
   (	"ID" VARCHAR2(50), 
	"CODE" VARCHAR2(255), 
	"PROVIDER" VARCHAR2(500), 
	"CONNECTIONSTRING" VARCHAR2(500), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE
   ) ;
--------------------------------------------------------
--  DDL for Table NDOCUMENT
--------------------------------------------------------

  CREATE TABLE "NDOCUMENT" 
   (	"ID" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"DOCUMENTNAME" VARCHAR2(255), 
	"TYPE" VARCHAR2(255), 
	"DOCUMENTID" VARCHAR2(255), 
	"STATUS" VARCHAR2(50), 
	"STATUSDETAIL" VARCHAR2(4000)
   ) ;
--------------------------------------------------------
--  DDL for Table NDOCUMENTCONTENT
--------------------------------------------------------

  CREATE TABLE "NDOCUMENTCONTENT" 
   (	"DOCUMENTID" VARCHAR2(50), 
	"DATA" BLOB
   ) ;
--------------------------------------------------------
--  DDL for Table NFLOW
--------------------------------------------------------

  CREATE TABLE "NFLOW" 
   (	"ID" VARCHAR2(50), 
	"INFOURL" VARCHAR2(500), 
	"CONTACT" VARCHAR2(255), 
	"ISPROTECTED" CHAR(1), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"CODE" VARCHAR2(255), 
	"DESCRIPTION" VARCHAR2(500)
   ) ;
--------------------------------------------------------
--  DDL for Table NNODENOTIFICATION
--------------------------------------------------------

  CREATE TABLE "NNODENOTIFICATION" 
   (	"ID" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"NOTIFYDATA" VARCHAR2(4000)
   ) ;
--------------------------------------------------------
--  DDL for Table NNOTIFICATION
--------------------------------------------------------

  CREATE TABLE "NNOTIFICATION" 
   (	"ID" VARCHAR2(50), 
	"FLOWID" VARCHAR2(50), 
	"ACCOUNTID" VARCHAR2(50), 
	"ONSOLICIT" CHAR(1), 
	"ONQUERY" CHAR(1), 
	"ONSUBMIT" CHAR(1), 
	"ONNOTIFY" CHAR(1), 
	"ONSCHEDULE" CHAR(1), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"ONDOWNLOAD" CHAR(1), 
	"ONEXECUTE" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NOBJECTCACHE
--------------------------------------------------------

  CREATE TABLE "NOBJECTCACHE" 
   (	"NAME" VARCHAR2(255), 
	"MODIFIEDON" DATE, 
	"EXPIRATION" DATE, 
	"DATA" BLOB
   ) ;
--------------------------------------------------------
--  DDL for Table NPARTNER
--------------------------------------------------------

  CREATE TABLE "NPARTNER" 
   (	"ID" VARCHAR2(50), 
	"NAME" VARCHAR2(50), 
	"URL" VARCHAR2(500), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"VERSION" VARCHAR2(50)
   ) ;
--------------------------------------------------------
--  DDL for Table NPLUGIN
--------------------------------------------------------

  CREATE TABLE "NPLUGIN" 
   (	"ID" VARCHAR2(50), 
	"FLOWID" VARCHAR2(50), 
	"BINARYVERSION" VARCHAR2(40), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"ZIPPEDBINARY" BLOB
   ) ;
--------------------------------------------------------
--  DDL for Table NREQUEST
--------------------------------------------------------

  CREATE TABLE "NREQUEST" 
   (	"ID" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"SERVICEID" VARCHAR2(50), 
	"ROWINDEX" NUMBER, 
	"MAXROWCOUNT" NUMBER, 
	"REQUESTTYPE" VARCHAR2(50), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"PARAMSBYNAME" CHAR(1)
   ) ;
--------------------------------------------------------
--  DDL for Table NREQUESTARG
--------------------------------------------------------

  CREATE TABLE "NREQUESTARG" 
   (	"ID" VARCHAR2(50), 
	"REQUESTID" VARCHAR2(50), 
	"ARGNAME" VARCHAR2(255), 
	"ARGVALUE" VARCHAR2(4000)
   ) ;
--------------------------------------------------------
--  DDL for Table NSCHEDULE
--------------------------------------------------------

  CREATE TABLE "NSCHEDULE" 
   (	"ID" VARCHAR2(50), 
	"NAME" VARCHAR2(255), 
	"FLOWID" VARCHAR2(50), 
	"STARTON" DATE, 
	"ENDON" DATE, 
	"SOURCETYPE" VARCHAR2(50), 
	"SOURCEID" VARCHAR2(255), 
	"SOURCEOPERATION" VARCHAR2(255), 
	"TARGETTYPE" VARCHAR2(50), 
	"TARGETID" VARCHAR2(255), 
	"LASTEXECUTEDON" DATE, 
	"NEXTRUN" DATE, 
	"FREQUENCYTYPE" VARCHAR2(50), 
	"FREQUENCY" NUMBER, 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"ISACTIVE" VARCHAR2(1), 
	"ISRUNNOW" VARCHAR2(1), 
	"EXECUTESTATUS" VARCHAR2(50), 
	"TARGETOPERATION" VARCHAR2(255), 
	"TARGETFLOW" VARCHAR2(255), 
	"SOURCEFLOW" VARCHAR2(255), 
	"LASTEXECUTEACTIVITYID" VARCHAR2(50)
   ) ;
--------------------------------------------------------
--  DDL for Table NSCHEDULESOURCEARG
--------------------------------------------------------

  CREATE TABLE "NSCHEDULESOURCEARG" 
   (	"ID" VARCHAR2(50), 
	"SCHEDULEID" VARCHAR2(50), 
	"NAME" VARCHAR2(255), 
	"VALUE" VARCHAR2(4000)
   ) ;
--------------------------------------------------------
--  DDL for Table NSERVICE
--------------------------------------------------------

  CREATE TABLE "NSERVICE" 
   (	"ID" VARCHAR2(50), 
	"NAME" VARCHAR2(50), 
	"FLOWID" VARCHAR2(50), 
	"ISACTIVE" CHAR(1), 
	"SERVICETYPE" VARCHAR2(128), 
	"IMPLEMENTOR" VARCHAR2(500), 
	"AUTHLEVEL" VARCHAR2(50), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"PUBLISHFLAGS" VARCHAR2(50)
   ) ;
--------------------------------------------------------
--  DDL for Table NSERVICEARG
--------------------------------------------------------

  CREATE TABLE "NSERVICEARG" 
   (	"ID" VARCHAR2(50), 
	"SERVICEID" VARCHAR2(50), 
	"ARGCODE" VARCHAR2(255), 
	"VALUE" VARCHAR2(4000)
   ) ;
--------------------------------------------------------
--  DDL for Table NSERVICECONN
--------------------------------------------------------

  CREATE TABLE "NSERVICECONN" 
   (	"ID" VARCHAR2(50), 
	"SERVICEID" VARCHAR2(50), 
	"CONNECTIONID" VARCHAR2(50), 
	"KEYNAME" VARCHAR2(255)
   ) ;
--------------------------------------------------------
--  DDL for Table NTRANSACTION
--------------------------------------------------------

  CREATE TABLE "NTRANSACTION" 
   (	"ID" VARCHAR2(50), 
	"FLOWID" VARCHAR2(50), 
	"NETWORKID" VARCHAR2(255), 
	"STATUS" VARCHAR2(50), 
	"MODIFIEDBY" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"STATUSDETAIL" VARCHAR2(4000), 
	"OPERATION" VARCHAR2(255), 
	"WEBMETHOD" VARCHAR2(50), 
	"ENDPOINTVERSION" VARCHAR2(50), 
	"NETWORKENDPOINTVERSION" VARCHAR2(50), 
	"NETWORKENDPOINTURL" VARCHAR2(500), 
	"NETWORKENDPOINTSTATUS" VARCHAR2(50), 
	"NETWORKENDPOINTSTATUSDETAIL" VARCHAR2(4000)
   ) ;
--------------------------------------------------------
--  DDL for Table NTRANSACTIONNOTIFICATION
--------------------------------------------------------

  CREATE TABLE "NTRANSACTIONNOTIFICATION" 
   (	"ID" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"URI" VARCHAR2(500), 
	"TYPE" VARCHAR2(50)
   ) ;
--------------------------------------------------------
--  DDL for Table NTRANSACTIONREALTIMEDETAILS
--------------------------------------------------------

  CREATE TABLE "NTRANSACTIONREALTIMEDETAILS" 
   (	"ID" VARCHAR2(50), 
	"STATUSTYPE" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"MODIFIEDON" DATE, 
	"ORDERINDEX" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table NTRANSACTIONRECIPIENT
--------------------------------------------------------

  CREATE TABLE "NTRANSACTIONRECIPIENT" 
   (	"ID" VARCHAR2(50), 
	"TRANSACTIONID" VARCHAR2(50), 
	"URI" VARCHAR2(500)
   ) ;
--------------------------------------------------------
--  Constraints for Table NTRANSACTIONREALTIMEDETAILS
--------------------------------------------------------

  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" ADD CONSTRAINT "NTRANSACTIONREALTIMEDETAI_PK" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" MODIFY ("STATUSTYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" MODIFY ("ORDERINDEX" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NFLOW
--------------------------------------------------------

  ALTER TABLE "NFLOW" ADD CONSTRAINT "PK_FLOW" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NFLOW" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NFLOW" MODIFY ("CONTACT" NOT NULL ENABLE);
 
  ALTER TABLE "NFLOW" MODIFY ("ISPROTECTED" NOT NULL ENABLE);
 
  ALTER TABLE "NFLOW" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NFLOW" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NFLOW" MODIFY ("CODE" NOT NULL ENABLE);
 
  ALTER TABLE "NFLOW" ADD CONSTRAINT "UNQ_FLOW_CODE" UNIQUE ("CODE") ENABLE;
--------------------------------------------------------
--  Constraints for Table NACTIVITY
--------------------------------------------------------

  ALTER TABLE "NACTIVITY" ADD CONSTRAINT "PK_ACTIVITY" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NACTIVITY" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NACTIVITY" MODIFY ("TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NACTIVITY" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NACTIVITY" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NSCHEDULE
--------------------------------------------------------

  ALTER TABLE "NSCHEDULE" ADD CONSTRAINT "PK_SCHEDULE" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NSCHEDULE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("NAME" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("STARTON" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("ENDON" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("SOURCETYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("SOURCEID" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("NEXTRUN" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("FREQUENCYTYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("FREQUENCY" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("ISACTIVE" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("ISRUNNOW" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" MODIFY ("EXECUTESTATUS" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULE" ADD CONSTRAINT "UNQ_SCHEDULE_NAME" UNIQUE ("NAME") ENABLE;
--------------------------------------------------------
--  Constraints for Table NOBJECTCACHE
--------------------------------------------------------

  ALTER TABLE "NOBJECTCACHE" ADD CONSTRAINT "PK_NOBJECTCACHE" PRIMARY KEY ("NAME") ENABLE;
 
  ALTER TABLE "NOBJECTCACHE" MODIFY ("NAME" NOT NULL ENABLE);
 
  ALTER TABLE "NOBJECTCACHE" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NOBJECTCACHE" MODIFY ("EXPIRATION" NOT NULL ENABLE);
 
  ALTER TABLE "NOBJECTCACHE" MODIFY ("DATA" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NCONNECTION
--------------------------------------------------------

  ALTER TABLE "NCONNECTION" ADD CONSTRAINT "PK_CONNECTION" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NCONNECTION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NCONNECTION" MODIFY ("CODE" NOT NULL ENABLE);
 
  ALTER TABLE "NCONNECTION" MODIFY ("PROVIDER" NOT NULL ENABLE);
 
  ALTER TABLE "NCONNECTION" MODIFY ("CONNECTIONSTRING" NOT NULL ENABLE);
 
  ALTER TABLE "NCONNECTION" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NCONNECTION" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NCONNECTION" ADD CONSTRAINT "UNQ_CONNECTION_CODE" UNIQUE ("CODE") ENABLE;
--------------------------------------------------------
--  Constraints for Table NNODENOTIFICATION
--------------------------------------------------------

  ALTER TABLE "NNODENOTIFICATION" ADD CONSTRAINT "PK_NNODENOTIFICATION" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NNODENOTIFICATION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NNODENOTIFICATION" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NNODENOTIFICATION" MODIFY ("NOTIFYDATA" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NPARTNER
--------------------------------------------------------

  ALTER TABLE "NPARTNER" ADD CONSTRAINT "PK_PARTNER" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NPARTNER" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NPARTNER" MODIFY ("NAME" NOT NULL ENABLE);
 
  ALTER TABLE "NPARTNER" MODIFY ("URL" NOT NULL ENABLE);
 
  ALTER TABLE "NPARTNER" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NPARTNER" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NPARTNER" MODIFY ("VERSION" NOT NULL ENABLE);
 
  ALTER TABLE "NPARTNER" ADD CONSTRAINT "UNQ_PARTNER_NAME" UNIQUE ("NAME") ENABLE;
--------------------------------------------------------
--  Constraints for Table NTRANSACTIONNOTIFICATION
--------------------------------------------------------

  ALTER TABLE "NTRANSACTIONNOTIFICATION" ADD CONSTRAINT "PK_NTRANSNOTIF" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NTRANSACTIONNOTIFICATION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONNOTIFICATION" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONNOTIFICATION" MODIFY ("URI" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONNOTIFICATION" MODIFY ("TYPE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NTRANSACTIONRECIPIENT
--------------------------------------------------------

  ALTER TABLE "NTRANSACTIONRECIPIENT" ADD CONSTRAINT "PK_NTRANSRECIPT" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NTRANSACTIONRECIPIENT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONRECIPIENT" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTIONRECIPIENT" MODIFY ("URI" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NACCOUNTPOLICY
--------------------------------------------------------

  ALTER TABLE "NACCOUNTPOLICY" ADD CONSTRAINT "PK_NACCOUNTPOLICY" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("ACCOUNTID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("QUALIFIER" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("ISALLOWED" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTPOLICY" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NACCOUNTAUTHREQUESTFLOW
--------------------------------------------------------

  ALTER TABLE "NACCOUNTAUTHREQUESTFLOW" ADD CONSTRAINT "PK_NACCOUNTAUTHREQUESTFLOW" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NACCOUNTAUTHREQUESTFLOW" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUESTFLOW" MODIFY ("ACCOUNTAUTHREQUESTID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUESTFLOW" MODIFY ("FLOWNAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NSCHEDULESOURCEARG
--------------------------------------------------------

  ALTER TABLE "NSCHEDULESOURCEARG" ADD CONSTRAINT "PK_NSCHEDULESOURCEARG" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NSCHEDULESOURCEARG" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULESOURCEARG" MODIFY ("SCHEDULEID" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULESOURCEARG" MODIFY ("NAME" NOT NULL ENABLE);
 
  ALTER TABLE "NSCHEDULESOURCEARG" ADD CONSTRAINT "UNQ_SCHEDSRCARG_SCHEDIDNAME" UNIQUE ("NAME", "SCHEDULEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table NPLUGIN
--------------------------------------------------------

  ALTER TABLE "NPLUGIN" ADD CONSTRAINT "NPLUGIN_PK" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NPLUGIN" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NPLUGIN" MODIFY ("FLOWID" NOT NULL ENABLE);
 
  ALTER TABLE "NPLUGIN" MODIFY ("BINARYVERSION" NOT NULL ENABLE);
 
  ALTER TABLE "NPLUGIN" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NPLUGIN" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NPLUGIN" MODIFY ("ZIPPEDBINARY" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NTRANSACTION
--------------------------------------------------------

  ALTER TABLE "NTRANSACTION" ADD CONSTRAINT "PK_TRANSACTION" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NTRANSACTION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTION" MODIFY ("FLOWID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTION" MODIFY ("NETWORKID" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTION" MODIFY ("STATUS" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTION" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTION" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NTRANSACTION" MODIFY ("WEBMETHOD" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NSERVICECONN
--------------------------------------------------------

  ALTER TABLE "NSERVICECONN" ADD CONSTRAINT "PK_NSERVICECONN" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NSERVICECONN" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICECONN" MODIFY ("SERVICEID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICECONN" MODIFY ("CONNECTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICECONN" MODIFY ("KEYNAME" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICECONN" ADD CONSTRAINT "UNQ_SVC_SERVICEIDKEYNAME" UNIQUE ("KEYNAME", "SERVICEID") ENABLE;
--------------------------------------------------------
--  Constraints for Table NACCOUNT
--------------------------------------------------------

  ALTER TABLE "NACCOUNT" ADD CONSTRAINT "PK_ACCOUNT" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NACCOUNT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNT" MODIFY ("NAASACCOUNT" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNT" MODIFY ("ISACTIVE" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNT" MODIFY ("SYSTEMROLE" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNT" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNT" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNT" ADD CONSTRAINT "UNQ_ACCOUNT_NAASACCOUNT" UNIQUE ("NAASACCOUNT") ENABLE;
--------------------------------------------------------
--  Constraints for Table NDOCUMENT
--------------------------------------------------------

  ALTER TABLE "NDOCUMENT" ADD CONSTRAINT "PK_DOCUMENT" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NDOCUMENT" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENT" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENT" MODIFY ("DOCUMENTNAME" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENT" MODIFY ("TYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENT" MODIFY ("DOCUMENTID" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENT" MODIFY ("STATUS" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENT" ADD CONSTRAINT "UNQ_DOC_TRANSIDDOCNAME" UNIQUE ("DOCUMENTNAME", "TRANSACTIONID") ENABLE;
--------------------------------------------------------
--  Constraints for Table NNOTIFICATION
--------------------------------------------------------

  ALTER TABLE "NNOTIFICATION" ADD CONSTRAINT "PK_NOTIFICATION" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("FLOWID" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ACCOUNTID" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONSOLICIT" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONQUERY" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONSUBMIT" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONNOTIFY" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONSCHEDULE" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONDOWNLOAD" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" MODIFY ("ONEXECUTE" NOT NULL ENABLE);
 
  ALTER TABLE "NNOTIFICATION" ADD CONSTRAINT "UNQ_NOTIF_FLOWIDACCTID" UNIQUE ("ACCOUNTID", "FLOWID") ENABLE;
--------------------------------------------------------
--  Constraints for Table NACTIVITYDETAIL
--------------------------------------------------------

  ALTER TABLE "NACTIVITYDETAIL" ADD CONSTRAINT "PK_ACTIVITYDETAIL" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NACTIVITYDETAIL" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NACTIVITYDETAIL" MODIFY ("ACTIVITYID" NOT NULL ENABLE);
 
  ALTER TABLE "NACTIVITYDETAIL" MODIFY ("DETAIL" NOT NULL ENABLE);
 
  ALTER TABLE "NACTIVITYDETAIL" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NACCOUNTAUTHREQUEST
--------------------------------------------------------

  ALTER TABLE "NACCOUNTAUTHREQUEST" ADD CONSTRAINT "PK_NACCOUNTAUTHREQUEST" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("TRANSACTIONID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("REQUESTGENERATEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("REQUESTTYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("NAASACCOUNT" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("FULLNAME" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("ORGANIZATIONAFFILIATION" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("TELEPHONENUMBER" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("EMAILADDRESS" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("AFFILIATEDNODEID" NOT NULL ENABLE);
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" MODIFY ("REQUESTEDNODEIDS" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NREQUESTARG
--------------------------------------------------------

  ALTER TABLE "NREQUESTARG" ADD CONSTRAINT "PK_REQUESTARG" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NREQUESTARG" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUESTARG" MODIFY ("REQUESTID" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUESTARG" MODIFY ("ARGNAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NSERVICE
--------------------------------------------------------

  ALTER TABLE "NSERVICE" ADD CONSTRAINT "PK_SERVICE" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NSERVICE" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("NAME" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("FLOWID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("ISACTIVE" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("SERVICETYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("IMPLEMENTOR" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("AUTHLEVEL" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICE" ADD CONSTRAINT "UNQ_SERVICE_NAMEFLOWID" UNIQUE ("FLOWID", "NAME") ENABLE;
--------------------------------------------------------
--  Constraints for Table NCONFIG
--------------------------------------------------------

  ALTER TABLE "NCONFIG" ADD CONSTRAINT "PK_CONFIG" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NCONFIG" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NCONFIG" MODIFY ("VALUE" NOT NULL ENABLE);
 
  ALTER TABLE "NCONFIG" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
 
  ALTER TABLE "NCONFIG" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NCONFIG" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NCONFIG" MODIFY ("ISEDITABLE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NDOCUMENTCONTENT
--------------------------------------------------------

  ALTER TABLE "NDOCUMENTCONTENT" ADD CONSTRAINT "PK_NDOCUMENTCONTENT" PRIMARY KEY ("DOCUMENTID") ENABLE;
 
  ALTER TABLE "NDOCUMENTCONTENT" MODIFY ("DOCUMENTID" NOT NULL ENABLE);
 
  ALTER TABLE "NDOCUMENTCONTENT" MODIFY ("DATA" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NREQUEST
--------------------------------------------------------

  ALTER TABLE "NREQUEST" ADD CONSTRAINT "PK_REQUEST" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NREQUEST" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("SERVICEID" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("ROWINDEX" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("MAXROWCOUNT" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("REQUESTTYPE" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("MODIFIEDBY" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("MODIFIEDON" NOT NULL ENABLE);
 
  ALTER TABLE "NREQUEST" MODIFY ("PARAMSBYNAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table NSERVICEARG
--------------------------------------------------------

  ALTER TABLE "NSERVICEARG" ADD CONSTRAINT "PK_SERVICEARG" PRIMARY KEY ("ID") ENABLE;
 
  ALTER TABLE "NSERVICEARG" MODIFY ("ID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICEARG" MODIFY ("SERVICEID" NOT NULL ENABLE);
 
  ALTER TABLE "NSERVICEARG" MODIFY ("ARGCODE" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index IDX_NPLUGIN_FLOWID
--------------------------------------------------------

  CREATE INDEX "IDX_NPLUGIN_FLOWID" ON "NPLUGIN" ("FLOWID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NPARTNER_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NPARTNER_MODIFIEDBY" ON "NPARTNER" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICECONN_CONNECTIONID
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICECONN_CONNECTIONID" ON "NSERVICECONN" ("CONNECTIONID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_REQUESTARG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REQUESTARG" ON "NREQUESTARG" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_FREQUENCYTYPE
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_FREQUENCYTYPE" ON "NSCHEDULE" ("FREQUENCYTYPE") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NACCOUNT_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NACCOUNT_MODIFIEDBY" ON "NACCOUNT" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_SCHEDSRCARG_SCHEDIDNAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_SCHEDSRCARG_SCHEDIDNAME" ON "NSCHEDULESOURCEARG" ("NAME", "SCHEDULEID") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_PARTNER_NAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_PARTNER_NAME" ON "NPARTNER" ("NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_SERVICETYPE
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_SERVICETYPE" ON "NSERVICE" ("SERVICETYPE") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_NOTIF_FLOWIDACCTID
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_NOTIF_FLOWIDACCTID" ON "NNOTIFICATION" ("ACCOUNTID", "FLOWID") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_SVC_SERVICEIDKEYNAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_SVC_SERVICEIDKEYNAME" ON "NSERVICECONN" ("KEYNAME", "SERVICEID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NCONNECTION_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NCONNECTION_MODIFIEDBY" ON "NCONNECTION" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULESOURCEARG_NAME
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULESOURCEARG_NAME" ON "NSCHEDULESOURCEARG" ("NAME") 
  ;
--------------------------------------------------------
--  DDL for Index PK_TRANSACTION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_TRANSACTION" ON "NTRANSACTION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_DOC_TRANSIDDOCNAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_DOC_TRANSIDDOCNAME" ON "NDOCUMENT" ("DOCUMENTNAME", "TRANSACTIONID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_NEXTRUN
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_NEXTRUN" ON "NSCHEDULE" ("NEXTRUN") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NNOTIFICATION_FLOWID
--------------------------------------------------------

  CREATE INDEX "IDX_NNOTIFICATION_FLOWID" ON "NNOTIFICATION" ("FLOWID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_ISRUNNOW
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_ISRUNNOW" ON "NSCHEDULE" ("ISRUNNOW") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SERVICE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SERVICE" ON "NSERVICE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_FLOWID
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_FLOWID" ON "NSCHEDULE" ("FLOWID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NDOCUMENT_DOCUMENTID
--------------------------------------------------------

  CREATE INDEX "IDX_NDOCUMENT_DOCUMENTID" ON "NDOCUMENT" ("DOCUMENTID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_FLOWID
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_FLOWID" ON "NSERVICE" ("FLOWID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NPLUGIN_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NPLUGIN_MODIFIEDBY" ON "NPLUGIN" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SERVICEARG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SERVICEARG" ON "NSERVICEARG" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NACCOUNT_ISACTIVE
--------------------------------------------------------

  CREATE INDEX "IDX_NACCOUNT_ISACTIVE" ON "NACCOUNT" ("ISACTIVE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_REQUEST
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_REQUEST" ON "NREQUEST" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_SCHEDULE_NAME
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_SCHEDULE_NAME" ON "NSCHEDULE" ("NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NNOTIFICATION_ACCOUNTID
--------------------------------------------------------

  CREATE INDEX "IDX_NNOTIFICATION_ACCOUNTID" ON "NNOTIFICATION" ("ACCOUNTID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NSCHEDULESOURCEARG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NSCHEDULESOURCEARG" ON "NSCHEDULESOURCEARG" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index NTRANSACTIONREALTIMEDETAI_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "NTRANSACTIONREALTIMEDETAI_PK" ON "NTRANSACTIONREALTIMEDETAILS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_PARTNER
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_PARTNER" ON "NPARTNER" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_SERVICE_NAMEFLOWID
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_SERVICE_NAMEFLOWID" ON "NSERVICE" ("FLOWID", "NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_PUBLISHFLAGS
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_PUBLISHFLAGS" ON "NSERVICE" ("PUBLISHFLAGS") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICECONN_SERVICEID
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICECONN_SERVICEID" ON "NSERVICECONN" ("SERVICEID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_MODIFIEDON
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_MODIFIEDON" ON "NSCHEDULE" ("MODIFIEDON") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NTRANSNOTIF
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NTRANSNOTIF" ON "NTRANSACTIONNOTIFICATION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NNODENOTIFICATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NNODENOTIFICATION" ON "NNODENOTIFICATION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NREQUEST_TRANSACTIONID
--------------------------------------------------------

  CREATE INDEX "IDX_NREQUEST_TRANSACTIONID" ON "NREQUEST" ("TRANSACTIONID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOTIFICATION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOTIFICATION" ON "NNOTIFICATION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NREQUEST_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NREQUEST_MODIFIEDBY" ON "NREQUEST" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_MODIFIEDBY" ON "NSCHEDULE" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NACCOUNTPOLICY_ACCOUNTID
--------------------------------------------------------

  CREATE INDEX "IDX_NACCOUNTPOLICY_ACCOUNTID" ON "NACCOUNTPOLICY" ("ACCOUNTID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NREQUEST_REQUESTTYPE
--------------------------------------------------------

  CREATE INDEX "IDX_NREQUEST_REQUESTTYPE" ON "NREQUEST" ("REQUESTTYPE") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_SCHEDULEID
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_SCHEDULEID" ON "NSERVICE" ("NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NOBJECTCACHE_MODIFIEDON
--------------------------------------------------------

  CREATE INDEX "IDX_NOBJECTCACHE_MODIFIEDON" ON "NOBJECTCACHE" ("MODIFIEDON") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_ISACTIVE
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_ISACTIVE" ON "NSERVICE" ("ISACTIVE") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NACCOUNTPOLICY_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NACCOUNTPOLICY_MODIFIEDBY" ON "NACCOUNTPOLICY" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_ISACTIVE
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_ISACTIVE" ON "NSCHEDULE" ("ISACTIVE") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NREQUESTARG_REQUESTID
--------------------------------------------------------

  CREATE INDEX "IDX_NREQUESTARG_REQUESTID" ON "NREQUESTARG" ("REQUESTID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ACTIVITY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ACTIVITY" ON "NACTIVITY" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NCONFIG_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NCONFIG_MODIFIEDBY" ON "NCONFIG" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_FREQUENCY
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_FREQUENCY" ON "NSCHEDULE" ("FREQUENCY") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NOBJECTCACHE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NOBJECTCACHE" ON "NOBJECTCACHE" ("NAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICEARG_SERVICEID
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICEARG_SERVICEID" ON "NSERVICEARG" ("SERVICEID") 
  ;
--------------------------------------------------------
--  DDL for Index NPLUGIN_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "NPLUGIN_PK" ON "NPLUGIN" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_AUTHLEVEL
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_AUTHLEVEL" ON "NSERVICE" ("AUTHLEVEL") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_ENDON
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_ENDON" ON "NSCHEDULE" ("ENDON") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICE_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICE_MODIFIEDBY" ON "NSERVICE" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_CONNECTION_CODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_CONNECTION_CODE" ON "NCONNECTION" ("CODE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CONFIG
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CONFIG" ON "NCONFIG" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NACCOUNTAUTHREQUESTFLOW
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NACCOUNTAUTHREQUESTFLOW" ON "NACCOUNTAUTHREQUESTFLOW" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NSERVICECONN
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NSERVICECONN" ON "NSERVICECONN" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NACCOUNT_MODIFIEDON
--------------------------------------------------------

  CREATE INDEX "IDX_NACCOUNT_MODIFIEDON" ON "NACCOUNT" ("MODIFIEDON") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_FLOW_CODE
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_FLOW_CODE" ON "NFLOW" ("CODE") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NREQUEST_SERVICEID
--------------------------------------------------------

  CREATE INDEX "IDX_NREQUEST_SERVICEID" ON "NREQUEST" ("SERVICEID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NDOCUMENTCONTENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NDOCUMENTCONTENT" ON "NDOCUMENTCONTENT" ("DOCUMENTID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ACTIVITYDETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ACTIVITYDETAIL" ON "NACTIVITYDETAIL" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NACCOUNTPOLICY
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NACCOUNTPOLICY" ON "NACCOUNTPOLICY" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_STARTON
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_STARTON" ON "NSCHEDULE" ("STARTON") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SCHEDULE
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SCHEDULE" ON "NSCHEDULE" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NDOCUMENT_DOCUMENTNAME
--------------------------------------------------------

  CREATE INDEX "IDX_NDOCUMENT_DOCUMENTNAME" ON "NDOCUMENT" ("DOCUMENTNAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSERVICECONN_KEYNAME
--------------------------------------------------------

  CREATE INDEX "IDX_NSERVICECONN_KEYNAME" ON "NSERVICECONN" ("KEYNAME") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NNOTIFICATION_MODIFIEDBY
--------------------------------------------------------

  CREATE INDEX "IDX_NNOTIFICATION_MODIFIEDBY" ON "NNOTIFICATION" ("MODIFIEDBY") 
  ;
--------------------------------------------------------
--  DDL for Index PK_DOCUMENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_DOCUMENT" ON "NDOCUMENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NSCHEDULE_LASTEXECUTEDON
--------------------------------------------------------

  CREATE INDEX "IDX_NSCHEDULE_LASTEXECUTEDON" ON "NSCHEDULE" ("LASTEXECUTEDON") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NDOCUMENT_TRANSACTIONID
--------------------------------------------------------

  CREATE INDEX "IDX_NDOCUMENT_TRANSACTIONID" ON "NDOCUMENT" ("TRANSACTIONID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NACCOUNTAUTHREQUEST
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NACCOUNTAUTHREQUEST" ON "NACCOUNTAUTHREQUEST" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_NTRANSRECIPT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_NTRANSRECIPT" ON "NTRANSACTIONRECIPIENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FLOW
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FLOW" ON "NFLOW" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index UNQ_ACCOUNT_NAASACCOUNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "UNQ_ACCOUNT_NAASACCOUNT" ON "NACCOUNT" ("NAASACCOUNT") 
  ;
--------------------------------------------------------
--  DDL for Index PK_ACCOUNT
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_ACCOUNT" ON "NACCOUNT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NACCOUNT_SYSTEMROLE
--------------------------------------------------------

  CREATE INDEX "IDX_NACCOUNT_SYSTEMROLE" ON "NACCOUNT" ("SYSTEMROLE") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CONNECTION
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CONNECTION" ON "NCONNECTION" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index IDX_NOBJECTCACHE_EXPIRATION
--------------------------------------------------------

  CREATE INDEX "IDX_NOBJECTCACHE_EXPIRATION" ON "NOBJECTCACHE" ("EXPIRATION") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table NACCOUNT
--------------------------------------------------------

  ALTER TABLE "NACCOUNT" ADD CONSTRAINT "FK_ACCOUNT_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NACCOUNTAUTHREQUEST
--------------------------------------------------------

  ALTER TABLE "NACCOUNTAUTHREQUEST" ADD CONSTRAINT "FK_ACCTAUTHREQUEST_ACCOUNT" FOREIGN KEY ("AUTHORIZATIONACCOUNTID")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NACCOUNTAUTHREQUEST" ADD CONSTRAINT "FK_ACCTAUTHREQUEST_TRANSACTION" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NACCOUNTAUTHREQUESTFLOW
--------------------------------------------------------

  ALTER TABLE "NACCOUNTAUTHREQUESTFLOW" ADD CONSTRAINT "FK_ACTATHRQSTFLW_ACTATHRQST" FOREIGN KEY ("ACCOUNTAUTHREQUESTID")
	  REFERENCES "NACCOUNTAUTHREQUEST" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NACCOUNTPOLICY
--------------------------------------------------------

  ALTER TABLE "NACCOUNTPOLICY" ADD CONSTRAINT "FK_ACCOUNTIDPOLICY_ACCOUNT" FOREIGN KEY ("ACCOUNTID")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NACCOUNTPOLICY" ADD CONSTRAINT "FK_ACCOUNTPOLICY_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NACTIVITY
--------------------------------------------------------

  ALTER TABLE "NACTIVITY" ADD CONSTRAINT "FK_ACTIVITY_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "NACTIVITY" ADD CONSTRAINT "FK_ACTIVITY_TRANSACTION" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NACTIVITYDETAIL
--------------------------------------------------------

  ALTER TABLE "NACTIVITYDETAIL" ADD CONSTRAINT "FK_ACTIVITYDETAIL_ACTIVITY" FOREIGN KEY ("ACTIVITYID")
	  REFERENCES "NACTIVITY" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NCONFIG
--------------------------------------------------------

  ALTER TABLE "NCONFIG" ADD CONSTRAINT "FK_CONFIG_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NCONNECTION
--------------------------------------------------------

  ALTER TABLE "NCONNECTION" ADD CONSTRAINT "FK_CONNECTION_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NDOCUMENT
--------------------------------------------------------

  ALTER TABLE "NDOCUMENT" ADD CONSTRAINT "FK_DOCUMENT_TRANSACTION" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NDOCUMENTCONTENT
--------------------------------------------------------

  ALTER TABLE "NDOCUMENTCONTENT" ADD CONSTRAINT "FK_DOCCONTENT_DOC" FOREIGN KEY ("DOCUMENTID")
	  REFERENCES "NDOCUMENT" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NFLOW
--------------------------------------------------------

  ALTER TABLE "NFLOW" ADD CONSTRAINT "FK_FLOW_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NNODENOTIFICATION
--------------------------------------------------------

  ALTER TABLE "NNODENOTIFICATION" ADD CONSTRAINT "FK_NODENOTIF_TRANS" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NNOTIFICATION
--------------------------------------------------------

  ALTER TABLE "NNOTIFICATION" ADD CONSTRAINT "FK_MODBY_NOTIF_ACCT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NNOTIFICATION" ADD CONSTRAINT "FK_NOTIF_ACCOUNT" FOREIGN KEY ("ACCOUNTID")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NNOTIFICATION" ADD CONSTRAINT "FK_NOTIF_FLOW" FOREIGN KEY ("FLOWID")
	  REFERENCES "NFLOW" ("ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table NPARTNER
--------------------------------------------------------

  ALTER TABLE "NPARTNER" ADD CONSTRAINT "FK_PARTNER_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NPLUGIN
--------------------------------------------------------

  ALTER TABLE "NPLUGIN" ADD CONSTRAINT "NPLUGIN_NACCOUNT_FK" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NPLUGIN" ADD CONSTRAINT "NPLUGIN_NFLOW_FK" FOREIGN KEY ("FLOWID")
	  REFERENCES "NFLOW" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NREQUEST
--------------------------------------------------------

  ALTER TABLE "NREQUEST" ADD CONSTRAINT "FK_MODBY_REQUEST_ACCT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NREQUEST" ADD CONSTRAINT "FK_REQUEST_SERVICE" FOREIGN KEY ("SERVICEID")
	  REFERENCES "NSERVICE" ("ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "NREQUEST" ADD CONSTRAINT "FK_REQUEST_TRANSACTION" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NREQUESTARG
--------------------------------------------------------

  ALTER TABLE "NREQUESTARG" ADD CONSTRAINT "FK_REQUESTARG_REQUEST" FOREIGN KEY ("REQUESTID")
	  REFERENCES "NREQUEST" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NSCHEDULE
--------------------------------------------------------

  ALTER TABLE "NSCHEDULE" ADD CONSTRAINT "FK_SCHEDULE_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "NSCHEDULE" ADD CONSTRAINT "FK_SCHEDULE_ACTIVITY" FOREIGN KEY ("LASTEXECUTEACTIVITYID")
	  REFERENCES "NACTIVITY" ("ID") ENABLE;
 
  ALTER TABLE "NSCHEDULE" ADD CONSTRAINT "FK_SCHEDULE_FLOW" FOREIGN KEY ("FLOWID")
	  REFERENCES "NFLOW" ("ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NSCHEDULESOURCEARG
--------------------------------------------------------

  ALTER TABLE "NSCHEDULESOURCEARG" ADD CONSTRAINT "FK_SCHEDULESOURCEARG_SCHEDULE" FOREIGN KEY ("SCHEDULEID")
	  REFERENCES "NSCHEDULE" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NSERVICE
--------------------------------------------------------

  ALTER TABLE "NSERVICE" ADD CONSTRAINT "FK_SERVICE_ACCOUNT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NSERVICE" ADD CONSTRAINT "FK_SERVICE_FLOW" FOREIGN KEY ("FLOWID")
	  REFERENCES "NFLOW" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NSERVICEARG
--------------------------------------------------------

  ALTER TABLE "NSERVICEARG" ADD CONSTRAINT "FK_SERVICEARG_SERVICE" FOREIGN KEY ("SERVICEID")
	  REFERENCES "NSERVICE" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NSERVICECONN
--------------------------------------------------------

  ALTER TABLE "NSERVICECONN" ADD CONSTRAINT "FK_SERVICECONN_CONNECTION" FOREIGN KEY ("CONNECTIONID")
	  REFERENCES "NCONNECTION" ("ID") ON DELETE CASCADE ENABLE;
 
  ALTER TABLE "NSERVICECONN" ADD CONSTRAINT "FK_SERVICECONN_SERVICE" FOREIGN KEY ("SERVICEID")
	  REFERENCES "NSERVICE" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NTRANSACTION
--------------------------------------------------------

  ALTER TABLE "NTRANSACTION" ADD CONSTRAINT "FK_MODIFIEDBY_TRANS_ACCT" FOREIGN KEY ("MODIFIEDBY")
	  REFERENCES "NACCOUNT" ("ID") ENABLE;
 
  ALTER TABLE "NTRANSACTION" ADD CONSTRAINT "FK_TRANSACTION_FLOW" FOREIGN KEY ("FLOWID")
	  REFERENCES "NFLOW" ("ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NTRANSACTIONNOTIFICATION
--------------------------------------------------------

  ALTER TABLE "NTRANSACTIONNOTIFICATION" ADD CONSTRAINT "FK_TRANSNOTIF_TRANS" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NTRANSACTIONREALTIMEDETAILS
--------------------------------------------------------

  ALTER TABLE "NTRANSACTIONREALTIMEDETAILS" ADD CONSTRAINT "NTRANSACTIONREALTIMEDETAI_FK1" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table NTRANSACTIONRECIPIENT
--------------------------------------------------------

  ALTER TABLE "NTRANSACTIONRECIPIENT" ADD CONSTRAINT "FK_TRANSRECIPIENT_TRANS" FOREIGN KEY ("TRANSACTIONID")
	  REFERENCES "NTRANSACTION" ("ID") ON DELETE CASCADE ENABLE;
