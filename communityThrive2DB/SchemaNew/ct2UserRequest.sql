USE communityThrive2DB

GO

CREATE TABLE ct2UserRequest(
	requestID INT PRIMARY KEY IDENTITY(1,1),
	userIDFK INT FOREIGN KEY REFERENCES ct2User(userID),
	

)

GO
