USE communityThrive2DB

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

-- Author:		Matt Spezia
-- Create date: 12/13/2016
-- Description:	Delete Receipt
-- =============================================
CREATE PROCEDURE sp_Deletect2Receipt
	@receiptID INT,
	@userIDFK INT,
	@donationIDFK INT



AS
BEGIN
	
	SET NOCOUNT ON;

    
	UPDATE ct2Receipt
	SET 
		userIDFK = @userIDFK,
		donationIDFK = @donationIDFK
	WHERE receiptID = @receiptID
END
GO
