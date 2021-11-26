-- Delete an Item in Inventory
CREATE PROC sp_DeleteItemFromInventory
	@Id INT
AS
BEGIN
	DELETE FROM
		Inventory
	WHERE
		Id=@Id;
END;