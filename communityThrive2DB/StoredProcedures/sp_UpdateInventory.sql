-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	Update Inventory
-- =============================================
CREATE PROC sp_UpdateInventory
    @inventoryID INT,
    @donationIDFK INT,
	@inventoryQuantity INT,
	@inventoryDescription VARCHAR(255)

AS 
BEGIN 
 
UPDATE ct2Inventory 
SET  
     donationIDFK = @donationIDFK,
	 inventoryQuantity = @inventoryQuantity,
	 inventoryDescription=@inventoryDescription

WHERE  inventoryID = @inventoryID
END
GO
