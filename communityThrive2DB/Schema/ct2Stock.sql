USE communityThrive2DB

GO

CREATE TABLE ct2Stock(
	stockID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	itemIDFK INT FOREIGN KEY REFERENCES ct2Item(itemID) NOT NULL,
	categoryIDFK INT FOREIGN KEY REFERENCES ct2Category(categoryID) NOT NULL,
	inventoryIDFK INT FOREIGN KEY REFERENCES ct2Inventory(inventoryID) NOT NULL,
	stockQuantity INT DEFAULT(0) NOT NULL,
	locationCode VARCHAR(50) NULL 
	
	
)

GO


