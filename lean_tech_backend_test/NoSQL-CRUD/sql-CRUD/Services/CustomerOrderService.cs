namespace nosql_CRUD.Services
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using nosql_CRUD.Models;
    using nosql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerOrderService : ICustomerOderService
    {
        private readonly IConfiguration configuration;
        private readonly IOrderService orderService;
        private readonly IMongoCollection<CustomerOrders> customerOrders;
        private readonly IMongoCollection<Customers> customers;
        private readonly IMongoCollection<Orders> orders;

        public CustomerOrderService(IConfiguration configuration, IOrderService orderService)
        {
            this.configuration = configuration;
            this.orderService = orderService;
            MongoClient client = new MongoClient(configuration["MongoConnectionString"]);
            IMongoDatabase database = client.GetDatabase("test");
            customerOrders = database.GetCollection<CustomerOrders>("customerOrders");
            customers = database.GetCollection<Customers>("customers");
            orders = database.GetCollection<Orders>("orders");
        }

        public IList<CustomerOrders> GetAll()
        {
            try
            {
                var _orders = orders.AsQueryable().ToList();

                var result = (from customerOrder in customerOrders.AsQueryable()
                        join customer in customers.AsQueryable() on customerOrder.Customer.Id equals customer.Id
                        select new CustomerOrders()
                        {
                            Id = customerOrder.Id,
                            Customer = customer,
                            Orders = customerOrder.Orders
                        }).ToList();

                // get customerOrders in orders
                result.ForEach(c => c.Orders = _orders.Where(x => c.Orders.Any(y => x.Id == y.Id)).ToList());

                return result;
                //return customerOrders.Find(m => true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public CustomerOrders Find(string id)
        {
            try
            {
                var _orders = orders.AsQueryable().ToList();

                var result = (from customerOrder in customerOrders.AsQueryable()
                              //where customerOrder.Id == id
                              join customer in customers.AsQueryable() on customerOrder.Customer.Id equals customer.Id
                              where customerOrder.Id == id
                              select new CustomerOrders()
                              {
                                  Id = customerOrder.Id,
                                  Customer = customer,
                                  Orders = customerOrder.Orders
                              }).FirstOrDefault();

                // get customerOrders in orders
                //result.Orders.ForEach(c => c = orderService.Find(c.Id));
                result.Orders = _orders.Where(x => result.Orders.Any(y => x.Id == y.Id)).ToList();

                return result;
                //return customerOrders.Find(m => m.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CustomerOrders Add(CustomerOrders model)
        {
            try
            {
                customerOrders.InsertOne(model);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(CustomerOrders model)
        {
            try
            {
                var result = customerOrders.ReplaceOne(m => m.Id == model.Id, model);
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
                var result = customerOrders.DeleteOne(m => m.Id == id);
                return int.Parse(result.DeletedCount.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
