CREATE DATABASE CigarShop

GO

USE [CigarShop]

GO


--part 1
CREATE TABLE Sizes(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL CHECK ([Length] BETWEEN 10 AND 25),
	RingRange DECIMAL(3, 2) NOT NULL CHECK (RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) NOT NULL UNIQUE,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id),
	TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id),
	SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars(
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT NOT NULL FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY(ClientId, CigarId)
)

GO

--part 2
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
	VALUES
	('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
	('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
	('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
	('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
	('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
	VALUES
	('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
	('Athens', 'Greece', '4342 McDonald Avenue', 10435),
	('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

SELECT *
	FROM Tastes

UPDATE Cigars
	SET PriceForSingleCigar = PriceForSingleCigar + (PriceForSingleCigar * 0.2)
	WHERE TastId = (SELECT Id
						FROM Tastes
						WHERE TasteType = 'Spicy')

UPDATE Brands
	SET BrandDescription = 'New description'
	WHERE BrandDescription IS NULL

DELETE FROM Clients
	WHERE AddressId  IN(SELECT Id FROM Addresses
	WHERE Country LIKE 'C%')

DELETE FROM Addresses
	WHERE Country LIKE 'C%'

GO

--part 3
SELECT CigarName, PriceForSingleCigar, ImageURL
	FROM Cigars
	ORDER BY PriceForSingleCigar, CigarName DESC

SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
	FROM Cigars AS c
	LEFT JOIN Tastes AS t
	ON t.Id = c.TastId
	WHERE t.TasteType IN('Earthy', 'Woody')
	ORDER BY c.PriceForSingleCigar DESC

SELECT c.Id, CONCAT_WS(' ', c.FirstName, c.LastName) AS ClientName, c.Email
	FROM Clients AS c
	LEFT JOIN ClientsCigars AS cc
	ON cc.ClientId = c.Id
	WHERE cc.ClientId IS NULL
	ORDER BY ClientName

SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL
	FROM Cigars AS c
	LEFT JOIN Sizes AS s
	ON s.Id = c.SizeId
	WHERE s.[Length] > 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
	ORDER BY c.CigarName, c.PriceForSingleCigar DESC

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, a.Country, a.ZIP, CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
	FROM Clients AS c
	LEFT JOIN Addresses AS a
	ON a.Id = c.AddressId
	LEFT JOIN ClientsCigars AS cc
	ON cc.ClientId = c.Id
	LEFT JOIN Cigars AS ci
	ON ci.Id = cc.CigarId
	WHERE ISNUMERIC(a.ZIP) = 1
	GROUP BY CONCAT(c.FirstName, ' ', c.LastName), a.Country, a.ZIP

SELECT c.LastName, CEILING(AVG(s.[Length])) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients AS c
	INNER JOIN ClientsCigars AS cc
	ON cc.ClientId = c.Id
	INNER JOIN Cigars AS ci
	ON ci.Id = cc.CigarId
	INNER JOIN Sizes AS s
	ON s.Id = ci.SizeId
	GROUP BY c.LastName
	ORDER BY CEILING(AVG(s.[Length])) DESC

GO

--part 4
SELECT COUNT(c.FirstName)
	FROM Clients AS c
	LEFT JOIN ClientsCigars AS cc
	ON cc.ClientId = c.Id
	GROUP BY c.FirstName

GO


CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT AS
BEGIN
	--RETURN (SELECT 
	--		CASE
	--			WHEN COUNT(c.FirstName) = (Select COUNT(FirstName) FROM Clients WHERE FirstName <> 'K') THEN 0
	--			WHEN cc.ClientId IS NULL THEN 0
	--			ELSE COUNT(cc.CigarId)
	--			END AS cnt
	--	FROM Clients AS c
	--	LEFT JOIN ClientsCigars AS cc
	--	ON cc.ClientId = c.Id
	--	GROUP BY c.FirstName, cc.ClientId
	--	HAVING c.FirstName = 'K')

	RETURN (SELECT COUNT(*)
				FROM ClientsCigars
				WHERE ClientId IN (SELECT Id FROM Clients WHERE FirstName = @name))
END

GO

SELECT dbo.udf_ClientWithCigars('Jason')

GO

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT c.CigarName, CONCAT('$', c.PriceForSingleCigar) AS Price, t.TasteType, b.BrandName, CONCAT(s.[Length], ' cm') AS CigarLength, CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars AS c
		LEFT JOIN Brands AS b
		ON b.Id = c.BrandId
		LEFT JOIN Tastes AS t
		ON t.Id = c.TastId
		LEFT JOIN Sizes AS s
		ON s.Id = c.SizeId
		WHERE t.TasteType = @taste
		ORDER BY CigarLength, CigarRingRange DESC
END

GO

EXEC usp_SearchByTaste 'Woody'