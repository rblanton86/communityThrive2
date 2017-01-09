USE communityThrive2DB


GO

CREATE TABLE ct2FamilyMember(
	familyMemberID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	recipientIDFK INT FOREIGN KEY REFERENCES ct2Recipient(recipientID) NOT NULL,
	familyMemberGender INT NULL,
	familyMemberAge INT NULL,
	isSpouse BIT NULL
	
)

GO


