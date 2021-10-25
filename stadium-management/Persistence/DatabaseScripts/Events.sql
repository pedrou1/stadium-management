CREATE TABLE [Events]
(  
	[EventId] INT IDENTITY (1, 1),
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(300) NOT NULL,
	[EventTypeId] INT NOT NULL,
	[StageId] INT NOT NULL,
	[Requirements] VARCHAR(300) NOT NULL,
	[Image] VARCHAR(100) NOT NULL,
	[StartTime] DATETIME NOT NULL,
	[EndTime] DATETIME NOT NULL,
	[SeatsAvailableStandard] INT NOT NULL,
	[SeatsAvailablePlus] INT NOT NULL,
	[BasePrice] INT NOT NULL,
	[IsDeleted] BIT CONSTRAINT [DFE_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventId]),
	CONSTRAINT [FK_EventType] FOREIGN KEY ([EventTypeId]) REFERENCES EventType ([EventTypeId]),
	CONSTRAINT [FK_Stage] FOREIGN KEY (StageId) REFERENCES Stage ([StageId])
)