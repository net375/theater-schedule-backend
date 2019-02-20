CREATE TABLE [dbo].[Watchlist] (
    [AccountId]  INT NOT NULL,
    [PerformanceId] INT NOT NULL,
    CONSTRAINT [PK_Watchlist] PRIMARY KEY CLUSTERED ([AccountId] ASC, [PerformanceId] ASC),
    CONSTRAINT [FK_Watchlist_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_Watchlist_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);

