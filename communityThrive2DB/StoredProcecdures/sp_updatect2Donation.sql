/*============================================= 
Description:      
UpdateProcedureDonationTable
Author: Francisco Duran    
Date: 12-12-16
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_updatect2Donation
	   @donationID INT
	   ,@userIDFK INT
		,@eventIDFK INT
		,@dateSubmitted DATETIME
		,@donationDescription VARCHAR(100)
		,@donationNotes VARCHAR(50)
	 
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT 
	
	BEGIN TRY
UPDATE ct2Donation
		SET userIDFK = @userIDFK
		,eventIDFK = @eventIDFK
		,dateSubmitted = @dateSubmitted
	   ,donationDescription = @donationDescription
	   ,donationNotes = @donationNotes
	   
    WHERE  donationID = @donationID
	END TRY
    BEGIN CATCH
 
 SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END