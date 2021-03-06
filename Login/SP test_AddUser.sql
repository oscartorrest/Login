USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Agrega_Usuario]    Script Date: 19/02/2014 11:23:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15-01-2014
-- Description:	Agrega un usuario asegurandose que el correo no esté siendo usado
-- =============================================
CREATE PROCEDURE [dbo].[test_AddUser] 
	-- Add the parameters for the stored procedure here
	@name varchar(50), 
	@mail varchar(100),
	@password varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
	if((select COUNT(*) from Usuario where @mail=Correo)=1 or @name='-1')
	begin
	--Regresa un 0 debido a que no se registrará.
	select 0;
	end
	else
	begin
	insert into Usuario values(@mail,@name,@password);
	--Regresa un 1 debido a que ya registró al usuario.
	select 1;
	end
    -- Insert statements for procedure here
END
