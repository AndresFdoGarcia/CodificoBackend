USE StoreSample;

CREATE PROCEDURE Sales.SalesDatePrediction
AS
BEGIN
    SET NOCOUNT ON;

    WITH OrderIntervals AS (
        SELECT 
            o.custid,
            DATEDIFF(day, 
                     LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate), 
                     o.orderdate) AS IntervalDays
        FROM Sales.Orders o
    ),
    AverageIntervals AS (
        SELECT 
            custid,
            AVG(IntervalDays) AS AvgIntervalDays
        FROM OrderIntervals
        WHERE IntervalDays IS NOT NULL
        GROUP BY custid
    ),
    LastOrderDates AS (
        SELECT 
            o.custid,
            MAX(o.orderdate) AS LastOrderDate
        FROM Sales.Orders o
        GROUP BY o.custid
    )
    SELECT 
        c.companyname AS [Customer Name],
        l.LastOrderDate AS [Last Order Date],
        DATEADD(day, a.AvgIntervalDays, l.LastOrderDate) AS [Next Predicted Order]
    FROM Sales.Customers c
    JOIN LastOrderDates l ON c.custid = l.custid
    JOIN AverageIntervals a ON c.custid = a.custid
    ORDER BY [Customer Name];
END;
GO


-------------------------------------------------------------------

------------------------------------------------------------------

CREATE PROCEDURE Sales.GetClientOrders
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        orderid,
        requireddate,
        shippeddate,
        shipname,
        shipaddress,
        shipcity
    FROM Sales.Orders
    WHERE custid = @CustomerID;
END;
GO

-------------------------------------------------------------------

-------------------------------------------------------------------

CREATE PROCEDURE Sales.GetEmployees
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        empid,
        firstname + ' ' + lastname AS FullName
    FROM HR.Employees;
END;
GO

--EXEC Sales.GetEmployees;

-------------------------------------------------------------------

-------------------------------------------------------------------

CREATE PROCEDURE Sales.GetShippers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        shipperid,
        companyname
    FROM Sales.Shippers;
END;
GO

--EXEC Sales.GetShippers;

-------------------------------------------------------------------

-------------------------------------------------------------------

CREATE PROCEDURE Production.GetProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        productid,
        productname,
        unitprice
    FROM Production.Products
    WHERE 
        Discontinued = 0; -- Suponiendo que queremos solo productos no discontinuados
END;
GO

--EXEC Production.GetProducts;

-------------------------------------------------------------------

-------------------------------------------------------------------

CREATE PROCEDURE Sales.AddNewOrder
    @Empid INT,
    @CustId INT,
    @Shipperid INT,
    @Shipname NVARCHAR(100),
    @Shipaddress NVARCHAR(100),
    @Shipcity NVARCHAR(50),
    @Orderdate DATE,
    @Requireddate DATE,
    @Shippeddate DATE,
    @Freight DECIMAL(18, 2),
    @Shipcountry NVARCHAR(50),
    @Productid INT,
    @Unitprice DECIMAL(18, 2),
    @Qty INT,
    @Discount DECIMAL(4, 2)
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar la nueva orden en la tabla Orders
    INSERT INTO Sales.Orders (empid, custid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
    VALUES (@Empid, @CustId, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry);

    -- Obtener el ID de la orden recién creada
    DECLARE @Orderid INT;
    SET @Orderid = SCOPE_IDENTITY();

    -- Insertar el producto en la tabla OrderDetails
    INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
    VALUES (@Orderid, @Productid, @Unitprice, @Qty, @Discount);
END;
GO

--EXEC Sales.AddNewOrder 
    --@Empid = 1,
    --@CustId = 3,
    --@Shipperid = 2,
    --@Shipname = 'Nombre del Envío',
    --@Shipaddress = 'Dirección del Envío',
    --@Shipcity = 'Ciudad del Envío',
    --@Orderdate = '2023-10-01',
    --@Requireddate = '2023-10-10',
    --@Shippeddate = '2023-10-05',
    --@Freight = 100.00,
    --@Shipcountry = 'País del Envío',
    --@Productid = 1,
    --@Unitprice = 20.00,
    --@Qty = 5,
    --@Discount = 0.00;