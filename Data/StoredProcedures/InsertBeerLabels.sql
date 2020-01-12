CREATE PROCEDURE [dbo].[InsertBeerLabels]
	@Icon VARCHAR(MAX),
	@Medium VARCHAR(MAX),
	@Large VARCHAR(MAX),
	@ContentAwareIcon VARCHAR(MAX),
	@ContentAwareMedium VARCHAR(MAX),
	@ContentAwareLarge VARCHAR(MAX)
AS
BEGIN
	INSERT INTO BeerLabels (
		Icon,
		Medium,
		Large,
		ContentAwareIcon,
		ContentAwareMedium,
		ContentAwareLarge
	)
	OUTPUT
		inserted.Id,
		inserted.Icon,
		inserted.Medium,
		inserted.Large,
		inserted.ContentAwareIcon,
		inserted.ContentAwareMedium,
		inserted.ContentAwareLarge
	VALUES (
		@Icon,
		@Medium,
		@Large,
		@ContentAwareIcon,
		@ContentAwareMedium,
		@ContentAwareLarge
	)
END
