CREATE TABLE Clients  
(  
	[ClientId] INT IDENTITY (1, 1),
	[Name] VARCHAR(50) NOT NULL, 
	[LastName] VARCHAR(50) NOT NULL, 
	[Username] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(100) NOT NULL,
	[IsDeleted] BIT CONSTRAINT [DF_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ClientId]),
	CONSTRAINT [UN_UsernameClients] UNIQUE ([Username])
) 