namespace Demo.Services
{
    using Demo.MyModels;
    using Demo.Services.Interfaces;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
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
                using (var context = new DemodbContext())
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
                using (var context = new DemodbContext())
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
                using (var context = new DemodbContext())
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
                using (var context = new DemodbContext())
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
                using (var context = new DemodbContext())
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
