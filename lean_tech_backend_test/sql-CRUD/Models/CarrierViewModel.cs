using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Models
{
    public class CarrierViewModel
    {
        public int? Id { get; set; }
        public string SCAC { get; set; }
        public string Name { get; set; }
        public int? MC { get; set; }
        public int? DOT { get; set; }
        public int? FEIN { get; set; }
    }
}
