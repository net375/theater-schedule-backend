CREATE TABLE [dbo].[MainImage] (
    [MainImageId] INT identity(1,1) NOT NULL,
    [Image]       VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_MainImage] PRIMARY KEY CLUSTERED ([MainImageId] ASC)
);

