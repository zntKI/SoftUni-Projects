CREATE DATABASE [Minions]

CREATE TABLE [Minions] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL,
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

INSERT INTO [Towns]([Id], [Name])
	VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

SELECT * FROM [Towns]
SELECT * FROM [Minions]

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate], [Biography])
	VALUES
	('Petar', 1.60, 120.30, 'm', '1999-02-02', NULL),
	('Ivan', 1.60, NULL, 'm', '1999-02-03', NULL),
	('Ivanka', NULL, NULL, 'f', '1999-03-02', NULL),
	('Petromir', 1.60, 120.30, 'm', '1998-02-02', NULL),
	('Stela', 1.80, 70.30, 'f', '1994-02-03', NULL)

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] TIME,
	[IsDeleted] VARCHAR(5) NOT NULL
	CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO [Users](Username, Password, IsDeleted)
	VALUES
	('Pesho', '23544badad', 'false'),
	('Pesho', '23544badad', 'true'),
	('Pesho', '23544badad', 'true'),
	('Pesho', '23544badad', 'true'),
	('Pesho', '23544badad', 'true')

SELECT * FROM [Users]

ALTER TABLE [Users]
ADD [IsDeleted] VARCHAR(5) NOT NULL
CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false')

ALTER TABLE [Users]
ADD CONSTRAINT CHK_PasswordLength
CHECK (LEN([Password]) >= 5)

ALTER TABLE [Users]
ADD CONSTRAINT CHK_D
DEFAULT GETDATE() FOR [LastLoginTime]

CREATE DATABASE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(70) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors](DirectorName, Notes)
	VALUES
	('Ivan', NULL),
	('Ivan', NULL),
	('Ivan', NULL),
	('Ivan', NULL),
	('Ivan', NULL)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(70) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Genres](GenreName, Notes)
	VALUES
	('Fiction', NULL),
	('Fiction', NULL),
	('Fiction', NULL),
	('Fiction', NULL),
	('Fiction', NULL)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(70) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories](CategoryName, Notes)
	VALUES
	('Smth', NULL),
	('Smth', NULL),
	('Smth', NULL),
	('Smth', NULL),
	('Smth', NULL)

CREATE TABLE [MOVIES](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(30) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] DATE NOT NULL,
	[Length] INT NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Movies](Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId)
	VALUES
	('Life of Pi', 1, '1999-02-02', 128, 1, 1),
	('Life of Pi', 1, '1999-02-02', 128, 1, 1),
	('Life of Pi', 1, '1999-02-02', 128, 1, 1),
	('Life of Pi', 1, '1999-02-02', 128, 1, 1),
	('Life of Pi', 1, '1999-02-02', 128, 1, 1)

UPDATE [Movies]
SET [Length] = [Length] * 0.1

SELECT [Salary] FROM [Employees]

SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
	AS [Full Name]
	FROM [Employees]
	WHERE [Salary] IN (25000, 14000, 12500, 23600)

SELECT TOP(5) [FirstName], [LastName]
	FROM [Employees]
	ORDER BY [Salary] DESC

SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [DepartmentID] <> 4

SELECT * FROM [Employees]
	ORDER BY [Salary] DESC,
			 [FirstName],
			 [LastName] DESC,
			 [MiddleName]
GO

CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT 
		CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name],
		[JobTitle] AS [Job Title]
	FROM [Employees]

GO

SELECT DISTINCT [JobTitle] FROM [Employees]

SELECT TOP(10) *
	FROM [Projects]
	ORDER BY [StartDate], [Name]

SELECT TOP(7) [FirstName], [LastName], [HireDate]
	FROM [Employees]
	ORDER BY [HireDate] DESC

SELECT [DepartmentID]
	FROM [Departments]
	WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

UPDATE [Employees]
	SET [Salary] += [Salary] * 0.12
	WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [Employees]

UPDATE [Employees]
	SET [Salary] -= [Salary] * 0.12
	WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [PeakName]
	FROM [Peaks]
	ORDER BY [PeakName]

SELECT TOP(30) [CountryName], [Population]
	FROM [Countries]
	WHERE [ContinentCode] = 'EU'
	ORDER BY [Population] DESC, [CountryName]

SELECT [CountryName], [CountryCode],
		CASE
			WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
		END AS [Currency]
	FROM [Countries]
	ORDER BY [CountryName]

SELECT [Name]
	FROM [Characters]
	ORDER BY [Name]



CREATE DATABASE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL NOT NULL,
	WeeklyRate DECIMAL NOT NULL,
	MonthlyRate DECIMAL NOT NULL,
	WeekendRate DECIMAL NOT NULL)

