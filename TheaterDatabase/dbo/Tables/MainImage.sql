CREATE TABLE [dbo].[MainImage] (
    [MainImageId] INT             NOT NULL,
    [Image]       VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_MainImage] PRIMARY KEY CLUSTERED ([MainImageId] ASC)
);

