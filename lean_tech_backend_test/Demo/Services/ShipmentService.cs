using Demo.MyModels;
using Demo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Demo.Services
{
    public class ShipmentService : IShipmentSerivice
    {
        private readonly IConfiguration configuration;
        private readonly ICarrierService carrierService;

        public ShipmentService(IConfiguration configuration, ICarrierService carrierService)
        {
            this.configuration = configuration;
            this.carrierService = carrierService;
        }

        public IList<Shipment> GetAll()
        {
            try
            {
                using (var context = new DemodbContext())
                {
                    var shipment = context.Shipments.ToList();
                    return shipment;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(Shipment model)
        {
            try
            {
                using (var context = new DemodbContext())
                {
                    //context.Entry(model).State = EntityState.Added;
                    var result = context.SaveChanges();//context.Shipments.Add(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Shipment Find(int id)
        {
            try
            {
                using (var context = new DemodbContext())
                {
                    var shipment = context.Shipments.Where(c => c.Id == id).FirstOrDefault();

                    return shipment;
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
                    var shipment = context.Shipments.Where(c => c.Id == id).FirstOrDefault();
                    context.Shipments.Remove(shipment);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Shipment model)
        {
            try
            {
                using (var context = new DemodbContext())
                {
                    //context.Entry(model).State = EntityState.Added;
                    context.Update(model);
                    //var shipment = context.Shipments.Update(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Import(List<Shipment> model)
        {
            try
            {
                using (var context = new DemodbContext())
                {
                    //context.Entry<List<Shipment>>(model).State = EntityState.Added;
                    context.AddRangeAsync(model);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find data by criteria in shipments table
        /// </summary>
        /// <param name="q">Words</param>
        /// <param name="date">Date</param>
        /// <returns>IList<Shipments></returns>
        public IList<Shipment> FindByCriteria(string q, DateTime? date)
        {
            try
            {
                using (var context = new DemodbContext())
                {
                    // todo: separate terms by space
                    var words = q.Split(' ').Select(w => w = $"\"{w}\"").ToList();
                    var result = String.Join(" OR ", words.ToArray());

                    var dateFiter = (date != null) ? $" CONVERT(DATE,[Date]) = '{date}' AND" : "";

                    // Note: Must have installed full-text search on the database and created the catalog for each table column
                    var query = $"SELECT * FROM dbo.shipments WHERE {dateFiter} CONTAINS(*, '{result}');";
                    var shipments = context.Shipments.FromSqlRaw(query).ToList();
                    return shipments;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
