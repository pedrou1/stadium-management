CREATE PROCEDURE Events_GetEvents
	@PageIndex INT,  
	@PageSize INT,
	@TotalRows INT OUTPUT
AS  
BEGIN  
	 DECLARE @StartRowIndex INT 
	 DECLARE @EndRowIndex INT
 
	 SET @StartRowIndex = (@PageIndex * @PageSize) + 1;
	 SET @EndRowIndex = (@PageIndex + 1) * @PageSize;
 
 SELECT [EventId] AS EventId,
		[Name] AS Name,
		[Description] AS Description,
		[StageId] AS StageId,
		[Requirements] AS Requirements, 
		[Image] AS Image,
		[StartTime] AS StartTime,
		[EndTime] AS EndTime,
		[SeatsAvailableStandard] AS SeatsAvailableStandard,
		[SeatsAvailablePlus] AS SeatsAvailablePlus,
		[BasePrice] AS BasePrice,
		[EventTypeId] AS EventTypeId,
		[EventTypeName] AS EventTypeName

		FROM  
			(SELECT ROW_NUMBER() over (order by EventId) as RowNumber,  
				E.[EventId] AS EventId,
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
			FROM [Events] AS E, EventType AS T 
			WHERE E.EventTypeId = T.EventTypeId AND E.IsDeleted = 0) Eventos
		WHERE RowNumber >= @StartRowIndex and RowNumber <= @EndRowIndex  

		SELECT @TotalRows = COUNT(*) FROM [Events] WHERE IsDeleted = 0
END