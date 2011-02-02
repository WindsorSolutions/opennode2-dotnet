Declare @rowID int,
	@maxRows int,
	@providingOrganizationName varchar(80),
	@projectOrganizationName varchar(80),
	@projectName varchar(255),
	@projectStartDate datetime,
	@projectEndDate datetime,
	@responsibleOrganizationName varchar(80),
	@maximumLocationLatitude decimal(8,6),
	@maximumLocationLongitude decimal(9,6),
	@minimumLocationLatitude decimal(8,6),
	@minimumLocationLongitude decimal(9,6),
	@locationDescriptorContext varchar(30),
	@locationDescriptorName varchar(100),
	@stationType varchar(20),
	@stationName varchar(255),
	@samplingOrganizationName varchar(80),
	@fieldEventStartDate datetime,
	@fieldEventEndDate datetime,
	@sampledMedia varchar(4000),
	@analyteName varchar(4000),
	@sampledTaxon varchar(4000),
	@Deliminator char(1)

	set @rowID = 0
	set @maxRows = 5000
	set @providingOrganizationName = ''
	set @projectOrganizationName = ''
	set @projectName = 'Data to Support the EPA''s EMAP-Estuaries Program'
	set @projectStartDate = '1/1/1970'
	set @projectEndDate = '1/1/2020'
	set @responsibleOrganizationName = ''
	set @maximumLocationLatitude = 0
	set @maximumLocationLongitude = 0
	set @minimumLocationLatitude = 0
	set @minimumLocationLongitude = 0
	set @locationDescriptorContext = ''
	set @locationDescriptorName = ''
	set @stationType = ''
	set @stationName = ''
	set @samplingOrganizationName = ''
	set @fieldEventStartDate = '1/1/1970'
	set @fieldEventEndDate = '1/1/2020'
	set @sampledMedia = ''
	set @analyteName = ''
	set @sampledTaxon = ''
	set @Deliminator = '|'












SELECT DISTINCT
		ProjectFK,
		ProvidingOrganizationFK,
		ProjectContactEntityFK
	FROM
		PNWWQX_XtraJoinTable
	WHERE
		(Len(@providingOrganizationName) = 0
		OR
		ProvidingOrganizationName LIKE @providingOrganizationName)
	AND
		(Len(@projectOrganizationName) = 0
		OR
		ProjectOrganizationName LIKE @projectOrganizationName)
	AND
		(Len(@projectName) = 0
		OR
		ProjectName LIKE @projectName)
	AND
		(@projectStartDate IS NULL
		OR
		ProjectStartDate >= @projectStartDate)
	AND
		(@projectEndDate IS NULL
		OR
		ProjectEndDate <= @projectEndDate)
	AND
		(Len(@responsibleOrganizationName) = 0
		OR
		StationOrganizationName LIKE @responsibleOrganizationName)
	AND
		((@minimumLocationLatitude = 0 AND @maximumLocationLatitude = 0)
		OR
		(LatitudeMeasure BETWEEN @minimumLocationLatitude AND @maximumLocationLatitude))
	AND
		((@minimumLocationLongitude = 0 AND @maximumLocationLongitude = 0)
		OR
		(LongitudeMeasure BETWEEN @minimumLocationLongitude AND @maximumLocationLongitude))
	AND
		(Len(@locationDescriptorContext) = 0
		OR
		LocationDescriptorContext = @locationDescriptorContext)
	AND
		(Len(@locationDescriptorName) = 0
		OR
		LocationDescriptorName = @locationDescriptorName)
	AND
		(Len(@stationType) = 0
		OR
		StationType = @stationType)
	AND
		(Len(@stationName) = 0
		OR
		StationName LIKE @stationName)
	AND
		(Len(@samplingOrganizationName) = 0
		OR
		FieldEventOrganizationName LIKE @samplingOrganizationName)
	AND
		(@fieldEventStartDate IS NULL
		OR
		FieldEventStartDate >= @fieldEventStartDate)
	AND
		(@fieldEventEndDate IS NULL
		OR
		FieldEventEndDate <= @fieldEventEndDate)
	AND
		(Len(@sampledMedia) = 0
		OR
		MediaText IN
		(SELECT * FROM dbo.fn_ArrayToTable(@sampledMedia,@Deliminator)))
	AND
		(Len(@analyteName) = 0
		OR
		AnalyteName IN
		(SELECT * FROM dbo.fn_ArrayToTable(@analyteName,@Deliminator)))
	AND
		(Len(@sampledTaxon) = 0
		OR
		FieldEventBiologicalSystematicName IN
		(SELECT * FROM dbo.fn_ArrayToTable(@sampledTaxon,@Deliminator)))

*/