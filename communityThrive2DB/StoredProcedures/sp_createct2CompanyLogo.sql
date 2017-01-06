/*============================================= 
Description:      
CreateProcedureCompanyLogoTable
Author: Francisco Duran    
Date: 1-5-17
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_createct2CompanyLogo
		@companyIDFK INT
		,@companyLogo VARBINARY
		,@dateAdded DATETIME
		,@isDeleted BIT 
	 
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT 
	
	BEGIN TRY
INSERT INTO ct2CompanyLogo (
		companyIDFK
		,companyLogo
		,dateAdded
		,isDeleted
	   )
    VALUES (
	   @companyIDFK
		,@companyLogo
		,@dateAdded
		,@isDeleted
	  )
 
DECLARE	@companyLogoID INT

SET @companyLogoID = SCOPE_IDENTITY()
 
SELECT 
	   companyIDFK = @companyIDFK
	   ,companyLogo = @companyLogo
	   ,dateAdded = @dateAdded
	   ,isDeleted = @isDeleted

FROM ct2CompanyLogo
WHERE  companyLogoID = @companyLogoID
END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END