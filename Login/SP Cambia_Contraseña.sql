USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Cambia_Contrasena]    Script Date: 16/01/2014 03:50:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15/01/2014
-- Description:	Cambia el correo del usuario
-- =============================================
CREATE PROCEDURE Cambia_Contrasena 
	-- Add the parameters for the stored procedure here
	@correo varchar(50),
	@contrasenaAntigua varchar(15),
	@contrasenaNueva varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where @correo=Correo and Contrasena=@contrasenaAntigua)=1)
	BEGIN
	 	  UPDATE Usuario
	  set Contrasena=@contrasenaNueva
	  where Correo=@correo;
	  select 1
	END
	else
	BEGIN;
	  select -1
	END
END
