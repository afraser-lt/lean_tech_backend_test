using sql_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Services.Interfaces
{
    public interface IShipmentSerivice
    {
        public IList<ShipmentViewModel> GetShipments(int? id = null);
        public string AddShipment(ShipmentViewModel shipment, int? id = null);

        public string RemoveShipment(int id);

        public IList<ShipmentViewModel> Search(string q, string date = null);
    }
}
