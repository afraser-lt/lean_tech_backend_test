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

    public class PackaginType : IPackaginTypeService
    {
        private readonly IConfiguration configuration;

        public PackaginType(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IList<PackaginTypes> GetAll()
        {
            try { 
                using (var context = new TestdbContext())
                {
                    var packaginType = context.PackaginTypes.ToList();
                    return packaginType;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(PackaginTypes model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.PackaginTypes.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(PackaginTypes model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var packaginType = context.PackaginTypes.Update(model);
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
                    var packaginType = context.PackaginTypes.Where(c => c.Id == id).FirstOrDefault();
                    context.PackaginTypes.Remove(packaginType);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PackaginTypes Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var packaginType = context.PackaginTypes.Where(c => c.Id == id).FirstOrDefault();
                    return packaginType;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
