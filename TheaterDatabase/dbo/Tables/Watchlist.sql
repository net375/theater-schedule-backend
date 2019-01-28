CREATE TABLE [dbo].[Watchlist] (
    [AccountId]  INT NOT NULL,
    [ScheduleId] INT NOT NULL,
    CONSTRAINT [PK_Watchlist] PRIMARY KEY CLUSTERED ([AccountId] ASC, [ScheduleId] ASC),
    CONSTRAINT [FK_Watchlist_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_Watchlist_Schedule] FOREIGN KEY ([ScheduleId]) REFERENCES [dbo].[Schedule] ([ScheduleId])
);

