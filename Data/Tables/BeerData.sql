CREATE TABLE [dbo].[BeerData]
(
	[Id] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [NameDisplay] VARCHAR(50) NOT NULL, 
    [Abv] DECIMAL(9, 1) NOT NULL, 
    [CreateDate] DATE NOT NULL, 
    [UpdateDate] DATE NOT NULL, 
    [IsOrganic] NCHAR(1) NOT NULL, 
    [IsRetired] NCHAR(1) NOT NULL, 
    [BeerLabelsId] INT NULL, 
    [BeerStylesId] INT NULL, 
    [Page] INT NOT NULL, 
    CONSTRAINT [FK_Beers_BeerLabels] FOREIGN KEY ([BeerLabelsId]) REFERENCES [BeerLabels]([Id]), 
    CONSTRAINT [FK_Beers_BeerStyles] FOREIGN KEY ([BeerStylesId]) REFERENCES [BeerStyles]([Id])
)
