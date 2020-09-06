using System;
using System.Collections.Generic;

namespace sql_CRUD.MyModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Packages { get; set; }
        public decimal Weight { get; set; }
        public bool Pallet { get; set; }
        public bool Slip { get; set; }
        public string ShippperInfo { get; set; }
        public Customer Customer { get; set; }
    }
}
