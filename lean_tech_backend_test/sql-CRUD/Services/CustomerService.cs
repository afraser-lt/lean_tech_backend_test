using Microsoft.Extensions.Configuration;
using sql_CRUD.MyModels;
using sql_CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace sql_CRUD.Core
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration configuration;
        private readonly ICarrierService carrierService;

        public CustomerService(IConfiguration configuration, ICarrierService carrierService)
        {
            this.configuration = configuration;
            this.carrierService = carrierService;
        }

        public int Add(Customer model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.Customers.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                    return customer;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Customer> GetAll()
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var customer = context.Customers.ToList();
                    return customer;
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
                    var customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                    context.Customers.Remove(customer);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Customer model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    //var customer = context.Customers.Update(model);
                    context.Update(model);
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
