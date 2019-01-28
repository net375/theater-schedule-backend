CREATE TABLE [dbo].[CreativePerson] (
    [CreativePersonId] INT           NOT NULL,
    [Profesion]        NVARCHAR (50) NOT NULL,
    [FistName]         NVARCHAR (50) NOT NULL,
    [LastName]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CreativePerson] PRIMARY KEY CLUSTERED ([CreativePersonId] ASC)
);

