CREATE PROCEDURE [dbo].[InsertBeerData]
	@Id VARCHAR(10),
	@Name VARCHAR(50),
	@NameDisplay VARCHAR(50),
	@Abv DECIMAL(9,1),
	@CreateDate DATE,
	@UpdateDate DATE,
	@IsOrganic NCHAR(1),
	@IsRetired NCHAR(1),
	@BeerLabelsId INT,
	@BeerStylesId INT,
	@Page INT
AS
BEGIN
	INSERT INTO BeerData
	OUTPUT
		inserted.Id,
		inserted.Name,
		inserted.NameDisplay,
		inserted.Abv,
		inserted.CreateDate,
		inserted.UpdateDate,
		inserted.IsOrganic,
		inserted.IsRetired,
		inserted.BeerLabelsId,
		inserted.BeerStylesId,
		inserted.Page
	VALUES (
		@Id,
		@Name,
		@NameDisplay,
		@Abv,
		@CreateDate,
		@UpdateDate,
		@IsOrganic,
		@IsRetired,
		@BeerLabelsId,
		@BeerStylesId,
		@Page
	)
END
