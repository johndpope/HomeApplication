CREATE PROCEDURE [dbo].[SaveCar]
	@carId INT,
	@make VARCHAR(255),
	@model VARCHAR(255),
	@year INT,
	@licensePlate VARCHAR(255),
	@enabled BIT
AS
	-- check to see if the record has already been saved in the database
	DECLARE @id INT = (SELECT [carId] FROM Car WHERE [carId] = @carId);
	IF (@id IS NULL) -- if not, save it
		INSERT INTO Car 
			([make], [model], [year], [licensePlate], [enabled]) 
		OUTPUT
			inserted.carId
		VALUES 
			(@make, @model, @year, @licensePlate, @enabled)
			
	ELSE -- update the existing record
		UPDATE Car SET 
			[make] = @make,
			[model] = @model,
			[year] = @year,
			[licensePlate] = @licensePlate,
			[enabled] = @enabled
		WHERE [carId] = @carId;
RETURN 
