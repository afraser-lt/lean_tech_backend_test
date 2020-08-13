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
        public int AddShipment(ShipmentViewModel shipment, int? id = null);
        public int RemoveShipment(int id);
    }
}
