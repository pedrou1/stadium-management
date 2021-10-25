CREATE PROCEDURE [dbo].[Events_GetEventById]
	@EventId INT
AS
BEGIN

SELECT E.[EventId] AS EventId,
		E.[Name] AS Name,
		E.[Description] AS Description,
		E.[StageId] AS StageId,
		E.[Requirements] AS Requirements, 
		E.[Image] AS Image,
		E.[StartTime] AS StartTime,
		E.[EndTime] AS EndTime,
		E.[SeatsAvailableStandard] AS SeatsAvailableStandard,
		E.[SeatsAvailablePlus] AS SeatsAvailablePlus,
		E.[BasePrice] AS BasePrice,
		T.[EventTypeId] AS EventTypeId,
		T.[Name] AS EventTypeName
  FROM [dbo].[Events] AS E, [dbo].[EventType] AS T 
  WHERE E.EventTypeId = T.EventTypeId AND E.EventId = @EventId

END