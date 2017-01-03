-- =============================================
-- Author:		Alejandro C.
-- Create date: 12 December 2016
-- Description:	Create Event
-- =============================================
CREATE PROCEDURE sp_CreateEvent
	   @eventTypeIDFK INT,
	   @eventDescription VARCHAR(100),
	   @eventDateTime DATETIME
	 
AS
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

	BEGIN

	BEGIN TRY
	-- Insert values into table
		INSERT INTO ct2Event(
				   
				   eventTypeIDFK,
				   eventDescription,
				   eventDateTime)
		VALUES (	
					
					@eventTypeIDFK,
					@eventDescription,
					@eventDateTime)

-- create variable to hold seeded ID					
DECLARE @eventID INT

-- get the id that was created and place in variable
SET @eventID = SCOPE_IDENTITY()

-- using the variable, check to see if all the values of the sp went into the table 
SELECT 
	   eventID,
	   eventTypeIDFK,
	   eventDescription,
	   eventDateTime
	   
	   	
	FROM ct2Event
 
	WHERE eventID = @eventID
	END TRY
	BEGIN CATCH
    -- Insert statements for procedure here
		SELECT @v_error=ERROR_MESSAGE()
		SELECT @V_errorno = ERROR_NUMBER()

		RAISERROR('DATABASE error occured%s',16,1,@v_error)
		RETURN -20000

	END CATCH

END