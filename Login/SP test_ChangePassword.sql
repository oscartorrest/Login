USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Cambia_Contrasena]    Script Date: 19/02/2014 11:38:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15/01/2014
-- Description:	Cambia el correo del usuario
-- =============================================
CREATE PROCEDURE [dbo].[test_ChangePassword] 
	-- Add the parameters for the stored procedure here
	@mail varchar(50),
	@oldPassword varchar(15),
	@newPassword varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where @mail=Correo and Contrasena=@oldPassword)=1)
	BEGIN
	 	  UPDATE Usuario
	  set Contrasena=@newPassword
	  where Correo=@mail;
	  select 1
	END
	else
	BEGIN;
	  select -1
	END
END
