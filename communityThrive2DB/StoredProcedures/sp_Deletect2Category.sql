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
	@categoryID INT,
	@categoryParentID INT,
	@categoryDescription VARCHAR(100),
	@isUserDefined BIT,
	@isDeleted BIT,
	@dateAdded DATETIME



AS
BEGIN
	
	SET NOCOUNT ON;

    
	UPDATE ct2Category
	SET 
		categoryParentID = @categoryParentID,
		categoryDescription = @categoryDescription,
		isUserDefined = @isUserDefined,
		isDeleted = @isDeleted

	WHERE categoryID = @categoryID
END
GO
