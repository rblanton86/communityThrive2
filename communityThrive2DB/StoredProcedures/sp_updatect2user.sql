-- =============================================
-- Author:		<Francisco Duran>
-- Create date: <12-12-16>
-- Description:	<update for User table>
-- =============================================
CREATE PROC sp_updatect2User
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
 
		UPDATE ct2User
		SET roleIDFK = @roleIDFK,
		companyIDFK = @companyIDFK,
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
		WHERE  userID = @userID
	END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END
