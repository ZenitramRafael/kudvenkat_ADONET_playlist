SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rafael Martinez
-- Create date: 20210808
-- Description:	A procedure for retrieving data from kudvenkat_ADONET_playlist_tblProducts
-- =============================================
CREATE PROCEDURE dbo.prockudvenkat_ADONET_playlist_getProducts
	-- Add the parameters for the stored procedure here
	@productID INT = 0
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF(@productID = 0)
	BEGIN
		SELECT * 
		FROM Example.dbo.kudvenkat_ADONET_playlist_tblProduct
	END
	ELSE
	BEGIN
    SELECT *
		
	FROM
		Example.dbo.kudvenkat_ADONET_playlist_tblProduct
	WHERE
		ProductID = @productID

	
	END
END
GO
