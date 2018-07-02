CREATE TABLE [dbo].[MaintenanceType]
(
	[typeId] INT IDENTITY NOT NULL PRIMARY KEY,
	[reminder] BIT NOT NULL DEFAULT 1,
	[timeSpan] INT
)
