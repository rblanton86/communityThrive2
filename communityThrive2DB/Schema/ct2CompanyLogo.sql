/*
Author: Matt Spezia
Date: 12/21/2016
Description: Company Logo Table
*/





CREATE TABLE ct2CompanyLogo
(
companyLogoID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
companyIDFK INT FOREIGN KEY REFERENCES ct2company(companyID) NOT NULL,
companyLogo VARBINARY(MAX) NOT NULL,
dateAdded DATETIME DEFAULT (GETDATE()),
isDeleted BIT DEFAULT (0)
)