

USE DMLRepeat;
GO

-----------------------------------------------------------------------------------
/* Customers */
CREATE TABLE Customers (
    [CustomerID] int identity(1, 1) PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL CHECK (LEN([FirstName]) >= 3),
    [LastName] VARCHAR(50) NOT NULL CHECK (LEN([LastName]) >= 3),
    [Email] VARCHAR(100) NOT NULL
);
GO

-- 1
INSERT INTO Customers(FirstName, LastName, Email)VALUES
('Orel', 'Eland', 'oeland0@ask.com'),
('Mark', 'Andreopolos', 'mandreopolos1@addtoany.com'),
('Patrizius', 'Smethurst', 'psmethurst2@virginia.edu'),
('Jeannine', 'Brownbill', 'jbrownbill3@mysql.com'),
('Bertina', 'Lymbourne', 'blymbourne4@soup.io'),
('Winne', 'Blanche', 'wblanche5@usgs.gov'),
('Kimberli', 'Jacks', 'kjacks6@ycombinator.com'),
('Silvan', 'Lippard', 'slippard7@ameblo.jp'),
('Adlai', 'Schonfelder', 'aschonfelder8@npr.org');
GO

-- 2
UPDATE Customers
SET Email = 'Hello@asdad.hp'
WHERE CustomerID = 1;

-- 3

DELETE FROM Customers WHERE CustomerID = 5;

--4

SELECT * FROM Customers ORDER BY LastName;

--5

INSERT INTO Customers(FirstName, LastName, Email)VALUES
('Killian','Mixter','kmixter0@blinklist.com'),
('Even','Noad','enoad1@drupal.org')

GO

