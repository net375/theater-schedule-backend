CREATE TABLE [dbo].[Event_TR]
(
	[Event_TRId] INT IDENTITY NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[ShortDescription] NVARCHAR(150) NOT NULL,
	[FullDescription] NVARCHAR(max) NOT NULL,
	[Type] NVARCHAR(50) NOT NULL,
	[LanguageId] INT NOT NULL,
	[EventId] INT NOT NULL,

	CONSTRAINT [FK_Event_TR_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event]([EventId]),
	CONSTRAINT [FK_Event_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
	CONSTRAINT [PK_Event_TR] PRIMARY KEY CLUSTERED ([Event_TRId] ASC)
)
