CREATE TABLE [dbo].[Schedule_TR]
(
	[Schedule_TRId] INT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(30) NOT NULL,
	[LanguageId] INT NOT NULL,
	[ScheduleId] INT NOT NULL,
	CONSTRAINT [PK_Schedule_TR] PRIMARY KEY CLUSTERED ([Schedule_TRId] ASC),
	CONSTRAINT [FK_Schedule_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
	CONSTRAINT [FK_Schedule_TR_Schedule] FOREIGN KEY ([ScheduleId]) REFERENCES [dbo].[Schedule]([ScheduleId]),
)
