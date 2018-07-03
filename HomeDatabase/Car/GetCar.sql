CREATE PROCEDURE [dbo].[GetCar]
	@id int
AS
	SELECT [carId], [make], [model], [year], [licensePlate] [enabled] FROM Car WHERE carId = @id;
RETURN 0
