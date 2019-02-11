CREATE TABLE [dbo].[Reply]
(
	[ReplyId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Text] NVARCHAR(200) NOT NULL,
	[MessageId] INT UNIQUE NOT NULL,
	CONSTRAINT [FK_Reply_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([MessageId])
)
