USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Agrega_Usuario]    Script Date: 16/01/2014 02:09:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15-01-2014
-- Description:	Agrega un usuario asegurandose que el correo no esté siendo usado
-- =============================================
CREATE PROCEDURE Agrega_Usuario 
	-- Add the parameters for the stored procedure here
	@nombre varchar(50), 
	@correo varchar(100),
	@contrasena varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
	if((select COUNT(*) from Usuario where @correo=Correo)=1 or @nombre='-1' or @contrasena='-1')
	begin
	--Regresa un 0 debido a que no se registrará.
	select 0;
	end
	else
	begin
	insert into Usuario values(@correo,@nombre,@contrasena);
	--Regresa un 1 debido a que ya registró al usuario.
	select 1;
	end
    -- Insert statements for procedure here
END
