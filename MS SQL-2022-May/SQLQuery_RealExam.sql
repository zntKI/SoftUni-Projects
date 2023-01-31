CREATE DATABASE Zoo

GO

USE [Zoo]

GO

--part 1
CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
	CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

GO

--part 2
INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
	VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
	VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)

UPDATE Animals
SET OwnerId = (SELECT Id
					FROM Owners
					WHERE [Name] = 'Kaloqn Stoqnov')
WHERE OwnerId IS NULL

DELETE FROM Volunteers
WHERE DepartmentId = (SELECT Id
							FROM VolunteersDepartments
							WHERE DepartmentName = 'Education program assistant')

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

GO

--part 3
SELECT [Name], PhoneNumber, [Address], AnimalId, DepartmentId
	FROM Volunteers
	ORDER BY [Name], AnimalId, DepartmentId

SELECT a.[Name], aty.AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
	FROM Animals AS a
	LEFT JOIN AnimalTypes AS aty
	ON aty.Id = a.AnimalTypeId
	ORDER BY a.[Name]

SELECT TOP(5) o.[Name], COUNT(a.Id) AS CountOfAnimals
	FROM Animals AS a
	INNER JOIN Owners AS o
	ON o.Id = a.OwnerId
	GROUP BY o.Id, o.[Name]
	ORDER BY CountOfAnimals DESC, o.[Name]

SELECT CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals, o.PhoneNumber, ac.CageId AS CageId
	FROM Animals AS a
	INNER JOIN Owners AS o
	ON o.Id = a.OwnerId
	INNER JOIN AnimalTypes AS aty
	ON aty.Id = a.AnimalTypeId
	INNER JOIN AnimalsCages AS ac
	ON ac.AnimalId = a.Id
	WHERE aty.AnimalType = 'Mammals'
	ORDER BY o.[Name], a.[Name] DESC

SELECT v.[Name], v.PhoneNumber, SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 2, LEN(v.[Address])) AS [Address]
	FROM Volunteers AS v
	LEFT JOIN VolunteersDepartments AS vd
	ON vd.Id = v.DepartmentId
	WHERE vd.DepartmentName = 'Education program assistant' AND v.[Address] LIKE '%Sofia%'
	ORDER BY v.[Name]

SELECT a.[Name], YEAR(a.BirthDate) AS BirthYear, aty.AnimalType
	FROM Animals AS a
	INNER JOIN AnimalTypes AS aty
	ON aty.Id = a.AnimalTypeId
	WHERE a.OwnerId IS NULL AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 AND aty.AnimalType <> 'Birds'
	ORDER BY a.[Name]

GO

--part 4
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT AS
BEGIN
	RETURN (SELECT COUNT(v.Id)
				FROM Volunteers AS v
				INNER JOIN VolunteersDepartments AS vd
				ON vd.Id = v.DepartmentId
				GROUP BY vd.Id, vd.DepartmentName
				HAVING vd.DepartmentName = @VolunteersDepartment) --no such name?
END

GO

CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT a.[Name],
			CASE
				WHEN a.OwnerId IS NULL THEN 'For adoption'
				ELSE o.[Name]
			END AS OwnersName
		FROM Animals AS a
		LEFT JOIN Owners AS o
		ON o.Id = a.OwnerId
		WHERE a.[Name] = @AnimalName
END
