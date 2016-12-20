-- =============================================
-- Author:		Alejandro C.
-- Create date: 13 December 2016
-- Description:	JOINS Inventory and Category table to Item
-- =============================================

SELECT  invi.inventoryID,
		invi.donationIDFK,
		invi.inventoryQuantity,
		invi.inventoryDescription,
		cat.categoryID,
		cat.categoryParentID,
		cat.categoryDescription,
		cat.dateAdded


FROM ct2Item item

LEFT JOIN ct2Category cat ON item.categoryIDFK = cat.categoryID
LEFT JOIN ct2Inventory invi ON item.inventoryIDFK = invi.inventoryID
--inner join ct2Event evt on don.eventIDFK = evt.EventID

order by item.itemID


