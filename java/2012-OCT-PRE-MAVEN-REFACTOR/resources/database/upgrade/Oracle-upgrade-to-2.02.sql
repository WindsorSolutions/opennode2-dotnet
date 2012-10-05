ALTER TABLE NAccount 
   ADD (IsDeleted    VARCHAR2(1)
       ,IsDemoUser   VARCHAR2(1)
       ,PasswordHash VARCHAR2(50));

ALTER TABLE NActivity 
   ADD (WebMethod     VARCHAR2(50)
       ,FlowName      VARCHAR2(255)
       ,Operation     VARCHAR2(255) );

ALTER TABLE NActivityDetail ADD (OrderIndex NUMBER );

ALTER TABLE NConfig MODIFY Description VARCHAR2(500);

ALTER TABLE NFlow MODIFY InfoUrl VARCHAR2(500);

ALTER TABLE NNotification 
ADD (ModifiedBy    VARCHAR2(50)
    ,ModifiedOn    DATE);

ALTER TABLE NPlugin ADD (BinaryVersion VARCHAR2(40));

ALTER TABLE NRequest ADD (ParamsByName VARCHAR2(1));

ALTER TABLE NSchedule 
   ADD (SourceFlow             VARCHAR2(255)  
       ,TargetFlow             VARCHAR2(255) 
       ,TargetOperation        VARCHAR2(255)
       ,LastExecuteActivityId  VARCHAR2(50));

ALTER TABLE NService ADD ( PublishFlags VARCHAR2(50) );

ALTER TABLE NTransaction 
   ADD (EndpointVersion                VARCHAR2(50) 
       ,NetworkEndpointVersion         VARCHAR2(50) 
       ,NetworkEndpointUrl             VARCHAR2(500) 
       ,NetworkEndpointStatus          VARCHAR2(50)
       ,NetworkEndpointStatusDetail    VARCHAR2(4000) );

CREATE TABLE NNodeNotification 
   (ID            VARCHAR2(50)   NOT NULL
   ,TransactionId VARCHAR2(50)   NOT NULL
   ,NotifyData    VARCHAR2(4000) NOT NULL) ;
    
ALTER TABLE NNodeNotification
    ADD CONSTRAINT PK_NNodeNotification
    PRIMARY KEY (ID);
    
ALTER TABLE NNodeNotification  
    ADD CONSTRAINT FK_NNodeNotif_Trans 
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(ID)
    ON DELETE CASCADE; 
    -- ON UPDATE CASCADE ;  no update cascade in Oracle

CREATE TABLE NObjectCache
   (NAME        VARCHAR2(50) NOT NULL
   ,DATA        BLOB         NOT NULL
   ,Expiration  DATE         NOT NULL
   ,ModifiedBy  VARCHAR2(50) NOT NULL
   ,ModifiedOn  DATE         NOT NULL);
    
ALTER TABLE NObjectCache
    ADD CONSTRAINT PK_NObjectCache
    PRIMARY KEY (NAME);

CREATE TABLE NTransactionRealtimeDetails
   (ID            VARCHAR2(50)   NOT NULL
   ,StatusType    VARCHAR2(50)   NOT NULL
   ,TransactionId VARCHAR2(50)   NOT NULL
   ,Detail        VARCHAR2(4000) NOT NULL
   ,OrderIndex    NUMBER         NOT NULL
   ,ModifiedBy    VARCHAR2(50)   NOT NULL
   ,ModifiedOn    DATE           NOT NULL);
   
ALTER TABLE NTransactionRealtimeDetails
    ADD CONSTRAINT PK_NTransactionRealtimeDetails
    PRIMARY KEY (ID);

ALTER TABLE NTransactionRealtimeDetails  
    ADD CONSTRAINT FK_NTransRealtimeDtl_Trans 
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(ID)
    ON DELETE CASCADE ;
    -- ON UPDATE CASCADE ;

