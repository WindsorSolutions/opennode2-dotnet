-- NOTE: MySQL must use the InnoDB storage engine in order for cascading deletes to work.

CREATE TABLE NAccount ( 
    Id          varchar(50) NOT NULL,
    NAASAccount varchar(500) NOT NULL,
    IsActive    char(1) NOT NULL,
    SystemRole  varchar(50) NOT NULL,
	Affiliation varchar(50) NOT NULL,
	IsDeleted varchar(1) NULL, -- added in 2.02
	IsDemoUser varchar(1) NULL, -- added in 2.02
	PasswordHash varchar(50) NULL, -- added in 2.02
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NAccountPolicy ( 
    Id          varchar(50) NOT NULL,
    AccountId   varchar(50) NOT NULL,
    PolicyType  varchar(50) NOT NULL,
    Qualifier   varchar(500) NOT NULL,
    IsAllowed   char(1) NOT NULL,
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NActivity ( 
    Id              varchar(50) NOT NULL,
    ActivityType    varchar(128) NOT NULL,
    TransactionId   varchar(50) NULL,
    IP              varchar(64) NULL,
    WebMethod varchar(50) NULL, -- added in 2.02
    FlowName varchar(255) NULL, -- added in 2.02
    Operation varchar(255) NULL, -- added in 2.02
    ModifiedBy      varchar(50) NOT NULL,
    ModifiedOn      datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NActivityDetail ( 
    Id          varchar(50) NOT NULL,
    ActivityId  varchar(50) NOT NULL,
    Detail      text NOT NULL,
    OrderIndex  int NULL, -- added in 2.02
    ModifiedOn  datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NConfig ( 
    Id          varchar(255) NOT NULL,
    ConfigValue varchar(8192) NOT NULL,
    Description varchar(500) NULL, -- changed in 2.02 to be nullable
    Name        varchar(255) NULL, -- added in 2.20
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL,
    IsEditable  char(1) NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NConnection ( 
    Id                  varchar(50) NOT NULL,
    Code                varchar(255) NOT NULL,
    Provider            varchar(500) NOT NULL,
    ConnectionString    varchar(500) NOT NULL,
    ModifiedBy          varchar(50) NOT NULL,
    ModifiedOn          datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NDocument ( 
    Id              varchar(50) NOT NULL,
    TransactionId   varchar(50) NOT NULL,
    DocumentName    varchar(255) NOT NULL,
    DocumentType    varchar(255) NOT NULL,
    DocumentId      varchar(255) NOT NULL,
    Status          varchar(50) NOT NULL,
    StatusDetail    varchar(8192) NULL,
    DocumentContent longblob NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NFlow ( 
    Id          varchar(50) NOT NULL,
    InfoUrl     varchar(500) NULL, -- changed in 2.02 to be nullable
    Contact     varchar(255) NOT NULL,
    IsProtected char(1) NOT NULL,
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL,
    Code        varchar(255) NOT NULL,
    TargetExchangeName varchar(255) NULL,
    Description varchar(500) NULL
    ) ENGINE=InnoDB;

CREATE TABLE NNotification ( 
    Id          varchar(50) NOT NULL,
    FlowId      varchar(50) NOT NULL,
    AccountId   varchar(50) NOT NULL,
    OnSolicit   char(1) NOT NULL,
    OnQuery     char(1) NOT NULL,
    OnSubmit    char(1) NOT NULL,
    OnNotify    char(1) NOT NULL,
    OnSchedule  char(1) NOT NULL,
    OnDownload  char(1) NOT NULL,
    OnExecute   char(1) NOT NULL,
    OnError     char(1) NULL,
    ModifiedBy  varchar(50) NULL,
    ModifiedOn  datetime NULL
    ) ENGINE=InnoDB;

CREATE TABLE NPartner ( 
    Id          varchar(50) NOT NULL,
    Name        varchar(500) NOT NULL,
    Url         varchar(500) NOT NULL,
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL,
    Version     varchar(50) NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NPlugin ( 
    Id              varchar(50) NOT NULL,
    FlowId          varchar(50) NOT NULL,
    ModifiedBy      varchar(50) NOT NULL,
    ModifiedOn      datetime NOT NULL,
    PluginContent   longblob NOT NULL,
    BinaryVersion   varchar(40) NULL
    ) ENGINE=InnoDB;

CREATE TABLE NRequest ( 
    Id              varchar(50) NOT NULL,
    TransactionId   varchar(50) NULL,
    ServiceId       varchar(50) NOT NULL,
    RowIndex        int NOT NULL,
    MaxRowCount     int NOT NULL,
    RequestType     varchar(50) NOT NULL,
    ParamsByName    varchar(1) NULL,
    ModifiedBy      varchar(50) NOT NULL,
    ModifiedOn      datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NRequestArg ( 
    Id          varchar(50) NOT NULL,
    RequestId   varchar(50) NOT NULL,
    ArgKey      varchar(255) NOT NULL,
    ArgValue    varchar(1024) NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NSchedule ( 
    Id                  varchar(50) NOT NULL,
    Name                varchar(50) NOT NULL,
    FlowId              varchar(50) NOT NULL,
    StartOn             datetime NOT NULL,
    EndOn               datetime NOT NULL,
    SourceType          varchar(50) NOT NULL,
    SourceId            varchar(255) NOT NULL,
    SourceOperation     varchar(255) NULL,
    TargetType          varchar(50) NULL,
    TargetId            varchar(255) NULL,
    LastExecutionInfo   text NULL,
    LastExecutedOn      datetime NULL,
    NextRun             datetime NULL,
    FrequencyType       varchar(50) NOT NULL,
    Frequency           int NOT NULL,
    ModifiedBy          varchar(50) NOT NULL,
    ModifiedOn          datetime NOT NULL,
    IsActive            varchar(1) NOT NULL,
    IsRunNow            varchar(1) NOT NULL,
    ExecuteStatus       varchar(50) NOT NULL,
    SourceFlow          varchar(255) NULL,
    TargetFlow          varchar(255) NULL, 
    TargetOperation     varchar(255) NULL,
    LastExecuteActivityId  varchar(50) NULL
    ) ENGINE=InnoDB;

CREATE TABLE NScheduleSourceArg ( 
    Id          varchar(50) NOT NULL,
    ScheduleId  varchar(50) NOT NULL,
    ArgKey      varchar(255) NOT NULL,
    ArgValue    text NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NService ( 
    Id          varchar(50) NOT NULL,
    Name        varchar(50) NOT NULL,
    FlowId      varchar(50) NOT NULL,
    IsActive    char(1) NOT NULL,
    ServiceType varchar(128) NOT NULL,
    Implementor varchar(500) NOT NULL,
    AuthLevel   varchar(50) NOT NULL,
    PublishFlags varchar(50) NULL,
    AuthRequired varchar(1) NULL,
    ModifiedBy  varchar(50) NOT NULL,
    ModifiedOn  datetime NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NServiceArg ( 
    Id          varchar(50) NOT NULL,
    ServiceId   varchar(50) NOT NULL,
    ArgKey      varchar(255) NOT NULL,
    ArgValue    varchar(1024)
    ) ENGINE=InnoDB;

CREATE TABLE NServiceConn ( 
    Id              varchar(50) NOT NULL,
    ServiceId       varchar(50) NOT NULL,
    ConnectionId    varchar(50) NOT NULL,
    KeyName         varchar(255) NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NTransaction ( 
    Id                          varchar(50) NOT NULL,
    FlowId                      varchar(50) NOT NULL,
    NetworkId                   varchar(255) NULL,
    Status                      varchar(50) NOT NULL,
    ModifiedBy                  varchar(50) NOT NULL,
    ModifiedOn                  datetime NOT NULL,
    StatusDetail                varchar(8192) NULL,
    Operation                   varchar(255) NULL,
    WebMethod                   varchar(50) NOT NULL,
    EndpointVersion             varchar(50) NULL,
    NetworkEndpointVersion      varchar(50) NULL, 
    NetworkEndpointUrl          varchar(500) NULL,
    NetworkEndpointStatus       varchar(50) NULL,
    NetworkEndpointStatusDetail varchar(8192) NULL
    ) ENGINE=InnoDB;

CREATE TABLE NTransactionNotification ( 
    Id              varchar(50) NOT NULL,
    TransactionId   varchar(50) NOT NULL,
    Uri             varchar(500) NOT NULL,
    Type            varchar(50) NOT NULL 
    ) ENGINE=InnoDB;

CREATE TABLE NTransactionRecipient ( 
    Id              varchar(50) NOT NULL,
    TransactionId   varchar(50) NOT NULL,
    Uri             varchar(500) NOT NULL 
    ) ENGINE=InnoDB;


ALTER TABLE NAccount
    ADD CONSTRAINT PK_Account
    PRIMARY KEY (Id);

ALTER TABLE NAccountPolicy
    ADD CONSTRAINT PK_NAccountPolicy
    PRIMARY KEY (Id);

ALTER TABLE NActivity
    ADD CONSTRAINT PK_Activity
    PRIMARY KEY (Id);

ALTER TABLE NActivityDetail
    ADD CONSTRAINT PK_ActivityDetail
    PRIMARY KEY (Id);

ALTER TABLE NConfig
    ADD CONSTRAINT PK_Config
    PRIMARY KEY (Id);

ALTER TABLE NConnection
    ADD CONSTRAINT PK_Connection
    PRIMARY KEY (Id);

ALTER TABLE NDocument
    ADD CONSTRAINT PK_Document
    PRIMARY KEY (Id);

ALTER TABLE NFlow
    ADD CONSTRAINT PK_Flow
    PRIMARY KEY (Id);

ALTER TABLE NNotification
    ADD CONSTRAINT PK_Notification
    PRIMARY KEY (Id);

ALTER TABLE NPartner
    ADD CONSTRAINT PK_Partner
    PRIMARY KEY (Id);

ALTER TABLE NRequest
    ADD CONSTRAINT PK_Request
    PRIMARY KEY (Id);

ALTER TABLE NRequestArg
    ADD CONSTRAINT PK_RequestArg
    PRIMARY KEY (Id);

ALTER TABLE NSchedule
    ADD CONSTRAINT PK_Schedule
    PRIMARY KEY (Id);

ALTER TABLE NScheduleSourceArg
    ADD CONSTRAINT PK_NScheduleSourceArg
    PRIMARY KEY (Id);

ALTER TABLE NService
    ADD CONSTRAINT PK_Service
    PRIMARY KEY (Id);

ALTER TABLE NServiceArg
    ADD CONSTRAINT PK_ServiceArg
    PRIMARY KEY (Id);

ALTER TABLE NServiceConn
    ADD CONSTRAINT PK_NServiceConn
    PRIMARY KEY (Id);

ALTER TABLE NTransaction
    ADD CONSTRAINT PK_Transaction
    PRIMARY KEY (Id);

ALTER TABLE NTransactionNotification
    ADD CONSTRAINT PK_NTransactionNotification
    PRIMARY KEY (Id);

ALTER TABLE NTransactionRecipient
    ADD CONSTRAINT PK_NTransactionRecipient
    PRIMARY KEY (Id);

ALTER TABLE NAccount
    ADD CONSTRAINT UNQ_Account_NAASAccount
    UNIQUE (NAASAccount);

ALTER TABLE NConnection
    ADD CONSTRAINT UNQ_Connection_Code
    UNIQUE (Code);

ALTER TABLE NDocument
    ADD CONSTRAINT UNQ_Document_TransactionIdDocumentName
    UNIQUE (TransactionId, DocumentName);

ALTER TABLE NFlow
    ADD CONSTRAINT UNQ_Flow_Code
    UNIQUE (Code);

ALTER TABLE NNotification
    ADD CONSTRAINT UNQ_Notification_FlowIdAccountId
    UNIQUE (FlowId, AccountId);

ALTER TABLE NPartner
    ADD CONSTRAINT UNQ_Partner_Name
    UNIQUE (Name);

ALTER TABLE NPartner
    ADD CONSTRAINT IX_NPartner
    UNIQUE (Name);

ALTER TABLE NScheduleSourceArg
    ADD CONSTRAINT UNQ_ScheduleSourceArg_ScheduleIdName
    UNIQUE (ScheduleId, ArgKey);

ALTER TABLE NService
    ADD CONSTRAINT UNQ_Service_NameFlowId
    UNIQUE (Name, FlowId);

ALTER TABLE NServiceConn
    ADD CONSTRAINT UNQ_Service_ServiceIdKeyName
    UNIQUE (ServiceId, KeyName);

ALTER TABLE NAccount
    ADD CONSTRAINT FK_Account_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NAccountPolicy
    ADD CONSTRAINT FK_AccountPolicy_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NAccountPolicy
    ADD CONSTRAINT FK_AccountIdPolicy_Account
    FOREIGN KEY(AccountId)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NActivity
    ADD CONSTRAINT FK_Activity_Transaction
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NActivity
    ADD CONSTRAINT FK_Activity_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NActivityDetail
    ADD CONSTRAINT FK_ActivityDetail_Activity
    FOREIGN KEY(ActivityId)
    REFERENCES NActivity(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NConfig
    ADD CONSTRAINT FK_Config_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NConnection
    ADD CONSTRAINT FK_Connection_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NDocument
    ADD CONSTRAINT FK_Document_Transaction
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NFlow
    ADD CONSTRAINT FK_Flow_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NNotification
    ADD CONSTRAINT FK_Notification_Flow
    FOREIGN KEY(FlowId)
    REFERENCES NFlow(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NNotification
    ADD CONSTRAINT FK_Notification_Account
    FOREIGN KEY(AccountId)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NPartner
    ADD CONSTRAINT FK_Partner_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NPlugin
    ADD CONSTRAINT FK_NPlugin_NFlow
    FOREIGN KEY(FlowId)
    REFERENCES NFlow(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NPlugin
    ADD CONSTRAINT FK_NPlugin_NAccount
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NRequest
    ADD CONSTRAINT FK_Request_Transaction
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NRequest
    ADD CONSTRAINT FK_Request_Service
    FOREIGN KEY(ServiceId)
    REFERENCES NService(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NRequest
    ADD CONSTRAINT FK_ModifiedBy_Request_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NRequestArg
    ADD CONSTRAINT FK_RequestArg_Request
    FOREIGN KEY(RequestId)
    REFERENCES NRequest(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NScheduleSourceArg
    ADD CONSTRAINT FK_ScheduleSourceArg_Schedule
    FOREIGN KEY(ScheduleId)
    REFERENCES NSchedule(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NService
    ADD CONSTRAINT FK_Service_Flow
    FOREIGN KEY(FlowId)
    REFERENCES NFlow(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NService
    ADD CONSTRAINT FK_Service_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NServiceArg
    ADD CONSTRAINT FK_ServiceArg_Service
    FOREIGN KEY(ServiceId)
    REFERENCES NService(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NServiceConn
    ADD CONSTRAINT FK_ServiceConn_Service
    FOREIGN KEY(ServiceId)
    REFERENCES NService(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NServiceConn
    ADD CONSTRAINT FK_ServiceConn_Connection
    FOREIGN KEY(ConnectionId)
    REFERENCES NConnection(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NTransaction
    ADD CONSTRAINT FK_ModifiedBy_Transaction_Account
    FOREIGN KEY(ModifiedBy)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NTransactionNotification
    ADD CONSTRAINT FK_TransactionNotification_Transaction
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NTransactionRecipient
    ADD CONSTRAINT FK_TransactionRecipient_Transaction
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;


-- additions for HERE AuthorizationRequest feature

CREATE TABLE NAccountAuthRequest (
    Id                          varchar(50) NOT NULL,
    TransactionId               varchar(50) NOT NULL,
    RequestGeneratedOn          datetime NOT NULL,
    RequestType                 varchar(255) NOT NULL,
    NAASAccount                 varchar(500) NOT NULL,
    FullName                    varchar(500) NOT NULL,
    OrganizationAffiliation     varchar(500) NOT NULL,
    TelephoneNumber             varchar(25) NOT NULL,
    EmailAddress                varchar(500) NOT NULL,
    AffiliatedNodeId            varchar(50) NOT NULL,
    AffiliatedCounty            varchar(255) NULL,
    PurposeDescription          varchar(4000) NULL,
    RequestedNodeIds            varchar(1000) NOT NULL,
    AuthorizationAccountId      varchar(50) NULL,
    AuthorizationComments       varchar(4000) NULL,
    AuthorizationGeneratedOn    datetime NULL,
    DidCreateInNaas             varchar(1) NULL
    );
    
ALTER TABLE NAccountAuthRequest
    ADD CONSTRAINT PK_NAccountAuthenticationRequest
    PRIMARY KEY (Id);

ALTER TABLE NAccountAuthRequest  
    ADD CONSTRAINT FK_AccountAuthenticationRequest_Transaction 
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

ALTER TABLE NAccountAuthRequest  
    ADD CONSTRAINT FK_AccountAuthRequest_Account 
    FOREIGN KEY(AuthorizationAccountId)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;

    
CREATE TABLE NAccountAuthRequestFlow (
    Id varchar(50)          NOT NULL,
    AccountAuthRequestId    varchar(50) NOT NULL,
    FlowName varchar(255)   NOT NULL,
    AccessGranted           varchar(1) NULL
    );

ALTER TABLE NAccountAuthRequestFlow
    ADD CONSTRAINT PK_NAccountAuthRequestFlow
    PRIMARY KEY (Id);
    
ALTER TABLE NAccountAuthRequestFlow  
    ADD CONSTRAINT FK_AccountAuthRequestFlow_AccountAuthRequest
    FOREIGN KEY(AccountAuthRequestId)
    REFERENCES NAccountAuthRequest(Id)
    ON DELETE CASCADE 
    ON UPDATE CASCADE ;
    
-- END additions for HERE AuthorizationRequest feature

-- Additions for 2.02
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
-- End Additions for 2.02