CREATE PROCEDURE [dbo].[Administrators_SignIn]
	@Username varchar(50),
	@Password varchar(50)

AS
BEGIN

DECLARE @adminExist int;

SELECT @adminExist = count(*) FROM [dbo].[Administrators] WHERE Username = @Username AND Password = @Password AND IsDeleted = 0;

SELECT [AdministratorId]
      ,[Name] AS Name
      ,[LastName] AS LastName
      ,[Username] AS Username
      ,[Password] AS Password
      ,[DocumentNumber] AS DocumentNumber
      ,[Telephone] AS Telephone
      ,[IsDeleted] AS IsDeleted
	  ,@adminExist AS adminExist
  FROM [dbo].[Administrators]
  WHERE Username = @Username AND Password = @Password AND IsDeleted = 0;

END
