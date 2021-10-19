CREATE PROCEDURE [dbo].[Clients_SignIn]
	@Username varchar(50),
	@Password varchar(50)

AS
BEGIN

DECLARE @clientExists int;

SELECT @clientExists = count(*) FROM [dbo].[Clients] WHERE Username = @Username AND Password = @Password AND IsDeleted = 0;

SELECT [ClientId] AS ClientId
      ,[Name] AS Name
      ,[LastName] AS LastName
      ,[Username] AS Username
      ,[Password] AS Password
      ,[IsDeleted] AS IsDeleted
	  ,@clientExists AS clientExists
  FROM [dbo].[Clients] 
  WHERE Username = @Username AND Password = @Password AND IsDeleted = 0;	

END