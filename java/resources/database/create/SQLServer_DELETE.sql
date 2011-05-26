--  additions for HERE AuthorizationRequest feature    
ALTER TABLE NAccountAuthRequestFlow  
    DROP CONSTRAINT FK_AccountAuthRequestFlow_AccountAuthRequest
;

ALTER TABLE NAccountAuthRequestFlow
    DROP CONSTRAINT PK_NAccountAuthRequestFlow
;

DROP TABLE NAccountAuthRequestFlow
;

ALTER TABLE NAccountAuthRequest  
    DROP CONSTRAINT FK_AccountAuthRequest_Account 
;

ALTER TABLE NAccountAuthRequest  
    DROP CONSTRAINT FK_AccountAuthenticationRequest_Transaction 
;

DROP TABLE NAccountAuthRequest
;
-- END additions for HERE AuthorizationRequest feature

ALTER TABLE NSERVICECONN
    DROP CONSTRAINT FK_SERVICECONN_SERVICE
;
ALTER TABLE NSERVICECONN
    DROP CONSTRAINT FK_SERVICECONN_CONNECTION
;
ALTER TABLE NSERVICEARG
    DROP CONSTRAINT FK_SERVICEARG_SERVICE
;
ALTER TABLE NSERVICE
    DROP CONSTRAINT FK_SERVICE_FLOW
;
ALTER TABLE NSERVICE
    DROP CONSTRAINT FK_SERVICE_ACCOUNT
;

ALTER TABLE NSCHEDULE
    DROP CONSTRAINT FK_SCHEDULE_ACCOUNT
;
ALTER TABLE NREQUESTARG
    DROP CONSTRAINT FK_REQUESTARG_REQUEST
;
ALTER TABLE NREQUEST
    DROP CONSTRAINT FK_REQUEST_TRANSACTION
;
ALTER TABLE NREQUEST
    DROP CONSTRAINT FK_REQUEST_SERVICE
;
ALTER TABLE NREQUEST
    DROP CONSTRAINT FK_MODIFIEDBY_REQUEST_ACCOUNT
;
ALTER TABLE NPARTNER
    DROP CONSTRAINT FK_PARTNER_ACCOUNT
;
ALTER TABLE NNOTIFICATION
    DROP CONSTRAINT FK_NOTIFICATION_FLOW
;
ALTER TABLE NNOTIFICATION
    DROP CONSTRAINT FK_NOTIFICATION_ACCOUNT
;

ALTER TABLE NFLOW
    DROP CONSTRAINT FK_FLOW_ACCOUNT
;
ALTER TABLE NDOCUMENTCONTENT
    DROP CONSTRAINT FK_DOCCONTENT_TRAN
;

ALTER TABLE NDOCUMENT
    DROP CONSTRAINT FK_DOCUMENT_TRANSACTION
;
ALTER TABLE NCONNECTION
    DROP CONSTRAINT FK_CONNECTION_ACCOUNT
;
ALTER TABLE NCONFIG
    DROP CONSTRAINT FK_CONFIG_ACCOUNT
;

ALTER TABLE NACTIVITY
    DROP CONSTRAINT FK_ACTIVITY_TRANSACTION
;
ALTER TABLE NACTIVITY
    DROP CONSTRAINT FK_ACTIVITY_ACCOUNT
;
ALTER TABLE NACCOUNTPOLICY
    DROP CONSTRAINT FK_ACCOUNTPOLICY_ACCOUNT
;
ALTER TABLE NACCOUNTPOLICY
    DROP CONSTRAINT FK_ACCOUNTIDPOLICY_ACCOUNT
;
ALTER TABLE NACCOUNT
    DROP CONSTRAINT FK_ACCOUNT_ACCOUNT
;
ALTER TABLE NTRANSACTIONRECIPIENT
    DROP CONSTRAINT PK_NTRANSACTIONRECIPIENT
;
ALTER TABLE NTRANSACTIONNOTIFICATION
    DROP CONSTRAINT PK_NTRANSACTIONNOTIFICATION
;
ALTER TABLE NTRANSACTION
    DROP CONSTRAINT PK_TRANSACTION
;
ALTER TABLE NSERVICECONN
    DROP CONSTRAINT PK_NSERVICECONN
;
ALTER TABLE NSERVICEARG
    DROP CONSTRAINT PK_SERVICEARG
;
ALTER TABLE NSERVICE
    DROP CONSTRAINT PK_SERVICE
;
ALTER TABLE NSCHEDULE
    DROP CONSTRAINT PK_SCHEDULE
;
ALTER TABLE NREQUESTARG
    DROP CONSTRAINT PK_REQUESTARG
;
ALTER TABLE NREQUEST
    DROP CONSTRAINT PK_REQUEST
;
ALTER TABLE NPARTNER
    DROP CONSTRAINT PK_PARTNER
;
ALTER TABLE NNOTIFICATION
    DROP CONSTRAINT PK_NOTIFICATION
;
ALTER TABLE NNODENOTIFICATION
    DROP CONSTRAINT PK_NNODENOTIFICATION
;
ALTER TABLE NFLOWROLE
    DROP CONSTRAINT PK_FLOWROLE
;
ALTER TABLE NFLOW
    DROP CONSTRAINT PK_FLOW
;
ALTER TABLE NDOCUMENTCONTENT
    DROP CONSTRAINT PK_NDOCUMENTCONTENT
;
ALTER TABLE NDOCUMENT
    DROP CONSTRAINT PK_DOCUMENT
;
ALTER TABLE NCONNECTION
    DROP CONSTRAINT PK_CONNECTION
;
ALTER TABLE NCONFIG
    DROP CONSTRAINT PK_CONFIG
;
ALTER TABLE NACTIVITYDETAIL
    DROP CONSTRAINT PK_ACTIVITYDETAIL
;
ALTER TABLE NACTIVITY
    DROP CONSTRAINT PK_ACTIVITY
;
ALTER TABLE NACCOUNTPOLICY
    DROP CONSTRAINT PK_NACCOUNTPOLICY
;
ALTER TABLE NACCOUNT
    DROP CONSTRAINT PK_ACCOUNT
;

ALTER TABLE NTRANSACTIONRECIPIENT
    DROP CONSTRAINT FK_TransactionRecipient_Transaction

DROP TABLE NTRANSACTIONRECIPIENT
;
DROP TABLE NTRANSACTIONNOTIFICATION
;
DROP TABLE NTRANSACTION
;
DROP TABLE NSERVICECONN
;
DROP TABLE NSERVICEARG
;
DROP TABLE NSERVICE
;

ALTER TABLE NSCHEDULE
    DROP CONSTRAINT PK_SCHEDULE
;

DROP TABLE NSCHEDULE
;
DROP TABLE NREQUESTARG
;
DROP TABLE NREQUEST
;
DROP TABLE NPARTNER
;
DROP TABLE NNOTIFICATION
;
DROP TABLE NNOTIFICATION
;

ALTER TABLE NFLOW
    DROP CONSTRAINT PK_FLOW
;

DROP TABLE NFLOW
;
DROP TABLE NDOCUMENTCONTENT
;
DROP TABLE NDOCUMENT
;
DROP TABLE NCONNECTION
;
DROP TABLE NCONFIG
;
DROP TABLE NACTIVITYDETAIL
;
DROP TABLE NACTIVITY
;
DROP TABLE NACCOUNTPOLICY
;
DROP TABLE NPLUGIN
;
DROP TABLE NSCHEDULESOURCEARG
;
DROP TABLE NACCOUNT
;

