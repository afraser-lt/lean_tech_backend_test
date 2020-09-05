using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Models
{
    public class PackaginTypeViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal? Length { get; set; }
        public string Description { get; set; }
    }
}
