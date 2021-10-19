CREATE PROCEDURE [dbo].[Administrators_DeleteAdministrator]
	@AdministratorId INT
AS
BEGIN

UPDATE Administrators SET [IsDeleted] = 1 WHERE AdministratorId = @AdministratorId;

END