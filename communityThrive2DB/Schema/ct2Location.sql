USE communityThrive2DB
GO



CREATE TABLE ct2Location(
	locationID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	stateID INT FOREIGN KEY REFERENCES ct2State(stateID) NOT NULL,
	cityID INT FOREIGN KEY REFERENCES ct2City(cityID) NOT NULL,

) 

GO

