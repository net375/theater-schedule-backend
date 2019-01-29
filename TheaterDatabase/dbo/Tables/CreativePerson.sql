CREATE TABLE [dbo].[CreativePerson] (
    [CreativePersonId] INT identity(1,1) NOT NULL,
    [Profesion]        NVARCHAR (50) NOT NULL,
    [FistName]         NVARCHAR (50) NOT NULL,
    [LastName]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CreativePerson] PRIMARY KEY CLUSTERED ([CreativePersonId] ASC)
);

