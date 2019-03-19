CREATE TABLE [dbo].[Settings] (
    [SettingsId] INT identity(1,1) NOT NULL,
    [LanguageId] INT NOT NULL,
	[DoesNotify] BIT NOT NULL,
	[NotificationFrequencyId] INT NOT NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([SettingsId] ASC),
	CONSTRAINT [FK_Settings_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
	CONSTRAINT [FK_Settings_NotificationFrequency] FOREIGN KEY ([NotificationFrequencyId]) REFERENCES [dbo].[NotificationFrequency]([NotificationFrequencyId])
);
