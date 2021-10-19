CREATE TABLE Administrators  
(  
	[AdministratorId] INT IDENTITY (1, 1),
	[Name] VARCHAR(50) NOT NULL, 
	[LastName] VARCHAR(50) NOT NULL, 
	[Username] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(100) NOT NULL,
	[DocumentNumber] VARCHAR (50) NOT NULL,
	[Telephone] VARCHAR (15) NOT NULL,
	[IsDeleted] BIT CONSTRAINT [DF_IsDeleted] DEFAULT ((0)) NOT NULL,
	CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED ([AdministratorId]),
	CONSTRAINT [UN_UsernameAdministrators] UNIQUE ([Username])
) 