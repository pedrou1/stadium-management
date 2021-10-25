CREATE PROCEDURE [dbo].[Events_AddEvent]
	@Name VARCHAR(50),
	@Description VARCHAR(100),
	@StageId INT,
	@Requirements VARCHAR(100),
	@Image VARCHAR(50),
	@StartTime DATETIME,
	@EndTime DATETIME,
	@SeatsAvailableStandard INT,
	@SeatsAvailablePlus INT,
	@BasePrice INT,
	@EventTypeId INT
AS
BEGIN

	INSERT INTO [dbo].[Events]
		([Name]
		,[Description]
		,[StageId]
		,[Requirements]
		,[Image] 
		,[StartTime]
		,[EndTime]
		,[SeatsAvailableStandard]
		,[SeatsAvailablePlus]
		,[BasePrice] 
		,[EventTypeId])
     VALUES
        (@Name,
		@Description,
		@StageId,
		@Requirements,
		@Image,
		@StartTime,
		@EndTime,
		@SeatsAvailableStandard,
		@SeatsAvailablePlus,
		@BasePrice,
		@EventTypeId)
 
END

