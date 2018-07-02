CREATE TABLE [dbo].[Maintenance]
(
	[maintenanceId] INT IDENTITY NOT NULL PRIMARY KEY,
	[carId] INT NOT NULL, 
	[typeId] INT NOT NULL,
	[date] DATE NOT NULL,
	[kilometers] INT NOT NULL,
    CONSTRAINT [FK_Maintenance_ToCar] FOREIGN KEY ([carId]) REFERENCES [Car]([carId]),
	CONSTRAINT [FK_Maintenance_ToType] FOREIGN KEY ([typeId]) REFERENCES [MaintenanceType]([typeId])
)
