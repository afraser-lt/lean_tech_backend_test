using Demo.MyModels;
using System;
using System.Collections.Generic;

namespace Demo.Services.Interfaces
{
    public interface IShipmentSerivice : IGeneralService<Shipment>
    {
        IList<Shipment> FindByCriteria(string q, DateTime? date);
        int Import(List<Shipment> shipments);
    }
}
