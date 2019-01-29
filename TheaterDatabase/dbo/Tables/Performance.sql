CREATE TABLE [dbo].[Performance] (
    [PerformanceId] INT identity(1,1) NOT NULL,
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
    CONSTRAINT [PK_PerformanceDetails] PRIMARY KEY CLUSTERED ([PerformanceId] ASC),
    CONSTRAINT [FK_Performance_CreativePerson] FOREIGN KEY ([ProducerId]) REFERENCES [dbo].[CreativePerson] ([CreativePersonId]),
    CONSTRAINT [FK_Performance_CreativePerson1] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[CreativePerson] ([CreativePersonId]),
    CONSTRAINT [FK_Performance_CreativePerson2] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[CreativePerson] ([CreativePersonId]),
    CONSTRAINT [FK_Performance_CreativePerson3] FOREIGN KEY ([ComposerId]) REFERENCES [dbo].[CreativePerson] ([CreativePersonId]),
    CONSTRAINT [FK_Performance_MainImage] FOREIGN KEY ([MainImageId]) REFERENCES [dbo].[MainImage] ([MainImageId])
);

