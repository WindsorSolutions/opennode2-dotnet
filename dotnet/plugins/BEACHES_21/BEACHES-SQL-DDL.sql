/****** Object:  Table [dbo].[NOTIF_YEARCOMPLETION]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_YEARCOMPLETION](
	[ID] [varchar](40) NOT NULL,
	[COMPLETIONYEAR] [varchar](4) NOT NULL,
	[NOTIFICATIONDATACOMPLETIONIND] [varchar](5) NULL,
	[MONITORINGDATACOMPLETIONIND] [varchar](5) NULL,
	[LOCATIONDATACOMPLETIONIND] [varchar](5) NULL,
 CONSTRAINT [PK_NOT_YR_COM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year the status indicators are for. (CompletionYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_YEARCOMPLETION', @level2type=N'COLUMN',@level2name=N'COMPLETIONYEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if all Notification Data has been submitted for the year.  False in any other case (NotificiationDataCompleteIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_YEARCOMPLETION', @level2type=N'COLUMN',@level2name=N'NOTIFICATIONDATACOMPLETIONIND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if all Monitoring Data has been submitted for the year.  False in any other case (MonitoringDataCompleteIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_YEARCOMPLETION', @level2type=N'COLUMN',@level2name=N'MONITORINGDATACOMPLETIONIND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if all Location Data has been submitted for the year.  False in any other case (LocationDataCompleteIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_YEARCOMPLETION', @level2type=N'COLUMN',@level2name=N'LOCATIONDATACOMPLETIONIND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: YearCompletionIndicatorDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_YEARCOMPLETION'
GO
/****** Object:  Table [dbo].[NOTIF_BEACH]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_BEACH](
	[ID] [varchar](40) NOT NULL,
	[BEACHIDENTIFIER] [varchar](8) NOT NULL,
	[BEACHNAME] [varchar](60) NULL,
	[BEACHDESCRIPTION] [varchar](255) NULL,
	[BEACHCOMMENT] [varchar](255) NULL,
	[BEACHSTATECODE] [char](2) NULL,
	[BEACHFIPSCOUNTYCODE] [varchar](5) NULL,
	[WATERBODYNAMECODE] [varchar](25) NULL,
	[WATERBODYTYPECODE] [varchar](25) NULL,
	[BEACHACCESSTYPE] [varchar](12) NULL,
	[BEACHACCESSCOMMENT] [varchar](255) NULL,
	[EFFECTIVEYEAR] [varchar](4) NULL,
	[BEACHTIERRANKING] [varchar](1) NULL,
	[BEACHACTBEACHINDICATOR] [varchar](5) NULL,
	[EXTENTLENGTHMEASURE] [decimal](19, 14) NULL,
	[EXTENTUNITOFMEASURE] [varchar](12) NULL,
	[SWIMSEASONSTARTDATE] [varchar](25) NULL,
	[SWIMSEASONLENGTH] [decimal](19, 14) NULL,
	[SWIMSEASONENDDATE] [varchar](25) NULL,
	[SWIMSEASONUNITOFMEASURE] [varchar](12) NULL,
	[SWIMSEASONFREQUENCYMEASURE] [decimal](19, 14) NULL,
	[OFFSEASONFREQUENCYMEASURE] [decimal](19, 14) NULL,
	[MONITORINGFREQUNITOFMEASURE] [varchar](255) NULL,
	[MONITOREDIRREGULARLY] [varchar](5) NULL,
	[MONITOREDIRREGULARLYCOMMENT] [varchar](255) NULL,
	[NOPOLLUTIONSOURCES] [varchar](5) NULL,
	[POLLUTIONSOURCESUNINVESTIGATED] [varchar](5) NULL,
	[STARTLATMEASURE] [varchar](25) NULL,
	[STARTLONGMEASURE] [varchar](25) NULL,
	[SOURCEMAPSCALE] [varchar](25) NULL,
	[HORIZCOLLMETHOD] [varchar](25) NULL,
	[HORIZCOLLDATUM] [varchar](25) NULL,
	[ENDLATMEASURE] [varchar](25) NULL,
	[ENDLONGMEASURE] [varchar](25) NULL,
 CONSTRAINT [PK_NOT_BCH] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique code that identifies the beach (BeachIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHIDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the program interest (ProgramInterestName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the program interest (ProgramInterestDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A comment about the program interest (ProgramInterestCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHCOMMENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The two letter code fot the state the program interest is located in (ProgramInterestStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHSTATECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The FIPS county code for the program interest (ProgramInterestFIPSCountyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHFIPSCOUNTYCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The water body name code for the beach. (WaterBodyNameCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'WATERBODYNAMECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The water body type code for the beach. (WaterBodyTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'WATERBODYTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The accessibility of the beach (ex: PUB_PUB_ACC, PRV_PUB_ACC) (BeachAccessibilityType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHACCESSTYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short comment about the accessibility of the beach (BeachAccessibilityComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHACCESSCOMMENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year the attribute is effective (AttributeEffectiveYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'EFFECTIVEYEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The tier of the beach (BeachTierRanking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHTIERRANKING'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if the beach qualifies as a BEACH Act beach.  False in any other case (BeachActBeachIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'BEACHACTBEACHINDICATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The length of the object (ExtentLengthMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'EXTENTLENGTHMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measurement (ExtentUnitOfMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'EXTENTUNITOFMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The start date of the swim season (SwimSeasonStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'SWIMSEASONSTARTDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that descreibes the length of the swim season (SwimSeasonLengthMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'SWIMSEASONLENGTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The end date of the swim season (SwimSeasonEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'SWIMSEASONENDDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure for the length of the swim season (SwimSeasonUnitOfMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'SWIMSEASONUNITOFMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the length of the swim season (SwimSeasonFrequencyMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'SWIMSEASONFREQUENCYMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the lenght of the off season (OffSeasonFrequencyMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'OFFSEASONFREQUENCYMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of time that is used for the measurements (MonitoringFrequencyUnitOfMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'MONITORINGFREQUNITOFMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'True if a beach is sporadically monitored.  False in any other case (MonitoredIrregularly)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'MONITOREDIRREGULARLY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments about the monitoring frequency of the beach. (MonitoredIrregularlyComment)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'MONITOREDIRREGULARLYCOMMENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This can only be true.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (NoPollutionSourcesIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'NOPOLLUTIONSOURCES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This can only be true.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (PollutionSourcesUninvestigatedIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'POLLUTIONSOURCESUNINVESTIGATED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'STARTLATMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'STARTLONGMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'SOURCEMAPSCALE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'HORIZCOLLMETHOD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that describes the reference datum used in determining latitude and longitude coordinates. (HorizontalCoordinateReferenceSystemDatumName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'HORIZCOLLDATUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'ENDLATMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH', @level2type=N'COLUMN',@level2name=N'ENDLONGMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: BeachDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACH'
GO
/****** Object:  Table [dbo].[NOTIF_ORGANIZATION]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ORGANIZATION](
	[ID] [varchar](40) NOT NULL,
	[ORGANIZATIONIDENTIFIER] [varchar](12) NOT NULL,
	[ORGANIZATIONTYPECODE] [varchar](12) NULL,
	[ORGANIZATIONNAME] [varchar](60) NULL,
	[ORGANIZATIONDESCRIPTION] [varchar](255) NULL,
	[ORGANIZATIONABBREVIATION] [varchar](30) NULL,
 CONSTRAINT [PK_NOT_ORG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique code that identifies each organization (OrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATION', @level2type=N'COLUMN',@level2name=N'ORGANIZATIONIDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details the type of agency being described (OrganizationTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATION', @level2type=N'COLUMN',@level2name=N'ORGANIZATIONTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details the name of the organization being described (OrganizationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATION', @level2type=N'COLUMN',@level2name=N'ORGANIZATIONNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short text description of the organization (OrganizationDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATION', @level2type=N'COLUMN',@level2name=N'ORGANIZATIONDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviation of the organization being described (OrganizationAbbreviationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATION', @level2type=N'COLUMN',@level2name=N'ORGANIZATIONABBREVIATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: OrganizationDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATION'
GO
/****** Object:  Table [dbo].[NOTIF_BEACHPROCEDURE]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_BEACHPROCEDURE](
	[ID] [varchar](40) NOT NULL,
	[PROCEDURETYPECODE] [varchar](12) NOT NULL,
	[PROCEDUREDESCRIPTION] [varchar](255) NOT NULL,
	[PROCEDUREIDENTIFIER] [varchar](8) NOT NULL,
	[BEACH_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_NOT_BCH_PRO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_BCHPRCDR_BCH_ID] ON [dbo].[NOTIF_BEACHPROCEDURE] 
(
	[BEACH_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the procedure (ProcedureTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPROCEDURE', @level2type=N'COLUMN',@level2name=N'PROCEDURETYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The description of the procedure (ProcedureDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPROCEDURE', @level2type=N'COLUMN',@level2name=N'PROCEDUREDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that identifies the procedure (ProcedureIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPROCEDURE', @level2type=N'COLUMN',@level2name=N'PROCEDUREIDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: BeachProcedureDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPROCEDURE'
GO
/****** Object:  Table [dbo].[NOTIF_BEACHPOLLUTION]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_BEACHPOLLUTION](
	[ID] [varchar](40) NOT NULL,
	[BEACH_ID] [varchar](40) NOT NULL,
	[POLLUTIONSOURCECODE] [varchar](12) NOT NULL,
	[POLLUTIONSOURCEDESCRIPTION] [varchar](255) NULL,
 CONSTRAINT [PK_NOT_BCH_POL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_BCH_P02] ON [dbo].[NOTIF_BEACHPOLLUTION] 
(
	[BEACH_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of pollution sources.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPOLLUTION', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of pollution sources.  Only one of the following is allowed: a list of pollution sources, NoPollutionSources must be true, or PollutionSourcesUninvestigated must be true. (BeachId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPOLLUTION', @level2type=N'COLUMN',@level2name=N'BEACH_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code representing the source of the polution (BeachPollutionSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPOLLUTION', @level2type=N'COLUMN',@level2name=N'POLLUTIONSOURCECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the pollution source (BeachPollutionSourceDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPOLLUTION', @level2type=N'COLUMN',@level2name=N'POLLUTIONSOURCEDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: BeachPollutionSourceDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHPOLLUTION'
GO
/****** Object:  Table [dbo].[NOTIF_BEACHACTIVITY]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_BEACHACTIVITY](
	[ID] [varchar](40) NOT NULL,
	[BEACH_ID] [varchar](40) NOT NULL,
	[ACTIVITYTYPECODE] [varchar](12) NOT NULL,
	[ACTIVITYNAME] [varchar](60) NOT NULL,
	[ACTUALSTARTDATE] [varchar](25) NOT NULL,
	[ACTUALSTOPDATE] [varchar](25) NOT NULL,
	[MONITORINGSTATIONIDENTIFIER] [varchar](65) NULL,
	[ACTIVITYDESCRIPTION] [varchar](255) NULL,
	[ACTIVITYCOMMENT] [varchar](255) NULL,
	[SENTTOEPA] [char](1) NULL,
	[EXTENTSTARTMEASURE] [decimal](19, 14) NULL,
	[EXTENTLENGTHMEASURE] [decimal](19, 14) NULL,
	[EXTENTUNITOFMEASURE] [varchar](255) NULL,
 CONSTRAINT [PK_NOT_BCH_ACT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_BCH_A02] ON [dbo].[NOTIF_BEACHACTIVITY] 
(
	[BEACH_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with an activity. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with an activity. (BeachId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'BEACH_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code for the type of activity being reported (ex: CLOSURE, CONTAM_ADV) (ActivityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTIVITYTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the activity being reported for the beach (ActivityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTIVITYNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The start date for the activity (ActivityActualStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTUALSTARTDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The stop date for the activity (ActivityActualStopDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTUALSTOPDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier for the monitoring station (ActivityMonitoringStationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'MONITORINGSTATIONIDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the activity (ActivityDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTIVITYDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A comment about the activity (ActivityCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTIVITYCOMMENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with an activity. (SetToEPA)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'SENTTOEPA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The distance of the beach that the activity affects (ActivityExtentStartMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'EXTENTSTARTMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The length of the measure (ActivityExtentLengthMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'EXTENTLENGTHMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of length for the measurement (ActivityExtentUnitOfMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY', @level2type=N'COLUMN',@level2name=N'EXTENTUNITOFMEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ActivityDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_BEACHACTIVITY'
GO
/****** Object:  Table [dbo].[NOTIF_PERSONBEACHROLE]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_PERSONBEACHROLE](
	[ID] [varchar](40) NOT NULL,
	[BEACH_ID] [varchar](40) NOT NULL,
	[PERSON_ID] [varchar](40) NOT NULL,
	[ROLETYPECODE] [varchar](12) NOT NULL,
	[ROLEEFFECTIVEDATE] [varchar](25) NOT NULL,
	[ROLESTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_PER_BCH_R] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_PER_BCH02] ON [dbo].[NOTIF_PERSONBEACHROLE] 
(
	[BEACH_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PRSNBCH_PRSN_ID] ON [dbo].[NOTIF_PERSONBEACHROLE] 
(
	[PERSON_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code for the role of the beach (ex: LOCAL, RESPONDENT) (BeachRoleTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ROLETYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the role becomes effective (BeachRoleEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ROLEEFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether the role is ACTIVE or INACTIVE (BeachRoleStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ROLESTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PersonRoleDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONBEACHROLE'
GO
/****** Object:  Table [dbo].[NOTIF_PERSON]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_PERSON](
	[ID] [varchar](40) NOT NULL,
	[ORGANIZATION_ID] [varchar](40) NOT NULL,
	[PERSONIDENTIFIER] [varchar](12) NOT NULL,
	[PERSONSTATUS] [varchar](8) NULL,
	[FIRSTNAME] [varchar](50) NULL,
	[LASTNAME] [varchar](50) NULL,
	[MIDDLEINITIAL] [varchar](2) NULL,
	[SUFFIX] [varchar](5) NULL,
	[TITLE] [varchar](60) NULL,
 CONSTRAINT [PK_NOT_PER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_P02] ON [dbo].[NOTIF_PERSON] 
(
	[ORGANIZATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with a person. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with a person. (OrganizationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'ORGANIZATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique code that identifies each a person (PersonIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'PERSONIDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether the person is ACTIVE or INACTIVE (PersonStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'PERSONSTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first name of the person (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'FIRSTNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The last name of the person (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'LASTNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The middle initial of the person (PersonMiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'MIDDLEINITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s suffix (NameSuffixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'SUFFIX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person''s title (NamePrefixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON', @level2type=N'COLUMN',@level2name=N'TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PersonDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSON'
GO
/****** Object:  Table [dbo].[NOTIF_ORGELECTRONICADDR]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ORGELECTRONICADDR](
	[ID] [varchar](40) NOT NULL,
	[ORGANIZATION_ID] [varchar](40) NOT NULL,
	[ELECTRONICADDRTYPECODE] [varchar](12) NOT NULL,
	[ELECTRONICADDR] [varchar](255) NOT NULL,
	[ELECTRONICADDREFFDATE] [varchar](25) NOT NULL,
	[ELECTRONICADDRSTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_ORG_EA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ORG_03] ON [dbo].[NOTIF_ORGELECTRONICADDR] 
(
	[ORGANIZATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with an organization''s electronic addresses. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with an organization''s electronic addresses. (OrganizationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR', @level2type=N'COLUMN',@level2name=N'ORGANIZATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of electronic address being described (ex: EMAIL, URL) (ElectronicAddressTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDRTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual address being described (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the change becomes effective (ElectronicAddressEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDREFFDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status the address will be changed to (ElectronicAddressStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDRSTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: OrganizationElectronicAddressType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGELECTRONICADDR'
GO
/****** Object:  Table [dbo].[NOTIF_ORGANIZATIONTELEPHONE]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ORGANIZATIONTELEPHONE](
	[ID] [varchar](40) NOT NULL,
	[ORGANIZATION_ID] [varchar](40) NOT NULL,
	[TELEPHONETYPECODE] [varchar](12) NOT NULL,
	[TELEPHONENUMBER] [varchar](12) NOT NULL,
	[TELEPHONEEFFECTIVEDATE] [varchar](25) NOT NULL,
	[TELEPHONESTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_ORG_TEL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ORG_T02] ON [dbo].[NOTIF_ORGANIZATIONTELEPHONE] 
(
	[ORGANIZATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with an organization''s telephone number. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with an organization''s telephone number. (OrganizationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE', @level2type=N'COLUMN',@level2name=N'ORGANIZATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone number being described (ex: VOICE, FAX) (TelephoneTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONETYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual telephone number being described (Must include "-".  ex: xxx-xxx-xxxx) (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONENUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the number becomes effective (TelephoneEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONEEFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status the number will be changed to (ex: ACTIVE, INACTIVE) (TelephoneStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONESTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: OrganizationTelephoneType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONTELEPHONE'
GO
/****** Object:  Table [dbo].[NOTIF_ORGANIZATIONMAILINGADDR]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ORGANIZATIONMAILINGADDR](
	[ID] [varchar](40) NOT NULL,
	[ORGANIZATION_ID] [varchar](40) NOT NULL,
	[MAILINGADDRTYPECODE] [varchar](12) NOT NULL,
	[MAILINGADDRLINE1] [varchar](100) NOT NULL,
	[MAILINGADDRLINE2] [varchar](100) NULL,
	[MAILINGADDRLINE3] [varchar](100) NULL,
	[MAILINGADDRCITY] [varchar](50) NOT NULL,
	[STATECODE] [char](2) NOT NULL,
	[ZIPCODE] [varchar](12) NOT NULL,
	[MAILINGADDREFFECTIVEDATE] [varchar](25) NOT NULL,
	[MAILINGADDRSTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_ORG_MA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ORG_02] ON [dbo].[NOTIF_ORGANIZATIONMAILINGADDR] 
(
	[ORGANIZATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details what type the mailing address is (MailingAddressTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDRTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first line of the address (MailingAddressStreetLine1Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDRLINE1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The second line of the address (MailingAddressStreetLine2Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDRLINE2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The third line of the address (MailingAddressStreetLine3Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDRLINE3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city name of the address (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDRCITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The state code of the address (StateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'STATECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The zip code of the address (AddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'ZIPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the change becomes effective (MailingAddressEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDREFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status that the mailing address will be changed to (MailingAddressStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR', @level2type=N'COLUMN',@level2name=N'MAILINGADDRSTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: OrganizationMailingAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONMAILINGADDR'
GO
/****** Object:  Table [dbo].[NOTIF_ORGANIZATIONBEACHROLE]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ORGANIZATIONBEACHROLE](
	[ID] [varchar](40) NOT NULL,
	[BEACH_ID] [varchar](40) NOT NULL,
	[ORGANIZATION_ID] [varchar](40) NOT NULL,
	[ROLETYPECODE] [varchar](12) NOT NULL,
	[ROLEEFFECTIVEDATE] [varchar](25) NOT NULL,
	[ROLESTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_ORG_BCH_R] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ORG_BCH02] ON [dbo].[NOTIF_ORGANIZATIONBEACHROLE] 
(
	[BEACH_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ORGNZT_ORGNZ_ID] ON [dbo].[NOTIF_ORGANIZATIONBEACHROLE] 
(
	[ORGANIZATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with a beach role. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with a beach role. (BeachId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE', @level2type=N'COLUMN',@level2name=N'BEACH_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information associated with a beach role. (OrganizationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ORGANIZATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code for the role of the beach (ex: LOCAL, RESPONDENT) (BeachRoleTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ROLETYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the role becomes effective (BeachRoleEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ROLEEFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether the role is ACTIVE or INACTIVE (BeachRoleStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE', @level2type=N'COLUMN',@level2name=N'ROLESTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: OrganizationRoleDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ORGANIZATIONBEACHROLE'
GO
/****** Object:  Table [dbo].[NOTIF_PERSONTELEPHONE]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_PERSONTELEPHONE](
	[ID] [varchar](40) NOT NULL,
	[PERSON_ID] [varchar](40) NOT NULL,
	[TELEPHONETYPECODE] [varchar](12) NOT NULL,
	[TELEPHONENUMBER] [varchar](12) NOT NULL,
	[TELEPHONEEFFECTIVEDATE] [varchar](25) NOT NULL,
	[TELEPHONESTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_PER_TEL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_PER_T02] ON [dbo].[NOTIF_PERSONTELEPHONE] 
(
	[PERSON_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with a person''s telephone number. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with a person''s telephone number. (PersonId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE', @level2type=N'COLUMN',@level2name=N'PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of telephone number being described (ex: VOICE, FAX) (TelephoneTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONETYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual telephone number being described (Must include "-".  ex: xxx-xxx-xxxx) (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONENUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the number becomes effective (TelephoneEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONEEFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status the number will be changed to (ex: ACTIVE, INACTIVE) (TelephoneStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE', @level2type=N'COLUMN',@level2name=N'TELEPHONESTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PersonTelephoneType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONTELEPHONE'
GO
/****** Object:  Table [dbo].[NOTIF_PERSONMAILINGADDRESS]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_PERSONMAILINGADDRESS](
	[ID] [varchar](40) NOT NULL,
	[PERSON_ID] [varchar](40) NOT NULL,
	[MAILINGADDRTYPECODE] [varchar](12) NOT NULL,
	[MAILINGADDRLINE1] [varchar](100) NOT NULL,
	[MAILINGADDRLINE2] [varchar](100) NULL,
	[MAILINGADDRLINE3] [varchar](100) NULL,
	[MAILINGADDRCITY] [varchar](50) NOT NULL,
	[STATECODE] [char](2) NOT NULL,
	[ZIPCODE] [varchar](12) NOT NULL,
	[MAILINGADDREFFECTIVEDATE] [varchar](25) NOT NULL,
	[MAILINGADDRSTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_PER_MA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_PER_02] ON [dbo].[NOTIF_PERSONMAILINGADDRESS] 
(
	[PERSON_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information for the person. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information for the person. (PersonId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details what type the mailing address is (MailingAddressTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDRTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first line of the address (MailingAddressStreetLine1Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDRLINE1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The second line of the address (MailingAddressStreetLine2Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDRLINE2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The third line of the address (MailingAddressStreetLine3Text)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDRLINE3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city name of the address (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDRCITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The state code of the address (StateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'STATECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The zip code of the address (AddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'ZIPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the change becomes effective (MailingAddressEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDREFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status that the mailing address will be changed to (MailingAddressStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS', @level2type=N'COLUMN',@level2name=N'MAILINGADDRSTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PersonMailingAddressDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONMAILINGADDRESS'
GO
/****** Object:  Table [dbo].[NOTIF_PERSONELECTRONICADDRESS]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_PERSONELECTRONICADDRESS](
	[ID] [varchar](40) NOT NULL,
	[PERSON_ID] [varchar](40) NOT NULL,
	[ELECTRONICADDRESSTYPECODE] [varchar](12) NOT NULL,
	[ELECTRONICADDRESS] [varchar](255) NOT NULL,
	[ELECTRONICADDRESSEFFECTIVEDATE] [varchar](25) NOT NULL,
	[ELECTRONICADDRESSSTATUS] [varchar](8) NOT NULL,
 CONSTRAINT [PK_NOT_PER_EA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_PER_03] ON [dbo].[NOTIF_PERSONELECTRONICADDRESS] 
(
	[PERSON_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with a person''s electronic addresses. (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: All the information asssociated with a person''s electronic addresses. (PersonId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS', @level2type=N'COLUMN',@level2name=N'PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of electronic address being described (ex: EMAIL, URL) (ElectronicAddressTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDRESSTYPECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual address being described (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the change becomes effective (ElectronicAddressEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDRESSEFFECTIVEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status the address will be changed to (ElectronicAddressStatusIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS', @level2type=N'COLUMN',@level2name=N'ELECTRONICADDRESSSTATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PersonElectronicAddressType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_PERSONELECTRONICADDRESS'
GO
/****** Object:  Table [dbo].[NOTIF_ACTIVITYSOURCE]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ACTIVITYSOURCE](
	[ID] [varchar](40) NOT NULL,
	[ACTIVITY_ID] [varchar](40) NOT NULL,
	[SOURCETYPE] [varchar](60) NOT NULL,
	[SOURCEDESCRIPTION] [varchar](255) NULL,
 CONSTRAINT [PK_NOT_ACT_SRC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ACT_S02] ON [dbo].[NOTIF_ACTIVITYSOURCE] 
(
	[ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Describes the source of the activity (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYSOURCE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Describes the source of the activity (ActivityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYSOURCE', @level2type=N'COLUMN',@level2name=N'ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code for the source of the activity (ActivitySourceType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYSOURCE', @level2type=N'COLUMN',@level2name=N'SOURCETYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the source of the activity (ActivitySourceDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYSOURCE', @level2type=N'COLUMN',@level2name=N'SOURCEDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ActivitySourceDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYSOURCE'
GO
/****** Object:  Table [dbo].[NOTIF_ACTIVITYREASON]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ACTIVITYREASON](
	[ID] [varchar](40) NOT NULL,
	[ACTIVITY_ID] [varchar](40) NOT NULL,
	[REASONTYPE] [varchar](60) NOT NULL,
	[REASONDESCRIPTION] [varchar](255) NULL,
 CONSTRAINT [PK_NOT_ACT_RSN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ACT_R02] ON [dbo].[NOTIF_ACTIVITYREASON] 
(
	[ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The reason for the activity (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYREASON', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The reason for the activity (ActivityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYREASON', @level2type=N'COLUMN',@level2name=N'ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code for the reason for the activity (ActivityReasonType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYREASON', @level2type=N'COLUMN',@level2name=N'REASONTYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the reason for the activity (ActivityReasonDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYREASON', @level2type=N'COLUMN',@level2name=N'REASONDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ActivityReasonDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYREASON'
GO
/****** Object:  Table [dbo].[NOTIF_ACTIVITYINDICATOR]    Script Date: 12/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NOTIF_ACTIVITYINDICATOR](
	[ID] [varchar](40) NOT NULL,
	[ACTIVITY_ID] [varchar](40) NOT NULL,
	[INDICATORTYPE] [varchar](60) NOT NULL,
	[INDICATORDESCRIPTION] [varchar](255) NULL,
 CONSTRAINT [PK_NOT_ACT_IND] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [FK_NOT_ACT_I02] ON [dbo].[NOTIF_ACTIVITYINDICATOR] 
(
	[ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The indicator used to test the activity (Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYINDICATOR', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The indicator used to test the activity (ActivityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYINDICATOR', @level2type=N'COLUMN',@level2name=N'ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code for the indicator (ActivityIndicatorType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYINDICATOR', @level2type=N'COLUMN',@level2name=N'INDICATORTYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A short description of the type of indicator (ActivityIndicatorDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYINDICATOR', @level2type=N'COLUMN',@level2name=N'INDICATORDESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ActivityIndicatorDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NOTIF_ACTIVITYINDICATOR'
GO
/****** Object:  ForeignKey [FK_NOT_BCH_POL]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_BEACHPOLLUTION]  WITH CHECK ADD  CONSTRAINT [FK_NOT_BCH_POL] FOREIGN KEY([BEACH_ID])
REFERENCES [dbo].[NOTIF_BEACH] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_BEACHPOLLUTION] CHECK CONSTRAINT [FK_NOT_BCH_POL]
GO
/****** Object:  ForeignKey [FK_NOT_BCH_ACT]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_BEACHACTIVITY]  WITH CHECK ADD  CONSTRAINT [FK_NOT_BCH_ACT] FOREIGN KEY([BEACH_ID])
REFERENCES [dbo].[NOTIF_BEACH] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_BEACHACTIVITY] CHECK CONSTRAINT [FK_NOT_BCH_ACT]
GO
/****** Object:  ForeignKey [FK_NOT_PER_BCH_R]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_PERSONBEACHROLE]  WITH CHECK ADD  CONSTRAINT [FK_NOT_PER_BCH_R] FOREIGN KEY([BEACH_ID])
REFERENCES [dbo].[NOTIF_BEACH] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_PERSONBEACHROLE] CHECK CONSTRAINT [FK_NOT_PER_BCH_R]
GO
/****** Object:  ForeignKey [FK_NOT_PER]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_PERSON]  WITH CHECK ADD  CONSTRAINT [FK_NOT_PER] FOREIGN KEY([ORGANIZATION_ID])
REFERENCES [dbo].[NOTIF_ORGANIZATION] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_PERSON] CHECK CONSTRAINT [FK_NOT_PER]
GO
/****** Object:  ForeignKey [FK_NOT_ORG_EA]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ORGELECTRONICADDR]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ORG_EA] FOREIGN KEY([ORGANIZATION_ID])
REFERENCES [dbo].[NOTIF_ORGANIZATION] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ORGELECTRONICADDR] CHECK CONSTRAINT [FK_NOT_ORG_EA]
GO
/****** Object:  ForeignKey [FK_NOT_ORG_TEL]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ORGANIZATIONTELEPHONE]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ORG_TEL] FOREIGN KEY([ORGANIZATION_ID])
REFERENCES [dbo].[NOTIF_ORGANIZATION] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ORGANIZATIONTELEPHONE] CHECK CONSTRAINT [FK_NOT_ORG_TEL]
GO
/****** Object:  ForeignKey [FK_NOT_ORG_MA]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ORGANIZATIONMAILINGADDR]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ORG_MA] FOREIGN KEY([ORGANIZATION_ID])
REFERENCES [dbo].[NOTIF_ORGANIZATION] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ORGANIZATIONMAILINGADDR] CHECK CONSTRAINT [FK_NOT_ORG_MA]
GO
/****** Object:  ForeignKey [FK_NOT_ORG_BCH_R]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ORGANIZATIONBEACHROLE]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ORG_BCH_R] FOREIGN KEY([BEACH_ID])
REFERENCES [dbo].[NOTIF_BEACH] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ORGANIZATIONBEACHROLE] CHECK CONSTRAINT [FK_NOT_ORG_BCH_R]
GO
/****** Object:  ForeignKey [FK_NOT_PER_TEL]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_PERSONTELEPHONE]  WITH CHECK ADD  CONSTRAINT [FK_NOT_PER_TEL] FOREIGN KEY([PERSON_ID])
REFERENCES [dbo].[NOTIF_PERSON] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_PERSONTELEPHONE] CHECK CONSTRAINT [FK_NOT_PER_TEL]
GO
/****** Object:  ForeignKey [FK_NOT_PER_MA]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_PERSONMAILINGADDRESS]  WITH CHECK ADD  CONSTRAINT [FK_NOT_PER_MA] FOREIGN KEY([PERSON_ID])
REFERENCES [dbo].[NOTIF_PERSON] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_PERSONMAILINGADDRESS] CHECK CONSTRAINT [FK_NOT_PER_MA]
GO
/****** Object:  ForeignKey [FK_NOT_PER_EA]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_PERSONELECTRONICADDRESS]  WITH CHECK ADD  CONSTRAINT [FK_NOT_PER_EA] FOREIGN KEY([PERSON_ID])
REFERENCES [dbo].[NOTIF_PERSON] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_PERSONELECTRONICADDRESS] CHECK CONSTRAINT [FK_NOT_PER_EA]
GO
/****** Object:  ForeignKey [FK_NOT_ACT_SRC]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ACTIVITYSOURCE]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ACT_SRC] FOREIGN KEY([ACTIVITY_ID])
REFERENCES [dbo].[NOTIF_BEACHACTIVITY] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ACTIVITYSOURCE] CHECK CONSTRAINT [FK_NOT_ACT_SRC]
GO
/****** Object:  ForeignKey [FK_NOT_ACT_RSN]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ACTIVITYREASON]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ACT_RSN] FOREIGN KEY([ACTIVITY_ID])
REFERENCES [dbo].[NOTIF_BEACHACTIVITY] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ACTIVITYREASON] CHECK CONSTRAINT [FK_NOT_ACT_RSN]
GO
/****** Object:  ForeignKey [FK_NOT_ACT_IND]    Script Date: 12/18/2009 16:05:06 ******/
ALTER TABLE [dbo].[NOTIF_ACTIVITYINDICATOR]  WITH CHECK ADD  CONSTRAINT [FK_NOT_ACT_IND] FOREIGN KEY([ACTIVITY_ID])
REFERENCES [dbo].[NOTIF_BEACHACTIVITY] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NOTIF_ACTIVITYINDICATOR] CHECK CONSTRAINT [FK_NOT_ACT_IND]
GO

ALTER TABLE NOTIF_BEACHPROCEDURE ADD CONSTRAINT FK_NOT_BCH_PRO FOREIGN KEY(BEACH_ID) REFERENCES NOTIF_BEACH(ID)
GO

ALTER TABLE NOTIF_PERSONBEACHROLE ADD CONSTRAINT FK_NOT_PER_BCH FOREIGN KEY(PERSON_ID) REFERENCES NOTIF_PERSON(ID)
GO

ALTER TABLE NOTIF_ORGANIZATIONBEACHROLE ADD CONSTRAINT FK_NOT_ORG_BCH FOREIGN KEY(ORGANIZATION_ID) REFERENCES NOTIF_ORGANIZATION(ID)
GO
