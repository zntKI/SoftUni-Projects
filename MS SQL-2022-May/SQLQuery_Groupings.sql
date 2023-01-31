GO

USE [Gringotts]

GO

SELECT TOP(2)
DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

SELECT
DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

SELECT
DepositGroup,
MagicWandCreator,
MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

SELECT 
AgeGroup,
COUNT(*) AS WizardCount
FROM
(SELECT
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	WHEN Age >= 61 THEN '[61+]'
END AS AgeGroup
FROM WizzardDeposits) AS s1
GROUP BY AgeGroup

SELECT
LEFT(FirstName,1)
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName,1)
ORDER BY LEFT(FirstName,1)

SELECT 
DepositGroup, IsDepositExpired,
AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

GO

USE [SoftUni]

GO

SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	FROM(SELECT *
	FROM Employees
	WHERE HireDate > '01/01/2000') AS [subQ]
	GROUP BY DepartmentID
	HAVING DepartmentID IN (2, 5, 7)

SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(*) AS Count
	FROM Employees
	WHERE ManagerID IS NULL

SELECT * 
	FROM(SELECT DepartmentID, Salary,
	ROW_NUMBER() OVER (ORDER BY DepartmentID) AS [Rank]
	FROM Employees
	ORDER BY DepartmentID, Salary DESC) AS [subQ]

SELECT *
INTO EmployeesEarnMore30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesEarnMore30000
WHERE ManagerID = 42

UPDATE EmployeesEarnMore30000
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary)
	FROM EmployeesEarnMore30000
	GROUP BY DepartmentID

