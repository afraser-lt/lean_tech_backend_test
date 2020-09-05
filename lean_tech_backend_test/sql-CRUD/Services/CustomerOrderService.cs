namespace sql_CRUD.Core
{
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class CustomerOrderService : ICustomerOderService
    {
        private readonly IConfiguration configuration;

        public CustomerOrderService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IList<CustomerOrders> GetAll()
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipmentOrder = context.CustomerOrders.ToList();
                    return shipmentOrder;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(CustomerOrders model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.CustomerOrders.Add(model);
                    return context.SaveChanges();
                }
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
                using (var context = new TestdbContext())
                {
                    var shipmentOrder = context.CustomerOrders.Update(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Remove(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipmentOrder = context.CustomerOrders.Where(c => c.Id == id).FirstOrDefault();
                    context.CustomerOrders.Remove(shipmentOrder);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CustomerOrders Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipmentOrder = context.CustomerOrders.Where(c => c.Id == id).FirstOrDefault();
                    return shipmentOrder;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
