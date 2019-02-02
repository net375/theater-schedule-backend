CREATE TABLE [dbo].[PerformanceCreativeTeamMember](
	[PerformanceCreativeTeamMemberId] INT IDENTITY(1,1) NOT NULL,
	[CreativeTeamMemberId] INT NOT NULL,
	[PerformanceId] INT NOT NULL,
	UNIQUE ([PerformanceCreativeTeamMemberId]),
	CONSTRAINT [PK_PerformanceCreativeTeamMember] PRIMARY KEY CLUSTERED ([CreativeTeamMemberId] ASC, [PerformanceId] ASC),
	CONSTRAINT [FK_PerformanceCreativeTeamMember_CreativeTeamMember] FOREIGN KEY ([CreativeTeamMemberId]) REFERENCES [dbo].[CreativeTeamMember] ([CreativeTeamMemberId]),
	CONSTRAINT [FK_PerformanceCreativeTeamMember_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId]),
);

