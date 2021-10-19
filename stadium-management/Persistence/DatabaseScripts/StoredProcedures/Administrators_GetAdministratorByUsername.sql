CREATE PROCEDURE [dbo].[Administrators_GetAdministratorByUsername]
	@Username varchar(50)

AS
BEGIN

DECLARE @AdministratorExist INT;

IF EXISTS (SELECT * FROM [dbo].[Administrators] WHERE Username = @Username) 
BEGIN
   SET @AdministratorExist = 1;
END
ELSE
BEGIN
   SET @AdministratorExist = 0;
END

RETURN @AdministratorExist;

END