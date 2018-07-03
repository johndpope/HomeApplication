using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Home.Server.Common;

namespace Home.Server.Meals
{
    public class MealRepository //: IMealRepository
    {
        ///<summary>
        ///
        ///</summary>
        ///<param name="meal"> The meal object being saved to the database</param>
        private readonly string _connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HomeDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";
        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Save(object data)
        {
            Meal meal = data as Meal;
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
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}