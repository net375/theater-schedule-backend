CREATE TABLE [dbo].[Account] (
    [AccountId] INT	identity(1,1) NOT NULL,
	[PasswordHash] [nvarchar](550) NOT NULL,
	[PasswordSalt] [nvarchar](500) NOT NULL,    
	[Email]     NVARCHAR (60) NOT NULL,
    [FirstName] NVARCHAR (25) NOT NULL,
    [LastName]  NVARCHAR (25) NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NULL,
    [Birthdate] DATE          NOT NULL,
	[PhoneIdentifier] NVARCHAR(40) UNIQUE NOT NULL,
	[SettingsId] INT  UNIQUE NULL,
    [PnoneNumber] NCHAR(15) NULL, 
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId] ASC),   
    CONSTRAINT [FK_Account_Settings]  FOREIGN KEY ([SettingsId]) REFERENCES [dbo].[Settings] ([SettingsId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_Email]
    ON [dbo].[Account]([Email] ASC)
    WHERE [Email] IS NOT NULL

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account';