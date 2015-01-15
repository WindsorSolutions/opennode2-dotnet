

CREATE TABLE NAccount ( 
	Id         	varchar2(50) NOT NULL,
	NAASAccount	varchar2(500) NOT NULL,
	IsActive   	char(1) NOT NULL,
	SystemRole 	varchar2(50) NOT NULL,
	Affiliation varchar2(50) NOT NULL,
	IsDeleted    VARCHAR2(1) NULL,
    IsDemoUser   VARCHAR2(1) NULL,
    PasswordHash VARCHAR2(50) NULL,
	ModifiedBy 	varchar2(50) NOT NULL,
	ModifiedOn 	date NOT NULL 
	)
;

CREATE TABLE NAccountPolicy ( 
	Id        	varchar2(50) NOT NULL,
	AccountId 	varchar2(50) NOT NULL,
	PolicyType	varchar2(50) NOT NULL,
	Qualifier 	varchar2(500) NOT NULL,
	IsAllowed 	char(1) NOT NULL,
	ModifiedBy	varchar2(50) NOT NULL,
	ModifiedOn	date NOT NULL 
	)
;

CREATE TABLE NActivity ( 
	Id           	varchar2(50) NOT NULL,
	ActivityType 	varchar2(128) NOT NULL,
	TransactionId	varchar2(50) NULL,
	IP           	varchar2(64) NULL,
	WebMethod       VARCHAR2(50) NULL,
    FlowName        VARCHAR2(255) NULL,
    Operation       VARCHAR2(255) NULL,
	ModifiedBy   	varchar2(50) NOT NULL,
	ModifiedOn   	date NOT NULL 
	)
;

CREATE TABLE NActivityDetail ( 
	Id        	varchar2(50) NOT NULL,
	ActivityId	varchar2(50) NOT NULL,
	Detail    	varchar2(4000) NOT NULL,
	OrderIndex  NUMBER NULL,
	ModifiedOn	date NOT NULL 
	)
;

CREATE TABLE NConfig ( 
	Id         	varchar2(255) NOT NULL,
	ConfigValue	varchar2(4000) NOT NULL,
	Description	varchar2(500) NULL,
	ModifiedBy 	varchar2(50) NOT NULL,
	ModifiedOn 	date NOT NULL,
	IsEditable 	char(1) NOT NULL 
	)
;

CREATE TABLE NConnection ( 
	Id              	varchar2(50) NOT NULL,
	Code            	varchar2(255) NOT NULL,
	Provider        	varchar2(500) NOT NULL,
	ConnectionString	varchar2(500) NOT NULL,
	ModifiedBy      	varchar2(50) NOT NULL,
	ModifiedOn      	date NOT NULL 
	)
;

CREATE TABLE NDocument ( 
	Id             	varchar2(50) NOT NULL,
	TransactionId  	varchar2(50) NOT NULL,
	DocumentName   	varchar2(255) NOT NULL,
	DocumentType   	varchar2(255) NOT NULL,
	DocumentId     	varchar2(255) NOT NULL,
	Status         	varchar2(50) NOT NULL,
	StatusDetail   	varchar2(4000) NULL,
	DocumentContent	blob NULL 
	)
;

CREATE TABLE NFlow ( 
	Id         	varchar2(50) NOT NULL,
	InfoUrl    	varchar2(500) NULL,
	Contact    	varchar2(255) NOT NULL,
	IsProtected	char(1) NOT NULL,
	ModifiedBy 	varchar2(50) NOT NULL,
	ModifiedOn 	date NOT NULL,
	Code       	varchar2(255) NOT NULL,
	TargetExchangeName varchar2(255) NULL,
	Description	varchar2(500) NULL 
	)
;

CREATE TABLE NNotification ( 
	Id        	varchar2(50) NOT NULL,
	FlowId    	varchar2(50) NOT NULL,
	AccountId 	varchar2(50) NOT NULL,
	OnSolicit 	char(1) NOT NULL,
	OnQuery   	char(1) NOT NULL,
	OnSubmit  	char(1) NOT NULL,
	OnNotify  	char(1) NOT NULL,
	OnSchedule	char(1) NOT NULL,
	OnDownload	char(1) NOT NULL,
	OnExecute 	char(1) NOT NULL,
	ModifiedBy  VARCHAR2(50) NULL,
    ModifiedOn  DATE NULL
	)
