-- Stored Procedure to Get All Inventory Items
CREATE PROC sp_GetAllInventoryItems
AS
BEGIN
	SELECT
		*
	FROM
		Inventory
END;