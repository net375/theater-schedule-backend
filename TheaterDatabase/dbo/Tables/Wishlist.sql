CREATE TABLE [dbo].[Wishlist] (
    [AccountId]  INT NOT NULL,
    [PerformanceId] INT NOT NULL,
    CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED ([AccountId] ASC, [PerformanceId] ASC),
    CONSTRAINT [FK_Wishlist_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_Wishlist_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);

