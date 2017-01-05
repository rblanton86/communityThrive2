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
	@familyMemberID INT
	



AS
BEGIN
	
	SET NOCOUNT ON;

    
	DELETE FROM ct2Family
	WHERE familyMemberID = @familyMemberID
END
GO
