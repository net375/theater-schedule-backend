CREATE TABLE [dbo].[PromoAction]
(
	[PromoActionId] INT IDENTITY(1,1) NOT NULL,
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL,
	CONSTRAINT [PK_PromoAction] PRIMARY KEY CLUSTERED ([PromoActionId] ASC),
)
