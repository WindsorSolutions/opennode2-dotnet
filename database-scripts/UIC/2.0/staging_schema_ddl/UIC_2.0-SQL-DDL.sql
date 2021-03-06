/****** Object:  Table [dbo].[UIC_ORG]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_ORG](
	[ORG_ID] [varchar](4) NOT NULL,
	[PRIMACY_AGENCY_CD] [varchar](50) NOT NULL,
	[ORG_NAME] [varchar](255) NULL,
 CONSTRAINT [PK_ORG] PRIMARY KEY CLUSTERED 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'4 character code of the Primacy Agency making the submission. (PrimacyAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ORG', @level2type=N'COLUMN',@level2name=N'PRIMACY_AGENCY_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: UICDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ORG'
GO
/****** Object:  Table [dbo].[UIC_CONTACT]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_CONTACT](
	[CONTACT_ID] [varchar](40) NOT NULL,
	[ORG_ID] [varchar](4) NOT NULL,
	[CONTACT_IDENT] [varchar](20) NOT NULL,
	[TELEPHONE_NUMBER_TXT] [varchar](20) NULL,
	[INDIVIDUAL_FULL_NAME] [varchar](70) NOT NULL,
	[CONTACT_CITY_NAME] [varchar](50) NULL,
	[CONTACT_ADDRESS_STATE_CD] [varchar](20) NULL,
	[CONTACT_ADDRESS_TXT] [varchar](150) NOT NULL,
	[CONTACT_ADDRESS_POSTAL_CD] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CONTACT] PRIMARY KEY CLUSTERED 
(
	[CONTACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CONTACT_ORG_ID] ON [UIC_CONTACT] 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Contact information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'CONTACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Contact information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Contact table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique contact for a well. (e.g. NMNR30005003490000). (ContactIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'CONTACT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The phone number of a contact for the well. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'TELEPHONE_NUMBER_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The legal and complete name of a contact person (including first name, middle name or initial, and surname) for the well. (IndividualFullName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'INDIVIDUAL_FULL_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, or village of the contact for a well. (ContactCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'CONTACT_CITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the state where the contact is located or the name of the country, if outside the U.S.  (ContactAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'CONTACT_ADDRESS_STATE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The street address of the contact for a well.  This can be physical location or a mailing address. (ContactAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'CONTACT_ADDRESS_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered.  (ContactAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT', @level2type=N'COLUMN',@level2name=N'CONTACT_ADDRESS_POSTAL_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ContactDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONTACT'
GO
/****** Object:  Table [dbo].[UIC_ENFORCEMENT]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_ENFORCEMENT](
	[ENFORCEMENT_ID] [varchar](40) NOT NULL,
	[ORG_ID] [varchar](4) NOT NULL,
	[ENFORCEMENT_IDENT] [varchar](20) NOT NULL,
	[ENFORCEMENT_ACT_DATE] [char](8) NOT NULL,
	[ENFORCEMENT_ACT_TYPE] [varchar](3) NOT NULL,
 CONSTRAINT [PK_ENFORCEMENT] PRIMARY KEY CLUSTERED 
(
	[ENFORCEMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_ENFRCMNT_ORG_ID] ON [UIC_ENFORCEMENT] 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Enforcement information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENFORCEMENT', @level2type=N'COLUMN',@level2name=N'ENFORCEMENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Enforcement information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENFORCEMENT', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Enforcement table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique  enforcement action (e.g. 08DI000566, …). (EnforcementIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENFORCEMENT', @level2type=N'COLUMN',@level2name=N'ENFORCEMENT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date the enforcement action was issued or filed (YYYYMMDD). (EnforcementActionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENFORCEMENT', @level2type=N'COLUMN',@level2name=N'ENFORCEMENT_ACT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of enforcement action taken by the EPA or states. (EnforcementActionType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENFORCEMENT', @level2type=N'COLUMN',@level2name=N'ENFORCEMENT_ACT_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EnforcementDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENFORCEMENT'
GO
/****** Object:  Table [dbo].[UIC_FACILITY]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_FACILITY](
	[FACILITY_ID] [varchar](40) NOT NULL,
	[ORG_ID] [varchar](4) NOT NULL,
	[FACILITY_IDENT] [varchar](20) NOT NULL,
	[LOCALITY_NAME] [varchar](128) NULL,
	[FACILITY_SITE_NAME] [varchar](80) NOT NULL,
	[FACILITY_PETITION_STATUS_CD] [varchar](128) NULL,
	[LOC_ADDRESS_STATE_CD] [varchar](128) NULL,
	[FACILITY_STATE_IDENT] [varchar](50) NOT NULL,
	[LOC_ADDRESS_TXT] [varchar](150) NOT NULL,
	[FACILITY_SITE_TYPE_CD] [varchar](128) NULL,
	[NAICS_CD] [varchar](128) NULL,
	[SIC_CD] [varchar](128) NULL,
	[LOC_ADDRESS_POSTAL_CD] [varchar](14) NOT NULL,
 CONSTRAINT [PK_FACILITY] PRIMARY KEY CLUSTERED 
(
	[FACILITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FACILITY_ORG_ID] ON [UIC_FACILITY] 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for multiple Facility information submissions. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'FACILITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for multiple Facility information submissions. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Facility table - The first four characters are the primacy agency code (appendix D).  The rest is DI program or State’s choice (letters and numbers only) identifying unique facility (e.g. DENR0000197590, …). (FacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'FACILITY_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, or village where the facility is located. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'LOCALITY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'FACILITY_SITE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status of review of no-migration petition (this is a technical demonstration required before Class I hazardous waste injection facilities may begin operating). (FacilityPetitionStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'FACILITY_PETITION_STATUS_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The U.S. Postal Service abbreviation that represents the state. (LocationAddressStateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'LOC_ADDRESS_STATE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Facility identification assigned by DI program or primacy state. (FacilityStateIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'FACILITY_STATE_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address that describes the physical (geographic) location of the main entrance of a facility site, including urban-style street address or rural address, well field entrance, etc. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'LOC_ADDRESS_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Class I well waste is disposed in either of two types of facilities: (1) Commercial- where the waste is generated offsite but transported to the disposal facility, or (2) Non-commercial-where the waste is generated onsite and disposed there also. (FacilitySiteTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'FACILITY_SITE_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The NAICS code that represents a subdivision of an industry that accommodates user needs in the United States (6-digits)--(Only primary code). (NAICSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'NAICS_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the economic activity of a company (4-digits)--(only the primary code). (SICCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'SIC_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location. (LocationAddressPostalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY', @level2type=N'COLUMN',@level2name=N'LOC_ADDRESS_POSTAL_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityListType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY'
GO
/****** Object:  Table [dbo].[UIC_GEOLOGY]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_GEOLOGY](
	[GEOLOGY_ID] [varchar](40) NOT NULL,
	[ORG_ID] [varchar](4) NOT NULL,
	[GEO_IDENT] [varchar](20) NOT NULL,
	[GEO_CONF_ZN_NAME] [varchar](255) NULL,
	[GEO_CONF_ZN_TOP_NUM] [varchar](20) NULL,
	[GEO_CONF_ZN_BOT_NUM] [varchar](20) NULL,
	[GEO_LITH_CONF_ZN_TXT] [varchar](255) NULL,
	[GEO_INJ_ZN_FORMATION_NAME] [varchar](255) NULL,
	[GEO_BOT_INJ_ZN_NUM] [varchar](20) NULL,
	[GEO_LITH_INJ_ZN_TXT] [varchar](255) NULL,
	[GEO_TOP_INJ_INTERVAL_NUM] [varchar](20) NULL,
	[GEO_BOT_INJ_INTERVAL_NUM] [varchar](20) NULL,
	[GEO_INJ_ZN_PERM_RATE_NUM] [varchar](20) NULL,
	[GEO_INJ_ZN_POR_PCNT_NUM] [varchar](20) NULL,
	[GEO_USDW_DEPTH_NUM] [varchar](20) NULL,
 CONSTRAINT [PK_GEOLOGY] PRIMARY KEY CLUSTERED 
(
	[GEOLOGY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_GEOLOGY_ORG_ID] ON [UIC_GEOLOGY] 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Geology information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEOLOGY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Geology information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Geology table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique geology information (e.g. 04DI0000000000 000566, …). (GeologyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geologic formation name. (GeologyConfiningZoneName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_CONF_ZN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The top of the geologic arresting layer that keeps injectate confined in the injection zone measured in feet below surface. (GeologyConfiningZoneTopNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_CONF_ZN_TOP_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The bottom of the geologic arresting layer that keeps injectate confined in the injection zone OR:The top of the vertical dimension of the zone in which waste is injected. -- measured in feet below surface. (GeologyConfiningZoneBottomNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_CONF_ZN_BOT_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Confining zone data in the form of a simple lithologic description of the formation. (GeologyLithologicConfiningZoneText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_LITH_CONF_ZN_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geologic formation name for injection zone. (GeologyInjectionZoneFormationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_INJ_ZN_FORMATION_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The bottom of the vertical dimension of the zone in which waste is injected, measured in feet below surface. (GeologyBottomInjectionZoneNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_BOT_INJ_ZN_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Injection zone data in the form of a simple lithologic description of the formation. (GeologyLithologicInjectionZoneText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_LITH_INJ_ZN_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The top of the vertical dimension of the specific layer(s) of the Injection. (GeologyTopInjectionIntervalNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_TOP_INJ_INTERVAL_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The bottom of the vertical dimension of the specific layer(s) of the Injection Zone in which waste is authorized to be injected into, measured in feet below surface. (GeologyBottomInjectionIntervalNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_BOT_INJ_INTERVAL_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The rate of diffusion of fluids (in this case liquid waste) under pressure through porous material (formation rock) that is measured in millidarcies (mD). (GeologyInjectioneZonePermeabilityRateNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_INJ_ZN_PERM_RATE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The percent of pore space the injection zone formation rock contains (measured in %). (GeologyInjectionZonePorosityPercentNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_INJ_ZN_POR_PCNT_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The depth (in feet) to the base of the underground source of drinking water (USDW). (GeologyUSDWDepthNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY', @level2type=N'COLUMN',@level2name=N'GEO_USDW_DEPTH_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GeologyDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_GEOLOGY'
GO
/****** Object:  Table [dbo].[UIC_PERMIT]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_PERMIT](
	[PERMIT_ID] [varchar](40) NOT NULL,
	[ORG_ID] [varchar](4) NOT NULL,
	[PERMIT_IDENT] [varchar](20) NOT NULL,
	[PERMIT_AOR_WELL_NUMBER_NUM] [varchar](20) NULL,
	[PERMIT_AUTHORIZED_STATUS_CD] [char](2) NOT NULL,
	[PERMIT_OWNERSHIP_TYPE_CD] [varchar](50) NULL,
	[PERMIT_AUTHORIZED_IDENT] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PERMIT] PRIMARY KEY CLUSTERED 
(
	[PERMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PERMIT_ORG_ID] ON [UIC_PERMIT] 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Permit information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'PERMIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Permit information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'ORG_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Permit table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique permit(e.g. 04DI0000000000WDW366, …). (PermitIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'PERMIT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number of wells identified in area of review (AOR) requiring corrective action. (PermitAORWellNumberNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'PERMIT_AOR_WELL_NUMBER_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identification of whether well is permitted or rule authorized.  If the well is permitted, the acceptable authorization types are individual, area, general, or emergency permits. (PermitAuthorizedStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'PERMIT_AUTHORIZED_STATUS_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of ownership for a UIC well. (PermitOwnershipTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'PERMIT_OWNERSHIP_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identification assigned by DI program or primacy state to permit or rule authorized well. (PermitAuthorizedIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT', @level2type=N'COLUMN',@level2name=N'PERMIT_AUTHORIZED_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT'
GO
/****** Object:  Table [dbo].[UIC_PERMIT_ACTIVITY]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_PERMIT_ACTIVITY](
	[PERMIT_ACTIVITY_ID] [varchar](40) NOT NULL,
	[PERMIT_ID] [varchar](40) NOT NULL,
	[PERMIT_ACT_IDENT] [varchar](20) NOT NULL,
	[PERMIT_ACT_ACT_TYPE_CD] [char](2) NOT NULL,
	[PERMIT_ACT_DATE] [char](8) NOT NULL,
	[PERMIT_ACT_PERMIT_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PERMIT_ACTIVITY] PRIMARY KEY CLUSTERED 
(
	[PERMIT_ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PRMT_ACT_PRM_ID] ON [UIC_PERMIT_ACTIVITY] 
(
	[PERMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Permit Activity information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PERMIT_ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Permit Activity information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PERMIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Permit Activity table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying the unique permit activity (e.g. TXRC0000000000WDW567, …). (PermitActivityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PERMIT_ACT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of permit action or authorization by rule. (PermitActivityActionTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PERMIT_ACT_ACT_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date (YYYYMMDD) corresponding to each acceptable value of Permit Action Type includes:

- Application Date for Permit Issuance: Date of receipt of an application by state or DI program for permit issued.

- Application Date for Major Permit Modification: Date of receipt of an application by the state or DI program for major permit modification.

- Permit Issued Date: Date of signature (approval) by state/DI official for the issuance/denial/ withdrawal of permit.

- Permit Denied/Withdrawn Date: Date of signature by state/DI official for the denial/withdrawal of permit.

- Approved Major Permit Modification Date: Approval date of a major permit modification.  This is a date where an approved major modification requires a complete technical review, public notification or review, and a final decision document signed by the regulating authority.

- File Review Date (Class II only): Date of rule-authorized file review to determine whether the well is in compliance with UIC regulatory requirements.
			 (PermitActivityDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PERMIT_ACT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Permit table. (PermitActivityPermitIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PERMIT_ACT_PERMIT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitActivityDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_PERMIT_ACTIVITY'
GO
/****** Object:  Table [dbo].[UIC_FACILITY_INSPECTION]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_FACILITY_INSPECTION](
	[FACILITY_INSPECTION_ID] [varchar](40) NOT NULL,
	[FACILITY_ID] [varchar](40) NOT NULL,
	[INSP_IDENT] [varchar](20) NOT NULL,
	[INSP_ACT_DATE] [char](8) NOT NULL,
	[INSP_TYPE_ACT_CD] [char](2) NOT NULL,
	[INSP_FACILITY_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_FCILTY_INSPCTON] PRIMARY KEY CLUSTERED 
(
	[FACILITY_INSPECTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FCLT_INS_FCL_ID] ON [UIC_FACILITY_INSPECTION] 
(
	[FACILITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Facility Inspection information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION', @level2type=N'COLUMN',@level2name=N'FACILITY_INSPECTION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Facility Inspection information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION', @level2type=N'COLUMN',@level2name=N'FACILITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Inspection table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique  inspection (e.g. WYEQ00 000566, …). (InspectionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date inspection action was completed (YYYYMMDD). (InspectionActionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ACT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of inspection action that was conducted. (InspectionTypeActionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_TYPE_ACT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Facility table- This field ONLY applies for Class V “No Well” inspection. (InspectionFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_FACILITY_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityInspectionDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_INSPECTION'
GO
/****** Object:  Table [dbo].[UIC_WELL]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WELL](
	[WELL_ID] [varchar](40) NOT NULL,
	[FACILITY_ID] [varchar](40) NOT NULL,
	[WELL_IDENT] [varchar](20) NOT NULL,
	[WELL_AQUIF_EXEMPT_INJ_CD] [varchar](128) NULL,
	[WELL_TOTAL_DEPTH_NUM] [varchar](128) NULL,
	[WELL_HI_PRI_DESIGNATION_CD] [varchar](128) NULL,
	[WELL_CONTACT_IDENT] [varchar](20) NOT NULL,
	[WELL_FACILITY_IDENT] [varchar](20) NOT NULL,
	[WELL_GEO_IDENT] [varchar](20) NULL,
	[WELL_SITE_AREA_NAME_TXT] [varchar](128) NULL,
	[WELL_PERMIT_IDENT] [varchar](20) NOT NULL,
	[WELL_STATE_IDENT] [varchar](20) NOT NULL,
	[WELL_STATE_TRIBAL_CD] [varchar](128) NULL,
	[WELL_IN_SRC_WATER_AREA_LOC_TXT] [varchar](128) NULL,
	[WELL_NAME] [varchar](128) NULL,
	[LOC_IDENT] [varchar](20) NOT NULL,
	[LOC_ADDRESS_COUNTY] [varchar](128) NULL,
	[LOC_ACCURACY_VALUE_MEASURE] [varchar](20) NULL,
	[GEO_REF_PT_CD] [varchar](50) NULL,
	[HORZ_COORD_REF_SYS_DATUM_CD] [varchar](50) NULL,
	[HORZ_COLLECTION_METHOD_CD] [varchar](50) NULL,
	[LOC_PT_LINE_AREA_CD] [varchar](50) NULL,
	[SRC_MAP_SCALE_NUM] [varchar](50) NULL,
	[LOC_WELL_IDENT] [varchar](20) NOT NULL,
	[LATITUDE_MEASURE] [varchar](20) NULL,
	[LONGITUDE_MEASURE] [varchar](20) NULL,
 CONSTRAINT [PK_WELL] PRIMARY KEY CLUSTERED 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WELL_FCILITY_ID] ON [UIC_WELL] 
(
	[FACILITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'FACILITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique well (e.g. TXEQWDW366, …). (WellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Well injects into exempting aquifer. (WellAquiferExemptionInjectionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_AQUIF_EXEMPT_INJ_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The vertical depth (in feet) from the surface to the bottom of injection well. (WellTotalDepthNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_TOTAL_DEPTH_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'High priority Class V wells include all active motor vehicle waste disposal wells (MVWDWs) and large-capacity cesspools regulated under the 1999 Class V Rule, industrial wells, plus all other Class V wells identified as high priority by State Directors. (WellHighPriorityDesignationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_HI_PRI_DESIGNATION_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Contact record. (WellContactIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_CONTACT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Facility record. (WellFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_FACILITY_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification for Geology record. (WellGeologyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_GEO_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the area where many Class III, IV, or V ( storm water drainage) injection wells are physically located or conducted. (WellSiteAreaNameText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_SITE_AREA_NAME_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Permit table. (WellPermitIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_PERMIT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The well identification assigned by primacy state or direct implementation (DI) program. (WellStateIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_STATE_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State postal code or tribal code (for American Indian or Alaska Native) indicating a program Directly Implemented by an EPA region (for DI programs). (WellStateTribalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_STATE_TRIBAL_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The well location in relation to the boundary of the ground water based source water area (SWA) delineated by the primacy state under the State Source Water Assessment Program (SWAP). (WellInSourceWaterAreaLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_IN_SRC_WATER_AREA_LOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that designates the well. (WellName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'WELL_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Location table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only identifying unique location (e.g. 03DI0000000000M00905). (LocationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LOC_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the U.S. county or county equivalent in which the regulated well is physically located. (LocationAddressCounty)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LOC_ADDRESS_COUNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quantitative measurement of the amount of deviation from true value in a measurement for latitude or longitude (estimate of error).  It describes the correctness of the latitude/longitude measurement, in meters.  Only the least accurate measurement is recorded, regardless whether it is for longitude or latitude. (LocationAccuracyValueMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LOC_ACCURACY_VALUE_MEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code representing the category of the feature referenced by the latitude and longitude. (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code representing the reference standard for three dimensional and horizontal positioning established by the U.S. National Geodetic Survey (NGS) and other bodies. (HorizontalCoordinateReferenceSystemDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'HORZ_COORD_REF_SYS_DATUM_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code representing the method used to determine the latitude/longitude.  This represents the primary source of the data. (HorizontalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'HORZ_COLLECTION_METHOD_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code representing the value indicating whether the latitude and longitude coordinates represent a point, multiple points on a line, or an area. (LocationPointLineAreaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LOC_PT_LINE_AREA_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code representing the scale of the map used to determine the latitude and longitude coordinates. (SourceMapScaleNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table. (LocationWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LOC_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Coordinate representing a location on the surface of the earth, using the earth''s Equator as the origin, reported in decimal format.  If an area permit is being requested, give the latitude and longitude of the approximate center of the area. (LatitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LATITUDE_MEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Coordinate representing a location on the surface of the earth, using the Prime Meridian (Greenwich, England) as the origin, reported in decimal format. If an area permit is being requested, give the latitude and longitude of the approximate center of the area. (LongitudeMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL', @level2type=N'COLUMN',@level2name=N'LONGITUDE_MEASURE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WellDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL'
GO
/****** Object:  Table [dbo].[UIC_FACILITY_VIOLATION]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_FACILITY_VIOLATION](
	[FACILITY_VIOLATION_ID] [varchar](40) NOT NULL,
	[FACILITY_ID] [varchar](40) NOT NULL,
	[VIOLATION_IDENT] [varchar](20) NOT NULL,
	[VIOLATION_CONTAMINATION_CD] [varchar](128) NULL,
	[VIOLATION_ENDANGERING_CD] [varchar](128) NULL,
	[VIOLATION_RTN_COMPL_DATE] [char](8) NULL,
	[VIOLATION_SIGNIFICANT_CD] [varchar](128) NULL,
	[VIOLATION_DETERMINED_DATE] [char](8) NOT NULL,
	[VIOLATION_TYPE_CD] [char](2) NOT NULL,
	[VIOLATION_FACILITY_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_FCILITY_VIOLTON] PRIMARY KEY CLUSTERED 
(
	[FACILITY_VIOLATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FCLT_VLT_FCL_ID] ON [UIC_FACILITY_VIOLATION] 
(
	[FACILITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Facility Violation information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'FACILITY_VIOLATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Facility Violation information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'FACILITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Violation table - The first four characters are the primacy agency code (appendix D).  The rest is DI program or State’s choice (letters and numbers only) identifying unique  violation (e.g. 08DI000366, …). (ViolationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Well in noncompliance has allegedly contaminated an underground source of drinking water (USDW) this year to date. (ViolationContaminationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_CONTAMINATION_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A violation that results in the well potentially or actually endangering the USDW.  The endangering fluid contaminant from the well is in violation of RCRA or SDWA or applicable regulations. (ViolationEndangeringCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_ENDANGERING_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the violation determined date (YYYYMMDD). (ViolationReturnComplianceDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_RTN_COMPL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The indication whether or not the violation is in Significant Non-Compliance (SNC). (ViolationSignificantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_SIGNIFICANT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation (YYYYMMDD). (ViolationDeterminedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_DETERMINED_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of violation that is the subject of the Violation Date. (ViolationTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Facility table-  This field ONLY applies for Class V violations at FACILITY. (ViolationFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_FACILITY_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityViolationDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_VIOLATION'
GO
/****** Object:  Table [dbo].[UIC_WELL_INSPECTION]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WELL_INSPECTION](
	[WELL_INSPECTION_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[INSP_IDENT] [varchar](20) NOT NULL,
	[INSP_ASSISTANCE_CD] [varchar](50) NULL,
	[INSP_DEFICIENCY_CD] [varchar](50) NULL,
	[INSP_ACT_DATE] [char](8) NOT NULL,
	[INSP_ICIS_COMPL_MONTR_RSN_CD] [varchar](50) NULL,
	[INSP_ICIS_COMPL_MONTR_TYPE_CD] [varchar](50) NULL,
	[INSP_ICIS_COMPL_ACT_TYPE_CD] [varchar](50) NULL,
	[INSP_ICIS_MOA_NAME] [varchar](128) NULL,
	[INSP_ICIS_RGN_PRI_NAME] [varchar](128) NULL,
	[INSP_TYPE_ACT_CD] [char](2) NOT NULL,
	[INSP_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_WELL_INSPECTION] PRIMARY KEY CLUSTERED 
(
	[WELL_INSPECTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WLL_INSP_WLL_ID] ON [UIC_WELL_INSPECTION] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Inspection information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'WELL_INSPECTION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Inspection information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Inspection table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique  inspection (e.g. WYEQ00 000566, …). (InspectionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Compliance assistance provided by the inspector based on national policy:

-- General Assistance: involves distributing prepared information on regulatory compliance, P2 or other written materials/websites.

-- Site-specific Assistance: involves on-site assistance by the inspector to support actions taken to address deficiencies. (InspectionAssistanceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ASSISTANCE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Potential violations found by EPA inspector during inspection. (InspectionDeficiencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_DEFICIENCY_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date inspection action was completed (YYYYMMDD). (InspectionActionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ACT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason for performing a Compliance Monitoring action:

-- Agency Priority: The compliance monitoring action was performed in furtherance of a priority or initiative of the Compliance Monitoring Agency or a partner agency.

-- Core Program: The compliance monitoring action was performed as part of the Compliance Monitoring Agency''s core programmatic activities.

-- Selected Monitoring Action: The Compliance Monitoring Agency selected the facility or regulated entity for compliance monitoring in response to a referral from another unit. 
 (InspectionICISComplianceMonitoringReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ICIS_COMPL_MONTR_RSN_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of compliance monitoring taken by a regulatory agency. (InspectionICISComplianceMonitoringTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ICIS_COMPL_MONTR_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of compliance activity taken by a regulatory agency. (InspectionICISComplianceActivityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ICIS_COMPL_ACT_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of Memorandum of Agreement (MOA) associated with the activity. (InspectionICISMOAName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ICIS_MOA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of regional priority associated with the activity. (InspectionICISRegionalPriorityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_ICIS_RGN_PRI_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of inspection action that was conducted. (InspectionTypeActionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_TYPE_ACT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table. (InspectionWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION', @level2type=N'COLUMN',@level2name=N'INSP_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WellInspectionDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_INSPECTION'
GO
/****** Object:  Table [dbo].[UIC_MI_TEST]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_MI_TEST](
	[MI_TEST_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[MECH_INTEG_TST_IDENT] [varchar](20) NOT NULL,
	[MECH_INTEG_TST_COMPLETED_DATE] [char](8) NOT NULL,
	[MECH_INTEG_TST_RESULT_CD] [char](2) NOT NULL,
	[MECH_INTEG_TST_TYPE_CD] [char](2) NOT NULL,
	[MECH_INTEG_TST_REM_ACT_DATE] [char](8) NULL,
	[MECH_INTEG_TST_REM_ACT_TYPE_CD] [varchar](50) NULL,
	[MECH_INTEG_TST_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_MI_TEST] PRIMARY KEY CLUSTERED 
(
	[MI_TEST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_MI_TEST_WELL_ID] ON [UIC_MI_TEST] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for MI Test information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MI_TEST_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for MI Test information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Mechanical Integrity Test table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique MIT (e.g. 03DIVA000235, …). (MechanicalIntegrityTestIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date that mechanical integrity test was completed (YYYYMMDD). (MechanicalIntegrityTestCompletedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_COMPLETED_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The result of mechanical integrity test on that date (see above). (MechanicalIntegrityTestResultCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_RESULT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of mechanical integrity test. (MechanicalIntegrityTestTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date (corresponding to Remedial Action Type) when a well that failed an MI test received successful remedial action (YYYYMMDD). (MechanicalIntegrityTestRemedialActionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_REM_ACT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of successful remedial action that well has received on the remedial action date. (MechanicalIntegrityTestRemedialActionTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_REM_ACT_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table. (MechanicalIntegrityTestWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST', @level2type=N'COLUMN',@level2name=N'MECH_INTEG_TST_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: MITestDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_MI_TEST'
GO
/****** Object:  Table [dbo].[UIC_FACILITY_RESPONSE]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_FACILITY_RESPONSE](
	[FACILITY_RESPONSE_ID] [varchar](40) NOT NULL,
	[FACILITY_VIOLATION_ID] [varchar](40) NOT NULL,
	[RESPONSE_ENFORCEMENT_IDENT] [varchar](20) NOT NULL,
	[RESPONSE_VIOLATION_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_FCILITY_RSPONSE] PRIMARY KEY CLUSTERED 
(
	[FACILITY_RESPONSE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FCL_RS_FC_VL_ID] ON [UIC_FACILITY_RESPONSE] 
(
	[FACILITY_VIOLATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Response information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_RESPONSE', @level2type=N'COLUMN',@level2name=N'FACILITY_RESPONSE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Response information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_RESPONSE', @level2type=N'COLUMN',@level2name=N'FACILITY_VIOLATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Enforcement table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State’s choice (letters and numbers only identifying unique  enforcement action (e.g. 08DI000766, …). (ResponseEnforcementIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_RESPONSE', @level2type=N'COLUMN',@level2name=N'RESPONSE_ENFORCEMENT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Violation table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State’s choice (letters and numbers only identifying unique violation (e.g. 08DI000905, …). (ResponseViolationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_RESPONSE', @level2type=N'COLUMN',@level2name=N'RESPONSE_VIOLATION_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityResponseDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_FACILITY_RESPONSE'
GO
/****** Object:  Table [dbo].[UIC_ENGINEERING]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_ENGINEERING](
	[ENGINEERING_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[ENGR_IDENT] [varchar](20) NOT NULL,
	[ENGR_MAX_FLOW_RATE_NUM] [varchar](20) NULL,
	[ENGR_PERM_ONSITE_INJ_VOL_NUM] [varchar](20) NULL,
	[ENGR_PERM_OFFSITE_INJ_VOL_NUM] [varchar](20) NULL,
	[ENGR_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ENGINEERING] PRIMARY KEY CLUSTERED 
(
	[ENGINEERING_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_ENGINRNG_WLL_ID] ON [UIC_ENGINEERING] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Engineering information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'ENGINEERING_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Engineering information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Engineering table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only identifying unique engineering information  (e.g. WYEQ00000543, …). (EngineeringIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'ENGR_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Maximum flow rate of injectate in the current quartermeasured in gallons per minute. (EngineeringMaximumFlowRateNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'ENGR_MAX_FLOW_RATE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permitted on-site injected volume measured in million gallon per month. (EngineeringPermittedOnsiteInjectionVolumeNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'ENGR_PERM_ONSITE_INJ_VOL_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permitted off-site injected volume measured in million gallon per month. (EngineeringPermittedOffsiteInjectionVolumeNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'ENGR_PERM_OFFSITE_INJ_VOL_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of an injection well. (EngineeringWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING', @level2type=N'COLUMN',@level2name=N'ENGR_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EngineeringDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_ENGINEERING'
GO
/****** Object:  Table [dbo].[UIC_WASTE]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WASTE](
	[WASTE_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[WASTE_IDENT] [varchar](20) NOT NULL,
	[WASTE_CD] [varchar](50) NULL,
	[WASTE_STREAM_CLASSIFICATION_CD] [varchar](50) NULL,
	[WASTE_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_WASTE] PRIMARY KEY CLUSTERED 
(
	[WASTE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WASTE_WELL_ID] ON [UIC_WASTE] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Waste information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE', @level2type=N'COLUMN',@level2name=N'WASTE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Waste information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification for waste records - The first four characters are primacy agency code (appendix D) and followed by 8 additional characters identifying unique waste (e.g. WYEQ00000543, …). (WasteIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE', @level2type=N'COLUMN',@level2name=N'WASTE_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The RCRA or state waste code included when the constituent has been assigned a code. (WasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE', @level2type=N'COLUMN',@level2name=N'WASTE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A classification of the waste stream that contains various constituents and waste codes in various concentrations.  These are liquids waste approved to go down the well. (WasteStreamClassificationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE', @level2type=N'COLUMN',@level2name=N'WASTE_STREAM_CLASSIFICATION_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of an injection well. (WasteWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE', @level2type=N'COLUMN',@level2name=N'WASTE_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WasteDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WASTE'
GO
/****** Object:  Table [dbo].[UIC_WELL_VIOLATION]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WELL_VIOLATION](
	[WELL_VIOLATION_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[VIOLATION_IDENT] [varchar](20) NOT NULL,
	[VIOLATION_CONTAMINATION_CD] [varchar](50) NULL,
	[VIOLATION_ENDANGERING_CD] [varchar](50) NULL,
	[VIOLATION_RTN_COMPL_DATE] [char](8) NULL,
	[VIOLATION_SIGNIFICANT_CD] [varchar](50) NULL,
	[VIOLATION_DETERMINED_DATE] [char](8) NOT NULL,
	[VIOLATION_TYPE_CD] [char](2) NOT NULL,
	[VIOLATION_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_WELL_VIOLATION] PRIMARY KEY CLUSTERED 
(
	[WELL_VIOLATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WLL_VLTN_WLL_ID] ON [UIC_WELL_VIOLATION] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Violation information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'WELL_VIOLATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Violation information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Violation table - The first four characters are the primacy agency code (appendix D).  The rest is DI program or State’s choice (letters and numbers only) identifying unique  violation (e.g. 08DI000366, …). (ViolationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Well in noncompliance has allegedly contaminated an underground source of drinking water (USDW) this year to date. (ViolationContaminationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_CONTAMINATION_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A violation that results in the well potentially or actually endangering the USDW.  The endangering fluid contaminant from the well is in violation of RCRA or SDWA or applicable regulations. (ViolationEndangeringCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_ENDANGERING_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the violation determined date (YYYYMMDD). (ViolationReturnComplianceDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_RTN_COMPL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The indication whether or not the violation is in Significant Non-Compliance (SNC). (ViolationSignificantCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_SIGNIFICANT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation (YYYYMMDD). (ViolationDeterminedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_DETERMINED_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of violation that is the subject of the Violation Date. (ViolationTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table. (ViolationWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION', @level2type=N'COLUMN',@level2name=N'VIOLATION_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WellViolationDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_VIOLATION'
GO
/****** Object:  Table [dbo].[UIC_WELL_TYPE]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WELL_TYPE](
	[WELL_TYPE_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[WELL_TYPE_IDENT] [varchar](20) NOT NULL,
	[WELL_TYPE_CD] [varchar](20) NOT NULL,
	[WELL_TYPE_DATE] [char](8) NOT NULL,
	[WELL_TYPE_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_WELL_TYPE] PRIMARY KEY CLUSTERED 
(
	[WELL_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WLL_TYPE_WLL_ID] ON [UIC_WELL_TYPE] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Type information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE', @level2type=N'COLUMN',@level2name=N'WELL_TYPE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Type information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well Type table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying unique well type (e.g. TXEQWDW369, …). (WellTypeIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE', @level2type=N'COLUMN',@level2name=N'WELL_TYPE_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of injection wells located at the listed facility. (WellTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE', @level2type=N'COLUMN',@level2name=N'WELL_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that well type is determined (YYYYMMDD).  This field ONLY applies when the well changes from one well type to another well type (e.g. converted from injection to production). (WellTypeDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE', @level2type=N'COLUMN',@level2name=N'WELL_TYPE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table. (WellTypeWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE', @level2type=N'COLUMN',@level2name=N'WELL_TYPE_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WellTypeDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_TYPE'
GO
/****** Object:  Table [dbo].[UIC_WELL_STATUS]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WELL_STATUS](
	[WELL_STATUS_ID] [varchar](40) NOT NULL,
	[WELL_ID] [varchar](40) NOT NULL,
	[WELL_STATUS_IDENT] [varchar](20) NOT NULL,
	[WELL_STATUS_DATE] [char](8) NOT NULL,
	[WELL_STATUS_OPER_STATUS_CD] [char](2) NOT NULL,
	[WELL_STATUS_WELL_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_WELL_STATUS] PRIMARY KEY CLUSTERED 
(
	[WELL_STATUS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WLL_STTS_WLL_ID] ON [UIC_WELL_STATUS] 
(
	[WELL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Status information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS', @level2type=N'COLUMN',@level2name=N'WELL_STATUS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Well Status information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS', @level2type=N'COLUMN',@level2name=N'WELL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well Status table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only identifying the unique Well Status (e.g. TXEQ WDW369, …). (WellStatusIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS', @level2type=N'COLUMN',@level2name=N'WELL_STATUS_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that well status is determined (YYYYMMDD). (WellStatusDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS', @level2type=N'COLUMN',@level2name=N'WELL_STATUS_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current operating status of well. (WellStatusOperatingStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS', @level2type=N'COLUMN',@level2name=N'WELL_STATUS_OPER_STATUS_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Well table. (WellStatusWellIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS', @level2type=N'COLUMN',@level2name=N'WELL_STATUS_WELL_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WellStatusDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_STATUS'
GO
/****** Object:  Table [dbo].[UIC_WELL_RESPONSE]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_WELL_RESPONSE](
	[WELL_RESPONSE_ID] [varchar](40) NOT NULL,
	[WELL_VIOLATION_ID] [varchar](40) NOT NULL,
	[RESPONSE_ENFORCEMENT_IDENT] [varchar](20) NOT NULL,
	[RESPONSE_VIOLATION_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_WELL_RESPONSE] PRIMARY KEY CLUSTERED 
(
	[WELL_RESPONSE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_WLL_RS_WL_VL_ID] ON [UIC_WELL_RESPONSE] 
(
	[WELL_VIOLATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Response information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_RESPONSE', @level2type=N'COLUMN',@level2name=N'WELL_RESPONSE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Response information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_RESPONSE', @level2type=N'COLUMN',@level2name=N'WELL_VIOLATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Enforcement table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State’s choice (letters and numbers only identifying unique  enforcement action (e.g. 08DI000766, …). (ResponseEnforcementIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_RESPONSE', @level2type=N'COLUMN',@level2name=N'RESPONSE_ENFORCEMENT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Violation table - The first four characters are the primacy agency code (Appendix D). The rest is DI program or State’s choice (letters and numbers only identifying unique violation (e.g. 08DI000905, …). (ResponseViolationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_RESPONSE', @level2type=N'COLUMN',@level2name=N'RESPONSE_VIOLATION_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: WellResponseDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_WELL_RESPONSE'
GO
/****** Object:  Table [dbo].[UIC_CORRECTION]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_CORRECTION](
	[CORRECTION_ID] [varchar](40) NOT NULL,
	[WELL_INSPECTION_ID] [varchar](40) NOT NULL,
	[CORRECTION_IDENT] [varchar](20) NOT NULL,
	[CORRECTION_ACT_TYPE_CD] [varchar](50) NULL,
	[CORRECTION_COMMENT_TXT] [varchar](255) NULL,
	[CORRECTION_INSP_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CORRECTION] PRIMARY KEY CLUSTERED 
(
	[CORRECTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CRRC_WLL_INS_ID] ON [UIC_CORRECTION] 
(
	[WELL_INSPECTION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Correction information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION', @level2type=N'COLUMN',@level2name=N'CORRECTION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Correction information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION', @level2type=N'COLUMN',@level2name=N'WELL_INSPECTION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Correction table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only identifying the unique  corrective action (e.g. 04DI00000139, …). (CorrectionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION', @level2type=N'COLUMN',@level2name=N'CORRECTION_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of actions taken to correct deficiencies. (CorrectionActionTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION', @level2type=N'COLUMN',@level2name=N'CORRECTION_ACT_TYPE_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Narrative description of actions taken by the facility or assistance to help the facility come into compliance. (CorrectionCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION', @level2type=N'COLUMN',@level2name=N'CORRECTION_COMMENT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identification of Inspection table. (CorrectionInspectionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION', @level2type=N'COLUMN',@level2name=N'CORRECTION_INSP_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectionDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CORRECTION'
GO
/****** Object:  Table [dbo].[UIC_CONSTITUENT]    Script Date: 04/06/2011 14:35:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [UIC_CONSTITUENT](
	[CONSTITUENT_ID] [varchar](40) NOT NULL,
	[WASTE_ID] [varchar](40) NOT NULL,
	[CONSTITUENT_IDENT] [varchar](20) NOT NULL,
	[MEASURE_VALUE] [varchar](20) NULL,
	[MEASURE_UNIT_CD] [varchar](50) NULL,
	[CONSTITUENT_NAME_TXT] [varchar](255) NULL,
	[CONSTITUENT_WASTE_IDENT] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CONSTITUENT] PRIMARY KEY CLUSTERED 
(
	[CONSTITUENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CNSTTNT_WSTE_ID] ON [UIC_CONSTITUENT] 
(
	[WASTE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Constituent information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'CONSTITUENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Container for Constituent information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'WASTE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification of Constituent  table - The first four characters are the primacy agency code (appendix D). The rest is DI program or State’s choice (letters and numbers only) identifying constituent information (e.g. WYEQ0000000000 000389, …). (ConstituentIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'CONSTITUENT_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The concentration of the individual waste constituent as reported by EPA Regional staff and/or state agency staff (measured in mg/l or pCi/l). (MeasureValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'MEASURE_VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unit of measuring concentration (mg/l or pCi/l). (MeasureUnitCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'MEASURE_UNIT_CD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The chemical name or a description of the waste, in accordance with EPA Chemical/Biological Internal Tracking Name (http://www.epa.gov/srs/). (ConstituentNameText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'CONSTITUENT_NAME_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identification for waste records. (ConstituentWasteIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT', @level2type=N'COLUMN',@level2name=N'CONSTITUENT_WASTE_IDENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ConstituentDetailType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UIC_CONSTITUENT'
GO
/****** Object:  ForeignKey [FK_CONSTITUNT_WSTE]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_CONSTITUENT]  WITH CHECK ADD  CONSTRAINT [FK_CONSTITUNT_WSTE] FOREIGN KEY([WASTE_ID])
REFERENCES [UIC_WASTE] ([WASTE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_CONSTITUENT] CHECK CONSTRAINT [FK_CONSTITUNT_WSTE]
GO
/****** Object:  ForeignKey [FK_CONTACT_ORG]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_CONTACT]  WITH CHECK ADD  CONSTRAINT [FK_CONTACT_ORG] FOREIGN KEY([ORG_ID])
REFERENCES [UIC_ORG] ([ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_CONTACT] CHECK CONSTRAINT [FK_CONTACT_ORG]
GO
/****** Object:  ForeignKey [FK_CRRCT_WLL_INSPC]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_CORRECTION]  WITH CHECK ADD  CONSTRAINT [FK_CRRCT_WLL_INSPC] FOREIGN KEY([WELL_INSPECTION_ID])
REFERENCES [UIC_WELL_INSPECTION] ([WELL_INSPECTION_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_CORRECTION] CHECK CONSTRAINT [FK_CRRCT_WLL_INSPC]
GO
/****** Object:  ForeignKey [FK_ENFORCEMENT_ORG]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_ENFORCEMENT]  WITH CHECK ADD  CONSTRAINT [FK_ENFORCEMENT_ORG] FOREIGN KEY([ORG_ID])
REFERENCES [UIC_ORG] ([ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_ENFORCEMENT] CHECK CONSTRAINT [FK_ENFORCEMENT_ORG]
GO
/****** Object:  ForeignKey [FK_ENGINEERING_WLL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_ENGINEERING]  WITH CHECK ADD  CONSTRAINT [FK_ENGINEERING_WLL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_ENGINEERING] CHECK CONSTRAINT [FK_ENGINEERING_WLL]
GO
/****** Object:  ForeignKey [FK_FACILITY_ORG]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_FACILITY]  WITH CHECK ADD  CONSTRAINT [FK_FACILITY_ORG] FOREIGN KEY([ORG_ID])
REFERENCES [UIC_ORG] ([ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_FACILITY] CHECK CONSTRAINT [FK_FACILITY_ORG]
GO
/****** Object:  ForeignKey [FK_FCLTY_INSP_FCLT]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_FACILITY_INSPECTION]  WITH CHECK ADD  CONSTRAINT [FK_FCLTY_INSP_FCLT] FOREIGN KEY([FACILITY_ID])
REFERENCES [UIC_FACILITY] ([FACILITY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_FACILITY_INSPECTION] CHECK CONSTRAINT [FK_FCLTY_INSP_FCLT]
GO
/****** Object:  ForeignKey [FK_FCL_RSP_FCL_VLT]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_FACILITY_RESPONSE]  WITH CHECK ADD  CONSTRAINT [FK_FCL_RSP_FCL_VLT] FOREIGN KEY([FACILITY_VIOLATION_ID])
REFERENCES [UIC_FACILITY_VIOLATION] ([FACILITY_VIOLATION_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_FACILITY_RESPONSE] CHECK CONSTRAINT [FK_FCL_RSP_FCL_VLT]
GO
/****** Object:  ForeignKey [FK_FCLTY_VLTN_FCLT]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_FACILITY_VIOLATION]  WITH CHECK ADD  CONSTRAINT [FK_FCLTY_VLTN_FCLT] FOREIGN KEY([FACILITY_ID])
REFERENCES [UIC_FACILITY] ([FACILITY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_FACILITY_VIOLATION] CHECK CONSTRAINT [FK_FCLTY_VLTN_FCLT]
GO
/****** Object:  ForeignKey [FK_GEOLOGY_ORG]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_GEOLOGY]  WITH CHECK ADD  CONSTRAINT [FK_GEOLOGY_ORG] FOREIGN KEY([ORG_ID])
REFERENCES [UIC_ORG] ([ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_GEOLOGY] CHECK CONSTRAINT [FK_GEOLOGY_ORG]
GO
/****** Object:  ForeignKey [FK_MI_TEST_WELL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_MI_TEST]  WITH CHECK ADD  CONSTRAINT [FK_MI_TEST_WELL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_MI_TEST] CHECK CONSTRAINT [FK_MI_TEST_WELL]
GO
/****** Object:  ForeignKey [FK_PERMIT_ORG]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_PERMIT]  WITH CHECK ADD  CONSTRAINT [FK_PERMIT_ORG] FOREIGN KEY([ORG_ID])
REFERENCES [UIC_ORG] ([ORG_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_PERMIT] CHECK CONSTRAINT [FK_PERMIT_ORG]
GO
/****** Object:  ForeignKey [FK_PRMT_ACTVT_PRMT]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_PERMIT_ACTIVITY]  WITH CHECK ADD  CONSTRAINT [FK_PRMT_ACTVT_PRMT] FOREIGN KEY([PERMIT_ID])
REFERENCES [UIC_PERMIT] ([PERMIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_PERMIT_ACTIVITY] CHECK CONSTRAINT [FK_PRMT_ACTVT_PRMT]
GO
/****** Object:  ForeignKey [FK_WASTE_WELL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WASTE]  WITH CHECK ADD  CONSTRAINT [FK_WASTE_WELL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WASTE] CHECK CONSTRAINT [FK_WASTE_WELL]
GO
/****** Object:  ForeignKey [FK_WELL_FACILITY]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WELL]  WITH CHECK ADD  CONSTRAINT [FK_WELL_FACILITY] FOREIGN KEY([FACILITY_ID])
REFERENCES [UIC_FACILITY] ([FACILITY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WELL] CHECK CONSTRAINT [FK_WELL_FACILITY]
GO
/****** Object:  ForeignKey [FK_WLL_INSPCTN_WLL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WELL_INSPECTION]  WITH CHECK ADD  CONSTRAINT [FK_WLL_INSPCTN_WLL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WELL_INSPECTION] CHECK CONSTRAINT [FK_WLL_INSPCTN_WLL]
GO
/****** Object:  ForeignKey [FK_WLL_RSP_WLL_VLT]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WELL_RESPONSE]  WITH CHECK ADD  CONSTRAINT [FK_WLL_RSP_WLL_VLT] FOREIGN KEY([WELL_VIOLATION_ID])
REFERENCES [UIC_WELL_VIOLATION] ([WELL_VIOLATION_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WELL_RESPONSE] CHECK CONSTRAINT [FK_WLL_RSP_WLL_VLT]
GO
/****** Object:  ForeignKey [FK_WELL_STATUS_WLL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WELL_STATUS]  WITH CHECK ADD  CONSTRAINT [FK_WELL_STATUS_WLL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WELL_STATUS] CHECK CONSTRAINT [FK_WELL_STATUS_WLL]
GO
/****** Object:  ForeignKey [FK_WELL_TYPE_WELL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WELL_TYPE]  WITH CHECK ADD  CONSTRAINT [FK_WELL_TYPE_WELL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WELL_TYPE] CHECK CONSTRAINT [FK_WELL_TYPE_WELL]
GO
/****** Object:  ForeignKey [FK_WLL_VIOLTON_WLL]    Script Date: 04/06/2011 14:35:51 ******/
ALTER TABLE [UIC_WELL_VIOLATION]  WITH CHECK ADD  CONSTRAINT [FK_WLL_VIOLTON_WLL] FOREIGN KEY([WELL_ID])
REFERENCES [UIC_WELL] ([WELL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [UIC_WELL_VIOLATION] CHECK CONSTRAINT [FK_WLL_VIOLTON_WLL]
GO
