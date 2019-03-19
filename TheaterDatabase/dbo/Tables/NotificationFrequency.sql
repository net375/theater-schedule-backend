CREATE TABLE [dbo].[NotificationFrequency]
(
	[NotificationFrequencyId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Frequency] INT NOT NULL --notify in n days
)
