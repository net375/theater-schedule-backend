CREATE TABLE [dbo].[Performance] (
    [PerformanceId] INT identity(1,1) NOT NULL,
	[MainImage]    VARBINARY (MAX) NOT NULL,
    [Duration]      INT  NOT NULL,
    [MinPrice]      INT  NOT NULL,
    [MaxPrice]      INT  NOT NULL,
    [MinimumAge]    INT  NOT NULL,
    [Description]   TEXT NULL,
    [MainImageId]   INT  NOT NULL,
    [ProducerId]    INT  NULL,
    [AuthorId]      INT  NULL,
    [ArtistId]      INT  NULL,
    [ComposerId]    INT  NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY CLUSTERED ([PerformanceId] ASC),
);

