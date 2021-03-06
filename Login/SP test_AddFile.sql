USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Add_File]    Script Date: 19/02/2014 11:16:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 17/02/2014
-- Description:	Funcion para guardar archivos
-- =============================================
CREATE PROCEDURE [dbo].[test_AddFile] 
	-- Add the parameters for the stored procedure here
	@mail varchar(50) , 
	@name varchar(255),
	@id varchar(36) = '' 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @id = NEWID()
	IF((select count(*) from Usuario where Correo=@mail)=1)
	BEGIN
	insert into Files values(@id,@mail,@name,'archivos/'+@mail+'/'+@id+SUBSTRING(@name,DATALENGTH(@name)+1-CHARINDEX('.',(REVERSE(@name))),DATALENGTH(@name)))
	select @id
	END
	ELSE
	BEGIN
	-- No existe el correo
	select 'nada'
	END
END
