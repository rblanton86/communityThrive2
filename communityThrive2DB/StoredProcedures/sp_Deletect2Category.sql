USE communityThrive2DB

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

-- Author:		Matt Spezia
-- Create date: 12/13/2016
-- Description:	Delete Category
-- =============================================
CREATE PROCEDURE sp_Deletect2Category
	@categoryID INT
	



AS
BEGIN
	
	SET NOCOUNT ON;

    
	DELETE FROM ct2Category

	WHERE categoryID = @categoryID
END
GO
