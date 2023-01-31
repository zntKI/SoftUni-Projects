SELECT [FirstName], [LastName] FROM [Employees]
WHERE FirstName LIKE 'Sa%'

SELECT [FirstName], [LastName] FROM [Employees]
WHERE CHARINDEX('ei', LastName) > 0

SELECT FirstName FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10)
	  AND YEAR(HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

SELECT Name FROM Towns
WHERE LEN(Name) = 5 OR LEN(Name) = 6
ORDER BY Name

SELECT TownID, Name FROM Towns
WHERE Name LIKE 'M%' OR Name LIKE 'K%' OR Name LIKE 'B%' OR Name LIKE 'E%'
ORDER BY Name

SELECT TownID, Name FROM Towns
WHERE Name LIKE '[^R]%' AND Name LIKE '[^B]%' AND Name LIKE '[^D]%'
ORDER BY Name

GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName FROM Employees
	WHERE YEAR(HireDate) > 2000
GO

SELECT FirstName, LastName FROM Employees
	WHERE LEN(LastName) = 5

SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Rank
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
		ORDER BY Salary DESC

SELECT *
	FROM (
			SELECT EmployeeID, FirstName, LastName, Salary,
				DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Rank
				FROM Employees
				WHERE Salary BETWEEN 10000 AND 50000
		 )
	AS [Ranking]
	WHERE [Rank] = 2
	ORDER BY Salary DESC

GO

USE [Geography]

GO

SELECT CountryName, IsoCode FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode

SELECT PeakName, RiverName,
	   LOWER(CONCAT(LEFT(PeakName, LEN(PeakName)), RIGHT(RiverName, LEN(RiverName) - 1))) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix

GO

USE Diablo

GO

SELECT TOP(50) Name, FORMAT(Start, 'yyyy-MM-dd') AS Start
	FROM Games
	WHERE YEAR(Start) IN (2011, 2012)
	ORDER BY Start, Name

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
	FROM Users
	ORDER BY [Email Provider], Username

SELECT Username, IpAddress
	FROM Users
	WHERE IpAddress LIKE '___.1_%._%.___'
	ORDER BY Username

SELECT Name,
	   CASE
		WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12
			THEN 'Morning'
		WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18
			THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) >= 18 AND DATEPART(HOUR, Start) < 24
			THEN 'Evening'
		END AS [Part of the Day],
	   CASE
	    WHEN Duration <= 3
			THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6
			THEN 'Short'
		WHEN Duration > 6
			THEN 'Long'
		WHEN Duration IS NULL
			THEN 'Extra Long'
	   END AS [Duration]
	FROM Games AS g
	ORDER BY Name, Duration, [Part of the Day]

SELECT ProductName, OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(month, 1, OrderDate) AS [Deliver Due]
	   FROM Orders