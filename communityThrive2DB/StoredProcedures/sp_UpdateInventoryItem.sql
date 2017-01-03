-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Update InventoryItem
-- =============================================
CREATE PROC sp_UpdateInventoryItem
    @itemID INT,
    @inventoryIDFK INT,
    @categoryIDFK INT,
	@itemName VARCHAR(255),
	@itemPrice INT,
	@itemDescription VARCHAR(255),
	@itemUPC INT

AS 
BEGIN 
 
UPDATE ct2Item
SET  
     inventoryIDFK = @inventoryIDFK,
	 categoryIDFK=@categoryIDFK,
	 itemName = @itemName,
	 itemPrice=@itemPrice,
	 itemDescription=@itemDescription,
	 itemUPC=@itemUPC

WHERE  itemID = @itemID
END
GO
