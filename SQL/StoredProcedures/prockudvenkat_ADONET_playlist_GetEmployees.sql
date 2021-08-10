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
-- Author:		Rafael Martinez
-- Create date: 20210808
-- Description:	A procedure for getting all data from kudvenkat_ADONET_playlist_tblEmployees
-- =============================================
CREATE PROCEDURE dbo.prockudvenkat_ADONET_playlist_GetEmployees 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Example.dbo.kudvenkat_ADONET_playlist_tblEmployees
END
GO
