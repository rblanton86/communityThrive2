
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Read Inventory Item
-- =============================================
CREATE PROCEDURE sp_ReadInventoryItem
	@itemID INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

	BEGIN TRY

		SELECT  item.itemName,
		item.itemPrice,
		item.itemDescription,

		cat.categoryParentID,
		cat.categoryDescription,
		cat.dateAdded


FROM ct2Item item

LEFT JOIN ct2Category cat ON item.categoryIDFK = cat.categoryID
LEFT JOIN ct2Inventory invi ON item.inventoryIDFK = invi.inventoryID
--inner join ct2Event evt on don.eventIDFK = evt.EventID

order by item.itemID, item.itemDescription


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
