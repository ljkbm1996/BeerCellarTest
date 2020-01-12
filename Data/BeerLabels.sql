CREATE TABLE [dbo].[BeerLabels]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Icon] VARCHAR(MAX) NULL, 
    [Medium] VARCHAR(MAX) NULL, 
    [Large] VARCHAR(MAX) NULL, 
    [ContentAwareIcon] VARCHAR(MAX) NULL, 
    [ContentAwareMedium] VARCHAR(MAX) NULL, 
    [ContentAwareLarge] VARCHAR(MAX) NULL
)
