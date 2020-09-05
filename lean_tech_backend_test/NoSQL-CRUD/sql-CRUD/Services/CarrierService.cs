namespace nosql_CRUD.Services
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using nosql_CRUD.Models;
    using nosql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarrierService : ICarrierService
    {
        private readonly IConfiguration configuration;
        private readonly IMongoCollection<Carriers> carriers;

        public CarrierService(IConfiguration configuration)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            carriers = database.GetCollection<Carriers>("carriers");
        }

        public IList<Carriers> GetAll()
        {
            try
            {
                return carriers.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Carriers Find(string id)
        {
            try
            {
                return carriers.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carriers Add(Carriers model)
        {
            try
            {
                carriers.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Carriers model)
        {
            try
            {
                var result = carriers.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = carriers.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
