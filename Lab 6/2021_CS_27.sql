/* QUERY NO 1
*/
SELECT Customers.CustomerID,OrderID,OrderDate
FROM Customers
JOIN (SELECT *
      FROM Orders
      WHERE (OrderDate) IS NULL)A
ON Customers.CustomerID = A.CustomerID
/*
 QUERY NO 2
*/ 
SELECT CustomerID,OrderID,OrderDate
FROM Orders
WHERE OrderDate IN (SELECT OrderDate 
                    FROM Orders 
					Where OrderDate IS NULL)

/*
   QUERY NO 3
*/
SELECT CustomerID,OrderID,OrderDate
FROM Orders
WHERE OrderDate IN (SELECT OrderDate
                    FROM Orders 
				    WHERE MONTH(OrderDate) = 7 AND YEAR(OrderDate) = 1997)

/*
   QUERY NO 4
*/
SELECT CustomerID,COUNT(CustomerID) AS totalorders
FROM Orders
GROUP BY CustomerID

/*
   QUERY NO 5
*/
SELECT *
FROM Employees
         UNION ALL
SELECT *
FROM Employees
         UNION ALL
(SELECT *
FROM Employees)
         UNION ALL
SELECT *
FROM Employees
        UNION ALL
SELECT *
FROM Employees

/*
   QUERY NO 6
*/
SELECT EmployeeID ,Employees.HireDate as Date
FROM Employees
WHERE Employees.HireDate IN (SELECT HireDate
                             FROM Employees 
							 WHERE HireDate >= 1996-07-04 AND HireDate <= 1997-08-04)

/*
   QUERY NO 7
*/
SELECT Customers.CustomerID,COUNT(Customers.CustomerID) as TotalOrders,COUNT(A.CustomerID) as TotalQuantity
FROM Customers
JOIN (SELECT *
      FROM Orders) A
ON Customers.CustomerID = A.CustomerID
WHERE Customers.Country IN (SELECT Country
                  FROM Customers 
				  WHERE Country ='USA')
Group By Customers.CustomerID

/*
   QUERY NO 8
*/
SELECT Customers.CustomerID, CompanyName,OrderID,OrderDate
FROM Customers
JOIN (SELECT *
      FROM Orders)A
ON Customers.CustomerID = A.CustomerID
WHERE OrderDate IN (SELECT OrderDate
                    FROM Orders
					WHERE MONTH(OrderDate) = 7 AND YEAR(OrderDate) = 1997 AND DAY(OrderDate) = 4)

/*
   QUERY NO 9
*/
SELECT COUNT(*) AS [Total Older Employee] 
FROM Employees ,(SELECT BirthDate
                 FROM Employees
                 WHERE Title like '%Manager') A
WHERE Employees.BirthDate < A.BirthDate

/*
   QUERY NO 10
*/
SELECT ProductName, OrderDate
FROM Products
JOIN (SELECT *
      FROM [Order Details]) A
ON Products.ProductID = A.ProductID
JOIN (SELECT *
      FROM Orders)B
ON A.OrderID = B.OrderID
WHERE OrderDate IN (SELECT OrderDate
                    FROM Orders 
					WHERE YEAR(OrderDate) = 1997 AND MONTH(OrderDate) = 8 AND Day(OrderDate) = 8)

/*
   QUERY NO 11
*/

SELECT ShipAddress,ShipCity,ShipCountry
FROM Orders
JOIN (SELECT *
      FROM Employees)A
ON Orders.EmployeeID = A.EmployeeID
WHERE A.FirstName IN (SELECT FirstName
                      FROM Employees
					  WHERE FirstName = 'Anne' AND ShippedDate > RequiredDate)

/*
   QUERY NO 12
*/
SELECT DISTINCT ShipCountry
FROM Orders
JOIN (SELECT *
      FROM [Order Details])O
ON Orders.OrderID = O.OrderID
JOIN (SELECT *
      FROM Products)P
ON O.ProductID = P.ProductID
JOIN (SELECT *
      FROM Categories)C
ON P.CategoryID = C.CategoryID
WHERE CategoryName IN (SELECT CategoryName
                       FROM Categories
					   WHERE CategoryName = 'Beverages')
