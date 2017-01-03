/*============================================= 
Description:      
UpdateProcedureCompanyTable
Author: Francisco Duran    
Date: 12-12-16
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_updatect2Company
	   @companyID INT
	   ,@companyName VARCHAR
		,@companyDescription VARCHAR
		,@companyDemographic VARCHAR
	 
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT 
	
	BEGIN TRY
UPDATE ct2company
		SET companyName =  @companyName
	   ,companyDescription = @companyDescription
	   ,companyDemographic = @companyDemographic
	   
    WHERE  companyID = @companyID
	END TRY
    BEGIN CATCH
 
 SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END