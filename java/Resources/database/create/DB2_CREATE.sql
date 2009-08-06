CREATE TABLE NACCOUNT ( 
    ID          VARCHAR(50) NOT NULL,
    NAASACCOUNT VARCHAR(500) NOT NULL,
    ISACTIVE    CHARACTER(1) NOT NULL,
    SYSTEMROLE  VARCHAR(50) NOT NULL,
    AFFILIATION VARCHAR(50) NOT NULL,
    MODIFIEDBY  VARCHAR(50) NOT NULL,
    MODIFIEDON  DATE NOT NULL 
    );

CREATE TABLE NACCOUNTPOLICY ( 
    ID          VARCHAR(50) NOT NULL,
    ACCOUNTID   VARCHAR(50) NOT NULL,
    POLICYTYPE  VARCHAR(50) NOT NULL,
    QUALIFIER   VARCHAR(500) NOT NULL,
    ISALLOWED   CHARACTER(1) NOT NULL,
    MODIFIEDBY  VARCHAR(50) NOT NULL,
    MODIFIEDON  DATE NOT NULL 
    );

CREATE TABLE NACTIVITY ( 
    ID              VARCHAR(50) NOT NULL,
    ACTIVITYTYPE    VARCHAR(128) NOT NULL,
    TRANSACTIONID   VARCHAR(50),
    IP              VARCHAR(64),
    MODIFIEDBY      VARCHAR(50) NOT NULL,
    MODIFIEDON      DATE NOT NULL 
    );

CREATE TABLE NACTIVITYDETAIL ( 
    ID          VARCHAR(50) NOT NULL,
    ACTIVITYID  VARCHAR(50) NOT NULL,
    DETAIL      VARCHAR(4000) NOT NULL,
    MODIFIEDON  DATE NOT NULL 
    );

CREATE TABLE NCONFIG ( 
    ID          VARCHAR(255) NOT NULL,
    CONFIGVALUE VARCHAR(4000) NOT NULL,
    DESCRIPTION VARCHAR(500) NOT NULL,
    MODIFIEDBY  VARCHAR(50) NOT NULL,
    MODIFIEDON  DATE NOT NULL,
    ISEDITABLE  CHARACTER(1) NOT NULL 
    );

CREATE TABLE NCONNECTION ( 
    ID                  VARCHAR(50) NOT NULL,
    CODE                VARCHAR(255) NOT NULL,
    PROVIDER            VARCHAR(500) NOT NULL,
    CONNECTIONSTRING    VARCHAR(500) NOT NULL,
    MODIFIEDBY          VARCHAR(50) NOT NULL,
    MODIFIEDON          DATE NOT NULL 
    );

CREATE TABLE NDOCUMENT ( 
    ID              VARCHAR(50) NOT NULL,
    TRANSACTIONID   VARCHAR(50) NOT NULL,
    DOCUMENTNAME    VARCHAR(255) NOT NULL,
    DOCUMENTTYPE    VARCHAR(255) NOT NULL,
    DOCUMENTID      VARCHAR(255) NOT NULL,
    STATUS          VARCHAR(50) NOT NULL,
    STATUSDETAIL    VARCHAR(4000),
    DOCUMENTCONTENT BLOB(1048576) 
    );

CREATE TABLE NFLOW ( 
    ID          VARCHAR(50) NOT NULL,
    INFOURL     VARCHAR(500) NOT NULL,
    CONTACT     VARCHAR(255) NOT NULL,
    ISPROTECTED CHARACTER(1) NOT NULL,
    MODIFIEDBY  VARCHAR(50) NOT NULL,
    MODIFIEDON  DATE NOT NULL,
    CODE        VARCHAR(255) NOT NULL,
    DESCRIPTION VARCHAR(500) 
    );

CREATE TABLE NNOTIFICATION ( 
    ID          VARCHAR(50) NOT NULL,
    FLOWID      VARCHAR(50) NOT NULL,
    ACCOUNTID   VARCHAR(50) NOT NULL,
    ONSOLICIT   CHARACTER(1) NOT NULL,
    ONQUERY     CHARACTER(1) NOT NULL,
    ONSUBMIT    CHARACTER(1) NOT NULL,
    ONNOTIFY    CHARACTER(1) NOT NULL,
    ONSCHEDULE  CHARACTER(1) NOT NULL,
    ONDOWNLOAD  CHARACTER(1) NOT NULL,
    ONEXECUTE   CHARACTER(1) NOT NULL 
    );

