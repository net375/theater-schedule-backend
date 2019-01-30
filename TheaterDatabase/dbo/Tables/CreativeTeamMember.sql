CREATE TABLE [dbo].[CreativeTeamMember] (
    [CreativeTeamMemberId] INT identity(1,1) NOT NULL,
    [Profesion]        NVARCHAR (50) NOT NULL,
    [FistName]         NVARCHAR (50) NOT NULL,
    [LastName]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CreativeTeamMember] PRIMARY KEY CLUSTERED ([CreativeTeamMemberId] ASC)
);

