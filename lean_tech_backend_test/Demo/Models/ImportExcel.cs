using Microsoft.AspNetCore.Http;

namespace Demo.Models
{
    public class ImportExcel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
