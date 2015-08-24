CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL IDENTITY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Phone] NVARCHAR(100) NOT NULL, 
    [Status] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id]) 
)
