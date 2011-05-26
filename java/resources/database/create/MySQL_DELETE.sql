--  additions for HERE AuthorizationRequest feature    
ALTER TABLE NAccountAuthRequestFlow  
    DROP FOREIGN KEY FK_AccountAuthRequestFlow_AccountAuthRequest
;

ALTER TABLE NAccountAuthRequestFlow
    DROP PRIMARY KEY
;

DROP TABLE NAccountAuthRequestFlow
;

ALTER TABLE NAccountAuthRequest  
    DROP FOREIGN KEY FK_AccountAuthRequest_Account 
;

ALTER TABLE NAccountAuthRequest  
    DROP FOREIGN KEY FK_AccountAuthenticationRequest_Transaction 
;

ALTER TABLE NAccountAuthRequest
    DROP PRIMARY KEY
;

DROP TABLE NAccountAuthRequest
;
-- END additions for HERE AuthorizationRequest feature

ALTER TABLE NTransactionRecipient
    DROP FOREIGN KEY FK_TransactionRecipient_Transaction
;

ALTER TABLE NTransactionNotification
    DROP FOREIGN KEY FK_TransactionNotification_Transaction
;

ALTER TABLE NTransaction
    DROP FOREIGN KEY FK_ModifiedBy_Transaction_Account
;
    
ALTER TABLE NServiceConn
    DROP FOREIGN KEY FK_ServiceConn_Service
;

ALTER TABLE NServiceConn
    DROP FOREIGN KEY FK_ServiceConn_Connection
;

ALTER TABLE NServiceArg
    DROP FOREIGN KEY FK_ServiceArg_Service
;

ALTER TABLE NService
    DROP FOREIGN KEY FK_Service_Flow
;

ALTER TABLE NService
    DROP FOREIGN KEY FK_Service_Account
;

ALTER TABLE NScheduleSourceArg
    DROP FOREIGN KEY FK_ScheduleSourceArg_Schedule
;

ALTER TABLE NRequestArg
    DROP FOREIGN KEY FK_RequestArg_Request
;

ALTER TABLE NRequest
    DROP FOREIGN KEY FK_Request_Service
;

ALTER TABLE NRequest
    DROP FOREIGN KEY FK_Request_Transaction
;

ALTER TABLE NPlugin
    DROP FOREIGN KEY FK_NPlugin_NAccount
;

ALTER TABLE NPlugin
    DROP FOREIGN KEY FK_NPlugin_NFlow
;

ALTER TABLE NRequest
    DROP FOREIGN KEY FK_ModifiedBy_Request_Account
;

ALTER TABLE NPartner
    DROP FOREIGN KEY FK_Partner_Account
;

ALTER TABLE NNotification
    DROP FOREIGN KEY FK_Notification_Account
;

ALTER TABLE NNotification
    DROP FOREIGN KEY FK_Notification_Flow
;

ALTER TABLE NFlow
    DROP FOREIGN KEY FK_Flow_Account
;

ALTER TABLE NDocument
    DROP FOREIGN KEY FK_Document_Transaction
;

ALTER TABLE NConnection
    DROP FOREIGN KEY FK_Connection_Account
;

ALTER TABLE NConfig
    DROP FOREIGN KEY FK_Config_Account
;

ALTER TABLE NActivityDetail
    DROP FOREIGN KEY FK_ActivityDetail_Activity
;

ALTER TABLE NActivity
    DROP FOREIGN KEY FK_Activity_Transaction
;

ALTER TABLE NActivity
    DROP FOREIGN KEY FK_Activity_Account
;

ALTER TABLE NAccountPolicy
    DROP FOREIGN KEY FK_AccountPolicy_Account
;

ALTER TABLE NAccountPolicy
    DROP FOREIGN KEY FK_AccountIdPolicy_Account
;

ALTER TABLE NAccount
    DROP FOREIGN KEY FK_Account_Account
;

ALTER TABLE NTransactionRecipient
    DROP PRIMARY KEY
;

ALTER TABLE NTransactionNotification
    DROP PRIMARY KEY
;

ALTER TABLE NTransaction
    DROP PRIMARY KEY
;

ALTER TABLE NServiceConn
    DROP PRIMARY KEY
;

ALTER TABLE NServiceArg
    DROP PRIMARY KEY
;

ALTER TABLE NService
    DROP PRIMARY KEY
;

ALTER TABLE NScheduleSourceArg
    DROP PRIMARY KEY
;

ALTER TABLE NSchedule
    DROP PRIMARY KEY
;

ALTER TABLE NRequestArg
    DROP PRIMARY KEY
;

ALTER TABLE NRequest
    DROP PRIMARY KEY
;

ALTER TABLE NPartner
    DROP PRIMARY KEY
;

ALTER TABLE NNotification
    DROP PRIMARY KEY
;

ALTER TABLE NFlow
    DROP PRIMARY KEY
;

ALTER TABLE NDocument
    DROP PRIMARY KEY
;

ALTER TABLE NConnection
    DROP PRIMARY KEY
;

ALTER TABLE NConfig
    DROP PRIMARY KEY
;

ALTER TABLE NActivityDetail
    DROP PRIMARY KEY
;

ALTER TABLE NActivity
    DROP PRIMARY KEY
;

ALTER TABLE NAccountPolicy
    DROP PRIMARY KEY
;

ALTER TABLE NAccount
    DROP PRIMARY KEY
;


DROP TABLE NTransactionRecipient
;

DROP TABLE NTransactionNotification
;

DROP TABLE NTransaction
;

DROP TABLE NServiceConn
;

DROP TABLE NServiceArg
;

DROP TABLE NService
;

DROP TABLE NScheduleSourceArg
;

DROP TABLE NSchedule
;

DROP TABLE NRequestArg
;

DROP TABLE NRequest
;

DROP TABLE NPlugin
;

DROP TABLE NPartner
;

DROP TABLE NNotification
;

DROP TABLE NFlow
;

DROP TABLE NDocument
;

DROP TABLE NConnection
;

DROP TABLE NConfig
;

DROP TABLE NActivityDetail
;

DROP TABLE NActivity
;

DROP TABLE NAccountPolicy
;

DROP TABLE NAccount
;

