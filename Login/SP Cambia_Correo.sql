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
-- Create date: 15/01/2'14
-- Description:	Cambia el correo del usuario
-- =============================================
CREATE PROCEDURE Cambia_Correo 
	-- Add the parameters for the stored procedure here
	@correoNuevo varchar(50),
	@correoAntiguo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where @correoNuevo=Correo)=1)
	BEGIN
	 select -1;
	END
	else
	BEGIN
	  UPDATE Usuario
	  set Correo=@correoNuevo
	  where Correo=@correoAntiguo;
	  select 1
	END
END
GO
