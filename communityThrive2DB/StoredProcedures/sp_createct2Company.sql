/*============================================= 
Description:      
CreateProcedureCompanyTable
Author: Francisco Duran    
Date: 12-12-16
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_createct2Company
		@companyName VARCHAR (150)
		,@companyDescription VARCHAR(250)
		,@companyLocation INT
		,@companyDemographic VARCHAR(150)
	 
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT 
	
	BEGIN TRY
INSERT INTO ct2Company (
		companyName
	   ,companyDescription
	   ,companyLocation
	   ,companyDemographic
	   )
    VALUES (
	   @companyName
	   ,@companyDescription
	   ,@companyLocation
	   ,@companyDemographic
	  )
 
DECLARE	@companyID INT

SET @companyID = SCOPE_IDENTITY()
 
SELECT 
	   companyName = @companyName,
	   companyDescription	= @companyDescription,
	   companyLocation = @companyLocation,
	   companyDemographic = @companyDemographic

FROM ct2Company 
WHERE  companyID = @companyID
END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END