;

CREATE TABLE NPartner ( 
	Id        	varchar2(50) NOT NULL,
	Name      	varchar2(500) NOT NULL,
	Url       	varchar2(500) NOT NULL,
	ModifiedBy	varchar2(50) NOT NULL,
	ModifiedOn	date NOT NULL,
	Version   	varchar2(50) NOT NULL 
	)
;

CREATE TABLE NPlugin ( 
	Id           	varchar2(50) NOT NULL,
	FlowId       	varchar2(50) NOT NULL,
	ModifiedBy   	varchar2(50) NOT NULL,
	ModifiedOn   	date NOT NULL,
	PluginContent	blob NOT NULL,
	BinaryVersion   VARCHAR2(40) NULL
	)
;

CREATE TABLE NRequest ( 
	Id           	varchar2(50) NOT NULL,
	TransactionId	varchar2(50) NULL,
	ServiceId    	varchar2(50) NOT NULL,
	RowIndex     	number NOT NULL,
	MaxRowCount  	number NOT NULL,
	RequestType  	varchar2(50) NOT NULL,
	ParamsByName    VARCHAR2(1) NULL,
	ModifiedBy   	varchar2(50) NOT NULL,
	ModifiedOn   	date NOT NULL 
	)
;

CREATE TABLE NRequestArg ( 
	Id       	varchar2(50) NOT NULL,
	RequestId	varchar2(50) NOT NULL,
	ArgKey   	varchar2(255) NOT NULL,
	ArgValue 	varchar2(1024) NOT NULL 
	)
;

CREATE TABLE NSchedule ( 
	Id               	varchar2(50) NOT NULL,
	Name             	varchar2(50) NOT NULL,
	FlowId           	varchar2(50) NOT NULL,
	StartOn          	date NOT NULL,
	EndOn            	date NOT NULL,
	SourceType       	varchar2(50) NOT NULL,
	SourceId         	varchar2(255) NOT NULL,
	SourceOperation  	varchar2(255) NULL,
	TargetType       	varchar2(50) NULL,
	TargetId         	varchar2(255) NULL,
	LastExecutionInfo	varchar2(4000) NULL,
	LastExecutedOn   	date NULL,
	NextRun          	date NULL,
	FrequencyType    	varchar2(50) NOT NULL,
	Frequency        	number NOT NULL,
	ModifiedBy       	varchar2(50) NOT NULL,
	ModifiedOn       	date NOT NULL,
	IsActive         	varchar2(1) NOT NULL,
	IsRunNow         	varchar2(1) NOT NULL,
	ExecuteStatus    	varchar2(50) NOT NULL,
	SourceFlow          VARCHAR2(255) NULL,
    TargetFlow          VARCHAR2(255) NULL, 
    TargetOperation     VARCHAR2(255) NULL,
    LastExecuteActivityId  VARCHAR2(50) NULL
	)
;

CREATE TABLE NScheduleSourceArg ( 
	Id        	varchar2(50) NOT NULL,
	ScheduleId	varchar2(50) NOT NULL,
	ArgKey    	varchar2(255) NOT NULL,
	ArgValue  	varchar2(4000) NULL 
	)
;

CREATE TABLE NService ( 
	Id         	varchar2(50) NOT NULL,
	Name       	varchar2(50) NOT NULL,
	FlowId     	varchar2(50) NOT NULL,
	IsActive   	char(1) NOT NULL,
	ServiceType	varchar2(128) NOT NULL,
	Implementor	varchar2(500) NOT NULL,
	AuthLevel  	varchar2(50) NOT NULL,
	PublishFlags VARCHAR2(50) NULL,
	AuthRequired varchar2(1) NULL,
	ModifiedBy 	varchar2(50) NOT NULL,
	ModifiedOn 	date NOT NULL 
	)
