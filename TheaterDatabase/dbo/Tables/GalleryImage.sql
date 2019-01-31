CREATE TABLE [dbo].[GalleryImage] (
    [GalleryImageId] INT identity(1,1) NOT NULL,
    [Image]          VARBINARY (MAX) NOT NULL,
    [PerformanceId]  INT             NULL,
    CONSTRAINT [PK_GalleryImage] PRIMARY KEY CLUSTERED ([GalleryImageId] ASC),
    CONSTRAINT [FK_GalleryImage_Performance] FOREIGN KEY ([PerformanceId]) REFERENCES [dbo].[Performance] ([PerformanceId])
);

