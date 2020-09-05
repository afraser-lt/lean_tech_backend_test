using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using sql_CRUD.MyModels;
using sql_CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace sql_CRUD.Core
{
    public class ShipmentService : IShipmentSerivice
    {
        private readonly IConfiguration configuration;
        private readonly ICarrierService carrierService;

        public ShipmentService(IConfiguration configuration, ICarrierService carrierService)
        {
            this.configuration = configuration;
            this.carrierService = carrierService;
        }

        public int Add(Shipments model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.Shipments.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Shipments Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipment = context.Shipments.Where(c => c.Id == id).FirstOrDefault();
                    return shipment;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Shipments> GetAll()
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipment = context.Shipments.ToList();
                    return shipment;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Remove(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipment = context.Shipments.Where(c => c.Id == id).FirstOrDefault();
                    context.Shipments.Remove(shipment);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Shipments model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipment = context.Shipments.Update(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find data by criteria in shipments table
        /// </summary>
        /// <param name="q">Words</param>
        /// <param name="date">Date</param>
        /// <returns>IList<Shipments></returns>
        public IList<Shipments> FindByCriteria(string q, DateTime? date)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    // todo: separate terms by space
                    var words = q.Split(' ').Select(w => $"'\"{w}\"'" + " AND ").ToString();
                    
                    var dateFiter = (date != null) ? $" Date = N'{date}' AND" : "";

                    // Note: Must have installed full-text search on the database and created the catalog for each table column
                    var shipments = context.Shipments.FromSqlRaw($"SELECT * FROM dbo.shipments WHERE {dateFiter} CONTAINS(*, {words});").ToList();
                    return shipments;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public int AddShipment(ShipmentViewModel shipment, int? id = null)
        {
            var result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration["ConnectionString"]))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand("[dbo].[sp_addShipment]", connection))
                    {
                        // Get current carrier values
                        var _shipmen = new ShipmentViewModel();
                        command.CommandType = CommandType.StoredProcedure;

                        // Update
                        if (id != null)
                        {
                            // Validate if the Carrier exists
                            if(shipment.Carrier != null)
                            {
                                var _carrier = carrierService.GetCarriers(shipment.Carrier.Id).FirstOrDefault();
                                if(_carrier == null) throw new Exception("The Carrier doesn't exists");
                            }

                            _shipmen = GetShipments(id).FirstOrDefault();
                            if (_shipmen != null)
                            {
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@carrierId", shipment.Carrier.Id ?? (_shipmen.Carrier.Id ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@date", shipment.Date ?? (_shipmen.Date ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@originCountry", shipment.OriginCountry ?? (_shipmen.OriginCountry ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@originState", shipment.OriginState ?? (_shipmen.OriginState ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@destinationCountry", shipment.DestinationCountry ?? (_shipmen.DestinationCountry ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@destinationState", shipment.DestinationState ?? (_shipmen.DestinationState ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@destinationCity", shipment.DestinationCity ?? (_shipmen.DestinationCity ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@pickupDate", shipment.PickupDate ?? (_shipmen.PickupDate ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@deliveryDate", shipment.DeliveryDate ?? (_shipmen.DeliveryDate ?? (Object)DBNull.Value));
                                command.Parameters.AddWithValue("@status", shipment.Status ?? (_shipmen.Status ?? (Object)DBNull.Value));
                                //command.Parameters.AddWithValue("@carrierRate", shipment.CarrierRate ?? (_shipmen.CarrierRate ?? (Object)DBNull.Value));
                            }
                            else
                            {
                                throw new Exception("The Shipment doesn't exists");
                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@id", shipment.Id ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@carrierId", shipment.Carrier.Id ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@date", shipment.Date ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@originCountry", shipment.OriginCountry ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@originState", shipment.OriginState ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@destinationCountry", shipment.DestinationCountry ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@destinationState", shipment.DestinationState ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@destinationCity", shipment.DestinationCity ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@pickupDate", shipment.PickupDate ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@deliveryDate", shipment.DeliveryDate ?? (Object)DBNull.Value);
                            command.Parameters.AddWithValue("@status", shipment.Status ?? (Object)DBNull.Value);
                            //command.Parameters.AddWithValue("@carrierRate", shipment.CarrierRate ?? (Object)DBNull.Value);
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
        */

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<ShipmentViewModel> GetShipments(int? id = null)
        {
            var Shipments = new List<ShipmentViewModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration["ConnectionString"]))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[sp_getShipment]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                                
                                var Shipment = new ShipmentViewModel();
                                Shipment.Id = reader.GetInt32("id");
                                Shipment.Carrier = carrierService.GetCarriers(reader.GetInt32("carrier_id")).FirstOrDefault();
                                Shipment.Date = reader["date"] != DBNull.Value ? reader.GetDateTime("date") : (DateTime?)null;
                                Shipment.OriginCountry = reader.GetString("originCountry");
                                Shipment.OriginState = reader.GetString("OriginState");
                                Shipment.DestinationCountry = reader.GetString("destinationCountry");
                                Shipment.DestinationState = reader.GetString("destinationState");
                                Shipment.DestinationCity = reader.GetString("destinationCity");
                                Shipment.PickupDate = reader["pickupDate"] != DBNull.Value ? reader.GetDateTime("pickupDate") : (DateTime?)null;
                                Shipment.DeliveryDate = reader["deliveryDate"] != DBNull.Value ? reader.GetDateTime("deliveryDate") : (DateTime?)null;
                                Shipment.Status = reader.GetString("status");
                                //Shipment.CarrierRate = reader["carrierRate"] != DBNull.Value ? reader.GetDecimal("carrierRate") : 0;
                                Shipments.Add(Shipment);
                            }
                        }
                    }
                    connection.Close();
                }
                return Shipments;
            }
            catch (Exception)
            {
                throw;
            }
        }
        */

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveShipment(int id)
        {
            var result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration["ConnectionString"]))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[sp_removeShipment]", connection))
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
        */
    }
}
