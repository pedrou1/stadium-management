CREATE PROCEDURE [dbo].[Administrators_UpdateAdministrator]
	@AdministratorId INT,
	@Name VARCHAR(50),
	@Lastname VARCHAR(50),
	@DocumentNumber VARCHAR(50),
	@Username VARCHAR(50),
	@Password VARCHAR(100),
	@Telephone VARCHAR(15),
	@AdministratorUsernameExist BIT OUT
AS
BEGIN

	IF EXISTS (SELECT * FROM [dbo].[Administrators] WHERE Username = @Username AND AdministratorId <> @AdministratorId) 
	BEGIN
	   SET @AdministratorUsernameExist = 1;
	END
	ELSE
	BEGIN
	   SET @AdministratorUsernameExist = 0;
	   UPDATE [dbo].[Administrators] 
		SET 
			[Name] = @Name
			,[Lastname] = @Lastname
			,[DocumentNumber] = @DocumentNumber
			,[Username] = @Username
			,[Password] = @Password
			,[Telephone] = @Telephone
		WHERE 
			AdministratorId = @AdministratorId
	END
END