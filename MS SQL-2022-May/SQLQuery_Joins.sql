GO

USE [SoftUni]

GO

SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, AddressText
         FROM [Employees] AS [e]
    LEFT JOIN [Addresses] AS a
           ON e.AddressID = a.AddressID
     ORDER BY e.AddressID

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
		  FROM Employees AS e
     LEFT JOIN Addresses AS a
            ON e.AddressID = a.AddressID
     LEFT JOIN Towns AS t
            ON a.TownID = t.TownID
      ORDER BY e.FirstName, e.LastName

   SELECT EmployeeID, FirstName, LastName, d.Name
     FROM Employees AS e
LEFT JOIN Departments AS d
       ON e.DepartmentID = d.DepartmentID
    WHERE d.Name = 'Sales'
 ORDER BY e.EmployeeID

SELECT TOP(5) EmployeeID, FirstName, Salary, d.Name AS DepartmentName
         FROM Employees AS e
    LEFT JOIN Departments AS d
           ON e.DepartmentID = d.DepartmentID
        WHERE e.Salary > 15000
     ORDER BY d.DepartmentID, e.EmployeeID

SELECT TOP(3) e.EmployeeID, FirstName
		 FROM Employees AS e
    LEFT JOIN EmployeesProjects AS ep
           ON e.EmployeeID = ep.EmployeeID
        WHERE ep.ProjectID IS NULL
     ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.Name
	FROM Employees AS e
	LEFT JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
	WHERE e.HireDate > '01/01/1999' AND d.Name IN('Sales', 'Finance')
	ORDER BY e.HireDate

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name
	FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
	INNER JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '08/13/2002' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

SELECT * FROM(
	SELECT e.EmployeeID, e.FirstName,
		   CASE
			WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			ELSE p.Name
		   END AS [ProjectName]
		FROM Employees AS e
		INNER JOIN EmployeesProjects AS ep
		ON ep.EmployeeID = e.EmployeeID
		INNER JOIN Projects AS p
		ON p.ProjectID = ep.ProjectID
		WHERE e.EmployeeID = 24) AS [subQ]
	WHERE EmployeeID = 24

SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName
	FROM Employees AS e
	LEFT JOIN Employees AS em
	ON em.EmployeeID = e.ManagerID
	WHERE e.ManagerID IN(3, 7)
	ORDER BY e.EmployeeID

SELECT TOP(50) e.EmployeeID,
			   CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName],
			   CONCAT(em.FirstName, ' ', em.LastName) AS [ManagerName],
			   d.Name AS [DepartmentName]
	FROM Employees AS e
	LEFT JOIN Employees AS em
	ON em.EmployeeID = e.ManagerID
	LEFT JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
	ORDER BY EmployeeID

SELECT TOP(1) AVG(Salary) AS MinAverageSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY AVG(Salary)

SELECT 10866.6666 AS MinAverageSalary

GO

USE [Geography]

GO

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries AS c
	INNER JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	INNER JOIN Mountains AS m
	ON m.Id = mc.MountainId
	INNER JOIN Peaks AS p
	ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

SELECT c.CountryCode, COUNT(*)
	FROM Countries AS c
	INNER JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	GROUP BY c.CountryCode
	HAVING c.CountryCode IN('BG', 'RU', 'US')

SELECT TOP(5) CountryName, RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
	INNER JOIN Continents AS con
	ON con.ContinentCode = c.ContinentCode
	WHERE con.ContinentName = 'Africa'
	ORDER BY c.CountryName

--SELECT con.ContinentCode, c.CurrencyCode, MAX(COUNT(c.CurrencyCode)) AS CurrencyUsage
--	FROM Continents AS con
--	INNER JOIN Countries AS c
--	ON c.ContinentCode = con.ContinentCode
--	GROUP BY con.ContinentCode, c.CurrencyCode
--	ORDER BY con.ContinentCode--, c.CurrencyCode DESC

SELECT COUNT(*) AS Count
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

SELECT TOP(5) c.CountryName,
	   MAX(p.Elevation) AS HighestPeakElevation,
	   MAX(r.Length) AS LongestRiverLength
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m
	ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p
	ON p.MountainId = m.Id
	LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
	GROUP BY c.CountryName
	ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName