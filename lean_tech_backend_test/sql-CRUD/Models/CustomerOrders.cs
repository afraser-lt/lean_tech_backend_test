using System;
using System.Collections.Generic;

namespace sql_CRUD.MyModels
{
    public class CustomerOrders
    {
        public int Id { get; set; }
        public Customers Customer { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
