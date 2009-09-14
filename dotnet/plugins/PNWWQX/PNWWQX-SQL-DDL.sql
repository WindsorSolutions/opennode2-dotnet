/****** Object:  Table [dbo].[PNWWQX_ProvidingOrganization]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_ProvidingOrganization](
	[ProvidingOrganizationPK] [int] NOT NULL,
	[ProvidingOrganizationIdentifier] [varchar](30) NOT NULL,
	[ProvidingOrganizationName] [varchar](80) NOT NULL,
	[ProvidingOrganizationType] [varchar](20) NOT NULL,
	[ProvidingOrganizationContactName] [varchar](70) NOT NULL,
	[MailingAddress] [varchar](50) NULL,
	[MailingAddressCityName] [varchar](30) NULL,
	[MailingAddressStateName] [varchar](35) NULL,
	[MailingAddressZIPCode] [varchar](14) NULL,
	[TelephoneNumber] [varchar](15) NOT NULL,
	[ElectronicMailAddressText] [varchar](100) NULL,
	[ProvidingOrganizationURL] [varchar](100) NULL,
 CONSTRAINT [ProvidingOrganizationPK] PRIMARY KEY CLUSTERED 
(
	[ProvidingOrganizationPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_Station](
	[StationPK] [int] NOT NULL,
	[StationIdentifier] [varchar](30) NOT NULL,
	[StationName] [varchar](255) NOT NULL,
	[StationLocationDescription] [varchar](255) NULL,
	[StationType] [varchar](20) NOT NULL,
	[LatitudeMeasure] [decimal](8, 6) NOT NULL,
	[LongitudeMeasure] [decimal](9, 6) NOT NULL,
	[HorizontalAccuracyMeasure] [numeric](10, 0) NULL,
	[SourceMapScaleNumber] [numeric](10, 0) NULL,
	[CoordinateDataSourceName] [varchar](35) NULL,
	[HorizontalCollectionMethodText] [varchar](60) NOT NULL,
	[HorizontalReferenceDatumName] [varchar](60) NOT NULL,
	[ReferencePointText] [varchar](60) NULL,
	[VerticalMeasure] [numeric](18, 0) NULL,
	[VerticalMeasureUnitofMeasure] [varchar](10) NULL,
	[VerticalAccuracyMeasure] [numeric](10, 0) NULL,
	[VerticalCollectionMethodText] [varchar](60) NULL,
	[VerticalReferenceDatumName] [varchar](60) NULL,
	[VerticalReferencePointContextText] [varchar](255) NULL,
 CONSTRAINT [StationPK] PRIMARY KEY CLUSTERED 
(
	[StationPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX__AllTableCount]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PNWWQX__AllTableCount](
	[Count_DT] [datetime] NULL,
	[PNWWQX_Affiliation] [int] NULL,
	[PNWWQX_BinaryLargeObject] [int] NULL,
	[PNWWQX_ContactEntity] [int] NULL,
	[PNWWQX_FieldEvent] [int] NULL,
	[PNWWQX_LocationDescriptor] [int] NULL,
	[PNWWQX_Project] [int] NULL,
	[PNWWQX_ProjectAnalyte] [int] NULL,
	[PNWWQX_ProjectStation] [int] NULL,
	[PNWWQX_ProvidingOrganization] [int] NULL,
	[PNWWQX_Result] [int] NULL,
	[PNWWQX_ResultDetectionLevel] [int] NULL,
	[PNWWQX_SamplePreparationMethod] [int] NULL,
	[PNWWQX_SamplePreservationMethod] [int] NULL,
	[PNWWQX_Station] [int] NULL,
	[PNWWQX_WellDetail] [int] NULL,
	[PNWWQX_XtraJoinTable] [int] NULL,
	[PNWWQX_DataCatalog_DataAccess] [int] NULL,
	[PNWWQX_DataCatalog_ProjectSummary] [int] NULL,
	[PNWWQX_DataCatalog_StationSummary] [int] NULL,
	[PNWWQX_DataCatalog_FieldEventSummary] [int] NULL,
	[PNWWQX_DataCatalog_StationLocationDescriptor] [int] NULL,
	[PNWWQX_DataCatalog_Utility_FilterByLastUpdate] [int] NULL
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [PNW__AllTableCount_SortByDateDesc_IDX] ON [dbo].[PNWWQX__AllTableCount] 
(
	[Count_DT] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADMIN_NodeFlowLoadCount]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADMIN_NodeFlowLoadCount](
	[TABLE_NAME_NM] [varchar](75) NULL,
	[RECORD_COUNT_QT] [int] NULL,
	[COUNT_DATE_DT] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [ADMIN_NodeFlowLoadCount_SortByDate_IDX] ON [dbo].[ADMIN_NodeFlowLoadCount] 
(
	[COUNT_DATE_DT] DESC,
	[TABLE_NAME_NM] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_FieldEventSummary_ORIGNAL]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_FieldEventSummary_ORIGNAL](
	[FieldEventSummaryPK] [int] IDENTITY(1,1) NOT NULL,
	[minFieldEventStartDate] [datetime] NOT NULL,
	[maxFieldEventEndDate] [datetime] NOT NULL,
	[MediaText] [varchar](30) NOT NULL,
	[BiologicalSystematicName] [varchar](200) NULL,
	[AnalyteName] [varchar](255) NULL,
	[NumberResults] [int] NULL,
	[FieldEventProjectIdentifier] [varchar](30) NOT NULL,
	[FieldEventStationIdentifier] [varchar](30) NOT NULL,
	[FieldEventContactOrganizationName] [varchar](80) NULL,
	[ProvidingOrganizationFK] [int] NULL,
 CONSTRAINT [PK_PNWWQX_DataCatalog_FieldEventSummary] PRIMARY KEY CLUSTERED 
(
	[FieldEventSummaryPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[PNWWQX_GetProjectsData]    Script Date: 06/23/2009 13:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE	[dbo].[PNWWQX_GetProjectsData]
			(
			@rowID							int = 0,
			@maxRows						int = 0,
			@providingOrganizationName				varchar(80) = '',
			@projectOrganizationName				varchar(80) = '',
			@projectName						varchar(255) = '',
			@projectStartDate					varchar(25) = '',
			@projectEndDate					varchar(25) = '',
			@responsibleOrganizationName				varchar(80) = '',
			@maximumLocationLatitude				decimal(8,6) = 0,
			@maximumLocationLongitude				decimal(9,6) = 0,
			@minimumLocationLatitude				decimal(8,6) = 0,
			@minimumLocationLongitude				decimal(9,6) = 0,
			@locationDescriptorContext				varchar(30) = '',
			@locationDescriptorName				varchar(100) = '',
			@stationType						varchar(4000) = '',
			@stationName						varchar(255) = '',
			@samplingOrganizationName				varchar(80) = '',
			@fieldEventStartDate					varchar(25) = '',
			@fieldEventEndDate					varchar(25) = '',
			@sampledMedia						varchar(4000) = '',
			@analyteName						varchar(4000) = '',
			@sampledTaxon					varchar(4000) = '',
			@Deliminator						char(1) = '|'
			)
AS

SET NOCOUNT ON
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
/*	
	//////////////////////////////
	Who: Balaji Narayanan
	When: 2/1/2007
	Action: Rewrote the procedure to make it a dynamic SQL
	//////////////////////////////
*/
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Stored procedure syntax with parameters to get results in query analyzer, in this case for the ANALYTE NAME, "Indan"
--PNWWQX_GetMeasurementsData 0,-1,'','','','1/1/1753','12/31/9999','',60,-100,40,-140,'','','','','','1/1/1753','12/31/9999','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,10,'','','','','','',60,-100,40,-140,'','','','','','','','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,10,'','','','','','',0,0,0,0,'','','','','','','','','Mercury','',''
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	DECLARE	@_ProjectStartDate					datetime
	DECLARE	@_ProjectEndDate					datetime
	DECLARE	@_FieldEventStartDate					datetime
	DECLARE	@_FieldEventEndDate					datetime

	SET		@_ProjectStartDate =					CONVERT(datetime, @projectStartDate)
	SET		@_ProjectEndDate =					CONVERT(datetime, @projectEndDate)
	SET		@_FieldEventStartDate =				CONVERT(datetime, @fieldEventStartDate)
	SET		@_FieldEventEndDate =					CONVERT(datetime, @FieldEventEndDate)

	IF @maxRows > 0 SET ROWCOUNT  @maxRows

	-- TNB change start
	DECLARE	@sql_where						nvarchar(4000)
	DECLARE	@sql_select						nvarchar(4000)
	DECLARE	@sql_query						nvarchar(4000)
	DECLARE	@paramlist						nvarchar(4000)

	--the WHERE clause for the dynamic query
	SET @sql_where = 'WHERE 1 = 1 '

	IF ISNULL(@providingOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProvidingOrganizationName like @xProvidingOrganizationName '    

	IF ISNULL(@projectOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectOrganizationName like @xprojectOrganizationName '    

	IF ISNULL(@projectName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectName like @xProjectName '                                       

	IF ISNULL(@projectStartDate,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectStartDate >= @xProjectStartDate '

	IF ISNULL(@projectEndDate,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectEndDate <= @xProjectEndDate '                                    

	IF ISNULL(@responsibleOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND StationOrganizationName like @xResponsibleOrganizationName '   

	IF ISNULL(@maximumLocationLatitude, 0) <> 0 AND ISNULL(@maximumLocationLongitude, 0) <> 0 AND ISNULL(@minimumLocationLatitude, 0) <> 0 AND ISNULL(@minimumLocationLongitude, 0) <> 0
		SET @sql_where = @sql_where + 'AND LatitudeMeasure BETWEEN @xMinimumLocationLatitude AND @xMaximumLocationLatitude ' +  'AND LongitudeMeasure BETWEEN @xMinimumLocationLongitude AND @xMaximumLocationLongitude ' 
	
	IF ISNULL(@LocationDescriptorContext,'') <> ''
		SET @sql_where = @sql_where + 'AND LocationDescriptorContext like @xLocationDescriptorContext '   

	IF ISNULL(@LocationDescriptorName,'') <> ''
		SET @sql_where = @sql_where + 'AND LocationDescriptorName like @xLocationDescriptorName '  

	IF ISNULL(@stationType,'') <> ''
		SET @sql_where = @sql_where + 'AND StationType IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xStationType,@xDeliminator))'

	IF ISNULL(@stationName,'') <> ''
		SET @sql_where = @sql_where + 'AND StationName like @xStationName '   

	IF ISNULL(@samplingOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND FieldEventOrganizationName like @xSamplingOrganizationName '

	IF ISNULL(@fieldEventStartDate,'') <> '' 
		SET @sql_where = @sql_where + 'AND FieldEventStartDate >= @xFieldEventStartDate '

	IF ISNULL(@fieldEventEndDate,'') <> '' 
		SET @sql_where = @sql_where + 'AND FieldEventEndDate <= @xFieldEventEndDate '

	IF ISNULL(@sampledMedia,'') <> ''
		SET @sql_where = @sql_where + 'AND MediaText IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledMedia,@xDeliminator))'

	IF ISNULL(@analyteName,'') <> ''
		SET @sql_where = @sql_where + 'AND AnalyteName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xAnalyteName,@xDeliminator))'

	IF ISNULL(@sampledTaxon,'') <> ''
		SET @sql_where = @sql_where + 'AND (FieldEventBiologicalSystematicName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledTaxon,@xDeliminator)) 
						  OR ResultBiologicalSystematicName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledTaxon,@xDeliminator)))'

	--the SELECT clause for the dynamic query
	SET @sql_select =	'SELECT DISTINCT ProjectFK, ProvidingOrganizationFK, ProjectContactEntityFK
		   		FROM PNWWQX_XtraJoinTable  '

	
	-- Declare Temp table to temporarily hold the theResultJoinList meeting the WHERE criteria
	-- We need this because using the EXEC the table variable cannot directly get the values (scope issue)
	CREATE TABLE	#ProjectJoinList
				(
				RowNumber					int IDENTITY (1, 1) Primary Key NOT NULL,
				ProjectPK					int NULL,
				ProvidingOrganizationPK				int NULL,
				ProjectContactEntityPK				int NULL
				)
	
	--the parameter list for the dynamic query execution
	SELECT @paramlist =	'@xProvidingOrganizationName  nvarchar(80), ' +
				'@xProjectOrganizationName  nvarchar(80), ' +  
				'@xSamplingOrganizationName nvarchar(80), '   +
				'@xResponsibleOrganizationName nvarchar(80), '   +
				'@xProjectName nvarchar(255), '   +
				'@xStationName nvarchar(255), '   +
				'@xFieldEventStartDate datetime, ' +
				'@xFieldEventEndDate datetime, ' +
				'@xProjectStartDate datetime, ' +
				'@xProjectEndDate datetime, ' +
				'@xMaximumLocationLatitude  decimal(8,6), ' +
				'@xMaximumLocationLongitude  decimal(9,6), ' +
				'@xMinimumLocationLatitude  decimal(8,6), ' +
				'@xMinimumLocationLongitude decimal(9,6), ' +
				'@xLocationDescriptorContext nvarchar(30), ' +
				'@xLocationDescriptorName nvarchar(100), ' +
				'@xStationType nvarchar(4000), '  +
				'@xSampledMedia nvarchar(4000), '  +
				'@xSampledTaxon nvarchar(4000), '  +
				'@xAnalyteName nvarchar(4000), '  +
				'@xDeliminator char(1) '

	-- Build the dynamic SQL query by concatenating the SELECT & WHERE clauses --
	SET @sql_query = @sql_select + @sql_where
	
	-- Retrive the records that matched the criteria & store them into the temporary table --
	INSERT INTO		#ProjectJoinList
	EXEC sp_executesql	@sql_query,
				@paramlist,                                   
				@providingOrganizationName,    -- wildcards
				@projectOrganizationName,  -- wildcards
				@samplingOrganizationName, -- wildcards
				@responsibleOrganizationName, -- wildcards
				@projectName, -- wildcards
				@stationName, -- wildcards
				@_fieldEventStartDate,
				@_fieldEventEndDate,
				@_projectStartDate,
				@_projectEndDate,
				@maximumLocationLatitude,
				@maximumLocationLongitude,
				@minimumLocationLatitude,
				@minimumLocationLongitude,
				@LocationDescriptorContext,
				@LocationDescriptorName,
				@stationType, -- list
				@sampledMedia, -- list
				@sampledTaxon, -- list
				@analyteName, -- list
				@Deliminator
	
	-- TNB change end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	--Select from the desired rows for paging
	IF		@rowID > 0
	BEGIN
			DELETE
			FROM		#ProjectJoinList
			WHERE	RowNumber < @rowID
	END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	--Remove rowcount limit to allow all results back from following selects
	SET ROWCOUNT 0
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 0. Providing Organization
	SELECT
	DISTINCT	PNWWQX_ProvidingOrganization.*
	FROM		PNWWQX_ProvidingOrganization
	INNER JOIN	#ProjectJoinList						AS theProjectJoinList
	ON		theProjectJoinList.ProvidingOrganizationPK = PNWWQX_ProvidingOrganization.ProvidingOrganizationPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 1. Projects
	SELECT
	DISTINCT	PNWWQX_Project.*
	FROM		PNWWQX_Project
	INNER JOIN	#ProjectJoinList						AS theProjectJoinList
	ON		theProjectJoinList.ProjectPK = PNWWQX_Project.ProjectPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 2. Contact Entity
	SELECT
	DISTINCT	PNWWQX_ContactEntity.*,
			theProjectJoinList.ProvidingOrganizationPK		AS ProvidingOrganizationFK,
			theProjectJoinList.ProjectPK				AS ProjectFK
	FROM		PNWWQX_ContactEntity
	INNER JOIN	#ProjectJoinList						AS theProjectJoinList
	ON		theProjectJoinList.ProjectContactEntityPK = PNWWQX_ContactEntity.ContactEntityPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 3. Project Analyte
	SELECT
	DISTINCT	PNWWQX_ProjectAnalyte.*
	FROM		PNWWQX_ProjectAnalyte
	INNER JOIN	#ProjectJoinList						AS theProjectJoinList
	ON		theProjectJoinList.ProjectPK = PNWWQX_ProjectAnalyte.ProjectFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 4. Project Details Binary Large Object
	SELECT
	DISTINCT	PNWWQX_BinaryLargeObject.*
	FROM		PNWWQX_BinaryLargeObject
	INNER JOIN	#ProjectJoinList						AS theProjectJoinList
	ON		theProjectJoinList.ProjectPK = PNWWQX_BinaryLargeObject.ProjectFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- Drop the temporary table --
	DROP TABLE	#ProjectJoinList
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[PNWWQX_GetStationsData]    Script Date: 06/23/2009 13:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE	[dbo].[PNWWQX_GetStationsData]
			(
			@rowID							int = 0,
			@maxRows						int = 0,
			@providingOrganizationName				varchar(80) = '',
			@projectOrganizationName				varchar(80) = '',
			@projectName						varchar(255) = '',
			@projectStartDate					varchar(25) = '',
			@projectEndDate					varchar(25) = '',
			@responsibleOrganizationName				varchar(80) = '',
			@maximumLocationLatitude				decimal(8,6) = 0,
			@maximumLocationLongitude				decimal(9,6) = 0,
			@minimumLocationLatitude				decimal(8,6) = 0,
			@minimumLocationLongitude				decimal(9,6) = 0,
			@locationDescriptorContext				varchar(30) = '',
			@locationDescriptorName				varchar(100) = '',
			@stationType						varchar(4000) = '',
			@stationName						varchar(255) = '',
			@samplingOrganizationName				varchar(80) = '',
			@fieldEventStartDate					varchar(25) = '',
			@fieldEventEndDate					varchar(25) = '',
			@sampledMedia						varchar(4000) = '',
			@analyteName						varchar(4000) = '',
			@sampledTaxon					varchar(4000) = '',
			@Deliminator						char(1) = '|'
			)
AS

SET NOCOUNT ON
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
/*	
	//////////////////////////////
	Who: Balaji Narayanan
	When: 2/1/2007
	Action: Rewrote the procedure to make it a dynamic SQL
	//////////////////////////////
*/
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Stored procedure syntax with parameters to get results in query analyzer, in this case for the ANALYTE NAME, "Indan"
--PNWWQX_GetMeasurementsData 0,-1,'','','','1/1/1753','12/31/9999','',60,-100,40,-140,'','','','','','1/1/1753','12/31/9999','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,10,'','','','','','',60,-100,40,-140,'','','','','','','','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,10,'','','','','','',0,0,0,0,'','','','','','','','','Mercury','',''
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	DECLARE	@_ProjectStartDate					datetime
	DECLARE	@_ProjectEndDate					datetime
	DECLARE	@_FieldEventStartDate					datetime
	DECLARE	@_FieldEventEndDate					datetime

	SET		@_ProjectStartDate =					CONVERT(datetime, @projectStartDate)
	SET		@_ProjectEndDate =					CONVERT(datetime, @projectEndDate)
	SET		@_FieldEventStartDate =				CONVERT(datetime, @fieldEventStartDate)
	SET		@_FieldEventEndDate =					CONVERT(datetime, @FieldEventEndDate)

	IF @maxRows > 0 SET ROWCOUNT  @maxRows

	-- TNB change start
	DECLARE	@sql_where						nvarchar(4000)
	DECLARE	@sql_select						nvarchar(4000)
	DECLARE	@sql_query						nvarchar(4000)
	DECLARE	@paramlist						nvarchar(4000)

	--the WHERE clause for the dynamic query
	SET @sql_where = 'WHERE 1 = 1 '

	IF ISNULL(@providingOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProvidingOrganizationName like @xProvidingOrganizationName '    

	IF ISNULL(@projectOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectOrganizationName like @xprojectOrganizationName '    

	IF ISNULL(@projectName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectName like @xProjectName '                                       

	IF ISNULL(@projectStartDate,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectStartDate >= @xProjectStartDate '

	IF ISNULL(@projectEndDate,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectEndDate <= @xProjectEndDate '                                    

	IF ISNULL(@responsibleOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND StationOrganizationName like @xResponsibleOrganizationName '   

	IF ISNULL(@maximumLocationLatitude, 0) <> 0 AND ISNULL(@maximumLocationLongitude, 0) <> 0 AND ISNULL(@minimumLocationLatitude, 0) <> 0 AND ISNULL(@minimumLocationLongitude, 0) <> 0
		SET @sql_where = @sql_where + 'AND LatitudeMeasure BETWEEN @xMinimumLocationLatitude AND @xMaximumLocationLatitude ' +  'AND LongitudeMeasure BETWEEN @xMinimumLocationLongitude AND @xMaximumLocationLongitude ' 
	
	IF ISNULL(@LocationDescriptorContext,'') <> ''
		SET @sql_where = @sql_where + 'AND LocationDescriptorContext like @xLocationDescriptorContext '   

	IF ISNULL(@LocationDescriptorName,'') <> ''
		SET @sql_where = @sql_where + 'AND LocationDescriptorName like @xLocationDescriptorName '  

	IF ISNULL(@stationType,'') <> ''
		SET @sql_where = @sql_where + 'AND StationType IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xStationType,@xDeliminator))'

	IF ISNULL(@stationName,'') <> ''
		SET @sql_where = @sql_where + 'AND StationName like @xStationName '   

	IF ISNULL(@samplingOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND FieldEventOrganizationName like @xSamplingOrganizationName '

	IF ISNULL(@fieldEventStartDate,'') <> '' 
		SET @sql_where = @sql_where + 'AND FieldEventStartDate >= @xFieldEventStartDate '

	IF ISNULL(@fieldEventEndDate,'') <> '' 
		SET @sql_where = @sql_where + 'AND FieldEventEndDate <= @xFieldEventEndDate '

	IF ISNULL(@sampledMedia,'') <> ''
		SET @sql_where = @sql_where + 'AND MediaText IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledMedia,@xDeliminator))'

	IF ISNULL(@analyteName,'') <> ''
		SET @sql_where = @sql_where + 'AND AnalyteName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xAnalyteName,@xDeliminator))'

	IF ISNULL(@sampledTaxon,'') <> ''
		SET @sql_where = @sql_where + 'AND (FieldEventBiologicalSystematicName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledTaxon,@xDeliminator)) 
						  OR ResultBiologicalSystematicName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledTaxon,@xDeliminator)))'

	--the SELECT clause for the dynamic query
	SET @sql_select =	'SELECT  DISTINCT  ProvidingOrganizationFK, ProjectFK, StationFK, ProjectContactEntityFK, StationContactEntityFK
		 		FROM PNWWQX_XtraJoinTable  '
	
	-- Declare Temp table to temporarily hold the theResultJoinList meeting the WHERE criteria
	-- We need this because using the EXEC the table variable cannot directly get the values (scope issue)
	CREATE TABLE	#StationJoinList
				(
				RowNumber					int IDENTITY (1, 1) Primary Key NOT NULL,
				ProvidingOrganizationPK				int NULL,
				ProjectPK					int NULL,
				StationPK					int NULL,
				ProjectContactEntityPK				int NULL,
				StationContactEntityPK				int NULL
				)
	
	--the parameter list for the dynamic query execution
	SELECT @paramlist =	'@xProvidingOrganizationName  nvarchar(80), ' +
				'@xProjectOrganizationName  nvarchar(80), ' +  
				'@xSamplingOrganizationName nvarchar(80), '   +
				'@xResponsibleOrganizationName nvarchar(80), '   +
				'@xProjectName nvarchar(255), '   +
				'@xStationName nvarchar(255), '   +
				'@xFieldEventStartDate datetime, ' +
				'@xFieldEventEndDate datetime, ' +
				'@xProjectStartDate datetime, ' +
				'@xProjectEndDate datetime, ' +
				'@xMaximumLocationLatitude  decimal(8,6), ' +
				'@xMaximumLocationLongitude  decimal(9,6), ' +
				'@xMinimumLocationLatitude  decimal(8,6), ' +
				'@xMinimumLocationLongitude decimal(9,6), ' +
				'@xLocationDescriptorContext nvarchar(30), ' +
				'@xLocationDescriptorName nvarchar(100), ' +
				'@xStationType nvarchar(4000), '  +
				'@xSampledMedia nvarchar(4000), '  +
				'@xSampledTaxon nvarchar(4000), '  +
				'@xAnalyteName nvarchar(4000), '  +
				'@xDeliminator char(1) '

	-- Build the dynamic SQL query by concatenating the SELECT & WHERE clauses --
	SET @sql_query = @sql_select + @sql_where
	
	-- Retrive the records that matched the criteria & store them into the temporary table --
	INSERT INTO		#StationJoinList
	EXEC sp_executesql	@sql_query,
				@paramlist,                                   
				@providingOrganizationName,    -- wildcards
				@projectOrganizationName,  -- wildcards
				@samplingOrganizationName, -- wildcards
				@responsibleOrganizationName, -- wildcards
				@projectName, -- wildcards
				@stationName, -- wildcards
				@_fieldEventStartDate,
				@_fieldEventEndDate,
				@_projectStartDate,
				@_projectEndDate,
				@maximumLocationLatitude,
				@maximumLocationLongitude,
				@minimumLocationLatitude,
				@minimumLocationLongitude,
				@LocationDescriptorContext,
				@LocationDescriptorName,
				@stationType, -- list
				@sampledMedia, -- list
				@sampledTaxon, -- list
				@analyteName, -- list
				@Deliminator
	
	-- TNB change end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	--Select from the desired rows for paging
	IF		@rowID > 0
	BEGIN
			DELETE
			FROM		#StationJoinList
			WHERE	RowNumber < @rowID
	END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	--Remove rowcount limit to allow all results back from following selects
	SET ROWCOUNT 0
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 0. Providing Organization 
	SELECT
	DISTINCT	PNWWQX_ProvidingOrganization.*
	FROM		PNWWQX_ProvidingOrganization
	INNER JOIN	PNWWQX_Project
	ON		PNWWQX_ProvidingOrganization.ProvidingOrganizationPK = PNWWQX_Project.ProvidingOrganizationFK
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		PNWWQX_Project.ProjectPK = theStationJoinList.ProjectPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 1. Projects 
	SELECT
	DISTINCT	PNWWQX_Project.*
	FROM		PNWWQX_Project
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.ProjectPK = PNWWQX_Project.ProjectPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 2. Stations 
	SELECT
	DISTINCT	PNWWQX_Station.*,
			theStationJoinList.ProvidingOrganizationPK		AS ProvidingOrganizationFK
	FROM		PNWWQX_Station
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.StationPK = PNWWQX_Station.StationPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 3. Well Detail 
	SELECT
	DISTINCT	PNWWQX_WellDetail.*
	FROM		PNWWQX_WellDetail
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.StationPK = PNWWQX_WellDetail.StationFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 4. Location Descriptors 
	SELECT
	DISTINCT	PNWWQX_LocationDescriptor.*
	FROM		PNWWQX_LocationDescriptor
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.StationPK = PNWWQX_LocationDescriptor.StationFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 5. Contact Entity
	SELECT
	DISTINCT	PNWWQX_ContactEntity.*,
			theStationJoinList.ProvidingOrganizationPK		AS ProvidingOrganizationFK,
			theStationJoinList.ProjectPK				AS ProjectFK,
			theStationJoinList.StationPK				AS StationFK
	FROM		PNWWQX_ContactEntity
	INNER JOIN	PNWWQX_Affiliation
	ON		PNWWQX_ContactEntity.ContactEntityPK = PNWWQX_Affiliation.ContactEntityFK
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.StationPK = PNWWQX_Affiliation.StationFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 6. Station Details Binary Large Object 
	SELECT
	DISTINCT	PNWWQX_BinaryLargeObject.*
	FROM		PNWWQX_BinaryLargeObject
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.StationPK = PNWWQX_BinaryLargeObject.StationFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 7. Project Station 
	SELECT
	DISTINCT	PNWWQX_ProjectStation.*
	FROM		dbo.PNWWQX_ProjectStation
	INNER JOIN	#StationJoinList						AS theStationJoinList
	ON		theStationJoinList.StationPK = PNWWQX_ProjectStation.StationFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- Drop the temporary table --
	DROP TABLE	#StationJoinList
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SET NOCOUNT OFF
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetRecordCount]    Script Date: 06/23/2009 13:34:59 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/*
	DESCRIPTION:	This user defined function developed for the node to parse strings that represent arrays with each element delimited by any desired character  into
			a table variable.  This allows an array of variables to be passed through a single stored procedure string variable.

	CREATED:	2004-01-09 by Windsor

	MODIFIED:	2007-01-05 by Bill Kellum
			Reformated for ease of reading.
*/
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE FUNCTION	[dbo].[fn_GetRecordCount] ( @table_nm varchar(100), @column_nm varchar(100))

RETURNS		int
AS
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN
	

	DECLARE	@recordCount	int
	DECLARE	@sql_statment	nvarchar(255)
	
	SET		@sql_statment = ' SELECT ' + @column_nm + ' FROM ' + @table_nm + ' WHERE Count_DT = (SELECT MAX(Count_DT) FROM ' + @table_nm + ')'

	EXEC sp_executesql @sql_statment

	RETURN	@recordCount

END
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_Utility_FilterByLastUpdate]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_Utility_FilterByLastUpdate](
	[PNWWQX_Table_NM] [varchar](50) NULL,
	[PNWWQX_Table_PK_ID] [int] NULL,
	[PNWWQX_Table_Last_Updated_DT] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ArrayToTable]    Script Date: 06/23/2009 13:34:59 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/*
	DESCRIPTION:	This user defined function developed for the node to parse strings that represent arrays with each element delimited by any desired character  into
			a table variable.  This allows an array of variables to be passed through a single stored procedure string variable.

	CREATED:	2004-01-09 by Windsor

	MODIFIED:	2007-01-05 by Bill Kellum
			Reformated for ease of reading.
*/
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE FUNCTION	[dbo].[fn_ArrayToTable] ( @array varchar(4000), @separator char(1) )

RETURNS		@ReturnValuesTable	TABLE
						(
						SomeValue		varchar(50)
						)
AS
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN
	
	DECLARE	@separator_position		int 		--This is used to locate each separator character
	DECLARE	@array_value			varchar(4000)	--This holds each array value as it is returned
	
	
	SET		@array = @array + @separator
	
	
	-- Loop through the string searching for separtor characters
	WHILE		PATINDEX('%' + @separator + '%' , @array) <> 0 
	BEGIN		
		-- patindex matches the a pattern against a string
		SELECT	@separator_position =  PATINDEX('%' + @separator + '%' , @array)
		SELECT	@array_value = LEFT(@array, @separator_position - 1)
		
		-- This is where you process the values passed.
		-- @array_value holds the value of this element of the array
		IF	(LEN(@array_value) > 0)

			BEGIN			
				INSERT INTO	@ReturnValuesTable (SomeValue) VALUES (@array_value)
			END
		
		-- This replaces what we just processed with and empty string
		SELECT	@array = STUFF(@array, 1, @separator_position, '')
	END

RETURN

END
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  Table [dbo].[PNWWQX_ContactEntity]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_ContactEntity](
	[ContactEntityPK] [int] NOT NULL,
	[ContactEntityIdentifier] [varchar](30) NOT NULL,
	[ContactOrganizationName] [varchar](80) NULL,
	[ContactEntityType] [varchar](20) NOT NULL,
	[ContactIndividualName] [varchar](70) NOT NULL,
	[MailingAddress] [varchar](50) NULL,
	[MailingAddressCityName] [varchar](30) NULL,
	[MailingAddressStateName] [varchar](35) NULL,
	[MailingAddressZIPCode] [varchar](14) NULL,
	[TelephoneNumber] [varchar](15) NOT NULL,
	[ElectronicMailAddressText] [varchar](100) NULL,
 CONSTRAINT [ContactEntityPK] PRIMARY KEY CLUSTERED 
(
	[ContactEntityPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_DataAccess]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_DataAccess](
	[DataSourceName] [varchar](60) NOT NULL,
	[DataSourceAccessMethod] [varchar](10) NOT NULL,
	[DataSourceLocation] [varchar](255) NULL,
	[AvailabilityDescription] [varchar](255) NULL,
	[RefreshDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_ProjectSummary]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_ProjectSummary](
	[ProjectIdentifier] [varchar](30) NOT NULL,
	[ProjectName] [varchar](255) NOT NULL,
	[ProjectStartDate] [datetime] NOT NULL,
	[ProjectEndDate] [datetime] NOT NULL,
	[ProjectContactOrganizationName] [varchar](80) NOT NULL,
	[ProvidingOrganizationFK] [int] NOT NULL,
 CONSTRAINT [PK_PNWWQX_DataCatalog_ProjectSummary] PRIMARY KEY CLUSTERED 
(
	[ProjectIdentifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_StationSummary]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_StationSummary](
	[StationIdentifier] [varchar](30) NOT NULL,
	[StationName] [varchar](255) NOT NULL,
	[StationType] [varchar](20) NOT NULL,
	[LatitudeMeasure] [decimal](8, 6) NOT NULL,
	[LongitudeMeasure] [decimal](9, 6) NOT NULL,
	[StationContactOrganizationName] [varchar](80) NULL,
	[ProvidingOrganizationFK] [int] NOT NULL,
 CONSTRAINT [PK_PNWWQX_DataCatalog_StationSummary] PRIMARY KEY CLUSTERED 
(
	[StationIdentifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_FieldEventSummary]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_FieldEventSummary](
	[FieldEventSummaryPK] [int] NOT NULL,
	[minFieldEventStartDate] [datetime] NOT NULL,
	[maxFieldEventEndDate] [datetime] NOT NULL,
	[MediaText] [varchar](30) NOT NULL,
	[BiologicalSystematicName] [varchar](200) NULL,
	[AnalyteName] [varchar](255) NULL,
	[NumberResults] [int] NULL,
	[FieldEventProjectIdentifier] [varchar](30) NOT NULL,
	[FieldEventStationIdentifier] [varchar](30) NOT NULL,
	[FieldEventContactOrganizationName] [varchar](80) NULL,
	[ProvidingOrganizationFK] [int] NULL,
 CONSTRAINT [PK_PNWWQX_DataCatalog_FieldEventSummary_FieldEventPK] PRIMARY KEY CLUSTERED 
(
	[FieldEventSummaryPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_DataCatalog_StationLocationDescriptor]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_DataCatalog_StationLocationDescriptor](
	[LocationDescriptorName] [varchar](100) NOT NULL,
	[LocationDescriptorContext] [varchar](30) NOT NULL,
	[StationSummaryIdentifier] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_Project]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_Project](
	[ProjectPK] [int] NOT NULL,
	[ProjectIdentifier] [varchar](30) NOT NULL,
	[ProjectName] [varchar](255) NOT NULL,
	[ProjectDescription] [varchar](255) NOT NULL,
	[ProjectQAPPIndicator] [varchar](5) NOT NULL,
	[ProjectQAPPDescription] [varchar](255) NULL,
	[ProjectStartDate] [datetime] NOT NULL,
	[ProjectEndDate] [datetime] NOT NULL,
	[ProjectAreaDescription] [varchar](255) NULL,
	[ProjectContactIdentifier] [varchar](30) NOT NULL,
	[PrimaryDataSourceIndicator] [varchar](5) NOT NULL,
	[ProvidingOrganizationFK] [int] NOT NULL,
 CONSTRAINT [ProjectPK] PRIMARY KEY CLUSTERED 
(
	[ProjectPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_ProjectStation]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_ProjectStation](
	[ProjectFK] [int] NOT NULL,
	[StationFK] [int] NOT NULL,
	[StationProjectIdentifier] [varchar](50) NULL,
 CONSTRAINT [PK_PNWWQX_ProjectStation] PRIMARY KEY CLUSTERED 
(
	[ProjectFK] ASC,
	[StationFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_FieldEvent](
	[FieldEventPK] [int] NOT NULL,
	[FieldEventStartDate] [datetime] NOT NULL,
	[FieldEventStartTimeZone] [varchar](3) NOT NULL,
	[FieldEventEndDate] [datetime] NOT NULL,
	[FieldEventEndTimeZone] [varchar](3) NOT NULL,
	[FieldEventTypeText] [varchar](80) NOT NULL,
	[SampleIdentificationText] [varchar](12) NULL,
	[MediaText] [varchar](30) NOT NULL,
	[BiologicalSystematicName] [varchar](200) NULL,
	[BiologicalSystematicContextName] [varchar](200) NULL,
	[BiologicalSystematicIdentifier] [varchar](15) NULL,
	[FieldEventUpperDepthMeasure] [numeric](18, 0) NULL,
	[FieldEventLowerDepthMeasure] [numeric](18, 0) NULL,
	[FieldEventDepthUnitMeasureName] [varchar](10) NULL,
	[FieldEventDepthComment] [varchar](255) NULL,
	[FieldEventNotes] [varchar](255) NULL,
	[MethodCode] [varchar](30) NULL,
	[MethodContext] [varchar](255) NULL,
	[MethodDescription] [varchar](255) NULL,
	[FieldEventProjectIdentifier] [varchar](30) NOT NULL,
	[FieldEventStationIdentifier] [varchar](30) NOT NULL,
	[FieldEventContactIdentifier] [varchar](30) NULL,
	[ProjectFK] [int] NOT NULL,
	[StationFK] [int] NOT NULL,
 CONSTRAINT [FieldEventPK] PRIMARY KEY CLUSTERED 
(
	[FieldEventPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_Result]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_Result](
	[ResultPK] [int] NOT NULL,
	[ResultValueMeasure] [varchar](255) NOT NULL,
	[ResultValueSignificantDigitsNumber] [numeric](10, 0) NULL,
	[ResultUnitMeasureName] [varchar](10) NOT NULL,
	[ResultQualifier] [varchar](255) NULL,
	[AnalyteIdentifier] [varchar](30) NULL,
	[AnalyteName] [varchar](255) NOT NULL,
	[AnalyteContextName] [varchar](255) NOT NULL,
	[BiologicalSystematicName] [varchar](200) NULL,
	[BiologicalSystematicContextName] [varchar](200) NULL,
	[BiologicalSystematicIdentifier] [varchar](30) NULL,
	[ResultQualityAssessment] [varchar](50) NOT NULL,
	[ResultStatus] [varchar](255) NOT NULL,
	[ResultAvailabilityDescription] [varchar](255) NOT NULL,
	[MethodCode] [varchar](30) NULL,
	[MethodContext] [varchar](255) NULL,
	[MethodDescription] [varchar](255) NULL,
	[QAQCExceptionIndicator] [varchar](5) NOT NULL,
	[QAQCExceptionCommentText] [varchar](255) NULL,
	[FieldEventFK] [int] NOT NULL,
 CONSTRAINT [ResultPK] PRIMARY KEY CLUSTERED 
(
	[ResultPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_XtraJoinTable]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_XtraJoinTable](
	[RowNum] [int] IDENTITY(1,1) NOT NULL,
	[ResultFK] [int] NOT NULL,
	[FieldEventFK] [int] NOT NULL,
	[StationFK] [int] NOT NULL,
	[ProjectFK] [int] NOT NULL,
	[ProvidingOrganizationFK] [int] NOT NULL,
	[ProjectContactEntityFK] [int] NOT NULL,
	[StationContactEntityFK] [int] NULL,
	[FieldEventContactEntityFK] [int] NOT NULL,
	[ProvidingOrganizationName] [varchar](80) NOT NULL,
	[ProjectName] [varchar](255) NOT NULL,
	[ProjectStartDate] [datetime] NOT NULL,
	[ProjectEndDate] [datetime] NOT NULL,
	[ProjectOrganizationName] [varchar](80) NOT NULL,
	[FieldEventOrganizationName] [varchar](80) NOT NULL,
	[StationOrganizationName] [varchar](80) NOT NULL,
	[StationName] [varchar](255) NOT NULL,
	[StationType] [varchar](20) NOT NULL,
	[LatitudeMeasure] [decimal](8, 6) NOT NULL,
	[LongitudeMeasure] [decimal](9, 6) NOT NULL,
	[LocationDescriptorName] [varchar](100) NOT NULL,
	[LocationDescriptorContext] [varchar](30) NOT NULL,
	[FieldEventStartDate] [datetime] NOT NULL,
	[FieldEventEndDate] [datetime] NOT NULL,
	[MediaText] [varchar](30) NOT NULL,
	[FieldEventBiologicalSystematicName] [varchar](200) NOT NULL,
	[ResultValueMeasure] [varchar](255) NOT NULL,
	[AnalyteIdentifier] [varchar](30) NULL,
	[AnalyteName] [varchar](255) NOT NULL,
	[ResultBiologicalSystematicName] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PNWWQX_XtraJoinTable] PRIMARY KEY NONCLUSTERED 
(
	[RowNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IX_PNWWQX_XtraJoinTable] ON [dbo].[PNWWQX_XtraJoinTable] 
(
	[AnalyteName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PNW_FEBiologicalSystematicName] ON [dbo].[PNWWQX_XtraJoinTable] 
(
	[FieldEventBiologicalSystematicName] ASC
)
INCLUDE ( [ProjectName],
[ProjectStartDate],
[ProjectEndDate],
[StationType],
[LatitudeMeasure],
[LongitudeMeasure],
[MediaText]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PNWWQX_XtraJoinTable_Lat] ON [dbo].[PNWWQX_XtraJoinTable] 
(
	[LatitudeMeasure] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PNWWQX_XtraJoinTable_Long] ON [dbo].[PNWWQX_XtraJoinTable] 
(
	[LongitudeMeasure] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNWWQX_SamplePreparationMethod]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_SamplePreparationMethod](
	[MethodCode] [varchar](30) NULL,
	[MethodContext] [varchar](255) NULL,
	[MethodDescription] [varchar](255) NULL,
	[FieldEventFK] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IX_PNWWQX_SamplePreparationMethod] ON [dbo].[PNWWQX_SamplePreparationMethod] 
(
	[FieldEventFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNWWQX_SamplePreservationMethod]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_SamplePreservationMethod](
	[MethodCode] [varchar](30) NULL,
	[MethodContext] [varchar](255) NULL,
	[MethodDescription] [varchar](255) NULL,
	[FieldEventFK] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE CLUSTERED INDEX [IX_PNWWQX_SamplePreservationMethod] ON [dbo].[PNWWQX_SamplePreservationMethod] 
(
	[FieldEventFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNWWQX_BinaryLargeObject]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_BinaryLargeObject](
	[name] [varchar](255) NULL,
	[type] [varchar](5) NULL,
	[content] [varbinary](1) NULL,
	[BinaryObjectURL] [varchar](100) NULL,
	[BinaryObjectSize] [numeric](10, 0) NULL,
	[BinaryObjectTitleText] [varchar](255) NULL,
	[BinaryObjectCreator] [varchar](100) NULL,
	[BinaryObjectSubject] [varchar](100) NULL,
	[BinaryObjectDescription] [varchar](255) NULL,
	[BinaryObjectPublisher] [varchar](12) NULL,
	[BinaryObjectContributor] [varchar](50) NULL,
	[BinaryObjectDate] [datetime] NULL,
	[BinaryObjectType] [varchar](100) NULL,
	[BinaryObjectContentTypeText] [varchar](100) NULL,
	[BinaryObjectIdentifierText] [varchar](12) NULL,
	[BinaryObjectSource] [varchar](100) NULL,
	[BinaryObjectLanguage] [varchar](20) NULL,
	[BinaryObjectRelation] [varchar](100) NULL,
	[BinaryObjectCoverage] [varchar](100) NULL,
	[BinaryObjectRights] [varchar](100) NULL,
	[ProjectFK] [int] NULL,
	[StationFK] [int] NULL,
	[FieldEventFK] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PNWWQX_BinaryLargeObject_FEFK] ON [dbo].[PNWWQX_BinaryLargeObject] 
(
	[FieldEventFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PNWWQX_BinaryLargeObject_ProjectFK] ON [dbo].[PNWWQX_BinaryLargeObject] 
(
	[ProjectFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PNWWQX_BinaryLargeObject_StationFK] ON [dbo].[PNWWQX_BinaryLargeObject] 
(
	[StationFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNWWQX_Affiliation]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PNWWQX_Affiliation](
	[ContactEntityFK] [int] NOT NULL,
	[ProjectFK] [int] NULL,
	[StationFK] [int] NULL,
	[FieldEventFK] [int] NULL,
	[ResultFK] [int] NULL
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IX_ResultFK] ON [dbo].[PNWWQX_Affiliation] 
(
	[ResultFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNWWQX_ProjectAnalyte]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_ProjectAnalyte](
	[AnalyteIdentifier] [varchar](35) NULL,
	[AnalyteName] [varchar](255) NOT NULL,
	[AnalyteContextName] [varchar](255) NOT NULL,
	[ProjectFK] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_ResultDetectionLevel]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_ResultDetectionLevel](
	[ResultDetectionLevelPK] [int] NOT NULL,
	[DetectionQuantitationLevelMeasure] [numeric](18, 0) NOT NULL,
	[DetectionQuantitationLevelUnitMeasureName] [varchar](10) NOT NULL,
	[DetectionQuantitationLevelTypeText] [varchar](60) NOT NULL,
	[ResultFK] [int] NOT NULL,
 CONSTRAINT [ResultDetectionLevelPK] PRIMARY KEY CLUSTERED 
(
	[ResultDetectionLevelPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_LocationDescriptor]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_LocationDescriptor](
	[LocationDescriptorName] [varchar](100) NOT NULL,
	[LocationDescriptorContext] [varchar](30) NOT NULL,
	[StationFK] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNWWQX_WellDetail]    Script Date: 06/23/2009 13:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNWWQX_WellDetail](
	[WellDetailPK] [int] NOT NULL,
	[WellIdentifier] [varchar](30) NULL,
	[WellIdentifierContext] [varchar](30) NOT NULL,
	[WellDepthCompletionMeasure] [numeric](18, 0) NULL,
	[WellOpenIntervalType] [varchar](60) NULL,
	[WellDepthTopOpenIntervalMeasure] [numeric](18, 0) NULL,
	[WellDepthBottomOpenIntervalMeasure] [numeric](18, 0) NULL,
	[WellDepthUnitMeasureName] [varchar](10) NULL,
	[WellDiameterMeasure] [numeric](18, 0) NULL,
	[WellDiameterUnitMeasureName] [varchar](10) NULL,
	[WellStatus] [varchar](10) NOT NULL,
	[WellUse] [varchar](30) NOT NULL,
	[StationFK] [int] NOT NULL,
 CONSTRAINT [WellDetailPK] PRIMARY KEY CLUSTERED 
(
	[WellDetailPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PNW_WellDetail_StationFK] ON [dbo].[PNWWQX_WellDetail] 
(
	[StationFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PNWWQX_GetDataCatalog]    Script Date: 06/23/2009 13:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.PNWWQX_Get_DataCatalog    Script Date: 8/10/2004 8:26:13 AM ******/



CREATE PROCEDURE [dbo].[PNWWQX_GetDataCatalog] AS

SELECT * FROM PNWWQX_ProvidingOrganization
SELECT * FROM PNWWQX_DataCatalog_ProjectSummary
SELECT * FROM PNWWQX_DataCatalog_StationSummary
SELECT * FROM PNWWQX_DataCatalog_StationLocationDescriptor
SELECT * FROM PNWWQX_DataCatalog_FieldEventSummary
SELECT * FROM PNWWQX_DataCatalog_DataAccess
GO
/****** Object:  StoredProcedure [dbo].[PNWWQX_GetMeasurementsData]    Script Date: 06/23/2009 13:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE	[dbo].[PNWWQX_GetMeasurementsData]
			(
			@rowID							int = 0,
			@maxRows						int = 0,
			@providingOrganizationName				varchar(80) = '',
			@projectOrganizationName				varchar(80) = '',
			@projectName						varchar(255) = '',
			@projectStartDate					varchar(25) = '',
			@projectEndDate					varchar(25) = '',
			@responsibleOrganizationName				varchar(80) = '',
			@maximumLocationLatitude				decimal(8,6) = 0,
			@maximumLocationLongitude				decimal(9,6) = 0,
			@minimumLocationLatitude				decimal(8,6) = 0,
			@minimumLocationLongitude				decimal(9,6) = 0,
			@locationDescriptorContext				varchar(30) = '',
			@locationDescriptorName				varchar(100) = '',
			@stationType						varchar(4000) = '',
			@stationName						varchar(255) = '',
			@samplingOrganizationName				varchar(80) = '',
			@fieldEventStartDate					varchar(25) = '',
			@fieldEventEndDate					varchar(25) = '',
			@sampledMedia						varchar(4000) = '',
			@analyteName						varchar(4000) = '',
			@sampledTaxon					varchar(4000) = '',
			@Deliminator						char(1) = '|'
			)
AS
SET NOCOUNT ON
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
/*	
	//////////////////////////////
	Who: Balaji Narayanan
	When: 2/1/2007
	Action: Rewrote the procedure to make it a dynamic SQL
	//////////////////////////////
*/
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Stored procedure syntax with parameters to get results in query analyzer, in this case for the ANALYTE NAME, "Indan"
--PNWWQX_GetMeasurementsData 0,-1,'','','','1/1/1753','12/31/9999','',60,-100,40,-140,'','','','','','1/1/1753','12/31/9999','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,10,'','','','','','',60,-100,40,-140,'','','','','','','','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,10,'','','','','','',0,0,0,0,'','','','','','','','','Mercury','',''
--PNWWQX_GetMeasurementsData 0,300,'','','Deschutes River Watershed (WRIA 13), multi-parameter TMDL','','','',60,-100,40,-140,'','','Groundwater','AHT007 (INSTREAM PIEZOMETER)','','','','Water','Temperature, water (daily average)',''
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	DECLARE	@_ProjectStartDate					datetime
	DECLARE	@_ProjectEndDate					datetime
	DECLARE	@_FieldEventStartDate					datetime
	DECLARE	@_FieldEventEndDate					datetime

	SET		@_ProjectStartDate =					CONVERT(datetime, @projectStartDate)
	SET		@_ProjectEndDate =					CONVERT(datetime, @projectEndDate)
	SET		@_FieldEventStartDate =				CONVERT(datetime, @fieldEventStartDate)
	SET		@_FieldEventEndDate =					CONVERT(datetime, @FieldEventEndDate)

	IF @maxRows > 0 SET ROWCOUNT  @maxRows

	-- TNB change start
	DECLARE	@sql_where						nvarchar(4000)
	DECLARE	@sql_select						nvarchar(4000)
	DECLARE	@sql_query						nvarchar(4000)
	DECLARE	@paramlist						nvarchar(4000)

	--the WHERE clause for the dynamic query
	SET @sql_where = 'WHERE 1 = 1 '

	IF ISNULL(@providingOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProvidingOrganizationName like @xProvidingOrganizationName '    

	IF ISNULL(@projectOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectOrganizationName like @xprojectOrganizationName '    

	IF ISNULL(@projectName,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectName like @xProjectName '                                       

	IF ISNULL(@projectStartDate,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectStartDate >= @xProjectStartDate '

	IF ISNULL(@projectEndDate,'') <> ''
		SET @sql_where = @sql_where + 'AND ProjectEndDate <= @xProjectEndDate '                                    

	IF ISNULL(@responsibleOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND StationOrganizationName like @xResponsibleOrganizationName '   

	IF ISNULL(@maximumLocationLatitude, 0) <> 0 AND ISNULL(@maximumLocationLongitude, 0) <> 0 AND ISNULL(@minimumLocationLatitude, 0) <> 0 AND ISNULL(@minimumLocationLongitude, 0) <> 0
		SET @sql_where = @sql_where + 'AND LatitudeMeasure BETWEEN @xMinimumLocationLatitude AND @xMaximumLocationLatitude ' +  'AND LongitudeMeasure BETWEEN @xMinimumLocationLongitude AND @xMaximumLocationLongitude ' 
	
	IF ISNULL(@LocationDescriptorContext,'') <> ''
		SET @sql_where = @sql_where + 'AND LocationDescriptorContext like @xLocationDescriptorContext '   

	IF ISNULL(@LocationDescriptorName,'') <> ''
		SET @sql_where = @sql_where + 'AND LocationDescriptorName like @xLocationDescriptorName '  

	IF ISNULL(@stationType,'') <> ''
		SET @sql_where = @sql_where + 'AND StationType IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xStationType,@xDeliminator))'

	IF ISNULL(@stationName,'') <> ''
		SET @sql_where = @sql_where + 'AND StationName like @xStationName '   

	IF ISNULL(@samplingOrganizationName,'') <> ''
		SET @sql_where = @sql_where + 'AND FieldEventOrganizationName like @xSamplingOrganizationName '

	IF ISNULL(@fieldEventStartDate,'') <> '' 
		SET @sql_where = @sql_where + 'AND FieldEventStartDate >= @xFieldEventStartDate '

	IF ISNULL(@fieldEventEndDate,'') <> '' 
		SET @sql_where = @sql_where + 'AND FieldEventEndDate <= @xFieldEventEndDate '

	IF ISNULL(@sampledMedia,'') <> ''
		SET @sql_where = @sql_where + 'AND MediaText IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledMedia,@xDeliminator))'

	IF ISNULL(@analyteName,'') <> ''
		SET @sql_where = @sql_where + 'AND AnalyteName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xAnalyteName,@xDeliminator))'

	IF ISNULL(@sampledTaxon,'') <> ''
		SET @sql_where = @sql_where + 'AND (FieldEventBiologicalSystematicName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledTaxon,@xDeliminator)) 
						  OR ResultBiologicalSystematicName IN (SELECT SomeValue FROM dbo.fn_ArrayToTable(@xSampledTaxon,@xDeliminator)))'

	--the SELECT clause for the dynamic query
	SET @sql_select =	'SELECT ResultFK, ProjectFK, ProvidingOrganizationFK, StationFK, FieldEventFK, ProjectContactEntityFK, StationContactEntityFK, FieldEventContactEntityFK
			  	FROM PNWWQX_XtraJoinTable  '

	
	-- Declare Temp table to temporarily hold the theResultJoinList meeting the WHERE criteria
	-- We need this because using the EXEC the table variable cannot directly get the values (scope issue)
	CREATE TABLE	#ResultJoinList
				(
				RowNumber					int IDENTITY (1, 1) Primary Key NOT NULL,
				ResultPK					int NULL,
				ProjectPK					int NULL,
				ProvidingOrganizationPK				int NULL,
				StationPK					int NULL,
				FieldEventPK					int NULL,
				ProjectContactEntityPK				int NULL,
				StationContactEntityPK				int NULL,
				FieldEventContactEntityPK			int NULL
				)
	
	--the parameter list for the dynamic query execution
	SELECT @paramlist =	'@xProvidingOrganizationName  nvarchar(80), ' +
				'@xProjectOrganizationName  nvarchar(80), ' +  
				'@xSamplingOrganizationName nvarchar(80), '   +
				'@xResponsibleOrganizationName nvarchar(80), '   +
				'@xProjectName nvarchar(255), '   +
				'@xStationName nvarchar(255), '   +
				'@xFieldEventStartDate datetime, ' +
				'@xFieldEventEndDate datetime, ' +
				'@xProjectStartDate datetime, ' +
				'@xProjectEndDate datetime, ' +
				'@xMaximumLocationLatitude  decimal(8,6), ' +
				'@xMaximumLocationLongitude  decimal(9,6), ' +
				'@xMinimumLocationLatitude  decimal(8,6), ' +
				'@xMinimumLocationLongitude decimal(9,6), ' +
				'@xLocationDescriptorContext nvarchar(30), ' +
				'@xLocationDescriptorName nvarchar(100), ' +
				'@xStationType nvarchar(4000), '  +
				'@xSampledMedia nvarchar(4000), '  +
				'@xSampledTaxon nvarchar(4000), '  +
				'@xAnalyteName nvarchar(4000), '  +
				'@xDeliminator char(1) '

	-- Build the dynamic SQL query by concatenating the SELECT & WHERE clauses --
	SET @sql_query = @sql_select + @sql_where
	
	-- Retrive the records that matched the criteria & store them into the temporary table --
	INSERT INTO		#ResultJoinList
	EXEC sp_executesql	@sql_query,
				@paramlist,                                   
				@providingOrganizationName,    -- wildcards
				@projectOrganizationName,  -- wildcards
				@samplingOrganizationName, -- wildcards
				@responsibleOrganizationName, -- wildcards
				@projectName, -- wildcards
				@stationName, -- wildcards
				@_fieldEventStartDate,
				@_fieldEventEndDate,
				@_projectStartDate,
				@_projectEndDate,
				@maximumLocationLatitude,
				@maximumLocationLongitude,
				@minimumLocationLatitude,
				@minimumLocationLongitude,
				@LocationDescriptorContext,
				@LocationDescriptorName,
				@stationType, -- list
				@sampledMedia, -- list
				@sampledTaxon, -- list
				@analyteName, -- list
				@Deliminator
	
	-- TNB change end
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	--Select from the desired rows for paging
	IF		@rowID > 0
	BEGIN
			DELETE
			FROM		#ResultJoinList
			WHERE	RowNumber < @rowID
	END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	--Remove rowcount limit to allow all results back from following selects
	SET ROWCOUNT 0
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 0. Providing Organization 
	SELECT
	DISTINCT	PNWWQX_ProvidingOrganization.*
	FROM		PNWWQX_ProvidingOrganization
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.ProvidingOrganizationPK = PNWWQX_ProvidingOrganization.ProvidingOrganizationPK
	ORDER BY	PNWWQX_ProvidingOrganization.ProvidingOrganizationName
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 1. Projects 
	SELECT
	DISTINCT	PNWWQX_Project.*
	FROM		PNWWQX_Project
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.ProjectPK = PNWWQX_Project.ProjectPK
	ORDER BY	PNWWQX_Project.ProjectName
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 2. Stations 
	SELECT
	DISTINCT	PNWWQX_Station.*,
			theResultJoinList.ProvidingOrganizationPK		AS ProvidingOrganizationFK
	FROM		PNWWQX_Station
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.StationPK = PNWWQX_Station.StationPK
	ORDER BY	PNWWQX_Station.StationName
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 3. Well Detail 
	SELECT
	DISTINCT	PNWWQX_WellDetail.*
	FROM		PNWWQX_WellDetail
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.StationPK = PNWWQX_WellDetail.StationFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 4. Location Descriptors 
	IF (SELECT COUNT(*) FROM PNWWQX_LocationDescriptor) > 0		--IF clause test for data because no data yet exists for this table
		BEGIN
			SELECT
			DISTINCT	PNWWQX_LocationDescriptor.*
			FROM		PNWWQX_LocationDescriptor
			INNER JOIN	#ResultJoinList				AS theResultJoinList
			ON		theResultJoinList.StationPK = PNWWQX_LocationDescriptor.StationFK
		END
	ELSE
		BEGIN
			SELECT	*
			FROM		PNWWQX_LocationDescriptor
		END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 5. Field Events 
	SELECT
	DISTINCT	PNWWQX_FieldEvent.*,
			theResultJoinList.ProvidingOrganizationPK		AS ProvidingOrganizationFK
	FROM		PNWWQX_FieldEvent
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.FieldEventPK = PNWWQX_FieldEvent.FieldEventPK
	ORDER BY	PNWWQX_FieldEvent.FieldEventStartDate
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 6. Contact Entity
	SELECT
	DISTINCT	PNWWQX_ContactEntity.*, 
			theResultJoinList.ProvidingOrganizationPK		AS ProvidingOrganizationFK,
			theResultJoinList.ProjectPK				AS ProjectFK,
			theResultJoinList.StationPK				AS StationFK,
			theResultJoinList.FieldEventPK				AS FieldEventFK
	FROM		PNWWQX_ContactEntity
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	--ON		theResultJoinList.ProjectContactEntityPK = PNWWQX_ContactEntity.ContactEntityPK	--optimization, no records exist yet for this join
	--OR		theResultJoinList.StationContactEntityPK = PNWWQX_ContactEntity.ContactEntityPK	--optimization, no records exist yet for this join
	ON		theResultJoinList.FieldEventContactEntityPK = PNWWQX_ContactEntity.ContactEntityPK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 7. Project Details Binary Large Object 
	SELECT
	DISTINCT	PNWWQX_BinaryLargeObject.*
	FROM		PNWWQX_BinaryLargeObject
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.ProjectPK = PNWWQX_BinaryLargeObject.ProjectFK
	--OR		theResultJoinList.FieldEventPK = PNWWQX_BinaryLargeObject.FieldEventFK		--optimization, no records exist yet for this join
	--OR		theResultJoinList.StationPK = PNWWQX_BinaryLargeObject.StationFK			--optimization, no records exist yet for this join
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 8. Results 
	SELECT
	DISTINCT	PNWWQX_Result.*,
			PNWWQX_ContactEntity.ContactEntityIdentifier
	FROM		PNWWQX_Result
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.ResultPK = PNWWQX_Result.ResultPK
	AND		theResultJoinList.FieldEventPK = PNWWQX_Result.FieldEventFK
	INNER JOIN	PNWWQX_ContactEntity
	ON		theResultJoinList.FieldEventContactEntityPK = PNWWQX_ContactEntity.ContactEntityPK
	ORDER BY	PNWWQX_Result.AnalyteName,
			PNWWQX_Result.ResultValueMeasure
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- 9. Detection Levels 
	IF (SELECT COUNT(*) FROM PNWWQX_ResultDetectionLevel) > 0	--IF clause test for data because no data yet exists for this table
		BEGIN
			SELECT	PNWWQX_ResultDetectionLevel.*
			FROM		PNWWQX_ResultDetectionLevel
			INNER JOIN	#ResultJoinList				AS theResultJoinList
			ON		theResultJoinList.ResultPK = PNWWQX_ResultDetectionLevel.ResultFK
		END
	ELSE
		BEGIN
			SELECT	*
			FROM		PNWWQX_ResultDetectionLevel
		END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	-- 10. Sample Preparation Method 
	SELECT
	DISTINCT	PNWWQX_SamplePreparationMethod.*
	FROM		PNWWQX_SamplePreparationMethod
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.FieldEventPK = PNWWQX_SamplePreparationMethod.FieldEventFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	-- 11. Sample Preservation Method 
	SELECT
	DISTINCT	PNWWQX_SamplePreservationMethod.*
	FROM		PNWWQX_SamplePreservationMethod
	INNER JOIN	#ResultJoinList						AS theResultJoinList
	ON		theResultJoinList.FieldEventPK = PNWWQX_SamplePreservationMethod.FieldEventFK
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- Drop the temporary table --
	DROP TABLE	#ResultJoinList
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SET NOCOUNT OFF
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ADMIN_CountFlowLoadByParameter]    Script Date: 06/23/2009 13:34:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------
CREATE
PROCEDURE	[dbo].[ADMIN_CountFlowLoadByParameter]
			@FlowName		varchar(25)
AS
SET NOCOUNT ON
---------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------
--	Supply any flow name parameter: 'DOH', 'FRS', 'PNWWQX', 'RCRA', or 'Wastex' to count that flow
--	Supply as parameter: '%' to count all flows

BEGIN
	DECLARE		@i			int
	DECLARE		@CountDate	datetime
	DECLARE		@TableCount	int
	DECLARE		@TableName	varchar(100)
	DECLARE		@SQLText	nvarchar(255)
	DECLARE		@TableList	TABLE
				(
				Table_ID	int identity(1, 1),
				Table_NM	varchar(100)
				)

	SET			@i = 1
	SET			@CountDate = GETDATE()
	
	INSERT INTO	@TableList
				(
				Table_NM
				)
	SELECT		name
	FROM		sysobjects
	WHERE		xtype = 'U'
	AND			name NOT LIKE '%Count%'				--eliminate previous count method tables
	AND			name != 'RCRA__LoadDivisionControl'	--eliminate loading utility table
	AND			name LIKE @FlowName + '%'
	ORDER BY	name

--select * from @TableList

	SET			@TableCount = (SELECT COUNT(*) FROM @TableList)

	WHILE @i <= @TableCount
		BEGIN
			SET			@TableName = (SELECT Table_NM FROM @TableList WHERE Table_ID = @i)
			SET			@SQLText = 'SELECT ''' + @TableName + ''', (SELECT COUNT(*) FROM ' + @TableName + '), ''' + CONVERT(varchar,@CountDate) + ''''

			INSERT INTO	ADMIN_NodeFlowLoadCount
						(
						TABLE_NAME_NM,
						RECORD_COUNT_QT,
						COUNT_DATE_DT
						)
			EXEC		sp_executesql @SQLText

--print @SQLText

			SET			@i = @i + 1					
		END
END
---------------------------------------------------------------------------------------------------
--]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
---------------------------------------------------------------------------------------------------
SET NOCOUNT OFF


--TEST COMMANDS:

--exec ADMIN_CountFlowLoadByParameter 'doh'

--exec ADMIN_CountFlowLoadByParameter '%'

--select * from ADMIN_NodeFlowLoadCount

--select * from ADMIN_NodeFlowLoadCount where table_name_nm like 'RCRA_%' and count_date_dt = (select max(count_date_dt) from admin_nodeflowloadcount where table_name_nm like 'RCRA_%')

--truncate table ADMIN_NodeFlowLoadCount
GO
/****** Object:  StoredProcedure [dbo].[ADMIN_GetFlowRecordTotalsOverTime]    Script Date: 06/23/2009 13:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	====================================================================================================================
-- Author:		bkel461
-- Create date: 20070417
-- Description:	<Description,,>
--	====================================================================================================================
CREATE PROCEDURE [dbo].[ADMIN_GetFlowRecordTotalsOverTime]
AS
BEGIN
SET NOCOUNT ON;
--	====================================================================================================================
	declare @FlowDateList table (ID int identity(1,1), FlowPrefix varchar(25), CountDate datetime, Description_DS varchar(25))
	--drop table #FlowDateList
	--create table #FlowDateList (ID int identity(1,1), FlowPrefix varchar(25), CountDate datetime, Description_DS varchar(25))
--	====================================================================================================================

	--get the last load date for each flow:
	insert into @FlowDateList
		select 'doh', max(count_date_dt), 'Last'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'doh%'
	union
		select 'frs', max(count_date_dt), 'Last'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'frs%'
	union
		select 'pnw', max(count_date_dt), 'Last'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'pnw%'
	union
		select 'rcr', max(count_date_dt), 'Last'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'rcr%'
	union
		select 'was', max(count_date_dt), 'Last'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'was%'

--	select * from @FlowDateList

--	====================================================================================================================

	--get the previous to last load date for each flow:
	insert into @FlowDateList
		select 'doh', max(count_date_dt), 'Previous'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'doh%'
		and count_date_dt not in
			(select max(count_date_dt)
			from dbo.ADMIN_NodeFlowLoadCount
			where table_name_nm like 'doh%')
	union
		select 'frs', max(count_date_dt), 'Previous'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'frs%'
		and count_date_dt not in
			(select max(count_date_dt)
			from dbo.ADMIN_NodeFlowLoadCount
			where table_name_nm like 'frs%')
	union
		select 'pnw', max(count_date_dt), 'Previous'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'pnw%'
		and count_date_dt not in
			(select max(count_date_dt)
			from dbo.ADMIN_NodeFlowLoadCount
			where table_name_nm like 'pnw%')
	union
		select 'rcr', max(count_date_dt), 'Previous'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'rcr%'
		and count_date_dt not in
			(select max(count_date_dt)
			from dbo.ADMIN_NodeFlowLoadCount
			where table_name_nm like 'rcr%')
	union
		select 'was', max(count_date_dt), 'Previous'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'was%'
		and count_date_dt not in
			(select max(count_date_dt)
			from dbo.ADMIN_NodeFlowLoadCount
			where table_name_nm like 'was%')

--	select * from @FlowDateList

--	====================================================================================================================

	--get the last load date prior to one week ago for each flow:
	insert into @FlowDateList
		select 'doh', max(count_date_dt), 'Week'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'doh%'
		and count_date_dt <= getdate() - 7
	union
		select 'frs', max(count_date_dt), 'Week'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'frs%'
		and count_date_dt <= getdate() - 7
	union
		select 'pnw', max(count_date_dt), 'Week'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'pnw%'
		and count_date_dt <= getdate() - 7
	union
		select 'rcr', max(count_date_dt), 'Week'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'rcr%'
		and count_date_dt <= getdate() - 7
	union
		select 'was', max(count_date_dt), 'Week'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'was%'
		and count_date_dt <= getdate() - 7

--	select * from @FlowDateList

--	====================================================================================================================

	--get the last load date prior to one Month ago for each flow:
	insert into @FlowDateList
		select 'doh', max(count_date_dt), 'Month'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'doh%'
		and count_date_dt <= getdate() - 31
	union
		select 'frs', max(count_date_dt), 'Month'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'frs%'
		and count_date_dt <= getdate() - 31
	union
		select 'pnw', max(count_date_dt), 'Month'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'pnw%'
		and count_date_dt <= getdate() - 31
	union
		select 'rcr', max(count_date_dt), 'Month'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'rcr%'
		and count_date_dt <= getdate() - 31
	union
		select 'was', max(count_date_dt), 'Month'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'was%'
		and count_date_dt <= getdate() - 31

--	select * from @FlowDateList

--	====================================================================================================================

	--get the last load date prior to one year ago for each flow:
	insert into @FlowDateList
		select 'doh', isnull(max(count_date_dt),''), 'Year'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'doh%'
		and count_date_dt <= getdate() - 365
	union
		select 'frs', isnull(max(count_date_dt),''), 'Year'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'frs%'
		and count_date_dt <= getdate() - 365
	union
		select 'pnw', isnull(max(count_date_dt),''), 'Year'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'pnw%'
		and count_date_dt <= getdate() - 365
	union
		select 'rcr', isnull(max(count_date_dt),''), 'Year'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'rcr%'
		and count_date_dt <= getdate() - 365
	union
		select 'was', isnull(max(count_date_dt),''), 'Year'
		from dbo.ADMIN_NodeFlowLoadCount
		where table_name_nm like 'was%'
		and count_date_dt <= getdate() - 365

--	select * from @FlowDateList

--	====================================================================================================================

	declare		@TableCountStats table
				(
				No int identity(1,1),
				NodeTable varchar(100),
				LastLoad int,
				Previous int,
				PrDiff int,
				PrPcntDiff varchar(25),
				Week int,
				WkDiff int,
				WkPcntDiff varchar(25),
				Month int,
				MoDiff int,
				MoPcntDiff varchar(25),
				Year int,
				YrDiff int,
				YrPcntDiff varchar(25),
				--LastLoadDate datetime
				LastLoadDate varchar(25)
				)

--	====================================================================================================================

	-- Get difference over last, previous, week, month, year loads
	insert into	@TableCountStats
				(
				NodeTable,
				LastLoad,
				Previous,
				PrDiff,
				PrPcntDiff,
				Week,
				WkDiff,
				WkPcntDiff,
				Month,
				MoDiff,
				MoPcntDiff,
				Year,
				YrDiff,
				YrPcntDiff,
				LastLoadDate
				)
	select		Last.Table_Name_NM									as "NodeTable",
				Last.Record_Count_QT								as "LastLoad",
				Previous.Record_Count_QT							as "Previous",
				Last.Record_Count_QT - Previous.Record_Count_QT		as "PrDiff",
				case convert(float, Previous.Record_Count_QT)
					when 0 then '0.00%'
					else 
						case charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Previous.Record_Count_QT))/convert(float, Previous.Record_Count_QT))), 1)
							when 0 then convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Previous.Record_Count_QT))/convert(float, Previous.Record_Count_QT))) + '.00%'
							else substring(convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Previous.Record_Count_QT))/convert(float, Previous.Record_Count_QT))), 1, charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Previous.Record_Count_QT))/convert(float, Previous.Record_Count_QT))), 1) + 2) + '%'
						end								
				end,
				Week.Record_Count_QT								as "Week",
				Last.Record_Count_QT - Week.Record_Count_QT			as "WkDiff",
				case convert(float, Week.Record_Count_QT)
					when 0 then '0.00%'
					else 
						case charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Week.Record_Count_QT))/convert(float, Week.Record_Count_QT))), 1)
							when 0 then convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Week.Record_Count_QT))/convert(float, Week.Record_Count_QT))) + '.00%'
							else substring(convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Week.Record_Count_QT))/convert(float, Week.Record_Count_QT))), 1, charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Week.Record_Count_QT))/convert(float, Week.Record_Count_QT))), 1) + 2) + '%'
						end								
				end,
				Month.Record_Count_QT								as "Month",
				Last.Record_Count_QT - Month.Record_Count_QT		as "MoDiff",
				case convert(float, Month.Record_Count_QT)
					when 0 then '0.00%'
					else 
						case charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Month.Record_Count_QT))/convert(float, Month.Record_Count_QT))), 1)
							when 0 then convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Month.Record_Count_QT))/convert(float, Month.Record_Count_QT))) + '.00%'
							else substring(convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Month.Record_Count_QT))/convert(float, Month.Record_Count_QT))), 1, charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Month.Record_Count_QT))/convert(float, Month.Record_Count_QT))), 1) + 2) + '%'
						end								
				end,
				Year.Record_Count_QT								as "Year",
				Last.Record_Count_QT - Year.Record_Count_QT			as "YrDiff",
				case convert(float, Year.Record_Count_QT)
					when 0 then '0.00%'
					else 
						case charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Year.Record_Count_QT))/convert(float, Year.Record_Count_QT))), 1)
							when 0 then convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Year.Record_Count_QT))/convert(float, Year.Record_Count_QT))) + '.00%'
							else substring(convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Year.Record_Count_QT))/convert(float, Year.Record_Count_QT))), 1, charindex('.', convert(varchar,(100 * (convert(float, Last.Record_Count_QT - Year.Record_Count_QT))/convert(float, Year.Record_Count_QT))), 1) + 2) + '%'
						end								
				end													as "PcntChange",
				--replace(convert(varchar(25), Last.Count_Date_DT, 111), '/', '') as "Last_Load_Date"	--yyyymmdd
				--replace(convert(varchar(25), Last.Count_Date_DT, 111), '/', '-') as "Last_Load_Date"	--yyyy-mm-dd
				--convert(varchar(25), Last.Count_Date_DT, 120) as "Last_Load_Date"						--yyyy-mm-dd hh:mi:ss
				--convert(varchar(25), Last.Count_Date_DT, 112) as "Last_Load_Date"						--yymmdd
				convert(varchar(25), Last.Count_Date_DT, 100) as "Last_Load_Date"						--mon dd yyyy hh:miAM (or PM) default
				--convert(varchar(25), Last.Count_Date_DT, 107) as "Last_Load_Date"						--mon dd yyyy
	from		dbo.ADMIN_NodeFlowLoadCount [Last]
	inner join	dbo.ADMIN_NodeFlowLoadCount [Previous]
	on			Last.Table_Name_NM = Previous.Table_Name_NM
	inner join	dbo.ADMIN_NodeFlowLoadCount [Week]
	on			Last.Table_Name_NM = Week.Table_Name_NM
	inner join	dbo.ADMIN_NodeFlowLoadCount [Month]
	on			Last.Table_Name_NM = Month.Table_Name_NM
	inner join	dbo.ADMIN_NodeFlowLoadCount [Year]
	on			Last.Table_Name_NM = Year.Table_Name_NM
	and			Last.Count_Date_DT in (select CountDate From @FlowDateList where Description_DS = 'Last')
	and			Previous.Count_Date_DT in (select CountDate From @FlowDateList where Description_DS = 'Previous')
	and			Week.Count_Date_DT in (select CountDate From @FlowDateList where Description_DS = 'Week')
	and			Month.Count_Date_DT in (select CountDate From @FlowDateList where Description_DS = 'Month')
	and			Year.Count_Date_DT in (select CountDate From @FlowDateList where Description_DS = 'Year')
	order by	Last.Table_Name_NM

--	select * from @TableCountStats

--	====================================================================================================================

	declare		@FlowSummary table
				(
				FlowName varchar(25),
				SumLast int,
				SumPrevious int,
				SumPrDiff int,
				--PcntPrDiff float,
				SumWeek int,
				SumWkDiff int,
				--PcntWkDiff float,
				SumMonth int,
				SumMoDiff int,
				--PcntMoDiff float,
				SumYear int,
				SumYrDiff int,
				--PcntYrDiff float,
				LastLoadDate varchar(25)
				)

	insert into	@FlowSummary
				(
				FlowName,
				SumLast,
				SumPrevious,
				SumPrDiff,
				--PcntPrDiff,
				SumWeek,
				SumWkDiff,
				--PcntWkDiff,
				SumMonth,
				SumMoDiff,
				--PcntMoDiff,
				SumYear,
				SumYrDiff,
				--PcntYrDiff,
				LastLoadDate
				)
	select		substring(NodeTable, 1, 3),
				sum(LastLoad),
				sum(Previous),
				sum(PrDiff),
				sum(Week),
				sum(WkDiff),
				sum(month),
				sum(MoDiff),
				sum(year),
				sum(YrDiff),
				LastLoadDate
	from		@TableCountStats
	group by	substring(NodeTable, 1, 3), LastLoadDate

	update		@FlowSummary
	set			FlowName =	case FlowName
							when 'PNW' then 'PNWWQX'
							when 'RCR' then 'RCRA'
							when 'Was' then 'WasteX'
							else FlowName
							end

--	update		@FlowSummary
--	set			PcntPrDiff = convert(varchar, (100 * (SumPrDiff/(SumLast - PrDiff)))--,
--				PcntWkDiff = convert(varchar, (100 * SumWkDiff/SumWeek)),
--				PcntMoDiff = convert(varchar, (100 * (SumMoDiff/SumMonth)),
--				PcntYrDiff = convert(varchar, (100 * (SumYrDiff/SunYear))

--	update @FlowAverage set PcntPrDiff = convert(varchar, (100 * (SumPrDiff/(SumLast - PrDiff)))
--	update @FlowAverage set PcntWkDiff = convert(varchar, (100 * SumWkDiff/SumWeek))
--	update @FlowAverage set PcntMoDiff = convert(varchar, (100 * (SumMoDiff/SumMonth))
--	update @FlowAverage set PcntYrDiff = convert(varchar, (100 * (SumYrDiff/SunYear))

	select * from @FlowSummary

--	exec [ADMIN_GetFlowRecordTotalsOverTime]

--	====================================================================================================================
END
GO
/****** Object:  ForeignKey [FK_PNWWQX_Affiliation_PNWWQX_ContactEntity]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Affiliation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_ContactEntity] FOREIGN KEY([ContactEntityFK])
REFERENCES [dbo].[PNWWQX_ContactEntity] ([ContactEntityPK])
GO
ALTER TABLE [dbo].[PNWWQX_Affiliation] CHECK CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_ContactEntity]
GO
/****** Object:  ForeignKey [FK_PNWWQX_Affiliation_PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Affiliation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_FieldEvent] FOREIGN KEY([FieldEventFK])
REFERENCES [dbo].[PNWWQX_FieldEvent] ([FieldEventPK])
GO
ALTER TABLE [dbo].[PNWWQX_Affiliation] CHECK CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_FieldEvent]
GO
/****** Object:  ForeignKey [FK_PNWWQX_Affiliation_PNWWQX_Project]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Affiliation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_Project] FOREIGN KEY([ProjectFK])
REFERENCES [dbo].[PNWWQX_Project] ([ProjectPK])
GO
ALTER TABLE [dbo].[PNWWQX_Affiliation] CHECK CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_Project]
GO
/****** Object:  ForeignKey [FK_PNWWQX_Affiliation_PNWWQX_Result]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Affiliation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_Result] FOREIGN KEY([ResultFK])
REFERENCES [dbo].[PNWWQX_Result] ([ResultPK])
GO
ALTER TABLE [dbo].[PNWWQX_Affiliation] CHECK CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_Result]
GO
/****** Object:  ForeignKey [FK_PNWWQX_Affiliation_PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Affiliation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_Station] FOREIGN KEY([StationFK])
REFERENCES [dbo].[PNWWQX_Station] ([StationPK])
GO
ALTER TABLE [dbo].[PNWWQX_Affiliation] CHECK CONSTRAINT [FK_PNWWQX_Affiliation_PNWWQX_Station]
GO
/****** Object:  ForeignKey [FK_PNWWQX_BinaryLargeObject_PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_BinaryLargeObject]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_BinaryLargeObject_PNWWQX_FieldEvent] FOREIGN KEY([FieldEventFK])
REFERENCES [dbo].[PNWWQX_FieldEvent] ([FieldEventPK])
GO
ALTER TABLE [dbo].[PNWWQX_BinaryLargeObject] CHECK CONSTRAINT [FK_PNWWQX_BinaryLargeObject_PNWWQX_FieldEvent]
GO
/****** Object:  ForeignKey [FK_PNWWQX_BinaryLargeObject_PNWWQX_Project]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_BinaryLargeObject]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_BinaryLargeObject_PNWWQX_Project] FOREIGN KEY([ProjectFK])
REFERENCES [dbo].[PNWWQX_Project] ([ProjectPK])
GO
ALTER TABLE [dbo].[PNWWQX_BinaryLargeObject] CHECK CONSTRAINT [FK_PNWWQX_BinaryLargeObject_PNWWQX_Project]
GO
/****** Object:  ForeignKey [FK_PNWWQX_BinaryLargeObject_PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_BinaryLargeObject]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_BinaryLargeObject_PNWWQX_Station] FOREIGN KEY([StationFK])
REFERENCES [dbo].[PNWWQX_Station] ([StationPK])
GO
ALTER TABLE [dbo].[PNWWQX_BinaryLargeObject] CHECK CONSTRAINT [FK_PNWWQX_BinaryLargeObject_PNWWQX_Station]
GO
/****** Object:  ForeignKey [FK_PNWWQX_DataCatalog_FieldEventSummary_PNWWQX_DataCatalog_ProjectSummary]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_DataCatalog_FieldEventSummary]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_DataCatalog_FieldEventSummary_PNWWQX_DataCatalog_ProjectSummary] FOREIGN KEY([FieldEventProjectIdentifier])
REFERENCES [dbo].[PNWWQX_DataCatalog_ProjectSummary] ([ProjectIdentifier])
GO
ALTER TABLE [dbo].[PNWWQX_DataCatalog_FieldEventSummary] CHECK CONSTRAINT [FK_PNWWQX_DataCatalog_FieldEventSummary_PNWWQX_DataCatalog_ProjectSummary]
GO
/****** Object:  ForeignKey [FK_PNWWQX_DataCatalog_FieldEventSummary_PNWWQX_DataCatalog_StationSummary]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_DataCatalog_FieldEventSummary]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_DataCatalog_FieldEventSummary_PNWWQX_DataCatalog_StationSummary] FOREIGN KEY([FieldEventStationIdentifier])
REFERENCES [dbo].[PNWWQX_DataCatalog_StationSummary] ([StationIdentifier])
GO
ALTER TABLE [dbo].[PNWWQX_DataCatalog_FieldEventSummary] CHECK CONSTRAINT [FK_PNWWQX_DataCatalog_FieldEventSummary_PNWWQX_DataCatalog_StationSummary]
GO
/****** Object:  ForeignKey [FK_PNWWQX_DataCatalog_ProjectSummary_PNWWQX_ProvidingOrganization]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_DataCatalog_ProjectSummary]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_DataCatalog_ProjectSummary_PNWWQX_ProvidingOrganization] FOREIGN KEY([ProvidingOrganizationFK])
REFERENCES [dbo].[PNWWQX_ProvidingOrganization] ([ProvidingOrganizationPK])
GO
ALTER TABLE [dbo].[PNWWQX_DataCatalog_ProjectSummary] CHECK CONSTRAINT [FK_PNWWQX_DataCatalog_ProjectSummary_PNWWQX_ProvidingOrganization]
GO
/****** Object:  ForeignKey [FK_PNWWQX_DataCatalog_StationLocationDescriptor_PNWWQX_DataCatalog_StationSummary]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_DataCatalog_StationLocationDescriptor]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_DataCatalog_StationLocationDescriptor_PNWWQX_DataCatalog_StationSummary] FOREIGN KEY([StationSummaryIdentifier])
REFERENCES [dbo].[PNWWQX_DataCatalog_StationSummary] ([StationIdentifier])
GO
ALTER TABLE [dbo].[PNWWQX_DataCatalog_StationLocationDescriptor] CHECK CONSTRAINT [FK_PNWWQX_DataCatalog_StationLocationDescriptor_PNWWQX_DataCatalog_StationSummary]
GO
/****** Object:  ForeignKey [FK_PNWWQX_DataCatalog_StationSummary_PNWWQX_ProvidingOrganization]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_DataCatalog_StationSummary]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_DataCatalog_StationSummary_PNWWQX_ProvidingOrganization] FOREIGN KEY([ProvidingOrganizationFK])
REFERENCES [dbo].[PNWWQX_ProvidingOrganization] ([ProvidingOrganizationPK])
GO
ALTER TABLE [dbo].[PNWWQX_DataCatalog_StationSummary] CHECK CONSTRAINT [FK_PNWWQX_DataCatalog_StationSummary_PNWWQX_ProvidingOrganization]
GO
/****** Object:  ForeignKey [FK_PNWWQX_FieldEvent_PNWWQX_ProjectStation]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_FieldEvent]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_FieldEvent_PNWWQX_ProjectStation] FOREIGN KEY([ProjectFK], [StationFK])
REFERENCES [dbo].[PNWWQX_ProjectStation] ([ProjectFK], [StationFK])
GO
ALTER TABLE [dbo].[PNWWQX_FieldEvent] CHECK CONSTRAINT [FK_PNWWQX_FieldEvent_PNWWQX_ProjectStation]
GO
/****** Object:  ForeignKey [FK_PNWWQX_LocationDescriptor_PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_LocationDescriptor]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_LocationDescriptor_PNWWQX_Station] FOREIGN KEY([StationFK])
REFERENCES [dbo].[PNWWQX_Station] ([StationPK])
GO
ALTER TABLE [dbo].[PNWWQX_LocationDescriptor] CHECK CONSTRAINT [FK_PNWWQX_LocationDescriptor_PNWWQX_Station]
GO
/****** Object:  ForeignKey [FK_PNWWQX_Project_PNWWQX_ProvidingOrganization]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Project]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Project_PNWWQX_ProvidingOrganization] FOREIGN KEY([ProvidingOrganizationFK])
REFERENCES [dbo].[PNWWQX_ProvidingOrganization] ([ProvidingOrganizationPK])
GO
ALTER TABLE [dbo].[PNWWQX_Project] CHECK CONSTRAINT [FK_PNWWQX_Project_PNWWQX_ProvidingOrganization]
GO
/****** Object:  ForeignKey [FK_PNWWQX_ProjectAnalyte_PNWWQX_Project]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_ProjectAnalyte]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_ProjectAnalyte_PNWWQX_Project] FOREIGN KEY([ProjectFK])
REFERENCES [dbo].[PNWWQX_Project] ([ProjectPK])
GO
ALTER TABLE [dbo].[PNWWQX_ProjectAnalyte] CHECK CONSTRAINT [FK_PNWWQX_ProjectAnalyte_PNWWQX_Project]
GO
/****** Object:  ForeignKey [FK_PNWWQX_ProjectStation_PNWWQX_Project]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_ProjectStation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_ProjectStation_PNWWQX_Project] FOREIGN KEY([ProjectFK])
REFERENCES [dbo].[PNWWQX_Project] ([ProjectPK])
GO
ALTER TABLE [dbo].[PNWWQX_ProjectStation] CHECK CONSTRAINT [FK_PNWWQX_ProjectStation_PNWWQX_Project]
GO
/****** Object:  ForeignKey [FK_PNWWQX_ProjectStation_PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_ProjectStation]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_ProjectStation_PNWWQX_Station] FOREIGN KEY([StationFK])
REFERENCES [dbo].[PNWWQX_Station] ([StationPK])
GO
ALTER TABLE [dbo].[PNWWQX_ProjectStation] CHECK CONSTRAINT [FK_PNWWQX_ProjectStation_PNWWQX_Station]
GO
/****** Object:  ForeignKey [FK_PNWWQX_Result_PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_Result]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_Result_PNWWQX_FieldEvent] FOREIGN KEY([FieldEventFK])
REFERENCES [dbo].[PNWWQX_FieldEvent] ([FieldEventPK])
GO
ALTER TABLE [dbo].[PNWWQX_Result] CHECK CONSTRAINT [FK_PNWWQX_Result_PNWWQX_FieldEvent]
GO
/****** Object:  ForeignKey [FK_PNWWQX_ResultDetectionLevel_PNWWQX_Result]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_ResultDetectionLevel]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_ResultDetectionLevel_PNWWQX_Result] FOREIGN KEY([ResultFK])
REFERENCES [dbo].[PNWWQX_Result] ([ResultPK])
GO
ALTER TABLE [dbo].[PNWWQX_ResultDetectionLevel] CHECK CONSTRAINT [FK_PNWWQX_ResultDetectionLevel_PNWWQX_Result]
GO
/****** Object:  ForeignKey [FK_PNWWQX_SamplePreparationMethod_PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_SamplePreparationMethod]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_SamplePreparationMethod_PNWWQX_FieldEvent] FOREIGN KEY([FieldEventFK])
REFERENCES [dbo].[PNWWQX_FieldEvent] ([FieldEventPK])
GO
ALTER TABLE [dbo].[PNWWQX_SamplePreparationMethod] CHECK CONSTRAINT [FK_PNWWQX_SamplePreparationMethod_PNWWQX_FieldEvent]
GO
/****** Object:  ForeignKey [FK_PNWWQX_SamplePreservationMethod_PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_SamplePreservationMethod]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_SamplePreservationMethod_PNWWQX_FieldEvent] FOREIGN KEY([FieldEventFK])
REFERENCES [dbo].[PNWWQX_FieldEvent] ([FieldEventPK])
GO
ALTER TABLE [dbo].[PNWWQX_SamplePreservationMethod] CHECK CONSTRAINT [FK_PNWWQX_SamplePreservationMethod_PNWWQX_FieldEvent]
GO
/****** Object:  ForeignKey [FK_PNWWQX_WellDetail_PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_WellDetail]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_WellDetail_PNWWQX_Station] FOREIGN KEY([StationFK])
REFERENCES [dbo].[PNWWQX_Station] ([StationPK])
GO
ALTER TABLE [dbo].[PNWWQX_WellDetail] CHECK CONSTRAINT [FK_PNWWQX_WellDetail_PNWWQX_Station]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity] FOREIGN KEY([ProjectContactEntityFK])
REFERENCES [dbo].[PNWWQX_ContactEntity] ([ContactEntityPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity1]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity1] FOREIGN KEY([StationContactEntityFK])
REFERENCES [dbo].[PNWWQX_ContactEntity] ([ContactEntityPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity1]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity2]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity2] FOREIGN KEY([FieldEventContactEntityFK])
REFERENCES [dbo].[PNWWQX_ContactEntity] ([ContactEntityPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_ContactEntity2]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_FieldEvent]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_FieldEvent] FOREIGN KEY([FieldEventFK])
REFERENCES [dbo].[PNWWQX_FieldEvent] ([FieldEventPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_FieldEvent]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_Project]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_Project] FOREIGN KEY([ProjectFK])
REFERENCES [dbo].[PNWWQX_Project] ([ProjectPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_Project]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_Result]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_Result] FOREIGN KEY([ResultFK])
REFERENCES [dbo].[PNWWQX_Result] ([ResultPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_Result]
GO
/****** Object:  ForeignKey [FK_PNWWQX_XtraJoinTable_PNWWQX_Station]    Script Date: 06/23/2009 13:34:56 ******/
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable]  WITH CHECK ADD  CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_Station] FOREIGN KEY([StationFK])
REFERENCES [dbo].[PNWWQX_Station] ([StationPK])
GO
ALTER TABLE [dbo].[PNWWQX_XtraJoinTable] CHECK CONSTRAINT [FK_PNWWQX_XtraJoinTable_PNWWQX_Station]
GO
