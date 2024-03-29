CREATE DATABASE [Service]

GO

USE [Service]

GO

--part 1
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
 	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
	--?
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	StatusId INT NOT NULL FOREIGN KEY REFERENCES [Status](Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

GO

--part 2
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
	VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
	VALUES
	(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

DELETE FROM Reports
WHERE StatusId = 4

GO

--part 3
SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
	FROM Reports AS r
	WHERE EmployeeId IS NULL
	ORDER BY r.OpenDate, [Description]

SELECT r.[Description], c.[Name]
	FROM Reports AS r
	INNER JOIN Categories AS c
	ON c.Id = r.CategoryId
	ORDER BY r.[Description], c.[Name]

SELECT TOP(5) c.[Name] AS CategoryName, COUNT(r.Id) AS ReportsNumber
	FROM Reports AS r
	INNER JOIN Categories AS c
	ON c.Id = r.CategoryId
	GROUP BY c.Id, c.[Name]
	ORDER BY 2 DESC, 1

SELECT u.Username, c.[Name] AS CategoryName
	FROM Users AS u
	INNER JOIN Reports AS r
	ON r.UserId = u.Id
	INNER JOIN Categories AS c
	ON c.Id = r.CategoryId
	WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate) AND DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
	ORDER BY 1, 2

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, COUNT(u.Id) AS UsersCount
	FROM Employees AS e
	LEFT JOIN Reports AS r
	ON r.EmployeeId = e.Id
	LEFT JOIN Users AS u
	ON u.Id = r.UserId
	GROUP BY e.Id, CONCAT(e.FirstName, ' ', e.LastName)
	ORDER BY 2 DESC, 1

SELECT CASE 
		WHEN CONCAT(e.FirstName, ' ', e.LastName) IS NULL THEN 'None'
		ELSE CONCAT(e.FirstName, ' ', e.LastName)
		END AS Employee, d.[Name] AS Department, c.[Name] AS Category, r.[Description], FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate, s.[Label] AS [Status], u.[Name] AS [User]
	FROM Reports AS r
	LEFT JOIN Employees AS e
	ON e.Id = r.EmployeeId
	LEFT JOIN Departments AS d
	ON d.Id = e.DepartmentId
	LEFT JOIN Categories AS c
	ON c.Id = r.CategoryId
	LEFT JOIN [Status] AS s
	ON s.Id = r.StatusId
	LEFT JOIN Users AS u
	ON u.Id = r.UserId
	--GROUP BY CONCAT(e.FirstName, ' ', e.LastName), d.[Name], c.[Name], r.[Description], FORMAT(r.OpenDate, 'dd.MM.yyyy'), s.[Label], u.[Name]
	ORDER BY CONCAT(e.FirstName, ' ', e.LastName) DESC, Department, Category ASC, [Description], OpenDate, [Status], [User]

GO

--part 4
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS
BEGIN
	IF @StartDate IS NULL OR @EndDate IS NULL
	BEGIN
		RETURN 0
	END
	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

GO

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	IF (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId) <> (SELECT c.DepartmentId
														FROM Reports AS r
														LEFT JOIN Categories AS c
														ON c.Id = r.CategoryId
														WHERE r.Id = @ReportId)
	BEGIN;
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
	END

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 30, 1