USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Cambia_Correo]    Script Date: 16/01/2014 03:47:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15/01/2'14
-- Description:	Cambia el nombre del usuario
-- =============================================
CREATE PROCEDURE Cambia_Nombre 
	-- Add the parameters for the stored procedure here
	@nombreNuevo varchar(100),
	@correo varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	  UPDATE Usuario
	  set Nombre=@nombreNuevo
	  where Correo=@correo;
	  select 1;
END
