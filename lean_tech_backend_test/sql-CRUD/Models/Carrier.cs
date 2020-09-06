using System;
using System.Collections.Generic;

namespace sql_CRUD.MyModels
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Scac { get; set; }
        public long Mc { get; set; }
        public long Dot { get; set; }
        public long Fein { get; set; }
        //public decimal Rate { get; set; }
    }
}
