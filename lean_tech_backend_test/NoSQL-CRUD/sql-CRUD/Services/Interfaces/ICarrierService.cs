namespace sql_CRUD.Services.Interfaces
{
    using sql_CRUD.Models;
    using System.Collections.Generic;

    public interface ICarrierService
    {
        public IList<CarrierViewModel> GetCarriers(int? id = null);
        public string AddCarrier(CarrierViewModel carrier, int? id = null);
        public string RemoveCarrier(int id);
    }
}
