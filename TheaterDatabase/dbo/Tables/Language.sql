CREATE TABLE [dbo].[Language]
(
	[LanguageId] INT IDENTITY(1,1) NOT NULL,
	
	 [LanguageCode] NVARCHAR(3) NOT NULL, 
    CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED ([LanguageId] ASC),
)
