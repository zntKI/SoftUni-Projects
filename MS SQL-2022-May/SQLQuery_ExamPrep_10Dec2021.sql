CREATE DATABASE [Airport]

GO

USE [Airport]

GO

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(100) NOT NULL UNIQUE,
	Email NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL UNIQUE,
	LastName NVARCHAR(30) NOT NULL UNIQUE,
	Age TINYINT NOT NULL CHECK (Age BETWEEN 21 AND 62),
	Rating DECIMAL(3, 1) CHECK (Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes(
	Id INT PRIMARY KEY IDENTITY,
	TypeName NVARCHAR(30) NOT NULL UNIQUE
)

CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer NVARCHAR(25) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition NVARCHAR(1) NOT NULL,
	TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft(
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id),
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports(
	Id INT PRIMARY KEY IDENTITY,
	AirportName NVARCHAR(70) NOT NULL UNIQUE,
	Country NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE FlightDestinations(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18, 2) NOT NULL DEFAULT 15
)

GO

--part 2
SELECT *
	FROM Pilots
	WHERE Id BETWEEN 5 AND 15

INSERT INTO Passengers(FullName, Email)
	VALUES
	(CONCAT('Krystal', ' ', 'Cuckson'), CONCAT('KrystalCuckson', '@gmail.com')),
	(CONCAT('Susy', ' ', 'Borrel'), CONCAT('SusyBorrel', '@gmail.com')),
	(CONCAT('Saxon', ' ', 'Veldman'), CONCAT('SaxonVeldman', '@gmail.com')),
	(CONCAT('Lenore', ' ', 'Romera'), CONCAT('LenoreRomera', '@gmail.com')),
	(CONCAT('Enrichetta', ' ', 'Jeremiah'), CONCAT('EnrichettaJeremiah', '@gmail.com')),
	(CONCAT('Delaney', ' ', 'Stove'), CONCAT('DelaneyStove', '@gmail.com')),
	(CONCAT('Ilaire', ' ', 'Tomaszewicz'), CONCAT('IlaireTomaszewicz', '@gmail.com')),
	(CONCAT('Genna', ' ', 'Jaquet'), CONCAT('GennaJaquet', '@gmail.com')),
	(CONCAT('Carlotta', ' ', 'Dykas'), CONCAT('CarlottaDykas', '@gmail.com')),
	(CONCAT('Viki', ' ', 'Oneal'), CONCAT('VikiOneal', '@gmail.com')),
	(CONCAT('Anthe', ' ', 'Larne'), CONCAT('AntheLarne', '@gmail.com'))

UPDATE Aircraft
	SET Condition = 'A'
	WHERE Condition IN ('C', 'B') AND (FlightHours IS NULL OR FlightHours BETWEEN 0 AND 100) AND [Year] >= 2013

DELETE Passengers
	WHERE LEN(FullName) <= 10

GO

--part 3
SELECT Manufacturer, Model, FlightHours, Condition
	FROM Aircraft
	ORDER BY FlightHours DESC

SELECT p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours
	FROM Pilots AS p
	INNER JOIN PilotsAircraft AS pa
	ON pa.PilotId = p.Id
	INNER JOIN Aircraft AS a
	ON a.Id = pa.AircraftId
	WHERE a.FlightHours IS NOT NULL AND FlightHours < 304
	ORDER BY a.FlightHours DESC, p.FirstName

SELECT TOP(20) fd.Id AS [DestinationId], fd.[Start], p.FullName, a.AirportName, fd.TicketPrice
	FROM FlightDestinations AS fd
	LEFT JOIN Passengers AS p
	ON p.Id = fd.PassengerId
	LEFT JOIN Airports AS a
	ON a.Id = fd.AirportId
	WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
	ORDER BY fd.TicketPrice DESC, a.AirportName

SELECT fd.AircraftId, a.Manufacturer, a.FlightHours, COUNT(fd.Id) AS FlightDestinationsCount, ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
	FROM FlightDestinations AS fd
	LEFT JOIN Aircraft AS a
	ON a.Id = fd.AircraftId
	GROUP BY fd.AircraftId, a.Manufacturer, a.FlightHours
	HAVING COUNT(fd.Id) >= 2
	ORDER BY FlightDestinationsCount DESC, fd.AircraftId

SELECT p.FullName, COUNT(fd.AircraftId) AS CountOfAircraft, SUM(fd.TicketPrice) AS TotalPayed
	FROM FlightDestinations AS fd
	LEFT JOIN Passengers AS p
	ON p.Id = fd.PassengerId
	GROUP BY p.FullName
	HAVING p.FullName LIKE '_a%' AND COUNT(fd.AircraftId) > 1
	ORDER BY p.FullName

SELECT ap.AirportName, fd.[Start] AS DayTime, fd.TicketPrice, p.FullName, ac.Manufacturer, ac.Model
	FROM FlightDestinations AS fd
	LEFT JOIN Passengers AS p
	ON p.Id = fd.PassengerId
	LEFT JOIN Airports AS ap
	ON ap.Id = fd.AirportId
	LEFT JOIN Aircraft AS ac
	ON ac.Id = fd.AircraftId
	WHERE (DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20) AND fd.TicketPrice > 2500
	ORDER BY ac.Model

GO

--part 4
CREATE FUNCTION udf_FlightDestinationsByEmail(@email NVARCHAR(50))
RETURNS INT AS
BEGIN
	DECLARE @cnt INT = (SELECT CASE
									WHEN COUNT(fd.Id) IS NULL THEN 0
									ELSE COUNT(fd.Id)
							   END AS Cnt
							FROM FlightDestinations AS fd
							RIGHT JOIN Passengers AS p
							ON p.Id = fd.PassengerId
							GROUP BY p.Email
							HAVING p.Email = @email)

	RETURN @cnt
END

SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')


CREATE PROC usp_SearchByAirportName @airportName NVARCHAR(70)
AS
BEGIN

	SELECT ap.AirportName, p.FullName,
			CASE
				WHEN fd.TicketPrice <= 400 THEN 'Low'
				WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
				WHEN fd.TicketPrice > 1501 THEN 'High'
			END AS LevelOfTickerPrice,
			ac.Manufacturer, ac.Condition, [at].TypeName
		FROM FlightDestinations AS fd
		LEFT JOIN Passengers AS p
		ON p.Id = fd.PassengerId
		LEFT JOIN Airports AS ap
		ON ap.Id = fd.AirportId
		LEFT JOIN Aircraft AS ac
		ON ac.Id = fd.AircraftId
		LEFT JOIN AircraftTypes AS [at]
		ON [at].Id = ac.TypeId
		WHERE ap.AirportName = @airportName
		ORDER BY ac.Manufacturer, p.FullName
END

E