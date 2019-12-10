USE [BDDistBHF_CF] 
GO

/****** Object:  UserDefinedTableType [dbo].[Mam_TI005Type]    Script Date: 10/12/2019 06:48:54 ******/
CREATE TYPE [dbo].[Mam_TI005Type] AS TABLE(
	[canumi] [int] NULL,
	[nro] [nvarchar](12) NULL,
	[cadesc] [nvarchar](200) NULL,
	[chporcen] [decimal](18, 2) NULL,
	[chdebe] [int] NULL,
	[chhaber] [int] NULL,
	[tc] [decimal](18, 2) NULL,
	[debe] [decimal](18, 2) NULL,
	[haber] [decimal](18, 2) NULL,
	[debesus] [decimal](18, 2) NULL,
	[habersus] [decimal](18, 2) NULL,
	[variable] [int] NULL,
	[linea] [int] NULL
)
GO


