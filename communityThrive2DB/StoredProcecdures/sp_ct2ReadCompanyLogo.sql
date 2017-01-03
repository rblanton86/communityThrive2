USE communityThrive2DB
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Author: Matt Spezia
Date: 12/22/2016
Description: Read Procedure ct2CompanyLogo
*/

CREATE PROCEDURE readCt2CompanyLogo
	@companyIDFK INT

AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @v_error VARCHAR(255),
	@v_errorNo INT

	BEGIN TRY

		SELECT
			clo.companyLogoID,
			clo.companyLogo,
			clo.dateAdded

		FROM Ct2CompanyLogo AS clo
		WHERE companyIDFK = @companyIDFK
		AND isDeleted = 0

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR ('Database error has occurred %s"', 16, 1, @v_error)
		RETURN -20000
	
	END CATCH

END
