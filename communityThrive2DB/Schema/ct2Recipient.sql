USE communityThrive2DB

GO

CREATE TABLE ct2Recipient(
	recipientID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	firstName VARCHAR(50)NOT NULL,
	lastName VARCHAR(50)NOT NULL,
	recipientGender INT NOT NULL
	
)

GO


