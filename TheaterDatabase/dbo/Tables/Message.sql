CREATE TABLE [dbo].[Message]
(
	[MessageId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Subject] NVARCHAR(50) NOT NULL,
	[MessageText] NVARCHAR(200) NOT NULL,
	[ReplyText] NVARCHAR(200) NULL,
	[AccountId] INT NOT NULL,
     
    CONSTRAINT [FK_Message_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
)
