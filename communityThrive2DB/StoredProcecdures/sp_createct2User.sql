/*============================================= 
Description:      
CreateProcedureUserTable
Author: Francisco Duran    
Date: 12-12-16
Change History:      
=============================================*/
USE communityThrive2DB;
GO
CREATE PROCEDURE sp_createct2User
	   @userID INT
	   ,@roleIDFK INT
		,@companyIDFK INT
		,@userTypeIDFK INT
		,@emailAddress VARCHAR(100)
		,@userPassword VARCHAR(100)
		,@firstName VARCHAR(50)
		,@lastName VARCHAR(50)
		,@phoneNumber VARCHAR(50)
		,@streetAddress VARCHAR(100)
		,@cityIDFK VARCHAR(100)
		,@stateIDFK VARCHAR(100)
		,@zipcode INT
	 
AS
BEGIN
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT 
	
	BEGIN TRY
INSERT INTO ct2User ( 
	   roleIDFK
	   ,companyIDFK
	   ,userTypeIDFK
	   ,emailaddress
	   ,userPassword
	   ,firstName
	   ,lastName
	   ,phoneNumber
	   ,streetAddress
	   ,cityIDFK
	   ,stateIDFK
	   ,zipcode)
    VALUES (
	   @roleIDFK
	   ,@companyIDFK
	   ,@userTypeIDFK
	   ,@emailAddress
	   ,@userPassword
	   ,@firstName
	   ,@lastName
	   ,@phoneNumber
	   ,@streetAddress
	   ,@cityIDFK
	   ,@stateIDFK
	   ,@zipcode)
 
SET @userID = SCOPE_IDENTITY()
 
SELECT 
	   roleIDFK = @roleIDFK,
	   companyIDFK	= @companyIDFK,
	   userTypeIDFK = @userTypeIDFK,
	   emailAddress = @emailAddress,
	   userPassword = @userPassword,
	   firstName = @firstName,
	   lastName = @lastName,
	   phoneNumber = @phoneNumber,
	   streetAddress = @streetAddress,
	   cityIDFK = @cityIDFK,
	   stateIDFK = @stateIDFK,
	   zipcode = @zipcode

FROM ct2User 
WHERE  userID = @userID
END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END