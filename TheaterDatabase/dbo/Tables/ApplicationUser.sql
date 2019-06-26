CREATE TABLE [dbo].[ApplicationUser](
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetimeoffset](7) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](550) NOT NULL,
	[PasswordSalt] [nvarchar](500) NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

