USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Cambia_Nombre]    Script Date: 19/02/2014 11:57:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15/01/2'14
-- Description:	Cambia el nombre del usuario
-- =============================================
CREATE PROCEDURE [dbo].[test_ChangeName] 
	-- Add the parameters for the stored procedure here
	@newName varchar(100),
	@mail varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	  UPDATE Usuario
	  set Nombre=@newName
	  where Correo=@mail;
	  select 1;
END
