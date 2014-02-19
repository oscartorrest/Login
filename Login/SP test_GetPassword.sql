USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Obten_Contrasena]    Script Date: 19/02/2014 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 16/01/2014
-- Description:	Regresa la contraseña del usuario específico
-- =============================================
CREATE PROCEDURE [dbo].[test_GetPassword] 
	-- Add the parameters for the stored procedure here
	@mail varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where Correo=@mail)=1)
	BEGIN
		select Contrasena from Usuario where @mail=Correo;
	END
END
