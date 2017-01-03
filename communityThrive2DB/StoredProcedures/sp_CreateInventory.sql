-- =============================================
-- Author:		Alejandro C.
-- Create date: 12 December 2016
-- Description:	Create Inventory
-- =============================================
CREATE PROCEDURE sp_CreateInventory
	   @donationIDFK INT,
	   @inventoryQuantity INT,
	   @inventoryDescription VARCHAR(255)
	 
AS
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

	BEGIN

	BEGIN TRY
	-- Insert values into table
		INSERT INTO ct2Inventory(
				   donationIDFK,
				   inventoryQuantity,
				   inventoryDescription
				   )
		VALUES (	
					@donationIDFK,
					@inventoryQuantity,
					@inventoryDescription
					)

-- create variable to hold seeded ID					
DECLARE @inventoryID INT
-- get the id that was created and place in variable
SET @inventoryID = SCOPE_IDENTITY()

-- using the variable, check to see if all the values of the sp went into the table 
SELECT 
	   inventoryID,
	   donationIDFK,
	   inventoryQuantity,
	   inventoryDescription	   
	   	
	FROM ct2Inventory
 
	WHERE inventoryID = @inventoryID
	END TRY
	BEGIN CATCH
    -- Insert statements for procedure here
		SELECT @v_error=ERROR_MESSAGE()
		SELECT @V_errorno = ERROR_NUMBER()

		RAISERROR('DATABASE error occured%s',16,1,@v_error)
		RETURN -20000

	END CATCH

END