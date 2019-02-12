CREATE TABLE [dbo].[PromoAction_TR]
(
	[PromoAction_TRId] INT IDENTITY(1,1) NOT NULL,
	[Description] NVARCHAR(max) NOT NULL,
	[PromoActionName] NVARCHAR(50) NOT NULL,
	[LanguageId] INT NOT NULL,
	[PromoActionId] INT NOT NULL,
	CONSTRAINT [FK_PromoAction_TR_PromoAction] FOREIGN KEY ([PromoActionId]) REFERENCES [dbo].[PromoAction]([PromoActionId]),
	CONSTRAINT [FK_PromoAction_TR_Language] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language]([LanguageId]),
	CONSTRAINT [PK_PromoAction_TR] PRIMARY KEY CLUSTERED ([PromoAction_TRId] ASC),
)
