USE communityThrive2DB


GO

CREATE TABLE ct2recipientDonationTracking(
	donationTrackingID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	recipientIDFK INT FOREIGN KEY REFERENCES ct2Recipient(recipientID) NOT NULL,
	eventIDFK INT FOREIGN KEY REFERENCES ct2Event(eventID) NOT NULL,
	stockIDFK INT FOREIGN KEY REFERENCES ct2Stock(stockID) NOT NULL,
	donationDate DATETIME DEFAULT(GETDATE()) NOT NULL
	
	
)
GO


