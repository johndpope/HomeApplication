using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Home.Server.Common;

namespace Home.Server.Cars
{
    public class CarRepository :  ICarRepository
    {
        private bool _typesLoaded = false;
        private List<MaintenanceType> _types = null;
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

        public async Task<CollectionResult<Maintenance>> GetMaintenance(int id)
        {
            List<Maintenance> results = new List<Maintenance>();
            Exception error = null;

            if (!_typesLoaded)
            {
                var result = await GetMaintenanceTypes();
                if (result.Error == null)
                    _types = result.Results;
                else
                    _types = new List<MaintenanceType>();
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "GetMaintenanceForCar";

                        command.Parameters.AddWithValue("@carId", id);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while(reader.Read())
                            {
                                results.Add(new Maintenance
                                {
                                    maintenanceId = reader.GetInt32(0),
                                    carId = reader.GetInt32(1),
                                    typeId = reader.GetInt32(2),
                                    date = reader.GetDateTime(3),
                                    kilometers = reader.GetInt32(4),
                                    type = _types.FirstOrDefault(x => x.typeId == reader.GetInt32(2))
                                });
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }

            return new CollectionResult<Maintenance> { Error = error, Results = results };
        }

        public async Task<CollectionResult<MaintenanceType>> GetMaintenanceTypes()
        {
            List<MaintenanceType> results = new List<MaintenanceType>();
            Exception error = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "GetMaintenanceTypes";

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                results.Add(new MaintenanceType()
                                {
                                    typeId = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    reminder = reader.GetBoolean(2),
                                    timeSpan = reader.GetInt32(3),
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
            return new CollectionResult<MaintenanceType> { Error = error, Results = results };
        }
    }
}