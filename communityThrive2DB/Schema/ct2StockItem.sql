USE communityThrive2DB
GO


CREATE TABLE ct2StockItem
(
	itemIDFK INT FOREIGN KEY REFERENCES ct2Item(itemID) NOT NULL,
	stockIDFK INT FOREIGN KEY REFERENCES ct2Stock(stockID) NOT NULL,
	createDate DATETIME DEFAULT (GETDATE()) NOT NULL,
	isDeleted BIT DEFAULT (0) NOT NULL
)

GO