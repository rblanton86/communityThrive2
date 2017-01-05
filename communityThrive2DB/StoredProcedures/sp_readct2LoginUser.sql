-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Erica Bowen
-- Create date: 01/04/2017
-- Description:	Read Login User
-- =============================================
CREATE PROCEDURE sp_readct2LoginUser
	-- Add the parameters for the stored procedure here
	@emailAddress varchar(150),
	@userPassword varchar(150)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SET NOCOUNT ON;
		DECLARE @v_error VARCHAR(255),
		@v_errorNo INT
	BEGIN TRY
		DECLARE @userID INT

		SELECT
		@userID =us.userID

		FROM ct2User us
		WHERE us.emailAddress = @emailAddress
			 AND us.userPassword = @userPassword
		
		EXEC sp_selectct2User @userID 
			  

	END TRY
	BEGIN CATCH 

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s',16,1,@v_error)
		RETURN -20000

	END CATCH
END
GO
