USE [login]
GO
/****** Object:  StoredProcedure [dbo].[test_ValidateCredentials]    Script Date: 19/02/2014 02:19:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 16/01/2014
-- Description:	regresa el nombre del usuario si es que este existe
-- =============================================
ALTER PROCEDURE [dbo].[test_ValidateCredentials] 
	-- Add the parameters for the stored procedure here
	@mail varchar(50), 
	@password varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where Correo=@mail and Contrasena=@password)=1)
	BEGIN
	select Nombre from Usuario where Correo=@mail and Contrasena=@password;
	END
END
