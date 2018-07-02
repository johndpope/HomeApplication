CREATE TABLE [dbo].[Grocery]
(
	[groceryId] INTEGER IDENTITY NOT NULL PRIMARY KEY, 
    [groceryName] VARCHAR(MAX) NOT NULL, 
    [mealId] INTEGER NOT NULL, 
    CONSTRAINT [FK_Grocery_Meal] FOREIGN KEY ([mealId]) REFERENCES [Meal]([mealId])
)
