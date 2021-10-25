CREATE PROCEDURE [dbo].[Events_UpdateEvent]
	@EventId INT,
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

	UPDATE [dbo].[Events]
	SET

		[Name] = @Name
		,[Description] = @Description
		,[StageId] = @StageId
		,[Requirements] = @Requirements
		,[Image] = @Image
		,[StartTime] = @StartTime
		,[EndTime] = @EndTime
		,[SeatsAvailableStandard] = @SeatsAvailableStandard
		,[SeatsAvailablePlus] = @SeatsAvailablePlus
		,[BasePrice] = @BasePrice
		,[EventTypeId] = @EventTypeId
	WHERE 
		EventId = @EventId

END