CREATE TABLE NPARTNER ( 
    ID          VARCHAR(50) NOT NULL,
    NAME        VARCHAR(50) NOT NULL,
    URL         VARCHAR(500) NOT NULL,
    MODIFIEDBY  VARCHAR(50) NOT NULL,
    MODIFIEDON  DATE NOT NULL,
    VERSION     VARCHAR(50) NOT NULL 
    );

CREATE TABLE NPLUGIN ( 
    ID              VARCHAR(50) NOT NULL,
    FLOWID          VARCHAR(50) NOT NULL,
    MODIFIEDBY      VARCHAR(50) NOT NULL,
    MODIFIEDON      DATE NOT NULL,
    PLUGINCONTENT   BLOB(1048576) NOT NULL 
    );

CREATE TABLE NREQUEST ( 
    ID              VARCHAR(50) NOT NULL,
    TRANSACTIONID   VARCHAR(50),
    SERVICEID       VARCHAR(50) NOT NULL,
    ROWINDEX        INTEGER NOT NULL,
    MAXROWCOUNT     INTEGER NOT NULL,
    REQUESTTYPE     VARCHAR(50) NOT NULL,
    MODIFIEDBY      VARCHAR(50) NOT NULL,
    MODIFIEDON      DATE NOT NULL 
    );

CREATE TABLE NREQUESTARG ( 
    ID          VARCHAR(50) NOT NULL,
    REQUESTID   VARCHAR(50) NOT NULL,
    ARGKEY      VARCHAR(255) NOT NULL,
    ARGVALUE    VARCHAR(1024) NOT NULL 
    );

CREATE TABLE NSCHEDULE ( 
    ID                  VARCHAR(50) NOT NULL,
    NAME                VARCHAR(50) NOT NULL,
    FLOWID              VARCHAR(50) NOT NULL,
    STARTON             DATE NOT NULL,
    ENDON               DATE NOT NULL,
    SOURCETYPE          VARCHAR(50) NOT NULL,
    SOURCEID            VARCHAR(255) NOT NULL,
    SOURCEOPERATION     VARCHAR(255),
    TARGETTYPE          VARCHAR(50),
    TARGETID            VARCHAR(255),
    LASTEXECUTIONINFO   VARCHAR(4000),
    LASTEXECUTEDON      DATE,
    NEXTRUN             DATE,
    FREQUENCYTYPE       VARCHAR(50) NOT NULL,
    FREQUENCY           INTEGER NOT NULL,
    MODIFIEDBY          VARCHAR(50) NOT NULL,
    MODIFIEDON          DATE NOT NULL,
    ISACTIVE            VARCHAR(1) NOT NULL,
    ISRUNNOW            VARCHAR(1) NOT NULL,
    EXECUTESTATUS       VARCHAR(50) NOT NULL 
    );

CREATE TABLE NSCHEDULESOURCEARG ( 
    ID          VARCHAR(50) NOT NULL,
    SCHEDULEID  VARCHAR(50) NOT NULL,
    ARGKEY      VARCHAR(255) NOT NULL,
    ARGVALUE    VARCHAR(4000) NOT NULL 
    );

CREATE TABLE NSERVICE ( 
    ID          VARCHAR(50) NOT NULL,
    NAME        VARCHAR(50) NOT NULL,
    FLOWID      VARCHAR(50) NOT NULL,
    ISACTIVE    CHARACTER(1) NOT NULL,
    SERVICETYPE VARCHAR(128) NOT NULL,
    IMPLEMENTOR VARCHAR(500) NOT NULL,
    AUTHLEVEL   VARCHAR(50) NOT NULL,
    MODIFIEDBY  VARCHAR(50) NOT NULL,
    MODIFIEDON  DATE NOT NULL 
    );

CREATE TABLE NSERVICEARG ( 
    ID          VARCHAR(50) NOT NULL,
    SERVICEID   VARCHAR(50) NOT NULL,
    ARGKEY      VARCHAR(255) NOT NULL,
    ARGVALUE    VARCHAR(1024) NOT NULL 
    );

