USE communityThrive2DB
GO
/****** Object:  StoredProcedure [dbo].[sp_createCategory]    Script Date: 12/12/16 4:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Matt Spezia
-- Create date: 12/12/2016
-- Description:	Insert Catagories
-- =============================================
CREATE PROCEDURE sp_Createct2Category 
	@categoryID INT,
	@dateAdded DATETIME,
	@categoryParentID INT,
	@isUserDefined BIT,
	@isDeleted BIT,
	@categoryDescription VARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     DECLARE @v_error VARCHAR(255),
	@v_errorNo INT

	BEGIN TRY

		INSERT ct2Category
		(
			   dateAdded,
			   isUserDefined,
			   isDeleted,
			   categoryDescription,
			   categoryParentID,
			   categoryID
		)
		VALUES
		(
			@dateAdded,
			@categoryParentID,
			@isUserDefined, 
			@isDeleted,
			@categoryDescription,
			@categoryID	

		)

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s"', 16, 1, @v_error)
		RETURN -20000

	END CATCH
END
