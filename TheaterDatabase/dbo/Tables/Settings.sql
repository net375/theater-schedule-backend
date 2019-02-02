CREATE TABLE [dbo].[Settings] (

    [SettingsId]  NVARCHAR(50) NOT NULL,
    [LanguageId] INT NOT NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([SettingsId] ASC)

);