CREATE TABLE NSERVICECONN ( 
    ID              VARCHAR(50) NOT NULL,
    SERVICEID       VARCHAR(50) NOT NULL,
    CONNECTIONID    VARCHAR(50) NOT NULL,
    KEYNAME         VARCHAR(255) NOT NULL 
    );

CREATE TABLE NTRANSACTION ( 
    ID              VARCHAR(50) NOT NULL,
    FLOWID          VARCHAR(50) NOT NULL,
    NETWORKID       VARCHAR(255) NOT NULL,
    STATUS          VARCHAR(50) NOT NULL,
    MODIFIEDBY      VARCHAR(50) NOT NULL,
    MODIFIEDON      DATE NOT NULL,
    STATUSDETAIL    VARCHAR(4000),
    OPERATION       VARCHAR(255),
    WEBMETHOD       VARCHAR(50) NOT NULL 
    );

CREATE TABLE NTRANSACTIONNOTIFICATION ( 
    ID              VARCHAR(50) NOT NULL,
    TRANSACTIONID   VARCHAR(50) NOT NULL,
    URI             VARCHAR(500) NOT NULL,
    TYPE            VARCHAR(50) NOT NULL 
    );

CREATE TABLE NTRANSACTIONRECIPIENT ( 
    ID              VARCHAR(50) NOT NULL,
    TRANSACTIONID   VARCHAR(50) NOT NULL,
    URI             VARCHAR(500) NOT NULL 
    );


ALTER TABLE NACCOUNT
    ADD CONSTRAINT PK_ACCOUNT
    PRIMARY KEY (ID)
;

ALTER TABLE NACCOUNTPOLICY
    ADD CONSTRAINT PK_NACCOUNTPOLICY
    PRIMARY KEY (ID)
;

ALTER TABLE NACTIVITY
    ADD CONSTRAINT PK_ACTIVITY
    PRIMARY KEY (ID)
;

ALTER TABLE NACTIVITYDETAIL
    ADD CONSTRAINT PK_ACTIVITYDETAIL
    PRIMARY KEY (ID)
;

ALTER TABLE NCONFIG
    ADD CONSTRAINT PK_CONFIG
    PRIMARY KEY (ID)
;

ALTER TABLE NCONNECTION
    ADD CONSTRAINT PK_CONNECTION
    PRIMARY KEY (ID)
;

ALTER TABLE NDOCUMENT
    ADD CONSTRAINT PK_DOCUMENT
    PRIMARY KEY (ID)
;

ALTER TABLE NFLOW
    ADD CONSTRAINT PK_FLOW
    PRIMARY KEY (ID)
;

ALTER TABLE NNOTIFICATION
    ADD CONSTRAINT PK_NOTIFICATION
    PRIMARY KEY (ID)
;

ALTER TABLE NPARTNER
    ADD CONSTRAINT PK_PARTNER
    PRIMARY KEY (ID)
;

ALTER TABLE NREQUEST
    ADD CONSTRAINT PK_REQUEST
    PRIMARY KEY (ID)
;

ALTER TABLE NREQUESTARG
    ADD CONSTRAINT PK_REQUESTARG
    PRIMARY KEY (ID)
;

ALTER TABLE NSCHEDULE
    ADD CONSTRAINT PK_SCHEDULE
    PRIMARY KEY (ID)
;

ALTER TABLE NSCHEDULESOURCEARG
    ADD CONSTRAINT PK_NSCHEDSOURCEARG
    PRIMARY KEY (ID)
;

ALTER TABLE NSERVICE
    ADD CONSTRAINT PK_SERVICE
    PRIMARY KEY (ID)
;

ALTER TABLE NSERVICEARG
    ADD CONSTRAINT PK_SERVICEARG
    PRIMARY KEY (ID)
;

ALTER TABLE NSERVICECONN
    ADD CONSTRAINT PK_NSERVICECONN
    PRIMARY KEY (ID)
;

ALTER TABLE NTRANSACTION
    ADD CONSTRAINT PK_TRANSACTION
    PRIMARY KEY (ID)
;

ALTER TABLE NTRANSACTIONNOTIFICATION
    ADD CONSTRAINT PK_NTRANNOTIF
    PRIMARY KEY (ID)
;

