CREATE TABLE [dbo].[HashTag_TR]
(
	[HashTag_TRId] INT IDENTITY(1,1) NOT NULL,	
	[Tag] NVARCHAR(30) NOT NULL,
	[LanguageId] INT NOT NULL,
	[HashTagId] INT NOT NULL,
	CONSTRAINT [PK_HashTag_TR] PRIMARY KEY CLUSTERED ([HashTag_TRId] ASC),
	CONSTRAINT [FK_HashTag_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
	CONSTRAINT [FK_HashTag_TR_HashTag] FOREIGN KEY ([HashTagId]) REFERENCES [dbo].[HashTag]([HashTagId]),
)
