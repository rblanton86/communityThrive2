
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Read Inventory Item
-- =============================================
CREATE PROCEDURE sp_ReadInventory
	@inventoryID INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

	BEGIN TRY

		SELECT  dona.donationID,
		dona.dateSubmitted,
		dona.donationNotes,
		invi.inventoryID,
		invi.inventoryQuantity,
		invi.inventoryDescription

FROM ct2Inventory invi

LEFT JOIN ct2Donation dona ON invi.donationIDFK = dona.donationID
--inner join ct2Event evt on don.eventIDFK = evt.EventID

order by invi.inventoryID

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
