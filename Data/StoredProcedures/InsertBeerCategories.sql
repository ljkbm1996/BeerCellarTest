CREATE PROCEDURE [dbo].[InsertBeerCategories]
	@Name VARCHAR(MAX)
AS
BEGIN
	INSERT INTO BeerCategories(Name)
	OUTPUT 
		inserted.Id, 
		inserted.Name
	VALUES(@Name);

END