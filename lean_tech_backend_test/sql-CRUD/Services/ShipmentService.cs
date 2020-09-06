using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sql_CRUD.MyModels;
using sql_CRUD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace sql_CRUD.Core
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
                using (var context = new TestdbContext())
                {
                    var shipment = context.Shipments
                                .Include(d => d.Carrier)
                                //.ThenInclude(s => s.Employee)
                                //.Include(d => d.DocType)
                                //.OrderBy(d => d.DocType.Name)
                                .ToList();

                    //var shipment = context.Shipments.ToList();
                    //shipment.ForEach(c => c.Carrier = carrierService.GetAll().AsQueryable().Where(x => c.Carrier.Id == x.Id).FirstOrDefault());
                    //context.Carriers.ToList().ForEach(c => c = carrierService.GetAll().AsQueryable().Where(x => c.Id == x.Id).FirstOrDefault());
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

        public Shipment Find(int id)
        {
            try
            {
                using (var context = new TestdbContext())
                {
                    var shipment = context.Shipments
                                .Include(d => d.Carrier)
                                .Where(c => c.Id == id).FirstOrDefault();

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
                using (var context = new TestdbContext())
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
                using (var context = new TestdbContext())
                {
                    context.Entry(model).State = EntityState.Added;
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
                using (var context = new TestdbContext())
                {
                    // todo: separate terms by space
                    var words = q.Split(' ').Select(w => $"'\"{w}\"'" + " AND ").ToString();

                    var dateFiter = (date != null) ? $" Date = N'{date}' AND" : "";

                    // Note: Must have installed full-text search on the database and created the catalog for each table column
                    var shipments = context.Shipments.FromSqlRaw($"SELECT * FROM dbo.shipments WHERE {dateFiter} CONTAINS(*, {words});").ToList();
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
