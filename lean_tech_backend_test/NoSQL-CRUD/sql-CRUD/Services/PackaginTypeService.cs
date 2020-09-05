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

    public class PackaginType : IPackaginTypeService
    {
        private readonly IConfiguration configuration;
        private readonly IMongoCollection<PackaginTypes> packaginTypes;

        public PackaginType(IConfiguration configuration)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            packaginTypes = database.GetCollection<PackaginTypes>("packaginTypes");
        }

        public IList<PackaginTypes> GetAll()
        {
            try
            {
                return packaginTypes.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PackaginTypes Find(string id)
        {
            try
            {
                return packaginTypes.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PackaginTypes Add(PackaginTypes model)
        {
            try
            {
                packaginTypes.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(PackaginTypes model)
        {
            try
            {
                var result = packaginTypes.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = packaginTypes.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
