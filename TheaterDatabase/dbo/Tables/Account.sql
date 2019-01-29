CREATE TABLE [dbo].[Account] (
    [AccountId] INT	identity(1,1) NOT NULL,
    [Password]  NVARCHAR (60) NULL,
    [Email]     NVARCHAR (60) NULL,
    [FirstName] NVARCHAR (25) NULL,
    [LastName]  NVARCHAR (25) NULL,
    [Birthdate] DATE          NULL,
	[PhoneIdentifier] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId] ASC),   
    CONSTRAINT [FK_Account_Settings] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Settings] ([SettingsId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Email]
    ON [dbo].[Account]([Email] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account';

