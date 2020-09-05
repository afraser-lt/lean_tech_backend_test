namespace sql_CRUD.Core
{
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.Models;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly IConfiguration configuration;

        public OrderService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IList<Orders> GetAll()
        {
            try { 
                using (var context = new TestdbContext())
                {
                    var order = context.Orders.ToList();
                    return order;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(Orders model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.Orders.Add(model);
                    return context.SaveChanges();
                }
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
                using (var context = new TestdbContext())
                {
                    var order = context.Orders.Update(model);
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
                    var order = context.Orders.Where(c => c.Id == id).FirstOrDefault();
                    context.Orders.Remove(order);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Orders Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var order = context.Orders.Where(c => c.Id == id).FirstOrDefault();
                    return order;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
