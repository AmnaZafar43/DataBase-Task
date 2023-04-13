/* QUERY NO 1
*/
SELECT ProductName
FROM Products
JOIN (SELECT AVG(UnitPrice) AS A
      FROM Products) B
ON Products.UnitPrice > B.A
/* QUERY NO 2
*/
SELECT *
FROM Orders
WHERE ShippedDate is NOT NULL
ORDER BY (ShippedDate)

/* QUERY NO 3
*/
SELECT Country
FROM Suppliers
GROUP BY Country
HAVING COUNT(Country) > 1

/* QUERY NO 4
*/
SELECT MONTH(ShippedDate) AS MonthNumber, OrderID AS OrderDelayed
FROM Orders
WHERE ShippedDate > RequiredDate

/* QUERY NO 5
*/
SELECT OrderID,Discount
FROM [Order Details]
WHERE Discount > 0

/* QUERY NO 6
*/
SELECT COUNT(ORDERID) AS TotalOrders
FROM Orders
WHERE ShipCountry = 'USA' AND ((ShippedDate IS NOT NULL) AND (YEAR(ShippedDate) = 1997))

SELECT ShipCity,COUNT(ShipCity) AS TotalOrders
FROM Orders
WHERE ShipCountry = 'USA' AND ((ShippedDate IS NOT NULL) AND (YEAR(ShippedDate) = 1997))
GROUP BY ShipCity


/* QUERY NO 7
*/
SELECT ShipCountry, OrderID AS OrdersDelayed
FROM Orders
WHERE ShippedDate > RequiredDate

/* QUERY NO 8
*/
SELECT OrderID,Discount,UnitPrice AS TotalPrice
FROM [Order Details]
WHERE Discount > 0

/* QUERY NO 9
*/
SELECT ShipRegion,ShipCity,COUNT(ShipCity) AS Orders
FROM Orders 
WHERE YEAR(ShippedDate) = 1997 AND ShipRegion IS NOT NULL
GROUP BY ShipRegion,ShipCity