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
/*****************************************************************************************************************************   
 *
 *  Script Name:  RCRA_5.4-SQL-DDL.sql
 *
 *  Company:  Windsor Solutions, Inc.
 *  
 *  Purpose:  This script will build the database objects supporting the RCRA v5.4 flow
 *   
 *  Maintenance:
 *  
 *    Analyst         Date            Comment 
 *    ----------      ----------      ------------------------------------------------------------------------------
 *    Bill R          2/4/2016        Adapted v5.2 DDL script for new elements in v5.3
 *    Bill R          3/17/2016       Added 5.4 changes
 *    Bill R          4/11/2016       Adjust decimal data types to match schema
 *    Bill R          11/15/2016      Add three missing address number fields from v5.3
 *
  ****************************************************************************************************************************   
 */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_SUBMISSIONHISTORY](
	[SUBMISSIONHISTORY_ID] [varchar](40) NOT NULL,
	[SCHEDULERUNDATE] [datetime] NOT NULL,
	[TRANSACTIONID] [varchar](50) NOT NULL,
	[PROCESSINGSTATUS] [varchar](50) NOT NULL,
 	[SUBMISSIONTYPE] [varchar](50) NOT NULL,
CONSTRAINT [PK_SUBMISSIONHISTO] PRIMARY KEY CLUSTERED 
(
	[SUBMISSIONHISTORY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SubmissionHistoryDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_SUBMISSIONHISTORY'
GO
/****** Object:  Table [dbo].[RCRA_PRM_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_SUBM](
	[PRM_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_PRM_SUBM] PRIMARY KEY CLUSTERED 
(
	[PRM_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HazardousWastePermitDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_HD_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_SUBM](
	[HD_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_HD_SUBM] PRIMARY KEY CLUSTERED 
(
	[HD_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HazardousWasteHandlerSubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_GIS_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_GIS_SUBM](
	[GIS_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_GIS_SUBM] PRIMARY KEY CLUSTERED 
(
	[GIS_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GeographicInformationSubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_FA_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_FA_SUBM](
	[FA_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_FA_SUBM] PRIMARY KEY CLUSTERED 
(
	[FA_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FinancialAssuranceSubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_CME_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_SUBM](
	[CME_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_CME_SUBM] PRIMARY KEY CLUSTERED 
(
	[CME_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HazardousWasteCMESubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_CA_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_SUBM](
	[CA_SUBM_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_CA_SUBM] PRIMARY KEY CLUSTERED 
(
	[CA_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HazardousWasteCorrectiveActionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_CME_FAC_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_FAC_SUBM](
	[CME_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[CME_SUBM_ID] [varchar](40) NOT NULL,
	[EPA_HDLR_ID] [varchar](255) NOT NULL,
 CONSTRAINT [PK_CME_FAC_SUBM] PRIMARY KEY CLUSTERED 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_FC_SB_CM_SB] ON [dbo].[RCRA_CME_FAC_SUBM] 
(
	[CME_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: This contains Hbasic Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'CME_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: This contains Hbasic Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'CME_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number that uniquely identifies the EPA handler. (EPAHandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'EPA_HDLR_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CMEFacilitySubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_FAC_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_CA_FAC_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_FAC_SUBM](
	[CA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[CA_SUBM_ID] [varchar](40) NOT NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
 CONSTRAINT [PK_CA_FAC_SUBM] PRIMARY KEY CLUSTERED 
(
	[CA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_FC_SB_CA_SB] ON [dbo].[RCRA_CA_FAC_SUBM] 
(
	[CA_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'CA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'CA_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionFacilitySubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_FAC_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_GIS_FAC_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_GIS_FAC_SUBM](
	[GIS_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[GIS_SUBM_ID] [varchar](40) NOT NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
 CONSTRAINT [PK_GIS_FAC_SUBM] PRIMARY KEY CLUSTERED 
(
	[GIS_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_GS_FC_SB_GS_SB] ON [dbo].[RCRA_GIS_FAC_SUBM] 
(
	[GIS_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Supplies all of the relevant GIS Data for a given Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'GIS_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Supplies all of the relevant GIS Data for a given Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'GIS_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GISFacilitySubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_FAC_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_FA_FAC_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_FA_FAC_SUBM](
	[FA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[FA_SUBM_ID] [varchar](40) NOT NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
 CONSTRAINT [PK_FA_FAC_SUBM] PRIMARY KEY CLUSTERED 
(
	[FA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FA_FC_SB_FA_SB] ON [dbo].[RCRA_FA_FAC_SUBM] 
(
	[FA_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'FA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'FA_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FinancialAssuranceFacilitySubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_FAC_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_HD_HBASIC]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_HBASIC](
	[HD_HBASIC_ID] [varchar](40) NOT NULL,
	[HD_SUBM_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
	[EXTRACT_FLAG] [char](1) NULL,
	[FACILITY_IDENTIFIER] [varchar](12) NULL,
 CONSTRAINT [PK_HD_HBASIC] PRIMARY KEY CLUSTERED 
(
	[HD_HBASIC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_HBA_HD_SU_ID] ON [dbo].[RCRA_HD_HBASIC] 
(
	[HD_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Details of facility submission. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'HD_HBASIC_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Details of facility submission. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'HD_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Designates that data is available for extract for public use. (PublicUseExtractIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'EXTRACT_FLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems. (FacilityRegistryID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC', @level2type=N'COLUMN',@level2name=N'FACILITY_IDENTIFIER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilitySubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HBASIC'
GO
/****** Object:  Table [dbo].[RCRA_PRM_FAC_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_FAC_SUBM](
	[PRM_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[PRM_SUBM_ID] [varchar](40) NOT NULL,
	[HANDLER_ID] [varchar](12) NOT NULL,
 CONSTRAINT [PK_PRM_FAC_SUBM] PRIMARY KEY CLUSTERED 
(
	[PRM_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_FC_SB_PR_SB] ON [dbo].[RCRA_PRM_FAC_SUBM] 
(
	[PRM_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: 
	This is the root element for this flow XML Schema.
	 (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'PRM_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: 
	This is the root element for this flow XML Schema.
	 (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'PRM_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code that uniquely identifies the handler. (HandlerID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_FAC_SUBM', @level2type=N'COLUMN',@level2name=N'HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitFacilitySubmissionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_FAC_SUBM'
GO
/****** Object:  Table [dbo].[RCRA_PRM_SERIES]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_SERIES](
	[PRM_SERIES_ID] [varchar](40) NOT NULL,
	[PRM_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[PERMIT_SERIES_SEQ_NUM] [int] NOT NULL,
	[PERMIT_SERIES_NAME] [varchar](40) NULL,
	[RESP_PERSON_DATA_OWNER_CODE] [char](2) NULL,
	[RESP_PERSON_ID] [varchar](5) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_PRM_SERIES] PRIMARY KEY CLUSTERED 
(
	[PRM_SERIES_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_SR_PR_FC_SB] ON [dbo].[RCRA_PRM_SERIES] 
(
	[PRM_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit series Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'PRM_SERIES_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit series Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'PRM_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'PERMIT_SERIES_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name or number assigned by the implementing agency. (PermitSeriesName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'PERMIT_SERIES_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitSeriesDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_SERIES'
GO
/****** Object:  Table [dbo].[RCRA_PRM_UNIT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_UNIT](
	[PRM_UNIT_ID] [varchar](40) NOT NULL,
	[PRM_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[PERMIT_UNIT_SEQ_NUM] [int] NOT NULL,
	[PERMIT_UNIT_NAME] [varchar](40) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_PRM_UNIT] PRIMARY KEY CLUSTERED 
(
	[PRM_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_UN_PR_FC_SB] ON [dbo].[RCRA_PRM_UNIT] 
(
	[PRM_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit Unit Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT', @level2type=N'COLUMN',@level2name=N'PRM_UNIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit Unit Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT', @level2type=N'COLUMN',@level2name=N'PRM_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT', @level2type=N'COLUMN',@level2name=N'PERMIT_UNIT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name or number assigned by the implementing agency to identify a process unit group. (PermitUnitName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT', @level2type=N'COLUMN',@level2name=N'PERMIT_UNIT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitUnitDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT'
GO
/****** Object:  Table [dbo].[RCRA_GIS_GEO_INFORMATION]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_GIS_GEO_INFORMATION](
	[GIS_GEO_INFORMATION_ID] [varchar](40) NOT NULL,
	[GIS_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[GEO_INFO_OWNER] [char](2) NOT NULL,
	[GEO_INFO_SEQ_NUM] [int] NOT NULL,
	[PERMIT_UNIT_SEQ_NUM] [int] NULL,
	[AREA_SEQ_NUM] [int] NULL,
	[LOC_COMM_TXT] [varchar](2000) NULL,
	[AREA_ACREAGE_MEAS] [decimal](13, 2) NULL,
	[AREA_MEAS_SRC_DATA_OWNER_CODE] [char](2) NULL,
	[AREA_MEAS_SRC_CODE] [varchar](8) NULL,
	[AREA_MEAS_DATE] [datetime] NULL,
	[DATA_COLL_DATE] [datetime] NOT NULL,
	[HORZ_ACC_MEAS] [int] NULL,
	[SRC_MAP_SCALE_NUM] [int] NULL,
	[COORD_DATA_SRC_DATA_OWNER_CODE] [char](2) NULL,
	[COORD_DATA_SRC_CODE] [varchar](3) NULL,
	[GEO_REF_PT_DATA_OWNER_CODE] [char](2) NULL,
	[GEO_REF_PT_CODE] [varchar](3) NULL,
	[GEOM_TYPE_DATA_OWNER_CODE] [char](2) NULL,
	[GEOM_TYPE_CODE] [varchar](3) NULL,
	[HORZ_COLL_METH_DATA_OWNER_CODE] [char](2) NULL,
	[HORZ_COLL_METH_CODE] [varchar](3) NULL,
	[HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE] [char](2) NULL,
	[HORZ_COORD_REF_SYS_DATUM_CODE] [varchar](3) NULL,
	[VERF_METH_DATA_OWNER_CODE] [char](2) NULL,
	[VERF_METH_CODE] [varchar](3) NULL,
	[LATITUDE] [decimal](19, 14) NULL,
	[LONGITUDE] [decimal](19, 14) NULL,
	[ELEVATION] [decimal](19, 14) NULL,
 CONSTRAINT [PK_GS_GO_INFORMTON] PRIMARY KEY CLUSTERED 
(
	[GIS_GEO_INFORMATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_GS_GO_IN_GS_FC] ON [dbo].[RCRA_GIS_GEO_INFORMATION] 
(
	[GIS_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Used to define the geographic coordinates of the Handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GIS_GEO_INFORMATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Used to define the geographic coordinates of the Handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GIS_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner of Geographic Information.  Should match state code (i.e. KS). (GeographicInformationOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GEO_INFO_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for the geographic information. (GeographicInformationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GEO_INFO_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'PERMIT_UNIT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'AREA_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional informaiton about the geographic coordinates. (LocationCommentsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'LOC_COMM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of acres associated with the handler or area. (AreaAcreageMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'AREA_ACREAGE_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defined the AreaMeasureSource. (AreaMeasureSourceDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'AREA_MEAS_SRC_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The source of information used to determine the number of acres associated with the handler or area. (AreaMeasureSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'AREA_MEAS_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date acreage information for the handler or area was collected. (AreaMeasureDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'AREA_MEAS_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calender date when data were collected (DataCollectionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'DATA_COLL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'HORZ_ACC_MEAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumeric)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The owner of the code.  If provided, it should be HQ. (CoordinateDataSourceDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'COORD_DATA_SRC_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the party responsible for proiding the latitude and longitude coordinates. (CoordinateDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'COORD_DATA_SRC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The owner of the code.  If provided, it should be HQ. (GeographicReferencePointDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the place for which the geographic codes were established (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The owner of the code.  If provided, it should be HQ. (GeometricTypeDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GEOM_TYPE_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the geometric entity represented by one point or a sequence of points (GeometricTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'GEOM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The owner of the code.  If provided, it should be HQ. (HorizontalCollectionMethodDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the method used to deterimine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The owner of the code.  If provided, it should be HQ. (HorizontalCoordinateReferenceSystemDatumDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the datum used in determining latitude and longitude coordinates (HorizontalCoordinateReferenceSystemDatumCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'HORZ_COORD_REF_SYS_DATUM_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The owner of the code.  If provided, it should be HQ. (VerificationMethodDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'VERF_METH_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Geometry property element of a GeoRSS GML instance (Latitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'LATITUDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Geometry property element of a GeoRSS GML instance (Longitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'LONGITUDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Geometry property element of a GeoRSS GML instance (Elevation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION', @level2type=N'COLUMN',@level2name=N'ELEVATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GeographicInformationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_GIS_GEO_INFORMATION'
GO
/****** Object:  Table [dbo].[RCRA_HD_OTHER_ID]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_OTHER_ID](
	[HD_OTHER_ID_ID] [varchar](40) NOT NULL,
	[HD_HBASIC_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[OTHER_ID] [varchar](12) NOT NULL,
	[RELATIONSHIP_OWNER] [char](2) NULL,
	[RELATIONSHIP_TYPE] [char](1) NULL,
	[SAME_FACILITY] [char](1) NULL,
	[NOTES] [varchar](4000) NULL,
 CONSTRAINT [PK_HD_OTHER_ID] PRIMARY KEY CLUSTERED 
(
	[HD_OTHER_ID_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_OT_ID_HD_HB] ON [dbo].[RCRA_HD_OTHER_ID] 
(
	[HD_HBASIC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contains alternative identifiers for the facility. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'HD_OTHER_ID_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contains alternative identifiers for the facility. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID', @level2type=N'COLUMN',@level2name=N'HD_HBASIC_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: OtherIDDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OTHER_ID'
GO
/****** Object:  Table [dbo].[RCRA_HD_HANDLER]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_HANDLER](
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[HD_HBASIC_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[ACTIVITY_LOCATION] [char](2) NOT NULL,
	[SOURCE_TYPE] [char](1) NOT NULL,
	[SEQ_NUMBER] [int] NOT NULL,
	[RECEIVE_DATE] [varchar](10) NULL,
	[HANDLER_NAME] [varchar](80) NULL,
	[ACKNOWLEDGE_DATE] [varchar](10) NULL,
	[NON_NOTIFIER] [char](1) NULL,
	[TSD_DATE] [varchar](10) NULL,
	[OFF_SITE_RECEIPT] [char](1) NULL,
	[ACCESSIBILITY] [char](1) NULL,
	[COUNTY_CODE_OWNER] [char](2) NULL,
	[COUNTY_CODE] [varchar](5) NULL,
	[NOTES] [varchar](4000) NULL,
	[ACKNOWLEDGE_FLAG] [char](1) NULL,
	[LOCATION_STREET1] [varchar](50) NULL,
	[LOCATION_STREET2] [varchar](50) NULL,
	[LOCATION_CITY] [varchar](25) NULL,
	[LOCATION_STATE] [char](2) NULL,
	[LOCATION_COUNTRY] [char](2) NULL,
	[LOCATION_ZIP] [varchar](14) NULL,
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
	[CONTACT_EMAIL_ADDRESS] [varchar](240) NULL,
	[CONTACT_PHONE] [varchar](15) NULL,
	[CONTACT_PHONE_EXT] [varchar](6) NULL,
	[CONTACT_FAX] [varchar](15) NULL,
    [CONTACT_STREET_NUMBER] [varchar](12) NULL,
	[CONTACT_STREET1] [varchar](30) NULL,
	[CONTACT_STREET2] [varchar](30) NULL,
	[CONTACT_CITY] [varchar](25) NULL,
	[CONTACT_STATE] [char](2) NULL,
	[CONTACT_COUNTRY] [char](2) NULL,
	[CONTACT_ZIP] [varchar](14) NULL,
	[PCONTACT_FIRST_NAME] [varchar](38) NULL,
	[PCONTACT_MIDDLE_NAME] [char](1) NULL,
	[PCONTACT_LAST_NAME] [varchar](38) NULL,
	[PCONTACT_ORG_NAME] [varchar](80) NULL,
	[PCONTACT_TITLE] [varchar](80) NULL,
	[PCONTACT_EMAIL_ADDRESS] [varchar](240) NULL,
	[PCONTACT_PHONE] [varchar](15) NULL,
	[PCONTACT_PHONE_EXT] [varchar](6) NULL,
	[PCONTACT_FAX] [varchar](15) NULL,
    [PCONTACT_STREET_NUMBER] [varchar](12) NULL,
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
	[LAND_TYPE] [char](1) NULL,
	[STATE_DISTRICT_OWNER] [char](2) NULL,
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
	[SHORT_TERM_GEN_IND] [char](1) NULL,
	[TRANSFER_FACILITY_IND] [char](1) NULL,
	[STATE_WASTE_GENERATOR_OWNER] [char](2) NULL,
	[STATE_WASTE_GENERATOR] [char](1) NULL,
	[FED_WASTE_GENERATOR_OWNER] [char](2) NULL,
	[FED_WASTE_GENERATOR] [char](1) NULL,
	[COLLEGE_IND] [char](1) NULL,
	[HOSPITAL_IND] [char](1) NULL,
	[NON_PROFIT_IND] [char](1) NULL,
	[WITHDRAWAL_IND] [char](1) NULL,
	[TRANS_CODE] [char](1) NULL,
	[NOTIFICATION_RSN_CODE] [char](1) NULL,
	[EFFC_DATE] [datetime] NULL,
	[FINANCIAL_ASSURANCE_IND] [char](1) NULL,
    --Added for v5.3
    [RECYCLING_IND] [char](1) NULL,
    [MAIL_STREET_NUMBER] [varchar](12) NULL,
    [LOCATION_STREET_NUMBER] [varchar](12) NULL,
    [NON_NOTIFIER_TEXT] [varchar](255) NULL,
    [ACCESSIBILITY_TEXT] [varchar](255) NULL,
    [STATE_DISTRICT_TEXT] [varchar](255) NULL,
    --Added for v5.4
    [INTRNL_NOTES] [varchar](4000) NULL
 CONSTRAINT [PK_HD_HANDLER] PRIMARY KEY CLUSTERED 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_HAN_HD_HB_ID] ON [dbo].[RCRA_HD_HANDLER] 
(
	[HD_HBASIC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Top level of all information about the handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Top level of all information about the handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'HD_HBASIC_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the Handler (HandlerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'HANDLER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date information was received for the handler. (AcknowledgeReceiptDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACKNOWLEDGE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NON_NOTIFIER'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Top level of all information about the handler. (AcknowledgeFlag)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACKNOWLEDGE_FLAG'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact fax number (FaxNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_FAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET_NUMBER';
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_MIDDLE_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact fax number (FaxNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_FAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permit Contact Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_STREET_NUMBER';
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LAND_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_DISTRICT_OWNER'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'SHORT_TERM_GEN_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'TRANSFER_FACILITY_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_WASTE_GENERATOR_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FED_WASTE_GENERATOR_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FED_WASTE_GENERATOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether or not the Handler is a College or University opting into SubPart K. (CollegeIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'COLLEGE_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether or not the Handler is a Hospital opting into SubPart K. (HospitalIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'HOSPITAL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether or not the Handler is a Non-Profit opting into SubPart K. (NonProfitIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NON_PROFIT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether or not the Handler is withdrawing from SubPart K. (WithdrawalIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'WITHDRAWAL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the reason for notifying Hazardous Secondary Material (NotificationReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NOTIFICATION_RSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether or not the facility has provided Financial Assurance for the HSM Activities (FinancialAssuranceIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'FINANCIAL_ASSURANCE_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HandlerDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the facility has a recycling process which the product has levels of hazardous constituents that are not comparable to or unable to be compared to a legitimate product or intermediate but that the recycling is still legitimate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'RECYCLING_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mailing Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_STREET_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET_NUMBER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing Notification source (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NON_NOTIFIER_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing reason facility is not accessible (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACCESSIBILITY_TEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing the code indicating the state-designated legislative district(s) in which the site is located (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_DISTRICT_TEXT'
GO
/****** Object:  Table [dbo].[RCRA_CA_AREA]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_AREA](
	[CA_AREA_ID] [varchar](40) NOT NULL,
	[CA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[AREA_SEQ_NUM] [int] NOT NULL,
	[FAC_WIDE_IND] [char](1) NULL,
	[AREA_NAME] [varchar](40) NULL,
	[AIR_REL_IND] [char](1) NULL,
	[GROUNDWATER_REL_IND] [char](1) NULL,
	[SOIL_REL_IND] [char](1) NULL,
	[SURFACE_WATER_REL_IND] [char](1) NULL,
	[REGULATED_UNIT_IND] [char](1) NULL,
	[EPA_RESP_PERSON_DATA_OWNER_CDE] [char](2) NULL,
	[EPA_RESP_PERSON_ID] [varchar](5) NULL,
	[STA_RESP_PERSON_DATA_OWNER_CDE] [char](2) NULL,
	[STA_RESP_PERSON_ID] [varchar](5) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_CA_AREA] PRIMARY KEY CLUSTERED 
(
	[CA_AREA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_AR_CA_FC_SB] ON [dbo].[RCRA_CA_AREA] 
(
	[CA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of Correction Action Areas for a particluar Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'CA_AREA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of Correction Action Areas for a particluar Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'CA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'AREA_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that the corrective action applies to the entire facility. (FacilityWideIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'FAC_WIDE_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the Corrective Action area. (AreaName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'AREA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that there has been a release to air (either within or beyond the facility boundary) from the unit/area. This may include releases of subsurface gas. (AirReleaseIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'AIR_REL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that there has been a release to groundwater from the unit/area. (GroundwaterReleaseIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'GROUNDWATER_REL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that there has been a release to soil (either within or beyond the facility boundary) from the unit/area. This may include subsoil contamination beneath the unit/area. (SoilReleaseIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'SOIL_REL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that there has been a release to surface water (either within or beyond the facility boundary) from the unit/area. (SurfaceWaterReleaseIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'SURFACE_WATER_REL_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates that the corrective action applies to a regulated unit. (RegulatedUnitIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'REGULATED_UNIT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (EPAResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'EPA_RESP_PERSON_DATA_OWNER_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The person currently responsible for the permit at the EPA level. (EPAResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'EPA_RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (StateResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'STA_RESP_PERSON_DATA_OWNER_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The state person currently responsible for overseeing the corrective action area. (StateResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'STA_RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionAreaDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA'
GO
/****** Object:  Table [dbo].[RCRA_CME_VIOL]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_VIOL](
	[CME_VIOL_ID] [varchar](40) NOT NULL,
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
 CONSTRAINT [PK_CME_VIOL] PRIMARY KEY CLUSTERED 
(
	[CME_VIOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_VL_CM_FC_SB] ON [dbo].[RCRA_CME_VIOL] 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Violation Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL', @level2type=N'COLUMN',@level2name=N'CME_VIOL_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ViolationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL'
GO
/****** Object:  Table [dbo].[RCRA_FA_MECHANISM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_FA_MECHANISM](
	[FA_MECHANISM_ID] [varchar](40) NOT NULL,
	[FA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[MECHANISM_AGN_CODE] [char](1) NOT NULL,
	[MECHANISM_SEQ_NUM] [int] NOT NULL,
	[MECHANISM_TYPE_DATA_OWNER_CODE] [char](2) NULL,
	[MECHANISM_TYPE_CODE] [char](1) NULL,
	[PROVIDER_TXT] [varchar](80) NULL,
	[PROVIDER_FULL_CONTACT_NAME] [varchar](33) NULL,
	[TELE_NUM_TXT] [varchar](15) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_FA_MECHANISM] PRIMARY KEY CLUSTERED 
(
	[FA_MECHANISM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FA_MC_FA_FC_SB] ON [dbo].[RCRA_FA_MECHANISM] 
(
	[FA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'FA_MECHANISM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'FA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique numerical identier for the mechanism. (MechanismSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defined the mechanism type. (MechanismTypeDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_TYPE_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of mechanism that addresses the cost estimate. (MechanismTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the financial institution with which the financial assurance mechanism is held, such as a bank (letter of credit) or a surety (surety bond); also identifies a facility (financial test), or a guarantor (corporate guarantee). (ProviderText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'PROVIDER_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Name of the provider. (ProviderFullContactName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'PROVIDER_FULL_CONTACT_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: MechanismDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM'
GO
/****** Object:  Table [dbo].[RCRA_FA_COST_EST]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_FA_COST_EST](
	[FA_COST_EST_ID] [varchar](40) NOT NULL,
	[FA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[COST_ESTIMATE_TYPE_CODE] [char](1) NOT NULL,
	[COST_ESTIMATE_AGN_CODE] [char](1) NOT NULL,
	[COST_ESTIMATE_SEQ_NUM] [int] NOT NULL,
	[RESP_PERSON_DATA_OWNER_CODE] [char](2) NULL,
	[RESP_PERSON_ID] [varchar](5) NULL,
	[COST_ESTIMATE_AMOUNT] [decimal](13, 2) NULL,
	[COST_ESTIMATE_DATE] [datetime] NULL,
	[COST_ESTIMATE_RSN_CODE] [char](1) NULL,
	[AREA_UNIT_NOTES_TXT] [varchar](240) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_FA_COST_EST] PRIMARY KEY CLUSTERED 
(
	[FA_COST_EST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FA_CS_ES_FA_FC] ON [dbo].[RCRA_FA_COST_EST] 
(
	[FA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Estimates of the Financial liability costs associated with a given Handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'FA_COST_EST_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Estimates of the Financial liability costs associated with a given Handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'FA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates what type of Financial Assurance is Required. (CostEstimateTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'COST_ESTIMATE_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the agency responsible for overseeing the review of the cost estimate. (CostEstimateAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'COST_ESTIMATE_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique number that identifies the cost estimate. (CostEstimateSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'COST_ESTIMATE_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The dollar amount of the cost estimate for a given financial assurance type. (CostEstimateAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'COST_ESTIMATE_AMOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the cost estimate for a given financial assurance type was submitted, adjusted, approved, or required to be in place. (CostEstimateDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'COST_ESTIMATE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The reason the cost estimate for a financial assurance type is being reported. (CostEstimateReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'COST_ESTIMATE_RSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding the corrective action area or permit unit that this cost estimate applies. (AreaUnitNotesText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'AREA_UNIT_NOTES_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CostEstimateDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST'
GO
/****** Object:  Table [dbo].[RCRA_CA_EVENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_EVENT](
	[CA_EVENT_ID] [varchar](40) NOT NULL,
	[CA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[CORCT_ACT_EVENT_DATA_OWNER_CDE] [char](2) NOT NULL,
	[CORCT_ACT_EVENT_CODE] [varchar](7) NOT NULL,
	[EVENT_AGN_CODE] [char](1) NOT NULL,
	[EVENT_SEQ_NUM] [int] NOT NULL,
	[ACTL_DATE] [datetime] NULL,
	[ORIGINAL_SCHEDULE_DATE] [datetime] NULL,
	[NEW_SCHEDULE_DATE] [datetime] NULL,
	[EVENT_SUBORG_DATA_OWNER_CODE] [char](2) NULL,
	[EVENT_SUBORG_CODE] [varchar](10) NULL,
	[RESP_PERSON_DATA_OWNER_CODE] [char](2) NULL,
	[RESP_PERSON_ID] [varchar](5) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_CA_EVENT] PRIMARY KEY CLUSTERED 
(
	[CA_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_EV_CA_FC_SB] ON [dbo].[RCRA_CA_EVENT] 
(
	[CA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of Correction Action Events for a particluar Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'CA_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of Correction Action Events for a particluar Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'CA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_EVENT_DATA_OWNER_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_EVENT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agency responsible for the event. (EventAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which actual completion of an event occurs. (ActualDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'ACTL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'ORIGINAL_SCHEDULE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'NEW_SCHEDULE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SUBORG_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Event responsible suborganization. (EventSuborganizationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SUBORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionEventDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT'
GO
/****** Object:  Table [dbo].[RCRA_CA_AUTHORITY]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_AUTHORITY](
	[CA_AUTHORITY_ID] [varchar](40) NOT NULL,
	[CA_FAC_SUBM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[AUTHORITY_DATA_OWNER_CODE] [char](2) NOT NULL,
	[AUTHORITY_TYPE_CODE] [char](1) NOT NULL,
	[AUTHORITY_AGN_CODE] [char](1) NOT NULL,
	[AUTHORITY_EFFC_DATE] [datetime] NOT NULL,
	[ISSUE_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
	[ESTABLISHED_REPOSITORY_CODE] [char](1) NULL,
	[RESP_LEAD_PROG_IDEN] [char](1) NULL,
	[AUTHORITY_SUBORG_DATA_OWNR_CDE] [char](2) NULL,
	[AUTHORITY_SUBORG_CODE] [varchar](10) NULL,
	[RESP_PERSON_DATA_OWNER_CODE] [char](2) NULL,
	[RESP_PERSON_ID] [varchar](5) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_CA_AUTHORITY] PRIMARY KEY CLUSTERED 
(
	[CA_AUTHORITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_AT_CA_FC_SB] ON [dbo].[RCRA_CA_AUTHORITY] 
(
	[CA_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of Correction Action Authorities for a particluar Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'CA_AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A list of Correction Action Authorities for a particluar Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'CA_FAC_SUBM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the authority. (AuthorityDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'AUTHORITY_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code used to indicate whether a permit, administrative order, or other authority has been issued to implement the corrective action process. (AuthorityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'AUTHORITY_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agency responsible for the Authority. (AuthorityAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'AUTHORITY_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date that the authority became effective. (AuthorityEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'AUTHORITY_EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date the authorized agency official signs the order, permit, or permit modification. (IssueDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'ISSUE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date when the corrective action authority is revoked or ended. (EndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'END_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The action by which the Director requires the owner/operator to establish and maintain an information repository at a location near the facility for the purpose of making accessible to interested parties documents, reports, and other public information relevant to public understanding of the activities, findings, and plans for such corrective action initiatives. (EstablishedRepositoryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'ESTABLISHED_REPOSITORY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the program in which the organization establishes the applicable guidance that the authority should be issued. (ResponsibleLeadProgramIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'RESP_LEAD_PROG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Authority responsible suborganization owner. (AuthoritySuborganizationDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'AUTHORITY_SUBORG_DATA_OWNR_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Authority responsible suborganization. (AuthoritySuborganizationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'AUTHORITY_SUBORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionAuthorityDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTHORITY'
GO
/****** Object:  Table [dbo].[RCRA_CME_EVAL]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_EVAL](
	[CME_EVAL_ID] [varchar](40) NOT NULL,
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
 CONSTRAINT [PK_CME_EVAL] PRIMARY KEY CLUSTERED 
(
	[CME_EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_EV_CM_FC_SB] ON [dbo].[RCRA_CME_EVAL] 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Evaluation Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL', @level2type=N'COLUMN',@level2name=N'CME_EVAL_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EvaluationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL'
GO
/****** Object:  Table [dbo].[RCRA_CME_ENFRC_ACT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_ENFRC_ACT](
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
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
 CONSTRAINT [PK_CME_ENFRC_ACT] PRIMARY KEY CLUSTERED 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_EN_AC_CM_FC] ON [dbo].[RCRA_CME_ENFRC_ACT] 
(
	[CME_FAC_SUBM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EnforcementActionDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_ENFRC_ACT'
GO
/****** Object:  Table [dbo].[RCRA_CME_CSNY_DATE]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_CSNY_DATE](
	[CME_CSNY_DATE_ID] [varchar](40) NOT NULL,
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[SNY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_CME_CSNY_DATE] PRIMARY KEY CLUSTERED 
(
	[CME_CSNY_DATE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_CS_DT_CM_EN] ON [dbo].[RCRA_CME_CSNY_DATE] 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'CME_CSNY_DATE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date of the SNY that the Action is Addressing (SNYDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE', @level2type=N'COLUMN',@level2name=N'SNY_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CSNYDateDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CSNY_DATE'
GO
/****** Object:  Table [dbo].[RCRA_CME_CITATION]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_CITATION](
	[CME_CITATION_ID] [varchar](40) NOT NULL,
	[CME_VIOL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[CITATION_NAME_SEQ_NUM] [int] NOT NULL,
	[CITATION_NAME] [varchar](128) NULL,
	[CITATION_NAME_OWNER] [varchar](255) NULL,
	[CITATION_NAME_TYPE] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_CITATION] PRIMARY KEY CLUSTERED 
(
	[CME_CITATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CME_CT_CM_VL_ID] ON [dbo].[RCRA_CME_CITATION] 
(
	[CME_VIOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CME_CITATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CME_VIOL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (CitationNameSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The citation(s) of the violations alleged (CME) or of the Authority used (CA). (CitationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State postal code (CitationNameOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3 (CitationNameType)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'CITATION_NAME_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Citation Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CitationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_CITATION'
GO
/****** Object:  Table [dbo].[RCRA_CA_EVENT_COMMITMENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_EVENT_COMMITMENT](
	[CA_EVENT_COMMITMENT_ID] [varchar](40) NOT NULL,
	[CA_EVENT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[COMMIT_LEAD] [char](2) NOT NULL,
	[COMMIT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_CA_EVNT_CMMTMNT] PRIMARY KEY CLUSTERED 
(
	[CA_EVENT_COMMITMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_EV_CM_CA_EV] ON [dbo].[RCRA_CA_EVENT_COMMITMENT] 
(
	[CA_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'CA_EVENT_COMMITMENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'CA_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'COMMIT_LEAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'COMMIT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EventEventCommitmentDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_EVENT_COMMITMENT'
GO
/****** Object:  Table [dbo].[RCRA_CA_AUTH_REL_EVENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_AUTH_REL_EVENT](
	[CA_AUTH_REL_EVENT_ID] [varchar](40) NOT NULL,
	[CA_AUTHORITY_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[CORCT_ACT_EVENT_DATA_OWNER_CDE] [char](2) NOT NULL,
	[CORCT_ACT_EVENT_CODE] [varchar](7) NOT NULL,
	[EVENT_AGN_CODE] [char](1) NOT NULL,
	[EVENT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_CA_AUTH_RL_EVNT] PRIMARY KEY CLUSTERED 
(
	[CA_AUTH_REL_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_AT_RL_EV_CA] ON [dbo].[RCRA_CA_AUTH_REL_EVENT] 
(
	[CA_AUTHORITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CA_AUTH_REL_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CA_AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_EVENT_DATA_OWNER_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_EVENT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agency responsible for the event. (EventAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionAuthorityRelatedEventDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AUTH_REL_EVENT'
GO
/****** Object:  Table [dbo].[RCRA_CA_AREA_REL_EVENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_AREA_REL_EVENT](
	[CA_AREA_REL_EVENT_ID] [varchar](40) NOT NULL,
	[CA_AREA_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[CORCT_ACT_EVENT_DATA_OWNER_CDE] [char](2) NOT NULL,
	[CORCT_ACT_EVENT_CODE] [varchar](7) NOT NULL,
	[EVENT_AGN_CODE] [char](1) NOT NULL,
	[EVENT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_CA_AREA_RL_EVNT] PRIMARY KEY CLUSTERED 
(
	[CA_AREA_REL_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_AR_RL_EV_CA] ON [dbo].[RCRA_CA_AREA_REL_EVENT] 
(
	[CA_AREA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CA_AREA_REL_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CA_AREA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_EVENT_DATA_OWNER_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'CORCT_ACT_EVENT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agency responsible for the event. (EventAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionAreaRelatedEventDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_AREA_REL_EVENT'
GO
/****** Object:  Table [dbo].[RCRA_CME_EVAL_VIOL]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_EVAL_VIOL](
	[CME_EVAL_VIOL_ID] [varchar](40) NOT NULL,
	[CME_EVAL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[VIOL_ACT_LOC] [varchar](255) NOT NULL,
	[VIOL_SEQ_NUM] [int] NOT NULL,
	[AGN_WHICH_DTRM_VIOL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_CME_EVAL_VIOL] PRIMARY KEY CLUSTERED 
(
	[CME_EVAL_VIOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_EV_VL_CM_EV] ON [dbo].[RCRA_CME_EVAL_VIOL] 
(
	[CME_EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'CME_EVAL_VIOL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'CME_EVAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (ViolationActivityLocation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_ACT_LOC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (ViolationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'VIOL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Evaluation and Violation (AgencyWhichDeterminedViolation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL', @level2type=N'COLUMN',@level2name=N'AGN_WHICH_DTRM_VIOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EvaluationViolationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_VIOL'
GO
/****** Object:  Table [dbo].[RCRA_CME_EVAL_COMMIT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_EVAL_COMMIT](
	[CME_EVAL_COMMIT_ID] [varchar](40) NOT NULL,
	[CME_EVAL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[COMMIT_LEAD] [varchar](255) NOT NULL,
	[COMMIT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_CME_EVAL_COMMIT] PRIMARY KEY CLUSTERED 
(
	[CME_EVAL_COMMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_EV_CM_CM_EV] ON [dbo].[RCRA_CME_EVAL_COMMIT] 
(
	[CME_EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'CME_EVAL_COMMIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'CME_EVAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentLead)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'COMMIT_LEAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT', @level2type=N'COLUMN',@level2name=N'COMMIT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EvaluationCommitmentDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_EVAL_COMMIT'
GO
/****** Object:  Table [dbo].[RCRA_CA_STATUTORY_CITATION]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_STATUTORY_CITATION](
	[CA_STATUTORY_CITATION_ID] [varchar](40) NOT NULL,
	[CA_AUTHORITY_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[STATUTORY_CITTION_DTA_OWNR_CDE] [char](2) NOT NULL,
	[STATUTORY_CITATION_IDEN] [char](1) NOT NULL,
 CONSTRAINT [PK_CA_STTTRY_CTTON] PRIMARY KEY CLUSTERED 
(
	[CA_STATUTORY_CITATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_ST_CT_CA_AT] ON [dbo].[RCRA_CA_STATUTORY_CITATION] 
(
	[CA_AUTHORITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_STATUTORY_CITATION', @level2type=N'COLUMN',@level2name=N'CA_STATUTORY_CITATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_STATUTORY_CITATION', @level2type=N'COLUMN',@level2name=N'CA_AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_STATUTORY_CITATION', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Orgnaization responsible for the Statutory Citation (use two-digit postal code) (StatutoryCitationDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_STATUTORY_CITATION', @level2type=N'COLUMN',@level2name=N'STATUTORY_CITTION_DTA_OWNR_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifier that identifies the statutory authority under which the corrective action event occured (StatutoryCitationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_STATUTORY_CITATION', @level2type=N'COLUMN',@level2name=N'STATUTORY_CITATION_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionStatutoryCitationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_STATUTORY_CITATION'
GO
/****** Object:  Table [dbo].[RCRA_CA_REL_PERMIT_UNIT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CA_REL_PERMIT_UNIT](
	[CA_REL_PERMIT_UNIT_ID] [varchar](40) NOT NULL,
	[CA_AREA_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[PERMIT_UNIT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_CA_RL_PRMIT_UNT] PRIMARY KEY CLUSTERED 
(
	[CA_REL_PERMIT_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CA_RL_PR_UN_CA] ON [dbo].[RCRA_CA_REL_PERMIT_UNIT] 
(
	[CA_AREA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A permitted unit related to a corrective action area. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_REL_PERMIT_UNIT', @level2type=N'COLUMN',@level2name=N'CA_REL_PERMIT_UNIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A permitted unit related to a corrective action area. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_REL_PERMIT_UNIT', @level2type=N'COLUMN',@level2name=N'CA_AREA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_REL_PERMIT_UNIT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_REL_PERMIT_UNIT', @level2type=N'COLUMN',@level2name=N'PERMIT_UNIT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CorrectiveActionRelatedPermitUnitDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CA_REL_PERMIT_UNIT'
GO
/****** Object:  Table [dbo].[RCRA_CME_PNLTY]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_PNLTY](
	[CME_PNLTY_ID] [varchar](40) NOT NULL,
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[PNLTY_TYPE_OWNER] [varchar](255) NOT NULL,
	[PNLTY_TYPE] [varchar](255) NOT NULL,
	[CASH_CIVIL_PNLTY_SOUGHT_AMOUNT] [decimal](13, 2) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_PNLTY] PRIMARY KEY CLUSTERED 
(
	[CME_PNLTY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_PN_CM_EN_AC] ON [dbo].[RCRA_CME_PNLTY] 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Penalty Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'CME_PNLTY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Penalty Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PenaltyDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PNLTY'
GO
/****** Object:  Table [dbo].[RCRA_CME_MILESTONE]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_MILESTONE](
	[CME_MILESTONE_ID] [varchar](40) NOT NULL,
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[MILESTONE_SEQ_NUM] [int] NOT NULL,
	[TECH_RQMT_IDEN] [varchar](50) NULL,
	[TECH_RQMT_DESC] [varchar](255) NULL,
	[MILESTONE_SCHD_COMP_DATE] [datetime] NULL,
	[MILESTONE_ACTL_COMP_DATE] [datetime] NULL,
	[MILESTONE_DFLT_DATE] [datetime] NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_MILESTONE] PRIMARY KEY CLUSTERED 
(
	[CME_MILESTONE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_ML_CM_EN_AC] ON [dbo].[RCRA_CME_MILESTONE] 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'CME_MILESTONE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Milestone Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: MilestoneDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MILESTONE'
GO
/****** Object:  Table [dbo].[RCRA_CME_MEDIA]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_MEDIA](
	[CME_MEDIA_ID] [varchar](40) NOT NULL,
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[MULTIMEDIA_CODE_OWNER] [varchar](255) NOT NULL,
	[MULTIMEDIA_CODE] [varchar](50) NOT NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_MEDIA] PRIMARY KEY CLUSTERED 
(
	[CME_MEDIA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_MD_CM_EN_AC] ON [dbo].[RCRA_CME_MEDIA] 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enfocement Multimedia Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'CME_MEDIA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enfocement Multimedia Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the multimedia code. (MultimediaCodeOwner)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'MULTIMEDIA_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code which indicates the medium or program other than RCRA participating in the enforcement action. (MultimediaCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'MULTIMEDIA_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enfocement Multimedia Data (Notes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: MediaDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_MEDIA'
GO
/****** Object:  Table [dbo].[RCRA_CME_RQST]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_RQST](
	[CME_RQST_ID] [varchar](40) NOT NULL,
	[CME_EVAL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[RQST_SEQ_NUM] [int] NOT NULL,
	[DATE_OF_RQST] [datetime] NULL,
	[DATE_RESP_RCVD] [datetime] NULL,
	[RQST_AGN] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_RQST] PRIMARY KEY CLUSTERED 
(
	[CME_RQST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CME_RQ_CM_EV_ID] ON [dbo].[RCRA_CME_RQST] 
(
	[CME_EVAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'CME_RQST_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Request Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST', @level2type=N'COLUMN',@level2name=N'CME_EVAL_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: RequestDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_RQST'
GO
/****** Object:  Table [dbo].[RCRA_FA_MECHANISM_DETAIL]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_FA_MECHANISM_DETAIL](
	[FA_MECHANISM_DETAIL_ID] [varchar](40) NOT NULL,
	[FA_MECHANISM_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[MECHANISM_DETAIL_SEQ_NUM] [int] NOT NULL,
	[MECHANISM_IDEN_TXT] [varchar](40) NULL,
	[FACE_VAL_AMOUNT] [decimal](13, 2) NULL,
	[EFFC_DATE] [datetime] NULL,
	[EXPIRATION_DATE] [datetime] NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_FA_MCHNISM_DTIL] PRIMARY KEY CLUSTERED 
(
	[FA_MECHANISM_DETAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FA_MC_DT_FA_MC] ON [dbo].[RCRA_FA_MECHANISM_DETAIL] 
(
	[FA_MECHANISM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'FA_MECHANISM_DETAIL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'FA_MECHANISM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'MECHANISM_DETAIL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned to the mechanism, such as a bond number or insurance policy number. (MechanismIdentificationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'MECHANISM_IDEN_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total dollar value of the financial assurance mechanism. (FaceValueAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'FACE_VAL_AMOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the instrument terminates, such as the end of the term of an insurance policy. (ExpirationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'EXPIRATION_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: MechanismDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_MECHANISM_DETAIL'
GO
/****** Object:  Table [dbo].[RCRA_CME_VIOL_ENFRC]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_VIOL_ENFRC](
	[CME_VIOL_ENFRC_ID] [varchar](40) NOT NULL,
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[VIOL_SEQ_NUM] [int] NOT NULL,
	[AGN_WHICH_DTRM_VIOL] [varchar](255) NOT NULL,
	[RTN_COMPL_SCHD_DATE] [datetime] NULL,
 CONSTRAINT [PK_CME_VIOL_ENFRC] PRIMARY KEY CLUSTERED 
(
	[CME_VIOL_ENFRC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_VL_EN_CM_EN] ON [dbo].[RCRA_CME_VIOL_ENFRC] 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'CME_VIOL_ENFRC_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (ViolationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'VIOL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Violation and Enforcement (AgencyWhichDeterminedViolation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'AGN_WHICH_DTRM_VIOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date, specified in the Compliance Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC', @level2type=N'COLUMN',@level2name=N'RTN_COMPL_SCHD_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ViolationEnforcementDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_VIOL_ENFRC'
GO
/****** Object:  Table [dbo].[RCRA_FA_COST_EST_REL_MECHANISM]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_FA_COST_EST_REL_MECHANISM](
	[FA_COST_EST_REL_MECHANISM_ID] [varchar](40) NOT NULL,
	[FA_COST_EST_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[MECHANISM_AGN_CODE] [char](1) NOT NULL,
	[MECHANISM_SEQ_NUM] [int] NOT NULL,
	[MECHANISM_DETAIL_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_FA_CST_ES_RL_MC] PRIMARY KEY CLUSTERED 
(
	[FA_COST_EST_REL_MECHANISM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_FA_CS_ES_RL_MC] ON [dbo].[RCRA_FA_COST_EST_REL_MECHANISM] 
(
	[FA_COST_EST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Cost Estimates and Related Mechanisms (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'FA_COST_EST_REL_MECHANISM_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Cost Estimates and Related Mechanisms (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'FA_COST_EST_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique numerical identier for the mechanism. (MechanismSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM', @level2type=N'COLUMN',@level2name=N'MECHANISM_DETAIL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CostEstimateRelatedMechanismDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_FA_COST_EST_REL_MECHANISM'
GO
/****** Object:  Table [dbo].[RCRA_CME_SUPP_ENVR_PRJT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_SUPP_ENVR_PRJT](
	[CME_SUPP_ENVR_PRJT_ID] [varchar](40) NOT NULL,
	[CME_ENFRC_ACT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[SEP_SEQ_NUM] [int] NOT NULL,
	[SEP_EXPND_AMOUNT] [decimal](13, 2) NULL,
	[SEP_SCHD_COMP_DATE] [datetime] NULL,
	[SEP_ACTL_DATE] [datetime] NULL,
	[SEP_DFLT_DATE] [datetime] NULL,
	[SEP_CODE_OWNER] [varchar](255) NULL,
	[SEP_DESC_TXT] [varchar](255) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_SPP_ENV_PRJ] PRIMARY KEY CLUSTERED 
(
	[CME_SUPP_ENVR_PRJT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CM_SP_EN_PR_CM] ON [dbo].[RCRA_CME_SUPP_ENVR_PRJT] 
(
	[CME_ENFRC_ACT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'CME_SUPP_ENVR_PRJT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT', @level2type=N'COLUMN',@level2name=N'CME_ENFRC_ACT_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SupplementalEnvironmentalProjectDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_SUPP_ENVR_PRJT'
GO
/****** Object:  Table [dbo].[RCRA_HD_ENV_PERMIT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_ENV_PERMIT](
	[HD_ENV_PERMIT_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[ENV_PERMIT_NUMBER] [varchar](13) NOT NULL,
	[ENV_PERMIT_OWNER] [char](2) NULL,
	[ENV_PERMIT_TYPE] [char](1) NULL,
	[ENV_PERMIT_DESC] [varchar](80) NOT NULL,
 CONSTRAINT [PK_HD_ENV_PERMIT] PRIMARY KEY CLUSTERED 
(
	[HD_ENV_PERMIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_EN_PE_HD_HA] ON [dbo].[RCRA_HD_ENV_PERMIT] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about environmental permits issued to the handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'HD_ENV_PERMIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about environmental permits issued to the handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EnvironmentalPermitDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_ENV_PERMIT'
GO
/****** Object:  Table [dbo].[RCRA_HD_CERTIFICATION]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_CERTIFICATION](
	[HD_CERTIFICATION_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[CERT_SEQ] [int] NOT NULL,
	[CERT_SIGNED_DATE] [varchar](10) NULL,
	[CERT_TITLE] [varchar](45) NULL,
	[CERT_FIRST_NAME] [varchar](38) NULL,
	[CERT_MIDDLE_INITIAL] [char](1) NULL,
	[CERT_LAST_NAME] [varchar](38) NULL,
 CONSTRAINT [PK_HD_CERTIFICATIO] PRIMARY KEY CLUSTERED 
(
	[HD_CERTIFICATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_CER_HD_HA_ID] ON [dbo].[RCRA_HD_CERTIFICATION] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Certification information for the person who certified report to the authorizing agency. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'HD_CERTIFICATION_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Certification information for the person who certified report to the authorizing agency. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence number for each certification for the handler. (CertificationSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which the handler information was certified by the reporting site. (SignedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_SIGNED_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First name of a person. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Middle initial of a person. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last name of a person. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CertificationDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION'
GO
/****** Object:  Table [dbo].[RCRA_HD_NAICS]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_NAICS](
	[HD_NAICS_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[NAICS_SEQ] [int] NOT NULL,
	[NAICS_OWNER] [char](2) NULL,
	[NAICS_CODE] [varchar](6) NULL,
 CONSTRAINT [PK_HD_NAICS] PRIMARY KEY CLUSTERED 
(
	[HD_NAICS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_NAI_HD_HA_ID] ON [dbo].[RCRA_HD_NAICS] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: North American Industry Classification Status codes reported for the handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'HD_NAICS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: North American Industry Classification Status codes reported for the handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence number for each NAICS code for the handler. (NAICSSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the NAICS Code. (NAICSOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The North American Industry Classification System Code that identifies the business activities of the facility. (NAICSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS', @level2type=N'COLUMN',@level2name=N'NAICS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: NAICSIdentityDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_NAICS'
GO
/****** Object:  Table [dbo].[RCRA_HD_STATE_ACTIVITY]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_STATE_ACTIVITY](
	[HD_STATE_ACTIVITY_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[STATE_ACTIVITY_OWNER] [char](2) NOT NULL,
	[STATE_ACTIVITY_TYPE] [varchar](5) NOT NULL,
 CONSTRAINT [PK_HD_STATE_ACTIVI] PRIMARY KEY CLUSTERED 
(
	[HD_STATE_ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_ST_AC_HD_HA] ON [dbo].[RCRA_HD_STATE_ACTIVITY] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: State waste activity of the handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'HD_STATE_ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: State waste activity of the handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the state activity type. (StateActivityOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'STATE_ACTIVITY_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the type of state activity. (StateActivityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY', @level2type=N'COLUMN',@level2name=N'STATE_ACTIVITY_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: StateActivityDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_STATE_ACTIVITY'
GO
/****** Object:  Table [dbo].[RCRA_PRM_EVENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_EVENT](
	[PRM_EVENT_ID] [varchar](40) NOT NULL,
	[PRM_SERIES_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[PERMIT_EVENT_DATA_OWNER_CODE] [char](2) NOT NULL,
	[PERMIT_EVENT_CODE] [varchar](7) NOT NULL,
	[EVENT_AGN_CODE] [char](1) NOT NULL,
	[EVENT_SEQ_NUM] [int] NOT NULL,
	[ACTL_DATE] [datetime] NULL,
	[ORIGINAL_SCHEDULE_DATE] [datetime] NULL,
	[NEW_SCHEDULE_DATE] [datetime] NULL,
	[RESP_PERSON_DATA_OWNER_CODE] [char](2) NULL,
	[RESP_PERSON_ID] [varchar](5) NULL,
	[EVENT_SUBORG_DATA_OWNER_CODE] [char](2) NULL,
	[EVENT_SUBORG_CODE] [varchar](10) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_PRM_EVENT] PRIMARY KEY CLUSTERED 
(
	[PRM_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PRM_EV_PR_SR_ID] ON [dbo].[RCRA_PRM_EVENT] 
(
	[PRM_SERIES_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit event Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'PRM_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit event Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'PRM_SERIES_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the event. (PermitEventDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'PERMIT_EVENT_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'PERMIT_EVENT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agency responsible for the event. (EventAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date on which actual completion of an event occurs. (ActualDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'ACTL_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'ORIGINAL_SCHEDULE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'NEW_SCHEDULE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'RESP_PERSON_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SUBORG_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Event responsible suborganization. (EventSuborganizationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SUBORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitEventDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT'
GO
/****** Object:  Table [dbo].[RCRA_HD_WASTE_CODE]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_WASTE_CODE](
	[HD_WASTE_CODE_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[WASTE_CODE_OWNER] [char](2) NULL,
	[WASTE_CODE_TYPE] [varchar](6) NULL,
 CONSTRAINT [PK_HD_WASTE_CODE] PRIMARY KEY CLUSTERED 
(
	[HD_WASTE_CODE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_WA_CO_HD_HA] ON [dbo].[RCRA_HD_WASTE_CODE] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'HD_WASTE_CODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that owns the data record. (WasteCodeOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to describe hazardous waste. (WasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HandlerWasteCodeDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_WASTE_CODE'
GO
/****** Object:  Table [dbo].[RCRA_HD_UNIVERSAL_WASTE]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_UNIVERSAL_WASTE](
	[HD_UNIVERSAL_WASTE_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[UNIVERSAL_WASTE_OWNER] [char](2) NULL,
	[UNIVERSAL_WASTE_TYPE] [char](1) NULL,
	[ACCUMULATED] [char](1) NULL,
	[GENERATED] [char](1) NULL,
 CONSTRAINT [PK_HD_UNIVER_WASTE] PRIMARY KEY CLUSTERED 
(
	[HD_UNIVERSAL_WASTE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_UN_WA_HD_HA] ON [dbo].[RCRA_HD_UNIVERSAL_WASTE] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about universal waste generated by the handler. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'HD_UNIVERSAL_WASTE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Information about universal waste generated by the handler. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: UniversalWasteActivityDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_UNIVERSAL_WASTE'
GO
/****** Object:  Table [dbo].[RCRA_HD_SEC_MATERIAL_ACTIVITY]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_SEC_MATERIAL_ACTIVITY](
	[HD_SEC_MATERIAL_ACTIVITY_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[HSM_SEQ_NUM] [varchar](20) NOT NULL,
	[FAC_CODE_OWNER_NAME] [varchar](128) NULL,
	[FAC_TYPE_CODE] [varchar](50) NULL,
	[ESTIMATED_SHORT_TONS_QNTY] [int] NULL,
	[ACTL_SHORT_TONS_QNTY] [int] NULL,
	[LAND_BASED_UNIT_IND] [varchar](50) NULL,
    --Added for v5.3
    LAND_BASED_UNIT_IND_TEXT [varchar](255) NULL,
 CONSTRAINT [PK_HD_SEC_MATE_ACT] PRIMARY KEY CLUSTERED 
(
	[HD_SEC_MATERIAL_ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_SE_MA_AC_HD] ON [dbo].[RCRA_HD_SEC_MATERIAL_ACTIVITY] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous Secondary Material activity of the Handler (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'HD_SEC_MATERIAL_ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous Secondary Material activity of the Handler (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique number identifying the HSM Activity for the Handler (HSMSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'HSM_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner of the Facility Code.  Shoule be HQ or the state code (i.e. KS) (FacilityCodeOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'FAC_CODE_OWNER_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of facility generating Hazardous Secondary Material (FacilityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'FAC_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The estimated amount of HSM generated by the Handler (EstimatedShortTonsQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'ESTIMATED_SHORT_TONS_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual amount of HSM generated by the Handler (ActualShortTonsQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'ACTL_SHORT_TONS_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code to indicate if the HSM is being managed in a Land Based Unit (LandBasedUnitIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'LAND_BASED_UNIT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: HazardousSecondaryMaterialActivityDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing the code to indicate if the HSM is being managed in a Land Based Unit (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'LAND_BASED_UNIT_IND_TEXT'
GO
/****** Object:  Table [dbo].[RCRA_HD_OWNEROP]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_OWNEROP](
	[HD_OWNEROP_ID] [varchar](40) NOT NULL,
	[HD_HANDLER_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[OWNER_OP_SEQ] [int] NOT NULL,
	[OWNER_OP_IND] [char](2) NULL,
	[OWNER_OP_TYPE] [char](1) NULL,
	[DATE_BECAME_CURRENT] [varchar](10) NULL,
	[DATE_ENDED_CURRENT] [varchar](10) NULL,
	[NOTES] [varchar](2000) NULL,
	[FIRST_NAME] [varchar](38) NULL,
	[MIDDLE_INITIAL] [char](1) NULL,
	[LAST_NAME] [varchar](38) NULL,
	[ORG_NAME] [varchar](80) NULL,
	[TITLE] [varchar](80) NULL,
	[EMAIL_ADDRESS] [varchar](240) NULL,
	[PHONE] [varchar](15) NULL,
	[PHONE_EXT] [varchar](6) NULL,
	[FAX] [varchar](15) NULL,
    [MAIL_ADDR_NUM_TXT] [varchar](12) NULL,
	[STREET1] [varchar](30) NULL,
	[STREET2] [varchar](30) NULL,
	[CITY] [varchar](25) NULL,
	[STATE] [char](2) NULL,
	[COUNTRY] [char](2) NULL,
	[ZIP] [varchar](14) NULL,
 CONSTRAINT [PK_HD_OWNEROP] PRIMARY KEY CLUSTERED 
(
	[HD_OWNEROP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_OWN_HD_HA_ID] ON [dbo].[RCRA_HD_OWNEROP] 
(
	[HD_HANDLER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler owner and operator information. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'HD_OWNEROP_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Handler owner and operator information. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'HD_HANDLER_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes for the facility Owner Operator. (OwnerOperatorSupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'NOTES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'FIRST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (MiddleInitial)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'MIDDLE_INITIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'LAST_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Contact information. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'TITLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email address data (EmailAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'EMAIL_ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone Number data (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telephone number extension (PhoneExtensionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'PHONE_EXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact fax number (FaxNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'FAX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner/Operator Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_NUM_TXT';
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FacilityOwnerOperatorDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP'
GO
/****** Object:  Table [dbo].[RCRA_PRM_UNIT_DETAIL]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_UNIT_DETAIL](
	[PRM_UNIT_DETAIL_ID] [varchar](40) NOT NULL,
	[PRM_UNIT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[PERMIT_UNIT_DETAIL_SEQ_NUM] [int] NOT NULL,
	[PROC_UNIT_DATA_OWNER_CODE] [char](2) NULL,
	[PROC_UNIT_CODE] [varchar](3) NULL,
	[PERMIT_STAT_EFFC_DATE] [datetime] NULL,
	[PERMIT_UNIT_CAP_QNTY] [decimal](14, 3) NULL,
	[CAP_TYPE_CODE] [char](1) NULL,
	[COMMER_STAT_CODE] [char](1) NULL,
	[LEGAL_OPER_STAT_DATA_OWNER_CDE] [char](2) NULL,
	[LEGAL_OPER_STAT_CODE] [varchar](4) NULL,
	[MEASUREMENT_UNIT_DATA_OWNR_CDE] [char](2) NULL,
	[MEASUREMENT_UNIT_CODE] [char](1) NULL,
	[NUM_OF_UNITS_COUNT] [int] NULL,
	[STANDARD_PERMIT_IND] [char](1) NULL,
	[SUPP_INFO_TXT] [varchar](2000) NULL,
 CONSTRAINT [PK_PRM_UNIT_DETAIL] PRIMARY KEY CLUSTERED 
(
	[PRM_UNIT_DETAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_UN_DT_PR_UN] ON [dbo].[RCRA_PRM_UNIT_DETAIL] 
(
	[PRM_UNIT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit Unit Detail Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PRM_UNIT_DETAIL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Permit Unit Detail Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PRM_UNIT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify a process unit detail. (PermitUnitDetailSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PERMIT_UNIT_DETAIL_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the process code. (ProcessUnitDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PROC_UNIT_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code specifying the unit group''s current waste treatment, storage, or disposal process. (ProcessUnitCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PROC_UNIT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date specifying when the other information in the process detail data record (i.e., process, capacity, and operating and legal status) became effective. (PermitStatusEffectiveDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PERMIT_STAT_EFFC_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permitted capacity of the unit (PermitUnitCapacityQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'PERMIT_UNIT_CAP_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the type of capacity. (CapacityTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'CAP_TYPE_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating that the facility, whether public or private, accepts hazardous waste for the process unit group from a third party. (CommercialStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'COMMER_STAT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the legal/operating status code. (LegalOperatingStatusDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'LEGAL_OPER_STAT_DATA_OWNER_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to indicate programmatic (operating and legal status) conditions that reflect RCRA program activity requirements of a unit. (LegalOperatingStatusCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'LEGAL_OPER_STAT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the unit of measure. (MeasurementUnitDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'MEASUREMENT_UNIT_DATA_OWNR_CDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the unit of measure. (MeasurementUnitCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'MEASUREMENT_UNIT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total number of units of the same process grouped together to form a single process unit group. (NumberOfUnitsCount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'NUM_OF_UNITS_COUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates whether or not the permit is a standardized permit. (StandardPermitIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'STANDARD_PERMIT_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes providing more information. (SupplementalInformationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPP_INFO_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitUnitDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_UNIT_DETAIL'
GO
/****** Object:  Table [dbo].[RCRA_PRM_WASTE_CODE]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_WASTE_CODE](
	[PRM_WASTE_CODE_ID] [varchar](40) NOT NULL,
	[PRM_UNIT_DETAIL_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[WASTE_CODE_OWNER] [char](2) NULL,
	[WASTE_CODE_TYPE] [varchar](6) NULL,
 CONSTRAINT [PK_PRM_WASTE_CODE] PRIMARY KEY CLUSTERED 
(
	[PRM_WASTE_CODE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_WS_CD_PR_UN] ON [dbo].[RCRA_PRM_WASTE_CODE] 
(
	[PRM_UNIT_DETAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'PRM_WASTE_CODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'PRM_UNIT_DETAIL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that owns the data record. (WasteCodeOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to describe hazardous waste. (WasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitHandlerWasteCodeDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_WASTE_CODE'
GO
/****** Object:  Table [dbo].[RCRA_PRM_RELATED_EVENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_RELATED_EVENT](
	[PRM_RELATED_EVENT_ID] [varchar](40) NOT NULL,
	[PRM_UNIT_DETAIL_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[ACT_LOC_CODE] [char](2) NOT NULL,
	[PERMIT_SERIES_SEQ_NUM] [int] NOT NULL,
	[PERMIT_EVENT_DATA_OWNER_CODE] [char](2) NOT NULL,
	[PERMIT_EVENT_CODE] [varchar](7) NOT NULL,
	[EVENT_AGN_CODE] [char](1) NOT NULL,
	[EVENT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_PRM_RELTED_EVNT] PRIMARY KEY CLUSTERED 
(
	[PRM_RELATED_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_RL_EV_PR_UN] ON [dbo].[RCRA_PRM_RELATED_EVENT] 
(
	[PRM_UNIT_DETAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Permitted Units and Permitting Events (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'PRM_RELATED_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Permitted Units and Permitting Events (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'PRM_UNIT_DETAIL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the location of the agency regulating the handler. (ActivityLocationCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'ACT_LOC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'PERMIT_SERIES_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that defines the event. (PermitEventDataOwnerCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'PERMIT_EVENT_DATA_OWNER_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'PERMIT_EVENT_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Agency responsible for the event. (EventAgencyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_AGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT', @level2type=N'COLUMN',@level2name=N'EVENT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitRelatedEventDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_RELATED_EVENT'
GO
/****** Object:  Table [dbo].[RCRA_PRM_EVENT_COMMITMENT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_PRM_EVENT_COMMITMENT](
	[PRM_EVENT_COMMITMENT_ID] [varchar](40) NOT NULL,
	[PRM_EVENT_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [char](1) NULL,
	[COMMIT_LEAD] [char](2) NOT NULL,
	[COMMIT_SEQ_NUM] [int] NOT NULL,
 CONSTRAINT [PK_PRM_EVNT_CMMTMN] PRIMARY KEY CLUSTERED 
(
	[PRM_EVENT_COMMITMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PR_EV_CM_PR_EV] ON [dbo].[RCRA_PRM_EVENT_COMMITMENT] 
(
	[PRM_EVENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'PRM_EVENT_COMMITMENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'PRM_EVENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'TRANS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'COMMIT_LEAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT_COMMITMENT', @level2type=N'COLUMN',@level2name=N'COMMIT_SEQ_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PermitEventCommitmentDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_PRM_EVENT_COMMITMENT'
GO
/****** Object:  Table [dbo].[RCRA_HD_SEC_WASTE_CODE]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_HD_SEC_WASTE_CODE](
	[HD_SEC_WASTE_CODE_ID] [varchar](40) NOT NULL,
	[HD_SEC_MATERIAL_ACTIVITY_ID] [varchar](40) NOT NULL,
	[TRANSACTION_CODE] [char](1) NULL,
	[WASTE_CODE_OWNER] [char](2) NULL,
	[WASTE_CODE_TYPE] [varchar](6) NULL,
 CONSTRAINT [PK_HD_SEC_WAST_COD] PRIMARY KEY CLUSTERED 
(
	[HD_SEC_WASTE_CODE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HD_SE_WA_CO_HD] ON [dbo].[RCRA_HD_SEC_WASTE_CODE] 
(
	[HD_SEC_MATERIAL_ACTIVITY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'HD_SEC_WASTE_CODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'HD_SEC_MATERIAL_ACTIVITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Transaction code used to define the add, update, or delete. (TransactionCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'TRANSACTION_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the agency that owns the data record. (WasteCodeOwnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_OWNER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code used to describe hazardous waste. (WasteCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_WASTE_CODE', @level2type=N'COLUMN',@level2name=N'WASTE_CODE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SecondaryHandlerWasteCodeDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_WASTE_CODE'
GO
/****** Object:  Table [dbo].[RCRA_CME_PYMT]    Script Date: 10/06/2010 21:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RCRA_CME_PYMT](
	[CME_PYMT_ID] [varchar](40) NOT NULL,
	[CME_PNLTY_ID] [varchar](40) NOT NULL,
	[TRANS_CODE] [varchar](50) NULL,
	[PYMT_SEQ_NUM] [int] NOT NULL,
	[PYMT_DFLT_DATE] [datetime] NULL,
	[SCHD_PYMT_DATE] [datetime] NULL,
	[SCHD_PYMT_AMOUNT] [decimal](13, 2) NULL,
	[ACTL_PYMT_DATE] [datetime] NULL,
	[ACTL_PAID_AMOUNT] [decimal](13, 2) NULL,
	[NOTES] [varchar](2000) NULL,
 CONSTRAINT [PK_CME_PYMT] PRIMARY KEY CLUSTERED 
(
	[CME_PYMT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CME_PY_CM_PN_ID] ON [dbo].[RCRA_CME_PYMT] 
(
	[CME_PNLTY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (_PK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'CME_PYMT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Compliance Monitoring and Enforcement Payment Data (_FK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT', @level2type=N'COLUMN',@level2name=N'CME_PNLTY_ID'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: PaymentDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_CME_PYMT'
GO
/****** Object:  ForeignKey [FK_CME_FC_SB_CM_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_FAC_SUBM]  WITH CHECK ADD  CONSTRAINT [FK_CME_FC_SB_CM_SB] FOREIGN KEY([CME_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_SUBM] ([CME_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_FAC_SUBM] CHECK CONSTRAINT [FK_CME_FC_SB_CM_SB]
GO
/****** Object:  ForeignKey [FK_CA_FC_SBM_CA_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_FAC_SUBM]  WITH CHECK ADD  CONSTRAINT [FK_CA_FC_SBM_CA_SB] FOREIGN KEY([CA_SUBM_ID])
REFERENCES [dbo].[RCRA_CA_SUBM] ([CA_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_FAC_SUBM] CHECK CONSTRAINT [FK_CA_FC_SBM_CA_SB]
GO
/****** Object:  ForeignKey [FK_GS_FC_SBM_GS_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_GIS_FAC_SUBM]  WITH CHECK ADD  CONSTRAINT [FK_GS_FC_SBM_GS_SB] FOREIGN KEY([GIS_SUBM_ID])
REFERENCES [dbo].[RCRA_GIS_SUBM] ([GIS_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_GIS_FAC_SUBM] CHECK CONSTRAINT [FK_GS_FC_SBM_GS_SB]
GO
/****** Object:  ForeignKey [FK_FA_FC_SBM_FA_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_FA_FAC_SUBM]  WITH CHECK ADD  CONSTRAINT [FK_FA_FC_SBM_FA_SB] FOREIGN KEY([FA_SUBM_ID])
REFERENCES [dbo].[RCRA_FA_SUBM] ([FA_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_FA_FAC_SUBM] CHECK CONSTRAINT [FK_FA_FC_SBM_FA_SB]
GO
/****** Object:  ForeignKey [FK_HD_HBAS_HD_SUBM]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_HBASIC]  WITH CHECK ADD  CONSTRAINT [FK_HD_HBAS_HD_SUBM] FOREIGN KEY([HD_SUBM_ID])
REFERENCES [dbo].[RCRA_HD_SUBM] ([HD_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_HBASIC] CHECK CONSTRAINT [FK_HD_HBAS_HD_SUBM]
GO
/****** Object:  ForeignKey [FK_PRM_FC_SB_PR_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_FAC_SUBM]  WITH CHECK ADD  CONSTRAINT [FK_PRM_FC_SB_PR_SB] FOREIGN KEY([PRM_SUBM_ID])
REFERENCES [dbo].[RCRA_PRM_SUBM] ([PRM_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_FAC_SUBM] CHECK CONSTRAINT [FK_PRM_FC_SB_PR_SB]
GO
/****** Object:  ForeignKey [FK_PRM_SR_PR_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_SERIES]  WITH CHECK ADD  CONSTRAINT [FK_PRM_SR_PR_FC_SB] FOREIGN KEY([PRM_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_PRM_FAC_SUBM] ([PRM_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_SERIES] CHECK CONSTRAINT [FK_PRM_SR_PR_FC_SB]
GO
/****** Object:  ForeignKey [FK_PRM_UN_PR_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_UNIT]  WITH CHECK ADD  CONSTRAINT [FK_PRM_UN_PR_FC_SB] FOREIGN KEY([PRM_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_PRM_FAC_SUBM] ([PRM_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_UNIT] CHECK CONSTRAINT [FK_PRM_UN_PR_FC_SB]
GO
/****** Object:  ForeignKey [FK_GS_GO_IN_GS_FC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_GIS_GEO_INFORMATION]  WITH CHECK ADD  CONSTRAINT [FK_GS_GO_IN_GS_FC] FOREIGN KEY([GIS_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_GIS_FAC_SUBM] ([GIS_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_GIS_GEO_INFORMATION] CHECK CONSTRAINT [FK_GS_GO_IN_GS_FC]
GO
/****** Object:  ForeignKey [FK_HD_OTH_ID_HD_HB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_OTHER_ID]  WITH CHECK ADD  CONSTRAINT [FK_HD_OTH_ID_HD_HB] FOREIGN KEY([HD_HBASIC_ID])
REFERENCES [dbo].[RCRA_HD_HBASIC] ([HD_HBASIC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_OTHER_ID] CHECK CONSTRAINT [FK_HD_OTH_ID_HD_HB]
GO
/****** Object:  ForeignKey [FK_HD_HAND_HD_HBAS]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_HANDLER]  WITH CHECK ADD  CONSTRAINT [FK_HD_HAND_HD_HBAS] FOREIGN KEY([HD_HBASIC_ID])
REFERENCES [dbo].[RCRA_HD_HBASIC] ([HD_HBASIC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_HANDLER] CHECK CONSTRAINT [FK_HD_HAND_HD_HBAS]
GO
/****** Object:  ForeignKey [FK_CA_ARA_CA_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_AREA]  WITH CHECK ADD  CONSTRAINT [FK_CA_ARA_CA_FC_SB] FOREIGN KEY([CA_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CA_FAC_SUBM] ([CA_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_AREA] CHECK CONSTRAINT [FK_CA_ARA_CA_FC_SB]
GO
/****** Object:  ForeignKey [FK_CME_VL_CM_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_VIOL]  WITH CHECK ADD  CONSTRAINT [FK_CME_VL_CM_FC_SB] FOREIGN KEY([CME_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_FAC_SUBM] ([CME_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_VIOL] CHECK CONSTRAINT [FK_CME_VL_CM_FC_SB]
GO
/****** Object:  ForeignKey [FK_FA_MCH_FA_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_FA_MECHANISM]  WITH CHECK ADD  CONSTRAINT [FK_FA_MCH_FA_FC_SB] FOREIGN KEY([FA_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_FA_FAC_SUBM] ([FA_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_FA_MECHANISM] CHECK CONSTRAINT [FK_FA_MCH_FA_FC_SB]
GO
/****** Object:  ForeignKey [FK_FA_CS_ES_FA_FC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_FA_COST_EST]  WITH CHECK ADD  CONSTRAINT [FK_FA_CS_ES_FA_FC] FOREIGN KEY([FA_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_FA_FAC_SUBM] ([FA_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_FA_COST_EST] CHECK CONSTRAINT [FK_FA_CS_ES_FA_FC]
GO
/****** Object:  ForeignKey [FK_CA_EVN_CA_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_CA_EVN_CA_FC_SB] FOREIGN KEY([CA_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CA_FAC_SUBM] ([CA_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_EVENT] CHECK CONSTRAINT [FK_CA_EVN_CA_FC_SB]
GO
/****** Object:  ForeignKey [FK_CA_ATH_CA_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_AUTHORITY]  WITH CHECK ADD  CONSTRAINT [FK_CA_ATH_CA_FC_SB] FOREIGN KEY([CA_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CA_FAC_SUBM] ([CA_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_AUTHORITY] CHECK CONSTRAINT [FK_CA_ATH_CA_FC_SB]
GO
/****** Object:  ForeignKey [FK_CME_EV_CM_FC_SB]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_EVAL]  WITH CHECK ADD  CONSTRAINT [FK_CME_EV_CM_FC_SB] FOREIGN KEY([CME_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_FAC_SUBM] ([CME_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_EVAL] CHECK CONSTRAINT [FK_CME_EV_CM_FC_SB]
GO
/****** Object:  ForeignKey [FK_CM_EN_AC_CM_FC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_ENFRC_ACT]  WITH CHECK ADD  CONSTRAINT [FK_CM_EN_AC_CM_FC] FOREIGN KEY([CME_FAC_SUBM_ID])
REFERENCES [dbo].[RCRA_CME_FAC_SUBM] ([CME_FAC_SUBM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_ENFRC_ACT] CHECK CONSTRAINT [FK_CM_EN_AC_CM_FC]
GO
/****** Object:  ForeignKey [FK_CM_CS_DT_CM_EN]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_CSNY_DATE]  WITH CHECK ADD  CONSTRAINT [FK_CM_CS_DT_CM_EN] FOREIGN KEY([CME_ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([CME_ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_CSNY_DATE] CHECK CONSTRAINT [FK_CM_CS_DT_CM_EN]
GO
/****** Object:  ForeignKey [FK_CME_CTTN_CME_VL]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_CITATION]  WITH CHECK ADD  CONSTRAINT [FK_CME_CTTN_CME_VL] FOREIGN KEY([CME_VIOL_ID])
REFERENCES [dbo].[RCRA_CME_VIOL] ([CME_VIOL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_CITATION] CHECK CONSTRAINT [FK_CME_CTTN_CME_VL]
GO
/****** Object:  ForeignKey [FK_CA_EVN_CM_CA_EV]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_EVENT_COMMITMENT]  WITH CHECK ADD  CONSTRAINT [FK_CA_EVN_CM_CA_EV] FOREIGN KEY([CA_EVENT_ID])
REFERENCES [dbo].[RCRA_CA_EVENT] ([CA_EVENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_EVENT_COMMITMENT] CHECK CONSTRAINT [FK_CA_EVN_CM_CA_EV]
GO
/****** Object:  ForeignKey [FK_CA_AT_RL_EV_CA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_AUTH_REL_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_CA_AT_RL_EV_CA] FOREIGN KEY([CA_AUTHORITY_ID])
REFERENCES [dbo].[RCRA_CA_AUTHORITY] ([CA_AUTHORITY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_AUTH_REL_EVENT] CHECK CONSTRAINT [FK_CA_AT_RL_EV_CA]
GO
/****** Object:  ForeignKey [FK_CA_AR_RL_EV_CA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_AREA_REL_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_CA_AR_RL_EV_CA] FOREIGN KEY([CA_AREA_ID])
REFERENCES [dbo].[RCRA_CA_AREA] ([CA_AREA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_AREA_REL_EVENT] CHECK CONSTRAINT [FK_CA_AR_RL_EV_CA]
GO
/****** Object:  ForeignKey [FK_CME_EV_VL_CM_EV]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_EVAL_VIOL]  WITH CHECK ADD  CONSTRAINT [FK_CME_EV_VL_CM_EV] FOREIGN KEY([CME_EVAL_ID])
REFERENCES [dbo].[RCRA_CME_EVAL] ([CME_EVAL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_EVAL_VIOL] CHECK CONSTRAINT [FK_CME_EV_VL_CM_EV]
GO
/****** Object:  ForeignKey [FK_CME_EV_CM_CM_EV]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_EVAL_COMMIT]  WITH CHECK ADD  CONSTRAINT [FK_CME_EV_CM_CM_EV] FOREIGN KEY([CME_EVAL_ID])
REFERENCES [dbo].[RCRA_CME_EVAL] ([CME_EVAL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_EVAL_COMMIT] CHECK CONSTRAINT [FK_CME_EV_CM_CM_EV]
GO
/****** Object:  ForeignKey [FK_CA_STT_CT_CA_AT]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_STATUTORY_CITATION]  WITH CHECK ADD  CONSTRAINT [FK_CA_STT_CT_CA_AT] FOREIGN KEY([CA_AUTHORITY_ID])
REFERENCES [dbo].[RCRA_CA_AUTHORITY] ([CA_AUTHORITY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_STATUTORY_CITATION] CHECK CONSTRAINT [FK_CA_STT_CT_CA_AT]
GO
/****** Object:  ForeignKey [FK_CA_RL_PR_UN_CA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CA_REL_PERMIT_UNIT]  WITH CHECK ADD  CONSTRAINT [FK_CA_RL_PR_UN_CA] FOREIGN KEY([CA_AREA_ID])
REFERENCES [dbo].[RCRA_CA_AREA] ([CA_AREA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CA_REL_PERMIT_UNIT] CHECK CONSTRAINT [FK_CA_RL_PR_UN_CA]
GO
/****** Object:  ForeignKey [FK_CME_PN_CM_EN_AC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_PNLTY]  WITH CHECK ADD  CONSTRAINT [FK_CME_PN_CM_EN_AC] FOREIGN KEY([CME_ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([CME_ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_PNLTY] CHECK CONSTRAINT [FK_CME_PN_CM_EN_AC]
GO
/****** Object:  ForeignKey [FK_CME_ML_CM_EN_AC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_MILESTONE]  WITH CHECK ADD  CONSTRAINT [FK_CME_ML_CM_EN_AC] FOREIGN KEY([CME_ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([CME_ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_MILESTONE] CHECK CONSTRAINT [FK_CME_ML_CM_EN_AC]
GO
/****** Object:  ForeignKey [FK_CME_MD_CM_EN_AC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_MEDIA]  WITH CHECK ADD  CONSTRAINT [FK_CME_MD_CM_EN_AC] FOREIGN KEY([CME_ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([CME_ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_MEDIA] CHECK CONSTRAINT [FK_CME_MD_CM_EN_AC]
GO
/****** Object:  ForeignKey [FK_CME_RQS_CME_EVL]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_RQST]  WITH CHECK ADD  CONSTRAINT [FK_CME_RQS_CME_EVL] FOREIGN KEY([CME_EVAL_ID])
REFERENCES [dbo].[RCRA_CME_EVAL] ([CME_EVAL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_RQST] CHECK CONSTRAINT [FK_CME_RQS_CME_EVL]
GO
/****** Object:  ForeignKey [FK_FA_MCH_DT_FA_MC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_FA_MECHANISM_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_FA_MCH_DT_FA_MC] FOREIGN KEY([FA_MECHANISM_ID])
REFERENCES [dbo].[RCRA_FA_MECHANISM] ([FA_MECHANISM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_FA_MECHANISM_DETAIL] CHECK CONSTRAINT [FK_FA_MCH_DT_FA_MC]
GO
/****** Object:  ForeignKey [FK_CM_VL_EN_CM_EN]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_VIOL_ENFRC]  WITH CHECK ADD  CONSTRAINT [FK_CM_VL_EN_CM_EN] FOREIGN KEY([CME_ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([CME_ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_VIOL_ENFRC] CHECK CONSTRAINT [FK_CM_VL_EN_CM_EN]
GO
/****** Object:  ForeignKey [FK_FA_CS_ES_RL_MC]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_FA_COST_EST_REL_MECHANISM]  WITH CHECK ADD  CONSTRAINT [FK_FA_CS_ES_RL_MC] FOREIGN KEY([FA_COST_EST_ID])
REFERENCES [dbo].[RCRA_FA_COST_EST] ([FA_COST_EST_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_FA_COST_EST_REL_MECHANISM] CHECK CONSTRAINT [FK_FA_CS_ES_RL_MC]
GO
/****** Object:  ForeignKey [FK_CM_SP_EN_PR_CM]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_SUPP_ENVR_PRJT]  WITH CHECK ADD  CONSTRAINT [FK_CM_SP_EN_PR_CM] FOREIGN KEY([CME_ENFRC_ACT_ID])
REFERENCES [dbo].[RCRA_CME_ENFRC_ACT] ([CME_ENFRC_ACT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_SUPP_ENVR_PRJT] CHECK CONSTRAINT [FK_CM_SP_EN_PR_CM]
GO
/****** Object:  ForeignKey [FK_HD_ENV_PE_HD_HA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_ENV_PERMIT]  WITH CHECK ADD  CONSTRAINT [FK_HD_ENV_PE_HD_HA] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_ENV_PERMIT] CHECK CONSTRAINT [FK_HD_ENV_PE_HD_HA]
GO
/****** Object:  ForeignKey [FK_HD_CERT_HD_HAND]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_CERTIFICATION]  WITH CHECK ADD  CONSTRAINT [FK_HD_CERT_HD_HAND] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_CERTIFICATION] CHECK CONSTRAINT [FK_HD_CERT_HD_HAND]
GO
/****** Object:  ForeignKey [FK_HD_NAIC_HD_HAND]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_NAICS]  WITH CHECK ADD  CONSTRAINT [FK_HD_NAIC_HD_HAND] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_NAICS] CHECK CONSTRAINT [FK_HD_NAIC_HD_HAND]
GO
/****** Object:  ForeignKey [FK_HD_STA_AC_HD_HA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_STATE_ACTIVITY]  WITH CHECK ADD  CONSTRAINT [FK_HD_STA_AC_HD_HA] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_STATE_ACTIVITY] CHECK CONSTRAINT [FK_HD_STA_AC_HD_HA]
GO
/****** Object:  ForeignKey [FK_PRM_EVN_PRM_SRS]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_PRM_EVN_PRM_SRS] FOREIGN KEY([PRM_SERIES_ID])
REFERENCES [dbo].[RCRA_PRM_SERIES] ([PRM_SERIES_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_EVENT] CHECK CONSTRAINT [FK_PRM_EVN_PRM_SRS]
GO
/****** Object:  ForeignKey [FK_HD_WAS_CO_HD_HA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_WASTE_CODE]  WITH CHECK ADD  CONSTRAINT [FK_HD_WAS_CO_HD_HA] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_WASTE_CODE] CHECK CONSTRAINT [FK_HD_WAS_CO_HD_HA]
GO
/****** Object:  ForeignKey [FK_HD_UNI_WA_HD_HA]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_UNIVERSAL_WASTE]  WITH CHECK ADD  CONSTRAINT [FK_HD_UNI_WA_HD_HA] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_UNIVERSAL_WASTE] CHECK CONSTRAINT [FK_HD_UNI_WA_HD_HA]
GO
/****** Object:  ForeignKey [FK_HD_SE_MA_AC_HD]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_SEC_MATERIAL_ACTIVITY]  WITH CHECK ADD  CONSTRAINT [FK_HD_SE_MA_AC_HD] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_SEC_MATERIAL_ACTIVITY] CHECK CONSTRAINT [FK_HD_SE_MA_AC_HD]
GO
/****** Object:  ForeignKey [FK_HD_OWNE_HD_HAND]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_OWNEROP]  WITH CHECK ADD  CONSTRAINT [FK_HD_OWNE_HD_HAND] FOREIGN KEY([HD_HANDLER_ID])
REFERENCES [dbo].[RCRA_HD_HANDLER] ([HD_HANDLER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_OWNEROP] CHECK CONSTRAINT [FK_HD_OWNE_HD_HAND]
GO
/****** Object:  ForeignKey [FK_PRM_UN_DT_PR_UN]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_UNIT_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_PRM_UN_DT_PR_UN] FOREIGN KEY([PRM_UNIT_ID])
REFERENCES [dbo].[RCRA_PRM_UNIT] ([PRM_UNIT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_UNIT_DETAIL] CHECK CONSTRAINT [FK_PRM_UN_DT_PR_UN]
GO
/****** Object:  ForeignKey [FK_PR_WS_CD_PR_UN]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_WASTE_CODE]  WITH CHECK ADD  CONSTRAINT [FK_PR_WS_CD_PR_UN] FOREIGN KEY([PRM_UNIT_DETAIL_ID])
REFERENCES [dbo].[RCRA_PRM_UNIT_DETAIL] ([PRM_UNIT_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_WASTE_CODE] CHECK CONSTRAINT [FK_PR_WS_CD_PR_UN]
GO
/****** Object:  ForeignKey [FK_PR_RL_EV_PR_UN]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_RELATED_EVENT]  WITH CHECK ADD  CONSTRAINT [FK_PR_RL_EV_PR_UN] FOREIGN KEY([PRM_UNIT_DETAIL_ID])
REFERENCES [dbo].[RCRA_PRM_UNIT_DETAIL] ([PRM_UNIT_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_RELATED_EVENT] CHECK CONSTRAINT [FK_PR_RL_EV_PR_UN]
GO
/****** Object:  ForeignKey [FK_PRM_EV_CM_PR_EV]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_PRM_EVENT_COMMITMENT]  WITH CHECK ADD  CONSTRAINT [FK_PRM_EV_CM_PR_EV] FOREIGN KEY([PRM_EVENT_ID])
REFERENCES [dbo].[RCRA_PRM_EVENT] ([PRM_EVENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_PRM_EVENT_COMMITMENT] CHECK CONSTRAINT [FK_PRM_EV_CM_PR_EV]
GO
/****** Object:  ForeignKey [FK_HD_SE_WA_CO_HD]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_HD_SEC_WASTE_CODE]  WITH CHECK ADD  CONSTRAINT [FK_HD_SE_WA_CO_HD] FOREIGN KEY([HD_SEC_MATERIAL_ACTIVITY_ID])
REFERENCES [dbo].[RCRA_HD_SEC_MATERIAL_ACTIVITY] ([HD_SEC_MATERIAL_ACTIVITY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_HD_SEC_WASTE_CODE] CHECK CONSTRAINT [FK_HD_SE_WA_CO_HD]
GO
/****** Object:  ForeignKey [FK_CME_PYM_CME_PNL]    Script Date: 10/06/2010 21:15:36 ******/
ALTER TABLE [dbo].[RCRA_CME_PYMT]  WITH CHECK ADD  CONSTRAINT [FK_CME_PYM_CME_PNL] FOREIGN KEY([CME_PNLTY_ID])
REFERENCES [dbo].[RCRA_CME_PNLTY] ([CME_PNLTY_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RCRA_CME_PYMT] CHECK CONSTRAINT [FK_CME_PYM_CME_PNL]
GO
