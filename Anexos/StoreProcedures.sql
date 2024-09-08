USE [StoreSample]
GO
/****** Object:  StoredProcedure [Sales].[SalesDatePrediction]    Script Date: 6/09/2024 2:15:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Sales].[SalesDatePrediction]
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
