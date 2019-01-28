CREATE TABLE [dbo].[Schedule] (
    [ScheduleId]    INT           NOT NULL,
    [Title]         NVARCHAR (25) NOT NULL,
    [Beginning]     DATETIME      NOT NULL,
    [PerformanceId] INT           NOT NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED ([ScheduleId] ASC),
    CONSTRAINT [FK_Performance_PerformanceDetails] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);

