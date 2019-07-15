CREATE TABLE [dbo].[ResetCode]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] INT NOT NULL,
	[AccountId] INT NOT NULL,
	[CreationTime] TIME NOT NULL,
	CONSTRAINT [FK_ResetCode_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
)