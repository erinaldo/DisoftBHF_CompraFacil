USE BDDistBHF_CF 
GO

/****** Object:  Table [dbo].[TV0011]    Script Date: 6/12/2019 05:34:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TV0011](
	[tbnumi] [int] IDENTITY(1000,1) NOT NULL,
	[tbtv1numi] [int] NULL,
	[tbty5prod] [int] NULL,
	[tbest] [int] NULL,
	[tbcmin] [decimal](18, 2) NULL,
	[tbumin] [int] NULL,
	[tbpbas] [decimal](18, 2) NULL,
	[tbptot] [decimal](18, 2) NULL,
	[tbporc] [decimal](18, 2) NULL,
	[tbdesc] [decimal](18, 2) NULL,
	[tbtotdesc] [decimal](18, 2) NULL,
	[tbobs] [nvarchar](30) NULL,
	[tbpcos] [decimal](18, 2) NULL,
	[tbptot2] [decimal](18, 2) NULL,
	[tbfact] [date] NULL,
	[tbhact] [nvarchar](5) NULL,
	[tbuact] [nvarchar](10) NULL,
 CONSTRAINT [PK_TV0011] PRIMARY KEY CLUSTERED 
(
	[tbnumi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



