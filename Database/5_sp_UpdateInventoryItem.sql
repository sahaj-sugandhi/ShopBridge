CREATE PROC sp_UpdateInventoryItem
	@Id INT,
	@ProductName NVARCHAR(30),
	@ProductDescription NVARCHAR(200),
	@Price DECIMAL(10,2)
AS
BEGIN
	UPDATE
		Inventory
	SET
		ProductName = @ProductName,
		ProductDescription = @ProductDescription,
		Price = @Price
	Where
		Id = @Id
END;