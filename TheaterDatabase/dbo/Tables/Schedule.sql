CREATE TABLE [dbo].[Schedule] (
    [ScheduleId]    INT identity(1,1) NOT NULL,
    [Title]         NVARCHAR (25) NOT NULL,
    [Beginning]     DATETIME      NOT NULL,
    [PerformanceId] INT           NOT NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED ([ScheduleId] ASC),
    CONSTRAINT [FK_Schedule_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);

