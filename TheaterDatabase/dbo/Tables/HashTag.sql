CREATE TABLE [dbo].[HashTag] (
    [HashTagId] INT identity(1,1) NOT NULL,
    [Tag]       NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_HashTag] PRIMARY KEY CLUSTERED ([HashTagId] ASC)
);

