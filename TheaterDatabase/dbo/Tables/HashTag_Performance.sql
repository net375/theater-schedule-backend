CREATE TABLE [dbo].[HashTag_Performance] (
    [PerformanceId] INT NOT NULL,
    [HashTagId]     INT NOT NULL,
	[HashTagPerformanceID] INT IDENTITY(1,1) NOT NULL,
	UNIQUE CLUSTERED (HashTagPerformanceID ASC),
    CONSTRAINT [PK_HashTagPerformanceID] PRIMARY KEY NONCLUSTERED ([HashTagPerformanceID] ASC),
    CONSTRAINT [FK_HashTag_Performance_HashTag] FOREIGN KEY ([HashTagId]) REFERENCES [dbo].[HashTag] ([HashTagId]),
    CONSTRAINT [FK_HashTag_Performance_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);