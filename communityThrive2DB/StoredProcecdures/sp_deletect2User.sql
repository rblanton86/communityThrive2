-- =============================================
-- Author:		<Francisco Duran>
-- Create date: <12-12-16>
-- Description:	<delete procedure for ctUser table>
-- =============================================
CREATE PROC sp_deletect2User
    @userID INT
AS 
BEGIN 
SET NOCOUNT ON;

    DECLARE @v_error VARCHAR(255),
    @v_errorNo INT
	
	BEGIN TRY
		DELETE
		FROM   ct2User
		WHERE  userID = @userID
	END TRY
    BEGIN CATCH

        SELECT @v_error = ERROR_MESSAGE()
        SELECT @v_errorNo = ERROR_NUMBER()

        RAISERROR('Database error occured %s',16,1,@v_error)
        RETURN -20000

    END CATCH
END
