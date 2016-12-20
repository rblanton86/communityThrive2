-- =============================================
-- Author:		Alejandro C.
-- Create date: 12 December 2016
-- Description:	Create Inventory Item
-- =============================================
CREATE PROCEDURE sp_CreateInventoryItem
	   
	   @inventoryIDFK INT,
	   @categoryIDFK INT,
	   @itemName VARCHAR(255),
	   @itemPrice INT,
	   @itemDescription VARCHAR(255),
	   @itemUPC INT
	 
AS
	DECLARE 
		@v_error VARCHAR(255),
		@V_errorno INT

	BEGIN

	BEGIN TRY
	-- Insert values into table
		INSERT INTO ct2Item(
				   
				   categoryIDFK,
				   itemName,
				   itemPrice,
				   itemDescription,
				   itemUPC)
		VALUES (	
					
					@categoryIDFK,
					@itemName,
					@itemPrice,
					@itemDescription,
					@itemUPC)

-- create variable to hold seeded ID					
DECLARE @itemID INT

-- get the id that was created and place in variable
SET @itemID = SCOPE_IDENTITY()

-- using the variable, check to see if all the values of the sp went into the table 
SELECT 
	   itemID,
	   categoryIDFK,
	   itemName,
	   itemPrice,
	   itemDescription,
	   itemUPC
	   
	   	
	FROM ct2Item
 
	WHERE itemID = @itemID
	END TRY
	BEGIN CATCH
    -- Insert statements for procedure here
		SELECT @v_error=ERROR_MESSAGE()
		SELECT @V_errorno = ERROR_NUMBER()

		RAISERROR('DATABASE error occured%s',16,1,@v_error)
		RETURN -20000

	END CATCH

END