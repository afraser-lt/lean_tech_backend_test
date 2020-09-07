using Microsoft.EntityFrameworkCore;

namespace Demo.MyModels
{
    public partial class DemodbContext : DbContext
    {
        public DemodbContext()
        {
        }

        public DemodbContext(DbContextOptions<DemodbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Demo;Trusted_Connection=True;");
            /*
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Testdb;Trusted_Connection=True;");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
