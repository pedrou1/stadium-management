CREATE PROCEDURE [dbo].[Clients_SignUp]
	@Name VARCHAR(50),
	@Lastname VARCHAR(50),
	@Password VARCHAR(100),
	@Username VARCHAR(50)
AS
BEGIN

	INSERT INTO [dbo].[Clients]
    (
		[Name],
        [LastName],
		[Username],
		[Password]
	)
    VALUES
    (
		@Name,
        @Lastname,
        @Username,
        @Password
	)
	SELECT SCOPE_IDENTITY();
 
END