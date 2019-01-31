CREATE TABLE [dbo].[Performance] (
    [PerformanceId] INT identity(1,1) NOT NULL,
	[MainImage]    VARBINARY (MAX) NOT NULL,
    [Duration]      INT  NOT NULL,
    [MinPrice]      INT  NOT NULL,
    [MaxPrice]      INT  NOT NULL,
    [MinimumAge]    INT  NOT NULL,
    [Description]   TEXT NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED ([PerformanceId] ASC),
);

