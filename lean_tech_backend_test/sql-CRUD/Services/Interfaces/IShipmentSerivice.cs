using Microsoft.AspNetCore.Mvc;
using sql_CRUD.MyModels;
using System;
using System.Collections.Generic;

namespace sql_CRUD.Services.Interfaces
{
    public interface IShipmentSerivice : IGeneralService<Shipment>
    {
        IList<Shipment> FindByCriteria(string q, DateTime? date);
    }
}
