CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

CREATE PROC [usp_GetEmployeesSalaryAboveNumber] @Num DECIMAL(18, 4)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Num
END

EXEC usp_GetEmployeesSalaryAboveNumber 35000

CREATE PROC usp_GetTownsStartingWith @townName NVARCHAR(50)
AS
BEGIN
	SELECT Name
	FROM Towns
	WHERE LEFT(Name, LEN(@townName)) = @townName
END

EXEC usp_GetTownsStartingWith 'b'

CREATE PROC usp_GetEmployeesFromTown @townName NVARCHAR(50)
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	INNER JOIN Addresses AS a
	ON a.AddressID = e.AddressID
	INNER JOIN Towns AS t
	ON t.TownID = a.TownID
	WHERE t.Name = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
RETURNS VARCHAR(8)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(8)

	IF @salary < 30000
	BEGIN
		SET @salaryLevel = 'Low'
	END

	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END

	ELSE IF @salary > 50000
	BEGIN
		SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

CREATE PROC usp_EmployeesBySalaryLevel @levelOfSalary VARCHAR(10)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END

EXEC usp_EmployeesBySalaryLevel 'High'

GO

USE [Bank]

Go

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT
	CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName

CREATE PROC usp_GetHoldersWithBalanceHigherThan @num DECIMAL(18, 4)
AS
BEGIN
	--SELECT FirstName, LastName FROM(
	--	SELECT ah.FirstName, ah.LastName, SUM(a.Balance) AS [Sum]
	--	FROM AccountHolders AS ah
	--	JOIN Accounts AS a
	--	ON a.AccountHolderId = ah.Id
	--	GROUP BY ah.FirstName, ah.LastName) AS [subQ]
	--WHERE [Sum] > @num
	--ORDER BY FirstName, LastName
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @num
	ORDER BY FirstName, LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 20000

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum DECIMAL, @intrRate FLOAT, @numOfY INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	RETURN @sum * (POWER((1 + @intrRate), @numOfY))
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

CREATE PROC usp_CalculateFutureValueForAccount
AS
BEGIN
	SELECT a.Id, ah.FirstName, ah.LastName, a.Balance, dbo.ufn_CalculateFutureValue(a.Balance, 0.1, 5)
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON a.AccountHolderId = ah.Id
END


GO

USE [SoftUni]

GO

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
		WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	DELETE FROM Employees
	WHERE DepartmentId = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END