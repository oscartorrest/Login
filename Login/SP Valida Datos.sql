-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 16/01/2014
-- Description:	regresa el nombre del usuario si es que este existe
-- =============================================
CREATE PROCEDURE Valida_Datos 
	-- Add the parameters for the stored procedure here
	@correo varchar(50), 
	@contrasena varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where Correo=@correo and Contrasena=@contrasena)=1)
	BEGIN
	select Nombre from Usuario where Correo=@correo and Contrasena=@contrasena;
	END
	else
	BEGIN
	select -1;
	END
END
GO

