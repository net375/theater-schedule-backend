CREATE TABLE [dbo].[Message]
(
	[MessageId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Subject] NVARCHAR(50) NOT NULL,
	[Text] NVARCHAR(200) NOT NULL,
	[AccountId] INT NOT NULL,
	[ReplyId] INT NULL,
    CONSTRAINT [FK_Message_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
	CONSTRAINT [FK_Message_Reply] FOREIGN KEY ([ReplyId]) REFERENCES [dbo].[Reply] ([ReplyId])
)

GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Reply]
    ON [dbo].[Message]([ReplyId])
    WHERE [ReplyId] IS NOT NULL
