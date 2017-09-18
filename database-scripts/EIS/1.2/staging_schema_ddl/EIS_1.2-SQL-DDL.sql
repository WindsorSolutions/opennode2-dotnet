/****** Object:  Table [dbo].[CERS_CERS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_CERS](
	[CERS_ID] [varchar](40) NOT NULL,
	[DATA_CATEGORY] [varchar](21) NOT NULL,
	[USER_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EMIS_YEAR] [int] NOT NULL,
	[MODEL] [varchar](255) NULL,
	[MODEL_VERS] [varchar](20) NULL,
	[EMIS_CRTN_DATE] [datetime] NULL,
	[SUBM_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_CERS] PRIMARY KEY CLUSTERED 
(
	[CERS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CERS_EMIS_YEAR] ON [dbo].[CERS_CERS] 
(
	[EMIS_YEAR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CRS_DTA_CTGRY] ON [dbo].[CERS_CERS] 
(
	[DATA_CATEGORY] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier of a user record.  This identifier is assigned by the receiving system and is unique for each user.  Permissions for updating data are granted based on the user identification. (UserIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'USER_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year of the submitted emissions. (EmissionsYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'EMIS_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the model or the conversion tool used for generating the emissions data. (Model)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'MODEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The version of the model or conversion tool. (ModelVersion)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'MODEL_VERS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that the data being submitted were created, or the date when the model generating the data was run. (EmissionsCreationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'EMIS_CRTN_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the file submission. (SubmittalComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS', @level2type=N'COLUMN',@level2name=N'SUBM_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CERSDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_CERS'
GO
/****** Object:  Table [dbo].[CERS_EVENT]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EVENT](
	[EVENT_ID] [varchar](40) NOT NULL,
	[CERS_ID] [varchar](40) NOT NULL,
	[EVENT_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EVENT_NAME] [varchar](128) NULL,
	[LAND_MGR] [varchar](255) NULL,
	[LOC_DESC] [varchar](255) NULL,
	[EVENT_CLASS_CODE] [varchar](50) NULL,
	[EVENT_SIZE_SRC_CODE] [varchar](50) NULL,
	[CONT_DATE] [datetime] NULL,
	[RECUR_IND_CODE] [varchar](50) NULL,
	[RECUR_YEAR] [int] NULL,
	[GRND_BASED_DATA_SRC_CODE] [varchar](50) NULL,
	[REMOTE_SENSING_DATA_SRC_CODE] [varchar](50) NULL,
	[FUEL_CONS_AND_EMIS_MODEL_CODE] [varchar](50) NULL,
	[FUEL_TYPE_MODEL_CODE] [varchar](50) NULL,
	[FUEL_SELC_CODE] [varchar](50) NULL,
	[IGNIT_METH_CODE] [varchar](50) NULL,
	[IGNIT_LOC_CODE] [varchar](50) NULL,
	[IGNIT_ORIEN_CODE] [varchar](50) NULL,
	[EVENT_CMNT] [varchar](255) NULL,
	[ATCH_FILE_CONT] [varbinary](max) NULL,
	[ATCH_FILE_NAME] [varchar](128) NULL,
	[ATCH_FILE_DESC] [varchar](255) NULL,
	[ATCH_FILE_SIZE] [varchar](255) NULL,
	[ATCH_FILE_CONT_TYPE_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_EVENT] PRIMARY KEY CLUSTERED 
(
	[EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EVENT_CERS_ID] ON [dbo].[CERS_EVENT] 
(
	[CERS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier provided by the land or event manager that identifies an event.  This identifier is unique for each event. (EventIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the event. (EventName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the Federal, State, Private, Municipal, County, Tribal agency or land owner that is managing the fire or responding to event. (LandManager)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'LAND_MGR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the location of the event. (LocationDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'LOC_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the classification of the fire. (EventClassificationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_CLASS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to determine the size of the event. (EventSizeSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SIZE_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the event was contained. (ContainmentDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'CONT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether a prescribed or agricultural fire has occurred previously at this location (Y/N). (RecurrenceIndicatorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'RECUR_IND_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The most recent year in which the fire recurred in this location. (RecurrenceYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'RECUR_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether ground-based data were included and if so, identifies their source. (GroundBasedDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'GRND_BASED_DATA_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether remotely-sensed data were included and if so, identifies their source. (RemoteSensingDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'REMOTE_SENSING_DATA_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The model(s) used to calculate fuel consumption and emissions estimates. (FuelConsumptionAndEmissionsModelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'FUEL_CONS_AND_EMIS_MODEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fuel model used to characterize available fuel beds (e.g., FCCS or NFDRS). (FuelTypeModelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'FUEL_TYPE_MODEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method used (on-site survey vs. GIS overlay) to select the appropriate fuel beds (e.g., red spruce, chaparral, sawgrass, or logging slash). (FuelSelectionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'FUEL_SELC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The method used to ignite the fire (i.e., DAID, helitorch, or driptorch). (IgnitionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'IGNIT_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The location and distribution of the ignition points within the burn area (e.g., center or multiple). (IgnitionLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'IGNIT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The  technique used to direct the orientation of the fire''s movement with respect to the wind (i.e., backing, strip-heading, or flanking). (IgnitionOrientationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'IGNIT_ORIEN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the event. (EventComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The data content of a file. (AttachmentFileContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of file. (AttachmentFileDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The size of the attached file. (AttachmentFileSize)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the content type of a file. (AttachmentFileContentTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EventDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT'
GO
/****** Object:  Table [dbo].[CERS_EVENT_RPT_PRD]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EVENT_RPT_PRD](
	[EVENT_RPT_PRD_ID] [varchar](40) NOT NULL,
	[EVENT_ID] [varchar](40) NOT NULL,
	[EVENT_BEGIN_DATE] [datetime] NOT NULL,
	[EVENT_END_DATE] [datetime] NOT NULL,
	[EVENT_STAGE_CODE] [varchar](50) NOT NULL,
	[BEGIN_HOUR] [varchar](255) NULL,
	[END_HOUR] [varchar](255) NULL,
	[EVENT_RPT_PRD_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EVENT_RPT_PRD] PRIMARY KEY CLUSTERED 
(
	[EVENT_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EVN_RP_PR_EV_ID] ON [dbo].[CERS_EVENT_RPT_PRD] 
(
	[EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first day for which emissions are reported for the reporting period. (EventBeginDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD', @level2type=N'COLUMN',@level2name=N'EVENT_BEGIN_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last day for which emissions are reported for the reporting period. (EventEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD', @level2type=N'COLUMN',@level2name=N'EVENT_END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies whether emissions reported are due to flaming, smoldering, or both. (EventStageCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD', @level2type=N'COLUMN',@level2name=N'EVENT_STAGE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The hour of the day in which the event began.  The hour is reported as a value between 00 and 23 inclusive, representing the hours of the day in 24 increments. (BeginHour)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD', @level2type=N'COLUMN',@level2name=N'BEGIN_HOUR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The hour of the day in which the event ended.  The hour is reported as a value between 00 and 23 inclusive, representing the hours of the day in 24 increments. (EndHour)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD', @level2type=N'COLUMN',@level2name=N'END_HOUR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the event reporting period. (EventReportingPeriodComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD', @level2type=N'COLUMN',@level2name=N'EVENT_RPT_PRD_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EventReportingPeriodDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_RPT_PRD'
GO
/****** Object:  Table [dbo].[CERS_MERGED_EVENTS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_MERGED_EVENTS](
	[MERGED_EVENTS_ID] [varchar](40) NOT NULL,
	[EVENT_ID] [varchar](40) NOT NULL,
	[EVENT_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[MERGED_DATE] [datetime] NULL,
	[MERGED_EVENTS_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_MERGED_EVENTS] PRIMARY KEY CLUSTERED 
(
	[MERGED_EVENTS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_MRGD_EVN_EVN_ID] ON [dbo].[CERS_MERGED_EVENTS] 
(
	[EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier provided by the land or event manager that identifies an event.  This identifier is unique for each event. (EventIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_MERGED_EVENTS', @level2type=N'COLUMN',@level2name=N'EVENT_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_MERGED_EVENTS', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first data that the discrete event is reported with the complex event. (MergedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_MERGED_EVENTS', @level2type=N'COLUMN',@level2name=N'MERGED_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the merged event. (MergedEventsComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_MERGED_EVENTS', @level2type=N'COLUMN',@level2name=N'MERGED_EVENTS_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: MergedEventsDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_MERGED_EVENTS'
GO
/****** Object:  Table [dbo].[CERS_FAC_SITE]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_FAC_SITE](
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[CERS_ID] [varchar](40) NOT NULL,
	[FAC_CATG_CODE] [varchar](50) NULL,
	[FAC_SITE_NAME] [varchar](128) NULL,
	[FAC_SITE_DESC] [varchar](255) NULL,
	[FAC_SITE_STAT_CODE] [varchar](50) NULL,
	[FAC_SITE_STAT_CODE_YEAR] [int] NULL,
	[SECT_TYPE_CODE] [varchar](50) NULL,
	[AGN_NAME] [varchar](128) NULL,
	[FAC_SITE_CMNT] [varchar](255) NULL,
	[LAT_MEAS] [varchar](255) NULL,
	[LONG_MEAS] [varchar](255) NULL,
	[SRC_MAP_SCALE_NUM] [varchar](20) NULL,
	[HORZ_ACC_MEAS] [varchar](255) NULL,
	[HORZ_ACC_UNT_MEAS] [varchar](255) NULL,
	[HORZ_COLL_METH_CODE] [varchar](50) NULL,
	[HORZ_REF_DATUM_CODE] [varchar](50) NULL,
	[GEO_REF_PT_CODE] [varchar](50) NULL,
	[DATA_COLL_DATE] [datetime] NULL,
	[GEO_CMNT] [varchar](255) NULL,
	[VERT_MEAS] [varchar](255) NULL,
	[VERT_UNT_MEAS_CODE] [varchar](50) NULL,
	[VERT_COLL_METH_CODE] [varchar](50) NULL,
	[VERT_REF_DATUM_CODE] [varchar](50) NULL,
	[VERF_METH_CODE] [varchar](50) NULL,
	[COORD_DATA_SRC_CODE] [varchar](50) NULL,
	[GEOM_TYPE_CODE] [varchar](50) NULL,
	[AREA_WTIN_PERM] [varchar](255) NULL,
	[AREA_WTIN_PERM_UNT_MEAS_CODE] [varchar](50) NULL,
	[PCNT_AREA_PROD_EMIS] [decimal](4,1) NULL,
	[ATCH_FILE_CONT] [varbinary](max) NULL,
	[ATCH_FILE_NAME] [varchar](128) NULL,
	[ATCH_FILE_DESC] [varchar](255) NULL,
	[ATCH_FILE_SIZE] [varchar](255) NULL,
	[ATCH_FILE_CONT_TYPE_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_FAC_SITE] PRIMARY KEY CLUSTERED 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FC_STE_CRS_ID] ON [dbo].[CERS_FAC_SITE] 
(
	[CERS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the Clean Air Act Stationary Source designation.  Examples include major, minor, and synthetic minor. (FacilityCategoryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_CATG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name assigned to the facility site by the reporter. (FacilitySiteName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Supplemental text that describes the facility site. (FacilitySiteDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the operating status of the facility site. (FacilitySiteStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_STAT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the operating status became applicable. (FacilitySiteStatusCodeYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_STAT_CODE_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The associated primary sector for a facility site.  Examples include:  General Stationary Combustion, Energy Production, Cement Production, Waste Water Treatment, etc. (SectorTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'SECT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the regulatory state or region where the facility is located in. (AgencyName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'AGN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the facility site. (FacilitySiteComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'FAC_SITE_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'LAT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'LONG_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizonal accuracy unit of measure. (HorizontalAccuracyUnitofMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_UNT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the reference datum used in determining latitude and longitude coordinates. (HorizontalReferenceDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'HORZ_REF_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date when data were collected. (DataCollectionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'DATA_COLL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about the geographic coordinates. (GeographicComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'GEO_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of elevation (i.e., the altitude), above or below a reference datum. (VerticalMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'VERT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The vertical unit of measure. (VerticalUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'VERT_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to collect the vertical measure (i.e., the altitude) of a reference point. (VerticalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalReferenceDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'VERT_REF_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'COORD_DATA_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the geometric entity represented by one point or a sequence of latitude and longitude points. (GeometricTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'GEOM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total area that is contained within the event perimeter for the reporting period. (AreaWithinPerimeter)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_PERM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the unit of measure for the area within the event perimeter. (AreaWithinPerimeterUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_PERM_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'PCNT_AREA_PROD_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The data content of a file. (AttachmentFileContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of file. (AttachmentFileDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The size of the attached file. (AttachmentFileSize)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the content type of a file. (AttachmentFileContentTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilitySiteDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE'
GO
/****** Object:  Table [dbo].[CERS_REL_PT]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_REL_PT](
	[REL_PT_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[REL_PT_TYPE_CODE] [varchar](50) NULL,
	[REL_PT_DESC] [varchar](255) NULL,
	[REL_PT_STK_HGT_MEAS] [varchar](255) NULL,
	[REL_PT_STK_HGT_UNT_MEAS_CODE] [varchar](50) NULL,
	[REL_PT_STK_DIA_MEAS] [varchar](255) NULL,
	[REL_PT_STK_DIA_UNT_MEAS_CODE] [varchar](50) NULL,
	[REL_PT_EXIT_GAS_VEL_MEAS] [varchar](255) NULL,
	[RL_PT_EXT_GS_VL_UNT_MS_CDE] [varchar](50) NULL,
	[REL_PT_EXIT_GAS_FLOW_RATE_MEAS] [varchar](255) NULL,
	[RL_PT_EXT_GS_FLW_RTE_UNT_MS_CD] [varchar](50) NULL,
	[REL_PT_EXIT_GAS_TMP_MEAS] [varchar](255) NULL,
	[REL_PT_FENCE_LINE_DIST_MEAS] [varchar](255) NULL,
	[RL_PT_FNCE_LNE_DST_UNT_MS_CDE] [varchar](50) NULL,
	[REL_PT_FGTV_HGT_MEAS] [varchar](255) NULL,
	[REL_PT_FGTV_HGT_UNT_MEAS_CODE] [varchar](50) NULL,
	[REL_PT_FGTV_WID_MEAS] [varchar](255) NULL,
	[REL_PT_FGTV_WID_UNT_MEAS_CODE] [varchar](50) NULL,
	[REL_PT_FGTV_LEN_MEAS] [varchar](255) NULL,
	[REL_PT_FGTV_LEN_UNT_MEAS_CODE] [varchar](50) NULL,
	[REL_PT_FGTV_ANGLE_MEAS] [varchar](255) NULL,
	[REL_PT_CMNT] [varchar](255) NULL,
	[REL_PT_STAT_CODE] [varchar](50) NULL,
	[REL_PT_STAT_CODE_YEAR] [int] NULL,
	[LAT_MEAS] [varchar](255) NULL,
	[LONG_MEAS] [varchar](255) NULL,
	[SRC_MAP_SCALE_NUM] [varchar](20) NULL,
	[HORZ_ACC_MEAS] [varchar](255) NULL,
	[HORZ_ACC_UNT_MEAS] [varchar](255) NULL,
	[HORZ_COLL_METH_CODE] [varchar](50) NULL,
	[HORZ_REF_DATUM_CODE] [varchar](50) NULL,
	[GEO_REF_PT_CODE] [varchar](50) NULL,
	[DATA_COLL_DATE] [datetime] NULL,
	[GEO_CMNT] [varchar](255) NULL,
	[VERT_MEAS] [varchar](255) NULL,
	[VERT_UNT_MEAS_CODE] [varchar](50) NULL,
	[VERT_COLL_METH_CODE] [varchar](50) NULL,
	[VERT_REF_DATUM_CODE] [varchar](50) NULL,
	[VERF_METH_CODE] [varchar](50) NULL,
	[COORD_DATA_SRC_CODE] [varchar](50) NULL,
	[GEOM_TYPE_CODE] [varchar](50) NULL,
	[AREA_WTIN_PERM] [varchar](255) NULL,
	[AREA_WTIN_PERM_UNT_MEAS_CODE] [varchar](50) NULL,
	[PCNT_AREA_PROD_EMIS] [decimal](4, 1) NULL,
 CONSTRAINT [PK_REL_PT] PRIMARY KEY CLUSTERED 
(
	[REL_PT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RL_PT_FC_STE_ID] ON [dbo].[CERS_REL_PT] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the type of release point. (ReleasePointTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text description of release point. (ReleasePointDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The height of the stack from the ground. (ReleasePointStackHeightMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_STK_HGT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The stack height unit of measure. (ReleasePointStackHeightUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_STK_HGT_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The internal diameter of the stack (measured in feet) at the release height. (ReleasePointStackDiameterMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_STK_DIA_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'the stack diameter unit of measure. (ReleasePointStackDiameterUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_STK_DIA_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The velocity of an exit gas stream. (ReleasePointExitGasVelocityMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_EXIT_GAS_VEL_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure for the velocity of an exit gas stream value.   (ReleasePointExitGasVelocityUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'RL_PT_EXT_GS_VL_UNT_MS_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the stack gas flow rate. (ReleasePointExitGasFlowRateMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_EXIT_GAS_FLOW_RATE_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure for the stack gas flow rate value.   (ReleasePointExitGasFlowRateUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'RL_PT_EXT_GS_FLW_RTE_UNT_MS_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The temperature of an exit gas stream (measured in degrees Fahrenheit). (ReleasePointExitGasTemperatureMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_EXIT_GAS_TMP_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the horizontal distance to the nearest fence line of a property within which the release point is located. (ReleasePointFenceLineDistanceMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FENCE_LINE_DIST_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fence line distance unit of measure. (ReleasePointFenceLineDistanceUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'RL_PT_FNCE_LNE_DST_UNT_MS_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fugitive release height above terrain of fugitive emissions. (ReleasePointFugitiveHeightMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_HGT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fugitive release height unit of measure. (ReleasePointFugitiveHeightUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_HGT_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The width of the fugitive release in the East-West direction as if the angle is zero degrees. (ReleasePointFugitiveWidthMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_WID_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fugitive width unit of measure code. (ReleasePointFugitiveWidthUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_WID_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The length (measured in feet) of the fugitive release in the North-South direction as if the angle is zero degrees. (ReleasePointFugitiveLengthMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_LEN_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The fugitive length unit of measure code. (ReleasePointFugitiveLengthUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_LEN_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The orientation angle for the area in degrees from North, measured positive in the clockwise direction. (ReleasePointFugitiveAngleMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_FGTV_ANGLE_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the release point. (ReleasePointComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the operating status of the release point. (ReleasePointStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_STAT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the release point status became applicable. (ReleasePointStatusCodeYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'REL_PT_STAT_CODE_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'LAT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'LONG_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizonal accuracy unit of measure. (HorizontalAccuracyUnitofMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_UNT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the reference datum used in determining latitude and longitude coordinates. (HorizontalReferenceDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'HORZ_REF_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date when data were collected. (DataCollectionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'DATA_COLL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about the geographic coordinates. (GeographicComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'GEO_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of elevation (i.e., the altitude), above or below a reference datum. (VerticalMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'VERT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The vertical unit of measure. (VerticalUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'VERT_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to collect the vertical measure (i.e., the altitude) of a reference point. (VerticalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalReferenceDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'VERT_REF_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'COORD_DATA_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the geometric entity represented by one point or a sequence of latitude and longitude points. (GeometricTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'GEOM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total area that is contained within the event perimeter for the reporting period. (AreaWithinPerimeter)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_PERM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the unit of measure for the area within the event perimeter. (AreaWithinPerimeterUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_PERM_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT', @level2type=N'COLUMN',@level2name=N'PCNT_AREA_PROD_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ReleasePointDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT'
GO
/****** Object:  Table [dbo].[CERS_FAC_SITE_QLTY_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_FAC_SITE_QLTY_IDEN](
	[FAC_SITE_QLTY_IDEN_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[QLTY_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FC_STE_QLTY_IDN] PRIMARY KEY CLUSTERED 
(
	[FAC_SITE_QLTY_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FC_ST_QL_ID_FC] ON [dbo].[CERS_FAC_SITE_QLTY_IDEN] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier for the quality finding. (QualityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_QLTY_IDEN', @level2type=N'COLUMN',@level2name=N'QLTY_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_QLTY_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilitySiteQualityIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_QLTY_IDEN'
GO
/****** Object:  Table [dbo].[CERS_FAC_SITE_ADDR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_FAC_SITE_ADDR](
	[FAC_SITE_ADDR_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[MAIL_ADDR_TXT] [varchar](255) NULL,
	[SUPP_ADDR_TXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CNTY_TXT] [varchar](255) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_POST_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[LOC_ADDR_TXT] [varchar](255) NULL,
	[SUPP_LOC_TXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[LOC_ADDR_STA_CODE] [varchar](50) NULL,
	[LOC_ADDR_POST_CODE] [varchar](50) NULL,
	[LOC_ADDR_CTRY_CODE] [varchar](50) NULL,
	[ADDR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_FAC_SITE_ADDR] PRIMARY KEY CLUSTERED 
(
	[FAC_SITE_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FC_ST_AD_FC_ST] ON [dbo].[CERS_FAC_SITE_ADDR] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city or town. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county. (MailingAddressCountyText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CNTY_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The physical location of a facility site or organization. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, village, or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the address information. (AddressComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR', @level2type=N'COLUMN',@level2name=N'ADDR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilitySiteAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_SITE_ADDR'
GO
/****** Object:  Table [dbo].[CERS_ALT_FAC_NAME]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_ALT_FAC_NAME](
	[ALT_FAC_NAME_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[ALT_NAME] [varchar](128) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[ALT_NAME_TYPE_TXT] [varchar](255) NULL,
	[EFFC_DATE] [datetime] NULL,
 CONSTRAINT [PK_ALT_FAC_NAME] PRIMARY KEY CLUSTERED 
(
	[ALT_FAC_NAME_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AL_FC_NM_FC_ST] ON [dbo].[CERS_ALT_FAC_NAME] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An alternative, historic, or program-specific name for the facility site. (AlternativeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_ALT_FAC_NAME', @level2type=N'COLUMN',@level2name=N'ALT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_ALT_FAC_NAME', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of alternative, historical, or program-specific name for the facility site (e.g., primary, legal, historical, local).  (AlternativeNameTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_ALT_FAC_NAME', @level2type=N'COLUMN',@level2name=N'ALT_NAME_TYPE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_ALT_FAC_NAME', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AlternativeFacilityNameDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_ALT_FAC_NAME'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT](
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[SCOPE] [varchar](255) NULL,
	[UNIT_DESC] [varchar](255) NULL,
	[UNIT_TYPE_CODE] [varchar](50) NULL,
	[UNIT_SRC_LOC] [varchar](255) NULL,
	[INSIG_SRC_IND] [varchar](50) NULL,
	[UNIT_DSGN_CAP] [varchar](255) NULL,
	[UNIT_DSGN_CAP_UNT_MEAS_CODE] [varchar](50) NULL,
	[UNIT_STAT_CODE] [varchar](50) NULL,
	[UNIT_STAT_CODE_YEAR] [int] NULL,
	[UNIT_OPER_DATE] [datetime] NULL,
	[UNIT_COMMER_OPER_DATE] [datetime] NULL,
	[UNIT_CMNT] [varchar](255) NULL,
	[CTRL_APCH_DESC] [varchar](255) NULL,
	[PCNT_CTRL_APCH_CAP_EFCY] [decimal](4, 1) NULL,
	[PCNT_CTRL_APCH_EFCT] [decimal](4, 1) NULL,
	[PCNT_CTRL_APCH_PEN] [decimal](4, 1) NULL,
	[FIRST_INVEN_YEAR] [int] NULL,
	[LAST_INVEN_YEAR] [int] NULL,
	[CTRL_APCH_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EMIS_UNIT] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EMS_UN_FC_ST_ID] ON [dbo].[CERS_EMIS_UNIT] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the scope of emissions data that are reported. Examples include Scope 1 - Stationary Combustion, Scope 1 - Mobile Combustion, Scope 2 - Purchased Electricity, and Scope 3 - Indirect. (Scope)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'SCOPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text description of the emissions unit. (UnitDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the type of emissions unit activity. (UnitTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The location or building number of the emissions source. (UnitSourceLocation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_SRC_LOC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the emissions source is insignificant. (InsignificantSourceIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'INSIG_SRC_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the size of the unit based on the maximum continuous throughput capacity of the unit. (UnitDesignCapacity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_DSGN_CAP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unit of measure for the design capacity of the emissions unit. (UnitDesignCapacityUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_DSGN_CAP_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the operating status of the emissions unit. (UnitStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_STAT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the unit status became applicable. (UnitStatusCodeYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_STAT_CODE_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which unit activity became operational. (UnitOperationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_OPER_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date in which the unit commenced operational activities (UnitCommercialOperationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_COMMER_OPER_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the emissions unit activity. (UnitComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'UNIT_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the overall control system or approach applied to an emissions unit or process. (ControlApproachDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'CTRL_APCH_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of that portion of an affected emission stream that is collected and routed to the control measures when the capture or collection system is operating as designed, reported as a percent. (PercentControlApproachCaptureEfficiency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_CAP_EFCY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of the portion of the reporting period''s activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary). (PercentControlApproachEffectiveness)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_EFCT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of the percent value of the nonpoint activity throughput that is affected by a rule or voluntary approach for the given location.  (Nonpoint only.) (PercentControlApproachPenetration)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_PEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The inventory year for which the controls were implemented.  (Point only.) (FirstInventoryYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'FIRST_INVEN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last inventory year for which the controls were active.  (Point only.) (LastInventoryYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'LAST_INVEN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments regarding the control approach. (ControlApproachComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT', @level2type=N'COLUMN',@level2name=N'CTRL_APCH_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT'
GO
/****** Object:  Table [dbo].[CERS_AFFL]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL](
	[AFFL_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[AFFL_TYPE_CODE] [varchar](50) NOT NULL,
	[AFFL_START_DATE] [datetime] NULL,
	[AFFL_END_DATE] [datetime] NULL,
 CONSTRAINT [PK_AFFL] PRIMARY KEY CLUSTERED 
(
	[AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AFFL_FC_STE_ID] ON [dbo].[CERS_AFFL] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the function that an organization or individual serves, or the relationship between an individual or organization and the facility site.  Examples include: Internal Reviewer, Lead Verifier, Verifying Body. (AffiliationTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_START_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL'
GO
/****** Object:  Table [dbo].[CERS_FAC_NAICS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_FAC_NAICS](
	[FAC_NAICS_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[NAICS_CODE] [varchar](50) NULL,
	[NAICS_PRI_IND] [varchar](50) NULL,
 CONSTRAINT [PK_FAC_NAICS] PRIMARY KEY CLUSTERED 
(
	[FAC_NAICS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FC_NCS_FC_ST_ID] ON [dbo].[CERS_FAC_NAICS] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a subdivision of an industry that accommodates user needs in the United States. (NAICSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (NAICSPrimaryIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_PRI_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityNAICSDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_NAICS'
GO
/****** Object:  Table [dbo].[CERS_FAC_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_FAC_IDEN](
	[FAC_IDEN_ID] [varchar](40) NOT NULL,
	[FAC_SITE_ID] [varchar](40) NOT NULL,
	[FAC_SITE_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[STA_AND_CNTY_FIPS_CODE] [varchar](50) NULL,
	[TRIB_CODE] [varchar](50) NULL,
	[STA_AND_CTRY_FIPS_CODE] [varchar](50) NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_FAC_IDEN] PRIMARY KEY CLUSTERED 
(
	[FAC_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FC_IDN_FC_ST_ID] ON [dbo].[CERS_FAC_IDEN] 
(
	[FAC_SITE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which the facility site is referred to by a system. (FacilitySiteIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The list is from FIPS Counties codes used for the identification of the Counties and County equivalents of the United States. (StateAndCountyFIPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'STA_AND_CNTY_FIPS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the American Indian Tribe or Alaskan Native entity. (TribalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'TRIB_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a State and Country for States in Mexico and Provinces in Canada. (StateAndCountryFIPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'STA_AND_CTRY_FIPS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_FAC_IDEN'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_CTRL_APCH_CTRL_MS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_CTRL_APCH_CTRL_MS](
	[EMS_UNT_CTRL_APCH_CTRL_MS_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[CTRL_MEAS_CODE] [varchar](50) NOT NULL,
	[CTRL_MEAS_SEQ] [varchar](255) NULL,
 CONSTRAINT [PK_EM_UN_CT_AP_CT] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_CTRL_APCH_CTRL_MS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_CT_AP_CT] ON [dbo].[CERS_EMS_UNT_CTRL_APCH_CTRL_MS] 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the piece of equipment or practice that is used to reduce one or more pollutants. (ControlMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_CTRL_APCH_CTRL_MS', @level2type=N'COLUMN',@level2name=N'CTRL_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sequnce in which the pollutant stream passes through the various devices in the control group. (ControlMeasureSequence)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_CTRL_APCH_CTRL_MS', @level2type=N'COLUMN',@level2name=N'CTRL_MEAS_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitControlApproachControlMeasureDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_CTRL_APCH_CTRL_MS'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_CTRL_APCH_CTR_PLT]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_CTRL_APCH_CTR_PLT](
	[EMS_UNT_CTRL_APCH_CTRL_PLT_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[POLT_CODE] [varchar](50) NOT NULL,
	[PCNT_CTRL_MEAS_REDC_EFCY] [decimal](4, 1) NULL,
 CONSTRAINT [PK_EM_UN_CT_AP_02] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_CTRL_APCH_CTRL_PLT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_CT_AP_02] ON [dbo].[CERS_EMS_UNT_CTRL_APCH_CTR_PLT] 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the pollutant for which emissions are reported. (PollutantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_CTRL_APCH_CTR_PLT', @level2type=N'COLUMN',@level2name=N'POLT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent reduction achieved for the pollutant when all control measures are operating as designed. (PercentControlMeasuresReductionEfficiency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_CTRL_APCH_CTR_PLT', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_MEAS_REDC_EFCY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitControlApproachControlPollutantDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_CTRL_APCH_CTR_PLT'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_RGLN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_RGLN](
	[EMIS_UNIT_RGLN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[RGTRY_CODE] [varchar](50) NOT NULL,
	[AGN_CODE_TXT] [varchar](255) NULL,
	[RGTRY_START_YEAR] [int] NULL,
	[RGTRY_END_YEAR] [int] NULL,
	[RGLN_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EMIS_UNIT_RGLN] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_RGLN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_RG_EM_UN] ON [dbo].[CERS_EMIS_UNIT_RGLN] 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that describes the regulation applicable to the emissions unit activity or process. (RegulatoryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text describing the non-federal regulation applicable to the emissions unit or process. (AgencyCodeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_RGLN', @level2type=N'COLUMN',@level2name=N'AGN_CODE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the enissions unit or process became subject to the regulation. (RegulatoryStartYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_START_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the enissions unit or process was no longer effected by the regulation. (RegulatoryEndYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_END_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments regarding the regulation. (RegulationComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_RGLN', @level2type=N'COLUMN',@level2name=N'RGLN_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitRegulationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_RGLN'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_QLTY_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_QLTY_IDEN](
	[EMIS_UNIT_QLTY_IDEN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[QLTY_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EMS_UNT_QLT_IDN] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_QLTY_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_QL_ID_EM] ON [dbo].[CERS_EMIS_UNIT_QLTY_IDEN] 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier for the quality finding. (QualityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_QLTY_IDEN', @level2type=N'COLUMN',@level2name=N'QLTY_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_QLTY_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitQualityIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_QLTY_IDEN'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_PROC]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_PROC](
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[SRC_CLASS_CODE] [varchar](50) NULL,
	[EMIS_TYPE_CODE] [varchar](50) NULL,
	[AIRCRAFT_ENGINE_TYPE_CODE] [varchar](50) NULL,
	[PROC_TYPE_CODE] [varchar](50) NULL,
	[PROC_DESC] [varchar](255) NULL,
	[LAST_EMIS_YEAR] [int] NULL,
	[PROC_CMNT] [varchar](255) NULL,
	[CTRL_APCH_DESC] [varchar](255) NULL,
	[PCNT_CTRL_APCH_CAP_EFCY] [decimal](4, 1) NULL,
	[PCNT_CTRL_APCH_EFCT] [decimal](4, 1) NULL,
	[PCNT_CTRL_APCH_PEN] [decimal](4, 1) NULL,
	[FIRST_INVEN_YEAR] [int] NULL,
	[LAST_INVEN_YEAR] [int] NULL,
	[CTRL_APCH_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EMIS_UNIT_PROC] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_EM_UN] ON [dbo].[CERS_EMIS_UNIT_PROC] 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPA Source Classification Code that identifies an emissions process. (SourceClassificationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'SRC_CLASS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mobile sources only. Examples include exhaust, evaporative and tire wear. (EmissionsTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'EMIS_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the combination of aircraft and engine type for airport emissions. (AircraftEngineTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'AIRCRAFT_ENGINE_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Defines the type of emissions produced by GHG processes. Examples included for a Scope 1 Stationary Combustion might be oil, gas, coal. (ProcessTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'PROC_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A text description of the emissions process. (ProcessDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'PROC_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last year in which emissions occurred for this process. (LastEmissionsYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'LAST_EMIS_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the emissions process. (ProcessComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'PROC_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the overall control system or approach applied to an emissions unit or process. (ControlApproachDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'CTRL_APCH_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of that portion of an affected emission stream that is collected and routed to the control measures when the capture or collection system is operating as designed, reported as a percent. (PercentControlApproachCaptureEfficiency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_CAP_EFCY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of the portion of the reporting period''s activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary). (PercentControlApproachEffectiveness)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_EFCT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of the percent value of the nonpoint activity throughput that is affected by a rule or voluntary approach for the given location.  (Nonpoint only.) (PercentControlApproachPenetration)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_PEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The inventory year for which the controls were implemented.  (Point only.) (FirstInventoryYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'FIRST_INVEN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last inventory year for which the controls were active.  (Point only.) (LastInventoryYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'LAST_INVEN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments regarding the control approach. (ControlApproachComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC', @level2type=N'COLUMN',@level2name=N'CTRL_APCH_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_IDEN](
	[EMIS_UNIT_IDEN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_EMIS_UNIT_IDEN] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_ID_EM_UN] ON [dbo].[CERS_EMIS_UNIT_IDEN] 
(
	[EMIS_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_IDEN'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG](
	[AFFL_ORG_ID] [varchar](40) NOT NULL,
	[AFFL_ID] [varchar](40) NOT NULL,
	[ORG_FORMAL_NAME] [varchar](128) NOT NULL,
	[PCNT_OWNER] [decimal](4, 1) NULL,
	[CONS_METH] [varchar](255) NULL,
	[ATCH_FILE_CONT] [varbinary](max) NULL,
	[ATCH_FILE_NAME] [varchar](128) NULL,
	[ATCH_FILE_DESC] [varchar](255) NULL,
	[ATCH_FILE_SIZE] [varchar](255) NULL,
	[ATCH_FILE_CONT_TYPE_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_AFFL_ORG] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AFFL_ORG_AFF_ID] ON [dbo].[CERS_AFFL_ORG] 
(
	[AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the organization. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'ORG_FORMAL_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains information on the percentage of ownership an organization has for a facility site. (PercentOwnership)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'PCNT_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Consolidation methodology for an organization, including:  operation control, financial control, operation control and equity share, financial control and equity share, equity share. (ConsolidationMethodology)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'CONS_METH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The data content of a file. (AttachmentFileContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of file. (AttachmentFileDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The size of the attached file. (AttachmentFileSize)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the content type of a file. (AttachmentFileContentTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG'
GO
/****** Object:  Table [dbo].[CERS_AFFL_INDV]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_INDV](
	[AFFL_INDV_ID] [varchar](40) NOT NULL,
	[AFFL_ID] [varchar](40) NOT NULL,
	[INDV_TITLE_TXT] [varchar](255) NULL,
	[NAME_PREFIX_TXT] [varchar](255) NULL,
	[FIRST_NAME] [varchar](128) NULL,
	[MIDDLE_NAME] [varchar](128) NULL,
	[LAST_NAME] [varchar](128) NULL,
	[NAME_SUFFIX_TXT] [varchar](255) NULL,
 CONSTRAINT [PK_AFFL_INDV] PRIMARY KEY CLUSTERED 
(
	[AFFL_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AFFL_IND_AFF_ID] ON [dbo].[CERS_AFFL_INDV] 
(
	[AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title held by a person in an organization. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV', @level2type=N'COLUMN',@level2name=N'INDV_TITLE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that precedes an individual''s name. (NamePrefixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV', @level2type=N'COLUMN',@level2name=N'NAME_PREFIX_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The given name of an individual. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV', @level2type=N'COLUMN',@level2name=N'FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The middle name or initial of an individual. (MiddleName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV', @level2type=N'COLUMN',@level2name=N'MIDDLE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The surname of an individual. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV', @level2type=N'COLUMN',@level2name=N'LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'the text that follows an individuals name. (NameSuffixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV', @level2type=N'COLUMN',@level2name=N'NAME_SUFFIX_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationIndividualDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV'
GO
/****** Object:  Table [dbo].[CERS_EVENT_LOC]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EVENT_LOC](
	[EVENT_LOC_ID] [varchar](40) NOT NULL,
	[EVENT_RPT_PRD_ID] [varchar](40) NOT NULL,
	[STA_AND_CNTY_FIPS_CODE] [varchar](50) NULL,
	[TRIB_CODE] [varchar](50) NULL,
	[STA_AND_CTRY_FIPS_CODE] [varchar](50) NULL,
	[LAT_MEAS] [varchar](255) NULL,
	[LONG_MEAS] [varchar](255) NULL,
	[SRC_MAP_SCALE_NUM] [varchar](20) NULL,
	[HORZ_ACC_MEAS] [varchar](255) NULL,
	[HORZ_ACC_UNT_MEAS] [varchar](255) NULL,
	[HORZ_COLL_METH_CODE] [varchar](50) NULL,
	[HORZ_REF_DATUM_CODE] [varchar](50) NULL,
	[GEO_REF_PT_CODE] [varchar](50) NULL,
	[DATA_COLL_DATE] [datetime] NULL,
	[GEO_CMNT] [varchar](255) NULL,
	[VERT_MEAS] [varchar](255) NULL,
	[VERT_UNT_MEAS_CODE] [varchar](50) NULL,
	[VERT_COLL_METH_CODE] [varchar](50) NULL,
	[VERT_REF_DATUM_CODE] [varchar](50) NULL,
	[VERF_METH_CODE] [varchar](50) NULL,
	[COORD_DATA_SRC_CODE] [varchar](50) NULL,
	[GEOM_TYPE_CODE] [varchar](50) NULL,
	[AREA_WTIN_PERM] [varchar](255) NULL,
	[AREA_WTIN_PERM_UNT_MEAS_CODE] [varchar](50) NULL,
	[PCNT_AREA_PROD_EMIS] [decimal](4, 1) NULL,
 CONSTRAINT [PK_EVENT_LOC] PRIMARY KEY CLUSTERED 
(
	[EVENT_LOC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EV_LC_EV_RP_PR] ON [dbo].[CERS_EVENT_LOC] 
(
	[EVENT_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The list is from FIPS Counties codes used for the identification of the Counties and County equivalents of the United States. (StateAndCountyFIPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'STA_AND_CNTY_FIPS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the American Indian Tribe or Alaskan Native entity. (TribalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'TRIB_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a State and Country for States in Mexico and Provinces in Canada. (StateAndCountryFIPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'STA_AND_CTRY_FIPS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'LAT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'LONG_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizonal accuracy unit of measure. (HorizontalAccuracyUnitofMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_UNT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the reference datum used in determining latitude and longitude coordinates. (HorizontalReferenceDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'HORZ_REF_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date when data were collected. (DataCollectionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'DATA_COLL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about the geographic coordinates. (GeographicComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'GEO_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of elevation (i.e., the altitude), above or below a reference datum. (VerticalMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'VERT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The vertical unit of measure. (VerticalUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'VERT_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the method used to collect the vertical measure (i.e., the altitude) of a reference point. (VerticalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalReferenceDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'VERT_REF_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'COORD_DATA_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the geometric entity represented by one point or a sequence of latitude and longitude points. (GeometricTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'GEOM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total area that is contained within the event perimeter for the reporting period. (AreaWithinPerimeter)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_PERM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the unit of measure for the area within the event perimeter. (AreaWithinPerimeterUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_PERM_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC', @level2type=N'COLUMN',@level2name=N'PCNT_AREA_PROD_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EventLocationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_LOC'
GO
/****** Object:  Table [dbo].[CERS_REL_PT_TST]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_REL_PT_TST](
	[REL_PT_TST_ID] [varchar](40) NOT NULL,
	[REL_PT_ID] [varchar](40) NOT NULL,
	[REL_PT_PLUME_HGT_MEAS] [varchar](255) NULL,
	[REL_PT_PLUME_HGT_UNT_MEAS_CODE] [varchar](50) NULL,
	[PCNT_OXYGEN_CONT] [decimal](4, 1) NULL,
	[PCNT_MOIS_CONT] [decimal](4, 1) NULL,
	[REL_PT_TST_DATE] [datetime] NULL,
 CONSTRAINT [PK_REL_PT_TST] PRIMARY KEY CLUSTERED 
(
	[REL_PT_TST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RL_PT_TS_RL_PT] ON [dbo].[CERS_REL_PT_TST] 
(
	[REL_PT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The height of the plume rise from the release point above sea level.  (ReleasePointPlumeHeightMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_TST', @level2type=N'COLUMN',@level2name=N'REL_PT_PLUME_HGT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The plume height unit of measure. (ReleasePointPlumeHeightUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_TST', @level2type=N'COLUMN',@level2name=N'REL_PT_PLUME_HGT_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of oxygen content present in the stack test. (PercentOxygenContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_TST', @level2type=N'COLUMN',@level2name=N'PCNT_OXYGEN_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of moisture content present in the stack test. (PercentMoistureContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_TST', @level2type=N'COLUMN',@level2name=N'PCNT_MOIS_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date in which stack test was taken. (ReleasePointTestDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_TST', @level2type=N'COLUMN',@level2name=N'REL_PT_TST_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ReleasePointTestDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_TST'
GO
/****** Object:  Table [dbo].[CERS_REL_PT_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_REL_PT_IDEN](
	[REL_PT_IDEN_ID] [varchar](40) NOT NULL,
	[REL_PT_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_REL_PT_IDEN] PRIMARY KEY CLUSTERED 
(
	[REL_PT_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RL_PT_ID_RL_PT] ON [dbo].[CERS_REL_PT_IDEN] 
(
	[REL_PT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ReleasePointIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_REL_PT_IDEN'
GO
/****** Object:  Table [dbo].[CERS_LOC]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC](
	[LOC_ID] [varchar](40) NOT NULL,
	[CERS_ID] [varchar](40) NOT NULL,
	[STA_AND_CNTY_FIPS_CODE] [varchar](50) NULL,
	[TRIB_CODE] [varchar](50) NULL,
	[STA_AND_CTRY_FIPS_CODE] [varchar](50) NULL,
	[CENSUS_BLOCK_IDEN] [varchar](50) NULL,
	[CENSUS_TRACT_IDEN] [varchar](50) NULL,
	[SHAPE_IDEN] [varchar](50) NULL,
	[LOC_CMNT] [varchar](255) NULL,
	[ATCH_FILE_CONT] [varbinary](max) NULL,
	[ATCH_FILE_NAME] [varchar](128) NULL,
	[ATCH_FILE_DESC] [varchar](255) NULL,
	[ATCH_FILE_SIZE] [varchar](255) NULL,
	[ATCH_FILE_CONT_TYPE_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_LOC] PRIMARY KEY CLUSTERED 
(
	[LOC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LOC_CERS_ID] ON [dbo].[CERS_LOC] 
(
	[CERS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The list is from FIPS Counties codes used for the identification of the Counties and County equivalents of the United States. (StateAndCountyFIPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'STA_AND_CNTY_FIPS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the American Indian Tribe or Alaskan Native entity. (TribalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'TRIB_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a State and Country for States in Mexico and Provinces in Canada. (StateAndCountryFIPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'STA_AND_CTRY_FIPS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier that represents the post 1990 census block, which is the smallest geographic entity recognized by the census. (CensusBlockIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'CENSUS_BLOCK_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier that represents the post 1990 census tract, which is ideally a neighborhood within a city. (CensusTractIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'CENSUS_TRACT_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The shape file identifier issued by EPA for a predefined geospatial shape. (ShapeIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'SHAPE_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the location. (LocationComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'LOC_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The data content of a file. (AttachmentFileContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of file. (AttachmentFileDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The size of the attached file. (AttachmentFileSize)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the content type of a file. (AttachmentFileContentTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC](
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[LOC_ID] [varchar](40) NOT NULL,
	[SRC_CLASS_CODE] [varchar](50) NULL,
	[EMIS_TYPE_CODE] [varchar](50) NULL,
	[AIRCRAFT_ENGINE_TYPE_CODE] [varchar](50) NULL,
	[PROC_TYPE_CODE] [varchar](50) NULL,
	[PROC_DESC] [varchar](255) NULL,
	[LAST_EMIS_YEAR] [int] NULL,
	[PROC_CMNT] [varchar](255) NULL,
	[CTRL_APCH_DESC] [varchar](255) NULL,
	[PCNT_CTRL_APCH_CAP_EFCY] [decimal](4, 1) NULL,
	[PCNT_CTRL_APCH_EFCT] [decimal](4, 1) NULL,
	[PCNT_CTRL_APCH_PEN] [decimal](4, 1) NULL,
	[FIRST_INVEN_YEAR] [int] NULL,
	[LAST_INVEN_YEAR] [int] NULL,
	[CTRL_APCH_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_LOC_PROC] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LOC_PROC_LOC_ID] ON [dbo].[CERS_LOC_PROC] 
(
	[LOC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPA Source Classification Code that identifies an emissions process. (SourceClassificationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'SRC_CLASS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mobile sources only. Examples include exhaust, evaporative and tire wear. (EmissionsTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'EMIS_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the combination of aircraft and engine type for airport emissions. (AircraftEngineTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'AIRCRAFT_ENGINE_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Defines the type of emissions produced by GHG processes. Examples included for a Scope 1 Stationary Combustion might be oil, gas, coal. (ProcessTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'PROC_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A text description of the emissions process. (ProcessDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'PROC_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last year in which emissions occurred for this process. (LastEmissionsYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'LAST_EMIS_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the emissions process. (ProcessComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'PROC_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the overall control system or approach applied to an emissions unit or process. (ControlApproachDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'CTRL_APCH_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of that portion of an affected emission stream that is collected and routed to the control measures when the capture or collection system is operating as designed, reported as a percent. (PercentControlApproachCaptureEfficiency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_CAP_EFCY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of the portion of the reporting period''s activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary). (PercentControlApproachEffectiveness)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_EFCT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An estimate of the percent value of the nonpoint activity throughput that is affected by a rule or voluntary approach for the given location.  (Nonpoint only.) (PercentControlApproachPenetration)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_APCH_PEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The inventory year for which the controls were implemented.  (Point only.) (FirstInventoryYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'FIRST_INVEN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last inventory year for which the controls were active.  (Point only.) (LastInventoryYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'LAST_INVEN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments regarding the control approach. (ControlApproachComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC', @level2type=N'COLUMN',@level2name=N'CTRL_APCH_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC_REL_PT_APPR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC_REL_PT_APPR](
	[LOC_PROC_REL_PT_APPR_ID] [varchar](40) NOT NULL,
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[AVE_PCNT_EMIS] [decimal](4, 1) NOT NULL,
	[REL_PT_APPR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_LC_PRC_RL_PT_AP] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_REL_PT_APPR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RL_PT_AP] ON [dbo].[CERS_LOC_PROC_REL_PT_APPR] 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average annual percent of an emissions process that is vented through a release point. (AveragePercentEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR', @level2type=N'COLUMN',@level2name=N'AVE_PCNT_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment regarding the average apportionment of emissions vented through a release point. (ReleasePointApportionmentComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR', @level2type=N'COLUMN',@level2name=N'REL_PT_APPR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessReleasePointApportionmentDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC_IDEN](
	[LOC_PROC_IDEN_ID] [varchar](40) NOT NULL,
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_LOC_PROC_IDEN] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_ID_LC_PR] ON [dbo].[CERS_LOC_PROC_IDEN] 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_IDEN'
GO
/****** Object:  Table [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_PLT]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_PLT](
	[LC_PRC_CTRL_APCH_CTRL_PLT_ID] [varchar](40) NOT NULL,
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[POLT_CODE] [varchar](50) NOT NULL,
	[PCNT_CTRL_MEAS_REDC_EFCY] [decimal](4, 1) NULL,
 CONSTRAINT [PK_LC_PR_CT_AP_02] PRIMARY KEY CLUSTERED 
(
	[LC_PRC_CTRL_APCH_CTRL_PLT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_CT_AP_02] ON [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_PLT] 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the pollutant for which emissions are reported. (PollutantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_CTRL_APCH_CTRL_PLT', @level2type=N'COLUMN',@level2name=N'POLT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent reduction achieved for the pollutant when all control measures are operating as designed. (PercentControlMeasuresReductionEfficiency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_CTRL_APCH_CTRL_PLT', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_MEAS_REDC_EFCY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessControlApproachControlPollutantDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_CTRL_APCH_CTRL_PLT'
GO
/****** Object:  Table [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_MS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_MS](
	[LC_PRC_CTRL_APCH_CTRL_MS_ID] [varchar](40) NOT NULL,
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[CTRL_MEAS_CODE] [varchar](50) NOT NULL,
	[CTRL_MEAS_SEQ] [varchar](255) NULL,
 CONSTRAINT [PK_LC_PR_CT_AP_CT] PRIMARY KEY CLUSTERED 
(
	[LC_PRC_CTRL_APCH_CTRL_MS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_CT_AP_CT] ON [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_MS] 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the piece of equipment or practice that is used to reduce one or more pollutants. (ControlMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_CTRL_APCH_CTRL_MS', @level2type=N'COLUMN',@level2name=N'CTRL_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sequnce in which the pollutant stream passes through the various devices in the control group. (ControlMeasureSequence)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_CTRL_APCH_CTRL_MS', @level2type=N'COLUMN',@level2name=N'CTRL_MEAS_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessControlApproachControlMeasureDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_CTRL_APCH_CTRL_MS'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC_RPT_PRD]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC_RPT_PRD](
	[LOC_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[RPT_PRD_TYPE_CODE] [varchar](50) NOT NULL,
	[EMIS_OPER_TYPE_CODE] [varchar](50) NULL,
	[START_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
	[CALC_PARM_TYPE_CODE] [varchar](50) NULL,
	[CALC_PARM_VAL] [varchar](50) NULL,
	[CALC_PARM_UNT_MEAS] [varchar](255) NULL,
	[CALC_MATERIAL_CODE] [varchar](50) NULL,
	[CALC_DATA_YEAR] [int] NULL,
	[CALC_DATA_SRC] [varchar](255) NULL,
	[RPT_PRD_CMNT] [varchar](255) NULL,
	[ACTL_HOURS_PER_PRD] [varchar](255) NULL,
	[AVE_DAYS_PER_WEEK] [varchar](255) NULL,
	[AVE_HOURS_PER_DAY] [varchar](255) NULL,
	[AVE_WEEKS_PER_PRD] [varchar](255) NULL,
	[PCNT_WINTER_ACT] [decimal](4, 1) NULL,
	[PCNT_SPRING_ACT] [decimal](4, 1) NULL,
	[PCNT_SUMMER_ACT] [decimal](4, 1) NULL,
	[PCNT_FALL_ACT] [decimal](4, 1) NULL,
 CONSTRAINT [PK_LC_PRC_RPT_PRD] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RP_PR_LC] ON [dbo].[CERS_LOC_PROC_RPT_PRD] 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time period type for which emissions are reported. (ReportingPeriodTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'RPT_PRD_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the operating state for the emissions being reported. (EmissionOperatingTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'EMIS_OPER_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the reporting period began.  Applies to the reporting of episodic or event emissions only. (StartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'START_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating whether the material measured is an input to the process, an output of the process or a static count (not a throughput).  (CalculationParameterTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_PARM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Activity or throughput of the process for a given time period. (CalculationParameterValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_PARM_VAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code for the unit of measure for calculation parameter value. (CalculationParameterUnitofMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_PARM_UNT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code for material or fuel processed. (CalculationMaterialCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_MATERIAL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual year represented by the data if it is different from the emissions year. (CalculationDataYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_DATA_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of the data used. (CalculationDataSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_DATA_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the reporting period. (ReportingPeriodComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'RPT_PRD_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Actual number of hours the process is active or operating during for the reporting period. (ActualHoursPerPeriod)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'ACTL_HOURS_PER_PRD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of days per week that the emissions process is active within the reporting period. (AverageDaysPerWeek)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'AVE_DAYS_PER_WEEK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of hours per day that the emissions process is active within the reporting period. (AverageHoursPerDay)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'AVE_HOURS_PER_DAY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of weeks that the emissions process is active within the reporting period. (AverageWeeksPerPeriod)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'AVE_WEEKS_PER_PRD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Winter months (December, January, February). (PercentWinterActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_WINTER_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Spring months (March, April, May). (PercentSpringActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_SPRING_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Summer months (June, July, August). (PercentSummerActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_SUMMER_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Fall months (September, October, November). (PercentFallActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_FALL_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessReportingPeriodDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC_RGLN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC_RGLN](
	[LOC_PROC_RGLN_ID] [varchar](40) NOT NULL,
	[LOC_PROC_ID] [varchar](40) NOT NULL,
	[RGTRY_CODE] [varchar](50) NOT NULL,
	[AGN_CODE_TXT] [varchar](255) NULL,
	[RGTRY_START_YEAR] [int] NULL,
	[RGTRY_END_YEAR] [int] NULL,
	[RGLN_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_LOC_PROC_RGLN] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_RGLN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RG_LC_PR] ON [dbo].[CERS_LOC_PROC_RGLN] 
(
	[LOC_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that describes the regulation applicable to the emissions unit activity or process. (RegulatoryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text describing the non-federal regulation applicable to the emissions unit or process. (AgencyCodeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'AGN_CODE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the enissions unit or process became subject to the regulation. (RegulatoryStartYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_START_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the enissions unit or process was no longer effected by the regulation. (RegulatoryEndYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_END_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments regarding the regulation. (RegulationComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGLN_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessRegulationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RGLN'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND](
	[QLTY_FIND_ID] [varchar](40) NOT NULL,
	[CERS_ID] [varchar](40) NOT NULL,
	[QLTY_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[QLTY_VERF_TYPE] [varchar](255) NULL,
	[QLTY_TYPE_CODE] [varchar](50) NULL,
	[QLTY_EXCPT] [varchar](255) NULL,
	[QLTY_STAT_CODE] [varchar](50) NULL,
	[QLTY_LEVELOF_ASSURANCE_CODE] [varchar](50) NULL,
	[QLTY_STANDARDS_SRC] [varchar](255) NULL,
	[QLTY_DETERMINATION_DATE] [datetime] NULL,
	[ATCH_FILE_CONT] [varbinary](max) NULL,
	[ATCH_FILE_NAME] [varchar](128) NULL,
	[ATCH_FILE_DESC] [varchar](255) NULL,
	[ATCH_FILE_SIZE] [varchar](255) NULL,
	[ATCH_FILE_CONT_TYPE_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_QLTY_FIND] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QLTY_FND_CRS_ID] ON [dbo].[CERS_QLTY_FIND] 
(
	[CERS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier for the quality finding. (QualityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the type of verification, such as entity inventory or emissions reduction project.  (QualityVerificationType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_VERF_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The nature of the verification report issued. Examples include: adverse or qualified. (QualityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any exceptions that the verifier has reported. (QualityExceptions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_EXCPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The quality or verification status of the facility site, emissions unit or emissions. Examples include:  verified or unverified. (QualityStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_STAT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The degree of assurance the intended user required in the verification findings.  Examples include:  reasonable and limited. (QualityLevelofAssuranceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_LEVELOF_ASSURANCE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of the standard such as ISO 14064-3, TCR GVP, CCAR GVP, etc. (QualityStandardsSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_STANDARDS_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which status was determined. (QualityDeterminationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'QLTY_DETERMINATION_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The data content of a file. (AttachmentFileContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of file. (AttachmentFileDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The size of the attached file. (AttachmentFileSize)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the content type of a file. (AttachmentFileContentTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG](
	[QLTY_FIND_ORG_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ID] [varchar](40) NOT NULL,
	[ORG_FORMAL_NAME] [varchar](128) NOT NULL,
	[PCNT_OWNER] [decimal](4, 1) NULL,
	[CONS_METH] [varchar](255) NULL,
	[ATCH_FILE_CONT] [varbinary](max) NULL,
	[ATCH_FILE_NAME] [varchar](128) NULL,
	[ATCH_FILE_DESC] [varchar](255) NULL,
	[ATCH_FILE_SIZE] [varchar](255) NULL,
	[ATCH_FILE_CONT_TYPE_CODE] [varchar](50) NULL,
 CONSTRAINT [PK_QLTY_FIND_ORG] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_QL_FN] ON [dbo].[CERS_QLTY_FIND_ORG] 
(
	[QLTY_FIND_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the organization. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'ORG_FORMAL_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains information on the percentage of ownership an organization has for a facility site. (PercentOwnership)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'PCNT_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Consolidation methodology for an organization, including:  operation control, financial control, operation control and equity share, financial control and equity share, equity share. (ConsolidationMethodology)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'CONS_METH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The data content of a file. (AttachmentFileContent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text describing the descriptive name used to represent the file, including file extension. (AttachmentFileName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of file. (AttachmentFileDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The size of the attached file. (AttachmentFileSize)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code describing the content type of a file. (AttachmentFileContentTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG', @level2type=N'COLUMN',@level2name=N'ATCH_FILE_CONT_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_INDV]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV](
	[QLTY_FIND_ORG_INDV_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_ID] [varchar](40) NOT NULL,
	[INDV_TITLE_TXT] [varchar](255) NULL,
	[NAME_PREFIX_TXT] [varchar](255) NULL,
	[FIRST_NAME] [varchar](128) NULL,
	[MIDDLE_NAME] [varchar](128) NULL,
	[LAST_NAME] [varchar](128) NULL,
	[NAME_SUFFIX_TXT] [varchar](255) NULL,
 CONSTRAINT [PK_QLT_FND_ORG_IND] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_IN_QL] ON [dbo].[CERS_QLTY_FIND_ORG_INDV] 
(
	[QLTY_FIND_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title held by a person in an organization. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV', @level2type=N'COLUMN',@level2name=N'INDV_TITLE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that precedes an individual''s name. (NamePrefixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV', @level2type=N'COLUMN',@level2name=N'NAME_PREFIX_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The given name of an individual. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV', @level2type=N'COLUMN',@level2name=N'FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The middle name or initial of an individual. (MiddleName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV', @level2type=N'COLUMN',@level2name=N'MIDDLE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The surname of an individual. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV', @level2type=N'COLUMN',@level2name=N'LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'the text that follows an individuals name. (NameSuffixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV', @level2type=N'COLUMN',@level2name=N'NAME_SUFFIX_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationIndividualDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_IDEN](
	[QLTY_FIND_ORG_IDEN_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_QLT_FND_ORG_IDN] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_ID_QL] ON [dbo].[CERS_QLTY_FIND_ORG_IDEN] 
(
	[QLTY_FIND_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_IDEN'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_COMMUN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_COMMUN](
	[QLTY_FIND_ORG_COMMUN_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_ID] [varchar](40) NOT NULL,
	[TELE_NUM_TXT] [varchar](20) NULL,
	[TELE_NUM_TYPE_NAME] [varchar](128) NULL,
	[TELE_EXT_NUM_TXT] [varchar](20) NULL,
	[ELEC_ADDR_TXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](128) NULL,
 CONSTRAINT [PK_QLT_FND_ORG_CMM] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_COMMUN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_CM_QL] ON [dbo].[CERS_QLTY_FIND_ORG_COMMUN] 
(
	[QLTY_FIND_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_EXT_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationCommunicationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_COMMUN'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_ADDR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_ADDR](
	[QLTY_FIND_ORG_ADDR_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_ID] [varchar](40) NOT NULL,
	[MAIL_ADDR_TXT] [varchar](255) NULL,
	[SUPP_ADDR_TXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CNTY_TXT] [varchar](255) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_POST_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[LOC_ADDR_TXT] [varchar](255) NULL,
	[SUPP_LOC_TXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[LOC_ADDR_STA_CODE] [varchar](50) NULL,
	[LOC_ADDR_POST_CODE] [varchar](50) NULL,
	[LOC_ADDR_CTRY_CODE] [varchar](50) NULL,
	[ADDR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_QLT_FND_ORG_ADD] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_AD_QL] ON [dbo].[CERS_QLTY_FIND_ORG_ADDR] 
(
	[QLTY_FIND_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city or town. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county. (MailingAddressCountyText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CNTY_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The physical location of a facility site or organization. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, village, or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the address information. (AddressComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'ADDR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_ADDR'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC_REL_PT_APPR_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC_REL_PT_APPR_IDEN](
	[LOC_PROC_REL_PT_APPR_IDEN_ID] [varchar](40) NOT NULL,
	[LOC_PROC_REL_PT_APPR_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_LC_PR_RL_PT_AP] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_REL_PT_APPR_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RL_PT_02] ON [dbo].[CERS_LOC_PROC_REL_PT_APPR_IDEN] 
(
	[LOC_PROC_REL_PT_APPR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessReleasePointApportionmentIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_REL_PT_APPR_IDEN'
GO
/****** Object:  Table [dbo].[CERS_LOC_PROC_RPT_PRD_EMIS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LOC_PROC_RPT_PRD_EMIS](
	[LOC_PROC_RPT_PRD_EMIS_ID] [varchar](40) NOT NULL,
	[LOC_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[POLT_CODE] [varchar](50) NOT NULL,
	[TOTAL_EMIS] [varchar](255) NOT NULL,
	[EMIS_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC] [varchar](255) NULL,
	[EMIS_FAC_NUM_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC_DEN_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC_FORM_CODE] [varchar](50) NULL,
	[EMIS_FAC_TXT] [varchar](255) NULL,
	[EMIS_CALC_METH_CODE] [varchar](50) NULL,
	[EMIS_FAC_REF_TXT] [varchar](255) NULL,
	[ALGOR_FORM_TXT] [varchar](255) NULL,
	[ALGOR_CMNT] [varchar](255) NULL,
	[CALC_METH_ACC_ASMT_CODE] [varchar](50) NULL,
	[EMIS_DE_MINIMIS_STAT] [varchar](255) NULL,
	[EMIS_CMNT] [varchar](255) NULL,
	[CO_2E] [varchar](255) NULL,
	[CO_2E_UNT_MEAS_CODE] [varchar](50) NULL,
	[CO_2_CONV_FAC] [varchar](255) NULL,
	[CO_2_CONV_FAC_SRC] [varchar](255) NULL,
 CONSTRAINT [PK_LC_PRC_RP_PR_EM] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_RPT_PRD_EMIS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RP_PR_EM] ON [dbo].[CERS_LOC_PROC_RPT_PRD_EMIS] 
(
	[LOC_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the pollutant for which emissions are reported. (PollutantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'POLT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total calculated or estimated amount of the pollutant. (TotalEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'TOTAL_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unit of measure for reported emissions. (EmissionsUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The emission factor used for the emissions value if a calculated value was provided. (EmissionFactor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerator for the unit of measure of the reported emission factor. (EmissionFactorNumeratorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_NUM_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The denominator for the unit of measure of the reported emission factor. (EmissionFactorDenominatorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_DEN_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the emission factor formula used to calculate emissions. (EmissionFactorFormulaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_FORM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Explanation for emission factor. (EmissionFactorText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that defines the method used to calculate emissions. (EmissionCalculationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_CALC_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference given for the emission factor used in the calculation. (EmissionFactorReferenceText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_REF_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formula used to calculate emissions. (AlgorithmFormulaText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'ALGOR_FORM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the algorithm, including units of measure, for the calculation method. (AlgorithmComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'ALGOR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C, CARB, Part 75, etc.  (CalculationMethodAccuracyAssessmentCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'CALC_METH_ACC_ASMT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status indicating if emissions are de minimis. (EmissionsDeMinimisStatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_DE_MINIMIS_STAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the emissions, method of calculation, or emission factor. (EmissionsComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total CO2 equivalent emissions. (CO2e)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2E'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure for the CO2 equivalent emissions. (CO2eUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2E_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Global warming potential (GWP) used to calculate CO2e. (CO2ConversionFactor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2_CONV_FAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of reference for the GWP value. (CO2ConversionFactorSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2_CONV_FAC_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessReportingPeriodEmissionsDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LOC_PROC_RPT_PRD_EMIS'
GO
/****** Object:  Table [dbo].[CERS_LC_PRC_RPT_PRD_SPP_CLC_PR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LC_PRC_RPT_PRD_SPP_CLC_PR](
	[LC_PRC_RPT_PRD_SPP_CLC_PRM_ID] [varchar](40) NOT NULL,
	[LOC_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[SUPP_CALC_PARM_TYPE] [varchar](255) NULL,
	[SUPP_CALC_PARM_VAL] [varchar](50) NULL,
	[SPP_CLC_PRM_NM_UNT_MS_CDE] [varchar](50) NULL,
	[SPP_CLC_PRM_DN_UNT_MS_CDE] [varchar](50) NULL,
	[SUPP_CALC_PARM_DATA_YEAR] [int] NULL,
	[SUPP_CALC_PARM_DATA_SRC] [varchar](255) NULL,
	[SUPP_CALC_PARM_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_LC_PR_RP_PR_SP] PRIMARY KEY CLUSTERED 
(
	[LC_PRC_RPT_PRD_SPP_CLC_PRM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RP_PR_SP] ON [dbo].[CERS_LC_PRC_RPT_PRD_SPP_CLC_PR] 
(
	[LOC_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the parameter that describes the type of activity, throughput or input used in the calculation. (SupplementalCalculationParameterType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the parameter. (SupplementalCalculationParameterValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_VAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerator unit of measure for the parameter. (SupplementalCalculationParameterNumeratorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SPP_CLC_PRM_NM_UNT_MS_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The denominator unit of measure for the parameter. (SupplementalCalculationParameterDenominatorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SPP_CLC_PRM_DN_UNT_MS_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year represented by the supplemental data if it is different from the emissions year. (SupplementalCalculationParameterDataYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_DATA_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of the supplemental parameter data used. (SupplementalCalculationParameterDataSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_DATA_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the parameter. (SupplementalCalculationParameterComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessReportingPeriodSupplementalCalculationParameterDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_SPP_CLC_PR'
GO
/****** Object:  Table [dbo].[CERS_LC_PRC_RPT_PRD_QLTY_IDN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_LC_PRC_RPT_PRD_QLTY_IDN](
	[LOC_PROC_RPT_PRD_QLTY_IDEN_ID] [varchar](40) NOT NULL,
	[LOC_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[QLTY_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LC_PR_RP_PR_QL] PRIMARY KEY CLUSTERED 
(
	[LOC_PROC_RPT_PRD_QLTY_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_LC_PR_RP_PR_QL] ON [dbo].[CERS_LC_PRC_RPT_PRD_QLTY_IDN] 
(
	[LOC_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier for the quality finding. (QualityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_QLTY_IDN', @level2type=N'COLUMN',@level2name=N'QLTY_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_QLTY_IDN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: LocationProcessReportingPeriodQualityIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_LC_PRC_RPT_PRD_QLTY_IDN'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_INDV_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_IDEN](
	[QLTY_FIND_ORG_INDV_IDEN_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_INDV_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_QLT_FN_OR_IN_ID] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_INDV_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_IN_ID] ON [dbo].[CERS_QLTY_FIND_ORG_INDV_IDEN] 
(
	[QLTY_FIND_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationIndividualIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_IDEN'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_INDV_COMMUN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_COMMUN](
	[QLTY_FIND_ORG_INDV_COMMUN_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_INDV_ID] [varchar](40) NOT NULL,
	[TELE_NUM_TXT] [varchar](20) NULL,
	[TELE_NUM_TYPE_NAME] [varchar](128) NULL,
	[TELE_EXT_NUM_TXT] [varchar](20) NULL,
	[ELEC_ADDR_TXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](128) NULL,
 CONSTRAINT [PK_QLT_FN_OR_IN_CM] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_INDV_COMMUN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_IN_CM] ON [dbo].[CERS_QLTY_FIND_ORG_INDV_COMMUN] 
(
	[QLTY_FIND_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_EXT_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationIndividualCommunicationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_COMMUN'
GO
/****** Object:  Table [dbo].[CERS_QLTY_FIND_ORG_INDV_ADDR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_ADDR](
	[QLTY_FIND_ORG_INDV_ADDR_ID] [varchar](40) NOT NULL,
	[QLTY_FIND_ORG_INDV_ID] [varchar](40) NOT NULL,
	[MAIL_ADDR_TXT] [varchar](255) NULL,
	[SUPP_ADDR_TXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CNTY_TXT] [varchar](255) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_POST_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[LOC_ADDR_TXT] [varchar](255) NULL,
	[SUPP_LOC_TXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[LOC_ADDR_STA_CODE] [varchar](50) NULL,
	[LOC_ADDR_POST_CODE] [varchar](50) NULL,
	[LOC_ADDR_CTRY_CODE] [varchar](50) NULL,
	[ADDR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_QLT_FN_OR_IN_AD] PRIMARY KEY CLUSTERED 
(
	[QLTY_FIND_ORG_INDV_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_QL_FN_OR_IN_AD] ON [dbo].[CERS_QLTY_FIND_ORG_INDV_ADDR] 
(
	[QLTY_FIND_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city or town. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county. (MailingAddressCountyText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CNTY_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The physical location of a facility site or organization. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, village, or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the address information. (AddressComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'ADDR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: QualityFindingOrganizationIndividualAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_QLTY_FIND_ORG_INDV_ADDR'
GO
/****** Object:  Table [dbo].[CERS_EVENT_EMIS_PROC]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EVENT_EMIS_PROC](
	[EVENT_EMIS_PROC_ID] [varchar](40) NOT NULL,
	[EVENT_LOC_ID] [varchar](40) NOT NULL,
	[SRC_CLASS_CODE] [varchar](50) NOT NULL,
	[FUEL_CONFIG_CODE] [varchar](50) NULL,
	[FUEL_LOADING] [varchar](255) NULL,
	[FUEL_LOADING_UNT_MEAS_CODE] [varchar](50) NULL,
	[AMT_FUEL_CONS] [varchar](255) NULL,
	[AMT_FUEL_CONS_UNT_MEAS_CODE] [varchar](50) NULL,
	[PCNT_TEN_HOUR_FUEL_MOIS] [decimal](4, 1) NULL,
	[PCNT_ONE_THSD_HOUR_FUEL_MOIS] [decimal](4, 1) NULL,
	[PCNT_LIVE_FUEL_MOIS] [decimal](4, 1) NULL,
	[PCNT_DUFF_FUEL_MOIS] [decimal](4, 1) NULL,
	[HEAT_REL] [varchar](255) NULL,
	[HEAT_REL_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_REDC_TECHNIQUE_CODE] [varchar](50) NULL,
	[EVENT_EMIS_PROC_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EVENT_EMIS_PROC] PRIMARY KEY CLUSTERED 
(
	[EVENT_EMIS_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EV_EM_PR_EV_LC] ON [dbo].[CERS_EVENT_EMIS_PROC] 
(
	[EVENT_LOC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPA Source Classification Code that identifies an emissions process. (SourceClassificationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'SRC_CLASS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The predominant configuration of the fuel burned (i.e., pile, windrow, broadcast or natural). (FuelConfigurationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'FUEL_CONFIG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fuel per acre available to consume. (FuelLoading)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'FUEL_LOADING'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the numerator of the unit of measure for the fuel loading. (FuelLoadingUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'FUEL_LOADING_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For a given day, the amount of fuel consumed in the defined geographic area. (AmountofFuelConsumed)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'AMT_FUEL_CONS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the unit of measure for the amount of fuel consumed. (AmountofFuelConsumedUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'AMT_FUEL_CONS_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ten-hour fuel moisture for the location, on the particular day the fire or smoldering occurred, in percent. (PercentTenHourFuelMoisture)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_TEN_HOUR_FUEL_MOIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The one-thousand-hour fuel moisture for the location, on the particular day the fire or smoldering occurred, in percent. (PercentOneThousandHourFuelMoisture)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_ONE_THSD_HOUR_FUEL_MOIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of water expressed as the percent of oven dry weight of living plant matter. (PercentLiveFuelMoisture)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_LIVE_FUEL_MOIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of water expressed as the percent of the oven dry weight of any cured or dead plant part.  This may include dead plant matter still attached to living plants. (PercentDuffFuelMoisture)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'PCNT_DUFF_FUEL_MOIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The amount of effective thermal energy (measured in million BTUs per hour or day) available to provide buoyant plume rise. (HeatRelease)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'HEAT_REL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the unit of measure for heat release. (HeatReleaseUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'HEAT_REL_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the method used for reducing emissions from prescribed fires, agricultural fires, Native American Fires and Wildland Use fires emissions. (EmissionReductionTechniqueCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'EMIS_REDC_TECHNIQUE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the event emissions process. (EventEmissionsProcessComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC', @level2type=N'COLUMN',@level2name=N'EVENT_EMIS_PROC_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EventEmissionsProcessDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_PROC'
GO
/****** Object:  Table [dbo].[CERS_GEOSPATIAL_PARAMS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_GEOSPATIAL_PARAMS](
	[GEOSPATIAL_PARAMS_ID] [varchar](40) NOT NULL,
	[EVENT_LOC_ID] [varchar](40) NOT NULL,
	[SHAPE_FILE_IDEN] [varchar](50) NOT NULL,
	[AREA_WTIN_SHAPE] [varchar](255) NULL,
	[AREA_WTIN_SHAPE_UNT_MEAS_CODE] [varchar](50) NULL,
	[PCNT_AREA_PROD_EMIS] [decimal](4, 1) NULL,
	[GEOSPATIAL_PARAMS_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_GSPTL_PRMS] PRIMARY KEY CLUSTERED 
(
	[GEOSPATIAL_PARAMS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_GSP_PR_EV_LC_ID] ON [dbo].[CERS_GEOSPATIAL_PARAMS] 
(
	[EVENT_LOC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier provided by the reporting agency that identifies the geospatial shape file for the reported emissions. (ShapeFileIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_GEOSPATIAL_PARAMS', @level2type=N'COLUMN',@level2name=N'SHAPE_FILE_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total area that is contained within the event shape for the reporting period. (AreaWithinShape)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_GEOSPATIAL_PARAMS', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_SHAPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the unit of measure for the area within the shape file. (AreaWithinShapeUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_GEOSPATIAL_PARAMS', @level2type=N'COLUMN',@level2name=N'AREA_WTIN_SHAPE_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of the area within the shape or perimeter that was affected by the event (e.g., area actually blackened by a fire). (PercentofAreaProducingEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_GEOSPATIAL_PARAMS', @level2type=N'COLUMN',@level2name=N'PCNT_AREA_PROD_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the geospatial parameters. (GeospatialParametersComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_GEOSPATIAL_PARAMS', @level2type=N'COLUMN',@level2name=N'GEOSPATIAL_PARAMS_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GeospatialParametersDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_GEOSPATIAL_PARAMS'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PRC_RL_PT_APPR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PRC_RL_PT_APPR](
	[EMIS_UNIT_PROC_REL_PT_APPR_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[AVE_PCNT_EMIS] [decimal](4, 1) NOT NULL,
	[REL_PT_APPR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EM_UN_PR_RL_PT] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_PROC_REL_PT_APPR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RL_PT] ON [dbo].[CERS_EMS_UNT_PRC_RL_PT_APPR] 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average annual percent of an emissions process that is vented through a release point. (AveragePercentEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APPR', @level2type=N'COLUMN',@level2name=N'AVE_PCNT_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment regarding the average apportionment of emissions vented through a release point. (ReleasePointApportionmentComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APPR', @level2type=N'COLUMN',@level2name=N'REL_PT_APPR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessReleasePointApportionmentDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APPR'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD](
	[EMIS_UNIT_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[RPT_PRD_TYPE_CODE] [varchar](50) NOT NULL,
	[EMIS_OPER_TYPE_CODE] [varchar](50) NULL,
	[START_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
	[CALC_PARM_TYPE_CODE] [varchar](50) NULL,
	[CALC_PARM_VAL] [varchar](50) NULL,
	[CALC_PARM_UNT_MEAS] [varchar](255) NULL,
	[CALC_MATERIAL_CODE] [varchar](50) NULL,
	[CALC_DATA_YEAR] [int] NULL,
	[CALC_DATA_SRC] [varchar](255) NULL,
	[RPT_PRD_CMNT] [varchar](255) NULL,
	[ACTL_HOURS_PER_PRD] [varchar](255) NULL,
	[AVE_DAYS_PER_WEEK] [varchar](255) NULL,
	[AVE_HOURS_PER_DAY] [varchar](255) NULL,
	[AVE_WEEKS_PER_PRD] [varchar](255) NULL,
	[PCNT_WINTER_ACT] [decimal](4, 1) NULL,
	[PCNT_SPRING_ACT] [decimal](4, 1) NULL,
	[PCNT_SUMMER_ACT] [decimal](4, 1) NULL,
	[PCNT_FALL_ACT] [decimal](4, 1) NULL,
 CONSTRAINT [PK_EMS_UN_PR_RP_PR] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RP_PR] ON [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD] 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The time period type for which emissions are reported. (ReportingPeriodTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'RPT_PRD_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the operating state for the emissions being reported. (EmissionOperatingTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'EMIS_OPER_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the reporting period began.  Applies to the reporting of episodic or event emissions only. (StartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'START_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating whether the material measured is an input to the process, an output of the process or a static count (not a throughput).  (CalculationParameterTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_PARM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Activity or throughput of the process for a given time period. (CalculationParameterValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_PARM_VAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code for the unit of measure for calculation parameter value. (CalculationParameterUnitofMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_PARM_UNT_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code for material or fuel processed. (CalculationMaterialCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_MATERIAL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual year represented by the data if it is different from the emissions year. (CalculationDataYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_DATA_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of the data used. (CalculationDataSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'CALC_DATA_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the reporting period. (ReportingPeriodComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'RPT_PRD_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Actual number of hours the process is active or operating during for the reporting period. (ActualHoursPerPeriod)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'ACTL_HOURS_PER_PRD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of days per week that the emissions process is active within the reporting period. (AverageDaysPerWeek)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'AVE_DAYS_PER_WEEK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of hours per day that the emissions process is active within the reporting period. (AverageHoursPerDay)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'AVE_HOURS_PER_DAY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average number of weeks that the emissions process is active within the reporting period. (AverageWeeksPerPeriod)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'AVE_WEEKS_PER_PRD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Winter months (December, January, February). (PercentWinterActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_WINTER_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Spring months (March, April, May). (PercentSpringActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_SPRING_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Summer months (June, July, August). (PercentSummerActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_SUMMER_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percentage of the annual activity that occurred during the Fall months (September, October, November). (PercentFallActivity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD', @level2type=N'COLUMN',@level2name=N'PCNT_FALL_ACT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessReportingPeriodDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RPT_PRD'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_PROC_RGLN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_PROC_RGLN](
	[EMIS_UNIT_PROC_RGLN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[RGTRY_CODE] [varchar](50) NOT NULL,
	[AGN_CODE_TXT] [varchar](255) NULL,
	[RGTRY_START_YEAR] [int] NULL,
	[RGTRY_END_YEAR] [int] NULL,
	[RGLN_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EMS_UNT_PRC_RGL] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_PROC_RGLN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RG_EM] ON [dbo].[CERS_EMIS_UNIT_PROC_RGLN] 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that describes the regulation applicable to the emissions unit activity or process. (RegulatoryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text describing the non-federal regulation applicable to the emissions unit or process. (AgencyCodeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'AGN_CODE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the enissions unit or process became subject to the regulation. (RegulatoryStartYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_START_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year in which the enissions unit or process was no longer effected by the regulation. (RegulatoryEndYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGTRY_END_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comments regarding the regulation. (RegulationComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RGLN', @level2type=N'COLUMN',@level2name=N'RGLN_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessRegulationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_RGLN'
GO
/****** Object:  Table [dbo].[CERS_EMIS_UNIT_PROC_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMIS_UNIT_PROC_IDEN](
	[EMIS_UNIT_PROC_IDEN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_EMS_UNT_PRC_IDN] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_PROC_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_ID_EM] ON [dbo].[CERS_EMIS_UNIT_PROC_IDEN] 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMIS_UNIT_PROC_IDEN'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_PL]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_PL](
	[EMS_UNT_PRC_CTR_APC_CTR_PLT_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[POLT_CODE] [varchar](50) NOT NULL,
	[PCNT_CTRL_MEAS_REDC_EFCY] [decimal](4, 1) NULL,
 CONSTRAINT [PK_EM_UN_PR_CT_02] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_PRC_CTR_APC_CTR_PLT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_CT_02] ON [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_PL] 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the pollutant for which emissions are reported. (PollutantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_CTR_APC_CT_PL', @level2type=N'COLUMN',@level2name=N'POLT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent reduction achieved for the pollutant when all control measures are operating as designed. (PercentControlMeasuresReductionEfficiency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_CTR_APC_CT_PL', @level2type=N'COLUMN',@level2name=N'PCNT_CTRL_MEAS_REDC_EFCY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessControlApproachControlPollutantDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_CTR_APC_CT_PL'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_MS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_MS](
	[EMS_UNT_PRC_CTRL_APC_CTR_MS_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_ID] [varchar](40) NOT NULL,
	[CTRL_MEAS_CODE] [varchar](50) NOT NULL,
	[CTRL_MEAS_SEQ] [varchar](255) NULL,
 CONSTRAINT [PK_EM_UN_PR_CT_AP] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_PRC_CTRL_APC_CTR_MS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_CT_AP] ON [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_MS] 
(
	[EMIS_UNIT_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the piece of equipment or practice that is used to reduce one or more pollutants. (ControlMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_CTR_APC_CT_MS', @level2type=N'COLUMN',@level2name=N'CTRL_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The sequnce in which the pollutant stream passes through the various devices in the control group. (ControlMeasureSequence)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_CTR_APC_CT_MS', @level2type=N'COLUMN',@level2name=N'CTRL_MEAS_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessControlApproachControlMeasureDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_CTR_APC_CT_MS'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_INDV]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_INDV](
	[AFFL_ORG_INDV_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_ID] [varchar](40) NOT NULL,
	[INDV_TITLE_TXT] [varchar](255) NULL,
	[NAME_PREFIX_TXT] [varchar](255) NULL,
	[FIRST_NAME] [varchar](128) NULL,
	[MIDDLE_NAME] [varchar](128) NULL,
	[LAST_NAME] [varchar](128) NULL,
	[NAME_SUFFIX_TXT] [varchar](255) NULL,
 CONSTRAINT [PK_AFFL_ORG_INDV] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_IN_AF_OR] ON [dbo].[CERS_AFFL_ORG_INDV] 
(
	[AFFL_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title held by a person in an organization. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV', @level2type=N'COLUMN',@level2name=N'INDV_TITLE_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that precedes an individual''s name. (NamePrefixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV', @level2type=N'COLUMN',@level2name=N'NAME_PREFIX_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The given name of an individual. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV', @level2type=N'COLUMN',@level2name=N'FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The middle name or initial of an individual. (MiddleName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV', @level2type=N'COLUMN',@level2name=N'MIDDLE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The surname of an individual. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV', @level2type=N'COLUMN',@level2name=N'LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'the text that follows an individuals name. (NameSuffixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV', @level2type=N'COLUMN',@level2name=N'NAME_SUFFIX_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationIndividualDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_IDEN](
	[AFFL_ORG_IDEN_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_AFFL_ORG_IDEN] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_ID_AF_OR] ON [dbo].[CERS_AFFL_ORG_IDEN] 
(
	[AFFL_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_IDEN'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_COMMUN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_COMMUN](
	[AFFL_ORG_COMMUN_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_ID] [varchar](40) NOT NULL,
	[TELE_NUM_TXT] [varchar](20) NULL,
	[TELE_NUM_TYPE_NAME] [varchar](128) NULL,
	[TELE_EXT_NUM_TXT] [varchar](20) NULL,
	[ELEC_ADDR_TXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](128) NULL,
 CONSTRAINT [PK_AFFL_ORG_COMMUN] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_COMMUN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_CM_AF_OR] ON [dbo].[CERS_AFFL_ORG_COMMUN] 
(
	[AFFL_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_EXT_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationCommunicationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_COMMUN'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_ADDR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_ADDR](
	[AFFL_ORG_ADDR_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_ID] [varchar](40) NOT NULL,
	[MAIL_ADDR_TXT] [varchar](255) NULL,
	[SUPP_ADDR_TXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CNTY_TXT] [varchar](255) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_POST_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[LOC_ADDR_TXT] [varchar](255) NULL,
	[SUPP_LOC_TXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[LOC_ADDR_STA_CODE] [varchar](50) NULL,
	[LOC_ADDR_POST_CODE] [varchar](50) NULL,
	[LOC_ADDR_CTRY_CODE] [varchar](50) NULL,
	[ADDR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_AFFL_ORG_ADDR] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_AD_AF_OR] ON [dbo].[CERS_AFFL_ORG_ADDR] 
(
	[AFFL_ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city or town. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county. (MailingAddressCountyText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CNTY_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The physical location of a facility site or organization. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, village, or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the address information. (AddressComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR', @level2type=N'COLUMN',@level2name=N'ADDR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_ADDR'
GO
/****** Object:  Table [dbo].[CERS_AFFL_INDV_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_INDV_IDEN](
	[AFFL_INDV_IDEN_ID] [varchar](40) NOT NULL,
	[AFFL_INDV_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_AFFL_INDV_IDEN] PRIMARY KEY CLUSTERED 
(
	[AFFL_INDV_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_IN_ID_AF_IN] ON [dbo].[CERS_AFFL_INDV_IDEN] 
(
	[AFFL_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationIndividualIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_IDEN'
GO
/****** Object:  Table [dbo].[CERS_AFFL_INDV_COMMUN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_INDV_COMMUN](
	[AFFL_INDV_COMMUN_ID] [varchar](40) NOT NULL,
	[AFFL_INDV_ID] [varchar](40) NOT NULL,
	[TELE_NUM_TXT] [varchar](20) NULL,
	[TELE_NUM_TYPE_NAME] [varchar](128) NULL,
	[TELE_EXT_NUM_TXT] [varchar](20) NULL,
	[ELEC_ADDR_TXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](128) NULL,
 CONSTRAINT [PK_AFFL_INDV_CMMN] PRIMARY KEY CLUSTERED 
(
	[AFFL_INDV_COMMUN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_IN_CM_AF_IN] ON [dbo].[CERS_AFFL_INDV_COMMUN] 
(
	[AFFL_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_EXT_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationIndividualCommunicationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_COMMUN'
GO
/****** Object:  Table [dbo].[CERS_AFFL_INDV_ADDR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_INDV_ADDR](
	[AFFL_INDV_ADDR_ID] [varchar](40) NOT NULL,
	[AFFL_INDV_ID] [varchar](40) NOT NULL,
	[MAIL_ADDR_TXT] [varchar](255) NULL,
	[SUPP_ADDR_TXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CNTY_TXT] [varchar](255) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_POST_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[LOC_ADDR_TXT] [varchar](255) NULL,
	[SUPP_LOC_TXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[LOC_ADDR_STA_CODE] [varchar](50) NULL,
	[LOC_ADDR_POST_CODE] [varchar](50) NULL,
	[LOC_ADDR_CTRY_CODE] [varchar](50) NULL,
	[ADDR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_AFFL_INDV_ADDR] PRIMARY KEY CLUSTERED 
(
	[AFFL_INDV_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_IN_AD_AF_IN] ON [dbo].[CERS_AFFL_INDV_ADDR] 
(
	[AFFL_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city or town. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county. (MailingAddressCountyText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CNTY_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The physical location of a facility site or organization. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, village, or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the address information. (AddressComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'ADDR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationIndividualAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_INDV_ADDR'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_INDV_ADDR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_INDV_ADDR](
	[AFFL_ORG_INDV_ADDR_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_INDV_ID] [varchar](40) NOT NULL,
	[MAIL_ADDR_TXT] [varchar](255) NULL,
	[SUPP_ADDR_TXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CNTY_TXT] [varchar](255) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_POST_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[LOC_ADDR_TXT] [varchar](255) NULL,
	[SUPP_LOC_TXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[LOC_ADDR_STA_CODE] [varchar](50) NULL,
	[LOC_ADDR_POST_CODE] [varchar](50) NULL,
	[LOC_ADDR_CTRY_CODE] [varchar](50) NULL,
	[ADDR_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_AFF_ORG_IND_ADD] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_INDV_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_IN_AD_AF] ON [dbo].[CERS_AFFL_ORG_INDV_ADDR] 
(
	[AFFL_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where mail is intended to be delivered, including street address, rural route, and P.O. Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of mail. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city or town. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the county. (MailingAddressCountyText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CNTY_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (MailingAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (MailingAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (MailingAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The physical location of a facility site or organization. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name, or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, village, or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The alphabetic codes that represent the name of the principal administrative subdivision of the United States, Canada, or Mexico. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_STA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a U.S. ZIP code or International postal code. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_POST_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (LocationAddressCountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CTRY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the address information. (AddressComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR', @level2type=N'COLUMN',@level2name=N'ADDR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationIndividualAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_ADDR'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_INDV_IDEN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_INDV_IDEN](
	[AFFL_ORG_INDV_IDEN_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_INDV_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_AFF_ORG_IND_IDN] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_INDV_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_IN_ID_AF] ON [dbo].[CERS_AFFL_ORG_INDV_IDEN] 
(
	[AFFL_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_IDEN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationIndividualIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_IDEN'
GO
/****** Object:  Table [dbo].[CERS_AFFL_ORG_INDV_COMMUN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_AFFL_ORG_INDV_COMMUN](
	[AFFL_ORG_INDV_COMMUN_ID] [varchar](40) NOT NULL,
	[AFFL_ORG_INDV_ID] [varchar](40) NOT NULL,
	[TELE_NUM_TXT] [varchar](20) NULL,
	[TELE_NUM_TYPE_NAME] [varchar](128) NULL,
	[TELE_EXT_NUM_TXT] [varchar](20) NULL,
	[ELEC_ADDR_TXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](128) NULL,
 CONSTRAINT [PK_AFF_ORG_IND_CMM] PRIMARY KEY CLUSTERED 
(
	[AFFL_ORG_INDV_COMMUN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_AF_OR_IN_CM_AF] ON [dbo].[CERS_AFFL_ORG_INDV_COMMUN] 
(
	[AFFL_ORG_INDV_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that identifies a particular telephone connection.  This includes the prefix for international standards. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc. (TelephoneNumberTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'TELE_EXT_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_COMMUN', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: AffiliationOrganizationIndividualCommunicationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_AFFL_ORG_INDV_COMMUN'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PR_RP_PR_SP_CL_PR]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PR_RP_PR_SP_CL_PR](
	[EMS_UNT_PRC_RPT_PR_SP_CL_PR_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[SUPP_CALC_PARM_TYPE] [varchar](255) NULL,
	[SUPP_CALC_PARM_VAL] [varchar](50) NULL,
	[SPP_CLC_PRM_NM_UNT_MS_CDE] [varchar](50) NULL,
	[SPP_CLC_PRM_DN_UNT_MS_CDE] [varchar](50) NULL,
	[SUPP_CALC_PARM_DATA_YEAR] [int] NULL,
	[SUPP_CALC_PARM_DATA_SRC] [varchar](255) NULL,
	[SUPP_CALC_PARM_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EM_UN_PR_RP_02] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_PRC_RPT_PR_SP_CL_PR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RP_03] ON [dbo].[CERS_EMS_UNT_PR_RP_PR_SP_CL_PR] 
(
	[EMIS_UNIT_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the parameter that describes the type of activity, throughput or input used in the calculation. (SupplementalCalculationParameterType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The value of the parameter. (SupplementalCalculationParameterValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_VAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerator unit of measure for the parameter. (SupplementalCalculationParameterNumeratorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SPP_CLC_PRM_NM_UNT_MS_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The denominator unit of measure for the parameter. (SupplementalCalculationParameterDenominatorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SPP_CLC_PRM_DN_UNT_MS_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year represented by the supplemental data if it is different from the emissions year. (SupplementalCalculationParameterDataYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_DATA_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of the supplemental parameter data used. (SupplementalCalculationParameterDataSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_DATA_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the parameter. (SupplementalCalculationParameterComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR', @level2type=N'COLUMN',@level2name=N'SUPP_CALC_PARM_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessReportingPeriodSupplementalCalculationParameterDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PR_RP_PR_SP_CL_PR'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_QL_ID]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_QL_ID](
	[EMS_UNT_PRC_RPT_PRD_QLT_IDN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[QLTY_IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EM_UN_PR_RP_PR] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_PRC_RPT_PRD_QLT_IDN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RP_02] ON [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_QL_ID] 
(
	[EMIS_UNIT_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier for the quality finding. (QualityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_QL_ID', @level2type=N'COLUMN',@level2name=N'QLTY_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_QL_ID', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessReportingPeriodQualityIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_QL_ID'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_EMS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_EMS](
	[EMIS_UNIT_PROC_RPT_PRD_EMIS_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_RPT_PRD_ID] [varchar](40) NOT NULL,
	[POLT_CODE] [varchar](50) NOT NULL,
	[TOTAL_EMIS] [varchar](255) NOT NULL,
	[EMIS_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC] [varchar](255) NULL,
	[EMIS_FAC_NUM_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC_DEN_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC_FORM_CODE] [varchar](50) NULL,
	[EMIS_FAC_TXT] [varchar](255) NULL,
	[EMIS_CALC_METH_CODE] [varchar](50) NULL,
	[EMIS_FAC_REF_TXT] [varchar](255) NULL,
	[ALGOR_FORM_TXT] [varchar](255) NULL,
	[ALGOR_CMNT] [varchar](255) NULL,
	[CALC_METH_ACC_ASMT_CODE] [varchar](50) NULL,
	[EMIS_DE_MINIMIS_STAT] [varchar](255) NULL,
	[EMIS_CMNT] [varchar](255) NULL,
	[CO_2E] [varchar](255) NULL,
	[CO_2E_UNT_MEAS_CODE] [varchar](50) NULL,
	[CO_2_CONV_FAC] [varchar](255) NULL,
	[CO_2_CONV_FAC_SRC] [varchar](255) NULL,
 CONSTRAINT [PK_EM_UN_PR_RP_03] PRIMARY KEY CLUSTERED 
(
	[EMIS_UNIT_PROC_RPT_PRD_EMIS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RP_04] ON [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_EMS] 
(
	[EMIS_UNIT_PROC_RPT_PRD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the pollutant for which emissions are reported. (PollutantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'POLT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total calculated or estimated amount of the pollutant. (TotalEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'TOTAL_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unit of measure for reported emissions. (EmissionsUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The emission factor used for the emissions value if a calculated value was provided. (EmissionFactor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerator for the unit of measure of the reported emission factor. (EmissionFactorNumeratorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_NUM_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The denominator for the unit of measure of the reported emission factor. (EmissionFactorDenominatorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_DEN_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the emission factor formula used to calculate emissions. (EmissionFactorFormulaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_FORM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Explanation for emission factor. (EmissionFactorText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that defines the method used to calculate emissions. (EmissionCalculationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_CALC_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference given for the emission factor used in the calculation. (EmissionFactorReferenceText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_REF_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formula used to calculate emissions. (AlgorithmFormulaText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'ALGOR_FORM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the algorithm, including units of measure, for the calculation method. (AlgorithmComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'ALGOR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C, CARB, Part 75, etc.  (CalculationMethodAccuracyAssessmentCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'CALC_METH_ACC_ASMT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status indicating if emissions are de minimis. (EmissionsDeMinimisStatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_DE_MINIMIS_STAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the emissions, method of calculation, or emission factor. (EmissionsComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'EMIS_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total CO2 equivalent emissions. (CO2e)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'CO_2E'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure for the CO2 equivalent emissions. (CO2eUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'CO_2E_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Global warming potential (GWP) used to calculate CO2e. (CO2ConversionFactor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'CO_2_CONV_FAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of reference for the GWP value. (CO2ConversionFactorSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS', @level2type=N'COLUMN',@level2name=N'CO_2_CONV_FAC_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessReportingPeriodEmissionsDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RPT_PRD_EMS'
GO
/****** Object:  Table [dbo].[CERS_EVENT_EMIS_EMIS]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EVENT_EMIS_EMIS](
	[EVENT_EMIS_EMIS_ID] [varchar](40) NOT NULL,
	[EVENT_EMIS_PROC_ID] [varchar](40) NOT NULL,
	[POLT_CODE] [varchar](50) NOT NULL,
	[TOTAL_EMIS] [varchar](255) NOT NULL,
	[EMIS_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC] [varchar](255) NULL,
	[EMIS_FAC_NUM_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC_DEN_UNT_MEAS_CODE] [varchar](50) NULL,
	[EMIS_FAC_FORM_CODE] [varchar](50) NULL,
	[EMIS_FAC_TXT] [varchar](255) NULL,
	[EMIS_CALC_METH_CODE] [varchar](50) NULL,
	[EMIS_FAC_REF_TXT] [varchar](255) NULL,
	[ALGOR_FORM_TXT] [varchar](255) NULL,
	[ALGOR_CMNT] [varchar](255) NULL,
	[CALC_METH_ACC_ASMT_CODE] [varchar](50) NULL,
	[EMIS_DE_MINIMIS_STAT] [varchar](255) NULL,
	[EMIS_CMNT] [varchar](255) NULL,
	[CO_2E] [varchar](255) NULL,
	[CO_2E_UNT_MEAS_CODE] [varchar](50) NULL,
	[CO_2_CONV_FAC] [varchar](255) NULL,
	[CO_2_CONV_FAC_SRC] [varchar](255) NULL,
 CONSTRAINT [PK_EVENT_EMIS_EMIS] PRIMARY KEY CLUSTERED 
(
	[EVENT_EMIS_EMIS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EV_EM_EM_EV_EM] ON [dbo].[CERS_EVENT_EMIS_EMIS] 
(
	[EVENT_EMIS_PROC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code identifying the pollutant for which emissions are reported. (PollutantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'POLT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total calculated or estimated amount of the pollutant. (TotalEmissions)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'TOTAL_EMIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unit of measure for reported emissions. (EmissionsUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The emission factor used for the emissions value if a calculated value was provided. (EmissionFactor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The numerator for the unit of measure of the reported emission factor. (EmissionFactorNumeratorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_NUM_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The denominator for the unit of measure of the reported emission factor. (EmissionFactorDenominatorUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_DEN_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that identifies the emission factor formula used to calculate emissions. (EmissionFactorFormulaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_FORM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Explanation for emission factor. (EmissionFactorText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that defines the method used to calculate emissions. (EmissionCalculationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_CALC_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reference given for the emission factor used in the calculation. (EmissionFactorReferenceText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_FAC_REF_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The formula used to calculate emissions. (AlgorithmFormulaText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'ALGOR_FORM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information about the algorithm, including units of measure, for the calculation method. (AlgorithmComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'ALGOR_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C, CARB, Part 75, etc.  (CalculationMethodAccuracyAssessmentCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'CALC_METH_ACC_ASMT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status indicating if emissions are de minimis. (EmissionsDeMinimisStatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_DE_MINIMIS_STAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the emissions, method of calculation, or emission factor. (EmissionsComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'EMIS_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total CO2 equivalent emissions. (CO2e)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2E'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure for the CO2 equivalent emissions. (CO2eUnitofMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2E_UNT_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Global warming potential (GWP) used to calculate CO2e. (CO2ConversionFactor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2_CONV_FAC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of reference for the GWP value. (CO2ConversionFactorSource)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS', @level2type=N'COLUMN',@level2name=N'CO_2_CONV_FAC_SRC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EventEmissionsEmissionsDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EVENT_EMIS_EMIS'
GO
/****** Object:  Table [dbo].[CERS_EMS_UNT_PRC_RL_PT_APP_IDN]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EMS_UNT_PRC_RL_PT_APP_IDN](
	[EMS_UNT_PRC_RL_PT_APPR_IDN_ID] [varchar](40) NOT NULL,
	[EMIS_UNIT_PROC_REL_PT_APPR_ID] [varchar](40) NOT NULL,
	[IDEN] [varchar](50) NOT NULL,
	[PROG_SYS_CODE] [varchar](50) NOT NULL,
	[EFFC_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_EM_UN_PR_RL_02] PRIMARY KEY CLUSTERED 
(
	[EMS_UNT_PRC_RL_PT_APPR_IDN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EM_UN_PR_RL_02] ON [dbo].[CERS_EMS_UNT_PRC_RL_PT_APP_IDN] 
(
	[EMIS_UNIT_PROC_REL_PT_APPR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An identifier by which an element is referred to in another system. (Identifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APP_IDN', @level2type=N'COLUMN',@level2name=N'IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the information management system which has responsibility for the data in a linked or interrelated information management system.   (ProgramSystemCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APP_IDN', @level2type=N'COLUMN',@level2name=N'PROG_SYS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier became effective. (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APP_IDN', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the identifier is no longer applicable. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APP_IDN', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EmissionsUnitProcessReleasePointApportionmentIdentificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EMS_UNT_PRC_RL_PT_APP_IDN'
GO
/****** Object:  Table [dbo].[CERS_EXCL_LOC_PARM]    Script Date: 11/04/2009 11:47:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CERS_EXCL_LOC_PARM](
	[EXCL_LOC_PARM_ID] [varchar](40) NOT NULL,
	[LOC_ID] [varchar](40) NOT NULL,
	[LOC_TYPE_CODE] [varchar](50) NOT NULL,
	[LOC_PARM] [varchar](255) NOT NULL,
	[LOC_CMNT] [varchar](255) NULL,
 CONSTRAINT [PK_EXCL_LOC_PARM] PRIMARY KEY CLUSTERED 
(
	[EXCL_LOC_PARM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_EXC_LC_PR_LC_ID] ON [dbo].[CERS_EXCL_LOC_PARM] 
(
	[LOC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the type of code or identifier that is being excluded. (LocationTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EXCL_LOC_PARM', @level2type=N'COLUMN',@level2name=N'LOC_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code value or the identifier for the location type code. (LocationParameter)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EXCL_LOC_PARM', @level2type=N'COLUMN',@level2name=N'LOC_PARM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments regarding the location. (LocationComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EXCL_LOC_PARM', @level2type=N'COLUMN',@level2name=N'LOC_CMNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ExcludedLocationParameterDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CERS_EXCL_LOC_PARM'
GO
/****** Object:  ForeignKey [FK_EVENT_CERS]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_EVENT_CERS] FOREIGN KEY([CERS_ID])
REFERENCES [dbo].[CERS_CERS] ([CERS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EVENT] CHECK CONSTRAINT [FK_EVENT_CERS]
GO
/****** Object:  ForeignKey [FK_EVN_RPT_PRD_EVN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EVENT_RPT_PRD]  WITH CHECK ADD  CONSTRAINT [FK_EVN_RPT_PRD_EVN] FOREIGN KEY([EVENT_ID])
REFERENCES [dbo].[CERS_EVENT] ([EVENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EVENT_RPT_PRD] CHECK CONSTRAINT [FK_EVN_RPT_PRD_EVN]
GO
/****** Object:  ForeignKey [FK_MRGD_EVNTS_EVNT]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_MERGED_EVENTS]  WITH CHECK ADD  CONSTRAINT [FK_MRGD_EVNTS_EVNT] FOREIGN KEY([EVENT_ID])
REFERENCES [dbo].[CERS_EVENT] ([EVENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_MERGED_EVENTS] CHECK CONSTRAINT [FK_MRGD_EVNTS_EVNT]
GO
/****** Object:  ForeignKey [FK_FAC_SITE_CERS]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_FAC_SITE]  WITH CHECK ADD  CONSTRAINT [FK_FAC_SITE_CERS] FOREIGN KEY([CERS_ID])
REFERENCES [dbo].[CERS_CERS] ([CERS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_FAC_SITE] CHECK CONSTRAINT [FK_FAC_SITE_CERS]
GO
/****** Object:  ForeignKey [FK_REL_PT_FAC_SITE]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_REL_PT]  WITH CHECK ADD  CONSTRAINT [FK_REL_PT_FAC_SITE] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_REL_PT] CHECK CONSTRAINT [FK_REL_PT_FAC_SITE]
GO
/****** Object:  ForeignKey [FK_FC_ST_QL_ID_FC]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_FAC_SITE_QLTY_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_FC_ST_QL_ID_FC] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_FAC_SITE_QLTY_IDEN] CHECK CONSTRAINT [FK_FC_ST_QL_ID_FC]
GO
/****** Object:  ForeignKey [FK_FC_STE_AD_FC_ST]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_FAC_SITE_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_FC_STE_AD_FC_ST] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_FAC_SITE_ADDR] CHECK CONSTRAINT [FK_FC_STE_AD_FC_ST]
GO
/****** Object:  ForeignKey [FK_ALT_FC_NM_FC_ST]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_ALT_FAC_NAME]  WITH CHECK ADD  CONSTRAINT [FK_ALT_FC_NM_FC_ST] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_ALT_FAC_NAME] CHECK CONSTRAINT [FK_ALT_FC_NM_FC_ST]
GO
/****** Object:  ForeignKey [FK_EMS_UNT_FC_STE]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT]  WITH CHECK ADD  CONSTRAINT [FK_EMS_UNT_FC_STE] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT] CHECK CONSTRAINT [FK_EMS_UNT_FC_STE]
GO
/****** Object:  ForeignKey [FK_AFFL_FAC_SITE]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL]  WITH CHECK ADD  CONSTRAINT [FK_AFFL_FAC_SITE] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL] CHECK CONSTRAINT [FK_AFFL_FAC_SITE]
GO
/****** Object:  ForeignKey [FK_FC_NCS_FC_STE]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_FAC_NAICS]  WITH CHECK ADD  CONSTRAINT [FK_FC_NCS_FC_STE] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_FAC_NAICS] CHECK CONSTRAINT [FK_FC_NCS_FC_STE]
GO
/****** Object:  ForeignKey [FK_FC_IDN_FC_STE]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_FAC_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_FC_IDN_FC_STE] FOREIGN KEY([FAC_SITE_ID])
REFERENCES [dbo].[CERS_FAC_SITE] ([FAC_SITE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_FAC_IDEN] CHECK CONSTRAINT [FK_FC_IDN_FC_STE]
GO
/****** Object:  ForeignKey [FK_EM_UN_CT_AP_CT]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_CTRL_APCH_CTRL_MS]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_CT_AP_CT] FOREIGN KEY([EMIS_UNIT_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT] ([EMIS_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_CTRL_APCH_CTRL_MS] CHECK CONSTRAINT [FK_EM_UN_CT_AP_CT]
GO
/****** Object:  ForeignKey [FK_EM_UN_CT_AP_02]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_CTRL_APCH_CTR_PLT]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_CT_AP_02] FOREIGN KEY([EMIS_UNIT_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT] ([EMIS_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_CTRL_APCH_CTR_PLT] CHECK CONSTRAINT [FK_EM_UN_CT_AP_02]
GO
/****** Object:  ForeignKey [FK_EMS_UN_RG_EM_UN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_RGLN]  WITH CHECK ADD  CONSTRAINT [FK_EMS_UN_RG_EM_UN] FOREIGN KEY([EMIS_UNIT_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT] ([EMIS_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_RGLN] CHECK CONSTRAINT [FK_EMS_UN_RG_EM_UN]
GO
/****** Object:  ForeignKey [FK_EM_UN_QL_ID_EM]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_QLTY_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_QL_ID_EM] FOREIGN KEY([EMIS_UNIT_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT] ([EMIS_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_QLTY_IDEN] CHECK CONSTRAINT [FK_EM_UN_QL_ID_EM]
GO
/****** Object:  ForeignKey [FK_EMS_UN_PR_EM_UN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC]  WITH CHECK ADD  CONSTRAINT [FK_EMS_UN_PR_EM_UN] FOREIGN KEY([EMIS_UNIT_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT] ([EMIS_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC] CHECK CONSTRAINT [FK_EMS_UN_PR_EM_UN]
GO
/****** Object:  ForeignKey [FK_EMS_UN_ID_EM_UN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_EMS_UN_ID_EM_UN] FOREIGN KEY([EMIS_UNIT_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT] ([EMIS_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_IDEN] CHECK CONSTRAINT [FK_EMS_UN_ID_EM_UN]
GO
/****** Object:  ForeignKey [FK_AFFL_ORG_AFFL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG]  WITH CHECK ADD  CONSTRAINT [FK_AFFL_ORG_AFFL] FOREIGN KEY([AFFL_ID])
REFERENCES [dbo].[CERS_AFFL] ([AFFL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG] CHECK CONSTRAINT [FK_AFFL_ORG_AFFL]
GO
/****** Object:  ForeignKey [FK_AFFL_INDV_AFFL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_INDV]  WITH CHECK ADD  CONSTRAINT [FK_AFFL_INDV_AFFL] FOREIGN KEY([AFFL_ID])
REFERENCES [dbo].[CERS_AFFL] ([AFFL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_INDV] CHECK CONSTRAINT [FK_AFFL_INDV_AFFL]
GO
/****** Object:  ForeignKey [FK_EVN_LC_EV_RP_PR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EVENT_LOC]  WITH CHECK ADD  CONSTRAINT [FK_EVN_LC_EV_RP_PR] FOREIGN KEY([EVENT_RPT_PRD_ID])
REFERENCES [dbo].[CERS_EVENT_RPT_PRD] ([EVENT_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EVENT_LOC] CHECK CONSTRAINT [FK_EVN_LC_EV_RP_PR]
GO
/****** Object:  ForeignKey [FK_RL_PT_TST_RL_PT]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_REL_PT_TST]  WITH CHECK ADD  CONSTRAINT [FK_RL_PT_TST_RL_PT] FOREIGN KEY([REL_PT_ID])
REFERENCES [dbo].[CERS_REL_PT] ([REL_PT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_REL_PT_TST] CHECK CONSTRAINT [FK_RL_PT_TST_RL_PT]
GO
/****** Object:  ForeignKey [FK_RL_PT_IDN_RL_PT]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_REL_PT_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_RL_PT_IDN_RL_PT] FOREIGN KEY([REL_PT_ID])
REFERENCES [dbo].[CERS_REL_PT] ([REL_PT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_REL_PT_IDEN] CHECK CONSTRAINT [FK_RL_PT_IDN_RL_PT]
GO
/****** Object:  ForeignKey [FK_LOC_CERS]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC]  WITH CHECK ADD  CONSTRAINT [FK_LOC_CERS] FOREIGN KEY([CERS_ID])
REFERENCES [dbo].[CERS_CERS] ([CERS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC] CHECK CONSTRAINT [FK_LOC_CERS]
GO
/****** Object:  ForeignKey [FK_LOC_PROC_LOC]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC]  WITH CHECK ADD  CONSTRAINT [FK_LOC_PROC_LOC] FOREIGN KEY([LOC_ID])
REFERENCES [dbo].[CERS_LOC] ([LOC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC] CHECK CONSTRAINT [FK_LOC_PROC_LOC]
GO
/****** Object:  ForeignKey [FK_LC_PR_RL_PT_AP]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC_REL_PT_APPR]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_RL_PT_AP] FOREIGN KEY([LOC_PROC_ID])
REFERENCES [dbo].[CERS_LOC_PROC] ([LOC_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC_REL_PT_APPR] CHECK CONSTRAINT [FK_LC_PR_RL_PT_AP]
GO
/****** Object:  ForeignKey [FK_LC_PRC_ID_LC_PR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_LC_PRC_ID_LC_PR] FOREIGN KEY([LOC_PROC_ID])
REFERENCES [dbo].[CERS_LOC_PROC] ([LOC_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC_IDEN] CHECK CONSTRAINT [FK_LC_PRC_ID_LC_PR]
GO
/****** Object:  ForeignKey [FK_LC_PR_CT_AP_02]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_PLT]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_CT_AP_02] FOREIGN KEY([LOC_PROC_ID])
REFERENCES [dbo].[CERS_LOC_PROC] ([LOC_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_PLT] CHECK CONSTRAINT [FK_LC_PR_CT_AP_02]
GO
/****** Object:  ForeignKey [FK_LC_PR_CT_AP_CT]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_MS]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_CT_AP_CT] FOREIGN KEY([LOC_PROC_ID])
REFERENCES [dbo].[CERS_LOC_PROC] ([LOC_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LC_PRC_CTRL_APCH_CTRL_MS] CHECK CONSTRAINT [FK_LC_PR_CT_AP_CT]
GO
/****** Object:  ForeignKey [FK_LC_PR_RP_PR_LC]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC_RPT_PRD]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_RP_PR_LC] FOREIGN KEY([LOC_PROC_ID])
REFERENCES [dbo].[CERS_LOC_PROC] ([LOC_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC_RPT_PRD] CHECK CONSTRAINT [FK_LC_PR_RP_PR_LC]
GO
/****** Object:  ForeignKey [FK_LC_PRC_RG_LC_PR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC_RGLN]  WITH CHECK ADD  CONSTRAINT [FK_LC_PRC_RG_LC_PR] FOREIGN KEY([LOC_PROC_ID])
REFERENCES [dbo].[CERS_LOC_PROC] ([LOC_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC_RGLN] CHECK CONSTRAINT [FK_LC_PRC_RG_LC_PR]
GO
/****** Object:  ForeignKey [FK_QLTY_FIND_CERS]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND]  WITH CHECK ADD  CONSTRAINT [FK_QLTY_FIND_CERS] FOREIGN KEY([CERS_ID])
REFERENCES [dbo].[CERS_CERS] ([CERS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND] CHECK CONSTRAINT [FK_QLTY_FIND_CERS]
GO
/****** Object:  ForeignKey [FK_QLT_FN_OR_QL_FN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG]  WITH CHECK ADD  CONSTRAINT [FK_QLT_FN_OR_QL_FN] FOREIGN KEY([QLTY_FIND_ID])
REFERENCES [dbo].[CERS_QLTY_FIND] ([QLTY_FIND_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG] CHECK CONSTRAINT [FK_QLT_FN_OR_QL_FN]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_IN_QL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_IN_QL] FOREIGN KEY([QLTY_FIND_ORG_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG] ([QLTY_FIND_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV] CHECK CONSTRAINT [FK_QL_FN_OR_IN_QL]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_ID_QL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_ID_QL] FOREIGN KEY([QLTY_FIND_ORG_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG] ([QLTY_FIND_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_IDEN] CHECK CONSTRAINT [FK_QL_FN_OR_ID_QL]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_CM_QL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_COMMUN]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_CM_QL] FOREIGN KEY([QLTY_FIND_ORG_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG] ([QLTY_FIND_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_COMMUN] CHECK CONSTRAINT [FK_QL_FN_OR_CM_QL]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_AD_QL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_AD_QL] FOREIGN KEY([QLTY_FIND_ORG_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG] ([QLTY_FIND_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_ADDR] CHECK CONSTRAINT [FK_QL_FN_OR_AD_QL]
GO
/****** Object:  ForeignKey [FK_LC_PR_RL_PT_02]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC_REL_PT_APPR_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_RL_PT_02] FOREIGN KEY([LOC_PROC_REL_PT_APPR_ID])
REFERENCES [dbo].[CERS_LOC_PROC_REL_PT_APPR] ([LOC_PROC_REL_PT_APPR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC_REL_PT_APPR_IDEN] CHECK CONSTRAINT [FK_LC_PR_RL_PT_02]
GO
/****** Object:  ForeignKey [FK_LC_PR_RP_PR_EM]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LOC_PROC_RPT_PRD_EMIS]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_RP_PR_EM] FOREIGN KEY([LOC_PROC_RPT_PRD_ID])
REFERENCES [dbo].[CERS_LOC_PROC_RPT_PRD] ([LOC_PROC_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LOC_PROC_RPT_PRD_EMIS] CHECK CONSTRAINT [FK_LC_PR_RP_PR_EM]
GO
/****** Object:  ForeignKey [FK_LC_PR_RP_PR_SP]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LC_PRC_RPT_PRD_SPP_CLC_PR]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_RP_PR_SP] FOREIGN KEY([LOC_PROC_RPT_PRD_ID])
REFERENCES [dbo].[CERS_LOC_PROC_RPT_PRD] ([LOC_PROC_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LC_PRC_RPT_PRD_SPP_CLC_PR] CHECK CONSTRAINT [FK_LC_PR_RP_PR_SP]
GO
/****** Object:  ForeignKey [FK_LC_PR_RP_PR_QL]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_LC_PRC_RPT_PRD_QLTY_IDN]  WITH CHECK ADD  CONSTRAINT [FK_LC_PR_RP_PR_QL] FOREIGN KEY([LOC_PROC_RPT_PRD_ID])
REFERENCES [dbo].[CERS_LOC_PROC_RPT_PRD] ([LOC_PROC_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_LC_PRC_RPT_PRD_QLTY_IDN] CHECK CONSTRAINT [FK_LC_PR_RP_PR_QL]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_IN_ID]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_IN_ID] FOREIGN KEY([QLTY_FIND_ORG_INDV_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG_INDV] ([QLTY_FIND_ORG_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_IDEN] CHECK CONSTRAINT [FK_QL_FN_OR_IN_ID]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_IN_CM]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_COMMUN]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_IN_CM] FOREIGN KEY([QLTY_FIND_ORG_INDV_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG_INDV] ([QLTY_FIND_ORG_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_COMMUN] CHECK CONSTRAINT [FK_QL_FN_OR_IN_CM]
GO
/****** Object:  ForeignKey [FK_QL_FN_OR_IN_AD]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_QL_FN_OR_IN_AD] FOREIGN KEY([QLTY_FIND_ORG_INDV_ID])
REFERENCES [dbo].[CERS_QLTY_FIND_ORG_INDV] ([QLTY_FIND_ORG_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_QLTY_FIND_ORG_INDV_ADDR] CHECK CONSTRAINT [FK_QL_FN_OR_IN_AD]
GO
/****** Object:  ForeignKey [FK_EVN_EM_PR_EV_LC]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EVENT_EMIS_PROC]  WITH CHECK ADD  CONSTRAINT [FK_EVN_EM_PR_EV_LC] FOREIGN KEY([EVENT_LOC_ID])
REFERENCES [dbo].[CERS_EVENT_LOC] ([EVENT_LOC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EVENT_EMIS_PROC] CHECK CONSTRAINT [FK_EVN_EM_PR_EV_LC]
GO
/****** Object:  ForeignKey [FK_GSPT_PRM_EVN_LC]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_GEOSPATIAL_PARAMS]  WITH CHECK ADD  CONSTRAINT [FK_GSPT_PRM_EVN_LC] FOREIGN KEY([EVENT_LOC_ID])
REFERENCES [dbo].[CERS_EVENT_LOC] ([EVENT_LOC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_GEOSPATIAL_PARAMS] CHECK CONSTRAINT [FK_GSPT_PRM_EVN_LC]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RL_PT]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RL_PT_APPR]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RL_PT] FOREIGN KEY([EMIS_UNIT_PROC_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC] ([EMIS_UNIT_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RL_PT_APPR] CHECK CONSTRAINT [FK_EM_UN_PR_RL_PT]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RP_PR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RP_PR] FOREIGN KEY([EMIS_UNIT_PROC_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC] ([EMIS_UNIT_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD] CHECK CONSTRAINT [FK_EM_UN_PR_RP_PR]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RG_EM]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC_RGLN]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RG_EM] FOREIGN KEY([EMIS_UNIT_PROC_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC] ([EMIS_UNIT_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC_RGLN] CHECK CONSTRAINT [FK_EM_UN_PR_RG_EM]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_ID_EM]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_ID_EM] FOREIGN KEY([EMIS_UNIT_PROC_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC] ([EMIS_UNIT_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMIS_UNIT_PROC_IDEN] CHECK CONSTRAINT [FK_EM_UN_PR_ID_EM]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_CT_02]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_PL]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_CT_02] FOREIGN KEY([EMIS_UNIT_PROC_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC] ([EMIS_UNIT_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_PL] CHECK CONSTRAINT [FK_EM_UN_PR_CT_02]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_CT_AP]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_MS]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_CT_AP] FOREIGN KEY([EMIS_UNIT_PROC_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC] ([EMIS_UNIT_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_CTR_APC_CT_MS] CHECK CONSTRAINT [FK_EM_UN_PR_CT_AP]
GO
/****** Object:  ForeignKey [FK_AFF_OR_IN_AF_OR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV]  WITH CHECK ADD  CONSTRAINT [FK_AFF_OR_IN_AF_OR] FOREIGN KEY([AFFL_ORG_ID])
REFERENCES [dbo].[CERS_AFFL_ORG] ([AFFL_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV] CHECK CONSTRAINT [FK_AFF_OR_IN_AF_OR]
GO
/****** Object:  ForeignKey [FK_AFF_OR_ID_AF_OR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_AFF_OR_ID_AF_OR] FOREIGN KEY([AFFL_ORG_ID])
REFERENCES [dbo].[CERS_AFFL_ORG] ([AFFL_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_IDEN] CHECK CONSTRAINT [FK_AFF_OR_ID_AF_OR]
GO
/****** Object:  ForeignKey [FK_AFF_OR_CM_AF_OR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_COMMUN]  WITH CHECK ADD  CONSTRAINT [FK_AFF_OR_CM_AF_OR] FOREIGN KEY([AFFL_ORG_ID])
REFERENCES [dbo].[CERS_AFFL_ORG] ([AFFL_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_COMMUN] CHECK CONSTRAINT [FK_AFF_OR_CM_AF_OR]
GO
/****** Object:  ForeignKey [FK_AFF_OR_AD_AF_OR]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_AFF_OR_AD_AF_OR] FOREIGN KEY([AFFL_ORG_ID])
REFERENCES [dbo].[CERS_AFFL_ORG] ([AFFL_ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_ADDR] CHECK CONSTRAINT [FK_AFF_OR_AD_AF_OR]
GO
/****** Object:  ForeignKey [FK_AFF_IN_ID_AF_IN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_INDV_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_AFF_IN_ID_AF_IN] FOREIGN KEY([AFFL_INDV_ID])
REFERENCES [dbo].[CERS_AFFL_INDV] ([AFFL_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_INDV_IDEN] CHECK CONSTRAINT [FK_AFF_IN_ID_AF_IN]
GO
/****** Object:  ForeignKey [FK_AFF_IN_CM_AF_IN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_INDV_COMMUN]  WITH CHECK ADD  CONSTRAINT [FK_AFF_IN_CM_AF_IN] FOREIGN KEY([AFFL_INDV_ID])
REFERENCES [dbo].[CERS_AFFL_INDV] ([AFFL_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_INDV_COMMUN] CHECK CONSTRAINT [FK_AFF_IN_CM_AF_IN]
GO
/****** Object:  ForeignKey [FK_AFF_IN_AD_AF_IN]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_INDV_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_AFF_IN_AD_AF_IN] FOREIGN KEY([AFFL_INDV_ID])
REFERENCES [dbo].[CERS_AFFL_INDV] ([AFFL_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_INDV_ADDR] CHECK CONSTRAINT [FK_AFF_IN_AD_AF_IN]
GO
/****** Object:  ForeignKey [FK_AF_OR_IN_AD_AF]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_AF_OR_IN_AD_AF] FOREIGN KEY([AFFL_ORG_INDV_ID])
REFERENCES [dbo].[CERS_AFFL_ORG_INDV] ([AFFL_ORG_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV_ADDR] CHECK CONSTRAINT [FK_AF_OR_IN_AD_AF]
GO
/****** Object:  ForeignKey [FK_AF_OR_IN_ID_AF]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_AF_OR_IN_ID_AF] FOREIGN KEY([AFFL_ORG_INDV_ID])
REFERENCES [dbo].[CERS_AFFL_ORG_INDV] ([AFFL_ORG_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV_IDEN] CHECK CONSTRAINT [FK_AF_OR_IN_ID_AF]
GO
/****** Object:  ForeignKey [FK_AF_OR_IN_CM_AF]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV_COMMUN]  WITH CHECK ADD  CONSTRAINT [FK_AF_OR_IN_CM_AF] FOREIGN KEY([AFFL_ORG_INDV_ID])
REFERENCES [dbo].[CERS_AFFL_ORG_INDV] ([AFFL_ORG_INDV_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_AFFL_ORG_INDV_COMMUN] CHECK CONSTRAINT [FK_AF_OR_IN_CM_AF]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RP_03]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PR_RP_PR_SP_CL_PR]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RP_03] FOREIGN KEY([EMIS_UNIT_PROC_RPT_PRD_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD] ([EMIS_UNIT_PROC_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PR_RP_PR_SP_CL_PR] CHECK CONSTRAINT [FK_EM_UN_PR_RP_03]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RP_02]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_QL_ID]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RP_02] FOREIGN KEY([EMIS_UNIT_PROC_RPT_PRD_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD] ([EMIS_UNIT_PROC_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_QL_ID] CHECK CONSTRAINT [FK_EM_UN_PR_RP_02]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RP_04]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_EMS]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RP_04] FOREIGN KEY([EMIS_UNIT_PROC_RPT_PRD_ID])
REFERENCES [dbo].[CERS_EMIS_UNIT_PROC_RPT_PRD] ([EMIS_UNIT_PROC_RPT_PRD_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RPT_PRD_EMS] CHECK CONSTRAINT [FK_EM_UN_PR_RP_04]
GO
/****** Object:  ForeignKey [FK_EV_EM_EM_EV_EM]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EVENT_EMIS_EMIS]  WITH CHECK ADD  CONSTRAINT [FK_EV_EM_EM_EV_EM] FOREIGN KEY([EVENT_EMIS_PROC_ID])
REFERENCES [dbo].[CERS_EVENT_EMIS_PROC] ([EVENT_EMIS_PROC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EVENT_EMIS_EMIS] CHECK CONSTRAINT [FK_EV_EM_EM_EV_EM]
GO
/****** Object:  ForeignKey [FK_EM_UN_PR_RL_02]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RL_PT_APP_IDN]  WITH CHECK ADD  CONSTRAINT [FK_EM_UN_PR_RL_02] FOREIGN KEY([EMIS_UNIT_PROC_REL_PT_APPR_ID])
REFERENCES [dbo].[CERS_EMS_UNT_PRC_RL_PT_APPR] ([EMIS_UNIT_PROC_REL_PT_APPR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EMS_UNT_PRC_RL_PT_APP_IDN] CHECK CONSTRAINT [FK_EM_UN_PR_RL_02]
GO
/****** Object:  ForeignKey [FK_EXCL_LC_PRM_LC]    Script Date: 11/04/2009 11:47:53 ******/
ALTER TABLE [dbo].[CERS_EXCL_LOC_PARM]  WITH CHECK ADD  CONSTRAINT [FK_EXCL_LC_PRM_LC] FOREIGN KEY([LOC_ID])
REFERENCES [dbo].[CERS_LOC] ([LOC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CERS_EXCL_LOC_PARM] CHECK CONSTRAINT [FK_EXCL_LC_PRM_LC]
GO
