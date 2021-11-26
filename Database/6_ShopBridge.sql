-- adding some dummy data and verifying created SPs

EXEC sp_InsertItemInInventory @ProductName = 'Pencils', @ProductDescription = 'Graphite Pencils, pack of 10', @Price = 40;

EXEC sp_InsertItemInInventory @ProductName = 'Pen', @ProductDescription = 'Ball Point Pens, pack of 5', @Price = 50;

EXEC sp_InsertItemInInventory @ProductName = 'Pages', @ProductDescription = 'Ruled Pages, bundle of 50', @Price = 100;

EXEC sp_InsertItemInInventory @ProductName = 'Pages', @ProductDescription = 'Ruled Pages, bundle of 50', @Price = 100;

EXEC sp_DeleteItemFromInventory @Id = 4;

EXEC sp_InsertItemInInventory @ProductName = 'Pages', @ProductDescription = 'Ruled Pages, bundle of 50', @Price = 100;

EXEC sp_UpdateInventoryItem @Id = 5, @ProductName = 'Drawing Sheet', @ProductDescription = 'White Drawing Sheet, single', @Price = 5;

EXEC sp_GetAllInventoryItems;