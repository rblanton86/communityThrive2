USE communityThrive2DB

GO

CREATE TABLE ct2Address(
	addressID INT PRIMARY KEY IDENTITY(1,1),
	streetAddress VARCHAR(150) NOT NULL,
	addressLocationIDFK INT FOREIGN KEY REFERENCES ct2Location(locationID) NOT NULL,
	zipcode INT NOT NULL

)

GO


