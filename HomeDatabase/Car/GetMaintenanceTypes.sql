CREATE PROCEDURE [dbo].[GetMaintenanceTypes]
AS
BEGIN
	SELECT [typeId], [name], [reminder], [timeSpan] FROM dbo.MaintenanceType
	RETURN
END
