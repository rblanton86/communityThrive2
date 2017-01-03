
USE communityThrive2DB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Matt
-- Create date: 12/13/2016
-- Description:	Read Category
-- =============================================
CREATE PROCEDURE sp_Readct2Category 
	@categoryID INT,
	@categoryParentID INT,
	@categoryDescription VARCHAR(100),
	@userDefined BIT,
	@isDeleted BIT,
	@dateAdded DATETIME
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
	@v_errorNo INT

	BEGIN TRY

		SELECT 
			cat.categoryID,
			cat.categoryParentID,
			cat.categoryDescription,
			cat.isUserDefined,
			cat.isDeleted,
			cat.dateAdded

		FROM ct2Category AS cat

		

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s"', 16, 1, @v_error)
		RETURN -20000

	END CATCH
END
