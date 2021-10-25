CREATE TABLE OrderLine  
(  
	[OrderLineId] INT IDENTITY (1, 1),
	[OrderId] INT NOT NULL,
	[EventId] INT NOT NULL,
	[Cost] INT NOT NULL,
	[SeatsStandard] INT NOT NULL,
	[SeatsPlus] INT NOT NULL,
	CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED ([OrderLineId]),
	CONSTRAINT [FK_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId]),
	CONSTRAINT [FK_Event] FOREIGN KEY ([EventId]) REFERENCES [Event] ([EventId])
)