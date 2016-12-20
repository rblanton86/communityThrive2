USE communityThrive2DB

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

-- Author:		Matt Spezia
-- Create date: 12/13/2016
-- Description:	Delete Family
-- =============================================
CREATE PROCEDURE sp_Deletect2Family
	@familyMemberID INT,
	@recipientIDFK INT,
	@familyMemberGender INT,
	@familyMemberAge INT,
	@isSpouse BIT



AS
BEGIN
	
	SET NOCOUNT ON;

    
	UPDATE ct2Family
	SET 
		recipientIDFK = @recipientIDFK,
		familyMemberGender = @familyMemberGender,
		familyMemberAge = @familyMemberAge,
		isSpouse = @isSpouse

	WHERE familyMemberID = @familyMemberID
END
GO
