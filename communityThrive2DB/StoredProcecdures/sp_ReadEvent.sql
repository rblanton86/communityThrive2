
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Read Event
-- =============================================
CREATE PROCEDURE sp_ReadEvent
	@eventID INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

	BEGIN TRY

		SELECT  evt.eventTypeID,
		evt.eventTypeDescription,
		evt.eventDesignation

FROM ct2Event eve

LEFT JOIN ct2EventType AS evt
ON eve.eventTypeIDFK = evt.eventTypeID
--inner join ct2Event evt on don.eventIDFK = evt.EventID

ORDER BY eve.eventID,eve.eventDescription
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
