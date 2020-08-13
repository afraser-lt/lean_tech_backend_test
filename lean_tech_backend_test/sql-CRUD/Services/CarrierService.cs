namespace sql_CRUD.Core
{
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.Models;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class CarrierService : ICarrierService
    {
        private readonly IConfiguration configuration;

        public CarrierService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<CarrierViewModel> GetCarriers(int? id = null)
        {
            var carriers = new List<CarrierViewModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration["ConnectionString"]))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[sp_getCarriers]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id",id ?? (Object)DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var carrier = new CarrierViewModel();
                                carrier.Id = reader.GetInt32("id");
                                carrier.Name = reader.GetString("name");
                                carrier.SCAC = reader.GetString("scac");
                                carrier.MC = reader["mc"] != DBNull.Value ? reader.GetInt32("mc") : 0; ;
                                carrier.DOT = reader["dot"] != DBNull.Value ? reader.GetInt32("dot") : 0;
                                carrier.FEIN = reader["fein"] != DBNull.Value ? reader.GetInt32("fein") : 0;
                                carriers.Add(carrier);
                            }
                        }
                    }
                    connection.Close();
                }
                return carriers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public int AddCarrier(CarrierViewModel carrier, int? id = null)
        {
            var result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration["ConnectionString"]))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[sp_addCarrier]", connection))
                    {
                        // Get current carrier values
                        var _carrier = new CarrierViewModel();
                        command.CommandType = CommandType.StoredProcedure;

                        // Update
                        if (id != null)
                        {
                            _carrier = GetCarriers(id).FirstOrDefault();
                            if (_carrier != null)
                            {
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@name", carrier.Name ?? (_carrier.Name ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@scac", carrier.SCAC ?? (_carrier.SCAC ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@dot", carrier.DOT ?? (_carrier.DOT ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@mc", carrier.MC ?? (_carrier.MC ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@fein", carrier.FEIN ?? (_carrier.FEIN ?? (Object)DBNull.Value));
                            }
                            else
                            {
                                throw new Exception("The Carrier doesn't exists");
                            }
                        }
                        // Create
                        else
                        {
                            command.Parameters.AddWithValue("@id", carrier.Id ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@name", carrier.Name);
                            command.Parameters.AddWithValue("@scac", carrier.SCAC ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@dot", carrier.DOT ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@mc", carrier.MC ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@fein", carrier.FEIN ?? (Object)DBNull.Value);
                        }
                        result = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveCarrier(int id)
        {
            var result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration["ConnectionString"]))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[sp_removeCarrier]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id);
                        result = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
