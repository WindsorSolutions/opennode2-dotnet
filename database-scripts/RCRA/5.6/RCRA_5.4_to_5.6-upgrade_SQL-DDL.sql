/*
Copyright (c) 2016, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/

/* SQL Server

 This script updates an existing RCRA v5.4 staging database to v5.6.
 Created: 11/3/2017
 Last Updated: 2/6/2018

*/

ALTER TABLE RCRA_HD_OWNEROP ALTER COLUMN NOTES VARCHAR(4000)
GO
ALTER TABLE RCRA_HD_OWNEROP ALTER COLUMN STREET1 VARCHAR(50)
GO
ALTER TABLE RCRA_HD_OWNEROP ALTER COLUMN STREET2 VARCHAR(50)
GO

ALTER TABLE RCRA_HD_HANDLER ADD RECYCLER_NOTES VARCHAR(4000) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'RECYCLER_NOTES ', @name=N'MS_Description', @value=N'Notes for recycling hazardous waste. (RecyclerNotes)'
GO

ALTER TABLE RCRA_HD_HANDLER ADD RECOGNIZED_TRADER_IMPORTER_IND CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'RECOGNIZED_TRADER_IMPORTER_IND', @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Import Trading activity. (RecognizedTraderImporterIndicator)'
GO
ALTER TABLE RCRA_HD_HANDLER ADD RECOGNIZED_TRADER_EXPORTER_IND CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'RECOGNIZED_TRADER_EXPORTER_IND', @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Export Trading activity. (RecognizedTraderExporterIndicator)'
GO
ALTER TABLE RCRA_HD_HANDLER ADD SLAB_IMPORTER_IND CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'SLAB_IMPORTER_IND', @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Slab Import activity. (SlabImporterIndicator)'
GO
ALTER TABLE RCRA_HD_HANDLER ADD SLAB_EXPORTER_IND CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'SLAB_EXPORTER_IND', @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Slab Export activity. (SlabExporterIndicator)'
GO
ALTER TABLE RCRA_HD_HANDLER ADD RECYCLER_ACT_NONSTORAGE CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'RECYCLER_ACT_NONSTORAGE', @name=N'MS_Description', @value=N'Identifies that Handler participates in Nonstorage Recycler Activity. (RecyclerActivityNonstorage)'
GO
ALTER TABLE RCRA_HD_HANDLER ADD MANIFEST_BROKER CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN', @level2name=N'MANIFEST_BROKER', @name=N'MS_Description', @value=N'Identifies that Handler is ManifestBroker. (ManifestBroker)'
GO
ALTER TABLE RCRA_CME_EVAL ADD NOC_DATE DATETIME NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN', @level2name=N'NOC_DATE', @name=N'MS_Description', @value=N'NOC Date. (NOCDate)';
GO
ALTER TABLE RCRA_CME_ENFRC_ACT ADD FA_REQUIRED CHAR(1) NULL
GO
EXEC sys.sp_addextendedproperty @level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN', @level2name=N'FA_REQUIRED', @name=N'MS_Description', @value=N'Whether financial responsibility is required. (FinancialAssuranceReqD)'
GO
/****** Object:  Table [dbo].[RCRA_HD_LQG_CLOSURE]    Script Date: 11/3/2017 4:03:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_LQG_CLOSURE](
	[HD_LQG_CLOSURE_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[CLOSURE_TYPE] [char](1) NULL,
	[EXPECTED_CLOSURE_DATE] [datetime] NULL,
	[NEW_CLOSURE_DATE] [datetime] NULL,
	[DATE_CLOSED] [datetime] NULL,
	[IN_COMPLIANCE_IND] [char](1) NULL,
 CONSTRAINT [PK_HD_LQG_CLOSURE] PRIMARY KEY CLUSTERED
(
	[HD_LQG_CLOSURE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: LQG closure info for a Handler' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'HD_LQG_CLOSURE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of the closure. (ClosureType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'CLOSURE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of expected closure. (ExpectedClosureDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'EXPECTED_CLOSURE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'New closure date. (NewClosureDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'NEW_CLOSURE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of closed. (DateClosed)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'DATE_CLOSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of in compliance. (InComplianceIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CLOSURE', @level2type=N'COLUMN',@level2name=N'IN_COMPLIANCE_IND'
GO
/****** Object:  Table [dbo].[RCRA_HD_LQG_CONSOLIDATION]    Script Date: 11/3/2017 4:03:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_LQG_CONSOLIDATION](
	[HD_LQG_CONSOLIDATION_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[SEQ_NUMBER] [int] NOT NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
	[HANDLER_NAME] [varchar](80) NULL,
	[MAIL_STREET_NUMBER] [varchar](12) NULL,
	[MAIL_STREET1] [varchar](50) NULL,
	[MAIL_STREET2] [varchar](50) NULL,
	[MAIL_CITY] [varchar](25) NULL,
	[MAIL_STATE] [char](2) NULL,
	[MAIL_COUNTRY] [char](2) NULL,
	[MAIL_ZIP] [varchar](14) NULL,
	[CONTACT_FIRST_NAME] [varchar](38) NULL,
	[CONTACT_MIDDLE_INITIAL] [char](1) NULL,
	[CONTACT_LAST_NAME] [varchar](38) NULL,
	[CONTACT_ORG_NAME] [varchar](80) NULL,
	[CONTACT_TITLE] [varchar](80) NULL,
	[CONTACT_EMAIL_ADDRESS] [varchar](80) NULL,
	[CONTACT_PHONE] [varchar](15) NULL,
	[CONTACT_PHONE_EXT] [varchar](6) NULL,
	[CONTACT_FAX] [varchar](15) NULL,
 CONSTRAINT [PK_HD_LQG_CONSOLIDATION] PRIMARY KEY CLUSTERED
(
	[HD_LQG_CONSOLIDATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: LQG consolidation info for a Handler' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'HD_LQG_CONSOLIDATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique number that identifies the Consolidation. (ConsolidationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'SEQ_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the Handler (HandlerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'HANDLER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_STREET_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mailing address information. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'MAIL_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: First name of the contact. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Middle initial of the contact. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Last name of the contact. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Name of the contact organization. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the contact person (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact fax number (FaxNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_LQG_CONSOLIDATION', @level2type=N'COLUMN',@level2name=N'CONTACT_FAX'
GO
/****** Object:  Table [dbo].[RCRA_HD_EPISODIC_EVENT]    Script Date: 11/3/2017 3:54:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_EPISODIC_EVENT](
	[HD_EPISODIC_EVENT_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[EVENT_OWNER] [char](2) NULL,
	[EVENT_TYPE] [varchar](3) NULL,
	[EVENT_OTHER_DESC] [varchar](80) NULL,
	[CONTACT_FIRST_NAME] [varchar](38) NULL,
	[CONTACT_MIDDLE_INITIAL] [char](1) NULL,
	[CONTACT_LAST_NAME] [varchar](38) NULL,
	[CONTACT_ORG_NAME] [varchar](80) NULL,
	[CONTACT_TITLE] [varchar](80) NULL,
	[CONTACT_EMAIL_ADDRESS] [varchar](80) NULL,
	[CONTACT_PHONE] [varchar](15) NULL,
	[CONTACT_PHONE_EXT] [varchar](6) NULL,
	[CONTACT_FAX] [varchar](15) NULL,
	[START_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
 CONSTRAINT [PK_HD_EPISODIC_EVENT] PRIMARY KEY CLUSTERED
(
	[HD_EPISODIC_EVENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Episodic event info for a Handler' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'HD_EPISODIC_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner of the episodic event. (EpisodicEventOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of the episodic event. (EpisodicEventType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Other description of the episodic event. (EpisodicEventOtherDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_OTHER_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First name of the contact. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Middle initial of the contact. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last name of the contact. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact organization name. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the contact. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address of the contact. (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number of the contact. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phone extension of the contact. (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fax number of the contact. (FaxNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'CONTACT_FAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Episodic event start event. (EpisodicEventStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'START_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Episodic event end event. (EpisodicEventEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_EVENT', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
/****** Object:  Table [dbo].[RCRA_HD_EPISODIC_WASTE]    Script Date: 11/3/2017 3:57:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_EPISODIC_WASTE](
	[HD_EPISODIC_WASTE_ID] [varchar](40) NOT NULL,
	[HD_EPISODIC_EVENT_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[SEQ_NUMBER] [int] NULL,
	[WASTE_DESC] [varchar](4000) NULL,
	[EST_QNTY] [int] NULL,
 CONSTRAINT [PK_HD_EPISODIC_WASTE] PRIMARY KEY CLUSTERED
(
	[HD_EPISODIC_WASTE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Episodic waste info for a Handler Episodic Event' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE', @level2type=N'COLUMN',@level2name=N'HD_EPISODIC_WASTE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Episode event data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE', @level2type=N'COLUMN',@level2name=N'HD_EPISODIC_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique number that identifies the episodic waste. (EpisodicWasteSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE', @level2type=N'COLUMN',@level2name=N'SEQ_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Waste description. (WasteDescription)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE', @level2type=N'COLUMN',@level2name=N'WASTE_DESC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The quantity of waste that is handled by each process code. This element pertains only to Part A submissions. (EstimatedQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE', @level2type=N'COLUMN',@level2name=N'EST_QNTY'
GO
/****** Object:  Table [dbo].[RCRA_HD_EPISODIC_WASTE_CODE]    Script Date: 11/3/2017 3:59:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_EPISODIC_WASTE_CODE](
	[HD_EPISODIC_WASTE_CODE_ID] [varchar](40) NOT NULL,
	[HD_EPISODIC_WASTE_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[WASTE_CODE_OWNER] [char](2) NULL,
	[WASTE_CODE] [varchar](6) NULL,
	[WASTE_CODE_TEXT] [varchar](80) NULL,
 CONSTRAINT [PK_HD_EPISODIC_WASTE_CODE] PRIMARY KEY CLUSTERED
(
	[HD_EPISODIC_WASTE_CODE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Episodic waste code details for Handler Episodic Waste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'HD_EPISODIC_WASTE_CODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Episodic waste data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'HD_EPISODIC_WASTE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner and definer of the waste code. (WasteCodeOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to describe hazardous waste. (WasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing the Waste Code (Data publishing only). (WasteCodeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_EPISODIC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_TEXT'
GO
/****** Object:  Table [dbo].[RCRA_RU_SUBM]    Script Date: 11/3/2017 4:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_RU_SUBM](
	[RU_SUBM_ID] [varchar](40) NOT NULL,
	[DATA_ACCESS] [varchar](10),
 CONSTRAINT [PK_RU_SUBM] PRIMARY KEY CLUSTERED
(
	[RU_SUBM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Universal waste report submission' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_SUBM', @level2type=N'COLUMN',@level2name=N'RU_SUBM_ID'
GO
/****** Object:  Table [dbo].[RCRA_RU_REPORT_UNIV_SUBM]    Script Date: 11/3/2017 4:00:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_RU_REPORT_UNIV_SUBM](
	[RU_REPORT_UNIV_SUBM_ID] [varchar](40) NOT NULL,
	[RU_SUBM_ID] [varchar](40) NOT NULL,
	CONSTRAINT [PK_RU_REPORT_UNIV_SUBM] PRIMARY KEY CLUSTERED
		(
			[RU_REPORT_UNIV_SUBM_ID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Universal waste report submission. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV_SUBM', @level2type=N'COLUMN',@level2name=N'RU_REPORT_UNIV_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Universal waste report submission. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV_SUBM', @level2type=N'COLUMN',@level2name=N'RU_SUBM_ID'
GO
/****** Object:  Table [dbo].[RCRA_RU_REPORT_UNIV]    Script Date: 11/3/2017 4:00:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_RU_REPORT_UNIV](
	[RU_REPORT_UNIV_ID] [varchar](40) NOT NULL,
	[RU_REPORT_UNIV_SUBM_ID] [varchar](40) NOT NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
	[ACTIVITY_LOCATION] [char](2) NOT NULL,
	[SOURCE_TYPE] [char](1) NULL,
	[SEQ_NUMBER] [int] NULL,
	[RECEIVE_DATE] [datetime] NULL,
	[HANDLER_NAME] [varchar](80) NULL,
	[NON_NOTIFIER_IND] [char](1) NULL,
	[ACCESSIBILITY] [char](1) NULL,
	[REPORT_CYCLE] [int] NULL,
	[REGION] [char](2) NULL,
	[STATE] [char](2) NULL,
	[EXTRACT_FLAG] [char](1) NULL,
	[ACTIVE_SITE] [varchar](5) NULL,
	[COUNTY_CODE] [varchar](5) NULL,
	[COUNTY_NAME] [varchar](80) NULL,
	[LOCATION_STREET_NUMBER] [varchar](12) NULL,
	[LOCATION_STREET1] [varchar](50) NULL,
	[LOCATION_STREET2] [varchar](50) NULL,
	[LOCATION_CITY] [varchar](25) NULL,
	[LOCATION_STATE] [char](2) NULL,
	[LOCATION_COUNTRY] [char](2) NULL,
	[LOCATION_ZIP] [char](14) NULL,
	[MAIL_STREET_NUMBER] [varchar](12) NULL,
	[MAIL_STREET1] [varchar](50) NULL,
	[MAIL_STREET2] [varchar](50) NULL,
	[MAIL_CITY] [varchar](25) NULL,
	[MAIL_STATE] [char](2) NULL,
	[MAIL_COUNTRY] [char](2) NULL,
	[MAIL_ZIP] [varchar](14) NULL,
	[CONTACT_STREET_NUMBER] [varchar](12) NULL,
	[CONTACT_STREET1] [varchar](50) NULL,
	[CONTACT_STREET2] [varchar](50) NULL,
	[CONTACT_CITY] [varchar](25) NULL,
	[CONTACT_STATE] [char](2) NULL,
	[CONTACT_COUNTRY] [char](2) NULL,
	[CONTACT_ZIP] [varchar](14) NULL,
	[CONTACT_NAME] [varchar](80) NULL,
	[CONTACT_PHONE] [varchar](22) NULL,
	[CONTACT_FAX] [varchar](15) NULL,
	[CONTACT_EMAIL] [varchar](80) NULL,
	[CONTACT_TITLE] [varchar](45) NULL,
	[OWNER_NAME] [varchar](80) NULL,
	[OWNER_TYPE] [char](1) NULL,
	[OWNER_SEQ_NUM] [int] NULL,
	[OPER_NAME] [varchar](80) NULL,
	[OPER_TYPE] [char](1) NULL,
	[OPER_SEQ_NUM] [int] NULL,
	[NAIC1_CODE] [varchar](6) NULL,
	[NAIC2_CODE] [varchar](6) NULL,
	[NAIC3_CODE] [varchar](6) NULL,
	[NAIC4_CODE] [varchar](6) NULL,
	[IN_HANDLER_UNIVERSE] [char](1) NULL,
	[IN_A_UNIVERSE] [char](1) NULL,
	[FED_WASTE_GENERATOR_OWNER] [char](2) NULL,
	[FED_WASTE_GENERATOR] [char](1) NULL,
	[STATE_WASTE_GENERATOR_OWNER] [char](2) NULL,
	[STATE_WASTE_GENERATOR] [char](1) NULL,
	[GEN_STATUS] [varchar](3) NULL,
	[UNIV_WASTE] [char](1) NULL,
	[LAND_TYPE] [char](1) NULL,
	[STATE_DISTRICT_OWNER] [char](2) NULL,
	[STATE_DISTRICT] [varchar](10) NULL,
	[SHORT_TERM_GEN_IND] [char](1) NULL,
	[IMPORTER_ACTIVITY] [char](1) NULL,
	[MIXED_WASTE_GENERATOR] [char](1) NULL,
	[TRANSPORTER_ACTIVITY] [char](1) NULL,
	[TRANSFER_FACILITY_IND] [char](1) NULL,
	[RECYCLER_ACTIVITY] [char](1) NULL,
	[ONSITE_BURNER_EXEMPTION] [char](1) NULL,
	[FURNACE_EXEMPTION] [char](1) NULL,
	[UNDERGROUND_INJECTION_ACTIVITY] [char](1) NULL,
	[UNIVERSAL_WASTE_DEST_FACILITY] [char](1) NULL,
	[OFFSITE_WASTE_RECEIPT] [char](1) NULL,
	[USED_OIL] [varchar](7) NULL,
	[FEDERAL_UNIVERSAL_WASTE] [char](1) NULL,
	[AS_FEDERAL_REGULATED_TSDF] [varchar](6) NULL,
	[AS_CONVERTED_TSDF] [varchar](6) NULL,
	[AS_STATE_REGULATED_TSDF] [varchar](9) NULL,
	[FEDERAL_IND] [varchar](3) NULL,
	[HSM] [char](2) NULL,
	[SUBPART_K] [varchar](4) NULL,
	[COMMERCIAL_TSD] [char](1) NULL,
	[TSD] [varchar](5) NULL,
	[GPRA_PERMIT] [char](1) NULL,
	[GPRA_RENEWAL] [char](1) NULL,
	[PERMIT_RENEWAL_WRKLD] [varchar](6) NULL,
	[PERM_WRKLD] [varchar](6) NULL,
	[PERM_PROG] [varchar](6) NULL,
	[PC_WRKLD] [varchar](6) NULL,
	[CLOS_WRKLD] [varchar](6) NULL,
	[GPRACA] [char](1) NULL,
	[CA_WRKLD] [char](1) NULL,
	[SUBJ_CA] [char](1) NULL,
	[SUBJ_CA_NON_TSD] [char](1) NULL,
	[SUBJ_CA_TSD_3004] [char](1) NULL,
	[SUBJ_CA_DISCRETION] [char](1) NULL,
	[NCAPS] [char](1) NULL,
	[EC_IND] [char](1) NULL,
	[IC_IND] [char](1) NULL,
	[CA_725_IND] [char](1) NULL,
	[CA_750_IND] [char](1) NULL,
	[OPERATING_TSDF] [varchar](6) NULL,
	[FULL_ENFORCEMENT] [varchar](6) NULL,
	[SNC] [char](1) NULL,
	[BOY_SNC] [char](1) NULL,
	[BOY_STATE_UNADDRESSED_SNC] [char](1) NULL,
	[STATE_UNADDRESSED] [char](1) NULL,
	[STATE_ADDRESSED] [char](1) NULL,
	[BOY_STATE_ADDRESSED] [char](1) NULL,
	[STATE_SNC_WITH_COMP_SCHED] [char](1) NULL,
	[BOY_STATE_SNC_WITH_COMP_SCHED] [char](1) NULL,
	[EPA_UNADDRESSED] [char](1) NULL,
	[BOY_EPA_UNADDRESSED] [char](1) NULL,
	[EPA_ADDRESSED] [char](1) NULL,
	[BOY_EPA_ADDRESSED] [char](1) NULL,
	[EPA_SNC_WITH_COMP_SCHED] [char](1) NULL,
	[BOY_EPA_SNC_WITH_COMP_SCHED] [char](1) NULL,
	[FA_REQUIRED] [varchar](5) NULL,
	[HHANDLER_LAST_CHANGE_DATE] [datetime] NULL,
	[PUBLIC_NOTES] [varchar](4000) NULL,
	[NOTES] [varchar](4000) NULL,
	[RECOGNIZED_TRADER_IMPORTER_IND] [char](1) NULL,
	[RECOGNIZED_TRADER_EXPORTER_IND] [char](1) NULL,
	[SLAB_IMPORTER_IND] [char](1) NULL,
	[SLAB_EXPORTER_IND] [char](1) NULL,
	[RECYCLER_NON_STORAGE_IND] [char](1) NULL,
	[MANIFEST_BROKER_IND] [char](1) NULL,
 CONSTRAINT [PK_RU_REPORT_UNIV] PRIMARY KEY CLUSTERED
(
	[RU_REPORT_UNIV_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Universal waste report details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RU_REPORT_UNIV_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Universal waste report submission. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RU_REPORT_UNIV_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerIdCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'ACTIVITY_LOCATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SOURCE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence number for each source record about a handler. (SequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SEQ_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RECEIVE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the Handler (HandlerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'HANDLER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NON_NOTIFIER_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reason why the handler is not accessible for normal processing (Bankrupt Indicator). (Accessibility)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'ACCESSIBILITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Report cycle. (ReportCycle)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'REPORT_CYCLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Region (Region)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'REGION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State (State)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Extract flag (ExtractFlag)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'EXTRACT_FLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Active site (ActiveSite)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'ACTIVE_SITE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'COUNTY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing the County Name(Data publishing only). (CountyName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'COUNTY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number portion of the location street address of the handler. (LocationAddressNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Street address of the handler. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Supplemental address of the handler. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'City in which the handler is located. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State in which the handler is located. (StateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country in which the handler is located. (CountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ZIP code in which the handler is located. (LocationZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LOCATION_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number portion of the mailing address of the handler. (MailingAddressNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_STREET_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Street address of the handler mailing address. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Supplemental address of the handler mailing address. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'City of the handler mailing address. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State of the handler mailing address. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of the handler mailing address. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ZIP code of the handler mailing address. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MAIL_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number portion of the mailing address of the handler contact. (MailingAddressNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Street address of the handler contact mailing address. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Supplemental address of the handler contact mailing address. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'City of the handler contact mailing address. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_CITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State of the handler contact mailing address. (MailingAddressStateUSPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country of the handler contact mailing address. (MailingAddressCountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_COUNTRY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ZIP code of the handler contact mailing address. (MailingAddressZIPCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_ZIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler contact name (first + last). (ContactNameCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler contact phone number. (ContactPhoneCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler contact fax number. (ContactFaxCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_FAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler contact email address. (ContactEmailCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_EMAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler contact title. (ContactTitleCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CONTACT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler owner name. (OwnerNameCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OWNER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler owner type. (OwnerTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OWNER_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler owner sequence number. (OwnerSeqCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OWNER_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler operator name. (OperatorNameCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OPER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler operator type. (OperatorTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OPER_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Handler operator sequence number. (OperatorSeqCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OPER_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NAIC 1 code (NAIC1Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NAIC1_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NAIC 2 code (NAIC2Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NAIC2_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NAIC 3 code (NAIC3Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NAIC3_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NAIC 4 code (NAIC4Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NAIC4_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'In handler universe (InHandlerUniverseCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'IN_HANDLER_UNIVERSE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'In a universe (InAUniverseCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'IN_A_UNIVERSE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FED_WASTE_GENERATOR_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FED_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_WASTE_GENERATOR_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gen status (GENSTATUS)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'GEN_STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Univ waste (UNIVWASTE)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'UNIV_WASTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'LAND_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_DISTRICT_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_DISTRICT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SHORT_TERM_GEN_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'IMPORTER_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MIXED_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'TRANSPORTER_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'TRANSFER_FACILITY_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code for recycling hazardous waste. (RecyclerActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RECYCLER_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'ONSITE_BURNER_EXEMPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FURNACE_EXEMPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'UNDERGROUND_INJECTION_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'UNIVERSAL_WASTE_DEST_FACILITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Off site waste receipt (OffSiteWasteReceiptCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OFFSITE_WASTE_RECEIPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Used oil code (UsedOilCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'USED_OIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Federal universal waste (FederalUniversalWasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FEDERAL_UNIVERSAL_WASTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'As federal regulated TSDF (AsFederalRegulatedTSDFCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'AS_FEDERAL_REGULATED_TSDF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'As converter TSDF (AsConverterTSDFCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'AS_CONVERTED_TSDF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'As state regulated TSDF (AsStateRegulatedTSDFCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'AS_STATE_REGULATED_TSDF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Federal indicator (FederalIndicatorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FEDERAL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'HSM code (HSMCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'HSM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Subpart K code (SubpartKCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SUBPART_K'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Commercial TSD code (CommercialTSDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'COMMERCIAL_TSD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TSD type (TSDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'TSD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GPRA permit (GPRAPermitCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'GPRA_PERMIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GPRA renewal code (GPRARenewalCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'GPRA_RENEWAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permit renewal WRKLD (PermitRenewalWRKLDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'PERMIT_RENEWAL_WRKLD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Perm WRKLD (PermWRKLDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'PERM_WRKLD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Perm PROG (PermPROGCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'PERM_PROG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PC WRKLD (PCWRKLDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'PC_WRKLD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clos WRKLD (ClosWRKLDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CLOS_WRKLD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GPRACA (GPRACACode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'GPRACA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CAWRKLD (CAWRKLDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CA_WRKLD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Subj CA (SubjCACode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SUBJ_CA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Subj CA non TSD (SubjCANonTSDCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SUBJ_CA_NON_TSD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Subj CA TSD 3004 (SubjCATSD3004Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SUBJ_CA_TSD_3004'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Subj CA discretion (SubjCADiscretionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SUBJ_CA_DISCRETION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NCAPS (NCAPSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NCAPS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EC indicator (ECIndicatorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'EC_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IC indicator (ICIndicatorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'IC_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CA 725 indicator (CA725IndicatorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CA_725_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CA 750 indicator (CA750IndicatorCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'CA_750_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Operating TSDF (OperatingTSDFCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'OPERATING_TSDF'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Full enforcement (FullEnforcementCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FULL_ENFORCEMENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SNC (SNCCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SNC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY SNC (BOYSNCCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_SNC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY state unaddressed SNC (BOYStateUnaddressedSNCCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_STATE_UNADDRESSED_SNC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State unaddressed (StateUnaddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_UNADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State addressed (StateAddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_ADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY state addressed (BOYStateAddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_STATE_ADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State SNC with comp sched (StateSNCWithCompSchedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'STATE_SNC_WITH_COMP_SCHED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY state SNC with comp sched (BOYStateSNCWithCompSchedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_STATE_SNC_WITH_COMP_SCHED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPA unaddressed (EPAUnaddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'EPA_UNADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY EPA unaddressed (BOYEPAUnaddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_EPA_UNADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPA addressed (EPAAddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'EPA_ADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY EPA addressed (BOYEPAAddressedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_EPA_ADDRESSED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPA SNC with comp sched (EPASNCWithcompSchedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'EPA_SNC_WITH_COMP_SCHED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BOY EPA SNC with comp sched (BOYEPASNCWithcompSchedCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'BOY_EPA_SNC_WITH_COMP_SCHED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FA required (FARequiredCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'FA_REQUIRED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'HHandler last change date (HHandlerLastChangeDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'HHANDLER_LAST_CHANGE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes (PublicNotesCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'PUBLIC_NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes (NotesCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Import Trading activity. Possible values are: Y/N (RecognizedTraderImporterIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RECOGNIZED_TRADER_IMPORTER_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Export Trading activity. Possible values are: Y/N (RecognizedTraderExporterIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RECOGNIZED_TRADER_EXPORTER_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Slab Import activity. Possible values are: Y/N (SlabImporterIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SLAB_IMPORTER_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that the Handler is participating in Slab Export activity. Possible values are: Y/N (SlabExporterIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'SLAB_EXPORTER_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recycle non storage (RecyclerNonStorageIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'RECYCLER_NON_STORAGE_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Manifest broker (ManifestBrokerIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_RU_REPORT_UNIV', @level2type=N'COLUMN',@level2name=N'MANIFEST_BROKER_IND'
GO
ALTER TABLE [dbo].[RCRA_HD_LQG_CONSOLIDATION]  WITH CHECK ADD  CONSTRAINT [FK_HD_LQG_CONSOL_HANDLER_ID] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_LQG_CONSOLIDATION] CHECK CONSTRAINT [FK_HD_LQG_CONSOL_HANDLER_ID]
GO
ALTER TABLE [dbo].[RCRA_HD_LQG_CLOSURE]  WITH CHECK ADD  CONSTRAINT [FK_HD_LQG_CLOS_HANDLER_ID] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_LQG_CLOSURE] CHECK CONSTRAINT [FK_HD_LQG_CLOS_HANDLER_ID]
GO
ALTER TABLE [dbo].[RCRA_HD_EPISODIC_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_HD_EPIS_EVT_HANDLER_ID] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_EPISODIC_EVENT] CHECK CONSTRAINT [FK_HD_EPIS_EVT_HANDLER_ID]
GO
ALTER TABLE [dbo].[RCRA_HD_EPISODIC_WASTE]  WITH CHECK ADD  CONSTRAINT [FK_HD_EPIS_WASTE_EVT_ID] FOREIGN KEY([HD_EPISODIC_EVENT_ID])
REFERENCES [dbo].[RCRA_HD_EPISODIC_EVENT] ([HD_EPISODIC_EVENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_EPISODIC_WASTE] CHECK CONSTRAINT [FK_HD_EPIS_WASTE_EVT_ID]
GO
ALTER TABLE [dbo].[RCRA_HD_EPISODIC_WASTE_CODE]  WITH CHECK ADD  CONSTRAINT [FK_HD_EPIS_WASTE_CD_WASTE_ID] FOREIGN KEY([HD_EPISODIC_WASTE_ID])
REFERENCES [dbo].[RCRA_HD_EPISODIC_WASTE] ([HD_EPISODIC_WASTE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_EPISODIC_WASTE_CODE] CHECK CONSTRAINT [FK_HD_EPIS_WASTE_CD_WASTE_ID]
GO
ALTER TABLE [dbo].[RCRA_RU_REPORT_UNIV_SUBM]  WITH CHECK ADD CONSTRAINT [FK_RU_REPORT_UNIV_SUBM_PARENT_ID] FOREIGN KEY([RU_SUBM_ID])
REFERENCES [dbo].[RCRA_RU_SUBM] ([RU_SUBM_ID])
	ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_RU_REPORT_UNIV_SUBM] CHECK CONSTRAINT [FK_RU_REPORT_UNIV_SUBM_PARENT_ID]
GO
ALTER TABLE [dbo].[RCRA_RU_REPORT_UNIV] WITH CHECK ADD CONSTRAINT [FK_RU_REPORT_UNIV_PARENT_ID] FOREIGN KEY([RU_REPORT_UNIV_SUBM_ID])
REFERENCES [dbo].[RCRA_RU_REPORT_UNIV_SUBM] ([RU_REPORT_UNIV_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_RU_REPORT_UNIV] CHECK CONSTRAINT [FK_RU_REPORT_UNIV_PARENT_ID]
GO