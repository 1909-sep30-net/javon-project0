-- CREATE DATABASE TThreeTeas
-- Create manually in Azure

-- DROP all previous tables
DROP TABLE TThreeTeas.Product;
DROP TABLE TThreeTeas.Location;
DROP TABLE TThreeTeas.Inventory;
DROP TABLE TThreeTeas.Customer;
DROP TABLE TThreeTeas.Order;
DROP TABLE TThreeTeas.LineItem;

-- CREATE TABLE Product
CREATE TABLE TThreeTeas.Product (
	ID INT IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	Price MONEY NOT NULL,
	CONSTRAINT PK_Product_ID PRIMARY KEY (ID)
);
-- CREATE TABLE Location
CREATE TABLE TThreeTeas.Location (
	ID INT IDENTITY(1,1),
	Address VARCHAR(255) NOT NULL,
	City VARCHAR(255) NOT NULL,
	Zipcode INT NOT NULL,
	State VARCHAR(2) NOT NULL,
	CONSTRAINT PK_Location_ID PRIMARY KEY (ID)
);
-- CREATE TABLE Inventory
CREATE TABLE TThreeTeas.Inventory (
	LocationID INT NOT NULL,
	ProductID INT NOT NULL,
	Stock INT NOT NULL,
	CONSTRAINT FK_LocationID_Location_ID FOREIGN KEY REFERENCES TThreeTeas.Location(ID),
	CONSTRAINT FK_ProductID_Product_ID FOREIGN KEY REFERENCES TThreeTeas.Product(ID)
);
-- CREATE TABLE Customer
CREATE TABLE TThreeTeas.Customer (
	ID INT IDENTITY(1,1),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR (255) NOT NULL,
	CONSTRAINT PK_Customer_ID PRIMARY KEY (ID)
);
-- CREATE TABLE Order
CREATE TABLE TThreeTeas.Order (
	ID INT IDENTITY(1,1),
	LocationID INT NOT NULL,
	CustomerID INT NOT NULL,
	OrderTime DATETIME NOT NULL,
	CONSTRAINT PK_Order_ID PRIMARY KEY (ID),
	CONSTRAINT FK_LocationID_Location_ID FOREIGN KEY REFERENCES TThreeTeas.Location(ID),
	CONSTRAINT FK_CustomerID_Customer_ID FOREIGN KEY REFERENCES TThreeTeas.Customer(ID)
);
-- CREATE TABLE LineItem
CREATE TABLE TThreeTeas.LineItem (
	OrderID INT NOT NULL,
	ProductID INT NOT NULL,
	Quantity INT NOT NULL,
	CONSTRAINT FK_OrderID_Order_ID FOREIGN KEY REFERENCES TThreeTeas.Order(ID),
	CONSTRAINT FK_ProductID_Product_ID FOREIGN KEY REFERENCES TThreeTeas.Product(ID)
);

-- INSERT INTO Products
INSERT INTO TThreeTeas.Product (Name, Price) VALUES
	('Butterscotch', 20.56),
	('Dark Chocolate Peppermint', 15.78),
	('White Winter Chai', 9.78),
	('Fresh Greens Tea', 23.62),
	('Pumpkin Pie', 8.34),
	('Jasmine Ancient Beauty Tea', 30.12);

-- INSERT INTO Locations
INSERT INTO TThreeTeas.Location (Address, City, Zipcode, State) VALUES
	('8 Winding Street', 'Hilly Glory', 71550, 'AK'),
	('32 Bull', 'Ranch Plaza', 90235, 'LA'),
	('192 Main', 'Shining Beacon', 89567, 'SD');

-- INSERT INTO Inventories for each Location
INSERT INTO TThreeTeas.Inventory (LocationID, ProductID, Stock) VALUES
	(1, 3, 4),
	(1, 4, 11),
	(1, 6, 21),
	(2, 2, 8),
	(2, 3, 14),
	(2, 5, 6),
	(3, 1, 6),
	(3, 3, 15),
	(3, 5, 7),
	(3, 6, 12);

-- INSERT INTO Customers
INSERT INTO TThreeTeas.Customer (FirstName, LastName) VALUES
	('Javon', 'Negahban'),
	('Ojan', 'Negahban'),
	('Henry', 'Ford'),
	('Nikola', 'Tesla'),
	('Lucy', 'Shepherd');

-- INSERT INTO Orders
INSERT INTO TThreeTeas.Order (LocationID, CustomerID, OrderTime) VALUES
	(2, 3, DATEADD(hh, -5, GETDATE())),
	(3, 4, DATEADD(hh, -20, GETDATE())),
	(1, 2, DATEADD(hh, -2, GETDATE())),
	(3, 4, DATEADD(hh, -1, GETDATE())),
	(1, 1, DATEADD(hh, -11, GETDATE()));

-- INSERT INTO LineItems for each Order
INSERT INTO TThreeTeas.LineItem (OrderID, ProductID, Quantity) VALUES
	(1, 2)