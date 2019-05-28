CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientName] NVARCHAR(50) NOT NULL, 
    [Birthday] DATETIME NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [VisitDate] DATETIME NOT NULL, 
    [Service] NVARCHAR(50) NOT NULL, 
    [WorkerId] INT NOT NULL
)
