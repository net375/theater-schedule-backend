
CREATE TABLE [dbo].[RefreshTokens](
	[DaysToExpire] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,	
	[IsActive] [BIT] NOT NULL,
	[RefreshToken] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	CONSTRAINT [FK_RefreshToken_Account]  FOREIGN KEY ([UserId]) REFERENCES [dbo].[Account] ([AccountId]) on delete cascade,
 CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
