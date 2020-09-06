namespace sql_CRUD.Core
{
    using Microsoft.Extensions.Configuration;
    using sql_CRUD.MyModels;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class CarrierService : ICarrierService
    {
        private readonly IConfiguration configuration;

        public CarrierService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IList<Carrier> GetAll()
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var carrier = context.Carriers.ToList();
                    return carrier;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(Carrier model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.Carriers.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Carrier model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    context.Update(model);
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
                    var carrier = context.Carriers.Where(c => c.Id == id).FirstOrDefault();
                    context.Carriers.Remove(carrier);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carrier Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var carrier = context.Carriers.Where(c => c.Id == id).FirstOrDefault();
                    return carrier;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
