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
-- Create date: 12/12/2016
-- Description:	Insert Geographic Location
-- =============================================
CREATE PROCEDURE sp_createct2GeoLocationState
	-- Add the parameters for the stored procedure here
	@stateDescription varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SET NOCOUNT ON;
		DECLARE @v_error VARCHAR(255),
		@v_errorNo INT
	BEGIN TRY

		DECLARE @stateID INT = 0

		SELECT TOP (1) @stateID = st.stateID
		FROM ct2State st
		WHERE UPPER(st.stateDescription) = UPPER(@stateDescription)

		IF ISNULL(@stateID, 0) = 0
			BEGIN

				INSERT ct2State
				(
					 [stateDescription]
				)

				VALUES
				(
					@stateDescription
				)

				SELECT @stateID = st.stateID
				FROM ct2State st
				WHERE UPPER(st.stateDescription) = UPPER(@stateDescription)

				RETURN @stateID
			END
		ELSE
			BEGIN
				RETURN 0;
			END


	END TRY
	BEGIN CATCH 

		SELECT @v_error = ERROR_MESSAGE()
		SELECT @v_errorNo = ERROR_NUMBER()

		RAISERROR('Database error occured %s',16,1,@v_error)
		RETURN -20000

	END CATCH
END
GO
