namespace sql_CRUD.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly IConfiguration configuration;
        private readonly ICustomerService customerService;

        public OrderService(IConfiguration configuration, ICustomerService customerService)
        {
            this.configuration = configuration;
            this.customerService = customerService;
        }

        public IList<Order> GetAll()
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    //var orders = context.Orders.ToList();
                    var orders = context.Orders
                                .Include(d => d.Customer)
                                .ToList();

                    //orders.ForEach(c => c.Customer = customerService.GetAll().AsQueryable().Where(x => c.Customer.Id == x.Id).FirstOrDefault());
                    return orders;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Order Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var order = context.Orders
                               .Include(d => d.Customer)
                               .Where(c => c.Id == id).FirstOrDefault();
                    //var order = GetAll().Where(c => c.Id == id).FirstOrDefault();
                    return order;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Add(Order model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    context.Entry(model).State = EntityState.Added;
                    var result = context.SaveChanges();//context.Shipments.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Order model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    context.Entry(model).State = EntityState.Modified;
                    var result = context.SaveChanges();//context.Shipments.Add(model);
                    return context.SaveChanges();
                    /*
                    var order = context.Orders.Update(model);
                    return context.SaveChanges();
                    */
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
    }
}
