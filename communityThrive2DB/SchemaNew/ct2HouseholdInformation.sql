USE communityThrive2DB


GO

CREATE TABLE ct2HouseholdInformation(
	householdInformationID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	recipientIDFK INT FOREIGN KEY REFERENCES ct2Recipient(recipientID) NOT NULL,
	householdIncome INT NULL,
	isEmployed BIT NULL
	
)

GO


