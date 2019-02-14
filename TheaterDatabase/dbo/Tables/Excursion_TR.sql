CREATE TABLE [dbo].[Excursion_TR]
(
	[Excursion_TRId] INT IDENTITY NOT NULL,
	[ExcursionName] NVARCHAR(50) NOT NULL,
	[ShortDescription] NVARCHAR(150) NOT NULL,
	[FullDescription] NVARCHAR(max) NOT NULL,
	[LanguageId] INT NOT NULL,
	[ExcursionId] INT NOT NULL,

	CONSTRAINT [FK_Excursion_TR_Excursion] FOREIGN KEY ([ExcursionId]) REFERENCES [dbo].[Excursion]([ExcursionId]),
	CONSTRAINT [FK_Excursion_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
	CONSTRAINT [PK_Excursion_TR] PRIMARY KEY CLUSTERED ([Excursion_TRId] ASC)
)
