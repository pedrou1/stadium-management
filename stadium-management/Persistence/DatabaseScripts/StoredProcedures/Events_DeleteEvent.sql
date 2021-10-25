CREATE PROCEDURE [dbo].[Events_DeleteEvent]
	@EventId INT
AS
BEGIN

UPDATE [Events] SET [IsDeleted] = 1 WHERE EventId = @EventId;

END