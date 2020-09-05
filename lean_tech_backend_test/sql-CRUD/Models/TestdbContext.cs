using Microsoft.EntityFrameworkCore;

namespace sql_CRUD.MyModels
{
    public partial class TestdbContext : DbContext
    {
        public TestdbContext()
        {
        }

        public TestdbContext(DbContextOptions<TestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bols> Bols { get; set; }
        public virtual DbSet<Carriers> Carriers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PackaginTypes> PackaginTypes { get; set; }
        public virtual DbSet<Receivers> Receivers { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<Shipments> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Test;Trusted_Connection=True;");
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
