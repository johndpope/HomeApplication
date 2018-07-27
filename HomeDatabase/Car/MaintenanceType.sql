CREATE TABLE [dbo].[MaintenanceType]
(
	[typeId] INT IDENTITY NOT NULL PRIMARY KEY,
	[name] VARCHAR(MAX) NOT NULL,
	[reminder] BIT NOT NULL DEFAULT 1,
	[timeSpan] INT
)
