namespace nosql_CRUD.Services
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using nosql_CRUD.Models;
    using nosql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BOLService : IBOLService
    {
        private readonly IConfiguration configuration;
        private readonly ICustomerOderService customerOderService;
        private readonly IShipmentSerivice shipmentSerivice;
        private readonly IMongoCollection<Bols> bols;
        private readonly IMongoCollection<PackaginTypes> packaginTypes;
        private readonly IMongoCollection<Receivers> receivers;
        private readonly IMongoCollection<Shipments> shipments;
        private readonly IMongoCollection<CustomerOrders> customerOrders;

        public BOLService(IConfiguration configuration, ICustomerOderService customerOderService, IShipmentSerivice shipmentSerivice)
        {
            this.configuration = configuration;
            this.customerOderService = customerOderService;
            this.shipmentSerivice = shipmentSerivice;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            bols = database.GetCollection<Bols>("BOLs");

            packaginTypes = database.GetCollection<PackaginTypes>("packaginTypes");
            receivers = database.GetCollection<Receivers>("receivers");
            shipments = database.GetCollection<Shipments>("shipments");
            customerOrders = database.GetCollection<CustomerOrders>("customerOrders");
        }

        public IList<Bols> GetAll()
        {
            try
            {
                var result = bols.Find(m => true).ToList();
                result.ForEach(c => c.PackaginType = packaginTypes.AsQueryable().Where(x => c.PackaginType.Id == x.Id).FirstOrDefault());
                result.ForEach(c => c.Receiver = receivers.AsQueryable().Where(x => c.Receiver.Id == x.Id).FirstOrDefault());
                result.ForEach(c => c.Shipment = shipmentSerivice.Find(
                    shipments
                    .AsQueryable()
                    .Where(x => c.Shipment.Id == x.Id)
                    .FirstOrDefault()
                    .Id)
                );
                result.ForEach(c => c.CustomerOrders = customerOderService.GetAll().Where(x => c.CustomerOrders.Any(y => x.Id == y.Id)).ToList());
                return result;
                //return bols.Find(m => true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Bols Find(string id)
        {
            try
            {
                var result = bols.Find(m => m.Id == id).FirstOrDefault();
                result.PackaginType = packaginTypes.AsQueryable().Where(x => result.PackaginType.Id == x.Id).FirstOrDefault();
                result.Receiver = receivers.AsQueryable().Where(x => result.Receiver.Id == x.Id).FirstOrDefault();
                result.Shipment = shipmentSerivice.Find(result.Shipment.Id); // return receiver with childs nodes
                //result.(c => c.CustomerOrders = customerOderService.GetAll().Where(x => c.CustomerOrders.Any(y => x.Id == y.Id)).ToList());
                result.CustomerOrders = customerOderService.GetAll().Where(x => result.CustomerOrders.Any(y => x.Id == y.Id)).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bols Add(Bols model)
        {
            try
            {
                bols.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Bols model)
        {
            try
            {
                var result = bols.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = bols.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