;

CREATE TABLE NServiceArg ( 
	Id       	varchar2(50) NOT NULL,
	ServiceId	varchar2(50) NOT NULL,
	ArgKey   	varchar2(255) NOT NULL,
	ArgValue 	varchar2(1024) NOT NULL 
	)
;

CREATE TABLE NServiceConn ( 
	Id          	varchar2(50) NOT NULL,
	ServiceId   	varchar2(50) NOT NULL,
	ConnectionId	varchar2(50) NOT NULL,
	KeyName     	varchar2(255) NOT NULL 
	)
;

CREATE TABLE NTransaction ( 
	Id          	varchar2(50) NOT NULL,
	FlowId      	varchar2(50) NOT NULL,
	NetworkId   	varchar2(255) NOT NULL,
	Status      	varchar2(50) NOT NULL,
	ModifiedBy  	varchar2(50) NOT NULL,
	ModifiedOn  	date NOT NULL,
	StatusDetail	varchar2(4000) NULL,
	Operation   	varchar2(255) NULL,
	WebMethod   	varchar2(50) NOT NULL,
	EndpointVersion             VARCHAR2(50) NULL,
    NetworkEndpointVersion      VARCHAR2(50) NULL, 
    NetworkEndpointUrl          VARCHAR2(500) NULL,
    NetworkEndpointStatus       VARCHAR2(50) NULL,
    NetworkEndpointStatusDetail VARCHAR2(4000) NULL
	)
;

CREATE TABLE NTransactionNotification ( 
	Id           	varchar2(50) NOT NULL,
	TransactionId	varchar2(50) NOT NULL,
	Uri          	varchar2(500) NOT NULL,
	Type         	varchar2(50) NOT NULL 
	)
;

CREATE TABLE NTransactionRecipient ( 
	Id           	varchar2(50) NOT NULL,
	TransactionId	varchar2(50) NOT NULL,
	Uri          	varchar2(500) NOT NULL 
	)
;


ALTER TABLE NAccount
	ADD CONSTRAINT PK_Account
	PRIMARY KEY (Id)
;

ALTER TABLE NAccountPolicy
	ADD CONSTRAINT PK_NAccountPolicy
	PRIMARY KEY (Id)
;

ALTER TABLE NActivity
	ADD CONSTRAINT PK_Activity
	PRIMARY KEY (Id)
;

ALTER TABLE NActivityDetail
	ADD CONSTRAINT PK_ActivityDetail
	PRIMARY KEY (Id)
;

ALTER TABLE NConfig
	ADD CONSTRAINT PK_Config
	PRIMARY KEY (Id)
;

ALTER TABLE NConnection
	ADD CONSTRAINT PK_Connection
	PRIMARY KEY (Id)
;

ALTER TABLE NDocument
	ADD CONSTRAINT PK_Document
	PRIMARY KEY (Id)
;

ALTER TABLE NFlow
	ADD CONSTRAINT PK_Flow
	PRIMARY KEY (Id)
;

ALTER TABLE NNotification
	ADD CONSTRAINT PK_Notification
	PRIMARY KEY (Id)
;

ALTER TABLE NPartner
	ADD CONSTRAINT PK_Partner
	PRIMARY KEY (Id)
;

ALTER TABLE NRequest
	ADD CONSTRAINT PK_Request
	PRIMARY KEY (Id)
;

ALTER TABLE NRequestArg
	ADD CONSTRAINT PK_RequestArg
	PRIMARY KEY (Id)
;

ALTER TABLE NSchedule
	ADD CONSTRAINT PK_Schedule
	PRIMARY KEY (Id)
;

ALTER TABLE NScheduleSourceArg
	ADD CONSTRAINT PK_NScheduleSourceArg
	PRIMARY KEY (Id)
;

ALTER TABLE NService
	ADD CONSTRAINT PK_Service
	PRIMARY KEY (Id)
;

ALTER TABLE NServiceArg
	ADD CONSTRAINT PK_ServiceArg
	PRIMARY KEY (Id)
