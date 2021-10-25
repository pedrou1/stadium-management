CREATE PROCEDURE [dbo].[Events_GetEventTypes]
AS
BEGIN

SELECT [EventTypeId] AS EventTypeId
      ,[Name] AS Name
FROM [dbo].[EventType]

END