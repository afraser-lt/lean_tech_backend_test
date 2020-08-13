using sql_CRUD.Models;
using System.Collections.Generic;

namespace sql_CRUD.Services.Interfaces
{
    public interface ICarrierService
    {
        public IList<CarrierViewModel> GetCarriers(int? id = null);
        public int AddCarrier(CarrierViewModel carrier, int? id = null);
        public int RemoveCarrier(int id);
    }
}
