USE BDDistBHF_CF 
GO
/****** Object:  StoredProcedure [dbo].[sp_Mam_TI005]    Script Date: 10/12/2019 06:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[sp_Mam_TI005](@tipo int,@oanumi int=-1,@oanumdoc nvarchar(10)='',@oatip int=-1,@oaano int=-1,@oames int=-1,
									 @oanum int=-1,@oafdoc date=null,@oatc decimal(18, 2)=-1,@oaglosa nvarchar(100)='',@oaobs nvarchar(50)='',
									 @oaemp int=-1,@fecha1 date=null,@fecha2 date=null,@uact nvarchar(10),@TI005 dbo.Mam_TI005Type Readonly,
									 @ifnumi int =-1,@ifto001numi int=-1,@iftc decimal(18,2)=null,
									 @iffechai date=null,@iffechaf date=null,@ifest int=-1,@ifsuc int=-1, 
									@modulo int=-1,@factura int=-1,@fechaI date=null,
@fechaF date=null,@plantilla int =-1,@TC009 dbo.TC009Type Readonly,@TO00111  dbo.TO00111Type ReadOnly,@numiPadre int=-1)
AS
BEGIN
	DECLARE @newHora nvarchar(5)
	set @newHora=CONCAT(DATEPART(HOUR,GETDATE()),':',DATEPART(MINUTE,GETDATE()))
	 declare @numiTo001 int
	DECLARE @newFecha date
	set @newFecha=GETDATE()
	declare @oanumibanco int
	DECLARE @fecha datetime

	set @fecha=@oafdoc
	set @fecha=DATEADD(HOUR,DATEPART (HOUR, GETDATE())  ,@fecha)
	set @fecha=DATEADD(MINUTE,DATEPART (MINUTE, GETDATE())  ,@fecha)
	set @fecha=DATEADD(SECOND,DATEPART (SECOND, GETDATE())  ,@fecha)

	
	

	IF @tipo=1 --NUEVO REGISTRO
	BEGIN
	
		BEGIN TRY 
		
			set @oanum=IIF((select COUNT(oanum) from BDDiconCF .dbo.TO001 where oatip=@oatip and oaano=@oaano and oames=@oames and oaemp=@oaemp)=0,0,(select MAX(oanum) from BDDiconCF .dbo.TO001 where oatip=@oatip and oaano=@oaano and oames=@oames and oaemp=@oaemp))+1
			declare @tipoCompr nvarchar(1)=IIF(@oatip=1,'I',IIF(@oatip=2,'E','T'));
			set @oanumdoc=CONCAT(RIGHT(CAST(@oaano as nvarchar),2),IIF(@oames<10,concat('0',cast(@oames as nvarchar)),cast(@oames as nvarchar)),'-',@tipoCompr,'-',CAST(@oanum as nvarchar));
			
			declare @NameSucursal nvarchar(100)='SUCURSAL PRINCIPAL' 

			INSERT INTO BDDiconCF .dbo.TO001 VALUES(@oanumdoc,@oatip,@oaano,@oames,@oanum,@iffechai,@oatc,@NameSucursal ,@oaobs,@oaemp)


			declare @variablePropoSucursal int =(select top 1 a.sfnumivarp  from BDDiconCF .dbo.TS007 as a where sfnumisuc=@ifsuc )
			set @oanumi=@@IDENTITY
			-- INSERTO EL DETALLE 
			INSERT INTO BDDiconCF .dbo.TO0011(obnumito1,oblin,obcuenta,obaux1,obaux2,obaux3,obobs,obobs2,obcheque,obtc,obdebebs,obhaberbs,obdebeus,obhaberus)
			SELECT @oanumi,td.linea ,td.canumi ,td.variable ,@variablePropoSucursal,0,td.cadesc ,'','',@iftc ,
				   td.debe ,td.haber,td.debesus ,td.habersus  FROM @TI005  AS td where td.linea >0;

	        set @numiTo001=(select  top 1 a.oanumi   from  BDDiconCF .dbo.TO001 as a where a.oanumdoc =@oanumdoc )
			set @ifnumi=IIF((select COUNT(ifnumi) from BDDiconCF .dbo.TI005)=0,0,(select MAX(ifnumi) from BDDiconCF .dbo.TI005))+1

			--inserto detalle del detalle
			INSERT INTO BDDiconCF .dbo.TO00111(ocnumito11,ocnumitc9)
			SELECT x.obnumi,td.ocnumitc9 FROM @TO00111 AS td,BDDiconCF .dbo.TO0011 x where x.obnumito1=@oanumi and x.oblin=td.ocnumito11;

			update BDDiconCF .dbo.TPA001 set aanumiasiento =@oanumi 
			where aatipo =@modulo  and aanumipadre =@numiPadre  and aaestado in (1,2)
			and aanumiasiento =0 
		

			
		
			select @oanumi 
		END TRY
		BEGIN CATCH
			INSERT INTO TB001 (banum,baproc,balinea,bamensaje,batipo,bafact,bahact,bauact)
				   VALUES(ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_MESSAGE(),1,@newFecha,@newHora,@uact)

		
		END CATCH
	END

END







