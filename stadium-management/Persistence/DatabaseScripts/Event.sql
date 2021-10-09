CREATE TABLE Event  
(  
	[EventId] INT IDENTITY (1, 1),
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(300) NOT NULL,
	[EventTypeId] INT NOT NULL,
	[Requirements] VARCHAR(300) NOT NULL,
	[Price] INT NOT NULL,
	[Logo] VARCHAR(80) NOT NULL,
	[IsDeleted] BIT CONSTRAINT [DF_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventId]),
	CONSTRAINT [FK_EventType] FOREIGN KEY ([EventTypeId]) REFERENCES EventType ([EventTypeId])
)