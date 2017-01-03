/*============================================= 
Description:      
CreateProcedureRecipientTable
Author: Francisco Duran    
Date: 12-12-16
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_createct2Recipient
	   @recipientID INT
	   ,@firstName VARCHAR(50)
		,@lastName VARCHAR(50)
		,@recipientGender INT
	 
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT 
	
	BEGIN TRY
INSERT INTO ct2Recipient ( 
	   firstName
	   ,lastName
	   ,recipientGender
	   )
    VALUES (
	   @firstName
	   ,@lastName
	   ,@recipientGender
	  )
 
SET @recipientID = SCOPE_IDENTITY()
 
SELECT 
	   firstName = @firstName,
	   lastName	= @lastName,
	   recipientGender = @recipientGender

FROM ct2Recipient
WHERE  recipientID = @recipientID
END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END