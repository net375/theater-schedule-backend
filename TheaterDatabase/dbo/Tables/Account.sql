﻿CREATE TABLE [dbo].[Account] (
    [AccountId] INT	identity(1,1) NOT NULL,
    [Password]  NVARCHAR (60) NULL,
    [Email]     NVARCHAR (60) NULL,
    [FirstName] NVARCHAR (25) NULL,
    [LastName]  NVARCHAR (25) NULL,
    [Birthdate] DATE          NULL,
	[PhoneIdentifier] NVARCHAR(50) UNIQUE NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId] ASC),   
    CONSTRAINT [FK_Account_Settings] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Settings] ([SettingsId])
);

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account';

