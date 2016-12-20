USE communityThrive2DB


GO

CREATE TABLE ct2EventType(
	eventTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	eventTypeDescription VARCHAR(100) NOT NULL,
	eventDesignation VARCHAR(50) NOT NULL
	
)

GO


