CREATE TABLE [dbo].[Settings] (
    [SettingsId] INT           NOT NULL,
    [Language]   NVARCHAR (25) NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([SettingsId] ASC)
);

