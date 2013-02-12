/****** Object:  Table [dbo].[Version]    Script Date: 06/02/2009 15:45:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Version](
	[Version] [varchar](10) NOT NULL,
	[UpdateDate] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Version] ADD  CONSTRAINT [DF_Version_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO


