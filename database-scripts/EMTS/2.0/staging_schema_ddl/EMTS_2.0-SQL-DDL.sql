/****** Object:  Database [NODE_FLOW_EMTS_20]    Script Date: 11/8/2011 4:36:33 PM ******/
/****** Object:  Table [dbo].[EMTS_BUY_PUB_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_BUY_PUB_SUPRT_DOC_DETAIL](
	[BUY_PUB_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[BUY_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_BUY_PUB_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[BUY_PUB_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_BUY_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_BUY_SUPRT_DOC_DETAIL](
	[BUY_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[BUY_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_BUY_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[BUY_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_BUY_TRANS_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_BUY_TRANS_DETAIL](
	[BUY_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[EMTS_ID] [varchar](40) NOT NULL,
	[TRANS_PART_ORG_IDEN] [varchar](12) NOT NULL,
	[TRANS_PART_ORG_NAME] [varchar](125) NOT NULL,
	[RIN_QNTY] [int] NOT NULL,
	[BATCH_VOL] [int] NULL,
	[FUEL_CODE] [varchar](4) NOT NULL,
	[ASSIGN_CODE] [int] NOT NULL,
	[RIN_YEAR] [int] NOT NULL,
	[BUY_RSN_CODE] [varchar](4) NOT NULL,
	[RIN_PRICE_AMT] [decimal](5, 2) NULL,
	[GALLON_PRICE_AMT] [decimal](5, 2) NULL,
	[TRANSFER_DATE] [datetime] NOT NULL,
	[PTD_NUM] [varchar](100) NULL,
	[MATCHING_TRANS_IDEN] [varchar](100) NULL,
	[TRANS_DETAIL_CMNT_TXT] [varchar](400) NULL,
	[GENR_ORG_IDEN] [varchar](12) NULL,
	[GENR_FAC_IDEN] [varchar](12) NULL,
	[BATCH_NUM_TXT] [varchar](20) NULL,
 CONSTRAINT [PK_BUY_TRANS_DETAIL] PRIMARY KEY CLUSTERED 
(
	[BUY_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_CO_PROD_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_CO_PROD_DETAIL](
	[CO_PROD_DETAIL_ID] [varchar](40) NOT NULL,
	[GENR_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[CO_PROD_CODE] [varchar](4) NOT NULL,
	[CO_PROD_DETAIL_CMNT_TXT] [varchar](400) NULL,
 CONSTRAINT [PK_CO_PROD_DETAIL] PRIMARY KEY CLUSTERED 
(
	[CO_PROD_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_EMTS]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_EMTS](
	[EMTS_ID] [varchar](40) NOT NULL,
	[USER_LOGIN_TXT] [varchar](100) NOT NULL,
	[SUBM_CRTN_DATE] [datetime] NOT NULL,
	[ORG_IDEN] [varchar](12) NOT NULL,
	[SUBM_CMNT_TXT] [varchar](400) NULL,
 CONSTRAINT [PK_EMTS] PRIMARY KEY CLUSTERED 
(
	[EMTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_FDSTK_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_FDSTK_DETAIL](
	[FDSTK_DETAIL_ID] [varchar](40) NOT NULL,
	[GENR_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[FDSTK_CODE] [varchar](4) NOT NULL,
	[RENEW_BIOMASS_IND] [char](1) NOT NULL,
	[FDSTK_QNTY] [decimal](10, 1) NOT NULL,
	[FDSTK_MEAS_CODE] [varchar](3) NOT NULL,
	[FDSTK_DETAIL_CMNT_TXT] [varchar](400) NULL,
 CONSTRAINT [PK_FDSTK_DETAIL] PRIMARY KEY CLUSTERED 
(
	[FDSTK_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_GENR_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_GENR_SUPRT_DOC_DETAIL](
	[GENR_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[GENR_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_GENR_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[GENR_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_GENR_TRANS_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_GENR_TRANS_DETAIL](
	[GENR_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[EMTS_ID] [varchar](40) NOT NULL,
	[RIN_QNTY] [int] NOT NULL,
	[BATCH_VOL] [int] NULL,
	[FUEL_CODE] [varchar](4) NOT NULL,
	[FUEL_CATG_CODE] [varchar](4) NOT NULL,
	[PROD_DATE] [datetime] NOT NULL,
	[PROC_CODE] [varchar](4) NOT NULL,
	[DENATURANT_VOL] [int] NULL,
	[EQUIVALENCE_VAL] [decimal](2, 1) NULL,
	[IMPORT_FAC_IDEN] [varchar](12) NULL,
	[TRANS_DETAIL_CMNT_TXT] [varchar](400) NULL,
	[GENR_ORG_IDEN] [varchar](12) NULL,
	[GENR_FAC_IDEN] [varchar](12) NULL,
	[BATCH_NUM_TXT] [varchar](20) NULL,
 CONSTRAINT [PK_GENR_TRANS_DETAIL] PRIMARY KEY CLUSTERED 
(
	[GENR_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_RETIRE_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_RETIRE_SUPRT_DOC_DETAIL](
	[RETIRE_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[RETIRE_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_RETIRE_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[RETIRE_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_RETIRE_TRANS_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_RETIRE_TRANS_DETAIL](
	[RETIRE_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[EMTS_ID] [varchar](40) NOT NULL,
	[RIN_QNTY] [int] NOT NULL,
	[BATCH_VOL] [int] NULL,
	[FUEL_CODE] [varchar](4) NOT NULL,
	[ASSIGN_CODE] [int] NOT NULL,
	[RIN_YEAR] [int] NOT NULL,
	[RETIRE_RSN_CODE] [varchar](4) NOT NULL,
	[TRANS_DATE] [datetime] NOT NULL,
	[COMPL_YEAR] [int] NULL,
	[COMPL_LEVEL_CODE] [varchar](3) NULL,
	[COMPL_FAC_IDEN] [varchar](12) NULL,
	[TRANS_DETAIL_CMNT_TXT] [varchar](400) NULL,
	[GENR_ORG_IDEN] [varchar](12) NULL,
	[GENR_FAC_IDEN] [varchar](12) NULL,
	[BATCH_NUM_TXT] [varchar](20) NULL,
 CONSTRAINT [PK_RETIRE_TRANS_DETAIL] PRIMARY KEY CLUSTERED 
(
	[RETIRE_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_SELL_PUB_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_SELL_PUB_SUPRT_DOC_DETAIL](
	[SELL_PUB_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[SELL_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SELL_PUB_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[SELL_PUB_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_SELL_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_SELL_SUPRT_DOC_DETAIL](
	[SELL_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[SELL_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SELL_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[SELL_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_SELL_TRANS_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_SELL_TRANS_DETAIL](
	[SELL_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[EMTS_ID] [varchar](40) NOT NULL,
	[TRANS_PART_ORG_IDEN] [varchar](12) NOT NULL,
	[TRANS_PART_ORG_NAME] [varchar](125) NOT NULL,
	[RIN_QNTY] [int] NOT NULL,
	[BATCH_VOL] [int] NULL,
	[FUEL_CODE] [varchar](4) NOT NULL,
	[ASSIGN_CODE] [int] NOT NULL,
	[RIN_YEAR] [int] NOT NULL,
	[SELL_RSN_CODE] [varchar](4) NOT NULL,
	[RIN_PRICE_AMT] [decimal](5, 2) NULL,
	[GALLON_PRICE_AMT] [decimal](5, 2) NULL,
	[TRANSFER_DATE] [datetime] NOT NULL,
	[PTD_NUM] [varchar](100) NULL,
	[MATCHING_TRANS_IDEN] [varchar](100) NULL,
	[TRANS_DETAIL_CMNT_TXT] [varchar](400) NULL,
	[GENR_ORG_IDEN] [varchar](12) NULL,
	[GENR_FAC_IDEN] [varchar](12) NULL,
	[BATCH_NUM_TXT] [varchar](20) NULL,
 CONSTRAINT [PK_SELL_TRANS_DETAIL] PRIMARY KEY CLUSTERED 
(
	[SELL_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_SEPR_SUPRT_DOC_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_SEPR_SUPRT_DOC_DETAIL](
	[SEPR_SUPRT_DOC_DETAIL_ID] [varchar](40) NOT NULL,
	[SEPR_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[SUPRT_DOC_TXT] [varchar](100) NOT NULL,
	[SUPRT_DOC_NUM_TXT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SEPR_SUPRT_DOC_DETAIL] PRIMARY KEY CLUSTERED 
(
	[SEPR_SUPRT_DOC_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMTS_SEPR_TRANS_DETAIL]    Script Date: 11/8/2011 4:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMTS_SEPR_TRANS_DETAIL](
	[SEPR_TRANS_DETAIL_ID] [varchar](40) NOT NULL,
	[EMTS_ID] [varchar](40) NOT NULL,
	[RIN_QNTY] [int] NOT NULL,
	[BATCH_VOL] [int] NULL,
	[FUEL_CODE] [varchar](4) NOT NULL,
	[RIN_YEAR] [int] NOT NULL,
	[SEPR_RSN_CODE] [varchar](4) NOT NULL,
	[TRANS_DATE] [datetime] NOT NULL,
	[BLENDER_ORG_IDEN] [varchar](12) NULL,
	[BLENDER_ORG_NAME] [varchar](125) NULL,
	[TRANS_DETAIL_CMNT_TXT] [varchar](400) NULL,
	[GENR_ORG_IDEN] [varchar](12) NULL,
	[GENR_FAC_IDEN] [varchar](12) NULL,
	[BATCH_NUM_TXT] [varchar](20) NULL,
 CONSTRAINT [PK_SEPR_TRANS_DETAIL] PRIMARY KEY CLUSTERED 
(
	[SEPR_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BY_PB_SPR_DC_DT_BY_TR_DT_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_BY_PB_SPR_DC_DT_BY_TR_DT_ID] ON [dbo].[EMTS_BUY_PUB_SUPRT_DOC_DETAIL]
(
	[BUY_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BY_SPR_DC_DTL_BY_TRN_DTL_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_BY_SPR_DC_DTL_BY_TRN_DTL_ID] ON [dbo].[EMTS_BUY_SUPRT_DOC_DETAIL]
(
	[BUY_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BUY_TRANS_DETAIL_EMTS_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_BUY_TRANS_DETAIL_EMTS_ID] ON [dbo].[EMTS_BUY_TRANS_DETAIL]
(
	[EMTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CO_PRD_DTIL_GNR_TRNS_DTL_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_CO_PRD_DTIL_GNR_TRNS_DTL_ID] ON [dbo].[EMTS_CO_PROD_DETAIL]
(
	[GENR_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_FDSTK_DTIL_GNR_TRNS_DTIL_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_FDSTK_DTIL_GNR_TRNS_DTIL_ID] ON [dbo].[EMTS_FDSTK_DETAIL]
(
	[GENR_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_GNR_SPR_DC_DTL_GNR_TR_DT_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_GNR_SPR_DC_DTL_GNR_TR_DT_ID] ON [dbo].[EMTS_GENR_SUPRT_DOC_DETAIL]
(
	[GENR_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_GENR_TRANS_DETAIL_EMTS_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_GENR_TRANS_DETAIL_EMTS_ID] ON [dbo].[EMTS_GENR_TRANS_DETAIL]
(
	[EMTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RTR_SPR_DC_DTL_RTR_TR_DT_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_RTR_SPR_DC_DTL_RTR_TR_DT_ID] ON [dbo].[EMTS_RETIRE_SUPRT_DOC_DETAIL]
(
	[RETIRE_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RETIRE_TRANS_DETAIL_EMTS_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_RETIRE_TRANS_DETAIL_EMTS_ID] ON [dbo].[EMTS_RETIRE_TRANS_DETAIL]
(
	[EMTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_SLL_PB_SP_DC_DT_SL_TR_DT_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_SLL_PB_SP_DC_DT_SL_TR_DT_ID] ON [dbo].[EMTS_SELL_PUB_SUPRT_DOC_DETAIL]
(
	[SELL_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_SLL_SPR_DC_DTL_SLL_TR_DT_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_SLL_SPR_DC_DTL_SLL_TR_DT_ID] ON [dbo].[EMTS_SELL_SUPRT_DOC_DETAIL]
(
	[SELL_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_SELL_TRANS_DETAIL_EMTS_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_SELL_TRANS_DETAIL_EMTS_ID] ON [dbo].[EMTS_SELL_TRANS_DETAIL]
(
	[EMTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_SPR_SPR_DC_DTL_SPR_TR_DT_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_SPR_SPR_DC_DTL_SPR_TR_DT_ID] ON [dbo].[EMTS_SEPR_SUPRT_DOC_DETAIL]
(
	[SEPR_TRANS_DETAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_SEPR_TRANS_DETAIL_EMTS_ID]    Script Date: 11/8/2011 4:36:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_SEPR_TRANS_DETAIL_EMTS_ID] ON [dbo].[EMTS_SEPR_TRANS_DETAIL]
(
	[EMTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EMTS_BUY_PUB_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_BY_PB_SPR_DC_DTL_BY_TRN_DTL] FOREIGN KEY([BUY_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_BUY_TRANS_DETAIL] ([BUY_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_BUY_PUB_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_BY_PB_SPR_DC_DTL_BY_TRN_DTL]
GO
ALTER TABLE [dbo].[EMTS_BUY_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_BY_SPRT_DC_DTIL_BY_TRNS_DTL] FOREIGN KEY([BUY_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_BUY_TRANS_DETAIL] ([BUY_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_BUY_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_BY_SPRT_DC_DTIL_BY_TRNS_DTL]
GO
ALTER TABLE [dbo].[EMTS_BUY_TRANS_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_BUY_TRANS_DETAIL_EMTS] FOREIGN KEY([EMTS_ID])
REFERENCES [dbo].[EMTS_EMTS] ([EMTS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_BUY_TRANS_DETAIL] CHECK CONSTRAINT [FK_BUY_TRANS_DETAIL_EMTS]
GO
ALTER TABLE [dbo].[EMTS_CO_PROD_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_CO_PRD_DETIL_GNR_TRNS_DETIL] FOREIGN KEY([GENR_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_GENR_TRANS_DETAIL] ([GENR_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_CO_PROD_DETAIL] CHECK CONSTRAINT [FK_CO_PRD_DETIL_GNR_TRNS_DETIL]
GO
ALTER TABLE [dbo].[EMTS_FDSTK_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_FDSTK_DETAIL_GNR_TRNS_DETIL] FOREIGN KEY([GENR_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_GENR_TRANS_DETAIL] ([GENR_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_FDSTK_DETAIL] CHECK CONSTRAINT [FK_FDSTK_DETAIL_GNR_TRNS_DETIL]
GO
ALTER TABLE [dbo].[EMTS_GENR_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_GNR_SPRT_DC_DTL_GNR_TRN_DTL] FOREIGN KEY([GENR_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_GENR_TRANS_DETAIL] ([GENR_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_GENR_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_GNR_SPRT_DC_DTL_GNR_TRN_DTL]
GO
ALTER TABLE [dbo].[EMTS_GENR_TRANS_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_GENR_TRANS_DETAIL_EMTS] FOREIGN KEY([EMTS_ID])
REFERENCES [dbo].[EMTS_EMTS] ([EMTS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_GENR_TRANS_DETAIL] CHECK CONSTRAINT [FK_GENR_TRANS_DETAIL_EMTS]
GO
ALTER TABLE [dbo].[EMTS_RETIRE_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_RTRE_SPR_DC_DTL_RTR_TRN_DTL] FOREIGN KEY([RETIRE_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_RETIRE_TRANS_DETAIL] ([RETIRE_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_RETIRE_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_RTRE_SPR_DC_DTL_RTR_TRN_DTL]
GO
ALTER TABLE [dbo].[EMTS_RETIRE_TRANS_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_RETIRE_TRANS_DETAIL_EMTS] FOREIGN KEY([EMTS_ID])
REFERENCES [dbo].[EMTS_EMTS] ([EMTS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_RETIRE_TRANS_DETAIL] CHECK CONSTRAINT [FK_RETIRE_TRANS_DETAIL_EMTS]
GO
ALTER TABLE [dbo].[EMTS_SELL_PUB_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_SLL_PB_SPR_DC_DTL_SLL_TR_DT] FOREIGN KEY([SELL_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_SELL_TRANS_DETAIL] ([SELL_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_SELL_PUB_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_SLL_PB_SPR_DC_DTL_SLL_TR_DT]
GO
ALTER TABLE [dbo].[EMTS_SELL_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_SLL_SPRT_DC_DTL_SLL_TRN_DTL] FOREIGN KEY([SELL_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_SELL_TRANS_DETAIL] ([SELL_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_SELL_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_SLL_SPRT_DC_DTL_SLL_TRN_DTL]
GO
ALTER TABLE [dbo].[EMTS_SELL_TRANS_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_SELL_TRANS_DETAIL_EMTS] FOREIGN KEY([EMTS_ID])
REFERENCES [dbo].[EMTS_EMTS] ([EMTS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_SELL_TRANS_DETAIL] CHECK CONSTRAINT [FK_SELL_TRANS_DETAIL_EMTS]
GO
ALTER TABLE [dbo].[EMTS_SEPR_SUPRT_DOC_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_SPR_SPRT_DC_DTL_SPR_TRN_DTL] FOREIGN KEY([SEPR_TRANS_DETAIL_ID])
REFERENCES [dbo].[EMTS_SEPR_TRANS_DETAIL] ([SEPR_TRANS_DETAIL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_SEPR_SUPRT_DOC_DETAIL] CHECK CONSTRAINT [FK_SPR_SPRT_DC_DTL_SPR_TRN_DTL]
GO
ALTER TABLE [dbo].[EMTS_SEPR_TRANS_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_SEPR_TRANS_DETAIL_EMTS] FOREIGN KEY([EMTS_ID])
REFERENCES [dbo].[EMTS_EMTS] ([EMTS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMTS_SEPR_TRANS_DETAIL] CHECK CONSTRAINT [FK_SEPR_TRANS_DETAIL_EMTS]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_PUB_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_PUB_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: BuyPublicSupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_PUB_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: BuySupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This identifies the buyer organization for a sell transaction or the selling organization for the buy transaction using the OrganizationIdentifier designated by OTAQReg. (TransactionPartnerOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_PART_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the organization trading partner. (TransactionPartnerOrganizationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_PART_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of RINs specified in the transaction. (RINQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_VOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'FUEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'ASSIGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The RINYear is the year in which the fuel is produced. (RINYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This code identifies the reason for a buy transaction. (BuyReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BUY_RSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Price paid per RIN. (RINPriceAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_PRICE_AMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Price paid per gallon of renewable fuel. (GallonPriceAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GALLON_PRICE_AMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the RIN transaction. (TransferDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANSFER_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The PTD number associated with the transaction. (PTDNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'PTD_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The EMTS transaction identification number that matches the submitted buy or sell transaction. (MatchingTransactionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'MATCHING_TRANS_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the transaction. (TransactionDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: BuyTransactionDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_BUY_TRANS_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that identifies the co-product created for the renewable fuel process. (CoProductCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_CO_PROD_DETAIL', @level2type=N'COLUMN',@level2name=N'CO_PROD_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the CoProduct. (CoProductDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_CO_PROD_DETAIL', @level2type=N'COLUMN',@level2name=N'CO_PROD_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CoProductDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_CO_PROD_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The CDX user login of the party responsible for preparing the submission file. (UserLoginText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_EMTS', @level2type=N'COLUMN',@level2name=N'USER_LOGIN_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date that the submission file was created. (SubmittalCreationDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_EMTS', @level2type=N'COLUMN',@level2name=N'SUBM_CRTN_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public identification number for the organization as designated by OTAQReg.  This must be reported if a OrganizationRINPin is not supplied. (OrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_EMTS', @level2type=N'COLUMN',@level2name=N'ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on submission file. (SubmittalCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_EMTS', @level2type=N'COLUMN',@level2name=N'SUBM_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: EMTSDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_EMTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that identifies the feedstock used to produce the renewable fuel associated with the batch number. (FeedstockCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_FDSTK_DETAIL', @level2type=N'COLUMN',@level2name=N'FDSTK_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator of whether the feedstock used qualifies as renewable biomass. (RenewableBiomassIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_FDSTK_DETAIL', @level2type=N'COLUMN',@level2name=N'RENEW_BIOMASS_IND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total amount of feedstock used in the production of the fuel. (FeedstockQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_FDSTK_DETAIL', @level2type=N'COLUMN',@level2name=N'FDSTK_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unit of measure associated with the volume of feedstock used in the production of renewable fuel. (FeedstockMeasureCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_FDSTK_DETAIL', @level2type=N'COLUMN',@level2name=N'FDSTK_MEAS_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the Feedstock. (FeedstockDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_FDSTK_DETAIL', @level2type=N'COLUMN',@level2name=N'FDSTK_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: FeedstockDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_FDSTK_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GenerateSupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of RINs specified in the transaction. (RINQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_VOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'FUEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The renewable fuel type as described in section 80.1426. (FuelCategoryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'FUEL_CATG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the renewable fuel was produced as designated by the producing facility. (ProductionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'PROD_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that identifies the process used for producing the renewable fuel. (ProcessCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'PROC_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The volume of non-renewable fuel added to a volume of ethanol to create the BatchVolume for a given BatchNumber of renewable fuel. (DenaturantVolume)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'DENATURANT_VOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A multiplier applied to BatchVolume to determine the number of RINs that will be generated per gallon of renewable fuel produced.  The EquivalenceValue is directly related to FuelCategoryCode as defined in Section 80.1415. (EquivalenceValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'EQUIVALENCE_VAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public facility identifier of the plant where the fuel was imported. (ImportFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'IMPORT_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the transaction. (TransactionDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: GenerateTransactionDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_GENR_TRANS_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: RetireSupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of RINs specified in the transaction. (RINQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_VOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'FUEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'ASSIGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The RINYear is the year in which the fuel is produced. (RINYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This code identifies the reason for a retire transaction. (RetireReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RETIRE_RSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the RIN transaction. (TransactionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The compliance year for which the transaction is applied. (ComplianceYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'COMPL_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The compliance basis for the submitting organization: Facility, Aggregated Importer, Aggregated Refiner, Aggregated Exporter, Non-Obligated Party. (ComplianceLevelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'COMPL_LEVEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The The facility identifier, as registered in OTAQReg, for the facility that has a compliance obligation. (ComplianceFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'COMPL_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the transaction. (TransactionDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: RetireTransactionDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_RETIRE_TRANS_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_PUB_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_PUB_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SellPublicSupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_PUB_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SellSupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This identifies the buyer organization for a sell transaction or the selling organization for the buy transaction using the OrganizationIdentifier designated by OTAQReg. (TransactionPartnerOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_PART_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the organization trading partner. (TransactionPartnerOrganizationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_PART_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of RINs specified in the transaction. (RINQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_VOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'FUEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'ASSIGN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The RINYear is the year in which the fuel is produced. (RINYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This code identifies the reason for a sell transaction. (SellReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'SELL_RSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Price paid per RIN. (RINPriceAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_PRICE_AMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Price paid per gallon of renewable fuel. (GallonPriceAmount)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GALLON_PRICE_AMT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the RIN transaction. (TransferDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANSFER_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The PTD number associated with the transaction. (PTDNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'PTD_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The EMTS transaction identification number that matches the submitted buy or sell transaction. (MatchingTransactionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'MATCHING_TRANS_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the transaction. (TransactionDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SellTransactionDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SELL_TRANS_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of document to which the document number applies.   (SupportingDocumentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number for the supporting document. (SupportingDocumentNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_SUPRT_DOC_DETAIL', @level2type=N'COLUMN',@level2name=N'SUPRT_DOC_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SeparateSupportingDocumentDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_SUPRT_DOC_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total number of RINs specified in the transaction. (RINQuantity)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_QNTY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_VOL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'FUEL_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The RINYear is the year in which the fuel is produced. (RINYear)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'RIN_YEAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This code identifies the reason for a separate transaction. (SeparateReasonCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'SEPR_RSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date of the RIN transaction. (TransactionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public organization identifier of the small Blender. (BlenderOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BLENDER_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the small blender that is blending the fuel.  (BlenderOrganizationName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BLENDER_ORG_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comment provided by the user on the transaction. (TransactionDetailCommentText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'TRANS_DETAIL_CMNT_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_ORG_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'GENR_FAC_IDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL', @level2type=N'COLUMN',@level2name=N'BATCH_NUM_TXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: SeparateTransactionDetailDataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EMTS_SEPR_TRANS_DETAIL'
GO
