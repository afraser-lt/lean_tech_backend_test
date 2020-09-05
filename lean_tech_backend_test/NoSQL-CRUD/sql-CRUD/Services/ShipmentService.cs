using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using nosql_CRUD.Models;
using nosql_CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nosql_CRUD.Services
{
    public class ShipmentService : IShipmentSerivice
    {
        private readonly IConfiguration configuration;
        //private readonly ICarrierService carrierService;
        private readonly IMongoCollection<Shipments> shipments;
        private readonly IMongoCollection<Carriers> carriers;

        public ShipmentService(IConfiguration configuration)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            shipments = database.GetCollection<Shipments>("shipments");
            carriers = database.GetCollection<Carriers>("carriers");
        }

        public IList<Shipments> GetAll()
        {
            try
            {
                var result = shipments.Find(m => true).ToList();
                result.ForEach(c => c.Carrier = carriers.AsQueryable().Where(x => c.Carrier.Id == x.Id).FirstOrDefault());
                return result;
                //return shipments.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Shipments Find(string id)
        {
            try
            {
                var result = shipments.Find(m => m.Id == id).FirstOrDefault();
                result.Carrier = carriers.AsQueryable().Where(x => result.Carrier.Id == x.Id).FirstOrDefault();
                return result;
                //return shipments.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Shipments Add(Shipments model)
        {
            try
            {
                shipments.InsertOne(model);
                return model;
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
                var result = shipments.ReplaceOne(m => m.Id == model.Id, model);
                return int.Parse(result.ModifiedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Remove(string id)
        {
            try
            {
                var result = shipments.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
