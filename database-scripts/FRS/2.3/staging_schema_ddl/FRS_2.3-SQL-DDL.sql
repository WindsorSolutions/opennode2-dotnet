SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [FRS_AlternateName](
	[AlternativeName] [varchar](80) NOT NULL,
	[AlternativeNameTypeText] [varchar](25) NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NOT NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_Deleted_Facility](
	[STATEFACILITYIDENTIFIER] [varchar](12) NOT NULL,
	[DELETIONDATE] [datetime] NOT NULL
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
CREATE TABLE [FRS_EnvironmentalInterest](
	[InformationSystemAcronymName] [varchar](20) NULL,
	[InformationSystemIdentifier] [varchar](30) NULL,
	[EnvironmentalInterestTypeText] [varchar](60) NOT NULL,
	[FederalStateInterestIndicator] [varchar](1) NULL,
	[EnvironmentalInterestStartDate] [datetime] NOT NULL,
	[InterestStartDateQualifierText] [varchar](50) NULL,
	[EnvironmentalInterestEndDate] [datetime] NULL,
	[InterestEndDateQualifierText] [varchar](50) NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_FacilitySite](
	[FacilityRegistryIdentifier] [varchar](12) NULL,
	[FacilitySiteName] [varchar](80) NOT NULL,
	[FacilitySiteTypeName] [varchar](40) NULL,
	[FederalFacilityIndicator] [varchar](1) NOT NULL,
	[TribalLandIndicator] [varchar](1) NULL,
	[TribalLandName] [varchar](200) NULL,
	[CongressionalDistrictNumber] [varchar](2) NULL,
	[LegislativeDistrictNumber] [varchar](3) NULL,
	[HUCCode] [varchar](8) NULL,
	[LocationAddressText] [varchar](50) NULL,
	[SupplementalLocationText] [varchar](50) NULL,
	[LocalityName] [varchar](60) NULL,
	[CountyStateFIPSCode] [varchar](5) NULL,
	[CountyName] [varchar](35) NULL,
	[StateUSPSCode] [varchar](2) NULL,
	[StateName] [varchar](35) NULL,
	[CountryName] [varchar](44) NULL,
	[LocationZIPCode] [varchar](14) NULL,
	[LocationDescriptionText] [varchar](256) NULL,
	[DataSourceName] [varchar](25) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](30) NOT NULL,
 CONSTRAINT [PK_FRS_FacilitySite] PRIMARY KEY CLUSTERED 
(
	[StateFacilityIdentifier] ASC,
	[FacilitySiteName] ASC
)WITH FILLFACTOR = 90 ON [PRIMARY]
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
CREATE TABLE [FRS_GeographicCoordinates](
	[LatitudeMeasure] [varchar](9) NULL,
	[LongitudeMeasure] [varchar](10) NULL,
	[HorizontalAccuracyMeasure] [varchar](5) NULL,
	[HorizontalCollectionMethodText] [varchar](60) NULL,
	[HorizontalReferenceDatumName] [varchar](7) NULL,
	[SourceMapScaleNumber] [varchar](9) NULL,
	[ReferencePointText] [varchar](50) NULL,
	[DataCollectionDate] [datetime] NULL,
	[GeometricTypeName] [varchar](6) NOT NULL,
	[LocationCommentsText] [varchar](240) NULL,
	[VerticalCollectionMethodText] [varchar](60) NULL,
	[VerticalMeasure] [varchar](10) NULL,
	[VerticalAccuracyMeasure] [varchar](7) NULL,
	[VerticalReferenceDatumName] [varchar](17) NULL,
	[DataSourceName] [varchar](30) NULL,
	[CoordinateDataSourceName] [varchar](3) NULL,
	[SubEntityIdentifier] [varchar](30) NULL,
	[SubEntityTypeName] [varchar](50) NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_Individual](
	[InformationSystemAcronymName] [varchar](20) NULL,
	[InformationSystemIdentifier] [varchar](30) NULL,
	[EnvironmentalInterestTypeText] [varchar](60) NULL,
	[AffiliationTypeText] [varchar](40) NOT NULL,
	[AffiliationStartDate] [datetime] NULL,
	[AffiliationEndDate] [datetime] NULL,
	[EmailAddressText] [varchar](120) NULL,
	[TelephoneNumber] [varchar](30) NULL,
	[PhoneExtension] [varchar](5) NULL,
	[FaxNumber] [varchar](30) NULL,
	[AlternateTelephoneNumber] [varchar](30) NULL,
	[IndividualFullName] [varchar](70) NOT NULL,
	[IndividualTitleText] [varchar](40) NULL,
	[MailingAddressText] [varchar](50) NULL,
	[SupplementalAddressText] [varchar](50) NULL,
	[MailingAddressCityName] [varchar](30) NOT NULL,
	[MailingAddressStateUSPSCode] [varchar](2) NULL,
	[MailingAddressStateName] [varchar](35) NULL,
	[MailingAddressCountryName] [varchar](44) NULL,
	[MailingAddressZIPCode] [varchar](14) NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_MailingAddress](
	[AffiliationTypeText] [varchar](40) NOT NULL,
	[MailingAddressText] [varchar](50) NULL,
	[SupplementalAddressText] [varchar](50) NULL,
	[MailingAddressCityName] [varchar](30) NULL,
	[MailingAddressStateUSPSCode] [varchar](2) NULL,
	[MailingAddressStateName] [varchar](35) NULL,
	[MailingAddressCountryName] [varchar](44) NULL,
	[MailingAddressZIPCode] [varchar](14) NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_NAICSCode](
	[InformationSystemAcronymName] [varchar](20) NULL,
	[InformationSystemIdentifier] [varchar](30) NULL,
	[EnvironmentalInterestTypeText] [varchar](60) NULL,
	[NAICSCode] [varchar](6) NOT NULL,
	[NAICSPrimaryIndicator] [varchar](10) NOT NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_Organization](
	[InformationSystemAcronymName] [varchar](20) NULL,
	[InformationSystemIdentifier] [varchar](30) NULL,
	[EnvironmentalInterestTypeText] [varchar](60) NULL,
	[AffiliationTypeText] [varchar](40) NOT NULL,
	[AffiliationStartDate] [datetime] NULL,
	[AffiliationEndDate] [datetime] NULL,
	[EmailAddressText] [varchar](120) NULL,
	[TelephoneNumber] [varchar](30) NULL,
	[PhoneExtension] [varchar](5) NULL,
	[FaxNumber] [varchar](30) NULL,
	[AlternateTelephoneNumber] [varchar](30) NULL,
	[OrganizationFormalName] [varchar](80) NOT NULL,
	[OrganizationDUNSNumber] [varchar](9) NULL,
	[OrganizationTypeText] [varchar](40) NULL,
	[EmployerIdentifier] [varchar](14) NULL,
	[StateBusinessIdentifier] [varchar](30) NULL,
	[UltimateParentName] [varchar](50) NULL,
	[UltimateParentDUNSNumber] [varchar](9) NULL,
	[MailingAddressText] [varchar](50) NULL,
	[SupplementalAddressText] [varchar](50) NULL,
	[MailingAddressCityName] [varchar](30) NOT NULL,
	[MailingAddressStateUSPSCode] [varchar](2) NULL,
	[MailingAddressStateName] [varchar](35) NULL,
	[MailingAddressCountryName] [varchar](44) NULL,
	[MailingAddressZIPCode] [varchar](14) NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
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
CREATE TABLE [FRS_SICCode](
	[InformationSystemAcronymName] [varchar](20) NULL,
	[InformationSystemIdentifier] [varchar](30) NULL,
	[EnvironmentalInterestTypeText] [varchar](60) NULL,
	[SICCode] [varchar](4) NOT NULL,
	[SICPrimaryIndicator] [varchar](10) NOT NULL,
	[DataSourceName] [varchar](50) NULL,
	[LastReportedDate] [datetime] NULL,
	[StateFacilitySystemAcronymName] [varchar](20) NOT NULL,
	[StateFacilityIdentifier] [varchar](12) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF