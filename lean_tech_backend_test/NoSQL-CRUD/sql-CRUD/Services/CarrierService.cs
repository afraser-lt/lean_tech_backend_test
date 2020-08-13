namespace sql_CRUD.Core
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using sql_CRUD.Models;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
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
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var carriersCollection = database.GetCollection<CarrierViewModel>("carriers");

                // Find a specific document with a filter
                if (id != null)
                {
                    var filter = Builders<CarrierViewModel>.Filter.Eq("Id", id);
                    var carriers = carriersCollection.Find(filter).ToList();
                    return carriers;
                }
                else
                {
                    var carriers = carriersCollection.Find(new BsonDocument()).ToList();
                    return carriers;
                }
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
        public string AddCarrier(CarrierViewModel carrier, int? id = null)
        {
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var carriers = database.GetCollection<CarrierViewModel>("carriers");

                // Update
                if (id != null)
                {
                    var _carrier = GetCarriers(id).FirstOrDefault();
                    if (_carrier != null)
                    {
                        var filter = Builders<CarrierViewModel>.Filter.Eq("ID", id);
                        var update = Builders<CarrierViewModel>.Update
                        .Set("NAME", carrier.Name ?? _carrier.Name)
                        .Set("SCAC", carrier.SCAC ?? _carrier.SCAC)
                        .Set("DOT", carrier.DOT ?? (Double.IsNaN((double)_carrier.DOT) ? null : _carrier.DOT))
                        .Set("MC", carrier.MC ?? (Double.IsNaN((double)_carrier.MC) ? null : _carrier.MC))
                        .Set("FEIN", carrier.FEIN ?? (Double.IsNaN((double)_carrier.FEIN) ? null : _carrier.FEIN));
                        var result = carriers.UpdateOne(filter, update);
                        return result.ModifiedCount > 0 ? "Carrier Updated" : "Carrier not found";
                    }
                    else
                    {
                        throw new Exception("The Carrier doesn't exists");
                    }
                }
                // Create
                else
                {
                    // Return the max id 
                    var maxId = carriers.Find(x => true).SortByDescending(d => d.Id).Limit(1).FirstOrDefaultAsync().Result.Id;
                    carrier.Id = maxId + 1;
                    carriers.InsertOne(carrier);
                    return "Carrier Added";
                }
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
        public string RemoveCarrier(int id)
        {
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var carriersCollection = database.GetCollection<CarrierViewModel>("carriers");

                var filter = Builders<CarrierViewModel>.Filter.Eq("Id", id);
                var result = carriersCollection.DeleteOne(filter);
                return result.DeletedCount > 0 ? "Carrier Deleted" : "Carrier not found";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
