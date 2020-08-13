namespace sql_CRUD.Core
{
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using sql_CRUD.Models;
    using sql_CRUD.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ShipmentService : IShipmentSerivice
    {
        private readonly IConfiguration configuration;
        private readonly IList<string> contextualConnectors = new List<string>() { 
            "and","&","for","so","because","or","plus","furthermore","moreover","In addition","also","as","as well as","when","what","who","witch"
        };

        public ShipmentService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public string AddShipment(ShipmentViewModel shipment, int? id = null)
        {
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var shipments = database.GetCollection<ShipmentViewModel>("shipments");

                // Update
                if (id != null)
                {
                    var _shipment = GetShipments(id).FirstOrDefault();
                    if (_shipment != null)
                    {
                        var filter = Builders<ShipmentViewModel>.Filter.Eq("Id", id);
                        var update = Builders<ShipmentViewModel>.Update
                        .Set("CARRIER_ID", shipment.Carrier_Id ?? _shipment.Carrier_Id)
                        .Set("DATE", shipment.Date ?? _shipment.Date)
                        .Set("ORIIGN_COUNTRY", shipment.Oriign_Country ?? _shipment.Oriign_Country)
                        .Set("ORIGIN_STATE", shipment.Origin_State ?? _shipment.Origin_State)
                        .Set("ORIGIN_CITY", shipment.Origin_City ?? _shipment.Origin_City)
                        .Set("DESTINATION_COUNTRY", shipment.Destination_Country ?? _shipment.Destination_Country)
                        .Set("DESTINATION_STATE", shipment.Destination_State ?? _shipment.Destination_State)
                        .Set("DESTINATION_CITY", shipment.Destination_City ?? _shipment.Destination_City)
                        .Set("PICKUP_DATE", shipment.Pickup_Date ?? _shipment.Pickup_Date)
                        .Set("DELIVERY_DATE", shipment.Delivery_Date ?? _shipment.Delivery_Date)
                        .Set("STATUS", shipment.Status ?? _shipment.Status)
                        .Set("CARRIER_RATE", shipment.Carrier_Rate ?? _shipment.Carrier_Rate);
                        var result = shipments.UpdateOne(filter, update);
                        return result.ModifiedCount > 0 ? "Shipment Updated" : "Shipment not found";
                    }
                    else
                    {
                        throw new Exception("The Shiptment doesn't exists");
                    }
                }
                // Create
                else
                {
                    // Return the max id 
                    int maxId = (int)shipments.Find(x => true).SortByDescending(d => d.Id).Limit(1).FirstOrDefaultAsync().Result.Id;
                    shipment.Id = maxId + 1;
                    shipments.InsertOne(shipment);
                    return $"Shiptment ID:{shipment.Id} Added";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<ShipmentViewModel> GetShipments(int? id = null)
        {
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var shipmentsCollection = database.GetCollection<ShipmentViewModel>("shipments");

                // Find a specific document with a filter
                if (id != null)
                {
                    var filter = Builders<ShipmentViewModel>.Filter.Eq("Id", id);
                    var shipments = shipmentsCollection.Find(filter).ToList();
                    return shipments;
                }
                else
                {
                    var shipments = shipmentsCollection.Find(new BsonDocument()).ToList();
                    return shipments;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string RemoveShipment(int id)
        {
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var shipmentsCollection = database.GetCollection<ShipmentViewModel>("shipments");

                var filter = Builders<ShipmentViewModel>.Filter.Eq("Id", id);
                var result = shipmentsCollection.DeleteOne(filter);
                return result.DeletedCount > 0 ? "Shipment Deleted" : "Shipment not found";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipmentsCollection"></param>
        public void CreateIndexs(ref IMongoCollection<ShipmentViewModel> shipmentsCollection)
        {
            var indexOptions = new CreateIndexOptions();

            var indexKeysDefinition = Builders<ShipmentViewModel>.IndexKeys;
            var l = new List<CreateIndexModel<ShipmentViewModel>>();

            //shipmentsCollection.ToBsonDocument<ShipmentViewModel>().Elements.Aggregate(x => x.ToBsonDocument().GetValue);

            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Carrier_Id)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Carrier_Rate)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Date)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Delivery_Date)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Destination_City)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Destination_Country)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Destination_State)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Origin_City)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Origin_State)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Oriign_Country)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Pickup_Date)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Status)));
            l.Add(new CreateIndexModel<ShipmentViewModel>(indexKeysDefinition.Text(x => x.Destination_State)));

            var result = shipmentsCollection.Indexes.CreateMany(l);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public IList<ShipmentViewModel> Search(string q, string date = null)
        {
            try
            {
                MongoClient dbClient = new MongoClient(configuration["MongoConnectionString"]);
                var database = dbClient.GetDatabase(configuration["Database"]);
                var shipmentsCollection = database.GetCollection<ShipmentViewModel>("shipments");

                // Verify is there are text index created
                var indexes = shipmentsCollection.Indexes.List().ToList();
                if(indexes.Count <= 1)
                {
                    CreateIndexs(ref shipmentsCollection);
                }

                // Find a specific document with a filter
                if (q != null)
                {
                    var filter = Builders<ShipmentViewModel>.Filter.Text(q);
                    var shipments = shipmentsCollection.Find(filter).ToList<ShipmentViewModel>();
                    return shipments;
                }
                else
                {
                    var shipments = shipmentsCollection.Find(new BsonDocument()).ToList();
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