;

ALTER TABLE NServiceConn
	ADD CONSTRAINT PK_NServiceConn
	PRIMARY KEY (Id)
;

ALTER TABLE NTransaction
	ADD CONSTRAINT PK_Transaction
	PRIMARY KEY (Id)
;

ALTER TABLE NTransactionNotification
	ADD CONSTRAINT PK_NTransactionNotification
	PRIMARY KEY (Id)
;

ALTER TABLE NTransactionRecipient
	ADD CONSTRAINT PK_NTransactionRecipient
	PRIMARY KEY (Id)
;

ALTER TABLE NAccount
	ADD CONSTRAINT UNQ_Account_NAASAccount
	UNIQUE (NAASAccount)
;

ALTER TABLE NConnection
	ADD CONSTRAINT UNQ_Connection_Code
	UNIQUE (Code)
;

ALTER TABLE NDocument
	ADD CONSTRAINT UNQ_Document_TranIdDocName
	UNIQUE (TransactionId, DocumentName)
;

ALTER TABLE NFlow
	ADD CONSTRAINT UNQ_Flow_Code
	UNIQUE (Code)
;

ALTER TABLE NNotification
	ADD CONSTRAINT UNQ_Notif_FlowIdAccId
	UNIQUE (FlowId, AccountId)
;

ALTER TABLE NPartner
	ADD CONSTRAINT UNQ_Partner_Name
	UNIQUE (Name)
;

ALTER TABLE NScheduleSourceArg
	ADD CONSTRAINT UNQ_SchedSrcArg_SchedIdName
	UNIQUE (ScheduleId, ArgKey)
;

ALTER TABLE NService
	ADD CONSTRAINT UNQ_Service_NameFlowId
	UNIQUE (Name, FlowId)
;

ALTER TABLE NServiceConn
	ADD CONSTRAINT UNQ_Service_ServiceIdKeyName
	UNIQUE (ServiceId, KeyName)
;

