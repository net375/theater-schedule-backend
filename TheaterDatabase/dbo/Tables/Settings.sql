CREATE TABLE [dbo].[Settings] (
    [SettingsId]  NVARCHAR(50) NOT NULL,
    [Language]   NVARCHAR (25) NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([SettingsId] ASC)
);

