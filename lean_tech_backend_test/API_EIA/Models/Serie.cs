using System.Collections.Generic;

namespace API_EIA.Models
{
    public class Serie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public string F { get; set; }
        public string UnitsShort { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public string Source { get; set; }
        public string Iso3166 { get; set; }
        public string Geography { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Updated { get; set; }
        public ICollection<Data> Data { get; set; }
    }

    public class Data
    {
        public string data1 { get; set; }
        public decimal data2 { get; set; }
    }
}
