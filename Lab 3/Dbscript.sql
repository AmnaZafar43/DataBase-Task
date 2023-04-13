/* Query 1
*/
SELECT *
FROM Orders
WHERE ShippedDate > RequiredDate

/* Query 2
*/
SELECT DISTINCT COUNTRY
FROM Employees

SELECT COUNT(DISTINCT(COUNTRY))
FROM Employees

/* Query 3
*/
SELECT *
FROM Employees
WHERE Title LIKE ('Vice_President%');

/* Query 4
*/
SELECT ProductName
FROM Products
WHERE Discontinued = 'TRUE';

/* Query 5
*/
SELECT OrderID
FROM [Order Details]
WHERE Discount = 0;

/* Query 6
*/
SELECT ContactName
FROM Customers
WHERE Region IS NULL

/* Query 7
*/
SELECT ContactName,Phone
FROM Customers
WHERE Country = 'USA' OR Country = 'UK'

/* Query 8
*/
SELECT CompanyName
FROM Suppliers
WHERE HomePage IS NOT NULL

/* Query 9
*/
SELECT ShipCountry
FROM Orders
WHERE YEAR(ShippedDate) LIKE ('1997')

/* Query 10
*/
SELECT CustomerID
FROM Orders
WHERE ShippedDate IS NULL

/* Query 11
*/
SELECT SupplierID,CompanyName,City
FROM Suppliers

/* Query 12
*/
SELECT *
FROM Employees
WHERE City = 'London'

SELECT COUNT(DISTINCT(COUNTRY)) AS TotalCountries
FROM Employees

/* Query 13
*/
SELECT ProductName
FROM Products
WHERE Discontinued = 1

/* Query 14
*/
SELECT OrderID
FROM [Order Details]
Where Discount <= 0.1

/* Query 15
*/
SELECT EmployeeID,FirstName,LastName,HomePhone
FROM Employees
WHERE Region IS NULL