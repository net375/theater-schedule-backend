CREATE TABLE [dbo].[Language]
(
	[LanguageId] INT IDENTITY(1,1) NOT NULL,
	[LanguageName] NVARCHAR(30) NOT NULL,
	 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED ([LanguageId] ASC),
)
