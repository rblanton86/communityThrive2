USE communityThrive2DB
GO



CREATE TABLE ct2Company(
	companyID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	companyAddressIDFK INT FOREIGN KEY REFERENCES ct2Address(ct2AddressID),
	companyName VARCHAR(150) NOT NULL,
	companyDescription VARCHAR(250) NOT NULL,
	companyDateCreated Datetime DEFAULT GETDATE(),
	companyLogo VARBINARY(MAX) NULL
	
	
)

GO


