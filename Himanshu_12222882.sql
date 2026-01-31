CREATE TABLE Sales_Raw

(

    OrderID INT,

    OrderDate VARCHAR(20),

    CustomerName VARCHAR(100),

    CustomerPhone VARCHAR(20),

    CustomerCity VARCHAR(50),

    ProductNames VARCHAR(200),   -- Multiple products comma-separated

    Quantities VARCHAR(100),     -- Multiple quantities comma-separated

    UnitPrices VARCHAR(100),     -- Multiple prices comma-separated

    SalesPerson VARCHAR(100)

);



INSERT INTO Sales_Raw VALUES

(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai',

 'Laptop,Mouse', '1,2', '55000,500', 'Anitha'),

 

(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore',

 'Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),

 

(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai',

 'Laptop', '1', '54000', 'Suresh'),

 

(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad',

 'Monitor,Mouse', '1,1', '12000,500', 'Anitha'),

 

(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore',

 'Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');

 /* Question 1 – Normalization */
CREATE TABLE Customers (
    CustomerID INT IDENTITY PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATE NOT NULL,
    CustomerID INT NOT NULL,
    SalesPerson VARCHAR(100),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Products (
    ProductID INT IDENTITY PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


/* Question 2 – Third Highest Total Sales */

WITH OrderTotals AS (
    SELECT 
        OrderID,
        SUM(
            CAST(q.value AS INT) * CAST(p.value AS INT)
        ) AS TotalSales
    FROM Sales_Raw
    CROSS APPLY STRING_SPLIT(Quantities, ',') q
    CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
    GROUP BY OrderID
),
RankedOrders AS (
    SELECT 
        OrderID,
        TotalSales,
        DENSE_RANK() OVER (ORDER BY TotalSales DESC) AS SalesRank
    FROM OrderTotals
)
SELECT OrderID, TotalSales
FROM RankedOrders
WHERE SalesRank = 3;



/* Question 3 */

SELECT 
    SalesPerson,
    SUM(
        CAST(q.value AS INT) * CAST(p.value AS INT)
    ) AS TotalSales
FROM Sales_Raw
CROSS APPLY STRING_SPLIT(Quantities, ',') q
CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
GROUP BY SalesPerson
HAVING SUM(
        CAST(q.value AS INT) * CAST(p.value AS INT)
    ) > 60000;


/* Question 4 */

SELECT
    CustomerName,
    SUM(
        CAST(q.value AS INT) * CAST(p.value AS INT)
    ) AS TotalSpent
FROM Sales_Raw
CROSS APPLY STRING_SPLIT(Quantities, ',') q
CROSS APPLY STRING_SPLIT(UnitPrices, ',') p
GROUP BY CustomerName
HAVING SUM(
        CAST(q.value AS INT) * CAST(p.value AS INT)
    ) >
    (
        SELECT AVG(CustomerTotal)
        FROM (
            SELECT 
                SUM(
                    CAST(q2.value AS INT) * CAST(p2.value AS INT)
                ) AS CustomerTotal
            FROM Sales_Raw
            CROSS APPLY STRING_SPLIT(Quantities, ',') q2
            CROSS APPLY STRING_SPLIT(UnitPrices, ',') p2
            GROUP BY CustomerName
        ) AvgTable
    );

/* Question 5*/
SELECT 
    UPPER(CustomerName) AS CustomerName,
    DATENAME(MONTH, CAST(OrderDate AS DATE)) AS OrderMonth,
    OrderDate
FROM Sales_Raw
WHERE 
    YEAR(CAST(OrderDate AS DATE)) = 2026
    AND MONTH(CAST(OrderDate AS DATE)) = 1;