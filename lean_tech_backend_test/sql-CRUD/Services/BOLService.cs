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

    public class BOLService : IBOLService
    {
        private readonly IConfiguration configuration;

        public BOLService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IList<Bols> GetAll()
        {
            try { 
                using (var context = new TestdbContext())
                {
                    var bol = context.Bols.ToList();
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
                    var result = context.Bols.Add(model);
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
                    var bol = context.Bols.Update(model);
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
                    var bol = context.Bols.Where(c => c.Id == id).FirstOrDefault();
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
                    var bol = context.Bols.Where(c => c.Id == id).FirstOrDefault();
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
