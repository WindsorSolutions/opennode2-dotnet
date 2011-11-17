ALTER TABLE NAccount ADD COLUMN IsDeleted VARCHAR(1)
/
ALTER TABLE NAccount ADD COLUMN IsDemoUser VARCHAR(1)
/
ALTER TABLE NAccount ADD COLUMN PasswordHash VARCHAR(50)
/
ALTER TABLE NActivity ADD COLUMN WebMethod VARCHAR(50)
/
ALTER TABLE NActivity ADD COLUMN FlowName VARCHAR(255)
/
ALTER TABLE NActivity ADD COLUMN Operation VARCHAR(255)
/
ALTER TABLE NActivityDetail ADD COLUMN OrderIndex INT
/
ALTER TABLE NConfig ALTER COLUMN Description VARCHAR(500)
/
ALTER TABLE NFlow ALTER COLUMN InfoUrl VARCHAR(500)
/
ALTER TABLE NNotification ADD COLUMN ModifiedBy VARCHAR(50)
/
ALTER TABLE NNotification ADD COLUMN ModifiedOn TIMESTAMP
/
ALTER TABLE NPlugin ADD COLUMN BinaryVersion VARCHAR(40)
/
ALTER TABLE NRequest ADD COLUMN ParamsByName VARCHAR(1)
/
ALTER TABLE NSchedule ADD COLUMN SourceFlow VARCHAR(255)
/
ALTER TABLE NSchedule ADD COLUMN TargetFlow VARCHAR(255)
/
ALTER TABLE NSchedule ADD COLUMN TargetOperation VARCHAR(255)
/
ALTER TABLE NSchedule ADD COLUMN LastExecuteActivityId VARCHAR(50)
/
ALTER TABLE NService ADD COLUMN PublishFlags VARCHAR(50)
/
ALTER TABLE NTransaction ADD COLUMN EndpointVersion VARCHAR(50)
/
ALTER TABLE NTransaction ADD COLUMN NetworkEndpointVersion VARCHAR(50)
/
ALTER TABLE NTransaction ADD COLUMN NetworkEndpointUrl VARCHAR(500)
/
ALTER TABLE NTransaction ADD COLUMN NetworkEndpointStatus VARCHAR(50)
/
ALTER TABLE NTransaction ADD COLUMN NetworkEndpointStatusDetail VARCHAR(4000)
/
CREATE TABLE NNodeNotification 
   (Id            VARCHAR(50) NOT NULL
   ,TransactionId VARCHAR(50) NOT NULL
   ,NotifyData    VARCHAR(4000) NOT NULL)
/  
ALTER TABLE NNodeNotification
    ADD CONSTRAINT PK_NNodeNotification
    PRIMARY KEY (Id)
/
ALTER TABLE NNodeNotification  
    ADD CONSTRAINT FK_NNodeNotifTrans
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE RESTRICT 
/
CREATE TABLE NObjectCache 
   (Name        VARCHAR(50)   NOT NULL
   ,Data        VARCHAR(4000) NOT NULL
   ,Expiration  TIMESTAMP     NOT NULL
   ,ModifiedBy  VARCHAR(50)   NOT NULL
   ,ModifiedOn  TIMESTAMP     NOT NULL)
/
ALTER TABLE NObjectCache
    ADD CONSTRAINT PK_NObjectCache
    PRIMARY KEY (Name)
/
CREATE TABLE NTransactionRealtimeDetails 
  (Id            VARCHAR(50)   NOT NULL
  ,StatusType    VARCHAR(50)   NOT NULL
  ,TransactionId VARCHAR(50)   NOT NULL
  ,Detail        VARCHAR(4000) NOT NULL
  ,OrderIndex    INT           NOT NULL
  ,ModifiedBy    VARCHAR(50)   NOT NULL
  ,ModifiedOn    TIMESTAMP     NOT NULL)
/
ALTER TABLE NTransactionRealtimeDetails
    ADD CONSTRAINT PK_NTransRTDtls
    PRIMARY KEY (Id)
/	
ALTER TABLE NNodeNotification  
    ADD CONSTRAINT FK_NTranRTDtlTran 
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE RESTRICT 
/
