CREATE TABLE Stage  
(  
	[StageId] INT IDENTITY (1, 1),
	[Description] VARCHAR(300) NOT NULL,
	[CapacitySeatsStandard] INT NOT NULL,
	[CapacitySeatsPlus] INT NOT NULL,
	[Image] VARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED ([StageId])
)