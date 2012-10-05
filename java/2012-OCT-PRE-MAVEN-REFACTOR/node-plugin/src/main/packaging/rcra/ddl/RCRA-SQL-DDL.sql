/****** Object:  Table [dbo].[RCRA_HD_HBASIC]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_HBASIC](
	[PK_GUID] [varchar](40) NOT NULL,
	[LAST_UPDATE_DATE] [timestamp] NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
	[EXTRACT_FLAG] [char](1) NULL,
	[FACILITY_IDENTIFIER] [varchar](12) NULL,
	[NOTES] [varchar](240) NULL,
 CONSTRAINT [PK_RCRA_HD_HBASIC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Designates that data is available for extract for public use. (PublicUseExtractIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'EXTRACT_FLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems. (FacilityRegistryID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'FACILITY_IDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes for the HBasic Identification table. (FacilitySupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_HAZRD_WASTE_CME_SUBM]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_HAZRD_WASTE_CME_SUBM](
	[HAZRD_WASTE_CME_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_RC_CM_HZ_WS_CM] PRIMARY KEY CLUSTERED 
(
	[HAZRD_WASTE_CME_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RCRA_CME_FAC_SUBM]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_FAC_SUBM](
	[CME_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[HAZRD_WASTE_CME_SUBM_ID] [varchar](40) NOT NULL,
	[EPA_HDLR_ID] [varchar](255) NOT NULL,
 CONSTRAINT [PK_RCRA_CME_FC_SBM] PRIMARY KEY CLUSTERED 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_FC_SB_HZ] ON [dbo].[RCRA_CME_FAC_SUBM] 
(
	[HAZRD_WASTE_CME_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: This contains Hbasic Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'CME_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: This contains Hbasic Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'HAZRD_WASTE_CME_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number that uniquely identifies the EPA handler. (EPAHandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'EPA_HDLR_ID'
GO
/****** Object:  Table [dbo].[RCRA_HD_HANDLER]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_HANDLER](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[ACKNOWLEDGE_FLAG] [char](1) NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[ACTIVITY_LOCATION] [char](2) NOT NULL,
	[SOURCE_TYPE] [char](1) NOT NULL,
	[SEQ_NUMBER] [int] NOT NULL,
	[RECEIVE_DATE] [varchar](10) NULL,
	[ACKNOWLEDGE_DATE] [varchar](10) NULL,
	[NON_NOTIFIER] [char](1) NULL,
	[NUMBER_OF_EMPLOYEES] [int] NULL,
	[TSD_DATE] [varchar](10) NULL,
	[OFF_SITE_RECEIPT] [char](1) NULL,
	[ACCESSIBILITY] [char](1) NULL,
	[COUNTY_CODE_OWNER] [char](2) NULL,
	[COUNTY_CODE] [varchar](5) NULL,
	[NOTES] [varchar](2000) NULL,
	[LOCATION_STREET1] [varchar](30) NULL,
	[LOCATION_STREET2] [varchar](30) NULL,
	[LOCATION_CITY] [varchar](25) NULL,
	[LOCATION_STATE] [char](2) NULL,
	[LOCATION_COUNTRY] [char](2) NULL,
	[LOCATION_ZIP] [varchar](14) NULL,
	[MAIL_STREET1] [varchar](30) NULL,
	[MAIL_STREET2] [varchar](30) NULL,
	[MAIL_CITY] [varchar](25) NULL,
	[MAIL_STATE] [char](2) NULL,
	[MAIL_COUNTRY] [char](2) NULL,
	[MAIL_ZIP] [varchar](14) NULL,
	[CONTACT_FIRST_NAME] [varchar](15) NULL,
	[CONTACT_LAST_NAME] [varchar](15) NULL,
	[CONTACT_MIDDLE_INITIAL] [char](1) NULL,
	[CONTACT_ORG_NAME] [varchar](80) NULL,
	[CONTACT_EMAIL_ADDRESS] [varchar](240) NULL,
	[CONTACT_PHONE] [varchar](15) NULL,
	[CONTACT_PHONE_EXT] [varchar](6) NULL,
	[CONTACT_STREET1] [varchar](30) NULL,
	[CONTACT_STREET2] [varchar](30) NULL,
	[CONTACT_CITY] [varchar](25) NULL,
	[CONTACT_STATE] [char](2) NULL,
	[CONTACT_COUNTRY] [char](2) NULL,
	[CONTACT_ZIP] [varchar](14) NULL,
	[PCONTACT_FIRST_NAME] [varchar](15) NULL,
	[PCONTACT_LAST_NAME] [varchar](15) NULL,
	[PCONTACT_MIDDLE_NAME] [char](1) NULL,
	[PCONTACT_ORG_NAME] [varchar](80) NULL,
	[PCONTACT_EMAIL_ADDRESS] [varchar](240) NULL,
	[PCONTACT_PHONE] [varchar](15) NULL,
	[PCONTACT_PHONE_EXT] [varchar](6) NULL,
	[PCONTACT_STREET1] [varchar](30) NULL,
	[PCONTACT_STREET2] [varchar](30) NULL,
	[PCONTACT_CITY] [varchar](25) NULL,
	[PCONTACT_STATE] [char](2) NULL,
	[PCONTACT_COUNTRY] [char](2) NULL,
	[PCONTACT_ZIP] [varchar](14) NULL,
	[USED_OIL_BURNER] [char](1) NULL,
	[USED_OIL_PROCESSOR] [char](1) NULL,
	[USED_OIL_REFINER] [char](1) NULL,
	[USED_OIL_MARKET_BURNER] [char](1) NULL,
	[USED_OIL_SPEC_MARKETER] [char](1) NULL,
	[USED_OIL_TRANSFER_FACILITY] [char](1) NULL,
	[USED_OIL_TRANSPORTER] [char](1) NULL,
	[SITE_NAME] [varchar](80) NULL,
	[LAND_TYPE] [char](1) NULL,
	[STATE_DISTRICT] [varchar](10) NULL,
	[IMPORTER_ACTIVITY] [char](1) NULL,
	[MIXED_WASTE_GENERATOR] [char](1) NULL,
	[RECYCLER_ACTIVITY] [char](1) NULL,
	[TRANSPORTER_ACTIVITY] [char](1) NULL,
	[TSD_ACTIVITY] [char](1) NULL,
	[UNDERGROUND_INJECTION_ACTIVITY] [char](1) NULL,
	[UNIVERSAL_WASTE_DEST_FACILITY] [char](1) NULL,
	[ONSITE_BURNER_EXEMPTION] [char](1) NULL,
	[FURNACE_EXEMPTION] [char](1) NULL,
	[FED_WASTE_GENERATOR_OWNER] [char](2) NULL,
	[FED_WASTE_GENERATOR] [char](1) NULL,
	[STATE_WASTE_GENERATOR_OWNER] [char](2) NULL,
	[STATE_WASTE_GENERATOR] [char](1) NULL,
 CONSTRAINT [PK_RCRA_HD_HANDLER] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_HD_HA_FK_GU] ON [dbo].[RCRA_HD_HANDLER] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Top level of all information about the handler. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Top level of all information about the handler. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Top level of all information about the handler. (AcknowledgeFlag)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACKNOWLEDGE_FLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACTIVITY_LOCATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'SOURCE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence number for each source record about a handler. (SourceRecordSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'SEQ_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'RECEIVE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date information was received for the handler. (AcknowledgeReceiptDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACKNOWLEDGE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NON_NOTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of employees currently working at the site. (OnsiteEmployeeQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NUMBER_OF_EMPLOYEES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date that operation of the facility commenced, the date construction on the facility commenced, or the date that operation is expected to begin. (TreatmentStorageDisposalDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'TSD_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status). (OffsiteWasteReceiptCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'OFF_SITE_RECEIPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the reason why the handler is not accessible for normal RCRA tracking and processing (previously called Bankrupt Indicator). (AccessibilityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACCESSIBILITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the county code. (CountyCodeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'COUNTY_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'COUNTY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding the Handler. (HandlerSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Location address information. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Location address information. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Location address information. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Location address information. (StateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Location address information. (CountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Location address information. (LocationZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_MIDDLE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the burning of used oil fuel. (FuelBurnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_BURNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in processing used oil activities. (ProcessorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_PROCESSOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in re-refining used oil activities. (RefinerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_REFINER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler directs shipments of used oil to burners. (MarketBurnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_MARKET_BURNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is a marketer who first claims the used oil meets the specifications. (SpecificationMarketerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_SPEC_MARKETER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler owns or operates a used oil transfer facility. (TransferFacilityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_TRANSFER_FACILITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in used oil transportation and/or transfer facility activities. (TransporterCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'USED_OIL_TRANSPORTER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The legal name of the site. (FacilitySiteName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'SITE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LAND_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_DISTRICT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'IMPORTER_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MIXED_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in recycling hazardous waste. (RecyclerActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'RECYCLER_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'TRANSPORTER_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the treatment, storage, or disposal of hazardous waste. (TreatmentStorageDisposalActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'TSD_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'UNDERGROUND_INJECTION_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'UNIVERSAL_WASTE_DEST_FACILITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ONSITE_BURNER_EXEMPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FURNACE_EXEMPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FED_WASTE_GENERATOR_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FED_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_WASTE_GENERATOR_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_WASTE_GENERATOR'
GO
/****** Object:  Table [dbo].[RCRA_HD_OTHER_ID]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_OTHER_ID](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[OTHER_ID] [varchar](12) NOT NULL,
	[RELATIONSHIP_OWNER] [char](2) NULL,
	[RELATIONSHIP_TYPE] [char](1) NULL,
	[SAME_FACILITY] [char](1) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_HD_OTHE_ID] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_HD_OT_ID_FK] ON [dbo].[RCRA_HD_OTHER_ID] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contains alternative identifiers for the facility. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contains alternative identifiers for the facility. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alternate facility identifier. (OtherHandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'OTHER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that owns the Relationship. (RelationshipOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'RELATIONSHIP_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the type of the relationship. (RelationshipTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'RELATIONSHIP_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether the alternate Id references the same facility. (SameFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'SAME_FACILITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding the alternative facility identifier. (OtherIDSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_HD_NAICS]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_NAICS](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[NAICS_SEQ] [int] NOT NULL,
	[NAICS_OWNER] [char](2) NULL,
	[NAICS_CODE] [varchar](6) NULL,
	[NOTES] [varchar](240) NULL,
 CONSTRAINT [PK_RCRA_HD_NAICS] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_HD_NA_FK_GU] ON [dbo].[RCRA_HD_NAICS] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: North American Industry Classification Status codes reported for the handler. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: North American Industry Classification Status codes reported for the handler. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence number for each NAICS code for the handler. (NAICSSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the NAICS Code. (NAICSOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The North American Industry Classification System Code that identifies the business activities of the facility. (NAICSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes for the handler NAICS Code. (NAICSSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_HD_WASTE_CODE]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_WASTE_CODE](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[WASTE_CODE_OWNER] [char](2) NULL,
	[WASTE_CODE_TYPE] [varchar](6) NULL,
 CONSTRAINT [PK_RCRA_HD_WAS_COD] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_HD_WA_CO_FK] ON [dbo].[RCRA_HD_WASTE_CODE] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that owns the data record. (WasteCodeOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to describe hazardous waste. (WasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_TYPE'
GO
/****** Object:  Table [dbo].[RCRA_HD_UNIVERSAL_WASTE]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_UNIVERSAL_WASTE](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[UNIVERSAL_WASTE_OWNER] [char](2) NULL,
	[UNIVERSAL_WASTE_TYPE] [char](1) NULL,
	[ACCUMULATED] [char](1) NULL,
	[GENERATED] [char](1) NULL,
	[NOTES] [varchar](240) NULL,
 CONSTRAINT [PK_RCRA_HD_UNI_WAS] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_HD_UN_WA_FK] ON [dbo].[RCRA_HD_UNIVERSAL_WASTE] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about universal waste generated by the handler. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about universal waste generated by the handler. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the universal waste type. (UniversalWasteOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'UNIVERSAL_WASTE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the type of universal waste. (UniversalWasteTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'UNIVERSAL_WASTE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in accumulating waste on site. (AccumulatedWasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'ACCUMULATED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in generating waste on site. (GeneratedHandlerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'GENERATED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding the handler Universal Waste Activity. (UniversalWasteSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_HD_STATE_ACTIVITY]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_STATE_ACTIVITY](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[STATE_ACTIVITY_OWNER] [char](2) NOT NULL,
	[STATE_ACTIVITY_TYPE] [varchar](5) NOT NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_HD_STA_ACT] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_HD_ST_AC_FK] ON [dbo].[RCRA_HD_STATE_ACTIVITY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: State waste activity of the handler. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: State waste activity of the handler. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the state activity type. (StateActivityOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'STATE_ACTIVITY_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the type of state activity. (StateActivityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'STATE_ACTIVITY_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding the Handler State Waste Activity. (StateActivitySupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_HD_OWNEROP]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_OWNEROP](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[OWNER_OP_SEQ] [int] NOT NULL,
	[OWNER_OP_IND] [char](2) NULL,
	[OWNER_OP_TYPE] [char](1) NULL,
	[DATE_BECAME_CURRENT] [varchar](10) NULL,
	[DATE_ENDED_CURRENT] [varchar](10) NULL,
	[DUNN_BRADSTREET_NUM] [varchar](10) NULL,
	[NOTES] [varchar](240) NULL,
	[FIRST_NAME] [varchar](15) NULL,
	[LAST_NAME] [varchar](15) NULL,
	[MIDDLE_INITIAL] [char](1) NULL,
	[ORG_NAME] [varchar](80) NULL,
	[EMAIL_ADDRESS] [varchar](240) NULL,
	[PHONE] [varchar](15) NULL,
	[PHONE_EXT] [varchar](6) NULL,
	[STREET1] [varchar](30) NULL,
	[STREET2] [varchar](30) NULL,
	[CITY] [varchar](25) NULL,
	[STATE] [char](2) NULL,
	[COUNTRY] [char](2) NULL,
	[ZIP] [varchar](14) NULL,
 CONSTRAINT [PK_RCRA_HD_OWNEROP] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_HD_OW_FK_GU] ON [dbo].[RCRA_HD_OWNEROP] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler owner and operator information. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler owner and operator information. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequential number used to order multiple occurrences of owners and operators. (OwnerOperatorSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'OWNER_OP_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating whether the data is associated with a current or previous owner or operator. The system will allow multiple current owners and operators. (OwnerOperatorIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'OWNER_OP_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the owner/operator type. (OwnerOperatorTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'OWNER_OP_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date indicating when the owner/operator became current. (CurrentStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'DATE_BECAME_CURRENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date indicating when the owner/operator changed to a different owner/operator. (CurrentEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'DATE_ENDED_CURRENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dunn and Bradstreet number used as an identifier (DUNSID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'DUNN_BRADSTREET_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes for the facility Owner Operator. (OwnerOperatorSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'ZIP'
GO
/****** Object:  Table [dbo].[RCRA_CME_VIOL]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_VIOL](
	[VIOL_ID] [varchar](40) NOT NULL,
	[CME_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[VIOL_ACT_LOC] [varchar](255) NOT NULL,
	[VIOL_SEQ_NUM] [int] NOT NULL,
	[AGN_WHICH_DTRM_VIOL] [varchar](255) NOT NULL,
	[VIOL_TYPE_OWNER] [varchar](255) NULL,
	[VIOL_TYPE] [varchar](255) NULL,
	[FORMER_CITATION_NAME] [varchar](128) NULL,
	[VIOL_DTRM_DATE] [datetime] NULL,
	[RTN_COMPL_ACTL_DATE] [datetime] NULL,
	[RTN_TO_COMPL_QUAL] [varchar](255) NULL,
	[VIOL_RESP_AGN] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_VIOL] PRIMARY KEY CLUSTERED 
(
	[VIOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_VL_CM_FC] ON [dbo].[RCRA_CME_VIOL] 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'CME_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationActivityLocation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_ACT_LOC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (AgencyWhichDeterminedViolation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'AGN_WHICH_DTRM_VIOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allowed value HQ (ViolationTypeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_TYPE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Violation Type (ViolationType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (FormerCitationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'FORMER_CITATION_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation. (ViolationDeterminedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_DTRM_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceActualDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'RTN_COMPL_ACTL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (ReturnToComplianceQualifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'RTN_TO_COMPL_QUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationResponsibleAgency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_RESP_AGN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_HD_ENV_PERMIT]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_ENV_PERMIT](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[ENV_PERMIT_NUMBER] [varchar](13) NOT NULL,
	[ENV_PERMIT_OWNER] [char](2) NULL,
	[ENV_PERMIT_TYPE] [char](1) NULL,
	[ENV_PERMIT_DESC] [varchar](20) NOT NULL,
	[NOTES] [varchar](240) NULL,
 CONSTRAINT [PK_RCRA_HD_ENV_PER] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_HD_EN_PE_FK] ON [dbo].[RCRA_HD_ENV_PERMIT] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about environmental permits issued to the handler. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about environmental permits issued to the handler. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identification number of an effective environmental permit issued to the handler, or the number of a filed application for which an environmental permit has not yet been issued. (EnvironmentalPermitID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'ENV_PERMIT_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the other permit type. (EnvironmentalPermitOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'ENV_PERMIT_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only. (EnvironmentalPermitTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'ENV_PERMIT_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of any permit type indicated as O (Other) in the Permit Type field. (EnvironmentalPermitDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'ENV_PERMIT_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes for the handler Environmental Permit. (EnvironmentalPermitSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_HD_CERTIFICATION]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_CERTIFICATION](
	[PK_GUID] [varchar](40) NOT NULL,
	[FK_GUID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[CERT_SEQ] [int] NOT NULL,
	[CERT_SIGNED_DATE] [varchar](10) NULL,
	[CERT_TITLE] [varchar](45) NULL,
	[CERT_FIRST_NAME] [varchar](15) NULL,
	[CERT_MIDDLE_INITIAL] [char](1) NULL,
	[CERT_LAST_NAME] [varchar](15) NULL,
	[NOTES] [varchar](245) NULL,
 CONSTRAINT [PK_RCRA_HD_CERTIFI] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_HD_CE_FK_GU] ON [dbo].[RCRA_HD_CERTIFICATION] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Certification information for the person who certified report to the authorizing agency. (PkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'PK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Certification information for the person who certified report to the authorizing agency. (FkGuid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'FK_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence number for each certification for the handler. (CertificationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the handler information was certified by the reporting site. (SignedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_SIGNED_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First name of a person. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Middle initial of a person. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last name of a person. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding the handler Certification. (CertificationSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_EVAL]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_EVAL](
	[EVAL_ID] [varchar](40) NOT NULL,
	[CME_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[EVAL_ACT_LOC] [varchar](255) NOT NULL,
	[EVAL_IDEN] [varchar](50) NOT NULL,
	[EVAL_START_DATE] [datetime] NOT NULL,
	[EVAL_RESP_AGN] [varchar](255) NOT NULL,
	[DAY_ZERO] [datetime] NULL,
	[FOUND_VIOL] [varchar](255) NULL,
	[CTZN_CPLT_IND] [varchar](50) NULL,
	[MULTIMEDIA_IND] [varchar](50) NULL,
	[SAMPL_IND] [varchar](50) NULL,
	[NOT_SUBTL_C_IND] [varchar](50) NULL,
	[EVAL_TYPE_OWNER] [varchar](255) NULL,
	[EVAL_TYPE] [varchar](255) NULL,
	[FOCUS_AREA_OWNER] [varchar](255) NULL,
	[FOCUS_AREA] [varchar](255) NULL,
	[EVAL_RESP_PERSON_IDEN_OWNER] [varchar](255) NULL,
	[EVAL_RESP_PERSON_IDEN] [varchar](50) NULL,
	[EVAL_RESP_SUBORG_OWNER] [varchar](255) NULL,
	[EVAL_RESP_SUBORG] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_EVAL] PRIMARY KEY CLUSTERED 
(
	[EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_EV_CM_FC] ON [dbo].[RCRA_CME_EVAL] 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'CME_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the EPA handler. (EvaluationActivityLocation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_ACT_LOC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name or number assigned by the implementing agency to identify an evaluation. (EvaluationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The first day of the inspection or record review regardless of the duration of the inspection. (EvaluationStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_START_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the agency responsible for conducting the evaluation. (EvaluationResponsibleAgency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_RESP_AGN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date fo the Last Non-Followup Evaluation (Applies to SNY/SNN Evaluations Only) (DayZero)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'DAY_ZERO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag indicating if a violation was found. (FoundViolation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'FOUND_VIOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The inspection or record review was initiated because of a tip/complaint (CitizenComplaintIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'CTZN_CPLT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (MultimediaIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'MULTIMEDIA_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (SamplingIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'SAMPL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniation made: sit is Non-Hazardous Waste. (NotSubtitleCIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'NOT_SUBTL_C_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the type of evaluation. (EvaluationTypeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_TYPE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code to report the type of evaluation conducted at the handler. (EvaluationType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusAreaOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'FOCUS_AREA_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusArea)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'FOCUS_AREA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (EvaluationResponsiblePersonIdentifierOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_RESP_PERSON_IDEN_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the evaluation. (EvaluationResponsiblePersonIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_RESP_PERSON_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the suborganization identifier. (EvaluationResponsibleSuborganizationOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_RESP_SUBORG_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the branch/district within the agency responsible for conducting the evaluation. (EvaluationResponsibleSuborganization)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'EVAL_RESP_SUBORG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_ENFRC_ACT]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_ENFRC_ACT](
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[CME_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[ENFRC_AGN_LOC_NAME] [varchar](128) NOT NULL,
	[ENFRC_ACT_IDEN] [varchar](50) NOT NULL,
	[ENFRC_ACT_DATE] [datetime] NOT NULL,
	[ENFRC_AGN_NAME] [varchar](128) NOT NULL,
	[ENFRC_DOCKET_NUM] [varchar](20) NULL,
	[ENFRC_ATTRY] [varchar](255) NULL,
	[CORCT_ACT_COMPT] [varchar](255) NULL,
	[CNST_AGMT_FINAL_ORDER_SEQ_NUM] [int] NULL,
	[APPEAL_INIT_DATE] [datetime] NULL,
	[APPEAL_RSLN_DATE] [datetime] NULL,
	[DISP_STAT_DATE] [datetime] NULL,
	[DISP_STAT_OWNER] [varchar](255) NULL,
	[DISP_STAT] [varchar](255) NULL,
	[ENFRC_OWNER] [varchar](255) NULL,
	[ENFRC_TYPE] [varchar](255) NULL,
	[ENFRC_RESP_PERSON_OWNER] [varchar](255) NULL,
	[ENFRC_RESP_PERSON_IDEN] [varchar](50) NULL,
	[ENFRC_RESP_SUBORG_OWNER] [varchar](255) NULL,
	[ENFRC_RESP_SUBORG] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCR_CME_ENF_ACT] PRIMARY KEY CLUSTERED 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_EN_AC_CM] ON [dbo].[RCRA_CME_ENFRC_ACT] 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'CME_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The U.S.Postal Service alphabetic code that represents the U.S.State or territory in which a state or local government enforcement agency operates. (EnforcementAgencyLocationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_AGN_LOC_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique alphanumeric identifier used in the applicable database to identify a specific enforcement action pertaining to a regulated entity or facility. (EnforcementActionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date the enforcement action was issued or filed. (EnforcementActionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The full name of the agency, department, or organization that submitted the enforcement action data to EPA. (EnforcementAgencyName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_AGN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes the relevant docket number which enforcement staff have assigned for tracking of enforcement actions. (EnforcementDocketNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_DOCKET_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the attorney within the agency responsible for issuing the enforcement action. (EnforcementAttorney)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_ATTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (CorrectiveActionComponent)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_COMPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (ConsentAgreementFinalOrderSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'CNST_AGMT_FINAL_ORDER_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (AppealInitiatedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'APPEAL_INIT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (AppealResolutionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'APPEAL_RSLN_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'DISP_STAT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'DISP_STAT_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (DispositionStatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'DISP_STAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State Postal Code (EnforcementOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that identifies the type of action being taken against a handler. (EnforcementType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (EnforcementResponsiblePersonOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_RESP_PERSON_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the enforcement. (EnforcementResponsiblePersonIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_RESP_PERSON_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganizationOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_RESP_SUBORG_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganization)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'ENFRC_RESP_SUBORG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_EVAL_VIOL]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_EVAL_VIOL](
	[EVAL_VIOL_ID] [varchar](40) NOT NULL,
	[EVAL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[VIOL_ACT_LOC] [varchar](255) NOT NULL,
	[VIOL_SEQ_NUM] [int] NOT NULL,
	[AGN_WHICH_DTRM_VIOL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_RCRA_CME_EVL_VL] PRIMARY KEY CLUSTERED 
(
	[EVAL_VIOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_EV_VL_EV] ON [dbo].[RCRA_CME_EVAL_VIOL] 
(
	[EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'EVAL_VIOL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'EVAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (ViolationActivityLocation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_ACT_LOC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (ViolationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (AgencyWhichDeterminedViolation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'AGN_WHICH_DTRM_VIOL'
GO
/****** Object:  Table [dbo].[RCRA_CME_EVAL_COMMIT]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_EVAL_COMMIT](
	[EVAL_COMMIT_ID] [varchar](40) NOT NULL,
	[EVAL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[COMMIT_LEAD] [varchar](255) NOT NULL,
	[COMMIT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_RCR_CME_EVL_CMM] PRIMARY KEY CLUSTERED 
(
	[EVAL_COMMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_EV_CM_EV] ON [dbo].[RCRA_CME_EVAL_COMMIT] 
(
	[EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'EVAL_COMMIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'EVAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentLead)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'COMMIT_LEAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'COMMIT_SEQ_NUM'
GO
/****** Object:  Table [dbo].[RCRA_CME_CSNY_DATE]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_CSNY_DATE](
	[CSNY_DATE_ID] [varchar](40) NOT NULL,
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[SNY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_RCR_CME_CSN_DTE] PRIMARY KEY CLUSTERED 
(
	[CSNY_DATE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_CS_DT_EN] ON [dbo].[RCRA_CME_CSNY_DATE] 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'CSNY_DATE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of the SNY that the Action is Addressing (SNYDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'SNY_DATE'
GO
/****** Object:  Table [dbo].[RCRA_CME_CITATION]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_CITATION](
	[CITATION_ID] [varchar](40) NOT NULL,
	[VIOL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[CITATION_NAME_SEQ_NUM] [int] NOT NULL,
	[CITATION_NAME] [varchar](128) NULL,
	[CITATION_NAME_OWNER] [varchar](255) NULL,
	[CITATION_NAME_TYPE] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_CTTN] PRIMARY KEY CLUSTERED 
(
	[CITATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_CM_CT_VL_ID] ON [dbo].[RCRA_CME_CITATION] 
(
	[VIOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'VIOL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (CitationNameSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The citation(s) of the violations alleged. (CitationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State postal code (CitationNameOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3 (CitationNameType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_VIOL_ENFRC]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_VIOL_ENFRC](
	[VIOL_ENFRC_ID] [varchar](40) NOT NULL,
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[VIOL_SEQ_NUM] [int] NOT NULL,
	[AGN_WHICH_DTRM_VIOL] [varchar](255) NOT NULL,
	[RTN_COMPL_SCHD_DATE] [datetime] NULL,
 CONSTRAINT [PK_RCRA_CME_VL_ENF] PRIMARY KEY CLUSTERED 
(
	[VIOL_ENFRC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_VL_EN_EN] ON [dbo].[RCRA_CME_VIOL_ENFRC] 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'VIOL_ENFRC_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (ViolationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'VIOL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (AgencyWhichDeterminedViolation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'AGN_WHICH_DTRM_VIOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date, specified in the Compliance Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'RTN_COMPL_SCHD_DATE'
GO
/****** Object:  Table [dbo].[RCRA_CME_PNLTY]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_PNLTY](
	[PNLTY_ID] [varchar](40) NOT NULL,
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[PNLTY_TYPE_OWNER] [varchar](255) NOT NULL,
	[PNLTY_TYPE] [varchar](255) NOT NULL,
	[CASH_CIVIL_PNLTY_SOUGHT_AMOUNT] [decimal](14, 6) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_PNLTY] PRIMARY KEY CLUSTERED 
(
	[PNLTY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_PN_EN_AC] ON [dbo].[RCRA_CME_PNLTY] 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Penalty Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'PNLTY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Penalty Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the penalty type (PenaltyTypeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'PNLTY_TYPE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code which indicates the type of penalty associated with the penalty amount. (PenaltyType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'PNLTY_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The dollar amount of any proposed cash civil penalty set forth in a Complaint/Proposed Order. (CashCivilPenaltySoughtAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'CASH_CIVIL_PNLTY_SOUGHT_AMOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Penalty Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_MILESTONE]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_MILESTONE](
	[MILESTONE_ID] [varchar](40) NOT NULL,
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[MILESTONE_SEQ_NUM] [int] NOT NULL,
	[TECH_RQMT_IDEN] [varchar](50) NULL,
	[TECH_RQMT_DESC] [varchar](255) NULL,
	[MILESTONE_SCHD_COMP_DATE] [datetime] NULL,
	[MILESTONE_ACTL_COMP_DATE] [datetime] NULL,
	[MILESTONE_DFLT_DATE] [datetime] NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_MLSTNE] PRIMARY KEY CLUSTERED 
(
	[MILESTONE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_ML_EN_AC] ON [dbo].[RCRA_CME_MILESTONE] 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'MILESTONE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'MILESTONE_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'TECH_RQMT_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'TECH_RQMT_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneScheduledCompletionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'MILESTONE_SCHD_COMP_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneActualCompletionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'MILESTONE_ACTL_COMP_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneDefaultedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'MILESTONE_DFLT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_MEDIA]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_MEDIA](
	[MEDIA_ID] [varchar](40) NOT NULL,
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[MULTIMEDIA_CODE_OWNER] [varchar](255) NOT NULL,
	[MULTIMEDIA_CODE] [varchar](50) NOT NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_MEDIA] PRIMARY KEY CLUSTERED 
(
	[MEDIA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_MD_EN_AC] ON [dbo].[RCRA_CME_MEDIA] 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enfocement Multimedia Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'MEDIA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enfocement Multimedia Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the multimedia code. (MultimediaCodeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'MULTIMEDIA_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code which indicates the medium or program other than RCRA participating in the enforcement action. (MultimediaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'MULTIMEDIA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enfocement Multimedia Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_SUPP_ENVR_PRJT]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_SUPP_ENVR_PRJT](
	[SUPP_ENVR_PRJT_ID] [varchar](40) NOT NULL,
	[ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[SEP_SEQ_NUM] [int] NOT NULL,
	[SEP_EXPND_AMOUNT] [decimal](14, 6) NULL,
	[SEP_SCHD_COMP_DATE] [datetime] NULL,
	[SEP_ACTL_DATE] [datetime] NULL,
	[SEP_DFLT_DATE] [datetime] NULL,
	[SEP_CODE_OWNER] [varchar](255) NULL,
	[SEP_DESC_TXT] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCR_CM_SP_EN_PR] PRIMARY KEY CLUSTERED 
(
	[SUPP_ENVR_PRJT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RC_CM_SP_EN_PR] ON [dbo].[RCRA_CME_SUPP_ENVR_PRJT] 
(
	[ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SUPP_ENVR_PRJT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEP Sequence Number allowed value 01-99 (SEPSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Expenditure Amount (SEPExpenditureAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_EXPND_AMOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valid date greater than or equal to the Date of Enforcement Action. (SEPScheduledCompletionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_SCHD_COMP_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEP actual completion date (SEPActualDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_ACTL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the SEP defaulted (SEPDefaultedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_DFLT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State postal code (SEPCodeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The narrative text describing any Supplemental Environmental Projects required to be performed pursuant to a Final Order. (SEPDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'SEP_DESC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_RQST]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_RQST](
	[RQST_ID] [varchar](40) NOT NULL,
	[EVAL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[RQST_SEQ_NUM] [int] NOT NULL,
	[DATE_OF_RQST] [datetime] NULL,
	[DATE_RESP_RCVD] [datetime] NULL,
	[RQST_AGN] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_RQST] PRIMARY KEY CLUSTERED 
(
	[RQST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_CM_RQ_EV_ID] ON [dbo].[RCRA_CME_RQST] 
(
	[EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'RQST_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'EVAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (RequestSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'RQST_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (DateOfRequest)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'DATE_OF_RQST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (DateResponseReceived)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'DATE_RESP_RCVD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (RequestAgency)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'RQST_AGN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  Table [dbo].[RCRA_CME_PYMT]    Script Date: 07/01/2009 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_PYMT](
	[PYMT_ID] [varchar](40) NOT NULL,
	[PNLTY_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[PYMT_SEQ_NUM] [int] NOT NULL,
	[PYMT_DFLT_DATE] [datetime] NULL,
	[SCHD_PYMT_DATE] [datetime] NULL,
	[SCHD_PYMT_AMOUNT] [decimal](14, 6) NULL,
	[ACTL_PYMT_DATE] [datetime] NULL,
	[ACTL_PAID_AMOUNT] [decimal](14, 6) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_RCRA_CME_PYMT] PRIMARY KEY CLUSTERED 
(
	[PYMT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RCR_CM_PY_PN_ID] ON [dbo].[RCRA_CME_PYMT] 
(
	[PNLTY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'PYMT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'PNLTY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'PYMT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentDefaultedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'PYMT_DFLT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'SCHD_PYMT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'SCHD_PYMT_AMOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (ActualPaymentDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'ACTL_PYMT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The dollar amount of any cost recovery required to be paid pursuant to a Final Order. (ActualPaidAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'ACTL_PAID_AMOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
/****** Object:  ForeignKey [FK_RC_CM_CT_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_CITATION]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_CT_RC_CM] FOREIGN KEY([VIOL_ID])
REFERENCES [dbo].[RCRA_CME_VIOL] ([VIOL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_CITATION] CHECK CONSTRAINT [FK_RC_CM_CT_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_CS_DT_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_CSNY_DATE]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_CS_DT_RC] FOREIGN KEY([ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_CSNY_DATE] CHECK CONSTRAINT [FK_RC_CM_CS_DT_RC]
GO
/****** Object:  ForeignKey [FK_RC_CM_EN_AC_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_ENFRC_ACT]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_EN_AC_RC] FOREIGN KEY([CME_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_FAC_SUBM] ([CME_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_ENFRC_ACT] CHECK CONSTRAINT [FK_RC_CM_EN_AC_RC]
GO
/****** Object:  ForeignKey [FK_RC_CM_EV_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_EVAL]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_EV_RC_CM] FOREIGN KEY([CME_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_FAC_SUBM] ([CME_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_EVAL] CHECK CONSTRAINT [FK_RC_CM_EV_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_EV_CM_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_EVAL_COMMIT]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_EV_CM_RC] FOREIGN KEY([EVAL_ID])
REFERENCES [dbo].[RCRA_CME_EVAL] ([EVAL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_EVAL_COMMIT] CHECK CONSTRAINT [FK_RC_CM_EV_CM_RC]
GO
/****** Object:  ForeignKey [FK_RC_CM_EV_VL_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_EVAL_VIOL]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_EV_VL_RC] FOREIGN KEY([EVAL_ID])
REFERENCES [dbo].[RCRA_CME_EVAL] ([EVAL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_EVAL_VIOL] CHECK CONSTRAINT [FK_RC_CM_EV_VL_RC]
GO
/****** Object:  ForeignKey [FK_RC_CM_FC_SB_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_FAC_SUBM]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_FC_SB_RC] FOREIGN KEY([HAZRD_WASTE_CME_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_HAZRD_WASTE_CME_SUBM] ([HAZRD_WASTE_CME_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_FAC_SUBM] CHECK CONSTRAINT [FK_RC_CM_FC_SB_RC]
GO
/****** Object:  ForeignKey [FK_RC_CM_MD_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_MEDIA]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_MD_RC_CM] FOREIGN KEY([ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_MEDIA] CHECK CONSTRAINT [FK_RC_CM_MD_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_ML_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_MILESTONE]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_ML_RC_CM] FOREIGN KEY([ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_MILESTONE] CHECK CONSTRAINT [FK_RC_CM_ML_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_PN_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_PNLTY]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_PN_RC_CM] FOREIGN KEY([ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_PNLTY] CHECK CONSTRAINT [FK_RC_CM_PN_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_PY_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_PYMT]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_PY_RC_CM] FOREIGN KEY([PNLTY_ID])
REFERENCES [dbo].[RCRA_CME_PNLTY] ([PNLTY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_PYMT] CHECK CONSTRAINT [FK_RC_CM_PY_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_RQ_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_RQST]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_RQ_RC_CM] FOREIGN KEY([EVAL_ID])
REFERENCES [dbo].[RCRA_CME_EVAL] ([EVAL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_RQST] CHECK CONSTRAINT [FK_RC_CM_RQ_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_SP_EN_PR]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_SUPP_ENVR_PRJT]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_SP_EN_PR] FOREIGN KEY([ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_SUPP_ENVR_PRJT] CHECK CONSTRAINT [FK_RC_CM_SP_EN_PR]
GO
/****** Object:  ForeignKey [FK_RC_CM_VL_RC_CM]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_VIOL]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_VL_RC_CM] FOREIGN KEY([CME_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_FAC_SUBM] ([CME_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_VIOL] CHECK CONSTRAINT [FK_RC_CM_VL_RC_CM]
GO
/****** Object:  ForeignKey [FK_RC_CM_VL_EN_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_CME_VIOL_ENFRC]  WITH CHECK ADD  CONSTRAINT [FK_RC_CM_VL_EN_RC] FOREIGN KEY([ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_VIOL_ENFRC] CHECK CONSTRAINT [FK_RC_CM_VL_EN_RC]
GO
/****** Object:  ForeignKey [FK_RC_HD_CE_RC_HD]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_CERTIFICATION]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_CE_RC_HD] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_CERTIFICATION] CHECK CONSTRAINT [FK_RC_HD_CE_RC_HD]
GO
/****** Object:  ForeignKey [FK_RC_HD_EN_PE_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_ENV_PERMIT]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_EN_PE_RC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_ENV_PERMIT] CHECK CONSTRAINT [FK_RC_HD_EN_PE_RC]
GO
/****** Object:  ForeignKey [FK_RC_HD_HA_RC_HD]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_HANDLER]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_HA_RC_HD] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HBASIC] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_HANDLER] CHECK CONSTRAINT [FK_RC_HD_HA_RC_HD]
GO
/****** Object:  ForeignKey [FK_RC_HD_NA_RC_HD]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_NAICS]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_NA_RC_HD] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_NAICS] CHECK CONSTRAINT [FK_RC_HD_NA_RC_HD]
GO
/****** Object:  ForeignKey [FK_RC_HD_OT_ID_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_OTHER_ID]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_OT_ID_RC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HBASIC] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_OTHER_ID] CHECK CONSTRAINT [FK_RC_HD_OT_ID_RC]
GO
/****** Object:  ForeignKey [FK_RC_HD_OW_RC_HD]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_OWNEROP]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_OW_RC_HD] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_OWNEROP] CHECK CONSTRAINT [FK_RC_HD_OW_RC_HD]
GO
/****** Object:  ForeignKey [FK_RC_HD_ST_AC_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_STATE_ACTIVITY]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_ST_AC_RC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_STATE_ACTIVITY] CHECK CONSTRAINT [FK_RC_HD_ST_AC_RC]
GO
/****** Object:  ForeignKey [FK_RC_HD_UN_WA_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_UNIVERSAL_WASTE]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_UN_WA_RC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_UNIVERSAL_WASTE] CHECK CONSTRAINT [FK_RC_HD_UN_WA_RC]
GO
/****** Object:  ForeignKey [FK_RC_HD_WA_CO_RC]    Script Date: 07/01/2009 10:54:20 ******/
ALTER TABLE [dbo].[RCRA_HD_WASTE_CODE]  WITH CHECK ADD  CONSTRAINT [FK_RC_HD_WA_CO_RC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([PK_GUID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_WASTE_CODE] CHECK CONSTRAINT [FK_RC_HD_WA_CO_RC]
GO
