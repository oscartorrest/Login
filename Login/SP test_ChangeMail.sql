USE [login]
GO
/****** Object:  StoredProcedure [dbo].[Cambia_Correo]    Script Date: 19/02/2014 11:54:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Torres
-- Create date: 15/01/2'14
-- Description:	Cambia el correo del usuario
-- =============================================
CREATE PROCEDURE [dbo].[test_ChangeMail] 
	-- Add the parameters for the stored procedure here
	@newMail varchar(50),
	@oldMail varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if((select COUNT(*) from Usuario where @newMail=Correo)=1)
	BEGIN
	 select -1;
	END
	else
	BEGIN
	  UPDATE Usuario
	  set Correo=@newMail
	  where Correo=@oldMail;
	  select 1
	END
END
