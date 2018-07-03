using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Home.Server.Common;

namespace Home.Server.Cars
{
    public class CarRepository :  ICarRepository
    {
        private readonly string _connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HomeDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True";
        public async Task<DataResult<Car>> Get(int id)
        {
            Car result = null;
            Exception error = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "GetCar";

                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            reader.Read();
                            result = new Car()
                            {
                                carId = reader.GetInt32(0),
                                make = reader.GetString(1),
                                model = reader.GetString(2),
                                year = reader.GetInt32(3),
                                licensePlate = reader.GetString(4),
                                enabled = reader.GetBoolean(5)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return new DataResult<Car> { Error = error, Result = result };
        }

        public async Task<CollectionResult<Car>> GetAll()
        {
            List<Car> results = new List<Car>();
            Exception error = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "GetCars";

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Car()
                                {
                                    carId = reader.GetInt32(0),
                                    make = reader.GetString(1),
                                    model = reader.GetString(2),
                                    year = reader.GetInt32(3),
                                    licensePlate = reader.GetString(4),
                                    enabled = reader.GetBoolean(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex;   
            }
            return new CollectionResult<Car> { Error = error, Results = results };
        }

        public async Task<OperationResult> Save(Car car)
        {
            Exception error = null;
            try
            {
                if (car == null)
                    throw new ArgumentNullException(nameof(car), $"Cannot save a null {nameof(Car)}.");

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SaveCar";

                        command.Parameters.AddWithValue("@carId", car.carId);
                        command.Parameters.AddWithValue("@make", car.make);
                        command.Parameters.AddWithValue("@model", car.model);
                        command.Parameters.AddWithValue("@year", car.year);
                        command.Parameters.AddWithValue("@licensePlate", car.licensePlate);
                        command.Parameters.AddWithValue("@enabled", car.enabled);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return new OperationResult { Error = error };
        }
    }
}