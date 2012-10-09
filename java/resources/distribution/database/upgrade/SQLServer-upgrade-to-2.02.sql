ALTER TABLE NAccount 
   ADD IsDeleted     VARCHAR(1) 
      ,IsDemoUser    VARCHAR(1)
      ,PasswordHash  VARCHAR(50);

ALTER TABLE NActivity 
   ADD WebMethod   VARCHAR(50)
      ,FlowName    VARCHAR(255)
      ,Operation   VARCHAR(255);

ALTER TABLE NActivityDetail ADD OrderIndex int ;

ALTER TABLE NConfig MODIFY Description VARCHAR(500) ;

ALTER TABLE NFlow MODIFY InfoUrl VARCHAR(500) ;

ALTER TABLE NNotification 
   ADD ModifiedBy   VARCHAR(50)
      ,ModifiedOn   DATETIME;

ALTER TABLE NPlugin ADD BinaryVersion VARCHAR(40) ;

ALTER TABLE NRequest ADD ParamsByName VARCHAR(1) ;

ALTER TABLE NSchedule 
   ADD SourceFlow             VARCHAR(255)
      ,TargetFlow             VARCHAR(255)
      ,TargetOperation         VARCHAR(255)
      ,LastExecuteActivityId   VARCHAR(50) ;

ALTER TABLE NService ADD PublishFlags VARCHAR(50) ;

ALTER TABLE NTransaction 
   ADD EndpointVersion              VARCHAR(50)
      ,NetworkEndpointVersion       VARCHAR(50)
      ,NetworkEndpointUrl           VARCHAR(500)
      ,NetworkEndpointStatus        VARCHAR(50)
      ,NetworkEndpointStatusDetail  VARCHAR(8000) ;

CREATE TABLE NNodeNotification
   (Id            VARCHAR(50)   NOT NULL
   ,TransactionId VARCHAR(50)   NOT NULL
   ,NotifyData    VARCHAR(4000) NOT NULL);
   
ALTER TABLE NNodeNotification
   ADD CONSTRAINT PK_NNodeNotification
   PRIMARY KEY (Id);

ALTER TABLE NNodeNotification  
   ADD CONSTRAINT FK_NNodeNotification_Transaction 
   FOREIGN KEY(TransactionId)
   REFERENCES NTransaction(Id)
   ON DELETE CASCADE 
   ON UPDATE CASCADE ;

CREATE TABLE NObjectCache 
   (Name          VARCHAR(50)    NOT NULL
   ,Data          VARBINARY(MAX) NOT NULL
   ,Expiration    DATETIME       NOT NULL
   ,ModifiedBy    VARCHAR(50)    NOT NULL
   ,ModifiedOn    DATETIME       NOT NULL) ;

ALTER TABLE NObjectCache
    ADD CONSTRAINT PK_NObjectCache
    PRIMARY KEY (Name);

CREATE TABLE NTransactionRealtimeDetails 
   (Id            VARCHAR(50)   NOT NULL
   ,StatusType    VARCHAR(50)   NOT NULL
   ,TransactionId VARCHAR(50)   NOT NULL
   ,Detail        VARCHAR(4000) NOT NULL
   ,OrderIndex    INT           NOT NULL
   ,ModifiedBy    VARCHAR(50)   NOT NULL
   ,ModifiedOn    DATETIME      NOT NULL) ;
   
ALTER TABLE NTransactionRealtimeDetails
   ADD CONSTRAINT PK_NTransactionRealtimeDetails
   PRIMARY KEY (Id);

ALTER TABLE NTransactionRealtimeDetails  
   ADD CONSTRAINT FK_NTransactionRealtimeDetails_Transaction 
   FOREIGN KEY(TransactionId)
   REFERENCES NTransaction(Id)
   ON DELETE CASCADE 
   ON UPDATE CASCADE ;

