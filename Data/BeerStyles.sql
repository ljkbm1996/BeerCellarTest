CREATE TABLE [dbo].[BeerStyles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CategoryId] INT NULL, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [ShortName] VARCHAR(MAX) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL
)
