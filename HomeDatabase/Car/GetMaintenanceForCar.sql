CREATE PROCEDURE [dbo].[GetMaintenanceForCar]
	@carId int
AS
BEGIN
	SELECT [maintenanceId], [carId], [typeId], [date], [kilometers] FROM Maintenance WHERE [carid] = @carId
	RETURN
END