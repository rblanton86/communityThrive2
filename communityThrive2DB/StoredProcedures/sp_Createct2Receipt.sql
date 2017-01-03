USE communityThrive2DB

GO

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

-- Author:		Matt Spezia
-- Create date: 12/13/2016
-- Description:	Insert Receipt

CREATE PROCEDURE sp_Createct2Receipt
	@receiptID INT,
	@userIDFK INT,
	@donationIDFK INT
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     DECLARE @v_error VARCHAR(255),
	@v_errorNo INT

	BEGIN TRY

		INSERT ct2Receipt
		(
			   receiptID,
			   userIDFK,
			   donationIDFK
			   
			   
		)
		VALUES
		(
			@receiptID,
			@userIDFK,
			@donationIDFK 
			
			

		)

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s"', 16, 1, @v_error)
		RETURN -20000

	END CATCH
END
