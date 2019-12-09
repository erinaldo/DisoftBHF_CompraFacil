USE BDDistBHF_CF 
GO

/****** Object:  View [dbo].[VR_GO_Factura]    Script Date: 7/12/2019 06:48:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


----------------------------------------------------------------------------------------------------------------------------------------------
CREATE view [dbo].[VR_GO_Factura]
as
SELECT a.fvanumi, a.fvafec, a.fvanfac, a.fvaautoriz, a.fvaest, a.fvanitcli, a.fvacodcli, a.fvadescli1, a.fvadescli2, a.fvastot, a.fvaimpsi, a.fvaimpeo, a.fvaimptc, a.fvasubtotal, a.fvadesc, a.fvatotal, a.fvadebfis, a.fvaccont, a.fvaflim, a.fvaimgqr, a.fvaalm, 
                  a.fvanumi2, b.fvbnumi, b.fvbcprod, b.fvbdesprod, b.fvbcant, b.fvbprecio, b.fvbnumi2
FROM     dbo.TFV001 AS a INNER JOIN
                  dbo.TFV0011 AS b ON a.fvanumi = b.fvbnumi AND a.fvanumi2 = b.fvbnumi2


GO


