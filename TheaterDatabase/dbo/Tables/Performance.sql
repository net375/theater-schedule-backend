CREATE TABLE [dbo].[Performance] (
    [PerformanceId] INT NOT NULL,
	[MainImage]    VARBINARY (MAX) NOT NULL,
    [Duration]      INT  NOT NULL,
    [MinPrice]      INT  NOT NULL,
    [MaxPrice]      INT  NOT NULL,
    [MinimumAge]    INT  NOT NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED ([PerformanceId] ASC),
);

