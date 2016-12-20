USE communityThrive2DB

GO

CREATE TABLE ct2Inventory(
	inventoryID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	donationIDFK INT FOREIGN KEY REFERENCES ct2Donation(donationID) NOT NULL,
	categoryIDFK INT FOREIGN KEY REFERENCES ct2Category(categoryID) NOT NULL,
	inventoryQuantity INT DEFAULT(0) NOT NULL,
	inventoryDescription VARCHAR(255) NOT NULL
	

)
GO


