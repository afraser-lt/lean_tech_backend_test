namespace sql_CRUD.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class BOLService : IBOLService
    {
        private readonly IConfiguration configuration;
        private readonly IOrderService orderService;

        public BOLService(IConfiguration configuration, IOrderService orderService)
        {
            this.configuration = configuration;
            this.orderService = orderService;
        }

        public IList<Bols> GetAll()
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var bol = context.Bols
                               .Include(d => d.PackaginType)
                               .Include(d => d.Receiver)
                               .Include(d => d.Shipment)
                               //.Include(d => d.Orders/*.Select(q => q.Customer)*/)
                               .Include("Orders.Customer") //include sub collections
                               .ToList();
                    return bol;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(Bols model)
        {
            try
            {
                using (var context = new TestdbContext())
                {

                    context.Entry(model).State = EntityState.Added;
                    var orders = orderService.GetAll().Where(x => model.Orders.Any(y => x.Id == y.Id)).ToList();
                    model.Orders = orders;
                    var result = context.Add(model);
                    context.SaveChanges();
                    
                    return context.SaveChanges();
                }
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
                using (var context = new TestdbContext())
                {
                    context.Entry(model).State = EntityState.Added;
                    var orders = orderService.GetAll().Where(x => model.Orders.Any(y => x.Id == y.Id)).ToList();
                    model.Orders = orders;
                    context.Bols.Update(model);
                    //var bol = context.Bols.Update(model);
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
                    //var bol = context.Bols.Where(c => c.Id == id).FirstOrDefault();
                    var bol = context.Bols.Include(b => b.Orders).Where(c => c.Id == id).FirstOrDefault();
                    context.Bols.Remove(bol);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Bols Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var bol = context.Bols
                               .Include(d => d.PackaginType)
                               .Include(d => d.Receiver)
                               .Include(d => d.Shipment)
                               //.Include(d => d.Orders/*.Select(q => q.Customer)*/)
                               .Include("Orders.Customer") //include sub collections
                               .Where(c => c.Id == id).FirstOrDefault();
                    return bol;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
