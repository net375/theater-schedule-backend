CREATE TABLE [dbo].[PerformanceCreativeTeamMember_TR]
(
	[PerformanceCreativeTeamMember_TRId] INT IDENTITY(1,1) NOT NULL,
	[Role] NVARCHAR(30) NOT NULL,
	[LanguageId] INT NOT NULL,	
	[PerformanceCreativeTeamMemberId] INT NOT NULL,
	CONSTRAINT [PK_PerformanceCreativeTeamMember_TR] PRIMARY KEY CLUSTERED ([PerformanceCreativeTeamMember_TRId] ASC),
	CONSTRAINT [FK_PerformanceCreativeTeamMember_TR_PerformanceCreativeTeamMember] FOREIGN KEY ([PerformanceCreativeTeamMemberId]) REFERENCES [dbo].[PerformanceCreativeTeamMember]([PerformanceCreativeTeamMemberId]),
	CONSTRAINT [FK_PerformanceCreativeTeamMember_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
)
