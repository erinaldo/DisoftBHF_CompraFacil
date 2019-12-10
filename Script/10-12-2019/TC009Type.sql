USE BDDistBHF_CF 
GO

/****** Object:  UserDefinedTableType [dbo].[TC009Type]    Script Date: 10/12/2019 06:50:26 ******/
CREATE TYPE [dbo].[TC009Type] AS TABLE(
	[cjci] [nvarchar](20) NULL,
	[cjnombre] [nvarchar](100) NULL,
	[cjtipo] [int] NULL,
	[cjnumiTc001] [int] NULL
)
GO