-----------------------------------------------------------------------------------
/* Orders */
CREATE TABLE Orders (
    [OrderID] int identity(1, 1) PRIMARY KEY,
    [CustomerID] int NOT NULL,
    [OrderDate] DATE,
    [TotalAmount] DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

-- Insert Orders
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES
(1, '2005-09-18', 150),
(2, '2018-10-23', 100),
(3, '2013-11-23', 120),
(4, '2016-05-12', 130),
(6, '2012-01-09', 140),
(7, '2019-04-15', 125),
(8, '2014-03-27', 135),
(9, '2020-07-29', 110);

GO

--6
UPDATE Orders
SET OrderDate = '2015-10-24', TotalAmount = 250
WHERE CustomerID = 1;

--7
UPDATE Orders
SET TotalAmount = 90
WHERE OrderID = 2;


--8
DELETE FROM Orders WHERE OrderID = 3;


--9
SELECT * FROM Orders WHERE CustomerID =1;


--10
SELECT * FROM Orders WHERE YEAR(OrderDate) = '2023';

GO

-----------------------------------------------------------------------------------
/* Products */
CREATE TABLE Products (
    [ProductID] int identity(1, 1) PRIMARY KEY,
    [ProductName] VARCHAR(100) NOT NULL CHECK (LEN([ProductName]) >= 3),
    [Price] DECIMAL(10, 2)
);
GO

-- 11
INSERT INTO Products (ProductName, Price) VALUES
('Laptop', 899.99),
('Smartphone', 499.99),
('Headphones', 89.99),
('Keyboard', 29.99),
('Mouse', 19.99),
('Monitor', 249.99),
('Charger', 15.99),
('Speaker', 129.99),
('Tablet', 349.99),
('Smartwatch', 199.99);
GO

--12
UPDATE Products
SET Price = 100.99
WHERE ProductID = 2;


--13
DELETE FROM Products WHERE ProductID = 4;


--14
SELECT * FROM Products WHERE Price > 100;

--15
SELECT * FROM Products WHERE Price <= 50;

GO

-----------------------------------------------------------------------------------
/* OrderDetails */
CREATE TABLE OrderDetails (
    OrderDetailID int identity(1, 1) PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- 16
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES
    (1, 1, 2, 250.50),   -- Laptop
    (1, 2, 1, 100.00),   -- Smartphone
    (2, 3, 3, 15.75),    -- Headphones
    (2, 4, 2, 40.00),    -- Keyboard
    (3, 5, 1, 50.25),    -- Mouse
    (3, 6, 4, 20.00),    -- Monitor
    (4, 7, 2, 60.10),    -- Charger
    (4, 8, 3, 120.00),   -- Speaker
    (5, 9, 3, 45.00),    -- Tablet
    (5, 1, 2, 35.50),    -- Laptop
    (6, 1, 4, 75.00),    -- Laptop
    (6, 2, 1, 12.99),    -- Smartphone
    (7, 3, 5, 28.30);    -- Headphones
GO

-- 17
UPDATE OrderDetails
SET Quantity = 3
WHERE OrderDetailID = 1

-- 18
DELETE FROM OrderDetails WHERE OrderDetailID = 2

-- 19
SELECT * FROM OrderDetails
WHERE OrderID = 1

-- 20
SELECT * FROM OrderDetails
WHERE ProductID = 2

-----------------------------------------------------------------------------------
/* JOIN PART */

-- 21
SELECT c.FirstName, c.LastName, o.OrderDate, o.TotalAmount FROM Orders o
INNER JOIN Customers c on o.CustomerID = c.CustomerID

-- 22
SELECT c.FirstName, od.Quantity FROM OrderDetails od
INNER JOIN Orders o on od.OrderID = o.OrderID
INNER JOIN Customers c on c.CustomerID = o.CustomerID

-- 23
SELECT o.OrderID, o.OrderDate, o.TotalAmount, c.FirstName, c.LastName FROM Orders o
LEFT JOIN Customers c ON o.CustomerID = c.CustomerID;

-- 24
SELECT o.OrderID, o.OrderDate, p.ProductName, od.Quantity, od.Price FROM Orders o
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;

-- 25
SELECT c.FirstName, c.LastName, o.OrderID, o.OrderDate, o.TotalAmount FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID;

-- 26
SELECT p.ProductName, o.OrderID, o.OrderDate, od.Quantity, od.Price FROM Products p
RIGHT JOIN OrderDetails od ON p.ProductID = od.ProductID
RIGHT JOIN Orders o ON od.OrderID = o.OrderID;

-- 27
SELECT o.OrderID, o.OrderDate, p.ProductName, od.Quantity, od.Price FROM Orders o
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;

-- 28
SELECT c.FirstName, c.LastName, o.OrderID, o.OrderDate, p.ProductName, od.Quantity, od.Price FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;

-- 29
SELECT c.FirstName, c.LastName FROM Customers c
WHERE c.CustomerID IN (
    SELECT o.CustomerID FROM Orders o
    WHERE o.TotalAmount > 500
);

-- 30
SELECT p.ProductName FROM Products p
WHERE p.ProductID IN (
    SELECT od.ProductID FROM OrderDetails od
    WHERE od.Quantity > 10
);

-- 31
SELECT c.FirstName, c.LastName,
       (SELECT SUM(o.TotalAmount) FROM Orders o WHERE o.CustomerID = c.CustomerID) AS TotalSpent
FROM Customers c;


-- 32
SELECT p.ProductName, p.Price FROM Products p
WHERE p.Price > (SELECT AVG(Price) FROM Products);


-- 33
SELECT o.OrderID, o.OrderDate, o.TotalAmount, c.FirstName, c.LastName, p.ProductName, od.Quantity, od.Price FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;


-- 34
SELECT c.FirstName, c.LastName, o.OrderID, o.OrderDate, p.ProductName, od.Quantity, od.Price FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;

-- 35
SELECT c.FirstName, c.LastName, p.ProductName, SUM(od.Quantity * od.Price) AS TotalCost FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID
GROUP BY c.FirstName, c.LastName, p.ProductName;

-- 36

SELECT o.OrderID, o.OrderDate, SUM(od.Quantity * od.Price) AS TotalCost FROM Orders o
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, o.OrderDate
HAVING SUM(od.Quantity * od.Price) > 1000;

-- 37

SELECT c.FirstName, c.LastName FROM Customers c
WHERE c.CustomerID IN (
    SELECT o.CustomerID FROM Orders o
    GROUP BY o.CustomerID
    HAVING SUM(o.TotalAmount) > (SELECT AVG(TotalAmount) FROM Orders)
);

-- 38
SELECT c.FirstName, c.LastName, COUNT(o.OrderID) AS OrderCount FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.FirstName, c.LastName;


-- 39
SELECT p.ProductName, SUM(od.Quantity) AS TotalQuantity FROM Products p
INNER JOIN OrderDetails od ON p.ProductID = od.ProductID
GROUP BY p.ProductName
HAVING SUM(od.Quantity) > 3;

-- 40
SELECT c.FirstName, c.LastName, od.Quantity FROM Customers c
JOIN Orders o on c.CustomerID = o.CustomerID
JOIN OrderDetails od on o.OrderID = od.OrderID
GROUP BY c.FirstName, c.LastName, od.Quantity
