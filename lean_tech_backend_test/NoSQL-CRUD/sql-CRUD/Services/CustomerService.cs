using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using nosql_CRUD.Models;
using nosql_CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace nosql_CRUD.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration configuration;
        private readonly ICarrierService carrierService;
        private readonly IMongoCollection<Customers> customers;

        public CustomerService(IConfiguration configuration, ICarrierService carrierService)
        {
            this.configuration = configuration;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            customers = database.GetCollection<Customers>("customers");
        }

        public IList<Customers> GetAll()
        {
            try
            {
                return customers.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Customers Find(string id)
        {
            try
            {
                return customers.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customers Add(Customers model)
        {
            try
            {
                customers.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Customers model)
        {
            try
            {
                var result = customers.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = customers.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
