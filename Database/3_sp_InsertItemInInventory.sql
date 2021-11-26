-- Stored Procedure to Insert an Item
CREATE PROC sp_InsertItemInInventory
	@ProductName NVARCHAR(30),
	@ProductDescription NVARCHAR(200),
	@Price DECIMAL(10,2)
AS
BEGIN
	INSERT INTO
		Inventory (ProductName, ProductDescription, Price)
	VALUES
		(@ProductName, @ProductDescription, @Price);
END;