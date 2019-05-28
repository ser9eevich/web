CREATE TABLE [dbo].[Workers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IndividualNumber] INT NOT NULL, 
    [WorkerName] NVARCHAR(50) NOT NULL, 
    [Position] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME NOT NULL
)
