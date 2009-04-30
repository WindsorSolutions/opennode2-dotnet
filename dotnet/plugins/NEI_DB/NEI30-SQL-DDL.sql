SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_CONTROLEQUIPMENT](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[EMISSIONUNITIDENTIFIER] [varchar](6) NULL,
	[PROCESSIDENTIFIER] [varchar](6) NULL,
	[POLLUTANTCODE] [varchar](9) NULL,
	[PRIMARYEFFICIENCYPERCENT] [numeric](5, 2) NULL,
	[CAPTUREEFFICIENCYPERCENT] [numeric](5, 2) NULL,
	[TOTALCAPTUREEFFICIENCYPERCENT] [numeric](5, 2) NULL,
	[DEVICEPRIMARYTYPECODE] [varchar](4) NULL,
	[DEVICESECONDARYTYPECODE] [varchar](4) NULL,
	[CONTROLSYSTEMDESCRIPTION] [varchar](40) NULL,
	[DEVICETHIRDTYPECODE] [varchar](4) NULL,
	[DEVICEFOURTHTYPECODE] [varchar](4) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[EU_ID] [varchar](6) NULL,
	[EP_ID] [varchar](6) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_EMISSIONPERIOD](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[EMISSIONUNITIDENTIFIER] [varchar](6) NULL,
	[PROCESSIDENTIFIER] [varchar](6) NULL,
	[EMISSIONPERIODSTARTDATE] [numeric](8, 0) NULL,
	[EMISSIONPERIODENDDATE] [numeric](8, 0) NULL,
	[EMISSIONPERIODSTARTTIME] [numeric](4, 0) NULL,
	[EMISSIONPERIODENDTIME] [numeric](4, 0) NULL,
	[THROUGHPUTVALUE] [float] NULL,
	[UNITNUMERATORVALUE] [varchar](10) NULL,
	[MATERIALCODE] [numeric](4, 0) NULL,
	[MATERIALINPUTOUTPUTCODE] [varchar](10) NULL,
	[AVERAGEDAYSPERWEEKVALUE] [numeric](1, 0) NULL,
	[AVERAGEWEEKSPERPERIODVALUE] [numeric](2, 0) NULL,
	[AVERAGEHOURSPERDAYVALUE] [numeric](2, 0) NULL,
	[AVERAGEHOURSPERPERIODVALUE] [numeric](4, 0) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[EU_ID] [varchar](6) NULL,
	[EP_ID] [varchar](6) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_EMISSIONPROCESS](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[EMISSIONUNITIDENTIFIER] [varchar](6) NULL,
	[RELEASEPOINTIDENTIFIER] [varchar](6) NULL,
	[PROCESSIDENTIFIER] [varchar](6) NULL,
	[SOURCECATEGORYCODE] [varchar](10) NULL,
	[MACTCODE] [varchar](6) NULL,
	[EMISSIONPROCESSDESCRIPTION] [varchar](78) NULL,
	[THROUGHPUTWINTERPERCENT] [numeric](3, 0) NULL,
	[THROUGHPUTSPRINGPERCENT] [numeric](3, 0) NULL,
	[THROUGHPUTSUMMERPERCENT] [numeric](3, 0) NULL,
	[THROUGHPUTFALLPERCENT] [numeric](3, 0) NULL,
	[AVERAGEDAILYPERWEEKVALUE] [numeric](1, 0) NULL,
	[AVERAGEWEEKSPERYEARVALUE] [numeric](2, 0) NULL,
	[AVERAGEHOURSPERDAYVALUE] [numeric](2, 0) NULL,
	[AVERAGEHOURSPERYEARVALUE] [numeric](4, 0) NULL,
	[FULLHEATCONTENTMEASURE] [numeric](8, 0) NULL,
	[FUELSULFURCONTENTMEASURE] [numeric](5, 0) NULL,
	[FUELASHCONTENTMEASURE] [numeric](5, 0) NULL,
	[MACTCOMPLIANCESTATUSCODE] [varchar](6) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[EU_ID] [varchar](6) NULL,
	[EP_ID] [varchar](6) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_EMISSIONRELEASEPOINT](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[RELEASEPOINTIDENTIFIER] [varchar](6) NULL,
	[RELEASEPOINTTYPECODE] [varchar](2) NULL,
	[STACKHEIGHTVALUE] [numeric](10, 2) NULL,
	[STACKDIAMETERVALUE] [numeric](10, 2) NULL,
	[STACKFENCELINEDISTANCEVALUE] [numeric](8, 2) NULL,
	[EXITGASTEMPERATUREVALUE] [numeric](10, 2) NULL,
	[EXITGASSTREAMVELOCITYVALUE] [numeric](10, 2) NULL,
	[EXITGASFLOWRATE] [numeric](10, 2) NULL,
	[LONGITUDEMEASURE] [numeric](11, 6) NULL,
	[LATITUDEMEASURE] [numeric](10, 6) NULL,
	[UTMZONECODE] [numeric](2, 0) NULL,
	[XYCOORDINATETYPECODE] [varchar](8) NULL,
	[FUGITIVEHORIZONTALAREAVALUE] [numeric](8, 0) NULL,
	[FUGITIVERELEASEHEIGHTVALUE] [numeric](8, 0) NULL,
	[FUGITIVEUNITOFMEASURECODE] [varchar](10) NULL,
	[RELEASEPOINTDESCRIPTION] [varchar](80) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[HORIZONTALCOLLECTIONMETHODCODE] [varchar](3) NULL,
	[HORIZONTALACCURACYMEASURE] [varchar](6) NULL,
	[HORIZONTALREFERENCEDATUMCODE] [varchar](3) NULL,
	[REFERENCEPOINTCODE] [varchar](3) NULL,
	[SOURCEMAPSCALENUMBER] [varchar](10) NULL,
	[COORDINATEDATASOURCECODE] [varchar](3) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[ER_ID] [varchar](6) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_EMISSIONSUBMISSION](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[EMISSIONUNITIDENTIFIER] [varchar](6) NULL,
	[PROCESSIDENTIFIER] [varchar](6) NULL,
	[POLLUTANTCODE] [varchar](9) NULL,
	[RELEASEPOINTIDENTIFIER] [varchar](6) NULL,
	[EMISSIONPERIODSTARTDATE] [numeric](8, 0) NULL,
	[EMISSIONPERIODENDDATE] [numeric](8, 0) NULL,
	[EMISSIONPERIODSTARTTIME] [numeric](4, 0) NULL,
	[EMISSIONPERIODENDTIME] [numeric](4, 0) NULL,
	[EMISSIONVALUE] [float] NULL,
	[EMISSIONUNITNUMERATORVALUE] [varchar](10) NULL,
	[EMISSIONTYPECODE] [varchar](2) NULL,
	[RELIABILITYINDICATOR] [numeric](5, 2) NULL,
	[EMISSIONFACTORVALUE] [float] NULL,
	[UNITNUMERATORVALUE] [varchar](10) NULL,
	[UNITDENOMINATORVALUE] [varchar](10) NULL,
	[MATERIALCODE] [numeric](4, 0) NULL,
	[MATERIALINPUTOUTPUTCODE] [varchar](10) NULL,
	[EMISSIONCALCULATIONMETHODCODE] [varchar](2) NULL,
	[EMISSIONFACTORRELIABILITY] [varchar](5) NULL,
	[RULEEFFECTIVENESSMEASURE] [numeric](5, 2) NULL,
	[RULEEFFECTIVENESSMETHODCODE] [varchar](2) NULL,
	[HAPEMISSIONSPERFORMANCELEVEL] [varchar](2) NULL,
	[CONTROLSTATUSCODE] [varchar](12) NULL,
	[EMISSIONDATALEVELIDENTIFIER] [varchar](10) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[EU_ID] [varchar](6) NULL,
	[EP_ID] [varchar](6) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_EMISSIONUNIT](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[EMISSIONUNITIDENTIFIER] [varchar](6) NULL,
	[ORISBOILERIDENTIFIER] [varchar](5) NULL,
	[SICCODE] [varchar](4) NULL,
	[NAICSCODE] [varchar](6) NULL,
	[DESIGNCAPACITYMEASURE] [numeric](10, 2) NULL,
	[UNITNUMERATORVALUE] [varchar](10) NULL,
	[UNITDENOMINATORVALUE] [varchar](10) NULL,
	[DESIGNCAPACITYMAXIMUM] [numeric](10, 2) NULL,
	[EMISSIONUNITDESCRIPTION] [varchar](80) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[EU_ID] [varchar](6) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_SITE](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[STATEFACILITYIDENTIFIER] [varchar](15) NULL,
	[FACILITYREGISTRYIDENTIFIER] [varchar](12) NULL,
	[FACILITYCATEGORYCODE] [varchar](2) NULL,
	[ORISFACILITYCODE] [varchar](6) NULL,
	[SICCODE] [varchar](4) NULL,
	[NAICS_CODE] [varchar](6) NULL,
	[FACILITYSITENAME] [varchar](80) NULL,
	[FACILITYDESCRIPTION] [varchar](40) NULL,
	[LOCATIONADDRESSTEXT] [varchar](50) NULL,
	[LOCALITYNAME] [varchar](60) NULL,
	[LOCATIONSTATECODE] [varchar](2) NULL,
	[LOCATIONZIPCODE] [varchar](14) NULL,
	[COUNTRYNAME] [varchar](40) NULL,
	[FACILITYNTIIDENTIFIER] [varchar](20) NULL,
	[ORGANIZATIONDUNSNUMBER] [varchar](9) NULL,
	[FACILITYTRIIDENTIFIER] [varchar](20) NULL,
	[TRANSACTIONSUBMITTALCODE] [varchar](4) NULL,
	[TRIBALCODE] [varchar](3) NULL,
	[SI_ID] [varchar](15) NULL,
	[INVENTORY_YEAR] [numeric](4, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NEI_TRANSMITTAL](
	[RECORDTYPECODE] [varchar](2) NULL,
	[COUNTYSTATEFIPSCODE] [varchar](5) NULL,
	[ORGANIZATIONFORMALNAME] [varchar](80) NULL,
	[TRANSACTIONTYPECODE] [varchar](2) NULL,
	[INVENTORYYEAR] [numeric](4, 0) NULL,
	[INVENTORYTYPECODE] [varchar](10) NULL,
	[TRANSACTIONCREATIONDATE] [numeric](8, 0) NULL,
	[SUBMISSIONNUMBER] [numeric](4, 0) NULL,
	[RELIABILITYINDICATOR] [numeric](5, 2) NULL,
	[TRANSACTIONCOMMENT] [varchar](80) NULL,
	[INDIVIDUALFULLNAME] [varchar](70) NULL,
	[TELEPHONENUMBER] [varchar](15) NULL,
	[TELEHPHONENUMBERTYPENAME] [varchar](10) NULL,
	[ELECTRONICADDRESSTEXT] [varchar](100) NULL,
	[ELECTRONICADDRESSTYPENAME] [varchar](10) NULL,
	[SOURCETYPECODE] [varchar](25) NULL,
	[AFFILIATIONTYPETEXT] [varchar](40) NULL,
	[FORMATVERSIONNUMBER] [numeric](4, 1) NULL,
	[TRIBALCODE] [varchar](3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF