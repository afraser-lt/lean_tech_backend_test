namespace nosql_CRUD.Services
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using nosql_CRUD.Models;
    using nosql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ReceiverService : IReceiverService
    {
        private readonly IConfiguration configuration;
        private readonly IMongoCollection<Receivers> receivers;

        public ReceiverService(IConfiguration configuration)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            receivers = database.GetCollection<Receivers>("receivers");
        }

        public IList<Receivers> GetAll()
        {
            try
            {
                return receivers.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Receivers Find(string id)
        {
            try
            {
                return receivers.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Receivers Add(Receivers model)
        {
            try
            {
                receivers.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Receivers model)
        {
            try
            {
                var result = receivers.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = receivers.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
