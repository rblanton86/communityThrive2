USE communityThrive2DB
GO



CREATE TABLE ct2company(
	companyID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	companyName VARCHAR(150) NOT NULL,
	companyDescription VARCHAR(250) NOT NULL,
	companyLocation VARCHAR(150) NOT NULL,
	companyDemographic VARCHAR(150) NOT NULL
	
)

GO


