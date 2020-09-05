namespace API_EIA.Services
{
    using API_EIA.Models;
    using API_EIA.Services.Interfaces;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SerieService : ISerieService
    {
        private readonly IConfiguration configuration;
        private readonly IMongoCollection<Serie> series;

        public SerieService(IConfiguration configuration)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration.GetConnectionString("MongoConnectionString"));
            IMongoDatabase database = client.GetDatabase("Test");
            series = database.GetCollection<Serie>("series");
        }

        public IList<Serie> GetAll()
        {
            try
            {
                return series.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Serie Find(string id)
        {
            try
            {
                return series.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Serie Add(Serie model)
        {
            try
            {
                series.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Serie model)
        {
            try
            {
                var result = series.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = series.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
