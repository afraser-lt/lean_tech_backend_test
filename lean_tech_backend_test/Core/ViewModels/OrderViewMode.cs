using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Models
{
    public class OrderViewModel
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public int Packages { get; set; }
        public decimal Weight { get; set; }
        public bool Pallet { get; set; }
        public bool Slip { get; set; }
        public string ShipperInfo { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}
