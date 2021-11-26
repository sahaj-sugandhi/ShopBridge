-- Inventory Table
CREATE TABLE Inventory (
	Id INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(30) NOT NULL,
	ProductDescription NVARCHAR(200) NOT NULL,
	Price DECIMAL(10,2) NOT NULL
);