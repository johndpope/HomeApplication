using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

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

        public async Task<List<Meal>> Get(int? id = null)
        {
            List<Meal> meals = new List<Meal>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (id != null)
                    {
                         command.CommandText = "GetMeal";
                         command.Parameters.AddWithValue("@id", id);
                    }
                    else
                        command.CommandText = "GetMeals";
                       
                    var result = await command.ExecuteReaderAsync();
                    
                    var meal = new Meal();
                    meal.mealId = result.GetInt32(0);
                    meal.mealName = result.GetString(1);
                    meal.enabled = result.GetBoolean(3);
                    meals.Add(meal);
                }
            }
            return meals;
        }

        public async Task Save(Meal meal)
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
                    command.Parameters.AddWithValue("@enabled", meal.enabled);
                    await command.ExecuteScalarAsync();
                }
            }
        }
    }
}