﻿CREATE TABLE [dbo].[Event]
(
	[EventId] INT IDENTITY NOT NULL,
	[Image] VARBINARY (MAX) NOT NULL,
	[Date] DATETIME NOT NULL,

	CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventId] ASC)
)
