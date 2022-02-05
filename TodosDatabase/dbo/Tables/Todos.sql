CREATE TABLE [dbo].[Todos]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Description] varchar(60) NOT NULL,
	[CreatedAt] datetime NOT NULL,
	[Deadline] datetime NOT NULL


)
