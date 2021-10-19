CREATE PROCEDURE [dbo].[Clients_GetClientByUsername]
	@Username varchar(50)

AS
BEGIN

DECLARE @ClientExists INT;

SET @ClientExists = (SELECT count(*) FROM [dbo].[Clients] WHERE Username = @Username);

RETURN @ClientExists;

END