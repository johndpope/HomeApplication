using System;
using System.Data;
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
        ///<summary>
        ///
        ///</summary>
        ///<param name="meal"> The meal object being saved to the database</param>
        public void Save(Meal meal)
        {
            if (meal == null)
                throw new ArgumentNullException(nameof(meal), $"Cannot save a null {nameof(Meal)}.");

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SaveMeal";

                    command.Parameters.AddWithValue("@id", meal.mealId);
                    command.Parameters.AddWithValue("@name", meal.mealName);
                    command.ExecuteScalar();
                }
            }
        }
    }
}