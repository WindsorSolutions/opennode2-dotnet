/****** Object:  Table [dbo].[NObjectCache]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NObjectCache](
	[Name] [varchar](255) NOT NULL,
	[Data] [varbinary](max) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Expiration] [datetime] NOT NULL,
 CONSTRAINT [PK_NObjectCache] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NAccount]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NAccount](
	[Id] [varchar](50) NOT NULL,
	[NAASAccount] [varchar](500) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[SystemRole] [varchar](50) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[IsDeleted] [char](1) NULL,
	[IsDemoUser] [char](1) NULL,
	[PasswordHash] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Account_NAASAccount] UNIQUE NONCLUSTERED 
(
	[NAASAccount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NConnection]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NConnection](
	[Id] [varchar](50) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Provider] [varchar](500) NOT NULL,
	[ConnectionString] [varchar](500) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Connection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Connection_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NConfig]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NConfig](
	[Id] [varchar](255) NOT NULL,
	[Value] [varchar](4000) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[IsEditable] [char](1) NOT NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NAccountPolicy]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NAccountPolicy](
	[Id] [varchar](50) NOT NULL,
	[AccountId] [varchar](50) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Qualifier] [varchar](500) NOT NULL,
	[IsAllowed] [char](1) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_NAccountPolicy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NFlow]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NFlow](
	[Id] [varchar](50) NOT NULL,
	[InfoUrl] [varchar](500) NOT NULL,
	[Contact] [varchar](255) NOT NULL,
	[IsProtected] [char](1) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Flow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Flow_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NPartner]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NPartner](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Url] [varchar](500) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Version] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_NPartner] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Partner_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NPlugin]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NPlugin](
	[Id] [varchar](50) NOT NULL,
	[FlowId] [varchar](50) NOT NULL,
	[BinaryVersion] [varchar](40) NOT NULL,
	[ZippedBinary] [varbinary](max) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_NPlugin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Plugin_BinaryVersionFlowId] UNIQUE NONCLUSTERED 
(
	[BinaryVersion] ASC,
	[FlowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NNotification]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NNotification](
	[Id] [varchar](50) NOT NULL,
	[FlowId] [varchar](50) NOT NULL,
	[AccountId] [varchar](50) NOT NULL,
	[OnSolicit] [char](1) NOT NULL,
	[OnQuery] [char](1) NOT NULL,
	[OnSubmit] [char](1) NOT NULL,
	[OnNotify] [char](1) NOT NULL,
	[OnSchedule] [char](1) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[OnDownload] [char](1) NOT NULL,
	[OnExecute] [char](1) NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Notification_FlowIdAccountId] UNIQUE NONCLUSTERED 
(
	[FlowId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NService]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NService](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FlowId] [varchar](50) NOT NULL,
	[IsActive] [char](1) NOT NULL,
	[ServiceType] [varchar](128) NOT NULL,
	[Implementor] [varchar](500) NOT NULL,
	[AuthLevel] [varchar](50) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[PublishFlags] [varchar](50) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Service_NameFlowId] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[FlowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NTransaction]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NTransaction](
	[Id] [varchar](50) NOT NULL,
	[FlowId] [varchar](50) NOT NULL,
	[NetworkId] [varchar](255) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[StatusDetail] [varchar](4000) NULL,
	[Operation] [varchar](255) NULL,
	[WebMethod] [varchar](50) NOT NULL,
	[EndpointVersion] [varchar](50) NULL,
	[NetworkEndpointVersion] [varchar](50) NULL,
	[NetworkEndpointUrl] [varchar](500) NULL,
	[NetworkEndpointStatus] [varchar](50) NULL,
	[NetworkEndpointStatusDetail] [varchar](4000) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NServiceConn]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NServiceConn](
	[Id] [varchar](50) NOT NULL,
	[ServiceId] [varchar](50) NOT NULL,
	[ConnectionId] [varchar](50) NOT NULL,
	[KeyName] [varchar](255) NOT NULL,
 CONSTRAINT [PK_NServiceConn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Service_ServiceIdKeyName] UNIQUE NONCLUSTERED 
(
	[ServiceId] ASC,
	[KeyName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NServiceArg]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NServiceArg](
	[Id] [varchar](50) NOT NULL,
	[ServiceId] [varchar](50) NOT NULL,
	[ArgCode] [varchar](255) NOT NULL,
	[Value] [varchar](4000) NULL,
 CONSTRAINT [PK_ServiceArg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NTransactionRecipient]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NTransactionRecipient](
	[Id] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[Uri] [varchar](500) NOT NULL,
 CONSTRAINT [PK_NTransactionRecipient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NTransactionRealtimeDetails]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NTransactionRealtimeDetails](
	[Id] [varchar](50) NOT NULL,
	[StatusType] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[Detail] [varchar](4000) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[OrderIndex] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TransactionRealtimeActivityDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NTransactionNotification]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NTransactionNotification](
	[Id] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[Uri] [varchar](500) NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NTransactionNotification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NAccountAuthRequest]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NAccountAuthRequest](
	[Id] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[RequestGeneratedOn] [datetime] NOT NULL,
	[RequestType] [varchar](255) NOT NULL,
	[NAASAccount] [varchar](500) NOT NULL,
	[FullName] [varchar](500) NOT NULL,
	[OrganizationAffiliation] [varchar](500) NOT NULL,
	[TelephoneNumber] [varchar](25) NOT NULL,
	[EmailAddress] [varchar](500) NOT NULL,
	[AffiliatedNodeId] [varchar](50) NOT NULL,
	[AffiliatedCounty] [varchar](255) NULL,
	[PurposeDescription] [varchar](4000) NULL,
	[RequestedNodeIds] [varchar](1000) NOT NULL,
	[AuthorizationAccountId] [varchar](50) NULL,
	[AuthorizationComments] [varchar](4000) NULL,
	[AuthorizationGeneratedOn] [datetime] NULL,
	[DidCreateInNaas] [varchar](1) NULL,
 CONSTRAINT [PK_NAccountAuthenticationRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NDocument]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NDocument](
	[Id] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[DocumentName] [varchar](255) NOT NULL,
	[Type] [varchar](255) NOT NULL,
	[DocumentId] [varchar](255) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[StatusDetail] [varchar](4000) NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Document_TransactionIdDocumentName] UNIQUE NONCLUSTERED 
(
	[TransactionId] ASC,
	[DocumentName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NActivity]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NActivity](
	[Id] [varchar](50) NOT NULL,
	[Type] [varchar](128) NOT NULL,
	[TransactionId] [varchar](50) NULL,
	[IP] [varchar](64) NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[WebMethod] [varchar](50) NULL,
	[FlowName] [varchar](255) NULL,
	[Operation] [varchar](255) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NNodeNotification]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NNodeNotification](
	[Id] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NOT NULL,
	[NotifyData] [varchar](max) NOT NULL,
 CONSTRAINT [PK_NNodeNotification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NRequest]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NRequest](
	[Id] [varchar](50) NOT NULL,
	[TransactionId] [varchar](50) NULL,
	[ServiceId] [varchar](50) NOT NULL,
	[RowIndex] [int] NOT NULL,
	[MaxRowCount] [int] NOT NULL,
	[RequestType] [varchar](50) NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ParamsByName] [char](1) NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NSchedule]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NSchedule](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FlowId] [varchar](50) NULL,
	[StartOn] [datetime] NOT NULL,
	[EndOn] [datetime] NOT NULL,
	[SourceType] [varchar](50) NOT NULL,
	[SourceId] [varchar](255) NOT NULL,
	[SourceFlow] [varchar](255) NULL,
	[SourceOperation] [varchar](255) NULL,
	[TargetType] [varchar](50) NULL,
	[TargetId] [varchar](255) NULL,
	[TargetFlow] [varchar](255) NULL,
	[TargetOperation] [varchar](255) NULL,
	[LastExecutedOn] [datetime] NULL,
	[NextRun] [datetime] NOT NULL,
	[FrequencyType] [varchar](50) NOT NULL,
	[Frequency] [int] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[IsActive] [varchar](1) NOT NULL,
	[IsRunNow] [varchar](1) NOT NULL,
	[ExecuteStatus] [varchar](50) NOT NULL,
	[LastExecuteActivityId] [varchar](50) NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Schedule_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NRequestArg]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NRequestArg](
	[Id] [varchar](50) NOT NULL,
	[RequestId] [varchar](50) NOT NULL,
	[ArgName] [varchar](255) NOT NULL,
	[ArgValue] [varchar](4000) NULL,
 CONSTRAINT [PK_RequestArg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NDocumentContent]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NDocumentContent](
	[DocumentId] [varchar](50) NOT NULL,
	[Data] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_NDocumentContent] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NActivityDetail]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NActivityDetail](
	[Id] [varchar](50) NOT NULL,
	[ActivityId] [varchar](50) NOT NULL,
	[Detail] [varchar](max) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[OrderIndex] [int] NULL,
 CONSTRAINT [PK_ActivityDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NAccountAuthRequestFlow]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NAccountAuthRequestFlow](
	[Id] [varchar](50) NOT NULL,
	[AccountAuthRequestId] [varchar](50) NOT NULL,
	[FlowName] [varchar](255) NOT NULL,
	[AccessGranted] [varchar](1) NULL,
 CONSTRAINT [PK_NAccountAuthRequestFlow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NScheduleSourceArg]    Script Date: 05/18/2009 12:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NScheduleSourceArg](
	[Id] [varchar](50) NOT NULL,
	[ScheduleId] [varchar](50) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_NScheduleSourceArg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_ScheduleSourceArg_ScheduleIdName] UNIQUE NONCLUSTERED 
(
	[ScheduleId] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Account_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NAccount]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NAccount] CHECK CONSTRAINT [FK_Account_Account]
GO
/****** Object:  ForeignKey [FK_AccountAuthenticationRequest_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NAccountAuthRequest]  WITH CHECK ADD  CONSTRAINT [FK_AccountAuthenticationRequest_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
GO
ALTER TABLE [dbo].[NAccountAuthRequest] CHECK CONSTRAINT [FK_AccountAuthenticationRequest_Transaction]
GO
/****** Object:  ForeignKey [FK_AccountAuthRequest_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NAccountAuthRequest]  WITH CHECK ADD  CONSTRAINT [FK_AccountAuthRequest_Account] FOREIGN KEY([AuthorizationAccountId])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NAccountAuthRequest] CHECK CONSTRAINT [FK_AccountAuthRequest_Account]
GO
/****** Object:  ForeignKey [FK_AccountAuthRequestFlow_AccountAuthRequest]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NAccountAuthRequestFlow]  WITH CHECK ADD  CONSTRAINT [FK_AccountAuthRequestFlow_AccountAuthRequest] FOREIGN KEY([AccountAuthRequestId])
REFERENCES [dbo].[NAccountAuthRequest] ([Id])
GO
ALTER TABLE [dbo].[NAccountAuthRequestFlow] CHECK CONSTRAINT [FK_AccountAuthRequestFlow_AccountAuthRequest]
GO
/****** Object:  ForeignKey [FK_AccountIdPolicy_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NAccountPolicy]  WITH CHECK ADD  CONSTRAINT [FK_AccountIdPolicy_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NAccountPolicy] CHECK CONSTRAINT [FK_AccountIdPolicy_Account]
GO
/****** Object:  ForeignKey [FK_AccountPolicy_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NAccountPolicy]  WITH CHECK ADD  CONSTRAINT [FK_AccountPolicy_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NAccountPolicy] CHECK CONSTRAINT [FK_AccountPolicy_Account]
GO
/****** Object:  ForeignKey [FK_Activity_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NActivity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NActivity] CHECK CONSTRAINT [FK_Activity_Account]
GO
/****** Object:  ForeignKey [FK_Activity_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NActivity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NActivity] CHECK CONSTRAINT [FK_Activity_Transaction]
GO
/****** Object:  ForeignKey [FK_ActivityDetail_Activity]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NActivityDetail]  WITH CHECK ADD  CONSTRAINT [FK_ActivityDetail_Activity] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[NActivity] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NActivityDetail] CHECK CONSTRAINT [FK_ActivityDetail_Activity]
GO
/****** Object:  ForeignKey [FK_Config_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NConfig]  WITH CHECK ADD  CONSTRAINT [FK_Config_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NConfig] CHECK CONSTRAINT [FK_Config_Account]
GO
/****** Object:  ForeignKey [FK_Connection_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NConnection]  WITH CHECK ADD  CONSTRAINT [FK_Connection_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NConnection] CHECK CONSTRAINT [FK_Connection_Account]
GO
/****** Object:  ForeignKey [FK_Document_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NDocument]  WITH CHECK ADD  CONSTRAINT [FK_Document_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NDocument] CHECK CONSTRAINT [FK_Document_Transaction]
GO
/****** Object:  ForeignKey [FK_DocumentContent_Document]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NDocumentContent]  WITH CHECK ADD  CONSTRAINT [FK_DocumentContent_Document] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[NDocument] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NDocumentContent] CHECK CONSTRAINT [FK_DocumentContent_Document]
GO
/****** Object:  ForeignKey [FK_Flow_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NFlow]  WITH CHECK ADD  CONSTRAINT [FK_Flow_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NFlow] CHECK CONSTRAINT [FK_Flow_Account]
GO
/****** Object:  ForeignKey [FK_NodeNotification_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NNodeNotification]  WITH CHECK ADD  CONSTRAINT [FK_NodeNotification_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NNodeNotification] CHECK CONSTRAINT [FK_NodeNotification_Transaction]
GO
/****** Object:  ForeignKey [FK_ModifiedBy_Notification_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NNotification]  WITH CHECK ADD  CONSTRAINT [FK_ModifiedBy_Notification_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NNotification] CHECK CONSTRAINT [FK_ModifiedBy_Notification_Account]
GO
/****** Object:  ForeignKey [FK_Notification_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NNotification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NNotification] CHECK CONSTRAINT [FK_Notification_Account]
GO
/****** Object:  ForeignKey [FK_Notification_Flow]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NNotification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Flow] FOREIGN KEY([FlowId])
REFERENCES [dbo].[NFlow] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NNotification] CHECK CONSTRAINT [FK_Notification_Flow]
GO
/****** Object:  ForeignKey [FK_Partner_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NPartner]  WITH CHECK ADD  CONSTRAINT [FK_Partner_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NPartner] CHECK CONSTRAINT [FK_Partner_Account]
GO
/****** Object:  ForeignKey [FK_Plugin_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NPlugin]  WITH CHECK ADD  CONSTRAINT [FK_Plugin_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NPlugin] CHECK CONSTRAINT [FK_Plugin_Account]
GO
/****** Object:  ForeignKey [FK_Plugin_Flow]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NPlugin]  WITH CHECK ADD  CONSTRAINT [FK_Plugin_Flow] FOREIGN KEY([FlowId])
REFERENCES [dbo].[NFlow] ([Id])
GO
ALTER TABLE [dbo].[NPlugin] CHECK CONSTRAINT [FK_Plugin_Flow]
GO
/****** Object:  ForeignKey [FK_ModifiedBy_Request_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NRequest]  WITH CHECK ADD  CONSTRAINT [FK_ModifiedBy_Request_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NRequest] CHECK CONSTRAINT [FK_ModifiedBy_Request_Account]
GO
/****** Object:  ForeignKey [FK_Request_Service]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_Request_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[NService] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NRequest] CHECK CONSTRAINT [FK_Request_Service]
GO
/****** Object:  ForeignKey [FK_Request_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_Request_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NRequest] CHECK CONSTRAINT [FK_Request_Transaction]
GO
/****** Object:  ForeignKey [FK_RequestArg_Request]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NRequestArg]  WITH NOCHECK ADD  CONSTRAINT [FK_RequestArg_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[NRequest] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NRequestArg] CHECK CONSTRAINT [FK_RequestArg_Request]
GO
/****** Object:  ForeignKey [FK_Schedule_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NSchedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NSchedule] CHECK CONSTRAINT [FK_Schedule_Account]
GO
/****** Object:  ForeignKey [FK_Schedule_Activity]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NSchedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Activity] FOREIGN KEY([LastExecuteActivityId])
REFERENCES [dbo].[NActivity] ([Id])
GO
ALTER TABLE [dbo].[NSchedule] CHECK CONSTRAINT [FK_Schedule_Activity]
GO
/****** Object:  ForeignKey [FK_Schedule_Flow]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NSchedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Flow] FOREIGN KEY([FlowId])
REFERENCES [dbo].[NFlow] ([Id])
GO
ALTER TABLE [dbo].[NSchedule] CHECK CONSTRAINT [FK_Schedule_Flow]
GO
/****** Object:  ForeignKey [FK_ScheduleSourceArg_Schedule]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NScheduleSourceArg]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleSourceArg_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[NSchedule] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NScheduleSourceArg] CHECK CONSTRAINT [FK_ScheduleSourceArg_Schedule]
GO
/****** Object:  ForeignKey [FK_Service_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NService]  WITH CHECK ADD  CONSTRAINT [FK_Service_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NService] CHECK CONSTRAINT [FK_Service_Account]
GO
/****** Object:  ForeignKey [FK_Service_Flow]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NService]  WITH CHECK ADD  CONSTRAINT [FK_Service_Flow] FOREIGN KEY([FlowId])
REFERENCES [dbo].[NFlow] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NService] CHECK CONSTRAINT [FK_Service_Flow]
GO
/****** Object:  ForeignKey [FK_ServiceArg_Service]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NServiceArg]  WITH CHECK ADD  CONSTRAINT [FK_ServiceArg_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[NService] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NServiceArg] CHECK CONSTRAINT [FK_ServiceArg_Service]
GO
/****** Object:  ForeignKey [FK_ServiceConn_Connection]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NServiceConn]  WITH CHECK ADD  CONSTRAINT [FK_ServiceConn_Connection] FOREIGN KEY([ConnectionId])
REFERENCES [dbo].[NConnection] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NServiceConn] CHECK CONSTRAINT [FK_ServiceConn_Connection]
GO
/****** Object:  ForeignKey [FK_ServiceConn_Service]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NServiceConn]  WITH CHECK ADD  CONSTRAINT [FK_ServiceConn_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[NService] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NServiceConn] CHECK CONSTRAINT [FK_ServiceConn_Service]
GO
/****** Object:  ForeignKey [FK_ModifiedBy_Transaction_Account]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NTransaction]  WITH CHECK ADD  CONSTRAINT [FK_ModifiedBy_Transaction_Account] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[NAccount] ([Id])
GO
ALTER TABLE [dbo].[NTransaction] CHECK CONSTRAINT [FK_ModifiedBy_Transaction_Account]
GO
/****** Object:  ForeignKey [FK_Transaction_Flow]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NTransaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Flow] FOREIGN KEY([FlowId])
REFERENCES [dbo].[NFlow] ([Id])
GO
ALTER TABLE [dbo].[NTransaction] CHECK CONSTRAINT [FK_Transaction_Flow]
GO
/****** Object:  ForeignKey [FK_TransactionNotification_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NTransactionNotification]  WITH CHECK ADD  CONSTRAINT [FK_TransactionNotification_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NTransactionNotification] CHECK CONSTRAINT [FK_TransactionNotification_Transaction]
GO
/****** Object:  ForeignKey [FK_TransactionRealtimeActivityDetail_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NTransactionRealtimeDetails]  WITH CHECK ADD  CONSTRAINT [FK_TransactionRealtimeActivityDetail_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NTransactionRealtimeDetails] CHECK CONSTRAINT [FK_TransactionRealtimeActivityDetail_Transaction]
GO
/****** Object:  ForeignKey [FK_TransactionRecipient_Transaction]    Script Date: 05/18/2009 12:44:56 ******/
ALTER TABLE [dbo].[NTransactionRecipient]  WITH CHECK ADD  CONSTRAINT [FK_TransactionRecipient_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[NTransaction] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NTransactionRecipient] CHECK CONSTRAINT [FK_TransactionRecipient_Transaction]
GO
