USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Get_Files]    Script Date: 19/02/2014 12:09:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 17/02/2014
-- Description:	Obtiene todos los archivos de un usuario
-- =============================================
CREATE PROCEDURE [dbo].[test_GetFiles] 
	-- Add the parameters for the stored procedure here
	@owner varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select IdFile,Name from Files where Owner=@owner;
END