ALTER TABLE NTRANSACTIONRECIPIENT
    ADD CONSTRAINT PK_NTRANRECIP
    PRIMARY KEY (ID)
;

CREATE UNIQUE INDEX UNQ_ACCOT_NAASACCT
    ON NACCOUNT(NAASACCOUNT);

CREATE UNIQUE INDEX UNQ_CONNECT_CODE
    ON NCONNECTION(CODE);

CREATE UNIQUE INDEX UNQ_DOC_TRANID
    ON NDOCUMENT(TRANSACTIONID, DOCUMENTNAME);

CREATE UNIQUE INDEX UNQ_FLOW_CODE
    ON NFLOW(CODE);

CREATE UNIQUE INDEX UNQ_NOTIF_FLOWACCT
    ON NNOTIFICATION(FLOWID, ACCOUNTID);

CREATE UNIQUE INDEX UNQ_PARTNER_NAME
    ON NPARTNER(NAME);

CREATE UNIQUE INDEX UNQ_SCHARG_SCHIDNM
    ON NSCHEDULESOURCEARG(SCHEDULEID, ARGKEY);

CREATE UNIQUE INDEX UNQ_SVC_NAMEFLOWID
    ON NSERVICE(NAME, FLOWID);

CREATE UNIQUE INDEX UNQ_SVC_SVCIDKEYNM
    ON NSERVICECONN(SERVICEID, KEYNAME);


