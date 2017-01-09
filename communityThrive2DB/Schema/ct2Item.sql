USE communityThrive2DB

GO

CREATE TABLE ct2Item(
	itemID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	inventoryIDFK INT FOREIGN KEY REFERENCES ct2Inventory(inventoryID) NOT NULL,
	categoryIDFK INT FOREIGN KEY REFERENCES ct2Category(categoryID) NOT NULL,
	itemName VARCHAR(255) NOT NULL,
	itemPrice INT NULL,
	itemDescription VARCHAR(255) NOT NULL,
	itemUPC INT NULL
	

)

GO