ALTER TABLE NAccount
	ADD CONSTRAINT FK_Account_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NAccountPolicy
	ADD CONSTRAINT FK_AccountPol_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NAccountPolicy
	ADD CONSTRAINT FK_AccountIdPol_Account
	FOREIGN KEY(AccountId)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NActivity
	ADD CONSTRAINT FK_Activity_Transaction
	FOREIGN KEY(TransactionId)
	REFERENCES NTransaction(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NActivity
	ADD CONSTRAINT FK_Activity_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NActivityDetail
	ADD CONSTRAINT FK_ActivDetail_Activity
	FOREIGN KEY(ActivityId)
	REFERENCES NActivity(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NConfig
	ADD CONSTRAINT FK_Config_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NConnection
	ADD CONSTRAINT FK_Connection_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NDocument
	ADD CONSTRAINT FK_Document_Transaction
	FOREIGN KEY(TransactionId)
	REFERENCES NTransaction(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NFlow
	ADD CONSTRAINT FK_Flow_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NNotification
	ADD CONSTRAINT FK_Notification_Flow
	FOREIGN KEY(FlowId)
	REFERENCES NFlow(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NNotification
	ADD CONSTRAINT FK_Notification_Account
	FOREIGN KEY(AccountId)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NPartner
	ADD CONSTRAINT FK_Partner_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NPlugin
	ADD CONSTRAINT FK_NPlugin_NFlow
	FOREIGN KEY(FlowId)
	REFERENCES NFlow(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NPlugin
	ADD CONSTRAINT FK_NPlugin_NAccount
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NRequest
	ADD CONSTRAINT FK_Request_Transaction
	FOREIGN KEY(TransactionId)
	REFERENCES NTransaction(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NRequest
	ADD CONSTRAINT FK_Request_Service
	FOREIGN KEY(ServiceId)
	REFERENCES NService(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NRequest
	ADD CONSTRAINT FK_ModBy_Request_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NRequestArg
	ADD CONSTRAINT FK_RequestArg_Request
	FOREIGN KEY(RequestId)
	REFERENCES NRequest(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NScheduleSourceArg
	ADD CONSTRAINT FK_ScheduleSourceArg_Schedule
	FOREIGN KEY(ScheduleId)
	REFERENCES NSchedule(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NService
	ADD CONSTRAINT FK_Service_Flow
	FOREIGN KEY(FlowId)
	REFERENCES NFlow(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NService
	ADD CONSTRAINT FK_Service_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NServiceArg
	ADD CONSTRAINT FK_ServiceArg_Service
	FOREIGN KEY(ServiceId)
	REFERENCES NService(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NServiceConn
	ADD CONSTRAINT FK_ServiceConn_Service
	FOREIGN KEY(ServiceId)
	REFERENCES NService(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NServiceConn
	ADD CONSTRAINT FK_ServiceConn_Connection
	FOREIGN KEY(ConnectionId)
	REFERENCES NConnection(Id)
	ON DELETE CASCADE 
; 

ALTER TABLE NTransaction
	ADD CONSTRAINT FK_ModBy_Tran_Account
	FOREIGN KEY(ModifiedBy)
	REFERENCES NAccount(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NTransactionNotification
	ADD CONSTRAINT FK_TranNotifn_Transaction
	FOREIGN KEY(TransactionId)
	REFERENCES NTransaction(Id)
	ON DELETE CASCADE 
;

ALTER TABLE NTransactionRecipient
	ADD CONSTRAINT FK_TranRec_Transaction
	FOREIGN KEY(TransactionId)
	REFERENCES NTransaction(Id)
	ON DELETE CASCADE 
;

    
-- additions for HERE AuthorizationRequest feature

CREATE TABLE NAccountAuthRequest (
    Id                          varchar2(50) NOT NULL,
    TransactionId               varchar2(50) NOT NULL,
    RequestGeneratedOn          date NOT NULL,
    RequestType                 varchar2(255) NOT NULL,
    NAASAccount                 varchar2(500) NOT NULL,
    FullName                    varchar2(500) NOT NULL,
    OrganizationAffiliation     varchar2(500) NOT NULL,
    TelephoneNumber             varchar2(25) NOT NULL,
    EmailAddress                varchar2(500) NOT NULL,
    AffiliatedNodeId            varchar2(50) NOT NULL,
    AffiliatedCounty            varchar2(255) NULL,
    PurposeDescription          varchar2(4000) NULL,
    RequestedNodeIds            varchar2(1000) NOT NULL,
    AuthorizationAccountId      varchar2(50) NULL,
    AuthorizationComments       varchar2(4000) NULL,
    AuthorizationGeneratedOn    date NULL,
    DidCreateInNaas             varchar2(1) NULL
    )
;

ALTER TABLE NAccountAuthRequest
    ADD CONSTRAINT PK_NAcctAuthnRequest
    PRIMARY KEY (Id)
;

ALTER TABLE NAccountAuthRequest 
    ADD CONSTRAINT FK_AcctAuthReq_Trans
    FOREIGN KEY(TransactionId)
    REFERENCES NTransaction(Id)
    ON DELETE CASCADE
;

ALTER TABLE NAccountAuthRequest 
    ADD CONSTRAINT FK_AcctAuthReq_Acct
    FOREIGN KEY(AuthorizationAccountId)
    REFERENCES NAccount(Id)
    ON DELETE CASCADE
;

CREATE TABLE NAccountAuthRequestFlow (
    Id varchar2(50)          NOT NULL,
    AccountAuthRequestId    varchar2(50) NOT NULL,
    FlowName varchar2(255)   NOT NULL,
    AccessGranted           varchar2(1) NULL
    )

;

ALTER TABLE NAccountAuthRequestFlow
    ADD CONSTRAINT PK_NAccountAuthRequestFlow
    PRIMARY KEY (Id)
;

ALTER TABLE NAccountAuthRequestFlow 
    ADD CONSTRAINT FK_AcctAuthReqFlow_AcctAuthReq
    FOREIGN KEY(AccountAuthRequestId)
    REFERENCES NAccountAuthRequest(Id)
    ON DELETE CASCADE
;

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