ALTER TABLE NACCOUNT
    ADD CONSTRAINT FK_ACCOUNT_ACCOUNT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NACCOUNTPOLICY
    ADD CONSTRAINT FK_ACCTPOL_ACCT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NACCOUNTPOLICY
    ADD CONSTRAINT FK_ACCTIDPOL_ACCT
    FOREIGN KEY(ACCOUNTID)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NACTIVITY
    ADD CONSTRAINT FK_ACT_TRANS
    FOREIGN KEY(TRANSACTIONID)
    REFERENCES NTRANSACTION(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NACTIVITY
    ADD CONSTRAINT FK_ACT_ACCT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NACTIVITYDETAIL
    ADD CONSTRAINT FK_ACTIVDET_ACT
    FOREIGN KEY(ACTIVITYID)
    REFERENCES NACTIVITY(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NCONFIG
    ADD CONSTRAINT FK_CONFIG_ACCOUNT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NCONNECTION
    ADD CONSTRAINT FK_CONNECT_ACCOUNT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NDOCUMENT
    ADD CONSTRAINT FK_DOC_TRANS
    FOREIGN KEY(TRANSACTIONID)
    REFERENCES NTRANSACTION(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NFLOW
    ADD CONSTRAINT FK_FLOW_ACCOUNT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NNOTIFICATION
    ADD CONSTRAINT FK_NOTIF_FLOW
    FOREIGN KEY(FLOWID)
    REFERENCES NFLOW(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NNOTIFICATION
    ADD CONSTRAINT FK_NOTIF_ACCT
    FOREIGN KEY(ACCOUNTID)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NPARTNER
    ADD CONSTRAINT FK_PARTNER_ACCOUNT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NPLUGIN
    ADD CONSTRAINT FK_NPLUGIN_NFLOW
    FOREIGN KEY(FLOWID)
    REFERENCES NFLOW(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NPLUGIN
    ADD CONSTRAINT FK_NPLUGIN_NACCT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NREQUEST
    ADD CONSTRAINT FK_REQUEST_TRANS
    FOREIGN KEY(TRANSACTIONID)
    REFERENCES NTRANSACTION(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NREQUEST
    ADD CONSTRAINT FK_REQUEST_SVC
    FOREIGN KEY(SERVICEID)
    REFERENCES NSERVICE(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NREQUEST
    ADD CONSTRAINT FK_MODBY_REQ_ACCT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NREQUESTARG
    ADD CONSTRAINT FK_REQ_REQUEST
    FOREIGN KEY(REQUESTID)
    REFERENCES NREQUEST(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NSCHEDULESOURCEARG
    ADD CONSTRAINT FK_SCHEDSRC_SCHED
    FOREIGN KEY(SCHEDULEID)
    REFERENCES NSCHEDULE(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NSERVICE
    ADD CONSTRAINT FK_SERVICE_FLOW
    FOREIGN KEY(FLOWID)
    REFERENCES NFLOW(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NSERVICE
    ADD CONSTRAINT FK_SERVICE_ACCOUNT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NSERVICEARG
    ADD CONSTRAINT FK_SVCEARG_SVC
    FOREIGN KEY(SERVICEID)
    REFERENCES NSERVICE(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NSERVICECONN
    ADD CONSTRAINT FK_SVCCONN_SVC
    FOREIGN KEY(SERVICEID)
    REFERENCES NSERVICE(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NSERVICECONN
    ADD CONSTRAINT FK_SVCCONN_CONN
    FOREIGN KEY(CONNECTIONID)
    REFERENCES NCONNECTION(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NTRANSACTION
    ADD CONSTRAINT FK_MODBY_TRAN_ACCT
    FOREIGN KEY(MODIFIEDBY)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NTRANSACTIONNOTIFICATION
    ADD CONSTRAINT FK_TRANOT_TRANS
    FOREIGN KEY(TRANSACTIONID)
    REFERENCES NTRANSACTION(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;

ALTER TABLE NTRANSACTIONRECIPIENT
    ADD CONSTRAINT FK_TRANREC_TRANS
    FOREIGN KEY(TRANSACTIONID)
    REFERENCES NTRANSACTION(ID)
    ON DELETE CASCADE 
    ON UPDATE NO ACTION ;


CREATE TABLE NACCOUNTAUTHREQUEST (
    ID                          VARCHAR(50) NOT NULL,
    TRANSACTIONID               VARCHAR(50) NOT NULL,
    REQUESTGENERATEDON          DATE NOT NULL,
    REQUESTTYPE                 VARCHAR(255) NOT NULL,
    NAASACCOUNT                 VARCHAR(500) NOT NULL,
    FULLNAME                    VARCHAR(500) NOT NULL,
    ORGANIZATIONAFFILIATION     VARCHAR(500) NOT NULL,
    TELEPHONENUMBER             VARCHAR(25) NOT NULL,
    EMAILADDRESS                VARCHAR(500) NOT NULL,
    AFFILIATEDNODEID            VARCHAR(50) NOT NULL,
    AFFILIATEDCOUNTY            VARCHAR(255),
    PURPOSEDESCRIPTION          VARCHAR(4000),
    REQUESTEDNODEIDS            VARCHAR(1000) NOT NULL,
    AUTHORIZATIONACCOUNTID      VARCHAR(50),
    AUTHORIZATIONCOMMENTS       VARCHAR(4000),
    AUTHORIZATIONGENERATEDON    DATE,
    DIDCREATEINNAAS             VARCHAR(1)
    );

ALTER TABLE NACCOUNTAUTHREQUEST
    ADD CONSTRAINT PK_NACCTAUTHNREQ
    PRIMARY KEY (ID);

ALTER TABLE NACCOUNTAUTHREQUEST 
    ADD CONSTRAINT FK_ACTAUTHREQ_TRAN
    FOREIGN KEY(TRANSACTIONID)
    REFERENCES NTRANSACTION(ID)
    ON DELETE CASCADE;

ALTER TABLE NACCOUNTAUTHREQUEST 
    ADD CONSTRAINT FK_ACCTAUTHREQ_ACT
    FOREIGN KEY(AUTHORIZATIONACCOUNTID)
    REFERENCES NACCOUNT(ID)
    ON DELETE CASCADE;

CREATE TABLE NACCOUNTAUTHREQUESTFLOW (
    ID VARCHAR(50)          NOT NULL,
    ACCOUNTAUTHREQUESTID    VARCHAR(50) NOT NULL,
    FLOWNAME VARCHAR(255)   NOT NULL,
    ACCESSGRANTED           VARCHAR(1)
    );

ALTER TABLE NACCOUNTAUTHREQUESTFLOW
    ADD CONSTRAINT PK_NACTAUTHREQFLOW
    PRIMARY KEY (ID);

ALTER TABLE NACCOUNTAUTHREQUESTFLOW 
    ADD CONSTRAINT FK_AUTHFLW_AUTHREQ
    FOREIGN KEY(ACCOUNTAUTHREQUESTID)
    REFERENCES NACCOUNTAUTHREQUEST(ID)
    ON DELETE CASCADE;
    
