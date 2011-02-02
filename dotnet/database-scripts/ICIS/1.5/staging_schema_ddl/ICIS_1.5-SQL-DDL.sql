/****** Object:  Table [dbo].[ICIS_DOCUMENT]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_DOCUMENT](
	[DOCUMENT_ID] [varchar](40) NOT NULL,
	[ID] [varchar](30) NOT NULL,
	[AUTHOR] [varchar](255) NULL,
	[ORG] [varchar](255) NULL,
	[TITLE] [varchar](255) NULL,
	[CRTN_TIME] [datetime] NULL,
	[CMNT] [varchar](255) NULL,
	[DATA_SERVICE] [varchar](255) NULL,
	[CONTACT_INFO] [varchar](255) NULL,
 CONSTRAINT [PK_ICIS_DOCUMENT] PRIMARY KEY CLUSTERED 
(
	[DOCUMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_DOCUMENT_ID] ON [ICIS_DOCUMENT] 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: Document' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_DOCUMENT'
GO
/****** Object:  Table [dbo].[ICIS_SUBM_HISTORY]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_SUBM_HISTORY](
	[SUBM_HISTORY_ID] [varchar](40) NOT NULL,
	[USER_ID] [varchar](30) NOT NULL,
	[SUBMIT_DATE] [datetime] NOT NULL,
	[LAST_PAYLOAD_UPDATE_DATE] [datetime] NOT NULL,
	[LOCAL_TRANS_ID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SUBM_HISTORY] PRIMARY KEY CLUSTERED 
(
	[SUBM_HISTORY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_SBM_HSTR_USR_ID] ON [ICIS_SUBM_HISTORY] 
(
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ICIS username of the user submitting the XML document (UserId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_SUBM_HISTORY', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time that the payload was submitted to the remote network node. (SubmitDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_SUBM_HISTORY', @level2type=N'COLUMN',@level2name=N'SUBMIT_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time used to pull data from the staging table (payload data older than this date was pulled). (LastPayloadUpdateDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_SUBM_HISTORY', @level2type=N'COLUMN',@level2name=N'LAST_PAYLOAD_UPDATE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The transaction id for the submitted data on the local node. (LocalTransactionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_SUBM_HISTORY', @level2type=N'COLUMN',@level2name=N'LOCAL_TRANS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SubmissionHistoryDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_SUBM_HISTORY'
GO
/****** Object:  Table [dbo].[ICIS_HEADER_PROPERTY]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_HEADER_PROPERTY](
	[HEADER_PROPERTY_ID] [varchar](40) NOT NULL,
	[DOCUMENT_ID] [varchar](40) NOT NULL,
	[NAME] [varchar](6) NOT NULL,
	[VAL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_HEADER_PROPERTY] PRIMARY KEY CLUSTERED 
(
	[HEADER_PROPERTY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_HDR_PRPR_DCM_ID] ON [ICIS_HEADER_PROPERTY] 
(
	[DOCUMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: Property' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_HEADER_PROPERTY'
GO
/****** Object:  Table [dbo].[ICIS_PAYLOAD_DATA]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_PAYLOAD_DATA](
	[PAYLOAD_DATA_ID] [varchar](40) NOT NULL,
	[DOCUMENT_ID] [varchar](40) NOT NULL,
	[LAST_PAYLOAD_UPDATE_DATE] [datetime] NULL,
	[USER_ID] [varchar](30) NULL,
	[OPER] [varchar](40) NULL,
 CONSTRAINT [PK_PAYLOAD_DATA] PRIMARY KEY CLUSTERED 
(
	[PAYLOAD_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_PY_DT_LS_PY_UP] ON [ICIS_PAYLOAD_DATA] 
(
	[LAST_PAYLOAD_UPDATE_DATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PYLD_DTA_DCM_ID] ON [ICIS_PAYLOAD_DATA] 
(
	[DOCUMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PYLD_DTA_USR_ID] ON [ICIS_PAYLOAD_DATA] 
(
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time that this payload was last updated for submission. (LastPayloadUpdateDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_PAYLOAD_DATA', @level2type=N'COLUMN',@level2name=N'LAST_PAYLOAD_UPDATE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ICIS username of the user submitting the XML document (UserId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_PAYLOAD_DATA', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: Payload' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_PAYLOAD_DATA'
GO
/****** Object:  Table [dbo].[ICIS_DISCHRG_MONTR_RPT_DATA]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_DISCHRG_MONTR_RPT_DATA](
	[DISCHRG_MONTR_RPT_DATA_ID] [varchar](40) NOT NULL,
	[PAYLOAD_DATA_ID] [varchar](40) NOT NULL,
	[TRANS_TYPE] [char](1) NULL,
	[TRANS_TIMESTAMP] [datetime] NULL,
	[SIGNATURE_DATE] [datetime] NULL,
	[PRINCPL_EXCUTVE_OFFCR_FRST_NME] [varchar](30) NULL,
	[PRINCIPL_EXCUTVE_OFFCR_LST_NME] [varchar](30) NULL,
	[PRINCIPAL_EXCUTIVE_OFFICR_TTLE] [varchar](40) NULL,
	[PRINCIPAL_EXECUTIVE_OFFICR_TLE] [varchar](10) NULL,
	[SIGNATORY_FIRST_NAME] [varchar](30) NULL,
	[SIGNATORY_LAST_NAME] [varchar](30) NULL,
	[SIGNATORY_TELE] [varchar](10) NULL,
	[RPT_CMNT_TXT] [varchar](255) NULL,
	[DMR_NO_DISCHRG_IND] [varchar](50) NULL,
	[DMR_NO_DISCHRG_RCVD_DATE] [datetime] NULL,
	[PERM_FEATURE_IDEN] [varchar](4) NULL,
	[LIMIT_SET_DESIGNATOR] [char](2) NULL,
	[MONTR_PRD_END_DATE] [datetime] NOT NULL,
	[PERMIT_IDEN] [varchar](9) NULL,
	[POLT_MET_FOR_LAND_APPLICATION] [varchar](10) NULL,
	[PATHOGEN_REDC_IND] [char](1) NULL,
	[VECTOR_REDC_IND] [char](1) NULL,
	[AGRONOMIC_GALLONS_RATE_FR_FILD] [varchar](5) NULL,
	[AGRONOMIC_DMT_RATE_FOR_FIELD] [varchar](5) NULL,
	[CLASS_A_ALT_USED] [varchar](3) NULL,
	[CLASS_A_ALTERNATIVES_TXT] [varchar](255) NULL,
	[CLASS_B_ALT_USED] [varchar](3) NULL,
	[CLASS_B_ALTERNATIVES_TXT] [varchar](255) NULL,
	[VAR_ALT_USED] [varchar](3) NULL,
	[VAR_ALTERNATIVES_TXT] [varchar](255) NULL,
	[SRFCE_DSPOSL_STE_PTHGN_RDC_IND] [char](1) NULL,
	[SURFCE_DSPOSL_STE_VCTR_RDC_IND] [char](1) NULL,
	[MANAGEMENT_PRACTICES_IND] [char](1) NULL,
	[CERTIFICATION_STATEMENT_IND] [char](1) NULL,
	[CERTIFIER_FIRST_NAME] [char](1) NULL,
	[CERTIFIER_LAST_NAME] [char](1) NULL,
	[SRFCE_DSPSL_STE_CLSS_A_ALT_USD] [varchar](3) NULL,
	[SRFCE_DSPS_STE_CLSS_A_ALTR_TXT] [varchar](255) NULL,
	[SRFCE_DSPSL_STE_CLSS_B_ALT_USD] [varchar](3) NULL,
	[SRFCE_DSPS_STE_CLSS_B_ALTR_TXT] [varchar](255) NULL,
	[SURFACE_DISPOSL_STE_VR_ALT_USD] [varchar](3) NULL,
	[SRFCE_DSPSL_STE_VR_ALTRNTV_TXT] [varchar](255) NULL,
	[BERYLLIUM_COMPL_IND] [varchar](50) NULL,
	[MERCURY_COMPL_IND] [varchar](50) NULL,
	[PART_258_COMPL_IND] [varchar](50) NULL,
	[PAINT_FILTER_TST_RSLT] [varchar](4) NULL,
	[TCLP_TST_RSLT] [varchar](4) NULL,
 CONSTRAINT [PK_DSC_MNT_RPT_DTA] PRIMARY KEY CLUSTERED 
(
	[DISCHRG_MONTR_RPT_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_DS_MN_RP_DT_PY] ON [ICIS_DISCHRG_MONTR_RPT_DATA] 
(
	[PAYLOAD_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: DischargeMonitoringReportData' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_DISCHRG_MONTR_RPT_DATA'
GO
/****** Object:  Table [dbo].[ICIS_CROP_TYPES_PLANTED]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_CROP_TYPES_PLANTED](
	[CROP_TYPES_PLANTED_ID] [varchar](40) NOT NULL,
	[DISCHRG_MONTR_RPT_DATA_ID] [varchar](40) NOT NULL,
	[TXT] [varchar](3) NOT NULL,
 CONSTRAINT [PK_CRP_TYPS_PLNTED] PRIMARY KEY CLUSTERED 
(
	[CROP_TYPES_PLANTED_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CR_TY_PL_DS_MN] ON [ICIS_CROP_TYPES_PLANTED] 
(
	[DISCHRG_MONTR_RPT_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CropTypesPlantedDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_CROP_TYPES_PLANTED'
GO
/****** Object:  Table [dbo].[ICIS_CROP_TYPES_HARVESTED]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_CROP_TYPES_HARVESTED](
	[CROP_TYPES_HARVESTED_ID] [varchar](40) NOT NULL,
	[DISCHRG_MONTR_RPT_DATA_ID] [varchar](40) NOT NULL,
	[TXT] [varchar](3) NOT NULL,
 CONSTRAINT [PK_CRP_TYPS_HRVSTD] PRIMARY KEY CLUSTERED 
(
	[CROP_TYPES_HARVESTED_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_CR_TY_HR_DS_MN] ON [ICIS_CROP_TYPES_HARVESTED] 
(
	[DISCHRG_MONTR_RPT_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CropTypesHarvestedDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_CROP_TYPES_HARVESTED'
GO
/****** Object:  Table [dbo].[ICIS_RPT_PARM]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_RPT_PARM](
	[RPT_PARM_ID] [varchar](40) NOT NULL,
	[DISCHRG_MONTR_RPT_DATA_ID] [varchar](40) NOT NULL,
	[RPT_SAMPLE_TYPE_TXT] [varchar](3) NULL,
	[RPT_FREQUENCY_CODE] [varchar](5) NULL,
	[RPT_NUM_OF_EXCURSIONS] [varchar](3) NULL,
	[CONCENTRTION_NM_RPT_UNT_MS_CDE] [char](2) NULL,
	[QNTY_NUM_RPT_UNIT_MEAS_CODE] [char](2) NULL,
	[PARM_CODE] [varchar](5) NOT NULL,
	[MONTR_SITE_DESC_CODE] [varchar](3) NOT NULL,
	[LIMIT_SEASON_NUM] [char](2) NOT NULL,
 CONSTRAINT [PK_RPT_PARM] PRIMARY KEY CLUSTERED 
(
	[RPT_PARM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_RP_PR_DS_MN_RP] ON [ICIS_RPT_PARM] 
(
	[DISCHRG_MONTR_RPT_DATA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ReportParameter' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_RPT_PARM'
GO
/****** Object:  Table [dbo].[ICIS_NUMERIC_REPORT]    Script Date: 01/14/2011 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ICIS_NUMERIC_REPORT](
	[NUMERIC_REPORT_ID] [varchar](40) NOT NULL,
	[RPT_PARM_ID] [varchar](40) NOT NULL,
	[NUM_RPT_CODE] [char](2) NOT NULL,
	[NUM_RPT_RCVD_DATE] [datetime] NULL,
	[NUM_RPT_NO_DISCHRG_IND] [varchar](3) NULL,
	[NUM_CONDITION_QNTY] [varchar](255) NULL,
	[NUM_CONDITION_ADJUSTED_QNTY] [varchar](255) NULL,
	[NUM_CONDITION_QUAL] [varchar](3) NULL,
 CONSTRAINT [PK_NUMERIC_REPORT] PRIMARY KEY CLUSTERED 
(
	[NUMERIC_REPORT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_NMR_RP_RP_PR_ID] ON [ICIS_NUMERIC_REPORT] 
(
	[RPT_PARM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: NumericReport' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ICIS_NUMERIC_REPORT'
GO
/****** Object:  ForeignKey [FK_CR_TY_HR_DS_MN]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_CROP_TYPES_HARVESTED]  WITH CHECK ADD  CONSTRAINT [FK_CR_TY_HR_DS_MN] FOREIGN KEY([DISCHRG_MONTR_RPT_DATA_ID])
REFERENCES [ICIS_DISCHRG_MONTR_RPT_DATA] ([DISCHRG_MONTR_RPT_DATA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_CROP_TYPES_HARVESTED] CHECK CONSTRAINT [FK_CR_TY_HR_DS_MN]
GO
/****** Object:  ForeignKey [FK_CR_TY_PL_DS_MN]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_CROP_TYPES_PLANTED]  WITH CHECK ADD  CONSTRAINT [FK_CR_TY_PL_DS_MN] FOREIGN KEY([DISCHRG_MONTR_RPT_DATA_ID])
REFERENCES [ICIS_DISCHRG_MONTR_RPT_DATA] ([DISCHRG_MONTR_RPT_DATA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_CROP_TYPES_PLANTED] CHECK CONSTRAINT [FK_CR_TY_PL_DS_MN]
GO
/****** Object:  ForeignKey [FK_DS_MN_RP_DT_PY]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_DISCHRG_MONTR_RPT_DATA]  WITH CHECK ADD  CONSTRAINT [FK_DS_MN_RP_DT_PY] FOREIGN KEY([PAYLOAD_DATA_ID])
REFERENCES [ICIS_PAYLOAD_DATA] ([PAYLOAD_DATA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_DISCHRG_MONTR_RPT_DATA] CHECK CONSTRAINT [FK_DS_MN_RP_DT_PY]
GO
/****** Object:  ForeignKey [FK_HDR_PRPRT_DCMNT]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_HEADER_PROPERTY]  WITH CHECK ADD  CONSTRAINT [FK_HDR_PRPRT_DCMNT] FOREIGN KEY([DOCUMENT_ID])
REFERENCES [ICIS_DOCUMENT] ([DOCUMENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_HEADER_PROPERTY] CHECK CONSTRAINT [FK_HDR_PRPRT_DCMNT]
GO
/****** Object:  ForeignKey [FK_NMR_RPR_RPT_PRM]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_NUMERIC_REPORT]  WITH CHECK ADD  CONSTRAINT [FK_NMR_RPR_RPT_PRM] FOREIGN KEY([RPT_PARM_ID])
REFERENCES [ICIS_RPT_PARM] ([RPT_PARM_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_NUMERIC_REPORT] CHECK CONSTRAINT [FK_NMR_RPR_RPT_PRM]
GO
/****** Object:  ForeignKey [FK_PYLOD_DTA_DCMNT]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_PAYLOAD_DATA]  WITH CHECK ADD  CONSTRAINT [FK_PYLOD_DTA_DCMNT] FOREIGN KEY([DOCUMENT_ID])
REFERENCES [ICIS_DOCUMENT] ([DOCUMENT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_PAYLOAD_DATA] CHECK CONSTRAINT [FK_PYLOD_DTA_DCMNT]
GO
/****** Object:  ForeignKey [FK_RP_PR_DS_MN_RP]    Script Date: 01/14/2011 16:53:37 ******/
ALTER TABLE [ICIS_RPT_PARM]  WITH CHECK ADD  CONSTRAINT [FK_RP_PR_DS_MN_RP] FOREIGN KEY([DISCHRG_MONTR_RPT_DATA_ID])
REFERENCES [ICIS_DISCHRG_MONTR_RPT_DATA] ([DISCHRG_MONTR_RPT_DATA_ID])
ON DELETE CASCADE
GO
ALTER TABLE [ICIS_RPT_PARM] CHECK CONSTRAINT [FK_RP_PR_DS_MN_RP]
GO
