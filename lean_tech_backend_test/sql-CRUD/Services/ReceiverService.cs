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

    public class ReceiverService : IReceiverService
    {
        private readonly IConfiguration configuration;

        public ReceiverService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IList<Receivers> GetAll()
        {
            try { 
                using (var context = new TestdbContext())
                {
                    var receiver = context.Receivers.ToList();
                    return receiver;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(Receivers model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var result = context.Receivers.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Receivers model)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var receiver = context.Receivers.Update(model);
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
                    var receiver = context.Receivers.Where(c => c.Id == id).FirstOrDefault();
                    context.Receivers.Remove(receiver);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Receivers Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var receiver = context.Receivers.Where(c => c.Id == id).FirstOrDefault();
                    return receiver;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
