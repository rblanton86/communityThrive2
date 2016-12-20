
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
CREATE PROCEDURE sp_Readct2Receipt 
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

		SELECT 
			rec.receiptID,
			usr.userID,
			don.donationID
			

		FROM ct2Receipt AS rec

		LEFT JOIN ct2User AS usr 
			ON rec.userIDFK = usr.userID

		LEFT JOIN ct2Donation AS don
			ON rec.donationIDFK = don.donationID

		

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s"', 16, 1, @v_error)
		RETURN -20000

	END CATCH
END
