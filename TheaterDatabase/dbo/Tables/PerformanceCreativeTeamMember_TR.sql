CREATE TABLE [dbo].[PerformanceCreativeTeamMember_TR]
(
	[PerformanceCreativeTeamMember_TRId] INT IDENTITY(1,1) NOT NULL,	
	[PerformanceCreativeTeamMemberId] INT NOT NULL,
	[Role_TRId] INT NOT NULL,

	CONSTRAINT [PK_PerformanceCreativeTeamMember_TR] PRIMARY KEY CLUSTERED ([PerformanceCreativeTeamMember_TRId] ASC),
	CONSTRAINT [FK_PerformanceCreativeTeamMember_TR_PerformanceCreativeTeamMember] FOREIGN KEY ([PerformanceCreativeTeamMemberId]) REFERENCES [dbo].[PerformanceCreativeTeamMember]([PerformanceCreativeTeamMemberId]),
	CONSTRAINT [FK_PerformanceCreativeTeamMember_TR_Role_TR] FOREIGN KEY ([Role_TRId]) REFERENCES [dbo].[Role_TR]([Role_TRId]),
)
