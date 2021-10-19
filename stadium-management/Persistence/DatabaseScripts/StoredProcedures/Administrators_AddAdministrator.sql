CREATE PROCEDURE [dbo].[Administrators_AddAdministrator]
	@Name VARCHAR(50),
	@Lastname VARCHAR(50),
	@Password VARCHAR(100),
	@Username VARCHAR(50),
	@DocumentNumber VARCHAR(50),
	@Telephone VARCHAR(15)
AS
BEGIN

	INSERT INTO [dbo].[Administrators]
    (
		[Name]
        ,[LastName]
        ,[Username]
        ,[Password]
        ,[DocumentNumber]
        ,[Telephone]
	)
    VALUES
    (
		@Name,
        @Lastname,
        @Username,
        @Password,
		@DocumentNumber,
		@Telephone
	)
	SELECT SCOPE_IDENTITY();

END