USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Get_File_Path]    Script Date: 19/02/2014 12:04:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 17/02/2014
-- Description:	Obtiene la dirección de un archivo
-- =============================================
CREATE PROCEDURE [dbo].[test_GetFilePath] 
	-- Add the parameters for the stored procedure here
	@idFile varchar(36)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select PathFile from Files where @idFile=IdFile;
END
