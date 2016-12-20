
USE communityThrive2DB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Matt
-- Create date: 12/13/2016
-- Description:	Read family
-- =============================================
CREATE PROCEDURE sp_Readct2Family 
	@familyMemberID INT,
	@recipientIDFK INT,
	@familyMemberGender INT,
	@familyMemberAge INT,
	@isSpouse BIT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
	@v_errorNo INT

	BEGIN TRY

		SELECT 
			fam.familyMemberID,
			rpt.recipientID
			
			

		FROM ct2FamilyMember AS fam

		LEFT JOIN ct2Recipient AS rpt 
			ON fam.recipientIDFK = rpt.recipientID

		

		

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s"', 16, 1, @v_error)
		RETURN -20000

	END CATCH
END
