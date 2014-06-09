alter table NAccount add column IsDeleted varchar(1) NULL;
alter table NAccount add column IsDemoUser varchar(1) NULL;
alter table NAccount add column PasswordHash varchar(50) NULL;

alter table NActivity add column WebMethod varchar(50) NULL;
alter table NActivity add column FlowName varchar(255) NULL;
alter table NActivity add column Operation varchar(255) NULL;

alter table NActivityDetail add column OrderIndex int NULL;

alter table NConfig modify Description varchar(500) null;

alter table NFlow modify InfoUrl varchar(500) null;

alter table NNotification add column ModifiedBy varchar(50) NULL;
alter table NNotification add column ModifiedOn datetime NULL;

alter table NPlugin add column BinaryVersion varchar(40) NULL;

alter table NRequest add column ParamsByName varchar(1) NULL;

alter table NSchedule add column SourceFlow varchar(255) NULL;
alter table NSchedule add column TargetFlow varchar(255) NULL;
alter table NSchedule add column TargetOperation varchar(255) NULL;
alter table NSchedule add column LastExecuteActivityId varchar(50) NULL;

alter table NService add column PublishFlags varchar(50) NULL;

alter table NTransaction modify NetworkId varchar(255) NULL;
alter table NTransaction add column EndpointVersion varchar(50) NULL;
alter table NTransaction add column NetworkEndpointVersion varchar(50) NULL;
alter table NTransaction add column NetworkEndpointUrl varchar(500) NULL;
alter table NTransaction add column NetworkEndpointStatus varchar(50) NULL;
alter table NTransaction add column NetworkEndpointStatusDetail varchar(8192) NULL;

CREATE TABLE NNodeNotification (
    Id            varchar(50) NOT NULL,
    TransactionId varchar(50) NOT NULL,
    NotifyData    varchar(4000) NOT NULL
    ) ENGINE=InnoDB;
ALTER TABLE NNodeNotification
    ADD CONSTRAINT PK_NNodeNotification
    PRIMARY KEY (Id);
ALTER TABLE NNodeNotification  
    ADD CONSTRAINT FK_NNodeNotification_Transaction 
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

CREATE TABLE NObjectCache (
    Name        varchar(50) NOT NULL,
    Data        longblob NOT NULL,
    Expiration  datetime NOT NULL,
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL 
    ) ENGINE=InnoDB;
ALTER TABLE NObjectCache
    ADD CONSTRAINT PK_NObjectCache
    PRIMARY KEY (Name);

CREATE TABLE NTransactionRealtimeDetails (
    Id            varchar(50) NOT NULL,
    StatusType    varchar(50) NOT NULL,
    TransactionId varchar(50) NOT NULL,
    Detail        varchar(4000) NOT NULL,
    OrderIndex    int NOT NULL,
    ModifiedBy    varchar(50) NOT NULL,
    ModifiedOn    datetime NOT NULL 
    ) ENGINE=InnoDB;
ALTER TABLE NTransactionRealtimeDetails
    ADD CONSTRAINT PK_NTransactionRealtimeDetails
    PRIMARY KEY (Id);
ALTER TABLE NTransactionRealtimeDetails  
    ADD CONSTRAINT FK_NTransactionRealtimeDetails_Transaction 
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;
