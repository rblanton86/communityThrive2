-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Update Event
-- =============================================
CREATE PROC sp_UpdateEvent
    @eventID INT,
    @eventTypeIDFK INT,
    @eventDescription VARCHAR(100),
	@eventDateTime DATETIME

AS 
BEGIN 
 
UPDATE ct2Event
SET  
     eventTypeIDFK = @eventTypeIDFK,
	 eventDescription=@eventDescription,
	 eventDateTime = @eventDateTime

WHERE  eventID = @eventID
END
GO
