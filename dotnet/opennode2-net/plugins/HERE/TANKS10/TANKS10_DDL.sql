/****** Object:  Table [dbo].[TANKS_SUBMISSION]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_SUBMISSION](
	[SUBMISSION_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_SUBMISSION] PRIMARY KEY CLUSTERED 
(
	[SUBMISSION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TANKS_FAC_SITE]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_FAC_SITE](
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[SUBMISSION_ID] [varchar](40) NOT NULL,
	[FAC_SITE_NAME] [varchar](128) NULL,
	[FEDERAL_FAC_IND] [varchar](4) NULL,
	[FAC_SITE_IDEN_CONTEXT] [varchar](255) NULL,
	[FAC_SITE_IDEN] [varchar](50) NULL,
	[FAC_SITE_TYPE_CODE] [varchar](50) NULL,
	[FAC_SITE_TYPE_NAME] [varchar](128) NULL,
	[CODE_LIST_VERSION_IDEN] [varchar](50) NULL,
	[CODE_LIST_VERSION_AGENCY_IDEN] [varchar](50) NULL,
	[CODE_LIST_VALUE] [varchar](50) NULL,
 CONSTRAINT [PK_FAC_SITE] PRIMARY KEY CLUSTERED 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FAC_SITE_SUB_ID] ON [dbo].[TANKS_FAC_SITE] 
(
	[SUBMISSION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Main component schema containing facility and tank information. (FacilitySiteId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Main component schema containing facility and tank information. (SubmissionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'SUBMISSION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator identifying facilities owned or operated by a federal government unit. (FederalFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FEDERAL_FAC_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The unique identification number used by a governmental entity to identify a facility site. (FacilitySiteIdentifierContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN_CONTEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The unique identification number used by a governmental entity to identify a facility site. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the type of site a facility occupies. (FacilitySiteTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name for the type of site the facility occupies. (FacilitySiteTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERSION_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERSION_AGENCY_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VALUE'
GO
/****** Object:  Table [dbo].[TANKS_TANK]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_TANK](
	[TANK_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[TANK_TYPE_TEXT] [varchar](3) NOT NULL,
	[TANK_USE_STATUS_TEXT] [varchar](255) NOT NULL,
	[TANK_IDEN_TEXT] [varchar](255) NULL,
	[TANK_INSTALL_DATE] [datetime] NULL,
	[TANK_IS_CONF_IND] [varchar](1) NULL,
	[TANK_CONST_TEXT] [varchar](255) NULL,
	[TANK_DESC_TEXT] [varchar](255) NULL,
	[TANK_LOC_DESC_TEXT] [varchar](255) NULL,
 CONSTRAINT [PK_TANK] PRIMARY KEY CLUSTERED 
(
	[TANK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_TANK_FAC_SIT_ID] ON [dbo].[TANKS_TANK] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (TankId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (FacilitySiteId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'FAC_SITE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying a storage tank as an aboveground (AST) or underground (UST) tank. (TankTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_TYPE_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies if the storage tank is currently being used, is temporarily/permanently out of service, and has been filled or removed. (TankUseStatusText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_USE_STATUS_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identification number used by a government entity to identify a storage tank. (TankIdentifierText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_IDEN_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that the storage tank was installed at the facility site. (TankInstallationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_INSTALL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the location or details of the tank is considered confidential information, or not. (TankIsConfidentialIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_IS_CONF_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The material used in the construction of the storage tank. For example, steel, concrete, fiberglass, unknown, or other. (TankConstructionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_CONST_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any additional descriptive text that could be used to identify or describe the storage tank. (TankDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_DESC_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief description of the storage tank location at the facility. (TankLocationDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK', @level2type=N'COLUMN',@level2name=N'TANK_LOC_DESC_TEXT'
GO
/****** Object:  Table [dbo].[TANKS_EXTERNAL_PROTECTION]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_EXTERNAL_PROTECTION](
	[EXTERNAL_PROTECTION_ID] [varchar](40) NOT NULL,
	[TANK_ID] [varchar](40) NOT NULL,
	[TEXT] [varchar](255) NULL,
 CONSTRAINT [PK_EXTERN_PROTECTI] PRIMARY KEY CLUSTERED 
(
	[EXTERNAL_PROTECTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EXTE_PRO_TAN_ID] ON [dbo].[TANKS_EXTERNAL_PROTECTION] 
(
	[TANK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (ExternalProtectionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_EXTERNAL_PROTECTION', @level2type=N'COLUMN',@level2name=N'EXTERNAL_PROTECTION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (TankId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_EXTERNAL_PROTECTION', @level2type=N'COLUMN',@level2name=N'TANK_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_EXTERNAL_PROTECTION', @level2type=N'COLUMN',@level2name=N'TEXT'
GO
/****** Object:  Table [dbo].[TANKS_INTERNAL_PROTECTION]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_INTERNAL_PROTECTION](
	[INTERNAL_PROTECTION_ID] [varchar](40) NOT NULL,
	[TANK_ID] [varchar](40) NOT NULL,
	[TEXT] [varchar](255) NULL,
 CONSTRAINT [PK_INTERN_PROTECTI] PRIMARY KEY CLUSTERED 
(
	[INTERNAL_PROTECTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_INTE_PRO_TAN_ID] ON [dbo].[TANKS_INTERNAL_PROTECTION] 
(
	[TANK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (InternalProtectionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_INTERNAL_PROTECTION', @level2type=N'COLUMN',@level2name=N'INTERNAL_PROTECTION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (TankId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_INTERNAL_PROTECTION', @level2type=N'COLUMN',@level2name=N'TANK_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank schema containing tank specific data elements. (Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_INTERNAL_PROTECTION', @level2type=N'COLUMN',@level2name=N'TEXT'
GO
/****** Object:  Table [dbo].[TANKS_TANK_COMPART]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_TANK_COMPART](
	[TANK_COMPART_ID] [varchar](40) NOT NULL,
	[TANK_ID] [varchar](40) NOT NULL,
	[TANK_COMPART_CAPACITY_NUM] [varchar](50) NULL,
	[TANK_COMPART_INSTALL_DATE] [datetime] NULL,
	[TANK_COMPART_IDEN_TEXT] [varchar](255) NULL,
	[TANK_COMPART_HAS_SEC_CONT_IND] [varchar](1) NULL,
	[PIPING_SYSTEM_TYPE_TEXT] [varchar](255) NULL,
	[PIPING_HAS_SEC_CONT_IND] [varchar](1) NULL,
	[TANK_CONTENT_IS_MIXTURE_IND] [varchar](1) NULL,
	[TANK_CONTENT_IS_CONF_IND] [varchar](1) NULL,
 CONSTRAINT [PK_TANK_COMPART] PRIMARY KEY CLUSTERED 
(
	[TANK_COMPART_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_TANK_COM_TAN_ID] ON [dbo].[TANKS_TANK_COMPART] 
(
	[TANK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank compartment schema containing tank compartment specific data elements. (TankCompartmentId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage Tank compartment schema containing tank compartment specific data elements. (TankId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Maximum capacity of the storage tank, in gallons. (TankCompartmentCapacityNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_CAPACITY_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'If applicable, date that the compartment within the storage tank was installed. (TankCompartmentInstallationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_INSTALL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identification number used by a government entity to identify a storage tank compartment. (TankCompartmentIdentifierText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_IDEN_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the secondary containment method, if any, of the storage tank compartment. (TankCompartmentHasSecondaryContainmentIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_HAS_SEC_CONT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of piping system utilized by the storage tank. For exampe, pressurized, suction, or safe suction. (PipingSystemTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'PIPING_SYSTEM_TYPE_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The material or construction method used in the tank piping.. (PipingHasSecondaryContainmentIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'PIPING_HAS_SEC_CONT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the contents of the tank compartment is a mixture of chemicals, or not. (TankContentIsMixtureIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_CONTENT_IS_MIXTURE_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the contents of the tank compartment is considered confidential information, or not. (TankContentIsConfidentialIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_TANK_COMPART', @level2type=N'COLUMN',@level2name=N'TANK_CONTENT_IS_CONF_IND'
GO
/****** Object:  Table [dbo].[TANKS_PIPING_CONST]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_PIPING_CONST](
	[PIPING_CONST_ID] [varchar](40) NOT NULL,
	[TANK_COMPART_ID] [varchar](40) NOT NULL,
	[TEXT] [varchar](255) NULL,
 CONSTRAINT [PK_PIPING_CONST] PRIMARY KEY CLUSTERED 
(
	[PIPING_CONST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PIP_CO_TA_CO_ID] ON [dbo].[TANKS_PIPING_CONST] 
(
	[TANK_COMPART_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage tank piping schema containing tank piping specific data elements. (PipingConstructionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_PIPING_CONST', @level2type=N'COLUMN',@level2name=N'PIPING_CONST_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage tank piping schema containing tank piping specific data elements. (TankCompartmentId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_PIPING_CONST', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Storage tank piping schema containing tank piping specific data elements. (Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_PIPING_CONST', @level2type=N'COLUMN',@level2name=N'TEXT'
GO
/****** Object:  Table [dbo].[TANKS_CHEM_SUBS_IDEN]    Script Date: 05/04/2009 14:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TANKS_CHEM_SUBS_IDEN](
	[CHEM_SUBS_IDEN_ID] [varchar](40) NOT NULL,
	[TANK_COMPART_ID] [varchar](40) NOT NULL,
	[EPA_CHEM_INTERNAL_NUM] [varchar](50) NULL,
	[CAS_REG_NUM] [varchar](50) NULL,
	[CHEM_SUBS_SYSTEMATIC_NAME] [varchar](128) NULL,
	[EPA_CHEM_REG_NAME] [varchar](128) NULL,
	[EPA_CHEM_IDEN] [varchar](50) NULL,
	[CHEM_NAME_CONTEXT_NAME] [varchar](128) NULL,
	[EPA_CHEM_REG_NAME_SRC_TEXT] [varchar](255) NULL,
	[EPA_CHEM_REG_NAME_CONTEXT_NAME] [varchar](128) NULL,
	[CHEM_SUBS_DEFINITION_TEXT] [varchar](255) NULL,
	[CHEM_SUBS_COMMENT_TEXT] [varchar](255) NULL,
	[CHEM_SUBS_SYNONYM_NAME] [varchar](128) NULL,
	[MOLECULAR_FORMULA_CODE] [varchar](50) NULL,
	[CHEM_SUBS_FORMULA_WGHT_QNTY] [varchar](255) NULL,
	[CHEM_SUBS_TYPE_NAME] [varchar](128) NULL,
	[CHEM_SUBS_LINEAR_STRU_CODE] [varchar](50) NULL,
	[CHEM_STRU_GRAPHICAL_DIAGRAM] [varchar](255) NULL,
	[CHEM_SUBS_CLASSIFICATION_NAME] [varchar](128) NULL,
	[CHEM_SYNONYM_STATUS_NAME] [varchar](128) NULL,
	[CHEM_SYNONYM_SRC_NAME] [varchar](128) NULL,
 CONSTRAINT [PK_CHEM_SUBS_IDEN] PRIMARY KEY CLUSTERED 
(
	[CHEM_SUBS_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CH_SU_ID_TA_CO] ON [dbo].[TANKS_CHEM_SUBS_IDEN] 
(
	[TANK_COMPART_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The Chemical Identification Block provides for the use of common identifiers for all chemical substances regulated or monitored by environmental programs. (ChemicalSubstanceIdentityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_IDEN_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The Chemical Identification Block provides for the use of common identifiers for all chemical substances regulated or monitored by environmental programs. (TankCompartmentId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'TANK_COMPART_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique record number assigned to all chemical substances and chemical groupings for internal tracking within EPA systems. (EPAChemicalInternalNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'EPA_CHEM_INTERNAL_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique number assigned by Chemical Abstracts Service (CAS) to a chemical substance. (CASRegistryNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CAS_REG_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name assigned to a chemical substance that describes it in terms of its molecular composition. (ChemicalSubstanceSystematicName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_SYSTEMATIC_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that the Environmental Protection Agency has selected as its preferred name for a chemical substance. (EPAChemicalRegistryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'EPA_CHEM_REG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique number assigned to all chemical substances and chemical groupings for which a CAS Registry Number does not exist and cannot be assigned. (EPAChemicalIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'EPA_CHEM_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that identifies the circumstances for which a chemical substance name is used. (ChemicalNameContextName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_NAME_CONTEXT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of the Environmental Protection Agency chemical registry name. (EPAChemicalRegistryNameSourceText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'EPA_CHEM_REG_NAME_SRC_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of source for the Environmental Protection Agency chemical registry name. (EPAChemicalRegistryNameContextName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'EPA_CHEM_REG_NAME_CONTEXT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides clarification to the identity of a chemical substance. (ChemicalSubstanceDefinitionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_DEFINITION_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a chemical substance. (ChemicalSubstanceCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_COMMENT_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name that is used as the alternative for representing a chemical substance. (ChemicalSubstanceSynonymName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_SYNONYM_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the number of atoms of each element in a molecule of a chemical substance. (MolecularFormulaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'MOLECULAR_FORMULA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sum of the atomic weights of constituent atoms in a molecule of a chemical substance. (ChemicalSubstanceFormulaWeightQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_FORMULA_WGHT_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A descriptive name for types of chemical substances. (ChemicalSubstanceTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the connectivity of atoms in a molecule of a chemical substance as a linear formula, such as SMILES. (ChemicalSubstanceLinearStructureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_LINEAR_STRU_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A graphical representation of a molecule of a chemical substance as a two or three dimensional diagram. (ChemicalStructureGraphicalDiagram)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_STRU_GRAPHICAL_DIAGRAM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of a schema that classifies chemical substances according to structural similarities. (ChemicalSubstanceClassificationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SUBS_CLASSIFICATION_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that documents the correctness of a synonym for a specific chemical substance. (ChemicalSynonymStatusName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SYNONYM_STATUS_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the source of an alternate name for a chemical substance. (ChemicalSynonymSourceName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TANKS_CHEM_SUBS_IDEN', @level2type=N'COLUMN',@level2name=N'CHEM_SYNONYM_SRC_NAME'
GO
/****** Object:  ForeignKey [FK_CHE_SU_ID_TA_CO]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_CHEM_SUBS_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_CHE_SU_ID_TA_CO] FOREIGN KEY([TANK_COMPART_ID])
REFERENCES [dbo].[TANKS_TANK_COMPART] ([TANK_COMPART_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_CHEM_SUBS_IDEN] CHECK CONSTRAINT [FK_CHE_SU_ID_TA_CO]
GO
/****** Object:  ForeignKey [FK_EXTER_PROT_TANK]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_EXTERNAL_PROTECTION]  WITH CHECK ADD  CONSTRAINT [FK_EXTER_PROT_TANK] FOREIGN KEY([TANK_ID])
REFERENCES [dbo].[TANKS_TANK] ([TANK_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_EXTERNAL_PROTECTION] CHECK CONSTRAINT [FK_EXTER_PROT_TANK]
GO
/****** Object:  ForeignKey [FK_FAC_SITE_SUBMIS]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_FAC_SITE]  WITH CHECK ADD  CONSTRAINT [FK_FAC_SITE_SUBMIS] FOREIGN KEY([SUBMISSION_ID])
REFERENCES [dbo].[TANKS_SUBMISSION] ([SUBMISSION_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_FAC_SITE] CHECK CONSTRAINT [FK_FAC_SITE_SUBMIS]
GO
/****** Object:  ForeignKey [FK_INTER_PROT_TANK]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_INTERNAL_PROTECTION]  WITH CHECK ADD  CONSTRAINT [FK_INTER_PROT_TANK] FOREIGN KEY([TANK_ID])
REFERENCES [dbo].[TANKS_TANK] ([TANK_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_INTERNAL_PROTECTION] CHECK CONSTRAINT [FK_INTER_PROT_TANK]
GO
/****** Object:  ForeignKey [FK_PIP_CON_TAN_COM]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_PIPING_CONST]  WITH CHECK ADD  CONSTRAINT [FK_PIP_CON_TAN_COM] FOREIGN KEY([TANK_COMPART_ID])
REFERENCES [dbo].[TANKS_TANK_COMPART] ([TANK_COMPART_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_PIPING_CONST] CHECK CONSTRAINT [FK_PIP_CON_TAN_COM]
GO
/****** Object:  ForeignKey [FK_TANK_FAC_SITE]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_TANK]  WITH CHECK ADD  CONSTRAINT [FK_TANK_FAC_SITE] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[TANKS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_TANK] CHECK CONSTRAINT [FK_TANK_FAC_SITE]
GO
/****** Object:  ForeignKey [FK_TANK_COMPA_TANK]    Script Date: 05/04/2009 14:44:56 ******/
ALTER TABLE [dbo].[TANKS_TANK_COMPART]  WITH CHECK ADD  CONSTRAINT [FK_TANK_COMPA_TANK] FOREIGN KEY([TANK_ID])
REFERENCES [dbo].[TANKS_TANK] ([TANK_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TANKS_TANK_COMPART] CHECK CONSTRAINT [FK_TANK_COMPA_TANK]
GO
