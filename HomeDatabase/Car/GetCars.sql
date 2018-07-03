CREATE PROCEDURE [dbo].[GetCars]
AS 
BEGIN
	SET NOCOUNT ON
	SELECT [carId], [make], [model], [year], [licensePlate], [enabled] FROM Car;
	RETURN 0
END