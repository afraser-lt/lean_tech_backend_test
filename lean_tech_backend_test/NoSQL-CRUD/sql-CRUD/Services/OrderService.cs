namespace nosql_CRUD.Services
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using nosql_CRUD.Models;
    using nosql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly IConfiguration configuration;
        private readonly IMongoCollection<Orders> orders;

        public OrderService(IConfiguration configuration)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            orders = database.GetCollection<Orders>("orders");
        }

        public IList<Orders> GetAll()
        {
            try
            {
                return orders.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Orders Find(string id)
        {
            try
            {
                return orders.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Orders Add(Orders model)
        {
            try
            {
                orders.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Orders model)
        {
            try
            {
                var result = orders.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = orders.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
