USE [BDDistBHF_CF] 
GO

/****** Object:  Table [dbo].[TS001]    Script Date: 6/12/2019 05:37:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TS001](
	[sanumi] [int] IDENTITY(1,1) NOT NULL,
	[sanit] [nvarchar](20) NULL,
	[sanom1] [nvarchar](100) NULL,
	[sanom2] [nvarchar](30) NULL
) ON [PRIMARY]

GO


