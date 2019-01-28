CREATE TABLE [dbo].[Account] (
    [AccountId] INT           NOT NULL,
    [Password]  NVARCHAR (60) NOT NULL,
    [Email]     NVARCHAR (60) NOT NULL,
    [FirstName] NVARCHAR (25) NOT NULL,
    [LastName]  NVARCHAR (25) NOT NULL,
    [Birthdate] DATE          NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId] ASC),   
    CONSTRAINT [FK_Account_Settings] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Settings] ([SettingsId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Email]
    ON [dbo].[Account]([Email] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account';

