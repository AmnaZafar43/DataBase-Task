/*QUERY NO 1
*/
SELECT Employees.FirstName
FROM Employees
CROSS JOIN Employees E

SELECT E.FirstName,F.LastName
FROM Employees E,Employees F
WHERE E.City = 'London'

/* ADVANCED TASKS:
   QUERY NO 1
*/
SELECT Customers.CustomerID,OrderID,OrderDate
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
WHERE (OrderDate) IS NULL
/*
   QUERY NO 2
*/
SELECT CustomerID,OrderID,OrderDate
FROM Orders
WHERE OrderDate IS NULL

/*
   QUERY NO 3
*/
SELECT CustomerID,OrderID,OrderDate
FROM Orders
WHERE MONTH(OrderDate) = 7 AND YEAR(OrderDate) = 1997 

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
FROM Employees;

/*
   QUERY NO 6
*/
SELECT EmployeeID ,Employees.HireDate as Date
FROM Employees
WHERE Employees.HireDate > 1996-07-04 AND Employees.HireDate < 1097-08-04

/*
   QUERY NO 7
*/
SELECT Customers.CustomerID,COUNT(Customers.CustomerID) as
TotalOrders,COUNT(Orders.CustomerID) as totalquantity
FROM Customers
JOIN Orders
ON Customers.CustomerID=Orders.CustomerID
WHERE Customers.Country ='USA'
Group By Customers.CustomerID;

/*
   QUERY NO 8
*/
SELECT Customers.CustomerID, CompanyName,OrderID,OrderDate
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
WHERE MONTH(OrderDate) = 7 AND YEAR(OrderDate) = 1997 AND DATE(OrderDate) = 4

/*
   QUERY NO 9
*/
SELECT COUNT(*) [Total Employee older than their managers]
FROM Employees ,(SELECT BirthDate
                 FROM Employees
                 WHERE Title like '') A
WHERE Employees.BirthDate < A.BirthDate;

/*
   QUERY NO 10
*/
SELECT ProductName, OrderDate
FROM Products
JOIN [Order Details]
ON Products.ProductID = [Order Details].ProductID
JOIN Orders
ON [Order Details].OrderID = Orders.OrderID
WHERE YEAR(OrderDate) = 1997 AND MONTH(OrderDate) = 8 AND DATE(OrderDate) = 8

/*
   QUERY NO 11
*/

SELECT ShipAddress,ShipCity,ShipCountry
FROM Orders
JOIN Employees
ON Orders.EmployeeID = Employees.EmployeeID
WHERE Employees.FirstName = 'Anne' AND ShippedDate > RequiredDate

/*
   QUERY NO 12
*/
SELECT DISTINCT ShipCountry
FROM Orders
JOIN [Order Details]
ON Orders.OrderID = [Order Details].OrderID
JOIN Products
ON [Order Details].ProductID = Products.ProductID
JOIN Categories
ON Products.CategoryID = Categories.CategoryID
WHERE CategoryName = 'Beverages'

