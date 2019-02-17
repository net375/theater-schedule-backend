CREATE TABLE [dbo].[Performance_TR]
(
	[Performance_TRId] INT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[LanguageId] INT NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	[PerformanceId] INT NOT NULL,
	CONSTRAINT [PK_Performance_TR] PRIMARY KEY CLUSTERED ([Performance_TRId] ASC),
	CONSTRAINT [FK_Performance_TR_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance]([PerformanceId]),
	CONSTRAINT [FK_Performance_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId])
)
