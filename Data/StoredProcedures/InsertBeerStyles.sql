CREATE PROCEDURE [dbo].[InsertBeerStyles]
	@Id INT,
	@CategoryId INT,
	@Name VARCHAR(MAX),
	@ShortName VARCHAR(MAX),
	@Description VARCHAR(MAX)
AS
BEGIN
	INSERT INTO  BeerStyles (
		CategoryId,
		Name,
		ShortName,
		Description
	)
	OUTPUT 
		inserted.Id,
		inserted.CategoryId,
		inserted.Name,
		inserted.ShortName,
		inserted.Description
	VALUES (
		@CategoryId,
		@Name,
		@ShortName,
		@Description
	)
END