INSERT INTO Categories(Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
	VALUES
	(1, 'abv', 100, 100, 100, 100),
	(2, 'abv', 100, 100, 100, 100),
	(3, 'abv', 100, 100, 100, 100)

CREATE TABLE Cars(
	Id INT PRIMARY KEY,
	PlateNumber NVARCHAR(15) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture IMAGE,
	Condition NVARCHAR(MAX),
	Available BIT NOT NULL)

INSERT INTO Cars(Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
	VALUES
	(1, 'abv', 'bgv', 'bgv', 1990, 1, 4, 1),
	(2, 'abv', 'bgv', 'bgv', 1990, 1, 4, 1),
	(3, 'abv', 'bgv', 'bgv', 1990, 1, 4, 1)

CREATE TABLE Employees(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX))

INSERT INTO Employees(Id, FirstName, LastName, Title)
	VALUES
	(1, 'g', 'j', 'abv'),
	(2, 'g', 'j', 'abv'),
	(3, 'g', 'j', 'abv')

CREATE TABLE Customers(
	Id INT PRIMARY KEY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	Address NVARCHAR(70) NOT NULL,
	City NVARCHAR(30) NOT NULL,
	ZIPCode NVARCHAR(15) NOT NULL,
	Notes NVARCHAR(MAX))

INSERT INTO Customers(Id, DriverLicenceNumber, FullName, Address, City, ZIPCode)
	VALUES
	(1, 2, 'sg', 'bg', 'ag', 'abh'),
	(2, 2, 'sg', 'bg', 'ag', 'abh'),
	(3, 2, 'sg', 'bg', 'ag', 'abh')

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL NOT NULL,
	KilometrageStart DECIMAL NOT NULL,
	KilometrageEnd DECIMAL NOT NULL,
	TotalKilometrage DECIMAL NOT NULL,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL NOT NULL,
	TaxRate DECIMAL NOT NULL,
	OrderStatus NVARCHAR(MAX),
	Notes NVARCHAR(MAX))

INSERT INTO RentalOrders(Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate)
	VALUES
	(1, 1, 1, 1, 100, 100, 120, 20, '01/01/2020', '01/02/2020', 30, 100, 100),
	(2, 1, 1, 1, 100, 100, 120, 20, '01/01/2020', '01/02/2020', 30, 100, 100),
	(3, 1, 1, 1, 100, 100, 120, 20, '01/01/2020', '01/02/2020', 30, 100, 100)


CREATE DATABASE Hotel

GO

USE Hotel

GO

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title)
	VALUES
	('J', 'A', 'B'),
	('J', 'A', 'B'),
	('J', 'A', 'B')

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	EmergencyName NVARCHAR(20) NOT NULL,
	EmergencyNumber NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
	VALUES
	(1, 'J', 'A', '089', 'k', '123'),
	(2, 'J', 'A', '089', 'k', '123'),
	(3, 'J', 'A', '089', 'k', '123')

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(100) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus)
	VALUES
	('a'),
	('b'),
	('c')

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(100) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType)
	VALUES
	('a'),
	('b'),
	('c')

CREATE TABLE BedTypes(
	BedType NVARCHAR(100) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType)
	VALUES
	('a'),
	('b'),
	('c')

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(100) NOT NULL,
	BedType NVARCHAR(100) NOT NULL,
	Rate DECIMAL(3, 1) NOT NULL,
	RoomStatus NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus)
	VALUES
	(1, 'a', 'b', 5.5, 'c'),
	(2, 'a', 'b', 5.5, 'c'),
	(3, 'a', 'b', 5.5, 'c')

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged MONEY NOT NULL,
	TaxRate DECIMAL NOT NULL,
	TaxAmount MONEY NOT NULL,
	PaymentTotal MONEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
	VALUES
	(1, '01/01/2020', 23, '01/01/2020', '01/01/2020', 10, 20.2, 1.1, 200.2, 1000.50),
	(1, '01/01/2020', 23, '01/01/2020', '01/01/2020', 10, 20.2, 1.1, 200.2, 1000.50),
	(1, '01/01/2020', 23, '01/01/2020', '01/01/2020', 10, 20.2, 1.1, 200.2, 1000.50)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL NOT NULL,
	PhoneCharge MONEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
	VALUES
	(1, '01/01/2020', 23, 2, 5.5, 20.5),
	(1, '01/01/2020', 23, 2, 5.5, 20.5),
	(1, '01/01/2020', 23, 2, 5.5, 20.5)