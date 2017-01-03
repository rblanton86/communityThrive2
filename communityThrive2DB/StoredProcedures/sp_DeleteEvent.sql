-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Delete Event
-- =============================================
CREATE PROCEDURE sp_DeleteEvent

    @eventID INT
	
AS 
BEGIN 
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

BEGIN TRY
	DELETE FROM  ct2Event
	
	WHERE  eventID = @eventID
	
END TRY
	BEGIN CATCH
    -- Insert statements for procedure here
		SELECT @v_error=ERROR_MESSAGE()
		SELECT @V_errorno = ERROR_NUMBER()

		RAISERROR('DATABASE error occured%s',16,1,@v_error)
		RETURN -20000

	END CATCH
END
GO