CREATE TABLE [dbo].[HashTag_Performance] (
    [PerformanceDetailsId] INT NOT NULL,
    [HashTagId]            INT NOT NULL,
    CONSTRAINT [PK_HashTag_PerformanceDetails] PRIMARY KEY CLUSTERED ([PerformanceDetailsId] ASC, [HashTagId] ASC),
    CONSTRAINT [FK_HashTag_PerformanceDetails_HashTag] FOREIGN KEY ([HashTagId]) REFERENCES [dbo].[HashTag] ([HashTagId]),
    CONSTRAINT [FK_HashTag_PerformanceDetails_PerformanceDetails] FOREIGN KEY ([PerformanceDetailsId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);

