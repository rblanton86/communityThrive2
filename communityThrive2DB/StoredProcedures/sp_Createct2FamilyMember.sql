USE [communityThrive2DB]
GO
/****** Object:  StoredProcedure [dbo].[sp_Createct2FamilyMember]    Script Date: 12/13/16 3:25:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		Matt Spezia
-- Create date: 12/13/2016
-- Description:	Insert FamilyMember

CREATE PROCEDURE sp_Createct2FamilyMember
	@recipientIDFK INT,
	@familyMemberGender INT,
	@familyMemberAge INT,
	@isSpouse BIT
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     DECLARE @v_error VARCHAR(255),
	@v_errorNo INT

	BEGIN TRY

		INSERT ct2FamilyMember
		(
			   recipientIDFK,
			   familyMemberGender,
			   familyMemberAge,
			   isSpouse
			   
			   
		)
		VALUES
		(
			@recipientIDFK,
			@familyMemberGender,
			@familyMemberAge,
			@isSpouse 
			
			

		)

	END TRY
	BEGIN CATCH

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s"', 16, 1, @v_error)
		RETURN -20000

	END CATCH
END
