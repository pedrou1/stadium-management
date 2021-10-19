CREATE PROCEDURE [dbo].[Administrators_GetAdministratorById]
	@AdministratorId INT
AS
BEGIN

SELECT [AdministratorId] AS AdministratorId
      ,[Name] AS Name
      ,[Lastname] AS Lastname
      ,[DocumentNumber] AS DocumentNumber
      ,[Telephone] AS Telephone
      ,[Username] AS Username
	  ,[Password] AS Password
	  ,[IsDeleted] AS IsDeleted
  FROM [dbo].[Administrators]
  WHERE AdministratorId = @AdministratorId

END