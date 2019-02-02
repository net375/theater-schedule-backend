CREATE TABLE [dbo].[CreativeTeamMember_TR]
(
	[CreativeTeamMember_TRId] INT IDENTITY(1,1) NOT NULL,
	[LanguageId] INT NOT NULL,	
	[CreativeTeamMemberId] INT NOT NULL,
	[FistName] NVARCHAR (50) NOT NULL,
    [LastName] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_CreativeTeamMember_TR] PRIMARY KEY CLUSTERED ([CreativeTeamMember_TRId] ASC),
	CONSTRAINT [FK_CreativeTeamMember_TR_CreativeTeamMembeR] FOREIGN KEY ([CreativeTeamMemberId]) REFERENCES [dbo].[CreativeTeamMember]([CreativeTeamMemberId]),
	CONSTRAINT [FK_CreativeTeamMember_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
)
