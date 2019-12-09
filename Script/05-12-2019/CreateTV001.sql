USE [BDDistBHF_CF]
GO

/****** Object:  Table [dbo].[TV001]    Script Date: 6/12/2019 05:31:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TV001](
	[tanumi] [int] NOT NULL,
	[taalm] [int] NULL,
	[tafdoc] [date] NULL,
	[taven] [int] NULL,
	[tatven] [int] NULL,
	[tafvcr] [date] NULL,
	[taclpr] [int] NOT NULL,
	[tamon] [int] NULL,
	[taest] [int] NULL,
	[tatotal] [decimal](18, 2) NULL,
	[tafact] [date] NULL,
	[tahact] [nvarchar](5) NULL,
	[tauact] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[tanumi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



