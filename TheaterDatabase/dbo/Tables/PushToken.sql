CREATE TABLE [dbo].[PushToken]
(
	[Token] VARCHAR(4096) NOT NULL PRIMARY KEY,
	[AccountId] INT NOT NULL,
	CONSTRAINT [FK_PushToken_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account]([AccountId])
)
