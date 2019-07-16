CREATE TABLE [dbo].[AdminsPost]
(
	[AdminsPostId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Subject] NVARCHAR(50) NOT NULL, 
    [PostText] NVARCHAR(200) NOT NULL, 
    [PostDate] DATE NOT NULL, 
    [IsPersonal] BIT NOT NULL, 
    [ToUserId] INT NULL, 

    CONSTRAINT [FK_AdminsPost_Account] FOREIGN KEY ([ToUserId]) REFERENCES [dbo].[Account]([AccountId])
)
