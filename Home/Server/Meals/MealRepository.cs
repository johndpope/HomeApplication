using System;
using System.Data.SqlClient;

namespace Home.Server.Meals
{
    public class MealRepository : IMealRepository
    {
        private readonly string _connectionString;
        public MealRepository()
        {
            _connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HomeDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";
        }
        public void Save(Meal meal)
        {
            if (meal == null)
                throw new ArgumentNullException(nameof(meal), $"Cannot save a null {nameof(Meal)}.");
            
            if (meal.mealUid == Guid.Empty)
                throw new ArgumentException("Guid.Empty is not a valid identifier.", nameof(meal));

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                int? 
            }
        }
    }
}